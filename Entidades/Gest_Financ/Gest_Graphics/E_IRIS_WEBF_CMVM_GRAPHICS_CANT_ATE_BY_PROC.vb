Public Class E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC
    Private E_CANT_ATE As Integer
    Public Property CANT_ATE() As Integer
        Get
            Return E_CANT_ATE
        End Get
        Set(ByVal value As Integer)
            E_CANT_ATE = value
        End Set
    End Property

    Private E_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return E_PROC_DESC
        End Get
        Set(ByVal value As String)
            E_PROC_DESC = value
        End Set
    End Property
End Class
