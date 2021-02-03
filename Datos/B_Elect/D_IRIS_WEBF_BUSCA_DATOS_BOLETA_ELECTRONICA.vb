'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions


    Function IRIS_WEBF_BUSCA_CORRELATIVO_B_ELECT() As Long
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As Long
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CORRELATIVO_B_ELECT"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_BUSCA_CORRELATIVO_A_BOLET() As Long
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As Long
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CORRELATIVO_A_BOLET"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_REPORTE_BOLETA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_REPORTE_BOLETA)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_REPORTE_BOLETA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_REPORTE_BOLETA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_REPORTE_BOLETA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_PROCEDENCIA", OleDbType.Integer).Value = ID_PROCEDENCIA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_REPORTE_BOLETA

            E_Proc_Item.FOLIO = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "") + " " + DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.RUT = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.COD = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.EXAMEN = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.TP_PAGO = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.BOLETA = DD_GEN.DB_NULL(Obj_Reader, 9, "")

            Dim V_PREV As Integer

            V_PREV = DD_GEN.DB_NULL(Obj_Reader, 10, "")

            Dim _S_IVA As Double = (V_PREV / 1.19) * 0.19
            _S_IVA = Math.Round(_S_IVA, 0)
            Dim _S_MntNeto As Integer
            _S_MntNeto = V_PREV - _S_IVA



            E_Proc_Item.NETO = _S_MntNeto
            E_Proc_Item.IVA = _S_IVA
            E_Proc_Item.TOTAL = V_PREV

            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_DATOS_BOLETA_FECHA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_BOL_ATE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_BOL_ATE
        Dim E_Proc_List As New List(Of E_BOL_ATE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_BOLETA_FECHA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_BOL_ATE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.FOLIO_CNE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.URL_BOLETA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.FOLIO_CNE_NC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.URL_NC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_USUARIO_CNE() As E_USU_CNE
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_USU_CNE
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_USUARIO_CNE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_USU_CNE
            E_Proc_Item.USU_CNE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PASS_CNE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_USU_CNE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_EMPRESA_CNE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_BUSCA_DATOS_ATE_BOLETA_ELECTRONICA(ByVal ATE_NUM As String) As E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_ATE_BOLETA_ELECTRONICA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_BUSCA_PARAMS_BOLETA_ELECTRONICA(ByVal FOLIO As String) As E_PARAMS_BE
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_PARAMS_BE
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PARAMS_BOLETA_ELECTRONICA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_PARAMS_BE
            E_Proc_Item.Folio = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.FormaEmision = DD_GEN.DB_NULL(Obj_Reader, 1, 1)

            If E_Proc_Item.FormaEmision = 1 Or E_Proc_Item.FormaEmision = 2 Or E_Proc_Item.FormaEmision = 20 Then
                E_Proc_Item.FormaEmision = 1
            End If

            E_Proc_Item.RUTReceptor = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.RznSocRecep = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 3, ""))
            E_Proc_Item.DirRecep = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 4, ""))
            E_Proc_Item.CmnaRecep = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 5, ""))
            E_Proc_Item.CiudadRecep = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 6, ""))
            E_Proc_Item.RazonRef = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 7, ""))
            E_Proc_Item.CodVndor = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 8, ""))
            E_Proc_Item.CodCaja = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 9, ""))
            'Agregar items a la lista

        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_BOLETA_ELECTRONICA(ByVal FOLIO As String) As List(Of E_DETALLE_BE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_DETALLE_BE
        Dim E_Proc_List As New List(Of E_DETALLE_BE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DETALLE_BOLETA_ELECTRONICA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read

            E_Proc_Item = New E_DETALLE_BE
            E_Proc_Item.NmbItem = QuitarCaracteres(DD_GEN.DB_NULL(Obj_Reader, 0, Nothing))

            If E_Proc_Item.NmbItem.Length > 27 Then
                E_Proc_Item.NmbItem = E_Proc_Item.NmbItem.Substring(0, 25) + "..."
            End If

            E_Proc_Item.PrcItem = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.IndExe = 0
            E_Proc_Item.TieneIVA = 1
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GUARDA_DATOS_NOTA_CREDITO(ByVal ATE_NUM As String, ByVal FOLIO_CNE As String, ByVal URL_BOLETA As String, ByVal USUARIO As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GUARDA_DATOS_NOTA_CREDITO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@FOLIO_CNE", OleDbType.VarChar).Value = FOLIO_CNE
            .Add("@URL_BOLETA", OleDbType.VarChar).Value = URL_BOLETA
            .Add("@USUARIO", OleDbType.VarChar).Value = USUARIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function

    Function IRIS_WEBF_GUARDA_DATOS_DESVINCULAR_BE(ByVal ATE_NUM As String, ByVal FOLIO_CNE As String, ByVal USUARIO As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GUARDA_DATOS_DESVINCULAR_BE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@FOLIO_CNE", OleDbType.VarChar).Value = FOLIO_CNE
            .Add("@USUARIO", OleDbType.VarChar).Value = USUARIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function
    Function IRIS_WEBF_GUARDA_DATOS_BOLETA_ELECTRONICA(ByVal ATE_NUM As String, ByVal FOLIO_CNE As String, ByVal URL_BOLETA As String, ByVal USUARIO As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GUARDA_DATOS_BOLETA_ELECTRONICA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@FOLIO_CNE", OleDbType.VarChar).Value = FOLIO_CNE
            .Add("@URL_BOLETA", OleDbType.VarChar).Value = URL_BOLETA
            .Add("@USUARIO", OleDbType.VarChar).Value = USUARIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function
    Function IRIS_WEBF_BUSCA_RUTA_BOLETA_ELECTRONICA(ByVal ATE_NUM As String) As E_RUTA_DOC_BE
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_RUTA_DOC_BE
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RUTA_BOLETA_ELECTRONICA_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_RUTA_DOC_BE
            E_Proc_Item.FOLIO_CNE = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.URL_BOLETA = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.FECHA_EMISION_BE = DD_GEN.DB_NULL(Obj_Reader, 2, Date.Now)
            E_Proc_Item.FOLIO_CNE_NC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.URL_NC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.FECHA_EMISION_NC = DD_GEN.DB_NULL(Obj_Reader, 5, Date.Now)
            E_Proc_Item.CONT = DD_GEN.DB_NULL(Obj_Reader, 6, 0)

        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function


    Public Function QuitarCaracteres(ByVal str)
        Dim Car As String

        Car = str

        Car = Car.Replace("ª", "a")
        Car = Car.Replace("°", "o")
        Car = Car.Replace("á", "a")
        Car = Car.Replace("é", "e")
        Car = Car.Replace("í", "i")
        Car = Car.Replace("ó", "o")
        Car = Car.Replace("ú", "u")
        Car = Car.Replace("ñ", "n")
        Car = Car.Replace("Á", "A")
        Car = Car.Replace("É", "E")
        Car = Car.Replace("Í", "I")
        Car = Car.Replace("Ó", "O")
        Car = Car.Replace("Ú", "U")
        Car = Car.Replace("Ñ", "N")
        Car = Car.Replace("α", "Alpha")
        Car = Car.Replace("β", "Beta")
        Car = Car.Replace("γ", "Gamma")

        Dim i As Integer
        Dim nCadena As String
        On Error Resume Next

        Dim chars As String = ":<>{}[]^+;_/*?¿!$%&/¨Ññ()='áéíóúÁÉÍÓÚ¡|@Ã›°ªαβγ"
        nCadena = Car
        For i = 1 To Len(chars)
            nCadena = Replace(nCadena, Mid(chars, i, 1), "")
        Next i

        Return nCadena
    End Function

    Function IRIS_WEBF_BUSCA_DATOS_BOLETA_FECHA_3(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_BOL_ATE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_BOL_ATE
        Dim E_Proc_List As New List(Of E_BOL_ATE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_BOLETA_FECHA_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_BOL_ATE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.FOLIO_CNE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.URL_BOLETA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.FOLIO_CNE_NC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.URL_NC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.USUARIO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_REPORTE_BOLETA_USUARIO(ByVal DESDE As String, ByVal HASTA As String, ByVal USU_NIC As String) As List(Of E_BOL_ATE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_BOL_ATE
        Dim E_Proc_List As New List(Of E_BOL_ATE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_REPORTE_BOLETA_USUARIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@USU_NIC", OleDbType.VarChar).Value = USU_NIC
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_BOL_ATE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.FOLIO_CNE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.USUARIO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_REPORTE_BOLETA_USUARIO_2(ByVal DESDE As String, ByVal HASTA As String, ByVal USU_NIC As String) As List(Of E_BOL_ATE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_BOL_ATE
        Dim E_Proc_List As New List(Of E_BOL_ATE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_REPORTE_BOLETA_USUARIO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@USU_NIC", OleDbType.VarChar).Value = USU_NIC
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_BOL_ATE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.FOLIO_CNE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.USUARIO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.TOTAL = DD_GEN.DB_NULL(Obj_Reader, 8, 0)

            Dim V_PREV As Integer

            V_PREV = DD_GEN.DB_NULL(Obj_Reader, 8, "")

            Dim _S_IVA As Double = (V_PREV / 1.19) * 0.19
            _S_IVA = Math.Round(_S_IVA, 0)
            Dim _S_MntNeto As Integer
            _S_MntNeto = V_PREV - _S_IVA



            E_Proc_Item.NETO = _S_MntNeto
            E_Proc_Item.IVA = _S_IVA
            E_Proc_Item.TOTAL = V_PREV

            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
