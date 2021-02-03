﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
    End Sub
    Function IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_SIN_ESTADO_AGENDA_CF_PRECIO(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_SIN_ESTADO_AGENDA_CF_PRECIO(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK_2_BONIFICACION(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK_2_BONIFICACION(ID_PREVE, ANO, CF)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC_BONIFICACION(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC_BONIFICACION(ID_PREVE, ANO, CF)
    End Function
End Class