﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_UPDATE_ESTADO_WEB_IMG_MOBILE
    Dim DD_Data As D_IRIS_WEBF_CMVM_UPDATE_ESTADO_WEB_IMG_MOBILE
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_UPDATE_ESTADO_WEB_IMG_MOBILE
    End Sub
    Function IRIS_WEBF_CMVM_UPDATE_ESTADO_WEB_IMG_MOBILE(ByVal ID As Long) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_ESTADO_WEB_IMG_MOBILE(ID)
    End Function
End Class
