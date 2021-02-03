Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization

Public Class Rel_Est_Exam
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            Return Data_LugarTM
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prevision() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim NN_Preve As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Preve As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Data_Preve = NN_Preve.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Preve.Count > 0) Then
            Return Data_Preve
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Estadistica() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU = New N_IRIS_WEBF_BUSCA_EST_DETER_POR_PRU
        data_paciente = NN.IRIS_WEBF_BUSCA_EST_DETER_POR_PRU()
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
    Public Shared Function Call_DataTable(ByVal DATE_str01 As String,
                                          ByVal DATE_str02 As String,
                                          ByVal ID_EST As Integer,
                                          ByVal ID_PROC As Integer,
                                          ByVal ID_PREVE As Integer,
                                          ByVal ID_ESTADO As Integer) As String
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
        Dim NN_Date As New N_Date_Operat
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

        List_Obj = NN_Table.IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2(Date_011, DATE_str022, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO) 'ID ESTADO
        If (List_Obj.Count > 0) Then
            'Serializar Objeto en formato JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(List_Obj, str_Builder)

            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Call_Export(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String,
                                          ByVal DATE_str02 As String,
                                          ByVal ID_EST As Integer,
                                          ByVal ID_PROC As Integer,
                                          ByVal ID_PREVE As Integer,
                                          ByVal ID_ESTADO As Integer) As String

        Dim NN_Table As New N_Check_Val_Criticos
        Dim URL As String

        Dim DIA As Integer
        Dim MES As Integer
        Dim AÑO As Integer
        Dim DIA2 As Integer
        Dim MES2 As Integer
        Dim AÑO2 As Integer
        Dim NN_Date As New N_Date_Operat
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

        URL = NN_Table.Gen_ExcelRELLLLL2(DOMAIN_URL, Date_011, DATE_str022, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO)

        Return URL
    End Function

End Class