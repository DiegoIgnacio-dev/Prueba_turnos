Imports Entidades
Imports Datos
Public Class N_DATA_IMPR
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_IMPR
    Public Sub New()
        Instancia_Datos = New D_DATA_IMPR
    End Sub
    Function IRIS_WEBF_VISOR_IMPR(ByVal ID_TURNO_IMPR As Integer, ByVal MD_FECHA As String, ByVal ONLY_DATE As String) As List(Of E_DATA_IMPR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_VISOR_IMPR(ID_TURNO_IMPR, MD_FECHA, ONLY_DATE)
    End Function

    Public Function IRIS_WEBF_UPDATE_TURNO_LOG(ByVal ID_TURNO_IMPR As Integer) As Integer
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_UPDATE_TURNO_LOG(ID_TURNO_IMPR) 'CUIDAR NOMBRES DE FUNCIONES
    End Function
End Class

