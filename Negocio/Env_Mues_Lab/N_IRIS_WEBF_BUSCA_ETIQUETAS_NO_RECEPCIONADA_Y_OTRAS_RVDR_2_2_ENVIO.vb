'Importar Capas
Imports Datos
Imports Entidades
Imports ASPPDFLib

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
    Inherits System.Web.UI.Page
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO


    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As E_List_wDict
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim List_Out As New E_List_wDict

        List_In = DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        'For Each etiq In List_In
        '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

        '    Pairs.Item(strKey) += 1
        'Next



        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim ate_muestra_comparador As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = "[" & List_In(i).CB_DESC & "]" & " - " & List_In(i).T_MUESTRA_DESC
            If i = 0 Then

                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            ElseIf ((((i > 0) And ((List_In(i).CB_DESC <> cb_desc_comparador))) Or List_In(i).ATE_NUM <> ate_num_comparador Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador)) Then
                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_NORMAL(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_NORMAL(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

    End Function

    Function PDFF(ByVal DOMAIN_URL As String,
                  ByVal TIPO As Integer,
                  ByVal DESDE As String,
                  ByVal HASTA As String,
                    ByVal ID_PRE As Integer,
                    ByVal ID_CF As Integer) As String


        Dim data_det_ate As E_List_wDict
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim list_definitiva As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim Item_definitivo As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO


        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        If (data_det_ate.List_Data.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        For Each List_Data As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO In data_det_ate.List_Data
            Item_definitivo = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

            If (indice_if = 0) Then
                indice_if += 1
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                'Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC

            ElseIf ((((indice_if > 0) And (List_Data.CB_DESC <> cb_desc_comparador))) Or List_Data.ATE_NUM <> ate_num_comparador Or muestra_comparador <> List_Data.T_MUESTRA_DESC) Then
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                'Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC
            End If
        Next

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Tubos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Estados de Exámenes por Tubos"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"



        Dim eje_y As Integer = 700

        Dim contador_filas As Integer = 1
        If list_definitiva.Count <= 41 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Estados de Exámenes por Tubos", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
                .DrawText("Desde: " & DESDE, STR_PARAM(40, 760, 300, "center", 16), FONT_2)
                .DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                .DrawText("#", STR_PARAM(15, 720, 15, "left", 9), FONT_2)
                .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                '.DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Ate.", STR_PARAM(300, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Env.", STR_PARAM(330, 720, 30, "left", 9), FONT_2)
                .DrawText("Lugar TM", STR_PARAM(370, 720, 100, "left", 9), FONT_2)
                .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                For i = 0 To (list_definitiva.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                    .DrawText(list_definitiva(i).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                    '.DrawText(list_definitiva(i).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).PAC_NOMBRE & " " & list_definitiva(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                    .DrawText(Format(list_definitiva(i).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                    .DrawText(Format(list_definitiva(i).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                    .DrawText(list_definitiva(i).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                    .DrawText("[" & list_definitiva(i).CB_DESC & "]" & " - " & list_definitiva(i).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                    eje_y = eje_y - 17
                    contador_filas += 1

                Next i
            End With
        Else

            Dim z = 0
            Dim i As Integer = 0

            eje_y = 700

            Dim fuck = DOC.Pages.Add(612, 792)

            With fuck.Canvas
                For z = z To list_definitiva.Count - 1
                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Estados de Exámenes por Tubos", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
                        .DrawText("Desde: " & DESDE, STR_PARAM(40, 760, 300, "center", 16), FONT_2)
                        .DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(15, 720, 15, "left", 9), FONT_2)
                        .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                        '.DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                        .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Ate.", STR_PARAM(300, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Env.", STR_PARAM(330, 720, 30, "left", 9), FONT_2)
                        .DrawText("Lugar TM", STR_PARAM(370, 720, 100, "left", 9), FONT_2)
                        .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                        .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                        .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                        '.DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                        .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                        .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                        .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                        .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                        eje_y = eje_y - 17
                        contador_filas += 1
                        i = 1

                    Else
                        If z <> 0 Then
                            If z Mod 41 = 0 Then

                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 750

                            End If
                        End If
                        With fuck.Canvas
                            .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                            .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                            '.DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                            .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                            .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                            .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                            .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)
                            eje_y = eje_y - 17
                            contador_filas += 1
                        End With
                    End If
                Next z
            End With
        End If

        Dim super_sumador = 0
        Dim PAGE_TOTALES = DOC.Pages.Add(612, 792)

        With PAGE_TOTALES.Canvas
            eje_y = 720
            contador_filas = 1

            .DrawText("TOTALES", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
            .DrawText("#", STR_PARAM(15, 740, 15, "left", 9), FONT_2)
            .DrawText("Etiqueta", STR_PARAM(200, 740, 70, "left", 9), FONT_2)
            .DrawText("TOTAL", STR_PARAM(530, 740, 176, "left", 9), FONT_2)

            For Each key In data_det_ate.Dictionary.Keys
                .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                .DrawText(key, STR_PARAM(200, eje_y, 70, "left", 7), FONT_1)
                .DrawText(data_det_ate.Dictionary.Item(key), STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

                eje_y = eje_y - 17
                contador_filas += 1
                super_sumador += data_det_ate.Dictionary.Item(key)
            Next

            .DrawText("TOTAL", STR_PARAM(15, eje_y, 176, "left", 9), FONT_2)
            .DrawText(super_sumador, STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function PDFF_TUBO(ByVal DOMAIN_URL As String,
                  ByVal NUMLOTE As Integer) As String

        Dim data_det_ate As E_List_wDict2
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim list_definitiva As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim Item_definitivo As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO


        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(NUMLOTE)

        If (data_det_ate.List_Data.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        For Each List_Data As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO In data_det_ate.List_Data
            Item_definitivo = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            If (indice_if = 0) Then
                indice_if += 1
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                'Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION
                Item_definitivo.ENVIO_NUM = List_Data.ENVIO_NUM
                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC

            ElseIf ((((indice_if > 0) And (List_Data.CB_DESC <> cb_desc_comparador))) Or List_Data.ATE_NUM <> ate_num_comparador Or List_Data.T_MUESTRA_DESC <> muestra_comparador) Then
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                'Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION
                Item_definitivo.ENVIO_NUM = List_Data.ENVIO_NUM

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC
            End If
        Next

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Lote" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Estados de Exámenes por Lote"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim eje_y As Integer = 700

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        Dim contador_1 As Integer = 1
        Dim contador_2 As Integer

        Dim contador_filas As Integer = 1
        If list_definitiva.Count <= 41 Then
            contador_2 = 2
            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .DrawImage(img_iris, "x=10, y=726, scalex=0.6, scaley=0.6")

                .SetFillColor(0, 0, 0)
                .DrawText("Estados de Exámenes por Lote", STR_PARAM(140, 780, 300, "center", 20), FONT_2)

                .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)
                contador_1 += 1

                .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
                .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

                .DrawText("#", STR_PARAM(10, 720, 15, "left", 9), FONT_2)
                .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                '.DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Ate.", STR_PARAM(305, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Env.", STR_PARAM(335, 720, 30, "left", 9), FONT_2)
                .DrawText("Lugar TM", STR_PARAM(365, 720, 100, "left", 9), FONT_2)
                .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                For i = 0 To (list_definitiva.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(10, eje_y, 15, "left", 8), FONT_2)
                    .DrawText(list_definitiva(i).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                    '.DrawText(list_definitiva(i).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).PAC_NOMBRE & " " & list_definitiva(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                    .DrawText(Format(list_definitiva(i).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(300, eje_y, 33, "left", 6), FONT_1)
                    .DrawText(Format(list_definitiva(i).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(335, eje_y, 30, "left", 6), FONT_1)
                    .DrawText(list_definitiva(i).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                    .DrawText("[" & list_definitiva(i).CB_DESC & "]" & " - " & list_definitiva(i).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                    eje_y = eje_y - 17
                    contador_filas += 1

                Next i
            End With
        Else

            Dim z = 0
            Dim i As Integer = 0

            contador_2 = ((list_definitiva.Count / 41) + 2)
            'contador_2 += 1
            eje_y = 700

            Dim fuck = DOC.Pages.Add(612, 792)
            Dim kkkkkk As Integer = 0
            With fuck.Canvas
                For z = z To list_definitiva.Count - 1
                    If i = 0 Then

                        .DrawImage(img_iris, "x=10, y=726, scalex=0.6, scaley=0.6")

                        .SetFillColor(0, 0, 0)
                        .DrawText("Estados de Exámenes por Lote", STR_PARAM(140, 780, 300, "center", 20), FONT_2)

                        .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)
                        contador_1 += 1

                        .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
                        .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

                        .DrawText("#", STR_PARAM(10, 720, 15, "left", 9), FONT_2)
                        .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                        '.DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                        .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Ate.", STR_PARAM(305, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Env.", STR_PARAM(335, 720, 30, "left", 9), FONT_2)
                        .DrawText("Lugar TM", STR_PARAM(365, 720, 100, "left", 9), FONT_2)
                        .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                        .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(10, eje_y, 15, "left", 8), FONT_2)
                        .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                        '.DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                        .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(300, eje_y, 33, "left", 6), FONT_1)
                        .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(335, eje_y, 30, "left", 6), FONT_1)
                        .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                        .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                        eje_y = eje_y - 17
                        contador_filas += 1
                        i = 1
                        kkkkkk = 1

                    Else
                        If z <> 0 Then
                            If z Mod 41 = 0 Then
                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 750
                                kkkkkk = 0

                            End If
                        End If
                        With fuck.Canvas

                            If kkkkkk = 0 Then
                                .DrawImage(img_iris, "x=50, y=745, scalex=0.6, scaley=0.6")

                                .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
                                .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

                                .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)
                                contador_1 += 1
                                'contador_2 += 1

                                kkkkkk = 1
                            End If

                            .DrawText(contador_filas, STR_PARAM(10, eje_y, 15, "left", 8), FONT_2)
                            .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                            '.DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                            .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(300, eje_y, 33, "left", 6), FONT_1)
                            .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(335, eje_y, 30, "left", 6), FONT_1)
                            .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                            .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)
                            eje_y = eje_y - 17
                            contador_filas += 1
                        End With
                    End If
                Next z
            End With
        End If

        Dim super_sumador = 0
        Dim PAGE_TOTALES = DOC.Pages.Add(612, 792)

        With PAGE_TOTALES.Canvas
            eje_y = 720
            contador_filas = 1

            .DrawImage(img_iris, "x=30, y=740, scalex=0.5, scaley=0.5")

            .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
            .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

            .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)

            .DrawText("TOTALES", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
            .DrawText("#", STR_PARAM(15, 740, 15, "left", 9), FONT_2)
            .DrawText("Etiqueta", STR_PARAM(200, 740, 70, "left", 9), FONT_2)
            .DrawText("TOTAL", STR_PARAM(530, 740, 176, "left", 9), FONT_2)

            For Each key In data_det_ate.Dictionary.Keys
                .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                .DrawText(key, STR_PARAM(200, eje_y, 70, "left", 7), FONT_1)
                .DrawText(data_det_ate.Dictionary.Item(key), STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

                eje_y = eje_y - 17
                contador_filas += 1
                super_sumador += data_det_ate.Dictionary.Item(key)
            Next

            .DrawText("TOTAL", STR_PARAM(15, eje_y, 176, "left", 9), FONT_2)
            .DrawText(super_sumador, STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF_2(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CF As Integer, ByVal VALOR As Integer) As String


        Dim NN_DTT As New N_Examenes_Sum
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES)
        Dim NN_Exam As New N_Examenes_Sum
        Dim NN_Date As New N_Date_Operat
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        If VALOR = 0 Then
            Data_DTT = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_MINDS_VALIDADOS(Date_01, Date_02, ID_CF, cookie_proc)
        ElseIf VALOR = 1 Then
            Data_DTT = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_MINDS_VALIDADOS_REVISADOS(Date_01, Date_02, ID_CF, cookie_proc)
        ElseIf VALOR = 2 Then
            Data_DTT = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_MINDS_TODOS(Date_01, Date_02, ID_CF, cookie_proc)
        End If

        If (Data_DTT.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Total_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad Total de Exámenes"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer
        Dim TOT_SIS As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0
        TOT_SIS = 0




        For x = 0 To Data_DTT.Count - 1
            TOT_ATE += Data_DTT(x).TOTAL_ATE
            TOT_SIS += Data_DTT(x).TOTA_SIS
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                .SetFillColor(0, 0, 0)
                .DrawText("Cantidad Total de Exámenes", STR_PARAM(200, 780, 611, "left", 17), FONT_2)
                .DrawText("Desde: " & DATE_str01 & " al " & DATE_str02, STR_PARAM(210, 765, 611, "left", 14), FONT_2)
                .DrawText("Total Exámenes: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - " & " Total Ventas: $ " & (Integer.Parse(TOT_SIS)).ToString("#,##0"), STR_PARAM(190, 750, 611, "left", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Descripción Prestación", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad de Exámenes", STR_PARAM(290, 720, 80, "left", 8), FONT_2)
                .DrawText("Venta", STR_PARAM(545, 720, 80, "left", 8), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(Data_DTT(i).TOT_FONASA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                    .DrawText("$ " & (Integer.Parse(Data_DTT(i).TOTA_SIS)).ToString("#,##0"), STR_PARAM(530, eje_y, 40, "right", 6), FONT_1)
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

                    If i = 0 Then

                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                        .SetFillColor(0, 0, 0)
                        .DrawText("Cantidad Total de Exámenes", STR_PARAM(200, 780, 611, "left", 17), FONT_2)
                        .DrawText("Desde: " & DATE_str01 & " al " & DATE_str02, STR_PARAM(210, 765, 611, "left", 14), FONT_2)
                        .DrawText("Total Exámenes: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - " & " Total Ventas: $ " & (Integer.Parse(TOT_SIS)).ToString("#,##0"), STR_PARAM(190, 750, 611, "left", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Descripción Prestación", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad de Exámenes", STR_PARAM(290, 720, 80, "left", 8), FONT_2)
                        .DrawText("Venta", STR_PARAM(545, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Data_DTT(z).CF_DESC, STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(Data_DTT(z).TOT_FONASA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                        .DrawText("$ " & (Integer.Parse(Data_DTT(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(530, eje_y, 40, "right", 6), FONT_1)
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
                            .DrawText(Data_DTT(z).CF_DESC, STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(Data_DTT(z).TOT_FONASA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                            .DrawText("$ " & (Integer.Parse(Data_DTT(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(530, eje_y, 40, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF_3(ByVal DOMAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer) As String


        Dim NN_DTT As New N_Examenes_Sum
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim NN_Exam As New N_GraficoVisor
        Dim NN_Date As New N_Date_Operat
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim NN_Med As New N_GraficoVisor
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

        Dim CF_DESCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESCCCCCCC = "Todos"
        Else
            CF_DESCCCCCCC = CF_DESC
        End If

        If (date_json_rial.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Total_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")


        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad de Atenciones Mensuales"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0



        For x = 0 To date_json_rial.Count - 1
            TOT_ATE += date_json_rial(x).E_Cantidad
            TOT_CF += date_json_rial(x).CANT_EXA
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If date_json_rial.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                .SetFillColor(0, 0, 0)
                .DrawText("Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"), STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " Examen: " & CF_DESCCCCCCC, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Fecha", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                .DrawText("Días", STR_PARAM(85, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Atenciones", STR_PARAM(400, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Exámenes", STR_PARAM(500, 720, 80, "left", 8), FONT_2)

                For i = 0 To (date_json_rial.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Format(CDate(date_json_rial(i).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                    .DrawText(date_json_rial(i).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).E_Cantidad)).ToString("#,##0"), STR_PARAM(450, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                For z = z To date_json_rial.Count - 1

                    If i = 0 Then
                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                        .SetFillColor(0, 0, 0)
                        .DrawText("Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"), STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                        .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " Examen: " & CF_DESCCCCCCC, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Fecha", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                        .DrawText("Días", STR_PARAM(85, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Atenciones", STR_PARAM(400, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Exámenes", STR_PARAM(500, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Format(CDate(date_json_rial(z).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                        .DrawText(date_json_rial(z).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).E_Cantidad)).ToString("#,##0"), STR_PARAM(450, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                            .DrawText(Format(CDate(date_json_rial(z).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                            .DrawText(date_json_rial(z).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).E_Cantidad)).ToString("#,##0"), STR_PARAM(450, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF_4(ByVal MAIN_URL As String, ByVal Dll As Long, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_Prev As New N_GraficoPrev
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim data_Prev As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION)
        Dim Prev_Desc As String = ""
        Dim mm As Integer
        mm = Format(Date.Now, "MM")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        For dd = 1 To 12
            Dim Item As New E_GraficoVisor_Json
            If Dll = 0 Then

                If VALOR = 0 Then
                    data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2_VALIDADOS(Dll, Año, dd, ID_CF, cookie_proc)

                ElseIf VALOR = 1 Then
                    data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2_VALIDADOS_REVISADOS(Dll, Año, dd, ID_CF, cookie_proc)
                ElseIf VALOR = 2 Then
                    data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2_TODOS(Dll, Año, dd, ID_CF, cookie_proc)
                End If

                'data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2(Dll, Año, dd, ID_CF)
                If data_Prev.Count <> 0 Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = data_Prev(0).CANT_ATE
                    Item.CANT_EXA = data_Prev(0).CANT_EXA
                    Item.PREVI = data_Prev(0).PREVI
                    date_json_rial.Add(Item)
                ElseIf (data_Prev.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    Item.PREVI = 0
                    date_json_rial.Add(Item)
                End If
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                If (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    Item.PREVI = 0
                    date_json_rial.Add(Item)
                Else
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    Item.PREVI = Data_Med(0).PREVI
                    date_json_rial.Add(Item)
                End If
            End If
        Next dd

        If (date_json_rial.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        Dim CF_DESSSCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESSSCCCCCCC = "Todos"
        Else
            CF_DESSSCCCCCCC = CF_DESC
        End If

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Anual_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad Total de Exámenes"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer
        Dim T_Ventas As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0
        T_Ventas = 0



        For x = 0 To date_json_rial.Count - 1
            TOT_ATE += date_json_rial(x).CANT_ATE
            TOT_CF += date_json_rial(x).CANT_ATE
            T_Ventas += date_json_rial(x).PREVI
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If date_json_rial.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                .SetFillColor(0, 0, 0)
                .DrawText("Cantidad Anual de Exámenes año " & Año & " Examen: " & CF_DESSSCCCCCCC, STR_PARAM(1, 780, 611, "center", 17), FONT_2)
                .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Total Ventas: $ " & (Integer.Parse(T_Ventas)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Mes", STR_PARAM(40, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Exámenes", STR_PARAM(350, 720, 80, "left", 8), FONT_2)
                .DrawText("Ventas", STR_PARAM(540, 720, 80, "left", 8), FONT_2)

                For i = 0 To (date_json_rial.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(date_json_rial(i).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_ATE)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)).ToString("#,##0"), STR_PARAM(400, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).PREVI).ToString("#,##0")), STR_PARAM(523, eje_y, 40, "right", 6), FONT_1)
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
                For z = z To date_json_rial.Count - 1

                    If i = 0 Then

                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                        .SetFillColor(0, 0, 0)
                        .DrawText("Cantidad Anual de Exámenes año " & Año & " Examen: " & CF_DESSSCCCCCCC, STR_PARAM(1, 780, 611, "center", 17), FONT_2)
                        .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Total Ventas: $ " & (Integer.Parse(T_Ventas)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Mes", STR_PARAM(40, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Exámenes", STR_PARAM(350, 720, 80, "left", 8), FONT_2)
                        .DrawText("Ventas", STR_PARAM(540, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(date_json_rial(z).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_ATE)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)).ToString("#,##0"), STR_PARAM(400, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).PREVI).ToString("#,##0")), STR_PARAM(523, eje_y, 40, "right", 6), FONT_1)
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
                            .DrawText(date_json_rial(z).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_ATE)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)), STR_PARAM(400, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).PREVI).ToString("#,##0")), STR_PARAM(523, eje_y, 40, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF_4_PROVEE(ByVal MAIN_URL As String, ByVal Dll As Long, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_Prev As New N_GraficoPrev
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim data_Prev As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION)
        Dim Prev_Desc As String = ""
        Dim mm As Integer
        mm = Format(Date.Now, "MM")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        For dd = 1 To 12
            Dim Item As New E_GraficoVisor_Json
            If Dll = 0 Then
                data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2(Dll, Año, dd, ID_CF)
                If data_Prev.Count <> 0 Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = data_Prev(0).CANT_ATE
                    Item.CANT_EXA = data_Prev(0).CANT_EXA
                    date_json_rial.Add(Item)
                ElseIf (data_Prev.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                If (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                Else
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                End If
            End If
        Next dd

        If (date_json_rial.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        Dim CF_DESSSCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESSSCCCCCCC = "Todos"
        Else
            CF_DESSSCCCCCCC = CF_DESC
        End If

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Anual_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad Total de Exámenes"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0



        For x = 0 To date_json_rial.Count - 1
            TOT_ATE += date_json_rial(x).CANT_ATE
            TOT_CF += date_json_rial(x).CANT_ATE
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If date_json_rial.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                .SetFillColor(0, 0, 0)
                .DrawText("Cantidad Anual de Exámenes año " & Año & " Examen: " & CF_DESSSCCCCCCC, STR_PARAM(1, 780, 611, "center", 17), FONT_2)
                .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Mes", STR_PARAM(40, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Atenciones", STR_PARAM(400, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Exámenes", STR_PARAM(500, 720, 80, "left", 8), FONT_2)

                For i = 0 To (date_json_rial.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(date_json_rial(i).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_ATE)).ToString("#,##0"), STR_PARAM(450, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                For z = z To date_json_rial.Count - 1

                    If i = 0 Then

                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                        .SetFillColor(0, 0, 0)
                        .DrawText("Cantidad Anual de Exámenes año " & Año & " Examen: " & CF_DESSSCCCCCCC, STR_PARAM(1, 780, 611, "center", 17), FONT_2)
                        .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Mes", STR_PARAM(40, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Atenciones", STR_PARAM(400, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Exámenes", STR_PARAM(500, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(date_json_rial(z).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_ATE)).ToString("#,##0"), STR_PARAM(450, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                            .DrawText(date_json_rial(z).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_ATE)).ToString("#,##0"), STR_PARAM(450, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF_3_Minds(ByVal DOMAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String


        Dim NN_DTT As New N_Examenes_Sum
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim NN_Exam As New N_GraficoVisor
        Dim NN_Date As New N_Date_Operat
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim NN_Med As New N_GraficoVisor

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




        Dim CF_DESCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESCCCCCCC = "Todos"
        Else
            CF_DESCCCCCCC = CF_DESC
        End If

        If (date_json_rial.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Total_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")


        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad de Atenciones Mensuales"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer
        Dim TOT_SIS As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0
        TOT_SIS = 0



        For x = 0 To date_json_rial.Count - 1
            TOT_ATE += date_json_rial(x).E_Cantidad
            TOT_CF += date_json_rial(x).CANT_EXA
            TOT_SIS += date_json_rial(x).TOTA_SIS
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If date_json_rial.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                .SetFillColor(0, 0, 0)
                .DrawText("Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"), STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Ventas: " & (Integer.Parse(TOT_SIS)).ToString("#,##0") & " - Examen: " & CF_DESCCCCCCC, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Fecha", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                .DrawText("Días", STR_PARAM(85, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Exámenes", STR_PARAM(300, 720, 80, "left", 8), FONT_2)
                .DrawText("Venta", STR_PARAM(530, 720, 80, "left", 8), FONT_2)

                For i = 0 To (date_json_rial.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Format(CDate(date_json_rial(i).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                    .DrawText(date_json_rial(i).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).E_Cantidad)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).TOTA_SIS)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                For z = z To date_json_rial.Count - 1

                    If i = 0 Then
                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                        .SetFillColor(0, 0, 0)
                        .DrawText("Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"), STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                        .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Ventas: " & (Integer.Parse(TOT_SIS)).ToString("#,##0") & " - Examen: " & CF_DESCCCCCCC, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Fecha", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                        .DrawText("Días", STR_PARAM(85, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Exámenes", STR_PARAM(300, 720, 80, "left", 8), FONT_2)
                        .DrawText("Venta", STR_PARAM(530, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Format(CDate(date_json_rial(z).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                        .DrawText(date_json_rial(z).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).E_Cantidad)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                            .DrawText(Format(CDate(date_json_rial(z).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                            .DrawText(date_json_rial(z).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).E_Cantidad)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function PDFF_6(ByVal MAIN_URL As String, ByVal Dll As Long, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_Prev As New N_GraficoPrev
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim data_Prev As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION)
        Dim Prev_Desc As String = ""
        Dim mm As Integer
        mm = Format(Date.Now, "MM")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        For dd = 1 To 12
            Dim Item As New E_GraficoVisor_Json
            If Dll = 0 Then

                If VALOR = 0 Then
                    data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2_VALIDADOS(Dll, Año, dd, ID_CF, cookie_proc)

                Else
                    data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2_VALIDADOS_REVISADOS(Dll, Año, dd, ID_CF, cookie_proc)
                End If

                'data_Prev = NN_Prev.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION_2(Dll, Año, dd, ID_CF)
                If data_Prev.Count <> 0 Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = data_Prev(0).CANT_ATE
                    Item.CANT_EXA = data_Prev(0).CANT_EXA
                    Item.PREVI = data_Prev(0).PREVI
                    Item.PAGADO = data_Prev(0).PAGADO
                    date_json_rial.Add(Item)
                ElseIf (data_Prev.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    Item.PREVI = 0
                    Item.PAGADO = 0
                    date_json_rial.Add(Item)
                End If
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                If (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    Item.PREVI = 0
                    Item.PAGADO = 0
                    date_json_rial.Add(Item)
                Else
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    Item.PREVI = Data_Med(0).PREVI
                    Item.PAGADO = Data_Med(0).PAGADO
                    date_json_rial.Add(Item)
                End If
            End If
        Next dd

        If (date_json_rial.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        Dim CF_DESSSCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESSSCCCCCCC = "Todos"
        Else
            CF_DESSSCCCCCCC = CF_DESC
        End If

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Anual_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad Total de Exámenes"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer
        Dim T_Ventas As Integer
        Dim T_Pagado As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0
        T_Ventas = 0
        T_Pagado = 0



        For x = 0 To date_json_rial.Count - 1
            TOT_ATE += date_json_rial(x).CANT_ATE
            TOT_CF += date_json_rial(x).CANT_ATE
            T_Ventas += date_json_rial(x).PREVI
            T_Pagado += date_json_rial(x).PAGADO
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If date_json_rial.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                .SetFillColor(0, 0, 0)
                .DrawText("Cantidad Anual de Exámenes año " & Año & " Examen: " & CF_DESSSCCCCCCC, STR_PARAM(1, 780, 611, "center", 17), FONT_2)
                .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Total Ventas: $ " & (Integer.Parse(T_Ventas)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Mes", STR_PARAM(40, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Exámenes", STR_PARAM(350, 720, 80, "left", 8), FONT_2)
                .DrawText("T. Sistema", STR_PARAM(440, 720, 80, "left", 8), FONT_2)
                .DrawText("T. Pagado", STR_PARAM(540, 720, 80, "left", 8), FONT_2)

                For i = 0 To (date_json_rial.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(date_json_rial(i).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_ATE)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)).ToString("#,##0"), STR_PARAM(400, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).PREVI).ToString("#,##0")), STR_PARAM(423, eje_y, 40, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).PAGADO).ToString("#,##0")), STR_PARAM(523, eje_y, 40, "right", 6), FONT_1)
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
                For z = z To date_json_rial.Count - 1

                    If i = 0 Then

                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                        .SetFillColor(0, 0, 0)
                        .DrawText("Cantidad Anual de Exámenes año " & Año & " Examen: " & CF_DESSSCCCCCCC, STR_PARAM(1, 780, 611, "center", 17), FONT_2)
                        .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Total Ventas: $ " & (Integer.Parse(T_Ventas)).ToString("#,##0"), STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Mes", STR_PARAM(40, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Exámenes", STR_PARAM(350, 720, 80, "left", 8), FONT_2)
                        .DrawText("T. Sistema", STR_PARAM(440, 720, 80, "left", 8), FONT_2)
                        .DrawText("T. Pagado", STR_PARAM(540, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(date_json_rial(z).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_ATE)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(400, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).PREVI).ToString("#,##0")), STR_PARAM(423, eje_y, 40, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).PAGADO).ToString("#,##0")), STR_PARAM(523, eje_y, 40, "right", 6), FONT_1)
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
                            .DrawText(date_json_rial(z).MES, STR_PARAM(40, eje_y, 300, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_ATE)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)), STR_PARAM(400, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).PREVI).ToString("#,##0")), STR_PARAM(423, eje_y, 40, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).PAGADO).ToString("#,##0")), STR_PARAM(523, eje_y, 40, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
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
    Function PDFF_3_Minds_2(ByVal DOMAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String


        Dim NN_DTT As New N_Examenes_Sum
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim NN_Exam As New N_GraficoVisor
        Dim NN_Date As New N_Date_Operat
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim NN_Med As New N_GraficoVisor

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




        Dim CF_DESCCCCCCC As String = ""

        If ID_CF = 0 Then
            CF_DESCCCCCCC = "Todos"
        Else
            CF_DESCCCCCCC = CF_DESC
        End If

        If (date_json_rial.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Cant_Total_Exam" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")


        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("calibri")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Cantidad de Atenciones Mensuales"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"


        Dim TOT_VAL As Integer
        Dim TOT_ATE As Integer
        Dim TOT_CF As Integer
        Dim TOT_SIS As Integer

        TOT_VAL = 0
        TOT_ATE = 0
        TOT_CF = 0
        TOT_SIS = 0



        For x = 0 To date_json_rial.Count - 1
            TOT_ATE += date_json_rial(x).E_Cantidad
            TOT_CF += date_json_rial(x).CANT_EXA
            TOT_SIS += date_json_rial(x).TOTA_SIS
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If date_json_rial.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                .SetFillColor(0, 0, 0)
                .DrawText("Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"), STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Ventas: " & (Integer.Parse(TOT_SIS)).ToString("#,##0") & " - Examen: " & CF_DESCCCCCCC, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Fecha", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                .DrawText("Días", STR_PARAM(85, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                .DrawText("Cantidad Exámenes", STR_PARAM(300, 720, 80, "left", 8), FONT_2)
                .DrawText("Venta", STR_PARAM(530, 720, 80, "left", 8), FONT_2)

                For i = 0 To (date_json_rial.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Format(CDate(date_json_rial(i).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                    .DrawText(date_json_rial(i).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).E_Cantidad)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).CANT_EXA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                    .DrawText((Integer.Parse(date_json_rial(i).TOTA_SIS)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                For z = z To date_json_rial.Count - 1

                    If i = 0 Then
                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")

                        .SetFillColor(0, 0, 0)
                        .DrawText("Año: " & Año & " Mes: " & Format(CDate("01" & "/" & Mes & "/" & Año), "MMMM"), STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                        .DrawText("Total Atenciones: " & (Integer.Parse(TOT_ATE)).ToString("#,##0") & " - Total Exámenes: " & (Integer.Parse(TOT_CF)).ToString("#,##0") & " - Ventas: " & (Integer.Parse(TOT_SIS)).ToString("#,##0") & " - Examen: " & CF_DESCCCCCCC, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Fecha", STR_PARAM(45, 720, 300, "left", 8), FONT_2)
                        .DrawText("Días", STR_PARAM(85, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Atenciones", STR_PARAM(200, 720, 300, "left", 8), FONT_2)
                        .DrawText("Cantidad Exámenes", STR_PARAM(300, 720, 80, "left", 8), FONT_2)
                        .DrawText("Venta", STR_PARAM(530, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Format(CDate(date_json_rial(z).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                        .DrawText(date_json_rial(z).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).E_Cantidad)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                        .DrawText((Integer.Parse(date_json_rial(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
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
                            .DrawText(Format(CDate(date_json_rial(z).E_Fecha), "dd/MM/yyyy"), STR_PARAM(45, eje_y, 300, "left", 6), FONT_1)
                            .DrawText(date_json_rial(z).E_Dias, STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).E_Cantidad)).ToString("#,##0"), STR_PARAM(250, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).CANT_EXA)).ToString("#,##0"), STR_PARAM(350, eje_y, 20, "right", 6), FONT_1)
                            .DrawText((Integer.Parse(date_json_rial(z).TOTA_SIS)).ToString("#,##0"), STR_PARAM(550, eje_y, 20, "right", 6), FONT_1)
                            .DrawText("_________________________________________________________________________________________________________________________________________________________", STR_PARAM(1, eje_y - 1, 605, "center", 7), FONT_1)
                            eje_y = eje_y - 9
                            contador_filas += 1
                        End With
                    End If
                    _C_Max += 1
                Next z
            End With
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class


Public Class E_List_wDict
    Private EE_List_Data As IEnumerable(Of Object)
    Public Property List_Data() As IEnumerable(Of Object)
        Get
            Return EE_List_Data
        End Get
        Set(ByVal value As IEnumerable(Of Object))
            EE_List_Data = value
        End Set
    End Property

    Private EE_Dictionary As Dictionary(Of String, Long)
    Public Property Dictionary() As Dictionary(Of String, Long)
        Get
            Return EE_Dictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Long))
            EE_Dictionary = value
        End Set
    End Property
End Class