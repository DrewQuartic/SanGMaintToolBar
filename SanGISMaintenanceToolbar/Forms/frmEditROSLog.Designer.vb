<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditROSLog
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
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnROSLgReset = New System.Windows.Forms.Button()
        Me.btnROSLgExit = New System.Windows.Forms.Button()
        Me.btnROSLgSave = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboROSLgSelectName = New System.Windows.Forms.ComboBox()
        Me.ckbxROSLgSearch = New System.Windows.Forms.CheckBox()
        Me.lblMapNumSelectName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtROSMapnum = New System.Windows.Forms.TextBox()
        Me.dtROSDocDate = New System.Windows.Forms.DateTimePicker()
        Me.txtROSLocation = New System.Windows.Forms.TextBox()
        Me.txtROSAssrBook = New System.Windows.Forms.TextBox()
        Me.cboROSBsheet = New System.Windows.Forms.ComboBox()
        Me.cboROSJur = New System.Windows.Forms.ComboBox()
        Me.cboROSNad = New System.Windows.Forms.ComboBox()
        Me.txtROSNumShts = New System.Windows.Forms.TextBox()
        Me.txtROSCalCoord = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtKnwnNum = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(414, 381)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 129
        Me.Label24.Text = "(F12)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(246, 381)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 128
        Me.Label23.Text = "(F1)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(67, 381)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 127
        Me.Label22.Text = "(F10)"
        '
        'btnROSLgReset
        '
        Me.btnROSLgReset.Location = New System.Drawing.Point(223, 342)
        Me.btnROSLgReset.Name = "btnROSLgReset"
        Me.btnROSLgReset.Size = New System.Drawing.Size(75, 36)
        Me.btnROSLgReset.TabIndex = 125
        Me.btnROSLgReset.Text = "RESET FORM"
        Me.btnROSLgReset.UseVisualStyleBackColor = True
        '
        'btnROSLgExit
        '
        Me.btnROSLgExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnROSLgExit.Location = New System.Drawing.Point(395, 342)
        Me.btnROSLgExit.Name = "btnROSLgExit"
        Me.btnROSLgExit.Size = New System.Drawing.Size(75, 36)
        Me.btnROSLgExit.TabIndex = 126
        Me.btnROSLgExit.Text = "EXIT"
        Me.btnROSLgExit.UseVisualStyleBackColor = True
        '
        'btnROSLgSave
        '
        Me.btnROSLgSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnROSLgSave.Location = New System.Drawing.Point(53, 342)
        Me.btnROSLgSave.Name = "btnROSLgSave"
        Me.btnROSLgSave.Size = New System.Drawing.Size(75, 36)
        Me.btnROSLgSave.TabIndex = 124
        Me.btnROSLgSave.Text = "Add ROS Log"
        Me.btnROSLgSave.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 326)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(481, 13)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "---------------------------------------------------------------------------------" & _
            "-----------------------------------------------------------------------------"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboROSLgSelectName
        '
        Me.cboROSLgSelectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboROSLgSelectName.Enabled = False
        Me.cboROSLgSelectName.FormattingEnabled = True
        Me.cboROSLgSelectName.Location = New System.Drawing.Point(309, 28)
        Me.cboROSLgSelectName.MaxDropDownItems = 20
        Me.cboROSLgSelectName.Name = "cboROSLgSelectName"
        Me.cboROSLgSelectName.Size = New System.Drawing.Size(190, 21)
        Me.cboROSLgSelectName.TabIndex = 168
        '
        'ckbxROSLgSearch
        '
        Me.ckbxROSLgSearch.AutoSize = True
        Me.ckbxROSLgSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbxROSLgSearch.Location = New System.Drawing.Point(205, 22)
        Me.ckbxROSLgSearch.Name = "ckbxROSLgSearch"
        Me.ckbxROSLgSearch.Size = New System.Drawing.Size(98, 30)
        Me.ckbxROSLgSearch.TabIndex = 170
        Me.ckbxROSLgSearch.TabStop = False
        Me.ckbxROSLgSearch.Text = " Search/Edit" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Existing "
        Me.ckbxROSLgSearch.UseVisualStyleBackColor = True
        '
        'lblMapNumSelectName
        '
        Me.lblMapNumSelectName.AutoSize = True
        Me.lblMapNumSelectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMapNumSelectName.Location = New System.Drawing.Point(306, 13)
        Me.lblMapNumSelectName.Name = "lblMapNumSelectName"
        Me.lblMapNumSelectName.Size = New System.Drawing.Size(178, 13)
        Me.lblMapNumSelectName.TabIndex = 171
        Me.lblMapNumSelectName.Text = "Select Map Num to display Attributes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Mapnum"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Doc Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Location"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "Assessor Book"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "Nad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 178
        Me.Label6.Text = "Jur"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "Num Sheets"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 180
        Me.Label9.Text = "Cal coord Index"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(50, 299)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 181
        Me.Label11.Text = "B Sheet"
        '
        'txtROSMapnum
        '
        Me.txtROSMapnum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtROSMapnum.Location = New System.Drawing.Point(101, 76)
        Me.txtROSMapnum.MaxLength = 5
        Me.txtROSMapnum.Name = "txtROSMapnum"
        Me.txtROSMapnum.Size = New System.Drawing.Size(100, 20)
        Me.txtROSMapnum.TabIndex = 182
        '
        'dtROSDocDate
        '
        Me.dtROSDocDate.Checked = False
        Me.dtROSDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtROSDocDate.Location = New System.Drawing.Point(101, 103)
        Me.dtROSDocDate.Name = "dtROSDocDate"
        Me.dtROSDocDate.ShowCheckBox = True
        Me.dtROSDocDate.Size = New System.Drawing.Size(134, 20)
        Me.dtROSDocDate.TabIndex = 183
        '
        'txtROSLocation
        '
        Me.txtROSLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtROSLocation.Location = New System.Drawing.Point(101, 131)
        Me.txtROSLocation.MaxLength = 255
        Me.txtROSLocation.Name = "txtROSLocation"
        Me.txtROSLocation.Size = New System.Drawing.Size(382, 20)
        Me.txtROSLocation.TabIndex = 184
        '
        'txtROSAssrBook
        '
        Me.txtROSAssrBook.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtROSAssrBook.Location = New System.Drawing.Point(101, 157)
        Me.txtROSAssrBook.MaxLength = 100
        Me.txtROSAssrBook.Name = "txtROSAssrBook"
        Me.txtROSAssrBook.Size = New System.Drawing.Size(382, 20)
        Me.txtROSAssrBook.TabIndex = 185
        '
        'cboROSBsheet
        '
        Me.cboROSBsheet.FormattingEnabled = True
        Me.cboROSBsheet.Location = New System.Drawing.Point(101, 292)
        Me.cboROSBsheet.MaxLength = 1
        Me.cboROSBsheet.Name = "cboROSBsheet"
        Me.cboROSBsheet.Size = New System.Drawing.Size(75, 21)
        Me.cboROSBsheet.TabIndex = 186
        '
        'cboROSJur
        '
        Me.cboROSJur.FormattingEnabled = True
        Me.cboROSJur.Location = New System.Drawing.Point(101, 213)
        Me.cboROSJur.MaxLength = 2
        Me.cboROSJur.Name = "cboROSJur"
        Me.cboROSJur.Size = New System.Drawing.Size(75, 21)
        Me.cboROSJur.TabIndex = 187
        '
        'cboROSNad
        '
        Me.cboROSNad.FormattingEnabled = True
        Me.cboROSNad.Location = New System.Drawing.Point(101, 186)
        Me.cboROSNad.MaxLength = 2
        Me.cboROSNad.Name = "cboROSNad"
        Me.cboROSNad.Size = New System.Drawing.Size(75, 21)
        Me.cboROSNad.TabIndex = 188
        '
        'txtROSNumShts
        '
        Me.txtROSNumShts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtROSNumShts.Location = New System.Drawing.Point(101, 240)
        Me.txtROSNumShts.MaxLength = 7
        Me.txtROSNumShts.Name = "txtROSNumShts"
        Me.txtROSNumShts.Size = New System.Drawing.Size(75, 20)
        Me.txtROSNumShts.TabIndex = 189
        '
        'txtROSCalCoord
        '
        Me.txtROSCalCoord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtROSCalCoord.Location = New System.Drawing.Point(101, 266)
        Me.txtROSCalCoord.MaxLength = 20
        Me.txtROSCalCoord.Name = "txtROSCalCoord"
        Me.txtROSCalCoord.Size = New System.Drawing.Size(134, 20)
        Me.txtROSCalCoord.TabIndex = 190
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(481, 13)
        Me.Label8.TabIndex = 191
        Me.Label8.Text = "---------------------------------------------------------------------------------" & _
            "-----------------------------------------------------------------------------"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(137, 22)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 31)
        Me.Label26.TabIndex = 194
        Me.Label26.Text = "OR"
        '
        'txtKnwnNum
        '
        Me.txtKnwnNum.Location = New System.Drawing.Point(21, 39)
        Me.txtKnwnNum.Name = "txtKnwnNum"
        Me.txtKnwnNum.Size = New System.Drawing.Size(100, 20)
        Me.txtKnwnNum.TabIndex = 193
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 26)
        Me.Label12.TabIndex = 192
        Me.Label12.Text = "Input Known MapNum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (and press Enter)"
        '
        'frmEditROSLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 409)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtKnwnNum)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtROSCalCoord)
        Me.Controls.Add(Me.txtROSNumShts)
        Me.Controls.Add(Me.cboROSNad)
        Me.Controls.Add(Me.cboROSJur)
        Me.Controls.Add(Me.cboROSBsheet)
        Me.Controls.Add(Me.txtROSAssrBook)
        Me.Controls.Add(Me.txtROSLocation)
        Me.Controls.Add(Me.dtROSDocDate)
        Me.Controls.Add(Me.txtROSMapnum)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboROSLgSelectName)
        Me.Controls.Add(Me.ckbxROSLgSearch)
        Me.Controls.Add(Me.lblMapNumSelectName)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btnROSLgReset)
        Me.Controls.Add(Me.btnROSLgExit)
        Me.Controls.Add(Me.btnROSLgSave)
        Me.Controls.Add(Me.Label10)
        Me.KeyPreview = True
        Me.Name = "frmEditROSLog"
        Me.Text = "Edit Record of Survey Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnROSLgReset As System.Windows.Forms.Button
    Friend WithEvents btnROSLgExit As System.Windows.Forms.Button
    Friend WithEvents btnROSLgSave As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboROSLgSelectName As System.Windows.Forms.ComboBox
    Friend WithEvents ckbxROSLgSearch As System.Windows.Forms.CheckBox
    Friend WithEvents lblMapNumSelectName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtROSMapnum As System.Windows.Forms.TextBox
    Friend WithEvents dtROSDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtROSLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtROSAssrBook As System.Windows.Forms.TextBox
    Friend WithEvents cboROSBsheet As System.Windows.Forms.ComboBox
    Friend WithEvents cboROSJur As System.Windows.Forms.ComboBox
    Friend WithEvents cboROSNad As System.Windows.Forms.ComboBox
    Friend WithEvents txtROSNumShts As System.Windows.Forms.TextBox
    Friend WithEvents txtROSCalCoord As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtKnwnNum As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
