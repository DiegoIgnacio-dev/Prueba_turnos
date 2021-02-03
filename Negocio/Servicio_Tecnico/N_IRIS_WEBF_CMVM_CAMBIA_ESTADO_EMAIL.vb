Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL
    End Sub

    Function IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL(ByVal NAME As Integer, ByVal ID_EMAIL As Integer, ByVal ESTADO As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL(NAME, ID_EMAIL, ESTADO)

    End Function
End Class
