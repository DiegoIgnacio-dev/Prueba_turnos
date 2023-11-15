Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_DATA_IMPR
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_VISOR_IMPR(ByVal ID_TURNO_IMPR As Integer, ByVal MD_FECHA As String, ByVal ONLY_DATE As String) As List(Of E_DATA_IMPR) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As E_DATA_IMPR 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_IMPR) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_VISOR_IMPR_UP" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_TURNO_IMPR", OleDbType.Integer).Value = ID_TURNO_IMPR
            .Add("@MD_FECHA", OleDbType.VarChar).Value = MD_FECHA
            .Add("@ONLY_DATE", OleDbType.VarChar).Value = ONLY_DATE

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader 'Ejecutar lector de datos
        While Obj_Reader.Read
            Item_Retorno = New E_DATA_IMPR 'Nuevo item de Entidad (Limpiar el anterior)
            Item_Retorno.TR_TURNO_LET = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.TR_TURNO_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.TR_TURNO_TIPO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function

    Function IRIS_WEBF_UPDATE_TURNO_LOG(ByVal ID_TURNO_IMPR As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_UPDATE_TURNO_LOG" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_MODULO_LOG", OleDbType.Integer).Value = ID_TURNO_IMPR
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Retorno = Cmd_SQL.ExecuteNonQuery 'Ejecutar lenctor de datos

        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Retorno 'Retornar la lista de Entidades
    End Function
End Class

