Imports System.Xml.Serialization
Public Class VtaBonInterfaz
    <System.SerializableAttribute(),
XmlRoot(ElementName:="VtaBonIntefazResponse", [Namespace]:="urn:WsInterfaz")>
    Public Class VtaBonInterfazResponse
        'Cada XmlElement debe tener Element Name y Namespace = ""
        <XmlElement(ElementName:="NumTransac", [Namespace]:="")>
        Public Property NumTransac As Integer

        <XmlElement(ElementName:="CodAuditoria", [Namespace]:="")>
        Public Property CodAuditoria As String

        <XmlElement(ElementName:="CodError", [Namespace]:="")>
        Public Property CodError As Integer

        <XmlElement(ElementName:="GloError", [Namespace]:="")>
        Public Property GloError As String
    End Class
End Class
