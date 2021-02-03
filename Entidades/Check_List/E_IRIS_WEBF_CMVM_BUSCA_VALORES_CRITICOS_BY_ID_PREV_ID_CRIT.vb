Public Class E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT
    Private E_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            E_ID_ATENCION = value
        End Set
    End Property

    Private E_ID_ATE_RES As Long
    Public Property ID_ATE_RES() As Long
        Get
            Return E_ID_ATE_RES
        End Get
        Set(ByVal value As Long)
            E_ID_ATE_RES = value
        End Set
    End Property

    Private E_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return E_ATE_NUM
        End Get
        Set(ByVal value As String)
            E_ATE_NUM = value
        End Set
    End Property

    Private E_ATE_FECHA As Date?
    Public Property ATE_FECHA() As Date?
        Get
            Return E_ATE_FECHA
        End Get
        Set(ByVal value As Date?)
            E_ATE_FECHA = value
        End Set
    End Property

    Private E_PAC_DCTO As String
    Public Property PAC_DCTO() As String
        Get
            Return E_PAC_DCTO
        End Get
        Set(ByVal value As String)
            E_PAC_DCTO = value
        End Set
    End Property

    Private E_PAC_NAME As String
    Public Property PAC_NAME() As String
        Get
            Return E_PAC_NAME
        End Get
        Set(ByVal value As String)
            E_PAC_NAME = value
        End Set
    End Property

    Private E_SEXO_DESC As String
    Public Property SEXO_DESC() As String
        Get
            Return E_SEXO_DESC
        End Get
        Set(ByVal value As String)
            E_SEXO_DESC = value
        End Set
    End Property

    Private E_PAC_FNAC As Date?
    Public Property PAC_FNAC() As Date?
        Get
            Return E_PAC_FNAC
        End Get
        Set(ByVal value As Date?)
            E_PAC_FNAC = value
        End Set
    End Property

    Private E_EDAD As String
    Public Property EDAD() As String
        Get
            Return E_EDAD
        End Get
        Set(ByVal value As String)
            E_EDAD = value
        End Set
    End Property

    Private E_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return E_PROC_DESC
        End Get
        Set(ByVal value As String)
            E_PROC_DESC = value
        End Set
    End Property

    Private E_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(ByVal value As String)
            E_PREVE_DESC = value
        End Set
    End Property

    Private E_CODF_COD As String
    Public Property CODF_COD() As String
        Get
            Return E_CODF_COD
        End Get
        Set(ByVal value As String)
            E_CODF_COD = value
        End Set
    End Property

    Private E_CODF_DESC As String
    Public Property CODF_DESC() As String
        Get
            Return E_CODF_DESC
        End Get
        Set(ByVal value As String)
            E_CODF_DESC = value
        End Set
    End Property

    Private E_PRU_COD As String
    Public Property PRU_COD() As String
        Get
            Return E_PRU_COD
        End Get
        Set(ByVal value As String)
            E_PRU_COD = value
        End Set
    End Property

    Private E_PRU_DESC As String
    Public Property PRU_DESC() As String
        Get
            Return E_PRU_DESC
        End Get
        Set(ByVal value As String)
            E_PRU_DESC = value
        End Set
    End Property

    Private E_EST_VALIDAC As String
    Public Property EST_VALIDAC() As String
        Get
            Return E_EST_VALIDAC
        End Get
        Set(ByVal value As String)
            E_EST_VALIDAC = value
        End Set
    End Property

    Private E_FECHA_VALIDAC As Date?
    Public Property FECHA_VALIDAC() As Date?
        Get
            Return E_FECHA_VALIDAC
        End Get
        Set(ByVal value As Date?)
            E_FECHA_VALIDAC = value
        End Set
    End Property

    Private E_TIPO_RES As String
    Public Property TIPO_RES() As String
        Get
            Return E_TIPO_RES
        End Get
        Set(ByVal value As String)
            E_TIPO_RES = value
        End Set
    End Property

    Private E_PRU_VALUE As Double
    Public Property PRU_VALUE() As Double
        Get
            Return E_PRU_VALUE
        End Get
        Set(ByVal value As Double)
            E_PRU_VALUE = value
        End Set
    End Property

    Private E_ALARMA As String
    Public Property ALARMA() As String
        Get
            Return E_ALARMA
        End Get
        Set(ByVal value As String)
            E_ALARMA = value
        End Set
    End Property

    Private E_ATE_RR_DESDE As Double
    Public Property ATE_RR_DESDE() As Double
        Get
            Return E_ATE_RR_DESDE
        End Get
        Set(ByVal value As Double)
            E_ATE_RR_DESDE = value
        End Set
    End Property

    Private E_ATE_R_DESDE As Double
    Public Property ATE_R_DESDE() As Double
        Get
            Return E_ATE_R_DESDE
        End Get
        Set(ByVal value As Double)
            E_ATE_R_DESDE = value
        End Set
    End Property

    Private E_ATE_R_HASTA As Double
    Public Property ATE_R_HASTA() As Double
        Get
            Return E_ATE_R_HASTA
        End Get
        Set(ByVal value As Double)
            E_ATE_R_HASTA = value
        End Set
    End Property

    Private E_ATE_RR_HASTA As Double
    Public Property ATE_RR_HASTA() As Double
        Get
            Return E_ATE_RR_HASTA
        End Get
        Set(ByVal value As Double)
            E_ATE_RR_HASTA = value
        End Set
    End Property

    Private E_FECHA_ENVIO As Date?
    Public Property FECHA_ENVIO() As Date?
        Get
            Return E_FECHA_ENVIO
        End Get
        Set(ByVal value As Date?)
            E_FECHA_ENVIO = value
        End Set
    End Property
End Class