Option Strict Off
Option Explicit On
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	Dim RS As CacheObject.ResultSet
	Dim m_factory As CacheObject.Factory
	Dim m_object As CacheObject.ObjInstance
	Const m_classname As String = "User.ADBK"
	Dim id As Object
	
	'UPGRADE_NOTE: ShowDialog は ShowDialog_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Public Function ShowDialog_Renamed(ByRef factory As CacheObject.Factory) As CacheObject.ObjInstance
		
		m_factory = factory
		
		Me.ShowDialog()
		
		'Set m_factory = Nothing
		ShowDialog_Renamed = m_object
		
	End Function
	
	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click
		
		Me.Hide()
		
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		
		' 名前のリストを取得
		ListLookupName.Items.Clear()
		RS = m_factory.ResultSet("User.ADBK", "ByName")
		RS.Execute(TxtSNAME.Text) ' ByName takes a single argument
		
		'　取得した名前リストをListBoxに展開
		While RS.Next
			'UPGRADE_WARNING: オブジェクト RS.GetDataByName() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ListLookupName.Items.Add(RS.GetDataByName("ANAME"))
		End While
		
	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name は name_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim name_Renamed As String
		name_Renamed = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		'選択されている名前に対応するデータを検索する。
		RS = m_factory.DynamicSQL("SELECT * FROM ADBK WHERE ANAME = ?")
		RS.Execute(name_Renamed) ' 値を'?'にバインド
		RS.Next()
		'検索フォームを非表示
		Me.Hide()
		'UPGRADE_WARNING: オブジェクト RS.GetDataByName() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		id = RS.GetDataByName("AID")
		'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_object = m_factory.OpenId(m_classname, id)
		If m_object Is Nothing Then
			MsgBox("オブジェクトを開くことができません。")
		Else
			'取得データをフォームフィールドに展開する
			'UPGRADE_WARNING: オブジェクト m_object.ANAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtNAME"), Object).Text = m_object.ANAME
			'UPGRADE_WARNING: オブジェクト m_object.AZIP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtZIP"), Object).Text = m_object.AZIP
			'UPGRADE_WARNING: オブジェクト m_object.ASTREET の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = m_object.ASTREET
			'UPGRADE_WARNING: オブジェクト m_object.APHHOME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtTELH"), Object).Text = m_object.APHHOME
			'UPGRADE_WARNING: オブジェクト m_object.APHOTH1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtTELO"), Object).Text = m_object.APHOTH1
			'UPGRADE_WARNING: オブジェクト m_object.AAGE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtAGE"), Object).Text = m_object.AAGE
			'UPGRADE_WARNING: オブジェクト m_object.ABTHDAY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("TxtDOB"), Object).Text = m_object.ABTHDAY
			'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
	End Sub
End Class