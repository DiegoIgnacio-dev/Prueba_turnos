Public Class E_DATA_CARGA_OPTION_TP

    Private EE_ID_ATE_TP_MODULO As Integer
    Private EE_ID_ESTADO_TP As Integer
    Private EE_TP_ATE_MODULO_DESC As String

    Public Property ID_ATE_TP_MODULO() As Integer
        Get
            Return EE_ID_ATE_TP_MODULO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATE_TP_MODULO = value
        End Set
    End Property

    Public Property ID_ESTADO_TP() As Integer
        Get
            Return EE_ID_ESTADO_TP
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO_TP = value
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

End Class
