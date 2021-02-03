'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_PROCE_DIALISIS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_PROCE_DIALISIS

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_PROCE_DIALISIS
    End Sub

    Function IRIS_WEBF_CMVM_BUSCA_PROCE_DIALISIS() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_PROCE_DIALISIS()
    End Function
End Class
