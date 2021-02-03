Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports Entidades
Imports Negocio
Imports System.Web.Script.Serialization
Public Class WsImed
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function VtaBonInterfaz(ByVal CodUsuario As String,
                                   ByVal CodClave As String,
                                   ByVal CodFinanciador As Integer,
                                   ByVal CodLugar As Integer,
                                   ByVal RutConvenio As String,
                                   ByVal CorrConvenio As Integer,
                                   ByVal RutTratante As String,
                                   ByVal RutSolic As String,
                                   ByVal NomSolic As String,
                                   ByVal CodEspecia As String,
                                   ByVal RutBenef As String,
                                   ByVal RutCajero As String,
                                   ByVal IndUrgencia As String,
                                   ByVal CodTipoTratamiento As Integer,
                                   ByVal FecIniTratamiento As String,
                                   ByVal FecTerTratamiento As String,
                                   ByVal CantDias As Integer,
                                   ByVal FolioAntecedente As Integer,
                                   ByVal UrlRetExito As String,
                                   ByVal UrlRetError As String,
                                   ByVal ListPrestAut As List(Of ListPrestAut)
                                   ) As VtaBonInterfaz.VtaBonInterfazResponse

        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLBonInt As String

        'Definir URL Request Web Service
        URLBonInt = "http://interfaz3pre.bonoelectronico.cl/WsInterfaz.php"

        'String Soap Request
        SoapStr = "<?xml version=""1.0"" encoding=""utf-8""?>"
        SoapStr = SoapStr & "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsInterfaz"">"
        SoapStr = SoapStr & "<soapenv:Header/>"
        SoapStr = SoapStr & "<soapenv:Body>"
        SoapStr = SoapStr & "<urn:VtaBonInterfaz soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        SoapStr = SoapStr & "<CodUsuario xsi:type=""xsd:String"">" + CodUsuario + "</CodUsuario>"
        SoapStr = SoapStr & "<CodClave xsi:type=""xsd: String"">" + CodClave + "</CodClave>"
        SoapStr = SoapStr & "<CodFinanciador xsi:type=""xsd: Int"">" + CodFinanciador.ToString + "</CodFinanciador>"
        SoapStr = SoapStr & "<CodLugar xsi:type=""xsd: Int"">" + CodLugar.ToString + "</CodLugar>"
        SoapStr = SoapStr & "<RutConvenio xsi:type=""xsd: String"">" + RutConvenio + "</RutConvenio>"
        SoapStr = SoapStr & "<CorrConvenio xsi:type=""xsd: Int"">" + CorrConvenio.ToString + "</CorrConvenio>"
        SoapStr = SoapStr & "<RutTratante xsi:type=""xsd: String"">" + RutTratante + "</RutTratante>"
        SoapStr = SoapStr & "<RutSolic xsi:type=""xsd: String"">" + RutSolic + "</RutSolic>"
        SoapStr = SoapStr & "<NomSolic xsi:type=""xsd: String"">" + NomSolic + "</NomSolic>"
        SoapStr = SoapStr & "<CodEspecia xsi:type=""xsd: String"">" + CodEspecia + "</CodEspecia>"
        SoapStr = SoapStr & "<RutBenef xsi:type=""xsd: String"">" + RutBenef + "</RutBenef>"
        SoapStr = SoapStr & "<RutCajero xsi:type=""xsd: String"">" + RutCajero + "</RutCajero>"
        SoapStr = SoapStr & "<IndUrgencia xsi:type=""xsd: String"">" + IndUrgencia + "</IndUrgencia>"
        SoapStr = SoapStr & "<CodTipoTratamiento xsi:type=""xsd: Int"">" + CodTipoTratamiento.ToString + "</CodTipoTratamiento>"
        SoapStr = SoapStr & "<FecIniTratamiento xsi:type=""xsd: String"">" + FecIniTratamiento + "</FecIniTratamiento>"
        SoapStr = SoapStr & "<FecTerTratamiento xsi:type=""xsd: String"">" + FecTerTratamiento + "</FecTerTratamiento>"
        SoapStr = SoapStr & "<CantDias xsi:type=""xsd: Int"">" + CantDias.ToString + "</CantDias>"
        SoapStr = SoapStr & "<FolioAntecedente xsi:type=""xsd: Int"">" + FolioAntecedente.ToString + "</FolioAntecedente>"
        SoapStr = SoapStr & "<UrlRetExito xsi:type=""xsd: String"">" + UrlRetExito + "</UrlRetExito>"
        SoapStr = SoapStr & "<UrlRetError xsi:type=""xsd: String"">" + UrlRetError + "</UrlRetError>"
        SoapStr = SoapStr & "<ListaBonos xsi:type='ns1:ListaBonosArray'>"
        '@@@@@@@@@@@@@@@@ LISTA DE PRESTACIONES @@@@@@@@@@@@@@@@

        For Each x In ListPrestAut
            SoapStr = SoapStr & "<ListaBonosType xsi:type='ns1:ListaBonosType'>"
            SoapStr = SoapStr & "<CodPrestacion xsi:type=""xsd: String"">" + x.CodPrestacion + "</CodPrestacion>"
            SoapStr = SoapStr & "<CodItem xsi:type=""xsd: String"">" + x.CodItem + "</CodItem>"
            SoapStr = SoapStr & "<Cantidad xsi:type=""xsd: Int"">" + x.Cantidad + "</Cantidad>"
            SoapStr = SoapStr & "<RecargoHora xsi:type=""xsd: String"">" + x.RecargoHora + "</RecargoHora>"
            SoapStr = SoapStr & "<MtoTotal xsi:type=""xsd: Int"">" + x.MtoTotal + "</MtoTotal>"
            SoapStr = SoapStr & "<InfAdicional xsi:type=""xsd: String"">" + x.InfAdicional + "</InfAdicional>"
            SoapStr = SoapStr & "</ListaBonosType>"
        Next

        '@@@@@@@@@@@@@@@@ LISTA DE PRESTACIONES @@@@@@@@@@@@@@@@
        SoapStr = SoapStr & "</ListaBonos>"
        SoapStr = SoapStr & "</urn:VtaBonInterfaz>"
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

            'Declarar XElement XDocVtaBonInterfazResp y asignar solo el elemento "VtaBonInterfazResponse" y namespace "urn:WsInterfaz" al que pertenece
            Dim XDocVtaBonInterfazResp = XDocSoap.Descendants("{urn:WsInterfaz}VtaBonInterfazResponse").First()

            'Asignar XNamespace XSI y XSD a Elemento XDocVtaBonInterfazResp
            XDocVtaBonInterfazResp.Add(New XAttribute(XNamespace.Xmlns + "xsi", nsXSI))
            XDocVtaBonInterfazResp.Add(New XAttribute(XNamespace.Xmlns + "xsd", nsXSD))

            'Declarar Variable DocBodyStr
            Dim DocBodyStr As String

            'Parsear XElement XDocVtaBonInterfazResp en variable DocBodyStr
            DocBodyStr = XDocVtaBonInterfazResp.ToString

            'Declarar XRoot como XmlRootAttribute, asignando el elemento de raíz y namespace
            Dim XRoot As New XmlRootAttribute With {
            .ElementName = "VtaBonInterfazResponse",
            .Namespace = "urn:WsInterfaz",
            .IsNullable = True
            }

            'Declarar XMLSerializer, asignando el Type como VtaBonInterfazResponse, y XMLRootAttribute como XRoot
            Dim Serialize As New XmlSerializer(GetType(VtaBonInterfaz.VtaBonInterfazResponse), XRoot)

            'Declarar Variable VtaBonInt
            Dim VtaBonInt As VtaBonInterfaz.VtaBonInterfazResponse = Nothing

            'Leer DocBodyStr con StringReader
            Using reader As New StringReader(DocBodyStr)
                'Deserializar DocBodyStr (reader), asignando el Type VtaBonInterfazResponse y guardar en variable VtaBonInt
                VtaBonInt = DirectCast(Serialize.Deserialize(reader), VtaBonInterfaz.VtaBonInterfazResponse)
            End Using

            Return VtaBonInt
        Catch ex As WebException
            Return Nothing
        End Try
    End Function

    Public Shared Function VerResulEmi(ByVal CodUsuario As String, ByVal CodClave As String, ByVal NumTransac As Integer) As VerResulEmi.VerResulEmiResponse
        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLBonInt As String

        'Definir URL Request Web Service
        URLBonInt = "http://interfaz3pre.bonoelectronico.cl/WsInterfaz.php"

        'String Soap Request
        SoapStr = "<?xml version=""1.0"" encoding=""utf-8""?>"
        SoapStr = SoapStr & "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsInterfaz"">"
        SoapStr = SoapStr & "<soapenv:Header/>"
        SoapStr = SoapStr & "<soapenv:Body>"
        SoapStr = SoapStr & "<urn:VerResulEmi soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        SoapStr = SoapStr & "<CodUsuario xsi:type=""xsd:String"">" + CodUsuario + "</CodUsuario>"
        SoapStr = SoapStr & "<CodClave xsi:type=""xsd: String"">" + CodClave + "</CodClave>"
        SoapStr = SoapStr & "<NumTransac xsi:type=""xsd: Int"">" + NumTransac.ToString + "</NumTransac>"
        SoapStr = SoapStr & "</urn:VerResulEmi>"
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

            'Declarar XElement XDocVerResulEmiResp y asignar solo el elemento "VerResulEmiResponse" y namespace "urn:WsInterfaz" al que pertenece
            Dim XDocVerResulEmiResp = XDocSoap.Descendants("{urn:WsInterfaz}VerResulEmiResponse").First()

            'Asignar XNamespace XSI y XSD a Elemento XDocVerResulEmiResp
            XDocVerResulEmiResp.Add(New XAttribute(XNamespace.Xmlns + "xsi", nsXSI))
            XDocVerResulEmiResp.Add(New XAttribute(XNamespace.Xmlns + "xsd", nsXSD))

            'Declarar Variable DocBodyStr
            Dim DocBodyStr As String

            'Parsear XElement XDocVerResulEmiResp en variable DocBodyStr
            DocBodyStr = XDocVerResulEmiResp.ToString

            'Declarar XRoot como XmlRootAttribute, asignando el elemento de raíz y namespace
            Dim XRoot As New XmlRootAttribute With {
            .ElementName = "VerResulEmiResponse",
            .Namespace = "urn:WsInterfaz",
            .IsNullable = True
            }

            'Declarar XMLSerializer, asignando el Type como VerResulEmiResponse, y XMLRootAttribute como XRoot
            Dim Serialize As New XmlSerializer(GetType(VerResulEmi.VerResulEmiResponse), XRoot)

            'Declarar Variable VerResEmi
            Dim VerResEmi As VerResulEmi.VerResulEmiResponse = Nothing

            'Leer DocBodyStr con StringReader
            Using reader As New StringReader(DocBodyStr)
                'Deserializar DocBodyStr (reader), asignando el Type VerResulEmiResponse y guardar en variable VerResEmi
                VerResEmi = DirectCast(Serialize.Deserialize(reader), VerResulEmi.VerResulEmiResponse)
            End Using

            Return VerResEmi
        Catch ex As WebException
            Return Nothing
        End Try
    End Function

    Public Shared Function ObtBonInterfaz(ByVal CodUsuario As String, ByVal CodClave As String, ByVal NumTransac As Integer) As ObtBonInterfaz.ObtBonInterfazResponse
        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLBonInt As String

        'Definir URL Request Web Service
        URLBonInt = "http://interfaz3pre.bonoelectronico.cl/WsInterfaz.php"

        'String Soap Request
        SoapStr = "<?xml version=""1.0"" encoding=""utf-8""?>"
        SoapStr = SoapStr & "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsInterfaz"">"
        SoapStr = SoapStr & "<soapenv:Header/>"
        SoapStr = SoapStr & "<soapenv:Body>"
        SoapStr = SoapStr & "<urn:ObtBonInterfaz soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        SoapStr = SoapStr & "<CodUsuario xsi:type=""xsd:String"">" + CodUsuario + "</CodUsuario>"
        SoapStr = SoapStr & "<CodClave xsi:type=""xsd: String"">" + CodClave + "</CodClave>"
        SoapStr = SoapStr & "<NumTransac xsi:type=""xsd: Int"">" + NumTransac.ToString + "</NumTransac>"
        SoapStr = SoapStr & "</urn:ObtBonInterfaz>"
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

            'Declarar XElement XDocObtBonIntResp y asignar solo el elemento "ObtBonInterfazResponse" y namespace "urn:WsInterfaz" al que pertenece
            Dim XDocObtBonIntResp = XDocSoap.Descendants("{urn:WsInterfaz}ObtBonInterfazResponse").First()

            'Asignar XNamespace XSI y XSD a Elemento XDocObtBonIntResp
            XDocObtBonIntResp.Add(New XAttribute(XNamespace.Xmlns + "xsi", nsXSI))
            XDocObtBonIntResp.Add(New XAttribute(XNamespace.Xmlns + "xsd", nsXSD))

            'Declarar Variable DocBodyStr
            Dim DocBodyStr As String

            'Parsear XElement XDocObtBonIntResp en variable DocBodyStr
            DocBodyStr = XDocObtBonIntResp.ToString

            'Declarar XRoot como XmlRootAttribute, asignando el elemento de raíz y namespace
            Dim XRoot As New XmlRootAttribute With {
            .ElementName = "ObtBonInterfazResponse",
            .Namespace = "urn:WsInterfaz",
            .IsNullable = True
            }

            'Declarar XMLSerializer, asignando el Type como ObtBonInterfazResponse, y XMLRootAttribute como XRoot
            Dim Serialize As New XmlSerializer(GetType(ObtBonInterfaz.ObtBonInterfazResponse), XRoot)

            'Declarar Variable ObtBon
            Dim ObtBon As ObtBonInterfaz.ObtBonInterfazResponse = Nothing

            'Leer DocBodyStr con StringReader
            Using reader As New StringReader(DocBodyStr)
                'Deserializar DocBodyStr (reader), asignando el Type ObtBonInterfazResponse y guardar en variable ObtBon
                ObtBon = DirectCast(Serialize.Deserialize(reader), ObtBonInterfaz.ObtBonInterfazResponse)
            End Using

            Return ObtBon
            ''INICIO COMENTAR
            ''Tratamiento de Propiedades de <ObtBon>: 
            ''CodFinanciador, RutConvenio, CorrConvenio, RutTratante, RutSolic, 
            ''NomSolic, CodEspecia, RutBenef, IndUrgencia, CodError, GloError
            ''_________________________________________________________________

            ''Obtener Lista de Bonos
            'Dim LstBon As List(Of ObtBonInterfaz.ListaBonosType) = ObtBon.ListaBonos

            ''**Recorrer Lista de Bonos como Bono
            'For Each Bono In LstBon

            '    'Tratamiento de Propiedades de <Bono>: FolioBono, FecEmi, NumPrestBon, NumBoleta, MontoAfecto, MontoExento, MontoTotal
            '    '____________________________________________________________________________________________________________________

            '    'Lista de Prestaciones Venta
            '    Dim LstPrestVta As List(Of ObtBonInterfaz.LisPrestVtaType) = Bono.LisPrestVta

            '    '**Recorrer Lista Prestaciones Venta como Prest
            '    For Each Prest In LstPrestVta
            '        'Tratamiento de Propiedades de <LstPrestVta>: 
            '        'CodPrestacion, CodItem, Cantidad, RecargoHora, MontoPrest, MontoBon, 
            '        'MontoCopago, EsGes, CodPatologia, CodIntSanitaria, CodCanasta, NumPieza
            '        '_______________________________________________________________________

            '        'Lista de Otras Bonificaciones
            '        Dim LstOtrasBon As List(Of ObtBonInterfaz.ListaOtrasBonType) = Prest.ListaOtrasBon

            '        '**Recorrer Lista Otras Bonificaciones como OtrasBon
            '        For Each OtrasBon In LstOtrasBon
            '            'Tratamiento de Propiedades <OtrasBon>: CodBonAdic, GloBonAdic, MtoBonAdic
            '            '________________________________________________________________________
            '        Next

            '    Next

            'Next

            ''Obtener Lista de Forma Pago
            'Dim LstForPag As List(Of ObtBonInterfaz.ListaForPagType) = ObtBon.ListaForPag

            ''**Recorrer Lista de Forma Pago como ForPag
            'For Each ForPag In LstForPag

            '    'Tratamiento de Propiedades <ForPag>:CodForPag, NumDo,c CodInst, CodEmi, EmiTarBan, CodAuto, MtoTransac
            '    '______________________________________________________________________________________________________
            'Next
            ''FIN COMENTAR
        Catch ex As WebException
            Return Nothing
        End Try

    End Function
End Class
