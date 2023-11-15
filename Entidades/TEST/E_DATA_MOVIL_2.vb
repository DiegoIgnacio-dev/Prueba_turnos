Public Class E_DATA_MOVIL_2

    Private EE_MD_MODULO As Char
    Private EE_MD_MODULO_RECEP As Integer
    Private EE_ID_MODULO_TURNO As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_TP_ATE_MODULO_DESC As String
    Private EE_MODULO_RECEP_DESC As String



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

    Public Property TP_ATE_MODULO_DESC() As String
        Get
            Return EE_TP_ATE_MODULO_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_ATE_MODULO_DESC = value
        End Set
    End Property

    Public Property MODULO_RECEP_DESC() As String
        Get
            Return EE_MODULO_RECEP_DESC
        End Get
        Set(ByVal value As String)
            EE_MODULO_RECEP_DESC = value
        End Set
    End Property

End Class