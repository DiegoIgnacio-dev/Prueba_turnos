﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA
    Dim DD_Data As D_IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA
    End Sub

    Function IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA(ByVal ID_PROC As Long, ByVal AÑO As String) As List(Of E_IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA)
        Return DD_Data.IRIS_WEBF_BUSCA_REL_PREV_PROC_PRUEBA(ID_PROC, AÑO)
    End Function
End Class
