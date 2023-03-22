Imports ZXing

Public Class FrmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> vbNullString Then
            Dim writer As New BarcodeWriter With {
                .Format = BarcodeFormat.QR_CODE
            }
            With writer
                .Options.Height = 200
                .Options.Width = 200
                .Options.Margin = 1
            End With
            Dim result = New Bitmap(writer.Write(TextBox1.Text))
            PictureBox1.Image = result
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        PictureBox1.Image = Nothing
    End Sub
End Class
