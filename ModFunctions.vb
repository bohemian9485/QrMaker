Module ModFunctions
    Friend Sub CenterForm(Mother As Form, Child As Form)
        ' Positions the form
        With Child
            ' Left of Child
            If .Width <= Mother.Width Then
                .Left = Mother.Left + Int((Mother.Width - .Width) / 2)
            Else
                .Left = Mother.Left - Int((.Width - Mother.Width) / 2)
            End If
            ' Top of Child
            If .Height <= Mother.Height Then
                .Top = Mother.Top + Int((Mother.Height - .Height) / 2)
            Else
                .Top = Mother.Top - Int((.Height - Mother.Height) / 2)
            End If
        End With
    End Sub
End Module
