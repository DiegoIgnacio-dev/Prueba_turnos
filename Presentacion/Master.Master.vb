Imports System.Configuration

Public Class Master
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try

        '    Dim objSession As HttpSessionState = HttpContext.Current.Session

        '    'Obtener valor de Sesión
        '    Dim C_Logged As String = Convert.ToString(Request.Cookies.[Get]("LOGGED").Value)
        '    Dim S_Logged As Boolean = CType(objSession("LOGGED"), Boolean)

        '    Dim C_Id_User As String = Convert.ToString(Request.Cookies.[Get]("ID_USER").Value)
        '    Dim S_Id_User As String = CType(objSession("ID_USER"), String)

        '    'Debug.WriteLine(C_Id_User)
        '    'Debug.WriteLine(S_Id_User)

        '    'If (isLogged = False And C_Id_User <> S_Id_User) Then
        '    If ((S_Logged <> C_Logged) Or (C_Id_User <> S_Id_User)) Then
        '        Response.Redirect("~/Account/Login.aspx")
        '    Else
        '        objSession.Timeout = 30
        '    End If

        'Catch ex As Exception
        '    Response.Redirect("~/Account/Login.aspx")
        'End Try

        'Check_Test()
    End Sub

    Sub Check_Test()
        Dim strConn As String = ConfigurationManager.ConnectionStrings("CadenaConexion_IrisLab_Test").ToString
        Dim arrConn As String() = strConn.Split(";")
        Dim bolTEST As Boolean = True




    End Sub

End Class


