Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization
Public Class ValoresCriticos_EMB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Request_Prevision(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_PROCEDENCIA_ACTIVO(ID_PROC)

        Return data_paciente
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
    Public Shared Function Llenar_Ddl_22() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_Programa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO = New N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
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
    Public Shared Function IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F(ByVal id_cf As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F)
        Dim NN As N_ValoresCriticos_EMB = New N_ValoresCriticos_EMB

        data_paciente = NN.IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F(id_cf)
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
    Public Shared Function Call_Ddl_Stat() As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        str_Builder.Append("[")
        str_Builder.Append("{")
        str_Builder.Append("'Text': 'Bajo', ")
        str_Builder.Append("'Value': 1")
        str_Builder.Append("}, ")
        str_Builder.Append("{")
        str_Builder.Append("'Text': 'Alto', ")
        str_Builder.Append("'Value': 2")
        str_Builder.Append("}")
        str_Builder.Append("]")

        Return str_Builder.ToString.Replace("'", Chr(34))
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_DataTable(ByVal DATE_str01 As String,
                                          ByVal DATE_str02 As String,
                                          ByVal ID_EXAM As Long,
                                          ByVal ID_PROg As Long,
                                          ByVal ID_PRUEB As Integer,
                                          ByVal ID_RESUL As Long,
                                          ByVal ID_STAT As Long,
                                          ByVal ID_SECC As Long,
                                          ByVal ID_PROCE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Table As New N_Check_Val_Criticos
        Dim List_Obj As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim DIA As Integer
        Dim MES As Integer
        Dim AÑO As Integer
        Dim DIA2 As Integer
        Dim MES2 As Integer
        Dim AÑO2 As Integer
        Dim NN_Date As New N_Date
        Dim N_ECrypt As New N_Encrypt
        DATE_str01 = DATE_str01.Replace("/", "-")
        DIA = DATE_str01.Split("-")(0)
        MES = DATE_str01.Split("-")(1)
        AÑO = DATE_str01.Split("-")(2)
        Dim Date_011 As Date = NN_Date.strToDate(AÑO, MES, DIA)

        DATE_str02 = DATE_str02.Replace("/", "-")
        DIA2 = DATE_str02.Split("-")(0)
        MES2 = DATE_str02.Split("-")(1)
        AÑO2 = DATE_str02.Split("-")(2)
        Dim DATE_str022 As Date = NN_Date.strToDate(AÑO2, MES2, DIA2)


        List_Obj = NN_Table.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_emb_2(Date_011, DATE_str022, ID_EXAM, ID_PROg, ID_PRUEB, ID_RESUL, ID_STAT, ID_SECC, ID_PROCE)

        If (List_Obj.Count > 0) Then
            For i = 0 To (List_Obj.Count - 1)
                List_Obj(i).Encyp = N_ECrypt.Encode(List_Obj(i).ID_ATENCION)
            Next i
            'Serializar Objeto en formato JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(List_Obj, str_Builder)

            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Call_Export(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_EXAM As Long, ByVal ID_PROg As Long, ByVal ID_PRUEB As Integer, ByVal ID_RESUL As Long, ByVal id_est As Integer, ByVal ID_SECC As Integer) As String

        Dim NN_Table As New N_Check_Val_Criticos
        Dim URL As String
        URL = NN_Table.Gen_Excel5(DOMAIN_URL, DATE_str01, DATE_str02, ID_EXAM, ID_PROg, ID_PRUEB, ID_RESUL, id_est, ID_SECC)

        Return URL
    End Function
End Class