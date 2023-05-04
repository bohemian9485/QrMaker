Public Class FrmAbout

    Private Const GITHUB As String = "https://github.com/bohemian9485"

    Private Sub CenterMe()
        Dim frm As FrmAbout = Me
        CenterForm(FrmMain, frm)
    End Sub

    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Versioin " & My.Application.Info.Version.ToString
        Label3.Text = My.Application.Info.Copyright
        LinkLabel1.LinkArea = New LinkArea(0, 6)
        CenterMe()
    End Sub

    Private Sub VisitLink()
        LinkLabel1.LinkVisited = True
        Process.Start(GITHUB)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            VisitLink()
        Catch ex As Exception
            Dim unUsed = MessageBox.Show("Unable to open link that was clicked.",
                                         "Error",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error)
        End Try
    End Sub
End Class