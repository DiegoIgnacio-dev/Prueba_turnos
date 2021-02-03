﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO
    End Sub

    Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO() As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        Return DD_Data.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO(CInt(Galleta.Value))

    End Function
    Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA(ByVal DESDE As Date, ByVal HASTA As Date, ByVal NLOTE As String) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Return DD_Data.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA(DESDE, HASTA, NLOTE)

    End Function

    Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_RECEP() As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Return DD_Data.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_RECEP()

    End Function
    Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA_RECEP(ByVal DESDE As Date, ByVal HASTA As Date, ByVal NLOTE As String) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Return DD_Data.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA_RECEP(DESDE, HASTA, NLOTE)

    End Function
    Function IRIS_WEBF_BUSCA_IF_UPDATE_LOTE_RECEPCIONADO_ENVIO_POR_RECEP(ByVal NLOTE As String) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Return DD_Data.IRIS_WEBF_BUSCA_IF_UPDATE_LOTE_RECEPCIONADO_ENVIO_POR_RECEP(NLOTE)

    End Function
End Class