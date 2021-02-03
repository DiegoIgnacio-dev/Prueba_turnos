Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

Public Class Ingreso_Ate_Caja6_Boleta
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
        URLBonInt = "http://interfaz4pre.bonoelectronico.cl/WsInterfaz.php"

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
        SoapStr = SoapStr & "<LisPrestAut xsi:type='ns1:LisPrestAutArray'>"
        '@@@@@@@@@@@@@@@@ LISTA DE PRESTACIONES @@@@@@@@@@@@@@@@

        For Each x In ListPrestAut
            SoapStr = SoapStr & "<LisPrestAutType xsi:type='ns1:LisPrestAutType'>"
            SoapStr = SoapStr & "<CodPrestacion xsi:type=""xsd: String"">" + x.CodPrestacion + "</CodPrestacion>"
            SoapStr = SoapStr & "<CodItem xsi:type=""xsd: String"">" + x.CodItem + "</CodItem>"
            SoapStr = SoapStr & "<Cantidad xsi:type=""xsd: Int"">" + x.Cantidad.ToString + "</Cantidad>"
            SoapStr = SoapStr & "<RecargoHora xsi:type=""xsd: String"">" + x.RecargoHora + "</RecargoHora>"
            SoapStr = SoapStr & "<MtoTotal xsi:type=""xsd: Int"">" + x.MtoTotal.ToString + "</MtoTotal>"
            SoapStr = SoapStr & "<InfAdicional xsi:type=""xsd: String"">" + x.InfAdicional + "</InfAdicional>"
            SoapStr = SoapStr & "</LisPrestAutType>"
        Next

        '@@@@@@@@@@@@@@@@ LISTA DE PRESTACIONES @@@@@@@@@@@@@@@@
        SoapStr = SoapStr & "</LisPrestAut>"
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
            'Return "ok"
        Catch ex As WebException
            Return Nothing
        End Try
    End Function
    <Services.WebMethod()>
    Public Shared Function VerResulEmi(ByVal CodUsuario As String, ByVal CodClave As String, ByVal NumTransac As Integer) As VerResulEmi.VerResulEmiResponse
        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLBonInt As String

        'Definir URL Request Web Service
        URLBonInt = "http://interfaz4pre.bonoelectronico.cl/WsInterfaz.php"

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
    <Services.WebMethod()>
    Public Shared Function ObtBonInterfaz(ByVal CodUsuario As String, ByVal CodClave As String, ByVal NumTransac As Integer) As ObtBonInterfaz.ObtBonInterfazResponse
        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLBonInt As String

        'Definir URL Request Web Service
        URLBonInt = "http://interfaz4pre.bonoelectronico.cl/WsInterfaz.php"

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

            'Return ObtBon                           '<-----------------------------------------------------

            'INICIO COMENTAR
            'Tratamiento de Propiedades de <ObtBon>: 
            'CodFinanciador, RutConvenio, CorrConvenio, RutTratante, RutSolic, 
            'NomSolic, CodEspecia, RutBenef, IndUrgencia, CodError, GloError
            '_________________________________________________________________

            'Obtener Lista de Bonos
            Dim LstBon As List(Of ObtBonInterfaz.ListaBonosType) = ObtBon.ListaBonos

            '**Recorrer Lista de Bonos como Bono
            For Each Bono In LstBon

                'Tratamiento de Propiedades de <Bono>: FolioBono, FecEmi, NumPrestBon, NumBoleta, MontoAfecto, MontoExento, MontoTotal
                '____________________________________________________________________________________________________________________

                'Lista de Prestaciones Venta
                Dim LstPrestVta As List(Of ObtBonInterfaz.LisPrestVtaType) = Bono.LisPrestVta

                '**Recorrer Lista Prestaciones Venta como Prest
                For Each Prest In LstPrestVta
                    'Tratamiento de Propiedades de <LstPrestVta>: 
                    'CodPrestacion, CodItem, Cantidad, RecargoHora, MontoPrest, MontoBon, 
                    'MontoCopago, EsGes, CodPatologia, CodIntSanitaria, CodCanasta, NumPieza
                    '_______________________________________________________________________

                    'Lista de Otras Bonificaciones
                    Dim LstOtrasBon As List(Of ObtBonInterfaz.ListaOtrasBonType) = Prest.ListaOtrasBon

                    '**Recorrer Lista Otras Bonificaciones como OtrasBon
                    For Each OtrasBon In LstOtrasBon
                        'Tratamiento de Propiedades <OtrasBon>: CodBonAdic, GloBonAdic, MtoBonAdic
                        '________________________________________________________________________
                    Next

                Next

            Next

            'Obtener Lista de Forma Pago
            Dim LstForPag As List(Of ObtBonInterfaz.ListaForPagType) = ObtBon.ListaForPag

            '**Recorrer Lista de Forma Pago como ForPag
            For Each ForPag In LstForPag

                'Tratamiento de Propiedades <ForPag>:CodForPag, NumDo,c CodInst, CodEmi, EmiTarBan, CodAuto, MtoTransac
                '______________________________________________________________________________________________________
            Next
            'FIN COMENTAR
        Catch ex As WebException
            Return Nothing
        End Try

    End Function

    '----------------------------------------------------------------------- FIN IMED -------------------------------------------------------------------------------------------------------------
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2_particular(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_particular As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN_particular As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION

        Dim ANO As Date
        ANO = CDate(Fecha)

        data_particular = NN_particular.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_PARTICULAR_BONIFICACION(Format(ANO, "yyyy"), 185)

        If (data_particular.Count > 0) Then

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_particular, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_BONIFICACION(Format(ANO, "yyyy"), ID_PREVE)
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam_pack(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK_2_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function tipo_pago() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Dim NN As N_Gen_Activos = New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function Request_Prevision(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_PROCEDENCIA_ACTIVO(ID_PROC)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_Programa(ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        Dim NN As New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_SubPrograma(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_Async_SubP)
        Dim NN_Activo As New N_Gen_Activos

        Return NN_Activo.Request_SubPrograma(ID_PREV, ID_PROG)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String) As REEE


        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_NEW(ID)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_2_NEW(ID)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_NEW(ID)
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal fecha As String, ByVal id As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        data_procedencia = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX(Date.Now, id)
        If data_procedencia.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_procedencia, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    '<Services.WebMethod()>
    'Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
    '                                         ByVal NOMBRE_PAC As String,
    '                                         ByVal APE_PAC As String,
    '                                         ByVal FNAC_PAC As String,
    '                                         ByVal ID_SEXO As Integer,
    '                                         ByVal ID_NACIONALIDAD As Integer,
    '                                         ByVal FONO1 As String,
    '                                         ByVal MOVIL1 As String,
    '                                         ByVal ID_CIU_COM As Integer,
    '                                         ByVal DIR_PAC As String,
    '                                         ByVal EMAIL_PAC As String,
    '                                         ByVal FUR As String,
    '                                         ByVal Paridad As String,
    '                                         ByVal ID_PAC As String,
    '                                         ByVal OB As String,
    '                                         ByVal Procedencia As Integer,
    '                                         ByVal Programa As Integer,
    '                                         ByVal Sector As Integer,
    '                                         ByVal TipoAtencion As Integer,
    '                                         ByVal PrioridadTM As Integer,
    '                                         ByVal Doctor As Integer,
    '                                         ByVal Prevision As Integer,
    '                                         ByVal EDAD As Integer,
    '                                         ByVal MES As Integer,
    '                                         ByVal DIA As Integer,
    '                                         ByVal TOTAL As Integer,
    '                                         ByVal FECHA_PRE As String,
    '                                         ByVal ids As List(Of ids2_caja),
    '                                         ByVal ate_obs As String,
    '                                         ByVal Interno As String,
    '                                         ByVal id_Diag As String,
    '                                         ByVal id_Diag2 As String,
    '                                         ByVal sub_atencion As String,
    '                                         ByVal vih As String,
    '                                         ByVal dni As String,
    '                                        ByVal ATE_V_SISTEMA As String,                 'PARÁMETROS  CAJA
    '                                        ByVal ATE_V_BENEF As String,
    '                                        ByVal ATE_V_CF As String,
    '                                        ByVal ATE_V_CF_FP As String,
    '                                        ByVal ATE_V_CP As String,
    '                                        ByVal ATE_V_CP_FP As String,
    '                                        ByVal ATE_V_BOLETA As String,
    '                                        ByVal ATE_V_PAGADO As String) As String

    '    Dim ATE_V_SISTEMA_2 As Integer = ATE_V_SISTEMA.ToString().Replace(".", "")
    '    Dim ATE_V_BENEF_2 As Integer = ATE_V_BENEF.ToString().Replace(".", "")
    '    Dim ATE_V_CF_2 As Integer = ATE_V_CF.ToString().Replace(".", "")
    '    Dim ATE_V_CF_FP_2 As Integer = ATE_V_CF_FP.ToString().Replace(".", "")
    '    Dim ATE_V_CP_2 As Integer = ATE_V_CP.ToString().Replace(".", "")
    '    Dim ATE_V_CP_FP_2 As Integer = ATE_V_CP_FP.ToString().Replace(".", "")
    '    Dim ATE_V_BOLETA_2 As Integer = ATE_V_BOLETA.ToString().Replace(".", "")
    '    Dim ATE_V_PAGADO_2 As Integer = ATE_V_PAGADO.ToString().Replace(".", "")

    '    Return "TEST"
    'End Function
    Public Shared Function TEST_GUARDAR() As Integer
        Return Nothing
    End Function

    <Services.WebMethod()>
    Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
                                            ByVal NOMBRE_PAC As String,
                                            ByVal APE_PAC As String,
                                            ByVal FNAC_PAC As String,
                                            ByVal ID_SEXO As Integer,
                                            ByVal ID_NACIONALIDAD As Integer,
                                            ByVal FONO1 As String,
                                            ByVal MOVIL1 As String,
                                            ByVal ID_CIU_COM As Integer,
                                            ByVal DIR_PAC As String,
                                            ByVal EMAIL_PAC As String,
                                            ByVal FUR As String,
                                            ByVal Paridad As String,
                                            ByVal ID_PAC As String,
                                            ByVal OB As String,
                                            ByVal Procedencia As Integer,
                                            ByVal Programa As Integer,
                                            ByVal Sector As Integer,
                                            ByVal TipoAtencion As Integer,
                                            ByVal PrioridadTM As Integer,
                                            ByVal Doctor As Integer,
                                            ByVal Prevision As Integer,
                                            ByVal EDAD As Integer,
                                            ByVal MES As Integer,
                                            ByVal DIA As Integer,
                                            ByVal TOTAL As Integer,
                                            ByVal FECHA_PRE As String,
                                            ByVal ids As List(Of ids2_caja),
                                            ByVal ate_obs As String,
                                            ByVal Interno As String,
                                            ByVal id_Diag As String,
                                            ByVal id_Diag2 As String,
                                            ByVal sub_atencion As String,
                                            ByVal vih As String,
                                            ByVal dni As String,
                                            ByVal ATE_V_SISTEMA As String, 'PARÁMETROS  CAJA    '1  VALOR PREVISIION
                                            ByVal ATE_V_BENEF As String,                        '2  VALOR BENEFICIARIO +  SEGURO COMPLEMENATRIO
                                            ByVal ATE_V_CF As String,                           '3  TOTAL FONASA
                                            ByVal ATE_V_CF_FP As String,                        '4  TIPO DE PAGO FONASA
                                            ByVal ATE_V_CP As String,                           '5  VALOR PARTICULAR
                                            ByVal ATE_V_CP_FP As String,                        '6  TIPO DE PAGO PARTICULAR
                                            ByVal ATE_V_BOLETA As String,                       '7  NUMERO DE BOLETA
                                            ByVal ATE_V_PAGADO As String,                       '8  TOTAL SUPREMO
                                            ByVal ATE_V_SEG_COMP As String,                     '9  SEGURO COMPLEMENTARIO
                                             ByVal ATE_TP_COPAGO_1 As String,                   '10 TIPO COPAGO 1
                                             ByVal ATE_VALOR_COPAGO_1 As String,                '11 VALOR COPAGO 1
                                             ByVal ATE_TP_COPAGO_2 As String,                   '12 TIPO COPAGO 2
                                             ByVal ATE_VALOR_COPAGO_2 As String,                '13 VALOR COPAGO 2
                                             ByVal ATE_TP_PARTICULAR_1 As String,               '14 TIPO PARTICULAR 1
                                             ByVal ATE_VALOR_PARTICULAR_1 As String,            '15 VALOR PARTICULAR
                                             ByVal ATE_TP_PARTICULAR_2 As String,               '16 TIPO PARTICULAR 2 
                                             ByVal ATE_VALOR_PARTICULAR_2 As String,             '17 VALOR PARTICULAR 2
                                             ByVal ATE_V_SC As String,
                                             ByVal S_Id_User As Integer                         'NUEVO ID_USUARIO
                                             ) As String
        Dim ATE_V_SISTEMA_2 As String
        Dim ATE_V_BENEF_2 As String
        Dim ATE_V_CF_2 As String
        Dim ATE_V_CF_FP_2 As String
        Dim ATE_V_CP_2 As String
        Dim ATE_V_CP_FP_2 As String
        Dim ATE_V_BOLETA_2 As String
        Dim ATE_V_PAGADO_2 As String
        Dim ATE_V_SEG_COMP_2 As String

        Dim ATE_V_SC_2 As String
        If (ATE_V_SC <> "") Then
            ATE_V_SC_2 = ATE_V_SC.ToString().Replace(".", "")
        Else
            ATE_V_SC_2 = 0
        End If


        Dim ATE_VALOR_PARTICULAR_1_2 As String
        Dim ATE_VALOR_PARTICULAR_2_2 As String

        If ATE_VALOR_PARTICULAR_2 <> "" Then
            ATE_VALOR_PARTICULAR_2_2 = ATE_VALOR_PARTICULAR_2.ToString().Replace(".", "")
        Else
            ATE_VALOR_PARTICULAR_2_2 = 0
        End If

        If ATE_VALOR_PARTICULAR_1 <> "" Then
            ATE_VALOR_PARTICULAR_1_2 = ATE_VALOR_PARTICULAR_1.ToString().Replace(".", "")
        Else
            ATE_VALOR_PARTICULAR_1_2 = 0
        End If

        If ATE_V_SISTEMA <> "" Then
            ATE_V_SISTEMA_2 = ATE_V_SISTEMA.ToString().Replace(".", "")
        Else
            ATE_V_SISTEMA_2 = 0
        End If

        If ATE_V_BENEF <> "" Then
            ATE_V_BENEF_2 = ATE_V_BENEF.ToString().Replace(".", "")
        Else
            ATE_V_BENEF_2 = 0
        End If

        If ATE_V_CF <> "" Then
            ATE_V_CF_2 = ATE_V_CF.ToString().Replace(".", "")
        Else
            ATE_V_CF_2 = 0
        End If

        If ATE_V_CF_FP <> "" Then
            ATE_V_CF_FP_2 = ATE_V_CF_FP.ToString().Replace(".", "")
        Else
            ATE_V_CF_FP_2 = 0
        End If

        If ATE_V_CP <> "" Then
            ATE_V_CP_2 = ATE_V_CP.ToString().Replace(".", "")
        Else
            ATE_V_CP_2 = 0
        End If

        If ATE_V_CP_FP <> "" Then
            ATE_V_CP_FP_2 = ATE_V_CP_FP.ToString().Replace(".", "")
        Else
            ATE_V_CP_FP_2 = 0
        End If

        If ATE_V_BOLETA <> "" Then
            ATE_V_BOLETA_2 = ATE_V_BOLETA.ToString().Replace(".", "")
        Else
            ATE_V_BOLETA_2 = 0
        End If

        If ATE_V_PAGADO <> "" Then
            ATE_V_PAGADO_2 = ATE_V_PAGADO.ToString().Replace(".", "")
        Else
            ATE_V_PAGADO_2 = 0
        End If

        If ATE_V_SEG_COMP <> "" Then
            ATE_V_SEG_COMP_2 = ATE_V_SEG_COMP.ToString().Replace(".", "")
        Else
            ATE_V_SEG_COMP_2 = 0
        End If



        'Checar Galletas
        If (Test_C.emptyCookies = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx", False)
            Return Nothing
        End If

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim correlativo As Integer

        'paciente
        Dim Rpaciente As Integer
        Dim examun As Integer
        Dim Str_Out As String = ""
        Dim DATASSSSSS As Integer
        ' Dim PREINGRESO2 As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        'Dim AIDIIIII_ADMINNNNNNN As HttpCookie = Request.Cookies.Get("ID_USER")
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim nn As N_IRIS_WEBF_GRABA_PACIENTE_ATENCION = New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION = New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As N_IRIS_WEBF_GRABA_PREINGRESO2 = New N_IRIS_WEBF_GRABA_PREINGRESO2
        Dim cc As N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC = New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO = New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else
            'regitrar paciente o actualizar
            If (Paridad = 2) Then
                Rpaciente = nn.IRIS_WEBF_GRABA_PACIENTE_ATENCION(RUT_PAC, NOMBRE_PAC.ToUpper, APE_PAC.ToUpper, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC.ToUpper, EMAIL_PAC, 1, OB.ToUpper, 1, dni)
            Else
                Rpaciente = vv.IRIS_WEBF_UPDATE_PACIENTE_ATENCION(ID_PAC, RUT_PAC, NOMBRE_PAC.ToUpper, APE_PAC.ToUpper, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC.ToUpper, EMAIL_PAC, 1, OB.ToUpper, 1)
            End If



            'ir a buscar correlativo
            correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
            If (Paridad = 2) Then
                'PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(correlativo, Rpaciente, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, ate_obs.ToUpper, 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, sub_atencion, vih, dni)
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW_CAJA(correlativo,
                                                              Rpaciente,
                                                              CInt(S_Id_User),
                                                              FUR,
                                                              Procedencia,
                                                              PrioridadTM,
                                                              TipoAtencion,
                                                              Doctor,
                                                              Prevision,
                                                              1,
                                                              1,
                                                              ("N° Orden Clínica: " & ids(0).Clinico),
                                                              0,
                                                              EDAD,
                                                              MES,
                                                              DIA,
                                                              TOTAL,
                                                              0,
                                                              0,
                                                              FECHA_PRE,
                                                              Programa,
                                                              Sector, ids(0).Clinico, 0, 0, sub_atencion, vih
                                                             )
            Else

                'PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(correlativo, ID_PAC, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, ate_obs.ToUpper, 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, sub_atencion, vih, dni)
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW_CAJA(correlativo,
                                              ID_PAC,
                                              CInt(S_Id_User),
                                              FUR,
                                              Procedencia,
                                              PrioridadTM,
                                              TipoAtencion,
                                              Doctor,
                                              Prevision,
                                              1,
                                              1,
                                              ("N° Orden Clínica: " & ids(0).Clinico),
                                              0,
                                              EDAD,
                                              MES,
                                              DIA,
                                              TOTAL,
                                              0,
                                              0,
                                              FECHA_PRE,
                                              Programa,
                                              Sector, ids(0).Clinico, 0, 0, sub_atencion, vih)
            End If
            Dim data_examen2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Dim NN_Examen2 As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

            Dim NN_Date As New N_Date
            Dim fecha As String = FECHA_PRE.Replace("/", "-")
            Dim DIA1 As String = fecha.Split("-")(0)
            Dim MES2 As String = fecha.Split("-")(1)
            Dim AÑO3 As String = fecha.Split("-")(2)
            Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
            Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)


            data_examen2 = NN_Examen2.IRIS_WEBF_BUSCA_EXAMEN(Date_02, Date_01, RUT_PAC)


            For i = 0 To ids.Count - 1
                examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, ids(i).Clinico)
            Next i





            Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
            Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
            Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
            Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
            Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
            Dim correlativo2 As Integer
            Dim id_atencion As Integer
            Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
            Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
            Dim id As Integer
            Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
            Dim resu As Integer
            Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
            Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
            Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
            Dim dual_copago As Integer
            'IRIS_GRABA_ATENCION_PROGRA2_2

            data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(PREINGRESO2_PRO_SEC)
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(PREINGRESO2_PRO_SEC)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(PREINGRESO2_PRO_SEC)
            correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
            id_atencion = ddx.IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC(correlativo2,
                                                                          data_pac(0).ID_PACIENTE,
                                                                          CInt(S_Id_User),
                                                                          data_pac(0).PREI_FUR,
                                                                          data_atencion(0).ID_PROCEDENCIA,
                                                                          data_atencion(0).ID_ORDEN,
                                                                          data_atencion(0).ID_TP_PACI,
                                                                          data_atencion(0).ID_DOCTOR,
                                                                          data_atencion(0).ID_PREVE,
                                                                          data_atencion(0).ID_LOCAL,
                                                                          1,
                                                                          data_atencion(0).PREI_OBS_FICHA,
                                                                          data_atencion(0).PREI_CAMA,
                                                                          data_pac(0).PREI_AÑO,
                                                                          data_pac(0).PREI_MES,
                                                                          data_pac(0).PREI_DIA,
                                                                          data_examen(0).PREI_DET_V_PAGADO,
                                                                          data_examen(0).PREI_DET_V_PREVI,
                                                                          data_examen(0).PREI_DET_V_COPAGO,
                                                                          data_atencion(0).ID_PROGRAMA,
                                                                          "",
                                                                          data_atencion(0).ID_SECTOR,
                                                                          ids(0).Clinico,
                                                                          Interno,
                                                                          data_atencion(0).ID_DIAGNOSTICO,
                                                                          data_atencion(0).ID_DIAGNOSTICO2,
                                                                          data_atencion(0).VIH,
                                                                          data_pac(0).DNI,
                                                                          OB,
                                                                          ATE_V_SISTEMA_2,                '1
                                                                          ATE_V_BENEF_2,                  '2
                                                                          ATE_V_CF_2,                     '3
                                                                          ATE_V_CF_FP_2,                  '4
                                                                          ATE_V_CP_2,                     '5
                                                                          ATE_V_CP_FP_2,                  '6
                                                                          ATE_V_BOLETA_2,                 '7
                                                                          ATE_V_PAGADO_2,                 '8
                                                                        ATE_V_SEG_COMP_2,                 '9
                                                                        ATE_V_SC_2)                       'SC EN ATENCION

            '--------------------------- DUAL COPAGO ---------------------------
            dual_copago = ddx.IRIS_WEBF_CMVM_GRABA_REL_COPAGO(id_atencion,
                                                              CInt(S_Id_User),
                                                              Date.Now,
                                                              ATE_TP_COPAGO_1,
                                                              ATE_VALOR_COPAGO_1,
                                                              ATE_TP_COPAGO_2,
                                                              ATE_VALOR_COPAGO_2,
                                                              ATE_V_CP_FP_2,
                                                              ATE_V_CP_2,
                                                              ATE_TP_PARTICULAR_1,
                                                              ATE_VALOR_PARTICULAR_1_2,
                                                              ATE_TP_PARTICULAR_2,
                                                              ATE_VALOR_PARTICULAR_2_2)




            '---------------------FIN DUAL COPAGO ------------------------------

            For i = 0 To ids.Count - 1
                Dim toti_copago As Integer = 0
                Dim toti_pagado As Integer = 0
                Dim descccc As Integer = 0

                descccc = ids(i).ATE_DET_VALOR_CS + ids(i).ATE_DET_VALOR_BENEF

                If (ids(i).CF_TP_PAGO = 1 Or ids(i).CF_TP_PAGO = 20 Or ids(i).CF_TP_PAGO = 4) Then
                    toti_copago = 0 'ids(i).ATE_DET_VALOR_CS + ids(i).ATE_DET_VALOR_BENEF
                    'toti_pagado = ids(i).Valor '- toti_copago
                    toti_pagado = ids(i).Valor - descccc '- toti_copago
                Else
                    toti_copago = ids(i).Valor - descccc 'ids(i).ATE_DET_VALOR_CS + ids(i).ATE_DET_VALOR_BENEF
                    toti_pagado = ids(i).Valor - descccc
                End If



                id = jj.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW(id_atencion,
                                                                   CInt(S_Id_User),
                                                                   ids(i).id_CF,
                                                                   ids(i).id_PER,
                                                                   ids(i).CF_TP_PAGO,
                                                                   0,
                                                                   ids(i).Valor,
                                                                   toti_pagado, 'ids(i).Valor,        'VALOR PAGADO !!!!
                                                                   toti_copago,'0,       'COPAGO
                                                                   0,
                                                                   ids(i).CF_TP_PREVE,
                                                                   ids(i).CF_TP_PAGO,
                                                                    ids(i).ATE_DET_VALOR_BENEF,             '1
                                                                    ids(i).ATE_DET_VALOR_CS,                '2
                                                                    ids(i).ATE_DET_TP_1,                    '3
                                                                    ids(i).ATE_DET_TP_OBS,                  '4
                                                                    ids(i).ATE_DET_NUM_BOL,                 '5
                                                                    ids(i).ATE_DET_NUM_BONO)                '6

                PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(data_examen(i).ID_PER)
                For x = 0 To PERFIL_PRUEBA.Count - 1
                    If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                    Else
                        If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                            resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                        Else
                            resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                        End If
                    End If
                Next x
            Next i

            '-------------------------------------------------------- GRABA DUAL COPAGO -----------------------------------------------------------------



            '----------------------------------------------------------FIN DUAL COPAGO -------------------------------------------------------------------

            '----------------- Auto PAGO Datos ---------------------------
            Dim qq As New N_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
            Dim update1 As Integer
            '----------------------------------------------------------
            Dim ww As New N_IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP
            Dim update2 As Integer
            '-----------------------------------------------------------
            Dim ee As New N_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES
            Dim buscarFormaPAgo As List(Of E_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES)
            '-----------------------------------------------------------------
            Dim rr As New N_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION
            Dim buscarAteDOC As List(Of E_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION)
            '---------------------------------------------------------------------------------
            Dim correlativo_tp_pago As Integer
            Dim bb As New N_IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO
            Dim qwerty As Integer
            Dim xcv As New N_IRIS_WEBF_GRABA_TRX_BONOS
            Dim qwe As Integer
            Dim uuuu As New N_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
            correlativo_tp_pago = bb.IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO()
            update1 = qq.IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago, 1)
            update2 = ww.IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago)

            Dim graba_ate As Integer
            Dim tt As New N_IRIS_GRABA_ATE_DOCUMENTO_PAGO
            graba_ate = tt.IRIS_GRABA_ATE_DOCUMENTO_PAGO(id_atencion, correlativo_tp_pago, CInt(S_Id_User))
            buscarFormaPAgo = ee.IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES(id_atencion)
            If (buscarFormaPAgo.Count > 0) Then
                If (buscarFormaPAgo(0).ID_TP_PAGO = 4 Or buscarFormaPAgo(0).ID_TP_PAGO = 5) Then
                    qwerty = xcv.IRIS_WEBF_GRABA_TRX_BONOS(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
                ElseIf (buscarFormaPAgo(0).ID_TP_PAGO = 1 Or buscarFormaPAgo(0).ID_TP_PAGO = 3 Or buscarFormaPAgo(0).ID_TP_PAGO = 7 Or buscarFormaPAgo(0).ID_TP_PAGO = 11) Then
                    qwerty = xcv.IRIS_WEBF_GRABA_TRX_EFECTIVO(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
                End If
            End If
            If (qwerty = 0) Then
                qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User), 0)
            Else
                qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, qwerty, CInt(S_Id_User), 0)
            End If
            Dim ahg As Integer
            Dim uu As New N_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
            'update despues de pago
            ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(PREINGRESO2_PRO_SEC, id_atencion)
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(PREINGRESO2_PRO_SEC, Interno, OB, data_atencion(0).PREI_OBS_FICHA)

            Dim NN_ExamenDet As New N_Exa_Esp_V
            Dim DataExamenDet As Integer
            Dim exa_avis As Integer

            For i = 0 To ids.Count - 1
                If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                    DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(id_atencion, ids(i).id_CF)

                    'If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
                    '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
                    'End If
                End If




            Next i


            Str_Out += "{"
            Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & id_atencion & Chr(34) & ", "
            Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
            Str_Out += "}"
            Return Str_Out
            Return datas
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Ciudad() As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Ciudad_By_ID_USER
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_CIUDAD
            lol.text = xItem.CIU_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Comuna(ByVal ID_CIUD As Integer) As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Comuna_By_ID_USER
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_COMUNA
            lol.text = xItem.COM_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Ciu_Com_User(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
        Dim NNN As New N_Login2

        Return NNN.IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER(ID_USER)
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    Public Class ids2_caja

        Dim E_id_CF As Integer
        Dim E_id_PER As Integer
        Dim E_Valor As Integer
        Dim E_Clinico As String
        Dim E_CF_ESTADO_EXAMEN As String
        Dim E_CF_TP_PAGO As String
        Dim E_ATE_DET_NUM_BONO As String           '6
        Dim E_ATE_DET_NUM_BOL As Integer            '5
        Dim E_ATE_DET_TP_OBS As String              '4
        Dim E_ATE_DET_TP_1 As Integer               '3
        Dim E_ATE_DET_VALOR_CS As Integer           '2
        Dim E_ATE_DET_VALOR_BENEF As Integer        '1

        Public Property ATE_DET_VALOR_BENEF As Integer
            Get
                Return E_ATE_DET_VALOR_BENEF
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_VALOR_BENEF = value
            End Set
        End Property

        Public Property ATE_DET_VALOR_CS As Integer
            Get
                Return E_ATE_DET_VALOR_CS
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_VALOR_CS = value
            End Set
        End Property

        Public Property ATE_DET_TP_1 As Integer
            Get
                Return E_ATE_DET_TP_1
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_TP_1 = value
            End Set
        End Property

        Public Property ATE_DET_TP_OBS As String
            Get
                Return E_ATE_DET_TP_OBS
            End Get
            Set(ByVal value As String)
                E_ATE_DET_TP_OBS = value
            End Set
        End Property

        Public Property ATE_DET_NUM_BOL As Integer
            Get
                Return E_ATE_DET_NUM_BOL
            End Get
            Set(ByVal value As Integer)
                E_ATE_DET_NUM_BOL = value
            End Set
        End Property

        Public Property ATE_DET_NUM_BONO As String
            Get
                Return E_ATE_DET_NUM_BONO
            End Get
            Set(ByVal value As String)
                E_ATE_DET_NUM_BONO = value
            End Set
        End Property

        Public Property CF_TP_PAGO As String
            Get
                Return E_CF_TP_PAGO
            End Get
            Set(ByVal value As String)
                E_CF_TP_PAGO = value
            End Set
        End Property
        Dim E_CF_TP_PREVE As String
        Public Property CF_TP_PREVE As String
            Get
                Return E_CF_TP_PREVE
            End Get
            Set(ByVal value As String)
                E_CF_TP_PREVE = value
            End Set
        End Property
        Public Property CF_ESTADO_EXAMEN As String
            Get
                Return E_CF_ESTADO_EXAMEN
            End Get
            Set(ByVal value As String)
                E_CF_ESTADO_EXAMEN = value
            End Set
        End Property

        Public Property Clinico As String
            Get
                Return E_Clinico
            End Get
            Set(ByVal value As String)
                E_Clinico = value
            End Set
        End Property
        Public Property Valor As Integer
            Get
                Return E_Valor
            End Get
            Set(ByVal value As Integer)
                E_Valor = value
            End Set
        End Property
        Public Property id_CF As Integer
            Get
                Return E_id_CF
            End Get
            Set(ByVal value As Integer)
                E_id_CF = value
            End Set
        End Property
        Public Property id_PER As Integer
            Get
                Return E_id_PER
            End Get
            Set(ByVal value As Integer)
                E_id_PER = value
            End Set
        End Property
    End Class
End Class