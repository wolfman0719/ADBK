VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "cVMClass"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
' VMCLASS.cls   CacheDirectサーバアクセスクラス
' By T.Imai 97/9/1
'           98/2/3  Wait method 追加
'           98/2/22 MServer property 追加
' H.S     1998/7/17 PrintLocalVariable
'利用法
'
'   General declarations で
'       Dim CacheDirect As New cVMClass
'
'   Form_Load イベントで
'       Set CacheDirect.VisM = Vism1
'
'   Form_Unload イベントで
'       Set CacheDirect = Nothing
'
'   Method
'       Cache 関数($... または ＝...）実行時
'           CacheDirect.Eval(Code) または CacheDirect.Evaluate(Code)
'               Function Call(帰り値あり）
'
'       M コマンド列実行時
'           CacheDirect.Exe(code) または CacheDirect.Execute(Code)
'               Subroutine Call
'       CacheDirect.Clear   P0,P1,P2,...,PLIST clear
'       CacheDirect.DebugPrint  P0,P1,P2,...,PLIST Debug window へ表示
'       CacheDirect.TimerStart CacheDirect.TimerStop M,TimerContinue
'       CacheDirect.Wait
'       CacheDirect.PLISTItem(i)
'       CacheDirect.Piece(string,substr,pos1,pos2)
'
'   Property
'       CacheDirect.NameSpace
'       CacheDirect.PDELIM
'       CacheDirect.Value
'       CacheDirect.P0,CacheDirect.P1,CacheDirect.P2,...,CacheDirect.P9
'       CacheDirect.PLIST
'       CacheDirect.Error
'       CacheDirect.ErrorName
'       CacheDirect.MouseIcon
'       CacheDirect.NoOfPLISTItem
'
'
'   例
'
'   On Error Resume Next
'   txtValue.Text = CacheDirect.Eval(txtEval.Text)
'   If Err <> 0 Then
'        ErrMsgBox
'   End If
'
'
'
'

Private m_Name, m_Code, m_Value, m_Error, m_ErrorName As String
Private m_VisM As Control
Private m_MouseIcon As Object
Private m_MousePointer As Integer
Private m_ElapseTime, m_StartTime, m_EndTime As Double

Public Sub Clear()

' VisM データ転送用プロパティの初期化

    m_VisM.P0 = ""
    m_VisM.P1 = ""
    m_VisM.P2 = ""
    m_VisM.P3 = ""
    m_VisM.P4 = ""
    m_VisM.P5 = ""
    m_VisM.P6 = ""
    m_VisM.P7 = ""
    m_VisM.P8 = ""
    m_VisM.P9 = ""
    m_VisM.PLIST = ""

End Sub


Public Sub DebugPrint()

    Debug.Print "NameSpace=" & m_VisM.Namespace
    Debug.Print "MServer=" & m_VisM.MServer
    Debug.Print "Code=" & m_VisM.Code
    Debug.Print "Value=" & m_VisM.Value
    Debug.Print "Error=" & m_VisM.Error
    Debug.Print "ErrorName=" & m_VisM.ErrorName
    Debug.Print "P0=" & m_VisM.P0
    Debug.Print "P1=" & m_VisM.P1
    Debug.Print "P2=" & m_VisM.P2
    Debug.Print "P3=" & m_VisM.P3
    Debug.Print "P4=" & m_VisM.P4
    Debug.Print "P5=" & m_VisM.P5
    Debug.Print "P6=" & m_VisM.P6
    Debug.Print "P7=" & m_VisM.P7
    Debug.Print "P8=" & m_VisM.P8
    Debug.Print "P9=" & m_VisM.P9
    Debug.Print "PDELIM=" & m_VisM.PDELIM
    Debug.Print "PLIST=" & m_VisM.PLIST

End Sub

Public Sub PrintLocalVariable()

'　サーバで保持しているローカル変数を表示する
    
    Dim i As Integer
    Dim Pieceno As Integer
    
    m_VisM.PDELIM = Chr(1)
    m_VisM.Execute "$$GetLocal^VISMUTIL(1)"
    Pieceno = length(m_VisM.PLIST, m_VisM.PDELIM)
    For i = 1 To Pieceno
      Debug.Print Piece(m_VisM.PLIST, m_VisM.PDELIM, i, i)
    Next i

End Sub

Public Property Let MouseIcon(N As Object)

    Screen.MouseIcon = N
    m_MousePointer = 99 'ccCoustom

End Property

Public Property Let MousePointer(N As Integer)

    m_MousePointer = N
    
End Property

Public Property Get MousePointer() As Integer

    MousePointer = m_MousePointer
    
End Property

Public Property Let Namespace(N As String)

    m_VisM.Namespace = N
    
End Property

Public Property Get Namespace() As String

    Namespace = m_VisM.Namespace
    
End Property

Public Property Get ErrorName() As String

    ErrorName = m_VisM.ErrorName
    
End Property

Public Property Get NoOfPLISTItem() As Integer

'PLISTの項目数を返す。

    NoOfPLISTItem = length(m_VisM.PLIST, m_VisM.PDELIM)
    
End Property

Private Function M_Execute(Code As String) As String

    Dim iMouseSave As Integer
    
    iMouseSave = Screen.MousePointer
    
    M_Execute = ""
    m_VisM.Value = ""
    
    If Code = "" Then Exit Function
    
    Screen.MousePointer = m_MousePointer
    
    On Error GoTo ConnectError
    
    m_VisM.Execute Code
    
    On Error GoTo 0
    
    Screen.MousePointer = iMouseSave
    
    If m_VisM.Error <> 0 Then
        
        On Error Resume Next
        Err.Raise Number:=(vbObjectError + m_VisM.Error), _
            Description:=Code & "  " & m_VisM.ErrorName
    
    End If
    
    M_Execute = m_VisM.Value
    
    Exit Function
    
