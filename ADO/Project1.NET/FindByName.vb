Option Strict Off
Option Explicit On
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	Dim cnn1 As New ADODB.Connection
	Dim rs As New ADODB.Recordset
	Const m_classname As String = "User.ADBK"
	Dim id As Object
	
	'UPGRADE_NOTE: ShowDialog �� ShowDialog_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public Function ShowDialog_Renamed(ByRef conn As ADODB.Connection) As ADODB.Recordset
		
		cnn1 = conn
		
		Me.ShowDialog()
		
		ShowDialog_Renamed = rs
		
	End Function
	
	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click
		
		Me.Hide()
		
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		
		' ���O�̃��X�g���擾
		ListLookupName.Items.Clear()
		'UPGRADE_NOTE: �I�u�W�F�N�g rs ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		rs = Nothing
		If TxtSNAME.Text = "" Then
			rs.Open("Select ANAME from ADBK", cnn1)
		Else
			rs.Open("Select ANAME from ADBK WHERE ANAME %STARTSWITH '" & TxtSNAME.Text & "'", cnn1)
		End If
		'�@�擾�������O���X�g��ListBox�ɓW�J
		While Not rs.EOF
			ListLookupName.Items.Add(rs.Fields("ANAME").Value)
			rs.MoveNext()
		End While
		
	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name �� name_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim name_Renamed As String
		name_Renamed = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
		'UPGRADE_NOTE: �I�u�W�F�N�g rs ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		rs = Nothing
		rs.Open("SELECT * FROM ADBK WHERE ANAME = '" & name_Renamed & "'", cnn1,  , ADODB.LockTypeEnum.adLockPessimistic)
		'�����t�H�[�����\��
		Me.Hide()
		If rs.EOF Then
			MsgBox("�I�u�W�F�N�g���J�����Ƃ��ł��܂���B")
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			id = rs.Fields("AID").Value
			'�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("ANAME").Value) Then CType(ADBKMain.Controls("TxtNAME"), Object).Text = rs.Fields("ANAME").Value
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("AZIP").Value) Then CType(ADBKMain.Controls("TxtZIP"), Object).Text = rs.Fields("AZIP").Value
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("ASTREET").Value) Then CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = rs.Fields("ASTREET").Value
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("APHHOME").Value) Then CType(ADBKMain.Controls("TxtTELH"), Object).Text = rs.Fields("APHHOME").Value
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("APHOTH1").Value) Then CType(ADBKMain.Controls("TxtTELO"), Object).Text = rs.Fields("APHOTH1").Value
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("AAGE").Value) Then CType(ADBKMain.Controls("TxtAGE"), Object).Text = rs.Fields("AAGE").Value
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(rs.Fields("ABTHDAY").Value) Then CType(ADBKMain.Controls("TxtDOB"), Object).Text = rs.Fields("ABTHDAY").Value
			'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
	End Sub
End Class