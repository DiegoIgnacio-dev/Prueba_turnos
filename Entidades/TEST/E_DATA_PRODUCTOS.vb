Public Class E_DATA_PRODUCTOS
    Private EE_ID_PRODUCTO As Long
    Private EE_NOMBRE_PRODUCTO As String
    Private EE_DESCRIPCION_PRODUCTO As String
    Private EE_PRECIO_PRODUCTO As Integer
    Public Property PRECIO_PRODUCTO() As Integer
        Get
            Return EE_PRECIO_PRODUCTO
        End Get
        Set(ByVal value As Integer)
            EE_PRECIO_PRODUCTO = value
        End Set
    End Property
    Public Property DESCRIPCION_PRODUCTO() As String
        Get
            Return EE_DESCRIPCION_PRODUCTO
        End Get
        Set(ByVal value As String)
            EE_DESCRIPCION_PRODUCTO = value
        End Set
    End Property
    Public Property NOMBRE_PRODUCTO() As String
        Get
            Return EE_NOMBRE_PRODUCTO
        End Get
        Set(ByVal value As String)
            EE_NOMBRE_PRODUCTO = value
        End Set
    End Property

    Public Property ID_PRODUCTO() As Long
        Get
            Return EE_ID_PRODUCTO
        End Get
        Set(ByVal value As Long)
            EE_ID_PRODUCTO = value
        End Set
    End Property
End Class
