Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_LugarTM_Det_Async
    'Declaraciones Generales
    Dim DD_Data As D_LugarTM_Det

    Dim STRLOCAL As String
    Dim URL_BASE As String
    Dim DESDE As String
    Dim HASTA As String
    Dim ID_CF As Integer
    Dim ID_FP As Integer
    Dim ID_PREV As Integer
    Dim E_DESDE As String
    Dim E_HASTA As String
    Dim EMAIL As String


    Sub New(ByVal xSTRLOCAL As String, ByVal xURL_BASE As String, ByVal xDESDE As String, ByVal xHASTA As String, ByVal xID_CF As Integer, ByVal xID_FP As Integer, ByVal xID_PREV As Integer, ByVal xE_DESDE As Integer, ByVal xE_HASTA As Integer, ByVal xEMAIL As String)
        DD_Data = New D_LugarTM_Det

        STRLOCAL = xSTRLOCAL
        URL_BASE = xURL_BASE
        DESDE = xDESDE
        HASTA = xHASTA
        ID_CF = xID_CF
        ID_FP = xID_FP
        ID_PREV = xID_PREV
        E_DESDE = xE_DESDE
        E_HASTA = xE_DESDE
        EMAIL = xEMAIL


    End Sub
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
    End Function
    Function IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)
    End Function

    Public Function Gen_Data() As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)

        If (E_DESDE = 0) And (E_HASTA = 0) Then
            List_Data = DD_Data.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)
        ElseIf (E_DESDE < E_HASTA) Then
            List_Data = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
        End If

        If (List_Data.Count = 0) Then
            Return List_Data
        End If

        Return List_Data
    End Function
    Public Function Gen_Data_IST() As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)

        If (E_DESDE = 0) And (E_HASTA = 0) Then
            List_Data = DD_Data.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46_IST(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)
        ElseIf (E_DESDE < E_HASTA) Then
            List_Data = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_IST(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
        End If

        If (List_Data.Count = 0) Then
            Return List_Data
        End If

        Return List_Data
    End Function

    Public Sub Gen_Excel_Async()
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim strFilename As String = ""
        Dim Mx_Data(14, 0) As Object

        '-----------------------------------------------------------------------------------------------------
        Dim NN_REX As New N_LugarTM_Det_Async(STRLOCAL, URL_BASE, DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, EMAIL)

        'PREPARAR CORREO
        Dim NN_CORREO As New N_EMAIL
        NN_CORREO.Set_Destinat = EMAIL
        NN_CORREO.Set_Asunto = "Pacientes, Exámenes y precios por previsión y lugar de Tm. [" & "Previsión" & "] - " & DESDE & " - " & HASTA
        If ((URL_Base.Contains("http:\\") = False) And (URL_Base.Contains("https:\\") = False)) Then
            URL_Base = "http:\\" & URL_Base
        End If

        Data_TM_Provision = NN_REX.Gen_Data()
        '----------------------------------------------------------------------------------------------

        'Vaciar Matriz
        ReDim Mx_Data(14, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_TM_Provision.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(14, y)
            End If
            Mx_Data(0, y) = Data_TM_Provision(y).ATE_NUM
            Mx_Data(1, y) = Format(CDate(Data_TM_Provision(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(2, y) = Data_TM_Provision(y).PAC_RUT
            Mx_Data(3, y) = Data_TM_Provision(y).SEXO_DESC
            Mx_Data(4, y) = Format(CDate(Data_TM_Provision(y).PAC_FNAC), "dd/MM/yyyy")
            Mx_Data(5, y) = Data_TM_Provision(y).ATE_AÑO & "A " & Data_TM_Provision(y).ATE_MES & "M " & Data_TM_Provision(y).ATE_DIA & "D"
            Mx_Data(6, y) = Data_TM_Provision(y).PAC_NOMBRE & "" & Data_TM_Provision(y).PAC_APELLIDO
            Mx_Data(7, y) = Data_TM_Provision(y).CF_DESC
            Mx_Data(8, y) = Data_TM_Provision(y).CF_COD & ".-"
            Mx_Data(9, y) = Data_TM_Provision(y).PROC_DESC
            Mx_Data(10, y) = Data_TM_Provision(y).ATE_DET_V_PREVI
            Mx_Data(11, y) = Format(CDate(Data_TM_Provision(y).ATE_FECHA), "HH:mm:ss")
            Mx_Data(12, y) = Data_TM_Provision(y).PREVE_DESC
            Mx_Data(13, y) = Data_TM_Provision(y).DOC_NOMBRE & "" & Data_TM_Provision(y).DOC_APELLIDO & "" & Data_TM_Provision(y).ATE_AÑO
            Mx_Data(14, y) = Data_TM_Provision(y).PROGRA_DESC

        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim formatonum As SLStyle
        Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Atenciones por LTM (Precios Detallado)")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Atenciones por LTM (Precios Detallado)")
        sl.SetCellValue("B4", "Desde: " & DESDE & " Hasta: " & HASTA)
        'nombre columnas
        sl.SetCellValue("A7", "N° Atención")
        sl.SetCellValue("B7", "Fecha")
        sl.SetCellValue("C7", "Rut")
        sl.SetCellValue("D7", "Sexo")
        sl.SetCellValue("E7", "Fecha Nacimiento")
        sl.SetCellValue("F7", "Edad")
        sl.SetCellValue("G7", "Nombre")
        sl.SetCellValue("H7", "Examen")
        sl.SetCellValue("I7", "Cod. Fonasa")
        sl.SetCellValue("J7", "Procedencia")
        sl.SetCellValue("K7", "Precio")
        sl.SetCellValue("L7", "Hora ATE.")
        sl.SetCellValue("M7", "Previsión")
        sl.SetCellValue("N7", "Medico")
        sl.SetCellValue("O7", "Programa")
        For y = 1 To 15
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
        estilo3.Font.Bold = False

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("A4", estilo2)
        sl.SetCellStyle("B4", estilo2)
        sl.SetCellStyle("C4", estilo2)
        sl.SetCellStyle("D4", estilo2)
        sl.SetCellStyle("E4", estilo2)
        sl.SetCellStyle("F4", estilo2)
        sl.SetCellStyle("G4", estilo2)
        sl.SetCellStyle("H4", estilo2)
        sl.SetCellStyle("I4", estilo2)
        sl.SetCellStyle("J4", estilo2)
        sl.SetCellStyle("K4", estilo2)
        sl.SetCellStyle("L4", estilo2)
        sl.SetCellStyle("M4", estilo2)
        sl.SetCellStyle("N4", estilo2)
        sl.SetCellStyle("O4", estilo2)

        For y = 8 To ltabla + 1
            For i = Asc("A") To Asc("O")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"

        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        strFilename = "IRISPDFDERIVADOS\Pacientes_Examenes_Precios_Prev_LugarTM" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(strLocal & strFilename)

        URL_BASE = URL_BASE.Replace("\", "/")
        Dim HTML As String = Write_Email(DESDE, HASTA, URL_BASE & "/" & strFilename.Replace("\", "/"), URL_BASE)
        NN_CORREO.Send_Email(HTML)

    End Sub
    Public Sub Gen_Excel_Async_IST()
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim strFilename As String = ""
        Dim Mx_Data(14, 0) As Object

        '-----------------------------------------------------------------------------------------------------
        Dim NN_REX As New N_LugarTM_Det_Async(STRLOCAL, URL_BASE, DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, EMAIL)

        'PREPARAR CORREO
        Dim NN_CORREO As New N_EMAIL
        NN_CORREO.Set_Destinat = EMAIL
        NN_CORREO.Set_Asunto = "Pacientes, Exámenes y precios por previsión y lugar de Tm. [" & "Previsión" & "] - " & DESDE & " - " & HASTA
        If ((URL_BASE.Contains("http:\\") = False) And (URL_BASE.Contains("https:\\") = False)) Then
            URL_BASE = "http:\\" & URL_BASE
        End If

        Data_TM_Provision = NN_REX.Gen_Data_IST()
        '----------------------------------------------------------------------------------------------

        'Vaciar Matriz
        ReDim Mx_Data(14, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_TM_Provision.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(14, y)
            End If
            Mx_Data(0, y) = Data_TM_Provision(y).ATE_NUM
            Mx_Data(1, y) = Format(CDate(Data_TM_Provision(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(2, y) = Data_TM_Provision(y).PAC_RUT
            Mx_Data(3, y) = Data_TM_Provision(y).SEXO_DESC
            Mx_Data(4, y) = Format(CDate(Data_TM_Provision(y).PAC_FNAC), "dd/MM/yyyy")
            Mx_Data(5, y) = Data_TM_Provision(y).ATE_AÑO & "A " & Data_TM_Provision(y).ATE_MES & "M " & Data_TM_Provision(y).ATE_DIA & "D"
            Mx_Data(6, y) = Data_TM_Provision(y).PAC_NOMBRE & "" & Data_TM_Provision(y).PAC_APELLIDO
            Mx_Data(7, y) = Data_TM_Provision(y).CF_DESC
            Mx_Data(8, y) = Data_TM_Provision(y).CF_COD & ".-"
            Mx_Data(9, y) = Data_TM_Provision(y).PROC_DESC
            Mx_Data(10, y) = Data_TM_Provision(y).ATE_DET_V_PREVI
            Mx_Data(11, y) = Format(CDate(Data_TM_Provision(y).ATE_FECHA), "HH:mm:ss")
            Mx_Data(12, y) = Data_TM_Provision(y).PREVE_DESC
            Mx_Data(13, y) = Data_TM_Provision(y).DOC_NOMBRE & "" & Data_TM_Provision(y).DOC_APELLIDO & "" & Data_TM_Provision(y).ATE_AÑO
            Mx_Data(14, y) = Data_TM_Provision(y).PROGRA_DESC

        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim formatonum As SLStyle
        Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Atenciones por LTM (Precios Detallado)")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Atenciones por LTM (Precios Detallado)")
        sl.SetCellValue("B4", "Desde: " & DESDE & " Hasta: " & HASTA)
        'nombre columnas
        sl.SetCellValue("A7", "N° Atención")
        sl.SetCellValue("B7", "Fecha")
        sl.SetCellValue("C7", "Rut")
        sl.SetCellValue("D7", "Sexo")
        sl.SetCellValue("E7", "Fecha Nacimiento")
        sl.SetCellValue("F7", "Edad")
        sl.SetCellValue("G7", "Nombre")
        sl.SetCellValue("H7", "Examen")
        sl.SetCellValue("I7", "Cod. Fonasa")
        sl.SetCellValue("J7", "Procedencia")
        sl.SetCellValue("K7", "Precio")
        sl.SetCellValue("L7", "Hora ATE.")
        sl.SetCellValue("M7", "Previsión")
        sl.SetCellValue("N7", "Medico")
        sl.SetCellValue("O7", "Programa")
        For y = 1 To 15
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
        estilo3.Font.Bold = False

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("A4", estilo2)
        sl.SetCellStyle("B4", estilo2)
        sl.SetCellStyle("C4", estilo2)
        sl.SetCellStyle("D4", estilo2)
        sl.SetCellStyle("E4", estilo2)
        sl.SetCellStyle("F4", estilo2)
        sl.SetCellStyle("G4", estilo2)
        sl.SetCellStyle("H4", estilo2)
        sl.SetCellStyle("I4", estilo2)
        sl.SetCellStyle("J4", estilo2)
        sl.SetCellStyle("K4", estilo2)
        sl.SetCellStyle("L4", estilo2)
        sl.SetCellStyle("M4", estilo2)
        sl.SetCellStyle("N4", estilo2)
        sl.SetCellStyle("O4", estilo2)

        For y = 8 To ltabla + 1
            For i = Asc("A") To Asc("O")
                sl.SetCellStyle(CStr(Chr(i) & y), estilo2)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y

        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"

        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        strFilename = "IRISPDFDERIVADOS\Pacientes_Examenes_Precios_Prev_LugarTM" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(STRLOCAL & strFilename)

        URL_BASE = URL_BASE.Replace("\", "/")
        Dim HTML As String = Write_Email(DESDE, HASTA, URL_BASE & "/" & strFilename.Replace("\", "/"), URL_BASE)
        NN_CORREO.Send_Email(HTML)

    End Sub

    Private Function Write_Email(ByVal Date_01 As Date, ByVal Date_02 As Date, ByVal link As String, ByVal url_base As String) As String
        Dim HTML_str As String = ""

        HTML_str &= "<!DOCTYPE html>" & vbLf
        HTML_str &= "<html>" & vbLf
        HTML_str &= "<head>" & vbLf
        HTML_str &= "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>" & vbLf
        HTML_str &= "<title>Pacientes, Exámenes y precios por previsión y lugar de Tm</title>" & vbLf
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
        HTML_str &= "                        <td>Pacientes, Exámenes y precios por previsión y lugar de Tm-</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Desde:</td>" & vbLf
        HTML_str &= "                        <td>" & Date_01 & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Hasta:</td>" & vbLf
        HTML_str &= "                        <td>" & Date_02 & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Procedencia:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(0) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Prevision:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(1) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Programa:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(2) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>SubPrograma:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(3) & "</td>" & vbLf
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
