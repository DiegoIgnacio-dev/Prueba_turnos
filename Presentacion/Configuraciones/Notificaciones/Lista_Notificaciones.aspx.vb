Imports Entidades
Imports Negocio
Public Class Lista_Notificaciones
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Busca_Lista(ByVal ID_USUARIO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET
        Dim Data_OUT As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET)

        Data_OUT = NN_Search.IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET(ID_USUARIO)
        If (Data_OUT.Count > 0) Then
            Return Data_OUT

        Else
            Return Nothing
        End If
    End Function

End Class