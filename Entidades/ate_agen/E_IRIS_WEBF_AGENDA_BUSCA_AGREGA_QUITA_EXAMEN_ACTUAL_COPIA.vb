Public Class E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_COPIA
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_ID_DET_PREI As Integer
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_CF_COD As String
    Dim EE_CF_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_PREI_DET_V_PREVI As Integer
    Dim EE_PREI_DET_V_PAGADO As Integer
    Dim EE_PREI_DET_V_COPAGO As Integer
    Dim EE_PREI_DET_DOC As Integer
    Dim EE_ID_TP_PAGO As Integer
    Dim EE_TP_PAGO_DESC As String
    Dim EE_CF_DIAS As String
    Dim EE_ID_PER As Integer
    Dim EE_ATE_NUM_OMI As String
    Dim EE_ATE_NUM_INTERFAZ As String
    Dim EE_ATE_CF_MULTIPLICADOS As String
    Dim EE_ATE_CODIGO_TEST As String
    Public Property ATE_CODIGO_TEST As String
        Get
            Return EE_ATE_CODIGO_TEST
        End Get
        Set(value As String)
            EE_ATE_CODIGO_TEST = value
        End Set
    End Property
    Public Property ATE_CF_MULTIPLICADOS As String
        Get
            Return EE_ATE_CF_MULTIPLICADOS
        End Get
        Set(value As String)
            EE_ATE_CF_MULTIPLICADOS = value
        End Set
    End Property
    Public Property ATE_NUM_OMI As String
        Get
            Return EE_ATE_NUM_OMI
        End Get
        Set(value As String)
            EE_ATE_NUM_OMI = value
        End Set
    End Property
    Public Property ATE_NUM_INTERFAZ As Integer
        Get
            Return EE_ATE_NUM_INTERFAZ
        End Get
        Set(value As Integer)
            EE_ATE_NUM_INTERFAZ = value
        End Set
    End Property
    Public Property ID_PREINGRESO As Integer
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(value As Integer)
            EE_ID_PREINGRESO = value
        End Set
    End Property
    Public Property ID_DET_PREI As Integer
        Get
            Return EE_ID_DET_PREI
        End Get
        Set(value As Integer)
            EE_ID_DET_PREI = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
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
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property PREI_DET_V_PREVI As Integer
        Get
            Return EE_PREI_DET_V_PREVI
        End Get
        Set(value As Integer)
            EE_PREI_DET_V_PREVI = value
        End Set
    End Property
    Public Property PREI_DET_V_PAGADO As Integer
        Get
            Return EE_PREI_DET_V_PAGADO
        End Get
        Set(value As Integer)
            EE_PREI_DET_V_PAGADO = value
        End Set
    End Property
    Public Property PREI_DET_V_COPAGO As Integer
        Get
            Return EE_PREI_DET_V_COPAGO
        End Get
        Set(value As Integer)
            EE_PREI_DET_V_COPAGO = value
        End Set
    End Property
    Public Property PREI_DET_DOC As Integer
        Get
            Return EE_PREI_DET_DOC
        End Get
        Set(value As Integer)
            EE_PREI_DET_DOC = value
        End Set
    End Property
    Public Property ID_TP_PAGO As Integer
        Get
            Return EE_ID_TP_PAGO
        End Get
        Set(value As Integer)
            EE_ID_TP_PAGO = value
        End Set
    End Property
    Public Property TP_PAGO_DESC As String
        Get
            Return EE_TP_PAGO_DESC
        End Get
        Set(value As String)
            EE_TP_PAGO_DESC = value
        End Set
    End Property
    Public Property CF_DIAS As String
        Get
            Return EE_CF_DIAS
        End Get
        Set(value As String)
            EE_CF_DIAS = value
        End Set
    End Property
    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
        End Set
    End Property
End Class
