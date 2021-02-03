Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Imports ASPPDFLib
Public Class REP_LAB_CANT_EXA_PROVEE_TOT_2
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF_2(DOMAIN_URL, DATE_str01, DATE_str02, ID_CF, 1)
        Return link
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_Examenes_Sum
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_PROVEE_2(Date_01, Date_02, ID_CF)
        If (Data_Prev.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Prev, str_Builder)
            datos = str_Builder.ToString
        Else
            datos = "null"
        End If
        Return datos
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CODIGO_FONASA As Long) As String
        Dim NN_Exam As New N_REP_LAB_CANT_EXA_TOT
        Return NN_Exam.Gen_Excel_PROVEE(DOMAIN_URL, DATE_str01, DATE_str02, ID_CODIGO_FONASA, 1)
    End Function

    Private Sub REP_LAB_CANT_EXA_TOT_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

    Function PDFF_2(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CF As Integer) As String


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

        Data_DTT = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_PROVEE_2(Date_01, Date_02, ID_CF)

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

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

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



        For x = 0 To Data_DTT.Count - 1
            TOT_ATE += Data_DTT(x).TOTAL_ATE
        Next



        Dim eje_y As Integer = 700
        Dim zz_Mod As Integer = 75
        Dim contador_filas As Integer = 1
        If Data_DTT.Count <= 75 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Cantidad Total de Exámenes desde " & DATE_str01 & " al " & DATE_str02, STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                .DrawText("Total Exámenes: " & TOT_ATE, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                .DrawText("Descripción Prestación", STR_PARAM(45, 720, 50, "left", 8), FONT_2)
                .DrawText("Cantidad de Exámenes", STR_PARAM(85, 720, 80, "left", 8), FONT_2)

                For i = 0 To (Data_DTT.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                    .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                    .DrawText(Format(Data_DTT(i).TOT_FONASA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
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


                        .SetFillColor(0, 0, 0)
                        .DrawText("Cantidad Total de Exámenes desde " & DATE_str01 & " al " & DATE_str02, STR_PARAM(1, 780, 611, "center", 18), FONT_2)
                        .DrawText("Total Exámenes: " & TOT_ATE, STR_PARAM(1, 755, 611, "center", 11), FONT_2)

                        .DrawText("#", STR_PARAM(25, 720, 15, "left", 8), FONT_2)
                        .DrawText("Descripción Prestación", STR_PARAM(45, 720, 50, "left", 8), FONT_2)
                        .DrawText("Cantidad de Exámenes", STR_PARAM(85, 720, 80, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(25, eje_y, 15, "left", 6), FONT_2)
                        .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                        .DrawText(Format(Data_DTT(i).TOT_FONASA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
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
                            .DrawText(Data_DTT(i).CF_DESC, STR_PARAM(45, eje_y, 130, "left", 6), FONT_1)
                            .DrawText(Format(Data_DTT(i).TOT_FONASA, "dd-MM-yyyy"), STR_PARAM(85, eje_y, 185, "left", 6), FONT_1)
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