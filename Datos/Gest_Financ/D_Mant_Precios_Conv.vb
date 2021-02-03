'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Mant_Precios_Conv
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA(ByVal ID_PREV As Long, ByVal ID_YEAR As Long, ByVal ALL_EXA As Boolean) As List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_YEAR", OleDbType.Numeric).Value = ID_YEAR
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
            E_Proc_Item = New E_IRIS_WEBF_MANT_PRECIOS_CONV_SHOW_DATA

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_CONVENIO_OUT = DD_GEN.DB_NULL(Obj_Reader, 3, False)
            E_Proc_Item.ID_CF_PRECIO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CF_PRECIO_COSTO_DERIV = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.CF_PRECIO_COSTO_T = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.CF_PRECIO_PJE_LAB = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.CF_PRECIO_PJE_CONV = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.ID_AÑO = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.AÑO_COD = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.AÑO_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            E_Proc_Item.PREVE_COD = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA(ByVal ID_CODF As Long, ByVal ID_PREC As Long, ByVal BIT_CONV As Boolean, ByVal LNG_PREC As Long, ByVal LNG_DERI As Long, ByVal LNG_CTOT As Long, ByVal DBL_PJEC As Single, ByVal DBL_PJEL As Single) As Boolean
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CODF", OleDbType.Numeric).Value = ID_CODF
            .Add("@ID_PREC", OleDbType.Numeric).Value = ID_PREC
            .Add("@BIT_CONV", OleDbType.Boolean).Value = BIT_CONV
            .Add("@LNG_PREC", OleDbType.Numeric).Value = LNG_PREC
            .Add("@LNG_DERI", OleDbType.Numeric).Value = LNG_DERI
            .Add("@LNG_CTOT", OleDbType.Numeric).Value = LNG_CTOT
            .Add("@DBL_PJEC", OleDbType.Numeric).Value = DBL_PJEC
            .Add("@DBL_PJEL", OleDbType.Numeric).Value = DBL_PJEL
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
        Return True
    End Function

    Function IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA_WITH_IDCF_PREV_AND_YEAR(ByVal ID_CODF As Long, ByVal ID_PREV As Long, ByVal STR_YEAR As Integer, ByVal LNG_PREC As Long, ByVal LNG_DERI As Long, ByVal LNG_CTOT As Long, ByVal DBL_PJEC As Single, ByVal DBL_PJEL As Single) As Boolean
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_MANT_PRECIOS_CONV_WRITE_DATA_WITH_IDCF_PREV_AND_YEAR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CODF", OleDbType.Numeric).Value = ID_CODF
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_YEAR", OleDbType.Numeric).Value = STR_YEAR
            .Add("@LNG_PREC", OleDbType.Numeric).Value = LNG_PREC
            .Add("@LNG_DERI", OleDbType.Numeric).Value = LNG_DERI
            .Add("@LNG_CTOT", OleDbType.Numeric).Value = LNG_CTOT
            .Add("@DBL_PJEC", OleDbType.Numeric).Value = DBL_PJEC
            .Add("@DBL_PJEL", OleDbType.Numeric).Value = DBL_PJEL
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

        Return True
    End Function
End Class