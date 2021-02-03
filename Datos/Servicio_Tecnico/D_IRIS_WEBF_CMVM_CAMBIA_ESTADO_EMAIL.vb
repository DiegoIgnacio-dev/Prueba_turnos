Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL(ByVal NAME As Integer, ByVal ID_EMAIL As Integer, ByVal ESTADO As Integer) As Integer

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@NAME", OleDbType.Integer).Value = NAME
            .Add("@ID_EMAIL", OleDbType.Integer).Value = ID_EMAIL
            .Add("@ESTADO", OleDbType.Integer).Value = ESTADO

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Obj_Reader = Cmd_command.ExecuteReader
        Dim AYYYYYY As Integer = 0
        While Obj_Reader.Read
            AYYYYYY = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
        End While

        objconexion.Oledbconexion.Close()
        Return AYYYYYY
    End Function
End Class
