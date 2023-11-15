Imports Datos
Imports Entidades
Public Class N_SIGUIENTE_TURNO
    'Declaramos una nueva instancia a al capa Datos
    Private Instancia_Datos As D_SIGUIENTE_TURNO
    Public Sub New()
        Instancia_Datos = New D_SIGUIENTE_TURNO
    End Sub
    Public Function Siguiente_Turno(ByVal ID_MODULO_TURNO As Integer, ByVal ID_MODULO_RECEP As Integer, ByVal TIPO_ATENCION As Integer, ByVal ONLY_DATE As String, ByVal DATO_NUM As Integer, ByVal LETRA_TURNO As Char) As Integer

        Dim _Return As Integer = 0
        Dim FECHA_HOY As String
        FECHA_HOY = Date.Now.ToString("dd-MM-yyyy")
        Dim ID_LOG As Integer = 0

        ID_LOG = Instancia_Datos.Busca_Log_Turno(ID_MODULO_TURNO, DATO_NUM, FECHA_HOY)

        If ID_LOG > 0 Then
            'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
            _Return += Instancia_Datos.Siguiente_Turno(ID_MODULO_TURNO, ID_MODULO_RECEP, TIPO_ATENCION, ONLY_DATE, DATO_NUM, LETRA_TURNO) 'CUIDAR NOMBRES DE FUNCIONES
            _Return += Instancia_Datos.Update_Log_Turno(ID_MODULO_TURNO, ID_MODULO_RECEP, DATO_NUM, FECHA_HOY) 'CUIDAR NOMBRES DE FUNCIONES

        End If

        Return _Return
    End Function


    Function RESET_FECHA() As List(Of E_DATA_RESET_FECHA) 'Igual que el Back End de Presentacion
        'definir variables para trabajar 
        'comparar fecha actual con la de  mi base de datos para actualizar registros
        Dim FECHA_HOY As String
        FECHA_HOY = Date.Now.ToString("dd-MM-yyyy")
        Dim REG As Object
        REG = Instancia_Datos.RESET_FECHA()
        For i = 0 To REG.Count - 1
            Dim IDREG As Integer = REG(i).ID_MODULO_TURNO
            Dim FECHA As Date = REG(i).MD_FECHA

            If FECHA <> FECHA_HOY Then
                Instancia_Datos.Update_Fecha(IDREG)
            End If
        Next

        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.RESET_FECHA()
    End Function

    Public Function UPDATE_TIME(ByVal LETRA_TURNO As Char, ByVal TIPO_ATENCION As Integer) As Integer
        'En este caso se opta por no crear una nueva lista de entidad, y se envía directa la lista, las 2 opciones son viables.
        Return Instancia_Datos.UPDATE_TIME(LETRA_TURNO, TIPO_ATENCION)
    End Function

End Class
