﻿Public Class E_IRIS_WEBF_BUSCA_HOJA_DE_TRABAJO_DE_SECCION_FECHA_AREA_DERIVADO
    Private EE_ID_ATENCION As Integer
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As Date
    Private EE_ID_PACIENTE As Integer
    Private EE_PAC_RUT As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_FNAC As Date
    Private EE_SEXO_DESC As String
    Private EE_ID_ESTADO As Integer
    Private EE_Expr1 As Integer
    Private EE_CF_DESC As String
    Private EE_PER_DESC As String
    Private EE_RLS_LS_DESC As String
    Private EE_AREA_DESC As String
    Private EE_ID_AREA As Integer
    Private EE_ATE_AÑO As String
    Private EE_ATE_MES As String
    Private EE_ATE_DIA As String
    Private EE_PROC_DESC As String
    Private EE_ID_SEXO As Integer
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_ATE_DNI As String
    Private EE_NAC_DESC As String
    Private EE_PROGRA_DESC As String
    Private EE_SECTOR_DESC As String
    Private EE_ATE_NUM_INTERNO As String
    Private EE_ENCRYPTED_ID As String
    Public Property ENCRYPTED_ID() As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(ByVal value As String)
            EE_ENCRYPTED_ID = value
        End Set
    End Property
    Public Property ATE_NUM_INTERNO() As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property
    Public Property SECTOR_DESC() As String
        Get
            Return EE_SECTOR_DESC
        End Get
        Set(ByVal value As String)
            EE_SECTOR_DESC = value
        End Set
    End Property
    Public Property PROGRA_DESC() As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(ByVal value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property NAC_DESC() As String
        Get
            Return EE_NAC_DESC
        End Get
        Set(ByVal value As String)
            EE_NAC_DESC = value
        End Set
    End Property
    Public Property ATE_DNI() As String
        Get
            Return EE_ATE_DNI
        End Get
        Set(ByVal value As String)
            EE_ATE_DNI = value
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
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_SEXO() As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SEXO = value
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
    Public Property ATE_DIA() As String
        Get
            Return EE_ATE_DIA
        End Get
        Set(ByVal value As String)
            EE_ATE_DIA = value
        End Set
    End Property
    Public Property ATE_MES() As String
        Get
            Return EE_ATE_MES
        End Get
        Set(ByVal value As String)
            EE_ATE_MES = value
        End Set
    End Property
    Public Property ATE_AÑO() As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As String)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property ID_AREA() As Integer
        Get
            Return EE_ID_AREA
        End Get
        Set(ByVal value As Integer)
            EE_ID_AREA = value
        End Set
    End Property
    Public Property AREA_DESC() As String
        Get
            Return EE_AREA_DESC
        End Get
        Set(ByVal value As String)
            EE_AREA_DESC = value
        End Set
    End Property
    Public Property RLS_LS_DESC() As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(ByVal value As String)
            EE_RLS_LS_DESC = value
        End Set
    End Property
    Public Property PER_DESC() As String
        Get
            Return EE_PER_DESC
        End Get
        Set(ByVal value As String)
            EE_PER_DESC = value
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
    Public Property Expr1() As Integer
        Get
            Return EE_Expr1
        End Get
        Set(ByVal value As Integer)
            EE_Expr1 = value
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
    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property
    Public Property PAC_FNAC() As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property ID_PACIENTE() As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
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
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
