﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM
    End Sub
    Function IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM)
        Return DD_Data.IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM(DESDE, HASTA, ID_PRE)
    End Function
End Class