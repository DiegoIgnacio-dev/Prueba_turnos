Imports Entidades
Imports Negocio
Public Class Adm_TM
    Inherits System.Web.UI.Page
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
    Public Shared Function Llenar_Ddl_Estados() As List(Of E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS()
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

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
    Public Shared Function Llenar_DL_ordenATE() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO = New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO

        data_paciente = NN.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORD As Integer, ByVal ID_PROC As Integer, ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)

        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER

        Data_OUT = NN_Search.IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS(DESDE, HASTA, ID_ORD, ID_PROC, ID_ESTADO)

        'If (Data_OUT.Count > 0) Then
        '    For i = 0 To Data_OUT.Count - 1
        '        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_OUT(i).ATE_NUM)

        '        If (Data_Estado_Mant_2.Count > 0) Then
        '            Data_OUT(i).DOCS_CANT = Data_Estado_Mant_2.Count
        '        Else
        '            Data_OUT(i).DOCS_CANT = 0
        '        End If
        '    Next i
        'End If

        If (Data_OUT.Count > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Estado_Atendido(ByVal ID_ATE As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USER)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Muestras(ByVal ATE_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_TM)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim LST_MUE As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_TM)
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION

        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        LST_MUE = NN_Search.IRIS_WEBF_BUSCA_ETIQUETAS_TM(ATE_NUM)
        If (LST_MUE.Count > 0) Then
            Return LST_MUE
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Actualiza_Obs(ByVal ATE_NUM As Integer, ByVal OBS As String) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_OBS_ATENCION(ATE_NUM, OBS)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Estado_Pendiente(ByVal ID_ATE As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USER)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As Integer = CType(objSession("P_ADMIN"), Integer)
        'If C_P_ADMIN = 0 Then
        '    Response.Redirect("~/Index.aspx")
        'End If
    End Sub
End Class