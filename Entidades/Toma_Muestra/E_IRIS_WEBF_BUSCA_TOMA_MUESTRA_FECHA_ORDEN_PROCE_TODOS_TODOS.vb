Public Class E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
    Private EE_ID_ATENCION As Integer
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_ATE_AÑO As Integer
    Private EE_PROC_DESC As String
    Private EE_ORD_DESC As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_FONO1 As String
    Private EE_PAC_MOVIL1 As String
    Private EE_SEXO_DESC As String
    Private EE_ID_PACIENTE As Integer
    Private EE_EST_DESCRIPCION As String
    Private EE_ESPERA As String
    Private EE_USU_NIC As String
    Private EE_ATE_ID_ESTADO_TM As Integer
    Private EE_DOCS_CANT As Integer
    Private EE_OBS As String
    Public Property OBS() As String
        Get
            Return EE_OBS
        End Get
        Set(ByVal value As String)
            EE_OBS = value
        End Set
    End Property
    Public Property DOCS_CANT As Integer
        Get
            Return EE_DOCS_CANT
        End Get
        Set(ByVal value As Integer)
            EE_DOCS_CANT = value
        End Set
    End Property
    Public Property ATE_ID_ESTADO_TM() As Integer
        Get
            Return EE_ATE_ID_ESTADO_TM
        End Get
        Set(ByVal value As Integer)
            EE_ATE_ID_ESTADO_TM = value
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
    Public Property ESPERA() As String
        Get
            Return EE_ESPERA
        End Get
        Set(ByVal value As String)
            EE_ESPERA = value
        End Set
    End Property
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property

    Public Property ID_PACIENTE() As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property
    Public Property PAC_MOVIL1() As String
        Get
            Return EE_PAC_MOVIL1
        End Get
        Set(ByVal value As String)
            EE_PAC_MOVIL1 = value
        End Set
    End Property
    Public Property PAC_FONO1() As String
        Get
            Return EE_PAC_FONO1
        End Get
        Set(ByVal value As String)
            EE_PAC_FONO1 = value
        End Set
    End Property
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property ORD_DESC() As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(ByVal value As String)
            EE_ORD_DESC = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property ATE_AÑO() As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
