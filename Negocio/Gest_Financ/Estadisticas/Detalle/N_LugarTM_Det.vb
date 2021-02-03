﻿Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_LugarTM_Det
    'Declaraciones Generales
    Dim DD_Data As D_LugarTM_Det
    Sub New()
        DD_Data = New D_LugarTM_Det
    End Sub
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_IST(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_IST(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
    End Function
    Function IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_DATA_ATB_GRAM(ByVal ID_PREVE As Integer, ByVal AÑO_DESC As String) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_DATA_ATB_GRAM(ID_PREVE, AÑO_DESC)
    End Function
    Function IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46_IST(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Return DD_Data.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46_IST(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_TM_Prevision As New N_LugarTM_Det
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim Mx_Data(14, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        Dim Str_d1() As String = Split(DESDE, "a")
        Dim Str_d2() As String = Split(HASTA, "a")


        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))

        Dim data_ATB_GRAM As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        'data_ATB_GRAM = NN_TM_Prevision.IRIS_WEBF_CMVM_BUSCA_DATA_ATB_GRAM(ID_PREV, Split(DESDE, "/")(2))
        data_ATB_GRAM = NN_TM_Prevision.IRIS_WEBF_CMVM_BUSCA_DATA_ATB_GRAM(ID_PREV, Str_d1(2))

        If (E_DESDE = 0) And (E_HASTA = 0) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(Date01, Date02, ID_CF, ID_FP, ID_PREV)

            For i = 0 To Data_TM_Provision.Count - 1
                Dim item_atb_gram As New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6
                Dim item_atb_gram2 As New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6
                If Data_TM_Provision(i).ID_CODIGO_FONASA = 284 Then         'cultivo corriente 1
                    '279 tincion de gram 1
                    '304 ATB 1

                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(0).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(0).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(0).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(1).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(1).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(1).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                ElseIf Data_TM_Provision(i).ID_CODIGO_FONASA = 812 Then     'cultivo corriente 2
                    '464 tincion de gram 2
                    '305 atb 2

                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(3).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(3).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(3).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(2).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(2).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(2).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                ElseIf Data_TM_Provision(i).ID_CODIGO_FONASA = 820 Then     'cultivo corriente 3
                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(4).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(4).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(4).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(6).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(6).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(6).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                ElseIf Data_TM_Provision(i).ID_CODIGO_FONASA = 1123 Then    'cultivo corriente 4
                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(5).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(5).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(5).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(7).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(7).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(7).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                End If
            Next i

        ElseIf (E_DESDE < E_HASTA) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(Date01, Date02, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)

            For i = 0 To Data_TM_Provision.Count - 1
                Dim item_atb_gram As New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6
                Dim item_atb_gram2 As New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6
                If Data_TM_Provision(i).ID_CODIGO_FONASA = 284 Then         'cultivo corriente 1
                    '279 tincion de gram 1
                    '304 ATB 1

                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(0).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(0).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(0).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(1).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(1).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(1).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                ElseIf Data_TM_Provision(i).ID_CODIGO_FONASA = 812 Then     'cultivo corriente 2
                    '464 tincion de gram 2
                    '305 atb 2

                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(3).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(3).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(3).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(2).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(2).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(2).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                ElseIf Data_TM_Provision(i).ID_CODIGO_FONASA = 820 Then     'cultivo corriente 3
                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(4).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(4).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(4).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(6).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(6).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(6).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                ElseIf Data_TM_Provision(i).ID_CODIGO_FONASA = 1123 Then    'cultivo corriente 4
                    item_atb_gram.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram.CF_DESC = data_ATB_GRAM(5).CF_DESC
                    item_atb_gram.CF_COD = data_ATB_GRAM(5).CF_COD
                    item_atb_gram.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram.ATE_DET_V_PREVI = data_ATB_GRAM(5).CF_PRECIO_AMB
                    item_atb_gram.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC
                    '--------------------------------------------------------------------
                    item_atb_gram2.ATE_NUM = Data_TM_Provision(i).ATE_NUM
                    item_atb_gram2.ATE_FECHA = Data_TM_Provision(i).ATE_FECHA
                    item_atb_gram2.PAC_RUT = Data_TM_Provision(i).PAC_RUT
                    item_atb_gram2.SEXO_DESC = Data_TM_Provision(i).SEXO_DESC
                    item_atb_gram2.PAC_FNAC = Data_TM_Provision(i).PAC_FNAC
                    item_atb_gram2.ATE_AÑO = Data_TM_Provision(i).ATE_AÑO
                    item_atb_gram2.ATE_MES = Data_TM_Provision(i).ATE_MES
                    item_atb_gram2.ATE_DIA = Data_TM_Provision(i).ATE_DIA
                    item_atb_gram2.PAC_NOMBRE = Data_TM_Provision(i).PAC_NOMBRE
                    item_atb_gram2.PAC_APELLIDO = Data_TM_Provision(i).PAC_APELLIDO
                    item_atb_gram2.CF_DESC = data_ATB_GRAM(7).CF_DESC
                    item_atb_gram2.CF_COD = data_ATB_GRAM(7).CF_COD
                    item_atb_gram2.PROC_DESC = Data_TM_Provision(i).PROC_DESC
                    item_atb_gram2.ATE_DET_V_PREVI = data_ATB_GRAM(7).CF_PRECIO_AMB
                    item_atb_gram2.PREVE_DESC = Data_TM_Provision(i).PREVE_DESC
                    item_atb_gram2.DOC_NOMBRE = Data_TM_Provision(i).DOC_NOMBRE
                    item_atb_gram2.DOC_APELLIDO = Data_TM_Provision(i).DOC_APELLIDO
                    item_atb_gram2.PROGRA_DESC = Data_TM_Provision(i).PROGRA_DESC

                    Data_TM_Provision.Add(item_atb_gram)
                    Data_TM_Provision.Add(item_atb_gram2)
                End If
            Next i
        End If
        If (Data_TM_Provision.Count = 0) Then
            Return "null"
            Exit Function
        End If
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
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
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
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo)
        sl.SetCellStyle("B4", estilo)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"

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

        'For y = 8 To ltabla + 1
        '    sl.SetCellStyle(CStr("K" & y), formatonum)
        '    'sl.SetCellStyle(CStr("E" & y), formatonum)
        'Next y
        'sumar columnas
        'sl.SetCellValue(CStr("K" & ltabla + 1), CStr("=SUM(" & "K" & "8:" & "K" & ltabla & ")"))
        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        'For i = Asc("A") To Asc("J")
        '    sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        'Next i
        'sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_TM_Provision(0).PROC_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_IST(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim NN_TM_Prevision As New N_LugarTM_Det
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim Mx_Data(14, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        Dim Str_d1() As String = Split(DESDE, "a")
        Dim Str_d2() As String = Split(HASTA, "a")

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        If (E_DESDE = 0) And (E_HASTA = 0) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46_IST(Date01, Date02, ID_CF, ID_FP, ID_PREV)
        ElseIf (E_DESDE < E_HASTA) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_IST(Date01, Date02, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
        End If
        If (Data_TM_Provision.Count = 0) Then
            Return "null"
            Exit Function
        End If
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
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
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
        stTotal.Font.FontSize = 10
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo)
        sl.SetCellStyle("B4", estilo)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"

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

        'For y = 8 To ltabla + 1
        '    sl.SetCellStyle(CStr("K" & y), formatonum)
        '    'sl.SetCellStyle(CStr("E" & y), formatonum)
        'Next y
        'sumar columnas
        'sl.SetCellValue(CStr("K" & ltabla + 1), CStr("=SUM(" & "K" & "8:" & "K" & ltabla & ")"))
        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        'For i = Asc("A") To Asc("J")
        '    sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        'Next i
        'sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_TM_Provision(0).PROC_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

End Class