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
	'Const m_classname As String = "User.ADBK"
	Const iris_classname As String = "User.ADBK"
	Dim id As Object

	'UPGRADE_NOTE: ShowDialog �� ShowDialog_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
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
		
		' ���O�̃��X�g���擾
		ListLookupName.Items.Clear()
		'RS = m_factory.ResultSet("User.ADBK", "ByName")
		'RS.Execute(TxtSNAME.Text) ' ByName takes a single argument
		'Dim SQLtext As String = "SELECT %ID,ANAME FROM ADBK WHERE (ANAME %STARTSWITH ?) ORDER BY %ID"
		Dim SQLtext As String = "call sqluser.ADBK_byname(?)"
		Dim Command As IRISCommand = New IRISCommand(SQLtext, iris_conn)
		Dim Name_param As IRISParameter = New IRISParameter("Name_col", IRISDbType.NVarChar)
		Name_param.Value = TxtSNAME.Text
		Command.Parameters.Add(Name_param)
		Dim Reader As IRISDataReader = Command.ExecuteReader()

		While Reader.Read()
			ListLookupName.Items.Add(Reader.Item(Reader.GetOrdinal("ANAME")))
		End While
		Reader.Close()
		Command.Dispose()

		'�@�擾�������O���X�g��ListBox�ɓW�J
		'While RS.Next
		'UPGRADE_WARNING: �I�u�W�F�N�g RS.GetDataByName() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'ListLookupName.Items.Add(RS.GetDataByName("ANAME"))
		'End While

	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name �� name_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim name_Renamed As String
		'name_Renamed = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		name_Renamed = ListLookupName.Items(ListLookupName.SelectedIndex).ToString()
		'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
		'RS = m_factory.DynamicSQL("SELECT * FROM ADBK WHERE ANAME = ?")
		'RS.Execute(name_Renamed) ' �l��'?'�Ƀo�C���h
		'RS.Next()
		Dim SQLtext As String = "SELECT * FROM ADBK WHERE ANAME = ?"
		Dim Command As IRISCommand = New IRISCommand(SQLtext, iris_conn)
		Dim Name_param As IRISParameter = New IRISParameter("Name_col", IRISDbType.NVarChar)
		Name_param.Value = name_Renamed
		Command.Parameters.Add(Name_param)
		Dim Reader As IRISDataReader = Command.ExecuteReader()
		Reader.Read()
		'�����t�H�[�����\��
		Me.Hide()
		'UPGRADE_WARNING: �I�u�W�F�N�g RS.GetDataByName() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'id = RS.GetDataByName("AID")
		id = Reader.Item(Reader.GetOrdinal("AID"))
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'm_object = m_factory.OpenId(m_classname, id)
		'If m_object Is Nothing Then
		iris_object = iris.ClassMethodObject(iris_classname, "%OpenId", id)
		If iris_object Is Nothing Then
			MsgBox("�I�u�W�F�N�g���J�����Ƃ��ł��܂���B")
		Else
			'�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ANAME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtNAME"), Object).Text = m_object.ANAME
			CType(ADBKMain.Controls("TxtNAME"), Object).Text = iris_object.Get("ANAME")
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.AZIP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtZIP"), Object).Text = m_object.AZIP
			CType(ADBKMain.Controls("TxtZIP"), Object).Text = iris_object.Get("AZIP")
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ASTREET �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = m_object.ASTREET
			CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = iris_object.Get("ASTREET")
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.APHHOME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtTELH"), Object).Text = m_object.APHHOME
			CType(ADBKMain.Controls("TxtTELH"), Object).Text = iris_object.Get("APHHOME")
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.APHOTH1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtTELO"), Object).Text = m_object.APHOTH1
			CType(ADBKMain.Controls("TxtTELO"), Object).Text = iris_object.Get("APHWORK")
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.AAGE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtAGE"), Object).Text = m_object.AAGE
			CType(ADBKMain.Controls("TxtAGE"), Object).Text = iris_object.Get("AAGE")
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ABTHDAY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'CType(ADBKMain.Controls("TxtDOB"), Object).Text = m_object.ABTHDAY
			CType(ADBKMain.Controls("TxtDOB"), Object).Text = iris_object.InvokeString("ABTHDAYLogicalToOdbc", iris_object.Get("ABTHDAY"))
			'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
		Reader.Close()
		Command.Dispose()
	End Sub
End Class