Imports Conexion
Imports Entidades
Imports System.Data.OleDb

Public Class D_DATA_CARGA_OPTION_TP
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_CARGA_OPTION_TP() As List(Of E_DATA_CARGA_OPTION_TP) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As New E_DATA_CARGA_OPTION_TP 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_CARGA_OPTION_TP) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_TURNO_BUSCA_TIPO_MODULO" 'Nombre PA
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
            Item_Retorno = New E_DATA_CARGA_OPTION_TP 'Nuevo item de Entidad (Limpiar el anterior)

            Item_Retorno.ID_ATE_TP_MODULO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.ID_ESTADO_TP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            Item_Retorno.TP_ATE_MODULO_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)

            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function
End Class
