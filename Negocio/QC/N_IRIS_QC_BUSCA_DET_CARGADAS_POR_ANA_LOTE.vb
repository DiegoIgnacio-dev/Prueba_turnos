﻿Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
    Dim DD_Data As D_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
    End Sub
    Function IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE(ByVal ID_ANA As Long, ByVal ID_LOTE As Long) As List(Of E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE)
        Return DD_Data.IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE(ID_ANA, ID_LOTE)
    End Function
End Class