﻿Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_BUSCA_NIVEL_ACTIVO
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_BUSCA_NIVEL_ACTIVO() As List(Of E_IRIS_QC_BUSCA_NIVEL_ACTIVO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_NIVEL_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_NIVEL_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_QC_BUSCA_NIVEL_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_QC_BUSCA_NIVEL_ACTIVO
            E_Proc_Item.ID_QC_NIVEL = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.QC_NIVEL_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class