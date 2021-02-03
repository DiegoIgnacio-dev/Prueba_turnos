Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Exa_Esp_V
    'Declaraciones Generales
    Dim DD_Data As D_Exa_Esp_V

    Sub New()
        DD_Data = New D_Exa_Esp_V
    End Sub

    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ID_ATE, ID_CODIGO_FONSA)
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(ID_ATE, ID_CODIGO_FONSA)
    End Function
    Function IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_PENDIENTES_CON_OMI(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_PENDIENTES_CON_OMI(ID_ATE, ID_CODIGO_FONSA)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_REGISTRO_PENDIENTES(ByVal ID_USER As Integer,
                                                      ByVal CB_DESC As String,
                                                      ByVal ATE_NUM As String,
                                                      ByVal ATE_NUM_OMI As String,
                                                      ByVal ID_CODIGO_FONASA As Integer,
                                                      ByVal CF_DESC As String,
                                                      ByVal FECHA_PEND As Date,
                                                      ByVal USU_ID_PROC As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_GRABA_REGISTRO_PENDIENTES(ID_USER, CB_DESC, ATE_NUM, ATE_NUM_OMI, ID_CODIGO_FONASA, CF_DESC, FECHA_PEND, USU_ID_PROC)
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_SAYDEX(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_SAYDEX(ID_ATE, ID_CODIGO_FONSA)
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX(ID_ATE, ID_CODIGO_FONSA)
    End Function
    Function IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SIDRA(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SIDRA(ID_ATE, ID_CODIGO_FONSA)
    End Function
End Class