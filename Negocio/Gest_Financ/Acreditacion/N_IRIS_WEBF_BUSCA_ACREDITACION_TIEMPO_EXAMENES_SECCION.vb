﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION
    End Sub
    Function IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal ID_IE As Integer, ByVal ID_SECCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION)
        Return DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, ID_IE, ID_SECCION)
    End Function
End Class