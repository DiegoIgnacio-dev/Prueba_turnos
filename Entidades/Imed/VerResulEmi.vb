Imports System.Xml.Serialization
Public Class VerResulEmi
    <System.SerializableAttribute(),
XmlRoot(ElementName:="VerResulEmiResponse", [Namespace]:="urn:WsInterfaz")>
    Public Class VerResulEmiResponse
        'Cada XmlElement debe tener Element Name y Namespace = ""
        <XmlElement(ElementName:="CodEstado", [Namespace]:="")>
        Public Property CodEstado As Integer

        <XmlElement(ElementName:="GloEstado", [Namespace]:="")>
        Public Property GloEstado As String
    End Class
End Class
