Public Class Test_C
    Public Shared Sub Check_C()
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim OBJET_COOK As HttpCookieCollection = HttpContext.Current.Request.Cookies
        Dim bolExit As Boolean = False

        If ((IsNothing(objSession) = True) Or (IsNothing(OBJET_COOK) = True)) Then
            bolExit = True
        End If

        If (IsNothing(OBJET_COOK("ID_USER")) = True) Then
            bolExit = True
        ElseIf (IsNothing(OBJET_COOK("LOGGED")) = True) Then
            bolExit = True
        ElseIf (IsNothing(OBJET_COOK("NAME")) = True) Then
            bolExit = True
        ElseIf (IsNothing(OBJET_COOK("NICKNAME")) = True) Then
            bolExit = True
        ElseIf (IsNothing(OBJET_COOK("P_ADMIN")) = True) Then
            bolExit = True
        ElseIf (IsNothing(OBJET_COOK("SURNAME")) = True) Then
            bolExit = True
        ElseIf (IsNothing(OBJET_COOK("USU_ID_PROC")) = True) Then
            bolExit = True
        End If

        If (bolExit = True) Then
            HttpContext.Current.Response.Redirect("~Index.aspx", True)
        End If
    End Sub

    Public Shared ReadOnly Property emptyCookies() As Boolean
        Get
            Dim objSession As HttpSessionState = HttpContext.Current.Session
            Dim objCookies As HttpCookieCollection = HttpContext.Current.Request.Cookies
            Dim bolExit As Boolean = False

            If ((IsNothing(objSession) = True) Or (IsNothing(objCookies) = True)) Then
                bolExit = True
            End If

            If (IsNothing(objCookies("ID_USER")) = True) Then
                bolExit = True
            ElseIf (IsNothing(objCookies("LOGGED")) = True) Then
                bolExit = True
            ElseIf (IsNothing(objCookies("NAME")) = True) Then
                bolExit = True
            ElseIf (IsNothing(objCookies("NICKNAME")) = True) Then
                bolExit = True
            ElseIf (IsNothing(objCookies("P_ADMIN")) = True) Then
                bolExit = True
            ElseIf (IsNothing(objCookies("SURNAME")) = True) Then
                bolExit = True
            ElseIf (IsNothing(objCookies("USU_ID_PROC")) = True) Then
                bolExit = True
            End If

            Return bolExit
        End Get
    End Property
End Class
