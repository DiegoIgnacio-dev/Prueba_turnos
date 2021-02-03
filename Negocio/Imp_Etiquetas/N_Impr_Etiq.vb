Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports DocumentFormat.OpenXml.Spreadsheet

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Impr_Etiq
    'Declaraciones Generales
    Dim DD_Data As D_Impr_Etiq

    Sub New()
        DD_Data = New D_Impr_Etiq
    End Sub

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ByVal ATE_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ATE_NUM)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE(ATE_NUM)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE_DETAILS(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE_DETAILS)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~Index.aspx")
        End If

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE_DETAILS(ATE_NUM, CInt(Galleta.Value))
    End Function

    Function GET_EXCEL(ByVal ATE_NUM As Long, ByVal ListT_Mue As List(Of Integer)) As String
        Dim Obj_Gen As New E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO
        Dim List_Out As New List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE_DETAILS)
        Dim strURL As String = HttpContext.Current.Request.Url.Authority
        Dim NNN As New N_Impr_Etiq

        Obj_Gen = NNN.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ATE_NUM)
        List_Out = NNN.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE_DETAILS(ATE_NUM)

        'Crear Tabla
        Dim Xls As New XlsDcto
        Xls.x = 1
        Xls.y = 1

        'Escribir Datos
        Xls.Merge(4)
        Xls.Write("Listado de Etiquetas", Xls.CSSref.h1("center"))
        Xls.NxtRow()
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Nro Atención :", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(ATE_NUM, Xls.CSSref.h2("left"))
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("RUT :", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(Obj_Gen.PAC_RUT, Xls.CSSref.h2("left"))
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Nombre :", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(Obj_Gen.PAC_NOMBRE & " " & Obj_Gen.PAC_APELLIDO, Xls.CSSref.h2("left"))
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Procedencia :", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(Obj_Gen.PROC_DESC, Xls.CSSref.h2("left"))
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Previsión :", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(Obj_Gen.PREVE_DESC, Xls.CSSref.h2("left"))
        Xls.NxtRow()

        Xls.SetColumnWidth(1, 20)
        Xls.SetColumnWidth(2, 20)
        Xls.SetColumnWidth(3, 20)
        Xls.SetColumnWidth(4, 25)
        Xls.SetColumnWidth(5, 25)
        Xls.SetColumnWidth(6, 60)

        Xls.x = 1
        Xls.y = Xls.y() + 1

        Xls.Write("Cod Barra", Xls.CSSref.th)
        Xls.Write("Tipo de Muestra", Xls.CSSref.th)
        Xls.Write("Color Tubo", Xls.CSSref.th)
        Xls.Write("Cod Fonasa", Xls.CSSref.th)
        Xls.Write("Cod Fon - Etiq.", Xls.CSSref.th)
        Xls.Write("Descripción", Xls.CSSref.th)
        Xls.NxtRow()

        For i = 0 To (List_Out.Count - 1)
            Xls.Write(List_Out(i).CB_COD & ".-", Xls.CSSref.td_string("center"))
            Xls.Write(List_Out(i).T_MUESTRA_DESC, Xls.CSSref.td_string("left"))
            Xls.Write(List_Out(i).GMUE_DESC, Xls.CSSref.td_string("center"))
            Xls.Write(List_Out(i).CF_COD & ".-", Xls.CSSref.td_string("left"))
            Xls.Write(List_Out(i).CF_CORTO, Xls.CSSref.td_string("left"))
            Xls.Write(List_Out(i).CF_DESC, Xls.CSSref.td_string("left"))

            Xls.NxtRow()
        Next
        Xls.Set_Table()

        'Ruta de Guardado
        Xls.Path = "IRISPDFDERIVADOS\List_Etiquetas"
        Xls.Path &= "_" & String.Format(Date.Now, "dd-MM-yyyy_")
        Xls.Path &= String.Format(Date.Now, "hh-mm-ss") & ".xlsx"

        Xls.Path = Xls.Path.Replace(" ", "_")
        Xls.Path = Xls.Path.Replace(":", "-")

        Xls.Guardar_Como(True)

        'Devolver la url del archivo generado
        Return strURL & "/" & Replace(Xls.Path, "\", "/")
    End Function

End Class