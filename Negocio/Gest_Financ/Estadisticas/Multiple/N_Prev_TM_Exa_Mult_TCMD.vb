Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web
Imports ASPPDFLib
Public Class N_Prev_TM_Exa_Mult_TCMD
    Inherits System.Web.UI.Page
    'Declaraciones Generales
    Dim DD_Data As D_Prev_TM_Exa_Mult_TCMD
    Sub New()
        DD_Data = New D_Prev_TM_Exa_Mult_TCMD
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal ID_PRE4 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, ID_PRE4, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD_2(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal ID_PRE4 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD_2(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, ID_PRE4, DESDE, HASTA)
    End Function
    Function PDFF(ByVal DOMAIN_URL As String,
                  ByVal ID_TP_PAGO As Long,
                  ByVal ID_PRE As Long,
                  ByVal ID_PRE2 As Long,
                  ByVal ID_PRE3 As Long,
                  ByVal ID_PRE4 As Long,
                  ByVal DATE_str01 As String,
                  ByVal DATE_str02 As String) As String


        Dim NN_DTT As New N_Prev_TM_Exa_Mult_TCMD
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)



        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, ID_PRE4, CDate(DATE_str01), CDate(DATE_str02))

        If (Data_DTT.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Mult_Proc_Prev_Prog" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Multiple Procedencia Previsión Programa"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        TOT_VAL = 0
        For x = 0 To Data_DTT.Count - 1
            TOT_VAL += Data_DTT(x).TOTA_SIS
        Next


        Dim TOT_ATE As Integer
        TOT_ATE = Data_DTT(0).TOTAL_ATE
        'For x = 0 To Data_DTT.Count - 1
        '    TOT_ATE += Data_DTT(x).TOTAL_ATE
        'Next

        Dim TOT_CF As Integer
        TOT_CF = 0
        For x = 0 To Data_DTT.Count - 1
            TOT_CF += Data_DTT(x).TOT_FONASA
        Next

        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Multiple Procedencia Previsión Programa " & DATE_str01 & " al " & DATE_str02, STR_PARAM(25, 780, 560, "center", 13), FONT_2)
                .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & TOT_CF & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 750, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                .DrawText("Código", STR_PARAM(45, 720, 50, "left", 9), FONT_2)
                .DrawText("Examen", STR_PARAM(105, 720, 80, "left", 9), FONT_2)
                .DrawText("Cantidad", STR_PARAM(440, 720, 40, "left", 9), FONT_2)
                '.DrawText("Atenciones", STR_PARAM(465, 720, 120, "left", 9), FONT_2)
                .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    'If (Data_DTT(i).CF_DESC.Length > 40) Then
                    '    Data_DTT(i).CF_DESC = Data_DTT(i).CF_DESC.Substring(0, 40)
                    'End If

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                    .DrawText(Data_DTT(i).CF_COD, STR_PARAM(45, eje_y, 55, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(105, eje_y, 275, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).TOT_FONASA, STR_PARAM(440, eje_y, 40, "right", 7), FONT_1)
                    '.DrawText(Data_DTT(i).TOTAL_ATE, STR_PARAM(465, eje_y, 40, "right", 7), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).TOTA_SIS)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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

                    'If (Data_DTT(z).CF_DESC.Length > 40) Then
                    '    Data_DTT(z).CF_DESC = Data_DTT(z).CF_DESC.Substring(0, 40)
                    'End If

                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Multiple Procedencia Previsión Programa " & DATE_str01 & " al " & DATE_str02, STR_PARAM(25, 780, 601, "center", 14), FONT_2)
                        .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & TOT_CF & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 750, 611, "center", 11), FONT_2)
                        '.DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                        .DrawText("Código", STR_PARAM(45, 720, 55, "left", 9), FONT_2)
                        .DrawText("Examen", STR_PARAM(105, 720, 80, "left", 9), FONT_2)
                        .DrawText("Cantidad", STR_PARAM(440, 720, 40, "left", 9), FONT_2)
                        '.DrawText("Atenciones", STR_PARAM(465, 720, 120, "left", 9), FONT_2)
                        .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                        .DrawText(Data_DTT(z).CF_COD, STR_PARAM(45, eje_y, 55, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).CF_DESC, STR_PARAM(105, eje_y, 275, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).TOT_FONASA, STR_PARAM(440, eje_y, 40, "right", 7), FONT_1)
                        '.DrawText(Data_DTT(z).TOTAL_ATE, STR_PARAM(465, eje_y, 40, "right", 7), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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
                            .DrawText(Data_DTT(z).CF_COD, STR_PARAM(45, eje_y, 55, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).CF_DESC, STR_PARAM(105, eje_y, 275, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).TOTAL_ATE, STR_PARAM(440, eje_y, 40, "right", 7), FONT_1)
                            '.DrawText(Data_DTT(z).TOT_FONASA, STR_PARAM(465, eje_y, 40, "right", 7), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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
    Function PDFF_2(ByVal DOMAIN_URL As String,
                  ByVal ID_TP_PAGO As Long,
                  ByVal ID_PRE As Long,
                  ByVal ID_PRE2 As Long,
                  ByVal ID_PRE3 As Long,
                  ByVal ID_PRE4 As Long,
                  ByVal DATE_str01 As String,
                  ByVal DATE_str02 As String) As String


        Dim NN_DTT As New N_Prev_TM_Exa_Mult_TCMD
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)



        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_TCMD_2(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, ID_PRE4, CDate(DATE_str01), CDate(DATE_str02))

        If (Data_DTT.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Mult_Proc_Prev_Prog" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Multiple Procedencia Previsión Programa"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        TOT_VAL = 0
        For x = 0 To Data_DTT.Count - 1
            TOT_VAL += Data_DTT(x).TOTA_SIS
        Next


        Dim TOT_ATE As Integer
        TOT_ATE = Data_DTT(0).TOTAL_ATE
        'For x = 0 To Data_DTT.Count - 1
        '    TOT_ATE += Data_DTT(x).TOTAL_ATE
        'Next

        Dim TOT_CF As Integer
        TOT_CF = 0
        For x = 0 To Data_DTT.Count - 1
            TOT_CF += Data_DTT(x).TOT_FONASA
        Next

        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Multiple Procedencia Previsión Programa " & DATE_str01 & " al " & DATE_str02, STR_PARAM(25, 780, 560, "center", 13), FONT_2)
                .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & TOT_CF & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 750, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                .DrawText("Código", STR_PARAM(45, 720, 55, "left", 9), FONT_2)
                .DrawText("Examen", STR_PARAM(105, 720, 80, "left", 9), FONT_2)
                .DrawText("Cantidad", STR_PARAM(380, 720, 40, "left", 9), FONT_2)
                '.DrawText("Atenciones", STR_PARAM(395, 720, 120, "left", 9), FONT_2)
                .DrawText("Unidad", STR_PARAM(485, 720, 120, "left", 9), FONT_2)
                .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    'If (Data_DTT(i).CF_DESC.Length > 40) Then
                    '    Data_DTT(i).CF_DESC = Data_DTT(i).CF_DESC.Substring(0, 40)
                    'End If

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 7), FONT_2)
                    .DrawText(Data_DTT(i).CF_COD, STR_PARAM(45, eje_y, 55, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(105, eje_y, 210, "left", 7), FONT_1)
                    .DrawText(Data_DTT(i).TOT_FONASA, STR_PARAM(380, eje_y, 40, "right", 7), FONT_1)
                    '.DrawText(Data_DTT(i).TOTAL_ATE, STR_PARAM(395, eje_y, 40, "right", 7), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM(485, eje_y, 30, "right", 7), FONT_1)
                    .DrawText("$" & (Integer.Parse(Data_DTT(i).TOTA_SIS)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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

                    'If (Data_DTT(z).CF_DESC.Length > 40) Then
                    '    Data_DTT(z).CF_DESC = Data_DTT(z).CF_DESC.Substring(0, 40)
                    'End If

                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Multiple Procedencia Previsión Programa " & DATE_str01 & " al " & DATE_str02, STR_PARAM(25, 780, 601, "center", 14), FONT_2)
                        .DrawText("Total Atenciones: " & TOT_ATE & " - Total Exámenes: " & TOT_CF & " - Total Valorización: " & "$" & (Integer.Parse(TOT_VAL)).ToString("#,##0"), STR_PARAM(1, 750, 611, "center", 11), FONT_2)
                        '.DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 9), FONT_2)
                        .DrawText("Código", STR_PARAM(45, 720, 55, "left", 9), FONT_2)
                        .DrawText("Examen", STR_PARAM(105, 720, 80, "left", 9), FONT_2)
                        .DrawText("Cantidad", STR_PARAM(380, 720, 40, "left", 9), FONT_2)
                        '.DrawText("Atenciones", STR_PARAM(395, 720, 120, "left", 9), FONT_2)
                        .DrawText("Unidad", STR_PARAM(485, 720, 120, "left", 9), FONT_2)
                        .DrawText("Valor", STR_PARAM(540, 720, 40, "right", 9), FONT_2)

                        .DrawText(Data_DTT(z).CF_COD, STR_PARAM(45, eje_y, 55, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).CF_DESC, STR_PARAM(105, eje_y, 210, "left", 7), FONT_1)
                        .DrawText(Data_DTT(z).TOT_FONASA, STR_PARAM(380, eje_y, 40, "right", 7), FONT_1)
                        '.DrawText(Data_DTT(z).TOTAL_ATE, STR_PARAM(395, eje_y, 40, "right", 7), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM(485, eje_y, 30, "right", 7), FONT_1)
                        .DrawText("$" & (Integer.Parse(Data_DTT(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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
                            .DrawText(Data_DTT(z).CF_COD, STR_PARAM(45, eje_y, 55, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).CF_DESC, STR_PARAM(105, eje_y, 210, "left", 7), FONT_1)
                            .DrawText(Data_DTT(z).TOT_FONASA, STR_PARAM(380, eje_y, 40, "right", 7), FONT_1)
                            '.DrawText(Data_DTT(z).TOTAL_ATE, STR_PARAM(395, eje_y, 40, "right", 7), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(z).ATE_DET_V_PREVI)).ToString("#,##0"), STR_PARAM(485, eje_y, 30, "right", 7), FONT_1)
                            .DrawText("$" & (Integer.Parse(Data_DTT(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(540, eje_y, 40, "right", 7), FONT_1)
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
End Class
