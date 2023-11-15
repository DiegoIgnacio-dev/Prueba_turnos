Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_Crea_Producto
    'Declarar la Conexión
    Dim CC_ConnBD As C_ConnBD
    'Declarar una nueva Instancia de General Functions
    Dim DD_GEN As New D_General_Functions
    Function Crear_Producto(ByVal NOMBRE As String, ByVal DESCRIPCION As String, ByVal PRECIO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD 'Nueva instancia de conexión

        Dim Cmd_SQL As New OleDb.OleDbCommand 'Comandos OleDb

        Dim Retorno As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure 'Tipo Consulta
            .CommandText = "IRIS_WEBF_GRABA_PRODUCTOS_TEST" 'Nombre PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test 'Cadena conexión
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NOMBRE", OleDbType.Varchar).Value = NOMBRE
            .Add("@DESCRIPCION", OleDbType.Varchar).Value = DESCRIPCION
            .Add("@PRECIO", OleDbType.Integer).Value = PRECIO
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
