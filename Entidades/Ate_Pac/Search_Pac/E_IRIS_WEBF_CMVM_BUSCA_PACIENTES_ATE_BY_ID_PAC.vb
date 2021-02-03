Public Class E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC
    Private E_ID_ATE As Long
    Public Property ID_ATE() As Long
        Get
            Return E_ID_ATE
        End Get
        Set(ByVal value As Long)
            E_ID_ATE = value
        End Set
    End Property

    Private E_ID_ENCRYPT As String
    Public Property ID_ENCRYPT() As String
        Get
            Return E_ID_ENCRYPT
        End Get
        Set(ByVal value As String)
            E_ID_ENCRYPT = value
        End Set
    End Property

    Private E_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return E_ATE_NUM
        End Get
        Set(ByVal value As String)
            E_ATE_NUM = value
        End Set
    End Property

    Private E_ATE_FECHA As Date?
    Public Property ATE_FECHA() As Date?
        Get
            Return E_ATE_FECHA
        End Get
        Set(ByVal value As Date?)
            E_ATE_FECHA = value
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

    Private E_PREV_DESC As String
    Public Property PREV_DESC() As String
        Get
            Return E_PREV_DESC
        End Get
        Set(ByVal value As String)
            E_PREV_DESC = value
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

    Private E_DOC_NAME As String
    Public Property DOC_NAME() As String
        Get
            Return E_DOC_NAME
        End Get
        Set(ByVal value As String)
            E_DOC_NAME = value
        End Set
    End Property
End Class
