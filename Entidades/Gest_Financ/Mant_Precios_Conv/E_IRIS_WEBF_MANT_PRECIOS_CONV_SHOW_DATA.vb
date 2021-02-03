Public Class E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA
    Private EE_ID_CODIGO_FONASA As Long
    Public Property ID_CODIGO_FONASA() As Long
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Long)
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

    Private EE_CF_CONVENIO_OUT As Boolean
    Public Property CF_CONVENIO_OUT() As Boolean
        Get
            Return EE_CF_CONVENIO_OUT
        End Get
        Set(ByVal value As Boolean)
            EE_CF_CONVENIO_OUT = value
        End Set
    End Property

    Private EE_ID_CF_PRECIO As Long
    Public Property ID_CF_PRECIO() As Long
        Get
            Return EE_ID_CF_PRECIO
        End Get
        Set(ByVal value As Long)
            EE_ID_CF_PRECIO = value
        End Set
    End Property

    Private EE_CF_PRECIO_AMB As Long
    Public Property CF_PRECIO_AMB() As Long
        Get
            Return EE_CF_PRECIO_AMB
        End Get
        Set(ByVal value As Long)
            EE_CF_PRECIO_AMB = value
        End Set
    End Property

    Private EE_CF_PRECIO_COSTO_DERIV As Long
    Public Property CF_PRECIO_COSTO_DERIV() As Long
        Get
            Return EE_CF_PRECIO_COSTO_DERIV
        End Get
        Set(ByVal value As Long)
            EE_CF_PRECIO_COSTO_DERIV = value
        End Set
    End Property

    Private EE_CF_PRECIO_COSTO_T As Long
    Public Property CF_PRECIO_COSTO_T() As Long
        Get
            Return EE_CF_PRECIO_COSTO_T
        End Get
        Set(ByVal value As Long)
            EE_CF_PRECIO_COSTO_T = value
        End Set
    End Property

    Private EE_CF_PRECIO_PJE_LAB As Double
    Public Property CF_PRECIO_PJE_LAB() As Double
        Get
            Return EE_CF_PRECIO_PJE_LAB
        End Get
        Set(ByVal value As Double)
            EE_CF_PRECIO_PJE_LAB = value
        End Set
    End Property

    Private EE_CF_PRECIO_PJE_CONV As Double
    Public Property CF_PRECIO_PJE_CONV() As Double
        Get
            Return EE_CF_PRECIO_PJE_CONV
        End Get
        Set(ByVal value As Double)
            EE_CF_PRECIO_PJE_CONV = value
        End Set
    End Property

    Private EE_ID_AÑO As Integer
    Public Property ID_AÑO() As Integer
        Get
            Return EE_ID_AÑO
        End Get
        Set(ByVal value As Integer)
            EE_ID_AÑO = value
        End Set
    End Property

    Private EE_AÑO_COD As String
    Public Property AÑO_COD() As String
        Get
            Return EE_AÑO_COD
        End Get
        Set(ByVal value As String)
            EE_AÑO_COD = value
        End Set
    End Property

    Private EE_AÑO_DESC As String
    Public Property AÑO_DESC() As String
        Get
            Return EE_AÑO_DESC
        End Get
        Set(ByVal value As String)
            EE_AÑO_DESC = value
        End Set
    End Property

    Private EE_ID_PREVE As Long
    Public Property ID_PREVE() As Long
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Long)
            EE_ID_PREVE = value
        End Set
    End Property

    Private EE_PREVE_COD As String
    Public Property PREVE_COD() As String
        Get
            Return EE_PREVE_COD
        End Get
        Set(ByVal value As String)
            EE_PREVE_COD = value
        End Set
    End Property

    Private EE_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
End Class