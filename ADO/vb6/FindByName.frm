VERSION 5.00
Begin VB.Form FindByName 
   Caption         =   "Form2"
   ClientHeight    =   4185
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form2"
   ScaleHeight     =   4185
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows �̊���l
   Begin VB.CommandButton CmdFind 
      Caption         =   "����"
      Height          =   495
      Left            =   240
      TabIndex        =   5
      Top             =   3360
      Width           =   1335
   End
   Begin VB.ListBox ListLookupName 
      Height          =   1680
      Left            =   600
      TabIndex        =   4
      Top             =   1320
      Width           =   3495
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "�L�����Z��"
      Height          =   495
      Left            =   3120
      TabIndex        =   3
      Top             =   3360
      Width           =   1335
   End
   Begin VB.CommandButton CmdOK 
      Caption         =   "OK"
      Height          =   495
      Left            =   1680
      TabIndex        =   2
      Top             =   3360
      Width           =   1335
   End
   Begin VB.TextBox TxtSNAME 
      Height          =   495
      Left            =   1200
      TabIndex        =   1
      Top             =   360
      Width           =   2535
   End
   Begin VB.Label LblSname 
      Caption         =   "���������F�@�@�i�O����v�j"
      Height          =   375
      Left            =   240
      TabIndex        =   0
      Top             =   480
      Width           =   1095
   End
End
Attribute VB_Name = "FindByName"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim cnn1 As New ADODB.Connection
Dim rs As New ADODB.Recordset
Const m_classname = "User.ADBK"
Dim id As Variant

Public Function ShowDialog(conn As ADODB.Connection) As ADODB.Recordset

    Set cnn1 = conn
    
    Me.Show vbModal
    
    Set ShowDialog = rs
        
End Function

Private Sub CmdCancel_Click()

FindByName.Hide

End Sub

Private Sub CmdFind_Click()

' ���O�̃��X�g���擾
ListLookupName.Clear
Set rs = Nothing
If TxtSNAME.Text = "" Then
  rs.Open "Select ANAME from ADBK", cnn1
Else
  rs.Open "Select ANAME from ADBK WHERE ANAME %STARTSWITH '" + TxtSNAME.Text + "'", cnn1
End If
'�@�擾�������O���X�g��ListBox�ɓW�J
While Not rs.EOF
        ListLookupName.AddItem rs.Fields("ANAME")
        rs.MoveNext
Wend

End Sub

Private Sub CmdOK_Click()
Dim name As String
name = ListLookupName.List(ListLookupName.ListIndex)
'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
Set rs = Nothing
rs.Open "SELECT * FROM ADBK WHERE ANAME = '" + name + "'", cnn1, , adLockPessimistic
'�����t�H�[�����\��
FindByName.Hide
If rs.EOF Then
   MsgBox "�I�u�W�F�N�g���J�����Ƃ��ł��܂���B"
Else
  id = rs.Fields("AID")
  '�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
  If Not IsNull(rs.Fields("ANAME")) Then ADBKMain!TxtNAME.Text = rs.Fields("ANAME")
  If Not IsNull(rs.Fields("AZIP")) Then ADBKMain!TxtZIP.Text = rs.Fields("AZIP")
  If Not IsNull(rs.Fields("ASTREET")) Then ADBKMain!TxtADDRESS.Text = rs.Fields("ASTREET")
  If Not IsNull(rs.Fields("APHHOME")) Then ADBKMain!TxtTELH.Text = rs.Fields("APHHOME")
  If Not IsNull(rs.Fields("APHOTH1")) Then ADBKMain!TxtTELO.Text = rs.Fields("APHOTH1")
  If Not IsNull(rs.Fields("AAGE")) Then ADBKMain!TxtAGE.Text = rs.Fields("AAGE")
  If Not IsNull(rs.Fields("ABTHDAY")) Then ADBKMain!TxtDOB.Text = rs.Fields("ABTHDAY")
  ADBKMain!lblAID.Caption = id
End If
End Sub

