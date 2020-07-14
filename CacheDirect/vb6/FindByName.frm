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
Dim CacheDirect As New cVMClass

Private Sub CmdCancel_Click()

FindByName.Hide

End Sub

Private Sub CmdFind_Click()

Dim i, NOL As Integer
Dim Node As String

' 名前のリストを取得
ListLookupName.Clear
CacheDirect.Clear
CacheDirect.PDELIM = Chr(1)
Node = ""
CacheDirect.P0 = "^ADBK(""XNAME"")"
CacheDirect.P1 = TxtSNAME.Text
CacheDirect.Execute "Do GetList^ADBK(P0,P1,P1,""　"")"
If CacheDirect.Error <> 0 Then
'     MsgBox (" Error " & CacheDirect.ErrorName)
     Exit Sub
End If

'　取得した名前リストをListBoxに展開
For i = 1 To CacheDirect.NoOfPLISTItem
  ListLookupName.AddItem CacheDirect.PLISTItem(i)
Next i

End Sub

Private Sub CmdOK_Click()

CacheDirect.Clear
CacheDirect.P0 = ListLookupName.List(ListLookupName.ListIndex)
'選択されている名前に対応するデータを検索する。
CacheDirect.Execute ("Do GetData^ADBK(P0)")
If CacheDirect.Error <> 0 Then
     Exit Sub
End If
'検索フォームを非表示
FindByName.Hide
'取得データをフォームフィールドに展開する
ADBKMain!TxtNAME.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 1)
ADBKMain!TxtZIP.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 2)
ADBKMain!TxtADDRESS.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 3)
ADBKMain!TxtTELH.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 4)
ADBKMain!TxtTELO.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 5)
ADBKMain!TxtAGE.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 6)
ADBKMain!TxtDOB.Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 7)

End Sub

Private Sub Form_Load()
Set CacheDirect.VisM = ADBKMain!VisM1
End Sub

Private Sub Form_Unload(Cancel As Integer)
Set CacheDirect = Nothing
End Sub
