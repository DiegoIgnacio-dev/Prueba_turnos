Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer,
                                            ByVal SUBP As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            .Add("@PROG", OleDbType.Numeric).Value = PROG
            .Add("@SUBP", OleDbType.Numeric).Value = SUBP
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.TOT_ATE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.TOT_CF = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.TOT_VAL = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2(ByVal DESDE As String,
                                          ByVal HASTA As String,
                                          ByVal PROC As Integer,
                                          ByVal PREV As Integer,
                                          ByVal PROG As Integer,
                                          ByVal SUBP As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            .Add("@PROG", OleDbType.Numeric).Value = PROG
            .Add("@SUBP", OleDbType.Numeric).Value = SUBP
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.SUB_PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.TOT_ATE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.TOT_CF = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.TOT_VAL = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR(ByVal DESDE As String,
                                        ByVal HASTA As String,
                                        ByVal PROC As Integer,
                                        ByVal PREV As Integer,
                                        ByVal PROG As Integer,
                                        ByVal SUBP As Integer,
                                        ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            '.Add("@PROG", OleDbType.Numeric).Value = PROG
            '.Add("@SUBP", OleDbType.Numeric).Value = SUBP
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)


            'E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'E_Proc_Item.SUB_PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.TOT_ATE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.TOT_CF = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.TOT_VAL = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2(ByVal DESDE As String,
                                       ByVal HASTA As String,
                                       ByVal PROC As Integer,
                                       ByVal PREV As Integer,
                                       ByVal PROG As Integer,
                                       ByVal SUBP As Integer,
                                       ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(DESDE)
        Dim ANO2 = Format(ANO, "yyyy")

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            '.Add("@PROG", OleDbType.Numeric).Value = PROG
            '.Add("@SUBP", OleDbType.Numeric).Value = SUBP
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@ANO", OleDbType.VarChar).Value = ANO2
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.TOT_VAL = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_2_SCR_2_TDE(ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer,
                                     ByVal SUBP As Integer,
                                     ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(DESDE)
        Dim ANO2 = Format(ANO, "yyyy")

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_TODOS_EXAMS"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            '.Add("@PROG", OleDbType.Numeric).Value = PROG
            '.Add("@SUBP", OleDbType.Numeric).Value = SUBP
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@ANO", OleDbType.VarChar).Value = ANO2
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO(ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer,
                                     ByVal SUBP As Integer,
                                     ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(DESDE)
        Dim ANO2 = Format(ANO, "yyyy")

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            '.Add("@PROG", OleDbType.Numeric).Value = PROG
            '.Add("@SUBP", OleDbType.Numeric).Value = SUBP
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@ANO", OleDbType.VarChar).Value = ANO2
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'E_Proc_Item.TOT_VAL = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)

            E_Proc_Item.ID_TP_PAGO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ID_TP_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR(ByVal DESDE As String,
                                  ByVal HASTA As String,
                                  ByVal PROC As Integer,
                                  ByVal PREV As Integer,
                                  ByVal PROG As Integer,
                                  ByVal SUBP As Integer,
                                  ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(DESDE)
        Dim ANO2 = Format(ANO, "yyyy")

        'If PREV = 278 Or PROC = 1787 Then                       '<-------------------------------------------------------------------
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP"
        'End If

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            '.Add("@PROG", OleDbType.Numeric).Value = PROG
            '.Add("@SUBP", OleDbType.Numeric).Value = SUBP
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@ANO", OleDbType.VarChar).Value = ANO2
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'E_Proc_Item.TOT_VAL = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)

            E_Proc_Item.ID_TP_PAGO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ID_TP_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_ATE_DET_ATE(ByVal DESDE As String,
                               ByVal HASTA As String,
                               ByVal PROC As Integer,
                               ByVal PREV As Integer,
                               ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(DESDE)
        Dim ANO2 = Format(ANO, "yyyy")

        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_ATE_DET_ATE"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@ANO", OleDbType.VarChar).Value = ANO2
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_TOTAL = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_TOTAL_PREVI = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_TOTAL_COPA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_V_SISTEMA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_V_BENEF = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_V_CF = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_V_CF_FP = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_V_CP = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_V_CP_FP = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_V_BOLETA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.USU_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.USU_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.ID_TP_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_V_BENEF = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS(ByVal DESDE As String,
                                 ByVal HASTA As String,
                                 ByVal PROC As Integer,
                                 ByVal PREV As Integer,
                                 ByVal PROG As Integer,
                                 ByVal SUBP As Integer,
                                 ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(DESDE)
        Dim ANO2 = Format(ANO, "yyyy")
        PA = "IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP_278_2_SCR_2_DUAL_COPAGO_DUAL_PARTICULAR_DESCUENTOS"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@ANO", OleDbType.VarChar).Value = ANO2
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ID_TP_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_V_BENEF = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(ByVal DESDE As String,
                            ByVal HASTA As String,
                            ByVal PROC As Integer,
                            ByVal PREV As Integer,
                            ByVal ID_USER As Integer,
                            ByVal ATE_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_CF", OleDbType.Numeric).Value = 0
            .Add("@ID_FP", OleDbType.Numeric).Value = 0
            .Add("@ID_PREV", OleDbType.Numeric).Value = 0
            .Add("@USU", OleDbType.Numeric).Value = 0
            .Add("@FOLIO", OleDbType.Numeric).Value = ATE_NUM
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.USU_REV = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USU_CRE = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORD = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORU = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_CF", OleDbType.Numeric).Value = PROC
            .Add("@ID_FP", OleDbType.Numeric).Value = TP_PAGO
            .Add("@ID_PREV", OleDbType.Numeric).Value = PREV
            .Add("@USU", OleDbType.Numeric).Value = ID_USER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.USU_REV = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USU_CRE = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORD = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORU = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_UPDATE_REVISION_DE_BONOS(ByVal ID_DET_ATE As Integer, ByVal ID_USUARIO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim PA As String

        PA = "IRIS_WEBF_UPDATE_REVISION_DE_BONOS"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_DET_ATE", OleDbType.Integer).Value = ID_DET_ATE
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA(ByVal DESDE As String,
                                          ByVal HASTA As String,
                                          ByVal PROC As Integer,
                                          ByVal TP_PAGO As Integer,
                                          ByVal PREV As Integer,
                                          ByVal ID_USER As Integer,
                                            ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_CF", OleDbType.Numeric).Value = PROC
            .Add("@ID_FP", OleDbType.Numeric).Value = TP_PAGO
            .Add("@ID_PREV", OleDbType.Numeric).Value = PREV
            .Add("@USU", OleDbType.Numeric).Value = ID_USER
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.USU_REV = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USU_CRE = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORD = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORU = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_MODAL(ByVal ATE_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_MODAL"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.Numeric).Value = ATE_NUM
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.USU_REV = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USU_CRE = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORD = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORU = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA_EDIT_TP_PAGO(ByVal DESDE As String,
                                        ByVal HASTA As String,
                                        ByVal PROC As Integer,
                                        ByVal TP_PAGO As Integer,
                                        ByVal PREV As Integer,
                                        ByVal ID_USER As Integer,
                                        ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_DOCTOR_CAJA_EDIT_TP_PAGO"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_CF", OleDbType.Numeric).Value = PROC
            .Add("@ID_FP", OleDbType.Numeric).Value = TP_PAGO
            .Add("@ID_PREV", OleDbType.Numeric).Value = PREV
            .Add("@USU", OleDbType.Numeric).Value = ID_USER
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.USU_REV = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USU_CRE = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORD = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORU = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_ID_ATE(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA_ID_ATE"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.USU_REV = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USU_CRE = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORD = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.ATE_DET_RCAJA_VALORU = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)
            E_Proc_Item.ID_TP_PAGO = DD_GEN.DB_NULL(Obj_Reader, 42, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
