Public Class E_DETALLE_BE
    Private EE_NmbItem As String
    Private EE_PrcItem As String
    Private EE_IndExe As String
    Private EE_TieneIVA As String
    Public Property TieneIVA() As String
        Get
            Return EE_TieneIVA
        End Get
        Set(ByVal value As String)
            EE_TieneIVA = value
        End Set
    End Property
    Public Property IndExe() As String
        Get
            Return EE_IndExe
        End Get
        Set(ByVal value As String)
            EE_IndExe = value
        End Set
    End Property
    Public Property PrcItem() As String
        Get
            Return EE_PrcItem
        End Get
        Set(ByVal value As String)
            EE_PrcItem = value
        End Set
    End Property
    Public Property NmbItem() As String
        Get
            Return EE_NmbItem
        End Get
        Set(ByVal value As String)
            EE_NmbItem = value
        End Set
    End Property
End Class
