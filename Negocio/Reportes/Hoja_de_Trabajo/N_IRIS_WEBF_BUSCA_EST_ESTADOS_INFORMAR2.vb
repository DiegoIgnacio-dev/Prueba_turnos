﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR2

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR2
    End Sub

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR2)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR2(DESDE, HASTA, ID_CF)
    End Function
End Class
