Public Class E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_FNAC As Date
    Dim EE_PRU_DESC As String
    Dim EE_CF_DESC As String
    Dim EE_ATE_AÑO As Integer
    Dim EE_ID_PACIENTE As Long
    Dim EE_ATE_NUM As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_RESULTADO As String
    Dim EE_ID_ATENCION As Long
    Dim EE_ATE_RESULTADO_NUM As String
    Dim EE_ATE_RR_DESDE As String
    Dim EE_ATE_RR_HASTA As String
    Dim EE_ATE_RR_ALTOBAJO As Double
    Dim EE_ATE_R_DESDE As String
    Dim EE_ATE_R_HASTA As String
    Dim EE_ATE_RESULTADO_ALT As String
    Dim EE_PROC_DESC As String
    Dim EE_ORD_DESC As String
    Dim EE_ATE_EST_VALIDA As Long
    Dim EE_ID_CODIGO_FONASA As String
    Dim EE_EDAD As String
    Dim EE_id_proce As String
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_ATE_DNI As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_NAC_DESC As String
    Dim EE_PROGRA_DESC As String
    Dim EE_ID_PER As String
    Dim EE_SECTOR_DESC As String
    Dim EE_PAC_FONO1 As String
    Dim EE_PAC_MOVIL1 As String

    Dim EE_ID_TP_RESULTADO As Integer
    Dim EE_ID_ATE_RES As Integer
    Dim EE_PRU_P_CERO As Integer
    Dim EE_PRU_COD As String
    Dim EE_PRU_VECTOR_CALCULO As String
    Dim EE_PRU_DECIMAL As Integer
    Dim EE_SECC_DESC As String
    Dim EE_Encyp As String
    Dim EE_ATE_MES As Integer
    Dim EE_ATE_DIA As Integer
    Public Property ATE_DIA As Integer
        Get
            Return EE_ATE_DIA
        End Get
        Set(value As Integer)
            EE_ATE_DIA = value
        End Set
    End Property
    Public Property ATE_MES As Integer
        Get
            Return EE_ATE_MES
        End Get
        Set(value As Integer)
            EE_ATE_MES = value
        End Set
    End Property
    Public Property Encyp As String
        Get
            Return EE_Encyp
        End Get
        Set(value As String)
            EE_Encyp = value
        End Set
    End Property
    Public Property SECC_DESC As String
        Get
            Return EE_SECC_DESC
        End Get
        Set(value As String)
            EE_SECC_DESC = value
        End Set
    End Property
    Public Property PRU_DECIMAL As Integer
        Get
            Return EE_PRU_DECIMAL
        End Get
        Set(value As Integer)
            EE_PRU_DECIMAL = value
        End Set
    End Property
    Public Property PRU_VECTOR_CALCULO As String
        Get
            Return EE_PRU_VECTOR_CALCULO
        End Get
        Set(value As String)
            EE_PRU_VECTOR_CALCULO = value
        End Set
    End Property
    Public Property PRU_COD As String
        Get
            Return EE_PRU_COD
        End Get
        Set(value As String)
            EE_PRU_COD = value
        End Set
    End Property
    Public Property PRU_P_CERO As Integer
        Get
            Return EE_PRU_P_CERO
        End Get
        Set(value As Integer)
            EE_PRU_P_CERO = value
        End Set
    End Property

    Public Property ID_ATE_RES As Integer
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(value As Integer)
            EE_ID_ATE_RES = value
        End Set
    End Property
    Public Property ID_TP_RESULTADO As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(value As Integer)
            EE_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property PAC_FONO1 As String
        Get
            Return EE_PAC_FONO1
        End Get
        Set(value As String)
            EE_PAC_FONO1 = value
        End Set
    End Property
    Public Property PAC_MOVIL1 As String
        Get
            Return EE_PAC_MOVIL1
        End Get
        Set(value As String)
            EE_PAC_MOVIL1 = value
        End Set
    End Property
    Dim EE_FONO As String
    Public Property FONO As String
        Get
            Return EE_FONO
        End Get
        Set(value As String)
            EE_FONO = value
        End Set
    End Property
    Public Property ID_PER As String
        Get
            Return EE_ID_PER
        End Get
        Set(value As String)
            EE_ID_PER = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property ATE_DNI As String
        Get
            Return EE_ATE_DNI
        End Get
        Set(value As String)
            EE_ATE_DNI = value
        End Set
    End Property
    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property
    Public Property SECTOR_DESC As String
        Get
            Return EE_SECTOR_DESC
        End Get
        Set(value As String)
            EE_SECTOR_DESC = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property NAC_DESC As String
        Get
            Return EE_NAC_DESC
        End Get
        Set(value As String)
            EE_NAC_DESC = value
        End Set
    End Property

    Public Property id_proce As String
        Get
            Return EE_id_proce
        End Get
        Set(value As String)
            EE_id_proce = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
        End Set
    End Property

    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property

    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property

    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property

    Public Property PRU_DESC As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(value As String)
            EE_PRU_DESC = value
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

    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property

    Public Property ID_PACIENTE As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Long)
            EE_ID_PACIENTE = value
        End Set
    End Property

    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Public Property ATE_RESULTADO As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property

    Public Property ID_ATENCION As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ATE_RESULTADO_NUM As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(value As String)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property

    Public Property ATE_RR_DESDE As String
        Get
            Return EE_ATE_RR_DESDE
        End Get
        Set(value As String)
            EE_ATE_RR_DESDE = value
        End Set
    End Property

    Public Property ATE_RR_HASTA As String
        Get
            Return EE_ATE_RR_HASTA
        End Get
        Set(value As String)
            EE_ATE_RR_HASTA = value
        End Set
    End Property

    Public Property ATE_RR_ALTOBAJO As Double
        Get
            Return EE_ATE_RR_ALTOBAJO
        End Get
        Set(value As Double)
            EE_ATE_RR_ALTOBAJO = value
        End Set
    End Property

    Public Property ATE_R_DESDE As String
        Get
            Return EE_ATE_R_DESDE
        End Get
        Set(value As String)
            EE_ATE_R_DESDE = value
        End Set
    End Property

    Public Property ATE_R_HASTA As String
        Get
            Return EE_ATE_R_HASTA
        End Get
        Set(value As String)
            EE_ATE_R_HASTA = value
        End Set
    End Property

    Public Property ATE_RESULTADO_ALT As String
        Get
            Return EE_ATE_RESULTADO_ALT
        End Get
        Set(value As String)
            EE_ATE_RESULTADO_ALT = value
        End Set
    End Property

    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Public Property ORD_DESC As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(value As String)
            EE_ORD_DESC = value
        End Set
    End Property

    Public Property ATE_EST_VALIDA As Long
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As Long)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As String
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As String)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property EDAD As String
        Get
            Return EE_EDAD
        End Get
        Set(value As String)
            EE_EDAD = value
        End Set
    End Property
End Class
