'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_INDICACIONES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_INDICACIONES
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_INDICACIONES
    End Sub
    Function IRIS_WEBF_BUSCA_INDICACIONES() As List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        Return DD_Data.IRIS_WEBF_BUSCA_INDICACIONES()
    End Function
End Class
