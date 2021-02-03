Imports Datos
Imports Entidades
Public Class N_IRIS_BUSCA_CANTIDAD_EXA_POR_CF_OMI
    Dim DD_Data As D_BUSCA_TOT_OMI
    Sub New()
        DD_Data = New D_BUSCA_TOT_OMI
    End Sub
    Function BUSCA_TOT_OMI(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_BUSCA_TOT_OMI)
        Return DD_Data.BUSCA_TOT_OMI(DESDE, HASTA)
    End Function
End Class
