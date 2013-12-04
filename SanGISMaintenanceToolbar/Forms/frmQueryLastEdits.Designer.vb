<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryLastEdits
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
        Me.btnExporttoExcel = New System.Windows.Forms.Button()
        Me.txtdays = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnFindFtr = New System.Windows.Forms.Button()
        Me.lblEditCnt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.dgRprtEdits = New System.Windows.Forms.DataGridView()
        Me.cboLayerSelectName = New System.Windows.Forms.ComboBox()
        Me.lblRDNMSelectName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNoneFound = New System.Windows.Forms.Label()
        CType(Me.dgRprtEdits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExporttoExcel
        '
        Me.btnExporttoExcel.Location = New System.Drawing.Point(318, 379)
        Me.btnExporttoExcel.Name = "btnExporttoExcel"
        Me.btnExporttoExcel.Size = New System.Drawing.Size(109, 22)
        Me.btnExporttoExcel.TabIndex = 260
        Me.btnExporttoExcel.Text = "Export List to Excel"
        Me.btnExporttoExcel.UseVisualStyleBackColor = True
        '
        'txtdays
        '
        Me.txtdays.Location = New System.Drawing.Point(487, 12)
        Me.txtdays.Name = "txtdays"
        Me.txtdays.Size = New System.Drawing.Size(55, 20)
        Me.txtdays.TabIndex = 258
        Me.txtdays.Text = "0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(363, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(118, 15)
        Me.Label25.TabIndex = 257
        Me.Label25.Text = "edited in the past"
        '
        'btnFindFtr
        '
        Me.btnFindFtr.Enabled = False
        Me.btnFindFtr.Location = New System.Drawing.Point(7, 377)
        Me.btnFindFtr.Name = "btnFindFtr"
        Me.btnFindFtr.Size = New System.Drawing.Size(197, 23)
        Me.btnFindFtr.TabIndex = 256
        Me.btnFindFtr.Text = "Find Record in Map"
        Me.btnFindFtr.UseVisualStyleBackColor = True
        '
        'lblEditCnt
        '
        Me.lblEditCnt.AutoSize = True
        Me.lblEditCnt.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblEditCnt.Location = New System.Drawing.Point(617, 382)
        Me.lblEditCnt.Name = "lblEditCnt"
        Me.lblEditCnt.Size = New System.Drawing.Size(13, 13)
        Me.lblEditCnt.TabIndex = 254
        Me.lblEditCnt.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(548, 384)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Total Edits: "
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(453, 379)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 252
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(221, 377)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 251
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'dgRprtEdits
        '
        Me.dgRprtEdits.AllowUserToAddRows = False
        Me.dgRprtEdits.AllowUserToDeleteRows = False
        Me.dgRprtEdits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgRprtEdits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgRprtEdits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRprtEdits.Location = New System.Drawing.Point(7, 38)
        Me.dgRprtEdits.MultiSelect = False
        Me.dgRprtEdits.Name = "dgRprtEdits"
        Me.dgRprtEdits.ReadOnly = True
        Me.dgRprtEdits.RowHeadersVisible = False
        Me.dgRprtEdits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRprtEdits.Size = New System.Drawing.Size(646, 333)
        Me.dgRprtEdits.TabIndex = 250
        '
        'cboLayerSelectName
        '
        Me.cboLayerSelectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLayerSelectName.FormattingEnabled = True
        Me.cboLayerSelectName.Location = New System.Drawing.Point(111, 9)
        Me.cboLayerSelectName.MaxDropDownItems = 20
        Me.cboLayerSelectName.Name = "cboLayerSelectName"
        Me.cboLayerSelectName.Size = New System.Drawing.Size(246, 21)
        Me.cboLayerSelectName.TabIndex = 246
        '
        'lblRDNMSelectName
        '
        Me.lblRDNMSelectName.AutoSize = True
        Me.lblRDNMSelectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRDNMSelectName.Location = New System.Drawing.Point(15, 9)
        Me.lblRDNMSelectName.Name = "lblRDNMSelectName"
        Me.lblRDNMSelectName.Size = New System.Drawing.Size(90, 15)
        Me.lblRDNMSelectName.TabIndex = 248
        Me.lblRDNMSelectName.Text = "Show me the"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(548, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "day(s)."
        '
        'lblNoneFound
        '
        Me.lblNoneFound.AutoSize = True
        Me.lblNoneFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoneFound.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNoneFound.Location = New System.Drawing.Point(81, 184)
        Me.lblNoneFound.Name = "lblNoneFound"
        Me.lblNoneFound.Size = New System.Drawing.Size(461, 26)
        Me.lblNoneFound.TabIndex = 262
        Me.lblNoneFound.Text = "    No Records found for Search Criteria    "
        '
        'frmQueryLastEdits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 413)
        Me.Controls.Add(Me.lblNoneFound)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExporttoExcel)
        Me.Controls.Add(Me.txtdays)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btnFindFtr)
        Me.Controls.Add(Me.lblEditCnt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.dgRprtEdits)
        Me.Controls.Add(Me.cboLayerSelectName)
        Me.Controls.Add(Me.lblRDNMSelectName)
        Me.Name = "frmQueryLastEdits"
        Me.Text = "frmQueryLastEdits"
        CType(Me.dgRprtEdits,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnExporttoExcel As System.Windows.Forms.Button
    Friend WithEvents txtdays As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnFindFtr As System.Windows.Forms.Button
    Friend WithEvents lblEditCnt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents dgRprtEdits As System.Windows.Forms.DataGridView
    Friend WithEvents cboLayerSelectName As System.Windows.Forms.ComboBox
    Friend WithEvents lblRDNMSelectName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNoneFound As System.Windows.Forms.Label
End Class
