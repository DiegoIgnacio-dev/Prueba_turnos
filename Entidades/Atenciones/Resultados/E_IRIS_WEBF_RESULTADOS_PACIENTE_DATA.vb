Public Class E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
    Private EE_ATE_AÑO As Integer
    Public Property ATE_AÑO() As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property
    Private EE_ATE_MES As Integer
    Public Property ATE_MES() As Integer
        Get
            Return EE_ATE_MES
        End Get
        Set(ByVal value As Integer)
            EE_ATE_MES = value
        End Set
    End Property
    Private EE_ATE_DIA As Integer
    Public Property ATE_DIA() As Integer
        Get
            Return EE_ATE_DIA
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DIA = value
        End Set
    End Property
    Private EE_ATE_OBS_TM As String
    Public Property ATE_OBS_TM() As String
        Get
            Return EE_ATE_OBS_TM
        End Get
        Set(ByVal value As String)
            EE_ATE_OBS_TM = value
        End Set
    End Property
    Private EE_ORD_DESC As String
    Public Property ORD_DESC() As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(ByVal value As String)
            EE_ORD_DESC = value
        End Set
    End Property
    Private EE_DOC_APELLIDO As String
    Public Property DOC_APELLIDO() As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Private EE_DOC_NOMBRE As String
    Public Property DOC_NOMBRE() As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Private EE_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property

    Private EE_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property

    Private EE_ATE_FECHA As Date
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Private EE_ATE_FUR As String
    Public Property ATE_FUR() As String
        Get
            Return EE_ATE_FUR
        End Get
        Set(ByVal value As String)
            EE_ATE_FUR = value
        End Set
    End Property

    Private EE_ID_PACIENTE As Long
    Public Property ID_PACIENTE() As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Long)
            EE_ID_PACIENTE = value
        End Set
    End Property

    Private EE_PAC_RUT As String
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property

    Private EE_PAC_NOMBRE As String
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property

    Private EE_PAC_APELLIDO As String
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property

    Private EE_PAC_FNAC As Date
    Public Property PAC_FNAC() As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property

    Private EE_EDAD As String
    Public Property EDAD() As String
        Get
            Return EE_EDAD
        End Get
        Set(ByVal value As String)
            EE_EDAD = value
        End Set
    End Property

    Private EE_SEXO_COD As String
    Public Property SEXO_COD() As String
        Get
            Return EE_SEXO_COD
        End Get
        Set(ByVal value As String)
            EE_SEXO_COD = value
        End Set
    End Property

    Private EE_SEXO_DESC As String
    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property

    Private EE_ID_PROCEDENCIA As Long
    Public Property ID_PROCEDENCIA() As Long
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Long)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property

    Private EE_ID_PREVE As Long
    Public Property ID_PREVE() As Long
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Long)
            EE_ID_PREVE = value
        End Set
    End Property

    Private EE_ID_PROGRA As Long
    Public Property ID_PROGRA() As Long
        Get
            Return EE_ID_PROGRA
        End Get
        Set(ByVal value As Long)
            EE_ID_PROGRA = value
        End Set
    End Property

    Private E_ID_INTEXT As Integer
    Public Property ID_INTEXT() As Integer
        Get
            Return E_ID_INTEXT
        End Get
        Set(ByVal value As Integer)
            E_ID_INTEXT = value
        End Set
    End Property

    Private E_ID_SECTOR As Integer
    Public Property ID_SECTOR() As Integer
        Get
            Return E_ID_SECTOR
        End Get
        Set(ByVal value As Integer)
            E_ID_SECTOR = value
        End Set
    End Property

    Private E_SECTOR_DESC As String
    Public Property SECTOR_DESC() As String
        Get
            Return E_SECTOR_DESC
        End Get
        Set(ByVal value As String)
            E_SECTOR_DESC = value
        End Set
    End Property

    Private E_CANT_HIST As Integer
    Public Property CANT_HIST() As Integer
        Get
            Return E_CANT_HIST
        End Get
        Set(ByVal value As Integer)
            E_CANT_HIST = value
        End Set
    End Property
End Class