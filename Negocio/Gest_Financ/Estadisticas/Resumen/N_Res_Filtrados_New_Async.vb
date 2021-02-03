Imports Datos
Imports Entidades

Imports System.Threading.Tasks
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Public Class N_Res_Filtrados_New_Async
    Dim D_Data As D_Res_Filtrados_New_Async

    Dim DATE_01 As Date
    Dim DATE_02 As Date
    Dim ID_PROC As Integer
    Dim ID_PREV As Integer
    Dim ID_PROG As Integer
    Dim ID_SUBP As Integer
    Dim EMAIL As String
    Dim ARRTEXT As String()
    Dim ALL_EXA As Boolean

    Dim strLocal As String
    Dim strFilename As String
    Dim URL_Base As String
    Dim User As String

    Sub New(ByVal xstrLocal As String, ByVal xURL As String,
            ByVal xDATE_01 As Date, ByVal xDATE_02 As Date,
            ByVal xID_PROC As Integer, ByVal xID_PREV As Integer,
            ByVal xID_PROG As Integer, ByVal xID_SUBP As Integer,
            ByVal xEMAIL As String, ByVal xARRTEXT As String(), ByVal xALL_EXA As Boolean, ByVal xUser As String)
        D_Data = New D_Res_Filtrados_New_Async

        DATE_01 = xDATE_01
        DATE_02 = xDATE_02
        ID_PROC = xID_PROC
        ID_PREV = xID_PREV
        ID_PROG = xID_PROG
        ID_SUBP = xID_SUBP
        EMAIL = xEMAIL
        ARRTEXT = xARRTEXT
        ALL_EXA = xALL_EXA

        strLocal = xstrLocal
        URL_Base = xURL
        User = xUser
    End Sub

    Public Function Gen_Data() As List(Of E_Async_Res_All)
        Dim List_Data As New List(Of E_Async_Res_All)

        List_Data = D_Data.Busca_Atenciones(DATE_01, DATE_02, ID_PROC, ID_PREV, ID_PROG, ID_SUBP)
        Dim Tot_Exa As Long = 0
        Dim Total_Res As Long = 0

        Dim Date_Init As Date = Date.Now

        If (List_Data.Count = 0) Then
            Return List_Data
        End If

        Dim LOG As New N_Log
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "dd-MM-yyyy - !") & User & ".txt"

        LOG.Write_Line("Se ha Iniciado Solicitud de Resultados Filtrados:")
        LOG.Write_Line("<space/>    - Desde         : " & Format(DATE_01, "dd/MM/yyyy"), False)
        LOG.Write_Line("<space/>    - Hasta         : " & Format(DATE_02, "dd/MM/yyyy"), False)
        LOG.Write_Line("<space/>    - Procedencia   : " & ARRTEXT(0), False)
        LOG.Write_Line("<space/>    - Previsión     : " & ARRTEXT(1), False)
        LOG.Write_Line("<space/>    - Programa      : " & ARRTEXT(2), False)
        LOG.Write_Line("<space/>    - Subprograma   : " & ARRTEXT(3), False)
        LOG.Write_Line("<space/>    - Ver Todos     : " & ALL_EXA, False)
        LOG.Write_Line("", False)
        For y = 0 To (List_Data.Count - 1)
            Dim ID_ATE As String = List_Data(y).ID_ATENCION
            D_Data = New D_Res_Filtrados_New_Async

            List_Data(y).VALUES = D_Data.Busca_Atenciones_Values(ID_ATE, ALL_EXA)
        Next y

        'Calcular tiempo
        Dim xTime As String
        Dim hh As Integer = 0
        Dim mm As Integer = 0
        Dim ss As Integer = 0
        ss = DateDiff(DateInterval.Second, Date_Init, Date.Now)
        While (ss >= 60)
            mm += 1
            ss -= 60
        End While
        While (mm >= 60)
            hh += 1
            mm -= 60
        End While
        xTime = Format(hh, "00") & ":" & Format(mm, "00") & ":" & Format(ss, "00")
        LOG.Write_Line("Consulta completada en " & xTime)

        Return List_Data
    End Function

    Public Sub Gen_Excel()
        Dim LOG As New N_Log
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "dd-MM-yyyy - !") & User & ".txt"

        Try
            Dim NN_REX As New N_Res_Filtrados_New_Async(strLocal, URL_Base, DATE_01, DATE_02, ID_PROC, ID_PREV, ID_PROG, ID_SUBP, EMAIL, ARRTEXT, ALL_EXA, User)
            Dim List_Data As New List(Of E_Async_Res_All)
            List_Data = NN_REX.Gen_Data()

            LOG.Write_Line("Armando Excel...")
            LOG.Write_Line("<space/>    Total pacientes = " & List_Data.Count, False)
            LOG.Write_Line("", False)


            'PREPARAR CORREO
            Dim NN_CORREO As New N_EMAIL
            NN_CORREO.Set_Destinat = EMAIL
            NN_CORREO.Set_Asunto = "Resultados Filtrados Prev. [" & Me.ARRTEXT(1) & "] - " & Format(DATE_01, "dd/MM/yyyy") & " - " & Format(DATE_02, "dd/MM/yyyy")
            If ((URL_Base.Contains("http:\\") = False) And (URL_Base.Contains("https:\\") = False)) Then
                URL_Base = "http:\\" & URL_Base
            End If

            'Comprobar si se generaron resultados
            If (List_Data.Count = 0) Then
                LOG.Write_Line("La búsqueda no arrojó resultados...")
                LOG.Write_Line("Armando y enviando Correo")

                URL_Base = URL_Base.Replace("\", "/")
                Dim XHTML As String = Write_Email(DATE_01, DATE_02, Nothing, URL_Base)
                NN_CORREO.Send_Email(XHTML)

                LOG.Write_Line("Correo enviado correctamente")
                LOG.Write_Separator()

                Return
            End If

            Dim Date_Init As Date = Date.Now
            Dim x1 As Integer = 1
            Dim y1 As Integer = 9
            Dim x2 As Integer = 0
            Dim y2 As Integer = 0


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
            css_THead.Font.FontSize = 12
            css_THead.Font.FontName = "Calibri"
            css_THead.Font.FontColor = System.Drawing.Color.White

            Dim css_TCell_left = xls.CreateStyle
            css_TCell_left.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
            css_TCell_left.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
            css_TCell_left.Font.Bold = False
            css_TCell_left.Font.FontSize = 10
            css_TCell_left.Font.FontName = "Calibri"

            Dim css_TCell_center = xls.CreateStyle
            css_TCell_center.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            css_TCell_center.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
            css_TCell_center.Font.Bold = False
            css_TCell_center.Font.FontSize = 10
            css_TCell_center.Font.FontName = "Calibri"

            Dim css_TCell_right = xls.CreateStyle
            css_TCell_right.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
            css_TCell_right.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
            css_TCell_right.Font.Bold = False
            css_TCell_right.Font.FontSize = 10
            css_TCell_right.Font.FontName = "Calibri"

            Dim css_TCell_Date = xls.CreateStyle
            css_TCell_Date.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            css_TCell_Date.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
            css_TCell_Date.Font.Bold = False
            css_TCell_Date.Font.FontSize = 10
            css_TCell_Date.FormatCode = "dd/mm/yyyy"

            'Colocar Título
            If (ALL_EXA = True) Then
                xls.SetCellValue(1, 1, "Resultados Filtrados (Todos los Resultados)")
            Else
                xls.SetCellValue(1, 1, "Resultados Filtrados (Solo 1er Resultado)")
            End If
            xls.SetCellStyle(1, 1, css_Title)
            xls.MergeWorksheetCells(1, 1, 1, 4)

            xls.SetCellValue(2, 1, "Desde: " & Format(DATE_01, "dd/MM/yyyy"))
            xls.SetCellStyle(2, 1, css_SubTitle)
            xls.MergeWorksheetCells(2, 1, 2, 3)

            xls.SetCellValue(3, 1, "Hasta: " & Format(DATE_02, "dd/MM/yyyy"))
            xls.SetCellStyle(3, 1, css_SubTitle)
            xls.MergeWorksheetCells(3, 1, 3, 3)

            xls.SetCellValue(4, 1, "Procedencia: " & ARRTEXT(0))
            xls.SetCellStyle(4, 1, css_SubTitle)
            xls.MergeWorksheetCells(4, 1, 4, 3)

            xls.SetCellValue(5, 1, "Previsión: " & ARRTEXT(1))
            xls.SetCellStyle(5, 1, css_SubTitle)
            xls.MergeWorksheetCells(5, 1, 5, 3)

            'xls.SetCellValue(6, 1, "Programa: " & ARRTEXT(2))
            'xls.SetCellStyle(6, 1, css_SubTitle)
            'xls.MergeWorksheetCells(6, 1, 6, 3)

            'xls.SetCellValue(7, 1, "Subprograma: " & ARRTEXT(3))
            'xls.SetCellStyle(7, 1, css_SubTitle)
            'xls.MergeWorksheetCells(7, 1, 7, 3)

            'Colocar Cabeceras
            x2 = x1
            xls.SetCellValue(y1, x2, "N° Atención") : x2 += 1
            xls.SetCellValue(y1, x2, "Fecha") : x2 += 1
            xls.SetCellValue(y1, x2, "RUT") : x2 += 1
            xls.SetCellValue(y1, x2, "Nombre Paciente") : x2 += 1
            xls.SetCellValue(y1, x2, "Sexo") : x2 += 1
            xls.SetCellValue(y1, x2, "F. Nac.") : x2 += 1
            xls.SetCellValue(y1, x2, "Edad") : x2 += 1
            xls.SetCellValue(y1, x2, "RUT Doctor") : x2 += 1
            xls.SetCellValue(y1, x2, "Nombre Doctor") : x2 += 1
            xls.SetCellValue(y1, x2, "Cod. Fonasa") : x2 += 1
            xls.SetCellValue(y1, x2, "Exámen") : x2 += 1
            xls.SetCellValue(y1, x2, "Determinación") : x2 += 1
            xls.SetCellValue(y1, x2, "Resultado") : x2 += 1
            xls.SetCellValue(y1, x2, "Unidad") : x2 += 1
            xls.SetCellValue(y1, x2, "Procedencia") : x2 += 1
            xls.SetCellValue(y1, x2, "Previsión") : x2 += 1
            xls.SetCellValue(y1, x2, "Programa") : x2 += 1
            xls.SetCellValue(y1, x2, "Sub Programa") : x2 += 1
            'xls.SetCellValue(y1, x2, "OC") : x2 += 1
            x2 -= 1

            For i = 1 To 18
                xls.SetCellStyle(9, i, css_THead)
            Next

            x2 = x1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 15) : x2 += 1
            xls.SetColumnWidth(x2, 50) : x2 += 1
            xls.SetColumnWidth(x2, 15) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 15) : x2 += 1
            xls.SetColumnWidth(x2, 50) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 55) : x2 += 1
            xls.SetColumnWidth(x2, 35) : x2 += 1
            xls.SetColumnWidth(x2, 40) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            'xls.SetColumnWidth(x2, 25) : x2 += 1
            x2 -= 1

            'Rellenar Campos
            Dim xIndex As Integer = 0
            For y = 0 To (List_Data.Count - 1)
                If (((y + 1) Mod 1000 = 0) Or (y = List_Data.Count - 1)) Then
                    Dim xStrN As String = CStr(y + 1)
                    While (xStrN.Length < CStr(List_Data.Count).Length)
                        xStrN = "0" & xStrN
                    End While
                    LOG.Write_Line("Pacientes Registrados = " & xStrN)
                End If

                For i = 0 To (List_Data(y).VALUES.Count - 1)
                    'If ((i > 0) And (ALL_EXA = False)) Then
                    '    If (List_Data(y).VALUES(i).CF_DESC = List_Data(y).VALUES(i - 1).CF_DESC) Then
                    '        Continue For
                    '    End If
                    'End If

                    Dim xRow As Integer = 10 + xIndex

                    'Datos
                    x2 = x1
                    xls.SetCellValue(xRow, x2, List_Data(y).ATE_NUM & ".-") : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).ATE_FECHA) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PAC_RUT) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PAC_NOMBRE & " " & List_Data(y).PAC_APELLIDO) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).SEXO_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, Format(List_Data(y).PAC_FNAC, "dd/MM/yyyy")) : x2 += 1

                    Dim NN_DATE As New N_Calc_Age
                    xls.SetCellValue(xRow, x2, NN_DATE.IrisLAB_Cal_Edad_Exacta(List_Data(y).PAC_FNAC, Date.Now)) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).DOC_RUT) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).DOC_NOMBRE & " " & List_Data(y).DOC_APELLIDO) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).CF_COD) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).CF_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).PRU_DESC) : x2 += 1

                    'Campo Value
                    Dim xValue_Num As String = List_Data(y).VALUES(i).ATE_RESULTADO_NUM.Replace(".", ",")
                    Dim xValue_Str As String = List_Data(y).VALUES(i).ATE_RESULTADO
                    Select Case (IsNumeric(xValue_Num))
                        Case False
                            If (IsNumeric(xValue_Str.Replace(".", ",")) = True) Then
                                xls.SetCellValue(xRow, x2, CDbl(xValue_Str.Replace(".", ",")))
                                xls.SetCellStyle(xRow, x2, css_TCell_right)
                            Else
                                xls.SetCellValue(xRow, x2, xValue_Str)
                                xls.SetCellStyle(xRow, x2, css_TCell_left)
                            End If
                        Case Else
                            If (IsNumeric(xValue_Num) = True) Then
                                xls.SetCellValue(xRow, x2, CDbl(xValue_Num))
                                xls.SetCellStyle(xRow, x2, css_TCell_right)
                            Else
                                xls.SetCellValue(xRow, x2, xValue_Num)
                                xls.SetCellStyle(xRow, x2, css_TCell_left)
                            End If
                    End Select
                    x2 += 1

                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).ATE_TXT_UNIDAD) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PROC_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PREVE_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PROGRA_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).SUBP_DESC) : x2 += 1
                    'If (IsNumeric(List_Data(y).ATE_OMI) = True) Then
                    'xls.SetCellValue(xRow, x2, CInt(List_Data(y).ATE_OMI))
                    'Else
                    'xls.SetCellValue(xRow, x2, List_Data(y).ATE_OMI)
                    'End If

                    'Estilos
                    x2 = x1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_Date) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_Date) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1

                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1

                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    'xls.SetCellStyle(xRow, x2, css_TCell_right) : x2 += 1

                    xIndex += 1
                Next i
            Next y

            'Seleccionar Área y Delimitar Tabla
            Dim DataTable As SLTable = xls.CreateTable(9, 1, 9 + xIndex, x2)
            DataTable.SetTableStyle(SLTableStyleTypeValues.Dark11)
            xls.InsertTable(DataTable)


            'Calcular tiempo
            Dim xTime As String
            Dim hh As Integer = 0
            Dim mm As Integer = 0
            Dim ss As Integer = 0
            ss = DateDiff(DateInterval.Second, Date_Init, Date.Now)
            While (ss >= 60)
                mm += 1
                ss -= 60
            End While
            While (mm >= 60)
                hh += 1
                mm -= 60
            End While
            xTime = Format(hh, "00") & ":" & Format(mm, "00") & ":" & Format(ss, "00")

            'Guardar Archivo
            'Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            'Dim strFilename As String = "IRISPDFDERIVADOS\Resultados_Filtrados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            strFilename = "IRISPDFDERIVADOS\Resultados_Filtrados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            'Dim strLocal As String = "C:\IrisLAB Log\"
            'Dim strFilename As String = "Resultados_Filtrados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

            xls.SaveAs(strLocal & strFilename)

            'Enviar archivo generado
            LOG.Write_Line("Archivo generado en " & xTime)
            LOG.Write_Line("Armando y enviando Correo")

            URL_Base = URL_Base.Replace("\", "/")
            Dim HTML As String = Write_Email(DATE_01, DATE_02, URL_Base & "/" & strFilename.Replace("\", "/"), URL_Base)
            NN_CORREO.Send_Email(HTML)

            LOG.Write_Line("Correo enviado correctamente")
            LOG.Write_Separator()

        Catch ex As Exception
            Log.Write_ERROR(ex)
            LOG.Write_Separator()
        End Try

        Return
    End Sub
    Public Sub Gen_Excel_Pena()
        Dim LOG As New N_Log
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "dd-MM-yyyy - !") & User & ".txt"

        Try
            Dim NN_REX As New N_Res_Filtrados_New_Async(strLocal, URL_Base, DATE_01, DATE_02, ID_PROC, ID_PREV, ID_PROG, ID_SUBP, EMAIL, ARRTEXT, ALL_EXA, User)
            Dim List_Data As New List(Of E_Async_Res_All)
            List_Data = NN_REX.Gen_Data()

            LOG.Write_Line("Armando Excel...")
            LOG.Write_Line("<space/>    Total pacientes = " & List_Data.Count, False)
            LOG.Write_Line("", False)


            'PREPARAR CORREO
            Dim NN_CORREO As New N_EMAIL
            NN_CORREO.Set_Destinat = EMAIL
            NN_CORREO.Set_Asunto = "Resultados Filtrados Prev. [" & Me.ARRTEXT(1) & "] - " & Format(DATE_01, "dd/MM/yyyy") & " - " & Format(DATE_02, "dd/MM/yyyy")
            If ((URL_Base.Contains("http:\\") = False) And (URL_Base.Contains("https:\\") = False)) Then
                URL_Base = "http:\\" & URL_Base
            End If

            'Comprobar si se generaron resultados
            If (List_Data.Count = 0) Then
                LOG.Write_Line("La búsqueda no arrojó resultados...")
                LOG.Write_Line("Armando y enviando Correo")

                URL_Base = URL_Base.Replace("\", "/")
                Dim XHTML As String = Write_Email(DATE_01, DATE_02, Nothing, URL_Base)
                NN_CORREO.Send_Email(XHTML)

                LOG.Write_Line("Correo enviado correctamente")
                LOG.Write_Separator()

                Return
            End If

            Dim Date_Init As Date = Date.Now
            Dim x1 As Integer = 1
            Dim y1 As Integer = 9
            Dim x2 As Integer = 0
            Dim y2 As Integer = 0


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
            css_TCell_right.Font.FontSize = 10
            css_TCell_right.Font.FontName = "Calibri"

            Dim css_TCell_Date = xls.CreateStyle
            css_TCell_Date.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            css_TCell_Date.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
            css_TCell_Date.Font.Bold = False
            css_TCell_Date.Font.FontSize = 10
            css_TCell_Date.FormatCode = "dd/mm/yyyy"

            'Colocar Título
            If (ALL_EXA = True) Then
                xls.SetCellValue(1, 1, "Resultados Filtrados (Todos los Resultados)")
            Else
                xls.SetCellValue(1, 1, "Resultados Filtrados (Solo 1er Resultado)")
            End If
            xls.SetCellStyle(1, 1, css_Title)
            xls.MergeWorksheetCells(1, 1, 1, 4)

            xls.SetCellValue(2, 1, "Desde: " & Format(DATE_01, "dd/MM/yyyy"))
            xls.SetCellStyle(2, 1, css_SubTitle)
            xls.MergeWorksheetCells(2, 1, 2, 3)

            xls.SetCellValue(3, 1, "Hasta: " & Format(DATE_02, "dd/MM/yyyy"))
            xls.SetCellStyle(3, 1, css_SubTitle)
            xls.MergeWorksheetCells(3, 1, 3, 3)

            xls.SetCellValue(4, 1, "Procedencia: " & ARRTEXT(0))
            xls.SetCellStyle(4, 1, css_SubTitle)
            xls.MergeWorksheetCells(4, 1, 4, 3)

            xls.SetCellValue(5, 1, "Previsión: " & ARRTEXT(1))
            xls.SetCellStyle(5, 1, css_SubTitle)
            xls.MergeWorksheetCells(5, 1, 5, 3)

            'xls.SetCellValue(6, 1, "Programa: " & ARRTEXT(2))
            'xls.SetCellStyle(6, 1, css_SubTitle)
            'xls.MergeWorksheetCells(6, 1, 6, 3)

            'xls.SetCellValue(7, 1, "Subprograma: " & ARRTEXT(3))
            'xls.SetCellStyle(7, 1, css_SubTitle)
            'xls.MergeWorksheetCells(7, 1, 7, 3)

            'Colocar Cabeceras
            x2 = x1
            xls.SetCellValue(y1, x2, "N° Atención") : x2 += 1
            xls.SetCellValue(y1, x2, "Fecha") : x2 += 1
            xls.SetCellValue(y1, x2, "RUT") : x2 += 1
            xls.SetCellValue(y1, x2, "Nombre Paciente") : x2 += 1
            xls.SetCellValue(y1, x2, "Sexo") : x2 += 1
            xls.SetCellValue(y1, x2, "F. Nac.") : x2 += 1
            xls.SetCellValue(y1, x2, "Edad") : x2 += 1
            xls.SetCellValue(y1, x2, "RUT Doctor") : x2 += 1
            xls.SetCellValue(y1, x2, "Nombre Doctor") : x2 += 1
            xls.SetCellValue(y1, x2, "Exámen") : x2 += 1
            xls.SetCellValue(y1, x2, "Determinación") : x2 += 1
            xls.SetCellValue(y1, x2, "Resultado") : x2 += 1
            xls.SetCellValue(y1, x2, "Unidad") : x2 += 1
            xls.SetCellValue(y1, x2, "Procedencia") : x2 += 1
            xls.SetCellValue(y1, x2, "Previsión") : x2 += 1
            xls.SetCellValue(y1, x2, "Programa") : x2 += 1
            xls.SetCellValue(y1, x2, "Sub Programa") : x2 += 1
            xls.SetCellValue(y1, x2, "OC") : x2 += 1
            x2 -= 1

            For i = 1 To 18
                xls.SetCellStyle(9, i, css_THead)
            Next

            x2 = x1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 15) : x2 += 1
            xls.SetColumnWidth(x2, 50) : x2 += 1
            xls.SetColumnWidth(x2, 15) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 15) : x2 += 1
            xls.SetColumnWidth(x2, 50) : x2 += 1
            xls.SetColumnWidth(x2, 55) : x2 += 1
            xls.SetColumnWidth(x2, 35) : x2 += 1
            xls.SetColumnWidth(x2, 40) : x2 += 1
            xls.SetColumnWidth(x2, 20) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            xls.SetColumnWidth(x2, 25) : x2 += 1
            x2 -= 1

            'Rellenar Campos
            Dim xIndex As Integer = 0
            For y = 0 To (List_Data.Count - 1)
                If (((y + 1) Mod 1000 = 0) Or (y = List_Data.Count - 1)) Then
                    Dim xStrN As String = CStr(y + 1)
                    While (xStrN.Length < CStr(List_Data.Count).Length)
                        xStrN = "0" & xStrN
                    End While
                    LOG.Write_Line("Pacientes Registrados = " & xStrN)
                End If

                For i = 0 To (List_Data(y).VALUES.Count - 1)
                    'If ((i > 0) And (ALL_EXA = False)) Then
                    '    If (List_Data(y).VALUES(i).CF_DESC = List_Data(y).VALUES(i - 1).CF_DESC) Then
                    '        Continue For
                    '    End If
                    'End If

                    Dim xRow As Integer = 10 + xIndex

                    'Datos
                    x2 = x1
                    xls.SetCellValue(xRow, x2, List_Data(y).ATE_NUM & ".-") : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).ATE_FECHA) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PAC_RUT) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PAC_NOMBRE & " " & List_Data(y).PAC_APELLIDO) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).SEXO_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, Format(List_Data(y).PAC_FNAC, "dd/MM/yyyy")) : x2 += 1

                    Dim NN_DATE As New N_Calc_Age
                    xls.SetCellValue(xRow, x2, NN_DATE.IrisLAB_Cal_Edad_Exacta(List_Data(y).PAC_FNAC, Date.Now)) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).DOC_RUT) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).DOC_NOMBRE & " " & List_Data(y).DOC_APELLIDO) : x2 += 1

                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).CF_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).PRU_DESC) : x2 += 1

                    'Campo Value
                    Dim xValue_Num As String = List_Data(y).VALUES(i).ATE_RESULTADO_NUM.Replace(".", ",")
                    Dim xValue_Str As String = List_Data(y).VALUES(i).ATE_RESULTADO
                    Select Case (IsNumeric(xValue_Num))
                        Case False
                            If (IsNumeric(xValue_Str.Replace(".", ",")) = True) Then
                                xls.SetCellValue(xRow, x2, CDbl(xValue_Str.Replace(".", ",")))
                                xls.SetCellStyle(xRow, x2, css_TCell_right)
                            Else
                                xls.SetCellValue(xRow, x2, xValue_Str)
                                xls.SetCellStyle(xRow, x2, css_TCell_left)
                            End If
                        Case Else
                            If (IsNumeric(xValue_Num) = True) Then
                                xls.SetCellValue(xRow, x2, CDbl(xValue_Num))
                                xls.SetCellStyle(xRow, x2, css_TCell_right)
                            Else
                                xls.SetCellValue(xRow, x2, xValue_Num)
                                xls.SetCellStyle(xRow, x2, css_TCell_left)
                            End If
                    End Select
                    x2 += 1

                    xls.SetCellValue(xRow, x2, List_Data(y).VALUES(i).ATE_TXT_UNIDAD) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PROC_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PREVE_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).PROGRA_DESC) : x2 += 1
                    xls.SetCellValue(xRow, x2, List_Data(y).SUBP_DESC) : x2 += 1
                    'If (IsNumeric(List_Data(y).ATE_OMI) = True) Then
                    'xls.SetCellValue(xRow, x2, CInt(List_Data(y).ATE_OMI))
                    'Else
                    xls.SetCellValue(xRow, x2, List_Data(y).ATE_OMI)
                    'End If

                    'Estilos
                    x2 = x1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_Date) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_Date) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1

                    xls.SetCellStyle(xRow, x2, css_TCell_center) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1

                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1

                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_left) : x2 += 1
                    xls.SetCellStyle(xRow, x2, css_TCell_right) : x2 += 1

                    xIndex += 1
                Next i
            Next y

            'Seleccionar Área y Delimitar Tabla
            Dim DataTable As SLTable = xls.CreateTable(9, 1, 9 + xIndex, x2)
            DataTable.SetTableStyle(SLTableStyleTypeValues.Dark11)
            xls.InsertTable(DataTable)


            'Calcular tiempo
            Dim xTime As String
            Dim hh As Integer = 0
            Dim mm As Integer = 0
            Dim ss As Integer = 0
            ss = DateDiff(DateInterval.Second, Date_Init, Date.Now)
            While (ss >= 60)
                mm += 1
                ss -= 60
            End While
            While (mm >= 60)
                hh += 1
                mm -= 60
            End While
            xTime = Format(hh, "00") & ":" & Format(mm, "00") & ":" & Format(ss, "00")

            'Guardar Archivo
            'Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            'Dim strFilename As String = "IRISPDFDERIVADOS\Resultados_Filtrados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            strFilename = "IRISPDFDERIVADOS\Resultados_Filtrados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            'Dim strLocal As String = "C:\IrisLAB Log\"
            'Dim strFilename As String = "Resultados_Filtrados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

            xls.SaveAs(strLocal & strFilename)

            'Enviar archivo generado
            LOG.Write_Line("Archivo generado en " & xTime)
            LOG.Write_Line("Armando y enviando Correo")

            URL_Base = URL_Base.Replace("\", "/")
            Dim HTML As String = Write_Email(DATE_01, DATE_02, URL_Base & "/" & strFilename.Replace("\", "/"), URL_Base)
            NN_CORREO.Send_Email(HTML)

            LOG.Write_Line("Correo enviado correctamente")
            LOG.Write_Separator()

        Catch ex As Exception
            LOG.Write_ERROR(ex)
            LOG.Write_Separator()
        End Try

        Return
    End Sub

    Private Function Write_Email(ByVal Date_01 As Date, ByVal Date_02 As Date, ByVal link As String, ByVal url_base As String) As String
        Dim HTML_str As String = ""

        HTML_str &= "<!DOCTYPE html>" & vbLf
        HTML_str &= "<html>" & vbLf
        HTML_str &= "<head>" & vbLf
        HTML_str &= "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>" & vbLf
        HTML_str &= "<title>Resultados Peñalolén</title>" & vbLf
        HTML_str &= "</head>" & vbLf
        HTML_str &= "<body>" & vbLf
        HTML_str &= "    <link href='https://fonts.googleapis.com/css?family=Saira' rel='stylesheet'>" & vbLf
        HTML_str &= "    <table style='width: 90%; margin: 0 auto; font-family: 'Saira', sans-serif;'>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <th align='center' style='padding: 0;'>" & vbLf
        HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: left;' src='" & url_base & "/Imagenes/IrisLab%20Logo%20LARGOa.png' />" & vbLf
        'HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: right;' src='" & url_base & "/Imagenes/00_logo_holanda_full.png />" & vbLf
        HTML_str &= "            </th>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <td style='padding: 5px; padding-top: 15px;'>" & vbLf
        HTML_str &= "                <table style='width: 100%; border-collapse: collapse; border: 2px solid #2d43d5;'>" & vbLf
        HTML_str &= "                    <tr>" & vbLf
        HTML_str &= "                        <th colspan='2' style='color: #ffffff; background: #2d43d5; font-size: 22px; padding: 5px;'>Solicitud de Documento:</th>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Documento Solicitado:</td>" & vbLf
        HTML_str &= "                        <td>Resultados Filtrados.-</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Desde:</td>" & vbLf
        HTML_str &= "                        <td>" & Format(Date_01, "dd/MM/yyyy") & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Hasta:</td>" & vbLf
        HTML_str &= "                        <td>" & Format(Date_02, "dd/MM/yyyy") & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Procedencia:</td>" & vbLf
        HTML_str &= "                        <td>" & Me.ARRTEXT(0) & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Prevision:</td>" & vbLf
        HTML_str &= "                        <td>" & Me.ARRTEXT(1) & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Programa:</td>" & vbLf
        HTML_str &= "                        <td>" & Me.ARRTEXT(2) & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>SubPrograma:</td>" & vbLf
        HTML_str &= "                        <td>" & Me.ARRTEXT(3) & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr align='center'>" & vbLf
        HTML_str &= "                        <td colspan='2'>" & vbLf

        If (String.IsNullOrEmpty(link) = False) Then
            HTML_str &= "                            <a href='" & link & "' style='text-decoration: none; font-size: 20px;'>Descargar Archivo</a>" & vbLf
        Else
            HTML_str &= "                            <strong style='text-decoration: none; font-size: 20px;'>La búsqueda solicitada no devolvió resultados.</strong>" & vbLf
        End If

        HTML_str &= "                        </td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                </table>" & vbLf
        HTML_str &= "            </td>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "    </table>" & vbLf
        HTML_str &= "</body>" & vbLf
        HTML_str &= "</html>" & vbLf

        Return HTML_str
    End Function
End Class
