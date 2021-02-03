Imports Entidades
Imports Negocio

Public Class Search_Pac
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function GET_Pacientes(ByVal PAC_RUT As String, ByVal PAC_DNI As String,
                                         ByVal PAC_NAME As String, ByVal PAC_LASTN As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC)

        Return (New N_Search_Pac).IRIS_WEBF_CMVM_BUSCA_PACIENTES_BY_DATA_PAC(PAC_RUT, PAC_DNI, PAC_NAME, PAC_LASTN)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Atenc_By_ID_PAC(ByVal ID_PAC As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)

        Return (New N_Search_Pac).IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC(ID_PAC)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Atenc_By_ATE_NUM(ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ID_PAC)

        Return (New N_Search_Pac).IRIS_WEBF_CMVM_BUSCA_PACIENTES_ATE_BY_ATE_NUM(ATE_NUM)
    End Function

    <Services.WebMethod()>
    Public Shared Function GET_Ate_Det(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE)

        Return (New N_Search_Pac).IRIS_WEBF_CMVM_BUSCA_PACIENTES_DET_ATE(ID_ATE)
    End Function
End Class