Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization

Public Class REP_LAB_EXA_2
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim objNnn As New N_Gen_Activos
        Dim objLst As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        objLst = objNnn.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV
        Return objLst
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String,
                                                                      ByVal DATE_str02 As String, ByVal PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date
        Dim NN_Exam As New N_REP_LAB_EXA
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        If (ID_CODIGO_FONASA = 0) Then
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2(Date_01, Date_02, PROCEDENCIA)
            If (Data_Prev.Count > 0) Then
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(Data_Prev, str_Builder)
                datos = str_Builder.ToString
            Else
                datos = "null"
            End If
        Else
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2(Date_01, Date_02, ID_CODIGO_FONASA, PROCEDENCIA)
            If (Data_Prev.Count > 0) Then
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(Data_Prev, str_Builder)
                datos = str_Builder.ToString
            Else
                datos = "null"
            End If
        End If
        Return datos
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CODIGO_FONASA As Long, ByVal PROCEDENCIA As Integer) As String
        Dim NN_Exam As New N_REP_LAB_EXA
        Return NN_Exam.Gen_Excel_2(DOMAIN_URL, DATE_str01, DATE_str02, ID_CODIGO_FONASA, PROCEDENCIA)
    End Function

    Private Sub REP_LAB_EXA_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies("P_ADMIN")
        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")

        End If

        If C_P_ADMIN.Value = "0" Or C_P_ADMIN.Value = "1" Or C_P_ADMIN.Value = "2" Or C_P_ADMIN.Value = "100" Or C_P_ADMIN.Value = "101" Or C_P_ADMIN.Value = "102" Or C_P_ADMIN.Value = "103" Or C_P_ADMIN.Value = "104" Then
        Else
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal PROCEDENCIA As Integer) As String
        'Declaraciones internas
        Dim NN_pdf As N_REP_LAB_EXA = New N_REP_LAB_EXA
        Dim link As String

        link = NN_pdf.PDFF_2(DOMAIN_URL, ID_CODIGO_FONASA, DATE_str01, DATE_str02, PROCEDENCIA)
        Return link
    End Function
End Class