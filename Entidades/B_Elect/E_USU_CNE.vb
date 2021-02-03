Public Class E_USU_CNE
    Private EE_USU_CNE As String
    Private EE_PASS_CNE As String
    Private EE_ID_USU_CNE As String
    Private EE_ID_EMPRESA_CNE As String
    Public Property ID_EMPRESA_CNE() As String
        Get
            Return EE_ID_EMPRESA_CNE
        End Get
        Set(ByVal value As String)
            EE_ID_EMPRESA_CNE = value
        End Set
    End Property
    Public Property ID_USU_CNE() As String
        Get
            Return EE_ID_USU_CNE
        End Get
        Set(ByVal value As String)
            EE_ID_USU_CNE = value
        End Set
    End Property
    Public Property PASS_CNE() As String
        Get
            Return EE_PASS_CNE
        End Get
        Set(ByVal value As String)
            EE_PASS_CNE = value
        End Set
    End Property
    Public Property USU_CNE() As String
        Get
            Return EE_USU_CNE
        End Get
        Set(ByVal value As String)
            EE_USU_CNE = value
        End Set
    End Property
End Class
