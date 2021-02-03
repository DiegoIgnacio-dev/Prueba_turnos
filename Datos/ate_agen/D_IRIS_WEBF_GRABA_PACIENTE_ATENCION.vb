﻿'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_PACIENTE_ATENCION
    'Declaraciones Generales
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_PACIENTE_ATENCION(ByVal RUT_PAC As String,
                                               ByVal NOMBRE_PAC As String,
                                               ByVal APE_PAC As String,
                                               ByVal FNAC_PAC As Date,
                                               ByVal ID_SEXO As Integer,
                                               ByVal ID_NACIONALIDAD As Integer,
                                               ByVal FONO1 As String,
                                               ByVal MOVIL1 As String,
                                               ByVal ID_CIU_COM As Integer,
                                               ByVal DIR_PAC As String,
                                               ByVal EMAIL_PAC As String,
                                               ByVal ID_DIAGNOSTICO As Integer,
                                               ByVal OBS_PER As String,
                                               ByVal ID_ESTADO As String,
                                               ByVal dni As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista      
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_PACIENTE_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT_PAC", OleDbType.VarChar).Value = RUT_PAC
            .Add("@NOMBRE_PAC", OleDbType.VarChar).Value = NOMBRE_PAC
            .Add("@APE_PAC", OleDbType.VarChar).Value = APE_PAC
            .Add("@FNAC_PAC", OleDbType.Date).Value = FNAC_PAC
            .Add("@ID_SEXO", OleDbType.Numeric).Value = ID_SEXO
            .Add("@ID_NACIONALIDAD", OleDbType.Numeric).Value = ID_NACIONALIDAD
            .Add("@FONO1", OleDbType.VarChar).Value = FONO1
            .Add("@MOVIL1", OleDbType.VarChar).Value = MOVIL1
            .Add("@ID_CIU_COM", OleDbType.Numeric).Value = ID_CIU_COM
            .Add("@DIR_PAC", OleDbType.VarChar).Value = DIR_PAC
            .Add("@EMAIL_PAC", OleDbType.VarChar).Value = EMAIL_PAC
            .Add("@ID_DIAGNOSTICO", OleDbType.Numeric).Value = ID_DIAGNOSTICO
            .Add("@OBS_PER", OleDbType.VarChar).Value = OBS_PER
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@DNI", OleDbType.VarChar).Value = dni
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
End Class