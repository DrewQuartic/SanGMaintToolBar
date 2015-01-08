Public Class ucRoadItemCompare
    Public Property SegVal1() As String
        Get
            If rb1.Checked Then
                Return rb1.Text

            Else
                Return Nothing
            End If

        End Get
        Set(value As String)

            rb1.Text = value

            rb1.Checked = False

        End Set
    End Property
    Public Property SegVal2() As String
        Get
            If rb2.Checked Then
                Return rb2.Text

            Else
                Return Nothing
            End If

        End Get
        Set(value As String)

            rb2.Text = value

            rb2.Checked = False

        End Set
    End Property
    Public Property gbName() As String
        Get
            Return gbControl.Text
        End Get
        Set(value As String)
            gbControl.Text = value
        End Set
    End Property



End Class
