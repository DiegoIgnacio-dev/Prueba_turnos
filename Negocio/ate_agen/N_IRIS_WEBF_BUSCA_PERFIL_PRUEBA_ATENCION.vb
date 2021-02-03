'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
    End Sub
    Function IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        Return DD_Data.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ID_PER)
    End Function
End Class