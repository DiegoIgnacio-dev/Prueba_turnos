<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Servicio_Tecnico.aspx.vb" Inherits="Presentacion.Servicio_Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        let Id_User, Asunto = "", Formulario = "", Mensaje = "", Fecha, Est_Checkbox;
        $(document).ready(function () {
            $("#txt_Asunto").val("");
            $("#txt_Formulario").val("");
            $("#txt_Mensaje").val("");

            $("#Btn_Enviar").click(aah => {
                Id_User = Galletas.getGalleta("ID_USER");
                Asunto = $("#txt_Asunto").val();
                Formulario = $("#txt_Formulario").val();
                Mensaje = $("#txt_Mensaje").val();
                Mensaje = '<p style="margin:0;padding-bottom:0.5rem">' + Mensaje.replace(/\n/g, "</p>\n<p style='margin:0;padding-bottom:0.5rem'>") + '</p>';
                Fecha = moment().format("DD-MM-YYYY hh:mm");
                Est_Checkbox = $("#checkito").prop("checked");
                //console.log(Id_User+" "+Asunto+" "+Formulario+" "+Mensaje+" "+Fecha);

                //Guardar_Ticket();
                if (Est_Checkbox == true) {
                    if (Asunto != "" && Mensaje != "") {
                        Send_Mail();
                    } else {
                        $("#mdlNotif .modal-header h4").text("Ingrese Campos");
                        $("#mdlNotif .modal-body p").html("Por favor ingrese Asunto y Mensaje.");
                        $("#mdlNotif").modal();
                    }
                } else {
                    $("#mdlNotif .modal-header h4").text("Confirmación Necesaria");
                    $("#mdlNotif .modal-body p").html("Por favor confirme la acción presionando el cuadro.");
                    $("#mdlNotif").modal();
                }
               
            });
        });

        function Send_Mail() {
            let Data_Par = JSON.stringify({
                "_ASUNTO": Asunto,
                "_FORM": Formulario,
                "_MENSAJE": Mensaje,
                "_ID_USU": Id_User,
                "_USU": Galletas.getGalleta("NAME") + " " + Galletas.getGalleta("SURNAME")
            });
            console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Servicio_Tecnico.aspx/Send_Email",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    $("#mdlNotif .modal-header h4").text("Mensaje enviado correctamente");
                    $("#mdlNotif .modal-body p").html("Se envió la información al equipo de soporte.");
                    $("#mdlNotif").modal();

                    $("#txt_Asunto").val("");
                    $("#txt_Formulario").val("");
                    $("#txt_Mensaje").val("");

                },
                "error": data => {
                    //Debug
                    $("#mdlNotif .modal-header h4").text("Error al enviar mensaje");
                    $("#mdlNotif .modal-body p").html("No se pudo enviar la información al equipo de soporte, por favor intente mas tarde.");
                    $("#mdlNotif").modal();
                }
            });
        }
        //function Guardar_Ticket() {
        //    //Debug
        //    console.log("Guardar");
        //    let Data_Par = JSON.stringify({
        //        "ID_USER": Id_User,
        //        "ASUNTO": Asunto,
        //        "FORMULARIO": Formulario,
        //        "MENSAJE": Mensaje,
        //        "FECHA": Fecha
        //    });

        //    $.ajax({
        //        "type": "POST",
        //        "url": "Servicio_Tecnico.aspx/Guardar_Ticket",
        //        "data": Data_Par,
        //        "contentType": "application/json;  charset=utf-8",
        //        "dataType": "json",
        //        "success": data => {
        //            //Debug
        //            $("#mdlNotif .modal-header h4").text("Mensaje enviado correctamente");
        //            $("#mdlNotif .modal-body p").html("Se envió la información al equipo de soporte.");
        //            $("#mdlNotif").modal();
        //        },
        //        "error": data => {
        //            //Debug
        //            $("#mdlNotif .modal-header h4").text("Error al enviar mensaje");
        //            $("#mdlNotif .modal-body p").html("No se pudo enviar la información al equipo de soporte, por favor intente mas tarde.");
        //            $("#mdlNotif").modal();
        //        }
        //    });
        //}

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar text-center">
                <h4><i class="fa fa-wrench fa-fw"></i>Soporte Técnico</h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-6">
                        <label for="">Asunto:</label>
                        <input type="text" class="form-control" id="txt_Asunto" />
                    </div>
                    <div class="col-lg-6">
                        <label for="">Formulario:</label>
                        <input type="text" class="form-control" id="txt_Formulario" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <label for="">Mensaje:</label>
                        <textarea class="form-control" style="min-height: 150px" id="txt_Mensaje"></textarea>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg text-center mt-3">
                        <label>
                            <input class="mr-2" type="checkbox" id="checkito">Estoy seguro de enviar este reporte a Irislab.</label>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-buscar" id="Btn_Enviar"><i class="fa fa-paper-plane fa-fw"></i>Enviar</button>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
