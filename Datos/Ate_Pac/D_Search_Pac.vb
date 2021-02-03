Imports Conexion
Imports Entidades
Imports System.Data.OleDb

Public Class D_Search_Pac

    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC(ByVal ID_USER As Integer, ByVal PAC_RUT As String,
                                                               ByVal PAC_DNI As String, ByVal PAC_NAME As String,
                                                               ByVal PAC_LASTN As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER
            .Add("@PAC_RUT", OleDbType.VarChar).Value = PAC_RUT
            .Add("@PAC_DNI", OleDbType.VarChar).Value = PAC_DNI
            .Add("@PAC_NAME", OleDbType.VarChar).Value = PAC_NAME
            .Add("@PAC_LASTN", OleDbType.VarChar).Value = PAC_LASTN
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC

            E_Proc_Item.ID_PAC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 1, "-")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 2, "-")
            E_Proc_Item.PAC_NAME = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            'E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC(ByVal ID_USER As Integer, ByVal ID_PAC As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER
            .Add("@ID_PAC", OleDbType.BigInt).Value = ID_PAC
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC

            E_Proc_Item.ID_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PREV_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NAME = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.DOC_NAME = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ATE_NUM(ByVal ID_USER As Integer, ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ATE_NUM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC

            E_Proc_Item.ID_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PREV_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NAME = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.DOC_NAME = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            '.CommandTimeout = 60 * 60 * 60
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
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE

            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.EST_COD = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.USER_V = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.FECHA_V = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
