Public Class Profile
    Sub Getdata()
        q = "select * from tb_users where id = '" & userid & "'"
        Cari(q)
        If dr.HasRows Then
            Try

                TbNama.Text = dr.Item("nama")
                Tbusername.Text = dr.Item("username")
                Tbemail.Text = dr.Item("email")
                TbPasword.Text = dr.Item("username")
                TbAlamat.Text = dr.Item("alamat")
                TbNohp.Text = dr.Item("nohp")
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub Updatekan()
        If TbNama.Text = "" Or Tbusername.Text = "" Or Tbemail.Text = "" Or TbPasword.Text = "" Or TbCPas.Text = "" Or TbAlamat.Text = "" Or TbNohp.Text = "" Then
            MsgBox("terdapat kolom kosong")
        Else
            If TbPasword.Text = TbCPas.Text Then
                q = "update tb_users set nama = '" & TbNama.Text & "', username = '" & Tbusername.Text & "',email = '" & Tbemail.Text & "',password ='" & TbPasword.Text & "',alamat = '" & TbAlamat.Text & "',nohp = '" & TbNohp.Text & "' where id = '" & userid & "'"
                ENQ(q)
            Else
                MsgBox("Password dan Confirm Password Tidak sama")
            End If
        End If
    End Sub

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Getdata()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Updatekan()
        Getdata()
    End Sub
End Class