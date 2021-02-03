Imports Entidades
Imports Negocio
Public Class Lista_Ticket
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Busca_Ticket(ByVal ID_USER As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET

        Dim Data_OUT As New List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET)
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_BUSCA_LISTA_TICKET(ID_USER)

        Return Data_OUT

    End Function
End Class