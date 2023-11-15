'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Login2
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(ByVal USER As String, ByVal PASS As String) As E_Login2
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_Login2

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Test
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@USER", OleDbType.VarChar).Value = USER
            .Add("@PASS", OleDbType.VarChar).Value = PASS
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
            E_Proc_Item.LOGGED = True
            E_Proc_Item.ID_USER = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.NICKNAME = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.P_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.RUT = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.NAME = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.SURNAME = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.USU_ID_PROC = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.USU_PREV = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_PROF = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.USU_RUT_IMED = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.USU_PASS_IMED = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
End Class
