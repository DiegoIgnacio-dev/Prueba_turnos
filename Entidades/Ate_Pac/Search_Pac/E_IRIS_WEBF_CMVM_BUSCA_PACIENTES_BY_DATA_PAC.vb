Public Class E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC
    Private E_ID_PAC As Long
    Public Property ID_PAC() As Long
        Get
            Return E_ID_PAC
        End Get
        Set(ByVal value As Long)
            E_ID_PAC = value
        End Set
    End Property

    Private E_PAC_RUT As String
    Public Property PAC_RUT() As String
        Get
            Return E_PAC_RUT
        End Get
        Set(ByVal value As String)
            E_PAC_RUT = value
        End Set
    End Property

    Private E_PAC_DNI As String
    Public Property PAC_DNI() As String
        Get
            Return E_PAC_DNI
        End Get
        Set(ByVal value As String)
            E_PAC_DNI = value
        End Set
    End Property

    Private E_PAC_NAME As String
    Public Property PAC_NAME() As String
        Get
            Return E_PAC_NAME
        End Get
        Set(ByVal value As String)
            E_PAC_NAME = value
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

    Private E_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(ByVal value As String)
            E_PREVE_DESC = value
        End Set
    End Property
End Class
