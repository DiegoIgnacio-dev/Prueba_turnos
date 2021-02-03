﻿Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_GRABA_TICKET
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_GRABA_TICKET(ByVal ID_USER As Integer,
                                            ByVal ASUNTO As String,
                                            ByVal FORMULARIO As String,
                                            ByVal MENSAJE As String,
                                            ByVal FECHA As String) As Integer

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_TICKET"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER
            .Add("@ASUNTO", OleDbType.VarChar).Value = ASUNTO
            .Add("@FORMULARIO", OleDbType.VarChar).Value = FORMULARIO
            .Add("@MENSAJE", OleDbType.VarChar).Value = MENSAJE
            .Add("@FECHA", OleDbType.Date).Value = CDate(FECHA)
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