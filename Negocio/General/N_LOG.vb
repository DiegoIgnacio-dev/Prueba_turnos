Imports System.Web
Imports System.IO
Public Class N_Log
    Dim fileRoot As String = "C:\"
    Private filePath As String = ""

    ''' <summary>
    ''' Ruta absoluta de guardado del archivo con respecto a la carpeta raíz del proyecto
    ''' </summary>
    ''' <returns></returns>
    Public Property Path() As String
        Get
            Return filePath
        End Get
        Set(ByVal value As String)
            filePath = value.Replace("/", "\")

            Dim arrDir As String() = filePath.Split("\")
            Dim Folder_Dir As String = ""

            For i = 0 To (arrDir.Count - 1)
                Select Case i
                    Case Is = (arrDir.Count - 1)
                        Exit For
                    Case Else
                        If (Trim(arrDir(i)) <> "") Then
                            Folder_Dir &= "\" & arrDir(i)
                        End If
                End Select
            Next i

            If (Directory.Exists(fileRoot & "/" & Folder_Dir) = False) Then
                Directory.CreateDirectory(fileRoot & "/" & Folder_Dir)
            End If
        End Set
    End Property

    Sub New()
        'Obtener mediante otra vía la Raíz del proyecto
        fileRoot = Hosting.HostingEnvironment.MapPath("/")
    End Sub

    ''' <summary>
    ''' Escribe una nueva línea de texto en el archivo de log.
    ''' </summary>
    ''' <param name="txtLine">Cadena con el texto a insertar, por defecto este corresponde a un salto de línea</param>
    Public Sub Write_Line(Optional ByVal txtLine As String = "", Optional ByVal Timestamp As Boolean = True)
        Select Case txtLine
            Case ""
                File.AppendAllText(fileRoot & filePath, txtLine & vbCrLf)
            Case Else
                Dim xStr As String = txtLine

                If (Timestamp = True) Then
                    xStr = Format(Date.Now, "[dd/MM/yyyy -> hh:mm:ss] ") & xStr
                End If

                xStr = xStr.Replace(" />", "/>")
                xStr = xStr.Replace("<space/>", "                         ")

                File.AppendAllText(fileRoot & filePath, xStr & vbCrLf)
        End Select


    End Sub
    Public Sub Write_Separator()
        File.AppendAllText(fileRoot & filePath, "----------------------------------------------------------------------------------" & vbCrLf)
    End Sub

    Public Sub Write_ERROR(ByVal Ex As Exception)
        Dim xPath As String = fileRoot & filePath
        Dim txtError As New StringBuilder

        txtError.Append("----------------------------------------------------------------------------------" & vbCrLf)
        txtError.Append(Format(Date.Now, "[dd/MM/yyyy -> hh:mm:ss]") & " ERROR:" & vbCrLf)
        txtError.Append("    Código: " & vbCrLf)
        txtError.Append("        " & Ex.GetHashCode & vbCrLf)
        txtError.Append(vbCrLf)

        Dim txtMessage As String = Ex.Message
        Dim xLen_Limit As Integer = 60
        Dim List_Message As New List(Of String)

        Do Until (Trim(txtMessage) = "")
            Dim arrText As String() = txtMessage.Split(" ")
            Dim xItem As String = ""

            For i = 0 To (arrText.Count - 1)
                xItem &= arrText(i)

                If (xItem.Length >= xLen_Limit) Then
                    Exit For
                ElseIf (xItem <> "") Then
                    xItem &= " "
                End If
            Next i

            xItem = Trim(xItem)
            txtMessage = txtMessage.Replace(xItem, "")
            List_Message.Add(xItem)
        Loop

        txtError.Append("    Descripción: " & vbCrLf)
        For i = 0 To (List_Message.Count - 1)
            txtError.Append("        " & List_Message(i) & vbCrLf)
        Next i


        txtError.Append(vbCrLf)
        txtError.Append("    Stack Trace:")

        Dim strStackTrace As String = Ex.StackTrace.Replace(" en ", vbCrLf & "en ")
        Dim arrStackTrace As String() = strStackTrace.Split(vbCrLf)
        For i = 0 To (arrStackTrace.GetUpperBound(0))
            Dim elem As String = LTrim(arrStackTrace(i))
            txtError.Append("        " & elem.Replace(Hosting.HostingEnvironment.MapPath("/"), "ROOT:\") & vbCrLf)
        Next i
        txtError.Append("----------------------------------------------------------------------------------" & vbCrLf)

        File.AppendAllText(xPath, txtError.ToString)
    End Sub
End Class
