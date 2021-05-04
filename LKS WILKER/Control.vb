Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Module Control
    Public conn As SqlConnection
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public EApp As Excel.Application
    Public EWB As Excel.Workbook
    Public missvalue As Object = System.Reflection.Missing.Value
    Public EWS As Excel.Worksheet
    Public role As String
    Public q As String
    Public clm, tbl As String
    Public userid As String
    Public Sub Koneksi()
        Try
            conn = New SqlConnection("Data Source=DESKTOP-VOQEHKC\SQLEXPRESS;Initial Catalog=db_okecell;Integrated Security=True;MultipleActiveResultSets=True")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Cari(ByVal q As String) As Boolean
        Try
            Koneksi()
            cmd = New SqlCommand(q, conn)
            dr = cmd.ExecuteReader
            dr.Read()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Function Tampil(ByVal clm As String, tbl As String) As Boolean
        Try
            Koneksi()
            da = New SqlDataAdapter("select " + clm + " from " + tbl, conn)
            ds = New DataSet
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function
    Function ENQ(ByVal q As String) As Boolean
        Try
            Koneksi()
            cmd = New SqlCommand(q, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function
End Module
