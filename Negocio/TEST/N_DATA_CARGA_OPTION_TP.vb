Imports Entidades
Imports Datos
Public Class N_DATA_CARGA_OPTION_TP
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_CARGA_OPTION_TP
    Public Sub New()
        Instancia_Datos = New D_DATA_CARGA_OPTION_TP
    End Sub
    Function IRIS_WEBF_CARGA_OPTION_TP() As List(Of E_DATA_CARGA_OPTION_TP) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_CARGA_OPTION_TP()
    End Function

End Class