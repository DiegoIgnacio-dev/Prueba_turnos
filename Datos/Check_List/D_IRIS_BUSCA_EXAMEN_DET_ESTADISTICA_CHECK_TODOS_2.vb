'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2(ByVal DESDE As Date,
                                                               ByVal HASTA As Date,
                                                               ByVal ID_CF As Integer,
                                                               ByVal ID_PRUEBA As Integer,
                                                               ByVal ID_PROC As Integer,
                                                             ByVal Procedencia As Integer,
                                                             ByVal Ddl_previ As Integer,
                                                             ByVal Ddl_programa As Integer,
                                                             ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
            .Add("@Procedencia ", OleDbType.Numeric).Value = Procedencia
            .Add("@Ddl_previ ", OleDbType.Numeric).Value = Ddl_previ
            .Add("@Ddl_programa ", OleDbType.Numeric).Value = Ddl_programa
            .Add("@Ddl_subPrograma ", OleDbType.Numeric).Value = Ddl_subPrograma

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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE(ByVal DESDE As Date,
                                                             ByVal HASTA As Date,
                                                             ByVal ID_CF As Integer,
                                                             ByVal ID_PRUEBA As Integer,
                                                             ByVal ID_PROC As Integer,
                                                           ByVal Procedencia As Integer,
                                                           ByVal Ddl_previ As Integer,
                                                           ByVal Ddl_programa As Integer,
                                                           ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
            .Add("@Procedencia ", OleDbType.Numeric).Value = Procedencia
            .Add("@Ddl_previ ", OleDbType.Numeric).Value = Ddl_previ
            .Add("@Ddl_programa ", OleDbType.Numeric).Value = Ddl_programa
            .Add("@Ddl_subPrograma ", OleDbType.Numeric).Value = Ddl_subPrograma

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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO(ByVal DESDE As Date,
                                                         ByVal HASTA As Date,
                                                         ByVal ID_CF As Integer,
                                                         ByVal ID_PRUEBA As Integer,
                                                         ByVal ID_PROC As Integer,
                                                       ByVal Procedencia As Integer,
                                                       ByVal Ddl_previ As Integer,
                                                       ByVal Ddl_programa As Integer,
                                                       ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
            .Add("@Procedencia ", OleDbType.Numeric).Value = Procedencia
            .Add("@Ddl_previ ", OleDbType.Numeric).Value = Ddl_previ
            .Add("@Ddl_programa ", OleDbType.Numeric).Value = Ddl_programa
            .Add("@Ddl_subPrograma ", OleDbType.Numeric).Value = Ddl_subPrograma

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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            'E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            'E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.AUDI_FORMA = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 35, "-")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS(ByVal DESDE As Date,
                                                       ByVal HASTA As Date,
                                                       ByVal ID_CF As Integer,
                                                       ByVal ID_PRUEBA As Integer,
                                                       ByVal ID_PROC As Integer,
                                                     ByVal Procedencia As Integer,
                                                     ByVal Ddl_previ As Integer,
                                                     ByVal Ddl_programa As Integer,
                                                     ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
            .Add("@Procedencia ", OleDbType.Numeric).Value = Procedencia
            .Add("@Ddl_previ ", OleDbType.Numeric).Value = Ddl_previ
            .Add("@Ddl_programa ", OleDbType.Numeric).Value = Ddl_programa
            .Add("@Ddl_subPrograma ", OleDbType.Numeric).Value = Ddl_subPrograma

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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            'E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            'E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.AUDI_FORMA = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 35, "-")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION_RESU(ByVal DESDE As Date,
                                                      ByVal HASTA As Date,
                                                      ByVal ID_CF As Integer,
                                                      ByVal ID_PRUEBA As Integer,
                                                      ByVal ID_PROC As Integer,
                                                    ByVal Procedencia As Integer,
                                                    ByVal Ddl_previ As Integer,
                                                    ByVal Ddl_programa As Integer,
                                                    ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION_RESU"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
            .Add("@Procedencia ", OleDbType.Numeric).Value = Procedencia
            .Add("@Ddl_previ ", OleDbType.Numeric).Value = Ddl_previ
            .Add("@Ddl_programa ", OleDbType.Numeric).Value = Ddl_programa
            .Add("@Ddl_subPrograma ", OleDbType.Numeric).Value = Ddl_subPrograma

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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            'E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            'E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            'E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            'E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            'E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            'E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            'E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            'E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            'E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            'E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            'E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            'E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            'E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            'E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            'E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            'E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            'E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            'E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            'E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            'E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            'E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            'E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            'E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            'E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            'E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            'E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            'E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            'E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            ''E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            'E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            'E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            'E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            'E_Proc_Item.AUDI_FORMA = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 35, "-")
            E_Proc_Item.TOTAL = DD_GEN.DB_NULL(Obj_Reader, 2, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class

