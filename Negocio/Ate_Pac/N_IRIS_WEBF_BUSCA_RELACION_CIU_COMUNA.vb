﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
    End Sub
    Function IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ByVal ID_CIU As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ID_CIU)
    End Function
End Class