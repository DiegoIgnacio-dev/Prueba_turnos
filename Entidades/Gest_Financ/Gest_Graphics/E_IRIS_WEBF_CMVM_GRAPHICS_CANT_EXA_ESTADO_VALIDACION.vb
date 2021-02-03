Public Class E_IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION
    Private E_CANT_EXAM As Integer
    Public Property CANT_EXAM() As Integer
        Get
            Return E_CANT_EXAM
        End Get
        Set(ByVal value As Integer)
            E_CANT_EXAM = value
        End Set
    End Property

    Private E_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property

    Private E_EST_COD As String
    Public Property EST_COD() As String
        Get
            Return E_EST_COD
        End Get
        Set(ByVal value As String)
            E_EST_COD = value
        End Set
    End Property

    Private E_EST_DESCRIPCION As String
    Public Property EST_DESCRIPCION() As String
        Get
            Return E_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            E_EST_DESCRIPCION = value
        End Set
    End Property
End Class
