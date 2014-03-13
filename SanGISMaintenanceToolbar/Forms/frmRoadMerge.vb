Imports ESRI.ArcGIS.Geodatabase
Public Class frmRoadMerge
    Private m_seg1 As String
    Private m_seg2 As String

    Public Property Vals(val1 As String, val2 As String) As String
        Get

            Return val1 & "," & val2


        End Get
        Set(value As String)
            m_seg1 = val1
            m_seg2 = val2
        End Set
    End Property
    Private Sub frmRoadMerge_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnMerge_Click(sender As System.Object, e As System.EventArgs)
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel1.Paint, FlowLayoutPanel2.Paint

    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMerge_Click_1(sender As System.Object, e As System.EventArgs) Handles btnMerge.Click
        Me.Hide()
    End Sub

    Private Sub btnMerge_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnMerge.MouseClick
        Me.Hide()
    End Sub
End Class