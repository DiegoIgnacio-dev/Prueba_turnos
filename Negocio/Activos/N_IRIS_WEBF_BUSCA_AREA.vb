Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_AREA
    Dim DD_Data As D_IRIS_WEBF_BUSCA_AREA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_AREA
    End Sub
    Function IRIS_WEBF_BUSCA_AREA() As List(Of E_IRIS_WEBF_BUSCA_AREA)
        Return DD_Data.IRIS_WEBF_BUSCA_AREA()
    End Function
End Class
