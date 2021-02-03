'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_GraficoHORA_ATE
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES(ByVal DESDE As Date, ByVal HASTA As Date) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As Long = 0
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
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
            'Agregar items a la lista
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal cookie_proc As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As Long = 0
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.Numeric).Value = cookie_proc
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
            'Agregar items a la lista
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS_AYER_AYER_SEMANA_PASADA(ByVal DESDE As Date,
                                                                                      ByVal HASTA As Date,
                                                                                      ByVal DESDE_SEMANA_PASADA As Date,
                                                                                      ByVal HASTA_SEMANA_PASADA As Date,
                                                                                      ByVal cookie_proc As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_HORA_CONTEO_ATENCIONES_MINDS_AYER_AYER_SEMANA_PASADA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@DESDE_SEMANA_PASADA", OleDbType.Date).Value = DESDE_SEMANA_PASADA
            .Add("@HASTA_SEMANA_PASADA", OleDbType.Date).Value = HASTA_SEMANA_PASADA
            .Add("@ID_PROC", OleDbType.Numeric).Value = cookie_proc
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS
            E_Proc_Item.AYER = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.AYER_SEMANA_PASADA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
