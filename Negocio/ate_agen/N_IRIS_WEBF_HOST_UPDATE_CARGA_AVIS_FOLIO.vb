﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO
    Dim DD_Data As D_IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO
    Sub New()
        DD_Data = New D_IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO
    End Sub
    Function IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO(ByVal HO_CC As String, ByVal PRE_INGRESO As String) As Integer
        Return DD_Data.IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO(HO_CC, PRE_INGRESO)
    End Function
    Function IRIS_WEBF_HOST_UPDATE_CARGA_AVIS(ByVal Rut As String, ByVal PRE_INGRESO As String) As Integer
        Return DD_Data.IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX(Rut, PRE_INGRESO)
    End Function
    Function IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX_FOLIO(ByVal HO_CC As String, ByVal PRE_INGRESO As String) As Integer
        Return DD_Data.IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX_FOLIO(HO_CC, PRE_INGRESO)
    End Function
    Function IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX(ByVal Rut As String, ByVal PRE_INGRESO As String) As Integer
        Return DD_Data.IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX(Rut, PRE_INGRESO)
    End Function
    Function IRIS_WEBF_HOST_UPDATE_CARGA_SIDRA_FOLIO_ID_ATENCION(ByVal HO_CC As String, ByVal ATENCION As String) As Integer
        Return DD_Data.IRIS_WEBF_HOST_UPDATE_CARGA_SIDRA_FOLIO_ID_ATENCION(HO_CC, ATENCION)
    End Function
End Class