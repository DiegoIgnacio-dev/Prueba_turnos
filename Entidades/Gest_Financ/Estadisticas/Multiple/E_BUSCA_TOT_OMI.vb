Public Class E_BUSCA_TOT_OMI
    Private EE_DESCRIPCION_EXAMEN As String
    Private EE_CODIGO_EXAMEN As String
    Private EE_CANTIDAD_EXAMEN As Integer
    Public Property CANTIDAD_EXAMEN() As Integer
        Get
            Return EE_CANTIDAD_EXAMEN
        End Get
        Set(ByVal value As Integer)
            EE_CANTIDAD_EXAMEN = value
        End Set
    End Property
    Public Property CODIGO_EXAMEN() As String
        Get
            Return EE_CODIGO_EXAMEN
        End Get
        Set(ByVal value As String)
            EE_CODIGO_EXAMEN = value
        End Set
    End Property
    Public Property DESCRIPCION_EXAMEN() As String
        Get
            Return EE_DESCRIPCION_EXAMEN
        End Get
        Set(ByVal value As String)
            EE_DESCRIPCION_EXAMEN = value
        End Set
    End Property
End Class
