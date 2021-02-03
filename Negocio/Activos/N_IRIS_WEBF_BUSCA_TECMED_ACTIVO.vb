Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_TECMED_ACTIVO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TECMED_ACTIVO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TECMED_ACTIVO
    End Sub
    Function IRIS_WEBF_BUSCA_TECMED_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_TECMED_ACTIVO)
        Return DD_Data.IRIS_WEBF_BUSCA_TECMED_ACTIVO()
    End Function
End Class
