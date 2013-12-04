Public Class frmSelectPasteLayer
    Public g_NotCanceled As Boolean

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        g_NotCanceled = False
        Me.Hide()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        g_NotCanceled = True
        Me.Hide()
    End Sub
End Class