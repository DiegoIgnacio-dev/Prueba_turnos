﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
    End Sub
    Function IRIS_WEBF_BUSCA_PACIENTE_LIKE2(ByVal RUT_P As String, ByVal NOM_P As String, ByVal APE_P As String, ByVal sinpuntos As String, Optional ByVal dni As String = Nothing) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2)
        Return DD_Data.IRIS_WEBF_BUSCA_PACIENTE_LIKE2(RUT_P, NOM_P, APE_P, sinpuntos, dni)
    End Function
End Class