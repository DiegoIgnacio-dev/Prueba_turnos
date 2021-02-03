﻿
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.numeric).Value = ID_PROC
            .Add("@ID_CF", OleDbType.numeric).Value = ID_CF
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
