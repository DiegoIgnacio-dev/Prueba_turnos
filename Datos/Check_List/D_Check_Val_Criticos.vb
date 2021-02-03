'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Check_Val_Criticos
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
            .Add("@ID_PRE2", OleDbType.BigInt).Value = ID_PRE2
            .Add("@ID_EST", OleDbType.BigInt).Value = ID_EST
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function



    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal SECCION As String, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim esss As String = ""
        'Configuración general
        If (ID_EST = 0) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_ALTERADOS2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        Else
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_ALTERADOS_ESTADO2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        End If
        If (ID_EST = 1) Then
            esss = "B"
        Else
            esss = "A"
        End If

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRE2", OleDbType.Numeric).Value = ID_PRE2
            .Add("@ID_EST", OleDbType.VarChar).Value = esss
            .Add("@SECCION", OleDbType.Numeric).Value = CInt(SECCION)
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS

            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 21, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 22, 0)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 31, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PROG As Long, ByVal ID_PRUEB As Long, ByVal ID_RESUL As Long, ByVal ID_STAT As Integer, ByVal ID_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        End If


        Dim S_Id_User As Integer = CInt(Galleta.Value)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        If (ID_RESUL = 0) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        ElseIf (ID_RESUL = 1) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_1_1"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        ElseIf (ID_RESUL = 2) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2_2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        End If


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
            .Add("@ID_PROG", OleDbType.BigInt).Value = ID_PROG
            .Add("@ID_PRUEB", OleDbType.BigInt).Value = ID_PRUEB
            .Add("@ID_EST", OleDbType.BigInt).Value = ID_STAT
            .Add("@ID_SECC", OleDbType.BigInt).Value = ID_SECC
            .Add("@IDPRO", OleDbType.BigInt).Value = CInt(Galleta.Value)
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.FONO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.SECC_DESC = DD_GEN.DB_NULL(Obj_Reader, 38, "")



            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Long,
                                                                ByVal ID_PROG As Long,
                                                                ByVal ID_PRUEB As Long,
                                                                ByVal ID_RESUL As Long,
                                                                ByVal ID_STAT As Integer,
                                                                ByVal ID_SECC As Integer,
                                                                ByVal ID_PROCE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        End If


        Dim S_Id_User As Integer = CInt(Galleta.Value)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        If (ID_RESUL = 0) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        ElseIf (ID_RESUL = 1) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_1_1_2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        ElseIf (ID_RESUL = 2) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2_2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        End If


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
            .Add("@ID_PROG", OleDbType.BigInt).Value = ID_PROG
            .Add("@ID_PRUEB", OleDbType.BigInt).Value = ID_PRUEB
            .Add("@ID_EST", OleDbType.BigInt).Value = ID_STAT
            .Add("@ID_SECC", OleDbType.BigInt).Value = ID_SECC
            '.Add("@IDPRO", OleDbType.BigInt).Value = CInt(Galleta.Value)
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
            .Add("@IDPRO", OleDbType.Integer).Value = ID_PROCE

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.FONO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.SECC_DESC = DD_GEN.DB_NULL(Obj_Reader, 38, "")



            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_NEW(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Long,
                                                                ByVal ID_PROG As Long,
                                                                ByVal ID_PRUEB As Long,
                                                                ByVal ID_RESUL As Long,
                                                                ByVal ID_STAT As Integer,
                                                                ByVal ID_SECC As Integer,
                                                                ByVal ID_PROCE As Integer,
                                                                ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        End If


        Dim S_Id_User As Integer = CInt(Galleta.Value)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        If (ID_RESUL = 0) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2_NEW"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        ElseIf (ID_RESUL = 1) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_1_1_2_NEW"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        ElseIf (ID_RESUL = 2) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_ESTADOS_VALORES_CRITICOS_EMB_2_2_NEW"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        End If


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
            .Add("@ID_PROG", OleDbType.BigInt).Value = ID_PROG
            .Add("@ID_PRUEB", OleDbType.BigInt).Value = ID_PRUEB
            .Add("@ID_EST", OleDbType.BigInt).Value = ID_STAT
            .Add("@ID_SECC", OleDbType.BigInt).Value = ID_SECC
            '.Add("@IDPRO", OleDbType.BigInt).Value = CInt(Galleta.Value)
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
            .Add("@IDPRO", OleDbType.Integer).Value = ID_PROCE
            .Add("@IDPREV", OleDbType.Integer).Value = ID_PREVE

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.FONO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.SECC_DESC = DD_GEN.DB_NULL(Obj_Reader, 38, "")



            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_EST As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_EST", OleDbType.Integer).Value = ID_EST
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.FONO = DD_GEN.DB_NULL(Obj_Reader, 31, "")

            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 37, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2(ByVal DESDE As Date,
                                                       ByVal HASTA As Date,
                                                       ByVal ID_EST As Integer,
                                                       ByVal ID_PROC As Integer,
                                                        ByVal ID_PREVE As Integer,
                                                        ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_EST", OleDbType.Integer).Value = ID_EST
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_PREVE", OleDbType.Integer).Value = ID_PREVE
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.FONO = DD_GEN.DB_NULL(Obj_Reader, 31, "")

            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 38, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 39, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2_ORINAS_SEDIMENTOS(ByVal DESDE As Date,
                                                     ByVal HASTA As Date,
                                                     ByVal ID_EST As Integer,
                                                     ByVal ID_PROC As Integer,
                                                      ByVal ID_PREVE As Integer,
                                                      ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_REL_PRUEBA_PRUEBA_2_2_ORINAS_SEDIMENTOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_EST", OleDbType.Integer).Value = ID_EST
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_PREVE", OleDbType.Integer).Value = ID_PREVE
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.FONO = DD_GEN.DB_NULL(Obj_Reader, 31, "")

            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 38, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 39, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
