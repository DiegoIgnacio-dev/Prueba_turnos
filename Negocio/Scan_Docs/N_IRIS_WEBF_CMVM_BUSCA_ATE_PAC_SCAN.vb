﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN(ByVal ID_ATENCION As Long) As E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN(ID_ATENCION)
    End Function
End Class
