Imports Entidades
Imports Negocio
Public Class Ingreso_Producto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Function Crear_Producto(ByVal NOMBRE As String, ByVal DESCRIPCION As String, ByVal PRECIO As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_Crea_Producto()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        Return Instancia_Negocio.Crear_Producto(NOMBRE, DESCRIPCION, PRECIO)

    End Function
End Class

