﻿Imports Negocio
Imports Entidades
Public Class Login_PROVEE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    <Services.WebMethod()>
    Public Shared Function User_Login(ByVal xUser As String, xPass As String) As E_Login2
        Dim thisPage As HttpContext = HttpContext.Current
        Dim nLogin As New N_Login2
        Dim itemUser As New E_Login2

        itemUser = nLogin.IRIS_WEBF_00_ASPX_LOGIN_PROVEEDORES(xUser, xPass)

        If (itemUser.LOGGED = True) Then
            Dim objSession As HttpSessionState = HttpContext.Current.Session
            objSession("LOGGED") = itemUser.LOGGED
            objSession("ID_USER") = itemUser.ID_USER
            objSession("NICKNAME") = itemUser.NICKNAME
            objSession("NAME") = itemUser.NAME
            objSession("SURNAME") = itemUser.SURNAME
            objSession("P_ADMIN") = itemUser.P_ADMIN
            objSession("USU_ID_PROC") = itemUser.USU_ID_PROC
            objSession("USU_PREV") = itemUser.USU_PREV
            objSession.Timeout = 30
        End If

        Return itemUser
    End Function

    <Services.WebMethod()>
    Public Shared Function User_Logout() As Boolean
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        objSession.Clear()
        objSession.Abandon()

        Return True
    End Function
End Class