Option Strict Off
Option Explicit On
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	'Dim CacheDirect As New cVMClass
	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click

		Me.Hide()

	End Sub

	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		
		Dim i As Object
		'Dim NOL As Short

		' 名前のリストを取得
		ListLookupName.Items.Clear()
		'以下の機能は未実装
		'CacheDirect.Clear()
		ADBKMain.CacheDirect.PDELIM = Chr(1)
		ADBKMain.CacheDirect.P0 = "^ADBK(""XNAME"")"
		ADBKMain.CacheDirect.P1 = TxtSNAME.Text
		ADBKMain.CacheDirect.Execute("Do GetList^VISMUTIL(P0,P1,P1,"" "")")
		'If CDbl(CacheDirect.Error_Renamed) <> 0 Then
		If CDbl(ADBKMain.CacheDirect.Error) <> 0 Then
			'MsgBox(" Error " & CacheDirect.ErrorName)
			MsgBox(" Error " & ADBKMain.CacheDirect.ErrorName)
			Exit Sub
		End If

		'　取得した名前リストをListBoxに展開
		'For i = 1 To CacheDirect.NoOfPLISTItem
		For i = 1 To ADBKMain.CacheDirect.getPLISTLength()
			'UPGRADE_WARNING: オブジェクト i の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'ListLookupName.Items.Add(CacheDirect.PLISTItem(i))
			ListLookupName.Items.Add(ADBKMain.CacheDirect.getPLIST(i))
		Next i

	End Sub

	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		Dim result() As String
		'CacheDirect.Clear()
		'CacheDirect.P0 = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		If (ListLookupName.SelectedIndex >= 0) Then
			ADBKMain.CacheDirect.P0 = ListLookupName.Items(ListLookupName.SelectedIndex).ToString()
			'選択されている名前に対応するデータを検索する。
			ADBKMain.CacheDirect.Execute(("Do GetData^ADBK(P0)"))
			'If CDbl(CacheDirect.Error_Renamed) <> 0 Then
			If CDbl(ADBKMain.CacheDirect.Error) <> 0 Then
				Exit Sub
			End If
			'検索フォームを非表示
			Me.Hide()
			'取得データをフォームフィールドに展開する
			'CType(ADBKMain.Controls("TxtNAME"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 1)
			'CType(ADBKMain.Controls("TxtZIP"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 2)
			'CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 3)
			'CType(ADBKMain.Controls("TxtTELH"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 4)
			'CType(ADBKMain.Controls("TxtTELO"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 5)
			'CType(ADBKMain.Controls("TxtAGE"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 6)
			'CType(ADBKMain.Controls("TxtDOB"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 7)
			result = ADBKMain.CacheDirect.P1.ToString().Split(Chr(2))
			CType(ADBKMain.Controls("TxtNAME"), Object).Text = result(0)
			CType(ADBKMain.Controls("TxtZIP"), Object).Text = result(1)
			CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = result(2)
			CType(ADBKMain.Controls("TxtTELH"), Object).Text = result(3)
			CType(ADBKMain.Controls("TxtTELO"), Object).Text = result(4)
			CType(ADBKMain.Controls("TxtAGE"), Object).Text = result(5)
			CType(ADBKMain.Controls("TxtDOB"), Object).Text = result(6)
		End If


	End Sub

	Private Sub FindByName_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'CacheDirect.VisM = CType(ADBKMain.Controls("VisM1"), Object)
	End Sub
	
	Private Sub FindByName_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: オブジェクト CacheDirect をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		'CacheDirect = Nothing

	End Sub
End Class