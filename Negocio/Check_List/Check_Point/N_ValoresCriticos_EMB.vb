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

Public Class N_ValoresCriticos_EMB
    'Declaraciones Generales
    Dim DD_Data As D_ValoresCriticos_EMB

    Sub New()
        DD_Data = New D_ValoresCriticos_EMB
    End Sub

    Function IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F(ByVal CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F)
        Return DD_Data.IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F(CF)
    End Function
End Class