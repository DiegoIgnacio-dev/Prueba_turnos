Imports Datos
Imports Entidades

Public Class N_Ate_Resultados
    'Declaraciones generales
    Dim DD_Data As D_Ate_Resultados

    Sub New()
        DD_Data = New D_Ate_Resultados

    End Sub

    'CULTIVOS

    Function IRIS_WEBF_GUARDA_QUITA_PANEL(ByVal Mx_Panel As List(Of E_IRIS_WEBF_GUARDA_QUITA_PANEL)) As Integer

        Dim ret As Integer = 0

        For Each p In Mx_Panel
            If p.TYPE = "Crea" Then

                Dim x_Item As New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA

                x_Item = DD_Data.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_BY_ID(p.ID_PREVE, Format(Date.Now, "yyyy"), p.ID_PANEL)

                Dim ID_Item As New ids555
                Dim ID_List As New List(Of ids555)

                ID_Item.id_CF = x_Item.ID_CODIGO_FONASA
                ID_Item.id_PER = x_Item.ID_PER
                ID_Item.Valor = x_Item.CF_PRECIO_AMB
                ID_Item.CF_ESTADO_EXAMEN = "Activo"
                ID_Item.CF_MULTIPLICADOS = ""
                ID_Item.HO_CC = 0

                ID_List.Add(ID_Item)

                Guardar_TodoByVal(ID_List, p.ID_ATE)

                ret += DD_Data.IRIS_WEBF_CMVM_GRABA_REL_PANEL_ANTIB(p.ID_ATE, p.ID_CF_CULT, p.ID_PANEL)

            Else

                ret += DD_Data.IRIS_WEBF_QUITA_PANEL_ANTIB(p.ID_ATE, p.ID_CF_CULT, p.ID_PANEL)

            End If
        Next

        Return ret
    End Function
    Function IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS)
        Return DD_Data.IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS(ID_ATE)
    End Function
    Function IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS)
        Return DD_Data.IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS(ID_CF, ID_ATE)
    End Function
    Function IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS)
        Return DD_Data.IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS(ID_CF, ID_ATE)
    End Function


    Function IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2(ByVal ID_ATE As Long,
                                                                     ByVal ID_SECCION As Long,
                                                                     ByVal ID_EXAMEN As Long,
                                                                     ByVal R_DIA As Integer,
                                                                     ByVal R_MES As Integer,
                                                                     ByVal R_AÑO As Integer)
        Return DD_Data.IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2(ID_ATE, ID_SECCION, ID_EXAMEN, R_DIA, R_MES, R_AÑO)

    End Function

    Function IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION(ByVal ID_ATE As Long, ByVal ID_PAC As Long, ByVal ID_PRU As Long) As List(Of E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION)
        Return DD_Data.IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION(ID_ATE, ID_PAC, ID_PRU)

    End Function

    Function IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ByVal ID_PRU As Long, ByVal SEXO As String) As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        Return DD_Data.IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ID_PRU, SEXO)

    End Function

    Function Calcular_Rango_Ref(ByVal Fecha_Ficha As Date, ByVal D_Year As Integer, ByVal D_Month As Integer, ByVal D_Day As Integer) As Date
        Dim Date_Tmp As Date = Fecha_Ficha

        Date_Tmp = Date_Tmp.AddYears(-D_Year)
        Date_Tmp = Date_Tmp.AddMonths(-D_Month)
        Date_Tmp = Date_Tmp.AddDays(-D_Day)

        Return Date_Tmp
    End Function


    Function IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION(ByVal ID_ATE As Long) As List(Of Sel_Secc_Parser)
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION)
        Dim List_Out As New List(Of Ddl_List_Resultados)
        Dim List_Count As New List(Of Sel_Secc_Parser)

        List_In = DD_Data.IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION(ID_ATE)
        'Return List_In

        For i = 0 To (List_In.Count - 1)
            Dim Item As Sel_Secc_Parser

            If (i = 0) Then
                Item = New Sel_Secc_Parser
                Item.arrID = New List(Of Integer)
                Item.ID_SECC = 0
                Item.Descr = "<< Todos >>"

                For ii = 0 To (List_In.Count - 1)
                    Item.arrID.Add(List_In(ii).ID_CODIGO_FONASA)
                Next ii
                List_Count.Add(Item)

                Item = New Sel_Secc_Parser
                Item.arrID = New List(Of Integer)
                Item.arrID.Add(List_In(i).ID_CODIGO_FONASA)
                Item.ID_SECC = List_In(i).ID_SECCION
                Item.Descr = List_In(i).RLS_LS_DESC

                List_Count.Add(Item)
            Else
                Dim xIndex As Integer = List_Count.Count - 1

                If (List_In(i).ID_SECCION = List_In(i - 1).ID_SECCION) Then
                    List_Count(xIndex).arrID.Add(List_In(i).ID_CODIGO_FONASA)
                Else
                    Item = New Sel_Secc_Parser

                    Item.arrID = New List(Of Integer)
                    Item.arrID.Add(List_In(i).ID_CODIGO_FONASA)
                    Item.ID_SECC = List_In(i).ID_SECCION
                    Item.Descr = List_In(i).RLS_LS_DESC

                    List_Count.Add(Item)
                End If
            End If
        Next i

        'For i = 0 To (List_Count.Count - 1)


        'Next i
        Return List_Count
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION)
        Return DD_Data.IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION(ID_ATE)

    End Function

    Function IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION(ByVal ID_ATE As Long, ByVal ID_RLS As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION)
        Return DD_Data.IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION(ID_ATE, ID_RLS)

    End Function

    Public Sub IRIS_WEBF_GRABA_CONTROL_AUDITORIA(ByVal ID_USER As Integer, ByVal ACTION As String, ByVal FORM As String, ByVal ID_ATE_RES As Long)
        DD_Data.IRIS_WEBF_GRABA_CONTROL_AUDITORIA(ID_USER, ACTION, FORM, ID_ATE_RES)
    End Sub

    Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ByVal ID_RES As Integer, ByVal RES As String)
        DD_Data.IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ID_RES, RES)
    End Sub

    Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ByVal ID_RES As Integer, ByVal RES As String, ByVal EVAL As String)
        DD_Data.IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ID_RES, RES, EVAL)
    End Sub
    Function IRIS_WEBF_BUSCA_CONTROL_AUDITORIA(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        Return DD_Data.IRIS_WEBF_BUSCA_CONTROL_AUDITORIA(ID_ATE_RES)
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS(ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS(ID_PRUEBA)
    End Function

    Sub IRIS_WEBF_UPDATE_VALIDA_RESULTADO(ByVal ID_ATE_RES As Integer, ByVal ID_USUARIO As Integer, ByVal DESDE As String, ByVal HASTA As String, ByVal AB As String, ByVal MUY_DESDE As String, ByVal MUY_HASTA As String, ByVal MUY_AB As Integer, ByVal UNIDADES As String)
        DD_Data.IRIS_WEBF_UPDATE_VALIDA_RESULTADO(ID_ATE_RES, ID_USUARIO, DESDE, HASTA, AB, MUY_DESDE, MUY_HASTA, MUY_AB, UNIDADES)
    End Sub

    Sub IRIS_WEBF_UPDATE_DESVALIDA_RESULTADO(ByVal ID_ATE_RES As Integer, ByVal ID_USUARIO As Integer)
        DD_Data.IRIS_WEBF_UPDATE_DESVALIDA_RESULTADO(ID_ATE_RES, ID_USUARIO)
    End Sub

    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R(ByVal ID_ATE As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                          ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                          ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long) As Long
        Dim ID_USER As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        If (IsNothing(ID_USER) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATE_L_R(ID_ATE, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI, CInt(ID_USER.Value))
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R_2(ByVal ATE_NUM As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                          ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                          ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long) As Long
        Dim ID_USER As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        If (IsNothing(ID_USER) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATE_L_R_2(ATE_NUM, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI, CInt(ID_USER.Value))
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO() As List(Of E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO()
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO(ByVal ID_ATE As Long) As E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO(ID_ATE)

    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(ByVal NUM_ATE As Long) As Long
        Dim ID_USER As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        If (IsNothing(ID_USER) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(NUM_ATE, CInt(ID_USER.Value))
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS(ByVal ID_ATE As Long, ByVal ID_PRU As Long, ByVal BL_ALL As Boolean) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS)
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS(ID_ATE, ID_PRU, BL_ALL)
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE)
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE(ID_ATE)
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF(ByVal ID_ATE As Long, ByVal ID_CF As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU)
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF(ID_ATE, ID_CF)
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA(ByVal ID_ATE As Long, ByVal ID_CF As Long) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA(ID_ATE, ID_CF)
    End Function
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    Dim E_ID_ATE As Long
    Dim E_ID_SECC As Integer
    Dim E_ID_EXAM As Long
    Dim E_ID_PAC As Long
    Dim E_F_NAC As Date
    Dim E_SEXO As String

    Public Property ID_ATE As Long
        Get
            Return E_ID_ATE
        End Get
        Set(value As Long)
            E_ID_ATE = value
        End Set
    End Property

    Public Property ID_SECC As Integer
        Get
            Return E_ID_SECC
        End Get
        Set(value As Integer)
            E_ID_SECC = value
        End Set
    End Property

    Public Property ID_EXAM As Long
        Get
            Return E_ID_EXAM
        End Get
        Set(value As Long)
            E_ID_EXAM = value
        End Set
    End Property

    Public Property ID_PAC As Long
        Get
            Return E_ID_PAC
        End Get
        Set(value As Long)
            E_ID_PAC = value
        End Set
    End Property

    Public Property F_NAC As Date
        Get
            Return E_F_NAC
        End Get
        Set(value As Date)
            E_F_NAC = value
        End Set
    End Property

    Public Property SEXO As String
        Get
            Return E_SEXO
        End Get
        Set(value As String)
            E_SEXO = value
        End Set
    End Property

    Function Build_Json_Datatable(ByRef Data_Res01 As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)) As List(Of E_Json_Result_DataTable)
        Dim Data_Hist As New List(Of E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION)
        Dim Json_Item As E_Json_Result_DataTable
        Dim Json_List As New List(Of E_Json_Result_DataTable)

        For y = 0 To (Data_Res01.Count - 1)
            Json_Item = New E_Json_Result_DataTable

            'Celda 01
            Dim Data_TP As New E_Json_Result_DataTable_Type_Data
            Data_TP.ID_TD = Data_Res01(y).ID_TP_RESULTADO
            Data_TP.DESC_TD = Data_Res01(y).TP_RESUL_COD

            Json_Item.TT = Data_TP

            'Celda 02
            Dim Json_Item_EE As New E_Json_Result_DataTable_EstadValidac
            Json_Item_EE.estado = Data_Res01(y).EST_COD
            Json_Item_EE.value = Data_Res01(y).ATE_EST_VALIDA

            Select Case Json_Item_EE.value
                Case 6, 14
                    Json_Item_EE.estado = Data_Res01(y).EST_COD
                Case Else
                    Json_Item_EE.estado = ""
            End Select
            Json_Item.EE = Json_Item_EE

            'Celda 03
            Dim Json_Exam As New E_Json_Result_DataTable_Examen
            Json_Exam.ID_PER = Data_Res01(y).ID_PER
            Json_Exam.ID_EXA = Data_Res01(y).ID_PRUEBA
            Json_Exam.ID_CF = Data_Res01(y).ID_CODIGO_FONASA
            Json_Exam.Descrp = Data_Res01(y).CF_CORTO
            Json_Item.Exam = Json_Exam

            'Celda 04
            Json_Item.Desc = Data_Res01(y).PRU_DESC

            'Celda 05
            Dim Json_Item_Res As New E_Json_Result_DataTable_Values
            Json_Item_Res.pruDecimal = Data_Res01(y).PRU_DECIMAL

            Select Case Json_Item.EE.value
                Case 6, 14
                    Dim objB2 As Object = Trim(Data_Res01(y).ATE_RR_DESDE)      'Muy Bajo
                    Dim objB1 As Object = Trim(Data_Res01(y).ATE_R_DESDE)       'Bajo
                    Dim objA1 As Object = Trim(Data_Res01(y).ATE_R_HASTA)       'Alto
                    Dim objA2 As Object = Trim(Data_Res01(y).ATE_RR_HASTA)      'Muy Alto

                    '--Muy Bajo----------------------
                    If (IsNumeric(objB2) = True) Then
                        Json_Item_Res.b2 = CDbl(objB2)
                    ElseIf (Trim(objB2) <> "") Then
                        Json_Item_Res.b2 = objB2
                    Else
                        Json_Item_Res.b2 = Nothing
                    End If

                    '--Bajo--------------------------
                    If (IsNumeric(objB1) = True) Then
                        Json_Item_Res.b1 = CDbl(objB1)
                    ElseIf (Trim(objB1) <> "") Then
                        Json_Item_Res.b1 = objB1
                    Else
                        Json_Item_Res.b1 = Nothing
                    End If

                    '--Alto--------------------------
                    If (IsNumeric(objA1) = True) Then
                        Json_Item_Res.a1 = CDbl(objA1)
                    ElseIf (Trim(objA1) <> "") Then
                        Json_Item_Res.a1 = objA1
                    Else
                        Json_Item_Res.a1 = Nothing
                    End If

                    '--Muy Alto----------------------
                    If (IsNumeric(objA2) = True) Then
                        Json_Item_Res.a2 = CDbl(objA2)
                    ElseIf (Trim(objA2) <> "") Then
                        Json_Item_Res.a2 = objA2
                    Else
                        Json_Item_Res.a2 = Nothing
                    End If
                Case Else
                    Dim objB2 As Object = Trim(Data_Res01(y).RF_V_B_DESDE)      'Muy Bajo
                    Dim objB1 As Object = Trim(Data_Res01(y).RF_V_DESDE)       'Bajo
                    Dim objA1 As Object = Trim(Data_Res01(y).RF_V_HASTA)       'Alto
                    Dim objA2 As Object = Trim(Data_Res01(y).RF_V_A_HASTA)      'Muy Alto

                    '--Muy Bajo----------------------
                    If (IsNumeric(objB2) = True) Then
                        Json_Item_Res.b2 = CDbl(objB2)
                    ElseIf (Trim(objB2) <> "") Then
                        Json_Item_Res.b2 = objB2
                    Else
                        Json_Item_Res.b2 = Nothing
                    End If

                    '--Bajo--------------------------
                    If (IsNumeric(objB1) = True) Then
                        Json_Item_Res.b1 = CDbl(objB1)
                    ElseIf (Trim(objB1) <> "") Then
                        Json_Item_Res.b1 = objB1
                    Else
                        Json_Item_Res.b1 = Nothing
                    End If

                    '--Alto--------------------------
                    If (IsNumeric(objA1) = True) Then
                        Json_Item_Res.a1 = CDbl(objA1)
                    ElseIf (Trim(objA1) <> "") Then
                        Json_Item_Res.a1 = objA1
                    Else
                        Json_Item_Res.a1 = Nothing
                    End If

                    '--Muy Alto----------------------
                    If (IsNumeric(objA2) = True) Then
                        Json_Item_Res.a2 = CDbl(objA2)
                    ElseIf (Trim(objA2) <> "") Then
                        Json_Item_Res.a2 = objA2
                    Else
                        Json_Item_Res.a2 = Nothing
                    End If
            End Select

            'Limpiar Valores de Resultados
            Dim objValNum As String = Data_Res01(y).ATE_RESULTADO_NUM
            Dim objValStr As String = Data_Res01(y).ATE_RESULTADO

            If (IsNothing(objValNum) = False) Then
                objValNum = Trim(objValNum)
            End If

            If (IsNothing(objValStr) = False) Then
                objValStr = Trim(objValStr)
            End If

            If (Json_Item.TT.ID_TD <> 1) Then
                Json_Item_Res.value = objValNum
            Else
                Json_Item_Res.value = objValStr
            End If

            Json_Item_Res.ID_RES = Data_Res01(y).ID_ATE_RES

            If (Data_Res01(y).PRU_P_CERO > 0) Then
                Json_Item_Res.pruCero = True
            Else
                Json_Item_Res.pruCero = False
            End If

            If (Data_Res01(y).REQ_RES_VAL.ToUpper = "1") Then
                Json_Item_Res.NEED_VALIDATE = True
            End If

            Json_Item_Res.PRU_COD = Data_Res01(y).PRU_COD
            Json_Item_Res.vector = Data_Res01(y).PRU_VECTOR_CALCULO
            Json_Item.Res = Json_Item_Res

            'Celda 06
            Json_Item.Unit = Data_Res01(y).UM_DESC

            'Celda 07

            If ((IsNumeric(Json_Item.Res.b1) = True) And (IsNumeric(Json_Item.Res.a1) = True)) Then
                If (IsNumeric(Json_Item.Res.value) = True) Then
                    Select Case Json_Item.Res.value
                        Case Is < Json_Item.Res.b1
                            Json_Item.Stat = "B"
                        Case Is > Json_Item.Res.a1
                            Json_Item.Stat = "A"
                        Case Else
                            Json_Item.Stat = "N"
                    End Select
                Else
                    'Json_Item.Stat = "E"
                    Json_Item.Stat = ""
                End If
            End If

            'Celda 08
            Select Case IsNumeric(Json_Item_Res.b1)
                Case True
                    Json_Item.Desd = Format(CDbl(Json_Item_Res.b1), "###,###,##0.##")
                Case Else
                    Json_Item.Desd = Json_Item_Res.b1
            End Select

            'Celda 09
            Select Case IsNumeric(Json_Item_Res.a1)
                Case True
                    Json_Item.Hast = Format(CDbl(Json_Item_Res.a1), "###,###,##0.##")
                Case Else
                    Json_Item.Hast = Json_Item_Res.a1
            End Select

            'Celda 10
            Dim NN_Ate As New N_Ate_Resultados
            Dim NN_Age As New N_Calc_Age
            'Data_Hist = NN_Ate.IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION(ID_ATE, ID_PAC, Data_Res01(y).ID_PRUEBA)
            'If (Data_Hist.Count > 0) Then
            If (Data_Res01(y).RES_HIST <> "" And Data_Res01(y).RES_HIST <> Nothing) Then
                Json_Item.ReHi = Data_Res01(y).RES_HIST
                Json_Item.cDia = NN_Age.IrisLAB_Cal_Edad_Exacta(Data_Res01(y).RES_HIST_FECHA, Date.Now, True)
            ElseIf Data_Res01(y).RES_HIST_NUM <> "" And Data_Res01(y).RES_HIST_NUM <> Nothing Then
                Json_Item.ReHi = Data_Res01(y).RES_HIST_NUM
                Json_Item.cDia = NN_Age.IrisLAB_Cal_Edad_Exacta(Data_Res01(y).RES_HIST_FECHA, Date.Now, True)
            End If




            ' End If

            'Añadir Items a la lista
            Json_List.Add(Json_Item)
        Next y

        Return Json_List
    End Function

    Private Function Json_Item_Result_Interval(ByVal ID_Prueba As Long, ByVal Json_Item As E_Json_Result_DataTable_Values) As E_Json_Result_DataTable_Values
        Dim NN_Ate As New N_Ate_Resultados
        Dim NN_Date As New N_Date
        Dim Data_Rango As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)

        Dim Date_01(2) As Double
        Dim Date_02(2) As Double


        '   R_ANO_DESDE <@AÑO && R_ANO_HASTA> @AÑO

        Dim F_nacim(2) As Long
        F_nacim(0) = Format(F_NAC, "yyyy")
        F_nacim(1) = Format(F_NAC, "MM")
        F_nacim(2) = Format(F_NAC, "dd")

        Dim Date_Nac As Date = NN_Date.strToDate(F_nacim(0), F_nacim(1), F_nacim(2))
        Dim Date_Desde As Date = Nothing
        Dim Date_Hasta As Date = Nothing

        Dim Encontrar_Datos As Boolean = False
        Dim rel_pos As Long = 0

        Data_Rango = NN_Ate.IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ID_Prueba, SEXO)
        If (Data_Rango.Count > 0) Then
            For y = 0 To (Data_Rango.Count - 1)
                Date_01(0) = Data_Rango(y).RF_ANO_DESDE
                Date_01(1) = Data_Rango(y).RF_MESES_DESDE
                Date_01(2) = Data_Rango(y).RF_DIAS_DESDE

                Date_02(0) = Data_Rango(y).RF_ANO_HASTA
                Date_02(1) = Data_Rango(y).RF_MESES_HASTA
                Date_02(2) = Data_Rango(y).RF_DIAS_HASTA

                Date_Desde = NN_Ate.Calcular_Rango_Ref(Date.Now, Date_01(0), Date_01(1), Date_01(2))
                Date_Hasta = NN_Ate.Calcular_Rango_Ref(Date.Now, Date_02(0), Date_02(1), Date_02(2))

                If (Date_Hasta <= Date_Nac) And (Date_Nac <= Date_Desde) Then
                    Encontrar_Datos = True
                    rel_pos = y
                    Exit For
                End If
            Next y
        End If

        If (Encontrar_Datos = True) Then
            Dim objB2 As Object     'Muy Bajo
            Dim objB1 As Object     'Bajo
            Dim objA1 As Object     'Alto
            Dim objA2 As Object     'Muy Alto

            If ((Trim(Data_Rango(rel_pos).RF_R_TEXTO).ToLower <> "null") And (Trim(Data_Rango(rel_pos).RF_R_TEXTO).ToLower <> Nothing)) Then
                objB2 = ""                                          'Muy Bajo
                objB1 = Trim(Data_Rango(rel_pos).RF_R_TEXTO)        'Bajo
                objA1 = "-"                                         'Alto
                objA2 = ""                                          'Muy Alto
            Else
                objB2 = Trim(Data_Rango(rel_pos).RF_V_B_DESDE)      'Muy Bajo
                objB1 = Trim(Data_Rango(rel_pos).RF_V_DESDE)        'Bajo
                objA1 = Trim(Data_Rango(rel_pos).RF_V_HASTA)        'Alto
                objA2 = Trim(Data_Rango(rel_pos).RF_V_A_HASTA)      'Muy Alto

            End If

            '--Muy Bajo----------------------
            If (IsNumeric(objB2) = True) Then
                Json_Item.b2 = CDbl(objB2)
            ElseIf (Trim(objB2) <> "") Then
                Json_Item.b2 = objB2
            Else
                Json_Item.b2 = Nothing
            End If

            '--Bajo--------------------------
            If (IsNumeric(objB1) = True) Then
                Json_Item.b1 = CDbl(objB1)
            ElseIf (Trim(objB1) <> "") Then
                Json_Item.b1 = objB1
            Else
                Json_Item.b1 = Nothing
            End If

            '--Alto--------------------------
            If (IsNumeric(objA1) = True) Then
                Json_Item.a1 = CDbl(objA1)
            ElseIf (Trim(objA1) <> "") Then
                Json_Item.a1 = objA1
            Else
                Json_Item.a1 = Nothing
            End If

            '--Muy Alto----------------------
            If (IsNumeric(objA2) = True) Then
                Json_Item.a2 = CDbl(objA2)
            ElseIf (Trim(objA2) <> "") Then
                Json_Item.a2 = objA2
            Else
                Json_Item.a2 = Nothing
            End If
        End If

        Return Json_Item
    End Function
    Public Function Guardar_TodoByVal(ByVal ids As List(Of ids555), ByVal ID_ATENCION As Integer) As Integer


        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        Dim correlativo2 As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
        Dim id As Integer
        Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
        Dim resu As Integer
        Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
        Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        Dim Str_Out As String = ""
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        End If

        If S_Id_User = "0" Then
            S_Id_User = "1"
        End If

        For i = 0 To ids.Count - 1
            id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_2(ID_ATENCION,
                                                                       CInt(S_Id_User),
                                                                     ids(i).id_CF,
                                                                      ids(i).id_PER,
                                                                       1,
                                                                       0,
                                                                     ids(i).Valor,
                                                                       ids(i).Valor,
                                                                       0,
                                                                        ids(i).HO_CC, ids(i).CF_MULTIPLICADOS, ids(i).CODIGO_TEST)

            PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ids(i).id_PER)

            For x = 0 To PERFIL_PRUEBA.Count - 1
                If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                Else
                    If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                    Else
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                    End If
                End If
            Next x
        Next i

        Dim NN_ExamenDet As New N_Exa_Esp_V
        Dim DataExamenDet As Integer
        Dim exa_avis As Integer

        For i = 0 To ids.Count - 1
            If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ID_ATENCION, ids(i).id_CF)

                'If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
                '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
                'End If
            End If

        Next i

        Dim numero As Integer
        Dim N_N As N_IRIS_OBTENER_INFO = New N_IRIS_OBTENER_INFO

        For i = 0 To ids.Count - 1
            If ((ids(i).HO_CC = 0) And (IsNothing(ids(i).CODIGO_TEST) = True)) Then
                Continue For
            End If

            If (ids(i).CF_ESTADO_EXAMEN <> "Espera") Then
                numero = N_N.UPDATE_ESTADO_TEST(ids(i).HO_CC, ids(i).CODIGO_TEST)
            End If

        Next i

        For x = 0 To ids.Count - 1
            If ((ids(x).HO_CC = 0) And (IsNothing(ids(x).CODIGO_TEST) = True)) Then
                Continue For
            End If

            If (ids(x).CF_MULTIPLICADOS <> "" And ids(x).CF_ESTADO_EXAMEN <> "Espera") Then
                Dim regex As New Regex("[0-9]+", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
                Dim match9000 As MatchCollection
                Dim list_Num As New List(Of String)

                match9000 = regex.Matches(ids(x).CF_MULTIPLICADOS)
                For y = 0 To (match9000.Count - 1)
                    If (match9000(y).Success = True) Then
                        numero = N_N.UPDATE_ESTADO_TEST(match9000(y).Value, ids(x).CODIGO_TEST)
                    End If
                Next y
            End If
        Next x







        Str_Out += "{"
        Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & ID_ATENCION & Chr(34) & ", "
        Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
        Str_Out += "}"
        Return 1


    End Function
End Class

Public Class Ddl_List_Resultados
    Private E_ID As String
    Public Property ID() As String
        Get
            Return E_ID
        End Get
        Set(ByVal value As String)
            E_ID = value
        End Set
    End Property

    Private E_Desc As String
    Public Property DESC() As String
        Get
            Return E_Desc
        End Get
        Set(ByVal value As String)
            E_Desc = value
        End Set
    End Property
End Class

Public Class Sel_Secc_Parser
    Private E_ARRID As List(Of Integer)
    Public Property arrID() As List(Of Integer)
        Get
            Return E_ARRID
        End Get
        Set(ByVal value As List(Of Integer))
            E_ARRID = value
        End Set
    End Property

    Private E_Descr As String
    Public Property Descr() As String
        Get
            Return E_Descr
        End Get
        Set(ByVal value As String)
            E_Descr = value
        End Set
    End Property

    Private E_ID_SECC As Long
    Public Property ID_SECC() As Long
        Get
            Return E_ID_SECC
        End Get
        Set(ByVal value As Long)
            E_ID_SECC = value
        End Set
    End Property
End Class

Public Class ids555
    Dim E_id_CF As Integer
    Dim E_id_PER As Integer
    Dim E_Valor As Integer
    Dim E_HO_CC As String
    Dim E_CF_ESTADO_EXAMEN As String
    Dim E_CF_MULTIPLICADOS As String
    Dim E_CODIGO_TEST As String
    Public Property CODIGO_TEST As String
        Get
            Return E_CODIGO_TEST
        End Get
        Set(ByVal value As String)
            E_CODIGO_TEST = value
        End Set
    End Property
    Public Property CF_MULTIPLICADOS As String
        Get
            Return E_CF_MULTIPLICADOS
        End Get
        Set(ByVal value As String)
            E_CF_MULTIPLICADOS = value
        End Set
    End Property
    Public Property CF_ESTADO_EXAMEN As String
        Get
            Return E_CF_ESTADO_EXAMEN
        End Get
        Set(ByVal value As String)
            E_CF_ESTADO_EXAMEN = value
        End Set
    End Property


    Public Property HO_CC As Integer
        Get
            Return E_HO_CC
        End Get
        Set(ByVal value As Integer)
            E_HO_CC = value
        End Set
    End Property
    Public Property Valor As Integer
        Get
            Return E_Valor
        End Get
        Set(ByVal value As Integer)
            E_Valor = value
        End Set
    End Property
    Public Property id_CF As Integer
        Get
            Return E_id_CF
        End Get
        Set(ByVal value As Integer)
            E_id_CF = value
        End Set
    End Property
    Public Property id_PER As Integer
        Get
            Return E_id_PER
        End Get
        Set(ByVal value As Integer)
            E_id_PER = value
        End Set
    End Property
End Class