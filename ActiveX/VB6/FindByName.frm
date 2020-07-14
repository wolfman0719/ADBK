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
Dim RS As CacheObject.ResultSet
Dim m_factory As CacheObject.factory
Dim m_object As CacheObject.ObjInstance
Const m_classname = "User.ADBK"
Dim id As Variant

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
ListLookupName.Clear
Set RS = m_factory.ResultSet("User.ADBK", "ByName")
RS.Execute (TxtSNAME.Text)   ' ByName takes a single argument

'�@�擾�������O���X�g��ListBox�ɓW�J
While RS.Next
        ListLookupName.AddItem RS.GetDataByName("ANAME")
Wend

End Sub

Private Sub CmdOK_Click()
Dim name As String
name = ListLookupName.List(ListLookupName.ListIndex)
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

