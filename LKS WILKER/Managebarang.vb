Public Class Managebarang
    Sub Tampilkan()
        clm = "*"
        tbl = "tb_barang"
        Tampil(clm, tbl)
        DGV.DataSource = ds.Tables(0)
        DGV.ReadOnly = True
    End Sub
    Sub AutoId()
        q = "select * from tb_barang order by id desc"
        Cari(q)
        If dr.HasRows Then
            TbId.Text = "ITM" + Format(Microsoft.VisualBasic.Right(dr.Item("id"), 8) + 1, "00000000")
        Else
            TbId.Text = "ITM00000001"
        End If
    End Sub
    Sub Kosongkan()
        AutoId()
        Tampilkan()
        TbNama.Clear()
        TbGambar.Clear()
        TbHarga.Clear()
        TbStok.Clear()
        TbKeterangan.Clear()
        TbNama.Focus()
    End Sub
    Sub Delete()
        q = "delete from tb_barang where id = '" & TbId.Text & "'"
        ENQ(q)
    End Sub
    Sub Updatekan()
        q = "select * from tb_barang where id = '" & TbId.Text & "'"
        Cari(q)
        If dr.HasRows Then
            q = "update tb_barang set nama = '" & TbNama.Text & "' ,gambar = '" & TbGambar.Text & "',stok = '" & TbStok.Text & "',keterangan = '" & TbKeterangan.Text & "' where id = '" & TbId.Text & "'"
            ENQ(q)
        Else
            Tambahkan()
        End If
    End Sub
    Sub Tambahkan()
        q = "insert into tb_barang(id,nama,gambar,harga,stok,keterangan) values('" & TbId.Text & "','" & TbNama.Text & "','" & TbGambar.Text & "','" & TbHarga.Text & "','" & TbStok.Text & "','" & TbKeterangan.Text & "')"
        ENQ(q)
    End Sub
    Private Sub Managebarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With OpenFileDialog1
            .Filter = "IMAGE FILES|*.jpg;*.png;*.bmp"
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TbGambar.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub BtnInsert_Click(sender As Object, e As EventArgs) Handles BtnInsert.Click
        Try
            Updatekan()
            Kosongkan
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        Try
            q = "select * from tb_barang where id = '" & DGV.Rows(e.RowIndex).Cells(0).Value & "'"
            Cari(q)
            TbId.Text = dr.Item("id")
            TbNama.Text = dr.Item("nama")
            TbGambar.Text = dr.Item("gambar")
            TbHarga.Text = dr.Item("harga")
            TbStok.Text = dr.Item("stok")
            TbKeterangan.Text = dr.Item("keterangan")
        Catch ex As Exception

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


End Class