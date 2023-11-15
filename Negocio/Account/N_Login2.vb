'Importar Capas
Imports Datos
Imports Entidades
Public Class N_Login2
    'Declaraciones Generales
    Dim DD_Data As D_Login2
    Sub New()
        DD_Data = New D_Login2
    End Sub

    Function IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(ByVal USER As String, ByVal PASS As String) As E_Login2
        Return DD_Data.IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(USER, PASS)
    End Function
End Class