Imports Entidades
Imports Datos

Public Class N_Search_Pac
    Dim DDD As D_Search_Pac

    Sub New()
        DDD = New D_Search_Pac
    End Sub

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC(ByVal PAC_RUT As String, ByVal PAC_DNI As String,
                                                               ByVal PAC_NAME As String, ByVal PAC_LASTN As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim ID_USER As Integer?

        If (IsNothing(galleta) = True) Then
            HttpContext.Current.Response.Redirect("/Index.aspx", False)
            Return Nothing
        Else
            ID_USER = CInt(galleta.Value)
            Return DDD.IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC(ID_USER, PAC_RUT, PAC_DNI, PAC_NAME, PAC_LASTN)
        End If

    End Function

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC(ByVal ID_PAC As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim ID_USER As Integer?

        If (IsNothing(galleta) = True) Then
            HttpContext.Current.Response.Redirect("/Index.aspx", False)
            Return Nothing
        Else
            ID_USER = CInt(galleta.Value)

            Dim listOut As New List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)
            listOut = DDD.IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC(ID_USER, ID_PAC)

            For Each item In listOut
                Dim NNN As New N_Encrypt

                item.ID_ENCRYPT = NNN.Encode(item.ID_ATE)
            Next

            Return listOut
        End If

    End Function

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ATE_NUM(ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim ID_USER As Integer?

        If (IsNothing(galleta) = True) Then
            HttpContext.Current.Response.Redirect("/Index.aspx", False)
            Return Nothing
        Else
            ID_USER = CInt(galleta.Value)

            Dim listOut As New List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)
            listOut = DDD.IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ATE_NUM(ID_USER, ATE_NUM)

            For Each item In listOut
                Dim NNN As New N_Encrypt

                item.ID_ENCRYPT = NNN.Encode(item.ID_ATE)
            Next

            Return listOut
        End If

    End Function

    Public Function IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE)
        Return DDD.IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE(ID_ATE)
    End Function
End Class
