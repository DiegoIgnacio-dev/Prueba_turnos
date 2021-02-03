<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Grabar_Email.aspx.vb" Inherits="Presentacion.Grabar_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>

        $(document).ready(function () {
            let Chk_Name, Chk_Index, Chk_Est;
            Ajax_Dest();
            Ajax_Copy();

            $("#btn_Guardar").click(aah=> {
                Ajax_Guardar_Email();
            });

            $("input[name='dest'], input[name='copy']").click(function () {
                let Chk_Name, Chk_Index, Chk_Est;

                Chk_Name = $(this).attr("name");
                Chk_Index = $(this).attr("data-index");
                Chk_Est = $(this).prop("checked");

                console.log(Chk_Name + " " + Chk_Index + " " + Chk_Est);
            });
        });

        let Mx_Dest = [{
            "ID_DEST": "",
            "EMAIL": "",
            "NOMBRE": "",
            "ID_ESTADO": "",
        }];
        let Mx_Copy = [{
            "ID_COPY": "",
            "EMAIL": "",
            "NOMBRE": "",
            "ID_ESTADO": "",
        }];

        function Ajax_Guardar_Email() {
            let _Email, _Nombre, _Tipo;
            _Email = $("#txt_Email").val();
            _Nombre = $("#txt_Nombre").val();
            _Tipo = $('input:radio:checked').val();
            console.log(_Email + " " + _Nombre + " " + _Tipo);

            if (_Email != "" && _Nombre != "" && _Tipo!= "") {
                let Data_Par = JSON.stringify({
                    "Email": _Email,
                    "Nombre": _Nombre,
                    "Tipo": _Tipo
                });

                $.ajax({
                    "type": "POST",
                    "url": "Grabar_Email.aspx/Graba_Email",
                    "data": Data_Par,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                    "success": data => {
                        //Debug
                        if (data.d != null) {

                            $("#mdlNotif .modal-header h4").text("Email guardado con éxito");
                            $("#mdlNotif .modal-body p").html("Se registro el email de manera correcta.");
                            $("#mdlNotif").modal();

                            

                        } else {

                            $("#mdlNotif .modal-header h4").text("Problema al guardar email");
                            $("#mdlNotif .modal-body p").html("Se produjo un problema al guardar los datos, intente nuevamente mas tarde.");
                            $("#mdlNotif").modal();
                        }
                        
                    },
                    "error": data => {
                        //Debug                        
                    }
                });
            }
            Ajax_Dest();
            Ajax_Copy();
        }

        function Ajax_Dest() {
            $.ajax({
                "type": "POST",
                "url": "Grabar_Email.aspx/Busca_Dest",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Dest = data.d;
                    //console.log(Mx_Dtt);
                    if (Mx_Dest != null) {
                        Fill_Dtt_Dest();
                    }
                    else {
                        $("#Dtt_Dest tbody").empty();
                        $("#Dtt_Dest tbody").append(
                            $("<tr>").append(
                            $("<td>").attr("colspan", 4).text("No se encontraron resultados.").css("font-size", "18px")
                            )
                        );
                    }
                },
                "error": data => {
                    //Debug
                    console.log("error");
                }
            });
        }
        function Ajax_Copy() {
            $.ajax({
                "type": "POST",
                "url": "Grabar_Email.aspx/Busca_Copy",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Copy = data.d;
                    //console.log(Mx_Dtt);
                    if (Mx_Copy != null) {
                        Fill_Dtt_Copy();
                    }
                    else {
                        $("#Dtt_Copy tbody").empty();
                        $("#Dtt_Copy tbody").append(
                            $("<tr>").append(
                            $("<td>").attr("colspan", 4).text("No se encontraron resultados.").css("font-size", "18px")
                            )
                        );
                    }
                },
                "error": data => {
                    //Debug
                    console.log("error");
                }
            });
        }
        function Fill_Dtt_Dest() {
            $("#Dtt_Dest").dataTable().fnDestroy();

            $("#Dtt_Dest tbody").empty();
            var i = 1
            Mx_Dest.forEach(aah => {
                let indexx = i - 1;
                $("<tr>").attr("data-index", i - 1).append(
                    $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                    $("<td>").css("text-align", "left").text(aah.EMAIL),
                    $("<td>").css("text-align", "left").text(aah.NOMBRE),
                    $("<td>").css("text-align", "center").html(function () {
                        let chk = "";
                        if (aah.ID_ESTADO == 1) {
                            chk = "checked";
                        }
                        else {
                            chk = "";
                        }
                        return "<input type='checkbox' name='dest' data-index='" + indexx + "' " + chk + "/>";
                    })
                ).appendTo("#Dtt_Dest tbody");
                i += 1;

            });

            $("input[name='dest']").click(function () {

                Chk_Name = $(this).attr("name");
                Chk_Index = $(this).attr("data-index");
                Chk_Est = $(this).prop("checked");

                Cambia_Estado_Mail(Chk_Name, Chk_Index, Chk_Est);
                //console.log(Chk_Name + " " + Chk_Index + " " + Chk_Est);
            });

            Notif_Dtt("#Dtt_Dest");
        }

        function Fill_Dtt_Copy() {
            $("#Dtt_Copy").dataTable().fnDestroy();

            $("#Dtt_Copy tbody").empty();
            var i = 1
            Mx_Copy.forEach(aah => {
                let indexx = i - 1;
                $("<tr>").attr("data-index", i - 1).append(
                    $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                    $("<td>").css("text-align", "left").text(aah.EMAIL),
                    $("<td>").css("text-align", "left").text(aah.NOMBRE),
                    $("<td>").css("text-align", "center").html(function () {
                        let chk = "";
                        if (aah.ID_ESTADO == 1) {
                            chk = "checked";
                        }
                        else {
                            chk = "";
                        }
                        return "<input type='checkbox' name='copy' data-index='" + indexx + "' " + chk + "/>";

                    })
                ).appendTo("#Dtt_Copy tbody");
                i += 1;

            });

            $("input[name='copy']").click(function () {

                Chk_Name = $(this).attr("name");
                Chk_Index = $(this).attr("data-index");
                Chk_Est = $(this).prop("checked");

                //console.log(Chk_Name + " " + Chk_Index + " " + Chk_Est);
                Cambia_Estado_Mail(Chk_Name, Chk_Index, Chk_Est);
            });

            Notif_Dtt("#Dtt_Copy");
        }

        function Cambia_Estado_Mail(Nme, Idx, Est) {
            //console.log(Nme+" - "+Idx+" - "+Est);
            let _Nam_Email, _Est_Email, _Id_Email;

            if(Nme == "dest"){
                _Id_Email = Mx_Dest[Idx].ID_DEST;
                _Nam_Email = 1;
            }
            else{
                _Id_Email = Mx_Copy[Idx].ID_COPY;
                _Nam_Email = 2;
            }
            if (Est == true) {
                _Est_Email = 1;
            }
            else {
                _Est_Email = 2;
            }

            let Data_Par = JSON.stringify({
                "NAME": _Nam_Email,
                "ID_EMAIL": _Id_Email,
                "ESTADO": _Est_Email
            });
            // console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Grabar_Email.aspx/Cambia_Estado_Email",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Ajax_Dest();
                    Ajax_Copy();

                    $("#mdlNotif .modal-header h4").text("Email editado con éxito");
                    $("#mdlNotif .modal-body p").html("Se editó el estado del email de manera correcta.");
                    $("#mdlNotif").modal();
                    //console.log("success");
                },
                "error": data => {
                    //Debug
                    $("#mdlNotif .modal-header h4").text("Problema al esitar email");
                    $("#mdlNotif .modal-body p").html("Se produjo un problema al editar los datos, intente nuevamente mas tarde.");
                    $("#mdlNotif").modal();
                    //console.log("error");
                }
            });
        }

        function Notif_Dtt(ID) {
            $(ID).DataTable({
                //"bSort": false,
                "iDisplayLength": 50,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar text-center">
                <h4><i class="fa fa-envelope-o fa-fw"></i>Registrar Email Soporte</h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <label for="txt_Email">Email:</label>
                        <input type="text" class="form-control" id="txt_Email" />
                    </div>
                    <div class="col-lg">
                        <label for="txt_Email">Nombre:</label>
                        <input type="text" class="form-control" id="txt_Nombre" />
                    </div>
                    <div class="col-lg-2">
                        <label class="m-0">Tipo:</label>
                        <div class="form-check m-0">
                            <label class="form-check-label">
                                <input type="radio" class="form-check-input mr-2" name="optradio" value="1">Destinatario
                            </label>
                        </div>
                        <div class="form-check m-0">
                            <label class="form-check-label">
                                <input type="radio" class="form-check-input mr-2" name="optradio" value="2">Copia
                            </label>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <br />
                        <button type="button" class="btn btn-block btn-buscar" id="btn_Guardar"><i class="fa fa-save fa-fw"></i>Guardar</button>
                    </div>
                </div>

                <hr />
                <h5><i class="fa fa-list fa-fw"></i>Lista Emails</h5>
                <div class="row">
                    <div class="col-lg-6">
                        <label>Tabla Destinatario:</label>
                        <table id="Dtt_Dest" class="table table-hover table-striped table-iris" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Email</th>
                                    <th>Nombre</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                    <div class="col-lg-6">
                        <label>Tabla Copia:</label>
                        <table id="Dtt_Copy" class="table table-hover table-striped table-iris" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Email</th>
                                    <th>Nombre</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
