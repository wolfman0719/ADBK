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
   StartUpPosition =   3  'Windows の既定値
   Begin VB.CommandButton CmdFind 
      Caption         =   "検索"
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
      Caption         =   "キャンセル"
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
      Caption         =   "検索氏名：　　（前方一致）"
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

' 名前のリストを取得
ListLookupName.Clear
Set RS = m_factory.ResultSet("User.ADBK", "ByName")
RS.Execute (TxtSNAME.Text)   ' ByName takes a single argument

'　取得した名前リストをListBoxに展開
While RS.Next
        ListLookupName.AddItem RS.GetDataByName("ANAME")
Wend

End Sub

Private Sub CmdOK_Click()
Dim name As String
name = ListLookupName.List(ListLookupName.ListIndex)
'選択されている名前に対応するデータを検索する。
Set RS = m_factory.DynamicSQL("SELECT * FROM ADBK WHERE ANAME = ?")
RS.Execute (name)    ' 値を'?'にバインド
RS.Next
'検索フォームを非表示
FindByName.Hide
id = RS.GetDataByName("AID")
Set m_object = m_factory.OpenId(m_classname, id)
If m_object Is Nothing Then
   MsgBox "オブジェクトを開くことができません。"
Else
  '取得データをフォームフィールドに展開する
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

