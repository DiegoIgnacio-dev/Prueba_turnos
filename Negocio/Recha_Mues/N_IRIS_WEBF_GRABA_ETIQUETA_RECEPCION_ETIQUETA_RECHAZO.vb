﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO
    End Sub

    Function IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO(ByVal ID_ATE As Integer, ByVal NUM_ATE As Integer, ByVal CB As String, ByVal ID_USUARIO As Integer, ByVal ID_RECHA As Integer, ByVal OBSERVAC As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO(ID_ATE, NUM_ATE, CB, ID_USUARIO, ID_RECHA, OBSERVAC)

    End Function
End Class