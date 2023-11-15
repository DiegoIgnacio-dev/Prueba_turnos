Imports Entidades
Imports Datos
Public Class N_DATA_ATENCIONES
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_ATENCIONES
    Public Sub New()
        Instancia_Datos = New D_DATA_ATENCIONES
    End Sub
    Function BUSCA_DATA_ATENCIONES(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_DATA_ATENCIONES) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.BUSCA_DATA_ATENCIONES(DESDE, HASTA)
    End Function
End Class
