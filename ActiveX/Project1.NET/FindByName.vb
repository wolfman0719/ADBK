Option Strict Off
Option Explicit On
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	Dim RS As CacheObject.ResultSet
	Dim m_factory As CacheObject.Factory
	Dim m_object As CacheObject.ObjInstance
	Const m_classname As String = "User.ADBK"
	Dim id As Object
	
	'UPGRADE_NOTE: ShowDialog �� ShowDialog_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
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
		
		' ���O�̃��X�g���擾
		ListLookupName.Items.Clear()
		RS = m_factory.ResultSet("User.ADBK", "ByName")
		RS.Execute(TxtSNAME.Text) ' ByName takes a single argument
		
		'�@�擾�������O���X�g��ListBox�ɓW�J
		While RS.Next
			'UPGRADE_WARNING: �I�u�W�F�N�g RS.GetDataByName() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ListLookupName.Items.Add(RS.GetDataByName("ANAME"))
		End While
		
	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		'UPGRADE_NOTE: name �� name_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim name_Renamed As String
		name_Renamed = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
		RS = m_factory.DynamicSQL("SELECT * FROM ADBK WHERE ANAME = ?")
		RS.Execute(name_Renamed) ' �l��'?'�Ƀo�C���h
		RS.Next()
		'�����t�H�[�����\��
		Me.Hide()
		'UPGRADE_WARNING: �I�u�W�F�N�g RS.GetDataByName() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		id = RS.GetDataByName("AID")
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_object = m_factory.OpenId(m_classname, id)
		If m_object Is Nothing Then
			MsgBox("�I�u�W�F�N�g���J�����Ƃ��ł��܂���B")
		Else
			'�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ANAME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtNAME"), Object).Text = m_object.ANAME
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.AZIP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtZIP"), Object).Text = m_object.AZIP
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ASTREET �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = m_object.ASTREET
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.APHHOME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtTELH"), Object).Text = m_object.APHHOME
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.APHOTH1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtTELO"), Object).Text = m_object.APHOTH1
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.AAGE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtAGE"), Object).Text = m_object.AAGE
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ABTHDAY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("TxtDOB"), Object).Text = m_object.ABTHDAY
			'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(ADBKMain.Controls("lblAID"), Object).Text = id
		End If
	End Sub
End Class