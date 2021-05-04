Public Class ManageUser
    Sub Tampilkan()
        clm = "*"
        tbl = "tb_users"
        Tampil(clm, tbl)
        DGV.DataSource = ds.Tables(0)
        DGV.ReadOnly = True
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
        Tampilkan()
        TbNama.Clear()
        TbUsername.Clear()
        TbEmail.Clear()
        TbPassword.Clear()
        TbAlamat.Clear()
        TbNoHp.Clear()
        TbNama.Focus()

    End Sub
    Sub Delete()
        q = "delete from tb_users where id = '" & TbId.Text & "'"
        ENQ(q)
    End Sub
    Sub Updatekan()
        q = "select * from tb_users where id = '" & TbId.Text & "'"
        Cari(q)
        If dr.HasRows Then
            q = "update tb_users set nama = '" & TbNama.Text & "',username ='" & TbUsername.Text & "',email = '" & TbEmail.Text & "',password = '" & TbPassword.Text & "',alamat = '" & TbAlamat.Text & "',nohp = '" & TbNoHp.Text & "' where id = '" & TbId.Text & "' "
            ENQ(q)
        Else
            Tambahkan()
        End If
    End Sub
    Sub Tambahkan()
        q = "insert into tb_users(id,nama,username,email,password,alamat,nohp,role) values('" & TbId.Text & "','" & TbNama.Text & "','" & TbUsername.Text & "','" & TbEmail.Text & "','" & TbPassword.Text & "','" & TbAlamat.Text & "','" & TbNoHp.Text & "','2')"
        ENQ(q)
    End Sub
    Private Sub ManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan()
    End Sub

    Private Sub BtnInsert_Click(sender As Object, e As EventArgs) Handles BtnInsert.Click
        Try
            Updatekan()
            Kosongkan()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btndelete_Click(sender As Object, e As EventArgs) Handles Btndelete.Click
        Try
            Delete()
            Kosongkan()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btncancel_Click(sender As Object, e As EventArgs) Handles Btncancel.Click
        Kosongkan()
    End Sub



    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        Try
            q = "select * from tb_users where id = '" & DGV.Rows(e.RowIndex).Cells(0).Value & "'"
            Cari(q)


            TbId.Text = dr.Item("id")
            TbNama.Text = dr.Item("nama")
            TbUsername.Text = dr.Item("username")
            TbEmail.Text = dr.Item("email")
            TbPassword.Text = dr.Item("password")
            TbAlamat.Text = dr.Item("alamat")
            TbNoHp.Text = dr.Item("nohp")

        Catch ex As Exception

        End Try
    End Sub


End Class