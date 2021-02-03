Imports Negocio
Imports Entidades
Public Class Impr_Etiq
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Get_Info(ByVal ATE_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO
        Dim List_Out As New E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO
        Dim NNN As New N_Impr_Etiq

        List_Out = NNN.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ATE_NUM)
        Return List_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Etiquetas(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        Dim List_Out As New List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        Dim NNN As New N_Impr_Etiq

        List_Out = NNN.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE(ATE_NUM)
        Return List_Out
    End Function
    <Services.WebMethod()>
    Public Shared Function Get_Excel(ByVal ATE_NUM As Long, ByVal ID_T_MUE As Integer()) As String
        Dim NNN As New N_Impr_Etiq
        Dim List_Etiq As New List(Of Integer)

        Return NNN.GET_EXCEL(ATE_NUM, List_Etiq)
    End Function
End Class