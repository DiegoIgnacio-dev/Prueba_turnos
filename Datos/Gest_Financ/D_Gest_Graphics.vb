Imports Conexion
Imports Entidades
Imports System.Data.OleDb

Public Class D_Gest_Graphics

    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Public Function IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC(ByVal DATE_01 As Date, ByVal DATE_02 As Date, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DATE_01", OleDbType.Date).Value = DATE_01
            .Add("@DATE_02", OleDbType.Date).Value = DATE_02
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.BigInt).Value = ID_PREV
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PROC

            E_Proc_Item.CANT_ATE = DD_GEN.DB_NULL(Obj_Reader, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV(ByVal DATE_01 As Date, ByVal DATE_02 As Date, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DATE_01", OleDbType.Date).Value = DATE_01
            .Add("@DATE_02", OleDbType.Date).Value = DATE_02
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.BigInt).Value = ID_PREV
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_GRAPHICS_CANT_ATE_BY_PREV

            E_Proc_Item.CANT_ATE = DD_GEN.DB_NULL(Obj_Reader, 0)
            E_Proc_Item.PREV_DESC = DD_GEN.DB_NULL(Obj_Reader, 1)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION(ByVal DATE_01 As Date, ByVal DATE_02 As Date, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DATE_01", OleDbType.Date).Value = DATE_01
            .Add("@DATE_02", OleDbType.Date).Value = DATE_02
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.BigInt).Value = ID_PREV
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_GRAPHICS_CANT_EXA_ESTADO_VALIDACION

            E_Proc_Item.CANT_EXAM = DD_GEN.DB_NULL(Obj_Reader, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 1)
            E_Proc_Item.EST_COD = DD_GEN.DB_NULL(Obj_Reader, 2)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
