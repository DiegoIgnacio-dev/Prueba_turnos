'Importar Capas
Imports Datos
Imports Entidades
Imports ASPPDFLib
Imports SpreadsheetLight
Public Class N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
    Inherits System.Web.UI.Page
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
    End Sub
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_PROVEE(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_PROVEE(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR_2(ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR_2(PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_PROVEE(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_PROVEE(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_MINDS(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_MINDS(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_PROVEE(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_PROVEE(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_MINDS(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_MINDS(DESDE, HASTA, PROC, PREV, PROG)
    End Function
    Function Gen_Excel(ByVal DOMAIN_URL As String,
                       ByVal DESDE As String,
                       ByVal HASTA As String,
                       ByVal PROC As Integer,
                       ByVal PREV As Integer,
                       ByVal PROG As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim Mx_Data(6, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2(DESDE, HASTA, PROC, PREV, PROG)
        If (Data_Prev.Count = 0) Then
            Return Nothing
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
            Mx_Data(0, y) = Data_Prev(y).ATE_NUM
            Mx_Data(1, y) = Data_Prev(y).ATE_FECHA.ToString("dd-MM-yyyy")
            Mx_Data(2, y) = Data_Prev(y).PAC_RUT
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE + " " + Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).CF_COD
            Mx_Data(5, y) = Data_Prev(y).CF_DESC
            Mx_Data(6, y) = CInt(Data_Prev(y).ATE_DET_V_PREVI)
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

        Dim TOT_ATE As Integer
        Dim TOT_EXA As Integer

        Dim Arr As New List(Of String)

        For y = 0 To Data_Prev.Count - 1
            If (y = 0) Then
                Arr.Add(Data_Prev(y).ATE_NUM)
            Else
                Dim _count As Integer
                For x = 0 To Arr.Count - 1
                    _count = 0
                    If (Arr(x) = Data_Prev(y).ATE_NUM) Then
                        _count = 1
                    End If
                Next
                If (_count = 0) Then
                    Arr.Add(Data_Prev(y).ATE_NUM)
                End If
            End If
        Next
        TOT_ATE = Arr.Count
        TOT_EXA = Data_Prev.Count

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Detalle Proc - Prev - Prog")
        'titulo de la tabla
        sl.SetCellValue("B2", "Detalle de Procedencia-Previsión-Programa")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        sl.SetCellValue("B4", Data_Prev(0).PROC_DESC & " - " & Data_Prev(0).PREVE_DESC & " - " & Data_Prev(0).PROGRA_DESC)
        sl.SetCellValue("B5", "Atenciones: " & TOT_ATE & " Exámenes: " & TOT_EXA)
        'nombre columnas
        sl.SetCellValue("B7", "Folio")
        sl.SetCellValue("C7", "Fecha")
        sl.SetCellValue("D7", "Rut")
        sl.SetCellValue("E7", "Nombre")
        sl.SetCellValue("F7", "Código")
        sl.SetCellValue("G7", "Examen")
        sl.SetCellValue("H7", "Valor")
        For y = 2 To 7
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
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
        sl.SetCellStyle("B5", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("E") To Asc("H")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("H") To Asc("H")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("H") To Asc("H")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Detalle P-P-P" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function PDFF(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer) As String


        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)



        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP(DESDE, HASTA, PROC, PREV, PROG)

        If (Data_DTT.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Det_Proc_Prev_Prog" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Detalle Procedencia Previsión Programa"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim tot_val As Integer
        tot_val = 0
        For x = 0 To Data_DTT.Count - 1
            tot_val += Data_DTT(x).ATE_DET_V_PREVI
        Next


        Dim TOT_ATE As Integer

        Dim Arr As New List(Of String)

        For y = 0 To Data_DTT.Count - 1
            If (y = 0) Then
                Arr.Add(Data_DTT(y).ATE_NUM)
            Else
                Dim _count As Integer
                For x = 0 To Arr.Count - 1
                    _count = 0
                    If (Arr(x) = Data_DTT(y).ATE_NUM) Then
                        _count = 1
                    End If
                Next
                If (_count = 0) Then
                    Arr.Add(Data_DTT(y).ATE_NUM)
                End If
            End If
        Next
        TOT_ATE = Arr.Count
        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText(DESDE & " al " & HASTA & " " & Data_DTT(0).PROC_DESC & " - " & Data_DTT(0).PREVE_DESC & " - " & Data_DTT(0).PROGRA_DESC, STR_PARAM(25, 780, 560, "center", 13), FONT_2)
                .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & Data_DTT.Count & " - Total Valorización: " & "$" & (Integer.Parse(tot_val)).ToString("#,##0"), STR_PARAM(1, 750, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                .DrawText("Folio", STR_PARAM(45, 720, 50, "left", 9), FONT_2)
                .DrawText("Fecha", STR_PARAM(75, 720, 80, "left", 9), FONT_2)
                .DrawText("Rut", STR_PARAM(125, 720, 40, "left", 9), FONT_2)
                .DrawText("Nombre", STR_PARAM(180, 720, 120, "left", 9), FONT_2)
                .DrawText("Código", STR_PARAM(320, 720, 120, "left", 9), FONT_2)
                .DrawText("Examen", STR_PARAM(370, 720, 120, "left", 9), FONT_2)
                .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    If (Data_DTT(i).CF_DESC.Length > 40) Then
                        Data_DTT(i).CF_DESC = Data_DTT(i).CF_DESC.Substring(0, 40)
                    End If

                    Dim _Name As String()
                    _Name = Split(Data_DTT(i).PAC_NOMBRE, " ")

                    If (_Name.Length > 1) Then
                        Data_DTT(i).PAC_NOMBRE = _Name(0)
                    End If

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                    .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd/MM/yyyy"), STR_PARAM(75, eje_y, 120, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).PAC_RUT, STR_PARAM(125, eje_y, 80, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(180, eje_y, 155, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).CF_COD, STR_PARAM(320, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).CF_DESC.ToUpper, STR_PARAM(370, eje_y, 180, "left", 7), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
                    .DrawText("_______________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)

                    eje_y = eje_y - 9
                    contador_filas += 1

                Next i
            End With
        Else

            Dim z = 0
            Dim i As Integer = 0

            eje_y = 700

            Dim fuck = DOC.Pages.Add(612, 792)
            Dim _C_Max As Integer = 0
            With fuck.Canvas
                For z = z To Data_DTT.Count - 1

                    If (Data_DTT(z).CF_DESC.Length > 40) Then
                        Data_DTT(z).CF_DESC = Data_DTT(z).CF_DESC.Substring(0, 40)
                    End If
                    Dim _Name As String()
                    _Name = Split(Data_DTT(z).PAC_NOMBRE, " ")

                    If (_Name.Length > 1) Then
                        Data_DTT(z).PAC_NOMBRE = _Name(0)
                    End If
                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText(DESDE & " al " & HASTA & " " & Data_DTT(0).PROC_DESC & " - " & Data_DTT(0).PREVE_DESC & " - " & Data_DTT(0).PROGRA_DESC, STR_PARAM(25, 780, 601, "center", 14), FONT_2)
                        .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & Data_DTT.Count & " - Total Valorización: " & "$" & (Integer.Parse(tot_val)).ToString("#,##0"), STR_PARAM(1, 750, 611, "center", 11), FONT_2)
                        '.DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                        .DrawText("Folio", STR_PARAM(45, 720, 50, "left", 9), FONT_2)
                        .DrawText("Fecha", STR_PARAM(75, 720, 80, "left", 9), FONT_2)
                        .DrawText("Rut", STR_PARAM(125, 720, 40, "left", 9), FONT_2)
                        .DrawText("Nombre", STR_PARAM(180, 720, 120, "left", 9), FONT_2)
                        .DrawText("Código", STR_PARAM(320, 720, 120, "left", 9), FONT_2)
                        .DrawText("Examen", STR_PARAM(370, 720, 120, "left", 9), FONT_2)
                        .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                        .DrawText(Data_DTT(z).ATE_NUM, STR_PARAM(45, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(Format(Data_DTT(z).ATE_FECHA, "dd/MM/yyyy"), STR_PARAM(75, eje_y, 120, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).PAC_RUT, STR_PARAM(125, eje_y, 80, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).PAC_NOMBRE & " " & Data_DTT(z).PAC_APELLIDO, STR_PARAM(180, eje_y, 155, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).CF_COD, STR_PARAM(320, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).CF_DESC.ToUpper, STR_PARAM(370, eje_y, 180, "left", 7), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
                        .DrawText("_______________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                        eje_y = eje_y - 9
                        contador_filas += 1
                        i = 1

                    Else
                        If z <> 0 Then
                            If _C_Max = zz_Mod Then

                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 750
                                _C_Max = 0
                                zz_Mod = 80
                            End If
                        End If
                        With fuck.Canvas
                            .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                            .DrawText(Data_DTT(z).ATE_NUM, STR_PARAM(45, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(Format(Data_DTT(z).ATE_FECHA, "dd/MM/yyyy"), STR_PARAM(75, eje_y, 120, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).PAC_RUT, STR_PARAM(125, eje_y, 80, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).PAC_NOMBRE & " " & Data_DTT(z).PAC_APELLIDO, STR_PARAM(180, eje_y, 155, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).CF_COD, STR_PARAM(320, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).CF_DESC.ToUpper, STR_PARAM(370, eje_y, 180, "left", 7), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
                            .DrawText("_______________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If

        'Dim super_sumador = 0
        'Dim PAGE_TOTALES = DOC.Pages.Add(612, 792)

        'With PAGE_TOTALES.Canvas
        '    eje_y = 720
        '    contador_filas = 1

        '    .DrawText("TOTALES", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
        '    .DrawText("#", STR_PARAM(15, 740, 15, "left", 9), FONT_2)
        '    .DrawText("Etiqueta", STR_PARAM(200, 740, 70, "left", 9), FONT_2)
        '    .DrawText("TOTAL", STR_PARAM(530, 740, 176, "left", 9), FONT_2)

        '    'For Each key In data_det_ate.Dictionary.Keys
        '    '    .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
        '    '    .DrawText(key, STR_PARAM(200, eje_y, 70, "left", 7), FONT_1)
        '    '    .DrawText(data_det_ate.Dictionary.Item(key), STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        '    '    eje_y = eje_y - 17
        '    '    contador_filas += 1
        '    '    super_sumador += data_det_ate.Dictionary.Item(key)
        '    'Next

        '    .DrawText("TOTAL", STR_PARAM(15, eje_y, 176, "left", 9), FONT_2)
        '    '.DrawText(super_sumador, STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        'End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function Gen_Excel_2(ByVal DOMAIN_URL As String,
                       ByVal PROG As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim Mx_Data(8, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR_2(PROG)
        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(8, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(8, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).ATE_NUM
            Mx_Data(2, y) = Format(Data_Prev(y).ATE_FECHA, "dd-MM-yyyy")
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE + " " + Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(5, y) = Data_Prev(y).PROC_DESC
            Mx_Data(6, y) = Data_Prev(y).CF_DESC
            Mx_Data(7, y) = Data_Prev(y).TP_PAGO_DESC
            Mx_Data(8, y) = CInt(Data_Prev(y).ATE_DET_V_PREVI)
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

        Dim TOT_ATE As Integer
        Dim TOT_EXA As Integer

        Dim Arr As New List(Of String)

        For y = 0 To Data_Prev.Count - 1
            If (y = 0) Then
                Arr.Add(Data_Prev(y).ATE_NUM)
            Else
                Dim _count As Integer
                For x = 0 To Arr.Count - 1
                    _count = 0
                    If (Arr(x) = Data_Prev(y).ATE_NUM) Then
                        _count = 1
                    End If
                Next
                If (_count = 0) Then
                    Arr.Add(Data_Prev(y).ATE_NUM)
                End If
            End If
        Next
        TOT_ATE = Arr.Count
        TOT_EXA = Data_Prev.Count

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Detalle Proc - Prev - Prog")
        'titulo de la tabla
        sl.SetCellValue("B2", "Detalle de Procedencia-Previsión-Programa")
        sl.SetCellValue("B3", "Folio: " & Data_Prev(0).ATE_NUM)
        sl.SetCellValue("B5", "Total Exámenes: " & Data_Prev.Count)
        'nombre columnas
        sl.SetCellValue("B7", "#")
        sl.SetCellValue("C7", "Folio")
        sl.SetCellValue("D7", "Fecha Ate")
        sl.SetCellValue("E7", "Nombre Pac")
        sl.SetCellValue("F7", "Previsión")
        sl.SetCellValue("G7", "Procedencia")
        sl.SetCellValue("H7", "Examen")
        sl.SetCellValue("I7", "Tipo Pago")
        sl.SetCellValue("J7", "Total")
        For y = 2 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
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
        sl.SetCellStyle("B5", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("J") To Asc("J")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("J") To Asc("J")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("J") To Asc("J")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("J" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Detalle_Folio_Usuario_" & Data_Prev(0).ATE_NUM & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function STR_PARAM(ByVal x As Single, ByVal y As Single, ByVal width As Single,
     ByVal alignment As String, ByVal size As Single) As String
        Dim PARAM_XX As String

        'Parámetros de la cadena
        PARAM_XX = ""
        PARAM_XX += "x=" & x & ";"                              'Posición x del cuadro de texto
        PARAM_XX += "y=" & y & ";"                              'Posición y del cuadro de texto
        PARAM_XX += "width=" & width & ";"                      'Ancho del cuadro de texto
        PARAM_XX += "alignment=" & alignment & ";"              'Alineación del cuadro de texto
        PARAM_XX += "size=" & size & ""                         'Tamaño de la fuente

        Return PARAM_XX
    End Function
End Class
