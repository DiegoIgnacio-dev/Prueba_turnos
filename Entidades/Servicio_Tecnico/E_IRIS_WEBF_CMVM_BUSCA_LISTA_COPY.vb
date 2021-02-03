Public Class E_IRIS_WEBF_CMVM_BUSCA_LISTA_COPY
    Private EE_ID_COPY As Integer
    Private EE_EMAIL As String
    Private EE_NOMBRE As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
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
    Public Property EMAIL() As String
        Get
            Return EE_EMAIL
        End Get
        Set(ByVal value As String)
            EE_EMAIL = value
        End Set
    End Property
    Public Property ID_COPY() As Integer
        Get
            Return EE_ID_COPY
        End Get
        Set(ByVal value As Integer)
            EE_ID_COPY = value
        End Set
    End Property
End Class
