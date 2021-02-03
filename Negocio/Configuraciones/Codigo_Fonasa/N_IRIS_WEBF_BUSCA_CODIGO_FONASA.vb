Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CODIGO_FONASA
    Private DD_Data As D_IRIS_WEBF_BUSCA_CODIGO_FONASA
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CODIGO_FONASA
    End Sub
    Function IRIS_WEBF_BUSCA_CODIGO_FONASA() As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
        Return DD_Data.D_IRIS_WEBF_BUSCA_CODIGO_FONASA()
    End Function
End Class
