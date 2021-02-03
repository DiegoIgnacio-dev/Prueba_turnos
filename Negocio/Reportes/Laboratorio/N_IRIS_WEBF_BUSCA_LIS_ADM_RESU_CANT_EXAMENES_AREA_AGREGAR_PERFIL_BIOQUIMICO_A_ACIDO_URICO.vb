Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
    End Sub

    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ID_TP_PAGO, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ID_TP_PAGO, DESDE, HASTA)
    End Function

    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_WITH_ID_PREVE(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_WITH_ID_PREVE(ID_TP_PAGO, DESDE, HASTA, ID_PREVE)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS_WITH_ID_PREVE(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS_WITH_ID_PREVE(ID_TP_PAGO, DESDE, HASTA, ID_PREVE)
    End Function

    Function Gen_Excel_Desagrupado(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String, ByVal ID_PREVE As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta
        Dim ID_CODIGO_FONASAA As Long = ID_CODIGO_FONASA
        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        'Realizar Consulta
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_WITH_ID_PREVE(ID_CODIGO_FONASAA, Date01, Date02, ID_PREVE)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            Dim fosfa As Boolean = False
            Dim trigli As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido urico
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 94 Then
                    fosfa = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    trigli = True
                End If
            Next i

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If (fosfa = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 94
                xItem.CF_DESC = "Fosfatasas Alcalinas"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1010"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If

            If (trigli = False) Then
                Dim xItem4 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem4.ID_CODIGO_FONASA = 138
                xItem4.CF_DESC = "Trigliceridos"
                xItem4.TOTAL_ATE = perfiles_lipidicos
                xItem4.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem4.SECC_ORDEN = 51
                xItem4.CF_COD = "1027"

                Data_Exam.Add(xItem4)
            End If

            'ORDENARRRRRRRRR

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
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
        xls.SetCellValue(1, 1, "Censo REM 18")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If

            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 145 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 668 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 76) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Desagrupado_VALIDADOS(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String, ByVal ID_PREVE As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta
        Dim ID_CODIGO_FONASAA As Long = ID_CODIGO_FONASA
        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        'Realizar Consulta
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS_WITH_ID_PREVE(ID_CODIGO_FONASAA, Date01, Date02, ID_PREVE)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            Dim fosfa As Boolean = False
            Dim trigli As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido urico
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 94 Then
                    fosfa = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    trigli = True
                End If
            Next i

            If (trigli = False) Then
                Dim xItem4 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem4.ID_CODIGO_FONASA = 138
                xItem4.CF_DESC = "Trigliceridos"
                xItem4.TOTAL_ATE = perfiles_lipidicos
                xItem4.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem4.SECC_ORDEN = 51
                xItem4.CF_COD = "1027"

                Data_Exam.Add(xItem4)
            End If

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If (fosfa = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 94
                xItem.CF_DESC = "Fosfatasas Alcalinas"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1010"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If

            'ORDENARRRRRRRRR
            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
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
        xls.SetCellValue(1, 1, "Censo REM18 Validados")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If

            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 145 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 668 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 76) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Agrupado(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String, ByVal ID_PREVE As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta
        Dim ID_CODIGO_FONASAA As Long = ID_CODIGO_FONASA
        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        'Realizar Consulta
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_WITH_ID_PREVE(ID_CODIGO_FONASAA, Date01, Date02, ID_PREVE)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            Dim fosfa As Boolean = False
            Dim trigli As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido urico
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 94 Then
                    fosfa = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    trigli = True
                End If
            Next i

            If (trigli = False) Then
                Dim xItem4 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem4.ID_CODIGO_FONASA = 138
                xItem4.CF_DESC = "Trigliceridos"
                xItem4.TOTAL_ATE = perfiles_lipidicos
                xItem4.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem4.SECC_ORDEN = 51
                xItem4.CF_COD = "1027"

                Data_Exam.Add(xItem4)
            End If

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If
            If (fosfa = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 94
                xItem.CF_DESC = "Fosfatasas Alcalinas"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1010"

                Data_Exam.Add(xItem)
            End If
            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If

            'ORDENARRRRRRRRR
            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
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
        xls.SetCellValue(1, 1, "Censo REM 18")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If
            'Data_Exam(xi).ID_CODIGO_FONASA <> 676 And 'Test de tolerancia a la glucosa
            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 103 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 141 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 66 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 558 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 138 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 463 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 57 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 94 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 136 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 137 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function Gen_Excel_Agrupado_VALIDADOS(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String, ByVal ID_PREVE As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta
        Dim ID_CODIGO_FONASAA As Long = ID_CODIGO_FONASA
        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        'Realizar Consulta
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS_WITH_ID_PREVE(ID_CODIGO_FONASAA, Date01, Date02, ID_PREVE)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            Dim fosfa As Boolean = False
            Dim trigli As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido uricoS
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 94 Then
                    fosfa = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    trigli = True
                End If



            Next i

            If (fosfa = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 94
                xItem.CF_DESC = "Fosfatasas Alcalinas"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1010"

                Data_Exam.Add(xItem)
            End If
            If (trigli = False) Then
                Dim xItem4 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem4.ID_CODIGO_FONASA = 138
                xItem4.CF_DESC = "Trigliceridos"
                xItem4.TOTAL_ATE = perfiles_lipidicos
                xItem4.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem4.SECC_ORDEN = 51
                xItem4.CF_COD = "1027"

                Data_Exam.Add(xItem4)
            End If
            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If
            'ORDENARRRRRRRRR

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
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
        xls.SetCellValue(1, 1, "Censo REM18 VALIDADOS")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If
            'Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 676 And 'Test de tolerancia a la glucosa
            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 103 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 141 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 66 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 558 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 138 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 463 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 57 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 94 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 136 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 137 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function Ordenar_REEEEE(ByVal List_In As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim List_Out As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Depurar!!!
        Debug.WriteLine("Lista entrada")
        For y = 0 To (List_In.Count - 1)
            Debug.WriteLine(List_In(y).SECC_ORDEN & " -- " & List_In(y).ID_CODIGO_FONASA & " -> " & List_In(y).CF_DESC)
        Next

        'Hacer una lista con los elementos estos en orden
        Dim memory_yeah As Integer = 0
        While (List_In.Count > 0)
            'Buscar el numero más alto
            Dim memory_Max As Integer = -1
            For y = 0 To (List_In.Count - 1)
                If (List_In(y).SECC_ORDEN > memory_Max) Then
                    memory_Max = List_In(y).SECC_ORDEN
                End If
            Next y
            memory_yeah = memory_Max + 1

            'Buscar más bajo
            Dim i As Integer = 0
            For y = 0 To (List_In.Count - 1)
                If (List_In(y).SECC_ORDEN < memory_yeah) Then
                    memory_yeah = List_In(y).SECC_ORDEN
                    i = y
                End If
            Next y

            'Mover elemento al otro lado
            List_Out.Add(List_In(i))
            List_In.RemoveAt(i)
        End While

        Return List_Out
    End Function
End Class