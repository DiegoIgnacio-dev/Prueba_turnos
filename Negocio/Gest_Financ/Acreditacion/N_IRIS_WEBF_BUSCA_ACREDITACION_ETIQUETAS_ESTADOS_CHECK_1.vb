﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1
    End Sub
    Function IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PREV As Integer, ByVal ID_PROC As Integer, ByVal ID_IE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1)
        Return DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1(DESDE, HASTA, ID_PREV, ID_PROC, ID_IE)
    End Function
End Class