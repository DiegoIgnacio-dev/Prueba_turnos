Imports Entidades
Imports Negocio
Public Class turnoIngreso1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()> 'Funciones con etiquetas de servicio tipo WebMethod
    Public Shared Function Ingresar_Turno(ByVal MD_MODULO As Char, ByVal MD_TURNO_IMPR As Integer, ByVal MD_TURNO_RECEP As Integer, ByVal MD_TIPO_MODULO As Integer, ByVal ID_ESTADO As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_Ingresa_Turno()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        Return Instancia_Negocio.Ingresar_Turno(MD_MODULO, MD_TURNO_IMPR, MD_TURNO_RECEP, MD_TIPO_MODULO, ID_ESTADO)
    End Function

    '#############################################################################################################
    'Funcion Update para la actualizacion de turnos
    <Services.WebMethod()>
    Public Shared Function Update_Turno(ByVal ID_TURNO As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_Ingresa_Turno()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        Return Instancia_Negocio.Update_Turno(ID_TURNO)
    End Function
    '###########################################################################################################
    'Funcion que actualiza el estado usando los checks
    <Services.WebMethod()>
    Public Shared Function Update_Check(ByVal ID_MODULO_TURNO As Integer, ByVal MD_FECHA As String, ByVal ID_ESTADO As Integer) As Integer
        'Funcion publica compartida que recibe parametros declarados con su tipo de dato y devuelve un entero

        'Declarar una nueva instancia de la capa Negocio
        Dim Instancia_Negocio As New N_Ingresa_Turno()

        'Seteamos la lista de entidad con lo que nos llegue de la funcion en la capa de Negocio

        Return Instancia_Negocio.Update_Check(ID_MODULO_TURNO, MD_FECHA, ID_ESTADO)
    End Function

    '#############################################################################################################
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
End Class