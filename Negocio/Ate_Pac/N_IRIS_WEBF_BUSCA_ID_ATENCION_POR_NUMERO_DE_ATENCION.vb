﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
    End Sub
    Function IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Return DD_Data.IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(NUM_ATE)
    End Function
    Function IRIS_WEBF_BUSCA_ID_PREINGRESO_POR_NUMERO_DE_AGENDA_ID(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Return DD_Data.IRIS_WEBF_BUSCA_ID_PREINGRESO_POR_NUMERO_DE_AGENDA_ID(NUM_ATE)
    End Function
End Class