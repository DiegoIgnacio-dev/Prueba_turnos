Imports Entidades
Imports Negocio
Public Class InCo_Area
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Area() As List(Of E_IRIS_WEBF_BUSCA_AREA)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Area As New N_IRIS_WEBF_BUSCA_AREA
        Dim Data_Area As New List(Of E_IRIS_WEBF_BUSCA_AREA)

        Data_Area = NN_Area.IRIS_WEBF_BUSCA_AREA()
        If (Data_Area.Count > 0) Then
            Return Data_Area
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_AREA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_AREA As Integer) As List(Of E_InCo_Area)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Area As New N_InCo_Area
        Dim Data_Area As New List(Of E_InCo_Area)

        Data_Area = NN_Area.IRIS_WEBF_BUSCA_LIS_ADM_AREA(DESDE, HASTA, ID_AREA)
        If (Data_Area.Count > 0) Then
            Return Data_Area
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_AREA As Integer, ByVal AREA_DESC As String) As String
        Dim NN_Area As New N_InCo_Area
        Return NN_Area.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_AREA, AREA_DESC)
    End Function
End Class