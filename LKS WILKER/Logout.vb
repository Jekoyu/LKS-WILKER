Public Class Logout
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As String
        r = MsgBox("Yakin Logout", vbYesNo)
        If r = vbYes Then
            Master.Visible = False
            Home.Show()
            Login.Kosongkan()
            Master.Close()
        Else
        End If
    End Sub
End Class