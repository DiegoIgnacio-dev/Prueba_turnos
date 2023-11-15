
Imports Entidades
    Imports Datos
Public Class N_Ingresa_Turno
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_Ingresa_Turno
    Public Sub New()
        Instancia_Datos = New D_Ingresa_Turno
    End Sub
    Public Function Ingresar_Turno(ByVal MD_MODULO As Char, ByVal MD_TURNO_IMPR As Integer, ByVal MD_TURNO_RECEP As Integer, ByVal MD_TIPO_MODULO As Integer, ByVal ID_ESTADO As Integer) As Integer
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.Ingresar_Turno(MD_MODULO, MD_TURNO_IMPR, MD_TURNO_RECEP, MD_TIPO_MODULO, ID_ESTADO) 'CUIDAR NOMBRES DE FUNCIONES
    End Function

    '############### CAPA DE NEGOCIOS UPDATE_TURNOS#######################
    Public Function Update_Turno(ByVal ID_TURNO As Integer) As Integer
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.Update_Turno(ID_TURNO) 'CUIDAR NOMBRES DE FUNCIONES
    End Function

    '################# CAPA DE NEGOCIOS CHECK_UPDATE###################
    Public Function Update_Check(ByVal ID_MODULO_TURNO As Integer, ByVal MD_FECHA As String, ByVal ID_ESTADO As Integer) As Integer
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.Update_Check(ID_MODULO_TURNO, MD_FECHA, ID_ESTADO) 'CUIDAR NOMBRES DE FUNCIONES
    End Function

End Class
