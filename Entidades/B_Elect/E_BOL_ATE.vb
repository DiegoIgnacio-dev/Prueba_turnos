Public Class E_BOL_ATE
    Private EE_ATE_NUM As String
    Private EE_FOLIO_CNE As String
    Private EE_URL_BOLETA As String
    Private EE_FOLIO_CNE_NC As String
    Private EE_URL_NC As String
    Private EE_USUARIO As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_RUT As String
    Private EE_ATE_FECHA As Date
    Private EE_PROC_DESC As String
    Private EE_TOTAL As Integer
    Private EE_NETO As Integer
    Private EE_BOLETA As Integer
    Private EE_IVA As Integer
    Public Property IVA() As Integer
        Get
            Return EE_IVA
        End Get
        Set(ByVal value As Integer)
            EE_IVA = value
        End Set
    End Property

    Public Property NETO() As Integer
        Get
            Return EE_NETO
        End Get
        Set(ByVal value As Integer)
            EE_NETO = value
        End Set
    End Property
    Public Property BOLETA() As String
        Get
            Return EE_BOLETA
        End Get
        Set(ByVal value As String)
            EE_BOLETA = value
        End Set
    End Property
    Public Property TOTAL() As Integer
        Get
            Return EE_TOTAL
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL = value
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
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property USUARIO() As String
        Get
            Return EE_USUARIO
        End Get
        Set(ByVal value As String)
            EE_USUARIO = value
        End Set
    End Property
    Public Property URL_NC() As String
        Get
            Return EE_URL_NC
        End Get
        Set(ByVal value As String)
            EE_URL_NC = value
        End Set
    End Property
    Public Property FOLIO_CNE_NC() As String
        Get
            Return EE_FOLIO_CNE_NC
        End Get
        Set(ByVal value As String)
            EE_FOLIO_CNE_NC = value
        End Set
    End Property
    Public Property URL_BOLETA() As String
        Get
            Return EE_URL_BOLETA
        End Get
        Set(ByVal value As String)
            EE_URL_BOLETA = value
        End Set
    End Property
    Public Property FOLIO_CNE() As String
        Get
            Return EE_FOLIO_CNE
        End Get
        Set(ByVal value As String)
            EE_FOLIO_CNE = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
End Class
