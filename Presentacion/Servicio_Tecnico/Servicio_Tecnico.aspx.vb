Imports Entidades
Imports Negocio
Imports System.Web.Mail
Public Class Servicio_Tecnico
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Send_Email(ByVal _ASUNTO As String, ByVal _FORM As String, ByVal _MENSAJE As String, ByVal _USU As String) As String

        'Dim s As String = "the quick brown fox jumps over the lazy dog"
        'Dim s2 As String = StrConv(s, VbStrConv.ProperCase)


        Dim NN_Search3 As New N_Gen_Activos

        Dim TITLE As String
        Dim ASUNTO As String
        Dim CORP_MAIL As String
        Dim CORP_PASS As String
        Dim PORT As String
        Dim HOST As String
        Dim MAIL_DEST As String
        Dim _PROC As String
        Dim _TO As List(Of String)
        Dim _CC As List(Of String)
        Dim _T_ADM As HttpCookie = HttpContext.Current.Request.Cookies("P_ADMIN")
        Dim Lista_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Lista_Preve As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        _USU = StrConv(_USU, VbStrConv.ProperCase)

        Dim NN_Search As New N_IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST
        _TO = NN_Search.IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST()

        Dim NN_Search2 As New N_IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY
        _CC = NN_Search2.IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY()

        Lista_Proce = NN_Search3.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV()

        Lista_Preve = NN_Search3.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(0)

        '/////////////////////////
        If Lista_Proce.Count = 1 Then
            _PROC = "Procedencia: " + StrConv(Lista_Proce(0).PROC_DESC, VbStrConv.ProperCase)
        ElseIf CInt(_T_ADM.Value) = 1 Then
            _PROC = "Usuario Administrador"
        Else
            _PROC = "Previsión: "
            For Each Prevv In Lista_Preve
                If Prevv Is Lista_Preve.Last Then
                    _PROC = _PROC + StrConv(Prevv.PREVE_DESC, VbStrConv.ProperCase)
                Else
                    _PROC = _PROC + StrConv(Prevv.PREVE_DESC, VbStrConv.ProperCase) + ", "
                End If
            Next
        End If
        '////////////////////////
        'Descripción del Mensaje
        TITLE = "IrisLab Soporte Web"
        ASUNTO = _ASUNTO
        'Datos del remitente
        CORP_MAIL = "envios@irislab.cl"
        CORP_PASS = "labtuxlinktux"
        HOST = "mail.irislab.cl"
        'HOST = "mail.aclin.cl"
        PORT = "25"
        'PORT = "587"

        'Correos de Destino
        MAIL_DEST = ""
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim ERR As String

        'CONFIGURACIÓN DEL STMP
        With _SMTP
            .Host = HOST
            .Port = PORT
            .EnableSsl = False 'True
            .Credentials = New System.Net.NetworkCredential(CORP_MAIL, CORP_PASS)
        End With

        'CONFIGURACION DEL MENSAJE
        With _Message

            For y = 0 To (_TO.Count - 1)
                .[To].Add(_TO(y))
            Next y

            'Correos con copia a...
            For y = 0 To (_CC.Count - 1)
                .CC.Add(_CC(y))
            Next y

            .From = New System.Net.Mail.MailAddress(CORP_MAIL, TITLE, System.Text.Encoding.UTF8) 'Quien lo envía
            .Subject = ASUNTO       'Asunto del e-Mail
            .SubjectEncoding = System.Text.Encoding.UTF8
            Dim Body_1 As String
            Dim Body_2 As String
            Dim Body_3 As String
            Dim Body_4 As String
            Dim Body_5 As String
            Dim Body_6 As String
            Dim Body_7 As String
            Dim Body_8 As String

            Body_1 = "<div style='background-color:white;border-bottom: 1px #00738e solid;border-right: 1px #00738e solid;border-left: 1px #00738e solid;'>" ' DIV
            Body_2 = "<div style='background-color:#00738e;'><h1 style='color:#fff;text-align:center;font-size:26px;font-family:sans-serif;padding:10px 0'>" + TITLE + "</h1></div>" ' TITULO
            Body_3 = "<h3 style='color:#014b5d;padding:25px 35px;font-size:15px;margin:0'>De: " + _USU + "<br>" + _PROC + "<br>" ' ASUNTO Y FORM
            Body_4 = "Asunto: " + _ASUNTO + "<br>Formulario: " + _FORM + "</h3>" ' ASUNTO Y FORM
            Body_5 = "<div style='text-align:justify;font-size:15px;padding:0 35px;color:#002e3a'>" + _MENSAJE + "</div>" ' MENSAJE
            Body_6 = "<hr style='border-color:#c2f4ff;max-width:80%;margin-top:17px'><br><h2 style='text-align:center;margin:0;color:#014b5d'>Soporte Informático IrisLab Web</h2>" ' SOPORTE
            Body_7 = "<div style='text-align:center'><img src='http://186.103.210.187:10000/Imagenes/IrisLab%20Logo%20LARGOa.png' style='max-width:430px;width:90vw'</div>" ' LOGO
            Body_8 = "<h3 style='text-align:center;margin:0;color:#014b5d;padding-bottom:25px'>Visítanos en: <a href='http://www.irislab.cl' style='color:#007b98'>www.irislab.cl</a></h3></div>" ' URL IRISLAB
            'Codificacion
            .Body = Body_1 & Body_2 & Body_3 & Body_4 & Body_5 & Body_6 & Body_7 & Body_8    'contenido del mail
            .BodyEncoding = System.Text.Encoding.UTF8
            .Priority = System.Net.Mail.MailPriority.Normal
            .IsBodyHtml = True
        End With

        'Enviar Correo
        Try
            _SMTP.Send(_Message)
            ERR = "ok"
        Catch ex As System.Net.Mail.SmtpException
            ERR = "Error"

        End Try

        Return ERR
    End Function

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub

    '<Services.WebMethod()>
    'Public Shared Function Guardar_Ticket(ByVal ID_USER As Integer,
    '                                        ByVal ASUNTO As String,
    '                                        ByVal FORMULARIO As String,
    '                                        ByVal MENSAJE As String,
    '                                        ByVal FECHA As String) As Integer
    '    'Declaraciones del Serializador
    '    Dim str_Builder As New StringBuilder

    '    Dim objSession As HttpSessionState = HttpContext.Current.Session
    '    'Declaraciones Consulta
    '    Dim NN_Search As New N_IRIS_WEBF_CMVM_GRABA_TICKET
    '    Dim Data_OUT As Integer

    '    Data_OUT = NN_Search.IRIS_WEBF_CMVM_GRABA_TICKET(ID_USER, ASUNTO, FORMULARIO, MENSAJE, FECHA)
    '    If (Data_OUT > 0) Then


    '        Return Data_OUT
    '    Else
    '        Return Nothing
    '    End If
    'End Function
End Class