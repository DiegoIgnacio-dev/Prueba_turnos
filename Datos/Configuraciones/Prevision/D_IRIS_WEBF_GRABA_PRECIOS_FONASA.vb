﻿'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_GRABA_PRECIOS_FONASA
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_GRABA_PRECIOS_FONASA(ByVal ID_PREVI As Integer, ByVal ID_CF As Integer, ByVal ID_ANO As Integer, ByVal ID_USUARO As Integer, ByVal V_AMB As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_PRECIOS_FONASA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREVI", OleDbType.Numeric).Value = ID_PREVI
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_AÑO", OleDbType.Numeric).Value = ID_ANO
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARO
            .Add("@V_AMB", OleDbType.Numeric).Value = V_AMB
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function
    Function IRIS_WEBF_CMVM_GRABA_PRECIOS_FONASA_BONIFICACION(ByVal ID_PREVI As Integer, ByVal ID_CF As Integer, ByVal ID_ANO As Integer, ByVal ID_USUARO As Integer, ByVal V_AMB As Integer, ByVal BONIFICACION As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_PRECIOS_FONASA_BONIFICACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREVI", OleDbType.Numeric).Value = ID_PREVI
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_AÑO", OleDbType.Numeric).Value = ID_ANO
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARO
            .Add("@V_AMB", OleDbType.Numeric).Value = V_AMB
            .Add("@BONIFICACION", OleDbType.Numeric).Value = BONIFICACION
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function
End Class
