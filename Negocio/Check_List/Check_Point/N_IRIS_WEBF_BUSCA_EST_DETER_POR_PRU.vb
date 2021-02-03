'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU
    End Sub
    Function IRIS_WEBF_BUSCA_EST_DETER_POR_PRU() As List(Of E_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_DETER_POR_PRU()
    End Function
End Class
