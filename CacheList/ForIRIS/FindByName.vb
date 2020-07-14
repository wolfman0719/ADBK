Option Strict Off
Option Explicit On
Imports InterSystems.Data.IRISClient
Imports InterSystems.Data.IRISClient.ADO
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	'Dim RS As CacheObject.ResultSet
	'Dim m_factory As CacheObject.Factory
	'Dim m_object As CacheObject.ObjInstance
	Dim iris As IRIS
	Dim iris_object As IRISObject
	Dim iris_conn As IRISConnection
	Dim listhelper As IRISListHelper

	'Const m_classname As String = "User.ADBK"
	Const iris_classname As String = "User.ADBK"
	Dim id As Object
	Dim success As Object

	'UPGRADE_NOTE: ShowDialog は ShowDialog_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	'Public Function ShowDialog_Renamed(ByRef factory As CacheObject.Factory) As CacheObject.ObjInstance
	Public Function ShowDialog_Renamed(ByRef iris_factory As IRIS, ByRef iris_connection As IRISConnection) As IRISObject

		'm_factory = factory
		iris = iris_factory
		iris_conn = iris_connection

		Me.ShowDialog()

		'Set m_factory = Nothing
		'ShowDialog_Renamed = m_object
		ShowDialog_Renamed = iris_object

	End Function

	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click
		
		Me.Hide()
		
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click

		Dim params() As String = {""}

		' 名前のリストを取得
		ListLookupName.Items.Clear()

		If listhelper Is Nothing Then
			listhelper = New IRISListHelper()
		End If

		listhelper.SQLText = "call sqluser.ADBK_byname(?)"
		listhelper.Listbox1 = ListLookupName
		params(0) = TxtSNAME.Text
		listhelper.Run("ANAME", iris_conn, params)
		'CacheList1.factory = m_factory
		' Display the Query dialog
		'UPGRADE_WARNING: オブジェクト success の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'success = CacheList1.ResultSet("User.ADBK", "ByName")
		'CacheList1.Run(TxtSNAME.Text)

	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name は name_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim name_Renamed As String
		'Dim i As Object

		'UPGRADE_WARNING: オブジェクト i の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'i = CacheList1.GetSelectedIndex()
		'UPGRADE_WARNING: オブジェクト i の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'name_Renamed = CacheList1.GetData(i, 2)
		'name = ListLookupName.List(ListLookupName.ListIndex)
		name_Renamed = ListLookupName.Items(ListLookupName.SelectedIndex).ToString()
		'選択されている名前に対応するデータを検索する。
		'RS = m_factory.DynamicSQL("SELECT * FROM ADBK WHERE ANAME = ?")
		'RS.Execute(name_Renamed) ' 値を'?'にバインド
		'RS.Next()
		Dim SQLtext As String = "SELECT * FROM ADBK WHERE ANAME = ?"
		Dim Command As IRISCommand = New IRISCommand(SQLtext, iris_conn)
		Dim Name_param As IRISParameter = New IRISParameter("Name_col", IRISDbType.NVarChar)
		Name_param.Value = name_Renamed
		Command.Parameters.Add(Name_param)
		Dim Reader As IRISDataReader = Command.ExecuteReader()
		Reader.Read()

		'検索フォームを非表示
		Me.Hide()
		'UPGRADE_WARNING: オブジェクト RS.GetDataByName() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'id = RS.GetDataByName("AID")
		id = Reader.Item(Reader.GetOrdinal("AID"))
		'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'm_object = m_factory.OpenId(m_classname, id)
		iris_object = iris.ClassMethodObject(iris_classname, "%OpenId", id)

		'If m_object Is Nothing Then
		If iris_object Is Nothing Then
			MsgBox("オブジェクトを開くことができません。")
		Else
			'取得データをフォームフィールドに展開する
			'UPGRADE_WARNING: オブジェクト m_object.ANAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtNAME"), Object).Text = m_object.ANAME
			CType(ADBKMain.Controls("TxtNAME"), Object).Text = iris_object.Get("ANAME")
			'UPGRADE_WARNING: オブジェクト m_object.AZIP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtZIP"), Object).Text = m_object.AZIP
			CType(ADBKMain.Controls("TxtZIP"), Object).Text = iris_object.Get("AZIP")
			'UPGRADE_WARNING: オブジェクト m_object.ASTREET の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = m_object.ASTREET
			CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = iris_object.Get("ASTREET")
			'UPGRADE_WARNING: オブジェクト m_object.APHHOME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtTELH"), Object).Text = m_object.APHHOME
			CType(ADBKMain.Controls("TxtTELH"), Object).Text = iris_object.Get("APHHOME")
			'UPGRADE_WARNING: オブジェクト m_object.APHOTH1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtTELO"), Object).Text = m_object.APHOTH1
			CType(ADBKMain.Controls("TxtTELO"), Object).Text = iris_object.Get("APHOTH1")
			'UPGRADE_WARNING: オブジェクト m_object.AAGE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtAGE"), Object).Text = m_object.AAGE
			CType(ADBKMain.Controls("TxtAGE"), Object).Text = iris_object.Get("AAGE")
			'UPGRADE_WARNING: オブジェクト m_object.ABTHDAY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'CType(ADBKMain.Controls("TxtDOB"), Object).Text = m_object.ABTHDAY
			CType(ADBKMain.Controls("TxtDOB"), Object).Text = iris_object.InvokeString("ABTHDAYLogicalToOdbc", iris_object.Get("ABTHDAY"))
			'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
	End Sub

	Private Sub FindByName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'TODO: このコード行はデータを 'DataSet1.ADBK' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
		Me.ADBKTableAdapter.Fill(Me.DataSet1.ADBK)

	End Sub
End Class