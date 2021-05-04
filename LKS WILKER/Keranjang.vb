Public Class Keranjang
    Dim idbarang As String
    Dim harga As String
    Dim total As Integer = 0
    Dim jumlah As Integer
    Dim stok As Integer
    Sub AutoId()
        q = "select * from tb_transaksi order by id desc"
        Cari(q)
        If dr.HasRows Then
            Tbid.Text = "TRC" + Format(Microsoft.VisualBasic.Right(dr.Item("id"), 8) + 1, "00000000")
        Else
            Tbid.Text = "TRC00000001"
        End If
    End Sub
    Sub Tampilkan()
        AutoId()
        clm = "*"
        tbl = "Keranjang where user_id = '" & userid & "'"
        Tampil(clm, tbl)
        DGV.DataSource = ds.Tables(0)
        DGV.ReadOnly = True
    End Sub
    Sub Transaksi1()
        q = "select * from tb_barang where id ='" & idbarang & "'"
        Cari(q)
        stok = dr.Item("stok")
        If jumlah <= stok Then
            stok = stok - jumlah
            q = "insert into tb_transaksi(id,user_id,tanggal,status,jumlah_harga) values('" & Tbid.Text & "','" & userid & "','" & Format(Now, "yyyy-MM-dd") & "','Baru','" & harga & "')"
            ENQ(q)
            q = "insert into tb_dtl_transaksi(pesanan_id,barang_id,jumlah,jumlah_harga)  values('" & Tbid.Text & "','" & idbarang & "','" & jumlah & "','" & harga & "')"
            ENQ(q)
            q = "update tb_barang set stok ='" & stok & "' where id = '" & userid & "' "
            Delete()
        End If
    End Sub
    Sub Delete()
        q = "delete from tb_keranjang where barang_id = '" & idbarang & "' and user_id = '" & userid & "'"
        ENQ(q)
        Tampilkan()
    End Sub
    Sub Transaksi2()
        stok = 0

        For i = 0 To DGV.Rows.Count - 2
            total = total + DGV.Item(6, i).Value
            q = "select * from tb_barang where id = '" & DGV.Item(1, i).Value & "'"
            Cari(q)
            q = "insert into tb_transaksi(id,user_id,tanggal,status,jumlah_harga) values('" & Tbid.Text & "','" & userid & "','" & Format(Now, "yyyy-MM-dd") & "','Baru','" & total & "')"

            Try
                cmd = New SqlClient.SqlCommand(q, conn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try


            If dr.HasRows Then
                stok = dr.Item("stok")
                If DGV.Item(5, i).Value <= stok Then

                    stok = stok - DGV.Item(5, i).Value
                    q = "insert into tb_dtl_transaksi(pesanan_id,barang_id,jumlah,jumlah_harga) values('" & Tbid.Text & "','" & DGV.Item(1, i).Value & "','" & DGV.Item(5, i).Value & "','" & DGV.Item(6, i).Value & "')"
                    ENQ(q)
                    q = "update tb_barang set stok  = '" & stok & "' where id = '" & DGV.Item(1, i).Value & "'"
                    ENQ(q)
                    q = "delete from tb_keranjang where user_id = '" & userid & "' and barang_id = '" & DGV.Item(1, i).Value & "'"
                    ENQ(q)

                Else
                    MsgBox("Stok Tidak mencukupi")
                End If
            End If
        Next

        Transaksi.LblHarga.Text = total
        Transaksi.Show()

    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        Try
            Button1.Enabled = True
            BtnCO.Enabled = True
            idbarang = DGV.Rows(e.RowIndex).Cells(1).Value
            harga = DGV.Rows(e.RowIndex).Cells(6).Value
            jumlah = DGV.Rows(e.RowIndex).Cells(5).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Keranjang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampilkan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Delete()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnCO_Click(sender As Object, e As EventArgs) Handles BtnCO.Click
        Transaksi.LblHarga.Text = harga
        Transaksi.tbid.Text = idbarang
        Transaksi1()
        Transaksi.ShowDialog()
    End Sub

    Private Sub BtnCOSEMUA_Click(sender As Object, e As EventArgs) Handles BtnCOSEMUA.Click
        Try
            Transaksi2()
            Tampilkan()
        Catch ex As Exception

        End Try

    End Sub


End Class