'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Ate_Resultados
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_GRABA_REL_PANEL_ANTIB(ByVal ID_ATE As Long, ByVal ID_CF_CULT As Integer, ByVal ID_PANEL As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_GRABA_REL_PANEL_ANTIB"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF_CULT", OleDbType.Numeric).Value = ID_CF_CULT
            .Add("@ID_PANEL", OleDbType.Numeric).Value = ID_PANEL
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function
    Function IRIS_WEBF_QUITA_PANEL_ANTIB(ByVal ID_ATE As Long, ByVal ID_CF_CULT As Integer, ByVal ID_PANEL As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_QUITA_PANEL_ANTIB"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF_CULT", OleDbType.Numeric).Value = ID_CF_CULT
            .Add("@ID_PANEL", OleDbType.Numeric).Value = ID_PANEL
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function
    Function IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ANTIBIOGRAMAS_CARGADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_COD_FONASA", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS

            E_Proc_Item.ID_REL_CF_ANTIB = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_CF_ANTIBIOGRAMA = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.CF_DESC_CULT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_COD_FONASA", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Obj_Reader, 6, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_BY_ID(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal ID_CF As Integer) As E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        'Declaraciones

        Dim Obj_Reader As OleDbDataReader
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCION_CODIGO_FONASA_BY_ID"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ANO", OleDbType.VarChar).Value = ANO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CF_PRECIO_HOS = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.AÑO_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DIAS = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_CF_PRECIO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista

        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2(ByVal ID_ATE As Long,
                                                                     ByVal ID_SECCION As Long,
                                                                     ByVal ID_EXAMEN As Long,
                                                                     ByVal R_DIA As Integer,
                                                                     ByVal R_MES As Integer,
                                                                     ByVal R_AÑO As Integer) As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_DETALLE_SECCION_EXAMEN_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_EXAMEN", OleDbType.Numeric).Value = ID_EXAMEN
            .Add("@R_DIA", OleDbType.Numeric).Value = R_DIA
            .Add("@R_MES", OleDbType.Numeric).Value = R_MES
            .Add("@R_AÑO", OleDbType.Numeric).Value = R_AÑO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2

            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_U_MEDIDA_1 = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.PRU_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 13, "").trim()
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.CF_CORTO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 16, 0)
            E_Proc_Item.ID_U_MEDIDA_2 = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 18, 0)
            E_Proc_Item.PRU_RESU_INMEDIATO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.EST_COD = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 27, 0)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 28, 0)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 29, 0)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.REQ_RES_VAL = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.RES_HIST = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.RES_HIST_NUM = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.RES_HIST_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Date.Now)
            E_Proc_Item.RES_HIST_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Date.Now)

            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 38, "")
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 39, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION(ByVal ID_ATE As Long, ByVal ID_PAC As Long, ByVal ID_PRU As Long) As List(Of E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = Integer.MaxValue
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters '[dbo].[IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA]
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION

            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA_2(ByVal ID_PRU As Long, ByVal SEXO As String, ByVal ID_ATE_RES As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_RANGO_REFERENCIA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
            If (IsNothing(SEXO) = True) Then
                .Add("@SEXO", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@SEXO", OleDbType.VarChar).Value = SEXO
            End If
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA

            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.RF_ANO_DESDE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.RF_MESES_DESDE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.RF_DIAS_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.RF_ANO_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.RF_MESES_HASTA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.RF_DIAS_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ByVal ID_PRU As Long, ByVal SEXO As String) As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_RANGO_REFERENCIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
            If (IsNothing(SEXO) = True) Then
                .Add("@SEXO", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@SEXO", OleDbType.VarChar).Value = SEXO
            End If

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA

            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.RF_ANO_DESDE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.RF_MESES_DESDE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.RF_DIAS_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.RF_V_DESDE = CDbl(DD_GEN.DB_NULL(Obj_Reader, 6, 0))
            E_Proc_Item.RF_V_HASTA = CDbl(DD_GEN.DB_NULL(Obj_Reader, 7, 0))
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.RF_ANO_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.RF_MESES_HASTA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.RF_DIAS_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_SECCION_POR_ID_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_SECCION = DD_GEN.DB_NULL(Obj_Reader, 4, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_EXAMENES_POR_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION

            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION(ByVal ID_ATE As Long, ByVal ID_RLS As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_RLS", OleDbType.Numeric).Value = ID_RLS
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION

            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 6, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ByVal ID_RES As Integer, ByVal RES As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_EXAMEN_TEXTO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_RES
            .Add("@RESULTADO", OleDbType.VarChar).Value = RES
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Sub IRIS_WEBF_GRABA_CONTROL_AUDITORIA(ByVal ID_USER As Integer, ByVal ACTION As String, ByVal FORM As String, ByVal ID_ATE_RES As Long)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_GRABA_CONTROL_AUDITORIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USER
            .Add("@ACCION", OleDbType.VarChar).Value = ACTION
            .Add("@FORMA", OleDbType.VarChar).Value = FORM
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ByVal ID_RES As Integer, ByVal RES As String, ByVal EVAL As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_EXAMEN_NUMERICO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_RES
            .Add("@RESULTADO", OleDbType.VarChar).Value = RES
            .Add("@ALTOBAJO", OleDbType.VarChar).Value = EVAL
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Function IRIS_WEBF_BUSCA_CONTROL_AUDITORIA(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_CONTROL_AUDITORIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA

            E_Proc_Item.AUDI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 0, New Date)
            E_Proc_Item.AUDI_ACCION = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.AUDI_FORMA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Sub IRIS_WEBF_UPDATE_VALIDA_RESULTADO(ByVal ID_ATE_RES As Integer, ByVal ID_USUARIO As Integer, ByVal DESDE As String, ByVal HASTA As String, ByVal AB As String, ByVal MUY_DESDE As String, ByVal MUY_HASTA As String, ByVal MUY_AB As Integer, ByVal UNIDADES As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_VALIDACION_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@DESDE", OleDbType.VarChar).Value = IIf(IsNothing(DESDE) = True, DBNull.Value, DESDE)
            .Add("@HASTA", OleDbType.VarChar).Value = IIf(IsNothing(HASTA) = True, DBNull.Value, HASTA)
            .Add("@AB", OleDbType.VarChar).Value = IIf(IsNothing(AB) = True, DBNull.Value, AB)
            .Add("@MUY_DESDE", OleDbType.VarChar).Value = IIf(IsNothing(MUY_DESDE) = True, DBNull.Value, MUY_DESDE)
            .Add("@MUY_HASTA", OleDbType.VarChar).Value = IIf(IsNothing(MUY_HASTA) = True, DBNull.Value, MUY_HASTA)
            .Add("@MUY_AB", OleDbType.Numeric).Value = IIf(IsNothing(MUY_AB) = True, DBNull.Value, MUY_AB)
            .Add("@UNIDADES", OleDbType.VarChar).Value = IIf(IsNothing(UNIDADES) = True, DBNull.Value, UNIDADES)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Sub IRIS_WEBF_UPDATE_DESVALIDA_RESULTADO(ByVal ID_ATE_RES As Integer, ByVal ID_USUARIO As Integer)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_DESVALIDACION_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Function IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS(ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS

            E_Proc_Item.ID_REL_PRU_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_RES_COD = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.RES_COD_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.RES_COD_COD = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R(ByVal ID_ATE As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                          ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                          ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                          ByVal ID_USER As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            '.Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
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
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R_2(ByVal ATE_NUM As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                          ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                          ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                          ByVal ID_USER As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            '.Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
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
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO() As List(Of E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_TIPO_CLIENTE_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        ''Enviar parámetros
        'With Cmd_SQL.Parameters

        'End With

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO

            E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.INTEXT_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.INTEXT_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO(ByVal ID_ATE As Long) As E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        E_Proc_Item.ID_PAC = 0
        E_Proc_Item.CANT_ATE = 0
        E_Proc_Item.CANT_EXA = 0

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item.ID_PAC = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CANT_ATE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.CANT_EXA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(ByVal NUM_ATE As Long, ByVal ID_USER As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_ATE", OleDbType.BigInt).Value = NUM_ATE
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim Response As Long
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            Response = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return Response
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS(ByVal ID_ATE As Long, ByVal ID_PRU As Long, ByVal BL_ALL As Boolean) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS)
        Dim obj_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_PRU", OleDbType.BigInt).Value = ID_PRU
            .Add("@BL_ALL", OleDbType.Boolean).Value = BL_ALL
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
            obj_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS

            obj_Item.ID_ATE = DD_GEN.DB_NULL(Obj_Reader, 0)
            obj_Item.NN_ATE = DD_GEN.DB_NULL(Obj_Reader, 1)
            obj_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2)
            obj_Item.ATE_R_VALUE = DD_GEN.DB_NULL(Obj_Reader, 3)
            obj_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4)
            obj_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 5)
            obj_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 6)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return obj_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE)
        Dim obj_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE"
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
        While Obj_Reader.Read
            obj_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE

            obj_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0)
            obj_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1)
            obj_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2)
            obj_Item.EXA_COUNT = DD_GEN.DB_NULL(Obj_Reader, 3)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return obj_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF(ByVal ID_ATE As Long, ByVal ID_CF As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU)
        Dim obj_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 1000 * 60 * 5
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
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
            obj_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU

            obj_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0)
            obj_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1)
            obj_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2)
            obj_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3)
            obj_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 4)
            obj_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 5)
            obj_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 6)
            obj_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 7)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return obj_List
    End Function

    Public Class EE_Check_Valida
        Private EE_ID_DET_ATE As Long
        Public Property ID_DET_ATE() As Long
            Get
                Return EE_ID_DET_ATE
            End Get
            Set(ByVal value As Long)
                EE_ID_DET_ATE = value
            End Set
        End Property
    End Class

    Function IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA(ByVal ID_ATE As Long, ByVal ID_CF As Long) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of EE_Check_Valida)
        Dim obj_Item As EE_Check_Valida

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 1000 * 60 * 5
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
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
            obj_Item = New EE_Check_Valida

            obj_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()

        If obj_List.Count > 0 Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class