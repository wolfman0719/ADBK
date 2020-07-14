Option Strict Off
Option Explicit On
Imports InterSystems.Data.IRISClient
Imports InterSystems.Data.IRISClient.ADO

Friend Class FindByName
	Inherits System.Windows.Forms.Form
	'Dim cnn1 As New ADODB.Connection
	'Dim rs As New ADODB.Recordset
	Dim Reader As IRISDataReader
	Dim iris_conn As IRISConnection = New IRISConnection

	'Const m_classname As String = "User.ADBK"
	Const iris_classname As String = "User.ADBK"
	Dim id As Object

	'UPGRADE_NOTE: ShowDialog �� ShowDialog_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	'Public Function ShowDialog_Renamed(ByRef conn As ADODB.Connection) As ADODB.Recordset
	Public Function ShowDialog_Renamed(ByRef conn As IRISConnection) As IRISDataReader


		'cnn1 = conn
		iris_conn = conn

		Me.ShowDialog()

		'ShowDialog_Renamed = rs
		ShowDialog_Renamed = Reader

	End Function

	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click

		Me.Hide()

	End Sub

	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click

		Dim Command As IRISCommand
		' ���O�̃��X�g���擾
		ListLookupName.Items.Clear()
		'UPGRADE_NOTE: �I�u�W�F�N�g rs ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		'rs = Nothing
		If TxtSNAME.Text = "" Then
			'rs.Open("Select ANAME from ADBK", cnn1)
			Dim SQLtext As String = "Select ANAME from ADBK"

			Command = New IRISCommand(SQLtext, iris_conn)

		Else
			'rs.Open("Select ANAME from ADBK WHERE ANAME %STARTSWITH '" & TxtSNAME.Text & "'", cnn1)
			Dim SQLtext As String = "Select ANAME from ADBK WHERE ANAME %STARTSWITH ?"
			Command = New IRISCommand(SQLtext, iris_conn)
			Dim Name_param As IRISParameter = New IRISParameter("Name_col", IRISDbType.NVarChar)
			Name_param.Value = TxtSNAME.Text
			Command.Parameters.Add(Name_param)

		End If
		'�@�擾�������O���X�g��ListBox�ɓW�J
		Reader = Command.ExecuteReader()

		While Reader.Read()
			ListLookupName.Items.Add(Reader.Item(Reader.GetOrdinal("ANAME")))
		End While
		Reader.Close()
		Command.Dispose()
		'While Not rs.EOF
		'ListLookupName.Items.Add(rs.Fields("ANAME").Value)
		'rs.MoveNext()
		'End While

	End Sub

	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name �� name_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim Command As IRISCommand
		Dim name_Renamed As String
		'name_Renamed = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		name_Renamed = ListLookupName.Items(ListLookupName.SelectedIndex).ToString()
		'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
		'UPGRADE_NOTE: �I�u�W�F�N�g rs ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		'rs = Nothing
		'rs.Open("SELECT * FROM ADBK WHERE ANAME = '" & name_Renamed & "'", cnn1,  , ADODB.LockTypeEnum.adLockPessimistic)
		iris_conn.IsolationLevel = IsolationLevel.ReadCommitted
		'�����t�H�[�����\��
		Dim SQLtext As String = "SELECT AID,ANAME,AZIP,ASTREET,APHHOME,APHWORK,{fn CONVERT(ABTHDAY,SQL_VARCHAR)} As DOB, AAGE FROM ADBK WHERE ANAME = ?"
		Command = New IRISCommand(SQLtext, iris_conn)
		Dim Name_param As IRISParameter = New IRISParameter("Name_col", IRISDbType.NVarChar)
		Name_param.Value = name_Renamed
		Command.Parameters.Add(Name_param)
		Me.Hide()
		Dim Reader As IRISDataReader = Command.ExecuteReader()
		If Not Reader.Read() Then

			'If rs.EOF Then
			MsgBox("�I�u�W�F�N�g���J�����Ƃ��ł��܂���B")
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'id = rs.Fields("AID").Value
			id = Reader.Item(Reader.GetOrdinal("AID"))
			'�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("ANAME").Value) Then CType(ADBKMain.Controls("TxtNAME"), Object).Text = rs.Fields("ANAME").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("ANAME"))) Then CType(ADBKMain.Controls("TxtNAME"), Object).Text = Reader.Item(Reader.GetOrdinal("ANAME"))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("AZIP").Value) Then CType(ADBKMain.Controls("TxtZIP"), Object).Text = rs.Fields("AZIP").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("AZIP"))) Then CType(ADBKMain.Controls("TxtZIP"), Object).Text = Reader.Item(Reader.GetOrdinal("AZIP"))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("ASTREET").Value) Then CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = rs.Fields("ASTREET").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("ASTREET"))) Then CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = Reader.Item(Reader.GetOrdinal("ASTREET"))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("APHHOME").Value) Then CType(ADBKMain.Controls("TxtTELH"), Object).Text = rs.Fields("APHHOME").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("APHHOME"))) Then CType(ADBKMain.Controls("TxtTELH"), Object).Text = Reader.Item(Reader.GetOrdinal("APHHOME"))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("APHOTH1").Value) Then CType(ADBKMain.Controls("TxtTELO"), Object).Text = rs.Fields("APHOTH1").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("APHWORK"))) Then CType(ADBKMain.Controls("TxtTELO"), Object).Text = Reader.Item(Reader.GetOrdinal("APHWORK"))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("AAGE").Value) Then CType(ADBKMain.Controls("TxtAGE"), Object).Text = rs.Fields("AAGE").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("AAGE"))) Then CType(ADBKMain.Controls("TxtAGE"), Object).Text = Reader.Item(Reader.GetOrdinal("AAGE"))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'If Not IsDBNull(rs.Fields("ABTHDAY").Value) Then CType(ADBKMain.Controls("TxtDOB"), Object).Text = rs.Fields("ABTHDAY").Value
			If Not IsDBNull(Reader.Item(Reader.GetOrdinal("DOB"))) Then CType(ADBKMain.Controls("TxtDOB"), Object).Text = Reader.Item(Reader.GetOrdinal("DOB"))
			'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
	End Sub
End Class