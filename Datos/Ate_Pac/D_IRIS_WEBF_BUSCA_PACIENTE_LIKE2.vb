'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_PACIENTE_LIKE2(ByVal RUT_P As String, ByVal NOM_P As String, ByVal APE_P As String, ByVal sinpuntos As String, ByVal dni As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2)
        Dim Reader_Comm As OleDbDataReader
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As Integer = CType(objSession("ID_USER"), Integer)
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        If (IsNothing(dni) = False) Then
            'PA CON DNI
            Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_PACIENTE_LIKE2_5_2_2"
        Else
            'PA SIN DNI
            Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_PACIENTE_LIKE2_4_2_2"
        End If

        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            If (IsNothing(RUT_P) = False) Then
                .Add("@RUT_P", OleDbType.VarChar).Value = RUT_P
            Else
                .Add("@RUT_P", OleDbType.VarChar).Value = DBNull.Value
            End If
            If (IsNothing(NOM_P) = False) Then
                .Add("@NOM_P", OleDbType.VarChar).Value = NOM_P
            Else
                .Add("@NOM_P", OleDbType.VarChar).Value = DBNull.Value
            End If
            If (IsNothing(APE_P) = False) Then
                .Add("@APE_P", OleDbType.VarChar).Value = APE_P
            Else
                .Add("@APE_P", OleDbType.VarChar).Value = DBNull.Value
            End If
            If (IsNothing(sinpuntos) = False) Then
                .Add("@sinpuntos", OleDbType.VarChar).Value = sinpuntos
            Else
                .Add("@sinpuntos", OleDbType.VarChar).Value = DBNull.Value
            End If
            If (IsNothing(dni) = False) Then
                .Add("@DNI_P", OleDbType.VarChar).Value = dni
            End If
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.SEXO_DESC = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.PAC_DIR = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PAC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PAC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PAC_OBS_PERMA = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.DIA_DESC = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.ID_SEXO = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.ID_LUGAR_TM = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.DESC_LUGAR_TM = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        Return List_Reader
    End Function
End Class
