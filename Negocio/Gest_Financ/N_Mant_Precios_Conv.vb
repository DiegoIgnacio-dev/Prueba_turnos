Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Mant_Precios_Conv
    'Declaraciones Generales
    Dim DD_Data As D_Mant_Precios_Conv

    Sub New()
        DD_Data = New D_Mant_Precios_Conv
    End Sub

    Function IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA(ByVal ID_PREV As Long, ByVal ID_YEAR As Long, ByVal ALL_EXA As Boolean) As List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)
        Return DD_Data.IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA(ID_PREV, ID_YEAR, ALL_EXA)
    End Function

    Function IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA(ByVal ID_CODF As Long, ByVal ID_PREC As Long, ByVal BIT_CONV As Boolean, ByVal LNG_PREC As Long, ByVal LNG_DERI As Long, ByVal LNG_CTOT As Long, ByVal DBL_PJEC As Single, ByVal DBL_PJEL As Single) As Boolean
        Return DD_Data.IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA(ID_CODF, ID_PREC, BIT_CONV, LNG_PREC, LNG_DERI, LNG_CTOT, DBL_PJEC, DBL_PJEL)
    End Function

    Function Copy_Prices(ByVal ID_PREV1 As Long, YEAR1 As Integer, ByVal ID_PREV2 As Long, ByVal ID_YEAR2 As Long, ByVal ALL_EXA As Boolean) As Boolean
        Dim List_In As New List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)
        List_In = DD_Data.IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA(ID_PREV1, YEAR1, ALL_EXA)

        For y = 0 To (List_In.Count - 1)
            DD_Data.IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA_WITH_IDCF_PREV_AND_YEAR(
                    List_In(y).ID_CODIGO_FONASA,
                    ID_PREV2,
                    ID_YEAR2,
                    List_In(y).CF_PRECIO_AMB,
                    List_In(y).CF_PRECIO_COSTO_DERIV,
                    List_In(y).CF_PRECIO_COSTO_T,
                    List_In(y).CF_PRECIO_PJE_CONV,
                    List_In(y).CF_PRECIO_PJE_LAB
                )
        Next

        Return True
    End Function

    Function Export(ByVal URL As String, ByVal ID_PREV As Long, ByVal ID_YEAR As Long, ByVal ALL_EXA As Boolean) As String
        Dim NN_Data As New N_Mant_Precios_Conv
        Dim objList As New List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)

        objList = NN_Data.IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA(ID_PREV, ID_YEAR, ALL_EXA)
        If (objList.Count = 0) Then
            Return Nothing
        End If

        'Crear nuevo Dcto
        Dim xls As New SLDocument
        Dim RowH As Integer = 20

        'Definir estilos
        Dim css_Title = xls.CreateStyle
        css_Title.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_Title.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_Title.Font.Bold = True
        css_Title.Font.FontSize = 11
        css_Title.Font.FontName = "Calibri"

        Dim css_SubTitle = xls.CreateStyle
        css_SubTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_SubTitle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_SubTitle.Font.Bold = True
        css_SubTitle.Font.FontSize = 10
        css_SubTitle.Font.FontName = "Calibri"

        Dim css_THead = xls.CreateStyle
        css_THead.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_THead.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_THead.Font.Bold = True
        css_THead.Font.FontSize = 10
        css_THead.Font.FontName = "Calibri"
        css_THead.Font.FontColor = System.Drawing.Color.White

        Dim css_TCell_left = xls.CreateStyle
        css_TCell_left.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_TCell_left.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_left.Font.Bold = False
        css_TCell_left.Font.FontName = "Calibri"
        css_TCell_left.Font.FontSize = 10

        Dim css_TCell_center = xls.CreateStyle
        css_TCell_center.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center.Font.Bold = False
        css_TCell_center.Font.FontName = "Calibri"
        css_TCell_center.Font.FontSize = 10

        Dim css_TCell_right = xls.CreateStyle
        css_TCell_right.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_right.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_right.Font.Bold = False
        css_TCell_right.Font.FontName = "Calibri"
        css_TCell_right.Font.FontSize = 10

        Dim css_TCell_Date = xls.CreateStyle
        css_TCell_Date.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_Date.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Date.Font.Bold = False
        css_TCell_Date.Font.FontSize = 10
        css_TCell_Date.Font.FontName = "Calibri"
        css_TCell_Date.FormatCode = "dd/mm/yyyy"

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
        xls.SetCellValue(1, 1, "Listados de Precios sin Convenio")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Previsión: " & objList(0).PREVE_DESC)
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Año: " & objList(0).AÑO_DESC)
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)

        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1
        xls.SetCellValue(y1, x2, "Cod Fonasa") : x2 += 1
        xls.SetCellValue(y1, x2, "Descripción") : x2 += 1
        xls.SetCellValue(y1, x2, "Convenio") : x2 += 1
        xls.SetCellValue(y1, x2, "Valor Unitario") : x2 += 1
        xls.SetCellValue(y1, x2, "Costo Derivado") : x2 += 1
        xls.SetCellValue(y1, x2, "Total Costos") : x2 += 1
        xls.SetCellValue(y1, x2, "Diferencia") : x2 += 1
        xls.SetCellValue(y1, x2, "% Centro Méd.") : x2 += 1
        xls.SetCellValue(y1, x2, "Monto Centro Méd.") : x2 += 1
        xls.SetCellValue(y1, x2, "$ Laboratorio.") : x2 += 1
        xls.SetCellValue(y1, x2, "Monto Laboratorio.") : x2 += 1
        x2 = x1

        For i = 1 To 11
            xls.SetCellStyle(5, i, css_THead)
        Next

        xls.SetColumnWidth(x2, RowH + 10) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 20) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 00) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        xls.SetColumnWidth(x2, RowH + 05) : x2 += 1
        x2 = x1

        For y = 0 To (objList.Count - 1)
            x2 = x1
            y2 += 1

            xls.SetCellValue(y2, x2, objList(y).CF_COD) : x2 += 1
            xls.SetCellValue(y2, x2, objList(y).CF_DESC) : x2 += 1

            If (objList(y).CF_CONVENIO_OUT = True) Then
                xls.SetCellValue(y2, x2, "Sí") : x2 += 1
            Else
                xls.SetCellValue(y2, x2, "-") : x2 += 1
            End If

            xls.SetCellValue(y2, x2, objList(y).CF_PRECIO_AMB) : x2 += 1
            xls.SetCellValue(y2, x2, objList(y).CF_PRECIO_COSTO_DERIV) : x2 += 1
            xls.SetCellValue(y2, x2, objList(y).CF_PRECIO_COSTO_T) : x2 += 1
            xls.SetCellValue(y2, x2, objList(y).CF_PRECIO_AMB - objList(y).CF_PRECIO_COSTO_T) : x2 += 1
            xls.SetCellValue(y2, x2, objList(y).CF_PRECIO_PJE_CONV) : x2 += 1
            xls.SetCellValue(y2, x2, (objList(y).CF_PRECIO_AMB - objList(y).CF_PRECIO_COSTO_T) * objList(y).CF_PRECIO_PJE_CONV * 0.01) : x2 += 1
            xls.SetCellValue(y2, x2, objList(y).CF_PRECIO_PJE_LAB) : x2 += 1
            xls.SetCellValue(y2, x2, (objList(y).CF_PRECIO_AMB - objList(y).CF_PRECIO_COSTO_T) * objList(y).CF_PRECIO_PJE_LAB * 0.01) : x2 += 1
            x2 = x1

            xls.SetCellStyle(y2, x2, css_TCell_left) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_left) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Percentage) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Percentage) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Money)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = xls.CreateTable(y1, x1, y2, x2)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Mant_Precios_Conv_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class