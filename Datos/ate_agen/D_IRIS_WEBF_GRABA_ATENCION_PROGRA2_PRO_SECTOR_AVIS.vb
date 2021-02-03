'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS(ByVal ATE_NUM As String,
                                                              ByVal ID_PACIENTE As Integer,
                                                              ByVal ID_USUARIO As Integer,
                                                              ByVal ATE_FUR As String,
                                                              ByVal ID_PROCE As Integer,
                                                              ByVal ID_ORDEN As Integer,
                                                              ByVal ID_TP_PACI As Integer,
                                                              ByVal ID_DOCTOR As Integer,
                                                              ByVal ID_PREVE As Integer,
                                                              ByVal ID_LOCAL As Integer,
                                                              ByVal ID_ESTADO As Integer,
                                                              ByVal ATE_OBS As String,
                                                              ByVal ATE_CAMA As String,
                                                              ByVal ATE_AÑO As Integer,
                                                              ByVal ATE_MES As Integer,
                                                              ByVal ATE_DIA As Integer,
                                                              ByVal ATE_TOTAL As Integer,
                                                              ByVal ATE_TOTAL_PREVI As Integer,
                                                              ByVal ATE_TOTAL_COPA As Integer,
                                                              ByVal ID_PROGRA As Integer,
                                                              ByVal ATE_RETIRO As String,
                                                              ByVal SECTOR As Integer,
                                                              ByVal ATE_AVIS As String,
                                                              ByVal Interno As String,
                                                                ByVal Diag As String,
                                                              ByVal Diag2 As String,
                                                              ByVal VIH As String,
                                                              ByVal dni As String,
                                                              ByVal ATE_TM As String, ByVal SUB_PROGRAMA As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_8_NEW"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM

            .Add("@SUB_PROGRAMA", OleDbType.VarChar).Value = SUB_PROGRAMA
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

    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_OMI(ByVal ATE_NUM As String,
                                                              ByVal ID_PACIENTE As Integer,
                                                              ByVal ID_USUARIO As Integer,
                                                              ByVal ATE_FUR As String,
                                                              ByVal ID_PROCE As Integer,
                                                              ByVal ID_ORDEN As Integer,
                                                              ByVal ID_TP_PACI As Integer,
                                                              ByVal ID_DOCTOR As Integer,
                                                              ByVal ID_PREVE As Integer,
                                                              ByVal ID_LOCAL As Integer,
                                                              ByVal ID_ESTADO As Integer,
                                                              ByVal ATE_OBS As String,
                                                              ByVal ATE_CAMA As String,
                                                              ByVal ATE_AÑO As Integer,
                                                              ByVal ATE_MES As Integer,
                                                              ByVal ATE_DIA As Integer,
                                                              ByVal ATE_TOTAL As Integer,
                                                              ByVal ATE_TOTAL_PREVI As Integer,
                                                              ByVal ATE_TOTAL_COPA As Integer,
                                                              ByVal ID_PROGRA As Integer,
                                                              ByVal ATE_RETIRO As String,
                                                              ByVal SECTOR As Integer,
                                                              ByVal ATE_AVIS As String,
                                                              ByVal Interno As String,
                                                                ByVal Diag As String,
                                                              ByVal Diag2 As String,
                                                              ByVal VIH As String,
                                                              ByVal dni As String,
                                                             ByVal ID_SUBP As Long) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_OMI_2_NEW"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
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
        Reader_Comm = Cmd_SQL.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function

    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX(ByVal ATE_NUM As String,
                                                          ByVal ID_PACIENTE As Integer,
                                                          ByVal ID_USUARIO As Integer,
                                                          ByVal ATE_FUR As String,
                                                          ByVal ID_PROCE As Integer,
                                                          ByVal ID_ORDEN As Integer,
                                                          ByVal ID_TP_PACI As Integer,
                                                          ByVal ID_DOCTOR As Integer,
                                                          ByVal ID_PREVE As Integer,
                                                          ByVal ID_LOCAL As Integer,
                                                          ByVal ID_ESTADO As Integer,
                                                          ByVal ATE_OBS As String,
                                                          ByVal ATE_CAMA As String,
                                                          ByVal ATE_AÑO As Integer,
                                                          ByVal ATE_MES As Integer,
                                                          ByVal ATE_DIA As Integer,
                                                          ByVal ATE_TOTAL As Integer,
                                                          ByVal ATE_TOTAL_PREVI As Integer,
                                                          ByVal ATE_TOTAL_COPA As Integer,
                                                          ByVal ID_PROGRA As Integer,
                                                          ByVal ATE_RETIRO As String,
                                                          ByVal SECTOR As Integer,
                                                          ByVal ATE_AVIS As String,
                                                          ByVal Interno As String,
                                                            ByVal Diag As String,
                                                          ByVal Diag2 As String,
                                                          ByVal VIH As String,
                                                          ByVal dni As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            'If (ATE_AVIS = Nothing) Then
            '    .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            'Else
            '    .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            'End If
            '.Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            '.Add("@Diag", OleDbType.Numeric).Value = Diag
            '.Add("@Diag2", OleDbType.Numeric).Value = Diag2
            '.Add("@VIH", OleDbType.VarChar).Value = VIH
            '.Add("@DNI", OleDbType.VarChar).Value = dni



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

    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX_POSTA(ByVal ATE_NUM As String,
                                                      ByVal ID_PACIENTE As Integer,
                                                      ByVal ID_USUARIO As Integer,
                                                      ByVal ATE_FUR As String,
                                                      ByVal ID_PROCE As Integer,
                                                      ByVal ID_ORDEN As Integer,
                                                      ByVal ID_TP_PACI As Integer,
                                                      ByVal ID_DOCTOR As Integer,
                                                      ByVal ID_PREVE As Integer,
                                                      ByVal ID_LOCAL As Integer,
                                                      ByVal ID_ESTADO As Integer,
                                                      ByVal ATE_OBS As String,
                                                      ByVal ATE_CAMA As String,
                                                      ByVal ATE_AÑO As Integer,
                                                      ByVal ATE_MES As Integer,
                                                      ByVal ATE_DIA As Integer,
                                                      ByVal ATE_TOTAL As Integer,
                                                      ByVal ATE_TOTAL_PREVI As Integer,
                                                      ByVal ATE_TOTAL_COPA As Integer,
                                                      ByVal ID_PROGRA As Integer,
                                                      ByVal ATE_RETIRO As String,
                                                      ByVal SECTOR As Integer,
                                                      ByVal ATE_AVIS As String,
                                                      ByVal Interno As String,
                                                        ByVal Diag As String,
                                                      ByVal Diag2 As String,
                                                      ByVal VIH As String,
                                                      ByVal dni As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX_3_NEW_POSTA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni

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
    Function IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SIDRA(ByVal ATE_NUM As String,
                                                          ByVal ID_PACIENTE As Integer,
                                                          ByVal ID_USUARIO As Integer,
                                                          ByVal ATE_FUR As String,
                                                          ByVal ID_PROCE As Integer,
                                                          ByVal ID_ORDEN As Integer,
                                                          ByVal ID_TP_PACI As Integer,
                                                          ByVal ID_DOCTOR As Integer,
                                                          ByVal ID_PREVE As Integer,
                                                          ByVal ID_LOCAL As Integer,
                                                          ByVal ID_ESTADO As Integer,
                                                          ByVal ATE_OBS As String,
                                                          ByVal ATE_CAMA As String,
                                                          ByVal ATE_AÑO As Integer,
                                                          ByVal ATE_MES As Integer,
                                                          ByVal ATE_DIA As Integer,
                                                          ByVal ATE_TOTAL As Integer,
                                                          ByVal ATE_TOTAL_PREVI As Integer,
                                                          ByVal ATE_TOTAL_COPA As Integer,
                                                          ByVal ID_PROGRA As Integer,
                                                          ByVal ATE_RETIRO As String,
                                                          ByVal SECTOR As Integer,
                                                          ByVal ATE_AVIS As String,
                                                          ByVal Interno As String,
                                                            ByVal Diag As String,
                                                          ByVal Diag2 As String,
                                                          ByVal VIH As String,
                                                          ByVal dni As String,
                                                          ByVal ATE_TM As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SIDRA_8_NEW"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM
            .Add("@SUB_PROGRAMA", OleDbType.VarChar).Value = 1

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

    Function IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA(ByVal ATE_NUM As String,
                                                       ByVal ID_PACIENTE As Integer,
                                                       ByVal ID_USUARIO As Integer,
                                                       ByVal ATE_FUR As String,
                                                       ByVal ID_PROCE As Integer,
                                                       ByVal ID_ORDEN As Integer,
                                                       ByVal ID_TP_PACI As Integer,
                                                       ByVal ID_DOCTOR As Integer,
                                                       ByVal ID_PREVE As Integer,
                                                       ByVal ID_LOCAL As Integer,
                                                       ByVal ID_ESTADO As Integer,
                                                       ByVal ATE_OBS As String,
                                                       ByVal ATE_CAMA As String,
                                                       ByVal ATE_AÑO As Integer,
                                                       ByVal ATE_MES As Integer,
                                                       ByVal ATE_DIA As Integer,
                                                       ByVal ATE_TOTAL As Integer,
                                                       ByVal ATE_TOTAL_PREVI As Integer,
                                                       ByVal ATE_TOTAL_COPA As Integer,
                                                       ByVal ID_PROGRA As Integer,
                                                       ByVal ATE_RETIRO As String,
                                                       ByVal SECTOR As Integer,
                                                       ByVal ATE_AVIS As String,
                                                       ByVal Interno As String,
                                                         ByVal Diag As String,
                                                       ByVal Diag2 As String,
                                                       ByVal VIH As String,
                                                       ByVal dni As String,
                                                       ByVal ATE_TM As String,
                                                       ByVal ATE_V_SISTEMA As Integer,                  '1      'PARÁMETROS  CAJA
                                                       ByVal ATE_V_BENEF As Integer,                    '2
                                                       ByVal ATE_V_CF As Integer,                       '3
                                                       ByVal ATE_V_CF_FP As Integer,                    '4
                                                       ByVal ATE_V_CP As Integer,                       '5
                                                       ByVal ATE_V_CP_FP As Integer,                    '6
                                                       ByVal ATE_V_BOLETA As Integer,                   '7
                                                       ByVal ATE_V_PAGADO As Integer,                   '8
                                                        ByVal ATE_V_SEG_COMP As Integer) As Integer     '9
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM
            '-------------------------------------------- CAJA ------------------------------------------
            .Add("@ATE_V_SISTEMA", OleDbType.Numeric).Value = ATE_V_SISTEMA     '1
            .Add("@ATE_V_BENEF", OleDbType.Numeric).Value = ATE_V_BENEF         '2
            .Add("@ATE_V_CF", OleDbType.Numeric).Value = ATE_V_CF               '3
            .Add("@ATE_V_CF_FP", OleDbType.Numeric).Value = ATE_V_CF_FP         '4
            .Add("@ATE_V_CP", OleDbType.Numeric).Value = ATE_V_CP               '5
            .Add("@ATE_V_CP_FP", OleDbType.Numeric).Value = ATE_V_CP_FP         '6
            .Add("@ATE_V_BOLETA", OleDbType.Numeric).Value = ATE_V_BOLETA       '7
            .Add("@ATE_V_PAGADO", OleDbType.Numeric).Value = ATE_V_PAGADO       '8
            .Add("@ATE_V_SEG_COMP", OleDbType.Numeric).Value = ATE_V_SEG_COMP    '9


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
    Function IRIS_WEBF_CMVM_GRABA_REL_COPAGO(ByVal ID_ATENCION As Integer,
                                            ByVal ID_USUARIO As Integer,
                                            ByVal ATE_FECHA As Date,
                                             ByVal ATE_VALOR_COPAGO_1 As String,                '1 VALOR COPAGO 1
                                             ByVal ATE_TP_COPAGO_1 As String,                   '2 TIPO COPAGO 1
                                             ByVal ATE_VALOR_COPAGO_2 As String,                '3 VALOR COPAGO 2
                                             ByVal ATE_TP_COPAGO_2 As String,                   '4 TIPO COPAGO 2
                                             ByVal ATE_V_CP_FP_2 As Integer,                    '5 TIPO PARTICULAR
                                             ByVal ATE_V_CP_2 As String,                        '6 VALOR PARTICULAR
                                             ByVal ATE_TP_PARTICULAR_1 As String,
                                             ByVal ATE_VALOR_PARTICULAR_1 As String,
                                             ByVal ATE_TP_PARTICULAR_2 As String,
                                             ByVal ATE_VALOR_PARTICULAR_2 As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_REL_COPAGO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@ATE_FECHA", OleDbType.Date).Value = ATE_FECHA
            .Add("@ATE_TP_COPAGO_1", OleDbType.Integer).Value = ATE_VALOR_COPAGO_1
            .Add("@ATE_VALOR_COPAGO_1", OleDbType.VarChar).Value = ATE_TP_COPAGO_1
            .Add("@ATE_TP_COPAGO_2", OleDbType.Integer).Value = ATE_VALOR_COPAGO_2
            .Add("@ATE_VALOR_COPAGO_2", OleDbType.VarChar).Value = ATE_TP_COPAGO_2
            .Add("@ATE_TP_PARTICULAR", OleDbType.Integer).Value = ATE_TP_PARTICULAR_1
            .Add("@ATE_VALOR_PARTICULAR", OleDbType.VarChar).Value = ATE_VALOR_PARTICULAR_1
            .Add("@ATE_TP_PARTICULAR_2", OleDbType.Integer).Value = ATE_TP_PARTICULAR_2
            .Add("@ATE_VALOR_PARTICULAR_2", OleDbType.VarChar).Value = ATE_VALOR_PARTICULAR_2

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
    Function IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC(ByVal ATE_NUM As String,
                                                      ByVal ID_PACIENTE As Integer,
                                                      ByVal ID_USUARIO As Integer,
                                                      ByVal ATE_FUR As String,
                                                      ByVal ID_PROCE As Integer,
                                                      ByVal ID_ORDEN As Integer,
                                                      ByVal ID_TP_PACI As Integer,
                                                      ByVal ID_DOCTOR As Integer,
                                                      ByVal ID_PREVE As Integer,
                                                      ByVal ID_LOCAL As Integer,
                                                      ByVal ID_ESTADO As Integer,
                                                      ByVal ATE_OBS As String,
                                                      ByVal ATE_CAMA As String,
                                                      ByVal ATE_AÑO As Integer,
                                                      ByVal ATE_MES As Integer,
                                                      ByVal ATE_DIA As Integer,
                                                      ByVal ATE_TOTAL As Integer,
                                                      ByVal ATE_TOTAL_PREVI As Integer,
                                                      ByVal ATE_TOTAL_COPA As Integer,
                                                      ByVal ID_PROGRA As Integer,
                                                      ByVal ATE_RETIRO As String,
                                                      ByVal SECTOR As Integer,
                                                      ByVal ATE_AVIS As String,
                                                      ByVal Interno As String,
                                                        ByVal Diag As String,
                                                      ByVal Diag2 As String,
                                                      ByVal VIH As String,
                                                      ByVal dni As String,
                                                      ByVal ATE_TM As String,
                                                      ByVal ATE_V_SISTEMA As Integer,                  '1      'PARÁMETROS  CAJA
                                                      ByVal ATE_V_BENEF As Integer,                    '2
                                                      ByVal ATE_V_CF As Integer,                       '3
                                                      ByVal ATE_V_CF_FP As Integer,                    '4
                                                      ByVal ATE_V_CP As Integer,                       '5
                                                      ByVal ATE_V_CP_FP As Integer,                    '6
                                                      ByVal ATE_V_BOLETA As Integer,                   '7
                                                      ByVal ATE_V_PAGADO As Integer,                   '8
                                                       ByVal ATE_V_SEG_COMP As Integer,                 '9
                                                        ByVal ATE_V_SC_2 As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM
            '-------------------------------------------- CAJA ------------------------------------------
            .Add("@ATE_V_SISTEMA", OleDbType.Numeric).Value = ATE_V_SISTEMA     '1
            .Add("@ATE_V_BENEF", OleDbType.Numeric).Value = ATE_V_BENEF         '2
            .Add("@ATE_V_CF", OleDbType.Numeric).Value = ATE_V_CF               '3
            .Add("@ATE_V_CF_FP", OleDbType.Numeric).Value = ATE_V_CF_FP         '4
            .Add("@ATE_V_CP", OleDbType.Numeric).Value = ATE_V_CP               '5
            .Add("@ATE_V_CP_FP", OleDbType.Numeric).Value = ATE_V_CP_FP         '6
            .Add("@ATE_V_BOLETA", OleDbType.Numeric).Value = ATE_V_BOLETA       '7
            .Add("@ATE_V_PAGADO", OleDbType.Numeric).Value = ATE_V_PAGADO       '8
            .Add("@ATE_V_SEG_COMP", OleDbType.Numeric).Value = ATE_V_SEG_COMP    '9
            '----------------------------------- FIN CAJA -------------------------------
            .Add("@ATE_V_SC_2", OleDbType.Numeric).Value = ATE_V_SEG_COMP       'SEGURO COMPLEMENTARIO EN TABLA IRIS_ATENCION


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
    Function IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ByVal ID_ATENCION As Integer,
                                                                                                    ByVal VALOR_PREVI As Integer,
                                                                                                    ByVal VALOR_BENEFI As Integer,
                                                                                                    ByVal VALOR_SC As Integer,
                                                                                                    ByVal VALOR_PAGADO As Integer,
                                                                                                    ByVal VALOR_CF As Integer,
                                                                                                    ByVal VALOR_CP As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As Integer
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
            .Add("@VALOR_PREVI", OleDbType.Integer).Value = VALOR_PREVI
            .Add("@VALOR_BENEFI", OleDbType.Integer).Value = VALOR_BENEFI
            .Add("@VALOR_SC", OleDbType.Integer).Value = VALOR_SC
            .Add("@VALOR_PAGADO", OleDbType.Integer).Value = VALOR_PAGADO
            .Add("@VALOR_CF", OleDbType.Integer).Value = VALOR_CF
            .Add("@VALOR_CP", OleDbType.Integer).Value = VALOR_CP


        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteNonQuery
        'While Reader_Comm.Read
        '    Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        'End While
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function

    Function IRIS_WEBF_CMVM_GRABA_LOG_IMED_VTABONINTERFAZ(ByVal ID_USUARIO As Integer,
                                                          ByVal ID_PROCEDENCIA As Integer,
                                                          ByVal ID_PREVISION As Integer,
                                                          ByVal RUT_PAC_LOG As String,
                                                          ByVal MENSAJE_LOG As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0

        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_LOG_IMED_VTABONINTERFAZ"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@ID_PREVISION", OleDbType.Numeric).Value = ID_PREVISION
            .Add("@RUT_PAC_LOG", OleDbType.VarChar).Value = RUT_PAC_LOG
            .Add("@MENSAJE_LOG", OleDbType.VarChar).Value = MENSAJE_LOG
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Read_Dt = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
    Function IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_MAS_BONOS_IMED(ByVal ATE_NUM As String,
                                                    ByVal ID_PACIENTE As Integer,
                                                    ByVal ID_USUARIO As Integer,
                                                    ByVal ATE_FUR As String,
                                                    ByVal ID_PROCE As Integer,
                                                    ByVal ID_ORDEN As Integer,
                                                    ByVal ID_TP_PACI As Integer,
                                                    ByVal ID_DOCTOR As Integer,
                                                    ByVal ID_PREVE As Integer,
                                                    ByVal ID_LOCAL As Integer,
                                                    ByVal ID_ESTADO As Integer,
                                                    ByVal ATE_OBS As String,
                                                    ByVal ATE_CAMA As String,
                                                    ByVal ATE_AÑO As Integer,
                                                    ByVal ATE_MES As Integer,
                                                    ByVal ATE_DIA As Integer,
                                                    ByVal ATE_TOTAL As Integer,
                                                    ByVal ATE_TOTAL_PREVI As Integer,
                                                    ByVal ATE_TOTAL_COPA As Integer,
                                                    ByVal ID_PROGRA As Integer,
                                                    ByVal ATE_RETIRO As String,
                                                    ByVal SECTOR As Integer,
                                                    ByVal ATE_AVIS As String,
                                                    ByVal Interno As String,
                                                      ByVal Diag As String,
                                                    ByVal Diag2 As String,
                                                    ByVal VIH As String,
                                                    ByVal dni As String,
                                                    ByVal ATE_TM As String,
                                                    ByVal ATE_V_SISTEMA As Integer,                  '1      'PARÁMETROS  CAJA
                                                    ByVal ATE_V_BENEF As Integer,                    '2
                                                    ByVal ATE_V_CF As Integer,                       '3
                                                    ByVal ATE_V_CF_FP As Integer,                    '4
                                                    ByVal ATE_V_CP As Integer,                       '5
                                                    ByVal ATE_V_CP_FP As Integer,                    '6
                                                    ByVal ATE_V_BOLETA As Integer,                   '7
                                                    ByVal ATE_V_PAGADO As Integer,                   '8
                                                     ByVal ATE_V_SEG_COMP As Integer,                 '9
                                                      ByVal ATE_V_SC_2 As Integer,
                                                    ByVal GLOBAL_BONO_NUM As String) As Integer     '10
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_MAS_BONOS_IMED"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM
            '-------------------------------------------- CAJA ------------------------------------------
            .Add("@ATE_V_SISTEMA", OleDbType.Numeric).Value = ATE_V_SISTEMA     '1
            .Add("@ATE_V_BENEF", OleDbType.Numeric).Value = ATE_V_BENEF         '2
            .Add("@ATE_V_CF", OleDbType.Numeric).Value = ATE_V_CF               '3
            .Add("@ATE_V_CF_FP", OleDbType.Numeric).Value = ATE_V_CF_FP         '4
            .Add("@ATE_V_CP", OleDbType.Numeric).Value = ATE_V_CP               '5
            .Add("@ATE_V_CP_FP", OleDbType.Numeric).Value = ATE_V_CP_FP         '6
            .Add("@ATE_V_BOLETA", OleDbType.Numeric).Value = ATE_V_BOLETA       '7
            .Add("@ATE_V_PAGADO", OleDbType.Numeric).Value = ATE_V_PAGADO       '8
            .Add("@ATE_V_SEG_COMP", OleDbType.Numeric).Value = ATE_V_SEG_COMP    '9
            '----------------------------------- FIN CAJA -------------------------------
            .Add("@ATE_V_SC_2", OleDbType.Numeric).Value = ATE_V_SEG_COMP               'SEGURO COMPLEMENTARIO EN TABLA IRIS_ATENCION
            .Add("@GLOBAL_BONO_NUM", OleDbType.VarChar).Value = GLOBAL_BONO_NUM       'BONO IMED EN TABLA IRIS_ATENCION


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

    Function IRIS_WEBF_CMVM_ESTADO_BONO_IMED(ByVal ID_USUARIO As Integer,
                                             ByVal COMENTARIO As String,
                                             ByVal FOLIO_BONO As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0

        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_ESTADO_BONO_IMED"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@COMENTARIO", OleDbType.VarChar).Value = COMENTARIO
            .Add("@FOLIO_BONO", OleDbType.VarChar).Value = FOLIO_BONO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Read_Dt = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
    Function IRIS_WEBF_CMVM_ANULA_ESTADO_BONO_IMED(ByVal ID_USUARIO As Integer,
                                                  ByVal COMENTARIO As String,
                                                   ByVal folio_bono As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0

        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_ANULA_ESTADO_BONO_IMED"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@COMENTARIO", OleDbType.VarChar).Value = COMENTARIO
            .Add("@FOLIO_BONO", OleDbType.VarChar).Value = folio_bono
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Read_Dt = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
End Class
