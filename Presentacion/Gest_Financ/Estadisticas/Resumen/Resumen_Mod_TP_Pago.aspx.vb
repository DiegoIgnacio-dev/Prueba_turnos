Imports Entidades
Imports Negocio
Public Class Resumen_Mod_TP_Pago
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Guardar_TodoByVal(ByVal ID_ATENCION As Integer,
                                            ByVal TOTAL As Integer,
                                            ByVal FECHA_PRE As String,
                                            ByVal ids As List(Of ids2_TP_CHANGE),
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
                                             ByVal ATE_V_SC As String
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

        Dim datas As String = ""
        Dim correlativo As Integer

        'paciente
        Dim Rpaciente As Integer
        Dim examun As Integer
        Dim Str_Out As String = ""
        Dim DATASSSSSS As Integer
        ' Dim PREINGRESO2 As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim nn As N_IRIS_WEBF_GRABA_PACIENTE_ATENCION = New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION = New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As N_IRIS_WEBF_GRABA_PREINGRESO2 = New N_IRIS_WEBF_GRABA_PREINGRESO2
        Dim cc As N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC = New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO = New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO

        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else


            Dim NN_Date As New N_Date
            Dim fecha As String = FECHA_PRE.Replace("/", "-")
            Dim DIA1 As String = fecha.Split("-")(0)
            Dim MES2 As String = fecha.Split("-")(1)
            Dim AÑO3 As String = fecha.Split("-")(2)
            Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)

            Dim update_confirm As Integer
            Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
            Dim update_confirm_det As Integer
            Dim update_log As Integer
            Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
            Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
            Dim dual_copago As Integer

            Dim VALOR_PREVI As Integer = 0
            Dim VALOR_BENEFI As Integer = 0
            Dim VALOR_SC As Integer = 0
            Dim VALOR_PAGADO As Integer = 0
            Dim VALOR_CF As Integer = 0
            Dim VALOR_CP As Integer = 0

            For i = 0 To ids.Count - 1
                VALOR_PREVI += ids(i).Valor
                VALOR_BENEFI += ids(i).ATE_DET_VALOR_BENEF
                VALOR_SC += ids(i).ATE_DET_VALOR_CS
                VALOR_PAGADO += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS

                If (ids(i).CF_TP_PAGO = 1 Or ids(i).CF_TP_PAGO = 20 Or ids(i).CF_TP_PAGO = 4) Then
                    VALOR_CP += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
                Else
                    VALOR_CF += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
                End If

            Next i

            update_confirm = ddx.IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ID_ATENCION,
                                                                                                                        VALOR_PREVI,
                                                                                                                        VALOR_BENEFI,
                                                                                                                        VALOR_SC,
                                                                                                                        VALOR_PAGADO,
                                                                                                                        VALOR_CF,
                                                                                                                        VALOR_CP)

            For i = 0 To ids.Count - 1
                Dim valor_copago_det As Integer
                If (ids(i).CF_TP_PAGO = 1 Or ids(i).CF_TP_PAGO = 20 Or ids(i).CF_TP_PAGO = 4) Then
                    valor_copago_det = 0 'ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
                Else
                    valor_copago_det = ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
                End If

                update_confirm_det = jj.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_NEW_TP_PAGO(ID_ATENCION,
                                                                                                        ids(i).id_CF,
                                                                                                        ids(i).ATE_DET_TP_1,
                                                                                                        ids(i).Valor,
                                                                                                        (ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS),
                                                                                                        valor_copago_det,
                                                                                                        ids(i).ATE_DET_VALOR_BENEF,
                                                                                                        ids(i).ATE_DET_VALOR_CS)

                update_log = jj.IRIS_WEBF_CMVM_GRABA_AUDITORIA_CAMBIO_TP_PAGO("Mod-TP PAGO ",
                                                                              ("Rut: " + "0" + " Nombre: " + "0" + " FNac: " + "0" + ""),
                                                                              Date.Now,
                                                                              CInt(S_Id_User),
                                                                              ID_ATENCION,
                                                                              0)

            Next i

            '--------------------------- DUAL COPAGO ---------------------------
            'dual_copago = ddx.IRIS_WEBF_CMVM_GRABA_REL_COPAGO(id_atencion,
            '                                                  CInt(S_Id_User),
            '                                                  Date.Now,
            '                                                  ATE_TP_COPAGO_1,
            '                                                  ATE_VALOR_COPAGO_1,
            '                                                  ATE_TP_COPAGO_2,
            '                                                  ATE_VALOR_COPAGO_2,
            '                                                  ATE_V_CP_FP_2,
            '                                                  ATE_V_CP_2,
            '                                                  ATE_TP_PARTICULAR_1,
            '                                                  ATE_VALOR_PARTICULAR_1_2,
            '                                                  ATE_TP_PARTICULAR_2,
            '                                                  ATE_VALOR_PARTICULAR_2_2)




            '---------------------FIN DUAL COPAGO ------------------------------













            Return datas
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function tipo_pago() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Dim NN As N_Gen_Activos = New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2_particular(ByVal ID_PREVE As Integer, ByVal Fecha As String) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        'Declaraciones internas
        Dim data_particular As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN_particular As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION

        Dim ANO As Date
        ANO = CDate(Fecha)

        data_particular = NN_particular.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_PARTICULAR_BONIFICACION(Format(ANO, "yyyy"), 185)

        Return data_particular

    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2(ByVal ID_PREVE As Integer, ByVal Fecha As String) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_BONIFICACION(Format(ANO, "yyyy"), ID_PREVE)
        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DL_DOC() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO = New N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String,
                                            ByVal search_mode As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP = New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF_DUAL_COPA_MED(DOMAIN_URL, DESDE,
                                            HASTA,
                                            PROC,
                                            PREV,
                                            ID_USER,
                                            ATE_NUM, search_mode, TP_PAGO, ID_ESTADO)
        Return link
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_User_Data() As List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE)
        Dim NNN As New N_Conf_User
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE)




        List_Data = NNN.IRIS_WEBF_CMVM_BUSCA_USUARIO_ID_PREVISION_SCR()

        Return List_Data
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)



        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, PROC, PREV, ID_USER, ATE_NUM)
        If (Data_DTT.Count > 0) Then
            'For i = 0 To Data_DTT.Count - 1
            '    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_DTT(i).ATE_NUM)

            '    If (Data_Estado_Mant_2.Count > 0) Then
            '        Data_DTT(i).DOCS_CANT = Data_Estado_Mant_2.Count
            '    Else
            '        Data_DTT(i).DOCS_CANT = 0
            '    End If
            'Next i

            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Modificar(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)



        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_ID_ATE(ID_ATENCION)
        If (Data_DTT.Count > 0) Then
            'For i = 0 To Data_DTT.Count - 1
            '    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_DTT(i).ATE_NUM)

            '    If (Data_Estado_Mant_2.Count > 0) Then
            '        Data_DTT(i).DOCS_CANT = Data_Estado_Mant_2.Count
            '    Else
            '        Data_DTT(i).DOCS_CANT = 0
            '    End If
            'Next i

            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Modal(ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)



        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_MODAL(ATE_NUM)
        If (Data_DTT.Count > 0) Then
            For i = 0 To Data_DTT.Count - 1
                Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_DTT(i).ATE_NUM)

                If (Data_Estado_Mant_2.Count > 0) Then
                    Data_DTT(i).DOCS_CANT = Data_Estado_Mant_2.Count
                Else
                    Data_DTT(i).DOCS_CANT = 0
                End If
            Next i

            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Select(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)


        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER, ID_ESTADO)

        If (Data_DTT.Count > 0) Then
            'For i = 0 To Data_DTT.Count - 1
            '    Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_DTT(i).ATE_NUM)

            '    If (Data_Estado_Mant_2.Count > 0) Then
            '        Data_DTT(i).DOCS_CANT = Data_Estado_Mant_2.Count
            '    Else
            '        Data_DTT(i).DOCS_CANT = 0
            '    End If

            'Next i
            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Elimina_Asoc(ByVal ID_FOTO_ATE As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As Integer = 0

        Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE_ASOC(ID_FOTO_ATE)


        Return Data_Estado_Mant_2

    End Function
    <Services.WebMethod()>
    Public Shared Function Get_Img(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(ID_ATENCION)

        If (Data_Estado_Mant_2.Count > 0) Then
            Return Data_Estado_Mant_2
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Ajax_Update(ByVal MUESTRA() As Object,
                                            ByVal ID_USUARIO As Integer) As Integer
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As Integer = 0

        For i = 0 To (MUESTRA.GetUpperBound(0))
            Dim ID_DET_ATEEEE As Integer = MUESTRA(i)

            Data_DTT = NN_DTT.IRIS_WEBF_UPDATE_REVISION_DE_BONOS(ID_DET_ATEEEE, ID_USUARIO)
        Next i


        Return Data_DTT

    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String,
                                            ByVal search_mode As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal ID_ESTADO As Integer) As String
        Dim NN_Prev As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Return NN_Prev.Gen_Excel_Dual_Copago_Med(DOMAIN_URL, DESDE,
                                            HASTA,
                                            PROC,
                                            PREV,
                                            ID_USER,
                                            ATE_NUM, search_mode, TP_PAGO, ID_ESTADO)
    End Function

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
    Public Shared Function Llenar_Ddl_Programa() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Declaraciones internas
        Dim NN_Preve As New N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        Dim Data_Preve As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Data_Preve = NN_Preve.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
        If (Data_Preve.Count > 0) Then
            Return Data_Preve
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function prueba_order_med(ByVal DOMAIN_URL As String, ByVal imgbase64 As String, ByVal tp_order As String, ByVal ID_ATENCION As Integer,
                                            ByVal ID_USUARIO As Integer,
                                            ByVal ATE_NUM As Integer) As Object

        'Dim R_HR_TN As New Resumen_Prev_Prog_Subp_Scr_3_Glob_Med
        'Dim result = R_HR_TN.GuardarImg_orden_medica(DOMAIN_URL, imgbase64, tp_order)

        Dim NN_Search As New N_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(imgbase64, ID_ATENCION, ID_USUARIO, ATE_NUM)

        Return Data_OUT
        'Return result

    End Function

    Public Function GuardarImg_orden_medica(DOMAIN_URL, img, tp_order)
        If img <> "#" And img <> "" And tp_order <> "" Then


            Dim extencion As String = "." + Convert.ToString(tp_order)

            Dim Base_imagen As String = img
            Dim Base_Imagen64Web As String = Base_imagen
            Dim BTWEB(Convert.FromBase64String(Base_imagen).Length - 1) As Byte
            BTWEB = Convert.FromBase64String(Base_imagen)
            Dim path As String

            'path = HttpContext.Current.Server.MapPath(".") + "\ordenes\" + ID_ATE_NUM
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "ORDENES\" & extencion

            'Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            'Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

            ''Devolver la url del archivo generado
            'Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
            'Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

            Dim SW As New IO.StreamWriter(Ruta_save_local & Relative_Path)
            'Dim SW As New IO.StreamWriter(path)
            SW.BaseStream.Write(BTWEB, 0, BTWEB.Length - 1)
            SW.Close()

            'Dim ruta As String = "E:\Mapeo\Soulsmakers.png"
            ''se encargara de obtener y almacenar los bytes temporalmente
            'Dim Ms As New IO.MemoryStream
            'Dim Bmp As New Bitmap(ruta)

            'Bmp.Save(Ms, Imaging.ImageFormat.Png)
            'Dim BT(Ms.Length - 1) As Byte
            'BT = Ms.GetBuffer


        End If


    End Function


    Public Class ids2_TP_CHANGE

        Dim E_id_CF As Integer
        Dim E_id_PER As Integer
        Dim E_Valor As Integer
        Dim E_Clinico As String
        Dim E_CF_ESTADO_EXAMEN As String
        Dim E_CF_TP_PAGO As String
        Dim E_ATE_DET_NUM_BONO As String           '6
        Dim E_ATE_DET_NUM_BOL As Integer            '5
        Dim E_ATE_DET_TP_OBS As String              '4
        Dim E_ATE_DET_TP_1 As Integer               '3
        Dim E_ATE_DET_VALOR_CS As Integer           '2
        Dim E_ATE_DET_VALOR_BENEF As Integer        '1

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