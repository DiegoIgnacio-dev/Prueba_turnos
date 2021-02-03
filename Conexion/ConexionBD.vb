Imports System.Configuration
Imports System.Data.OleDb
Public Class ConexionBD
    Public Oledbconexion
    Public ReadOnly Property Connect_to_IrisLab_LoBarnechea() As OleDbConnection
        Get
            If Oledbconexion Is Nothing Then
                Dim sConnString As String = ConfigurationManager.ConnectionStrings("CadenaConexion_IrisLab_LoBarnechea").ToString
                Oledbconexion = New OleDbConnection(sConnString)
            End If
            Return Oledbconexion
        End Get
    End Property
End Class
