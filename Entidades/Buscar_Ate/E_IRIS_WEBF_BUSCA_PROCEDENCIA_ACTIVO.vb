
Public Class E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
    Private EE_ID_PROCEDENCIA As String
    Private EE_PROC_COD As String
    Private EE_PROC_DESC As String
    Private EE_ID_ESTADO As String
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
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
    Public Property PROC_COD() As String
        Get
            Return EE_PROC_COD
        End Get
        Set(ByVal value As String)
            EE_PROC_COD = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA() As String
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As String)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
End Class
