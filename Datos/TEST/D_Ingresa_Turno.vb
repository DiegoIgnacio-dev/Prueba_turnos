Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_Ingresa_Turno
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function Ingresar_Turno(ByVal MD_MODULO As Char, ByVal MD_TURNO_IMPR As Integer, ByVal MD_TURNO_RECEP As Integer, ByVal MD_TIPO_MODULO As Integer, ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_GRABA_M_TEST" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@MD_MODULO", OleDbType.VarChar).Value = MD_MODULO
            .Add("@MD_TURNO_IMPR", OleDbType.Integer).Value = MD_TURNO_IMPR
            .Add("@MD_TURNO_RECEP", OleDbType.Integer).Value = MD_TURNO_RECEP
            .Add("@MD_TIPO_MODULO", OleDbType.Integer).Value = MD_TIPO_MODULO
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
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

    '################ UPDATE_TURNOS#########################################

    Function Update_Turno(ByVal ID_TURNO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_UPDATE_TURNO_RECEP" 'Nombre PA Cambiar
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
        Retorno = Cmd_SQL.ExecuteNonQuery 'Ejecutar lenctor de datos

        CC_ConnBD.Oledbconexion.Close() 'Cerrar conexión a la BD
        Return Retorno 'Retornar la lista de Entidades
    End Function

    '################ UPDATE_CHECK_TURNOS#########################################

    Function Update_Check(ByVal ID_MODULO_TURNO As Integer, ByVal MD_FECHA As String, ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_UPDATE_TURNO_CHECK2" 'Nombre PA Cambiar
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters

            .Add("@ID_MODULO_TURNO", OleDbType.Integer).Value = ID_MODULO_TURNO
            .Add("MD_FECHA", OleDbType.Date).Value = MD_FECHA
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO


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
