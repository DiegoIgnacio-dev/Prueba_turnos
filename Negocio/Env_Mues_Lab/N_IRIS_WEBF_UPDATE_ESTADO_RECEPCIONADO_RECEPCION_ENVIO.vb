﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO
    End Sub

    Function IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO(ID_ATE, ID_USUARIO)

    End Function
End Class
