VERSION 5.00
Begin VB.Form ADBKMain 
   Caption         =   "Form1"
   ClientHeight    =   6360
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6375
   LinkTopic       =   "Form1"
   ScaleHeight     =   6360
   ScaleWidth      =   6375
   StartUpPosition =   3  'Windows の既定値
   Begin VB.CommandButton CmdEnd 
      Caption         =   "終了"
      Height          =   495
      Left            =   5160
      TabIndex        =   19
      Top             =   5520
      Width           =   1095
   End
   Begin VB.TextBox TxtDOB 
      Height          =   375
      Left            =   1920
      TabIndex        =   18
      Top             =   4800
      Width           =   1935
   End
   Begin VB.CommandButton CmdUpdate 
      Caption         =   "登録／更新"
      Height          =   495
      Left            =   3960
      TabIndex        =   16
      Top             =   5520
      Width           =   1095
   End
   Begin VB.CommandButton CmdNew 
      Caption         =   "新規"
      Height          =   495
      Left            =   1560
      TabIndex        =   15
      Top             =   5520
      Width           =   1095
   End
   Begin VB.CommandButton CmdDelete 
      Caption         =   "削除"
      Height          =   495
      Left            =   2760
      TabIndex        =   14
      Top             =   5520
      Width           =   1095
   End
   Begin VB.CommandButton CmdFind 
      Caption         =   "検索"
      Height          =   495
      Left            =   360
      TabIndex        =   13
      Top             =   5520
      Width           =   1095
   End
   Begin VB.TextBox TxtAGE 
      Height          =   375
      Left            =   1920
      TabIndex        =   11
      Top             =   4200
      Width           =   1455
   End
   Begin VB.TextBox TxtTELO 
      Height          =   375
      Left            =   1920
      TabIndex        =   10
      Top             =   3600
      Width           =   2295
   End
   Begin VB.TextBox TxtTELH 
      Height          =   375
      Left            =   1920
      TabIndex        =   8
      Top             =   3000
      Width           =   2295
   End
   Begin VB.TextBox TxtADDRESS 
      Height          =   375
      Left            =   1920
      TabIndex        =   6
      Top             =   2400
      Width           =   4335
   End
   Begin VB.TextBox TxtZIP 
      Height          =   375
      Left            =   1920
      TabIndex        =   4
      Top             =   1800
      Width           =   855
   End
   Begin VB.TextBox TxtNAME 
      Height          =   375
      Left            =   1920
      TabIndex        =   2
      Top             =   1200
      Width           =   2775
   End
   Begin VB.Label lblAID 
      Height          =   255
      Left            =   240
      TabIndex        =   21
      Top             =   240
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.Label LblDateFormat 
      Caption         =   "YYYY/MM/DD"
      Height          =   255
      Left            =   4200
      TabIndex        =   20
      Top             =   4920
      Width           =   1335
   End
   Begin VB.Label LblDob 
      Caption         =   "生年月日："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   17
      Top             =   4920
      Width           =   1215
   End
   Begin VB.Label LblAge 
      Caption         =   "年齢："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   12
      Top             =   4320
      Width           =   1215
   End
   Begin VB.Label LblTelo 
      Caption         =   "会社Tel："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   9
      Top             =   3720
      Width           =   1215
   End
   Begin VB.Label LblTelh 
      Caption         =   "自宅Tel："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   7
      Top             =   3120
      Width           =   1215
   End
   Begin VB.Label LblAddress 
      Caption         =   "住所："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   5
      Top             =   2520
      Width           =   1215
   End
   Begin VB.Label Label3 
      Caption         =   "郵便番号："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   3
      Top             =   1800
      Width           =   1215
   End
   Begin VB.Label Label2 
      Caption         =   "名前："
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   1
      Top             =   1200
      Width           =   735
   End
   Begin VB.Label Label1 
      Caption         =   "住所録"
      BeginProperty Font 
         Name            =   "ＭＳ Ｐ明朝"
         Size            =   15.75
         Charset         =   128
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   2400
      TabIndex        =   0
      Top             =   360
      Width           =   2415
   End
End
Attribute VB_Name = "ADBKMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim cnn1 As New ADODB.Connection
Dim rs As New ADODB.Recordset
Dim id As Variant
Dim newflag As Boolean

