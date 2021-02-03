Public Class E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_PREI_NUM As Integer
    Dim EE_PREI_FECHA As Date
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PREI_FEC_FLE As Integer
    Dim EE_PREI_FECHA_PRE As Date
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PREI_IID_ESTADO As Integer
    Dim EE_EST_DESCRIPCION As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_PROC_DESC As String
    Dim EE_CANT_EXAM As Integer
    Dim EE_ATE_NUM As String
    Dim EE_DNI As String
    Dim EE_PREI_HORA As String

    Public Property PREI_HORA As String
        Get
            Return EE_PREI_HORA
        End Get
        Set(ByVal value As String)
            EE_PREI_HORA = value
        End Set
    End Property

    Public Property DNI As String
        Get
            Return EE_DNI
        End Get
        Set(ByVal value As String)
            EE_DNI = value
        End Set
    End Property
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property CANT_EXAM As Integer
        Get
            Return EE_CANT_EXAM
        End Get
        Set(ByVal value As Integer)
            EE_CANT_EXAM = value
        End Set
    End Property
    Public Property ID_PREINGRESO As Integer
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(value As Integer)
            EE_ID_PREINGRESO = value
        End Set
    End Property
    Public Property PREI_NUM As Integer
        Get
            Return EE_PREI_NUM
        End Get
        Set(value As Integer)
            EE_PREI_NUM = value
        End Set
    End Property
    Public Property PREI_FECHA As Date
        Get
            Return EE_PREI_FECHA
        End Get
        Set(value As Date)
            EE_PREI_FECHA = value
        End Set
    End Property
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property PREI_FEC_FLE As Integer
        Get
            Return EE_PREI_FEC_FLE
        End Get
        Set(value As Integer)
            EE_PREI_FEC_FLE = value
        End Set
    End Property
    Public Property PREI_FECHA_PRE As Date
        Get
            Return EE_PREI_FECHA_PRE
        End Get
        Set(value As Date)
            EE_PREI_FECHA_PRE = value
        End Set
    End Property
    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property PREI_IID_ESTADO As Integer
        Get
            Return EE_PREI_IID_ESTADO
        End Get
        Set(value As Integer)
            EE_PREI_IID_ESTADO = value
        End Set
    End Property
    Public Property EST_DESCRIPCION As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
End Class
