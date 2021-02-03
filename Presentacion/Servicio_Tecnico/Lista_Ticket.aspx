<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lista_Ticket.aspx.vb" Inherits="Presentacion.Lista_Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        $(document).ready(function () {
            //Set_Div(1, "Asunto", "Hoy", "Form", "User", 1);

            $("div[data-name='ticket_div']").click(function () {
                let id_click = $(this).attr("data-value");
                console.log("Click " + id_click);
            });

            Ajax_Ticket();
        })

        let Mx_Ticket = [{
            "ID_TICKET": "",
            "ASUNTO": "",
            "FORMULARIO": "",
            "FECHA": "",
            "ESTADO": "",
            "USU_NIC": "",
            "USU_NOMBRE": "",
            "USU_APELLIDO": ""
        }];

        function Ajax_Ticket() {
            var Data_Par = JSON.stringify({
                "ID_USER": Galletas.getGalleta("ID_USER")  
            });
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Lista_Ticket.aspx/Busca_Ticket",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ticket = data.d;
                    console.log(Mx_Ticket);
                    if (Mx_Ticket != null) {
                        Fill_Ticket();
                    }
                    else {
                        console.log("error");
                    }
                },
                "error": data => {
                    //Debug
                    console.log("errorrr");
                }
            });
        }
        function Fill_Ticket(){
            Mx_Ticket.forEach(aah => {
                let F_Ticket = moment(aah.FECHA).format("DD-MM-YYYY hh:mm");
                Set_Div(aah.ID_TICKET, aah.ASUNTO, F_Ticket, aah.FORMULARIO, aah.USU_NIC+"-"+aah.USU_NOMBRE+" "+aah.USU_APELLIDO, aah.ESTADO);
            });
        }
        function Set_Div(S_Id, S_Asunto, S_Fecha, S_Formulario, S_Usuario, S_Estado) {
            let S_Class, S_Est;
            switch (S_Estado) {
                case 0:
                    S_Class = "Ticket-N-Div";
                    S_Est = " [Nueva]";
                    break;
                case 1:
                    S_Class = "Ticket-O-Div";
                    S_Est = " [Pendiente]";
                    break;
                case 2:
                    S_Class = "Ticket-C-Div";
                    S_Est = " [Solucionado]";
                    break;
            }
            $("#Body_Ticket").append(
                "<div class='mb-1 p-2 " + S_Class + "' id='Ticket_" + S_Id + "' data-name='ticket_div' data-value='" + S_Id + "'></div>"
                );
            $("#Ticket_" + S_Id).append(
                "<div class='row mb-2'><div class='col-lg-1'></div><div class='col-lg-7'><h5>" + S_Asunto + " " + S_Est + "</h5></div><div class='col-lg-4'>" + S_Fecha + "</div></div>"
                );
            $("#Ticket_" + S_Id).append(
                "<div class='row'><div class='col-lg-1'></div><div class='col-lg-7'>Formulario: " + S_Formulario + "</div><div class='col-lg-4'>" + S_Usuario + "</div></div>"
                );
        }
    </script>
    <style>
        /*NUEVO*/
        .Ticket-N-Div:hover {
            background-color: #fbdf92;
            cursor:pointer;
        }

        .Ticket-N-Div {
            border: 1px #ffc107 solid;
            background-color: #ffefc1;
            color: #856404;
        }
        /*ACTIVO*/
        .Ticket-O-Div:hover {
            background-color: #a2f5d4;
            cursor:pointer;
        }

        .Ticket-O-Div {
            border: 1px #3dd197 solid;
            background-color: #d6ffef;
        }
        /*CERRADO*/
        .Ticket-C-Div:hover {
            background-color: #ededed;
            cursor:pointer;
        }

        .Ticket-C-Div {
            border: 1px #c5c5c5 solid;
            background-color: white;
            color: #6b6b6b;
        }
    </style>
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar">
                <h4>Lista de Ticket de Soporte</h4>
            </div>
            <div class="card-body" id="Body_Ticket">
            </div>
        </div>
    </div>
</asp:Content>
