Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
    Dim EE_TOTAL_ATE As Long
    Dim EE_TOTAL_PREVE As Long
    Dim EE_TOT_FONASA As Long
    Dim EE_TOTA_SIS As Long
    Dim EE_TOTA_USU As Long
    Dim EE_TOTA_COPA As Long
    Dim EE_CF_DESC As String
    Dim EE_ID_CODIGO_FONASA As Long
    Dim EE_ID_ESTADO As Long
    Dim EE_CF_COD As String
    Dim EE_CF_UNIT As Long
    Private EE_PROC_DESC As String
    Private EE_PREVE_DESC As String
    Private EE_CF_OMI As String
    Private EE_TOT_OMI As Integer
    Private EE_ATE_DET_V_PREVI As Long
    Public Property ATE_DET_V_PREVI() As Long
        Get
            Return EE_ATE_DET_V_PREVI
        End Get
        Set(ByVal value As Long)
            EE_ATE_DET_V_PREVI = value
        End Set
    End Property
    Public Property TOT_OMI() As Integer
        Get
            Return EE_TOT_OMI
        End Get
        Set(ByVal value As Integer)
            EE_TOT_OMI = value
        End Set
    End Property
    Public Property CF_OMI() As String
        Get
            Return EE_CF_OMI
        End Get
        Set(ByVal value As String)
            EE_CF_OMI = value
        End Set
    End Property
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property CF_UNIT() As Long
        Get
            Return EE_CF_UNIT
        End Get
        Set(ByVal value As Long)
            EE_CF_UNIT = value
        End Set
    End Property
    Public Property TOTAL_ATE As Long
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(value As Long)
            EE_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_PREVE As Long
        Get
            Return EE_TOTAL_PREVE
        End Get
        Set(value As Long)
            EE_TOTAL_PREVE = value
        End Set
    End Property
    Public Property TOT_FONASA As Long
        Get
            Return EE_TOT_FONASA
        End Get
        Set(value As Long)
            EE_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTA_SIS As Long
        Get
            Return EE_TOTA_SIS
        End Get
        Set(value As Long)
            EE_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Long
        Get
            Return EE_TOTA_USU
        End Get
        Set(value As Long)
            EE_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Long
        Get
            Return EE_TOTA_COPA
        End Get
        Set(value As Long)
            EE_TOTA_COPA = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Long)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return EE_CF_COD
        End Get
        Set(value As String)
            EE_CF_COD = value
        End Set
    End Property
End Class
