Public Class E_DATA_VISOR

    Private EE_MD_MODULO As Char
    Private EE_MD_MODULO_RECEP As Integer
    Private EE_MD_TIPO_MODULO As Integer
    Private EE_ID_MODULO_RECEP As Integer



    Public Property MD_MODULO() As Char
        Get
            Return EE_MD_MODULO
        End Get
        Set(ByVal value As Char)
            EE_MD_MODULO = value
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
    Public Property MD_TIPO_MODULO() As Integer
        Get
            Return EE_MD_TIPO_MODULO
        End Get
        Set(ByVal value As Integer)
            EE_MD_TIPO_MODULO = value
        End Set
    End Property

    Public Property ID_MODULO_RECEP() As Integer
        Get
            Return EE_ID_MODULO_RECEP
        End Get
        Set(ByVal value As Integer)
            EE_ID_MODULO_RECEP = value
        End Set
    End Property

End Class
