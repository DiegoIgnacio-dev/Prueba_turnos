﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO
    End Sub

    Function IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO(ByVal ID_ATE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO)
        Return DD_Data.IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO(ID_ATE, ID_CF)

    End Function
End Class