Imports ZXing
Imports System.IO

Public Class FrmMain
    ' holder for generated QR code
    Private pix As Bitmap

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult
        ' Validates user input
        If TextBox1.Text <> vbNullString Then
            If TextBox2.Text <> vbNullString Then
                ' Variables for readability
                Dim networkEncryption As String = ComboBox1.Text
                Dim networkName As String = TextBox1.Text
                Dim password As String = TextBox2.Text
                ' Creates barcode writer
                Dim writer As New BarcodeWriter With {
                    .Format = BarcodeFormat.QR_CODE
                }
                With writer
                    .Options.Height = 200
                    .Options.Width = 200
                    .Options.Margin = 1
                End With
                ' The one-liner below was created after getting the idea from the query in ChatGPT
                Dim wifiPayload As String = $"WIFI:T:{networkEncryption};S:{networkName};P:{password};;"
                pix = New Bitmap(writer.Write(wifiPayload))
                PictureBox1.Image = pix
                Button2.Enabled = True
            Else
                TextBox2.Focus()
                result = MessageBox.Show("WIFI password is required.",
                                         "Incomplete Data",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information)
            End If
        Else
            TextBox1.Focus()
            result = MessageBox.Show("WIFI SSID is required.",
                                     "Incomplete Data",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        PictureBox1.Image = Nothing
        Button2.Enabled = False
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Shows application version number
        Text &= " v" & My.Application.Info.Version.ToString
        ' Initializes controls
        ComboBox1.SelectedIndex = 0
        Button2.Enabled = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        PictureBox1.Image = Nothing
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Uses WIFI network name as image file name
        SaveFileDialog1.FileName = TextBox1.Text
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Using ms As New MemoryStream()
                pix.Save(ms, Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()
                File.WriteAllBytes(SaveFileDialog1.FileName, byteImage)
            End Using
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        ' Shows FrmAbout
        Dim frm As New FrmAbout
        With frm
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Static hideMode As Boolean
        TextBox2.UseSystemPasswordChar = hideMode
        hideMode = Not hideMode
        If hideMode Then
            Button3.ImageIndex = 1
        Else
            Button3.ImageIndex = 0
        End If
    End Sub
End Class
