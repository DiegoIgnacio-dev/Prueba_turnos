﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS
    End Sub
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer, ByVal ID_VAL As Integer, ByVal ID_NMUE As Integer, ByVal ID_SECCION As Integer, ByVal ID_TUBO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS(TIPO, DESDE, HASTA, ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ID_TUBO)
    End Function
End Class
