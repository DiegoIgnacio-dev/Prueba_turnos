﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
    End Sub
    Function IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Return DD_Data.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Return DD_Data.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ID_PREV)
    End Function
End Class