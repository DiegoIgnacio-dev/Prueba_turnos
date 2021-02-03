Imports Entidades
Imports Negocio
Public Class InCo_Sec
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Sec() As List(Of E_IRIS_WEBF_BUSCA_SECCION)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Area As New N_IRIS_WEBF_BUSCA_SECCION
        Dim Data_Area As New List(Of E_IRIS_WEBF_BUSCA_SECCION)

        Data_Area = NN_Area.IRIS_WEBF_BUSCA_SECCION()
        If (Data_Area.Count > 0) Then
            Return Data_Area
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_SECCION(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_SECCION As Integer) As List(Of E_InCo_Sec)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Area As New N_InCo_Sec
        Dim Data_Area As New List(Of E_InCo_Sec)

        Data_Area = NN_Area.IRIS_WEBF_BUSCA_LIS_ADM_SECCION(DESDE, HASTA, ID_SECCION)
        If (Data_Area.Count > 0) Then
            Return Data_Area
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_SECCION As Integer, ByVal SEC_DESC As String) As String
        Dim NN_Area As New N_InCo_Sec
        Return NN_Area.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_SECCION, SEC_DESC)
    End Function
End Class