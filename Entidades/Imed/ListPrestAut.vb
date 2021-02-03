Public Class ListPrestAut
    Private E_CodPrestacion As String
    Private E_CodItem As String
    Private E_Cantidad As Integer
    Private E_RecargoHora As String
    Private E_MtoTotal As Integer
    Private E_InfAdicional As String
    Public Property CodPrestacion() As String
        Get
            Return E_CodPrestacion
        End Get
        Set(ByVal value As String)
            E_CodPrestacion = value
        End Set
    End Property
    Public Property CodItem() As String
        Get
            Return E_CodItem
        End Get
        Set(ByVal value As String)
            E_CodItem = value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return E_Cantidad
        End Get
        Set(ByVal value As Integer)
            E_Cantidad = value
        End Set
    End Property
    Public Property RecargoHora() As String
        Get
            Return E_RecargoHora
        End Get
        Set(ByVal value As String)
            E_RecargoHora = value
        End Set
    End Property
    Public Property MtoTotal() As Integer
        Get
            Return E_MtoTotal
        End Get
        Set(ByVal value As Integer)
            E_MtoTotal = value
        End Set
    End Property
    Public Property InfAdicional() As String
        Get
            Return E_InfAdicional
        End Get
        Set(ByVal value As String)
            E_InfAdicional = value
        End Set
    End Property
End Class
