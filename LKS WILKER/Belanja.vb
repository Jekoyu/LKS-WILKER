Public Class Belanja
    Sub Tampilkan()
        clm = "id,nama,gambar,harga,stok,keterangan"
        tbl = "tb_barang"
        Tampil(clm, tbl)
        DGV.DataSource = ds.Tables(0)
        DGV.ReadOnly = True
    End Sub
    Private Sub Belanja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampilkan()
    End Sub



    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        BtnNext.Enabled = True
        Rincian.LblNamaBarang.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        Rincian.Lblharga.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        Rincian.Lblstok.Text = DGV.Rows(e.RowIndex).Cells(4).Value
        Rincian.PictureBox1.BackgroundImage = Image.FromFile(DGV.Rows(e.RowIndex).Cells(2).Value)
        Rincian.LblKet.Text = DGV.Rows(e.RowIndex).Cells(5).Value
        Rincian.TbId.Text = DGV.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Rincian.ShowDialog()

    End Sub


End Class