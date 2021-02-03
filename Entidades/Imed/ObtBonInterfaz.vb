Imports System.Xml.Serialization
Public Class ObtBonInterfaz
    'XmlRoot elemento "ObtBonInterfazResponse" con namespace "urn:WsInterfaz"
    <System.SerializableAttribute(),
XmlRoot(ElementName:="ObtBonInterfazResponse", [Namespace]:="urn:WsInterfaz")>
    Public Class ObtBonInterfazResponse
        'Cada XmlElement debe tener Element Name y Namespace = ""
        <XmlElement(ElementName:="CodFinanciador", [Namespace]:="")>
        Public Property CodFinanciador As Integer

        <XmlElement(ElementName:="RutConvenio", [Namespace]:="")>
        Public Property RutConvenio As String

        <XmlElement(ElementName:="CorrConvenio", [Namespace]:="")>
        Public Property CorrConvenio As Integer

        <XmlElement(ElementName:="RutTratante", [Namespace]:="")>
        Public Property RutTratante As String

        <XmlElement(ElementName:="RutSolic", [Namespace]:="")>
        Public Property RutSolic As String

        <XmlElement(ElementName:="NomSolic", [Namespace]:="")>
        Public Property NomSolic As String

        <XmlElement(ElementName:="CodEspecia", [Namespace]:="")>
        Public Property CodEspecia As String

        <XmlElement(ElementName:="RutBenef", [Namespace]:="")>
        Public Property RutBenef As String

        <XmlElement(ElementName:="IndUrgencia", [Namespace]:="")>
        Public Property IndUrgencia As String

        <XmlElement(ElementName:="CodError", [Namespace]:="")>
        Public Property CodError As Integer

        <XmlElement(ElementName:="GloError", [Namespace]:="")>
        Public Property GloError As String

        'Cada XmlArray debe tener Element Name y Namespace = ""
        <XmlArray(ElementName:="ListaBonos", [Namespace]:="")>
        Public Property ListaBonos As List(Of ListaBonosType)

        <XmlArray(ElementName:="ListaForPag", [Namespace]:="", IsNullable:=True)>
        Public Property ListaForPag As List(Of ListaForPagType)

    End Class

    'Cada Lista de Type debe tener XmlType y Namespace "urn:WsInterfaz"
    <XmlType("ListaBonosType", [Namespace]:="urn:WsInterfaz")>
    Public Class ListaBonosType
        <XmlElement(ElementName:="FolioBono", [Namespace]:="")>
        Public Property FolioBono As Integer
        <XmlElement(ElementName:="FecEmi", [Namespace]:="")>
        Public Property FecEmi As String
        <XmlElement(ElementName:="NumPrestBon", [Namespace]:="")>
        Public Property NumPrestBon As Integer?
        <XmlElement(ElementName:="NumBoleta", [Namespace]:="", IsNullable:=True)>
        Public Property NumBoleta As Integer?
        <XmlElement(ElementName:="MontoAfecto", [Namespace]:="", IsNullable:=True)>
        Public Property MontoAfecto As Integer?
        <XmlElement(ElementName:="MontoExento", [Namespace]:="", IsNullable:=True)>
        Public Property MontoExento As Integer?
        <XmlElement(ElementName:="MontoTotal", [Namespace]:="", IsNullable:=True)>
        Public Property MontoTotal As Integer?
        <XmlArray(ElementName:="LisPrestVta", [Namespace]:="")>
        Public Property LisPrestVta As List(Of LisPrestVtaType)
    End Class

    'Cada Lista de Type debe tener XmlType y Namespace "urn:WsInterfaz"
    <XmlType("LisPrestVtaType", [Namespace]:="urn:WsInterfaz")>
    Public Class LisPrestVtaType
        <XmlElement(ElementName:="CodPrestacion", [Namespace]:="")>
        Public Property CodPrestacion As String

        <XmlElement(ElementName:="CodItem", [Namespace]:="")>
        Public Property CodItem As String

        <XmlElement(ElementName:="Cantidad", [Namespace]:="", IsNullable:=True)>
        Public Property Cantidad As Integer?

        <XmlElement(ElementName:="RecargoHora", [Namespace]:="")>
        Public Property RecargoHora As String

        <XmlElement(ElementName:="MontoPrest", [Namespace]:="", IsNullable:=True)>
        Public Property MontoPrest As Integer?

        <XmlElement(ElementName:="MontoBon", [Namespace]:="", IsNullable:=True)>
        Public Property MontoBon As Integer?

        <XmlElement(ElementName:="MontoCopago", [Namespace]:="", IsNullable:=True)>
        Public Property MontoCopago As Integer?

        <XmlElement(ElementName:="EsGes", [Namespace]:="")>
        Public Property EsGes As String

        <XmlElement(ElementName:="CodPatologia", [Namespace]:="")>
        Public Property CodPatologia As String

        <XmlElement(ElementName:="CodIntSanitaria", [Namespace]:="")>
        Public Property CodIntSanitaria As String

        <XmlElement(ElementName:="CodCanasta", [Namespace]:="")>
        Public Property CodCanasta As String

        <XmlElement(ElementName:="NumPieza", [Namespace]:="")>
        Public Property NumPieza As String

        <XmlArray(ElementName:="ListaOtrasBon", [Namespace]:="")>
        Public Property ListaOtrasBon As List(Of ListaOtrasBonType)
    End Class

    'Cada Lista de Type debe tener XmlType y Namespace "urn:WsInterfaz"
    <XmlType("ListaOtrasBonType", [Namespace]:="urn:WsInterfaz")>
    Public Class ListaOtrasBonType
        <XmlElement(ElementName:="CodBonAdic", [Namespace]:="", IsNullable:=True)>
        Public Property CodBonAdic As Integer?

        <XmlElement(ElementName:="GloBonAdic", [Namespace]:="")>
        Public Property GloBonAdic As String

        <XmlElement(ElementName:="MtoBonAdic", [Namespace]:="", IsNullable:=True)>
        Public Property MtoBonAdic As Integer?
    End Class

    'Cada Lista de Type debe tener XmlType y Namespace "urn:WsInterfaz"
    <XmlType("ListaForPagType", [Namespace]:="urn:WsInterfaz")>
    Public Class ListaForPagType
        <XmlElement(ElementName:="CodForPag", [Namespace]:="", IsNullable:=True)>
        Public Property CodForPag As Integer?

        <XmlElement(ElementName:="NumDoc", [Namespace]:="")>
        Public Property NumDoc As String

        <XmlElement(ElementName:="CodInst", [Namespace]:="", IsNullable:=True)>
        Public Property CodInst As Integer?

        <XmlElement(ElementName:="CodEmi", [Namespace]:="", IsNullable:=True)>
        Public Property CodEmi As Integer?

        <XmlElement(ElementName:="EmiTarBan", [Namespace]:="")>
        Public Property EmiTarBan As String

        <XmlElement(ElementName:="CodAuto", [Namespace]:="")>
        Public Property CodAuto As String

        <XmlElement(ElementName:="MtoTransac", [Namespace]:="", IsNullable:=True)>
        Public Property MtoTransac As Integer?
    End Class
End Class




