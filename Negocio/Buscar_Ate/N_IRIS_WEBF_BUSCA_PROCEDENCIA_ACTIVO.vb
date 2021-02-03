Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
    Private DD_Data As D_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
    End Sub
    Function IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~/Account/Login.aspx")
        End If

        Return DD_Data.D_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO(Galleta.Value)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(ByVal ID_PREV As Integer, ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~/Account/Login.aspx")
        End If

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(ID_PREV, ID_USER)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim Galleta2 As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~/Account/Login.aspx")
        End If

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE(Galleta.Value, Galleta2.Value)
    End Function
End Class
