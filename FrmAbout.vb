Public Class FrmAbout

    Private Sub CenterMe()
        Dim frm As FrmAbout = Me
        CenterForm(FrmMain, frm)
    End Sub

    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Versioin " & My.Application.Info.Version.ToString
        Label3.Text = My.Application.Info.Copyright
        CenterMe()
    End Sub
End Class