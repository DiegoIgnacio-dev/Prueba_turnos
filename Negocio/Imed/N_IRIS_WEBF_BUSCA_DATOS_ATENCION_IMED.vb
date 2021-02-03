Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED


    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED
    End Sub
    Function IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED(ByVal FOLIO As String) As E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED

        Dim Params_Ret As New E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED
        Params_Ret = DD_Data.IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED(FOLIO)
        'Params_Ret.Lst_Detalle = DD_Data.IRIS_WEBF_BUSCA_DETALLE_BOLETA_ELECTRONICA(FOLIO) 

        Return Params_Ret
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_FOLIO_IMED(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED)

        Dim Params_Ret As New List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED)
        Params_Ret = DD_Data.IRIS_WEBF_BUSCA_DETALLE_FOLIO_IMED(ID_ATENCION)

        Return Params_Ret
    End Function


End Class
