'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_DETALLE_PREINGRESO(ByVal ID_ATE As Integer,
                                                ByVal ID_USUARIO As Integer,
                                                ByVal ID_CF As Integer,
                                                ByVal ID_PER As Integer,
                                                ByVal ID_TP_PAGO As Integer,
                                                ByVal ATE_DET_DOC As Integer,
                                                ByVal ATE_DET_V_PREVI As Integer,
                                                ByVal ATE_DET_V_PAGADO As Integer,
                                                ByVal ATE_DET_V_CCOPAGO As Integer,
                                                Optional ByVal HO_CC As String = "0") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_PREINGRESO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTER", OleDbType.VarChar).Value = HO_CC
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
    Function IRIS_WEBF_GRABA_DETALLE_PREINGRESO_SIDRA(ByVal ID_ATE As Integer,
                                             ByVal ID_USUARIO As Integer,
                                             ByVal ID_CF As Integer,
                                             ByVal ID_PER As Integer,
                                             ByVal ID_TP_PAGO As Integer,
                                             ByVal ATE_DET_DOC As Integer,
                                             ByVal ATE_DET_V_PREVI As Integer,
                                             ByVal ATE_DET_V_PAGADO As Integer,
                                             ByVal ATE_DET_V_CCOPAGO As Integer,
                                             Optional ByVal HO_CC As String = "0") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_PREINGRESO_2_SIDRA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTER", OleDbType.VarChar).Value = HO_CC
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
