Imports Entidades
Imports Negocio
Public Class M_Impresion_modulo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Busca_TP_Impr() As List(Of E_IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_TURNO_BUSCA_TIPO_IMPR()
    End Function

    'Funcion para el visor de modulo en contruccion

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function M_Impresion_Env(ByVal ID_TURNO_IMPR As Integer, ByVal MD_FECHA As String, ByVal ONLY_DATE As String) As List(Of E_DATA_IMPR)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_IMPR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_VISOR_IMPR(ID_TURNO_IMPR, MD_FECHA, ONLY_DATE)
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_TURNO_LOG(ByVal ID_TURNO_IMPR As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_IMPR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_UPDATE_TURNO_LOG(ID_TURNO_IMPR)


    End Function

End Class