Public Class E_DATA_MODULO_MENOR

    Private EE_ID_MODULO_TURNO As Integer
    Private EE_MD_MODULO_RECEP As Integer

    Public Property ID_MODULO_TURNO() As Integer
        Get
            Return EE_ID_MODULO_TURNO
        End Get
        Set(ByVal value As Integer)
            EE_ID_MODULO_TURNO = value
        End Set
    End Property

    Public Property MD_MODULO_RECEP() As Integer
        Get
            Return EE_MD_MODULO_RECEP
        End Get
        Set(ByVal value As Integer)
            EE_MD_MODULO_RECEP = value
        End Set
    End Property
End Class
