Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_GRABA_EMAIL
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_EMAIL

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_EMAIL
    End Sub

    Function IRIS_WEBF_CMVM_GRABA_EMAIL(ByVal Email As String, ByVal Nombre As String, ByVal Tipo As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_GRABA_EMAIL(Email, Nombre, Tipo)

    End Function
End Class
