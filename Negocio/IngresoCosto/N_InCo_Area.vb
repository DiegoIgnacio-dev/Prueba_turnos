Imports Entidades
Imports Datos
Imports SpreadsheetLight
Public Class N_InCo_Area

    'Declaraciones Generales
    Dim DD_Data As D_InCo_Area
    Sub New()
        DD_Data = New D_InCo_Area
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_AREA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_AREA As Integer) As List(Of E_InCo_Area)

        Dim List_in As New List(Of E_InCo_Area)
        List_in = DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_AREA(DESDE, HASTA, ID_AREA)

        Return List_in
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_AREA As Integer, ByVal AREA_DESC As String) As String
        'Declaraciones Generales
        Dim NN_Aten As New N_InCo_Area
        Dim Data_Aten As New List(Of E_InCo_Area)
        Dim Mx_Data(5, 0) As Object
        'Obtener parámetros para la consulta
        'Realizar Consulta
        Data_Aten = NN_Aten.IRIS_WEBF_BUSCA_LIS_ADM_AREA(DESDE, HASTA, ID_AREA)
        If (Data_Aten.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(5, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Aten.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(5, y)
            End If
            Mx_Data(0, y) = Data_Aten(y).CF_COD
            Mx_Data(1, y) = Data_Aten(y).AREA_DESC
            Mx_Data(2, y) = Data_Aten(y).CF_DESC
            Mx_Data(3, y) = Data_Aten(y).TOT_FONASA
            Mx_Data(4, y) = Data_Aten(y).CONTROL_COSTO_PRECIO
            Mx_Data(5, y) = Data_Aten(y).TOT_FONASA * Data_Aten(y).CONTROL_COSTO_PRECIO
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
        Dim stTotal2 As SLStyle
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Ing vs Cos Area")
        'titulo de la tabla
        sl.SetCellValue("B2", "Ingreso vs Costos por Area ")

        sl.SetCellValue("B3", "Area: " & AREA_DESC)

        sl.SetCellValue("B4", "Desde: " & DESDE & " Hasta: " & DESDE)
        'nombre columnas
        sl.SetCellValue("A7", "Código")
        sl.SetCellValue("B7", "Area")
        sl.SetCellValue("C7", "Examen")
        sl.SetCellValue("D7", "Cantidad")
        sl.SetCellValue("E7", "Costo Unit.")
        sl.SetCellValue("F7", "Total Costo")
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

        stTotal2 = sl.CreateStyle()
        stTotal2.Font.FontSize = 12
        stTotal2.Font.Bold = True
        stTotal2.FormatCode = "###,###,##0"

        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "$###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("E") To Asc("F")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("D") To Asc("F")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("E") To Asc("F")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        For i = Asc("D") To Asc("D")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal2)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("F" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & AREA_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class
