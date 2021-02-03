Imports ASPPDFLib
Imports System.Web
Imports Negocio
Imports Entidades
Public Class N_PDF
    Inherits System.Web.UI.Page
    Function PDF_waa(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal data As Object) As String

        'Nombre del archivo
        Dim FileName_str As String = "LISTADO DE OC Y SEDIMENTOS" + " " + DESDE + " " + HASTA

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument


        Dim FONT_1 = DOC.Fonts("Times-Roman")               'Fuente
        Dim FONT_2 = DOC.Fonts("Times-Bold")                'Fuente Bold

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "LISTADO DE OC Y SEDIMENTOS"            'Título del documento
        DOC.Creator = "IrisLab_Osorno"                      'Creador
        DOC.Author = "IrisLab_Osorno"

        Dim eje_y As Integer = 640

        If data.Count <= 12 Then
            Dim PAGE_1 = DOC.Pages.Add(612, 792)                'Hoja Carta = 612 x 792
            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("LISTADO DE OC Y SEDIMENTOS", STR_PARAM(70, 732, 500, "center", 20), FONT_1)

                .DrawText("EXAMENES : ORINA COMPLETA Y SEDIMENTOS", STR_PARAM(43, 693, 500, "left", 16), FONT_1)

                .DrawText("Fecha Desde: " & DESDE & " " & "Hasta: " & HASTA, STR_PARAM(43, 676, 500, "left", 14), FONT_1)

                For z = 0 To (data.Count - 1)
                    .DrawText(data(z).SEXO_DESC & " " & "Folio: " & data(z).ATE_NUM, STR_PARAM(43, eje_y, 100, "left", 9), FONT_2)
                    .DrawText("C.EPI", STR_PARAM(270, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("LEUCO", STR_PARAM(305, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("ERITRO.", STR_PARAM(340, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("BACT.", STR_PARAM(378, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("MUCUS", STR_PARAM(413, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("CRIST.", STR_PARAM(448, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("CILIN", STR_PARAM(483, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("OTRO 1", STR_PARAM(518, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("OTROS 2", STR_PARAM(553, eje_y, 35, "left", 8), FONT_2)
                    eje_y = eje_y - 10
                    .DrawText(data(z).PAC_NOMBRE & " " & data(z).PAC_APELLIDO, STR_PARAM(43, eje_y, 300, "left", 9), FONT_2)
                    eje_y = eje_y - 10
                    .DrawText("Rut: " & data(z).PAC_RUT & " " & "Edad: " & data(z).ATE_AÑO & " " & "Examen: " & data(z).CF_CORTO, STR_PARAM(43, eje_y, 300, "left", 9), FONT_1)
                    eje_y = eje_y - 10
                    .DrawText("_____________________________________________________________________________________________________________________", STR_PARAM(43, eje_y, 600, "left", 9), FONT_1)
                    eje_y = eje_y - 20
                Next z
            End With
        Else
            Dim z = 0
            Dim i As Integer = 0
            'For i = 0 To data.Count / 12
            eje_y = 640
            Dim fuck = DOC.Pages.Add(612, 792)
            With fuck.Canvas
                For z = z To data.Count - 1

                    If i = 0 Then
                        .SetFillColor(0, 0, 0)
                        .DrawText("LISTADO DE OC Y SEDIMENTOS", STR_PARAM(70, 732, 500, "center", 20), FONT_1)

                        .DrawText("EXAMENES : ORINA COMPLETA Y SEDIMENTOS", STR_PARAM(43, 693, 500, "left", 16), FONT_1)

                        .DrawText("Fecha Desde: " & DESDE & " " & "Hasta: " & HASTA, STR_PARAM(43, 676, 500, "left", 14), FONT_1)

                        .DrawText(data(z).SEXO_DESC & " " & "Folio: " & data(z).ATE_NUM, STR_PARAM(43, eje_y, 200, "left", 9), FONT_2)
                        .DrawText("C.EPI", STR_PARAM(270, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("LEUCO", STR_PARAM(305, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("ERITRO.", STR_PARAM(340, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("BACT.", STR_PARAM(378, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("MUCUS", STR_PARAM(413, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("CRIST.", STR_PARAM(448, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("CILIN", STR_PARAM(483, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("OTRO 1", STR_PARAM(518, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("OTROS 2", STR_PARAM(553, eje_y, 35, "left", 8), FONT_2)
                        eje_y = eje_y - 10
                        .DrawText(data(z).PAC_NOMBRE & " " & data(z).PAC_APELLIDO, STR_PARAM(43, eje_y, 300, "left", 9), FONT_2)
                        eje_y = eje_y - 10
                        .DrawText("Rut: " & data(z).PAC_RUT & " " & "Edad: " & data(z).ATE_AÑO & " " & "Examen: " & data(z).CF_CORTO, STR_PARAM(43, eje_y, 300, "left", 9), FONT_1)
                        eje_y = eje_y - 10
                        .DrawText("_____________________________________________________________________________________________________________________", STR_PARAM(43, eje_y, 600, "left", 9), FONT_1)
                        eje_y = eje_y - 20
                        i = 1

                    Else

                        If z <> 0 Then
                            If z Mod 13 = 0 Then
                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 740
                            End If
                        End If
                        With fuck.Canvas
                            .DrawText(data(z).SEXO_DESC & " " & "Folio: " & data(z).ATE_NUM, STR_PARAM(43, eje_y, 200, "left", 9), FONT_2)
                            .DrawText("C.EPI", STR_PARAM(270, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("LEUCO", STR_PARAM(305, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("ERITRO.", STR_PARAM(340, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("BACT.", STR_PARAM(378, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("MUCUS", STR_PARAM(413, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("CRIST.", STR_PARAM(448, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("CILIN", STR_PARAM(483, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("OTRO 1", STR_PARAM(518, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("OTROS 2", STR_PARAM(553, eje_y, 35, "left", 8), FONT_2)
                            eje_y = eje_y - 10
                            .DrawText(data(z).PAC_NOMBRE & " " & data(z).PAC_APELLIDO, STR_PARAM(43, eje_y, 300, "left", 9), FONT_2)
                            eje_y = eje_y - 10
                            .DrawText("Rut: " & data(z).PAC_RUT & " " & "Edad: " & data(z).ATE_AÑO & " " & "Examen: " & data(z).CF_CORTO, STR_PARAM(43, eje_y, 300, "left", 9), FONT_1)
                            eje_y = eje_y - 10
                            .DrawText("_____________________________________________________________________________________________________________________", STR_PARAM(43, eje_y, 600, "left", 9), FONT_1)
                            eje_y = eje_y - 20
                        End With
                    End If
                Next z

            End With
            'Next i
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function PDF_Derivados(ByVal DOMAIN_URL As String, ByVal data As List(Of E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_), ByVal Derivador As String) As String

        'Nombre del archivo
        Dim FileName_str As String = "LISTADO DE PACIENTES DERIVADOS"

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument


        Dim FONT_1 = DOC.Fonts("Times-Roman")               'Fuente
        Dim FONT_2 = DOC.Fonts("Times-Bold")                'Fuente Bold

        Dim img_iris = DOC.OpenImage(My.Request.PhysicalApplicationPath & "Imagenes\" & "logo_irislabPDF.jpg")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "LISTADO DE PACIENTES DERIVADOS"            'Título del documento
        DOC.Creator = "IrisLab_Osorno"                      'Creador
        DOC.Author = "IrisLab_Osorno"

        Dim eje_y As Integer = 640

        If data.Count <= 12 Then
            Dim PAGE_1 = DOC.Pages.Add(612, 792)                'Hoja Carta = 612 x 792   ....
            With PAGE_1.Canvas
                .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                .SetFillColor(0, 0, 0)
                .DrawText("LISTADO DE PACIENTES Y DERIVADOS", STR_PARAM(70, 732, 500, "center", 20), FONT_1)

                .DrawText("Fecha: " & Date.Now & "        " & "A: " & Derivador, STR_PARAM(43, 676, 500, "left", 14), FONT_1)

                For z = 0 To (data.Count - 1)
                    .DrawText("Folio: ", STR_PARAM(40, eje_y, 100, "left", 8), FONT_2)
                    .DrawText("Fecha", STR_PARAM(65, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("Rut", STR_PARAM(125, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("Nombre Paciente", STR_PARAM(175, eje_y, 65, "left", 8), FONT_2)
                    .DrawText("F.Nacimiento", STR_PARAM(285, eje_y, 50, "left", 8), FONT_2)
                    .DrawText("Orden", STR_PARAM(350, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("Examen", STR_PARAM(405, eje_y, 35, "left", 8), FONT_2)
                    .DrawText("Médico", STR_PARAM(475, eje_y, 35, "left", 8), FONT_2)

                    eje_y = eje_y - 15

                    .DrawText(data(z).ATE_NUM, STR_PARAM(40, eje_y, 100, "left", 6), FONT_2)
                    .DrawText(data(z).ATE_FECHA, STR_PARAM(65, eje_y, 35, "left", 6), FONT_2)
                    .DrawText(data(z).PAC_RUT, STR_PARAM(125, eje_y, 35, "left", 6), FONT_2)
                    .DrawText(data(z).PAC_NOMBRE & " " & data(z).PAC_APELLIDO, STR_PARAM(175, eje_y, 100, "left", 6), FONT_2)
                    .DrawText(CDate(Format(data(z).PAC_FNAC, "dd/MMMM/yy")), STR_PARAM(285, eje_y, 50, "left", 6), FONT_2)
                    .DrawText(data(z).ORD_DESC, STR_PARAM(350, eje_y, 35, "left", 6), FONT_2)
                    .DrawText(data(z).CF_DESC, STR_PARAM(405, eje_y, 35, "left", 6), FONT_2)
                    .DrawText(data(z).DOC_NOMBRE & " " & data(z).DOC_APELLIDO, STR_PARAM(475, eje_y, 100, "left", 6), FONT_2)

                    eje_y = eje_y - 10

                    .DrawText("_____________________________________________________________________________________________________________________", STR_PARAM(43, eje_y, 600, "left", 9), FONT_1)

                    eje_y = eje_y - 22
                Next z
            End With
        Else
            Dim z = 0
            Dim i As Integer = 0
            'For i = 0 To data.Count / 12
            eje_y = 640
            Dim fuck = DOC.Pages.Add(612, 792)
            With fuck.Canvas
                For z = z To data.Count - 1

                    If i = 0 Then
                        .DrawImage(img_iris, "x=10, y=740, scalex=0.6, scaley=0.6")
                        .SetFillColor(0, 0, 0)
                        .DrawText("LISTADO DE PACIENTES Y DERIVADOS", STR_PARAM(70, 732, 500, "center", 20), FONT_1)
                        .DrawText("Fecha: " & Date.Now & "    " & "A: " & Derivador, STR_PARAM(43, 676, 500, "left", 14), FONT_1)

                        .DrawText("Folio: ", STR_PARAM(40, eje_y, 100, "left", 8), FONT_2)
                        .DrawText("Fecha", STR_PARAM(65, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("Rut", STR_PARAM(125, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(175, eje_y, 65, "left", 8), FONT_2)
                        .DrawText("F.Nacimiento", STR_PARAM(285, eje_y, 50, "left", 8), FONT_2)
                        .DrawText("Orden", STR_PARAM(350, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("Examen", STR_PARAM(405, eje_y, 35, "left", 8), FONT_2)
                        .DrawText("Médico", STR_PARAM(475, eje_y, 35, "left", 8), FONT_2)

                        eje_y = eje_y - 20

                        .DrawText(data(z).ATE_NUM, STR_PARAM(40, eje_y, 100, "left", 6), FONT_2)
                        .DrawText(data(z).ATE_FECHA, STR_PARAM(65, eje_y, 35, "left", 6), FONT_2)
                        .DrawText(data(z).PAC_RUT, STR_PARAM(125, eje_y, 35, "left", 6), FONT_2)
                        .DrawText(data(z).PAC_NOMBRE & " " & data(z).PAC_APELLIDO, STR_PARAM(175, eje_y, 100, "left", 6), FONT_2)
                        .DrawText(CDate(Format(data(z).PAC_FNAC, "dd/MMMM/yy")), STR_PARAM(285, eje_y, 50, "left", 6), FONT_2)
                        .DrawText(data(z).ORD_DESC, STR_PARAM(350, eje_y, 35, "left", 6), FONT_2)
                        .DrawText(data(z).CF_DESC, STR_PARAM(405, eje_y, 35, "left", 6), FONT_2)
                        .DrawText(data(z).DOC_NOMBRE & " " & data(z).DOC_APELLIDO, STR_PARAM(475, eje_y, 100, "left", 6), FONT_2)

                        eje_y = eje_y - 10

                        .DrawText("_____________________________________________________________________________________________________________________", STR_PARAM(43, eje_y, 600, "left", 9), FONT_1)

                        eje_y = eje_y - 22
                        i = 1

                    Else

                        If z <> 0 Then
                            If z Mod 12 = 0 Then
                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 740
                            End If
                        End If
                        With fuck.Canvas

                            .DrawText("Folio: ", STR_PARAM(40, eje_y, 100, "left", 8), FONT_2)
                            .DrawText("Fecha", STR_PARAM(65, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("Rut", STR_PARAM(125, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("Nombre Paciente", STR_PARAM(175, eje_y, 65, "left", 8), FONT_2)
                            .DrawText("F.Nacimiento", STR_PARAM(285, eje_y, 50, "left", 8), FONT_2)
                            .DrawText("Orden", STR_PARAM(350, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("Examen", STR_PARAM(405, eje_y, 35, "left", 8), FONT_2)
                            .DrawText("Médico", STR_PARAM(475, eje_y, 35, "left", 8), FONT_2)

                            eje_y = eje_y - 20

                            .DrawText(data(z).ATE_NUM, STR_PARAM(40, eje_y, 100, "left", 6), FONT_2)
                            .DrawText(data(z).ATE_FECHA, STR_PARAM(65, eje_y, 35, "left", 6), FONT_2)
                            .DrawText(data(z).PAC_RUT, STR_PARAM(125, eje_y, 35, "left", 6), FONT_2)
                            .DrawText(data(z).PAC_NOMBRE & " " & data(z).PAC_APELLIDO, STR_PARAM(175, eje_y, 100, "left", 6), FONT_2)
                            .DrawText(CDate(Format(data(z).PAC_FNAC, "dd/MMMM/yy")), STR_PARAM(285, eje_y, 50, "left", 6), FONT_2)
                            .DrawText(data(z).ORD_DESC, STR_PARAM(350, eje_y, 35, "left", 6), FONT_2)
                            .DrawText(data(z).CF_DESC, STR_PARAM(405, eje_y, 35, "left", 6), FONT_2)
                            .DrawText(data(z).DOC_NOMBRE & " " & data(z).DOC_APELLIDO, STR_PARAM(475, eje_y, 100, "left", 6), FONT_2)

                            eje_y = eje_y - 10

                            .DrawText("_____________________________________________________________________________________________________________________", STR_PARAM(43, eje_y, 600, "left", 9), FONT_1)

                            eje_y = eje_y - 22
                        End With
                    End If
                Next z

            End With
            'Next i
        End If


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Private Function STR_PARAM(ByVal x As Single, ByVal y As Single, ByVal width As Single,
         ByVal alignment As String, ByVal size As Single) As String
        Dim PARAM_XX As String

        'Parámetros de la cadena
        PARAM_XX = ""
        PARAM_XX += "x=" & x & ";"                              'Posición x del cuadro de texto
        PARAM_XX += "y=" & y & ";"                              'Posición y del cuadro de texto
        PARAM_XX += "width=" & width & ";"                      'Ancho del cuadro de texto
        PARAM_XX += "alignment=" & alignment & ";"              'Alineación del cuadro de texto
        PARAM_XX += "size=" & size & ""                         'Tamaño de la fuente

        Return PARAM_XX
    End Function
End Class
