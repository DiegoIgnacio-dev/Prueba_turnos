Public Class E_IRIS_WEBF_OBTENER_INFO
    Dim EE_N_OMI As Integer
    Dim EE_RUT_PACIENTE As String
    Dim EE_NOMBRE_PACIENTE As String
    Dim EE_APELLIDO_PACIENTE As String
    Dim EE_SEXO_PACIENTE As String
    Dim EE_FECHA_NAC_PACIENTE As String
    Dim EE_DIRECCION As String
    Dim EE_FONO As String
    Dim EE_COD_EXA_INTERNO As String
    Dim EE_COD_EXA_HOMO As String
    Dim EE_NOMBRE_EXAMEN As String
    Dim EE_OBSERVACIONES As String
    Dim EE_RUT_MEDICO As String
    Dim EE_NOMBRE As String
    Dim EE_APELLIDO_MEDICO As String
    Dim EE_NUMERO_OMI_REAL As String
    Dim EE_EMP As String
    Dim EE_DNI As String
    Public Property DNI As String
        Get
            Return EE_DNI
        End Get
        Set(value As String)
            EE_DNI = value
        End Set
    End Property
    Public Property EMP As String
        Get
            Return EE_EMP
        End Get
        Set(value As String)
            EE_EMP = value
        End Set
    End Property
    Public Property NUMERO_OMI_REAL As String
        Get
            Return EE_NUMERO_OMI_REAL
        End Get
        Set(value As String)
            EE_NUMERO_OMI_REAL = value
        End Set
    End Property
    Public Property APELLIDO_MEDICO As String
        Get
            Return EE_APELLIDO_MEDICO
        End Get
        Set(value As String)
            EE_APELLIDO_MEDICO = value
        End Set
    End Property
    Public Property NOMBRE As String
        Get
            Return EE_NOMBRE
        End Get
        Set(value As String)
            EE_NOMBRE = value
        End Set
    End Property
    Public Property RUT_MEDICO As String
        Get
            Return EE_RUT_MEDICO
        End Get
        Set(value As String)
            EE_RUT_MEDICO = value
        End Set
    End Property
    Public Property OBSERVACIONES As String
        Get
            Return EE_OBSERVACIONES
        End Get
        Set(value As String)
            EE_OBSERVACIONES = value
        End Set
    End Property
    Public Property NOMBRE_EXAMEN As String
        Get
            Return EE_NOMBRE_EXAMEN
        End Get
        Set(value As String)
            EE_NOMBRE_EXAMEN = value
        End Set
    End Property
    Public Property COD_EXA_HOMO As String
        Get
            Return EE_COD_EXA_HOMO
        End Get
        Set(value As String)
            EE_COD_EXA_HOMO = value
        End Set
    End Property
    Public Property COD_EXA_INTERNO As String
        Get
            Return EE_COD_EXA_INTERNO
        End Get
        Set(value As String)
            EE_COD_EXA_INTERNO = value
        End Set
    End Property
    Public Property FONO As String
        Get
            Return EE_FONO
        End Get
        Set(value As String)
            EE_FONO = value
        End Set
    End Property
    Public Property DIRECCION As String
        Get
            Return EE_DIRECCION
        End Get
        Set(value As String)
            EE_DIRECCION = value
        End Set
    End Property
    Public Property FECHA_NAC_PACIENTE As String
        Get
            Return EE_FECHA_NAC_PACIENTE
        End Get
        Set(value As String)
            EE_FECHA_NAC_PACIENTE = value
        End Set
    End Property
    Public Property SEXO_PACIENTE As String
        Get
            Return EE_SEXO_PACIENTE
        End Get
        Set(value As String)
            EE_SEXO_PACIENTE = value
        End Set
    End Property
    Public Property APELLIDO_PACIENTE As String
        Get
            Return EE_APELLIDO_PACIENTE
        End Get
        Set(value As String)
            EE_APELLIDO_PACIENTE = value
        End Set
    End Property
    Public Property NOMBRE_PACIENTE As String
        Get
            Return EE_NOMBRE_PACIENTE
        End Get
        Set(value As String)
            EE_NOMBRE_PACIENTE = value
        End Set
    End Property
    Public Property RUT_PACIENTE As String
        Get
            Return EE_RUT_PACIENTE
        End Get
        Set(value As String)
            EE_RUT_PACIENTE = value
        End Set
    End Property

    Public Property N_OMI As Integer
        Get
            Return EE_N_OMI
        End Get
        Set(value As Integer)
            EE_N_OMI = value
        End Set
    End Property
End Class
