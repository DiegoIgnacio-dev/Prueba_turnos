﻿Public Class E_IRIS_WEBF_BUSCA_DATOS_ATENCION_IMED
    Private EE_ID_ATENCION As Long
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_ID_PACIENTE As Long
    Private EE_PAC_RUT As String
    Private EE_PREVE_DESC As String
    Private EE_PROC_DESC As String
    Private EE_ATE_BON_IMED As String
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_ATE_DET_NUM_BONO As String
    Private EE_CF_DESC As String
    Private EE_USU_NIC As String
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
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
    Public Property ATE_DET_NUM_BONO() As String
        Get
            Return EE_ATE_DET_NUM_BONO
        End Get
        Set(ByVal value As String)
            EE_ATE_DET_NUM_BONO = value
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
    Public Property ATE_BON_IMED() As String
        Get
            Return EE_ATE_BON_IMED
        End Get
        Set(ByVal value As String)
            EE_ATE_BON_IMED = value
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
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
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
    Public Property ID_PACIENTE() As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Long)
            EE_ID_PACIENTE = value
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
    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
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
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property

End Class
