﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
    Dim DD_Data As D_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
    End Sub
    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        Return DD_Data.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4(ID_ATE)
    End Function
    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        Return DD_Data.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2(ID_ATE)
    End Function
End Class