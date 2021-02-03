'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Exa_Esp_V
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.Numeric).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.VarChar).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_PENDIENTES_CON_OMI(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_PENDIENTES_CON_OMI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.Numeric).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function

    Function IRIS_WEBF_CMVM_GRABA_REGISTRO_PENDIENTES(ByVal ID_USER As Integer,
                                                      ByVal CB_DESC As String,
                                                      ByVal ATE_NUM As String,
                                                      ByVal ATE_NUM_OMI As String,
                                                      ByVal ID_CODIGO_FONASA As Integer,
                                                      ByVal CF_DESC As String,
                                                      ByVal FECHA_PEND As Date,
                                                      ByVal USU_ID_PROC As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_REGISTRO_PENDIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@CB_DESC", OleDbType.VarChar).Value = CB_DESC
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ATE_NUM_OMI", OleDbType.VarChar).Value = ATE_NUM_OMI
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@CF_DESC", OleDbType.VarChar).Value = CF_DESC
            .Add("@FECHA_PEND", OleDbType.Date).Value = FECHA_PEND
            .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX_222"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.VarChar).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_SAYDEX(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ORDEN", OleDbType.Numeric).Value = ID_ATE
            .Add("@CODIGO_EXAMEN", OleDbType.Numeric).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SIDRA(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SIDRA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.VarChar).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function
End Class