Public Class E_IRIS_WEBF_BUSCA_ETIQUETAS_TM
    Private EE_CF_COD As String
    Private EE_CF_DESC As String
    Private EE_MUESTRA As String
    Public Property MUESTRA() As String
        Get
            Return EE_MUESTRA
        End Get
        Set(ByVal value As String)
            EE_MUESTRA = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
End Class
