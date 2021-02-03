Imports Entidades
Imports Negocio
Public Class InCo_Prev
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Preve() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Preve As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Preve As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        Data_Preve = NN_Preve.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Preve.Count > 0) Then
            Return Data_Preve
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_PREVE(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PREVE As Integer) As List(Of E_InCo_Preve)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Preve As New N_InCo_Preve
        Dim Data_Preve As New List(Of E_InCo_Preve)

        Data_Preve = NN_Preve.IRIS_WEBF_BUSCA_LIS_ADM_PREVE(DESDE, HASTA, ID_PREVE)
        If (Data_Preve.Count > 0) Then
            Return Data_Preve
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PREVE As Integer, ByVal PREVE_DESC As String) As String
        Dim NN_Prev As New N_InCo_Preve
        Return NN_Prev.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_PREVE, PREVE_DESC)
    End Function
End Class