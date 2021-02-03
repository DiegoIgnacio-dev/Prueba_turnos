Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web
Public Class N_Prevision_Sum
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Prev As D_Prevision_Sum
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Prev = New D_Prevision_Sum
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(ByVal ID_PRE As Long, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Return DD_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(ID_PRE, Date_01, Date_02)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_PREVISION_GER(ByVal ID_PRE As Long, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Return DD_Prev.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_PREVISION_GER(ID_PRE, Date_01, Date_02)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_PREVISION_VALIDADOS(ByVal ID_PRE As Long, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Return DD_Prev.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_PREVISION_VALIDADOS(ID_PRE, Date_01, Date_02)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal PREVE As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_Prev As New N_Prevision_Sum
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim Previs As Long = PREVE
        'Realizar Consulta
        Data_Prev = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(Previs, DATE1, DATE2)
        If (Data_Prev.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(6, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(6, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(1, y) = Data_Prev(y).TOTAL_ATE
            Mx_Data(2, y) = Data_Prev(y).TOT_FONASA
            Mx_Data(3, y) = Data_Prev(y).TOTA_SIS
            Mx_Data(4, y) = Data_Prev(y).TOTA_USU
            Mx_Data(5, y) = Data_Prev(y).TOTA_COPA
            Mx_Data(6, y) = CInt(Data_Prev(y).TOTA_USU + Data_Prev(y).TOTA_COPA)
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim formatonum As SLStyle
        Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Detalle Previsión")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Previsión")
        If (PREVE = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev(0).PREVE_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE1 & " Hasta: " & DATE2)
        'nombre columnas
        sl.SetCellValue("A7", "Previsión")
        sl.SetCellValue("B7", "Cant. Atenciones")
        sl.SetCellValue("C7", "Cant. Exámenes")
        sl.SetCellValue("D7", "Total Sistema")
        sl.SetCellValue("E7", "Total Usuarios")
        sl.SetCellValue("F7", "Total Copago")
        sl.SetCellValue("G7", "Total Pagado")
        For y = 1 To 7
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7

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

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("G")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("B") To Asc("G")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("G")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("G" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (PREVE = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Prev(0).PREVE_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function



    Function Gen_Excel2(ByVal MAIN_URL As String, ByVal PREVE As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim Data_Prev As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        Data_Prev = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX_EStadi(DATE1, DATE2, PREVE)
        Dim Mx_Data(5, 0) As Object
        'Obtener parámetros para la consulta
        Dim Previs As Long = PREVE
        'Realizar Consulta
        If (Data_Prev.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(5, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(5, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).PROC_DESC
            Mx_Data(1, y) = Data_Prev(y).TOTAL_AGEND_CUPO_NORMAL
            Mx_Data(2, y) = Data_Prev(y).TOTAL_AGEND_PRIORITARIO
            Mx_Data(3, y) = Data_Prev(y).TOTAL_AGEND_ESPONTANEO
            Mx_Data(4, y) = Data_Prev(y).TOTAL_AGEND_PAP
            Mx_Data(5, y) = Data_Prev(y).TOTAL_AGEND_PAP + Data_Prev(y).TOTAL_AGEND_ESPONTANEO + Data_Prev(y).TOTAL_AGEND_PRIORITARIO + Data_Prev(y).TOTAL_AGEND_CUPO_NORMAL
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim formatonum As SLStyle
        Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Total de Agendados por Cupo")
        'titulo de la tabla
        sl.SetCellValue("B2", "Total de Agendados por Cupo")
        If (PREVE = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev(0).PROC_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE1 & " Hasta: " & DATE2)
        'nombre columnas
        sl.SetCellValue("A7", "Procedencia")
        sl.SetCellValue("B7", "Cant. Cupo Normal")
        sl.SetCellValue("C7", "Cant. Cupo Prioritario")
        sl.SetCellValue("D7", "Cant. Cupo Espontáneo")
        sl.SetCellValue("E7", "Cant. Cupo PAP")
        sl.SetCellValue("F7", "Total")
        For y = 1 To 7
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7

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

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("F")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("B") To Asc("F")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("F")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("F" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (PREVE = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Prev(0).PROC_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
    <Services.WebMethod()>
    Function Excel_Ger(ByVal DOMAIN_URL As String, ByVal ID_PREV As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas

        Dim NN_Date As New N_Date
        Dim NN_Prev As New N_Prevision_Sum
        Dim data_det_ate As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        data_det_ate = NN_Prev.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_PREVISION_GER(ID_PREV, DATE_str01, DATE_str02)

        Dim NN_Date_2 As New N_Date
        Dim NN_Prev_2 As New N_Prevision_Sum
        Dim Data_Prev_2 As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Data_Prev_2 = NN_Prev_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(ID_PREV, DATE_str01, DATE_str02)

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
        Dim edad As Integer = 0
        Dim idate As String = ""


        Dim Mx_Data(8, 0) As Object

        If (data_det_ate.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Crear nuevo Dcto
        Dim xls As New SLDocument
        Dim RowH As Integer = 30

        'Definir estilos
        Dim css_Title = xls.CreateStyle
        css_Title.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_Title.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_Title.Font.Bold = True
        css_Title.Font.FontSize = 20

        Dim css_SubTitle = xls.CreateStyle
        css_SubTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_SubTitle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_SubTitle.Font.Bold = True
        css_SubTitle.Font.FontSize = 16

        Dim css_THead = xls.CreateStyle
        css_THead.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_THead.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_THead.Font.Bold = True
        css_THead.Font.FontSize = 12
        'css_THead.Font.FontColor = System.Drawing.Color.White
        css_THead.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.White, System.Drawing.Color.Orange)

        Dim css_TCell_left = xls.CreateStyle
        css_TCell_left.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_TCell_left.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_left.Font.Bold = False
        css_TCell_left.Font.FontSize = 10

        Dim css_TCell_center = xls.CreateStyle
        css_TCell_center.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center.Font.Bold = False
        css_TCell_center.Font.FontSize = 10

        Dim css_TCell_right = xls.CreateStyle
        css_TCell_right.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_right.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_right.Font.Bold = False
        css_TCell_right.Font.FontSize = 10

        Dim css_TCell_Date = xls.CreateStyle
        css_TCell_Date.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_Date.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Date.Font.Bold = False
        css_TCell_Date.Font.FontSize = 10
        css_TCell_Date.FormatCode = "dd/mm/yyyy"

        Dim css_TCell_Number = xls.CreateStyle
        css_TCell_Number.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Number.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Number.Font.Bold = False
        css_TCell_Number.Font.FontSize = 10
        css_TCell_Number.FormatCode = "###,###,##0"

        Dim css_TCell_Money = xls.CreateStyle
        css_TCell_Money.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Money.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Money.Font.Bold = False
        css_TCell_Money.Font.FontSize = 10
        css_TCell_Money.FormatCode = "$ ###,###,##0"

        Dim css_TCell_Percentage = xls.CreateStyle
        css_TCell_Percentage.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Percentage.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Percentage.Font.Bold = False
        css_TCell_Percentage.Font.FontSize = 10
        css_TCell_Percentage.FormatCode = "#,##0.00 %"



        'Colocar Título
        xls.SetCellValue(1, 1, "Resumen Previsión-Procedencia")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        If ID_PREV = 0 Then
            xls.SetCellValue(2, 1, "Previsión: " & "Todas")
            xls.SetCellStyle(2, 1, css_SubTitle)
            xls.MergeWorksheetCells(2, 1, 2, 3)
        Else
            xls.SetCellValue(2, 1, "Previsión: " & data_det_ate(0).PREVE_DESC)
            xls.SetCellStyle(2, 1, css_SubTitle)
            xls.MergeWorksheetCells(2, 1, 2, 3)
        End If


        'xls.SetCellValue(3, 1, "Hasta: " & HASTA)
        'xls.SetCellStyle(3, 1, css_SubTitle)
        'xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 1
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetColumnWidth(1, RowH - 15)
        xls.SetColumnWidth(2, RowH + 00)
        xls.SetColumnWidth(3, RowH + 15)
        xls.SetColumnWidth(4, RowH - 10)
        xls.SetColumnWidth(5, RowH - 10)
        xls.SetColumnWidth(6, RowH - 10)
        xls.SetColumnWidth(7, RowH - 10)
        xls.SetColumnWidth(8, RowH - 10)
        xls.SetColumnWidth(9, RowH - 10)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Previsión") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Procedencia") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. Atenciones") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. Exámenes") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Sistema") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Usuarios") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Copago") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Pagado") : x2 = x1

        For Each List_Data As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION In data_det_ate
            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PREVE_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PROC_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.TOTAL_ATE) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.TOT_FONASA) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_SIS) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_USU) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_COPA) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_COPA + List_Data.TOTA_USU) : x2 = x1

            xi += 1

            indice_if += 1


        Next

        x2 = x1
        y2 += 2
        Dim contadorin = 1
        Dim super_sumador = 0

        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Previsión") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. Atenciones") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. Exámenes") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Sistema") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Usuarios") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Copago") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Pagado") : x2 = x1


        For Each List_Data As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION In Data_Prev_2
            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PREVE_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.TOTAL_ATE) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.TOT_FONASA) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_SIS) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_USU) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_COPA) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
            xls.SetCellValue(y2, x2, List_Data.TOTA_COPA + List_Data.TOTA_USU) : x2 = x1

            xi += 1

            indice_if += 1

        Next



        Dim T_Ate As Integer = 0
        Dim T_Exa As Integer = 0
        Dim T_Sis As Integer = 0
        Dim T_Usu As Integer = 0
        Dim T_Cop As Integer = 0
        Dim T_Pag As Integer = 0

        x2 = x1
        y2 += 2

        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. Atenciones") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. Exámenes") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Sistema") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Usuarios") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Copago") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total Pagado") : x2 = x1


        For Each List_Data_2 As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION In Data_Prev_2
            T_Ate += List_Data_2.TOTAL_ATE
            T_Exa += List_Data_2.TOT_FONASA
            T_Sis += List_Data_2.TOTA_SIS
            T_Usu += List_Data_2.TOTA_USU
            T_Cop += List_Data_2.TOTA_COPA
            T_Pag += List_Data_2.TOTA_COPA + List_Data_2.TOTA_USU
        Next

        x2 = x1
            y2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_right)
            xls.SetCellValue(y2, x2, T_Ate) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_right)
            xls.SetCellValue(y2, x2, T_Exa) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Money)
        xls.SetCellValue(y2, x2, T_Sis) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Money)
        xls.SetCellValue(y2, x2, T_Usu) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Money)
        xls.SetCellValue(y2, x2, T_Cop) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Money)
        xls.SetCellValue(y2, x2, T_Pag) : x2 = x1


            'x2 = x1
            'y2 += 1

            'xls.SetCellStyle(y2, x2, css_THead)
            'xls.SetCellValue(y2, x2, "TOTAL") : x2 += 1
            'xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
            'xls.SetCellStyle(y2, x2, css_THead)
            'xls.SetCellValue(y2, x2, super_sumador) : x2 = x1


            'Crear Ruta de Guardado
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Resumen_Preve_Proce" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class
