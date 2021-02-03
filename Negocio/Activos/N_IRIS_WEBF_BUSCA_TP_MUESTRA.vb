Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_TP_MUESTRA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_MUESTRA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_MUESTRA
    End Sub
    Function IRIS_WEBF_BUSCA_TP_MUESTRA() As List(Of E_IRIS_WEBF_BUSCA_TP_MUESTRA)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_MUESTRA()
    End Function
End Class

