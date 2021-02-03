Imports Entidades
Imports Negocio
Public Class HT_Exa

    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Examen() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)

        Data_CF = NN_CF.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As Date,
                                            ByVal HASTA As Date,
                                            ByVal ID_CF As Integer,
                                            ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3)
        'Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3(DESDE, HASTA, ID_CF, PROCEDENCIA)

        If (Data.Count > 0) Then
            For i = 0 To (Data.Count - 1)
                Data(i).ENCRYPTED_ID = N_ECrypt.Encode(Data(i).ID_ATENCION)
            Next i
            Return Data
        Else
            Return Nothing
        End If
    End Function
End Class