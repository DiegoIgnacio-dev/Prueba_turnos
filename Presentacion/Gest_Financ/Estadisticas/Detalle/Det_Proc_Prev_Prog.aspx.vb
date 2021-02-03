Imports Entidades
Imports Negocio
Public Class Det_Proc_Prev_Prog
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP = New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF(DOMAIN_URL, DESDE, HASTA, PROC, PREV, PROG)
        Return link
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2(DESDE, HASTA, PROC, PREV, PROG)
        If (Data_DTT.Count > 0) Then
            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer) As String
        Dim NN_Prev As New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Return NN_Prev.Gen_Excel(DOMAIN_URL, DESDE, HASTA, PROC, PREV, PROG)
    End Function
End Class