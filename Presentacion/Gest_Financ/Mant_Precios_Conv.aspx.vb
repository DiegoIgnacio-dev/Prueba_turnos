Imports Negocio
Imports Entidades

Public Class Mant_Precios_Conv
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        If (C_P_ADMIN.Value <> 1) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

    <Services.WebMethod()>
    Public Shared Function Select_Year() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        Dim NN_Data As New N_Gen_Activos
        Dim objList As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)

        objList = NN_Data.IRIS_WEBF_BUSCA_AÑO_ACTIVO
        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function Select_Prev() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN_Data As New N_Gen_Activos
        Dim objList As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        objList = NN_Data.IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function Select_Data(ByVal ID_PREV As Long, ByVal ID_YEAR As Long, ByVal ALL_EXA As Boolean) As List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)
        Dim NN_Data As New N_Mant_Precios_Conv
        Dim objList As New List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)

        objList = NN_Data.IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA(ID_PREV, ID_YEAR, ALL_EXA)
        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Sub Write_Data(ByVal ID_CODF As Long, ByVal ID_PREC As Long, ByVal BIT_CONV As Boolean, ByVal LNG_PREC As Long, ByVal LNG_DERI As Long, ByVal LNG_CTOT As Long, ByVal DBL_PJEC As Single, ByVal DBL_PJEL As Single)
        Dim NN_Data As New N_Mant_Precios_Conv
        NN_Data.IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA(ID_CODF, ID_PREC, BIT_CONV, LNG_PREC, LNG_DERI, LNG_CTOT, DBL_PJEC, DBL_PJEL)

    End Sub

    <Services.WebMethod()>
    Public Shared Function Export(ByVal ID_PREV As Long, ByVal ID_YEAR As Long, ByVal ALL_EXA As Boolean) As String
        Dim NN_Data As New N_Mant_Precios_Conv
        Dim xURL As String = HttpContext.Current.Request.Url.Authority

        Return NN_Data.Export(xURL, ID_PREV, ID_YEAR, ALL_EXA)
    End Function

    <Services.WebMethod()>
    Public Shared Function Copy_Data(ByVal ID_PREV1 As Long, ByVal ID_YEAR1 As Long, ByVal ID_PREV2 As Long, ByVal ID_YEAR2 As Long, ByVal ALL As Boolean) As Boolean
        Dim NN_Data As New N_Mant_Precios_Conv

        Return NN_Data.Copy_Prices(ID_PREV1, ID_YEAR1, ID_PREV2, ID_YEAR2, ALL)
    End Function
End Class