Public Class Laporan
    Sub tampilkan()
        clm = "*"
        tbl = "Laporan"
        Tampil(clm, tbl)
        DGV.DataSource = ds.Tables(0)
        DGV.ReadOnly = True

    End Sub
    Private Sub Laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkan()

    End Sub
    Sub export()
        EApp = New Microsoft.Office.Interop.Excel.Application
        EWB = EApp.Workbooks.Add(missvalue)
        EWS = EWB.Worksheets("Sheet1")
        For a = 0 To DGV.RowCount - 2
            For b = 0 To DGV.ColumnCount - 1
                For c = 1 To DGV.ColumnCount - 1
                    EWS.Cells(1, c) = DGV.Columns(c - 1).HeaderText
                    EWS.Cells(a + 2, b + 1) = DGV(b, a).Value
                Next
            Next
        Next
        With SaveFileDialog1
            .Filter = "EXCEL|*.xlx;*.xlsx"
        End With
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            EWS.SaveAs(SaveFileDialog1.FileName)
            EWB.Close()
            EApp.Quit()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        export()
    End Sub
End Class