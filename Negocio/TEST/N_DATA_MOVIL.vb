Imports Entidades
Imports Datos

Public Class N_DATA_MOVIL
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_MOVIL
    Public Sub New()
        Instancia_Datos = New D_DATA_MOVIL
    End Sub
    Function IRIS_WEBF_BUSCA_MODULOS() As List(Of E_DATA_MOVIL) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_BUSCA_MODULOS()
    End Function
End Class