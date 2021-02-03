'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    Sub New()

        DD_Data = New D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    End Sub
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function



    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2(ByVal DESDE As Date,
                                                             ByVal HASTA As Date,
                                                             ByVal ID_CF As Integer,
                                                             ByVal ID_PRUEBA As Integer,
                                                             ByVal Procedencia As Integer,
                                                             ByVal Ddl_previ As Integer,
                                                             ByVal Ddl_programa As Integer,
                                                             ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE(ByVal DESDE As Date,
                                                         ByVal HASTA As Date,
                                                         ByVal ID_CF As Integer,
                                                         ByVal ID_PRUEBA As Integer,
                                                         ByVal Procedencia As Integer,
                                                         ByVal Ddl_previ As Integer,
                                                         ByVal Ddl_programa As Integer,
                                                         ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO(ByVal DESDE As Date,
                                                     ByVal HASTA As Date,
                                                     ByVal ID_CF As Integer,
                                                     ByVal ID_PRUEBA As Integer,
                                                     ByVal Procedencia As Integer,
                                                     ByVal Ddl_previ As Integer,
                                                     ByVal Ddl_programa As Integer,
                                                     ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION_RESU(ByVal DESDE As Date,
                                                     ByVal HASTA As Date,
                                                     ByVal ID_CF As Integer,
                                                     ByVal ID_PRUEBA As Integer,
                                                     ByVal Procedencia As Integer,
                                                     ByVal Ddl_previ As Integer,
                                                     ByVal Ddl_programa As Integer,
                                                     ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS_1_DETERMINACION_RESU(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS(ByVal DESDE As Date,
                                                 ByVal HASTA As Date,
                                                 ByVal ID_CF As Integer,
                                                 ByVal ID_PRUEBA As Integer,
                                                 ByVal Procedencia As Integer,
                                                 ByVal Ddl_previ As Integer,
                                                 ByVal Ddl_programa As Integer,
                                                 ByVal Ddl_subPrograma As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_SOLO_MULTIPLE_TRANSMITIDO_TODOS(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC, Procedencia, Ddl_previ, Ddl_programa, Ddl_subPrograma)
    End Function
End Class