Public Class E_DATA_ATENCIONES

    Private EE_FECHA As String
    Private EE_NUM_TUR As Integer



    Public Property FECHA() As String
        Get
            Return EE_FECHA
        End Get
        Set(ByVal value As String)
            EE_FECHA = value
        End Set
    End Property

    Public Property NUM_TUR() As Integer
        Get
            Return EE_NUM_TUR
        End Get
        Set(ByVal value As Integer)
            EE_NUM_TUR = value
        End Set
    End Property


End Class
