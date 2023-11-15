Imports Entidades
Imports Negocio

Public Class VistaModulosMovil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Busca_Modulo_Movil() As List(Of E_DATA_MODULOS) 'crear mi propia E_DATA_TURNO
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_MODULOS

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_BUSCA_MODULOS()
    End Function
End Class