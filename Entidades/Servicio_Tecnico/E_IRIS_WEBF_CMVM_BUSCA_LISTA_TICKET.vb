Public Class E_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET
    Private EE_ID_TICKET As Long
    Private EE_ASUNTO As String
    Private EE_FORMULARIO As String
    Private EE_FECHA As DateTime
    Private EE_ESTADO As Integer
    Private EE_USU_NIC As String
    Private EE_USU_NOMBRE As String
    Private EE_USU_APELLIDO As String
    Public Property USU_APELLIDO() As String
        Get
            Return EE_USU_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_USU_APELLIDO = value
        End Set
    End Property
    Public Property USU_NOMBRE() As String
        Get
            Return EE_USU_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_USU_NOMBRE = value
        End Set
    End Property
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property ESTADO() As Integer
        Get
            Return EE_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ESTADO = value
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
    Public Property FORMULARIO() As String
        Get
            Return EE_FORMULARIO
        End Get
        Set(ByVal value As String)
            EE_FORMULARIO = value
        End Set
    End Property
    Public Property ASUNTO() As String
        Get
            Return EE_ASUNTO
        End Get
        Set(ByVal value As String)
            EE_ASUNTO = value
        End Set
    End Property
    Public Property ID_TICKET() As Long
        Get
            Return EE_ID_TICKET
        End Get
        Set(ByVal value As Long)
            EE_ID_TICKET = value
        End Set
    End Property
End Class