ConnectError:
    
    Screen.MousePointer = iMouseSave
    
    On Error Resume Next
    Err.Raise Number:=(vbObjectError + 2000), _
    Description:="VisM1.Execute 実行ができません。" & _
    Chr(13) & Chr(10) & "Cache'　Directサーバが起動されていない？"

End Function

Public Property Get Error() As String

    Error = m_VisM.Error
    
End Property

Public Property Get MServer() As String

    MServer = m_VisM.MServer
    
End Property

Public Property Let PDELIM(N As String)

    m_VisM.PDELIM = N
    
End Property

Public Property Let MServer(N As String)

    m_VisM.MServer = N
    
End Property
Public Function TimerStart() As Double

    m_StartTime = Timer
    m_ElapseTime = 0
    TimerStart = m_StartTime
    
End Function
Public Function TimerContinue() As Double

    m_StartTime = Timer
    TimerContinue = m_StartTime
    
End Function

Public Function TimerStop() As Double

    m_EndTime = Timer
    t = m_EndTime - m_StartTime
    
    While (t < -0.01)
    
        t = t + 86400
    
    Wend

    m_ElapseTime = m_ElapseTime + t
    TimerStop = m_EndTime
    
End Function

Public Sub Wait(Waitseconds As Single)
' 指定秒数待ち（ハング）

    Dim StartTime As Single
    StartTime = Timer
    Do While Timer < StartTime + Waitseconds
        DoEvents
    Loop
    
End Sub

Public Property Get ElapseTime() As Double

    ElapseTime = m_ElapseTime
    
End Property

Public Property Get StartTime() As Double

    StartTime = m_StartTime
    
End Property

Public Property Get EndTime() As Double

    EndTime = m_ndTime
    
End Property

Public Property Get Value() As String

    Value = m_VisM.Value
    
End Property

Public Function Eval(Code As String) As String

    Eval = M_Execute(Code)
        
End Function

Public Function Evaluate(Code As String) As String

    Evaluate = M_Execute(Code)
        
End Function

Public Sub Execute(Code As String)

    M_Execute (Code)
    
End Sub

Public Sub Exe(Code As String)

    M_Execute (Code)
    
End Sub

Public Function PLISTItem(ByVal ItemNo As Integer) As String

'　n番目のPLIST項目を返す。

    PLISTItem = Piece(m_VisM.PLIST, m_VisM.PDELIM, ItemNo, ItemNo)
    
End Function

Public Function MPiece(ByVal str As String, ByVal substr As String, ByVal pos As Integer) As String

'　$Piece関数互換

    MPiece = Piece(str, substr, pos, pos)
    
End Function

Public Property Set VisM(N As Object)

    Set m_VisM = N
    
End Property

Public Property Let P1(N As String)

   m_VisM.P1 = N
    
End Property

Public Property Let P2(N As String)

   m_VisM.P2 = N
    
End Property

Public Property Let P4(N As String)

   m_VisM.P4 = N
    
End Property
Public Property Let P3(N As String)

   m_VisM.P3 = N
    
End Property

Public Property Let P5(N As String)

   m_VisM.P5 = N
    
End Property

Public Property Let P6(N As String)

   m_VisM.P6 = N
    
End Property

Public Property Let P7(N As String)

   m_VisM.P7 = N
    
End Property
Public Property Let P8(N As String)

   m_VisM.P8 = N
    
End Property
Public Property Get P8() As String

   P8 = m_VisM.P8
    
End Property

Public Property Let P9(N As String)

   m_VisM.P9 = N
    
End Property


Public Property Let P0(N As String)

   m_VisM.P0 = N
    
End Property

Public Property Let PLIST(N As String)

   m_VisM.PLIST = N
    
End Property

Public Property Get PLIST() As String

   PLIST = m_VisM.PLIST
    
End Property


Public Property Get P1() As String

   P1 = m_VisM.P1
    
End Property

Public Property Get P2() As String

   P2 = m_VisM.P2
    
End Property
Public Property Get P3() As String

   P3 = m_VisM.P3
    
End Property

Public Property Get P4() As String

   P4 = m_VisM.P4
    
End Property

Public Property Get P5() As String

   P5 = m_VisM.P5
    
End Property

Public Property Get P6() As String

   P6 = m_VisM.P6

End Property

Public Property Get P7() As String

   P7 = m_VisM.P7
    
End Property

Public Property Get P9() As String

   P9 = m_VisM.P9
    
End Property

Public Property Get P0() As String

   P0 = m_VisM.P0
    
End Property

Private Sub Class_Initialize()

    m_MousePointer = 11 'ccHourglass

End Sub

Private Function length(ByVal fullstr As String, ByVal substr As String) As Integer
    Dim i, j, c, L As Integer

    L = Len(substr)
    c = 1: j = 1
    Do
        i = InStr(j, fullstr, substr)
        If i = 0 Then Exit Do
        j = i + L
        c = c + 1
    Loop
    length = c

End Function

Private Function Piece(ByVal fullstr As String, ByVal substr As String, ByVal P1 As Integer, ByVal P2 As Integer) As String
    Dim i As Integer    'pointer for next found substr
    Dim j As Integer    'pointer for start of next search
    Dim L As Integer    'length of substr
    Dim c As Integer    'piece counter
    Dim m1 As Integer   'beginning offset for return value
    Dim m2 As Integer   'ending offset for return value

    If P1 < 1 Then P1 = 1
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

