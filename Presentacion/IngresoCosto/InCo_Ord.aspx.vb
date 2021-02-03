Imports Entidades
Imports Negocio
Public Class InCo_Ord
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Ord() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Ord As New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
        Dim Data_Ord As New List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)

        Data_Ord = NN_Ord.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
        If (Data_Ord.Count > 0) Then
            Return Data_Ord
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_ORD(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORDEN As Integer) As List(Of E_InCo_Ord)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Ord As New N_InCo_Ord
        Dim Data_Ord As New List(Of E_InCo_Ord)

        Data_Ord = NN_Ord.IRIS_WEBF_BUSCA_LIS_ADM_ORD(DESDE, HASTA, ID_ORDEN)
        If (Data_Ord.Count > 0) Then
            Return Data_Ord
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORDEN As Integer, ByVal ORDEN_DESC As String) As String
        Dim NN_Ord As New N_InCo_Ord
        Return NN_Ord.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_ORDEN, ORDEN_DESC)
    End Function
End Class