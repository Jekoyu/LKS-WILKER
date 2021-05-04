Public Class Register
    Dim id As String
    Sub SwitchPanel(ByVal pnl As Form)
        Home.PnlContent.Controls.Clear()
        pnl.TopLevel = False
        Home.PnlContent.Controls.Add(pnl)
        pnl.Show()
    End Sub
    Sub AutoId()
        q = "select * from tb_users order by id desc"
        Cari(q)
        If dr.HasRows Then
            TbId.Text = "USR" + Format(Microsoft.VisualBasic.Right(dr.Item("id"), 8) + 1, "00000000")
        Else
            TbId.Text = "USR00000001"
        End If
    End Sub
    Sub Kosongkan()
        AutoId()
        TbNama.Clear()
        TbUsername.Clear()
        TbEmail.Clear()
        TbPassword.Clear()
        TbCPassword.Clear()
        TbNama.Focus()
    End Sub
    Sub Register()
        q = "insert into tb_users(id,nama,username,email,password,role) values('" & TbId.Text & "','" & TbNama.Text & "','" & TbUsername.Text & "','" & TbEmail.Text & "','" & TbPassword.Text & "','2')"
        ENQ(q)
        MsgBox("Success", MsgBoxStyle.Information)
    End Sub
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoId()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        SwitchPanel(Login)
        Login.Kosongkan()
    End Sub

    Private Sub BtnReg_Click(sender As Object, e As EventArgs) Handles BtnReg.Click
        If TbId.Text = "" Or TbUsername.Text = "" Or TbEmail.Text = "" Or TbNama.Text = "" Or TbPassword.Text = "" Then
            MsgBox("Terdapat Kolom Yang Kosong", MsgBoxStyle.Critical)
        Else
            If TbPassword.Text = TbCPassword.Text Then
                Register()

                Kosongkan()
            Else
                MsgBox("Password dan Confirm Password tidak sama")
            End If

        End If
    End Sub

End Class