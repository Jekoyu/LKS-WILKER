Public Class Home
    Sub SwitchPanel(ByVal pnl As Form)
        PnlContent.Controls.Clear()
        pnl.TopLevel = False
        PnlContent.Controls.Add(pnl)
        pnl.Show()
    End Sub
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SwitchPanel(Login)
    End Sub
End Class
