﻿Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Ver_Det_Pend
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String,
                                          ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION)
        Data = NN.IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION(CDate(DESDE), CDate(HASTA), ID_CF)
        If (Data.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If


    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
                                          ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION)

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim Mx_Data(8, 0) As Object
        Data = NN.IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION(CDate(DESDE), CDate(HASTA), ID_CF)
        If (Data.Count > 0) Then

            Dim Mx_Datac(8, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(8, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(8, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(Data(y).ATE_NUM)
                Mx_Data(2, y) = Data(y).CF_DESC
                Mx_Data(3, y) = Data(y).PRU_DESC
                Mx_Data(4, y) = Data(y).TP_RESUL_COD
                If (Data(y).ATE_RESULTADO = Nothing) Then
                    Mx_Data(5, y) = ""
                Else
                    Mx_Data(5, y) = Data(y).ATE_RESULTADO
                End If
                Mx_Data(6, y) = Data(y).UM_DESC
                Mx_Data(7, y) = Format(Data(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(8, y) = Data(y).EST_DESCRIPCION
            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Determinaciones Pendientes")
        'titulo de la tabla
        sl.SetCellValue("B2", "Determinaciones Pendientes")

        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Exámen")
        sl.SetColumnWidth("C", 30)
        sl.SetCellValue("D8", "Determinación")
        sl.SetColumnWidth("D", 40)
        sl.SetCellValue("E8", "T")
        sl.SetColumnWidth("E", 10)
        sl.SetCellValue("F8", "Resultado")
        sl.SetCellValue("G8", "Unidad")
        sl.SetCellValue("H8", "Fecha")
        sl.SetCellValue("I8", "Estado")

        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 8
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True
        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("I" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 3, 100, 101, 102
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class