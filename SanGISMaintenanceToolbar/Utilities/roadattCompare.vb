
Imports System.Collections.Generic

Public Class roadattCompare
    Private m_attName As String
    Private m_attValue As String
    Public Property AttName() As String
        Get
            Return m_attName
        End Get
        Set(value As String)
            m_attName = value
        End Set
    End Property

    Public Property AttValue() As String
        Get
            Return m_attValue
        End Get
        Set(value As String)
            m_attValue = value
        End Set
    End Property
End Class
