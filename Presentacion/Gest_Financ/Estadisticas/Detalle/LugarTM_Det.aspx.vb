Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class LugarTM_Det
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Return Data_Prev_Activo
        'If (Data_Prev_Activo.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Prev_Activo, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Proce() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        Return Data_Proce
        'If (Data_Proce.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_Proce, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_T_Pago() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_T_Pago As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Consultar por previsiones activas
        Data_T_Pago = NN_Activos.IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE()
        Return Data_T_Pago
        'If (Data_T_Pago.Count > 0) Then
        '    'Serializar a Json
        '    Serializer.Serialize(Data_T_Pago, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim retorno As String
        'Declaraciones internas
        Dim NN_Date As New N_Date
        Dim NN_TM_Prevision As New N_LugarTM_Det
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim Date_01 As Date = NN_Date.strToDate(Split(DESDE, "/")(2), Split(DESDE, "/")(1), Split(DESDE, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(HASTA, "/")(2), Split(HASTA, "/")(1), Split(HASTA, "/")(0))
        retorno = ""

        Dim data_ATB_GRAM As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        data_ATB_GRAM = NN_TM_Prevision.IRIS_WEBF_CMVM_BUSCA_DATA_ATB_GRAM(ID_PREV, Split(DESDE, "/")(2))

        If (E_DESDE = 0) And (E_HASTA = 0) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEB_BUSCA_EST_ESTADOS_INFORMAR46(DESDE, HASTA, ID_CF, ID_FP, ID_PREV)

            'Tincion de Gram                                0
            'Antibiograma Corriente                         1
            'Antibiograma Corriente Nº2                     2
            'Tinción de Gram Nº2                            3
            'Tincion de Gram Irislab 3                      4
            'Tincion de Gram Irislab 4                      5
            'Antibiograma Cultivo Corriente Irislab 3       6
            'Antibiograma Cultivo Corriente Irislab 4       7

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



            Return Data_TM_Provision
            'If (Data_TM_Provision.Count > 0) Then
            '    'Serializar con JSON
            '    Serializer.MaxJsonLength = 999999999
            '    Serializer.Serialize(Data_TM_Provision, str_Builder)
            '    retorno = str_Builder.ToString
            'Else
            '    retorno = ("null")
            'End If
        ElseIf (E_DESDE < E_HASTA) Then
            Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)

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

            Return Data_TM_Provision
            'If (Data_TM_Provision.Count > 0) Then
            '    'Serializar con JSON
            '    Serializer.MaxJsonLength = 999999999
            '    Serializer.Serialize(Data_TM_Provision, str_Builder)
            '    retorno = str_Builder.ToString
            'Else
            '    retorno = ("null")
            'End If
        Else
            Return Nothing
            'retorno = ("null")
        End If
        'Return retorno
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_FP As Integer, ByVal ID_PREV As Integer, ByVal E_DESDE As Integer, ByVal E_HASTA As Integer) As String
        Dim NN_TM_Prevision As New N_LugarTM_Det
        Return NN_TM_Prevision.Gen_Excel(MAIN_URL, DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA)
    End Function

    <Services.WebMethod()>
    Public Shared Sub Gen_Excel_Async(ByVal MAIN_URL As String,
                                      ByVal DESDE As String,
                                      ByVal HASTA As String,
                                      ByVal ID_CF As Integer,
                                      ByVal ID_FP As Integer,
                                      ByVal ID_PREV As Integer,
                                      ByVal E_DESDE As Integer,
                                      ByVal E_HASTA As Integer,
                                      ByVal EMAIL As String)

        Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim URL_Base As String = HttpContext.Current.Request.Url.Authority

        Dim NN_Gen As New N_LugarTM_Det_Async(strLocal, URL_Base, N_Date.toDate(DESDE), N_Date.toDate(HASTA), ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, EMAIL)

        Dim Hilo As Threading.Thread = New Threading.Thread(
        New Threading.ThreadStart(AddressOf NN_Gen.Gen_Excel_Async)
    )
        Hilo.Start()

    End Sub

    Private Sub LugarTM_Det_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class