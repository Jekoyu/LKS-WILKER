Public Class Rincian
    Dim skr As Integer
    Dim stok As Integer
    Dim hasil As Integer
    Dim harga As Integer
    Dim total As Integer
    Dim jumlah As Integer
    Sub AutoId()
        q = "select * from tb_transaksi order by id desc"
        Cari(q)
        If dr.HasRows Then
            TbIdTr.Text = "TRC" + Format(Microsoft.VisualBasic.Right(dr.Item("id"), 8) + 1, "00000000")
        Else
            TbIdTr.Text = "TRC00000001"
        End If
    End Sub
    Sub Keranjang()
        q = "insert into tb_keranjang(barang_id,user_id,jumlah,jumlah_harga) values('" & TbId.Text & "','" & userid & "','" & TbJml.Text & "','" & Lbltotal.Text & "')"
        ENQ(q)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        skr = TbJml.Text
        If skr > 1 Then
            hasil = skr - 1
            TbJml.Text = hasil
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        skr = TbJml.Text
        stok = Lblstok.Text
        If skr < stok Then
            hasil = skr + 1
            TbJml.Text = hasil
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Keranjang()
            MsgBox("Telah Di Masukkan Ke dalam Keranjang")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TbJml_TextChanged(sender As Object, e As EventArgs) Handles TbJml.TextChanged
        harga = Lblharga.Text
        skr = TbJml.Text
        total = harga * skr
        Lbltotal.Text = total

    End Sub

    Private Sub Rincian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbltotal.Text = Lblharga.Text
        AutoId()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Transaksi.LblHarga.Text = Lbltotal.Text
        q = "select * from tb_barang where id ='" & TbId.Text & "'"
        Cari(q)
        stok = dr.Item("stok")
        jumlah = TbJml.Text
        If jumlah <= stok Then
            stok = stok - jumlah
            q = "insert into tb_transaksi(id,user_id,tanggal,status,jumlah_harga) values('" & TbIdTr.Text & "','" & userid & "','" & Format(Now, "yyyy-MM-dd") & "','Baru','" & Lbltotal.Text & "')"

            ENQ(q)

            q = "insert into tb_dtl_transaksi(pesanan_id,barang_id,jumlah,jumlah_harga)  values('" & TbIdTr.Text & "','" & TbId.Text & "','" & jumlah & "','" & Lbltotal.Text & "')"
            ENQ(q)

            q = "update tb_barang set stok ='" & stok & "' where id = '" & TbId.Text & "' "
            ENQ(q)
        End If
        Belanja.Tampilkan()

        Transaksi.ShowDialog()
    End Sub
End Class