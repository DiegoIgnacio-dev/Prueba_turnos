Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Public Class Prev_TM_Exa_Mult_Valid_OMI_GROUP
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prev() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Prev.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Proce() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(0)
        If (Data_Proce.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Proce, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Medi() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Medi As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Consultar por previsiones activas
        Data_Medi = NN_Activos.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()
        If (Data_Medi.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Medi, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Exa As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Consultar por previsiones activas
        Data_Exa = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exa.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Exa, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_TP_PAGO As Long,
                                            ByVal ID_PRE As Long,
                                            ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long,
                                            ByVal DATE_str01 As String,
                                            ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer 'challa
        Dim str_Builder As New StringBuilder 'challa
        'Declaraciones internas
        Dim NN_Date As New N_Date 'challa
        Dim NN_TM_Prevision As New N_Prev_TM_Exa_Mult_Valid
        Dim NN_BUSCA_TOT_OMI As New N_IRIS_BUSCA_CANTIDAD_EXA_POR_CF_OMI
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_OMI(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)

        Dim obj_Data As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
        Dim List_Tot_Omi As New List(Of E_BUSCA_TOT_OMI)

        List_Tot_Omi = NN_BUSCA_TOT_OMI.BUSCA_TOT_OMI(DATE_str01, DATE_str02)

        If (Data_TM_Provision.Count > 0) Then

            Dim Data_Final As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)

            For Each _data In Data_TM_Provision

                obj_Data = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
                'If _data.ID_CODIGO_FONASA <> 72 And _data.ID_CODIGO_FONASA <> 73 And _data.ID_CODIGO_FONASA <> 75 Then

                obj_Data.ID_CODIGO_FONASA = _data.ID_CODIGO_FONASA
                obj_Data.CF_COD = _data.CF_COD
                obj_Data.CF_DESC = _data.CF_DESC
                obj_Data.CF_OMI = _data.CF_OMI
                obj_Data.TOT_FONASA = _data.TOT_FONASA

                For Each _Omi In List_Tot_Omi
                    If _Omi.DESCRIPCION_EXAMEN = _data.CF_DESC Or (_data.CF_DESC = "PSA Total" And _Omi.DESCRIPCION_EXAMEN = "ANTIGENO PROSTATICO ESPECIFICO") Or (_data.CF_DESC = "VHS" And _Omi.DESCRIPCION_EXAMEN = "VELOCIDAD DE ERITROSEDIMENTACION (PROC. AUT.)") Then
                        obj_Data.TOT_OMI = _Omi.CANTIDAD_EXAMEN
                    End If
                Next


                Data_Final.Add(obj_Data)

                ' End If

            Next




            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Final, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_GROUP(ByVal ID_TP_PAGO As Long,
                                            ByVal ID_PRE As Long,
                                            ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long,
                                            ByVal DATE_str01 As String,
                                            ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_TM_Prevision As New N_Prev_TM_Exa_Mult_Valid
        Dim NN_BUSCA_TOT_OMI As New N_IRIS_BUSCA_CANTIDAD_EXA_POR_CF_OMI
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_OMI(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)

        Dim obj_Data As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
        Dim List_Tot_Omi As New List(Of E_BUSCA_TOT_OMI)

        List_Tot_Omi = NN_BUSCA_TOT_OMI.BUSCA_TOT_OMI(DATE_str01, DATE_str02)

        If (Data_TM_Provision.Count > 0) Then

            Dim Data_Final As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)

            For Each _data In Data_TM_Provision

                obj_Data = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED

                obj_Data.ID_CODIGO_FONASA = _data.ID_CODIGO_FONASA
                obj_Data.CF_COD = _data.CF_COD
                obj_Data.CF_DESC = _data.CF_DESC
                obj_Data.CF_OMI = _data.CF_OMI
                obj_Data.TOT_FONASA = _data.TOT_FONASA

                For Each _Omi In List_Tot_Omi
                    If _Omi.DESCRIPCION_EXAMEN = _data.CF_DESC Or (_data.CF_DESC = "PSA Total" And _Omi.DESCRIPCION_EXAMEN = "ANTIGENO PROSTATICO ESPECIFICO") Or (_data.CF_DESC = "VHS" And _Omi.DESCRIPCION_EXAMEN = "VELOCIDAD DE ERITROSEDIMENTACION (PROC. AUT.)") Then
                        obj_Data.TOT_OMI = _Omi.CANTIDAD_EXAMEN
                    End If
                Next


                Data_Final.Add(obj_Data)

            Next
            '*************************************************************************************************************************************************
            Dim tiempo_protrombina As Boolean = False
            Dim creatinina As Boolean = False
            Dim hemorragia As Boolean = False
            Dim electrolitos As Boolean = False
            Dim albumina_proteTotales As Boolean = False
            Dim transaminasas As Boolean = False
            Dim cultivo As Boolean = False
            Dim microalbu As Boolean = False
            Dim orina As Boolean = False
            Dim nota_a As Boolean = False
            Dim nota_b As Boolean = False

            Dim tiempo_protrombina_cant As Integer = 0
            Dim creatinina_cant As Integer = 0
            Dim hemorragia_cant As Integer = 0
            Dim electrolitos_cant As Integer = 0
            Dim albumina_proteTotales_cant As Integer = 0
            Dim transaminasas_cant As Integer = 0
            Dim cultivo_cant As Integer = 0
            Dim microalbu_cant As Integer = 0
            Dim orina_cant As Integer = 0
            Dim nota_a_cant As Integer = 0
            Dim nota_b_cant As Integer = 0

            If Data_Final.Count > 0 Then
                For Each item In Data_Final
                    Dim obj_agrupado As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED

                    'tiempo_protrombina
                    If (item.CF_OMI = "00036-2012") Then
                        tiempo_protrombina_cant += 1
                    End If

                    'creatinina
                    If (item.CF_OMI = "011-2012") Then
                        creatinina_cant += 1
                    End If

                    'hemorragia
                    If (item.CF_OMI = "025-2012C") Then
                        hemorragia_cant += 1
                    End If

                    'Electrolitos Plasmaticos
                    If (item.CF_COD = "0302032" Or item.CF_COD = "0302032-1" Or item.CF_COD = "0302032-2" Or item.CF_COD = "0302032-3") Then
                        electrolitos_cant += 1
                    End If

                    'albumina_proteTotales
                    If (item.CF_COD = "0302060" Or item.CF_COD = "0302060-1") Then
                        albumina_proteTotales_cant += 1
                    End If

                    'transaminasas
                    If (item.CF_COD = "0302063" Or item.CF_COD = "0302063-1") Then
                        transaminasas_cant += 1
                    End If

                    'cultivo
                    If (item.CF_COD = "0306008" Or item.CF_COD = "0306008-1") Then
                        cultivo_cant += 1
                    End If

                    'microalbu
                    If (item.CF_COD = "0309013" Or item.CF_COD = "0309013-2") Then
                        microalbu_cant += 1
                    End If

                    'orina
                    If (item.CF_COD = "0309022" Or item.CF_COD = "0309022-1") Then
                        orina_cant += 1
                    End If

                    'nota_a
                    If (item.CF_COD = "1-1" Or item.CF_COD = "1-2" Or item.CF_COD = "1-3" Or item.CF_COD = "1-4" Or item.CF_COD = "1-7") Then
                        nota_a_cant += 1
                    End If

                    'nota_b
                    If (item.CF_COD = "123-2" Or item.CF_COD = "123-3" Or item.CF_COD = "123-4" Or item.CF_COD = "123-6" Or item.CF_COD = "123-7") Then
                        nota_b_cant += 1
                    End If




                    Data_Final.Add(obj_agrupado)

                Next
            Else
                Exit Function
            End If


            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(Data_Final, str_Builder)
                Return str_Builder.ToString
            Else
                Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal ID_TP_PAGO As Long,
                                            ByVal ID_PRE As Long,
                                            ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long,
                                            ByVal DATE_str01 As String,
                                            ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN_Date As New N_Date 'challa
        Dim NN_TM_Prevision As New N_Prev_TM_Exa_Mult_Valid
        Dim NN_BUSCA_TOT_OMI As New N_IRIS_BUSCA_CANTIDAD_EXA_POR_CF_OMI
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_OMI(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)

        Dim obj_Data As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
        Dim List_Tot_Omi As New List(Of E_BUSCA_TOT_OMI)
        Dim Data_Final As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        List_Tot_Omi = NN_BUSCA_TOT_OMI.BUSCA_TOT_OMI(DATE_str01, DATE_str02)

        If (Data_TM_Provision.Count > 0) Then



            For Each _data In Data_TM_Provision

                obj_Data = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
                'If _data.ID_CODIGO_FONASA <> 72 And _data.ID_CODIGO_FONASA <> 73 And _data.ID_CODIGO_FONASA <> 75 Then

                obj_Data.ID_CODIGO_FONASA = _data.ID_CODIGO_FONASA
                obj_Data.CF_COD = _data.CF_COD
                obj_Data.CF_DESC = _data.CF_DESC
                obj_Data.CF_OMI = _data.CF_OMI
                obj_Data.TOT_FONASA = _data.TOT_FONASA

                For Each _Omi In List_Tot_Omi
                    If _Omi.DESCRIPCION_EXAMEN = _data.CF_DESC Or (_data.CF_DESC = "PSA Total" And _Omi.DESCRIPCION_EXAMEN = "ANTIGENO PROSTATICO ESPECIFICO") Or (_data.CF_DESC = "VHS" And _Omi.DESCRIPCION_EXAMEN = "VELOCIDAD DE ERITROSEDIMENTACION (PROC. AUT.)") Then
                        obj_Data.TOT_OMI = _Omi.CANTIDAD_EXAMEN
                    End If
                Next


                Data_Final.Add(obj_Data)

                ' End If

            Next
        Else
            Return Nothing
            Exit Function
        End If
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument

        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim edad As Integer = 0
        Dim idate As String = ""


        Dim Mx_Data(10, 0) As Object



        '--------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Crear nuevo Dcto
        Dim xls As New SLDocument
        Dim RowH As Integer = 10

        'Definir estilos
        Dim css_Title = xls.CreateStyle
        css_Title.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_Title.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_Title.Font.Bold = True
        css_Title.Font.FontName = "Calibri"
        css_Title.Font.FontSize = 11

        Dim css_SubTitle = xls.CreateStyle
        css_SubTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_SubTitle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_SubTitle.Font.Bold = True
        css_SubTitle.Font.FontName = "Calibri"
        css_SubTitle.Font.FontSize = 10

        Dim css_THead = xls.CreateStyle
        css_THead.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_THead.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_THead.Font.Bold = True
        css_THead.Font.FontName = "Calibri"
        css_THead.Font.FontSize = 10
        'css_THead.Font.FontColor = System.Drawing.Color.White
        css_THead.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.White, System.Drawing.Color.Orange)

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

        Dim css_TCell_center_yellow = xls.CreateStyle
        css_TCell_center_yellow.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_yellow.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_yellow.Font.Bold = False
        css_TCell_center_yellow.Font.FontSize = 10
        css_TCell_center_yellow.Font.FontName = "Calibri"
        css_TCell_center_yellow.Font.FontColor = System.Drawing.Color.Gold

        Dim css_TCell_center_red = xls.CreateStyle
        css_TCell_center_red.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_red.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_red.Font.Bold = False
        css_TCell_center_red.Font.FontSize = 10
        css_TCell_center_red.Font.FontName = "Calibri"
        css_TCell_center_red.Font.FontColor = System.Drawing.Color.Red


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
        xls.SetCellValue(1, 1, "Envíos Datos OMI")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)
        xls.SetCellValue(2, 1, "Desde: " & DATE_str01)
        xls.SetCellValue(3, 1, "Hasta: " & DATE_str02)


        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 2, 3)

        'xls.SetCellValue(3, 1, "Hasta: " & HASTA)
        'xls.SetCellStyle(3, 1, css_SubTitle)
        'xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 1
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 05)
        xls.SetColumnWidth(3, RowH + 20)
        xls.SetColumnWidth(4, RowH + 10)
        xls.SetColumnWidth(5, RowH + 10)
        xls.SetColumnWidth(6, RowH + 10)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Código") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Exámenes") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant_Exámenes") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cant. OMI") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Cod. OMI") : x2 += 1

        For Each _data In Data_Final

            obj_Data = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED
            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, _data.CF_COD) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, _data.CF_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, _data.TOT_FONASA) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, _data.TOT_OMI) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, _data.CF_OMI) : x2 = x1

            xi += 1

            indice_if += 1
        Next



        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Envios_Datos_OMI" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Private Sub Prev_TM_Exa_Mult_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

End Class