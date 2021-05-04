Public Class Login
    Sub SwitchPanel(ByVal pnl As Form)
        Home.PnlContent.Controls.Clear()
        pnl.TopLevel = False
        Home.PnlContent.Controls.Add(pnl)
        pnl.Show()
    End Sub
    Sub Kosongkan()
        TbUsername.Clear()
        TbPassword.Clear()
        TbUsername.Focus()
    End Sub
    Sub Login()
        q = "select * from tb_users where username = '" & TbUsername.Text & "'  and password = '" & TbPassword.Text & "'"
        Cari(q)
        If dr.HasRows Then
            role = dr.Item("role")
            If role = "1" Then
                Master.Admin()

                Dashboard.LblNama.Text = dr.Item("nama")
                Logout.LblNama.Text = dr.Item("nama")
                userid = dr.Item("id")
                Home.Visible = False
                Master.Show()
            ElseIf role = "2" Then
                Master.User()
                Home.Visible = False
                Dashboard.LblNama.Text = dr.Item("nama")
                Logout.LblNama.Text = dr.Item("nama")
                Home.Visible = False
                userid = dr.Item("id")
                Master.Show()
            End If
        Else
            MsgBox("Username/Email dan password Yang Anda Masukkan Salah")
        End If
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        SwitchPanel(Register)
        Register.Kosongkan()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Login()
    End Sub



    Private Sub TbPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            Login()
        End If
    End Sub
End Class