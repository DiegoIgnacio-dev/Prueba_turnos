Public Class E_DATA_ULT_IMPR
    Private EE_LETRA_ATENCION As String
    Private EE_TR_TURNO_NUM As Integer
    Private EE_TR_ATENCION_TIPO As Integer


    Public Property LETRA_ATENCION() As String
        Get
            Return EE_LETRA_ATENCION
        End Get
        Set(ByVal value As String)
            EE_LETRA_ATENCION = value
        End Set
    End Property
    Public Property TR_TURNO_NUM() As Integer
        Get
            Return EE_TR_TURNO_NUM
        End Get
        Set(ByVal value As Integer)
            EE_TR_TURNO_NUM = value
        End Set
    End Property
    Public Property TR_ATENCION_TIPO() As Integer
        Get
            Return EE_TR_ATENCION_TIPO
        End Get
        Set(ByVal value As Integer)
            EE_TR_ATENCION_TIPO = value
        End Set
    End Property



End Class