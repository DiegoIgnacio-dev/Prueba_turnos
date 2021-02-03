Imports System.Web
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Public Class D_General_Functions
    'Usar en caso de que exista la posibilidad de recibir datos nulos de la DB
    Function DB_NULL(ByVal Obj_Reader_inst As OleDbDataReader, ByVal Index As Integer, Optional ByVal Default_Value As Object = Nothing) As Object
        If (IsDBNull(Obj_Reader_inst(Index)) = False) Then
            Return Obj_Reader_inst(Index)
        Else
            Return Default_Value
        End If
    End Function

    'Usar en caso de que exista la posibilidad de recibir datos nulos de la DB
    Function DB_NULL_MYSQL(ByVal Obj_Reader_inst As MySqlDataReader, ByVal Index As Integer, Optional ByVal Default_Value As Object = Nothing) As Object
        If (IsDBNull(Obj_Reader_inst(Index)) = False) Then
            Return Obj_Reader_inst(Index)
        Else
            Return Default_Value
        End If
    End Function
End Class

