Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

Public Class Anul_Bon
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ATE_NUM As String) As E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED
        Dim Data_Estado_Mant As New E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED

        Data_Estado_Mant = NN.IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED(ATE_NUM)
        If (Data_Estado_Mant IsNot Nothing) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_det(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED)

        Data_Estado_Mant = NN.IRIS_WEBF_BUSCA_DETALLE_FOLIO_IMED(ID_ATENCION)
        If (Data_Estado_Mant IsNot Nothing) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function AnBonInt(ByVal CodUsuario As String,
                                    ByVal CodClave As String,
                                    ByVal CodFinanciador As String,
                                    ByVal OrigenLlamado As String,
                                    ByVal RutConvenio As String,
                                    ByVal RutBenef As String,
                                    ByVal FolioBono As String,
                                    ByVal UrlRetorno As String,
                                    ByVal S_Id_User As Integer) As AnBonInt.AnBonIntResponse

        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLBonInt As String

        'Definir URL Request Web Service
        URLBonInt = "http://interfaz4pre.bonoelectronico.cl/WsInterfaz.php"

        ''String Soap Request
        'SoapStr = "<?xml version=""1.0"" encoding=""utf-8""?>"
        'SoapStr = SoapStr & "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsInterfaz"">"
        'SoapStr = SoapStr & "<soapenv:Header/>"
        'SoapStr = SoapStr & "<soapenv:Body>"
        'SoapStr = SoapStr & "<urn:VtaBonInterfaz soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        'SoapStr = SoapStr & "<CodUsuario xsi:type=""xsd:String"">" + CodUsuario.ToString + "</CodUsuario>"
        'SoapStr = SoapStr & "<CodClave xsi:type=""xsd: String"">" + CodClave.ToString + "</CodClave>"
        'SoapStr = SoapStr & "<CodFinanciador xsi:type=""xsd: Int"">" + CodFinanciador + "</CodFinanciador>"
        'SoapStr = SoapStr & "<OrigenLlamado xsi:type=""xsd: Int"">" + OrigenLlamado + "</OrigenLlamado>"
        'SoapStr = SoapStr & "<RutConvenio xsi:type=""xsd: String"">" + RutConvenio.ToString + "</RutConvenio>"
        'SoapStr = SoapStr & "<RutBenef xsi:type=""xsd: String"">" + RutBenef.ToString + "</RutBenef>"
        'SoapStr = SoapStr & "<FolioBono xsi:type=""xsd: Int"">" + FolioBono.ToString + "</FolioBono>"
        'SoapStr = SoapStr & "<UrlRetorno xsi:type=""xsd: String"">" + "http://interfaz4pre.bonoelectronico.cl/WsInterfaz.php" + "</UrlRetorno>"
        'SoapStr = SoapStr & "</urn:VtaBonInterfaz>"
        'SoapStr = SoapStr & "</soapenv:Body>"
        'SoapStr = SoapStr & "</soapenv:Envelope>"

        SoapStr = "<?xml version=""1.0"" encoding=""utf-8""?>"
        SoapStr = SoapStr & "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsInterfaz"">"
        SoapStr = SoapStr & "<soapenv:Header/>"
        SoapStr = SoapStr & "<soapenv:Body>"
        SoapStr = SoapStr & "<urn:AnBonInt soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        SoapStr = SoapStr & "<CodUsuario xsi:type=""xsd:String"">" + CodUsuario + "</CodUsuario>"
        SoapStr = SoapStr & "<CodClave xsi:type=""xsd: String"">" + CodClave + "</CodClave>"
        SoapStr = SoapStr & "<CodFinanciador xsi:type=""xsd: Int"">" + CodFinanciador.ToString + "</CodFinanciador>"
        SoapStr = SoapStr & "<OrigenLlamado xsi:type=""xsd: Int"">" + OrigenLlamado + "</OrigenLlamado>"
        SoapStr = SoapStr & "<RutConvenio xsi:type=""xsd: String"">" + RutConvenio + "</RutConvenio>"
        SoapStr = SoapStr & "<RutBenef xsi:type=""xsd: String"">" + RutBenef + "</RutBenef>"
        SoapStr = SoapStr & "<FolioBono xsi:type=""xsd: Int"">" + FolioBono + "</FolioBono>"
        SoapStr = SoapStr & "<UrlRetorno xsi:type=""xsd: String"">" + UrlRetorno + "</UrlRetorno>"
        SoapStr = SoapStr & "</urn:AnBonInt>"
        SoapStr = SoapStr & "</soapenv:Body>"
        SoapStr = SoapStr & "</soapenv:Envelope>"


        Try
            'Soap String a Byte
            SoapByte = System.Text.Encoding.UTF8.GetBytes(SoapStr)
            '** Crear POST Request con URL del Web Service
            Request = HttpWebRequest.Create(URLBonInt)
            Request.KeepAlive = True
            Request.ContentType = "text/xml; charset=utf-8"
            Request.ContentLength = SoapByte.Length
            Request.Method = "POST"
            'Agregar Headers para Decompresión GZip
            Request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate;q=0.8")
            Request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            'Declarar Encode UTF-8
            Dim Enc As Encoding = Encoding.GetEncoding("utf-8")

            'Iniciar Request
            DataStream = Request.GetRequestStream()
            DataStream.Write(SoapByte, 0, SoapByte.Length)
            DataStream.Close()
            'Declarar Variable Soap Response
            Dim SoapResponse As String

            'Leer Response y asignar a variable Soap Response
            Using _Response As HttpWebResponse = Request.GetResponse()
                Using _DataStream As Stream = _Response.GetResponseStream()
                    Using Reader As StreamReader = New StreamReader(_DataStream, Enc)
                        SoapResponse = Reader.ReadToEnd()
                    End Using
                End Using
            End Using

            'Declarar XDocSoap como XDocument
            Dim XDocSoap As XDocument = New XDocument()

            If SoapResponse <> Nothing Then
                'Parsear String SoapResponse en variable XDocSoap
                XDocSoap = XDocument.Parse(SoapResponse)
            End If

            'Declarar XNamespace para XSI y XSD (Se encuentran en el elemento Envelope del response SOAP)
            Dim nsXSI As XNamespace = "http://www.w3.org/2001/XMLSchema-instance"
            Dim nsXSD As XNamespace = "http://www.w3.org/2001/XMLSchema"

            'Declarar XElement XDocVerResulEmiResp y asignar solo el elemento "AnBonIntResponse" y namespace "urn:WsInterfaz" al que pertenece
            Dim XDocAnBonIntResp = XDocSoap.Descendants("{urn:WsInterfaz}AnBonIntResponse").First()

            'Asignar XNamespace XSI y XSD a Elemento XDocVerResulEmiResp
            XDocAnBonIntResp.Add(New XAttribute(XNamespace.Xmlns + "xsi", nsXSI))
            XDocAnBonIntResp.Add(New XAttribute(XNamespace.Xmlns + "xsd", nsXSD))

            'Declarar Variable DocBodyStr
            Dim DocBodyStr As String

            'Parsear XElement XDocVerResulEmiResp en variable DocBodyStr
            DocBodyStr = XDocAnBonIntResp.ToString

            'Declarar XRoot como XmlRootAttribute, asignando el elemento de raíz y namespace
            Dim XRoot As New XmlRootAttribute With {
            .ElementName = "AnBonInt",
            .Namespace = "urn:WsInterfaz",
            .IsNullable = True
            }

            'Declarar XMLSerializer, asignando el Type como AnBonIntResponse, y XMLRootAttribute como XRoot
            Dim Serialize As New XmlSerializer(GetType(AnBonInt.AnBonIntResponse), XRoot)

            'Declarar Variable ResAnBonInt
            Dim ResAnBonInt As AnBonInt.AnBonIntResponse = Nothing

            'Leer DocBodyStr con StringReader
            Using reader As New StringReader(DocBodyStr)
                'Deserializar DocBodyStr (reader), asignando el Type AnBonIntResponse y guardar en variable AnBonInt
                ResAnBonInt = DirectCast(Serialize.Deserialize(reader), AnBonInt.AnBonIntResponse)
            End Using

            Dim est_bon As Integer = 0
            Dim NN_IMED_LOG As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS

            If (ResAnBonInt.CodError = 0) Then
                est_bon = NN_IMED_LOG.IRIS_WEBF_CMVM_ESTADO_BONO_IMED(S_Id_User, "BONO ANULADO: " & FolioBono, FolioBono)
            End If


            Return ResAnBonInt
        Catch ex As WebException
            Return Nothing
        End Try
    End Function

    <Services.WebMethod()>
    Public Shared Function AnulBol(ByVal CodUsuario As String,
                                       ByVal CodClave As String,
                                       ByVal NumTransac As Integer,
                                       ByVal CodAuditoria As String,
                                       ByVal S_Id_User As Integer,
                                     ByVal ID_PROCEDENCIA As Integer,
                                     ByVal ID_PREVISION As Integer) As String

        'Dim loguito As Integer = 0
        'Dim NN_IMED_LOG As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        'Dim FOLIO_BONOS As String = ""

        'If (ObtBon.CodError = 0) Then
        '    For i = 0 To ObtBon.ListaBonos.Count - 1
        '        If (i = 0) Then
        '            FOLIO_BONOS = ObtBon.ListaBonos(0).FolioBono
        '        Else
        '            If (ObtBon.ListaBonos(i).FolioBono <> ObtBon.ListaBonos(i - 1).FolioBono) Then
        '                FOLIO_BONOS += "," & ObtBon.ListaBonos(i).FolioBono
        '            End If

        '        End If
        '    Next i
        '    loguito = NN_IMED_LOG.IRIS_WEBF_CMVM_GRABA_LOG_IMED_VTABONINTERFAZ(S_Id_User, ID_PROCEDENCIA, ID_PREVISION, ObtBon.RutBenef, "RESPUESTA SOLICITUD DE BONO - FolioBono: " & FOLIO_BONOS)

        'ElseIf (ObtBon.CodError = 1) Then
        '    loguito = NN_IMED_LOG.IRIS_WEBF_CMVM_GRABA_LOG_IMED_VTABONINTERFAZ(S_Id_User, ID_PROCEDENCIA, ID_PREVISION, ObtBon.RutBenef, "RESPUESTA SOLICITUD DE BONO - ERROR: " & ObtBon.GloError)
        'Else
        '    loguito = NN_IMED_LOG.IRIS_WEBF_CMVM_GRABA_LOG_IMED_VTABONINTERFAZ(S_Id_User, ID_PROCEDENCIA, ID_PREVISION, ObtBon.RutBenef, "RESPUESTA SOLICITUD DE BONO - FolioBono: ERROR NO IDENTIFICADO")
        'End If

        'Return Nothing
        'End Try

    End Function
End Class






