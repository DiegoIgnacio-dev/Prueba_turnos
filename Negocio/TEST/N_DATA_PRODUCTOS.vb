Imports Entidades
Imports Datos
Public Class N_DATA_PRODUCTOS
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_PRODUCTOS
    Public Sub New()
        Instancia_Datos = New D_DATA_PRODUCTOS
    End Sub
    Function IRIS_WEBF_BUSCA_PRODUCTOS(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_DATA_PRODUCTOS) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
    End Function
End Class
