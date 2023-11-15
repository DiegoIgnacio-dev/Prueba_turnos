Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_DATA_MODULOS
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_MODULOS() As List(Of E_DATA_MODULOS) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As New E_DATA_MODULOS 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_MODULOS) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_BUSCA_ATENCION_2" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
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
            Item_Retorno = New E_DATA_MODULOS 'Nuevo item de Entidad (Limpiar el anterior)

            Item_Retorno.MD_MODULO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.MD_TIPO_MODULO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            Item_Retorno.ID_MODULO_TURNO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            Item_Retorno.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            Item_Retorno.ID_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            Item_Retorno.TP_ATE_MODULO_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            Item_Retorno.FECHA_TIME = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)


            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function

    Function IRIS_WEBF_BUSCA_MODULOS_POR_ID(ByVal ID_TURNO As Integer) As List(Of E_DATA_MODULOS) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As New E_DATA_MODULOS 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_MODULOS) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_BUSCA_MODULOS_POR_ID" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@MD_TIPO_MODULO", OleDbType.Integer).Value = ID_TURNO
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
            Item_Retorno = New E_DATA_MODULOS 'Nuevo item de Entidad (Limpiar el anterior)

            Item_Retorno.MD_MODULO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.MD_MODULO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.MD_TIPO_MODULO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            Item_Retorno.ID_MODULO_TURNO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            Item_Retorno.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function
End Class
