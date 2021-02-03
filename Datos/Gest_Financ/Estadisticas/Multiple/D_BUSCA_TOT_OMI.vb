'Importar Capas
Imports Conexion
Imports Entidades
Imports MySql.Data.MySqlClient
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_BUSCA_TOT_OMI
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function BUSCA_TOT_OMI(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_BUSCA_TOT_OMI)
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As MySqlDataReader
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_BUSCA_TOT_OMI
        Dim E_Proc_Obj As New List(Of E_BUSCA_TOT_OMI)


        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.Text
            .CommandText = "select distinct DESCRIPCION_EXAMEN, CODIGO_EXAMEN, count(distinct ID_ATENCION) AS CANTIDAD from resultados_examen where FECHA_toma_muestra BETWEEN  str_to_date('" + DESDE + "','%d-%m-%Y') AND DATE_ADD(str_to_date('" + HASTA + "','%d-%m-%Y'), INTERVAL 1 DAY) group by DESCRIPCION_EXAMEN having count(DESCRIPCION_EXAMEN) >= 1"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
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
            E_Proc_Item = New E_BUSCA_TOT_OMI

            E_Proc_Item.DESCRIPCION_EXAMEN = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 0, 0)
            E_Proc_Item.CODIGO_EXAMEN = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 1, 0)
            E_Proc_Item.CANTIDAD_EXAMEN = DD_GEN.DB_NULL_MYSQL(Obj_Reader, 2, 0)

            E_Proc_Obj.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Obj
    End Function
End Class
