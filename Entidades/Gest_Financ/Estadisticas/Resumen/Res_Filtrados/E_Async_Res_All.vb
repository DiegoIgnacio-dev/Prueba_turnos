Public Class E_Async_Res_All

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

    Private EE_SEXO_DESC As String
    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property

    Private EE_PAC_FNAC As Date
    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property

    Private EE_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Private EE_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property

    Private EE_PROGRA_DESC As String
    Public Property PROGRA_DESC() As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(ByVal value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property

    Private EE_SUBP_DESC As String
    Public Property SUBP_DESC() As String
        Get
            Return EE_SUBP_DESC
        End Get
        Set(ByVal value As String)
            EE_SUBP_DESC = value
        End Set
    End Property

    Private EE_ATE_OMI As String
    Public Property ATE_OMI() As String
        Get
            Return EE_ATE_OMI
        End Get
        Set(ByVal value As String)
            EE_ATE_OMI = value
        End Set
    End Property

    Private E_DOC_RUT As String
    Public Property DOC_RUT() As String
        Get
            Return E_DOC_RUT
        End Get
        Set(ByVal value As String)
            E_DOC_RUT = value
        End Set
    End Property

    Private E_DOC_NOMBRE As String
    Public Property DOC_NOMBRE() As String
        Get
            Return E_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            E_DOC_NOMBRE = value
        End Set
    End Property

    Private E_DOC_APELLIDO As String
    Public Property DOC_APELLIDO() As String
        Get
            Return E_DOC_APELLIDO
        End Get
        Set(ByVal value As String)
            E_DOC_APELLIDO = value
        End Set
    End Property

    Private EE_VALUES As List(Of E_Async_Res_All_Values)
    Public Property VALUES() As List(Of E_Async_Res_All_Values)
        Get
            Return EE_VALUES
        End Get
        Set(ByVal value As List(Of E_Async_Res_All_Values))
            EE_VALUES = value
        End Set
    End Property
End Class