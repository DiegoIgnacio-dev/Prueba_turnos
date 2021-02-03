Imports Entidades
Imports Negocio
Public Class InCo_TP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_TP() As List(Of E_IRIS_WEBF_BUSCA_TP_PAGO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_TP As New N_IRIS_WEBF_BUSCA_TP_PAGO
        Dim Data_TP As New List(Of E_IRIS_WEBF_BUSCA_TP_PAGO)

        Data_TP = NN_TP.IRIS_WEBF_BUSCA_TP_PAGO()
        If (Data_TP.Count > 0) Then
            Return Data_TP
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_ADM_TP(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TP As Integer) As List(Of E_InCo_TP)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_TP As New N_InCo_TP
        Dim Data_TP As New List(Of E_InCo_TP)

        Data_TP = NN_TP.IRIS_WEBF_BUSCA_LIS_ADM_ORD(DESDE, HASTA, ID_TP)
        If (Data_TP.Count > 0) Then
            Return Data_TP
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TP As Integer, ByVal TP_DESC As String) As String
        Dim NN_TP As New N_InCo_TP
        Return NN_TP.Gen_Excel(DOMAIN_URL, DESDE, HASTA, ID_TP, TP_DESC)
    End Function
End Class