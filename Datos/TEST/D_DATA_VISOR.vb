Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_DATA_VISOR
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_VISOR_TURNO(ByVal ID_TURNO As Integer) As List(Of E_DATA_VISOR) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As E_DATA_VISOR 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_VISOR) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_VISOR_TURNO" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_TURNO", OleDbType.Integer).Value = ID_TURNO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader 'Ejecutar lenctor de datos
        While Obj_Reader.Read
            Item_Retorno = New E_DATA_VISOR 'Nuevo item de Entidad (Limpiar el anterior)
            Item_Retorno.MD_MODULO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.MD_TIPO_MODULO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            Item_Retorno.ID_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function

    Function IRIS_WEBF_VISOR_TURNO_RECEP(ByVal ID_MODULO_RECEP As Integer) As List(Of E_DATA_VISOR) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As E_DATA_VISOR 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_VISOR) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_BUSCA_VISOR_TURNO_RECEP" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_MODULO_RECEP", OleDbType.Integer).Value = ID_MODULO_RECEP
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader 'Ejecutar lenctor de datos
        While Obj_Reader.Read
            Item_Retorno = New E_DATA_VISOR 'Nuevo item de Entidad (Limpiar el anterior)
            Item_Retorno.MD_MODULO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.MD_TIPO_MODULO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            Item_Retorno.ID_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function

    Function IRIS_WEBF_VISOR_TURNO_TIPO(ByVal ID_TIPO As Integer) As List(Of E_DATA_VISOR) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As E_DATA_VISOR 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_VISOR) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_VISOR_TURNO_TIPO" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_TIPO", OleDbType.Integer).Value = ID_TIPO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader 'Ejecutar lenctor de datos
        While Obj_Reader.Read
            Item_Retorno = New E_DATA_VISOR 'Nuevo item de Entidad (Limpiar el anterior)
            Item_Retorno.MD_MODULO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.MD_TIPO_MODULO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            Item_Retorno.ID_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function


    Function IRIS_WEBF_TURNO_MENOR(ByVal MD_TIPO_MODULO As Integer) As List(Of E_DATA_MODULO_MENOR) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As E_DATA_MODULO_MENOR 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_MODULO_MENOR) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_BUSCAR_MENOR" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@MD_TIPO_MODULO", OleDbType.Integer).Value = MD_TIPO_MODULO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State 'Consultar estado conexión BD
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader 'Ejecutar lenctor de datos
        While Obj_Reader.Read
            Item_Retorno = New E_DATA_MODULO_MENOR 'Nuevo item de Entidad (Limpiar el anterior)
            Item_Retorno.ID_MODULO_TURNO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function
End Class
