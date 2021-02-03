Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Ingreso_Ate_Caja4_Bol_2
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
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
    Public Shared Function Llenar_tabla_exam2_particular(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_particular As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN_particular As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION

        Dim ANO As Date
        ANO = CDate(Fecha)

        data_particular = NN_particular.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_PARTICULAR_BONIFICACION(Format(ANO, "yyyy"), 69)

        If (data_particular.Count > 0) Then

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_particular, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
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
    Public Shared Function Llenar_tabla_exam2(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_BONIFICACION(Format(ANO, "yyyy"), ID_PREVE)
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
    Public Shared Function Llenar_tabla_exam2_ID_CF(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal ID_CF As Integer, ByVal ID_CF_REAL As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_BONIFICACION_ID_CODIGO_FONASA(Format(ANO, "yyyy"), ID_PREVE, ID_CF, ID_CF_REAL)
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
    Public Shared Function Llenar_tabla_exam_pack(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK_2_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
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
    Public Shared Function tipo_pago() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Dim NN As N_Gen_Activos = New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function Request_Prevision(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE_2_AND_PART_WEB(ID_PROC)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_Programa(ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        Dim NN As New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_SubPrograma(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_Async_SubP)
        Dim NN_Activo As New N_Gen_Activos

        Return NN_Activo.Request_SubPrograma(ID_PREV, ID_PROG)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String) As REEE


        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_NEW(ID)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_2_NEW(ID)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_NEW(ID)
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal fecha As String, ByVal id As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        data_procedencia = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX(Date.Now, id)
        If data_procedencia.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_procedencia, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    '<Services.WebMethod()>
    'Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
    '                                         ByVal NOMBRE_PAC As String,
    '                                         ByVal APE_PAC As String,
    '                                         ByVal FNAC_PAC As String,
    '                                         ByVal ID_SEXO As Integer,
    '                                         ByVal ID_NACIONALIDAD As Integer,
    '                                         ByVal FONO1 As String,
    '                                         ByVal MOVIL1 As String,
    '                                         ByVal ID_CIU_COM As Integer,
    '                                         ByVal DIR_PAC As String,
    '                                         ByVal EMAIL_PAC As String,
    '                                         ByVal FUR As String,
    '                                         ByVal Paridad As String,
    '                                         ByVal ID_PAC As String,
    '                                         ByVal OB As String,
    '                                         ByVal Procedencia As Integer,
    '                                         ByVal Programa As Integer,
    '                                         ByVal Sector As Integer,
    '                                         ByVal TipoAtencion As Integer,
    '                                         ByVal PrioridadTM As Integer,
    '                                         ByVal Doctor As Integer,
    '                                         ByVal Prevision As Integer,
    '                                         ByVal EDAD As Integer,
    '                                         ByVal MES As Integer,
    '                                         ByVal DIA As Integer,
    '                                         ByVal TOTAL As Integer,
    '                                         ByVal FECHA_PRE As String,
    '                                         ByVal ids As List(Of ids2_caja),
    '                                         ByVal ate_obs As String,
    '                                         ByVal Interno As String,
    '                                         ByVal id_Diag As String,
    '                                         ByVal id_Diag2 As String,
    '                                         ByVal sub_atencion As String,
    '                                         ByVal vih As String,
    '                                         ByVal dni As String,
    '                                        ByVal ATE_V_SISTEMA As String,                 'PARÁMETROS  CAJA
    '                                        ByVal ATE_V_BENEF As String,
    '                                        ByVal ATE_V_CF As String,
    '                                        ByVal ATE_V_CF_FP As String,
    '                                        ByVal ATE_V_CP As String,
    '                                        ByVal ATE_V_CP_FP As String,
    '                                        ByVal ATE_V_BOLETA As String,
    '                                        ByVal ATE_V_PAGADO As String) As String

    '    Dim ATE_V_SISTEMA_2 As Integer = ATE_V_SISTEMA.ToString().Replace(".", "")
    '    Dim ATE_V_BENEF_2 As Integer = ATE_V_BENEF.ToString().Replace(".", "")
    '    Dim ATE_V_CF_2 As Integer = ATE_V_CF.ToString().Replace(".", "")
    '    Dim ATE_V_CF_FP_2 As Integer = ATE_V_CF_FP.ToString().Replace(".", "")
    '    Dim ATE_V_CP_2 As Integer = ATE_V_CP.ToString().Replace(".", "")
    '    Dim ATE_V_CP_FP_2 As Integer = ATE_V_CP_FP.ToString().Replace(".", "")
    '    Dim ATE_V_BOLETA_2 As Integer = ATE_V_BOLETA.ToString().Replace(".", "")
    '    Dim ATE_V_PAGADO_2 As Integer = ATE_V_PAGADO.ToString().Replace(".", "")

    '    Return "TEST"
    'End Function
    Public Shared Function TEST_GUARDAR() As Integer
        Return Nothing
    End Function

    <Services.WebMethod()>
    Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
                                            ByVal NOMBRE_PAC As String,
                                            ByVal APE_PAC As String,
                                            ByVal FNAC_PAC As String,
                                            ByVal ID_SEXO As Integer,
                                            ByVal ID_NACIONALIDAD As Integer,
                                            ByVal FONO1 As String,
                                            ByVal MOVIL1 As String,
                                            ByVal ID_CIU_COM As Integer,
                                            ByVal DIR_PAC As String,
                                            ByVal EMAIL_PAC As String,
                                            ByVal FUR As String,
                                            ByVal Paridad As String,
                                            ByVal ID_PAC As String,
                                            ByVal OB As String,
                                            ByVal Procedencia As Integer,
                                            ByVal Programa As Integer,
                                            ByVal Sector As Integer,
                                            ByVal TipoAtencion As Integer,
                                            ByVal PrioridadTM As Integer,
                                            ByVal Doctor As Integer,
                                            ByVal Prevision As Integer,
                                            ByVal EDAD As Integer,
                                            ByVal MES As Integer,
                                            ByVal DIA As Integer,
                                            ByVal TOTAL As Integer,
                                            ByVal FECHA_PRE As String,
                                            ByVal ids As List(Of ids2_caja),
                                            ByVal ate_obs As String,
                                            ByVal Interno As String,
                                            ByVal id_Diag As String,
                                            ByVal id_Diag2 As String,
                                            ByVal sub_atencion As String,
                                            ByVal vih As String,
                                            ByVal dni As String,
                                            ByVal ATE_V_SISTEMA As String, 'PARÁMETROS  CAJA    '1  VALOR PREVISIION
                                            ByVal ATE_V_BENEF As String,                        '2  VALOR BENEFICIARIO +  SEGURO COMPLEMENATRIO
                                            ByVal ATE_V_CF As String,                           '3  TOTAL FONASA
                                            ByVal ATE_V_CF_FP As String,                        '4  TIPO DE PAGO FONASA
                                            ByVal ATE_V_CP As String,                           '5  VALOR PARTICULAR
                                            ByVal ATE_V_CP_FP As String,                        '6  TIPO DE PAGO PARTICULAR
                                            ByVal ATE_V_BOLETA As String,                       '7  NUMERO DE BOLETA
                                            ByVal ATE_V_PAGADO As String,                       '8  TOTAL SUPREMO
                                            ByVal ATE_V_SEG_COMP As String,                     '9  SEGURO COMPLEMENTARIO
                                             ByVal ATE_TP_COPAGO_1 As String,                   '10 TIPO COPAGO 1
                                             ByVal ATE_VALOR_COPAGO_1 As String,                '11 VALOR COPAGO 1
                                             ByVal ATE_TP_COPAGO_2 As String,                   '12 TIPO COPAGO 2
                                             ByVal ATE_VALOR_COPAGO_2 As String,                '13 VALOR COPAGO 2
                                             ByVal ATE_TP_PARTICULAR_1 As String,               '14 TIPO PARTICULAR 1
                                             ByVal ATE_VALOR_PARTICULAR_1 As String,            '15 VALOR PARTICULAR
                                             ByVal ATE_TP_PARTICULAR_2 As String,               '16 TIPO PARTICULAR 2 
                                             ByVal ATE_VALOR_PARTICULAR_2 As String,             '17 VALOR PARTICULAR 2
                                             ByVal ATE_V_SC As String,
                                             ByVal S_Id_User As Integer                         'NUEVO ID_USUARIO
                                             ) As String
        Dim ATE_V_SISTEMA_2 As String
        Dim ATE_V_BENEF_2 As String
        Dim ATE_V_CF_2 As String
        Dim ATE_V_CF_FP_2 As String
        Dim ATE_V_CP_2 As String
        Dim ATE_V_CP_FP_2 As String
        Dim ATE_V_BOLETA_2 As String
        Dim ATE_V_PAGADO_2 As String
        Dim ATE_V_SEG_COMP_2 As String

        Dim ATE_V_SC_2 As String
        If (ATE_V_SC <> "") Then
            ATE_V_SC_2 = ATE_V_SC.ToString().Replace(".", "")
        Else
            ATE_V_SC_2 = 0
        End If


        Dim ATE_VALOR_PARTICULAR_1_2 As String
        Dim ATE_VALOR_PARTICULAR_2_2 As String

        If ATE_VALOR_PARTICULAR_2 <> "" Then
            ATE_VALOR_PARTICULAR_2_2 = ATE_VALOR_PARTICULAR_2.ToString().Replace(".", "")
        Else
            ATE_VALOR_PARTICULAR_2_2 = 0
        End If

        If ATE_VALOR_PARTICULAR_1 <> "" Then
            ATE_VALOR_PARTICULAR_1_2 = ATE_VALOR_PARTICULAR_1.ToString().Replace(".", "")
        Else
            ATE_VALOR_PARTICULAR_1_2 = 0
        End If

        If ATE_V_SISTEMA <> "" Then
            ATE_V_SISTEMA_2 = ATE_V_SISTEMA.ToString().Replace(".", "")
        Else
            ATE_V_SISTEMA_2 = 0
        End If

        If ATE_V_BENEF <> "" Then
            ATE_V_BENEF_2 = ATE_V_BENEF.ToString().Replace(".", "")
        Else
            ATE_V_BENEF_2 = 0
        End If

        If ATE_V_CF <> "" Then
            ATE_V_CF_2 = ATE_V_CF.ToString().Replace(".", "")
        Else
            ATE_V_CF_2 = 0
        End If

        If ATE_V_CF_FP <> "" Then
            ATE_V_CF_FP_2 = ATE_V_CF_FP.ToString().Replace(".", "")
        Else
            ATE_V_CF_FP_2 = 0
        End If

        If ATE_V_CP <> "" Then
            ATE_V_CP_2 = ATE_V_CP.ToString().Replace(".", "")
        Else
            ATE_V_CP_2 = 0
        End If

        If ATE_V_CP_FP <> "" Then
            ATE_V_CP_FP_2 = ATE_V_CP_FP.ToString().Replace(".", "")
        Else
            ATE_V_CP_FP_2 = 0
        End If

        If ATE_V_BOLETA <> "" Then
            ATE_V_BOLETA_2 = ATE_V_BOLETA.ToString().Replace(".", "")
        Else
            ATE_V_BOLETA_2 = 0
        End If

        If ATE_V_PAGADO <> "" Then
            ATE_V_PAGADO_2 = ATE_V_PAGADO.ToString().Replace(".", "")
        Else
            ATE_V_PAGADO_2 = 0
        End If

        If ATE_V_SEG_COMP <> "" Then
            ATE_V_SEG_COMP_2 = ATE_V_SEG_COMP.ToString().Replace(".", "")
        Else
            ATE_V_SEG_COMP_2 = 0
        End If



        'Checar Galletas
        If (Test_C.emptyCookies = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx", False)
            Return Nothing
        End If

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim correlativo As Integer

        'paciente
        Dim Rpaciente As Integer
        Dim examun As Integer
        Dim Str_Out As String = ""
        Dim DATASSSSSS As Integer
        ' Dim PREINGRESO2 As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        'Dim AIDIIIII_ADMINNNNNNN As HttpCookie = Request.Cookies.Get("ID_USER")
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim nn As N_IRIS_WEBF_GRABA_PACIENTE_ATENCION = New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION = New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As N_IRIS_WEBF_GRABA_PREINGRESO2 = New N_IRIS_WEBF_GRABA_PREINGRESO2
        Dim cc As N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC = New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO = New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else
            'regitrar paciente o actualizar
            If (Paridad = 2) Then
                Rpaciente = nn.IRIS_WEBF_GRABA_PACIENTE_ATENCION(RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, dni)
            Else
                Rpaciente = vv.IRIS_WEBF_UPDATE_PACIENTE_ATENCION(ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1)
            End If



            'ir a buscar correlativo
            correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
            If (Paridad = 2) Then
                'PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(correlativo, Rpaciente, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, ate_obs.ToUpper, 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, sub_atencion, vih, dni)
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW_CAJA(correlativo,
                                                              Rpaciente,
                                                              CInt(S_Id_User),
                                                              FUR,
                                                              Procedencia,
                                                              PrioridadTM,
                                                              TipoAtencion,
                                                              Doctor,
                                                              Prevision,
                                                              1,
                                                              1,
                                                              ("N° Orden Clínica: " & ids(0).Clinico),
                                                              0,
                                                              EDAD,
                                                              MES,
                                                              DIA,
                                                              TOTAL,
                                                              0,
                                                              0,
                                                              FECHA_PRE,
                                                              Programa,
                                                              Sector, ids(0).Clinico, 0, 0, sub_atencion, vih
                                                             )
            Else

                'PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(correlativo, ID_PAC, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, ate_obs.ToUpper, 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, sub_atencion, vih, dni)
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW_CAJA(correlativo,
                                              ID_PAC,
                                              CInt(S_Id_User),
                                              FUR,
                                              Procedencia,
                                              PrioridadTM,
                                              TipoAtencion,
                                              Doctor,
                                              Prevision,
                                              1,
                                              1,
                                              ("N° Orden Clínica: " & ids(0).Clinico),
                                              0,
                                              EDAD,
                                              MES,
                                              DIA,
                                              TOTAL,
                                              0,
                                              0,
                                              FECHA_PRE,
                                              Programa,
                                              Sector, ids(0).Clinico, 0, 0, sub_atencion, vih)
            End If
            Dim data_examen2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Dim NN_Examen2 As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

            Dim NN_Date As New N_Date
            Dim fecha As String = FECHA_PRE.Replace("/", "-")
            Dim DIA1 As String = fecha.Split("-")(0)
            Dim MES2 As String = fecha.Split("-")(1)
            Dim AÑO3 As String = fecha.Split("-")(2)
            Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
            Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)


            data_examen2 = NN_Examen2.IRIS_WEBF_BUSCA_EXAMEN(Date_02, Date_01, RUT_PAC)


            For i = 0 To ids.Count - 1
                examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, ids(i).Clinico)
            Next i





            Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
            Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
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
            Dim dual_copago As Integer

            Dim data_atencion_tp As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
            Dim NN_atencion_tp As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION

            'IRIS_GRABA_ATENCION_PROGRA2_2

            data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(PREINGRESO2_PRO_SEC)
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(PREINGRESO2_PRO_SEC)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(PREINGRESO2_PRO_SEC)
            correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
            id_atencion = ddx.IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC(correlativo2,
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
                                                                          ids(0).Clinico,
                                                                          Interno,
                                                                          data_atencion(0).ID_DIAGNOSTICO,
                                                                          data_atencion(0).ID_DIAGNOSTICO2,
                                                                          data_atencion(0).VIH,
                                                                          data_pac(0).DNI,
                                                                          OB,
                                                                          ATE_V_SISTEMA_2,                '1
                                                                          ATE_V_BENEF_2,                  '2
                                                                          ATE_V_CF_2,                     '3
                                                                          ATE_V_CF_FP_2,                  '4
                                                                          ATE_V_CP_2,                     '5
                                                                          ATE_V_CP_FP_2,                  '6
                                                                          ATE_V_BOLETA_2,                 '7
                                                                          ATE_V_PAGADO_2,                 '8
                                                                        ATE_V_SEG_COMP_2,                 '9
                                                                        ATE_V_SC_2)                       'SC EN ATENCION

            '--------------------------- DUAL COPAGO ---------------------------
            dual_copago = ddx.IRIS_WEBF_CMVM_GRABA_REL_COPAGO(id_atencion,
                                                              CInt(S_Id_User),
                                                              Date.Now,
                                                              ATE_TP_COPAGO_1,
                                                              ATE_VALOR_COPAGO_1,
                                                              ATE_TP_COPAGO_2,
                                                              ATE_VALOR_COPAGO_2,
                                                              ATE_V_CP_FP_2,
                                                              ATE_V_CP_2,
                                                              ATE_TP_PARTICULAR_1,
                                                              ATE_VALOR_PARTICULAR_1_2,
                                                              ATE_TP_PARTICULAR_2,
                                                              ATE_VALOR_PARTICULAR_2_2)




            '---------------------FIN DUAL COPAGO ------------------------------

            For i = 0 To ids.Count - 1
                Dim toti_copago As Integer = 0
                Dim toti_pagado As Integer = 0
                Dim descccc As Integer = 0

                descccc = ids(i).ATE_DET_VALOR_CS + ids(i).ATE_DET_VALOR_BENEF

                If (ids(i).CF_TP_PAGO = 1 Or ids(i).CF_TP_PAGO = 20 Or ids(i).CF_TP_PAGO = 4) Then
                    toti_copago = 0 'ids(i).ATE_DET_VALOR_CS + ids(i).ATE_DET_VALOR_BENEF
                    'toti_pagado = ids(i).Valor '- toti_copago
                    toti_pagado = ids(i).Valor - descccc '- toti_copago
                Else
                    toti_copago = ids(i).Valor - descccc 'ids(i).ATE_DET_VALOR_CS + ids(i).ATE_DET_VALOR_BENEF
                    toti_pagado = ids(i).Valor - descccc
                End If



                id = jj.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_ATE_DET_PREVE(id_atencion,
                                                                   CInt(S_Id_User),
                                                                   ids(i).id_CF,
                                                                   ids(i).id_PER,
                                                                   ids(i).CF_TP_PAGO,
                                                                   0,
                                                                   ids(i).Valor,
                                                                   toti_pagado, 'ids(i).Valor,        'VALOR PAGADO !!!!
                                                                   toti_copago,'0,       'COPAGO
                                                                   0,
                                                                   ids(i).CF_TP_PREVE,
                                                                   ids(i).CF_TP_PAGO,
                                                                    ids(i).ATE_DET_VALOR_BENEF,             '1
                                                                    ids(i).ATE_DET_VALOR_CS,                '2
                                                                    ids(i).ATE_DET_TP_1,                    '3
                                                                    ids(i).ATE_DET_TP_OBS,                  '4
                                                                    ids(i).ATE_DET_NUM_BOL,                 '5
                                                                    ids(i).ATE_DET_NUM_BONO,                '6
                                                                    ids(i).ID_DET_PREVE)                    '7

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

            '-------------------------------------------------------- GRABA DUAL COPAGO -----------------------------------------------------------------



            '----------------------------------------------------------FIN DUAL COPAGO -------------------------------------------------------------------

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
            ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(PREINGRESO2_PRO_SEC, id_atencion)
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(PREINGRESO2_PRO_SEC, Interno, OB, data_atencion(0).PREI_OBS_FICHA)

            Dim NN_ExamenDet As New N_Exa_Esp_V
            Dim DataExamenDet As Integer
            Dim exa_avis As Integer

            For i = 0 To ids.Count - 1
                If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                    DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(id_atencion, ids(i).id_CF)

                    'If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
                    '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
                    'End If
                End If




            Next i

            data_atencion_tp = NN_atencion_tp.IRIS_WEBF_CMVM_BUSCA_EXAMS_PARTI_O_EFEC_DET_ATENCION(id_atencion)
            Dim ate_numerin As Integer = 0

            If (data_atencion_tp.Count > 0) Then
                ate_numerin = data_atencion_tp(0).ATE_NUM
            Else
                ate_numerin = 0
            End If

            Str_Out += "{"
            Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & id_atencion & Chr(34) & ", "
            Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34) & ", "
            Str_Out += Chr(34) & "Boleta" & Chr(34) & ": " & Chr(34) & ate_numerin & Chr(34)
            Str_Out += "}"
            Return Str_Out
            Return datas
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Ciudad() As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Ciudad_By_ID_USER
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_CIUDAD
            lol.text = xItem.CIU_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Comuna(ByVal ID_CIUD As Integer) As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Comuna_By_ID_USER
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_COMUNA
            lol.text = xItem.COM_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Ciu_Com_User(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
        Dim NNN As New N_Login2

        Return NNN.IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER(ID_USER)
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    Public Class ids2_caja

        Dim E_id_CF As Integer
        Dim E_id_PER As Integer
        Dim E_Valor As Integer
        Dim E_Clinico As String
        Dim E_CF_ESTADO_EXAMEN As String
        Dim E_CF_TP_PAGO As String
        Dim E_ATE_DET_NUM_BONO As String            '6
        Dim E_ATE_DET_NUM_BOL As Integer            '5
        Dim E_ATE_DET_TP_OBS As String              '4
        Dim E_ATE_DET_TP_1 As Integer               '3
        Dim E_ATE_DET_VALOR_CS As Integer           '2
        Dim E_ATE_DET_VALOR_BENEF As Integer        '1
        Dim E_ID_DET_PREVE As Integer               '7

        Public Property ID_DET_PREVE As Integer
            Get
                Return E_ID_DET_PREVE
            End Get
            Set(ByVal value As Integer)
                E_ID_DET_PREVE = value
            End Set
        End Property

        Public Property ATE_DET_VALOR_BENEF As Integer
            Get
                Return E_ATE_DET_VALOR_BENEF
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_VALOR_BENEF = value
            End Set
        End Property

        Public Property ATE_DET_VALOR_CS As Integer
            Get
                Return E_ATE_DET_VALOR_CS
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_VALOR_CS = value
            End Set
        End Property

        Public Property ATE_DET_TP_1 As Integer
            Get
                Return E_ATE_DET_TP_1
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_TP_1 = value
            End Set
        End Property

        Public Property ATE_DET_TP_OBS As String
            Get
                Return E_ATE_DET_TP_OBS
            End Get
            Set(ByVal value As String)
                E_ATE_DET_TP_OBS = value
            End Set
        End Property

        Public Property ATE_DET_NUM_BOL As Integer
            Get
                Return E_ATE_DET_NUM_BOL
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_NUM_BOL = value
            End Set
        End Property

        Public Property ATE_DET_NUM_BONO As String
            Get
                Return E_ATE_DET_NUM_BONO
            End Get
            Set(ByVal value As String)
                E_ATE_DET_NUM_BONO = value
            End Set
        End Property

        Public Property CF_TP_PAGO As String
            Get
                Return E_CF_TP_PAGO
            End Get
            Set(ByVal value As String)
                E_CF_TP_PAGO = value
            End Set
        End Property
        Dim E_CF_TP_PREVE As String
        Public Property CF_TP_PREVE As String
            Get
                Return E_CF_TP_PREVE
            End Get
            Set(ByVal value As String)
                E_CF_TP_PREVE = value
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

        Public Property Clinico As String
            Get
                Return E_Clinico
            End Get
            Set(ByVal value As String)
                E_Clinico = value
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
End Class