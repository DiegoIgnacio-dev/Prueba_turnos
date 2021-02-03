Imports System.IO
Imports System.Net
Imports System.Xml.Serialization
Imports Entidades
Imports Negocio
Imports SpreadsheetLight
Imports System.Web.Script.Serialization
Public Class Boleta_Electronica1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Boleta_Electronica(ByVal Folio As String, ByVal URL_CNE As String, ByVal USUARIO As String) As xDocConv.XDecXML

        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLDTE As String
        Dim d_USU_CNE As E_USU_CNE
        Dim Params As E_PARAMS_BE
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA()

        Params = NN.IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA(Folio)

        If (Params.RUTReceptor = "") Then
            Params.RUTReceptor = "77.831.300-6"
        End If

        Dim CORRE_B_ELECT As Long
        'Definir URL Request Web Service
        'URLDTE = "http://wspruebas.dtesoftware.cl/webservice/wsdlboletas/Wsboletas.php"
        URLDTE = URL_CNE
        d_USU_CNE = NN.IRIS_WEBF_BUSCA_USUARIO_CNE()

        CORRE_B_ELECT = NN.IRIS_WEBF_BUSCA_CORRELATIVO_B_ELECT()

        Dim _XML As String = "" 'Declarar XML
        Dim _usuario As String = EncodeStrToBase64(d_USU_CNE.USU_CNE) 'Declarar Usuario CNE, debe codificarse en Base64 
        Dim _password As String = EncodeStrToBase64(d_USU_CNE.PASS_CNE) 'Declarar Password CNE, debe codificarse en Base64 
        Dim _id_usuario As String = EncodeStrToBase64(d_USU_CNE.ID_USU_CNE) 'Declarar ID_USUARIO CNE, debe codificarse en Base64 
        Dim _id_empresa As String = EncodeStrToBase64(d_USU_CNE.ID_EMPRESA_CNE) 'Declarar ID_EMPRESA CNE, debe codificarse en Base64 

        Dim MntNeto As Integer = 0 'Declarar Monto Neto
        Dim IVA As Integer = 0 'Declarar IVA
        Dim MntTotal As Integer = 0 'Declarar Monto Total
        Dim TotalPeriodo As Integer = 0 'Declarar Monto Periodo
        Dim VlrPagar As Integer = 0 'Declarar Valor a Pagar

        If Params.Lst_Detalle.Count = 0 Then
            Dim x_Ret As New xDocConv.XDecXML
            x_Ret.glosa = "Exámenes sin boleta electrónica afecta"
            Return x_Ret
        End If

        For Each det In Params.Lst_Detalle 'Ciclo por cada detalle en la lista de detalle
            If det.IndExe = 0 Then ' si es Afecto se calcula el IVA y MntNeto
                If det.TieneIVA = 1 Then 'Pregunta si tiene IVA (1 Si, 2 No)

                    'Console.WriteLine((1500 / 1.19) * 0.19)
                    'Console.WriteLine(Math.Round(239.49579831939, 0))
                    'Console.WriteLine(1500 - Math.Round(239.49579831939, 0))

                    Dim _S_IVA As Double = (det.PrcItem / 1.19) * 0.19
                    _S_IVA = Math.Round(_S_IVA, 0)
                    Dim _S_MntNeto As Integer
                    _S_MntNeto = det.PrcItem - _S_IVA

                    IVA += _S_IVA
                    MntNeto += _S_MntNeto
                    'IVA += (CInt(det.PrcItem) - (CInt(det.PrcItem) / 1.19)) 'Calculo de IVA
                    ' MntNeto += (CInt(det.PrcItem) / 1.19) 'Calculo de Monto Neto
                Else
                    IVA += (CInt(det.PrcItem) * 0.19) 'Calculo de IVA
                    MntNeto += (CInt(det.PrcItem)) 'Calculo de Monto Neto
                End If

            End If
        Next

        'Monto Total, Total Periodo y Valor a Pagar deben ser lo mismo.
        MntTotal = MntNeto + IVA
        TotalPeriodo = MntTotal
        VlrPagar = MntTotal

        _XML = "<?xml version=""1.0"" encoding=""UTF-8""?>"
        _XML += "<DTE version=""1.0"" ID=""ALET" + CORRE_B_ELECT.ToString + """>" 'ID Documento Unico, BI+FOLIO IRIS
        _XML += "<Encabezado>"

        _XML += "<IdDoc>"
        _XML += "<TipoDTE>39</TipoDTE>"
        _XML += "<Folio></Folio>"
        _XML += "<FchEmis>" + Date.Now.ToString("dd-MM-yyyy") + "</FchEmis>"
        _XML += "<IndServicio>3</IndServicio>"
        _XML += "<FormaEmision>1</FormaEmision>" '1 CONTADO, 2 CREDITO
        _XML += "</IdDoc>"

        _XML += "<Emisor>" 'Al enviar RUT (sin puntos, con guión) o tener cuenta en CNE, automaticamente ingresa los datos de SII
        _XML += "<RUTEmisor>76172518-1</RUTEmisor>"
        _XML += "<RznSocEmisor>IRISLAB</RznSocEmisor>"
        _XML += "<GiroEmisor>COMPUTACIONAL</GiroEmisor>"
        _XML += "<CdgSIISucur>103</CdgSIISucur>"
        _XML += "<DirOrigen>Bulnes 671</DirOrigen>"
        _XML += "<CmnaOrigen>OSORNO</CmnaOrigen>"
        _XML += "<CiudadOrigen>OSORNO</CiudadOrigen>"
        _XML += "</Emisor>"

        _XML += "<Receptor>"
        _XML += "<RUTRecep>" + Params.RUTReceptor.Replace(".", "") + "</RUTRecep>" 'Rut Paciente sin puntos, con guión
        _XML += "<RznSocRecep>" + Params.RznSocRecep + "</RznSocRecep>" 'Nombre Paciente

        If Params.DirRecep = "" Then
            Params.DirRecep = "Direccion no registrada"
        End If

        _XML += "<DirRecep>" + Params.DirRecep + "</DirRecep>" 'Dirección Paciente
        _XML += "<CmnaRecep>" + Params.CmnaRecep + "</CmnaRecep>" 'Comuna Paciente
        _XML += "<CiudadRecep>" + Params.CiudadRecep + "</CiudadRecep>" 'Ciudad Paciente
        _XML += "<GiroRecep>Particular</GiroRecep>"
        _XML += "</Receptor>"

        ' CALCULAR VALORES

        _XML += "<Totales>"
        _XML += "<MntNeto>" + MntNeto.ToString + "</MntNeto>" 'Monto Neto
        _XML += "<IVA>" + IVA.ToString + "</IVA>" 'IVA
        _XML += "<MntTotal>" + MntTotal.ToString + "</MntTotal>" 'Monto Total
        _XML += "<TotalPeriodo>" + TotalPeriodo.ToString + "</TotalPeriodo>" 'Total Periodo
        _XML += "<VlrPagar>" + VlrPagar.ToString + "</VlrPagar>" 'Valor a Pagar
        _XML += "</Totales>"
        _XML += "</Encabezado>"

        ' FOREACH DETALLE
        Dim linea As Integer = 1
        For Each det In Params.Lst_Detalle 'Ciclo por cada Detalle en la lista detalle
            If det.IndExe = 0 Then
                Dim CIVA As Integer

                If det.TieneIVA = 0 Then
                    CIVA = Math.Round(det.PrcItem * 1.19, 0)
                End If

                _XML += "<Detalle>"
                _XML += "<NroLinDet>" + linea.ToString + "</NroLinDet>"
                _XML += "<NmbItem>" + det.NmbItem + "</NmbItem>" 'CF_DESC
                _XML += "<QtyItem>1</QtyItem>"

                If det.TieneIVA = 1 Then
                    _XML += "<PrcItem>" + det.PrcItem + "</PrcItem>" 'PRECIO CF
                Else
                    _XML += "<PrcItem>" + CIVA.ToString + "</PrcItem>" 'PRECIO CF
                End If

                _XML += "<DescuentoPct>"
                _XML += "</DescuentoPct>"
                _XML += "<DescuentoMonto>"
                _XML += "</DescuentoMonto>"

                If det.TieneIVA = 1 Then
                    _XML += "<MontoItem>" + det.PrcItem + "</MontoItem>" 'Precio CF
                Else
                    _XML += "<MontoItem>" + CIVA.ToString + "</MontoItem>" 'Precio CF
                End If

                _XML += "</Detalle>"
                linea += 1
            End If
        Next

        _XML += "<Referencia>"
        _XML += "<NroLinRef>1</NroLinRef>"
        _XML += "<CodRef>OBS</CodRef>"
        _XML += "<RazonRef>" + Params.RazonRef + "</RazonRef>" 'Observación Venta
        _XML += "<CodVndor>" + Params.CodVndor + "</CodVndor>" 'USU_NIC
        _XML += "<CodCaja>" + Params.CodCaja + "</CodCaja>" 'CAJA-USU_NIC
        _XML += "</Referencia>"
        _XML += "</DTE>"

        'Convertir XML en String HTML
        _XML = HttpUtility.HtmlEncode(_XML)

        'String Request
        SoapStr = "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:procesardte"">"
        SoapStr += "<soapenv:Header/>"
        SoapStr += "<soapenv:Body>"
        SoapStr += "<urn:procesardte soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        SoapStr += "<XML xsi:type=""xsd:string"">" + _XML + "</XML>" 'Enviar XML como String
        SoapStr += "<usuario xsi:type=""xsd:string"">" + _usuario + "</usuario>" 'Usuario Base64
        SoapStr += "<password xsi:type=""xsd:string"">" + _password + "</password>" 'Contraseña Base64
        SoapStr += "<id_usuario xsi:type=""xsd:string"">" + _id_usuario + "</id_usuario>" 'ID_USUARIO Base64
        SoapStr += "<id_empresa xsi:type=""xsd:string"">" + _id_empresa + "</id_empresa>" 'ID_EMPRESA Base64
        SoapStr += "</urn:procesardte>"
        SoapStr += "</soapenv:Body>"
        SoapStr += "</soapenv:Envelope>"

        'Asignar Protocolo de Seguridad
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Try
            'Soap String a Byte
            SoapByte = System.Text.Encoding.UTF8.GetBytes(SoapStr)
            '** Crear POST Request con URL del Web Service
            Request = HttpWebRequest.Create(URLDTE)
            Request.KeepAlive = True
            Request.ContentType = "text/xml; charset=utf-8"
            Request.ContentLength = SoapByte.Length
            Request.Method = "POST"
            'Agregar Headers para Decompresión GZip
            Request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate")
            Request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            'Declarar Encode UTF-8
            Dim Enc As Encoding = Encoding.GetEncoding("iso-8859-1")

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
                        'Using Reader As StreamReader = New StreamReader(_DataStream)
                        SoapResponse = Reader.ReadToEnd()
                    End Using
                End Using
            End Using

            'Declarar XDocSoap como XDocument
            Dim XDocSoap As XDocument = New XDocument()

            If SoapResponse <> Nothing Then
                'Parsear String SoapResponse en variable XDocSoap
                Try
                    'SoapResponse = SoapResponse.Replace("¡¡La inserción no se realizó!!¡¡La inserción no se realizó!!", "")
                    'SoapResponse = SoapResponse.Replace("¡¡La inserción no se realizó!!", "")
                    XDocSoap = XDocument.Parse(SoapResponse)
                Catch ex As Exception
                    Return Nothing
                End Try

            End If

            'Declarar XNamespace para XSI y XSD (Se encuentran en el elemento Envelope del response SOAP)
            Dim nsXSI As XNamespace = "http://www.w3.org/2001/XMLSchema-instance"
            Dim nsXSD As XNamespace = "http://www.w3.org/2001/XMLSchema"

            'Declarar XElement XDocResp y asignar solo el elemento "procesardteResponse" y namespace "urn:procesardte" al que pertenece
            Dim XDocResp = XDocSoap.Descendants("{urn:procesardte}procesardteResponse").First()

            'Asignar XNamespace XSI y XSD a Elemento XDocVtaBonInterfazResp
            XDocResp.Add(New XAttribute(XNamespace.Xmlns + "xsi", nsXSI))
            XDocResp.Add(New XAttribute(XNamespace.Xmlns + "xsd", nsXSD))

            'Declarar Variable DocBodyStr
            Dim DocBodyStr As String

            'Parsear XElement XDocResp en variable DocBodyStr
            DocBodyStr = XDocResp.ToString

            'Declarar XRoot como XmlRootAttribute, asignando el elemento de raíz y namespace
            Dim XRoot As New XmlRootAttribute With {
            .ElementName = "procesardteResponse",
            .Namespace = "urn:procesardte",
            .IsNullable = True
            }

            'Declarar XMLSerializer, asignando el Type como procesardteResponse, y XMLRootAttribute como XRoot
            Dim Serialize As New XmlSerializer(GetType(pdteRest.procesardteResponse), XRoot)

            'Declarar Variable E_procdte
            Dim _procdte As pdteRest.procesardteResponse = Nothing

            'Leer DocBodyStr con StringReader
            Using reader As New StringReader(DocBodyStr)
                'Deserializar DocBodyStr (reader), asignando el Type procesardteResponse y guardar en variable _procdte
                _procdte = DirectCast(Serialize.Deserialize(reader), pdteRest.procesardteResponse)
            End Using

            'Capturar el Return del Web Service
            Dim strXML = _procdte._return

            'Decodificar el Return
            strXML = HttpUtility.HtmlDecode(strXML)

            Dim DecXML As String = strXML

            Dim XDecXML As XDocument = New XDocument()

            If DecXML <> Nothing Then
                'Parsear String DecXML en variable XDocSoap
                XDecXML = XDocument.Parse(DecXML)
            End If

            Dim SerializeDec As New XmlSerializer(GetType(xDocConv.XDecXML))

            Dim _XDec As xDocConv.XDecXML = Nothing

            'Obtener primer nodo XML
            Dim XDocString = XDecXML.FirstNode.ToString

            'Leer XDocString con StringReader
            Using reader As New StringReader(XDocString)
                'Deserializar XDocString (reader), asignando el Type XDecXML y guardar en variable _XDec
                _XDec = DirectCast(SerializeDec.Deserialize(reader), xDocConv.XDecXML)
            End Using

            Try
                'Decodificar la URL
                _XDec.rutadocumento = HttpUtility.UrlDecode(_XDec.rutadocumento)
            Catch ex As Exception

            End Try

            'Guardar FOLIO y RUTA_DOCUMENTO en IRIS_ATENCION
            If _XDec.glosa = "Documento Generado Exitoso" Then
                Dim _r As Integer
                _r = NN.IRIS_WEBF_GUARDA_DATOS_BOLETA_ELECTRONICA(Folio, _XDec.folio, _XDec.rutadocumento, USUARIO)
            End If


            'Retornar Objeto _XDec
            Return _XDec
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    <Services.WebMethod()>
    Public Shared Function Anula_Boleta_Electronica(ByVal Folio As String, ByVal URL_CNE As String, ByVal USUARIO As String) As xDocConv.XDecXML

        'Declaraciones
        Dim Request As HttpWebRequest
        Dim DataStream As Stream
        Dim SoapByte() As Byte
        Dim SoapStr As String
        Dim URLDTE As String
        Dim d_USU_CNE As E_USU_CNE
        Dim Params As E_PARAMS_BE
        Dim Params_BE As New E_RUTA_DOC_BE
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA()

        Params = NN.IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA(Folio)
        Params_BE = NN.IRIS_WEBF_BUSCA_RUTA_BOLETA_ELECTRONICA(Folio)
        Dim CORRE_A_BOLET As Long
        CORRE_A_BOLET = NN.IRIS_WEBF_BUSCA_CORRELATIVO_A_BOLET()


        'Definir URL Request Web Service
        'URLDTE = "http://wspruebas.dtesoftware.cl/webservice/wsdlboletas/Wsboletas.php"
        URLDTE = URL_CNE
        d_USU_CNE = NN.IRIS_WEBF_BUSCA_USUARIO_CNE()

        Dim _XML As String = "" 'Declarar XML
        Dim _usuario As String = EncodeStrToBase64(d_USU_CNE.USU_CNE) 'Declarar Usuario CNE, debe codificarse en Base64 
        Dim _password As String = EncodeStrToBase64(d_USU_CNE.PASS_CNE) 'Declarar Password CNE, debe codificarse en Base64 
        Dim _id_usuario As String = EncodeStrToBase64(d_USU_CNE.ID_USU_CNE) 'Declarar ID_USUARIO CNE, debe codificarse en Base64 
        Dim _id_empresa As String = EncodeStrToBase64(d_USU_CNE.ID_EMPRESA_CNE) 'Declarar ID_EMPRESA CNE, debe codificarse en Base64 

        Dim MntNeto As Integer = 0 'Declarar Monto Neto
        Dim IVA As Integer = 0 'Declarar IVA
        Dim MntTotal As Integer = 0 'Declarar Monto Total
        Dim TotalPeriodo As Integer = 0 'Declarar Monto Periodo
        Dim VlrPagar As Integer = 0 'Declarar Valor a Pagar

        If Params.Lst_Detalle.Count = 0 Then
            Dim x_Ret As New xDocConv.XDecXML
            x_Ret.glosa = "Exámenes sin boleta electrónica afecta"
            Return x_Ret
        End If

        For Each det In Params.Lst_Detalle 'Ciclo por cada detalle en la lista de detalle
            If det.IndExe = 0 Then ' si es Afecto se calcula el IVA y MntNeto
                If det.TieneIVA = 1 Then 'Pregunta si tiene IVA (1 Si, 2 No)

                    'Console.WriteLine((1500 / 1.19) * 0.19)
                    'Console.WriteLine(Math.Round(239.49579831939, 0))
                    'Console.WriteLine(1500 - Math.Round(239.49579831939, 0))

                    Dim _S_IVA As Double = (det.PrcItem / 1.19) * 0.19
                    _S_IVA = Math.Round(_S_IVA, 0)
                    Dim _S_MntNeto As Integer
                    _S_MntNeto = det.PrcItem - _S_IVA

                    IVA += _S_IVA
                    MntNeto += _S_MntNeto
                    'IVA += (CInt(det.PrcItem) - (CInt(det.PrcItem) / 1.19)) 'Calculo de IVA
                    ' MntNeto += (CInt(det.PrcItem) / 1.19) 'Calculo de Monto Neto
                Else
                    IVA += (CInt(det.PrcItem) * 0.19) 'Calculo de IVA
                    MntNeto += (CInt(det.PrcItem)) 'Calculo de Monto Neto
                End If

            End If
        Next

        'Monto Total, Total Periodo y Valor a Pagar deben ser lo mismo.
        MntTotal = MntNeto + IVA
        TotalPeriodo = MntTotal
        VlrPagar = MntTotal

        If Params.DirRecep = "" Then
            Params.DirRecep = "Direccion no registrada"
        End If

        _XML = "<?xml version=""1.0"" encoding=""UTF-8""?>"
        _XML += "<DTE version=""1.0"" ID=""ALET" + CORRE_A_BOLET.ToString + """>" 'ID Documento Unico, BI+FOLIO IRIS
        _XML += "<Tipo>61</Tipo>"
        _XML += "<Folio></Folio>"
        _XML += "<FechaEmision>" + Date.Now.ToString("dd-MM-yyyy") + "</FechaEmision>"
        _XML += "<FechaVencimiento>" + Date.Now.ToString("dd-MM-yyyy") + "</FechaVencimiento>"
        _XML += "<TipoDespacho/>"
        _XML += "<TipoTraslado/>"
        _XML += "<FormaPago>1</FormaPago>"
        _XML += "<GlosaPago>Anular Boleta</GlosaPago>"
        _XML += "<Sucursal>Osorno</Sucursal>"
        _XML += "<CodigoSucursal>2</CodigoSucursal>"
        _XML += "<DireccionSucursal>Bulnes 671</DireccionSucursal>"
        _XML += "<Vendedor>" + Params.CodVndor + "</Vendedor>"
        _XML += "<RutReceptor>" + Params.RUTReceptor.Replace(".", "") + "</RutReceptor>"
        _XML += "<RazonReceptor>" + Params.RznSocRecep + "</RazonReceptor>"
        _XML += "<GiroReceptor>PARTICULAR</GiroReceptor>"
        _XML += "<ContactoReceptor/>"
        _XML += "<DireccionReceptor>" + Params.DirRecep + "</DireccionReceptor>"
        _XML += "<ComunaReceptor>" + Params.CmnaRecep + "</ComunaReceptor>"
        _XML += "<CiudadReceptor>" + Params.CiudadRecep + "</CiudadReceptor>"
        _XML += "<TelefonoReceptor></TelefonoReceptor>"
        _XML += "<TipoCentroReceptor>1</TipoCentroReceptor>"
        _XML += "<CentroCostoReceptor>1</CentroCostoReceptor>"
        _XML += "<Patente></Patente>"
        _XML += "<RutChofer></RutChofer>"
        _XML += "<NombreChofer></NombreChofer>"
        _XML += "<DireccionDestino></DireccionDestino>"
        _XML += "<ComunaDestino></ComunaDestino>"
        _XML += "<CiudadDestino></CiudadDestino>"
        _XML += "<Unitarios>2</Unitarios>"
        _XML += "<Neto>" + MntNeto.ToString + "</Neto>"
        _XML += "<Exento/>"
        _XML += "<Iva>" + IVA.ToString + "</Iva>"
        _XML += "<Total>" + MntTotal.ToString + "</Total>"

        _XML += "<Referencias>"
        _XML += "<NroLinRef>1</NroLinRef>"
        _XML += "<CodigoRef>39</CodigoRef>"
        _XML += "<MotivoRef>1</MotivoRef>"
        _XML += "<FolioRef>" + Params_BE.FOLIO_CNE + "</FolioRef>"
        _XML += "<FechaRef>" + Params_BE.FECHA_EMISION_BE.ToString("dd-MM-yyyy") + "</FechaRef>"
        _XML += "<RazonRef> Anular Boleta</RazonRef>"
        _XML += "</Referencias>"
        ' FOREACH DETALLE
        Dim linea As Integer = 1
        For Each det In Params.Lst_Detalle 'Ciclo por cada Detalle en la lista detalle
            If det.IndExe = 0 Then
                Dim CIVA As Integer

                If det.TieneIVA = 0 Then
                    CIVA = Math.Round(det.PrcItem * 1.19, 0)
                End If

                _XML += "<Detalle>"
                _XML += "<NrLinDetalle>" + linea.ToString + "</NrLinDetalle>"
                _XML += "<IndExe>0</IndExe>"
                _XML += "<Codigo>DET" + linea.ToString + "</Codigo>"
                _XML += "<Descripcion>Producto Afecto</Descripcion>"
                _XML += "<Glosa>" + det.NmbItem + "</Glosa>" 'CF_DESC
                _XML += "<Cantidad>1</Cantidad>"
                _XML += "<UnidadMedida>1</UnidadMedida>"
                If det.TieneIVA = 1 Then
                    _XML += "<Unitario>" + det.PrcItem + "</Unitario>" 'PRECIO CF
                Else
                    _XML += "<Unitario>" + CIVA.ToString + "</Unitario>" 'PRECIO CF
                End If

                _XML += "<DescuentoLinea></DescuentoLinea>"
                _XML += "<ValorDescuento></ValorDescuento>"

                If det.TieneIVA = 1 Then
                    _XML += "<SubTotal>" + det.PrcItem + "</SubTotal>" 'Precio CF
                Else
                    _XML += "<SubTotal>" + CIVA.ToString + "</SubTotal>" 'Precio CF
                End If
                _XML += "<CodigoImpRet></CodigoImpRet>"
                _XML += "</Detalle>"
                linea += 1
            End If
        Next

        _XML += "</DTE>"

        'Convertir XML en String HTML
        _XML = HttpUtility.HtmlEncode(_XML)

        'String Request
        SoapStr = "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:procesardte"">"
        SoapStr += "<soapenv:Header/>"
        SoapStr += "<soapenv:Body>"
        SoapStr += "<urn:procesardte soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">"
        SoapStr += "<XML xsi:type=""xsd:string"">" + _XML + "</XML>" 'Enviar XML como String
        SoapStr += "<usuario xsi:type=""xsd:string"">" + _usuario + "</usuario>" 'Usuario Base64
        SoapStr += "<password xsi:type=""xsd:string"">" + _password + "</password>" 'Contraseña Base64
        SoapStr += "<id_usuario xsi:type=""xsd:string"">" + _id_usuario + "</id_usuario>" 'ID_USUARIO Base64
        SoapStr += "<id_empresa xsi:type=""xsd:string"">" + _id_empresa + "</id_empresa>" 'ID_EMPRESA Base64
        SoapStr += "</urn:procesardte>"
        SoapStr += "</soapenv:Body>"
        SoapStr += "</soapenv:Envelope>"

        'Asignar Protocolo de Seguridad
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Try
            'Soap String a Byte
            SoapByte = System.Text.Encoding.UTF8.GetBytes(SoapStr)
            '** Crear POST Request con URL del Web Service
            Request = HttpWebRequest.Create(URLDTE)
            Request.KeepAlive = True
            Request.ContentType = "text/xml; charset=utf-8"
            Request.ContentLength = SoapByte.Length
            Request.Method = "POST"
            'Agregar Headers para Decompresión GZip
            Request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate")
            Request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            'Declarar Encode UTF-8
            Dim Enc As Encoding = Encoding.GetEncoding("iso-8859-1")

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
                        'Using Reader As StreamReader = New StreamReader(_DataStream)
                        SoapResponse = Reader.ReadToEnd()
                    End Using
                End Using
            End Using

            'Declarar XDocSoap como XDocument
            Dim XDocSoap As XDocument = New XDocument()

            If SoapResponse <> Nothing Then
                'Parsear String SoapResponse en variable XDocSoap
                Try
                    'SoapResponse = SoapResponse.Replace("¡¡La inserción no se realizó!!¡¡La inserción no se realizó!!", "")
                    'SoapResponse = SoapResponse.Replace("¡¡La inserción no se realizó!!", "")
                    XDocSoap = XDocument.Parse(SoapResponse)
                Catch ex As Exception
                    Return Nothing
                End Try

            End If

            'Declarar XNamespace para XSI y XSD (Se encuentran en el elemento Envelope del response SOAP)
            Dim nsXSI As XNamespace = "http://www.w3.org/2001/XMLSchema-instance"
            Dim nsXSD As XNamespace = "http://www.w3.org/2001/XMLSchema"

            'Declarar XElement XDocResp y asignar solo el elemento "procesardteResponse" y namespace "urn:procesardte" al que pertenece
            Dim XDocResp = XDocSoap.Descendants("{urn:procesardte}procesardteResponse").First()

            'Asignar XNamespace XSI y XSD a Elemento XDocVtaBonInterfazResp
            XDocResp.Add(New XAttribute(XNamespace.Xmlns + "xsi", nsXSI))
            XDocResp.Add(New XAttribute(XNamespace.Xmlns + "xsd", nsXSD))

            'Declarar Variable DocBodyStr
            Dim DocBodyStr As String

            'Parsear XElement XDocResp en variable DocBodyStr
            DocBodyStr = XDocResp.ToString

            'Declarar XRoot como XmlRootAttribute, asignando el elemento de raíz y namespace
            Dim XRoot As New XmlRootAttribute With {
            .ElementName = "procesardteResponse",
            .Namespace = "urn:procesardte",
            .IsNullable = True
            }

            'Declarar XMLSerializer, asignando el Type como procesardteResponse, y XMLRootAttribute como XRoot
            Dim Serialize As New XmlSerializer(GetType(pdteRest.procesardteResponse), XRoot)

            'Declarar Variable E_procdte
            Dim _procdte As pdteRest.procesardteResponse = Nothing

            'Leer DocBodyStr con StringReader
            Using reader As New StringReader(DocBodyStr)
                'Deserializar DocBodyStr (reader), asignando el Type procesardteResponse y guardar en variable _procdte
                _procdte = DirectCast(Serialize.Deserialize(reader), pdteRest.procesardteResponse)
            End Using

            'Capturar el Return del Web Service
            Dim strXML = _procdte._return

            'Decodificar el Return
            strXML = HttpUtility.HtmlDecode(strXML)

            Dim DecXML As String = strXML

            Dim XDecXML As XDocument = New XDocument()

            If DecXML <> Nothing Then
                'Parsear String DecXML en variable XDocSoap
                XDecXML = XDocument.Parse(DecXML)
            End If

            Dim SerializeDec As New XmlSerializer(GetType(xDocConv.XDecXML))

            Dim _XDec As xDocConv.XDecXML = Nothing

            'Obtener primer nodo XML
            Dim XDocString = XDecXML.FirstNode.ToString

            'Leer XDocString con StringReader
            Using reader As New StringReader(XDocString)
                'Deserializar XDocString (reader), asignando el Type XDecXML y guardar en variable _XDec
                _XDec = DirectCast(SerializeDec.Deserialize(reader), xDocConv.XDecXML)
            End Using

            Try
                'Decodificar la URL
                _XDec.rutadocumento = HttpUtility.UrlDecode(_XDec.rutadocumento)
            Catch ex As Exception

            End Try

            If _XDec.glosa = "Documento Generado Exitoso" Then
                Dim _r As Integer
                _r = NN.IRIS_WEBF_GUARDA_DATOS_NOTA_CREDITO(Folio, _XDec.folio, _XDec.rutadocumento, USUARIO)
            End If
            'Guardar FOLIO y RUTA_DOCUMENTO en IRIS_ATENCION


            'Retornar Objeto _XDec
            Return _XDec
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    <Services.WebMethod()>
    Public Shared Function Ver_Boleta_Electronica(ByVal Folio As String) As E_RUTA_DOC_BE
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As New E_RUTA_DOC_BE
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA()
        datas = NN.IRIS_WEBF_BUSCA_RUTA_BOLETA_ELECTRONICA(Folio)

        Return datas


    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Usuarios As New N_Usuario_Sum
        Dim Data_Usuarios_Resumen As New List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Consultar por previsiones activas
        Data_Usuarios_Resumen = NN_Usuarios.IRIS_WEBF_CMVM_BUSCA_USUARIO2_BOL()
        Return Data_Usuarios_Resumen

    End Function

    <Services.WebMethod()>
    Public Shared Function Reporte(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_REPORTE_BOLETA)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As New List(Of E_IRIS_WEBF_REPORTE_BOLETA)
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA()
        datas = NN.IRIS_WEBF_REPORTE_BOLETA(DESDE, HASTA, ID_PROCEDENCIA)

        Return datas


    End Function
    <Services.WebMethod()>
    Public Shared Function Reporte_usuario(ByVal DESDE As String, ByVal HASTA As String, ByVal USU_NIC As String) As List(Of E_BOL_ATE)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim datas As New List(Of E_BOL_ATE)
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA()
        datas = NN.IRIS_WEBF_REPORTE_BOLETA_USUARIO_2(DESDE, HASTA, USU_NIC)

        Return datas


    End Function

    <Services.WebMethod()>
    Public Shared Function Exportar_usuario(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal USU_NIC As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN_Det_Ate As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
        Dim data_det_ate As New List(Of E_BOL_ATE)

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim edad As Integer = 0
        Dim idate As String = ""


        Dim net As Integer = 0
        Dim iva As Integer = 0
        Dim tot As Integer = 0

        Dim Mx_Data(7, 0) As Object

        data_det_ate = NN_Det_Ate.IRIS_WEBF_REPORTE_BOLETA_USUARIO_2(DESDE, HASTA, USU_NIC)

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(6, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(7, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(data_det_ate(y).ATE_NUM)
                Mx_Data(2, y) = Format(data_det_ate(y).ATE_FECHA, "dd/MM/yyyy hh:mm:ss")
                Mx_Data(3, y) = data_det_ate(y).PAC_RUT
                Mx_Data(4, y) = data_det_ate(y).PAC_NOMBRE & " " & data_det_ate(y).PAC_APELLIDO
                Mx_Data(5, y) = data_det_ate(y).FOLIO_CNE
                Mx_Data(6, y) = data_det_ate(y).TOTAL
                Mx_Data(7, y) = data_det_ate(y).USUARIO

            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Rep BE")

        'titulo de la tabla
        sl.SetCellValue("B2", "Reporte Boleta Electrónica por Usuario")

        sl.SetCellValue("B4", "USUARIO :" & USU_NIC)



        sl.SetCellValue("B6", "DESDE: " & DESDE)
        sl.SetCellValue("D6", "HASTA: " & HASTA)

        For y = 1 To 8
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "Folio")
        sl.SetCellValue("C8", "Fecha")
        sl.SetCellValue("D8", "RUT")
        sl.SetCellValue("E8", "Paciente")
        sl.SetColumnWidth("E", 40)
        sl.SetCellValue("F8", "N° Boleta")
        sl.SetColumnWidth("F", 20)
        sl.SetCellValue("G8", "Total")
        sl.SetCellValue("H8", "Usuario Emisor")
        sl.SetColumnWidth("H", 20)

        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)

                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))

            Next x
            ltabla += 1
        Next y
        ltabla += 8
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True

        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True

        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("E3", estilo3)
        sl.SetCellStyle("E4", estilo3)
        sl.SetCellStyle("E5", estilo3)

        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    <Services.WebMethod()>
    Public Shared Function Exportar(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN_Det_Ate As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
        Dim data_det_ate As New List(Of E_IRIS_WEBF_REPORTE_BOLETA)

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim edad As Integer = 0
        Dim idate As String = ""


        Dim net As Integer = 0
        Dim iva As Integer = 0
        Dim tot As Integer = 0

        Dim Mx_Data(12, 0) As Object

        data_det_ate = NN_Det_Ate.IRIS_WEBF_REPORTE_BOLETA(DESDE, HASTA, ID_PROCEDENCIA)

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(12, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(12, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(data_det_ate(y).FOLIO)
                Mx_Data(2, y) = Format(data_det_ate(y).FECHA, "dd/MM/yyyy hh:mm:ss")
                Mx_Data(3, y) = data_det_ate(y).RUT
                Mx_Data(4, y) = data_det_ate(y).NOMBRE
                Mx_Data(5, y) = data_det_ate(y).COD
                Mx_Data(6, y) = data_det_ate(y).EXAMEN
                Mx_Data(7, y) = data_det_ate(y).PROCEDENCIA
                Mx_Data(8, y) = data_det_ate(y).TP_PAGO
                Mx_Data(9, y) = data_det_ate(y).BOLETA
                Mx_Data(10, y) = data_det_ate(y).NETO
                Mx_Data(11, y) = data_det_ate(y).IVA
                Mx_Data(12, y) = data_det_ate(y).TOTAL


                net += data_det_ate(y).NETO
                iva += data_det_ate(y).IVA
                tot += data_det_ate(y).TOTAL

            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Rep BE")

        'titulo de la tabla
        sl.SetCellValue("B2", "Reporte Boleta Electrónica")

        If ID_PROCEDENCIA = 0 Then
            sl.SetCellValue("B4", "PROCEDENCIA : TODAS")
        Else
            sl.SetCellValue("B4", "PROCEDENCIA :" & data_det_ate(0).PROCEDENCIA)
        End If


        sl.SetCellValue("B6", "DESDE: " & DESDE)
        sl.SetCellValue("D6", "HASTA: " & HASTA)

        sl.SetCellValue("E3", "NETO: $" & net.ToString)
        sl.SetCellValue("E4", "IVA: $" & iva.ToString)
        sl.SetCellValue("E5", "TOTAL: $" & tot.ToString)


        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "Folio")
        sl.SetCellValue("C8", "Fecha")
        sl.SetCellValue("D8", "RUT")
        sl.SetCellValue("E8", "Nombre")
        sl.SetColumnWidth("E", 40)
        sl.SetCellValue("F8", "Código")
        sl.SetCellValue("G8", "Examen")
        sl.SetColumnWidth("G", 50)
        sl.SetCellValue("H8", "Procedencia")
        sl.SetColumnWidth("H", 30)
        sl.SetCellValue("I8", "Tipo Pago")
        sl.SetColumnWidth("I", 20)
        sl.SetCellValue("J8", "N° Boleta")
        sl.SetColumnWidth("J", 20)
        sl.SetCellValue("K8", "Neto")
        sl.SetColumnWidth("K", 20)
        sl.SetCellValue("L8", "IVA")
        sl.SetColumnWidth("L", 20)
        sl.SetCellValue("M8", "Total")
        sl.SetColumnWidth("M", 20)

        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)

                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))

            Next x
            ltabla += 1
        Next y
        ltabla += 8
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True

        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True

        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("E3", estilo3)
        sl.SetCellStyle("E4", estilo3)
        sl.SetCellStyle("E5", estilo3)

        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("M" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function


    <Services.WebMethod()>
    Public Shared Function Desvincular_BE(ByVal ATE_NUM As String, ByVal FOLIO_CNE As String, ByVal USUARIO As String) As Integer

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
        Dim ret As Integer
        ret = NN.IRIS_WEBF_GUARDA_DATOS_DESVINCULAR_BE(ATE_NUM, FOLIO_CNE, USUARIO)
        Return ret
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ATE_NUM As String) As E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
        Dim Data_Estado_Mant As New E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2

        Data_Estado_Mant = NN.IRIS_WEBF_BUSCA_DATOS_ATE_BOLETA_ELECTRONICA(ATE_NUM)
        If (Data_Estado_Mant IsNot Nothing) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_ATE(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_BOL_ATE)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
        Dim Data_Estado_Mant As New List(Of E_BOL_ATE)

        Data_Estado_Mant = NN.IRIS_WEBF_BUSCA_DATOS_BOLETA_FECHA_3(DESDE, HASTA)
        If (Data_Estado_Mant IsNot Nothing) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function EncodeStrToBase64(valor As String) As String
        Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(valor)
        Dim myBase64 As String = Convert.ToBase64String(myByte)
        Return myBase64
    End Function

End Class

Public Class pdteRest
    <System.SerializableAttribute(),
XmlRoot(ElementName:="procesardteResponse", [Namespace]:="urn:procesardte")>
    Public Class procesardteResponse
        'Cada XmlElement debe tener Element Name y Namespace = ""
        <XmlElement(ElementName:="return", [Namespace]:="")>
        Public Property _return As String
    End Class
End Class

Public Class xDocConv
    <System.SerializableAttribute(),
XmlRoot(ElementName:="server", [Namespace]:="")>
    Public Class XDecXML
        'Cada XmlElement debe tener Element Name y Namespace = ""
        <XmlElement(ElementName:="respuesta", [Namespace]:="")>
        Public Property respuesta As String

        <XmlElement(ElementName:="glosa", [Namespace]:="")>
        Public Property glosa As String

        <XmlElement(ElementName:="rutreceptor", [Namespace]:="")>
        Public Property rutreceptor As String

        <XmlElement(ElementName:="folio", [Namespace]:="")>
        Public Property folio As String

        <XmlElement(ElementName:="tipo", [Namespace]:="")>
        Public Property tipo As String

        <XmlElement(ElementName:="rutadocumento", [Namespace]:="")>
        Public Property rutadocumento As String
    End Class
End Class