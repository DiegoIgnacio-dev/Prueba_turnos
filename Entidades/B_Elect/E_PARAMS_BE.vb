Public Class E_PARAMS_BE
    Private EE_Folio As String
    Private EE_FormaEmision As String
    Private EE_RUTReceptor As String
    Private EE_RznSocRecep As String
    Private EE_DirRecep As String
    Private EE_CmnaRecep As String
    Private EE_CiudadRecep As String
    Private EE_Lst_Detalle As List(Of E_DETALLE_BE)
    Private EE_RazonRef As String
    Private EE_CodVndor As String
    Private EE_CodCaja As String
    Public Property CodCaja() As String
        Get
            Return EE_CodCaja
        End Get
        Set(ByVal value As String)
            EE_CodCaja = value
        End Set
    End Property
    Public Property CodVndor() As String
        Get
            Return EE_CodVndor
        End Get
        Set(ByVal value As String)
            EE_CodVndor = value
        End Set
    End Property
    Public Property RazonRef() As String
        Get
            Return EE_RazonRef
        End Get
        Set(ByVal value As String)
            EE_RazonRef = value
        End Set
    End Property

    Public Property Lst_Detalle() As List(Of E_DETALLE_BE)
        Get
            Return EE_Lst_Detalle
        End Get
        Set(ByVal value As List(Of E_DETALLE_BE))
            EE_Lst_Detalle = value
        End Set
    End Property


    Public Property CiudadRecep() As String
        Get
            Return EE_CiudadRecep
        End Get
        Set(ByVal value As String)
            EE_CiudadRecep = value
        End Set
    End Property
    Public Property CmnaRecep() As String
        Get
            Return EE_CmnaRecep
        End Get
        Set(ByVal value As String)
            EE_CmnaRecep = value
        End Set
    End Property
    Public Property DirRecep() As String
        Get
            Return EE_DirRecep
        End Get
        Set(ByVal value As String)
            EE_DirRecep = value
        End Set
    End Property
    Public Property RznSocRecep() As String
        Get
            Return EE_RznSocRecep
        End Get
        Set(ByVal value As String)
            EE_RznSocRecep = value
        End Set
    End Property
    Public Property RUTReceptor() As String
        Get
            Return EE_RUTReceptor
        End Get
        Set(ByVal value As String)
            EE_RUTReceptor = value
        End Set
    End Property
    Public Property FormaEmision() As String
        Get
            Return EE_FormaEmision
        End Get
        Set(ByVal value As String)
            EE_FormaEmision = value
        End Set
    End Property
    Public Property Folio() As String
        Get
            Return EE_Folio
        End Get
        Set(ByVal value As String)
            EE_Folio = value
        End Set
    End Property
End Class
