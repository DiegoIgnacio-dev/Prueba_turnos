Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_DATA_ATENCIONES
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function BUSCA_DATA_ATENCIONES(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_DATA_ATENCIONES) ' Lo mismo que las demas capas
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Obj_Reader As OleDbDataReader 'Lector OleDb

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        'Declaraciones 'lista'
        Dim Item_Retorno As E_DATA_ATENCIONES 'Item de Entidad

        Dim Lista_Retorno As New List(Of E_DATA_ATENCIONES) 'Nueva lista de Entidad
        'Configuración general

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "BUSCA_ATENCION" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE) 'Parametros que recibe el PA
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA) 'Convertir fechas de String a Date
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
            Item_Retorno = New E_DATA_ATENCIONES 'Nuevo item de Entidad (Limpiar el anterior)
            Item_Retorno.FECHA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing) 'Recibir datos de la BD y almacenarlos en el item por cada propiedad
            Item_Retorno.NUM_TUR = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)



            'Agregar item de Entidad a la lista de Entidades
            Lista_Retorno.Add(Item_Retorno)
        End While
        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Lista_Retorno 'Retornar la lista de Entidades
    End Function
End Class