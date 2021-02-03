Imports Entidades
Imports Datos

Public Class N_Val_Criticos_New
    Dim D_Data As D_Val_Criticos_New

    Sub New()
        D_Data = New D_Val_Criticos_New
    End Sub

    Public Function IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT(ByVal DATE_01 As Date, ByVal DATE_02 As Date,
                                                                             ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                                                             ByVal ID_CODF As Long, ByVal ID_CRIT As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT)
        Dim objList As New List(Of E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT)
        objList = D_Data.IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT(DATE_01, DATE_02, ID_PROC, ID_PREV, ID_CODF, ID_CRIT)
        For Each item In objList
            Dim EEE As New N_Calc_Age

            item.EDAD = EEE.IrisLAB_Cal_Edad_Exacta(item.PAC_FNAC, Date.Now)
        Next

        Return objList
    End Function

    Public Function Create_Excel(ByVal DATE_01 As Date, ByVal DATE_02 As Date,
                                 ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                 ByVal ID_CODF As Long, ByVal ID_CRIT As Long, ByVal ARR_STR As String()) As String
        Dim objList As New List(Of E_IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT)
        objList = Me.IRIS_WEBF_CMVM_BUSCA_VALORES_CRITICOS_BY_ID_PREV_ID_CRIT(DATE_01, DATE_02, ID_PROC, ID_PREV, ID_CODF, ID_CRIT)

        If (objList.Count = 0) Then
            Return Nothing
        End If

        Dim Xls As New XlsDcto
        Xls.x = 1
        Xls.y = 1

        Xls.Merge(4)
        Xls.Write("Valores Críticos", Xls.CSSref.h1)
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Fecha Desde: ", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(Format(DATE_01, "dd/MM/yyyy"), Xls.CSSref.h2)
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Fecha Hasta: ", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(Format(DATE_02, "dd/MM/yyyy"), Xls.CSSref.h2)
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Procedencia: ", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(ARR_STR(0), Xls.CSSref.h2)
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Previsión: ", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(ARR_STR(1), Xls.CSSref.h2)
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Examen: ", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(ARR_STR(2), Xls.CSSref.h2)
        Xls.NxtRow()

        Xls.Merge(2)
        Xls.Write("Estado: ", Xls.CSSref.h2("right"))
        Xls.Merge(2)
        Xls.Write(ARR_STR(3), Xls.CSSref.h2)
        Xls.NxtRow()

        Xls.SetColumnWidth(1, 20)
        Xls.SetColumnWidth(2, 20)
        Xls.SetColumnWidth(3, 25)
        Xls.SetColumnWidth(4, 50)
        Xls.SetColumnWidth(5, 25)
        Xls.SetColumnWidth(6, 20)
        Xls.SetColumnWidth(7, 20)
        Xls.SetColumnWidth(8, 40)
        Xls.SetColumnWidth(9, 40)
        Xls.SetColumnWidth(10, 20)
        Xls.SetColumnWidth(11, 45)
        Xls.SetColumnWidth(12, 45)
        Xls.SetColumnWidth(13, 20)
        Xls.SetColumnWidth(14, 20)
        Xls.SetColumnWidth(15, 20)
        Xls.SetColumnWidth(16, 20)
        Xls.SetColumnWidth(17, 20)
        Xls.SetColumnWidth(18, 20)
        Xls.SetColumnWidth(19, 20)
        Xls.SetColumnWidth(20, 20)
        Xls.SetColumnWidth(21, 20)
        Xls.SetColumnWidth(22, 20)
        Xls.SetColumnWidth(23, 20)
        Xls.SetColumnWidth(24, 20)
        Xls.SetColumnWidth(25, 25)
        Xls.SetColumnWidth(26, 45)
        Xls.SetColumnWidth(27, 45)

        Xls.NxtRow()
        Xls.NxtRow()

        Xls.x = Xls.x
        Xls.y = Xls.y

        Xls.Write("N° Atención", Xls.CSSref.th)
        Xls.Write("Fecha Atenc.", Xls.CSSref.th)
        Xls.Write("RUT/DNI", Xls.CSSref.th)
        Xls.Write("Nombre Paciente", Xls.CSSref.th)
        Xls.Write("Sexo", Xls.CSSref.th)
        Xls.Write("Fecha Nac.", Xls.CSSref.th)
        Xls.Write("Edad", Xls.CSSref.th)
        Xls.Write("Procedencia", Xls.CSSref.th)
        Xls.Write("Previsión", Xls.CSSref.th)
        Xls.Write("Cod. Fonasa", Xls.CSSref.th)
        Xls.Write("Descripción Cod. Fonasa", Xls.CSSref.th)
        Xls.Write("Prueba", Xls.CSSref.th)
        Xls.Write("Fecha Validac.", Xls.CSSref.th)
        Xls.Write("Hora Validac.", Xls.CSSref.th)
        Xls.Write("Resultado", Xls.CSSref.th)
        Xls.Write("Alarma", Xls.CSSref.th)
        Xls.Write("Muy Bajo", Xls.CSSref.th)
        Xls.Write("Bajo", Xls.CSSref.th)
        Xls.Write("Alto", Xls.CSSref.th)
        Xls.Write("Muy Alto", Xls.CSSref.th)
        Xls.Write("Fecha Notif.", Xls.CSSref.th)
        Xls.Write("Hora Notif.", Xls.CSSref.th)
        Xls.Write("Usuario.", Xls.CSSref.th)
        Xls.Write("Tipo Aviso.", Xls.CSSref.th)
        Xls.Write("Estado.", Xls.CSSref.th)
        Xls.Write("Avisado a...", Xls.CSSref.th)
        Xls.Write("Causa", Xls.CSSref.th)
        Xls.NxtRow()

        For Each Item In objList
            Xls.Write(Item.ATE_NUM & ".-", Xls.CSSref.td_string("right"))
            Xls.Write(Format(Item.ATE_FECHA, "dd/MM/yyyy"), Xls.CSSref.td_date("center"))
            Xls.Write(Item.PAC_DCTO, Xls.CSSref.td_string("center"))
            Xls.Write(Item.PAC_NAME, Xls.CSSref.td_string("left"))
            Xls.Write(Item.SEXO_DESC, Xls.CSSref.td_string("center"))
            Xls.Write(Format(Item.PAC_FNAC, "dd/MM/yyyy"), Xls.CSSref.td_date("center"))
            Xls.Write(Item.EDAD, Xls.CSSref.td_string("center"))
            Xls.Write(Item.PROC_DESC, Xls.CSSref.td_string("left"))
            Xls.Write(Item.PREVE_DESC, Xls.CSSref.td_string("left"))
            Xls.Write(Item.CODF_COD & ".-", Xls.CSSref.td_string("center"))
            Xls.Write(Item.CODF_DESC, Xls.CSSref.td_string("left"))
            Xls.Write(Item.PRU_DESC, Xls.CSSref.td_string("left"))
            Xls.Write(Format(Item.FECHA_VALIDAC, "dd/MM/yyyy"), Xls.CSSref.td_date("center"))
            Xls.Write(Item.FECHA_VALIDAC, Xls.CSSref.td_time("center"))
            Xls.Write(Item.PRU_VALUE, Xls.CSSref.td_float("right"))
            Xls.Write(Item.ALARMA, Xls.CSSref.td_string("center"))
            Xls.Write(Item.ATE_RR_DESDE, Xls.CSSref.td_float("right"))
            Xls.Write(Item.ATE_R_DESDE, Xls.CSSref.td_float("right"))
            Xls.Write(Item.ATE_R_HASTA, Xls.CSSref.td_float("right"))
            Xls.Write(Item.ATE_RR_HASTA, Xls.CSSref.td_float("right"))
            Xls.Write("", Xls.CSSref.td_date("center"))
            Xls.Write("", Xls.CSSref.td_time("center"))
            Xls.Write("", Xls.CSSref.td_string("left"))
            Xls.Write("", Xls.CSSref.td_time("center"))
            Xls.Write("", Xls.CSSref.td_time("center"))
            Xls.Write("", Xls.CSSref.td_string("left"))
            Xls.Write("", Xls.CSSref.td_string("left"))

            Xls.NxtRow()
        Next
        Xls.Set_Table()

        Xls.Path = "IRISPDFDERIVADOS\"
        Xls.Path &= "Val_Criticos"
        Xls.Path &= "_" & Format(Date.Now, "dd-MM-yyyy_")
        Xls.Path &= Format(Date.Now, "hh-mm-ss") & ".xlsx"

        Xls.Path = Xls.Path.Replace(" ", "_")
        Xls.Path = Xls.Path.Replace(":", "-")

        Xls.Guardar_Como(True)

        'Devolver la url del archivo generado
        Return HttpContext.Current.Request.Url.Authority & "/" & Replace(Xls.Path, "\", "/")
    End Function
End Class
