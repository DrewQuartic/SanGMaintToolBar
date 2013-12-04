<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQueryLots
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnLotExit = New System.Windows.Forms.Button()
        Me.dgLotInfo = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblLotFndCnt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLOTSubDivID = New System.Windows.Forms.TextBox()
        Me.lblNoneFound = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboLotSort = New System.Windows.Forms.ComboBox()
        Me.btnExporttoExcel = New System.Windows.Forms.Button()
        CType(Me.dgLotInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLotExit
        '
        Me.btnLotExit.Location = New System.Drawing.Point(511, 363)
        Me.btnLotExit.Name = "btnLotExit"
        Me.btnLotExit.Size = New System.Drawing.Size(79, 23)
        Me.btnLotExit.TabIndex = 1
        Me.btnLotExit.Text = "Exit"
        Me.btnLotExit.UseVisualStyleBackColor = True
        '
        'dgLotInfo
        '
        Me.dgLotInfo.AllowUserToAddRows = False
        Me.dgLotInfo.AllowUserToDeleteRows = False
        Me.dgLotInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLotInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgLotInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLotInfo.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgLotInfo.Location = New System.Drawing.Point(12, 40)
        Me.dgLotInfo.Name = "dgLotInfo"
        Me.dgLotInfo.ReadOnly = True
        Me.dgLotInfo.RowHeadersVisible = False
        Me.dgLotInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgLotInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgLotInfo.Size = New System.Drawing.Size(597, 317)
        Me.dgLotInfo.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 360)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 239
        Me.Label11.Text = "Num of Lots"
        '
        'lblLotFndCnt
        '
        Me.lblLotFndCnt.AutoSize = True
        Me.lblLotFndCnt.Location = New System.Drawing.Point(83, 360)
        Me.lblLotFndCnt.Name = "lblLotFndCnt"
        Me.lblLotFndCnt.Size = New System.Drawing.Size(13, 13)
        Me.lblLotFndCnt.TabIndex = 243
        Me.lblLotFndCnt.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "SubDivID"
        '
        'txtLOTSubDivID
        '
        Me.txtLOTSubDivID.Location = New System.Drawing.Point(97, 14)
        Me.txtLOTSubDivID.Name = "txtLOTSubDivID"
        Me.txtLOTSubDivID.Size = New System.Drawing.Size(100, 20)
        Me.txtLOTSubDivID.TabIndex = 245
        '
        'lblNoneFound
        '
        Me.lblNoneFound.AutoSize = True
        Me.lblNoneFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoneFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoneFound.Location = New System.Drawing.Point(203, 18)
        Me.lblNoneFound.Name = "lblNoneFound"
        Me.lblNoneFound.Size = New System.Drawing.Size(395, 16)
        Me.lblNoneFound.TabIndex = 246
        Me.lblNoneFound.Text = "NO RECORDS FOUND IN TABLE FOR THAT SUBDIV ID"
        Me.lblNoneFound.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 368)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Sort By:"
        '
        'cboLotSort
        '
        Me.cboLotSort.FormattingEnabled = True
        Me.cboLotSort.Location = New System.Drawing.Point(203, 364)
        Me.cboLotSort.Name = "cboLotSort"
        Me.cboLotSort.Size = New System.Drawing.Size(121, 21)
        Me.cboLotSort.TabIndex = 248
        '
        'btnExporttoExcel
        '
        Me.btnExporttoExcel.Location = New System.Drawing.Point(358, 364)
        Me.btnExporttoExcel.Name = "btnExporttoExcel"
        Me.btnExporttoExcel.Size = New System.Drawing.Size(109, 22)
        Me.btnExporttoExcel.TabIndex = 249
        Me.btnExporttoExcel.Text = "Export List to Excel"
        Me.btnExporttoExcel.UseVisualStyleBackColor = True
        '
        'FrmQueryLots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 397)
        Me.Controls.Add(Me.btnExporttoExcel)
        Me.Controls.Add(Me.cboLotSort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNoneFound)
        Me.Controls.Add(Me.txtLOTSubDivID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblLotFndCnt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dgLotInfo)
        Me.Controls.Add(Me.btnLotExit)
        Me.Name = "FrmQueryLots"
        Me.Text = "Query Lots"
        CType(Me.dgLotInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLotExit As System.Windows.Forms.Button
    Friend WithEvents dgLotInfo As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblLotFndCnt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLOTSubDivID As System.Windows.Forms.TextBox
    Friend WithEvents lblNoneFound As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboLotSort As System.Windows.Forms.ComboBox
    Friend WithEvents btnExporttoExcel As System.Windows.Forms.Button
End Class
