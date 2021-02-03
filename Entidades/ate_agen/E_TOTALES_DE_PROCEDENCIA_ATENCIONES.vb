Public Class E_TOTALES_DE_PROCEDENCIA_ATENCIONES
    Dim EE_TOTAL_AGEND_CUPO_NORMAL As Integer
    Dim EE_TOTAL_AGEND_PRIORITARIO As Integer
    Dim EE_TOTAL_AGEND_ESPONTANEO As Integer
    Dim EE_TOTAL_AGEND_PAP As Integer
    Dim EE_id_desc As String
    Public Property id_desc As String
        Get
            Return EE_id_desc
        End Get
        Set(value As String)
            EE_id_desc = value
        End Set
    End Property
    Public Property TOTAL_AGEND_PAP As Integer
        Get
            Return EE_TOTAL_AGEND_PAP
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_PAP = value
        End Set
    End Property
    Public Property TOTAL_AGEND_CUPO_NORMAL As Integer
        Get
            Return EE_TOTAL_AGEND_CUPO_NORMAL
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_CUPO_NORMAL = value
        End Set
    End Property
    Public Property TOTAL_AGEND_PRIORITARIO As Integer
        Get
            Return EE_TOTAL_AGEND_PRIORITARIO
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_PRIORITARIO = value
        End Set
    End Property
    Public Property TOTAL_AGEND_ESPONTANEO As Integer
        Get
            Return EE_TOTAL_AGEND_ESPONTANEO
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_ESPONTANEO = value
        End Set
    End Property
End Class
