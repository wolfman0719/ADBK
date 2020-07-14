Attribute VB_Name = "AutoInstall"
Option Explicit
Dim TheFile As String, failed As Boolean, title As String
Public Function Install(ProductTitle, _
                        VisM1 As VisM, _
                        ParamArray Steps())
    ' ProductTitle appears in the MsgBoxes
    ' Vism1 is the Vism object to use to communicate with the server
    ' Steps is an array of arguments made up of steps
    ' Each Step consists of exactly 5 arguments :
    '    Format,Description,Namespace,Test,File
    '        where Format is "OBJ", "INT", "MAC", "INC", "GLO" or "RUN"
    '                   "OBJ" means Cache ^%ROMF format
    '                   "INT", "MAC", and "INC" mean Cache ^%RO format
    '                   "GLO" means Cache ^%GO format
    '                   "RUN" means execute a piece of code
    '              Description will be displayed to the user to confirm loading, as
    '                   "Load <Description> into <Namespace> Namespace" or
    '                   "Run <Description> in <Namespace> Namespace"
    '              Namespace is target namespace (null=current)
    '              Test is a piece of Cachescript to run on server in Namespace.
    '                   Returns  0 if the correct version of this file is already installed,
    '                           >0 if installation is needed
    '              File is file spec (full path or defaults to current directory)
    '                   or code to run
    ' Function returns sucess status.  Partial install counts as failure
    
    Dim Format() As String, Description() As String, Namespace() As String
    Dim Test() As String, File() As String
    
    Dim oldnamespace As String, rf As String, message As String
    Dim instruct As String, nsp As String
    Dim filenum As Integer, i As Integer, StepCount As Integer
    Dim prog As String
    Dim processed As Integer, declined As Integer
    Dim skipped As Integer
    
    title = "AutoInstall for  : " & ProductTitle
    
    ' Calculate StepCount
    StepCount = (UBound(Steps) + 1) \ 5
    If (UBound(Steps) + 1) Mod StepCount <> 0 Then
        MsgBox "Invalid number of arguments to Install", , title
        Install = False
        Exit Function
    End If
    
    ' Load the arrays from the Steps parameters
    ReDim Format(StepCount)
    ReDim Description(StepCount)
    ReDim Namespace(StepCount)
    ReDim Test(StepCount)
    ReDim File(StepCount)
    For i = 1 To StepCount
        Format(i) = Steps((i - 1) * 5 + 0)
        Description(i) = Steps((i - 1) * 5 + 1)
        Namespace(i) = Steps((i - 1) * 5 + 2)
        Test(i) = Steps((i - 1) * 5 + 3)
        File(i) = Steps((i - 1) * 5 + 4)
    Next i
    
    processed = 0
    declined = 0
    skipped = 0
    failed = False
    oldnamespace = VisM1.Namespace
    
    For i = 1 To StepCount
    
        ' run the test
        VisM1.Namespace = Namespace(i)
        VisM1.Code = "s VALUE=" & Test(i)
        VisM1.ExecFlag = 1
        If VisM1.Error Then
            MsgBox VisM1.ErrorName, , title
            GoTo GoBack
        End If
        If Val(VisM1.Value) = 0 Then ' nothing to do here
            skipped = skipped + 1
            GoTo NextStep
        End If
    
        'Confirm with the user
        nsp = Namespace(i)
        If nsp = "" Then nsp = "current"
        If UCase(Format(i)) = "RUN" Then
            message = "Run " & Description(i) & " in " & nsp & " Namespace"
        Else
            message = "Load " & Description(i) & " into " & nsp & " Namespace"
        End If
        If MsgBox(message, 4, title) = 7 Then ' user declined
            declined = declined + 1
            GoTo NextStep
        End If
        
        processed = processed + 1
        TheFile = File(i)
        ' dispatch according to file type
        Select Case UCase(Format(i))
            Case "GLO"
                LoadGlobal VisM1
            Case "OBJ"
                LoadObject VisM1
            Case "INT"
                LoadRoutine VisM1
            Case "MAC"
                LoadRoutine VisM1
            Case "INC"
                LoadRoutine VisM1
            Case "RUN"
                RunCode VisM1
        End Select
        
        If failed Then Exit For
        
NextStep:
    Next
    
    If failed Then
        MsgBox "Installation failed", , title
    Else
        If skipped = StepCount Then ' silent
        Else
            If processed = StepCount Then
                MsgBox "Installation successful", , title
            Else
                If (processed + skipped) = StepCount Then
                    MsgBox "Installation completed successfully", , title
                Else
                    MsgBox "Partial installation. Please finish later", , title
                    failed = True
                End If
            End If
        End If
    End If
    
GoBack:
    VisM1.Namespace = oldnamespace
    
    If failed Then
        Install = False
    Else
        Install = True
    End If
