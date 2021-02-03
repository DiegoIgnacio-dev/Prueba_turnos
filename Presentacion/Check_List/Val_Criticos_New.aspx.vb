Imports Entidades
Imports Negocio

Public Class Val_Criticos_New
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function GET_Select_Proc() As List(Of Gen_Select)
        Dim galletas As HttpSessionState = HttpContext.Current.Session
        Dim objList As New List(Of Gen_Select)
        Dim objItem As Gen_Select
        Dim N As New N_Gen_Activos

        If (CInt(galletas.Item("ID_USER")) = 374) Then
            Dim rawList As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

            objItem = New Gen_Select
            objItem.text = "TODOS"
            objItem.value = 0
            objList.Add(objItem)

            rawList = N.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
            For Each item In rawList
                objItem = New Gen_Select
                objItem.text = item.PROC_DESC
                objItem.value = item.ID_PROCEDENCIA

                objList.Add(objItem)
            Next
        Else
            Dim rawList As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

            rawList = N.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(0)
            For Each item In rawList
                objItem = New Gen_Select
                objItem.text = item.PROC_DESC
                objItem.value = item.ID_PROCEDENCIA

                objList.Add(objItem)
            Next
        End If

        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Select_Prev(ByVal ID_PROC As Long) As List(Of Gen_Select)
        Dim galletas As HttpSessionState = HttpContext.Current.Session
        Dim objList As New List(Of Gen_Select)
        Dim objItem As Gen_Select
        Dim N As New N_Gen_Activos
        Dim rawList As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)


        If (CInt(galletas.Item("ID_USER")) = 374) Then
            rawList = N.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC, True)

            objItem = New Gen_Select
            objItem.text = "TODOS"
            objItem.value = 0
            objList.Add(objItem)
        Else
            rawList = N.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)
        End If

        For Each item In rawList
            objItem = New Gen_Select
            objItem.text = item.PREVE_DESC
            objItem.value = item.ID_PREVE

            objList.Add(objItem)
        Next

        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Select_CodF() As List(Of Gen_Select)
        Dim galletas As HttpSessionState = HttpContext.Current.Session
        Dim objList As New List(Of Gen_Select)
        Dim objItem As Gen_Select
        Dim N As New N_Gen_Activos

        Dim rawList As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        objItem = New Gen_Select
        objItem.text = "TODOS"
        objItem.value = 0
        objList.Add(objItem)

        rawList = N.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        For Each item In rawList
            objItem = New Gen_Select
            objItem.text = item.CF_DESC
            objItem.value = item.ID_CODIGO_FONASA

            objList.Add(objItem)
        Next

        Return objList
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Data(ByVal DATE_01 As String, ByVal DATE_02 As String,
                                    ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                    ByVal ID_CODF As Long, ByVal ID_CRIT As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT)
        Return (New N_Val_Criticos_New).IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT(N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV, ID_CODF, ID_CRIT)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Excel_Url(ByVal DATE_01 As String, ByVal DATE_02 As String,
                                         ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                         ByVal ID_CODF As Long, ByVal ID_CRIT As Long, ARR_STR As String()) As String
        Return (New N_Val_Criticos_New).Create_Excel(N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV, ID_CODF, ID_CRIT, ARR_STR)
    End Function
End Class

Public Class Gen_Select
    Private E_value As Long
    Public Property value() As Long
        Get
            Return E_value
        End Get
        Set(ByVal value As Long)
            E_value = value
        End Set
    End Property

    Private E_text As String
    Public Property text() As String
        Get
            Return E_text
        End Get
        Set(ByVal value As String)
            E_text = value
        End Set
    End Property
End Class