Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    End Sub
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER(ByVal ID_USUARIO As Integer, IMG As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER(ID_USUARIO, IMG)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(ByVal IMG As String, ByVal ID_ATENCION As Integer, ByVal ID_USUARIO As Integer, ByVal ATE_NUM As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(IMG, ID_ATENCION, ID_USUARIO, ATE_NUM)
    End Function

End Class
