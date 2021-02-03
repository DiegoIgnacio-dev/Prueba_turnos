Public Class E_RUTA_DOC_BE
    Private EE_FOLIO_CNE As String
    Private EE_URL_BOLETA As String
    Private EE_CONT As Integer
    Private EE_FECHA_EMISION_BE As DateTime
    Private EE_FOLIO_CNE_NC As String
    Private EE_URL_NC As String
    Private EE_FECHA_EMISION_NC As DateTime
    Public Property FECHA_EMISION_NC() As String
        Get
            Return EE_FECHA_EMISION_NC
        End Get
        Set(ByVal value As String)
            EE_FECHA_EMISION_NC = value
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
    Public Property FECHA_EMISION_BE() As DateTime
        Get
            Return EE_FECHA_EMISION_BE
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_EMISION_BE = value
        End Set
    End Property
    Public Property CONT() As Integer
        Get
            Return EE_CONT
        End Get
        Set(ByVal value As Integer)
            EE_CONT = value
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
End Class
