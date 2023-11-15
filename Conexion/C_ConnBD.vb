Imports System.Configuration
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class C_ConnBD
    Public Oledbconexion
    Public ReadOnly Property Connect_to_IrisLab_Test() As OleDbConnection
        Get
            If Oledbconexion Is Nothing Then
                Dim sConnString As String = ConfigurationManager.ConnectionStrings("CadenaConexion_IrisLab_Test").ToString
                Oledbconexion = New OleDbConnection(sConnString)
            End If
            Return Oledbconexion
        End Get
    End Property
End Class
