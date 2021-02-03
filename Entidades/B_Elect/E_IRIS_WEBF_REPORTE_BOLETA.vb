Public Class E_IRIS_WEBF_REPORTE_BOLETA
    Private EE_FOLIO As String
    Private EE_NOMBRE As String
    Private EE_COD As String
    Private EE_EXAMEN As String
    Private EE_PROCEDENCIA As String
    Private EE_TP_PAGO As String
    Private EE_BOLETA As String
    Private EE_NETO As Integer
    Private EE_IVA As Integer
    Private EE_TOTAL As Integer
    Private EE_RUT As String
    Private EE_FECHA As DateTime
    Private EE_USUARIO As String
    Public Property USUARIO() As String
        Get
            Return EE_USUARIO
        End Get
        Set(ByVal value As String)
            EE_USUARIO = value
        End Set
    End Property
    Public Property FECHA() As DateTime
        Get
            Return EE_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA = value
        End Set
    End Property
    Public Property RUT() As String
        Get
            Return EE_RUT
        End Get
        Set(ByVal value As String)
            EE_RUT = value
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
    Public Property TP_PAGO() As String
        Get
            Return EE_TP_PAGO
        End Get
        Set(ByVal value As String)
            EE_TP_PAGO = value
        End Set
    End Property
    Public Property PROCEDENCIA() As String
        Get
            Return EE_PROCEDENCIA
        End Get
        Set(ByVal value As String)
            EE_PROCEDENCIA = value
        End Set
    End Property
    Public Property EXAMEN() As String
        Get
            Return EE_EXAMEN
        End Get
        Set(ByVal value As String)
            EE_EXAMEN = value
        End Set
    End Property
    Public Property COD() As String
        Get
            Return EE_COD
        End Get
        Set(ByVal value As String)
            EE_COD = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return EE_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_NOMBRE = value
        End Set
    End Property
    Public Property FOLIO() As String
        Get
            Return EE_FOLIO
        End Get
        Set(ByVal value As String)
            EE_FOLIO = value
        End Set
    End Property
End Class
