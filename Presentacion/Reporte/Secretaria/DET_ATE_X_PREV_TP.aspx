<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="DET_ATE_X_PREV_TP.aspx.vb" Inherits="Presentacion.DET_ATE_X_PREV_TP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />

    <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>
    <%-- Funciones varias --%>
    <script type="text/javascript">
        function jsDecimals(e) {

            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
                    if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Función para las teclas especiales
        //------------------------------------------
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, y Delete
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, y flechas
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest
            return false;
        }

        function addCommas(nStr) {
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + '.' + '$2');
            }
            return x1 + x2;
        }
    </script>

    <%-- Declaración de Eventos --%>
    <script>
        $(document).ready(function () {
            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            $("#Div_Total").empty().css({ "display": "none" });
            $("#Div_Graph").empty().css({ "display": "none" });
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla_Data").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px"
                }).text("Realice su Búsqueda.")

            );

            //Llamar al llenado de los DropDownList
            Ajax_Ddl_Prev();
            //Ajax_Ddl_T_Pago();
            Ajax_Ddl();

            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {

                Ajax_DataTable();

            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });
            $("#E_DESDE").change(function () {
                var desde = $("#E_DESDE").val();

                if (desde == "") {
                    $("#E_DESDE").val(0);
                }

                if ((isNaN(desde) = false) && (desde > 150)) {
                    $("#E_DESDE").val(150);
                }

            });
            $("#E_HASTA").change(function () {
                var hasta = $("#E_HASTA").val();
                if (hasta == "") {
                    $("#E_HASTA").val(0);
                }

                if ((isNaN(hasta) = false) && (hasta > 150)) {
                    $("#E_HASTA").val(150);
                }
            });

        });
    </script>


    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList

        var Mx_Ddl_Previ = [
    {
        "ID_PREVE": 0,
        "PREVE_COD": "asdf",
        "PREVE_DESC": "asdf",
        "ID_ESTADO": 0
    }
        ];

        var Mx_Ddl_T_Pago = [
    {
        "ID_TP_PAGO": 0,
        "TP_PAGO_DESC": "asdf",
        "TP_PAGO_ING": "asdf",
        "ID_ESTADO": 0
    }
        ];

        var Mx_Ddl = [
                {
                    "ID_USUARIO": 0,
                    "USU_NOMBRE": "asdf",
                    "USU_APELLIDO": "asdf",
                    "ID_ESTADO": 0,
                    "PER_USU_DESC": "asdf",
                    "USU_NIC": "asdf"
                }
        ];

        function Ajax_Ddl_Prev() {



            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_PREV_TP.aspx/Llenar_Ddl_Prev",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Previ = JSON.parse(json_receiver);
                        Fill_Ddl_Previ();
                        $(".block_wait").hide();



                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla").empty();
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );




                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";



                }
            });
        }

        function Ajax_Ddl_T_Pago() {



            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_PREV_TP.aspx/Llenar_Ddl_T_Pago",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_T_Pago = JSON.parse(json_receiver);
                        Fill_Ddl_T_Pago();
                        $(".block_wait").hide();



                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla").empty();
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );



                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";



                }
            });
        }
        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_PREV_TP.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Ddl = json_receiver;
                        Fill_Ddl();
                        $(".block_wait").hide();



                    } else {




                    }
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";



                }
            });
        }
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                TOTAL_ATE:"", 
                TOTAL_PREVE:"", 
                TOT_FONASA:"", 
                TOTA_SIS:"", 
                TOTA_USU:"", 
                TOTA_COPA:"", 
                TP_PAGO_DESC:"", 
                ID_TP_PAGO: "",
                PREVE_DESC: "",
                USU_NIC:""

            }
        ];

        function Ajax_DataTable() {

            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#DdlPrevi").val(),
                "USUARIO": $("#DLLUSU").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val())
            });

            $(".block_wait").fadeIn(500);
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_PREV_TP.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla_Data_Totales").empty();

                        Fill_DataTable();
                        $(".block_wait").hide();
                        Hide_Modal();

                    } else {


                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Data_Totales").empty();
                        $("#Div_Tabla_Data").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    $(".block_wait").fadeOut(500);
                    var str_Error = "Error interno del Servidor";
                    Hide_Modal();


                }
            });
        }

        //Generar Excel
        function Ajax_Excel() {

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "ID_PREVE": $("#DdlPrevi").val(),
                "USUARIO": $("#DLLUSU").val(),
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val())
            });

            $(".block_wait").fadeIn(500);
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "DET_ATE_X_PREV_TP.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != "null") {
                        Hide_Modal();
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>";

                        $("#mdlNotif .modal-header h4").text("Archivo Generado");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();



                    } else {
                        Hide_Modal();
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."

                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Error);
                        $("#mdlNotif").modal();



                    }
                },
                "error": function (response) {

                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();



                }
            });
        }
    </script>
    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl_Previ() {
            $("#DdlPrevi").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlPrevi");
            for (y = 0; y < Mx_Ddl_Previ.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_Previ[y].ID_PREVE
                }).text(Mx_Ddl_Previ[y].PREVE_DESC).appendTo("#DdlPrevi");
            }
        };

        function Fill_Ddl_Proce() {

            var procee = Galletas.getGalleta("USU_ID_PROC");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#DdlProce");
                Mx_Ddl_Proce.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                });
            }
            else {
                Mx_Ddl_Proce.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                    }

                });
            }
        }

        function Fill_Ddl_T_Pago() {
            $("#Ddl_T_Pago").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#Ddl_T_Pago");
            for (y = 0; y < Mx_Ddl_T_Pago.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_T_Pago[y].ID_TP_PAGO
                }).text(Mx_Ddl_T_Pago[y].TP_PAGO_DESC).appendTo("#Ddl_T_Pago");
            }
        };
        function Fill_Ddl() {
            $("#DLLUSU").empty();

            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_USUARIO
                }).text(Mx_Ddl[y].USU_NIC + " - " + Mx_Ddl[y].USU_NOMBRE + " " + Mx_Ddl[y].USU_APELLIDO).appendTo("#DLLUSU");
            }
        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );

            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "text-center" }).text("#"),
                    $("<th>", { "class": "text-center" }).text("Forma de Pago"),
                    $("<th>", { "class": "text-center" }).text("Cantidad Atenciones"),
                    $("<th>", { "class": "text-center" }).text("Cantidad Exámenes"),
                    $("<th>", { "class": "text-center" }).text("Total Sistema"),
                    $("<th>", { "class": "text-center" }).text("Total Usuario"),
                    $("<th>", { "class": "text-center" }).text("Total Copago"),
                    $("<th>", { "class": "text-center" }).text("Total Pagado")
                )
            );

            let tot_exa = 0;
            let tot_sis = 0;
            let tot_usu = 0;
            let tot_copa = 0;
            let tot_pag = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TP_PAGO_DESC),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOTAL_ATE),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].TOT_FONASA),
                        $("<td>", { "align": "center" }).text("$" + addCommas(Mx_Dtt[i].TOTA_SIS)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(Mx_Dtt[i].TOTA_USU)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(Mx_Dtt[i].TOTA_COPA)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(Mx_Dtt[i].TOTA_USU + Mx_Dtt[i].TOTA_COPA))
                    )
                );

                tot_exa += Mx_Dtt[i].TOT_FONASA;
                tot_sis += Mx_Dtt[i].TOTA_SIS;
                tot_usu += Mx_Dtt[i].TOTA_USU;
                tot_copa += Mx_Dtt[i].TOTA_COPA;
                tot_pag += Mx_Dtt[i].TOTA_USU + Mx_Dtt[i].TOTA_COPA;
                
            }

            $("<table>", {
                "id": "DataTable_Totales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Data_Totales");

            $("#DataTable_Totales").append(
                $("<thead>"),
                $("<tbody>")
            );

            $("#DataTable_Totales thead").append(
                $("<tr>").append(
                    $("<th>", { align: "center", colspan: 2 }).text(""),
                    $("<th>", { "class": "text-center" }).text("Exámenes"),
                    $("<th>", { "class": "text-center" }).text("Total Sistema"),
                    $("<th>", { "class": "text-center" }).text("Total Usuario"),
                    $("<th>", { "class": "text-center" }).text("Total Copago"),
                    $("<th>", { "class": "text-center" }).text("Total Pagado")
                )
            );

                $("#DataTable_Totales tbody").append(
                    $("<tr>").append(
                        $("<td>", { align: "center", colspan: 2 }).text(""),
                        $("<td>", { "align": "center" }).text(tot_exa),
                        $("<td>", { "align": "center" }).text("$" + addCommas(tot_sis)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(tot_usu)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(tot_copa)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(tot_pag))
                    )
                );

            //$("#DataTable").DataTable({
            //    "bSort": false,
            //    "iDisplayLength": 25,
            //    "language": {
            //        "DisplayLength": 100,
            //        "lengthMenu": "Mostrar: _MENU_",
            //        "zeroRecords": "No hay concidencias",
            //        "info": "Mostrando Página _PAGE_ de _PAGES_",
            //        "infoEmpty": "No hay concidencias",
            //        "infoFiltered": "(Se busco en _MAX_ registros )",
            //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
            //        "paginate": {
            //            "previous": "Anterior",
            //            "next": "Siguiente"
            //        }
            //    }
            //});
            Hide_Modal();
        }
    </script>

    <%-- Datepickers --%>
    <script>
        $(document).ready(function () {
            var Date_Now = function () {
                //Obtener valores
                var obj_date = new Date();
                var dd = parseInt(obj_date.getDate());
                var mm = parseInt(obj_date.getMonth()) + 1;
                var yy = parseInt(obj_date.getFullYear());

                if (dd < 10) { dd = "0" + dd; }
                if (mm < 10) { mm = "0" + mm; }

                return String(dd + "/" + mm + "/" + yy);
            };

            $('#fecha1').datetimepicker(
               {
                   debug: true,
                   icons: {
                       previous: 'fa fa-arrow-left',
                       next: 'fa fa-arrow-right'
                   },
                   format: 'dd-mm-yyyy',
                   language: 'es',
                   weekStart: 1,
                   autoclose: true,
                   minDate: Date.now(),
                   minView: 2
               }
           );
            $('#fecha2').datetimepicker(
               {
                   debug: true,
                   icons: {
                       previous: 'fa fa-arrow-left',
                       next: 'fa fa-arrow-right'
                   },
                   format: 'dd-mm-yyyy',
                   language: 'es',
                   weekStart: 1,
                   autoclose: true,
                   minDate: Date.now(),
                   minView: 2
               }
           );
            var dateNow = moment().format("DD-MM-YYYY");
            $("#fecha1 input").val(dateNow);
            $("#fecha2 input").val(dateNow);

            //$("#TxtDate_01").val(Date_Now);
            //$("#TxtDate_02").val(Date_Now);
        });
    </script>


    <%-- CSS Personalizado --%>
    <style>
        #DataTable thead, #Table_T thead {
            background-color: #28a745;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">

    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Resumen de Atenciones por Previsión</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-2">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha1'>
                        <input type='text' id="TxtDate_01" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-2">
                    <label for="fecha">Hasta:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-1">

                </div>
                <div class="col-lg-4">
                    <label for="DLLUSU">Usuario:</label>
                    <select id="DLLUSU" class="form-control"></select>
                </div>
                <div class="col-lg-3">
                    <label for="DdlPrevi">Prevision:</label>
                    <select id="DdlPrevi" class="form-control"></select>
                </div>
<%--                <div class="col-lg">
                    <label for="Ddl_T_Pago">Forma de Pago:</label>
                    <select id="Ddl_T_Pago" class="form-control"></select>
                </div>--%>
            </div>
            <div class="row">
                <div class="col-lg">
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
                <div class="col-lg">
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                </div>
            </div>
        </div>
    </div>
    <div class="card p-3 border-bar">
        <div class="row">
            <div class="col-lg-12">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Listado de Atenciones</h5>
                        <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris" style="overflow:auto"></div>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_Data_Totales" class="table table-hover table-striped table-iris" style="overflow:auto"></div>
                    </div>
                </div>
                <%--  <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_02" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>--%>
            </div>

        </div>
        <%--<div class="row">
            <div class="col-lg-12">
                <h5>Gráfico</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>--%>
    </div>
</asp:Content>


