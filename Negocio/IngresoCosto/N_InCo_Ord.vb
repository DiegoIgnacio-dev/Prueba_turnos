Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Public Class N_InCo_Ord


    'Declaraciones Generales
    Dim DD_Data As D_InCo_Ord
    Sub New()
        DD_Data = New D_InCo_Ord
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_ORD(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORDEN As Integer) As List(Of E_InCo_Ord)

        Dim List_in As New List(Of E_InCo_Ord)
        List_in = DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_ORD(DESDE, HASTA, ID_ORDEN)

        Return List_in
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORDEN As Integer, ByVal ORDEN_DESC As String) As String
        'Declaraciones Generales
        Dim NN_Aten As New N_InCo_Ord
        Dim Data_Aten As New List(Of E_InCo_Ord)
        Dim Mx_Data(10, 0) As Object
        'Obtener parámetros para la consulta
        'Realizar Consulta
        Data_Aten = NN_Aten.IRIS_WEBF_BUSCA_LIS_ADM_ORD(DESDE, HASTA, ID_ORDEN)
        If (Data_Aten.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(10, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Aten.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(10, y)
            End If
            Mx_Data(0, y) = Data_Aten(y).ATE_NUM
            Mx_Data(1, y) = Data_Aten(y).ORD_DESC
            Mx_Data(2, y) = Format(Data_Aten(y).ATE_FECHA, "MM/dd/yyyy hh:mm:ss")
            Mx_Data(3, y) = Data_Aten(y).PROC_DESC
            Mx_Data(4, y) = Data_Aten(y).CF_COD
            Mx_Data(5, y) = Data_Aten(y).CF_DESC
            Mx_Data(6, y) = Data_Aten(y).ATE_DET_V_PREVI
            Mx_Data(7, y) = Data_Aten(y).ATE_DET_V_PAGADO
            Mx_Data(8, y) = Data_Aten(y).ATE_DET_V_COPAGO
            Mx_Data(9, y) = Data_Aten(y).ATE_DET_V_PAGADO
            Mx_Data(10, y) = Data_Aten(y).CONTROL_COSTO_PRECIO
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim formatonum As SLStyle
        Dim stTotal As SLStyle
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Ing vs Cos Ord")
        'titulo de la tabla
        sl.SetCellValue("B2", "Ingreso vs Costos por Orden Atención")

        sl.SetCellValue("B3", "Orden: " & ORDEN_DESC)

        sl.SetCellValue("B4", "Desde: " & DESDE & " Hasta: " & DESDE)
        'nombre columnas
        sl.SetCellValue("A7", "Folio")
        sl.SetCellValue("B7", "Orden")
        sl.SetCellValue("C7", "Fecha")
        sl.SetCellValue("D7", "Procedencia")
        sl.SetCellValue("E7", "Código")
        sl.SetCellValue("F7", "Examen")
        sl.SetCellValue("G7", "Valor Sistema")
        sl.SetCellValue("H7", "Valor Usuario")
        sl.SetCellValue("I7", "Valor Copago")
        sl.SetCellValue("J7", "Valor Pagado")
        sl.SetCellValue("K7", "Costo")
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
        stTotal.FormatCode = "$###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "$###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("G") To Asc("K")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("G") To Asc("K")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("K")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("K" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & ORDEN_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class
