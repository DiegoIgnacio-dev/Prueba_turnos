Public Class E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE
    Private E_CF_COD As String
    Public Property CF_COD() As String
        Get
            Return E_CF_COD
        End Get
        Set(ByVal value As String)
            E_CF_COD = value
        End Set
    End Property

    Private E_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return E_CF_DESC
        End Get
        Set(ByVal value As String)
            E_CF_DESC = value
        End Set
    End Property

    Private E_EST_COD As String
    Public Property EST_COD() As String
        Get
            Return E_EST_COD
        End Get
        Set(ByVal value As String)
            E_EST_COD = value
        End Set
    End Property

    Private E_USER_V As String
    Public Property USER_V() As String
        Get
            Return E_USER_V
        End Get
        Set(ByVal value As String)
            E_USER_V = value
        End Set
    End Property

    Private E_FECHA_V As Date?
    Public Property FECHA_V() As Date?
        Get
            Return E_FECHA_V
        End Get
        Set(ByVal value As Date?)
            E_FECHA_V = value
        End Set
    End Property

    Private E_TP_PAGO_DESC As String
    Public Property TP_PAGO_DESC() As String
        Get
            Return E_TP_PAGO_DESC
        End Get
        Set(ByVal value As String)
            E_TP_PAGO_DESC = value
        End Set
    End Property
End Class
