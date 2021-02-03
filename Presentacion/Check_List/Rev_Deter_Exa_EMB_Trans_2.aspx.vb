Imports Entidades
Imports Negocio
Imports Datos
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Rev_Deter_Exa_EMB_Trans_2
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Request_Prevision(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_PROCEDENCIA_ACTIVO(ID_PROC)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_Programa(ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        Dim NN As New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_SubPrograma(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_Async_SubP)
        Dim NN_Activo As New N_Gen_Activos

        Return NN_Activo.Request_SubPrograma(ID_PREV, ID_PROG)
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
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DdL_prevision() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam(ByVal ID_PREV As Long) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_Gen_Activos
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_BY_ID_PREV(ID_PREV)
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
    Public Shared Function Llenar_Ddl_Det(ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST(ID_CF)
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
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_EST As Integer,
                                             ByVal Procedencia As Integer,
                                              ByVal Ddl_previ As Integer,
                                               ByVal Ddl_programa As Integer,
                                                ByVal Ddl_subPrograma As Integer,
                                            ByVal TRANSMITIDO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim Data As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim Json_Item_Res As New E_Json_Result_DataTable_Values2
        Dim NN_Ate As New N_Ate_Resultados2

        If (TRANSMITIDO = 1) Then
            Data = NN.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION_RESU(CDate(DESDE), CDate(HASTA), ID_CF, ID_EST, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
        Else
            Data = NN.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS(CDate(DESDE), CDate(HASTA), ID_CF, ID_EST, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
        End If

        If (Data.Count > 0) Then
            'For y = 0 To Data.Count - 1
            '    Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data(y).ID_ATENCION)
            '    Data(y).PAC_RUT = Data_Datos_Pac(0).PAC_RUT
            '    If (Data(y).ATE_EST_VALIDA = 6 Or Data(y).ATE_EST_VALIDA = 14) Then
            '        Data(y).ATE_RR_DESDE = ""
            '        Data(y).ATE_R_DESDE = ""
            '        Data(y).ATE_R_HASTA = ""
            '        Data(y).ATE_RR_HASTA = ""
            '    Else
            '        Json_Item_Res.b2 = Data(y).ATE_RR_DESDE
            '        Json_Item_Res.b1 = Data(y).ATE_R_DESDE
            '        Json_Item_Res.a1 = Data(y).ATE_R_HASTA
            '        Json_Item_Res.a2 = Data(y).ATE_RR_HASTA
            '        Json_Item_Res = NN_Ate.Json_Item_Result_Interval(Data(y).ID_PRUEBA,
            '                                                  Data_Datos_Pac(0).SEXO_DESC,
            '                                                  CDate(Data_Datos_Pac(0).PAC_FNAC),
            '                                                  Json_Item_Res)
            '        Data(y).ATE_RR_DESDE = Json_Item_Res.b2
            '        Data(y).ATE_R_DESDE = Json_Item_Res.b1
            '        Data(y).ATE_R_HASTA = Json_Item_Res.a1
            '        Data(y).ATE_RR_HASTA = Json_Item_Res.a2
            '    End If
            'Next y
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Det_Ate(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Encrypt As New N_Encrypt
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE)
        Dim data_num As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE = New N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE
        Dim NN_Num As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE(ID_ATE)
        If (data_det_ate.Count > 0) Then
            data_num = NN_Num.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data_det_ate(0).ID_ATENCION)
            data_det_ate(0).NUM_ATE = data_num(0).ATE_NUM
            For i = 0 To (data_det_ate.Count - 1)
                data_det_ate(i).ENCRYPTED_ID = Encrypt.Encode(ID_ATE)
            Next i
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
                                          ByVal ID_CF As Integer,
                                          ByVal ID_EST As Integer,
                                             ByVal Procedencia As Integer,
                                              ByVal Ddl_previ As Integer,
                                               ByVal Ddl_programa As Integer,
                                                ByVal Ddl_subPrograma As Integer,
                                 ByVal TRANSMITIDO As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim NN As New N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim Data As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim Json_Item_Res As New E_Json_Result_DataTable_Values2
        Dim NN_Ate As New N_Ate_Resultados2
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim Mx_Data(3, 0) As Object

        If (TRANSMITIDO = 1) Then
            Data = NN.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION_RESU(CDate(DESDE), CDate(HASTA), ID_CF, ID_EST, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
        Else
            Data = NN.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS(CDate(DESDE), CDate(HASTA), ID_CF, ID_EST, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
        End If
        If (Data.Count > 0) Then
            'For y = 0 To Data.Count - 1
            '    Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data(y).ID_ATENCION)
            '    Data(y).PAC_RUT = Data_Datos_Pac(0).PAC_RUT
            '    If (Data(y).ATE_EST_VALIDA = 6 Or Data(y).ATE_EST_VALIDA = 14) Then
            '        Data(y).ATE_RR_DESDE = ""
            '        Data(y).ATE_R_DESDE = ""
            '        Data(y).ATE_R_HASTA = ""
            '        Data(y).ATE_RR_HASTA = ""
            '    Else
            '        Json_Item_Res.b2 = Data(y).ATE_RR_DESDE
            '        Json_Item_Res.b1 = Data(y).ATE_R_DESDE
            '        Json_Item_Res.a1 = Data(y).ATE_R_HASTA
            '        Json_Item_Res.a2 = Data(y).ATE_RR_HASTA
            '        Json_Item_Res = NN_Ate.Json_Item_Result_Interval(Data(y).ID_PRUEBA,
            '                                                         Data_Datos_Pac(0).SEXO_DESC,
            '                                                         CDate(Data_Datos_Pac(0).PAC_FNAC),
            '                                                         Json_Item_Res)
            '        Data(y).ATE_RR_DESDE = Json_Item_Res.b2
            '        Data(y).ATE_R_DESDE = Json_Item_Res.b1
            '        Data(y).ATE_R_HASTA = Json_Item_Res.a1
            '        Data(y).ATE_RR_HASTA = Json_Item_Res.a2
            '    End If
            'Next y
            Dim Mx_Datac(3, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(3, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(3, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = Data(y).CF_COD
                Mx_Data(2, y) = Data(y).CF_DESC
                Mx_Data(3, y) = Data(y).TOTAL
                'Mx_Data(4, y) = Data(y).PAC_NOMBRE + " " + Data(y).PAC_APELLIDO
                'If (Data(y).ID_SEXO = 1) Then
                '    Mx_Data(5, y) = "Masculino"
                'Else
                '    Mx_Data(5, y) = "Femenino"
                'End If
                'Mx_Data(6, y) = Format(Data(y).PAC_FNAC, "dd/MM/yyyy")
                'Mx_Data(7, y) = Data(y).ATE_AÑO & " " & "Años"
                'Mx_Data(8, y) = Format(Data(y).ATE_FECHA, "dd/MM/yyyy")
                'Mx_Data(9, y) = Data(y).PROC_DESC
                'If (Data(y).PROGRA_DESC <> "") Then
                '    Mx_Data(10, y) = Data(y).PROGRA_DESC
                'Else
                '    Mx_Data(10, y) = ""
                'End If
                'If (Data(y).SUBP_DESC <> "") Then
                '    Mx_Data(11, y) = Data(y).SUBP_DESC
                'Else
                '    Mx_Data(11, y) = ""
                'End If
                'If (Data(y).SECTOR_DESC <> "") Then
                '    Mx_Data(12, y) = Data(y).SECTOR_DESC
                'Else
                '    Mx_Data(12, y) = ""
                'End If
                'Mx_Data(13, y) = Data(y).CF_DESC
                'Mx_Data(14, y) = Data(y).PRU_DESC
                'Mx_Data(15, y) = Data(y).TP_RESUL_COD
                'If (Data(y).ATE_RESULTADO = "") Then
                '    Mx_Data(16, y) = Data(y).ATE_RESULTADO = ""
                '    If (Data(y).ATE_RESULTADO_NUM = "") Then
                '        Mx_Data(16, y) = ""
                '    Else
                '        Mx_Data(16, y) = Data(y).ATE_RESULTADO_NUM
                '    End If
                'Else
                '    Mx_Data(16, y) = Data(y).ATE_RESULTADO
                'End If

                'If (Data(y).UM_DESC = "") Then
                '    Mx_Data(17, y) = "SIN UNIDAD"
                'Else
                '    Mx_Data(17, y) = Data(y).UM_DESC
                'End If

                ''Mx_Data(18, y) = Data(y).UM_DESC
                'Mx_Data(18, y) = Data(y).AUDI_FORMA

            Next y
        Else
            Return "null"
        End If

        For y = 1 To 3
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Resultados por Determinaciones Transmitidas (Resumen)")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Resultados por Determinaciones Transmitidas (Resumen)")
        sl.SetCellValue("B4", "Desde: " & DESDE)
        sl.SetCellValue("B5", "Hasta " & HASTA)

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "Cf Cod")
        sl.SetCellValue("C8", "Descripción")
        sl.SetCellValue("D8", "TOTAL")
        'sl.SetCellValue("E8", "Nombre Paciente")
        'sl.SetColumnWidth("E", 40)
        'sl.SetCellValue("F8", "Sexo")
        'sl.SetCellValue("G8", "Fecha Nac.")
        'sl.SetCellValue("H8", "Edad")
        'sl.SetCellValue("I8", "Fecha Ingreso")
        'sl.SetCellValue("J8", "Lugar TM")
        'sl.SetCellValue("K8", "Programa")
        'sl.SetCellValue("L8", "SubPrograma")
        'sl.SetCellValue("M8", "Sector")
        'sl.SetCellValue("N8", "Examen")
        'sl.SetCellValue("O8", "Determinacion")
        'sl.SetCellValue("P8", "T")
        'sl.SetCellValue("Q8", "Resultado")
        'sl.SetCellValue("R8", "Unidad")
        'sl.SetCellValue("S8", "Transmitido")


        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 8
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
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        sl.SetCellStyle("B5", estilo3)

        'sumar columnas
        For i = Asc("D") To Asc("D")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i

        sl.SetCellValue("C" & ltabla + 1, "Total:")

        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("D" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Public Shared Function Calcular_Edad(Fecha_Nacimiento As Date) As Integer
        Dim Años As Object
        ' comprueba si el valor no es nulo  
        Años = DateDiff("yyyy", Fecha_Nacimiento, Now)
        If Date.Now < DateSerial(Year(Now), Month(Fecha_Nacimiento),
                           Day(Fecha_Nacimiento)) Then
            Años = Años - 1
        End If
        Calcular_Edad = CInt(Años)
    End Function

    'Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
    '    Dim objSession As HttpSessionState = HttpContext.Current.Session
    '    Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

    '    If (IsNothing(C_P_ADMIN) = True) Then
    '        Response.Redirect("~/Index.aspx")
    '    End If

    '    Select Case (CInt(C_P_ADMIN.Value))
    '        Case 1, 3
    '        Case Else
    '            Response.Redirect("~/Index.aspx")
    '    End Select
    'End Sub
End Class