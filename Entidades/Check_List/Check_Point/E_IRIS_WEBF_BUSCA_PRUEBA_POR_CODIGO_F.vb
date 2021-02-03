Public Class E_IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F
    Private EE_ID_PRUEBA As Integer
    Public Property ID_PRUEBA() As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property

    Private EE_PRU_DESC As String
    Public Property PRU_DESC() As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_PRU_DESC = value
        End Set
    End Property
End Class