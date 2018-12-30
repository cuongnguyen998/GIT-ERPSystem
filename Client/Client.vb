Imports System.Xml

Public Class Client
    Public MyService As New ACSoft.Client.MyService.TService
    Public MyConfig As XmlDocument
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim Loader As New ACSoft.Client.frmLoad
        Loader.Session("URL") = "http://localhost:5529/TService.asmx"
        Loader.Session("TimeOut") = 200000
        Loader.TMyService(MyService)
        Loader.TMyConfig(MyConfig)
        MyService.Url = Loader.Session("URL")
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Hide()
    End Sub
End Class
