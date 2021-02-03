Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Index_PROVEE
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

        For i = 1 To 15
            Dim Item As New E_GraficoVisor_Json
            Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_CANTIAD_ATENCIONES_DIARIOS_EXA_PROVEE_2_INDEX(fecha_1, fecha_1, ID_CF)

            If (Format(fecha_1, "dddd") = "domingo") Then
                i = i - 1
            Else
                If Data_Med.Count = 0 Then
                    Item.E_Fecha = fecha_1
                    Item.E_Cantidad = 0
                    Item.CANT_EXA = 0
                    Item.E_Dias = Format(fecha_1, "dddd")
                    date_json_rial.Add(Item)
                    i = i - 1

                Else
                    Item.E_Fecha = fecha_1
                    Item.E_Cantidad = Data_Med(0).TOTAL_ATE
                    Item.CANT_EXA = Data_Med(0).TOTAL_EXA
                    Item.E_Dias = Format(fecha_1, "dddd")
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

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_PROVEE(fechita_1, fechita_1, 0, 0, 0)
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

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_PROVEE(fechita_1, fechita_1, 0, 0, 0)
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

        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_PROVEE(fechita_1, fechita_1, 0, 0, 0)
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


        Dim str_Date = Format(Date.Now, "dd-MM-yyyy")
        str_Date = str_Date.Replace("-", "/")
        For h = 0 To 23
            str_Date = str_Date.Replace("-", "/")
            Dim dRef() As String = str_Date.Split("/")
            Dim Date_Out As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES(Date_Out, Date_Out)
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
End Class