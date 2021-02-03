Public Class Gerencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As HttpCookie = Request.Cookies.Get("ID_USER")

        If (IsNothing(ID_USER) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        If (ID_USER.Value <> 1 And ID_USER.Value <> 137) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

End Class