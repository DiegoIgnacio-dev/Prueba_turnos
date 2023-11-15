Imports Entidades
Imports Datos
Public Class N_Crea_Producto
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_Crea_Producto
    Public Sub New()
        Instancia_Datos = New D_Crea_Producto
    End Sub
    Function Crear_Producto(ByVal NOMBRE As String, ByVal DESCRIPCION As String, ByVal PRECIO As Integer) As Integer
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.Crear_Producto(NOMBRE, DESCRIPCION, PRECIO)
    End Function
End Class
