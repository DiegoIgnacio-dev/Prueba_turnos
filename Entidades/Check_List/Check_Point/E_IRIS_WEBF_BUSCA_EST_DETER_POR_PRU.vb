Public Class E_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU
    Private EE_ID_EST As Integer
    Public Property ID_EST() As Integer
        Get
            Return EE_ID_EST
        End Get
        Set(ByVal value As Integer)
            EE_ID_EST = value
        End Set
    End Property
    Private EE_EST_EXA_COD As String
    Public Property EXT_EXA_COD() As String
        Get
            Return EE_EST_EXA_COD
        End Get
        Set(ByVal value As String)
            EE_EST_EXA_COD = value
        End Set
    End Property
    Private EE_EST_EXA_DESC As String
    Public Property EST_EXA_DESC() As String
        Get
            Return EE_EST_EXA_DESC
        End Get
        Set(ByVal value As String)
            EE_EST_EXA_DESC = value
        End Set
    End Property
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
