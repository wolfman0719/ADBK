VERSION 5.00
Object = "{F4D7DECE-EB39-11D1-A333-0000F8773CDC}#1.0#0"; "CACHEL~1.OCX"
Begin VB.Form FindByName 
   Caption         =   "Form2"
   ClientHeight    =   5235
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6885
   LinkTopic       =   "Form2"
   ScaleHeight     =   5235
   ScaleWidth      =   6885
   StartUpPosition =   3  'Windows �̊���l
   Begin CACHELISTLib.CacheList CacheList1 
      Height          =   1575
      Left            =   1200
      TabIndex        =   5
      Top             =   1320
      Width           =   2295
      _Version        =   65536
      _ExtentX        =   4048
      _ExtentY        =   2778
      _StockProps     =   13
      BackColor       =   16777215
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MinToDisplay    =   50
   End
   Begin VB.CommandButton CmdFind 
      Caption         =   "����"
      Height          =   495
      Left            =   240
      TabIndex        =   4
      Top             =   3360
      Width           =   1335
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
Dim RS As CacheObject.ResultSet
Dim m_factory As CacheObject.factory
Dim m_object As CacheObject.ObjInstance
Const m_classname = "User.ADBK"
Dim id As Variant
Dim success As Variant

Public Function ShowDialog(factory As CacheObject.factory) As CacheObject.ObjInstance

    Set m_factory = factory
    
    Me.Show vbModal
    
    'Set m_factory = Nothing
    Set ShowDialog = m_object
        
End Function

Private Sub CmdCancel_Click()

FindByName.Hide

End Sub

Private Sub CmdFind_Click()

' ���O�̃��X�g���擾
'ListLookupName.Clear
Set CacheList1.factory = m_factory
' Display the Query dialog
success = CacheList1.ResultSet("User.ADBK", "ByName")
CacheList1.Run TxtSNAME.Text

End Sub

Private Sub CmdOK_Click()
Dim name As String
Dim i As Variant

i = CacheList1.GetSelectedIndex()
name = CacheList1.GetData(i, 2)
'name = ListLookupName.List(ListLookupName.ListIndex)
'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
Set RS = m_factory.DynamicSQL("SELECT * FROM ADBK WHERE ANAME = ?")
RS.Execute (name)    ' �l��'?'�Ƀo�C���h
RS.Next
'�����t�H�[�����\��
FindByName.Hide
id = RS.GetDataByName("AID")
Set m_object = m_factory.OpenId(m_classname, id)
If m_object Is Nothing Then
   MsgBox "�I�u�W�F�N�g���J�����Ƃ��ł��܂���B"
Else
  '�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
  ADBKMain!TxtNAME.Text = m_object.ANAME
  ADBKMain!TxtZIP.Text = m_object.AZIP
  ADBKMain!TxtADDRESS.Text = m_object.ASTREET
  ADBKMain!TxtTELH.Text = m_object.APHHOME
  ADBKMain!TxtTELO.Text = m_object.APHOTH1
  ADBKMain!TxtAGE.Text = m_object.AAGE
  ADBKMain!TxtDOB.Text = m_object.ABTHDAY
  ADBKMain!lblAID.Caption = id
End If
End Sub

