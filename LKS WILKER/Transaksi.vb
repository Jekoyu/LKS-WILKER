Public Class Transaksi
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Transaksi berhasil di check Out silahkan melakaukan pembayaran", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class