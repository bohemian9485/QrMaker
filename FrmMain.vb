Imports ZXing

Public Class FrmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult
        If TextBox1.Text <> vbNullString Then
            If TextBox2.Text <> vbNullString Then
                Dim writer As New BarcodeWriter With {
                    .Format = BarcodeFormat.QR_CODE
                }
                With writer
                    .Options.Height = 200
                    .Options.Width = 200
                    .Options.Margin = 1
                End With
                Dim wifiPayload As String = $"WIFI:T:WPA;S:{TextBox1.Text};P:{TextBox2.Text};;"
                Dim pix = New Bitmap(writer.Write(wifiPayload))
                PictureBox1.Image = pix
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
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub
End Class
