Public Class E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_CF_COD As String
    Private EE_CF_DESC As String
    Private EE_USU_NIC As String
    Private EE_ID_DET_ATE As Long
    Private EE_ATE_DET_V_ID_ESTADO As Integer
    Private EE_ATE_DET_V_FECHA As DateTime
    Public Property ATE_DET_V_FECHA() As DateTime
        Get
            Return EE_ATE_DET_V_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_DET_V_FECHA = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO() As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_DET_ATE() As Long
        Get
            Return EE_ID_DET_ATE
        End Get
        Set(ByVal value As Long)
            EE_ID_DET_ATE = value
        End Set
    End Property
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
End Class
