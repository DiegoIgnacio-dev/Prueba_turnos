﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_RES_CODIFICADO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_RES_CODIFICADO
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_RES_CODIFICADO
    End Sub
    Function IRIS_WEBF_GRABA_RES_CODIFICADO(ByVal RES_COD As String, ByVal RES_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_RES_CODIFICADO(RES_COD, RES_DES, ID_ESTADO)
    End Function
End Class