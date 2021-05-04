Public Class History
    Sub Tampilkan()
        clm = "*"
        tbl = "HistoryTR where user_id = '" & userid & "'"
        Tampil(clm, tbl)
        DGV.DataSource = ds.Tables(0)
        DGV.ReadOnly = True
    End Sub
    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampilkan()
    End Sub
End Class