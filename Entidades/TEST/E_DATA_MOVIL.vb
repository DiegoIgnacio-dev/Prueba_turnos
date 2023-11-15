Public Class E_DATA_MOVIL

    Private EE_MD_MODULO As Char
    Private EE_MD_MODULO_RECEP As Integer
    Private EE_MD_TIPO_MODULO As Integer
    Private EE_ID_MODULO_TURNO As Integer
    Private EE_ID_ESTADO As Integer



    Public Property MD_TIPO_MODULO() As Integer
        Get
            Return EE_MD_TIPO_MODULO
        End Get
        Set(ByVal value As Integer)
            EE_MD_TIPO_MODULO = value
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
    Public Property MD_MODULO() As Char
        Get
            Return EE_MD_MODULO
        End Get
        Set(ByVal value As Char)
            EE_MD_MODULO = value
        End Set
    End Property

    Public Property ID_MODULO_TURNO() As Integer
        Get
            Return EE_ID_MODULO_TURNO
        End Get

        Set(ByVal value As Integer)
            EE_ID_MODULO_TURNO = value
        End Set
    End Property

    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

End Class
