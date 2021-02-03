Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_TP_PAGO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_PAGO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_PAGO
    End Sub
    Function IRIS_WEBF_BUSCA_TP_PAGO() As List(Of E_IRIS_WEBF_BUSCA_TP_PAGO)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_PAGO()
    End Function
End Class
