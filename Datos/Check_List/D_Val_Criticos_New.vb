Imports Conexion
Imports Entidades
Imports System.Data.OleDb

Public Class D_Val_Criticos_New
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Public Function IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT(ByVal DATE_01 As Date, ByVal DATE_02 As Date,
                                                                             ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                                                             ByVal ID_CODF As Long, ByVal ID_CRIT As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DATE_01", OleDbType.Date).Value = DATE_01
            .Add("@DATE_02", OleDbType.Date).Value = DATE_02
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_CODF", OleDbType.Numeric).Value = ID_CODF
            .Add("@ID_CRIT", OleDbType.Numeric).Value = ID_CRIT
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_DCTO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NAME = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CODF_COD = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.CODF_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.EST_VALIDAC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.FECHA_VALIDAC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.TIPO_RES = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PRU_VALUE = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ALARMA = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.FECHA_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
