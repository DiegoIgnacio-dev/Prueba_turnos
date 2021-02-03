﻿Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Pac_TDM_COPIA
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        'Select Case (C_P_ADMIN.Value)
        '    Case 2
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub

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
    Public Shared Function Llenar_PAC(ByVal ID As String, ByVal fecha As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX

        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_COPIA)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim numero As Integer = 0
        Dim N_N As N_IRIS_OBTENER_INFO = New N_IRIS_OBTENER_INFO

        Dim update_estado_omi As Integer

        data_pac = NN_pac.IRIS_WEBF_CMVM_PROGRAMA_PENDIENTES_PENALOLEN_OMI(ID, fecha)

        If data_pac.Count > 0 Then

            For i = 0 To data_pac.Count - 1
                data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_ATE_ESTADO_4_COPIA(data_pac(i).ID_ATENCION)

                If data_examen.Count > 0 Then
                    For xxx = 0 To data_examen.Count - 1

                        If (data_examen(xxx).ATE_NUM_OMI <> "" Or data_examen(xxx).ATE_NUM_OMI <> "0") And data_examen(xxx).ATE_CODIGO_TEST <> "" Then

                            numero = N_N.UPDATE_ESTADO_TEST_NULL(data_examen(xxx).ATE_NUM_OMI, data_examen(xxx).ATE_CODIGO_TEST)

                            update_estado_omi = NN_Examen.IRIS_WEBF_CMVM_UPDATE_ID_ESTADO_REV_OMI(data_examen(xxx).ID_DET_PREI)

                            If (data_examen(xxx).ATE_CF_MULTIPLICADOS <> "") Then

                                update_estado_omi = NN_Examen.IRIS_WEBF_CMVM_UPDATE_ID_ESTADO_REV_OMI(data_examen(xxx).ID_DET_PREI)

                                Dim regex As New Regex("[0-9]+", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
                                Dim match9000 As MatchCollection
                                Dim list_Num As New List(Of String)

                                match9000 = regex.Matches(data_examen(xxx).ATE_CF_MULTIPLICADOS)
                                For y = 0 To (match9000.Count - 1)
                                    If (match9000(y).Success = True) Then
                                        numero = N_N.UPDATE_ESTADO_TEST_NULL(match9000(y).Value, data_examen(xxx).ATE_CODIGO_TEST)
                                    End If
                                Next y
                            End If
                        End If
                    Next xxx
                End If
            Next i

        End If
        Return data_pac
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String, ByVal ID_ATE As String) As REEE_COPIA
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_COPIA)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(ID)


        'IFIFIF'
        If (ID_ATE = 0) Then
            'data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(ID)
        Else
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_ATE_ESTADO_4_COPIA(ID_ATE)
        End If

        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(ID)
        Dim reeeeeee As New REEE_COPIA
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_Actualizar(ByVal ID_ate As String,
                                        ByVal id_pre As String,
                                        ByVal obs_TDM As String,
                                        ByVal obs As String,
                                        ByVal interno As String) As String





        '-------------------------------__________________----------------------------




        '-------------------------------__________________----------------------------

        ''Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        'Dim str_Builder As New StringBuilder
        'Dim datas As String = ""
        'Dim DATASSSSSS As Integer
        'Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        'Dim Str_Out As String = ""
        'Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        'Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        'Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        'Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        'Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        'Dim correlativo2 As Integer
        'Dim id_atencion As Integer
        ''update despues de pago
        'If (ID_ate = 0) Then
        '    DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_pre, interno, obs, obs_TDM)
        'Else
        '    DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_ATENCION(ID_ate, interno, obs_TDM, obs)
        '    DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_pre, interno, obs_TDM, obs)
        'End If

        'If DATASSSSSS > 0 Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(DATASSSSSS, str_Builder)
        '    datas = str_Builder.ToString
        'Else
        '    datas = "null"
        'End If
        'Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_update(ByVal ID_ate As String,
                                        ByVal id_pre As String,
                                        ByVal obs_TDM As String,
                                        ByVal obs As String,
                                        ByVal interno As String) As List(Of E_IRIS_WEBF_correlativos_COPIA)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim DATASSSSSS As Integer
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim Str_Out As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        Dim correlativo2 As Integer
        Dim id_atencion As Integer
        Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
        Dim id As Integer
        Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
        Dim resu As Integer
        Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
        Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(id_pre)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(id_pre)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(id_pre)
        correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()


        id_atencion = ddx.IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS(correlativo2,
                                                                          data_pac(0).ID_PACIENTE,
                                                                          CInt(S_Id_User),
                                                                          data_pac(0).PREI_FUR,
                                                                          data_atencion(0).ID_PROCEDENCIA,
                                                                          data_atencion(0).ID_ORDEN,
                                                                          data_atencion(0).ID_TP_PACI,
                                                                          data_atencion(0).ID_DOCTOR,
                                                                          data_atencion(0).ID_PREVE,
                                                                          data_atencion(0).ID_LOCAL,
                                                                          1,
                                                                          data_atencion(0).PREI_OBS_FICHA,
                                                                          data_atencion(0).PREI_CAMA,
                                                                          data_pac(0).PREI_AÑO,
                                                                          data_pac(0).PREI_MES,
                                                                          data_pac(0).PREI_DIA,
                                                                          data_examen(0).PREI_DET_V_PAGADO,
                                                                          data_examen(0).PREI_DET_V_PREVI,
                                                                          data_examen(0).PREI_DET_V_COPAGO,
                                                                          data_atencion(0).ID_PROGRAMA,
                                                                          "",
                                                                         data_atencion(0).ID_SECTOR,
                                                                         correlativo2,
                                                                         interno,
                                                                         data_atencion(0).ID_DIAGNOSTICO, data_atencion(0).ID_DIAGNOSTICO2, data_atencion(0).VIH, data_pac(0).DNI, obs_TDM, 1)

        For i = 0 To data_examen.Count - 1
            id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(id_atencion,
                                                                   CInt(S_Id_User),
                                                                   data_examen(i).ID_CODIGO_FONASA,
                                                                   data_examen(i).ID_PER,
                                                                   data_examen(i).ID_TP_PAGO,
                                                                   data_examen(i).PREI_DET_DOC,
                                                                   data_examen(i).PREI_DET_V_PREVI,
                                                                   data_examen(i).PREI_DET_V_PAGADO,
                                                                   data_examen(i).PREI_DET_V_COPAGO,
                                                                   data_examen(i).ATE_NUM_AVIS)

            PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(data_examen(i).ID_PER)
            For x = 0 To PERFIL_PRUEBA.Count - 1
                If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                Else
                    If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                    Else
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                    End If
                End If
            Next x
        Next i
        '----------------- Auto PAGO Datos ---------------------------
        Dim qq As New N_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
        Dim update1 As Integer
        '----------------------------------------------------------
        Dim ww As New N_IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP
        Dim update2 As Integer
        '-----------------------------------------------------------
        Dim ee As New N_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES
        Dim buscarFormaPAgo As List(Of E_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES)
        '-----------------------------------------------------------------
        Dim rr As New N_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION
        Dim buscarAteDOC As List(Of E_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION)
        '---------------------------------------------------------------------------------
        Dim correlativo_tp_pago As Integer
        Dim bb As New N_IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO
        Dim qwerty As Integer
        Dim xcv As New N_IRIS_WEBF_GRABA_TRX_BONOS
        Dim qwe As Integer
        Dim uuuu As New N_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
        correlativo_tp_pago = bb.IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO()
        update1 = qq.IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago, 1)
        update2 = ww.IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago)

        Dim graba_ate As Integer
        Dim tt As New N_IRIS_GRABA_ATE_DOCUMENTO_PAGO
        graba_ate = tt.IRIS_GRABA_ATE_DOCUMENTO_PAGO(id_atencion, correlativo_tp_pago, CInt(S_Id_User))
        buscarFormaPAgo = ee.IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES(id_atencion)
        If (buscarFormaPAgo.Count > 0) Then
            If (buscarFormaPAgo(0).ID_TP_PAGO = 4 Or buscarFormaPAgo(0).ID_TP_PAGO = 5) Then
                qwerty = xcv.IRIS_WEBF_GRABA_TRX_BONOS(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
            ElseIf (buscarFormaPAgo(0).ID_TP_PAGO = 1 Or buscarFormaPAgo(0).ID_TP_PAGO = 3 Or buscarFormaPAgo(0).ID_TP_PAGO = 7 Or buscarFormaPAgo(0).ID_TP_PAGO = 11) Then
                qwerty = xcv.IRIS_WEBF_GRABA_TRX_EFECTIVO(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
            End If
        End If
        If (qwerty = 0) Then
            qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User), 0)
        Else
            qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, qwerty, CInt(S_Id_User), 0)
        End If
        Dim ahg As Integer
        Dim uu As New N_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
        'update despues de pago
        DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_ATENCION(id_atencion, interno, obs_TDM, obs)
        DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_pre, interno, obs_TDM, obs)
        ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(id_pre, id_atencion)
        Dim item As New E_IRIS_WEBF_correlativos_COPIA
        Dim enviar As New List(Of E_IRIS_WEBF_correlativos_COPIA)
        item.ID_ATENCION = id_atencion
        item.Correlativo = correlativo2
        enviar.Add(item)
        Return enviar
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String,
                                          ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim Data As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim NN As New N_PROCEDENCIAS_Y_CANT_MAX

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim Mx_Data(5, 0) As Object
        Data = NN.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ID_CF, DESDE)
        If (Data.Count > 0) Then
            Dim Mx_Datac(6, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(6, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(6, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = Data(y).PAC_NOMBRE + " " + Data(y).PAC_APELLIDO
                Mx_Data(2, y) = Data(y).PAC_RUT
                Mx_Data(3, y) = Data(y).PREI_NUM
                Mx_Data(4, y) = Data(y).PROC_DESC
                Mx_Data(5, y) = CInt(Data(y).CANT_EXAM)
                Mx_Data(6, y) = Data(y).EST_DESCRIPCION
            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de pacientes")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de pacientes")
        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y
        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "Nombre Paciente")
        sl.SetCellValue("C8", "Rut")
        sl.SetCellValue("D8", "N° Atención")
        sl.SetColumnWidth("D", 40)
        sl.SetCellValue("E8", "Procedencia")
        sl.SetCellValue("F8", "Cant. Exámenes")
        sl.SetCellValue("G8", "Estado")

        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 8
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True
        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("G" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal ID As String, ByVal fecha As String) As String

        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ID, fecha)
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim Mx_Data(7, 0) As Object
        If (data_pac.Count > 0) Then
            Dim Mx_Datac(7, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(7, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (data_pac.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(7, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = data_pac(y).PAC_NOMBRE + " " + data_pac(y).PAC_APELLIDO
                If (data_pac(y).PAC_RUT = "") Then
                    Mx_Data(2, y) = data_pac(y).DNI
                Else
                    Mx_Data(2, y) = data_pac(y).PAC_RUT
                End If
                Mx_Data(3, y) = data_pac(y).PREI_NUM
                Mx_Data(4, y) = data_pac(y).ATE_NUM
                Mx_Data(5, y) = data_pac(y).PROC_DESC
                Mx_Data(6, y) = data_pac(y).CANT_EXAM
                Mx_Data(7, y) = data_pac(y).EST_DESCRIPCION
            Next y
        Else
            Return Nothing
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Pacientes")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Pacientes")
        sl.SetCellValue("B3", fecha)
        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "Nombre Paciente")
        sl.SetColumnWidth("B", 40)
        sl.SetCellValue("C8", "Rut o DNI")
        sl.SetColumnWidth("C", 20)
        sl.SetCellValue("D8", "N° Pre Ingreso")
        sl.SetColumnWidth("D", 10)
        sl.SetCellValue("E8", "N° Atención")
        sl.SetColumnWidth("E", 10)
        sl.SetCellValue("F8", "Procedencia")
        sl.SetColumnWidth("F", 20)
        sl.SetCellValue("G8", "Cant. Exámenes")
        sl.SetColumnWidth("G", 10)
        sl.SetCellValue("H8", "Estado")
        sl.SetColumnWidth("H", 20)


        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 8
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True
        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class
Public Class REEE_COPIA
    Dim arr1 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
    Dim arr2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_COPIA)
    Dim arr3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
    Public Property proparra3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Get
            Return arr3
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION))
            arr3 = value
        End Set
    End Property
    Public Property proparra1 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Get
            Return arr1
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2))
            arr1 = value
        End Set
    End Property
    Public Property proparra2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_COPIA)
        Get
            Return arr2
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_COPIA))
            arr2 = value
        End Set
    End Property
End Class
Public Class E_IRIS_WEBF_correlativos_COPIA
    Dim EE_ID_ATENCION As Integer
    Dim EE_Correlativo As Integer
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property Correlativo As Integer
        Get
            Return EE_Correlativo
        End Get
        Set(value As Integer)
            EE_Correlativo = value
        End Set
    End Property
    'Lol
End Class