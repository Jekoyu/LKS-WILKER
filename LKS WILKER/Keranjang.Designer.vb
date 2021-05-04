<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Keranjang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnCO = New System.Windows.Forms.Button()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCOSEMUA = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Tbid = New System.Windows.Forms.TextBox()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCO
        '
        Me.BtnCO.Enabled = False
        Me.BtnCO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCO.Location = New System.Drawing.Point(598, 85)
        Me.BtnCO.Name = "BtnCO"
        Me.BtnCO.Size = New System.Drawing.Size(120, 23)
        Me.BtnCO.TabIndex = 5
        Me.BtnCO.Text = "CHECK OUT"
        Me.BtnCO.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(39, 114)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(823, 523)
        Me.DGV.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(377, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "KERANJANG"
        '
        'BtnCOSEMUA
        '
        Me.BtnCOSEMUA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCOSEMUA.Location = New System.Drawing.Point(724, 85)
        Me.BtnCOSEMUA.Name = "BtnCOSEMUA"
        Me.BtnCOSEMUA.Size = New System.Drawing.Size(128, 23)
        Me.BtnCOSEMUA.TabIndex = 6
        Me.BtnCOSEMUA.Text = "CHECK OUT SEMUA"
        Me.BtnCOSEMUA.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(472, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "DELETE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Tbid
        '
        Me.Tbid.Location = New System.Drawing.Point(712, 13)
        Me.Tbid.Name = "Tbid"
        Me.Tbid.Size = New System.Drawing.Size(100, 22)
        Me.Tbid.TabIndex = 8
        Me.Tbid.Visible = False
        '
        'Keranjang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 670)
        Me.Controls.Add(Me.Tbid)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnCOSEMUA)
        Me.Controls.Add(Me.BtnCO)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Keranjang"
        Me.Text = "Keranjang"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCO As Button
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCOSEMUA As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Tbid As TextBox
End Class
