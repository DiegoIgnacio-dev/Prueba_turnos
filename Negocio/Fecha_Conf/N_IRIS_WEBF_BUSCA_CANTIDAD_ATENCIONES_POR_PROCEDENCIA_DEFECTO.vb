﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
    Private DD_Data As D_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
    End Sub
    Function IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO(ByVal ID_PRO As String) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO)
        Return DD_Data.D_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO(ID_PRO)
    End Function
End Class