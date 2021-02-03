Public Class E_InCo_Area
    Private EE_TOT_FONASA As Integer
    Private EE_TOTA_SIS As Integer
    Private EE_TOTA_USU As Integer
    Private EE_TOTA_COPA As Integer
    Private EE_CF_DESC As String
    Private EE_RLS_LS_DESC As String
    Private EE_AREA_DESC As String
    Private EE_CF_COD As String
    Private EE_CONTROL_COSTO_PRECIo As Integer
    Public Property CONTROL_COSTO_PRECIO() As Integer
        Get
            Return EE_CONTROL_COSTO_PRECIo
        End Get
        Set(ByVal value As Integer)
            EE_CONTROL_COSTO_PRECIo = value
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
    Public Property AREA_DESC() As String
        Get
            Return EE_AREA_DESC
        End Get
        Set(ByVal value As String)
            EE_AREA_DESC = value
        End Set
    End Property
    Public Property RLS_LS_DESC() As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(ByVal value As String)
            EE_RLS_LS_DESC = value
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
    Public Property TOTA_COPA() As Integer
        Get
            Return EE_TOTA_COPA
        End Get
        Set(ByVal value As Integer)
            EE_TOTA_COPA = value
        End Set
    End Property
    Public Property TOTA_USU() As Integer
        Get
            Return EE_TOTA_USU
        End Get
        Set(ByVal value As Integer)
            EE_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_SIS() As Integer
        Get
            Return EE_TOTA_SIS
        End Get
        Set(ByVal value As Integer)
            EE_TOTA_SIS = value
        End Set
    End Property
    Public Property TOT_FONASA() As Integer
        Get
            Return EE_TOT_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_TOT_FONASA = value
        End Set
    End Property
End Class
