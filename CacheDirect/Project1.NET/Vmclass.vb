Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class cVMClass
	' VMCLASS.cls   CacheDirectサーバアクセスクラス
	' By T.Imai 97/9/1
	'           98/2/3  Wait method 追加
	'           98/2/22 MServer property 追加
	' H.S     1998/7/17 PrintLocalVariable
	'利用法
	'
	'   General declarations で
	'       Dim CacheDirect As New cVMClass
	'
	'   Form_Load イベントで
	'       Set CacheDirect.VisM = Vism1
	'
	'   Form_Unload イベントで
	'       Set CacheDirect = Nothing
	'
	'   Method
	'       Cache 関数($... または ＝...）実行時
	'           CacheDirect.Eval(Code) または CacheDirect.Evaluate(Code)
	'               Function Call(帰り値あり）
	'
	'       M コマンド列実行時
	'           CacheDirect.Exe(code) または CacheDirect.Execute(Code)
	'               Subroutine Call
	'       CacheDirect.Clear   P0,P1,P2,...,PLIST clear
	'       CacheDirect.DebugPrint  P0,P1,P2,...,PLIST Debug window へ表示
	'       CacheDirect.TimerStart CacheDirect.TimerStop M,TimerContinue
	'       CacheDirect.Wait
	'       CacheDirect.PLISTItem(i)
	'       CacheDirect.Piece(string,substr,pos1,pos2)
	'
	'   Property
	'       CacheDirect.NameSpace
	'       CacheDirect.PDELIM
	'       CacheDirect.Value
	'       CacheDirect.P0,CacheDirect.P1,CacheDirect.P2,...,CacheDirect.P9
	'       CacheDirect.PLIST
	'       CacheDirect.Error
	'       CacheDirect.ErrorName
	'       CacheDirect.MouseIcon
	'       CacheDirect.NoOfPLISTItem
	'
	'
	'   例
	'
	'   On Error Resume Next
	'   txtValue.Text = CacheDirect.Eval(txtEval.Text)
	'   If Err <> 0 Then
	'        ErrMsgBox
	'   End If
	'
	'
	'
	'
	
	Private m_Value, m_Name, m_Code, m_Error As Object
	Private m_ErrorName As String
	Private m_VisM As System.Windows.Forms.Control
	Private m_MouseIcon As Object
	Private m_MousePointer As Short
	Private m_ElapseTime, m_StartTime As Object
	Private m_EndTime As Double
	
	Public Sub Clear()
		
		' VisM データ転送用プロパティの初期化
		
		'UPGRADE_WARNING: オブジェクト m_VisM.P0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P0 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P1 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P2 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P3 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P3 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P4 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P4 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P5 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P5 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P6 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P6 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P7 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P7 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P8 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P8 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.P9 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.P9 = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.PLIST = ""
		
	End Sub
	
	
	Public Sub DebugPrint()
		
		'UPGRADE_WARNING: オブジェクト m_VisM.Namespace の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("NameSpace=" & m_VisM.Namespace)
		'UPGRADE_WARNING: オブジェクト m_VisM.MServer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("MServer=" & m_VisM.MServer)
		'UPGRADE_WARNING: オブジェクト m_VisM.Code の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("Code=" & m_VisM.Code)
		'UPGRADE_WARNING: オブジェクト m_VisM.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("Value=" & m_VisM.Value)
		'UPGRADE_WARNING: オブジェクト m_VisM.Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("Error=" & m_VisM.Error)
		'UPGRADE_WARNING: オブジェクト m_VisM.ErrorName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("ErrorName=" & m_VisM.ErrorName)
		'UPGRADE_WARNING: オブジェクト m_VisM.P0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P0=" & m_VisM.P0)
		'UPGRADE_WARNING: オブジェクト m_VisM.P1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P1=" & m_VisM.P1)
		'UPGRADE_WARNING: オブジェクト m_VisM.P2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P2=" & m_VisM.P2)
		'UPGRADE_WARNING: オブジェクト m_VisM.P3 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P3=" & m_VisM.P3)
		'UPGRADE_WARNING: オブジェクト m_VisM.P4 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P4=" & m_VisM.P4)
		'UPGRADE_WARNING: オブジェクト m_VisM.P5 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P5=" & m_VisM.P5)
		'UPGRADE_WARNING: オブジェクト m_VisM.P6 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P6=" & m_VisM.P6)
		'UPGRADE_WARNING: オブジェクト m_VisM.P7 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P7=" & m_VisM.P7)
		'UPGRADE_WARNING: オブジェクト m_VisM.P8 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P8=" & m_VisM.P8)
		'UPGRADE_WARNING: オブジェクト m_VisM.P9 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("P9=" & m_VisM.P9)
		'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("PDELIM=" & m_VisM.PDELIM)
		'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Debug.Print("PLIST=" & m_VisM.PLIST)
		
	End Sub
	
	Public Sub PrintLocalVariable()
		
		'　サーバで保持しているローカル変数を表示する
		
		Dim i As Short
		Dim Pieceno As Short
		
		'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.PDELIM = Chr(1)
		'UPGRADE_WARNING: オブジェクト m_VisM.Execute の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.Execute("$$GetLocal^VISMUTIL(1)")
		'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Pieceno = length(m_VisM.PLIST, m_VisM.PDELIM)
		For i = 1 To Pieceno
			'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Debug.Print(Piece(m_VisM.PLIST, m_VisM.PDELIM, i, i))
		Next i
		
	End Sub
	
	Public WriteOnly Property MouseIcon() As Object
		Set(ByVal Value As Object)
			
			'UPGRADE_ISSUE: Screen プロパティ Screen.MouseIcon はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト N の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Screen.MouseIcon = Value
			m_MousePointer = 99 'ccCoustom
			
		End Set
	End Property
	
	
	Public Property MousePointer() As Short
		Get
			
			MousePointer = m_MousePointer
			
		End Get
		Set(ByVal Value As Short)
			
			m_MousePointer = Value
			
		End Set
	End Property
	
	
	'UPGRADE_NOTE: Namespace は Namespace_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Public Property Namespace_Renamed() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.Namespace の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Namespace_Renamed = m_VisM.Namespace
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.Namespace の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.Namespace = Value
			
		End Set
	End Property
	
	Public ReadOnly Property ErrorName() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.ErrorName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ErrorName = m_VisM.ErrorName
			
		End Get
	End Property
	
	Public ReadOnly Property NoOfPLISTItem() As Short
		Get
			
			'PLISTの項目数を返す。
			
			'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NoOfPLISTItem = length(m_VisM.PLIST, m_VisM.PDELIM)
			
		End Get
	End Property
	
	'UPGRADE_NOTE: Error は Error_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Public ReadOnly Property Error_Renamed() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Error_Renamed = m_VisM.Error
			
		End Get
	End Property
	
	
	Public Property MServer() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.MServer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			MServer = m_VisM.MServer
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.MServer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.MServer = Value
			
		End Set
	End Property
	
	Public WriteOnly Property PDELIM() As String
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.PDELIM = Value
			
		End Set
	End Property
	
	Public ReadOnly Property ElapseTime() As Double
		Get
			
			'UPGRADE_WARNING: オブジェクト m_ElapseTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElapseTime = m_ElapseTime
			
		End Get
	End Property
	
	Public ReadOnly Property StartTime() As Double
		Get
			
			'UPGRADE_WARNING: オブジェクト m_StartTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			StartTime = m_StartTime
			
		End Get
	End Property
	
	Public ReadOnly Property EndTime() As Double
		Get
			Dim m_ndTime As Object
			
			'UPGRADE_WARNING: オブジェクト m_ndTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			EndTime = m_ndTime
			
		End Get
	End Property
	
	Public ReadOnly Property Value() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Value = m_VisM.Value
			
		End Get
	End Property
	
	Public WriteOnly Property VisM() As Object
		Set(ByVal Value As Object)
			
			m_VisM = Value
			
		End Set
	End Property
	
	
	
	Public Property P1() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P1 = m_VisM.P1
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P1 = Value
			
		End Set
	End Property
	
	
	Public Property P2() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P2 = m_VisM.P2
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P2 = Value
			
		End Set
	End Property
	
	
	Public Property P4() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P4 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P4 = m_VisM.P4
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P4 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P4 = Value
			
		End Set
	End Property
	Public Property P3() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P3 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P3 = m_VisM.P3
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P3 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P3 = Value
			
		End Set
	End Property
	
	
	Public Property P5() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P5 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P5 = m_VisM.P5
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P5 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P5 = Value
			
		End Set
	End Property
	
	
	Public Property P6() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P6 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P6 = m_VisM.P6
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P6 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P6 = Value
			
		End Set
	End Property
	
	
	Public Property P7() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P7 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P7 = m_VisM.P7
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P7 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P7 = Value
			
		End Set
	End Property
	Public Property P8() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P8 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P8 = m_VisM.P8
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P8 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P8 = Value
			
		End Set
	End Property
	
	
	Public Property P9() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P9 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P9 = m_VisM.P9
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P9 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P9 = Value
			
		End Set
	End Property
	
	
	
	Public Property P0() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			P0 = m_VisM.P0
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.P0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.P0 = Value
			
		End Set
	End Property
	
	
	Public Property PLIST() As String
		Get
			
			'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PLIST = m_VisM.PLIST
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_VisM.PLIST = Value
			
		End Set
	End Property
	
	Private Function M_Execute(ByRef Code As String) As String
		
		Dim iMouseSave As Short
		
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		iMouseSave = System.Windows.Forms.Cursor.Current
		
		M_Execute = ""
		'UPGRADE_WARNING: オブジェクト m_VisM.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.Value = ""
		
		If Code = "" Then Exit Function
		
		'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = m_MousePointer
		
		On Error GoTo ConnectError
		
		'UPGRADE_WARNING: オブジェクト m_VisM.Execute の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_VisM.Execute(Code)
		
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = iMouseSave
		
		'UPGRADE_WARNING: オブジェクト m_VisM.Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If m_VisM.Error <> 0 Then
			
			On Error Resume Next
			'UPGRADE_WARNING: オブジェクト m_VisM.Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト m_VisM.ErrorName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Err.Raise(Number:=(vbObjectError + m_VisM.Error), Description:=Code & "  " & m_VisM.ErrorName)
			
		End If
		
		'UPGRADE_WARNING: オブジェクト m_VisM.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		M_Execute = m_VisM.Value
		
		Exit Function
		
