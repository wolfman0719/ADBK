Option Strict Off
Option Explicit On
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	Dim cnn1 As New ADODB.Connection
	Dim rs As New ADODB.Recordset
	Const m_classname As String = "User.ADBK"
	Dim id As Object
	
	'UPGRADE_NOTE: ShowDialog は ShowDialog_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Public Function ShowDialog_Renamed(ByRef conn As ADODB.Connection) As ADODB.Recordset
		
		cnn1 = conn
		
		Me.ShowDialog()
		
		ShowDialog_Renamed = rs
		
	End Function
	
	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click
		
		Me.Hide()
		
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		
		' 名前のリストを取得
		ListLookupName.Items.Clear()
		'UPGRADE_NOTE: オブジェクト rs をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		rs = Nothing
		If TxtSNAME.Text = "" Then
			rs.Open("Select ANAME from ADBK", cnn1)
		Else
			rs.Open("Select ANAME from ADBK WHERE ANAME %STARTSWITH '" & TxtSNAME.Text & "'", cnn1)
		End If
		'　取得した名前リストをListBoxに展開
		While Not rs.EOF
			ListLookupName.Items.Add(rs.Fields("ANAME").Value)
			rs.MoveNext()
		End While
		
	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name は name_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim name_Renamed As String
		name_Renamed = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		'選択されている名前に対応するデータを検索する。
		'UPGRADE_NOTE: オブジェクト rs をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		rs = Nothing
		rs.Open("SELECT * FROM ADBK WHERE ANAME = '" & name_Renamed & "'", cnn1,  , ADODB.LockTypeEnum.adLockPessimistic)
		'検索フォームを非表示
		Me.Hide()
		If rs.EOF Then
			MsgBox("オブジェクトを開くことができません。")
		Else
			'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			id = rs.Fields("AID").Value
			'取得データをフォームフィールドに展開する
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("ANAME").Value) Then CType(ADBKMain.Controls("TxtNAME"), Object).Text = rs.Fields("ANAME").Value
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("AZIP").Value) Then CType(ADBKMain.Controls("TxtZIP"), Object).Text = rs.Fields("AZIP").Value
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("ASTREET").Value) Then CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = rs.Fields("ASTREET").Value
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("APHHOME").Value) Then CType(ADBKMain.Controls("TxtTELH"), Object).Text = rs.Fields("APHHOME").Value
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("APHOTH1").Value) Then CType(ADBKMain.Controls("TxtTELO"), Object).Text = rs.Fields("APHOTH1").Value
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("AAGE").Value) Then CType(ADBKMain.Controls("TxtAGE"), Object).Text = rs.Fields("AAGE").Value
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(rs.Fields("ABTHDAY").Value) Then CType(ADBKMain.Controls("TxtDOB"), Object).Text = rs.Fields("ABTHDAY").Value
			'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
	End Sub
End Class