'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Ate_Resultados_Info
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_RESULTADOS_PACIENTE_DATA(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
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
        Dim E_Proc_Item As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

        While Obj_Reader.Read
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.SEXO_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.ID_SECTOR = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.CANT_HIST = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 24, "")
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
End Class