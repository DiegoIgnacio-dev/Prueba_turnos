Imports Entidades
Imports Negocio
Public Class Ingreso_Ingredientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Function Crear_Ingredientes(ByVal CODIGO As String, ByVal DESCRIPCION As String, ByVal UNIDAD As String, ByVal CANTIDAD As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        ' Dim Instancia_Negocio As New N_Crea_Ingredientes()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        ' Return Instancia_Negocio.Crear_Ingredientes(NOMBRE, DESCRIPCION, PRECIO)
        Return 1
    End Function
End Class