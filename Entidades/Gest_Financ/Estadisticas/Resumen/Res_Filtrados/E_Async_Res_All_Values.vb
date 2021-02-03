Public Class E_Async_Res_All_Values
    Private EE_ID_CODIGO_FONASA As Integer
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Private EE_CF_COD As String
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property

    Private EE_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property

    Private EE_PRU_DESC As String
    Public Property PRU_DESC() As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_PRU_DESC = value
        End Set
    End Property

    Private EE_ATE_RESULTADO_NUM As String
    Public Property ATE_RESULTADO_NUM() As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property

    Private EE_ATE_RESULTADO As String
    Public Property ATE_RESULTADO() As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property

    Private EE_ATE_TXT_UNIDAD As String
    Public Property ATE_TXT_UNIDAD() As String
        Get
            Return EE_ATE_TXT_UNIDAD
        End Get
        Set(ByVal value As String)
            EE_ATE_TXT_UNIDAD = value
        End Set
    End Property

    Private EE_ATE_EST_VALIDA As String
    Public Property ATE_EST_VALIDA() As String
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(ByVal value As String)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property

    Private EE_ATE_R_DESDE As String
    Public Property ATE_R_DESDE() As String
        Get
            Return EE_ATE_R_DESDE
        End Get
        Set(ByVal value As String)
            EE_ATE_R_DESDE = value
        End Set
    End Property

    Private EE_ATE_R_HASTA As String
    Public Property ATE_R_HASTA() As String
        Get
            Return EE_ATE_R_HASTA
        End Get
        Set(ByVal value As String)
            EE_ATE_R_HASTA = value
        End Set
    End Property

    Private E_ID_TIPO_DATO As Integer
    Public Property ID_TIPO_DATO() As Integer
        Get
            Return E_ID_TIPO_DATO
        End Get
        Set(ByVal value As Integer)
            E_ID_TIPO_DATO = value
        End Set
    End Property
End Class
