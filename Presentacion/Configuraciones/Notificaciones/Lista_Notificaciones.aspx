<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Lista_Notificaciones.aspx.vb" Inherits="Presentacion.Lista_Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
<%--    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="easyui/themes/icon.css">
    <script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>--%>
    <script>
        $(document).ready(fn=> {
            Llenar_Ddl_Preve();
            Llenar_Ddl_Proce();
            Llenar_Ddl_Users();

            $("#Slt_Preve").click((aah) => {
                Last_Changed = 1;
                $("#Slt_Preve").addClass("border-warning border-2x");
                $("#Slt_Proce").removeClass("border-warning border-2x");
                $("#Slt_Users").removeClass("border-warning border-2x");
                $("#Slt_Confirma").removeClass("border-warning border-2x");
            });
            $("#Slt_Proce").click(aah=> {
                Last_Changed = 2;
                $("#Slt_Preve").removeClass("border-warning border-2x");
                $("#Slt_Proce").addClass("border-warning border-2x");
                $("#Slt_Confirma").removeClass("border-warning border-2x");
                $("#Slt_Users").removeClass("border-warning border-2x");
            });
            $("#Slt_Users").click(aah=> {
                Last_Changed = 3;
                $("#Slt_Preve").removeClass("border-warning border-2x");
                $("#Slt_Proce").removeClass("border-warning border-2x");
                $("#Slt_Confirma").removeClass("border-warning border-2x");
                $("#Slt_Users").addClass("border-warning border-2x");
            });

            $("#btn_Buscar").click(eeh=> {
                switch (Last_Changed) { // Tipo de mensaje
                    case 0:
                        //console.log("nope");
                        break;
                    case 1:
                        Lista_Notificaciones($("#Slt_Preve").val(), 0, 0, $("#Slt_Tipo").val(), $("#Slt_Confirma").val(), $("#Slt_Estado").val());
                        //console.log($("#Slt_Preve").val(), 0, 0, $("#Slt_Confirma").val()), $("#Slt_Estado").val();
                        break;
                    case 2:
                        Lista_Notificaciones(0, $("#Slt_Proce").val(), 0, $("#Slt_Tipo").val(), $("#Slt_Confirma").val(), $("#Slt_Estado").val());
                        //console.log(0, $("#Slt_Proce").val(), 0, $("#Slt_Confirma").val(), $("#Slt_Estado").val());
                        break;
                    case 3:
                        Lista_Notificaciones(0, 0, $("#Slt_Users").val(), $("#Slt_Tipo").val(), $("#Slt_Confirma").val(), $("#Slt_Estado").val());
                        //console.log(0, 0, $("#Slt_Users").val(), $("#Slt_Confirma").val(), $("#Slt_Estado").val());
                        break;
                }
            });
        });
        let Last_Changed = 0;
        let Mx_Ddl_Preve = [{
            "ID_PREVE": "",
            "PREVE_COD": "",
            "PREVE_DESC": "",
            "ID_ESTADO": ""
        }];
        let Mx_Ddl_Proce = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];
        let Mx_Users = [{
            "ID_USUARIO": "",
            "USU_NOMBRE": "",
            "USU_APELLIDO": "",
            "ID_ESTADO": "",
            "USU_NIC": "",
            "ADMIN_DESC": "",
            "USU_ID_PREV": "",
            "USU_ID_PROC": "",
            "PROC_DESC": "",
            "PREVE_DESC": ""
        }];
        let Mx_Dtt = [{
            "TIPO_MSG": "",
            "MSG": "",
            "CONFIRMA": "",
            "FECHA_CONF": "",
            "USU_NOMBRE": "",
            "USU_APELLIDO": "",
            "ID_USUARIO": "",
            "ID_ESTADO": ""
        }];

        function Llenar_Ddl_Preve() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Notificaciones.aspx/Llenar_Ddl_Preve",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ddl_Preve = data.d;
                    Select_Preve();
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Llenar_Ddl_Proce() {
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Notificaciones.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Ddl_Proce = data.d;
                    Select_Proce();
                },
                "error": data => {
                }
            });
        }
        function Llenar_Ddl_Users() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Notificaciones.aspx/Call_Users",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Users = data.d;
                    Select_Users();
                },
                "error": data => {
                    //Debug
                }
            });
        }

        function Select_Preve() {
            Mx_Ddl_Preve.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PREVE
                    }
                ).text(aaa.PREVE_DESC).appendTo("#Slt_Preve");
            });
        }
        function Select_Users() {
            $("<option>",
                    {
                        "value": 0
                    }
                ).text("Todos").appendTo("#Slt_Users");
            Mx_Users.forEach(bbb => {
                $("<option>",
                    {
                        "value": bbb.ID_USUARIO
                    }
                ).text(bbb.USU_NOMBRE + " " + bbb.USU_APELLIDO).appendTo("#Slt_Users");
            });
        }
        function Select_Proce() {
            Mx_Ddl_Proce.forEach(ccc => {
                $("<option>",
                    {
                        "value": ccc.ID_PROCEDENCIA
                    }
                ).text(ccc.PROC_DESC).appendTo("#Slt_Proce");
            });
        }

        function Lista_Notificaciones(_Preve, _Proce, _User, _Tipo, _Confirma, _Estado) {
            var Data_Par = JSON.stringify({
                "ID_PREVE": _Preve,
                "ID_PROCE": _Proce,
                "ID_USUARIO": _User,
                "TIPO": _Tipo,
                "CONFIRMA": _Confirma,
                "ESTADO": _Estado,
            });

            //Debug
            $.ajax({
                "type": "POST",
                "url": "Lista_Notificaciones.aspx/Busca_Lista",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Dtt = data.d;
                    //console.log(Mx_Dtt);
                    if (Mx_Dtt != null) {
                        Fill_DataTable();
                    }
                    else {
                        $("#msg_Datatable tbody").empty();
                        $("#msg_Datatable tbody").append(
                            $("<tr>").append(
                            $("<td>").attr("colspan", 7).text("No se encontraron resultados.").css("font-size", "18px")
                            )
                        );
                    }
                },
                "error": data => {
                    //Debug
                    //console.log("error");
                }
            });
        }
        function Fill_DataTable() {
            $("#msg_Datatable").dataTable().fnDestroy();
            //console.log("Fill Datatable");
            $("#msg_Datatable tbody").empty();
            var i = 1
            Mx_Dtt.forEach(aah => {
                let indexx = i - 1;
                $("<tr>").attr("data-index", i - 1).append(
                    $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                    $("<td>").css("text-align", "left").text(eeh => {
                        switch (aah.TIPO_MSG) { // Tipo de mensaje
                            case 1:
                                return "Cache";
                                break;
                            case 2:
                                return "Sistema";
                                break;
                            case 3:
                                return "Mantención";
                                break;
                            case 4:
                                return "Otros";
                                break;
                        }
                    }),
                    $("<td>").css("text-align", "left").text(aah.MSG),
                    $("<td>").css("text-align", "left").text(aah.USU_NOMBRE + " " + aah.USU_APELLIDO),
                    $("<td>").css("text-align", "center").text(function () {
                        if (aah.CONFIRMA == 0) {
                            return "NO";
                        } else {
                            $(this).css("cssText", "background-color:#aff57a;text-align:center");
                            return "SI";
                        }
                    }),
                    $("<td>").css("text-align", "left").text(ooh=> {
                        if (aah.CONFIRMA != 0) {
                            return moment(aah.FECHA_CONF).format("DD-MM-YYYY hh:mm");
                        }

                    }),
                    $("<td>").css("text-align", "left").text(function () {
                        if (aah.ID_ESTADO == 1) {
                            $(this).css("cssText", "background-color:#e9f57a;");
                            return "Activada";
                        } else {
                            return "Desactivada";
                        }

                    })
                ).appendTo("#msg_Datatable tbody");
                i += 1;

            });

            Notif_Dtt();
        }
        function Notif_Dtt() {
            $("#msg_Datatable").DataTable({
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
    <style>
        .border-2x {
            border: 2px solid #028178 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar">
                <h4 class="m-0 text-center">Lista de Notificaciones</h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <label>Previsión</label>
                        <select class="form-control combobox" id="Slt_Preve">
                        </select>
                    </div>
                    <div class="col-lg">
                        <label>Procedencia</label>
                        <select class="form-control" id="Slt_Proce">
                        </select>
                    </div>
                    <div class="col-lg">
                        <label>Usuario</label>
                        <select class="form-control" id="Slt_Users">
                        </select>
                    </div>
                    <div class="col-lg">
                        <label>Tipo:</label>
                        <select class="form-control" id="Slt_Tipo">
                            <option value="0">Todas</option>
                            <option value="1">Cache</option>
                            <option value="2">Sistema</option>
                            <option value="3">Mantención</option>
                            <option value="4">Otro</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label>Confirmadas:</label>
                        <select class="form-control" id="Slt_Confirma">
                            <option value="2">Todas</option>
                            <option value="1">Si</option>
                            <option value="0">No</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label>Estado:</label>
                        <select class="form-control" id="Slt_Estado">
                            <option value="0">Todas</option>
                            <option value="1">Activada</option>
                            <option value="2">Desactivada</option>
                        </select>
                    </div>
                    <div class="col-lg text-center">
                        <br />
                        <button type="button" class="btn btn-buscar mt-2 btn-block" id="btn_Buscar"><i class="fa fa-search fa-fw"></i>Buscar</button>
                    </div>
                </div>
                <div class="row mt-3">
                    <h5><i class="fa fa-list fa-fw"></i>Lista de Notificaciones</h5>
                </div>
                <div class="row mt-3">
                    <table class="table table-hover table-striped table-iris" id="msg_Datatable" cellspacing="0">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Tipo</th>
                                <th>Mensaje</th>
                                <th>Usuario</th>
                                <th class="text-center">Confirmado</th>
                                <th>Fecha Conf.</th>
                                <th>Estado</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
