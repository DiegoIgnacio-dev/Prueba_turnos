Imports Entidades
Imports Negocio
Public Class Grabar_Email
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Busca_Dest() As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_DEST)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_BUSCA_LISTA_DEST_COPY
        Dim Data_OUT As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_DEST)

        Data_OUT = NN_Search.IRIS_WEBF_CMVM_BUSCA_LISTA_DEST()
        If (Data_OUT.Count > 0) Then
            Return Data_OUT

        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Busca_Copy() As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_COPY)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_BUSCA_LISTA_DEST_COPY
        Dim Data_OUT As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_COPY)

        Data_OUT = NN_Search.IRIS_WEBF_CMVM_BUSCA_LISTA_COPY()
        If (Data_OUT.Count > 0) Then
            Return Data_OUT

        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Graba_Email(ByVal Email As String, ByVal Nombre As String, ByVal Tipo As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_GRABA_EMAIL
        Dim Data_OUT As Integer

        Data_OUT = NN_Search.IRIS_WEBF_CMVM_GRABA_EMAIL(Email, Nombre, Tipo)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Cambia_Estado_Email(ByVal NAME As Integer, ByVal ID_EMAIL As Integer, ByVal ESTADO As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL
        Dim Data_OUT As Integer

        Data_OUT = NN_Search.IRIS_WEBF_CMVM_CAMBIA_ESTADO_EMAIL(NAME, ID_EMAIL, ESTADO)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
End Class