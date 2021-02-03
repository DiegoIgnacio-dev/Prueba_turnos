Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class GraficoTPUser
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Call_User_Data() As List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE)
        Dim NNN As New N_Conf_User
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE)

        List_Data = NNN.IRIS_WEBF_CMVM_BUSCA_USUARIO_ID_PREVISION_SCR()

        Return List_Data
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
    Public Shared Function Llenar_Ddl_TP() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE()
        If (Data_Proce.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Proce, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal Dll As Integer, ByVal Año As String, ByVal Mes As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_TP As New N_GraficoAteTP
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        'Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)
        Dim mm As Integer
        Dim yyyy As Integer
        yyyy = Format(Date.Now, "yyyy")
        mm = Format(Date.Now, "MM")

        If (Mes = 0) Then
            For dd = 1 To 12
                Dim Item As New E_GraficoVisor_Json
                Data_Med = NN_TP.IRIS_WEBF_CMVM_BUSCA_CANT_EXAMENES_ATE_USUARIO(Dll, Año, dd)
                If Data_Med.Count <> 0 Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                ElseIf (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If

            Next dd
        Else
            For dd = 1 To 12
                Dim Item As New E_GraficoVisor_Json

                If Mes = dd Then
                    Data_Med = NN_TP.IRIS_WEBF_CMVM_BUSCA_CANT_EXAMENES_ATE_USUARIO(Dll, Año, dd)
                    If Data_Med.Count <> 0 Then
                        Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                        Item.CANT_ATE = Data_Med(0).CANT_ATE
                        Item.CANT_EXA = Data_Med(0).CANT_EXA
                        date_json_rial.Add(Item)
                    ElseIf (Data_Med.Count = 0) Then
                        Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                        Item.CANT_ATE = 0
                        Item.CANT_EXA = 0
                        date_json_rial.Add(Item)
                    End If
                Else
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If

            Next dd
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
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal Dll As String, ByVal Año As String, ByVal USER As String, ByVal Mes As Integer) As String
        Dim NN_Grafico_Ate As New N_GraficoAteTP
        Return NN_Grafico_Ate.Gen_Excel_User(MAIN_URL, Dll, Año, USER, Mes)
    End Function

    Private Sub GraficoAteTP_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)

    End Sub
End Class