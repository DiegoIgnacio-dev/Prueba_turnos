﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA() As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA)
        Return DD_Data.D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA()
    End Function
End Class
