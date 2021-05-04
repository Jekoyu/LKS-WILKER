Public Class Master
    Sub Admin()
        BtnHome.Visible = True
        BtnManageBarang.Visible = True
        BtnManageUser.Visible = True
        BtnLaporan.Visible = True
        BtnAbout.Visible = True
        Button3.Visible = True
    End Sub
    Sub User()
        BtnHome.Visible = True
        BtnBelanja.Visible = True
        BtnKeranjang.Visible = True
        BtnHistoryBelanja.Visible = True
        BtnAbout.Visible = True
        BtnLogout.Visible = True
        Button3.Visible = True
    End Sub

    Sub switchpanel(ByVal panel As Form)
        PnlConten.Controls.Clear()
        panel.TopLevel = False
        PnlConten.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Master_Load(sender As Object, e As EventArgs) Handles Me.Load
        switchpanel(Dashboard)
    End Sub

    Private Sub BtnManageUser_Click(sender As Object, e As EventArgs) Handles BtnManageUser.Click
        switchpanel(ManageUser)
        ManageUser.Kosongkan()


    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles BtnHome.Click
        switchpanel(Dashboard)
    End Sub

    Private Sub BtnManageBarang_Click(sender As Object, e As EventArgs) Handles BtnManageBarang.Click
        switchpanel(Managebarang)
        Managebarang.Kosongkan()
    End Sub

    Private Sub BtnBelanja_Click(sender As Object, e As EventArgs) Handles BtnBelanja.Click
        switchpanel(Belanja)
        Belanja.Tampilkan()

    End Sub

    Private Sub BtnHistoryBelanja_Click(sender As Object, e As EventArgs) Handles BtnHistoryBelanja.Click
        switchpanel(History)
        History.tampilkan
    End Sub

    Private Sub BtnKeranjang_Click(sender As Object, e As EventArgs) Handles BtnKeranjang.Click
        switchpanel(Keranjang)
        Keranjang.Tampilkan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As String
        r = MsgBox("Yakin Tutup", vbYesNo)
        If r = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles BtnAbout.Click
        switchpanel(About)
    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        switchpanel(Profile)
        Profile.Getdata()

    End Sub

    Private Sub BtnLaporan_Click(sender As Object, e As EventArgs) Handles BtnLaporan.Click
        switchpanel(Laporan)
        Laporan.tampilkan()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        switchpanel(Logout)
    End Sub


End Class