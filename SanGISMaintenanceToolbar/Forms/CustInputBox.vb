Imports System.Windows.Forms



Public Class CustInputBox

    Protected m_BlankValid As Boolean = True
    Protected m_ReturnText As String = ""

    Public Overloads Function ShowDialog( _
   ByVal TitleText As String, _
   ByVal PromptText As String, _
   ByVal DefaultText As String, _
   ByRef EnteredText As String, _
   ByVal BlankValid As Boolean, ByVal SysDrawPoint As System.Drawing.Point) As System.Windows.Forms.DialogResult
        m_BlankValid = BlankValid
        lblPrompt.Text = PromptText
        Me.Text = TitleText
        txtInput.Text = DefaultText
        txtInput.SelectionStart = Int(Len(DefaultText))
        'lblPrompt.Text = SysDrawPoint.X.ToString() & "," & SysDrawPoint.Y.ToString()
        Me.Location = New System.Drawing.Point(SysDrawPoint.X, SysDrawPoint.Y)
        Me.ShowDialog()
        EnteredText = m_ReturnText
        Return Me.DialogResult
    End Function

    Private Sub txtInput_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            BtnOK.PerformClick()
        End If
    End Sub


    Private Sub txtInput_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInput.TextChanged
        If txtInput.Text = "" Then
            BtnOK.Enabled = m_BlankValid
        Else
            BtnOK.Enabled = True
        End If
    End Sub


    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOK.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        m_ReturnText = Me.txtInput.Text
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        m_ReturnText = ""
        Me.Close()
    End Sub
End Class