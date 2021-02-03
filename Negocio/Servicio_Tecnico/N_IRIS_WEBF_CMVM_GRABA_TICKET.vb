Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_GRABA_TICKET
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_TICKET

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_TICKET
    End Sub

    Function IRIS_WEBF_CMVM_GRABA_TICKET(ByVal ID_USER As Integer,
                                            ByVal ASUNTO As String,
                                            ByVal FORMULARIO As String,
                                            ByVal MENSAJE As String,
                                            ByVal FECHA As String) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_GRABA_TICKET(ID_USER, ASUNTO, FORMULARIO, MENSAJE, FECHA)

    End Function
End Class
