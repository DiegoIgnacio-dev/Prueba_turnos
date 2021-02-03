Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Public Class Resumen_Prev_Prog_Subp_Scr_3_Glob_Rend
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String, ByVal search_mode As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP = New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF_DUAL_COPA_MED_REND(DOMAIN_URL, DESDE, HASTA, PROC, PREV, TP_PAGO, ID_USER, ATE_NUM, search_mode)
        Return link
    End Function

    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String,
                                     ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String, ByVal search_mode As Integer) As String
        Dim NN_Prev As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Return NN_Prev.Gen_Excel_Dual_Copago_Rend(DOMAIN_URL, DESDE, HASTA, PROC, PREV, TP_PAGO, ID_USER, ATE_NUM, search_mode)
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_User_Data() As List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE)
        Dim NNN As New N_Conf_User
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE)




        List_Data = NNN.IRIS_WEBF_CMVM_BUSCA_USUARIO_ID_PREVISION_SCR()

        Return List_Data
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer,
                                            ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)



        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE2_FOLIO_CAJA(DESDE, HASTA, PROC, PREV, ID_USER, ATE_NUM)
        If (Data_DTT.Count > 0) Then
            For i = 0 To Data_DTT.Count - 1
                Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_DTT(i).ATE_NUM)

                If (Data_Estado_Mant_2.Count > 0) Then
                    Data_DTT(i).DOCS_CANT = Data_Estado_Mant_2.Count
                Else
                    Data_DTT(i).DOCS_CANT = 0
                End If
            Next i

            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Select(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal PROC As Integer,
                                            ByVal TP_PAGO As Integer,
                                            ByVal PREV As Integer,
                                            ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)

        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)


        Data_DTT = NN_DTT.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_CAJA(DESDE, HASTA, PROC, TP_PAGO, PREV, ID_USER)

        If (Data_DTT.Count > 0) Then
            For i = 0 To Data_DTT.Count - 1
                Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_DTT(i).ATE_NUM)

                If (Data_Estado_Mant_2.Count > 0) Then
                    Data_DTT(i).DOCS_CANT = Data_Estado_Mant_2.Count
                Else
                    Data_DTT(i).DOCS_CANT = 0
                End If

            Next i
            Return Data_DTT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Get_Img(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(ID_ATENCION)

        If (Data_Estado_Mant_2.Count > 0) Then
            Return Data_Estado_Mant_2
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Ajax_Update(ByVal MUESTRA() As Object,
                                            ByVal ID_USUARIO As Integer) As Integer
        'Declaraciones internas
        Dim NN_DTT As New N_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim Data_DTT As Integer = 0

        For i = 0 To (MUESTRA.GetUpperBound(0))
            Dim ID_DET_ATEEEE As Integer = MUESTRA(i)

            Data_DTT = NN_DTT.IRIS_WEBF_UPDATE_REVISION_DE_BONOS(ID_DET_ATEEEE, ID_USUARIO)
        Next i


        Return Data_DTT

    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            Return Data_LugarTM
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prevision() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim NN_Preve As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Preve As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Data_Preve = NN_Preve.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Preve.Count > 0) Then
            Return Data_Preve
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Programa() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Declaraciones internas
        Dim NN_Preve As New N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        Dim Data_Preve As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Data_Preve = NN_Preve.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
        If (Data_Preve.Count > 0) Then
            Return Data_Preve
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
End Class