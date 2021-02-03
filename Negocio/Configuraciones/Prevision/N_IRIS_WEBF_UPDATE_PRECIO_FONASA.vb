Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_PRECIO_FONASA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PRECIO_FONASA
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PRECIO_FONASA
    End Sub
    Function IRIS_WEBF_UPDATE_PRECIO_FONASA(ByVal ID_PRECIO As Integer, ByVal AMB As Integer, ByVal ID_USUARIO As Integer, ByVal FECHA As DateTime, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.D_IRIS_WEBF_UPDATE_PRECIO_FONASA(ID_PRECIO, AMB, ID_USUARIO, FECHA, ID_ESTADO)
    End Function
End Class
