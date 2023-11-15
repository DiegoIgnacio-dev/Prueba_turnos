Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR
    Public Sub New()
        Instancia_Datos = New D_IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR
    End Sub
    Function IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR() As List(Of E_IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR()
    End Function
End Class
