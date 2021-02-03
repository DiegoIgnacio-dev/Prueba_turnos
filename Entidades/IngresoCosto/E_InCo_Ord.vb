Public Class E_InCo_Ord
    Private EE_ID_ATENCION As Long
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_PROC_DESC As String
    Private EE_PREVE_DESC As String
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_CF_DESC As String
    Private EE_CF_COD As String
    Private EE_ATE_DET_V_PREVI As Integer
    Private EE_ATE_DET_V_PAGADO As Integer
    Private EE_ATE_DET_V_COPAGO As Integer
    Private EE_CONTROL_COSTO_PRECIO As Integer
    Private EE_ORD_DESC As String
    Public Property ORD_DESC() As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(ByVal value As String)
            EE_ORD_DESC = value
        End Set
    End Property
    Public Property CONTROL_COSTO_PRECIO() As Integer
        Get
            Return EE_CONTROL_COSTO_PRECIO
        End Get
        Set(ByVal value As Integer)
            EE_CONTROL_COSTO_PRECIO = value
        End Set
    End Property
    Public Property ATE_DET_V_COPAGO() As Integer
        Get
            Return EE_ATE_DET_V_COPAGO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_COPAGO = value
        End Set
    End Property
    Public Property ATE_DET_V_PAGADO() As Integer
        Get
            Return EE_ATE_DET_V_PAGADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_PAGADO = value
        End Set
    End Property
    Public Property ATE_DET_V_PREVI() As Integer
        Get
            Return EE_ATE_DET_V_PREVI
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_PREVI = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property DOC_APELLIDO() As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property DOC_NOMBRE() As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
