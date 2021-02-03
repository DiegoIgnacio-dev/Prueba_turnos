Imports Entidades
Imports Negocio
Public Class InCo_TM
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            Return Data_LugarTM
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PROC As Integer) As List(Of E_InCo_TM)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_InCo_TM
        Dim Data_LugarTM As New List(Of E_InCo_TM)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM(DESDE, HASTA, ID_PROC)
        If (Data_LugarTM.Count > 0) Then
            Return Data_LugarTM
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PROC As Integer, ByVal PROC_DESC As String) As String
        Dim NN_Prev As New N_InCo_TM
        Return NN_Prev.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_PROC, PROC_DESC)
    End Function
End Class