Public Class E_DATA_IMPR

    Private EE_TR_TURNO_LET As Char
    Private EE_TR_TURNO_NUM As Integer
    Private EE_TR_TURNO_TIPO As Integer
    Private EE_ONLY_DATE As Char

    Public Property TR_TURNO_LET() As Char
        Get
            Return EE_TR_TURNO_LET
        End Get
        Set(ByVal value As Char)
            EE_TR_TURNO_LET = value
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
    Public Property TR_TURNO_TIPO() As Integer
        Get
            Return EE_TR_TURNO_TIPO
        End Get
        Set(ByVal value As Integer)
            EE_TR_TURNO_TIPO = value
        End Set
    End Property

    Public Property ONLY_DATE() As Char
        Get
            Return EE_ONLY_DATE
        End Get
        Set(ByVal value As Char)
            EE_ONLY_DATE = value
        End Set
    End Property

End Class