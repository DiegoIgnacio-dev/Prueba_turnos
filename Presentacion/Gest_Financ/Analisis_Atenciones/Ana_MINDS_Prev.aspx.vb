Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Ana_MINDS_Prev
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function PDFF_4(ByVal MAIN_URL As String, ByVal Dll As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF_4(MAIN_URL, Dll, Año, ID_CF, CF_DESC, VALOR)
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
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_AÑO_ACTIVO
        'If (Data_Prev_Activo.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Prev_Activo, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return Data_Prev_Activo
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prev() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        'If (Data_Proce.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Proce, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return Data_Proce
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal Dll As Integer, ByVal Año As String, ByVal ID_CF As Integer, ByVal VALOR As Integer) As List(Of E_GraficoVisor_Json)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_Prev As New N_GraficoPrev
        Dim NN_TP As New N_GraficoAteTP
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim data_Prev As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_PREVISION)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        'Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim mm As Integer
        Dim yyyy As Integer
        yyyy = Format(Date.Now, "yyyy")
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
        'If (date_json_rial.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(date_json_rial, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return date_json_rial
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal Dll As String, ByVal Año As String, ByVal ID_CF As Integer, ByVal CF_DESC As String, ByVal VALOR As Integer) As String
        Dim NN_Grafico_Ate As New N_AnaPrev
        Return NN_Grafico_Ate.Gen_Excel_2(MAIN_URL, Dll, Año, ID_CF, CF_DESC, VALOR)
    End Function

    Private Sub AnaPrev_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class