Public Class E_GraficoVisor_Json
    Private Fecha As Date
    Private Cantidad As Integer
    Private Dias As String
    Private E_MES As String
    Private E_CANT_ATE As Long
    Private E_CANT_EXA As Long
    Private E_PREVI As Long
    Private E_PAGADO As Long
    Private E_COPAGO As Long
    Private E_TOTA_SIS As Long
    Private E_ESTE_MES As Long
    Private E_ESTE_DIA_MES_PASADO As Long
    Private E_Fecha_2 As Date
    Private E_Dias_2 As String
    Public Property Dias_2 As String
        Get
            Return E_Dias_2
        End Get
        Set(value As String)
            E_Dias_2 = value
        End Set
    End Property
    Public Property Fecha_2 As Date
        Get
            Return E_Fecha_2
        End Get
        Set(value As Date)
            E_Fecha_2 = value
        End Set
    End Property
    Public Property ESTE_DIA_MES_PASADO As Long
        Get
            Return E_ESTE_DIA_MES_PASADO
        End Get
        Set(value As Long)
            E_ESTE_DIA_MES_PASADO = value
        End Set
    End Property
    Public Property ESTE_MES As Long
        Get
            Return E_ESTE_MES
        End Get
        Set(value As Long)
            E_ESTE_MES = value
        End Set
    End Property
    Public Property TOTA_SIS As Long
        Get
            Return E_TOTA_SIS
        End Get
        Set(value As Long)
            E_TOTA_SIS = value
        End Set
    End Property
    Public Property MES As String
        Get
            Return E_MES
        End Get
        Set(value As String)
            E_MES = value
        End Set
    End Property
    Public Property CANT_ATE As Long
        Get
            Return E_CANT_ATE
        End Get
        Set(value As Long)
            E_CANT_ATE = value
        End Set
    End Property
    Public Property CANT_EXA As Long
        Get
            Return E_CANT_EXA
        End Get
        Set(value As Long)
            E_CANT_EXA = value
        End Set
    End Property
    Public Property PREVI As Long
        Get
            Return E_PREVI
        End Get
        Set(value As Long)
            E_PREVI = value
        End Set
    End Property
    Public Property PAGADO As Long
        Get
            Return E_PAGADO
        End Get
        Set(value As Long)
            E_PAGADO = value
        End Set
    End Property
    Public Property COPAGO As Long
        Get
            Return E_COPAGO
        End Get
        Set(value As Long)
            E_COPAGO = value
        End Set
    End Property
    Public Property E_Fecha As Date
        Get
            Return Fecha
        End Get
        Set(value As Date)
            Fecha = value
        End Set
    End Property
    Public Property E_Cantidad As Integer
        Get
            Return Cantidad
        End Get
        Set(value As Integer)
            Cantidad = value
        End Set
    End Property
    Public Property E_Dias As String
        Get
            Return Dias
        End Get
        Set(value As String)
            Dias = value
        End Set
    End Property
End Class
