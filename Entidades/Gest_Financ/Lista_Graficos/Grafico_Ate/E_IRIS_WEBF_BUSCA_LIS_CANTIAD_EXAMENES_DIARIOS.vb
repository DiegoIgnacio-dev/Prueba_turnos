Public Class E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS
    Dim EE_TOTAL_ATE As Integer
    Dim EE_TOTAL_EXA As Integer
    Dim EE_TOTA_SIS As Integer
    Dim EE_TOTA_USU As Integer
    Dim EE_TOTA_COPA As Integer
    Dim EE_PREVE_DESC As String
    Dim EE_AREA_DESC As String
    Dim EE_AYER As Integer
    Dim EE_AYER_SEMANA_PASADA As Integer
    Dim EE_MES_DIA As Integer
    Dim EE_MES_DIA_PASADO As Integer
    Dim EE_MES_PASADO As Integer
    Dim EE_MES_ANTE_PASADO As Integer
    Dim EE_FECHA As Date
    Dim EE_ESTE_MES As Integer
    Dim EE_ESTE_DIA_MES_PASADO As Integer
    Public Property ESTE_DIA_MES_PASADO As Integer
        Get
            Return EE_ESTE_DIA_MES_PASADO
        End Get
        Set(value As Integer)
            EE_ESTE_DIA_MES_PASADO = value
        End Set
    End Property
    Public Property ESTE_MES As Integer
        Get
            Return EE_ESTE_MES
        End Get
        Set(value As Integer)
            EE_ESTE_MES = value
        End Set
    End Property
    Public Property FECHA As Date
        Get
            Return EE_FECHA
        End Get
        Set(value As Date)
            EE_FECHA = value
        End Set
    End Property
    Public Property MES_ANTE_PASADO As Integer
        Get
            Return EE_MES_ANTE_PASADO
        End Get
        Set(value As Integer)
            EE_MES_ANTE_PASADO = value
        End Set
    End Property
    Public Property MES_PASADO As Integer
        Get
            Return EE_MES_PASADO
        End Get
        Set(value As Integer)
            EE_MES_PASADO = value
        End Set
    End Property
    Public Property MES_DIA_PASADO As Integer
        Get
            Return EE_MES_DIA_PASADO
        End Get
        Set(value As Integer)
            EE_MES_DIA_PASADO = value
        End Set
    End Property
    Public Property MES_DIA As Integer
        Get
            Return EE_MES_DIA
        End Get
        Set(value As Integer)
            EE_MES_DIA = value
        End Set
    End Property
    Public Property AYER_SEMANA_PASADA As Integer
        Get
            Return EE_AYER_SEMANA_PASADA
        End Get
        Set(value As Integer)
            EE_AYER_SEMANA_PASADA = value
        End Set
    End Property
    Public Property AYER As Integer
        Get
            Return EE_AYER
        End Get
        Set(value As Integer)
            EE_AYER = value
        End Set
    End Property
    Public Property AREA_DESC As String
        Get
            Return EE_AREA_DESC
        End Get
        Set(value As String)
            EE_AREA_DESC = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property TOTAL_ATE As Integer
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(value As Integer)
            EE_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_EXA As Integer
        Get
            Return EE_TOTAL_EXA
        End Get
        Set(value As Integer)
            EE_TOTAL_EXA = value
        End Set
    End Property
    Public Property TOTA_SIS As Integer
        Get
            Return EE_TOTA_SIS
        End Get
        Set(value As Integer)
            EE_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Integer
        Get
            Return EE_TOTA_USU
        End Get
        Set(value As Integer)
            EE_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Integer
        Get
            Return EE_TOTA_COPA
        End Get
        Set(value As Integer)
            EE_TOTA_COPA = value
        End Set
    End Property
End Class
