Public Class frmTransferRoadInfo
    Public p_NotCanceled As Boolean
 
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        p_NotCanceled = False
        Me.Hide()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        p_NotCanceled = True
        Me.Hide()
    End Sub
End Class