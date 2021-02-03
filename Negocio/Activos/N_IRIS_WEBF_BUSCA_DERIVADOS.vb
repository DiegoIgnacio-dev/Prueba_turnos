'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_DERIVADOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DERIVADOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DERIVADOS
    End Sub

    Function IRIS_WEBF_BUSCA_DERIVADOS() As List(Of E_IRIS_WEBF_BUSCA_DERIVADOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DERIVADOS()

    End Function
End Class