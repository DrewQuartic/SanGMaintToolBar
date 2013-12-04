<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditBlockRangeIssue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditBlockRangeIssue))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbEdit = New System.Windows.Forms.GroupBox()
        Me.lblRoadSeg = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnRoadGetFtr = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtUpdtReviewDate = New System.Windows.Forms.DateTimePicker()
        Me.btnUpdt = New System.Windows.Forms.Button()
        Me.txtUpdtNotes = New System.Windows.Forms.TextBox()
        Me.cboUpdtExcept = New System.Windows.Forms.ComboBox()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.lblQuery = New System.Windows.Forms.Label()
        Me.txtRoadSegID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboIssue = New System.Windows.Forms.ComboBox()
        Me.lblNumRecs = New System.Windows.Forms.Label()
        Me.ckboxIncludeEx = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtReviewed = New System.Windows.Forms.DateTimePicker()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.dtPosted = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboJur = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgBRIssueList = New System.Windows.Forms.DataGridView()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExporttoExcel = New System.Windows.Forms.Button()
        Me.gbEdit.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        CType(Me.dgBRIssueList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbEdit
        '
        Me.gbEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbEdit.BackColor = System.Drawing.Color.Linen
        Me.gbEdit.Controls.Add(Me.lblRoadSeg)
        Me.gbEdit.Controls.Add(Me.Label9)
        Me.gbEdit.Controls.Add(Me.btnRoadGetFtr)
        Me.gbEdit.Controls.Add(Me.btnDelete)
        Me.gbEdit.Controls.Add(Me.Label8)
        Me.gbEdit.Controls.Add(Me.Label7)
        Me.gbEdit.Controls.Add(Me.dtUpdtReviewDate)
        Me.gbEdit.Controls.Add(Me.btnUpdt)
        Me.gbEdit.Controls.Add(Me.txtUpdtNotes)
        Me.gbEdit.Controls.Add(Me.cboUpdtExcept)
        Me.gbEdit.Location = New System.Drawing.Point(1, 256)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(680, 79)
        Me.gbEdit.TabIndex = 5
        Me.gbEdit.TabStop = False
        Me.gbEdit.Text = "Update Reviewed Issues"
        '
        'lblRoadSeg
        '
        Me.lblRoadSeg.AutoSize = True
        Me.lblRoadSeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoadSeg.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblRoadSeg.Location = New System.Drawing.Point(7, 33)
        Me.lblRoadSeg.Name = "lblRoadSeg"
        Me.lblRoadSeg.Size = New System.Drawing.Size(37, 13)
        Me.lblRoadSeg.TabIndex = 8
        Me.lblRoadSeg.Text = "None"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(370, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 26)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Review" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Notes:"
        '
        'btnRoadGetFtr
        '
        Me.btnRoadGetFtr.BackgroundImage = CType(resources.GetObject("btnRoadGetFtr.BackgroundImage"), System.Drawing.Image)
        Me.btnRoadGetFtr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRoadGetFtr.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRoadGetFtr.Location = New System.Drawing.Point(641, 16)
        Me.btnRoadGetFtr.Name = "btnRoadGetFtr"
        Me.btnRoadGetFtr.Size = New System.Drawing.Size(33, 27)
        Me.btnRoadGetFtr.TabIndex = 4
        Me.btnRoadGetFtr.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelete.Location = New System.Drawing.Point(643, 49)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(31, 24)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(199, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 26)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Review" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Date:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(85, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 26)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Is" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Exception:"
        '
        'dtUpdtReviewDate
        '
        Me.dtUpdtReviewDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtUpdtReviewDate.Location = New System.Drawing.Point(248, 27)
        Me.dtUpdtReviewDate.Name = "dtUpdtReviewDate"
        Me.dtUpdtReviewDate.Size = New System.Drawing.Size(105, 20)
        Me.dtUpdtReviewDate.TabIndex = 1
        '
        'btnUpdt
        '
        Me.btnUpdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUpdt.Image = CType(resources.GetObject("btnUpdt.Image"), System.Drawing.Image)
        Me.btnUpdt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdt.Location = New System.Drawing.Point(569, 23)
        Me.btnUpdt.Name = "btnUpdt"
        Me.btnUpdt.Size = New System.Drawing.Size(66, 45)
        Me.btnUpdt.TabIndex = 3
        Me.btnUpdt.Text = "Update Record"
        Me.btnUpdt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdt.UseVisualStyleBackColor = True
        '
        'txtUpdtNotes
        '
        Me.txtUpdtNotes.Location = New System.Drawing.Point(419, 20)
        Me.txtUpdtNotes.Multiline = True
        Me.txtUpdtNotes.Name = "txtUpdtNotes"
        Me.txtUpdtNotes.Size = New System.Drawing.Size(133, 52)
        Me.txtUpdtNotes.TabIndex = 2
        '
        'cboUpdtExcept
        '
        Me.cboUpdtExcept.FormattingEnabled = True
        Me.cboUpdtExcept.Location = New System.Drawing.Point(145, 27)
        Me.cboUpdtExcept.Name = "cboUpdtExcept"
        Me.cboUpdtExcept.Size = New System.Drawing.Size(37, 21)
        Me.cboUpdtExcept.TabIndex = 0
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Linen
        Me.gbSearch.Controls.Add(Me.lblQuery)
        Me.gbSearch.Controls.Add(Me.txtRoadSegID)
        Me.gbSearch.Controls.Add(Me.Label10)
        Me.gbSearch.Controls.Add(Me.cboIssue)
        Me.gbSearch.Controls.Add(Me.lblNumRecs)
        Me.gbSearch.Controls.Add(Me.ckboxIncludeEx)
        Me.gbSearch.Controls.Add(Me.Label5)
        Me.gbSearch.Controls.Add(Me.dtReviewed)
        Me.gbSearch.Controls.Add(Me.btnReset)
        Me.gbSearch.Controls.Add(Me.dtPosted)
        Me.gbSearch.Controls.Add(Me.Label6)
        Me.gbSearch.Controls.Add(Me.Label1)
        Me.gbSearch.Controls.Add(Me.cboJur)
        Me.gbSearch.Controls.Add(Me.Label2)
        Me.gbSearch.Controls.Add(Me.Label3)
        Me.gbSearch.Location = New System.Drawing.Point(687, 3)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(229, 302)
        Me.gbSearch.TabIndex = 4
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "Search Block Range Issue Table"
        '
        'lblQuery
        '
        Me.lblQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuery.Location = New System.Drawing.Point(19, 243)
        Me.lblQuery.Name = "lblQuery"
        Me.lblQuery.Size = New System.Drawing.Size(204, 52)
        Me.lblQuery.TabIndex = 234
        Me.lblQuery.Text = "Query:"
        '
        'txtRoadSegID
        '
        Me.txtRoadSegID.Location = New System.Drawing.Point(103, 55)
        Me.txtRoadSegID.Name = "txtRoadSegID"
        Me.txtRoadSegID.Size = New System.Drawing.Size(107, 20)
        Me.txtRoadSegID.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 232
        Me.Label10.Text = "Road ID:"
        '
        'cboIssue
        '
        Me.cboIssue.FormattingEnabled = True
        Me.cboIssue.Location = New System.Drawing.Point(103, 140)
        Me.cboIssue.Name = "cboIssue"
        Me.cboIssue.Size = New System.Drawing.Size(107, 21)
        Me.cboIssue.TabIndex = 3
        '
        'lblNumRecs
        '
        Me.lblNumRecs.AutoSize = True
        Me.lblNumRecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRecs.Location = New System.Drawing.Point(175, 25)
        Me.lblNumRecs.Name = "lblNumRecs"
        Me.lblNumRecs.Size = New System.Drawing.Size(14, 13)
        Me.lblNumRecs.TabIndex = 231
        Me.lblNumRecs.Text = "0"
        '
        'ckboxIncludeEx
        '
        Me.ckboxIncludeEx.AutoSize = True
        Me.ckboxIncludeEx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckboxIncludeEx.Location = New System.Drawing.Point(22, 210)
        Me.ckboxIncludeEx.Name = "ckboxIncludeEx"
        Me.ckboxIncludeEx.Size = New System.Drawing.Size(116, 17)
        Me.ckboxIncludeEx.TabIndex = 5
        Me.ckboxIncludeEx.Text = "Include Exceptions"
        Me.ckboxIncludeEx.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 13)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "Number of Records Found: "
        '
        'dtReviewed
        '
        Me.dtReviewed.Checked = False
        Me.dtReviewed.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReviewed.Location = New System.Drawing.Point(103, 113)
        Me.dtReviewed.Name = "dtReviewed"
        Me.dtReviewed.ShowCheckBox = True
        Me.dtReviewed.Size = New System.Drawing.Size(107, 20)
        Me.dtReviewed.TabIndex = 2
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(165, 203)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(45, 29)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'dtPosted
        '
        Me.dtPosted.Checked = False
        Me.dtPosted.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPosted.Location = New System.Drawing.Point(103, 86)
        Me.dtPosted.Name = "dtPosted"
        Me.dtPosted.ShowCheckBox = True
        Me.dtPosted.Size = New System.Drawing.Size(107, 20)
        Me.dtPosted.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Jurisdiction"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 223
        Me.Label1.Text = "ReviewDate   >="
        '
        'cboJur
        '
        Me.cboJur.FormattingEnabled = True
        Me.cboJur.Location = New System.Drawing.Point(103, 168)
        Me.cboJur.Name = "cboJur"
        Me.cboJur.Size = New System.Drawing.Size(107, 21)
        Me.cboJur.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "PostDate       >="
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 225
        Me.Label3.Text = "Type of Issue"
        '
        'dgBRIssueList
        '
        Me.dgBRIssueList.AllowUserToAddRows = False
        Me.dgBRIssueList.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgBRIssueList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgBRIssueList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgBRIssueList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBRIssueList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgBRIssueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBRIssueList.Location = New System.Drawing.Point(1, 3)
        Me.dgBRIssueList.MultiSelect = False
        Me.dgBRIssueList.Name = "dgBRIssueList"
        Me.dgBRIssueList.ReadOnly = True
        Me.dgBRIssueList.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgBRIssueList.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgBRIssueList.RowTemplate.DividerHeight = 4
        Me.dgBRIssueList.RowTemplate.Height = 20
        Me.dgBRIssueList.RowTemplate.ReadOnly = True
        Me.dgBRIssueList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgBRIssueList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBRIssueList.ShowCellToolTips = False
        Me.dgBRIssueList.Size = New System.Drawing.Size(680, 247)
        Me.dgBRIssueList.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(841, 311)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 24)
        Me.btnExit.TabIndex = 262
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnExporttoExcel
        '
        Me.btnExporttoExcel.Location = New System.Drawing.Point(693, 311)
        Me.btnExporttoExcel.Name = "btnExporttoExcel"
        Me.btnExporttoExcel.Size = New System.Drawing.Size(132, 23)
        Me.btnExporttoExcel.TabIndex = 261
        Me.btnExporttoExcel.Text = "Export List to Excel"
        Me.btnExporttoExcel.UseVisualStyleBackColor = True
        '
        'frmEditBlockRangeIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 338)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnExporttoExcel)
        Me.Controls.Add(Me.gbEdit)
        Me.Controls.Add(Me.gbSearch)
        Me.Controls.Add(Me.dgBRIssueList)
        Me.Name = "frmEditBlockRangeIssue"
        Me.Text = "Review Block Range Overlaps"
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        CType(Me.dgBRIssueList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents lblRoadSeg As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnRoadGetFtr As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtUpdtReviewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnUpdt As System.Windows.Forms.Button
    Friend WithEvents txtUpdtNotes As System.Windows.Forms.TextBox
    Friend WithEvents cboUpdtExcept As System.Windows.Forms.ComboBox
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblQuery As System.Windows.Forms.Label
    Friend WithEvents txtRoadSegID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboIssue As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumRecs As System.Windows.Forms.Label
    Friend WithEvents ckboxIncludeEx As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtReviewed As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents dtPosted As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboJur As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgBRIssueList As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnExporttoExcel As System.Windows.Forms.Button
End Class
