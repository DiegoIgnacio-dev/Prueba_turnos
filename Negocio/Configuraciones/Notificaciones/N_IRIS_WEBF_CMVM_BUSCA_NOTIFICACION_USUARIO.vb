﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO(ByVal ID_USUARIO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO(ID_USUARIO)
    End Function
End Class