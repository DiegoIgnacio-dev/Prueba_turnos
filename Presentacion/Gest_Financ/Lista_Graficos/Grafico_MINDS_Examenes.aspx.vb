Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Grafico_MINDS_Examenes
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF_3_Minds(DOMAIN_URL, DATE_str01, DATE_str02, ID_CF, CF_DESC, VALOR, VALOR_2)
        Return link
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_AÑO_ACTIVO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
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
    Public Shared Function Llenar_DataTable(ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)

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




        If (date_json_rial.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(date_json_rial, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer, ByVal VALOR_2 As Integer) As String
        Dim NN_Prev As New N_GraficoVisor
        Return NN_Prev.Gen_ExcelAteProvee_Minds(MAIN_URL, Mes, Año, ID_CF, CF_DESC, VALOR, VALOR_2)
    End Function

    Private Sub GraficoExamenes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class