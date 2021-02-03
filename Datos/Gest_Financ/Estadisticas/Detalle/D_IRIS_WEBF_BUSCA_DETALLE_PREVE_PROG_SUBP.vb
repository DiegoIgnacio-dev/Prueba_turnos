Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2(ByVal DESDE As String,
                                          ByVal HASTA As String,
                                          ByVal PROC As Integer,
                                          ByVal PREV As Integer,
                                          ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR(ByVal DESDE As String,
                                        ByVal HASTA As String,
                                        ByVal PROC As Integer,
                                        ByVal PREV As Integer,
                                        ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SCR"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_SCR_2(ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String

        Dim ANO = CDate(Date.Now)
        Dim ANO2 = Format(ANO, "yyyy")

        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SCR_2"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = PROG
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_PROVEE(ByVal DESDE As String,
                                     ByVal HASTA As String,
                                     ByVal PROC As Integer,
                                     ByVal PREV As Integer,
                                     ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_PROVEE"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_PROVEE(ByVal DESDE As String,
                                 ByVal HASTA As String,
                                 ByVal PROC As Integer,
                                 ByVal PREV As Integer,
                                 ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_PROVEE"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_PROVEE(ByVal DESDE As String,
                                         ByVal HASTA As String,
                                         ByVal PROC As Integer,
                                         ByVal PREV As Integer,
                                         ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_PROVEE"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS(ByVal DESDE As String,
                                        ByVal HASTA As String,
                                        ByVal PROC As Integer,
                                        ByVal PREV As Integer,
                                        ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_INDEX_MINDS"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_MINDS(ByVal DESDE As String,
                                   ByVal HASTA As String,
                                   ByVal PROC As Integer,
                                   ByVal PREV As Integer,
                                   ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_USU_GRAPH_INDEX_MINDS"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            .Add("@ID_PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            .Add("@PROG", OleDbType.Numeric).Value = PROG
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_MINDS(ByVal DESDE As String,
                               ByVal HASTA As String,
                               ByVal PROC As Integer,
                               ByVal PREV As Integer,
                               ByVal PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP)
        Dim PA As String
        'If PREV = 278 Or PROC = 1787 Then
        PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2_278_2_SEXO_GRAPH_INDEX_MINDS"
        'Else
        '    PA = "IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP_2"
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
            .Add("@ID_PROC", OleDbType.Numeric).Value = PROC
            .Add("@PREV", OleDbType.Numeric).Value = PREV
            .Add("@PROG", OleDbType.Numeric).Value = PROG
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_PREVE_PROG_SUBP
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
