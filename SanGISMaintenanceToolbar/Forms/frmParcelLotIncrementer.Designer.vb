<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParcelLotIncrementer
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optParcelAPN = New System.Windows.Forms.RadioButton
        Me.optLotBlock = New System.Windows.Forms.RadioButton
        Me.txtBK = New System.Windows.Forms.TextBox
        Me.txtPG = New System.Windows.Forms.TextBox
        Me.txtCurrentValue = New System.Windows.Forms.TextBox
        Me.txtSID = New System.Windows.Forms.TextBox
        Me.btnSubDivLst = New System.Windows.Forms.Button
        Me.lblSubdivID = New System.Windows.Forms.Label
        Me.cboSubDivIDs = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Book"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(90, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Page"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(150, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "?"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(211, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optParcelAPN)
        Me.GroupBox1.Controls.Add(Me.optLotBlock)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose an attribute to increment"
        '
        'optParcelAPN
        '
        Me.optParcelAPN.AutoSize = True
        Me.optParcelAPN.Location = New System.Drawing.Point(45, 65)
        Me.optParcelAPN.Name = "optParcelAPN"
        Me.optParcelAPN.Size = New System.Drawing.Size(80, 17)
        Me.optParcelAPN.TabIndex = 1
        Me.optParcelAPN.TabStop = True
        Me.optParcelAPN.Text = "Parcel APN"
        Me.optParcelAPN.UseVisualStyleBackColor = True
        '
        'optLotBlock
        '
        Me.optLotBlock.AutoSize = True
        Me.optLotBlock.Location = New System.Drawing.Point(45, 32)
        Me.optLotBlock.Name = "optLotBlock"
        Me.optLotBlock.Size = New System.Drawing.Size(110, 17)
        Me.optLotBlock.TabIndex = 0
        Me.optLotBlock.TabStop = True
        Me.optLotBlock.Text = "Lot Block Number"
        Me.optLotBlock.UseVisualStyleBackColor = True
        '
        'txtBK
        '
        Me.txtBK.Location = New System.Drawing.Point(34, 43)
        Me.txtBK.Name = "txtBK"
        Me.txtBK.Size = New System.Drawing.Size(41, 20)
        Me.txtBK.TabIndex = 5
        Me.txtBK.Text = "000"
        '
        'txtPG
        '
        Me.txtPG.Location = New System.Drawing.Point(93, 43)
        Me.txtPG.Name = "txtPG"
        Me.txtPG.Size = New System.Drawing.Size(41, 20)
        Me.txtPG.TabIndex = 6
        Me.txtPG.Text = "000"
        '
        'txtCurrentValue
        '
        Me.txtCurrentValue.Location = New System.Drawing.Point(153, 43)
        Me.txtCurrentValue.Name = "txtCurrentValue"
        Me.txtCurrentValue.Size = New System.Drawing.Size(41, 20)
        Me.txtCurrentValue.TabIndex = 7
        Me.txtCurrentValue.Text = "00"
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(212, 43)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Size = New System.Drawing.Size(41, 20)
        Me.txtSID.TabIndex = 8
        Me.txtSID.Text = "00"
        '
        'btnSubDivLst
        '
        Me.btnSubDivLst.Location = New System.Drawing.Point(212, 197)
        Me.btnSubDivLst.Name = "btnSubDivLst"
        Me.btnSubDivLst.Size = New System.Drawing.Size(55, 35)
        Me.btnSubDivLst.TabIndex = 11
        Me.btnSubDivLst.Text = "SubDiv ID's"
        Me.btnSubDivLst.UseVisualStyleBackColor = True
        '
        'lblSubdivID
        '
        Me.lblSubdivID.AutoSize = True
        Me.lblSubdivID.Location = New System.Drawing.Point(12, 208)
        Me.lblSubdivID.Name = "lblSubdivID"
        Me.lblSubdivID.Size = New System.Drawing.Size(53, 13)
        Me.lblSubdivID.TabIndex = 10
        Me.lblSubdivID.Text = "SubDivID"
        '
        'cboSubDivIDs
        '
        Me.cboSubDivIDs.FormattingEnabled = True
        Me.cboSubDivIDs.Location = New System.Drawing.Point(71, 205)
        Me.cboSubDivIDs.Name = "cboSubDivIDs"
        Me.cboSubDivIDs.Size = New System.Drawing.Size(123, 21)
        Me.cboSubDivIDs.TabIndex = 9
        '
        'frmParcelLotIncrementer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 244)
        Me.Controls.Add(Me.btnSubDivLst)
        Me.Controls.Add(Me.lblSubdivID)
        Me.Controls.Add(Me.cboSubDivIDs)
        Me.Controls.Add(Me.txtSID)
        Me.Controls.Add(Me.txtCurrentValue)
        Me.Controls.Add(Me.txtPG)
        Me.Controls.Add(Me.txtBK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmParcelLotIncrementer"
        Me.Text = "Incrementer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optParcelAPN As System.Windows.Forms.RadioButton
    Friend WithEvents optLotBlock As System.Windows.Forms.RadioButton
    Friend WithEvents txtBK As System.Windows.Forms.TextBox
    Friend WithEvents txtPG As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentValue As System.Windows.Forms.TextBox
    Friend WithEvents txtSID As System.Windows.Forms.TextBox
    Friend WithEvents btnSubDivLst As System.Windows.Forms.Button
    Friend WithEvents lblSubdivID As System.Windows.Forms.Label
    Friend WithEvents cboSubDivIDs As System.Windows.Forms.ComboBox
End Class
