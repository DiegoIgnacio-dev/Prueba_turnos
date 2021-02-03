Imports System.Xml.Serialization
Public Class AnBonInt
    <System.SerializableAttribute(),
XmlRoot(ElementName:="AnBonIntResponse", [Namespace]:="urn:WsInterfaz")>
    Public Class AnBonIntResponse
        'Cada XmlElement debe tener Element Name y Namespace = ""
        <XmlElement(ElementName:="CodError", [Namespace]:="")>
        Public Property CodError As Integer

        <XmlElement(ElementName:="GloError", [Namespace]:="")>
        Public Property GloError As String
    End Class
End Class
