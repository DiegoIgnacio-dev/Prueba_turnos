Public Class E_DATA_CARGA_OPTION

    Private EE_ID_MODULO_RECEP As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_MODULO_RECEP_DESC As String


    Public Property ID_MODULO_RECEP() As Integer
        Get
            Return EE_ID_MODULO_RECEP
        End Get
        Set(ByVal value As Integer)
            EE_ID_MODULO_RECEP = value
        End Set
    End Property

    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Public Property MODULO_RECEP_DESC() As String
        Get
            Return EE_MODULO_RECEP_DESC
        End Get
        Set(ByVal value As String)
            EE_MODULO_RECEP_DESC = value
        End Set
    End Property


End Class
