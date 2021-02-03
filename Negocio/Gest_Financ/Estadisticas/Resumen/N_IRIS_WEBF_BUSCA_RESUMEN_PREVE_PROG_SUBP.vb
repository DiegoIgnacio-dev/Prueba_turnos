Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports ASPPDFLib
Public Class N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
    Inherits System.Web.UI.Page
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
    End Sub
    Function PDFF(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer,
                                     ByVal SUBP As Integer) As String


        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)



        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP(DESDE, HASTA, PROC, PREV, PROG, SUBP)

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
        DOC.Title = "Resumen Procedencia Previsión Programa"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0

        For x = 0 To Data_DTT.Count - 1
            TOT_VAL += Data_DTT(x).TOT_VAL
        Next

        For x = 0 To Data_DTT.Count - 1
            TOT_ATE += Data_DTT(x).TOT_ATE
        Next

        For x = 0 To Data_DTT.Count - 1
            TOT_CF += Data_DTT(x).TOT_CF
        Next

        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Resumen Prev-Prog-Subp desde " & DESDE & " al " & HASTA, STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & TOT_CF & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                .DrawText("Procedencia", STR_PARAM(45, 720, 50, "left", 9), FONT_2)
                .DrawText("Previsión", STR_PARAM(155, 720, 80, "left", 9), FONT_2)
                .DrawText("Programa", STR_PARAM(340, 720, 40, "left", 9), FONT_2)
                .DrawText("Atenciones", STR_PARAM(430, 720, 120, "left", 9), FONT_2)
                .DrawText("Exámenes", STR_PARAM(495, 720, 120, "left", 9), FONT_2)
                .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    If (Data_DTT(i).PREVE_DESC.Length > 43) Then
                        Data_DTT(i).PREVE_DESC = Data_DTT(i).PREVE_DESC.Substring(0, 43)
                    End If

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                    .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(45, eje_y, 130, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(155, eje_y, 185, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).PROGRA_DESC, STR_PARAM(340, eje_y, 140, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).TOT_ATE, STR_PARAM(430, eje_y, 40, "right", 7), FONT_1)
                    .DrawText(Data_DTT(i).TOT_CF, STR_PARAM(495, eje_y, 40, "right", 7), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).TOT_VAL)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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

                    If (Data_DTT(z).PREVE_DESC.Length > 43) Then
                        Data_DTT(z).PREVE_DESC = Data_DTT(z).PREVE_DESC.Substring(0, 43)
                    End If

                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Resumen Prev-Prog-Subp desde " & DESDE & " al " & HASTA, STR_PARAM(1, 780, 611, "center", 14), FONT_2)
                        .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & Data_DTT.Count & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)
                        '.DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                        .DrawText("Procedencia", STR_PARAM(45, 720, 50, "left", 9), FONT_2)
                        .DrawText("Previsión", STR_PARAM(155, 720, 80, "left", 9), FONT_2)
                        .DrawText("Programa", STR_PARAM(340, 720, 40, "left", 9), FONT_2)
                        .DrawText("Atenciones", STR_PARAM(430, 720, 120, "left", 9), FONT_2)
                        .DrawText("Exámenes", STR_PARAM(495, 720, 120, "left", 9), FONT_2)
                        .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                        .DrawText(Data_DTT(z).PROC_DESC, STR_PARAM(45, eje_y, 130, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).PREVE_DESC, STR_PARAM(155, eje_y, 185, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).PROGRA_DESC, STR_PARAM(340, eje_y, 140, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).TOT_ATE, STR_PARAM(430, eje_y, 40, "right", 7), FONT_1)
                        .DrawText(Data_DTT(z).TOT_CF, STR_PARAM(495, eje_y, 40, "right", 7), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(z).TOT_VAL)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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
                            .DrawText(Data_DTT(z).PROC_DESC, STR_PARAM(45, eje_y, 130, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).PREVE_DESC, STR_PARAM(155, eje_y, 185, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).PROGRA_DESC, STR_PARAM(340, eje_y, 140, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).TOT_ATE, STR_PARAM(430, eje_y, 40, "right", 7), FONT_1)
                            .DrawText(Data_DTT(z).TOT_CF, STR_PARAM(495, eje_y, 40, "right", 7), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(z).TOT_VAL)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP(DESDE, HASTA, PROC, PREV, PROG, SUBP)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2(DESDE, HASTA, PROC, PREV, PROG, SUBP)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR(DESDE, HASTA, PROC, PREV, PROG, SUBP, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO(DESDE, HASTA, 0, 0, PROG, SUBP, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR(DESDE, HASTA, 0, 0, PROG, SUBP, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS(DESDE, HASTA, 0, 0, PROG, SUBP, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_ATE_DET_ATE(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_ATE_DET_ATE(DESDE, HASTA, PROC, PREV, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, 0, 0, ID_USER, ATE_NUM)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_ID_ATE(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_ID_ATE(ID_ATENCION)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_MODAL(ByVal ATE_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_MODAL(ATE_NUM)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER, ID_ESTADO)
    End Function

    Function IRIS_WEBF_UPDATE_REVISION_DE_BONOS(ByVal ID_DET_ATE As Integer, ByVal ID_USER As Integer) As Integer





        Return DD_Data.IRIS_WEBF_UPDATE_REVISION_DE_BONOS(ID_DET_ATE, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2(DESDE, HASTA, 0, 0, PROG, SUBP, ID_USER)
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2_TDE(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)





        Return DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2_TDE(DESDE, HASTA, 0, 0, PROG, SUBP, ID_USER)
    End Function
    Function Gen_Excel(ByVal DOMAIN_URL As String,
                       ByVal DESDE As String,
                       ByVal HASTA As String,
                       ByVal PROC As Integer,
                       ByVal PREV As Integer,
                       ByVal PROG As Integer,
                       ByVal SUBP As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim Mx_Data(6, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2(DESDE, HASTA, PROC, PREV, PROG, SUBP)
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
            Mx_Data(0, y) = Data_Prev(y).PROC_DESC
            Mx_Data(1, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(2, y) = Data_Prev(y).PROGRA_DESC
            Mx_Data(3, y) = Data_Prev(y).SUB_PROGRA_DESC.ToUpper
            Mx_Data(4, y) = CInt(Data_Prev(y).TOT_ATE)
            Mx_Data(5, y) = CInt(Data_Prev(y).TOT_CF)
            Mx_Data(6, y) = CInt(Data_Prev(y).TOT_VAL)
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
        sl.RenameWorksheet("Sheet1", "Resumen Proc-Prev-Prog")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Procedencia - Previsión - Programa")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        'nombre columnas
        sl.SetCellValue("B7", "Procedencia")
        sl.SetCellValue("C7", "Previsión")
        sl.SetCellValue("D7", "Programa")
        sl.SetCellValue("E7", "Sub Programa")
        sl.SetCellValue("F7", "Total Atenciones")
        sl.SetCellValue("G7", "Total Exámenes")
        sl.SetCellValue("H7", "Total Valor")
        For y = 2 To 8
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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("E")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("H")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        'For i = Asc("E") To Asc("G")
        '    sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
        '    'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        'Next i
        'estilo totales
        For i = Asc("B") To Asc("H")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        'sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Resumen P-P-P" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_scr(ByVal DOMAIN_URL As String,
                       ByVal DESDE As String,
                       ByVal HASTA As String,
                       ByVal PROC As Integer,
                       ByVal PREV As Integer,
                       ByVal PROG As Integer,
                       ByVal SUBP As Integer,
                           ByVal ID_USER As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim Mx_Data(6, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR(DESDE, HASTA, PROC, PREV, PROG, SUBP, ID_USER)
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
            Mx_Data(0, y) = Data_Prev(y).PROC_DESC
            Mx_Data(1, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(2, y) = Data_Prev(y).PROGRA_DESC
            Mx_Data(3, y) = Data_Prev(y).SUB_PROGRA_DESC.ToUpper
            Mx_Data(4, y) = CInt(Data_Prev(y).TOT_ATE)
            Mx_Data(5, y) = CInt(Data_Prev(y).TOT_CF)
            Mx_Data(6, y) = CInt(Data_Prev(y).TOT_VAL)
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
        sl.RenameWorksheet("Sheet1", "Resumen Proc-Prev-Prog")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Procedencia - Previsión - Programa")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        'nombre columnas
        sl.SetCellValue("B7", "Procedencia")
        sl.SetCellValue("C7", "Previsión")
        sl.SetCellValue("D7", "Programa")
        sl.SetCellValue("E7", "Sub Programa")
        sl.SetCellValue("F7", "Total Atenciones")
        sl.SetCellValue("G7", "Total Exámenes")
        sl.SetCellValue("H7", "Total Valor")
        For y = 2 To 8
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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("E")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("H")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        'For i = Asc("E") To Asc("G")
        '    sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
        '    'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        'Next i
        'estilo totales
        For i = Asc("B") To Asc("H")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        'sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Resumen P-P-P" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_scr_2(ByVal DOMAIN_URL As String,
                     ByVal DESDE As String,
                     ByVal HASTA As String,
                     ByVal PROC As Integer,
                     ByVal PREV As Integer,
                     ByVal PROG As Integer,
                     ByVal SUBP As Integer,
                         ByVal ID_USER As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim Mx_Data(8, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2(DESDE, HASTA, PROC, PREV, PROG, SUBP, ID_USER)
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
            Mx_Data(2, y) = Format(Data_Prev(y).ATE_FECHA, "dd-MM-yyyy HH:mm")
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PROC_DESC
            Mx_Data(5, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(6, y) = Data_Prev(y).USU_NIC
            Mx_Data(7, y) = Data_Prev(y).TP_PAGO_DESC
            Mx_Data(8, y) = CInt(Data_Prev(y).TOT_VAL)
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
        sl.RenameWorksheet("Sheet1", "Secretaria Resumen Atenciones")
        'titulo de la tabla
        sl.SetCellValue("B2", "Secretaria Resumen Atenciones")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        sl.SetCellValue("B4", "Usuario: " & Data_Prev(0).USU_NIC)
        'nombre columnas
        sl.SetCellValue("B7", "#")
        sl.SetCellValue("C7", "Ate Num")
        sl.SetCellValue("D7", "Fecha Ate")
        sl.SetCellValue("E7", "Pac Nombre")
        sl.SetCellValue("F7", "Procedencia")
        sl.SetCellValue("G7", "Previsión")
        sl.SetCellValue("H7", "Usuario")
        sl.SetCellValue("I7", "T.Pago")
        sl.SetCellValue("J7", "Total")
        For y = 2 To 10
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y

        sl.SetColumnWidth(2, 10.0)
        ltabla += 7

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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("E")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("J")
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
        For i = Asc("B") To Asc("J")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("J" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Resumen_Secre_Ate_Usu" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function PDFF_2(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As String


        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)



        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2(DESDE, HASTA, PROC, PREV, 0, 0, ID_USER)

        If (Data_DTT.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Secretaria_Resumen_Atenciones" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Secretaria Resumen Atenciones"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0

        For x = 0 To Data_DTT.Count - 1
            TOT_VAL += Data_DTT(x).TOT_VAL
        Next

        For x = 0 To Data_DTT.Count - 1
            TOT_ATE += Data_DTT(x).TOT_ATE
        Next

        For x = 0 To Data_DTT.Count - 1
            TOT_CF += Data_DTT(x).TOT_CF
        Next

        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Secretaria Resumen Atenciones desde " & DESDE & " al " & HASTA, STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Atenciones: " & Data_DTT.Count & " - Usuario: " & Data_DTT(0).USU_NIC & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Ate Num", STR_PARAM(45, 720, 50, "left", 8), FONT_2)
                .DrawText("Fecha Ate", STR_PARAM(85, 720, 80, "left", 8), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(140, 720, 80, "left", 8), FONT_2)
                .DrawText("Procedencia", STR_PARAM(320, 720, 120, "left", 8), FONT_2)
                .DrawText("Previsión", STR_PARAM(420, 720, 120, "left", 8), FONT_2)
                .DrawText("T. Pago", STR_PARAM(500, 720, 40, "left", 8), FONT_2)
                .DrawText("Valor", STR_PARAM(530, 720, 40, "right", 8), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    If (Data_DTT(i).PREVE_DESC.Length > 43) Then
                        Data_DTT(i).PREVE_DESC = Data_DTT(i).PREVE_DESC.Substring(0, 43)
                    End If

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                    .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(140, eje_y, 140, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(320, eje_y, 120, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(420, eje_y, 120, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).TP_PAGO_DESC, STR_PARAM(500, eje_y, 40, "left", 6), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).TOT_VAL)).ToString("#,##0"), STR_PARAM(530, eje_y, 40, "right", 6), FONT_1)
                    .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)

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

                    If (Data_DTT(z).PREVE_DESC.Length > 43) Then
                        Data_DTT(z).PREVE_DESC = Data_DTT(z).PREVE_DESC.Substring(0, 43)
                    End If

                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Secretaria Resumen Atenciones desde " & DESDE & " al " & HASTA, STR_PARAM(1, 780, 611, "center", 14), FONT_2)
                        .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & Data_DTT.Count & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)
                        '.DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Ate Num", STR_PARAM(45, 720, 50, "left", 8), FONT_2)
                        .DrawText("Fecha Ate", STR_PARAM(85, 720, 80, "left", 8), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(140, 720, 80, "left", 8), FONT_2)
                        .DrawText("Procedencia", STR_PARAM(320, 720, 120, "left", 8), FONT_2)
                        .DrawText("Previsión", STR_PARAM(420, 720, 120, "left", 8), FONT_2)
                        .DrawText("T. Pago", STR_PARAM(500, 720, 40, "left", 8), FONT_2)
                        .DrawText("Valor", STR_PARAM(530, 720, 40, "right", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                        .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(140, eje_y, 140, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(320, eje_y, 120, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(420, eje_y, 120, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).TP_PAGO_DESC, STR_PARAM(500, eje_y, 40, "left", 6), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(i).TOT_VAL)).ToString("#,##0"), STR_PARAM(530, eje_y, 40, "right", 6), FONT_1)
                        .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
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
                            .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                            .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                            .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(140, eje_y, 140, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(320, eje_y, 120, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(420, eje_y, 120, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).TP_PAGO_DESC, STR_PARAM(500, eje_y, 40, "left", 6), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(i).TOT_VAL)).ToString("#,##0"), STR_PARAM(530, eje_y, 40, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
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
    Function Gen_Excel_scr_2_by_Exam(ByVal DOMAIN_URL As String,
                  ByVal DESDE As String,
                  ByVal HASTA As String,
                  ByVal PROC As Integer,
                  ByVal PREV As Integer,
                  ByVal PROG As Integer,
                  ByVal SUBP As Integer,
                      ByVal ID_USER As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim Mx_Data(9, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2_TDE(DESDE, HASTA, PROC, PREV, PROG, SUBP, ID_USER)
        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(9, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(9, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).ATE_NUM
            Mx_Data(2, y) = Format(Data_Prev(y).ATE_FECHA, "dd-MM-yyyy HH:mm")
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PROC_DESC
            Mx_Data(5, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(6, y) = Data_Prev(y).USU_NIC
            Mx_Data(7, y) = Data_Prev(y).CF_DESC
            Mx_Data(8, y) = Data_Prev(y).TP_PAGO_DESC
            Mx_Data(9, y) = CInt(Data_Prev(y).CF_PRECIO_AMB)
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
        sl.RenameWorksheet("Sheet1", "Secretaria Resumen Atenciones")
        'titulo de la tabla
        sl.SetCellValue("B2", "Secretaria Resumen Atenciones-Exámenes")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        sl.SetCellValue("B4", "Usuario: " & Data_Prev(0).USU_NIC)
        'nombre columnas
        sl.SetCellValue("B7", "#")
        sl.SetCellValue("C7", "Ate Num")
        sl.SetCellValue("D7", "Fecha Ate")
        sl.SetCellValue("E7", "Pac Nombre")
        sl.SetCellValue("F7", "Procedencia")
        sl.SetCellValue("G7", "Previsión")
        sl.SetCellValue("H7", "Usuario")
        sl.SetCellValue("I7", "Examen")
        sl.SetCellValue("J7", "T. Pago")
        sl.SetCellValue("K7", "Total")
        For y = 2 To 11
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y

        sl.SetColumnWidth(2, 10.0)

        sl.SetColumnWidth("I", 30.0)

        ltabla += 7

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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("E")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("K")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("K") To Asc("K")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("B") To Asc("K")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("K" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Resumen_Secre_Ate_Usu" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function PDFF_2_by_Exam(ByVal DOMAIN_URL As String,
                                   ByVal DESDE As String,
                                          ByVal HASTA As String,
                                          ByVal PROC As Integer,
                                          ByVal PREV As Integer,
                                          ByVal PROG As Integer,
                                          ByVal SUBP As Integer,
                                          ByVal ID_USER As Integer) As String


        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)



        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2_TDE(DESDE, HASTA, PROC, PREV, 0, 0, ID_USER)

        If (Data_DTT.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Secretaria_Resumen_Atenciones" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Secretaria Resumen Atenciones"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0

        For x = 0 To Data_DTT.Count - 1
            TOT_VAL += Data_DTT(x).CF_PRECIO_AMB

            If (x > 0) Then
                If Data_DTT(x).ID_ATENCION <> Data_DTT(x - 1).ID_ATENCION Then
                    TOT_ATE = TOT_ATE + 1
                End If
            ElseIf (x = 0) Then
                TOT_ATE = TOT_ATE + 1
            End If


        Next

        For x = 0 To Data_DTT.Count - 1
            TOT_CF += Data_DTT(x).TOT_CF
        Next

        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Secretaria Resumen Atenciones desde " & DESDE & " al " & HASTA, STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Atenciones: " & TOT_ATE & " Total Exámenes: " & Data_DTT.Count & " - Usuario: " & Data_DTT(0).USU_NIC & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 10), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Ate Num", STR_PARAM(45, 720, 50, "left", 8), FONT_2)
                .DrawText("Fecha Ate", STR_PARAM(85, 720, 80, "left", 8), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(130, 720, 80, "left", 8), FONT_2)
                .DrawText("Procedencia", STR_PARAM(280, 720, 120, "left", 8), FONT_2)
                .DrawText("Previsión", STR_PARAM(340, 720, 120, "left", 8), FONT_2)
                .DrawText("Examen", STR_PARAM(390, 720, 40, "left", 8), FONT_2)
                .DrawText("T.Pago", STR_PARAM(520, 720, 40, "left", 8), FONT_2)
                .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 8), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    If (Data_DTT(i).PREVE_DESC.Length > 43) Then
                        Data_DTT(i).PREVE_DESC = Data_DTT(i).PREVE_DESC.Substring(0, 43)
                    End If

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                    .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 140, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(280, eje_y, 120, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(340, eje_y, 120, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(390, eje_y, 130, "left", 6), FONT_1)
                    .DrawText(Data_DTT(i).TP_PAGO_DESC, STR_PARAM(520, eje_y, 120, "left", 6), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).CF_PRECIO_AMB)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 6), FONT_1)
                    .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)

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

                    If (Data_DTT(z).PREVE_DESC.Length > 43) Then
                        Data_DTT(z).PREVE_DESC = Data_DTT(z).PREVE_DESC.Substring(0, 43)
                    End If

                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Secretaria Resumen Atenciones desde " & DESDE & " al " & HASTA, STR_PARAM(1, 780, 611, "center", 14), FONT_2)
                        .DrawText("Total Atenciones: " & TOT_ATE & "Total Exámenes: " & Data_DTT.Count & " - Usuario: " & Data_DTT(0).USU_NIC & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 10), FONT_2)
                        '.DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Ate Num", STR_PARAM(45, 720, 50, "left", 8), FONT_2)
                        .DrawText("Fecha Ate", STR_PARAM(85, 720, 80, "left", 8), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(130, 720, 80, "left", 8), FONT_2)
                        .DrawText("Procedencia", STR_PARAM(280, 720, 120, "left", 8), FONT_2)
                        .DrawText("Previsión", STR_PARAM(340, 720, 120, "left", 8), FONT_2)
                        .DrawText("Examen", STR_PARAM(390, 720, 40, "left", 8), FONT_2)
                        .DrawText("T.Pago", STR_PARAM(520, 720, 40, "left", 8), FONT_2)
                        .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                        .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 140, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(280, eje_y, 120, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(340, eje_y, 120, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(390, eje_y, 130, "left", 6), FONT_1)
                        .DrawText(Data_DTT(i).TP_PAGO_DESC, STR_PARAM(520, eje_y, 120, "left", 6), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(i).CF_PRECIO_AMB)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 6), FONT_1)
                        .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
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
                            .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                            .DrawText(Data_DTT(i).ATE_NUM, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                            .DrawText(Format(Data_DTT(i).ATE_FECHA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).PAC_NOMBRE & " " & Data_DTT(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 140, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).PROC_DESC, STR_PARAM(280, eje_y, 120, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).PREVE_DESC, STR_PARAM(340, eje_y, 120, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(390, eje_y, 130, "left", 6), FONT_1)
                            .DrawText(Data_DTT(i).TP_PAGO_DESC, STR_PARAM(520, eje_y, 120, "left", 6), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(i).CF_PRECIO_AMB)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If

        'End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_Excel_Dual_Copago(ByVal DOMAIN_URL As String,
                   ByVal DESDE As String,
                   ByVal HASTA As String,
                   ByVal PROC As Integer,
                   ByVal PREV As Integer,
                   ByVal PROG As Integer,
                   ByVal SUBP As Integer,
                       ByVal ID_USER As Integer) As String
        'Declaraciones Generales
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim Mx_Data(16, 0) As Object
        'Realizar Consulta
        Data_Prev = DD_Data.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS(DESDE, HASTA, PROC, PREV, PROG, SUBP, ID_USER)
        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(16, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        Dim tot_copa As Integer = 0
        Dim tot_parti As Integer = 0

        For i = 0 To Data_Prev.Count - 1
            tot_copa += CInt(Data_Prev(i).REL_MONTO_COPAGO_1) + CInt(Data_Prev(i).REL_MONTO_COPAGO_1)
            tot_parti += CInt(Data_Prev(i).REL_MONTO_PARTICULAR)
        Next i

        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(16, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).ATE_NUM
            Mx_Data(2, y) = Format(Data_Prev(y).ATE_FECHA, "dd-MM-yyyy HH:mm")
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PROC_DESC
            Mx_Data(5, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(6, y) = Data_Prev(y).USU_NIC

            If Data_Prev(y).REL_MONTO_COPAGO_1 = "0" Then
                Mx_Data(7, y) = "-/-"
            Else
                If Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 1 Then
                    Mx_Data(7, y) = "Efectivo"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 2 Then
                    Mx_Data(7, y) = "Cheque"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 3 Then
                    Mx_Data(7, y) = "Pendiente"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 4 Then
                    Mx_Data(7, y) = "Bono"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 5 Then
                    Mx_Data(7, y) = "Bono Electronico"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 10 Then
                    Mx_Data(7, y) = "Tarjeta"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 11 Then
                    Mx_Data(7, y) = "Sin Costo"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 18 Then
                    Mx_Data(7, y) = "Abono"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 19 Then
                    Mx_Data(7, y) = "Convenio"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_1 = 20 Then
                    Mx_Data(7, y) = "Transferencia"
                End If
            End If

            Mx_Data(8, y) = CInt(Data_Prev(y).REL_MONTO_COPAGO_1)

            If Data_Prev(y).REL_MONTO_COPAGO_2 = "0" Then
                Mx_Data(9, y) = "-"
            Else
                If Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 1 Then
                    Mx_Data(9, y) = "Efectivo"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 2 Then
                    Mx_Data(9, y) = "Cheque"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 3 Then
                    Mx_Data(9, y) = "Pendiente"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 4 Then
                    Mx_Data(9, y) = "Bono"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 5 Then
                    Mx_Data(9, y) = "Bono Electronico"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 10 Then
                    Mx_Data(9, y) = "Tarjeta"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 11 Then
                    Mx_Data(9, y) = "Sin Costo"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 18 Then
                    Mx_Data(9, y) = "Abono"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 19 Then
                    Mx_Data(9, y) = "Convenio"
                ElseIf Data_Prev(y).ID_TP_PAGO_COPAGO_2 = 20 Then
                    Mx_Data(9, y) = "Transferencia"
                End If
            End If

            Mx_Data(10, y) = CInt(Data_Prev(y).REL_MONTO_COPAGO_2)

            If Data_Prev(y).REL_MONTO_PARTICULAR = "0" Then
                Mx_Data(11, y) = "-"
            Else
                If Data_Prev(y).ID_TP_PAGO_PARTICULAR = 1 Then
                    Mx_Data(11, y) = "Efectivo"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 2 Then
                    Mx_Data(11, y) = "Cheque"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 3 Then
                    Mx_Data(11, y) = "Pendiente"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 4 Then
                    Mx_Data(11, y) = "Bono"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 5 Then
                    Mx_Data(11, y) = "Bono Electronico"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 10 Then
                    Mx_Data(11, y) = "Tarjeta"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 11 Then
                    Mx_Data(11, y) = "Sin Costo"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 18 Then
                    Mx_Data(11, y) = "Abono"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 19 Then
                    Mx_Data(11, y) = "Convenio"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR = 20 Then
                    Mx_Data(11, y) = "Transferencia"
                End If
            End If

            Mx_Data(12, y) = CInt(Data_Prev(y).REL_MONTO_PARTICULAR)

            If Data_Prev(y).REL_MONTO_PARTICULAR_2 = "0" Then
                Mx_Data(13, y) = "-"
            Else
                If Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 1 Then
                    Mx_Data(13, y) = "Efectivo"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 2 Then
                    Mx_Data(13, y) = "Cheque"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 3 Then
                    Mx_Data(13, y) = "Pendiente"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 4 Then
                    Mx_Data(13, y) = "Bono"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 5 Then
                    Mx_Data(13, y) = "Bono Electronico"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 10 Then
                    Mx_Data(13, y) = "Tarjeta"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 11 Then
                    Mx_Data(13, y) = "Sin Costo"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 18 Then
                    Mx_Data(13, y) = "Abono"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 19 Then
                    Mx_Data(13, y) = "Convenio"
                ElseIf Data_Prev(y).ID_TP_PAGO_PARTICULAR_2 = 20 Then
                    Mx_Data(13, y) = "Transferencia"
                End If
            End If

            Mx_Data(14, y) = CInt(Data_Prev(y).REL_MONTO_PARTICULAR_2)
            Mx_Data(15, y) = CInt(Data_Prev(y).ATE_V_BENEF)


            Mx_Data(16, y) = CInt(Data_Prev(y).REL_MONTO_COPAGO_1 + CInt(Data_Prev(y).REL_MONTO_COPAGO_2) + CInt(Data_Prev(y).REL_MONTO_PARTICULAR) + CInt(Data_Prev(y).REL_MONTO_PARTICULAR_2) + CInt(Data_Prev(y).ATE_V_BENEF))
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
        sl.RenameWorksheet("Sheet1", "Secretaria Resumen Atenciones Copago/Particular")
        'titulo de la tabla
        sl.SetCellValue("B2", "Secretaria Resumen Atenciones Copago/Particular")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        sl.SetCellValue("B4", "Usuario: " & Data_Prev(0).USU_NIC)
        'nombre columnas
        sl.SetCellValue("B7", "#")
        sl.SetCellValue("C7", "Ate Num")
        sl.SetCellValue("D7", "Fecha Ate")
        sl.SetCellValue("E7", "Pac Nombre")
        sl.SetCellValue("F7", "Procedencia")
        sl.SetCellValue("G7", "Previsión")
        sl.SetCellValue("H7", "Usuario")
        sl.SetCellValue("I7", "FP. Copago 1")
        sl.SetCellValue("J7", "Total Copago 1")
        sl.SetCellValue("K7", "FP. Copago 2")
        sl.SetCellValue("L7", "Total Copago 2")
        sl.SetCellValue("M7", "FP. Particular 1")
        sl.SetCellValue("N7", "Total Particular 1")
        sl.SetCellValue("O7", "FP. Particular 2")
        sl.SetCellValue("P7", "Total Particular 2")
        sl.SetCellValue("Q7", "Descuentos")
        sl.SetCellValue("R7", "TOTAL")
        For y = 2 To 18
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y

        sl.SetColumnWidth(2, 10.0)
        ltabla += 7

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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("6")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("6")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("J") To Asc("J")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        For i = Asc("L") To Asc("L")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        For i = Asc("N") To Asc("N")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        For i = Asc("P") To Asc("R")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("B") To Asc("O")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("R" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Resumen_Secre_Ate_Usu_Caja" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function PDFF_DUAL_COPA(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS(DESDE, HASTA, PROC, PREV, 0, 0, ID_USER)

        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Secretaria_Resumen_Atenciones_Caja" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = System.Web.HttpContext.Current.Server.CreateObject("Persits.Pdf")
        DOC.Title = "Secretaria Resumen Atenciones Copago/Particular"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        Dim eje_y As Integer = 85

        Dim contador_filas As Integer = 1

        Dim zz As Integer
        Dim z As Integer
        Dim xxx As Integer

        eje_y = 85

        Dim fuck = DOC.Pages.Add(612, 792)

        With fuck.Canvas
            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


            .SetFillColor(0, 0, 0)
            .DrawText("Secretaria Resumen Atenciones Copago/Particular", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)
            .DrawText("Usuario: " & Data_Prev(0).USU_NIC, STR_PARAM_2(40, 500, 396, "left", 11, 90), FONT_2)

            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 8, 90), FONT_2)
            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 8, 90), FONT_2)
            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 8, 90), FONT_2)
            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 8, 90), FONT_2)
            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 8, 90), FONT_2)
            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 8, 90), FONT_2)
            .DrawText("FP. Copago 1", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
            .DrawText("T. Copago 1", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
            .DrawText("FP. Copago 2", STR_PARAM_2(70, 385, 50, "left", 7, 90), FONT_2)
            .DrawText("T. Copago 2", STR_PARAM_2(70, 435, 60, "left", 7, 90), FONT_2)
            .DrawText("FP. Particular 1", STR_PARAM_2(70, 480, 50, "left", 7, 90), FONT_2)
            .DrawText("T. Particular 1", STR_PARAM_2(70, 540, 70, "left", 7, 90), FONT_2)
            .DrawText("FP. Particular 2", STR_PARAM_2(70, 600, 70, "left", 7, 90), FONT_2)
            .DrawText("T. Particular 2", STR_PARAM_2(70, 660, 70, "left", 7, 90), FONT_2)
            .DrawText("T. Descuentos", STR_PARAM_2(70, 710, 70, "left", 7, 90), FONT_2)
            .DrawText("TOTAL", STR_PARAM_2(70, 755, 35, "left", 8, 90), FONT_2)

            For z = 0 To Data_Prev.Count - 1

                If contador_filas < 31 Then

                    .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                    .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                    .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_COPAGO_1 = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1)).ToString("#,##0"), STR_PARAM_2(eje_y, 340, 60, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_COPAGO_2 = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 435, 60, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_PARTICULAR = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 480, 20, "center", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_PARTICULAR = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR)).ToString("#,##0"), STR_PARAM_2(eje_y, 540, 100, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_PARTICULAR_2 = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 660, 100, "left", 6, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 710, 100, "left", 6, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1) + Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2) + Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 755, 50, "left", 6, 90), FONT_2)


                    eje_y = eje_y + 17
                    contador_filas += 1
                    zz += 1
                    If zz = 30 And Data_Prev.Count > 30 Then

                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If
                Else

                    If zz = 32 Then
                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If

                    With fuck.Canvas

                        If xxx = 1 Then
                            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


                            .SetFillColor(0, 0, 0)
                            .DrawText("Secretaria Resumen Atenciones Copago/Particular", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
                            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)
                            .DrawText("Usuario: " & Data_Prev(0).USU_NIC, STR_PARAM_2(40, 500, 396, "left", 11, 90), FONT_2)

                            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 8, 90), FONT_2)
                            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 8, 90), FONT_2)
                            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 8, 90), FONT_2)
                            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 8, 90), FONT_2)
                            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 8, 90), FONT_2)
                            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 8, 90), FONT_2)
                            .DrawText("FP. Copago 1", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
                            .DrawText("T. Copago 1", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
                            .DrawText("FP. Copago 2", STR_PARAM_2(70, 385, 50, "left", 7, 90), FONT_2)
                            .DrawText("T. Copago 2", STR_PARAM_2(70, 435, 60, "left", 7, 90), FONT_2)
                            .DrawText("FP. Particular 1", STR_PARAM_2(70, 480, 50, "left", 7, 90), FONT_2)
                            .DrawText("T. Particular 1", STR_PARAM_2(70, 540, 70, "left", 7, 90), FONT_2)
                            .DrawText("FP. Particular 2", STR_PARAM_2(70, 600, 70, "left", 7, 90), FONT_2)
                            .DrawText("T. Particular 2", STR_PARAM_2(70, 660, 70, "left", 7, 90), FONT_2)
                            .DrawText("T. Descuentos", STR_PARAM_2(70, 710, 70, "left", 7, 90), FONT_2)
                            .DrawText("TOTAL", STR_PARAM_2(70, 755, 35, "left", 8, 90), FONT_2)
                            xxx = 0
                        End If

                        .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                        .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                        .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_COPAGO_1 = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1)).ToString("#,##0"), STR_PARAM_2(eje_y, 340, 60, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_COPAGO_2 = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 435, 60, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_PARTICULAR = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 480, 20, "center", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_PARTICULAR = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR)).ToString("#,##0"), STR_PARAM_2(eje_y, 540, 100, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_PARTICULAR_2 = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 660, 100, "left", 6, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 710, 100, "left", 6, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1) + Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2) + Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 755, 50, "left", 6, 90), FONT_2)



                        eje_y = eje_y + 17
                        contador_filas += 1
                        zz += 1
                    End With
                End If
            Next z
        End With
        'End If
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function PDFF_DUAL_COPA_GLOB(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer,
                                            ByVal ID_USER As Integer) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS(DESDE, HASTA, PROC, PREV, 0, 0, ID_USER)

        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Secretaria_Resumen_Atenciones_Caja" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = System.Web.HttpContext.Current.Server.CreateObject("Persits.Pdf")
        DOC.Title = "Secretaria Resumen Atenciones Copago/Particular"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        Dim eje_y As Integer = 85

        Dim contador_filas As Integer = 1

        Dim zz As Integer
        Dim z As Integer
        Dim xxx As Integer

        eje_y = 85

        Dim fuck = DOC.Pages.Add(612, 792)

        With fuck.Canvas
            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


            .SetFillColor(0, 0, 0)
            .DrawText("Secretaria Resumen Atenciones Copago/Particular", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)
            .DrawText("Usuario: " & Data_Prev(0).USU_NIC, STR_PARAM_2(40, 500, 396, "left", 11, 90), FONT_2)

            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 8, 90), FONT_2)
            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 8, 90), FONT_2)
            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 8, 90), FONT_2)
            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 8, 90), FONT_2)
            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 8, 90), FONT_2)
            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 8, 90), FONT_2)
            .DrawText("FP. Copago 1", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
            .DrawText("T. Copago 1", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
            .DrawText("FP. Copago 2", STR_PARAM_2(70, 385, 50, "left", 7, 90), FONT_2)
            .DrawText("T. Copago 2", STR_PARAM_2(70, 435, 60, "left", 7, 90), FONT_2)
            .DrawText("FP. Particular 1", STR_PARAM_2(70, 480, 50, "left", 7, 90), FONT_2)
            .DrawText("T. Particular 1", STR_PARAM_2(70, 540, 70, "left", 7, 90), FONT_2)
            .DrawText("FP. Particular 2", STR_PARAM_2(70, 600, 70, "left", 7, 90), FONT_2)
            .DrawText("T. Particular 2", STR_PARAM_2(70, 660, 70, "left", 7, 90), FONT_2)
            .DrawText("T. Descuentos", STR_PARAM_2(70, 710, 70, "left", 7, 90), FONT_2)
            .DrawText("TOTAL", STR_PARAM_2(70, 755, 35, "left", 8, 90), FONT_2)

            For z = 0 To Data_Prev.Count - 1

                If contador_filas < 31 Then

                    .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                    .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                    .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_COPAGO_1 = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1)).ToString("#,##0"), STR_PARAM_2(eje_y, 340, 60, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_COPAGO_2 = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 435, 60, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_PARTICULAR = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 480, 20, "center", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_PARTICULAR = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR)).ToString("#,##0"), STR_PARAM_2(eje_y, 540, 100, "left", 6, 90), FONT_1)

                    If Data_Prev(z).REL_MONTO_PARTICULAR_2 = "0" Then
                        .DrawText("-/-", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                    Else
                        If Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 1 Then
                            .DrawText("Efectivo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 2 Then
                            .DrawText("Cheque", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 3 Then
                            .DrawText("Pendiente", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 4 Then
                            .DrawText("Bono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 5 Then
                            .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 10 Then
                            .DrawText("Tarjeta", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 11 Then
                            .DrawText("Sin Costo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 18 Then
                            .DrawText("Abono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 19 Then
                            .DrawText("Convenio", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 20 Then
                            .DrawText("Transferencia", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        End If
                    End If

                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 660, 100, "left", 6, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 710, 100, "left", 6, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1) + Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2) + Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 755, 50, "left", 6, 90), FONT_2)


                    eje_y = eje_y + 17
                    contador_filas += 1
                    zz += 1
                    If zz = 30 And Data_Prev.Count > 30 Then

                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If
                Else

                    If zz = 32 Then
                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If

                    With fuck.Canvas

                        If xxx = 1 Then
                            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


                            .SetFillColor(0, 0, 0)
                            .DrawText("Secretaria Resumen Atenciones Copago/Particular", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
                            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)
                            .DrawText("Usuario: " & Data_Prev(0).USU_NIC, STR_PARAM_2(40, 500, 396, "left", 11, 90), FONT_2)

                            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 8, 90), FONT_2)
                            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 8, 90), FONT_2)
                            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 8, 90), FONT_2)
                            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 8, 90), FONT_2)
                            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 8, 90), FONT_2)
                            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 8, 90), FONT_2)
                            .DrawText("FP. Copago 1", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
                            .DrawText("T. Copago 1", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
                            .DrawText("FP. Copago 2", STR_PARAM_2(70, 385, 50, "left", 7, 90), FONT_2)
                            .DrawText("T. Copago 2", STR_PARAM_2(70, 435, 60, "left", 7, 90), FONT_2)
                            .DrawText("FP. Particular 1", STR_PARAM_2(70, 480, 50, "left", 7, 90), FONT_2)
                            .DrawText("T. Particular 1", STR_PARAM_2(70, 540, 70, "left", 7, 90), FONT_2)
                            .DrawText("FP. Particular 2", STR_PARAM_2(70, 600, 70, "left", 7, 90), FONT_2)
                            .DrawText("T. Particular 2", STR_PARAM_2(70, 660, 70, "left", 7, 90), FONT_2)
                            .DrawText("T. Descuentos", STR_PARAM_2(70, 710, 70, "left", 7, 90), FONT_2)
                            .DrawText("TOTAL", STR_PARAM_2(70, 755, 35, "left", 8, 90), FONT_2)
                            xxx = 0
                        End If

                        .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                        .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                        .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_COPAGO_1 = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_1 = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 295, 30, "left", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1)).ToString("#,##0"), STR_PARAM_2(eje_y, 340, 60, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_COPAGO_2 = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_COPAGO_2 = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 385, 30, "left", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 435, 60, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_PARTICULAR = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 480, 20, "center", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_PARTICULAR = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 480, 30, "center", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR)).ToString("#,##0"), STR_PARAM_2(eje_y, 540, 100, "left", 6, 90), FONT_1)

                        If Data_Prev(z).REL_MONTO_PARTICULAR_2 = "0" Then
                            .DrawText("-/-", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                        Else
                            If Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 1 Then
                                .DrawText("Efectivo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 2 Then
                                .DrawText("Cheque", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 3 Then
                                .DrawText("Pendiente", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 4 Then
                                .DrawText("Bono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 5 Then
                                .DrawText("Bono Electrónico", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 10 Then
                                .DrawText("Tarjeta", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 11 Then
                                .DrawText("Sin Costo", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 18 Then
                                .DrawText("Abono", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 19 Then
                                .DrawText("Convenio", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            ElseIf Data_Prev(z).ID_TP_PAGO_PARTICULAR_2 = 20 Then
                                .DrawText("Transferencia", STR_PARAM_2(eje_y, 600, 20, "center", 6, 90), FONT_1)
                            End If
                        End If

                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2)).ToString("#,##0"), STR_PARAM_2(eje_y, 660, 100, "left", 6, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 710, 100, "left", 6, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_1) + Integer.Parse(Data_Prev(z).REL_MONTO_COPAGO_2) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR) + Integer.Parse(Data_Prev(z).REL_MONTO_PARTICULAR_2) + Integer.Parse(Data_Prev(z).ATE_V_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 755, 50, "left", 6, 90), FONT_2)



                        eje_y = eje_y + 17
                        contador_filas += 1
                        zz += 1
                    End With
                End If
            Next z
        End With
        'End If
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function PDFF_DUAL_COPA_MED(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String, ByVal search_mode As Integer, ByVal TP_PAGO As Integer,
                                            ByVal ID_ESTADO As Integer) As String


        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        If (search_mode = 0) Then
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, PROC, PREV, ID_USER, ATE_NUM)
            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If
                Next i
            Else
                Return Nothing
            End If
        Else
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER, ID_ESTADO)

            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If

                Next i
            Else
                Return Nothing
            End If
        End If

        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Revision_Multiple" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = System.Web.HttpContext.Current.Server.CreateObject("Persits.Pdf")
        DOC.Title = "Revisión Múltiple"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        Dim eje_y As Integer = 85

        Dim contador_filas As Integer = 1

        Dim zz As Integer
        Dim z As Integer
        Dim xxx As Integer

        eje_y = 85

        Dim fuck = DOC.Pages.Add(612, 792)

        With fuck.Canvas
            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


            .SetFillColor(0, 0, 0)
            .DrawText("Revisión Múltiple", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)

            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 7, 90), FONT_2)
            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 7, 90), FONT_2)
            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 7, 90), FONT_2)
            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 7, 90), FONT_2)
            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 7, 90), FONT_2)
            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 7, 90), FONT_2)
            .DrawText("Exámenes", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
            .DrawText("Cod. Fonasa", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
            .DrawText("F. Pago", STR_PARAM_2(70, 385, 60, "left", 6, 90), FONT_2)
            .DrawText("T. Atención", STR_PARAM_2(70, 415, 50, "left", 6, 90), FONT_2)
            .DrawText("V. Pagado", STR_PARAM_2(70, 450, 50, "left", 6, 90), FONT_2)
            .DrawText("Copago", STR_PARAM_2(70, 485, 70, "left", 6, 90), FONT_2)
            .DrawText("Particular", STR_PARAM_2(70, 510, 70, "left", 6, 90), FONT_2)
            .DrawText("Bonificación", STR_PARAM_2(70, 545, 70, "left", 6, 90), FONT_2)
            .DrawText("S. Complemen.", STR_PARAM_2(70, 585, 70, "left", 6, 90), FONT_2)
            .DrawText("Revisado", STR_PARAM_2(70, 630, 35, "left", 6, 90), FONT_2)
            .DrawText("Usu. Revisa.", STR_PARAM_2(70, 665, 35, "left", 6, 90), FONT_2)
            .DrawText("Órdenes", STR_PARAM_2(70, 705, 35, "left", 6, 90), FONT_2)

            For z = 0 To Data_Prev.Count - 1

                If contador_filas < 31 Then

                    .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                    .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                    .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).CF_DESC, STR_PARAM_2(eje_y, 295, 30, "left", 5, 90), FONT_1)
                    .DrawText(Data_Prev(z).CF_COD, STR_PARAM_2(eje_y, 340, 60, "left", 5, 90), FONT_1)
                    .DrawText(Data_Prev(z).TP_PAGO_DESC, STR_PARAM_2(eje_y, 385, 30, "left", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM_2(eje_y, 415, 60, "left", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 450, 20, "center", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_COPAGO)).ToString("#,##0"), STR_PARAM_2(eje_y, 485, 100, "left", 5, 90), FONT_1)

                    If (Data_Prev(z).TP_PAGO_DESC = "Efectivo" Or Data_Prev(z).TP_PAGO_DESC = "Particular" Or Data_Prev(z).TP_PAGO_DESC = "Transferencia" Or Data_Prev(z).TP_PAGO_DESC = "Cheque") Then
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                    Else
                        .DrawText("$0", STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                    End If
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 545, 100, "left", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_CS)).ToString("#,##0"), STR_PARAM_2(eje_y, 585, 100, "left", 5, 90), FONT_1)

                    If (Data_Prev(z).USU_REV = "" Or Data_Prev(z).USU_REV = Nothing) Then
                        .DrawText("NO", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                    Else
                        .DrawText("SI", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                    End If

                    .DrawText(Data_Prev(z).USU_REV, STR_PARAM_2(eje_y, 665, 50, "left", 5, 90), FONT_1)
                    If (Data_Prev(z).DOCS_CANT = 0) Then
                        .DrawText(0, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                    Else
                        .DrawText(Data_Prev(z).DOCS_CANT, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                    End If



                    eje_y = eje_y + 17
                    contador_filas += 1
                    zz += 1
                    If zz = 30 And Data_Prev.Count > 30 Then

                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If
                Else

                    If zz = 32 Then
                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If

                    With fuck.Canvas

                        If xxx = 1 Then
                            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


                            .SetFillColor(0, 0, 0)
                            .DrawText("Revisión Múltiple", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
                            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)

                            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 7, 90), FONT_2)
                            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 7, 90), FONT_2)
                            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 7, 90), FONT_2)
                            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 7, 90), FONT_2)
                            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 7, 90), FONT_2)
                            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 7, 90), FONT_2)
                            .DrawText("Exámenes", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
                            .DrawText("Cod. Fonasa", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
                            .DrawText("F. Pago", STR_PARAM_2(70, 385, 60, "left", 6, 90), FONT_2)
                            .DrawText("T. Atención", STR_PARAM_2(70, 415, 50, "left", 6, 90), FONT_2)
                            .DrawText("V. Pagado", STR_PARAM_2(70, 450, 50, "left", 6, 90), FONT_2)
                            .DrawText("Copago", STR_PARAM_2(70, 485, 70, "left", 6, 90), FONT_2)
                            .DrawText("Particular", STR_PARAM_2(70, 510, 70, "left", 6, 90), FONT_2)
                            .DrawText("Bonificación", STR_PARAM_2(70, 545, 70, "left", 6, 90), FONT_2)
                            .DrawText("S. Complemen.", STR_PARAM_2(70, 585, 70, "left", 6, 90), FONT_2)
                            .DrawText("Revisado", STR_PARAM_2(70, 630, 35, "left", 6, 90), FONT_2)
                            .DrawText("Usu. Revisa.", STR_PARAM_2(70, 665, 35, "left", 6, 90), FONT_2)
                            .DrawText("Órdenes", STR_PARAM_2(70, 705, 35, "left", 6, 90), FONT_2)
                            xxx = 0
                        End If

                        .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                        .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                        .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).CF_DESC, STR_PARAM_2(eje_y, 295, 30, "left", 5, 90), FONT_1)
                        .DrawText(Data_Prev(z).CF_COD, STR_PARAM_2(eje_y, 340, 60, "left", 5, 90), FONT_1)
                        .DrawText(Data_Prev(z).TP_PAGO_DESC, STR_PARAM_2(eje_y, 385, 30, "left", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM_2(eje_y, 415, 60, "left", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 450, 20, "center", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_COPAGO)).ToString("#,##0"), STR_PARAM_2(eje_y, 485, 100, "left", 5, 90), FONT_1)

                        If (Data_Prev(z).TP_PAGO_DESC = "Efectivo" Or Data_Prev(z).TP_PAGO_DESC = "Particular" Or Data_Prev(z).TP_PAGO_DESC = "Transferencia" Or Data_Prev(z).TP_PAGO_DESC = "Cheque") Then
                            .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                        Else
                            .DrawText("$0", STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                        End If
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 545, 100, "left", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_CS)).ToString("#,##0"), STR_PARAM_2(eje_y, 585, 100, "left", 5, 90), FONT_1)

                        If (Data_Prev(z).USU_REV = "" Or Data_Prev(z).USU_REV = Nothing) Then
                            .DrawText("NO", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                        Else
                            .DrawText("SI", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                        End If

                        .DrawText(Data_Prev(z).USU_REV, STR_PARAM_2(eje_y, 665, 50, "left", 5, 90), FONT_1)
                        If (Data_Prev(z).DOCS_CANT = 0) Then
                            .DrawText(0, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                        Else
                            .DrawText(Data_Prev(z).DOCS_CANT, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                        End If



                        eje_y = eje_y + 17
                        contador_filas += 1
                        zz += 1
                    End With
                End If
            Next z
        End With
        'End If
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Dual_Copago_Med(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String, ByVal search_mode As Integer, ByVal TP_PAGO As Integer,
                                            ByVal ID_ESTADO As Integer) As String
        'Declaraciones Generales
        Dim Mx_Data(20, 0) As Object
        'Realizar Consulta
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        If (search_mode = 0) Then
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, PROC, PREV, ID_USER, ATE_NUM)
            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If
                Next i
            Else
                Return Nothing
            End If
        Else
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER, ID_ESTADO)

            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If

                Next i
            Else
                Return Nothing
            End If
        End If
        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(20, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        Dim tot_copa As Integer = 0
        Dim tot_parti As Integer = 0

        For i = 0 To Data_Prev.Count - 1
            tot_copa += CInt(Data_Prev(i).REL_MONTO_COPAGO_1) + CInt(Data_Prev(i).REL_MONTO_COPAGO_1)
            tot_parti += CInt(Data_Prev(i).REL_MONTO_PARTICULAR)
        Next i

        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(20, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).ATE_NUM
            Mx_Data(2, y) = Format(Data_Prev(y).ATE_FECHA, "dd-MM-yyyy HH:mm")
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PROC_DESC
            Mx_Data(5, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(6, y) = Data_Prev(y).CF_DESC
            Mx_Data(7, y) = Data_Prev(y).CF_COD
            Mx_Data(8, y) = Data_Prev(y).TP_PAGO_DESC
            Mx_Data(9, y) = CInt(Data_Prev(y).ATE_DET_V_PREVI)
            Mx_Data(10, y) = CInt(Data_Prev(y).ATE_DET_V_PAGADO)
            Mx_Data(11, y) = CInt(Data_Prev(y).ATE_DET_V_COPAGO)

            If (Data_Prev(y).TP_PAGO_DESC = "Efectivo" Or Data_Prev(y).TP_PAGO_DESC = "Particular" Or Data_Prev(y).TP_PAGO_DESC = "Transferencia" Or Data_Prev(y).TP_PAGO_DESC = "Cheque") Then
                Mx_Data(12, y) = CInt(Data_Prev(y).ATE_DET_V_PAGADO)
            Else
                Mx_Data(12, y) = 0
            End If

            Mx_Data(13, y) = CInt(Data_Prev(y).ATE_DET_VALOR_BENEF)
            Mx_Data(14, y) = CInt(Data_Prev(y).ATE_DET_VALOR_CS)

            If (Data_Prev(y).USU_REV = "" Or Data_Prev(y).USU_REV = Nothing) Then
                Mx_Data(15, y) = "NO"
            Else
                Mx_Data(15, y) = "SI"
            End If
            Mx_Data(16, y) = Data_Prev(y).USUARIO_DET
            Mx_Data(17, y) = Data_Prev(y).DOC_NOMBRE & " " & Data_Prev(y).DOC_APELLIDO
            If (Data_Prev(y).USU_REV = "" Or Data_Prev(y).USU_REV = Nothing) Then
                Mx_Data(18, y) = "-/-"
            Else
                Mx_Data(18, y) = Format(Data_Prev(y).ATE_DET_RCAJA_FECHA, "dd-MM-yyyy HH:mm")
            End If

            Mx_Data(19, y) = Data_Prev(y).USU_REV

            If (Data_Prev(y).DOCS_CANT = 0) Then
                Mx_Data(20, y) = 0
            Else
                Mx_Data(20, y) = Data_Prev(y).DOCS_CANT
            End If


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
        sl.RenameWorksheet("Sheet1", "Revisión Múltiple")
        'titulo de la tabla
        sl.SetCellValue("B2", "Revisión Múltiple")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        'nombre columnas
        sl.SetCellValue("B7", "#")
        sl.SetCellValue("C7", "Ate Num")
        sl.SetCellValue("D7", "Fecha Ate")
        sl.SetCellValue("E7", "Pac Nombre")
        sl.SetCellValue("F7", "Procedencia")
        sl.SetCellValue("G7", "Previsión")
        sl.SetCellValue("H7", "Exámenes")
        sl.SetCellValue("I7", "Cod. Fonasa")
        sl.SetCellValue("J7", "F. Pago")
        sl.SetCellValue("K7", "Total Atención")
        sl.SetCellValue("L7", "Valor Pagado")
        sl.SetCellValue("M7", "Copago")
        sl.SetCellValue("N7", "Particular")
        sl.SetCellValue("O7", "Bonificación")
        sl.SetCellValue("P7", "S. Complementario")
        sl.SetCellValue("Q7", "Revisado")
        sl.SetCellValue("R7", "Usu. Creación")
        sl.SetCellValue("S7", "Médico")
        sl.SetCellValue("T7", "F. Revisado")
        sl.SetCellValue("U7", "Usu. Revisión")
        sl.SetCellValue("V7", "Órdenes")
        For y = 2 To 22
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y

        sl.SetColumnWidth(2, 10.0)
        ltabla += 7

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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("6")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("6")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("K") To Asc("O")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("B") To Asc("O")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("V" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Revisón_Multiple_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function PDFF_DUAL_COPA_MED_REND(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String, ByVal search_mode As Integer) As String


        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        If (search_mode = 0) Then
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, PROC, PREV, ID_USER, ATE_NUM)
            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If
                Next i
            Else
                Return Nothing
            End If
        Else
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER)

            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If

                Next i
            Else
                Return Nothing
            End If
        End If

        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Revision_Multiple" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = System.Web.HttpContext.Current.Server.CreateObject("Persits.Pdf")
        DOC.Title = "Revisión"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        Dim eje_y As Integer = 85

        Dim contador_filas As Integer = 1

        Dim zz As Integer
        Dim z As Integer
        Dim xxx As Integer

        eje_y = 85

        Dim fuck = DOC.Pages.Add(612, 792)

        With fuck.Canvas
            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


            .SetFillColor(0, 0, 0)
            .DrawText("Revisión", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)

            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 7, 90), FONT_2)
            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 7, 90), FONT_2)
            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 7, 90), FONT_2)
            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 7, 90), FONT_2)
            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 7, 90), FONT_2)
            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 7, 90), FONT_2)
            .DrawText("Exámenes", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
            .DrawText("Cod. Fonasa", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
            .DrawText("F. Pago", STR_PARAM_2(70, 385, 60, "left", 6, 90), FONT_2)
            .DrawText("T. Atención", STR_PARAM_2(70, 415, 50, "left", 6, 90), FONT_2)
            .DrawText("V. Pagado", STR_PARAM_2(70, 450, 50, "left", 6, 90), FONT_2)
            .DrawText("Copago", STR_PARAM_2(70, 485, 70, "left", 6, 90), FONT_2)
            .DrawText("Particular", STR_PARAM_2(70, 510, 70, "left", 6, 90), FONT_2)
            .DrawText("Bonificación", STR_PARAM_2(70, 545, 70, "left", 6, 90), FONT_2)
            .DrawText("S. Complemen.", STR_PARAM_2(70, 585, 70, "left", 6, 90), FONT_2)
            .DrawText("Revisado", STR_PARAM_2(70, 630, 35, "left", 6, 90), FONT_2)
            .DrawText("Usu. Revisa.", STR_PARAM_2(70, 665, 35, "left", 6, 90), FONT_2)
            .DrawText("Órdenes", STR_PARAM_2(70, 705, 35, "left", 6, 90), FONT_2)

            For z = 0 To Data_Prev.Count - 1

                If contador_filas < 31 Then

                    .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                    .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                    .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).CF_DESC, STR_PARAM_2(eje_y, 295, 30, "left", 5, 90), FONT_1)
                    .DrawText(Data_Prev(z).CF_COD, STR_PARAM_2(eje_y, 340, 60, "left", 5, 90), FONT_1)
                    .DrawText(Data_Prev(z).TP_PAGO_DESC, STR_PARAM_2(eje_y, 385, 30, "left", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM_2(eje_y, 415, 60, "left", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 450, 20, "center", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_COPAGO)).ToString("#,##0"), STR_PARAM_2(eje_y, 485, 100, "left", 5, 90), FONT_1)

                    If (Data_Prev(z).TP_PAGO_DESC = "Efectivo" Or Data_Prev(z).TP_PAGO_DESC = "Particular" Or Data_Prev(z).TP_PAGO_DESC = "Transferencia" Or Data_Prev(z).TP_PAGO_DESC = "Cheque") Then
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                    Else
                        .DrawText("$0", STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                    End If
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 545, 100, "left", 5, 90), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_CS)).ToString("#,##0"), STR_PARAM_2(eje_y, 585, 100, "left", 5, 90), FONT_1)

                    If (Data_Prev(z).USU_REV = "" Or Data_Prev(z).USU_REV = Nothing) Then
                        .DrawText("NO", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                    Else
                        .DrawText("SI", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                    End If

                    .DrawText(Data_Prev(z).USU_REV, STR_PARAM_2(eje_y, 665, 50, "left", 5, 90), FONT_1)
                    If (Data_Prev(z).DOCS_CANT = 0) Then
                        .DrawText(0, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                    Else
                        .DrawText(Data_Prev(z).DOCS_CANT, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                    End If



                    eje_y = eje_y + 17
                    contador_filas += 1
                    zz += 1
                    If zz = 30 And Data_Prev.Count > 30 Then

                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If
                Else

                    If zz = 32 Then
                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If

                    With fuck.Canvas

                        If xxx = 1 Then
                            .DrawImage(img_iris, "x=40, y=10, scalex=0.6, scaley=0.6, angle=90")


                            .SetFillColor(0, 0, 0)
                            .DrawText("Revisión", STR_PARAM_2(15, 0, 792, "center", 20, 90), FONT_2)
                            .DrawText("Desde:  " & DESDE & " - " & "Hasta: " & HASTA, STR_PARAM_2(40, 50, 396, "left", 11, 90), FONT_2)

                            .DrawText("#", STR_PARAM_2(70, 20, 25, "left", 7, 90), FONT_2)
                            .DrawText("Folio", STR_PARAM_2(70, 35, 25, "left", 7, 90), FONT_2)
                            .DrawText("Fecha Ate", STR_PARAM_2(70, 60, 40, "left", 7, 90), FONT_2)
                            .DrawText("Pac Nombre", STR_PARAM_2(70, 100, 70, "left", 7, 90), FONT_2)
                            .DrawText("Procedencia", STR_PARAM_2(70, 180, 45, "left", 7, 90), FONT_2)
                            .DrawText("Previsión", STR_PARAM_2(70, 245, 55, "left", 7, 90), FONT_2)
                            .DrawText("Exámenes", STR_PARAM_2(70, 295, 50, "left", 7, 90), FONT_2)
                            .DrawText("Cod. Fonasa", STR_PARAM_2(70, 340, 60, "left", 7, 90), FONT_2)
                            .DrawText("F. Pago", STR_PARAM_2(70, 385, 60, "left", 6, 90), FONT_2)
                            .DrawText("T. Atención", STR_PARAM_2(70, 415, 50, "left", 6, 90), FONT_2)
                            .DrawText("V. Pagado", STR_PARAM_2(70, 450, 50, "left", 6, 90), FONT_2)
                            .DrawText("Copago", STR_PARAM_2(70, 485, 70, "left", 6, 90), FONT_2)
                            .DrawText("Particular", STR_PARAM_2(70, 510, 70, "left", 6, 90), FONT_2)
                            .DrawText("Bonificación", STR_PARAM_2(70, 545, 70, "left", 6, 90), FONT_2)
                            .DrawText("S. Complemen.", STR_PARAM_2(70, 585, 70, "left", 6, 90), FONT_2)
                            .DrawText("Revisado", STR_PARAM_2(70, 630, 35, "left", 6, 90), FONT_2)
                            .DrawText("Usu. Revisa.", STR_PARAM_2(70, 665, 35, "left", 6, 90), FONT_2)
                            .DrawText("Órdenes", STR_PARAM_2(70, 705, 35, "left", 6, 90), FONT_2)
                            xxx = 0
                        End If

                        .DrawText(contador_filas, STR_PARAM_2(eje_y, 20, 25, "left", 6, 90), FONT_2)
                        .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM_2(eje_y, 35, 25, "left", 6, 90), FONT_1)
                        .DrawText(Format("dd-MM-yyyy", Data_Prev(z).ATE_FECHA), STR_PARAM_2(eje_y, 60, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM_2(eje_y, 100, 70, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM_2(eje_y, 180, 100, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PREVE_DESC, STR_PARAM_2(eje_y, 245, 55, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).CF_DESC, STR_PARAM_2(eje_y, 295, 30, "left", 5, 90), FONT_1)
                        .DrawText(Data_Prev(z).CF_COD, STR_PARAM_2(eje_y, 340, 60, "left", 5, 90), FONT_1)
                        .DrawText(Data_Prev(z).TP_PAGO_DESC, STR_PARAM_2(eje_y, 385, 30, "left", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM_2(eje_y, 415, 60, "left", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 450, 20, "center", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_COPAGO)).ToString("#,##0"), STR_PARAM_2(eje_y, 485, 100, "left", 5, 90), FONT_1)

                        If (Data_Prev(z).TP_PAGO_DESC = "Efectivo" Or Data_Prev(z).TP_PAGO_DESC = "Particular" Or Data_Prev(z).TP_PAGO_DESC = "Transferencia" Or Data_Prev(z).TP_PAGO_DESC = "Cheque") Then
                            .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_V_PAGADO)).ToString("#,##0"), STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                        Else
                            .DrawText("$0", STR_PARAM_2(eje_y, 510, 100, "left", 5, 90), FONT_1)
                        End If
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_BENEF)).ToString("#,##0"), STR_PARAM_2(eje_y, 545, 100, "left", 5, 90), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_Prev(z).ATE_DET_VALOR_CS)).ToString("#,##0"), STR_PARAM_2(eje_y, 585, 100, "left", 5, 90), FONT_1)

                        If (Data_Prev(z).USU_REV = "" Or Data_Prev(z).USU_REV = Nothing) Then
                            .DrawText("NO", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                        Else
                            .DrawText("SI", STR_PARAM_2(eje_y, 630, 50, "left", 5, 90), FONT_1)
                        End If

                        .DrawText(Data_Prev(z).USU_REV, STR_PARAM_2(eje_y, 665, 50, "left", 5, 90), FONT_1)
                        If (Data_Prev(z).DOCS_CANT = 0) Then
                            .DrawText(0, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                        Else
                            .DrawText(Data_Prev(z).DOCS_CANT, STR_PARAM_2(eje_y, 705, 50, "left", 5, 90), FONT_1)
                        End If



                        eje_y = eje_y + 17
                        contador_filas += 1
                        zz += 1
                    End With
                End If
            Next z
        End With
        'End If
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Dual_Copago_Rend(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String, ByVal search_mode As Integer) As String
        'Declaraciones Generales
        Dim Mx_Data(20, 0) As Object
        'Realizar Consulta
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        If (search_mode = 0) Then
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, PROC, PREV, ID_USER, ATE_NUM)
            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If
                Next i
            Else
                Return Nothing
            End If
        Else
            Data_Prev = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER)

            If (Data_Prev.Count > 0) Then
                For i = 0 To Data_Prev.Count - 1
                    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                    If (Data_Estado_Mant_2.Count > 0) Then
                        Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                    Else
                        Data_Prev(i).DOCS_CANT = 0
                    End If

                Next i
            Else
                Return Nothing
            End If
        End If
        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(20, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        Dim tot_copa As Integer = 0
        Dim tot_parti As Integer = 0

        For i = 0 To Data_Prev.Count - 1
            tot_copa += CInt(Data_Prev(i).REL_MONTO_COPAGO_1) + CInt(Data_Prev(i).REL_MONTO_COPAGO_1)
            tot_parti += CInt(Data_Prev(i).REL_MONTO_PARTICULAR)
        Next i

        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(20, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).ATE_NUM
            Mx_Data(2, y) = Format(Data_Prev(y).ATE_FECHA, "dd-MM-yyyy HH:mm")
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PROC_DESC
            Mx_Data(5, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(6, y) = Data_Prev(y).CF_DESC
            Mx_Data(7, y) = Data_Prev(y).CF_COD
            Mx_Data(8, y) = Data_Prev(y).TP_PAGO_DESC
            Mx_Data(9, y) = CInt(Data_Prev(y).ATE_DET_V_PREVI)
            Mx_Data(10, y) = CInt(Data_Prev(y).ATE_DET_V_PAGADO)
            Mx_Data(11, y) = CInt(Data_Prev(y).ATE_DET_V_COPAGO)

            If (Data_Prev(y).TP_PAGO_DESC = "Efectivo" Or Data_Prev(y).TP_PAGO_DESC = "Particular" Or Data_Prev(y).TP_PAGO_DESC = "Transferencia" Or Data_Prev(y).TP_PAGO_DESC = "Cheque") Then
                Mx_Data(12, y) = CInt(Data_Prev(y).ATE_DET_V_PAGADO)
            Else
                Mx_Data(12, y) = 0
            End If

            Mx_Data(13, y) = CInt(Data_Prev(y).ATE_DET_VALOR_BENEF)
            Mx_Data(14, y) = CInt(Data_Prev(y).ATE_DET_VALOR_CS)

            If (Data_Prev(y).USU_REV = "" Or Data_Prev(y).USU_REV = Nothing) Then
                Mx_Data(15, y) = "NO"
            Else
                Mx_Data(15, y) = "SI"
            End If
            Mx_Data(16, y) = Data_Prev(y).USUARIO_DET
            Mx_Data(17, y) = Data_Prev(y).DOC_NOMBRE & " " & Data_Prev(y).DOC_APELLIDO
            If (Data_Prev(y).USU_REV = "" Or Data_Prev(y).USU_REV = Nothing) Then
                Mx_Data(18, y) = "-/-"
            Else
                Mx_Data(18, y) = Format(Data_Prev(y).ATE_DET_RCAJA_FECHA, "dd-MM-yyyy HH:mm")
            End If

            Mx_Data(19, y) = Data_Prev(y).USU_REV

            If (Data_Prev(y).DOCS_CANT = 0) Then
                Mx_Data(20, y) = 0
            Else
                Mx_Data(20, y) = Data_Prev(y).DOCS_CANT
            End If


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
        sl.RenameWorksheet("Sheet1", "Revisión")
        'titulo de la tabla
        sl.SetCellValue("B2", "Revisión Revisión")
        sl.SetCellValue("B3", "Desde: " & DESDE & " Hasta: " & HASTA)
        'nombre columnas
        sl.SetCellValue("B7", "#")
        sl.SetCellValue("C7", "Ate Num")
        sl.SetCellValue("D7", "Fecha Ate")
        sl.SetCellValue("E7", "Pac Nombre")
        sl.SetCellValue("F7", "Procedencia")
        sl.SetCellValue("G7", "Previsión")
        sl.SetCellValue("H7", "Exámenes")
        sl.SetCellValue("I7", "Cod. Fonasa")
        sl.SetCellValue("J7", "F. Pago")
        sl.SetCellValue("K7", "Total Atención")
        sl.SetCellValue("L7", "Valor Pagado")
        sl.SetCellValue("M7", "Copago")
        sl.SetCellValue("N7", "Particular")
        sl.SetCellValue("O7", "Bonificación")
        sl.SetCellValue("P7", "S. Complementario")
        sl.SetCellValue("Q7", "Revisado")
        sl.SetCellValue("R7", "Usu. Creación")
        sl.SetCellValue("S7", "Médico")
        sl.SetCellValue("T7", "F. Revisado")
        sl.SetCellValue("U7", "Usu. Revisión")
        sl.SetCellValue("V7", "Órdenes")
        For y = 2 To 22
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 2, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y

        sl.SetColumnWidth(2, 10.0)
        ltabla += 7

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
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("B7", estilo2)
        sl.SetCellStyle("C7", estilo2)
        sl.SetCellStyle("D7", estilo2)

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("6")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
            For i = Asc("F") To Asc("6")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("K") To Asc("O")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("B") To Asc("O")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("B" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("B7", CStr("V" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & "Revision_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Public Function STR_PARAM_2(ByVal x As Single, ByVal y As Single, ByVal width As Single,
 ByVal alignment As String, ByVal size As Single, ByVal angle As Single) As String
        Dim PARAM_XX As String

        'Parámetros de la cadena
        PARAM_XX = ""
        PARAM_XX += "x=" & x & ";"                              'Posición x del cuadro de texto
        PARAM_XX += "y=" & y & ";"                              'Posición y del cuadro de texto
        PARAM_XX += "width=" & width & ";"                      'Ancho del cuadro de texto
        PARAM_XX += "alignment=" & alignment & ";"              'Alineación del cuadro de texto
        PARAM_XX += "size=" & size & ";"                         'Tamaño de la fuente
        PARAM_XX += "angle=" & angle & ""
        Return PARAM_XX
    End Function
End Class
