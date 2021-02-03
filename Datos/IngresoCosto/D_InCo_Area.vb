Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_InCo_Area
    Function IRIS_WEBF_BUSCA_LIS_ADM_AREA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_AREA As Integer) As List(Of E_InCo_Area)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_InCo_Area
        Dim List_Reader As New List(Of E_InCo_Area)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_AREA", OleDbType.Numeric).Value = ID_AREA
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
            Obj_Read_Dt = New E_InCo_Area
            Obj_Read_Dt.TOT_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.TOTA_SIS = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.TOTA_USU = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.TOTA_COPA = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.RLS_LS_DESC = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.AREA_DESC = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.CONTROL_COSTO_PRECIO = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
