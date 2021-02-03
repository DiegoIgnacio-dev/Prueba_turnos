Imports Entidades
Imports Negocio
Imports System.Threading.Tasks

Public Class Res_Filtrados
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function GET_list_Proc() As List(Of Gen_Select)
        'Declaraciones Internas
        Dim nnn As New N_Gen_Activos
        Dim obj_out As New List(Of Gen_Select)
        Dim obj_list As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        'Consultar por previsiones activas
        obj_list = nnn.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        For Each proc In obj_list
            Dim item As New Gen_Select

            item.text = proc.PROC_DESC
            item.value = proc.ID_PROCEDENCIA

            obj_out.Add(item)
        Next
        Return obj_out
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_List_Prev(ByVal ID_PROC As Long) As List(Of Gen_Select)
        'Declaraciones Internas
        Dim nnn As New N_Gen_Activos
        Dim obj_out As New List(Of Gen_Select)
        Dim obj_list As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        obj_list = nnn.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)
        For Each prev In obj_list
            Dim item As New Gen_Select

            item.text = prev.PREVE_DESC
            item.value = prev.ID_PREVE

            obj_out.Add(item)
        Next
        Return obj_out
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_List_Prog(ByVal ID_PREV As Long) As List(Of Gen_Select)
        Dim nnn As New N_Gen_Activos
        Dim obj_out As New List(Of Gen_Select)
        Dim obj_list As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)

        obj_list = nnn.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ID_PREV)
        For Each prog In obj_list
            Dim item As New Gen_Select

            item.text = prog.PROGRA_DESC
            item.value = prog.ID_PROGRA

            obj_out.Add(item)
        Next
        Return obj_out
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_List_SubP(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of Gen_Select)
        Dim nnn As New N_Gen_Activos
        Dim obj_out As New List(Of Gen_Select)
        Dim obj_list As New List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)

        'Consultar por previsiones activas
        obj_list = nnn.IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ID_PREV, ID_PROG)
        For Each subp In obj_list
            Dim item As New Gen_Select

            item.text = subp.SUBP_DESC
            item.value = subp.ID_SUBP

            obj_out.Add(item)
        Next
        Return obj_out
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_Data(ByVal DATE_01 As String, ByVal DATE_02 As String,
                                    ByVal ID_PROC As Integer, ByVal ID_PREV As Integer,
                                    ByVal ID_PROG As Integer, ByVal ID_SUBP As Integer,
                                    ByVal ALL_EXA As Boolean, ByVal ARRTEXT As String()) As List(Of E_Async_Res_All)

        Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim URL_Base As String = HttpContext.Current.Request.Url.Authority
        Dim xUser = HttpContext.Current.Request.Cookies("NICKNAME").Value
        Dim NN_Gen As New N_Res_Filtrados_New_Async(strLocal, URL_Base, N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV, ID_PROG, ID_SUBP, "", ARRTEXT, ALL_EXA, xUser)

        Dim LOG As New N_Log
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "dd-MM-yyyy - !") & xUser & ".txt"

        Try
            Dim xList As New List(Of E_Async_Res_All)
            xList = NN_Gen.Gen_Data()
            LOG.Write_Line("Datos enviados al Front End")
            LOG.Write_Separator()

            Return xList
        Catch ex As Exception
            LOG.Write_ERROR(ex)
            LOG.Write_Separator()
            Return Nothing
        End Try
    End Function

    <Services.WebMethod()>
    Public Shared Sub Request_Excel(ByVal DATE_01 As String, ByVal DATE_02 As String,
                                    ByVal ID_PROC As Integer, ByVal ID_PREV As Integer,
                                    ByVal ID_PROG As Integer, ByVal ID_SUBP As Integer,
                                    ByVal ALL_EXA As Boolean, ByVal EMAIL As String, ByVal ARRTEXT As String())

        Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim URL_Base As String = HttpContext.Current.Request.Url.Authority
        Dim xUser = HttpContext.Current.Request.Cookies("NICKNAME").Value
        Dim NN_Gen As New N_Res_Filtrados_New_Async(strLocal, URL_Base, N_Date.toDate(DATE_01), N_Date.toDate(DATE_02), ID_PROC, ID_PREV, ID_PROG, ID_SUBP, EMAIL, ARRTEXT, ALL_EXA, xUser)

        Dim LOG As New N_Log
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "dd-MM-yyyy - !") & xUser & ".txt"

        If ID_PREV = 126 Then
            Dim hilo_2 As Threading.Thread = New Threading.Thread(
                New Threading.ThreadStart(AddressOf NN_Gen.Gen_Excel_Pena)
                )
            hilo_2.Start()
        Else
            Dim Hilo As Threading.Thread = New Threading.Thread(
            New Threading.ThreadStart(AddressOf NN_Gen.Gen_Excel)
        )
            Hilo.Start()
        End If



    End Sub
End Class