Imports Entidades
Imports Negocio
Public Class Ingreso_Turnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Carga_Option() As List(Of E_DATA_CARGA_OPTION) 'crear mi propia E_DATA_TURNO
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_CARGA_OPTION

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_CARGA_OPTION()
    End Function
    'FUNCION PARA LAS OPCIONES DE TIPO DE ATENCION
    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Carga_Option_Tp() As List(Of E_DATA_CARGA_OPTION_TP) 'crear mi propia E_DATA_TURNO
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_CARGA_OPTION_TP

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_CARGA_OPTION_TP()
    End Function

    'Funcion Update para la actualizacion de turnos
    <Services.WebMethod()>
    Public Shared Function Siguiente_Turno(ByVal ID_MODULO_TURNO As Integer, ByVal ID_MODULO_RECEP As Integer, ByVal TIPO_ATENCION As Integer, ByVal ONLY_DATE As String, ByVal DATO_NUM As Integer, ByVal LETRA_TURNO As Char) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_SIGUIENTE_TURNO()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        Return Instancia_Negocio.Siguiente_Turno(ID_MODULO_TURNO, ID_MODULO_RECEP, TIPO_ATENCION, ONLY_DATE, DATO_NUM, LETRA_TURNO)

    End Function

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Visor_Ultima_Impresion() As List(Of E_DATA_ULT_IMPR) 'crear mi propia E_DATA_TURNO
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_ULT_IMPR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_VISOR_ULT_IMPR()
    End Function

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Visor_Ultima_Impresion_Tipo(ByVal ID_TIPO As Integer) As List(Of E_DATA_ULT_IMPR) 'crear mi propia E_DATA_TURNO
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_ULT_IMPR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_VISOR_ULT_IMPR_TIPO(ID_TIPO)
    End Function
    'Funcion para el visor de modulo en contruccion

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Visor_Turno(ByVal ID_TURNO As Integer) As List(Of E_DATA_VISOR)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_VISOR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_VISOR_TURNO(ID_TURNO)
    End Function

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Visor_Turno_Tipo(ByVal ID_TIPO As Integer) As List(Of E_DATA_VISOR)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_VISOR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_VISOR_TURNO_TIPO(ID_TIPO)
    End Function

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Visor_Turno_Recep(ByVal ID_MODULO_RECEP As Integer) As List(Of E_DATA_VISOR)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_VISOR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_VISOR_TURNO_RECEP(ID_MODULO_RECEP)
    End Function

    'metodo para enviar parametro ded busqueda y traer resultado

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function IRIS_WEBF_TURNO_MENOR(ByVal MD_TIPO_MODULO As Integer) As List(Of E_DATA_MODULO_MENOR)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_DATA_VISOR

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.IRIS_WEBF_TURNO_MENOR(MD_TIPO_MODULO)
    End Function

    'Funcion update fecha reset
    <Services.WebMethod()>
    Public Shared Function RESET_FECHA() As List(Of E_DATA_RESET_FECHA)
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve una lista de entidad

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_SIGUIENTE_TURNO

        'Declarar una nueva instancia de la lista de entidad
        'Dim Lista_Retorno As New List(Of E_DATA_PRODUCTOS)

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio
        'Lista_Retorno = Instancia_Negocio.IRIS_WEBF_BUSCA_PRODUCTOS(DESDE, HASTA)
        'Return Lista_Retorno

        Return Instancia_Negocio.RESET_FECHA()
    End Function

    'Funcion Update para la actualizacion de turnos
    <Services.WebMethod()>
    Public Shared Function UPDATE_TIME(ByVal LETRA_TURNO As Char, ByVal TIPO_ATENCION As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_SIGUIENTE_TURNO()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        Return Instancia_Negocio.UPDATE_TIME(LETRA_TURNO, TIPO_ATENCION)

    End Function
End Class