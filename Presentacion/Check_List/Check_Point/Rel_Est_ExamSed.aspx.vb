﻿Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization

Public Class Rel_Est_ExamSed
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

        For y = 0 To List_Obj.Count - 1
            'Seleccionar valor
            Dim Res_Num As Double = List_Obj(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = List_Obj(y).ATE_RESULTADO
            Dim Res_Alt As String = List_Obj(y).ATE_RESULTADO_ALT

            Dim Final_Stage As String = ""

            If (Res_Str <> Nothing) Then
                Try
                    Final_Stage = CDbl(Res_Str)
                Catch
                    Final_Stage = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Final_Stage = Res_Num
            Else
                If (Res_Alt <> Nothing) Then
                    Final_Stage = Res_Alt
                Else
                    Final_Stage = "-"
                End If

            End If
            'Limpiar Valores de Resultados
            Dim objValNum As String = List_Obj(y).ATE_RESULTADO_NUM
            Dim objValStr As String = List_Obj(y).ATE_RESULTADO

            If (IsNothing(objValNum) = False) Then
                objValNum = Trim(objValNum)
            End If

            If (IsNothing(objValStr) = False) Then
                objValStr = Trim(objValStr)
            End If

            If (List_Obj(y).ID_TP_RESULTADO <> 1) Then
                Final_Stage = objValNum
            Else
                Final_Stage = objValStr
            End If
            Dim pru_Cero As Boolean
            If (List_Obj(y).PRU_P_CERO > 0) Then
                pru_Cero = True
            Else
                pru_Cero = False
            End If
            If ((IsNumeric(Final_Stage) = True)) Then
                If ((pru_Cero = False) And (CDbl(Final_Stage.Replace(",", ".")) = 0)) Then

                    Final_Stage = ""
                End If
            End If
            If ((IsNumeric(Final_Stage) = True)) Then

                Dim numerito_3 As String
                Dim N_Dbl_3 As Double
                numerito_3 = Final_Stage
                numerito_3 = numerito_3.Replace(",", ".")
                N_Dbl_3 = CDbl(Val(numerito_3))
                N_Dbl_3 = Math.Round(N_Dbl_3, CInt(List_Obj(y).PRU_DECIMAL))

                Final_Stage = N_Dbl_3
            End If
        Next y





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

        URL = NN_Table.Gen_ExcelRELLLLL2_ORINA_SEDI(DOMAIN_URL, Date_011, DATE_str022, ID_EST, ID_PROC, ID_PREVE, ID_ESTADO)

        Return URL
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class