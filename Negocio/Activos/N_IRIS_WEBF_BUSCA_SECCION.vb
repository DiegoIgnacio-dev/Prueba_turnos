Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_SECCION
    Dim DD_Data As D_IRIS_WEBF_BUSCA_SECCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_SECCION
    End Sub
    Function IRIS_WEBF_BUSCA_SECCION() As List(Of E_IRIS_WEBF_BUSCA_SECCION)
        Return DD_Data.IRIS_WEBF_BUSCA_SECCION()
    End Function
End Class
