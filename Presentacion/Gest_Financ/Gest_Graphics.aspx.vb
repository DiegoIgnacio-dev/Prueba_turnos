Imports Negocio
Imports Entidades

Public Class Gest_Graphics
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function GET_Proc() As List(Of Gen_Select)
        Dim objRaw As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim objList As New List(Of Gen_Select)
        Dim objItem As New Gen_Select

        objRaw = (New N_Gen_Activos).IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV()

        'Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("P_ADMIN")
        'If (CInt(galleta.Value) = 1) Then
        objItem.text = "TODOS"
        objItem.value = 0
        objList.Add(objItem)
        'End If

        For Each item In objRaw
            objItem = New Gen_Select

            objItem.text = item.PROC_DESC
            objItem.value = item.ID_PROCEDENCIA
            objList.Add(objItem)
        Next

        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Prev(ByVal ID_PROC As Long) As List(Of Gen_Select)
        Dim objRaw As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim objList As New List(Of Gen_Select)
        Dim objItem As New Gen_Select

        objRaw = (New N_Gen_Activos).IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)

        'Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("P_ADMIN")
        'If (CInt(galleta.Value) = 1) Then
        objItem.text = "TODOS"
        objItem.value = 0
        objList.Add(objItem)
        'End If

        For Each item In objRaw
            objItem = New Gen_Select

            objItem.text = item.PREVE_DESC
            objItem.value = item.ID_PREVE
            objList.Add(objItem)
        Next

        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Cant_Ate_byProc(ByVal DATE_01 As String, ByVal DATE_02 As String, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC)
        Return (New N_Gest_Graphics).IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC(N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Cant_Ate_byPrev(ByVal DATE_01 As String, ByVal DATE_02 As String, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV)
        Return (New N_Gest_Graphics).IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV(N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Cant_Exa_byProc_byPrev(ByVal DATE_01 As String, ByVal DATE_02 As String, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION)
        Return (New N_Gest_Graphics).IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION(N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV)
    End Function
End Class