﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM
    End Sub

    Function IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM(ByVal NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM)
        Return DD_Data.IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM(NUM)

    End Function
End Class