ConnectError: 
		
		'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = iMouseSave
		
		On Error Resume Next
		Err.Raise(Number:=(vbObjectError + 2000), Description:="VisM1.Execute 実行ができません。" & Chr(13) & Chr(10) & "Cache'　Directサーバが起動されていない？")
		
	End Function
	Public Function TimerStart() As Double
		
		'UPGRADE_WARNING: オブジェクト m_StartTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_StartTime = VB.Timer()
		'UPGRADE_WARNING: オブジェクト m_ElapseTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_ElapseTime = 0
		'UPGRADE_WARNING: オブジェクト m_StartTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TimerStart = m_StartTime
		
	End Function
	Public Function TimerContinue() As Double
		
		'UPGRADE_WARNING: オブジェクト m_StartTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_StartTime = VB.Timer()
		'UPGRADE_WARNING: オブジェクト m_StartTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TimerContinue = m_StartTime
		
	End Function
	
	Public Function TimerStop() As Double
		Dim t As Object
		
		m_EndTime = VB.Timer()
		'UPGRADE_WARNING: オブジェクト m_StartTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト t の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		t = m_EndTime - m_StartTime
		
		While (t < -0.01)
			
			'UPGRADE_WARNING: オブジェクト t の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			t = t + 86400
			
		End While
		
		'UPGRADE_WARNING: オブジェクト t の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト m_ElapseTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		m_ElapseTime = m_ElapseTime + t
		TimerStop = m_EndTime
		
	End Function
	
	Public Sub Wait(ByRef Waitseconds As Single)
		' 指定秒数待ち（ハング）
		
		Dim StartTime As Single
		StartTime = VB.Timer()
		Do While VB.Timer() < StartTime + Waitseconds
			System.Windows.Forms.Application.DoEvents()
		Loop 
		
	End Sub
	
	Public Function Eval(ByRef Code As String) As String
		
		Eval = M_Execute(Code)
		
	End Function
	
	Public Function Evaluate(ByRef Code As String) As String
		
		Evaluate = M_Execute(Code)
		
	End Function
	
	Public Sub Execute(ByRef Code As String)
		
		M_Execute(Code)
		
	End Sub
	
	Public Sub Exe(ByRef Code As String)
		
		M_Execute(Code)
		
	End Sub
	
	Public Function PLISTItem(ByVal ItemNo As Short) As String
		
		'　n番目のPLIST項目を返す。
		
		'UPGRADE_WARNING: オブジェクト m_VisM.PDELIM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト m_VisM.PLIST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PLISTItem = Piece(m_VisM.PLIST, m_VisM.PDELIM, ItemNo, ItemNo)
		
	End Function
	
	'UPGRADE_NOTE: str は str_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Public Function MPiece(ByVal str_Renamed As String, ByVal substr As String, ByVal pos As Short) As String
		
		'　$Piece関数互換
		
		MPiece = Piece(str_Renamed, substr, pos, pos)
		
	End Function
	
	'UPGRADE_NOTE: Class_Initialize は Class_Initialize_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Initialize_Renamed()
		
		m_MousePointer = 11 'ccHourglass
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Private Function length(ByVal fullstr As String, ByVal substr As String) As Short
		Dim j, i, c As Object
		Dim L As Short
		
		L = Len(substr)
		'UPGRADE_WARNING: オブジェクト c の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		c = 1
		'UPGRADE_WARNING: オブジェクト j の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		j = 1
		Do 
			'UPGRADE_WARNING: オブジェクト j の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト i の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			i = InStr(j, fullstr, substr)
			'UPGRADE_WARNING: オブジェクト i の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If i = 0 Then Exit Do
			'UPGRADE_WARNING: オブジェクト i の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト j の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			j = i + L
			'UPGRADE_WARNING: オブジェクト c の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			c = c + 1
		Loop 
		'UPGRADE_WARNING: オブジェクト c の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		length = c
		
	End Function
	
	Private Function Piece(ByVal fullstr As String, ByVal substr As String, ByVal P1 As Short, ByVal P2 As Short) As String
		Dim i As Short 'pointer for next found substr
		Dim j As Short 'pointer for start of next search
		Dim L As Short 'length of substr
		Dim c As Short 'piece counter
		Dim m1 As Short 'beginning offset for return value
		Dim m2 As Short 'ending offset for return value
		
		If P1 < 1 Then P1 = 1
		If P1 > P2 Then Piece = "" : Exit Function
		
		L = Len(substr)
		m1 = Len(fullstr) + 1 'default values to use for MID$() in the end
		m2 = Len(fullstr) 'if they are never modified in the do-loop
		
		i = -L + 1 : j = 1 : c = 1
		Do 
			If c = P1 Then m1 = i + L
			If c = P2 + 1 Then m2 = i - 1 : Exit Do
			i = InStr(j, fullstr, substr)
			If i = 0 Then Exit Do
			j = i + L
			c = c + 1
		Loop 
		
		Piece = Mid(fullstr, m1, m2 - m1 + 1)
		
	End Function
End Class