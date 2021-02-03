'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_METODO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_METODO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_METODO
    End Sub
    Function IRIS_WEBF_BUSCA_METODO() As List(Of E_IRIS_WEBF_BUSCA_METODO)
        Return DD_Data.IRIS_WEBF_BUSCA_METODO()
    End Function
End Class
