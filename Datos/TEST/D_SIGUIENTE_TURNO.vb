
Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_SIGUIENTE_TURNO
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions

    Function Busca_Log_Turno(ByVal ID_MODULO_TURNO As Integer, ByVal DATO_NUM As Integer, ByVal FECHA_HOY As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer = 0

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_BUSCA_ID_LOG" 'Nombre PA Cambiar A IRIS_WEBF_TURNO_UPDATE_RECEP
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_MODULO_TURNO", OleDbType.Integer).Value = ID_MODULO_TURNO
            .Add("@DATO_NUM", OleDbType.Integer).Value = DATO_NUM
            .Add("@LETRA_TURNO", OleDbType.Date).Value = CDate(FECHA_HOY)


        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        Obj_Reader = Cmd_SQL.ExecuteReader 'Ejecutar lenctor de datos
        While Obj_Reader.Read
            Retorno = DD_GEN.DB_NULL(Obj_Reader, 0, 0) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
        End While

        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Retorno 'Retornar la lista de Entidades
    End Function

    Function Siguiente_Turno(ByVal ID_MODULO_TURNO As Integer, ByVal ID_MODULO_RECEP As Integer, ByVal TIPO_ATENCION As Integer, ByVal ONLY_DATE As String, ByVal DATO_NUM As Integer, ByVal LETRA_TURNO As Char) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_UPDATE_RECEP" 'Nombre PA Cambiar A IRIS_WEBF_TURNO_UPDATE_RECEP
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_MODULO_TURNO", OleDbType.Integer).Value = ID_MODULO_TURNO
            .Add("@ID_MODULO_RECEP", OleDbType.Integer).Value = ID_MODULO_RECEP
            .Add("@TIPO_ATENCION", OleDbType.Integer).Value = TIPO_ATENCION
            .Add("@ONLY_DATE", OleDbType.Date).Value = ONLY_DATE
            .Add("@DATO_NUM", OleDbType.Integer).Value = DATO_NUM
            .Add("@LETRA_TURNO", OleDbType.Char).Value = LETRA_TURNO


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

    Function Update_Log_Turno(ByVal ID_MODULO_TURNO As Integer, ByVal ID_MODULO_RECEP As Integer, ByVal DATO_NUM As Integer, ByVal FECHA_HOY As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_UPDATE_LOG_TURNO" 'Nombre PA Cambiar
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_MODULO_TURNO", OleDbType.Integer).Value = ID_MODULO_TURNO
            .Add("@ID_MODULO_RECEP", OleDbType.Integer).Value = ID_MODULO_RECEP
            .Add("@DATO_NUM", OleDbType.Integer).Value = DATO_NUM
            .Add("@FECHA_HOY", OleDbType.Date).Value = CDate(FECHA_HOY)

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

    Function RESET_FECHA() As List(Of E_DATA_RESET_FECHA) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As New E_DATA_RESET_FECHA 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_RESET_FECHA) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_UPDATE_FECHA" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
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
            Item_Retorno = New E_DATA_RESET_FECHA 'Nuevo item de Entidad (Limpiar el anterior)

            Item_Retorno.ID_MODULO_TURNO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)

            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function
    Function Update_Fecha(ByVal ID As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_UPDATE_FECHA_POR_ID" 'Nombre PA Cambiar
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID", OleDbType.Integer).Value = ID


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




    Function UPDATE_TIME(ByVal LETRA_TURNO As Char, ByVal TIPO_ATENCION As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_UPDATE_TIME_ALERT" 'Nombre PA Cambiar
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@LETRA_TURNO", OleDbType.Char).Value = LETRA_TURNO
            .Add("@TIPO_ATENCION", OleDbType.Integer).Value = TIPO_ATENCION
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
