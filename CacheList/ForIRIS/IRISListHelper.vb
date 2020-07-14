Imports Microsoft.VisualBasic
Imports InterSystems.Data.IRISClient
Imports InterSystems.Data.IRISClient.ADO

Public Class IRISListHelper

	Public WithEvents Listbox1 As System.Windows.Forms.ListBox
	Public SQLText As String

	Public Sub Run(ByVal columnname As String, ByVal iris_conn As IRISConnection, ParamArray params() As String)

		' 名前のリストを取得
		Dim Command As IRISCommand = New IRISCommand(SQLText, iris_conn)
		Dim i As Integer
		Dim irisparams(10) As IRISParameter
		For Each param As String In params
			irisparams(i) = New IRISParameter("param" + i.ToString(), IRISDbType.NVarChar)
			irisparams(i).Value = params(i)
			Command.Parameters.Add(irisparams(i))
		Next
		Dim Reader As IRISDataReader = Command.ExecuteReader()

		While Reader.Read()
			Listbox1.Items.Add(Reader.Item(Reader.GetOrdinal(columnname)))
		End While
		Reader.Close()
		Command.Dispose()

	End Sub


End Class
