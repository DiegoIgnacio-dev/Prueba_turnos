﻿Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class REP_LAB_CANT_EXA_ARE_SECC_2_VALIDADOS
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prevision() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Prevision As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Prevision As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Prevision.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Prevision, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String,
                                                                      ByVal DATE_str02 As String, ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        Dim lol As New N_Log
        lol.Path = "wololooo.txt"
        Dim datos As String = ""
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Try

            'Declaraciones del Serializador
            Dim Serializer As New JavaScriptSerializer
            Dim str_Builder As New StringBuilder
            'Declaraciones internas
            Dim NN_Date As New N_Date_Operat
            Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            DATE_str01 = DATE_str01.Replace("-", "/")
            DATE_str02 = DATE_str02.Replace("-", "/")
            Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
            Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS_WITH_ID_PREVE(ID_CODIGO_FONASA, Date_01, Date_02, ID_PREVE)

            Dim perfiles_bioquimicos As Integer = 0
            Dim perfiles_hepaticos As Integer = 0
            Dim perfiles_lipidicos As Integer = 0

            If (Data_Prev.Count > 0) Then
                For a = 0 To Data_Prev.Count - 1
                    If Data_Prev(a).ID_CODIGO_FONASA = 145 Then
                        perfiles_bioquimicos = Data_Prev(a).TOTAL_ATE
                    End If
                Next a

                For b = 0 To Data_Prev.Count - 1
                    If Data_Prev(b).ID_CODIGO_FONASA = 668 Then
                        perfiles_hepaticos = Data_Prev(b).TOTAL_ATE
                    End If
                Next b

                For c = 0 To Data_Prev.Count - 1
                    If Data_Prev(c).ID_CODIGO_FONASA = 76 Then
                        perfiles_lipidicos = Data_Prev(c).TOTAL_ATE
                    End If
                Next c

                Dim found136 As Boolean = False
                Dim bili_total As Boolean = False
                Dim bili_direc As Boolean = False
                Dim fosfa As Boolean = False
                Dim trigli As Boolean = False
                For i = 0 To Data_Prev.Count - 1
                    'Data_Prev(i).ID_CODIGO_FONASA = 617 Or Acido urico
                    'Data_Prev(i).ID_CODIGO_FONASA = 676 Or



                    If Data_Prev(i).ID_CODIGO_FONASA = 103 Or Data_Prev(i).ID_CODIGO_FONASA = 66 Or Data_Prev(i).ID_CODIGO_FONASA = 558 Then
                        Data_Prev(i).TOTAL_ATE += perfiles_bioquimicos
                    End If

                    If Data_Prev(i).ID_CODIGO_FONASA = 463 Or Data_Prev(i).ID_CODIGO_FONASA = 57 Or Data_Prev(i).ID_CODIGO_FONASA = 94 Or Data_Prev(i).ID_CODIGO_FONASA = 136 Or Data_Prev(i).ID_CODIGO_FONASA = 137 Then
                        Data_Prev(i).TOTAL_ATE += perfiles_hepaticos
                    End If

                    If Data_Prev(i).ID_CODIGO_FONASA = 140 Or Data_Prev(i).ID_CODIGO_FONASA = 141 Or Data_Prev(i).ID_CODIGO_FONASA = 138 Then
                        Data_Prev(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                    End If

                    'Identificar CF 136
                    If (Data_Prev(i).ID_CODIGO_FONASA = 136) Then
                        found136 = True
                    End If

                    If Data_Prev(i).ID_CODIGO_FONASA = 57 Then
                        bili_total = True
                    End If
                    If Data_Prev(i).ID_CODIGO_FONASA = 463 Then
                        bili_direc = True
                    End If
                    If Data_Prev(i).ID_CODIGO_FONASA = 94 Then
                        fosfa = True
                    End If
                    If Data_Prev(i).ID_CODIGO_FONASA = 138 Then
                        trigli = True
                    End If
                Next i

                If (trigli = False) Then
                    Dim xItem4 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                    xItem4.ID_CODIGO_FONASA = 138
                    xItem4.CF_DESC = "Trigliceridos"
                    xItem4.TOTAL_ATE = perfiles_lipidicos
                    xItem4.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                    xItem4.SECC_ORDEN = 51
                    xItem4.CF_COD = "1027"

                    Data_Prev.Add(xItem4)
                End If
                'Agregar 136 si no existe
                If (found136 = False) Then
                    Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                    xItem.ID_CODIGO_FONASA = 136
                    xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                    xItem.TOTAL_ATE = perfiles_hepaticos
                    xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                    xItem.SECC_ORDEN = 51
                    xItem.CF_COD = "1026"

                    Data_Prev.Add(xItem)
                End If

                If (fosfa = False) Then
                    Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                    xItem.ID_CODIGO_FONASA = 94
                    xItem.CF_DESC = "Fosfatasas Alcalinas"
                    xItem.TOTAL_ATE = perfiles_hepaticos
                    xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                    xItem.SECC_ORDEN = 51
                    xItem.CF_COD = "1010"

                    Data_Prev.Add(xItem)
                End If

                If bili_total = False Then
                    Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                    xItem2.ID_CODIGO_FONASA = 57
                    xItem2.CF_DESC = "Bilirrubina total"
                    xItem2.TOTAL_ATE = perfiles_hepaticos
                    xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                    xItem2.SECC_ORDEN = 51
                    xItem2.CF_COD = "1004"

                    Data_Prev.Add(xItem2)

                End If

                If bili_direc = False Then
                    Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                    xItem3.ID_CODIGO_FONASA = 463
                    xItem3.CF_DESC = "Bilirrubina Directa"
                    xItem3.TOTAL_ATE = perfiles_hepaticos
                    xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                    xItem3.SECC_ORDEN = 51
                    xItem3.CF_COD = "1003"

                    Data_Prev.Add(xItem3)
                End If

                'ORDENARRRRRRRRR
                Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Prev)

            Else
                Lista_REEEEEEE = Data_Prev
            End If
        Catch ex As Exception
            lol.Write_ERROR(ex)
        End Try
        lol.Write_Line("Wololooooo~ ")
        Return Lista_REEEEEEE
    End Function

    <Services.WebMethod()>
    Public Shared Function Gen_Excel_Desagrupado(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CODIGO_FONASA As Long, ByVal ID_PREVE As Integer) As String
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Return NN_Exam.Gen_Excel_Desagrupado_VALIDADOS(DOMAIN_URL, ID_CODIGO_FONASA, DATE_str01, DATE_str02, ID_PREVE)
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel_Agrupado(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CODIGO_FONASA As Long, ByVal ID_PREVE As Integer) As String
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Return NN_Exam.Gen_Excel_Agrupado_VALIDADOS(DOMAIN_URL, ID_CODIGO_FONASA, DATE_str01, DATE_str02, ID_PREVE)
    End Function

    Private Sub REP_LAB_CANT_EXA_ARE_SECC_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

End Class