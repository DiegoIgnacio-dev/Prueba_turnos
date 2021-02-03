Public Class E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
    Private EE_AUDI_FECHA As Date
    Public Property AUDI_FECHA() As Date
        Get
            Return EE_AUDI_FECHA
        End Get
        Set(ByVal value As Date)
            EE_AUDI_FECHA = value
        End Set
    End Property

    Private EE_AUDI_ACCION As String
    Public Property AUDI_ACCION() As String
        Get
            Return EE_AUDI_ACCION
        End Get
        Set(ByVal value As String)
            EE_AUDI_ACCION = value
        End Set
    End Property

    Private EE_AUDI_FORMA As String
    Public Property AUDI_FORMA() As String
        Get
            Return EE_AUDI_FORMA
        End Get
        Set(ByVal value As String)
            EE_AUDI_FORMA = value
        End Set
    End Property

    Private EE_ID_ATE_RES As Long
    Public Property ID_ATE_RES() As Long
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(ByVal value As Long)
            EE_ID_ATE_RES = value
        End Set
    End Property

    Private EE_USU_NIC As String
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property
End Class