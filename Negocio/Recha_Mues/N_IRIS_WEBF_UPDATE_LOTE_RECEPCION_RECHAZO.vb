﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO
    End Sub

    Function IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO(ByVal ID_LOTE As Integer, ByVal ID_USUARIO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO(ID_LOTE, ID_USUARIO)

    End Function
End Class
