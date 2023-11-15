Imports Entidades
Imports Datos

Public Class N_DATA_MODULOS
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_MODULOS
    Public Sub New()
        Instancia_Datos = New D_DATA_MODULOS
    End Sub
    Function IRIS_WEBF_BUSCA_MODULOS() As List(Of E_DATA_MODULOS) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_BUSCA_MODULOS()
    End Function

    Function IRIS_WEBF_BUSCA_MODULOS_POR_ID(ByVal ID_TURNO As Integer) As List(Of E_DATA_MODULOS) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_BUSCA_MODULOS_POR_ID(ID_TURNO)
    End Function

End Class