End Function
Private Sub LoadGlobal(VisM1 As VisM)
    ' ^%GO format :
    '    rec 1  :  description
    '    rec 2  :  date saved
    '    rec 3,5,7,...  :  global node
    '    rec 4,6,8,...  :  data
    '    rec n  : null string
    '    <eof>
    Dim descriptionline As String, dateline As String
    Dim textline As String, m As String
    Dim filenum As Integer
    
    ' open the file
    filenum = FreeFile
    On Error GoTo FileOpenError
    Open TheFile For Input As filenum
    On Error GoTo HandleError
    
    
    m = ""
    Line Input #filenum, descriptionline
    Line Input #filenum, dateline
    Line Input #filenum, textline
    While textline <> ""
        If m <> "" Then m = m & vbCrLf
        m = m & "set " & textline
        Line Input #filenum, textline
        m = m & "=" & quoted(textline)
        If Len(m) > 15000 Then
            sendplist m, VisM1
            m = ""
        End If
        Line Input #filenum, textline
    Wend
    sendplist m, VisM1
    
CloseFile:
    Close filenum
    Exit Sub
HandleError: ' error occurred after opening file
    UnexpectedError
    GoTo CloseFile
FileOpenError: ' error while opening the file
    FileError
End Sub
Private Sub LoadObject(VisM1 As VisM)
    ' ^%ROMF format :
    '     bytes 0-256       header (format info, comment, etc - not checked !)
    '           257-275     date - not checked
    '           277-277     volume number (this Sub only handles single volume)
    '           278         routine name length (rnl).  Zero if no more routines
    '           279-278+rnl routine name
    '           278+rnl-x   padding to 4-byte boundary, if needed
    '           x+1-x+4     object code length (binary)
    '           x+5-x+2052  object code block (2048 bytes)
    '            ...        ... repeat
    '           y-y+z       trailing bytes of object code
    '           a+278       routine name length (rnl)
    '           a+279-      routine name
    Dim filenum As Integer
    Dim fileheader As String, filedate As String, filevol As String
    Dim namelength As String, namelengthint As Integer
    Dim routinename As String, pad As String
    Dim ol As String, objlen As Long, i As Long
    Dim obj As String, m As String
    
    ' open the file
    filenum = FreeFile
    On Error GoTo FileOpenError
    Open TheFile For Binary Access Read As filenum
    On Error GoTo HandleError

    ' get header
    fileheader = Input(256, filenum)
    filedate = Input(18, filenum)
    filevol = Input(2, filenum)

    ' get routine name
    namelength = Input(1, filenum)
    namelengthint = Asc(namelength)
    
    ' repeat until no more routines
    While namelengthint > 0
    
        routinename = Input(namelengthint, filenum)
        If ((31 - namelengthint) Mod 4) Then
            pad = Input((31 - namelengthint) Mod 4, filenum)
        End If
    
        ' get length of object code
        ol = Input(4, filenum)
        objlen = ((Asc(Mid(ol, 4)) * 256 + Asc(Mid(ol, 3))) * 256 + Asc(Mid(ol, 2))) _
                    * 256 + Asc(ol)
    
        ' get object code
        obj = ""
        If (objlen Mod 2048) Then obj = Input(objlen Mod 2048, filenum)
        For i = (objlen Mod 2048) + 1 To objlen Step 2048
            obj = obj & Input(2048, filenum)
        Next
    
        ' build a plist to send to Cache
        m = "s ^rOBJ(""" & routinename & """)=P0" & vbCrLf
        m = m & "k ^ROUTINE(""" & routinename & """)"
        VisM1.P0 = obj
        sendplist m, VisM1
    
        ' get next routine name length
        namelength = Input(1, filenum)
        namelengthint = Asc(namelength)
    
    Wend
    
CloseFile:
    Close filenum
    Exit Sub
HandleError: ' error occurred after opening file
    UnexpectedError
    GoTo CloseFile
FileOpenError: ' error while opening the file
    FileError
End Sub
Private Sub LoadRoutine(VisM1 As VisM)
    ' This routine handles MAC, INC and INT, any mixture of these, except that
    '  INC's must precede the MAC's that use them !
    '
    ' ^%RO format :
    '    rec 1    :  Title^<rf>^description  (ignored)
    '    rec 2    :  %RO on date            (ignored)
    '    rec 3    :  Test.<rf>.1.57039,33072
    '    rec 4-n  :  lines of routine
    '    rec n+1  :  null string
    '    rec m    :  Test2.<rf>.1.57039,33072
    '    rec m+1-p:  lines of routine
    '    rec p+1  :  null string
    '    rec p+2  :  null string
    '    <eof>
    Dim descriptionline As String, dateline As String
    Dim textline As String, routinename As String, routinedollarh As String
    Dim gloref As String, nakedref As String, m As String
    Dim filenum As Integer, linect As Long, routinetype As String
    
    ' open the file
    filenum = FreeFile
    On Error GoTo FileOpenError
    Open TheFile For Input As filenum
    On Error GoTo HandleError
    
    ' load the description and date header lines
    Line Input #filenum, descriptionline
    Line Input #filenum, dateline
        
    ' load the routines
    Line Input #filenum, textline ' routine header line
    While textline <> ""
        routinename = Piece(textline, ".", 1)
        routinetype = Piece(textline, ".", 2)
        Select Case routinetype
        Case "MAC"
            gloref = "^rMAC(""" & routinename & """" ' eg ^rMAC("Test"
        Case "INC"
            gloref = "^rINC(""" & routinename & """" ' eg ^rINC("Test"
        Case "INT"
            gloref = "^ROUTINE(""" & routinename & """" ' eg ^ROUTINE("Test"
        End Select
        nakedref = gloref & ",0," ' eg ^ROUTINE("Test",0,
        routinedollarh = Piece(textline, ".", 4)
        
        m = "k " & gloref & ")"
        linect = 0 ' lines in ^ROUTINE, not in m string !
        Line Input #filenum, textline ' first line of routine
        While textline <> ""
            If textline = "." Then textline = "" ' ^%RO converts blank lines to "."
            linect = linect + 1
            If m <> "" Then m = m & vbCrLf
            m = m & "s " & nakedref & linect & ")=" & quoted(textline)
            nakedref = "^("
            If Len(m) > 15000 Then
                sendplist m, VisM1
                m = ""
                nakedref = gloref & ",0,"
            End If
            Line Input #filenum, textline ' rest of routine
        Wend
        If m <> "" Then m = m & vbCrLf
        m = m & "set " & gloref & ",0,0)=" & linect & vbCrLf
        sendplist m, VisM1
        
        ' now the line to compile the routine
        Select Case routinetype
        Case "MAC"
            m = "d COMPILE^%urcomp(""" & routinename & """,""MAC"",.x,0)"
        Case "INC"
            m = ""
        Case "INT"
            m = "d COMPILE^%urcomp(""" & routinename & """,""INT"",.x,0)"
        End Select
        
        ' and one to set the date
        m = m & " s " & gloref & ",0)=""" & routinedollarh & """"
        sendplist m, VisM1
        
        Line Input #filenum, textline
    Wend

CloseFile:
    Close filenum
    Exit Sub
HandleError: ' error occurred after opening file
    UnexpectedError
    GoTo CloseFile
FileOpenError: ' error while opening the file
    FileError
End Sub
Private Sub RunCode(VisM1 As VisM)
    ' Runs the code contained in TheFile
    
    VisM1.Code = TheFile
    VisM1.ExecFlag = 1
    If VisM1.Error Then
        MsgBox VisM1.ErrorName, , title
        failed = True
        Exit Sub
    End If
    
End Sub
Private Sub sendplist(commands As String, VisM1 As VisM)
    If commands <> "" Then
        VisM1.Code = "for i=1:1:PLIST x PLIST(i)"
        VisM1.PLIST = commands
        VisM1.ExecFlag = 1
        If VisM1.Error Then
            MsgBox VisM1.ErrorName, , title
        End If
    End If
End Sub
Private Function quoted(str As String)
    ' returns the string str within quotes, doubling as needed
    Dim x As String, out As String, i As Integer
    x = str
    out = """"
    While x <> ""
        i = InStr(x, """")
        If i = 0 Then
            out = out & x
            x = ""
        Else
            out = out & Left(x, i - 1) & """"""
            x = Right(x, Len(x) - i)
        End If
    Wend
    quoted = out & """"
End Function
Function Piece(ByVal fullstr As String, ByVal substr As String, ByVal P1 As Integer, Optional ByVal P2 As Integer)
    
' This function is supplied by InterSystems in some of their
' Visual M examples.

    Dim i As Integer    'pointer for next found substr
    Dim j As Integer    'pointer for start of next search
    Dim L As Integer    'length of substr
    Dim c As Integer    'piece counter
    Dim m1 As Integer   'beginning offset for return value
    Dim m2 As Integer   'ending offset for return value

    If P1 < 1 Then P1 = 1
    If P2 = 0 Then P2 = P1
    If P1 > P2 Then Piece = "": Exit Function

    L = Len(substr)
    m1 = Len(fullstr) + 1   'default values to use for MID$() in the end
    m2 = Len(fullstr)       'if they are never modified in the do-loop

    i = -L + 1: j = 1: c = 1
    Do
        If c = P1 Then m1 = i + L
        If c = P2 + 1 Then m2 = i - 1: Exit Do
        i = InStr(j, fullstr, substr)
        If i = 0 Then Exit Do
        j = i + L
        c = c + 1
    Loop

    Piece = Mid$(fullstr, m1, m2 - m1 + 1)

End Function
Private Sub UnexpectedError()
    MsgBox "Unexpected error : " & Error, , title
    failed = True
End Sub
Private Sub FileError()
Dim textline As String
    If Err = 53 Then ' file not found
        textline = UCase(TheFile) & "   could not be found in your current directory"
        textline = textline & vbCr & "  which is " & CurDir
        textline = textline & vbCr & "Either move the file into this directory"
        textline = textline & vbCr & "  or start the program again with the appropriate default directory"
        MsgBox textline, , title
        failed = True
    Else
        UnexpectedError
    End If
End Sub
