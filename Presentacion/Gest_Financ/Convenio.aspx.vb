﻿'Importar Capas
Imports Entidades
Imports Negocio
'Importar Librerías
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Convenio
    Inherits System.Web.UI.Page
    'Sub interno de la clase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
    <Services.WebMethod()>
    Public Shared Function JSON_Prev_Call() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones de la Consulta
        Dim NN_List As New N_Gen_Activos
        Dim DD_List As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Realizar Consulta
        DD_List = NN_List.IRIS_WEBF_BUSCA_PREVISION_ACTIVO

        Return DD_List
    End Function
    <Services.WebMethod()>
    Public Shared Function JSON_Data_Call(ByVal ID_PREV As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        'Declaraciones del editor de Fechas
        Dim NN_Date As New N_Date_Operat
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        'Declaraciones de la Consulta
        Dim NN_List As New N_Convenio
        Dim DD_List As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)

        'Realizar consulta
        DD_List = NN_List.IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ID_PREV, Date_01, Date_02)
        Return DD_List
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Xls(ByVal ID_PREV As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones de la Consulta
        Dim NN_List As New N_Convenio
        Dim DOMAIN_URL As String = HttpContext.Current.Request.Url.Authority
        Return NN_List.Gen_Xls(DOMAIN_URL, ID_PREV, DATE_str01, DATE_str02)
    End Function
End Class