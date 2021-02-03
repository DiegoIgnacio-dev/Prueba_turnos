Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Codigos_Fonasa
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Estado_Mant() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        If (Data_Estado_Mant.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Estado_Mant, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Agrupacion_Mant() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Agrupacion_Mant As New N_IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR
        Dim Data_Agrupacion_Mant As New List(Of E_IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR)
        Data_Agrupacion_Mant = NN_Agrupacion_Mant.IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR()
        If (Data_Agrupacion_Mant.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Agrupacion_Mant, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Dtt() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Cod_Fonasa As New N_IRIS_WEBF_BUSCA_CODIGO_FONASA
        Dim Data_Cod_Fonasa As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
        Data_Cod_Fonasa = NN_Cod_Fonasa.IRIS_WEBF_BUSCA_CODIGO_FONASA()
        If (Data_Cod_Fonasa.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Cod_Fonasa, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Año(ByVal ANO As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Año As New N_IRIS_WEBF_BUSCA_ANOS_POR_ID
        Dim Data_Año As New List(Of E_IRIS_WEBF_BUSCA_ANOS_POR_ID)
        Data_Año = NN_Año.IRIS_WEBF_BUSCA_ANOS_POR_ID(ANO)
        If (Data_Año.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Año, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_CF(ByVal ID_CF As Integer, ByVal COD_CF As String, ByVal DESC_CF As String, ByVal CORTO_CF As String, ByVal DIAS_CF As Integer, ByVal ID_ESTADO As Integer, ByVal SOLA_CF As String, ByVal IMP_NOM_CF As String, ByVal IMP_SEL_CF As String, ByVal IMP_PAR_CF As String, ByVal HOST_CF As String, ByVal ID_MUESTRA As String) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_UCF As New N_IRIS_WEBF_UPDATE_CODIGO_FONASA
        Dim Data_UCF As Integer
        Data_UCF = NN_UCF.IRIS_WEBF_UPDATE_CODIGO_FONASA(ID_CF, COD_CF, DESC_CF, CORTO_CF, DIAS_CF, ID_ESTADO, SOLA_CF, IMP_NOM_CF, IMP_SEL_CF, IMP_PAR_CF, HOST_CF, ID_MUESTRA)

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Data_UCF, str_Builder)
        Return str_Builder.ToString
        Return Nothing
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_PF(ByVal ID_ANO As Integer, ByVal ID_USUARIO As Integer, ByVal ID_FONASA As Integer, ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_UPF As New N_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
        Dim Data_UPF As Integer
        Data_UPF = NN_UPF.IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION(ID_ANO, ID_USUARIO, ID_FONASA, ID_ESTADO)

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Data_UPF, str_Builder)
        Return str_Builder.ToString
        Return Nothing
    End Function
    <Services.WebMethod()>
    Public Shared Function Create_CF(ByVal COD_CF As String, ByVal DESC_CF As String, ByVal CORTO_CF As String, ByVal DIAS_CF As Integer, ByVal ID_ESTADO As Integer, ByVal SOLA_CF As String, ByVal IMP_NOM_CF As String, ByVal IMP_SEL_CF As String, ByVal IMP_PAR_CF As String, ByVal HOST_CF As String, ByVal ID_MUESTRA As String) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_UCF As New N_IRIS_WEBF_GRABA_CODIGO_FONASA
        Dim Data_UCF As Integer
        Data_UCF = NN_UCF.IRIS_WEBF_GRABA_CODIGO_FONASA(COD_CF, DESC_CF, CORTO_CF, DIAS_CF, ID_ESTADO, SOLA_CF, IMP_NOM_CF, IMP_SEL_CF, IMP_PAR_CF, HOST_CF, ID_MUESTRA)
        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Data_UCF, str_Builder)
        Return str_Builder.ToString
        Return Nothing
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 100, 101, 102
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class