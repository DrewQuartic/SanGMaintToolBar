Option Strict Off
Option Explicit On
Friend Class frmZipperInput
	Inherits System.Windows.Forms.Form
		
	Public m_bCancel As Boolean
  Public m_TopoColl As Collection
	
	Private Sub cmdAllTopo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllTopo.Click
    Try
      Dim lLoop, lIndex As Integer
      For lLoop = 1 To m_TopoColl.Count()
        lIndex = m_TopoColl.Item(lLoop)
        lstLayers.SetItemChecked(lIndex, True)
      Next lLoop
    Catch ex As Exception
      MsgBox("cmdAllTopo_Click - " & Erl() & " - " & Err.Description)
    End Try
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		m_bCancel = True
		Me.Hide()
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		m_bCancel = False
    Me.Hide()
	End Sub
	
	Private Sub frmZipperInput_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		m_bCancel = True
	End Sub
	
  Private Sub Form_Terminate_Renamed()
    m_TopoColl = Nothing
  End Sub
	
	Private Sub frmZipperInput_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    m_TopoColl = Nothing
	End Sub
	
  Private Sub txtDistance_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDistance.TextChanged
    If Not IsNumeric(txtDistance.Text) Then
      txtDistance.Text = "0"
    End If

    If CDbl(txtDistance.Text) > 0 Then
      cmdOK.Enabled = True
    Else
      cmdOK.Enabled = False
    End If
  End Sub
End Class