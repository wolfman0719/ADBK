Imports System.Text
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Public Class setup
    Public co As New connectioninfo()
    Public Sub LoadSetupFile(ByVal jsonFilePath As String)
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonStr As String = ""

        'ファイルからJson文字列を読み込む
        Using sr As New System.IO.StreamReader(jsonFilePath, enc)
            jsonStr = sr.ReadToEnd()
        End Using

        'Json文字列をJson形式データに復元する
        Dim jsonObj As Object = JsonConvert.DeserializeObject(jsonStr)

        co.hostname = jsonObj("Hhostname")
        co.port = jsonObj("port")
        co.username = jsonObj("username")
        co.password = jsonObj("password")
        co.irisnamespace = jsonObj("irisnamespace")

    End Sub

End Class

Public Class connectioninfo
    Public Property hostname As String
    Public Property port As Integer
    Public Property username As String
    Public Property password As String
    Public Property irisnamespace As String
End Class
