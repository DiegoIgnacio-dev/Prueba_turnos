'Importar Bibliotecas
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Check_Val_Criticos
    'Declaraciones Generales
    Dim DD_Data As D_Check_Val_Criticos

    Sub New()
        DD_Data = New D_Check_Val_Criticos
    End Sub

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, ID_PROC)

    End Function

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_emb(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PROG As Long, ByVal ID_PRUE As Long, ByVal ID_RESUL As Long, ByVal ID_STAT As Integer, ByVal ID_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB(DESDE, HASTA, ID_CF, ID_PROG, ID_PRUE, ID_RESUL, ID_STAT, ID_SECC)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal SECCION As String) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, SECCION, ID_PROC)

    End Function
    Function IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_EST As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2(DESDE, HASTA, ID_EST)
    End Function
    Function IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2(ByVal DESDE As Date,
                                                       ByVal HASTA As Date,
                                                       ByVal ID_EST As Integer,
                                                       ByVal ID_PROC As Integer,
                                                        ByVal ID_PREVE As Integer,
                                                        ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2(DESDE, HASTA, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO)
    End Function
    Function IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2_ORINAS_SEDIMENTOS(ByVal DESDE As Date,
                                                       ByVal HASTA As Date,
                                                       ByVal ID_EST As Integer,
                                                       ByVal ID_PROC As Integer,
                                                        ByVal ID_PREVE As Integer,
                                                        ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2_ORINAS_SEDIMENTOS(DESDE, HASTA, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO)
    End Function
    Function Gen_Excel5(ByVal DOMAIN_URL As String, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PROg As Long, ByVal ID_PRUEB As Integer, ByVal ID_RESUL As Long, ByVal id_sta As Integer, ByVal ID_SECC As Integer) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PROGRA = ID_PROg) Then
                Select_Prev = List_Activo_02(y).PROGRA_DESC
                Exit For
            End If
        Next y

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB(DESDE, HASTA, ID_CF, ID_PROg, ID_PRUEB, ID_RESUL, id_sta, ID_SECC)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(16, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).ATE_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(10, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(11, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(12, y) = Data_OUT(y).SECC_DESC
            Mx_Data(13, y) = Data_OUT(y).PRU_DESC

            'Seleccionar valor
            Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
            Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

            If (Res_Str <> Nothing) Then
                Try
                    Mx_Data(14, y) = CDbl(Res_Str)
                Catch
                    Mx_Data(14, y) = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Mx_Data(14, y) = Res_Num
            Else
                If (Res_Alt <> Nothing) Then
                    Mx_Data(14, y) = Res_Alt
                Else
                    Mx_Data(14, y) = "-"
                End If

            End If
            'Limpiar Valores de Resultados
            Dim objValNum As String = Data_OUT(y).ATE_RESULTADO_NUM
            Dim objValStr As String = Data_OUT(y).ATE_RESULTADO

            If (IsNothing(objValNum) = False) Then
                objValNum = Trim(objValNum)
            End If

            If (IsNothing(objValStr) = False) Then
                objValStr = Trim(objValStr)
            End If

            If (Data_OUT(y).ID_TP_RESULTADO <> 1) Then
                Mx_Data(14, y) = objValNum
            Else
                Mx_Data(14, y) = objValStr
            End If
            Dim pru_Cero As Boolean
            If (Data_OUT(y).PRU_P_CERO > 0) Then
                pru_Cero = True
            Else
                pru_Cero = False
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then
                If ((pru_Cero = False) And (CDbl(Mx_Data(14, y).replace(",", ".")) = 0)) Then

                    Mx_Data(14, y) = ""
                End If
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then

                Dim numerito_3 As String
                Dim N_Dbl_3 As Double
                numerito_3 = Mx_Data(14, y)
                numerito_3 = numerito_3.Replace(",", ".")
                N_Dbl_3 = CDbl(Val(numerito_3))
                N_Dbl_3 = Math.Round(N_Dbl_3, CInt(Data_OUT(y).PRU_DECIMAL))

                Mx_Data(14, y) = N_Dbl_3
            End If

            Mx_Data(15, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

            Mx_Data(16, y) = Data_OUT(y).FONO

        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Críticos: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(DESDE, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(HASTA, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Progama: " & Select_Prev)


        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Críticos: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sección") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fono") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x

        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))

            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            ''Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_Criticos_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function Gen_Excel5_NEW(ByVal DOMAIN_URL As String, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PROg As Long, ByVal ID_PRUEB As Integer, ByVal ID_RESUL As Long, ByVal id_sta As Integer, ByVal ID_SECC As Integer, ByVal ID_PROCE As Integer, ByVal ID_PREVE As Integer) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PROGRA = ID_PROg) Then
                Select_Prev = List_Activo_02(y).PROGRA_DESC
                Exit For
            End If
        Next y

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_NEW(DESDE, HASTA, ID_CF, ID_PROg, ID_PRUEB, ID_RESUL, id_sta, ID_SECC, ID_PROCE, ID_PREVE)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(16, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).ATE_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(10, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(11, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(12, y) = Data_OUT(y).SECC_DESC
            Mx_Data(13, y) = Data_OUT(y).PRU_DESC

            'Seleccionar valor
            Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
            Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

            If (Res_Str <> Nothing) Then
                Try
                    Mx_Data(14, y) = CDbl(Res_Str)
                Catch
                    Mx_Data(14, y) = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Mx_Data(14, y) = Res_Num
            Else
                If (Res_Alt <> Nothing) Then
                    Mx_Data(14, y) = Res_Alt
                Else
                    Mx_Data(14, y) = "-"
                End If

            End If
            'Limpiar Valores de Resultados
            Dim objValNum As String = Data_OUT(y).ATE_RESULTADO_NUM
            Dim objValStr As String = Data_OUT(y).ATE_RESULTADO

            If (IsNothing(objValNum) = False) Then
                objValNum = Trim(objValNum)
            End If

            If (IsNothing(objValStr) = False) Then
                objValStr = Trim(objValStr)
            End If

            If (Data_OUT(y).ID_TP_RESULTADO <> 1) Then
                Mx_Data(14, y) = objValNum
            Else
                Mx_Data(14, y) = objValStr
            End If
            Dim pru_Cero As Boolean
            If (Data_OUT(y).PRU_P_CERO > 0) Then
                pru_Cero = True
            Else
                pru_Cero = False
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then
                If ((pru_Cero = False) And (CDbl(Mx_Data(14, y).replace(",", ".")) = 0)) Then

                    Mx_Data(14, y) = ""
                End If
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then

                Dim numerito_3 As String
                Dim N_Dbl_3 As Double
                numerito_3 = Mx_Data(14, y)
                numerito_3 = numerito_3.Replace(",", ".")
                N_Dbl_3 = CDbl(Val(numerito_3))
                N_Dbl_3 = Math.Round(N_Dbl_3, CInt(Data_OUT(y).PRU_DECIMAL))

                Mx_Data(14, y) = N_Dbl_3
            End If

            Mx_Data(15, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

            Mx_Data(16, y) = Data_OUT(y).FONO

        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Críticos: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(DESDE, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(HASTA, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Progama: " & Select_Prev)


        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Críticos: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sección") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fono") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x

        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))

            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            ''Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_Criticos_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PREVE = ID_PRE2) Then
                Select_Prev = List_Activo_02(y).PREVE_DESC
                Exit For
            End If
        Next y

        Dim Select_Stat As String = "Todos"
        Select Case ID_EST
            Case 1
                Select_Stat = "Bajo"
            Case 2
                Select_Stat = "Alto"
        End Select

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, ID_PROC)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(18, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).ATE_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            'Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(9, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(10, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(11, y) = Data_OUT(y).PRU_DESC

            'Seleccionar valor
            Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
            Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

            If (Res_Str <> Nothing) Then
                Try
                    Mx_Data(12, y) = CDbl(Res_Str)
                Catch
                    Mx_Data(12, y) = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Mx_Data(12, y) = Res_Num
            Else
                Mx_Data(12, y) = Res_Alt
            End If

            Mx_Data(13, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

            'Comprobar Rango
            Dim Rage As Integer = Data_OUT(y).ATE_RR_ALTOBAJO
            Select Case Rage
                Case 1
                    Mx_Data(14, y) = "B"
                Case 2
                    Mx_Data(14, y) = "A"
                Case Else
                    Mx_Data(14, y) = ""
            End Select

            Try
                Mx_Data(15, y) = CDbl(Data_OUT(y).ATE_RR_DESDE)
            Catch
                Mx_Data(15, y) = Data_OUT(y).ATE_RR_DESDE
            End Try

            Try
                Mx_Data(16, y) = CDbl(Data_OUT(y).ATE_R_DESDE)
            Catch
                Mx_Data(16, y) = Data_OUT(y).ATE_R_DESDE
            End Try

            Try
                Mx_Data(17, y) = CDbl(Data_OUT(y).ATE_R_HASTA)
            Catch
                Mx_Data(17, y) = Data_OUT(y).ATE_R_HASTA
            End Try

            Try
                Mx_Data(18, y) = CDbl(Data_OUT(y).ATE_RR_HASTA)
            Catch
                Mx_Data(18, y) = Data_OUT(y).ATE_RR_HASTA
            End Try

        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Críticos: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(DESDE, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(HASTA, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Previsión: " & Select_Prev)
        Xls.SetCellValue(6, 1, "Estado: " & Select_Stat)

        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Críticos: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alarma") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x

        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        'Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))

            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/MM/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_Criticos_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function


    Function Gen_Excel2(ByVal DOMAIN_URL As String, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal SECCION As String) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PREVE = ID_PRE2) Then
                Select_Prev = List_Activo_02(y).PREVE_DESC
                Exit For
            End If
        Next y

        Dim Select_Stat As String = "Todos"
        Select Case ID_EST
            Case 1
                Select_Stat = "Bajo"
            Case 2
                Select_Stat = "Alto"
        End Select

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = HttpContext.Current.Request.Cookies("USU_ID_PROC").Value
        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, SECCION, ID_PROC)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(18, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        Dim ccc As Integer = 0
        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)

            Dim Calc_Age As New N_Calc_Age
            If (C_P_ADMIN = Data_OUT(y).id_proce Or C_P_ADMIN = 0) Then
                If (ccc > 0) Then
                    ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), ccc)
                End If

                Mx_Data(0, ccc) = Data_OUT(y).ATE_NUM
                Mx_Data(1, ccc) = Data_OUT(y).PAC_RUT
                Mx_Data(2, ccc) = Data_OUT(y).ATE_DNI
                Mx_Data(3, ccc) = Data_OUT(y).NAC_DESC
                Mx_Data(4, ccc) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
                Mx_Data(5, ccc) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
                Mx_Data(6, ccc) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
                Mx_Data(7, ccc) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(8, ccc) = Data_OUT(y).PROC_DESC
                'Mx_Data(9, ccc) = Data_OUT(y).ATE_NUM_INTERNO
                Mx_Data(9, ccc) = Data_OUT(y).PROGRA_DESC
                Mx_Data(10, ccc) = Data_OUT(y).SECTOR_DESC
                Mx_Data(11, ccc) = Data_OUT(y).PRU_DESC

                'Seleccionar valor
                Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
                Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
                Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

                If (Res_Str <> Nothing) Then
                    Try
                        Mx_Data(12, ccc) = CDbl(Res_Str)
                    Catch
                        Mx_Data(12, ccc) = Res_Str
                    End Try
                ElseIf (Res_Num <> Nothing) Then
                    Mx_Data(12, ccc) = Res_Num
                Else
                    Mx_Data(12, ccc) = Res_Alt
                End If

                Mx_Data(13, ccc) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

                'Comprobar Rango

                Mx_Data(14, ccc) = Data_OUT(y).ATE_RESULTADO_ALT

                Try
                    Mx_Data(15, ccc) = CDbl(Data_OUT(y).ATE_RR_DESDE)
                Catch
                    Mx_Data(15, ccc) = Data_OUT(y).ATE_RR_DESDE
                End Try

                Try
                    Mx_Data(16, ccc) = CDbl(Data_OUT(y).ATE_R_DESDE)
                Catch
                    Mx_Data(16, ccc) = Data_OUT(y).ATE_R_DESDE
                End Try

                Try
                    Mx_Data(17, ccc) = CDbl(Data_OUT(y).ATE_R_HASTA)
                Catch
                    Mx_Data(17, ccc) = Data_OUT(y).ATE_R_HASTA
                End Try

                Try
                    Mx_Data(18, ccc) = CDbl(Data_OUT(y).ATE_RR_HASTA)
                Catch
                    Mx_Data(18, ccc) = Data_OUT(y).ATE_RR_HASTA
                End Try


                ccc = ccc + 1
            End If


        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Alterados: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(DESDE, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(HASTA, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Previsión: " & Select_Prev)
        Xls.SetCellValue(6, 1, "Estado: " & Select_Stat)

        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)
        Xls.SetCellStyle(6, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)
        Xls.MergeWorksheetCells(6, 1, 6, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Alterados: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alarma") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x

        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        'Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/MM/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_alterados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_emb_2(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Long,
                                                                ByVal ID_PROG As Long,
                                                                ByVal ID_PRUE As Long,
                                                                ByVal ID_RESUL As Long,
                                                                ByVal ID_STAT As Integer,
                                                                ByVal ID_SECC As Integer,
                                                                ByVal ID_PROCE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2(DESDE, HASTA, ID_CF, ID_PROG, ID_PRUE, ID_RESUL, ID_STAT, ID_SECC, ID_PROCE)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_emb_NEW(ByVal DESDE As Date,
                                                               ByVal HASTA As Date,
                                                               ByVal ID_CF As Long,
                                                               ByVal ID_PROG As Long,
                                                               ByVal ID_PRUE As Long,
                                                               ByVal ID_RESUL As Long,
                                                               ByVal ID_STAT As Integer,
                                                               ByVal ID_SECC As Integer,
                                                               ByVal ID_PROCE As Integer,
                                                               ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_NEW(DESDE, HASTA, ID_CF, ID_PROG, ID_PRUE, ID_RESUL, ID_STAT, ID_SECC, ID_PROCE, ID_PREVE)
    End Function

    Function Gen_ExcelRELLLLL2(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String,
                                          ByVal DATE_str02 As String,
                                          ByVal ID_EST As Integer,
                                          ByVal ID_PROC As Integer,
                                          ByVal ID_PREVE As Integer,
                                          ByVal ID_ESTADO As Integer) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        'Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)

        'List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        'List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO

        'Dim Select_Exam As String = "Todos"
        'For y = 0 To (List_Activo_01.Count - 1)
        '    If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
        '        Select_Exam = List_Activo_01(y).CF_DESC
        '        Exit For
        '    End If
        'Next y

        'Dim Select_Prev As String = "Todos"
        'For y = 0 To (List_Activo_02.Count - 1)
        '    If (List_Activo_02(y).ID_PROGRA = ID_PROg) Then
        '        Select_Prev = List_Activo_02(y).PROGRA_DESC
        '        Exit For
        '    End If
        'Next y

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2(DATE_str01, DATE_str02, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(17, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        Dim validados As Integer = 0
        Dim en_espera As Integer = 0

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).ATE_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Data_OUT(y).ATE_AÑO & "A " & Data_OUT(y).ATE_MES & "M " & Data_OUT(y).ATE_DIA & "D"
            'Mx_Data(6, y) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(10, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(11, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(12, y) = ""
            Mx_Data(13, y) = Data_OUT(y).PRU_DESC

            'Seleccionar valor
            Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
            Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

            If (Res_Str <> Nothing) Then
                Try
                    Mx_Data(14, y) = CDbl(Res_Str)
                Catch
                    Mx_Data(14, y) = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Mx_Data(14, y) = Res_Num
            Else
                If (Res_Alt <> Nothing) Then
                    Mx_Data(14, y) = Res_Alt
                Else
                    Mx_Data(14, y) = "-"
                End If

            End If
            'Limpiar Valores de Resultados
            Dim objValNum As String = Data_OUT(y).ATE_RESULTADO_NUM
            Dim objValStr As String = Data_OUT(y).ATE_RESULTADO

            If (IsNothing(objValNum) = False) Then
                objValNum = Trim(objValNum)
            End If

            If (IsNothing(objValStr) = False) Then
                objValStr = Trim(objValStr)
            End If

            If (Data_OUT(y).ID_TP_RESULTADO <> 1) Then
                Mx_Data(14, y) = objValNum
            Else
                Mx_Data(14, y) = objValStr
            End If
            Dim pru_Cero As Boolean
            If (Data_OUT(y).PRU_P_CERO > 0) Then
                pru_Cero = True
            Else
                pru_Cero = False
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then
                If ((pru_Cero = False) And (CDbl(Mx_Data(14, y).replace(",", ".")) = 0)) Then

                    Mx_Data(14, y) = ""
                End If
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then

                Dim numerito_3 As String
                Dim N_Dbl_3 As Double
                numerito_3 = Mx_Data(14, y)
                numerito_3 = numerito_3.Replace(",", ".")
                N_Dbl_3 = CDbl(Val(numerito_3))
                N_Dbl_3 = Math.Round(N_Dbl_3, CInt(Data_OUT(y).PRU_DECIMAL))

                Mx_Data(14, y) = N_Dbl_3
            End If

            Mx_Data(15, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

            Mx_Data(16, y) = Data_OUT(y).FONO

            If (Data_OUT(y).ATE_EST_VALIDA = 6 Or Data_OUT(y).ATE_EST_VALIDA = "6" Or Data_OUT(y).ATE_EST_VALIDA = 14 Or Data_OUT(y).ATE_EST_VALIDA = "14") Then
                validados += 1
                Mx_Data(17, y) = "Validado"
            Else
                en_espera += 1
                Mx_Data(17, y) = "En Espera"
            End If



        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Estadísticas:  ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & DATE_str01)
        Xls.SetCellValue(3, 1, "Fecha hasta: " & DATE_str02)

        Xls.SetCellValue(4, 1, "Cant. En Espera: " & en_espera)
        Xls.SetCellValue(5, 1, "Cant. validados: " & validados)



        'Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        'Xls.SetCellValue(5, 1, "Progama: " & Select_Prev)


        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Estadísticas: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sección") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fono") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Estado") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x

        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'Estado
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))

            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            ''Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Estadísticas_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function Gen_ExcelRELLLLL2_ORINA_SEDI(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String,
                                        ByVal DATE_str02 As String,
                                        ByVal ID_EST As Integer,
                                        ByVal ID_PROC As Integer,
                                        ByVal ID_PREVE As Integer,
                                        ByVal ID_ESTADO As Integer) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        'Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)

        'List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        'List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO

        'Dim Select_Exam As String = "Todos"
        'For y = 0 To (List_Activo_01.Count - 1)
        '    If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
        '        Select_Exam = List_Activo_01(y).CF_DESC
        '        Exit For
        '    End If
        'Next y

        'Dim Select_Prev As String = "Todos"
        'For y = 0 To (List_Activo_02.Count - 1)
        '    If (List_Activo_02(y).ID_PROGRA = ID_PROg) Then
        '        Select_Prev = List_Activo_02(y).PROGRA_DESC
        '        Exit For
        '    End If
        'Next y

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2_ORINAS_SEDIMENTOS(DATE_str01, DATE_str02, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(17, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        Dim validados As Integer = 0
        Dim en_espera As Integer = 0

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).ATE_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Data_OUT(y).ATE_AÑO & "A " & Data_OUT(y).ATE_MES & "M " & Data_OUT(y).ATE_DIA & "D"
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(10, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(11, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(12, y) = ""
            Mx_Data(13, y) = Data_OUT(y).PRU_DESC

            'Seleccionar valor
            Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
            Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

            If (Res_Str <> Nothing) Then
                Try
                    Mx_Data(14, y) = CDbl(Res_Str)
                Catch
                    Mx_Data(14, y) = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Mx_Data(14, y) = Res_Num
            Else
                If (Res_Alt <> Nothing) Then
                    Mx_Data(14, y) = Res_Alt
                Else
                    Mx_Data(14, y) = "-"
                End If

            End If
            'Limpiar Valores de Resultados
            Dim objValNum As String = Data_OUT(y).ATE_RESULTADO_NUM
            Dim objValStr As String = Data_OUT(y).ATE_RESULTADO

            If (IsNothing(objValNum) = False) Then
                objValNum = Trim(objValNum)
            End If

            If (IsNothing(objValStr) = False) Then
                objValStr = Trim(objValStr)
            End If

            If (Data_OUT(y).ID_TP_RESULTADO <> 1) Then
                Mx_Data(14, y) = objValNum
            Else
                Mx_Data(14, y) = objValStr
            End If
            Dim pru_Cero As Boolean
            If (Data_OUT(y).PRU_P_CERO > 0) Then
                pru_Cero = True
            Else
                pru_Cero = False
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then
                If ((pru_Cero = False) And (CDbl(Mx_Data(14, y).replace(",", ".")) = 0)) Then

                    Mx_Data(14, y) = ""
                End If
            End If
            If ((IsNumeric(Mx_Data(14, y)) = True)) Then

                Dim numerito_3 As String
                Dim N_Dbl_3 As Double
                numerito_3 = Mx_Data(14, y)
                numerito_3 = numerito_3.Replace(",", ".")
                N_Dbl_3 = CDbl(Val(numerito_3))
                N_Dbl_3 = Math.Round(N_Dbl_3, CInt(Data_OUT(y).PRU_DECIMAL))

                Mx_Data(14, y) = N_Dbl_3
            End If

            Mx_Data(15, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

            Mx_Data(16, y) = Data_OUT(y).FONO

            If (Data_OUT(y).ATE_EST_VALIDA = 6 Or Data_OUT(y).ATE_EST_VALIDA = "6" Or Data_OUT(y).ATE_EST_VALIDA = 14 Or Data_OUT(y).ATE_EST_VALIDA = "14") Then
                validados += 1
                Mx_Data(17, y) = "Validado"
            Else
                en_espera += 1
                Mx_Data(17, y) = "En Espera"
            End If



        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Estadísticas:  ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & DATE_str01)
        Xls.SetCellValue(3, 1, "Fecha hasta: " & DATE_str02)

        Xls.SetCellValue(4, 1, "Cant. En Espera: " & en_espera)
        Xls.SetCellValue(5, 1, "Cant. validados: " & validados)



        'Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        'Xls.SetCellValue(5, 1, "Progama: " & Select_Prev)


        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Estadísticas: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sección") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fono") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Estado") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        'Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x

        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'Estado
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        'Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))

            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            ''Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Estadísticas_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class