Imports Entidades
Imports Negocio
Public Class InCo_Med
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Doc() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Med As New N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)

        Data_Med = NN_Med.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()
        If (Data_Med.Count > 0) Then
            Return Data_Med
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_MED(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_DOC As Integer) As List(Of E_InCo_Med)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Med As New N_InCo_Med
        Dim Data_Med As New List(Of E_InCo_Med)

        Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_ADM_MED(DESDE, HASTA, ID_DOC)
        If (Data_Med.Count > 0) Then
            Return Data_Med
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_DOC As Integer, ByVal DOC_NOM As String) As String
        Dim NN_Med As New N_InCo_Med
        Return NN_Med.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_DOC, DOC_NOM)
    End Function
End Class