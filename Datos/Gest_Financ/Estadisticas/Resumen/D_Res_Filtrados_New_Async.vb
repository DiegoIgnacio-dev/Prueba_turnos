'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Threading.Tasks
Imports System.Data.OleDb
Public Class D_Res_Filtrados_New_Async
    Dim DD_Gen As New D_General_Functions

    Public Function Busca_Atenciones(ByVal DATE_01 As Date, ByVal DATE_02 As Date,
                                           ByVal ID_PROC As Integer, ByVal ID_PREV As Integer,
                                           ByVal ID_PROG As Integer, ByVal ID_SUBP As Integer) As List(Of E_Async_Res_All)
        'Declaraciones SQL
        Dim CC_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_Proc_Item As E_Async_Res_All
        Dim E_Proc_List As New List(Of E_Async_Res_All)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_RESULTADOS_BUSCA_ATENCIONES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DATE_01", OleDbType.Date).Value = DATE_01
            .Add("@DATE_02", OleDbType.Date).Value = DATE_02
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SUBP", OleDbType.Numeric).Value = ID_SUBP
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
            E_Proc_Item = New E_Async_Res_All

            E_Proc_Item.ID_ATENCION = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_Gen.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.PAC_RUT = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.SEXO_DESC = DD_Gen.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_FNAC = DD_Gen.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.PROGRA_DESC = DD_Gen.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.SUBP_DESC = DD_Gen.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_OMI = DD_Gen.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.DOC_RUT = DD_Gen.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.DOC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 15, "")

            'Agregar elementos a la Lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function Busca_Atenciones_Values(ByVal ID_ATE As Integer, ByVal ALL_EXA As Boolean) As List(Of E_Async_Res_All_Values)
        'Declaraciones SQL
        Dim CC_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_Proc_Item As E_Async_Res_All_Values
        Dim E_Proc_List As New List(Of E_Async_Res_All_Values)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            If (ALL_EXA = True) Then
                .CommandText = "IRIS_WEBF_RESULTADOS_BUSCA_ATENCIONES_RESULTADOS"
            Else
                .CommandText = "IRIS_WEBF_RESULTADOS_BUSCA_ATENCIONES_RESULTADOS_GROUP"
            End If
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ALL_EXA", OleDbType.Boolean).Value = ALL_EXA
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
            E_Proc_Item = New E_Async_Res_All_Values

            E_Proc_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PRU_DESC = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_Gen.DB_NULL(Obj_Reader, 4, "").ToString.Trim
            E_Proc_Item.ATE_RESULTADO = DD_Gen.DB_NULL(Obj_Reader, 5, "").ToString.Trim
            E_Proc_Item.ATE_TXT_UNIDAD = DD_Gen.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_Gen.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_R_DESDE = DD_Gen.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_R_HASTA = DD_Gen.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_TIPO_DATO = DD_Gen.DB_NULL(Obj_Reader, 10, 0)

            'Agregar elementos a la Lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
