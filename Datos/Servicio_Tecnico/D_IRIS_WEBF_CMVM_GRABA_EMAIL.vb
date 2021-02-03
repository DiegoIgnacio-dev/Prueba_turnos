Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_GRABA_EMAIL
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_GRABA_EMAIL(ByVal Email As String, ByVal Nombre As String, ByVal Tipo As Integer) As Integer

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_EMAIL"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@EMAIL", OleDbType.VarChar).Value = Email
            .Add("@NOMBRE", OleDbType.VarChar).Value = Nombre
            .Add("@TIPO", OleDbType.Integer).Value = Tipo

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
