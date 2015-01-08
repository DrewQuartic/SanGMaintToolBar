Imports ESRI.ArcGIS.Geodatabase
Imports System.Windows.Forms


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
        Dim myControlls As ControlCollection

        myControlls = Me.Controls
        Dim i As Integer
        Dim k As Integer

        Dim txtName As String
        i = 0
        k = 0

        For i = 0 To myControlls.Count - 1
            txtName = myControlls.Item(i).Name
            If txtName = "flpGroups" Then
                Dim flpFlowP As FlowLayoutPanel = TryCast(myControlls.Item(i), FlowLayoutPanel)

                Dim ctlflow As System.Windows.Forms.Control.ControlCollection = flpFlowP.Controls
                'ctlflow = myControlls.Item(i).Controls
                For k = 0 To ctlflow.Count - 1
                    Dim ucRIC As ucRoadItemCompare = TryCast(ctlflow.Item(k), ucRoadItemCompare)
                    If ucRIC IsNot Nothing Then
                        If ucRIC.rb1.Checked = False And ucRIC.rb2.Checked = False Then
                            MessageBox.Show("No value chose for " + ucRIC.gbName + ". Please pick a value and try again", "Problem:", MessageBoxButtons.OK)
                            Exit Sub
                        End If
                    End If

                Next k

            End If

        Next i

        Me.Hide()
    End Sub

    Private Sub btnCancel_Click_1(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Throw New ApplicationException("User Cancelled the merge")
    End Sub

    Private Sub Label3_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub
End Class