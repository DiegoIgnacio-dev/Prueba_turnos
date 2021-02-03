Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Index_MINDS
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal Mes As String, ByVal Año As String, ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)

        Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)


        'For dd = 1 To days
        '    Dim Date_01 As Date = NN_Date.strToDate(Año, Mes, dd)
        '    Dim Item As New E_GraficoVisor_Json
        '    Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2_INDEX(Date_01, Date_01, ID_CF)
        '    If (Format(Date_01, "dddd") = "domingo") Then
        '    Else
        '        If Data_Med.Count = 0 Then
        '            Item.E_Fecha = Date_01
        '            Item.E_Cantidad = 0
        '            Item.CANT_EXA = 0
        '            Item.E_Dias = Format(Date_01, "dddd")
        '            date_json_rial.Add(Item)
        '        Else
        '            Item.E_Fecha = Date_01
        '            Item.E_Cantidad = Data_Med(0).TOTAL_ATE
        '            Item.CANT_EXA = Data_Med(0).TOTAL_EXA
        '            Item.E_Dias = Format(Date_01, "dddd")
        '            date_json_rial.Add(Item)
        '        End If
        '    End If

        'Next dd


        Dim fecha_1 As Date
        fecha_1 = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        For i = 1 To 15
            Dim Item As New E_GraficoVisor_Json
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_2_2(fecha_1, fecha_1, ID_CF, cookie_proc)

            If (Format(fecha_1, "dddd") = "domingo") Then
                i = i - 1
            Else
                If Data_Med.Count = 0 Then
                    Item.E_Fecha = fecha_1
                    Item.E_Cantidad = 0
                    Item.CANT_EXA = 0
                    Item.E_Dias = Format(fecha_1, "dddd")
                    Item.TOTA_SIS = 0
                    date_json_rial.Add(Item)
                    i = i - 1

                Else
                    Item.E_Fecha = fecha_1
                    Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                    Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                    Item.E_Dias = Format(fecha_1, "dddd")
                    Item.TOTA_SIS = Data_Med(0).TOTA_SIS
                    date_json_rial.Add(Item)

                End If
            End If
            fecha_1 = fecha_1.AddDays(-1)
        Next i


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
    Public Shared Function Bus_Cant() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_CANT As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
        Dim Data_CANT As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA)
        Data_CANT = NN_CANT.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA()
        If (Data_CANT.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_CANT, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
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
    Public Shared Function Bus_Exa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_EXA As New N_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS
        Dim Data_EXA As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS)
        Data_EXA = NN_EXA.IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS()
        If (Data_EXA.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_EXA, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Bus_Notif() As List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)


        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO(S_Id_User)
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Upd_Notif(ByVal ID_REL_N_U As Integer) As Integer

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO(ID_REL_N_U)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Dlt_Notif(ByVal ID_NOTIF As Integer) As Integer

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_DELETE_NOTIFICACION_USUARIO
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_DELETE_NOTIFICACION_USUARIO(ID_NOTIF)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Graph_2() As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)

        Dim fechita_1 As Date = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS(fechita_1, fechita_1, cookie_proc, 0, 0)
        If (Data_DTT.Count > 0) Then
            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Graph_3() As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)

        Dim fechita_1 As Date = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_MINDS(fechita_1, fechita_1, cookie_proc, 0, 0)
        If (Data_DTT.Count > 0) Then
            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Graph_4() As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)

        Dim fechita_1 As Date = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_MINDS(fechita_1, fechita_1, cookie_proc, 0, 0)
        If (Data_DTT.Count > 0) Then
            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Data_Graph_5() As List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES)
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        Dim str_Date = Format(Date.Now, "dd-MM-yyyy")
        str_Date = str_Date.Replace("-", "/")
        For h = 0 To 23
            str_Date = str_Date.Replace("-", "/")
            Dim dRef() As String = str_Date.Split("/")
            Dim Date_Out As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS(Date_Out, Date_Out, cookie_proc)
            Debug.WriteLine("Fecha: " & Format(Date_Out, "dd/MM/yyyy HH:mm:ss"))
            Debug.WriteLine("Valor: " & Format(Value, "###,###,##0.##"))
            Debug.WriteLine("")
            Dim E_Item As New E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES
            E_Item.FECHA = Date_Out
            E_Item.NUMERO = Value
            Data_Out.Add(E_Item)
        Next h
        Debug.WriteLine("Llenado Completado")
        If (Data_Out.Count > 0) Then
            Return Data_Out
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Data_Graph_6() As List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES) 'DINEROS
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES)
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        Dim str_Date = Format(Date.Now, "dd-MM-yyyy")
        str_Date = str_Date.Replace("-", "/")
        For h = 0 To 23
            str_Date = str_Date.Replace("-", "/")
            Dim dRef() As String = str_Date.Split("/")
            Dim Date_Out As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS(Date_Out, Date_Out, cookie_proc)
            Debug.WriteLine("Fecha: " & Format(Date_Out, "dd/MM/yyyy HH:mm:ss"))
            Debug.WriteLine("Valor: " & Format(Value, "###,###,##0.##"))
            Debug.WriteLine("")
            Dim E_Item As New E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES
            E_Item.FECHA = Date_Out
            E_Item.NUMERO = Value
            Data_Out.Add(E_Item)
        Next h
        Debug.WriteLine("Llenado Completado")
        If (Data_Out.Count > 0) Then
            Return Data_Out
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Dinero() As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim Data_Final As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)

        Dim fecha_1 As Date
        fecha_1 = Format(Date.Now, "dd-MM-yyyy")



        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)
        Dim cookie_prev = CType(objSession("USU_PREV"), Integer)


        For z = 0 To 2
            Dim item As New E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS_DINEROS_PREVE_GRAPH(fecha_1, cookie_proc)
            If Data_Med.Count > 0 Then
                'For i = 0 To Data_Med.Count - 1


                item.PREVE_DESC = Data_Med(0).PREVE_DESC
                item.TOTA_SIS = Data_Med(0).TOTA_SIS
                item.TOTAL_ATE = Data_Med(0).TOTAL_ATE
                item.TOTAL_EXA = Data_Med(0).TOTAL_EXA

                Data_Final.Add(item)
                'Next i
            Else
                item.PREVE_DESC = ""
                item.TOTA_SIS = 0
                item.TOTAL_ATE = 0
                item.TOTAL_EXA = 0

                Data_Final.Add(item)
            End If
            fecha_1 = DateAdd(DateInterval.Day, -1, fecha_1)
        Next z






        Return Data_Final

    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Area_Dinero() As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)

        Dim fecha_1 As Date
        fecha_1 = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)
        Dim cookie_prev = CType(objSession("USU_PREV"), Integer)

        Data_Med = NN_Med.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_MINDS_MONEY(fecha_1, cookie_proc)


        Return Data_Med

    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Medico() As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO)

        Dim fecha_1 As Date
        fecha_1 = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)
        Dim cookie_prev = CType(objSession("USU_PREV"), Integer)

        Data_Med = NN_Med.IRIS_WEBF_CMVM_BUSCA_LIS_ADM_RESU_MEDICO_MINDS_MONEY(fecha_1, cookie_proc)


        Return Data_Med

    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Info_Extra() As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)

        Dim ayer As Date
        Dim ayer_semana_pasada As Date
        Dim mes_dia As Date
        Dim mes_dia_pasado As Date
        Dim mes_pasado As Date
        Dim mes_ante_pasado As Date

        ayer = Format(Date.Now, "dd-MM-yyyy")
        ayer_semana_pasada = Format(Date.Now, "dd-MM-yyyy")
        mes_dia = Format(Date.Now, "dd-MM-yyyy")
        mes_dia_pasado = Format(Date.Now, "dd-MM-yyyy")
        mes_pasado = Format(Date.Now, "dd-MM-yyyy")
        mes_ante_pasado = Format(Date.Now, "dd-MM-yyyy")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        '----------------------------------------------- Ayer vs. mismo día de la semana pasada -------------------------------------------------
        ayer = ayer.AddDays(-1)
        ayer_semana_pasada = ayer_semana_pasada.AddDays(-8)
        '---------------------------------------------- FIN Ayer vs. mismo día de la semana pasada ----------------------------------------------

        '----------------------------------------------- Este mes vs. mismo día delmes pasado ----------------------------------------------------
        'mes_dia 
        mes_dia_pasado = mes_dia_pasado.AddMonths(-1)
        '---------------------------------------------- FIN Este mes vs. mismo día del mes pasado -----------------------------------------------

        '----------------------------------------------- El mes pasado vs. mes anterior --------------------------------------------------------
        Dim mes As String = Format(Date.Now, "MM")
        Dim ano As String = Format(Date.Now, "yyyy")

        'Dim Date_01 As Date = NN_Date.strToDate(ano, mes, 01)
        'Dim Date_02 As Date = NN_Date.strToDate(ano, mes, 01)

        mes_pasado = NN_Date.strToDate(ano, mes, 01)
        mes_ante_pasado = NN_Date.strToDate(ano, mes, 01)

        mes_pasado = mes_pasado.AddMonths(-1)
        mes_ante_pasado = mes_ante_pasado.AddMonths(-2)
        '---------------------------------------------- FIN El mes pasado vs. mes anterior -----------------------------------------------------
        Data_Med = NN_Med.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS_DINEROS_PREVE_GRAPH_INFO_MULTIPLE(ayer,
                                                                                                                        ayer_semana_pasada,
                                                                                                                        mes_dia,
                                                                                                                        mes_dia_pasado,
                                                                                                                        mes_pasado,
                                                                                                                        mes_ante_pasado,
                                                                                                                        cookie_proc)

        Return Data_Med

        'If (date_json_rial.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(date_json_rial, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
    End Function
    <Services.WebMethod()>
    Public Shared Function row_1() As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim Data_In As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        Dim ayer As Date
        Dim ayer_semana_pasada As Date

        ayer = Format(Date.Now, "dd-MM-yyyy")
        ayer_semana_pasada = Format(Date.Now, "dd-MM-yyyy")

        ayer = ayer.AddDays(-1)
        ayer_semana_pasada = ayer_semana_pasada.AddDays(-8)

        Dim str_Date_AYER = CStr(ayer) 'Format(Date.Now, "dd-MM-yyyy")
        Dim str_Date_AYER_SEMANA_PASADA = CStr(ayer_semana_pasada) 'Format(Date.Now, "dd-MM-yyyy")
        str_Date_AYER = str_Date_AYER.Replace("-", "/")
        str_Date_AYER_SEMANA_PASADA = str_Date_AYER_SEMANA_PASADA.Replace("-", "/")
        For h = 0 To 23
            str_Date_AYER = str_Date_AYER.Replace("-", "/")
            str_Date_AYER_SEMANA_PASADA = str_Date_AYER_SEMANA_PASADA.Replace("-", "/")
            Dim dRef_AYER() As String = str_Date_AYER.Split("/")
            Dim dRef_AYER_SEMANA_PASADA() As String = str_Date_AYER_SEMANA_PASADA.Split("/")
            Dim Date_Out_AYER As Date = NN_Date.strToDate(dRef_AYER(2), dRef_AYER(1), dRef_AYER(0), h)
            Dim Date_Out_AYER_SEMANA_PASADA As Date = NN_Date.strToDate(dRef_AYER_SEMANA_PASADA(2), dRef_AYER_SEMANA_PASADA(1), dRef_AYER_SEMANA_PASADA(0), h)
            Dim Value As Long = 0
            Data_In = NN_Search.IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS_AYER_AYER_SEMANA_PASADA(Date_Out_AYER, Date_Out_AYER,
                                                                                                        Date_Out_AYER_SEMANA_PASADA, Date_Out_AYER_SEMANA_PASADA,
                                                                                                        cookie_proc)

            Dim E_Item As New E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS
            E_Item.FECHA = Date_Out_AYER
            E_Item.AYER = Data_In(0).AYER
            E_Item.AYER_SEMANA_PASADA = Data_In(0).AYER_SEMANA_PASADA
            Data_Out.Add(E_Item)
        Next h
        Debug.WriteLine("Llenado Completado")
        If (Data_Out.Count > 0) Then
            Return Data_Out
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Row_2() As List(Of E_GraficoVisor_Json)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)

        'Dim days As Integer = System.DateTime.DaysInMonth(Año, Mes)

        Dim fecha_1 As Date
        fecha_1 = Format(Date.Now, "dd-MM-yyyy")

        Dim fecha_2 As Date
        fecha_2 = Format(Date.Now, "dd-MM-yyyy")
        fecha_2 = fecha_2.AddMonths(-1)

        Dim fecha_dia_final As Integer


        Dim fecha_dia As String = Format(Date.Now, "dd")
        fecha_dia_final = CStr(fecha_dia)

        fecha_dia_final = CInt(fecha_dia_final)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        For i = 1 To fecha_dia_final
            Dim Item As New E_GraficoVisor_Json
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_ESTE_MES_VS_MISMO_DIA_MES_ANTERIOR(fecha_1,
                                                                                                                                        fecha_2,
                                                                                                                                        0,
                                                                                                                                        cookie_proc)
            'If (Format(fecha_1, "dddd") = "domingo") Then
            '    i = i - 1
            'Else
            '    If Data_Med.Count = 0 Then
            '        Item.E_Fecha = fecha_1
            '        Item.E_Cantidad = 0
            '        Item.CANT_EXA = 0
            '        Item.E_Dias = Format(fecha_1, "dddd")
            '        date_json_rial.Add(Item)
            '        i = i - 1

            '    Else
            Item.E_Fecha = fecha_1
            Item.ESTE_MES = Data_Med(0).ESTE_MES
            Item.ESTE_DIA_MES_PASADO = Data_Med(0).ESTE_DIA_MES_PASADO
            Item.E_Dias = Format(fecha_1, "dddd")
            date_json_rial.Add(Item)

            'End If
            'End If
            fecha_1 = fecha_1.AddDays(-1)
            fecha_2 = fecha_2.AddDays(-1)
        Next i

        Return date_json_rial
    End Function

    <Services.WebMethod()>
    Public Shared Function Row_3() As List(Of E_GraficoVisor_Json)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoVisor
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)

        Dim mes As String = Format(Date.Now, "MM")
        Dim ano As String = Format(Date.Now, "yyyy")

        Dim days As Integer = System.DateTime.DaysInMonth(ano, mes)

        Dim fecha_1 As Date
        fecha_1 = Format(Date.Now, "dd-MM-yyyy")
        fecha_1 = fecha_1.AddMonths(-1)

        Dim mes_1 As String = Format(fecha_1, "MM")

        Dim fecha_2 As Date
        fecha_2 = Format(Date.Now, "dd-MM-yyyy")
        fecha_2 = fecha_2.AddMonths(-2)

        Dim mes_2 As String = Format(fecha_2, "MM")

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim cookie_proc = CType(objSession("USU_ID_PROC"), Integer)

        For dd = 1 To days
            Dim Date_01 As Date = NN_Date.strToDate(ano, mes_1, dd)
            Dim Date_02 As Date = NN_Date.strToDate(ano, mes_2, dd)
            Dim Item As New E_GraficoVisor_Json
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_MINDS_2_INDEX_MINDS_ESTE_MES_VS_MISMO_DIA_MES_ANTERIOR(Date_01,
                                                                                                                                        Date_02,
                                                                                                                                        0,
                                                                                                                                        cookie_proc)

            Item.E_Fecha = Date_01
            Item.Fecha_2 = Date_02
            Item.ESTE_MES = Data_Med(0).ESTE_MES
            Item.ESTE_DIA_MES_PASADO = Data_Med(0).ESTE_DIA_MES_PASADO
            Item.E_Dias = Format(Date_01, "dddd")
            Item.Dias_2 = Format(Date_02, "dddd")
            date_json_rial.Add(Item)

            'End If
            'End If
            fecha_1 = fecha_1.AddDays(1)
            fecha_2 = fecha_2.AddDays(1)
        Next dd

        Return date_json_rial
    End Function
End Class