Public Class E_DATA_RESET_FECHA

    Private EE_ID_MODULO_TURNO As Integer
    Private EE_MD_FECHA As String


    Public Property ID_MODULO_TURNO() As Integer
        Get
            Return EE_ID_MODULO_TURNO
        End Get

        Set(ByVal value As Integer)
            EE_ID_MODULO_TURNO = value
        End Set
    End Property

    Public Property MD_FECHA() As String
        Get
            Return EE_MD_FECHA
        End Get
        Set(ByVal value As String)
            EE_MD_FECHA = value
        End Set
    End Property

End Class
