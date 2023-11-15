Imports Entidades
Imports Datos
Public Class N_DATA_ULT_IMPR
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_ULT_IMPR
    Public Sub New()
        Instancia_Datos = New D_DATA_ULT_IMPR
    End Sub
    Function IRIS_WEBF_VISOR_ULT_IMPR() As List(Of E_DATA_ULT_IMPR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_VISOR_ULT_IMPR()
    End Function
    Function IRIS_WEBF_VISOR_ULT_IMPR_TIPO(ByVal ID_TIPO As Integer) As List(Of E_DATA_ULT_IMPR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_VISOR_ULT_IMPR_TIPO(ID_TIPO)
    End Function

End Class