Private Sub CmdDelete_Click()
Dim status As Integer
Dim command As String
    id = lblAID.Caption
    If id = "" Then
        MsgBox "レコードを削除できません(IDなし)", vbInformation
        Exit Sub
    End If
    status = MsgBox("本当に削除しますか？　", vbYesNoCancel, "住所録削除")
    If status = vbYes Then                    ' [はい] がクリックされた場合、
       'command = "delete from adbk where aid = " + lblAID.Caption
       'cnn1.Execute command
       rs.Delete
       '入力フィールドをクリア
       TxtADDRESS.Text = ""
       TxtNAME.Text = ""
       TxtZIP.Text = ""
       TxtAGE.Text = ""
       TxtDOB.Text = ""
       TxtTELH.Text = ""
       TxtTELO.Text = ""
       lblAID.Caption = ""
    End If
    '検索結果をクリアする
    FindByName!ListLookupName.Clear
End Sub

Private Sub CmdEnd_Click()
Unload Me
End
End Sub

Private Sub CmdFind_Click()
FindByName!ListLookupName.Clear
'検索フォームを表示する
Set rs = FindByName.ShowDialog(cnn1)
'新規入力時以外は、名前フィールドは変更不可とする。
TxtNAME.Locked = True
newflag = False
End Sub

Private Sub CmdNew_Click()
'名前フィールドを変更可能に戻す
TxtNAME.Locked = False
'入力フィールドをクリア
TxtADDRESS.Text = ""
TxtNAME.Text = ""
TxtZIP.Text = ""
TxtAGE.Text = ""
TxtDOB.Text = ""
TxtTELH.Text = ""
TxtTELO.Text = ""
newflag = True
Set rs = Nothing
rs.Open "SELECT * FROM ADBK WHERE ANAME = 'zzz'", cnn1, , adLockPessimistic
End Sub

Private Sub CmdUpdate_Click()
Dim command As String
status = MsgBox("本当に更新しますか？　", vbYesNoCancel, "住所録更新")
If status = vbYes Then      ' [はい] がクリックされた場合、
    If newflag = True Then  '新規作成
       'Set rs = Nothing
       'command = "INSERT INTO ADBK (ANAME,ASTREET,AZIP,ABTHDAY,APHHOME,APHOTH1)"
       'command = command + " VALUES('" + TxtNAME.Text + "','" + TxtADDRESS.Text + "','"
       'command = command + TxtZIP.Text + "','" + Format(TxtDOB.Text, "YYYY-MM-DD") + "','"
       'command = command + TxtTELH.Text + "','" + TxtTELO.Text
       On Error GoTo actionSaveError
       'cnn1.Execute command
       rs.AddNew
       rs.Fields("ASTREET") = TxtADDRESS.Text
       rs.Fields("AZIP") = TxtZIP.Text
       rs.Fields("ABTHDAY") = TxtDOB.Text
       rs.Fields("APHHOME") = TxtTELH.Text
       rs.Fields("APHOTH1") = TxtTELO.Text
       rs.Fields("ANAME") = TxtNAME.Text
    Else
       rs.Fields("ASTREET") = TxtADDRESS.Text
       rs.Fields("AZIP") = TxtZIP.Text
       rs.Fields("ABTHDAY") = TxtDOB.Text
       rs.Fields("APHHOME") = TxtTELH.Text
       rs.Fields("APHOTH1") = TxtTELO.Text
    End If
    On Error GoTo actionSaveError
    rs.Update
    'command = "UPDATE ADBK SET ASTREET = '" + TxtADDRESS.Text + "', AZIP = '" + TxtZIP.Text
    'command = command + "', ABTHDAY = '" + Format(TxtDOB.Text, "YYYY-MM-DD") + "' , APHHOME = '" + TxtTELH.Text
    'command = command + "', APHHOME = '" + TxtTELH.Text + "' WHERE AID = " + lblAID.Caption
    'cnn1.Execute command
    Exit Sub
actionSaveError:
    MsgBox "データ形式エラー " + Err.Description
End If
End Sub

Private Sub Form_Load()
    cnn1.ConnectionString = "DSN=CacheISJSAMPLES;UID=_system;PWD=sys"
    cnn1.Open
End Sub

Private Sub Form_Unload(Cancel As Integer)
Set rs = Nothing
cnn1.Close
End Sub
