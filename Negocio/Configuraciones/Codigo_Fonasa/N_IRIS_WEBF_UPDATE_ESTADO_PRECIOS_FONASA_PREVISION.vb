﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
    Private DD_Data As D_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
    End Sub
    Function IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION(ByVal ID_ANO As Integer, ByVal ID_USUARIO As Integer, ByVal ID_FONASA As Integer, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.D_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION(ID_ANO, ID_USUARIO, ID_FONASA, ID_ESTADO)
    End Function
End Class
