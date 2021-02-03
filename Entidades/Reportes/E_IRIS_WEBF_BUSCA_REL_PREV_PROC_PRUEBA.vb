Public Class E_IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA
    Private EE_ID_PRUEBA As Long
    Private EE_AGRU_PRU_PROC_DESC As String
    Public Property AGRU_PRU_PROC_DESC() As String
        Get
            Return EE_AGRU_PRU_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_AGRU_PRU_PROC_DESC = value
        End Set
    End Property
    Public Property ID_PRUEBA() As Long
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Long)
            EE_ID_PRUEBA = value
        End Set
    End Property
End Class
