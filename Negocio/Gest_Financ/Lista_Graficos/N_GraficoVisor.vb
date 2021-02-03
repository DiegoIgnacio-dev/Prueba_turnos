Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_GraficoVisor
    'Declaraciones Generales
    Dim DD_Data As D_GraficoAte
    Dim DD_Data_Exa As D_GraficoExa
    Dim DD_Data_Sitema As D_GraficoT_Sistema
    Dim DD_Data_PAC As D_GraficoPAC
    Dim DD_Data_Copa As D_GraficoCopago
    Dim DD_Data_HoraATE As D_GraficoHORA_ATE
    Dim DD_Data_HoraEXA As D_GraficoHORA_EXA
    Sub New()
        DD_Data = New D_GraficoAte
        DD_Data_Exa = New D_GraficoExa
        DD_Data_Sitema = New D_GraficoT_Sistema
        DD_Data_PAC = New D_GraficoPAC
        DD_Data_Copa = New D_GraficoCopago
        DD_Data_HoraATE = New D_GraficoHORA_ATE
        DD_Data_HoraEXA = New D_GraficoHORA_EXA
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS_EXA(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS_EXA(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_SISTEMA(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Sitema.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_SISTEMA(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_PACIENTE(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_PAC.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_PACIENTE(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_COPAGO(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Copa.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_COPAGO(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES(ByVal DESDE As Date, ByVal HASTA As Date) As Long
        Return DD_Data_HoraATE.IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal cookie_proc As Integer) As Long
        Return DD_Data_HoraATE.IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS(DESDE, HASTA, cookie_proc)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS_AYER_AYER_SEMANA_PASADA(ByVal DESDE As Date, ByVal HASTA As Date, ByVal DESDE_SEMANA_PASADA As Date, ByVal HASTA_SEMANA_PASADA As Date, ByVal cookie_proc As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_HoraATE.IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS_AYER_AYER_SEMANA_PASADA(DESDE, HASTA, DESDE_SEMANA_PASADA, HASTA_SEMANA_PASADA, cookie_proc)
    End Function
    Function IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES(ByVal DESDE As Date, ByVal HASTA As Date) As Long
        Return DD_Data_HoraEXA.IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2_INDEX(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2_INDEX(DESDE, HASTA, ID_CF)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_2_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_2_2(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_ESTE_MES_VS_MISMO_DIA_MES_ANTERIOR(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_ESTE_MES_VS_MISMO_DIA_MES_ANTERIOR(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_DINEROS_MINDS(ByVal DESDE As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_DINEROS_MINDS(DESDE, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS_DINEROS_PREVE_GRAPH(ByVal DESDE As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS_DINEROS_PREVE_GRAPH(DESDE, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS_DINEROS_PREVE_GRAPH_INFO_MULTIPLE(ByVal ayer As Date,
                                                                                                           ByVal ayer_semana_pasada As Date,
                                                                                                           ByVal mes_dia As Date,
                                                                                                           ByVal mes_dia_pasado As Date,
                                                                                                           ByVal mes As Date,
                                                                                                           ByVal mes_pasado As Date,
                                                                                                           ByVal cookie_proc As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS_DINEROS_PREVE_GRAPH_INFO_MULTIPLE(ayer, ayer_semana_pasada, mes_dia, mes_dia_pasado, mes, mes_pasado, cookie_proc)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_MINDS_MONEY(ByVal DESDE As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_MINDS_MONEY(DESDE, ID_PROC)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_MEDICO_MINDS_MONEY(ByVal DESDE As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO)
        Return DD_Data_Exa.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_MEDICO_MINDS_MONEY(DESDE, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2(DESDE, HASTA, ID_CF)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_VENTAS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_VENTAS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_VENTAS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_VENTAS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS_VENTAS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS_VENTAS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_MONTOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_MONTOS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_MONTOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_MONTOS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Return DD_Data_Exa.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS(DESDE, HASTA, ID_CF, ID_PROC)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String) As String
        'Declaraciones Generales
        Dim Mx_Data(2, 0) As Object
        Dim NN_Date As New N_Date
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
            Dim Item As New E_GraficoVisor_Json
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS(Date_01, Date_01)
            If (Format(Date_01, "dddd") = "domingo") Then
            Else
                Item.E_Fecha = Date_01
                Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                Item.E_Dias = Format(Date_01, "dddd")
                date_json_rial.Add(Item)
            End If
        Next dd
        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Cantidad
            Mx_Data(2, y) = date_json_rial(y).E_Dias
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
        sl.RenameWorksheet("Sheet1", "Visor de Cantidades Atenciones Mensuales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Cantidades Atenciones Mensuales")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"))
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Cantidad De Atenciones")
        sl.SetCellValue("C7", "Dias")

        For y = 1 To 3
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("B" & ltabla + 1), CStr("=SUM(" & "B" & "8:" & "B" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i
        sl.SetCellValue(CStr("B" & ltabla + 2), CStr("=AVERAGE(" & "B" & "8:" & "B" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelExa(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String) As String
        'Declaraciones Generales
        Dim Mx_Data(2, 0) As Object
        Dim NN_Date As New N_Date
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
            Dim Item As New E_GraficoVisor_Json
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS_EXA(Date_01, Date_01)
            If (Format(Date_01, "dddd") = "domingo") Then
            Else
                Item.E_Fecha = Date_01
                Item.E_Cantidad = Data_Med(0).TOTAL_EXA
                Item.E_Dias = Format(Date_01, "dddd")
                date_json_rial.Add(Item)
            End If


        Next dd

        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Cantidad
            Mx_Data(2, y) = date_json_rial(y).E_Dias
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
        sl.RenameWorksheet("Sheet1", "Visor de Cantidades de Exámenes Mensuales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Cantidades de Exámenes Mensuales")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"))
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Cantidad De Exámenes")
        sl.SetCellValue("C7", "Dias")

        For y = 1 To 3
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("B" & ltabla + 1), CStr("=SUM(" & "B" & "8:" & "B" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i
        sl.SetCellValue(CStr("B" & ltabla + 2), CStr("=AVERAGE(" & "B" & "8:" & "B" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelSistema(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String) As String
        'Declaraciones Generales
        Dim Mx_Data(2, 0) As Object
        Dim NN_Date As New N_Date
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
            Dim Item As New E_GraficoVisor_Json
            If (Format(Date_01, "dddd") = "domingo") Then
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_SISTEMA(Date_01, Date_01)
                Item.E_Fecha = Date_01
                Item.E_Cantidad = Data_Med(0).TOTA_SIS
                Item.E_Dias = Format(Date_01, "dddd")
                date_json_rial.Add(Item)
            End If
        Next dd
        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Cantidad
            Mx_Data(2, y) = date_json_rial(y).E_Dias
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
        sl.RenameWorksheet("Sheet1", "Visor de Totales Sistema Mensuales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Totales Sistema Mensuales)")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"))
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Total Sistema")
        sl.SetCellValue("C7", "Dias")

        For y = 1 To 3
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("B" & ltabla + 1), CStr("=SUM(" & "B" & "8:" & "B" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i
        sl.SetCellValue(CStr("B" & ltabla + 2), CStr("=AVERAGE(" & "B" & "8:" & "B" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelPAC(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String) As String
        'Declaraciones Generales
        Dim Mx_Data(2, 0) As Object
        Dim NN_Date As New N_Date
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
            Dim Item As New E_GraficoVisor_Json
            If (Format(Date_01, "dddd") = "domingo") Then
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_PACIENTE(Date_01, Date_01)
                Item.E_Fecha = Date_01
                Item.E_Cantidad = Data_Med(0).TOTA_USU
                Item.E_Dias = Format(Date_01, "dddd")
                date_json_rial.Add(Item)
            End If
        Next dd
        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Cantidad
            Mx_Data(2, y) = date_json_rial(y).E_Dias
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
        sl.RenameWorksheet("Sheet1", "Visor de Totales Paciente Mensual")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Totales Paciente Mensual")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"))
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Total Paciente")
        sl.SetCellValue("C7", "Dias")

        For y = 1 To 3
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("B" & ltabla + 1), CStr("=SUM(" & "B" & "8:" & "B" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i
        sl.SetCellValue(CStr("B" & ltabla + 2), CStr("=AVERAGE(" & "B" & "8:" & "B" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelCopa(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String) As String
        'Declaraciones Generales
        Dim Mx_Data(2, 0) As Object
        Dim NN_Date As New N_Date
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)

        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
            Dim Item As New E_GraficoVisor_Json
            If (Format(Date_01, "dddd") = "domingo") Then
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_TOTAL_COPAGO(Date_01, Date_01)
                Item.E_Fecha = Date_01
                Item.E_Cantidad = Data_Med(0).TOTA_COPA
                Item.E_Dias = Format(Date_01, "dddd")
                date_json_rial.Add(Item)
            End If
        Next dd
        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Cantidad
            Mx_Data(2, y) = date_json_rial(y).E_Dias
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
        sl.RenameWorksheet("Sheet1", "Visor de Totales Copago Mensual")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Totales Copago Mensual")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"))
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Total Sistema")
        sl.SetCellValue("C7", "Dias")

        For y = 1 To 3
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("B" & ltabla + 1), CStr("=SUM(" & "B" & "8:" & "B" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i
        sl.SetCellValue(CStr("B" & ltabla + 2), CStr("=AVERAGE(" & "B" & "8:" & "B" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelHoraEXA(ByVal MAIN_URL As String, ByVal str_Date As String) As String
        'Declaraciones internas
        Dim NN_Date As New N_Date
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES)
        str_Date = str_Date.Replace("-", "/")
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")
        For h = 0 To 23
            Dim dRef() As String = str_Date.Split("/")
            Dim Date_Out As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES(Date_Out, Date_Out)
            Debug.WriteLine("Fecha: " & Format(Date_Out, "dd/MM/yyyy HH:mm:ss"))
            Debug.WriteLine("Valor: " & Format(Value, "###,###,##0.##"))
            Debug.WriteLine("")
            Dim E_Item As New E_IRIS_WEBF_BUSCA_HORA_CONTEO_EXAMENES
            E_Item.FECHA = Date_Out
            E_Item.NUMERO = Value
            Data_Out.Add(E_Item)
        Next h
        Dim Mx_Data(1, 0) As Object

        ''Realizar Consulta
        'Data_Lis_Ate = NN_Lis_Ate.IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES(ID_PRE, Date01, Date02)
        'If (Data_Lis_Ate.Count = 0) Then
        '    Return "null"
        '    Exit Function
        'End If
        'Vaciar Matriz
        ReDim Mx_Data(1, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Out.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(1, y)
            End If
            Mx_Data(0, y) = Format(Data_Out(y).FECHA, "HH:mm")
            Mx_Data(1, y) = Data_Out(y).NUMERO
            'Mx_Data(2, y) = Data_Lis_Ate(y).ATE_AÑO & " años"
            'Mx_Data(3, y) = Format(Data_Lis_Ate(y).ATE_FECHA, "dd/MM/yyy")
            'Mx_Data(4, y) = Format(Data_Lis_Ate(y).ATE_FECHA, "HH:mm:ss")
            'Mx_Data(5, y) = Data_Lis_Ate(y).PROC_DESC
            'Mx_Data(6, y) = Data_Lis_Ate(y).SEXO_DESC
            'Mx_Data(7, y) = CInt(Data_Lis_Ate(y).ATE_TOTAL)
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
        sl.RenameWorksheet("Sheet1", "Atenciones Totales (Listado)")
        ''titulo de la tabla
        sl.SetCellValue("B2", "Atenciones Totales Por Horas ")
        sl.SetCellValue("B3", "Fecha: " & str_Date)
        'If (Dll = "0") Then
        '    sl.SetCellValue("B3", "Tipo de Pago: Todas")
        'Else
        '    sl.SetCellValue("B3", "Tipo de Pago: " & TP_Desc)
        'End If
        'nombre columnas
        sl.SetCellValue("A7", "Hora")
        sl.SetCellValue("B7", "N° de Atenciones")

        For y = 1 To 2
            sl.SetColumnWidth(y, 20.0)
        Next y
        sl.SetColumnWidth(2, 35.0) 'Ancho para la columna de Nombre
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
            For i = Asc("B") To Asc("B")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("B") To Asc("B")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("C")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("B" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Todos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        'If (Dll = 0) Then
        '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        '    Dim Relative_Path As String = "IRISPDFDERIVADOS\Todos" & "hola" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        '    'Devolver la url del archivo generado
        '    Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        'Else
        '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        '    Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "hola" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        '    'Devolver la url del archivo generado
        '    Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        'End If
    End Function
    Function Gen_Excel_HORA_ATE(ByVal DOMAIN_URL As String, ByVal str_Date As String) As String
        'Declaraciones internas
        Dim NN_Date As New N_Date
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES)
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")
        For h = 0 To 23
            Dim dRef() As String = str_Date.Split("-")
            Dim Date_REEEE As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES(Date_REEEE, Date_REEEE)
            Debug.WriteLine("Fecha: " & Format(Date_REEEE, "dd/MM/yyyy HH:mm:ss"))
            Debug.WriteLine("Valor: " & Format(Value, "###,###,##0.##"))
            Debug.WriteLine("")
            Dim E_Item As New E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES
            E_Item.FECHA = Date_REEEE
            E_Item.NUMERO = Value
            Data_Out.Add(E_Item)
        Next h
        'Vaciar Matriz
        Dim Mx_Data(1, 0) As Object
        ReDim Mx_Data(1, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Out.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Data_Out(y).FECHA
            Mx_Data(1, y) = Data_Out(y).NUMERO
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 4
        Dim tablePosCol As Integer = 1
        'Colocar Título
        Dim Date_Out As Date = NN_Date.strToDate(str_Date.Split("-")(2), str_Date.Split("-")(1), str_Date.Split("-")(0))
        Xls.SetCellValue(1, 1, "Atenciones Totales por Hora")
        Xls.SetCellValue(2, 1, "Fecha: " & Format(Date_Out, "dd/MM/yyyy"))
        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Atenciones Por Hora - " & Format(Date_Out, "dd/MM/yyyy"))
        Dim tablePosCol_now As Integer = tablePosCol
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Hora") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Total Ate")
        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14
        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x
        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20)
        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1
            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
            Next x
            'Formato de celdas
            Dim style = Xls.CreateStyle()
            'style.FormatCode = "dd/mm/yyyy h:mm:ss"
            style.FormatCode = "hh:mm"
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol, style)
            'style.FormatCode = "$ ###,###,##0"
            style.FormatCode = "###,###,##0"
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now, style)
        Next y
        'Definir Estilos de "Totales"
        tablePosRow_now += 1
        Dim style_total = Xls.CreateStyle()
        style_total.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        style_total.Font.Bold = True
        style_total.Font.FontSize = 16
        Xls.SetCellStyle(tablePosRow_now, tablePosCol, style_total)
        style_total.Font.Bold = False
        'style_total.FormatCode = "$ ###,###,##0"
        style_total.FormatCode = "###,###,##0"
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now, style_total)
        'Insertar totales
        Dim nChar As Integer = Asc("A") - 1
        Xls.SetCellValue(tablePosRow_now, tablePosCol, "Total:")
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now, "=SUM(" & (Chr(nChar + tablePosCol_now) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now) & tablePosRow_now - 1) & ")")
        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)
        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Hora_Ate_Total" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelAteProvee(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer) As String
        'Declaraciones Generales
        Dim Mx_Data(3, 0) As Object
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        If VALOR = 0 Then
            For dd = 1 To days
                Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                Dim Item As New E_GraficoVisor_Json
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2(Date_01, Date_01, ID_CF)
                If (Format(Date_01, "dddd") = "domingo") Then
                Else
                    If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                        'Item.E_Fecha = Date_01
                        'Item.E_Cantidad = 0
                        'Item.CANT_EXA = 0
                        'Item.E_Dias = Format(Date_01, "dddd")
                        'date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        date_json_rial.Add(Item)
                    End If
                End If


            Next dd
        Else
            For dd = 1 To days
                Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                Dim Item As New E_GraficoVisor_Json
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2(Date_01, Date_01, ID_CF)

                If Data_Med.Count = 0 Then
                    Item.E_Fecha = Date_01
                    Item.E_Cantidad = 0
                    Item.CANT_EXA = 0
                    Item.E_Dias = Format(Date_01, "dddd")
                    date_json_rial.Add(Item)
                Else
                    Item.E_Fecha = Date_01
                    Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                    Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                    Item.E_Dias = Format(Date_01, "dddd")
                    date_json_rial.Add(Item)
                End If



            Next dd
        End If

        Dim CF_DESCCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESCCCCCCCC = "Todos"
        Else
            CF_DESCCCCCCCC = CF_DESC
        End If

        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(3, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Dias
            Mx_Data(2, y) = date_json_rial(y).E_Cantidad
            Mx_Data(3, y) = date_json_rial(y).CANT_EXA

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
        sl.RenameWorksheet("Sheet1", "Visor de Cantidades de Atenciones Mensuales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Cantidades de Atenciones Mensuales")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & " Examen: " & CF_DESCCCCCCCC)
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Dias")
        sl.SetCellValue("C7", "Cantidad De Atenciones")
        sl.SetCellValue("D7", "Cantidad De Exámenes")


        For y = 1 To 4
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("C" & ltabla + 1), CStr("=SUM(" & "C" & "8:" & "C" & ltabla & ")"))
        sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(" & "D" & "8:" & "D" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i

        sl.SetCellValue(CStr("C" & ltabla + 2), CStr("=AVERAGE(" & "C" & "8:" & "C" & ltabla & ")"))
        sl.SetCellValue(CStr("D" & ltabla + 2), CStr("=AVERAGE(" & "D" & "8:" & "D" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("D" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelAteProvee_Minds(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String
        'Declaraciones Generales
        Dim Mx_Data(4, 0) As Object
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        If (VALOR_2 = 0) Then
            If VALOR = 0 Then
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_VENTAS(Date_01, Date_01, ID_CF, cookie_proc)
                    If (Format(Date_01, "dddd") = "domingo") Then
                    Else
                        If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                            'Item.E_Fecha = Date_01
                            'Item.E_Cantidad = 0
                            'Item.CANT_EXA = 0
                            'Item.E_Dias = Format(Date_01, "dddd")
                            'date_json_rial.Add(Item)
                        Else
                            Item.E_Fecha = Date_01
                            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                            Item.E_Dias = Format(Date_01, "dddd")
                            Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                            date_json_rial.Add(Item)
                        End If
                    End If


                Next dd
            Else
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_VENTAS(Date_01, Date_01, ID_CF, cookie_proc)

                    If Data_Med.Count = 0 Then
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = 0
                        Item.CANT_EXA = 0
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.TOTA_SIS = 0
                        date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                        date_json_rial.Add(Item)
                    End If



                Next dd
            End If

        ElseIf VALOR_2 = 1 Then

            If VALOR = 0 Then
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_VENTAS(Date_01, Date_01, ID_CF, cookie_proc)
                    If (Format(Date_01, "dddd") = "domingo") Then
                    Else
                        If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                            'Item.E_Fecha = Date_01
                            'Item.E_Cantidad = 0
                            'Item.CANT_EXA = 0
                            'Item.E_Dias = Format(Date_01, "dddd")
                            'date_json_rial.Add(Item)
                        Else
                            Item.E_Fecha = Date_01
                            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                            Item.E_Dias = Format(Date_01, "dddd")
                            Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                            date_json_rial.Add(Item)
                        End If
                    End If


                Next dd
            Else
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_VENTAS(Date_01, Date_01, ID_CF, cookie_proc)

                    If Data_Med.Count = 0 Then
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = 0
                        Item.CANT_EXA = 0
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.TOTA_SIS = 0
                        date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                        date_json_rial.Add(Item)
                    End If



                Next dd
            End If
        ElseIf VALOR_2 = 2 Then

            If VALOR = 0 Then
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS_VENTAS(Date_01, Date_01, ID_CF, cookie_proc)
                    If (Format(Date_01, "dddd") = "domingo") Then
                    Else
                        If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                            'Item.E_Fecha = Date_01
                            'Item.E_Cantidad = 0
                            'Item.CANT_EXA = 0
                            'Item.E_Dias = Format(Date_01, "dddd")
                            'date_json_rial.Add(Item)
                        Else
                            Item.E_Fecha = Date_01
                            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                            Item.E_Dias = Format(Date_01, "dddd")
                            Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                            date_json_rial.Add(Item)
                        End If
                    End If


                Next dd
            Else
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS_VENTAS(Date_01, Date_01, ID_CF, cookie_proc)

                    If Data_Med.Count = 0 Then
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = 0
                        Item.CANT_EXA = 0
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.TOTA_SIS = 0
                        date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                        date_json_rial.Add(Item)
                    End If



                Next dd
            End If
        End If





        Dim CF_DESCCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESCCCCCCCC = "Todos"
        Else
            CF_DESCCCCCCCC = CF_DESC
        End If

        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(4, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Dias
            Mx_Data(2, y) = date_json_rial(y).E_Cantidad
            Mx_Data(3, y) = date_json_rial(y).CANT_EXA
            Mx_Data(4, y) = date_json_rial(y).TOTA_SIS

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
        sl.RenameWorksheet("Sheet1", "Visor de Cantidades de Atenciones Mensuales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Cantidades de Atenciones Mensuales")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & " Examen: " & CF_DESCCCCCCCC)
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Dias")
        sl.SetCellValue("C7", "Cantidad De Atenciones")
        sl.SetCellValue("D7", "Cantidad De Exámenes")
        sl.SetCellValue("E7", "Ventas")


        For y = 1 To 5
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("C" & ltabla + 1), CStr("=SUM(" & "C" & "8:" & "C" & ltabla & ")"))
        sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(" & "D" & "8:" & "D" & ltabla & ")"))
        sl.SetCellValue(CStr("E" & ltabla + 1), CStr("=SUM(" & "E" & "8:" & "E" & ltabla & ")"))
        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("B")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i

        sl.SetCellValue(CStr("C" & ltabla + 2), CStr("=AVERAGE(" & "C" & "8:" & "C" & ltabla & ")"))
        sl.SetCellValue(CStr("D" & ltabla + 2), CStr("=AVERAGE(" & "D" & "8:" & "D" & ltabla & ")"))

        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("E" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelAteProvee_Minds_Monts(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String
        'Declaraciones Generales
        Dim Mx_Data(5, 0) As Object
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        If (VALOR_2 = 0) Then
            If VALOR = 0 Then
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_MONTOS(Date_01, Date_01, ID_CF, cookie_proc)
                    If (Format(Date_01, "dddd") = "domingo") Then
                    Else
                        If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                            'Item.E_Fecha = Date_01
                            'Item.E_Cantidad = 0
                            'Item.CANT_EXA = 0
                            'Item.E_Dias = Format(Date_01, "dddd")
                            'date_json_rial.Add(Item)
                        Else
                            Item.E_Fecha = Date_01
                            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                            Item.E_Dias = Format(Date_01, "dddd")
                            Item.PREVI = Data_Med(0).TOTA_SIS
                            Item.PAGADO = Data_Med(0).TOTA_USU
                            Item.COPAGO = Data_Med(0).TOTA_COPA
                            date_json_rial.Add(Item)
                        End If
                    End If


                Next dd
            Else
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_MONTOS(Date_01, Date_01, ID_CF, cookie_proc)

                    If Data_Med.Count = 0 Then
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = 0
                        Item.CANT_EXA = 0
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.PREVI = 0
                        Item.PAGADO = 0
                        Item.COPAGO = 0
                        date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.PREVI = Data_Med(0).TOTA_SIS
                        Item.PAGADO = Data_Med(0).TOTA_USU
                        Item.COPAGO = Data_Med(0).TOTA_COPA
                        date_json_rial.Add(Item)
                    End If



                Next dd
            End If

        ElseIf VALOR_2 = 1 Then

            If VALOR = 0 Then
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_MONTOS(Date_01, Date_01, ID_CF, cookie_proc)
                    If (Format(Date_01, "dddd") = "domingo") Then
                    Else
                        If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                            'Item.E_Fecha = Date_01
                            'Item.E_Cantidad = 0
                            'Item.CANT_EXA = 0
                            'Item.E_Dias = Format(Date_01, "dddd")
                            'date_json_rial.Add(Item)
                        Else
                            Item.E_Fecha = Date_01
                            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                            Item.E_Dias = Format(Date_01, "dddd")
                            Item.PREVI = Data_Med(0).TOTA_SIS
                            Item.PAGADO = Data_Med(0).TOTA_USU
                            Item.COPAGO = Data_Med(0).TOTA_COPA
                            date_json_rial.Add(Item)
                        End If
                    End If


                Next dd
            Else
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_VALIDADOS_REVISADOS_MONTOS(Date_01, Date_01, ID_CF, cookie_proc)

                    If Data_Med.Count = 0 Then
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = 0
                        Item.CANT_EXA = 0
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.PREVI = 0
                        Item.PAGADO = 0
                        Item.COPAGO = 0
                        date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.PREVI = Data_Med(0).TOTA_SIS
                        Item.PAGADO = Data_Med(0).TOTA_USU
                        Item.COPAGO = Data_Med(0).TOTA_COPA
                        date_json_rial.Add(Item)
                    End If



                Next dd
            End If
        ElseIf VALOR_2 = 2 Then

            If VALOR = 0 Then
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS(Date_01, Date_01, ID_CF, cookie_proc)
                    If (Format(Date_01, "dddd") = "domingo") Then
                    Else
                        If Data_Med.Count = 0 Or (Data_Med(0).TOTAL_ATE = 0 And Data_Med(0).TOTAL_EXA = 0) Then
                            'Item.E_Fecha = Date_01
                            'Item.E_Cantidad = 0
                            'Item.CANT_EXA = 0
                            'Item.E_Dias = Format(Date_01, "dddd")
                            'date_json_rial.Add(Item)
                        Else
                            Item.E_Fecha = Date_01
                            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                            Item.E_Dias = Format(Date_01, "dddd")
                            Item.PREVI = Data_Med(0).TOTA_SIS
                            Item.PAGADO = Data_Med(0).TOTA_USU
                            Item.COPAGO = Data_Med(0).TOTA_COPA
                            date_json_rial.Add(Item)
                        End If
                    End If


                Next dd
            Else
                For dd = 1 To days
                    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
                    Dim Item As New E_GraficoVisor_Json
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_TODOS(Date_01, Date_01, ID_CF, cookie_proc)

                    If Data_Med.Count = 0 Then
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = 0
                        Item.CANT_EXA = 0
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.PREVI = 0
                        Item.PAGADO = 0
                        Item.COPAGO = 0
                        date_json_rial.Add(Item)
                    Else
                        Item.E_Fecha = Date_01
                        Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                        Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                        Item.E_Dias = Format(Date_01, "dddd")
                        Item.PREVI = Data_Med(0).TOTA_SIS
                        Item.PAGADO = Data_Med(0).TOTA_USU
                        Item.COPAGO = Data_Med(0).TOTA_COPA
                        date_json_rial.Add(Item)
                    End If



                Next dd
            End If
        End If





        Dim CF_DESCCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESCCCCCCCC = "Todos"
        Else
            CF_DESCCCCCCCC = CF_DESC
        End If

        If (date_json_rial.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(5, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Format(CDate(date_json_rial(y).E_Fecha), "dd/MM/yyyy")
            Mx_Data(1, y) = date_json_rial(y).E_Dias
            Mx_Data(2, y) = date_json_rial(y).E_Cantidad
            Mx_Data(3, y) = date_json_rial(y).CANT_EXA
            Mx_Data(4, y) = date_json_rial(y).PREVI
            Mx_Data(5, y) = date_json_rial(y).PAGADO


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
        sl.RenameWorksheet("Sheet1", "Visor de Cantidades de Atenciones Mensuales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Visor de Cantidades de Atenciones Mensuales")
        sl.SetCellValue("B4", "Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & " Examen: " & CF_DESCCCCCCCC)
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Dias")
        sl.SetCellValue("C7", "Cantidad De Atenciones")
        sl.SetCellValue("D7", "Cantidad De Exámenes")
        sl.SetCellValue("E7", "Total Sistema")
        sl.SetCellValue("F7", "Total Pagado")


        For y = 1 To 6
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
            sl.SetCellStyle(CStr("B" & y), formatonum)
            'sl.SetCellStyle(CStr("E" & y), formatonum)
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("C" & ltabla + 1), CStr("=SUM(" & "C" & "8:" & "C" & ltabla & ")"))
        sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(" & "D" & "8:" & "D" & ltabla & ")"))
        sl.SetCellValue(CStr("E" & ltabla + 1), CStr("=SUM(" & "E" & "8:" & "E" & ltabla & ")"))
        sl.SetCellValue(CStr("F" & ltabla + 1), CStr("=SUM(" & "F" & "8:" & "F" & ltabla & ")"))

        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("F")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 2), stTotal)
        Next i

        sl.SetCellValue(CStr("C" & ltabla + 2), CStr("=AVERAGE(" & "C" & "8:" & "C" & ltabla & ")"))
        sl.SetCellValue(CStr("D" & ltabla + 2), CStr("=AVERAGE(" & "D" & "8:" & "D" & ltabla & ")"))
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("A" & ltabla + 2, "Promedio:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("F" & ltabla + 2))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM") & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class