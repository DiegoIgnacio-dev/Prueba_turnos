﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3
    End Sub

    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3(DESDE, HASTA, ID_CF, PROCEDENCIA)
    End Function
End Class
