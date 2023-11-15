Imports Entidades
Imports Datos
Public Class N_DATA_VISOR
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_VISOR
    Public Sub New()
        Instancia_Datos = New D_DATA_VISOR
    End Sub
    Function IRIS_WEBF_VISOR_TURNO(ByVal ID_TURNO As Integer) As List(Of E_DATA_VISOR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_VISOR_TURNO(ID_TURNO)
    End Function
    Function IRIS_WEBF_VISOR_TURNO_TIPO(ByVal ID_TIPO As Integer) As List(Of E_DATA_VISOR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_VISOR_TURNO_TIPO(ID_TIPO)
    End Function
    Function IRIS_WEBF_VISOR_TURNO_RECEP(ByVal ID_MODULO_RECEP As Integer) As List(Of E_DATA_VISOR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_VISOR_TURNO_RECEP(ID_MODULO_RECEP)
    End Function

    Function IRIS_WEBF_TURNO_MENOR(ByVal MD_TIPO_MODULO As Integer) As List(Of E_DATA_MODULO_MENOR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_TURNO_MENOR(MD_TIPO_MODULO)
    End Function
End Class
