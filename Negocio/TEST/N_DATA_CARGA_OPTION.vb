﻿Imports Entidades
Imports Datos
Public Class N_DATA_CARGA_OPTION
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_DATA_CARGA_OPTION
    Public Sub New()
        Instancia_Datos = New D_DATA_CARGA_OPTION
    End Sub
    Function IRIS_WEBF_CARGA_OPTION() As List(Of E_DATA_CARGA_OPTION) 'Igual que el Back End de Presentacion
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.IRIS_WEBF_CARGA_OPTION()
    End Function
End Class
