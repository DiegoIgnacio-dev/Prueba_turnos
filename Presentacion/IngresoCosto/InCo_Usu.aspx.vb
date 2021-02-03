Imports Entidades
Imports Negocio
Public Class InCo_Usu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Usu() As List(Of E_IRIS_WEBF_BUSCA_TECMED_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Usu As New N_IRIS_WEBF_BUSCA_TECMED_ACTIVO
        Dim Data_Usu As New List(Of E_IRIS_WEBF_BUSCA_TECMED_ACTIVO)

        Data_Usu = NN_Usu.IRIS_WEBF_BUSCA_TECMED_ACTIVO()
        If (Data_Usu.Count > 0) Then
            Return Data_Usu
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_TECMED(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_USUARIO As Integer) As List(Of E_InCo_TecMed)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Usu As New N_InCO_TecMed
        Dim Data_Usu As New List(Of E_InCo_TecMed)

        Data_Usu = NN_Usu.IRIS_WEBF_BUSCA_LIS_ADM_TECMED(DESDE, HASTA, ID_USUARIO)
        If (Data_Usu.Count > 0) Then
            Return Data_Usu
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_USUARIO As Integer, ByVal USU_NOM As String) As String
        Dim NN_Usu As New N_InCO_TecMed
        Return NN_Usu.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_USUARIO, USU_NOM)
    End Function
End Class