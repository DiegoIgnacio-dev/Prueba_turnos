Imports Entidades
Imports Datos

Public Class N_DATA_MOVIL_2
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_MOVIL_2
    Public Sub New()
        Instancia_Datos = New D_DATA_MOVIL_2
    End Sub
    Function IRIS_WEBF_BUSCA_MODULOS_MOVIL(ByVal ID_MODULO_TURNO As Integer) As List(Of E_DATA_MOVIL_2) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_BUSCA_MODULOS_MOVIL(ID_MODULO_TURNO)
    End Function
End Class