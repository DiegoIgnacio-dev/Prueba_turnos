Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web
Public Class N_Prev_TM_Exa_Mult_Valid
    'Declaraciones Generales
    Dim DD_Data As D_Prev_TM_Exa_Mult
    Sub New()
        DD_Data = New D_Prev_TM_Exa_Mult
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_VALID(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DESDE, HASTA)
    End Function


    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_OMI(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_VALID_OMI(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DESDE, HASTA)
    End Function


    Function IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_VALID_NEW(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_VALID_NEW(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DESDE, HASTA)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_Prev As New N_Prev_TM_Exa_Mult
        Dim Data_Prev_TM_Exa_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim paguito As Long = ID_TP_PAGO
        Dim Previs As Long = ID_PRE
        Dim previs2 As Long = ID_PRE2
        Dim previs3 As Long = ID_PRE3
        'Realizar Consulta
        Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)
        If (Data_Prev_TM_Exa_Sum.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(9, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev_TM_Exa_Sum.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(9, y)
            End If
            Mx_Data(0, y) = Data_Prev_TM_Exa_Sum(y).CF_COD
            Mx_Data(1, y) = Data_Prev_TM_Exa_Sum(y).CF_DESC
            Mx_Data(2, y) = Data_Prev_TM_Exa_Sum(y).TOTAL_ATE
            Mx_Data(3, y) = Data_Prev_TM_Exa_Sum(y).TOT_FONASA
            Mx_Data(4, y) = Data_Prev_TM_Exa_Sum(y).TOTA_SIS
            Mx_Data(5, y) = Data_Prev_TM_Exa_Sum(y).TOTA_USU
            Mx_Data(6, y) = Data_Prev_TM_Exa_Sum(y).TOTA_COPA
            Mx_Data(7, y) = CInt(Data_Prev_TM_Exa_Sum(y).TOTA_USU + Data_Prev_TM_Exa_Sum(y).TOTA_COPA)
            Mx_Data(8, y) = ""
            Mx_Data(9, y) = ""
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
        sl.RenameWorksheet("Sheet1", "Resumen de Atenciones por Lugar de TM y Previsión Validados")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Atenciones por Lugar de TM y Previsión Validados")
        If (Previs = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev_TM_Exa_Sum(0).CF_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE_str01 & " Hasta: " & DATE_str02)
        'nombre columnas
        sl.SetCellValue("A7", "Código")
        sl.SetCellValue("B7", "Exámenes")
        sl.SetCellValue("C7", "Cant. Atenciones")
        sl.SetCellValue("D7", "Cant. Exámenes")
        sl.SetCellValue("E7", "Total Sistema")
        sl.SetCellValue("F7", "Total Usuario")
        sl.SetCellValue("G7", "Total Copago")
        sl.SetCellValue("H7", "Total Pagado")
        sl.SetCellValue("I7", "Valor Examen")
        sl.SetCellValue("J7", "Total")
        For y = 1 To 10
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
            For i = Asc("C") To Asc("J")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("C") To Asc("H")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("J")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("J" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (Previs = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas_Valid" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Valid" & Data_Prev_TM_Exa_Sum(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function

    Function Gen_Excel_NEW(ByVal MAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                        ByVal ID_PRE3 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_Prev As New N_Prev_TM_Exa_Mult_Valid
        Dim Data_Prev_TM_Exa_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim paguito As Long = ID_TP_PAGO
        Dim Previs As Long = ID_PRE
        Dim previs2 As Long = ID_PRE2
        Dim previs3 As Long = ID_PRE3
        'Realizar Consulta
        Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_VALID_NEW(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)
        If (Data_Prev_TM_Exa_Sum.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(9, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev_TM_Exa_Sum.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(9, y)
            End If
            Mx_Data(0, y) = Data_Prev_TM_Exa_Sum(y).CF_COD
            Mx_Data(1, y) = Data_Prev_TM_Exa_Sum(y).CF_DESC
            Mx_Data(2, y) = Data_Prev_TM_Exa_Sum(y).TOTAL_ATE
            Mx_Data(3, y) = Data_Prev_TM_Exa_Sum(y).TOT_FONASA
            Mx_Data(4, y) = Data_Prev_TM_Exa_Sum(y).TOTA_SIS
            Mx_Data(5, y) = Data_Prev_TM_Exa_Sum(y).TOTA_USU
            Mx_Data(6, y) = Data_Prev_TM_Exa_Sum(y).TOTA_COPA
            Mx_Data(7, y) = CInt(Data_Prev_TM_Exa_Sum(y).TOTA_USU + Data_Prev_TM_Exa_Sum(y).TOTA_COPA)
            Mx_Data(8, y) = ""
            Mx_Data(9, y) = ""
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
        sl.RenameWorksheet("Sheet1", "Resumen de Atenciones por Lugar de TM y Previsión Validados")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Atenciones por Lugar de TM y Previsión Validados")
        If (Previs = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev_TM_Exa_Sum(0).CF_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE_str01 & " Hasta: " & DATE_str02)
        'nombre columnas
        sl.SetCellValue("A7", "Código")
        sl.SetCellValue("B7", "Exámenes")
        sl.SetCellValue("C7", "Cant. Atenciones")
        sl.SetCellValue("D7", "Cant. Exámenes")
        sl.SetCellValue("E7", "Total Sistema")
        sl.SetCellValue("F7", "Total Usuario")
        sl.SetCellValue("G7", "Total Copago")
        sl.SetCellValue("H7", "Total Pagado")
        sl.SetCellValue("I7", "Valor Examen")
        sl.SetCellValue("J7", "Total")
        For y = 1 To 10
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
            For i = Asc("C") To Asc("J")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("C") To Asc("H")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("J")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("J" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (Previs = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas_Valid" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Valid" & Data_Prev_TM_Exa_Sum(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
    Function Gen_Excel_TECMED(ByVal MAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                         ByVal ID_PRE3 As Long, ByVal ID_PRE4 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_Prev As New N_Prev_TM_Exa_Mult_TCMD
        Dim Data_Prev_TM_Exa_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Dim Mx_Data(4, 0) As Object
        'Obtener parámetros para la consulta
        Dim paguito As Long = ID_TP_PAGO
        Dim Previs As Long = ID_PRE
        Dim previs2 As Long = ID_PRE2
        Dim previs3 As Long = ID_PRE3
        'Realizar Consulta
        Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, ID_PRE4, DATE_str01, DATE_str02)
        If (Data_Prev_TM_Exa_Sum.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(3, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev_TM_Exa_Sum.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(3, y)
            End If
            Mx_Data(0, y) = Data_Prev_TM_Exa_Sum(y).CF_COD
            Mx_Data(1, y) = Data_Prev_TM_Exa_Sum(y).CF_DESC
            Mx_Data(2, y) = Data_Prev_TM_Exa_Sum(y).TOTAL_ATE
            Mx_Data(3, y) = Data_Prev_TM_Exa_Sum(y).TOT_FONASA
            'Mx_Data(4, y) = Data_Prev_TM_Exa_Sum(y).TOTA_SIS
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
        sl.RenameWorksheet("Sheet1", "Resumen Exámenes Multiple")
        'titulo de la tabla
        sl.SetCellValue("A2", "Resumen Exámenes Multiple")
        If (Previs = 0) Then
            sl.SetCellValue("A3", "Previsión: Todas")
        Else
            sl.SetCellValue("A3", "Previsión: " & Data_Prev_TM_Exa_Sum(0).CF_DESC)
        End If
        sl.SetCellValue("A4", "Desde: " & DATE_str01 & " Hasta: " & DATE_str02)
        'nombre columnas
        sl.SetCellValue("A7", "Código")
        sl.SetCellValue("B7", "Exámenes")
        sl.SetCellValue("C7", "Cant. Atenciones")
        sl.SetCellValue("D7", "Cant. Exámenes")
        'sl.SetCellValue("E7", "Valor Total")
        For y = 1 To 10
            sl.SetColumnWidth(y, 20.0)
        Next y
        sl.SetColumnWidth("B", 40)

        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Calibri"
        estilo.Font.FontSize = 11
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Calibri"
        estilo2.Font.FontSize = 10
        estilo2.Font.Bold = False

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Calibri"
        estilo3.Font.FontSize = 10
        estilo3.Font.Bold = False

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("A2", estilo)
        sl.SetCellStyle("A3", estilo2)
        sl.SetCellStyle("A4", estilo3)

        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
                sl.SetCellStyle(y + Excel_y, x + 1, estilo2)
            Next x
            ltabla += 1
        Next y
        ltabla += 7


        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("C") To Asc("E")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        'For i = Asc("D") To Asc("E")
        '    sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
        '    'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        'Next i
        'estilo totales
        'For i = Asc("A") To Asc("D")
        '    sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        'Next i
        'sl.SetCellValue("A" & ltabla + 1, "Total:")
        'sl.SetCellValue("C" & ltabla + 1, Data_Prev_TM_Exa_Sum(0).TOTAL_ATE)
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("D" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (Previs = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas_Valid" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Valid" & Data_Prev_TM_Exa_Sum(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
    Function Gen_Excel_TECMED_2(ByVal MAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long, ByVal ID_PRE4 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_Prev As New N_Prev_TM_Exa_Mult_TCMD
        Dim Data_Prev_TM_Exa_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Dim Mx_Data(5, 0) As Object
        'Obtener parámetros para la consulta
        Dim paguito As Long = ID_TP_PAGO
        Dim Previs As Long = ID_PRE
        Dim previs2 As Long = ID_PRE2
        Dim previs3 As Long = ID_PRE3
        'Realizar Consulta
        Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD_2(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, ID_PRE4, DATE_str01, DATE_str02)
        If (Data_Prev_TM_Exa_Sum.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(5, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev_TM_Exa_Sum.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(5, y)
            End If
            Mx_Data(0, y) = Data_Prev_TM_Exa_Sum(y).CF_COD
            Mx_Data(1, y) = Data_Prev_TM_Exa_Sum(y).CF_DESC
            Mx_Data(2, y) = ""
            Mx_Data(3, y) = Data_Prev_TM_Exa_Sum(y).TOT_FONASA
            Mx_Data(4, y) = Data_Prev_TM_Exa_Sum(y).ATE_DET_V_PREVI
            Mx_Data(5, y) = Data_Prev_TM_Exa_Sum(y).TOTA_SIS
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
        sl.RenameWorksheet("Sheet1", "Resumen Exámenes Multiple")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen Exámenes Multiple")
        If (Previs = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev_TM_Exa_Sum(0).CF_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE_str01 & " Hasta: " & DATE_str02)
        'nombre columnas
        sl.SetCellValue("A7", "Código")
        sl.SetCellValue("B7", "Exámenes")
        sl.SetCellValue("C7", "Cant. Atenciones")
        sl.SetCellValue("D7", "Cant. Exámenes")
        sl.SetCellValue("E7", "Valor Unidad")
        sl.SetCellValue("F7", "Valor Total")
        For y = 1 To 10
            sl.SetColumnWidth(y, 20.0)
        Next y
        sl.SetColumnWidth("B", 40)
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
            For i = Asc("C") To Asc("F")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("D") To Asc("D")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        For i = Asc("F") To Asc("F")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("F")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        sl.SetCellValue("C" & ltabla + 1, Data_Prev_TM_Exa_Sum(0).TOTAL_ATE)
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("F" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (Previs = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas_Valid" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Valid" & Data_Prev_TM_Exa_Sum(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
End Class