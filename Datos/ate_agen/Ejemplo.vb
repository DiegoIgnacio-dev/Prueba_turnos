'Importar Capas
Imports Conexion
Imports Entidades
Imports MySql.Data.MySqlClient
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class Ejemplo
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_OMI(ByVal folio As String) As List(Of E_IRIS_WEBF_OBTENER_INFO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As MySqlDataReader
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_OBTENER_INFO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_OBTENER_INFO)


        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("OMI", MySqlDbType.VarChar)
        parametro_1(0).Value = folio

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "OBTENER_INFO_EMB"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteReader()
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_OBTENER_INFO

            E_Proc_Item.N_OMI = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 3, Nothing)
            E_Proc_Item.RUT_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DNI = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 5, Nothing)
            E_Proc_Item.NOMBRE_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 6, Nothing)
            E_Proc_Item.APELLIDO_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 7, Nothing)
            E_Proc_Item.SEXO_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 8, Nothing)
            E_Proc_Item.FECHA_NAC_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 9, Nothing)
            E_Proc_Item.DIRECCION = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 10, Nothing)
            E_Proc_Item.FONO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 11, Nothing)
            E_Proc_Item.COD_EXA_INTERNO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 12, Nothing)
            E_Proc_Item.NOMBRE_EXAMEN = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 13, Nothing)
            'E_Proc_Item.COD_EXA_HOMO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 14, Nothing)

            'E_Proc_Item.OBSERVACIONES = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 18, Nothing)
            E_Proc_Item.RUT_MEDICO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 14, Nothing)
            E_Proc_Item.NOMBRE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 15, Nothing)
            E_Proc_Item.APELLIDO_MEDICO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 16, Nothing)
            E_Proc_Item.EMP = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 17, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_OMI_2(ByVal folio As String) As List(Of E_IRIS_WEBF_OBTENER_INFO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As MySqlDataReader
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_OBTENER_INFO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_OBTENER_INFO)


        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("RUT", MySqlDbType.VarChar)
        parametro_1(0).Value = folio

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "OBTENER_EXAMAEN_RUT"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteReader()
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_OBTENER_INFO


            E_Proc_Item.N_OMI = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 3, Nothing)
            E_Proc_Item.RUT_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DNI = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 5, Nothing)
            E_Proc_Item.NOMBRE_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 6, Nothing)
            E_Proc_Item.APELLIDO_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 7, Nothing)
            E_Proc_Item.SEXO_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 8, Nothing)
            E_Proc_Item.FECHA_NAC_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 9, Nothing)
            E_Proc_Item.DIRECCION = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 10, Nothing)
            E_Proc_Item.FONO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 11, Nothing)
            E_Proc_Item.COD_EXA_INTERNO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 12, Nothing)
            E_Proc_Item.NOMBRE_EXAMEN = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 13, Nothing)
            'E_Proc_Item.COD_EXA_HOMO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 14, Nothing)

            'E_Proc_Item.OBSERVACIONES = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 18, Nothing)
            E_Proc_Item.RUT_MEDICO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 14, Nothing)
            E_Proc_Item.NOMBRE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 15, Nothing)
            E_Proc_Item.APELLIDO_MEDICO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 16, Nothing)
            E_Proc_Item.EMP = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 17, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_DNI_OMI_2(ByVal folio As String) As List(Of E_IRIS_WEBF_OBTENER_INFO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As MySqlDataReader
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_OBTENER_INFO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_OBTENER_INFO)


        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("DNI", MySqlDbType.VarChar)
        parametro_1(0).Value = folio

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "OBTENER_EXAMAEN_DNI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteReader()
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_OBTENER_INFO


            E_Proc_Item.N_OMI = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 3, Nothing)
            E_Proc_Item.RUT_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 4, Nothing)
            E_Proc_Item.NOMBRE_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 6, Nothing)
            E_Proc_Item.APELLIDO_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 7, Nothing)
            E_Proc_Item.SEXO_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 8, Nothing)
            E_Proc_Item.FECHA_NAC_PACIENTE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 9, Nothing)
            E_Proc_Item.DIRECCION = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 10, Nothing)
            E_Proc_Item.FONO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 11, Nothing)
            E_Proc_Item.COD_EXA_INTERNO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 12, Nothing)
            E_Proc_Item.NOMBRE_EXAMEN = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 13, Nothing)
            'E_Proc_Item.COD_EXA_HOMO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 14, Nothing)

            'E_Proc_Item.OBSERVACIONES = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 18, Nothing)
            E_Proc_Item.RUT_MEDICO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 14, Nothing)
            E_Proc_Item.NOMBRE = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 15, Nothing)
            E_Proc_Item.APELLIDO_MEDICO = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 16, Nothing)
            E_Proc_Item.EMP = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 17, Nothing)
            E_Proc_Item.DNI = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function UPDATE_ESTADO_TEST(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        Dim parametro_2(0) As MySqlParameter
        'Declaraciones 'lista'



        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("OMI", MySqlDbType.VarChar)
        parametro_1(0).Value = OC

        parametro_2(0) = New MySqlParameter("COD_EXAMEN", MySqlDbType.VarChar)
        parametro_2(0).Value = CODIGO_TEST

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UPDATE_ESTADO_EXAMEN"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
            .Parameters.AddRange(parametro_2)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteNonQuery


        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

    Function UPDATE_ESTADO_TEST_NULL(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        Dim parametro_2(0) As MySqlParameter
        'Declaraciones 'lista'



        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("OMI", MySqlDbType.VarChar)
        parametro_1(0).Value = OC

        parametro_2(0) = New MySqlParameter("COD_EXAMEN", MySqlDbType.VarChar)
        parametro_2(0).Value = CODIGO_TEST

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UPDATE_ESTADO_EXAMEN_TO_NULL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
            .Parameters.AddRange(parametro_2)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteNonQuery


        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

End Class
