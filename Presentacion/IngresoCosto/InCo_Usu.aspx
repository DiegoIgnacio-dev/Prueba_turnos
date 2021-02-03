<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="InCo_Usu.aspx.vb" Inherits="Presentacion.InCo_Usu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(() => {

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);

            $('#Txt_Date01, #Txt_Date02').datetimepicker(
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
            Llenar_Ddl_Usu();

            $("#btn_Buscar").click(() => {
                Ajax_Datatable();
            });
            $("#btn_Excel").click(() => {
                Ajax_Excel();
            });
        });

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

        var Mx_Ddl_Usu = [{
            "ID_USUARIO": "",
            "USU_NOMBRE": "",
            "USU_APELLIDO": "",
            "ID_ESTADO": ""
        }];
        function Llenar_Ddl_Usu() {
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "InCo_Usu.aspx/Llenar_Ddl_Usu",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_Usu = data.d;

                    Fill_Ddl_Usu();
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Fill_Ddl_Usu() {
            var procee = Galletas.getGalleta("USU_ID_PROC");
            //var procee = 0;

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Slt_Usu");
            Mx_Ddl_Usu.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_USUARIO
                    }
                ).text(aaa.USU_NOMBRE+" "+aaa.USU_APELLIDO).appendTo("#Slt_Usu");
            });
        }

        var Mx_Dtt = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "PROC_DESC": "",
            "PREVE_DESC": "",
            "DOC_NOMBRE": "",
            "DOC_APELLIDO": "",
            "CF_DESC": "",
            "CF_COD": "",
            "ATE_DET_V_PREVI": "",
            "ATE_DET_V_PAGADO": "",
            "ATE_DET_V_COPAGO": "",
            "CONTROL_COSTO_PRECIO": "",
            "USU_NOMBRE": "",
            "USU_APELLIDO": ""
        }];
        function Ajax_Datatable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "ID_USUARIO": $("#Slt_Usu").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "InCo_Usu.aspx/IRIS_WEBF_BUSCA_LIS_ADM_TECMED",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Dtt = data.d;

                    if (Mx_Dtt == null) {
                        Hide_Modal();
                        $("#div_Dtt").empty();
                        $("#div_Dtt").html("<h3 class='text-center'>Sin Resultados</h3>");
                    } else {
                        $("#div_Dtt").empty();
                        Fill_Dtt();
                    }
                },
                "error": data => {
                    Hide_Modal();
                    $("#div_Dtt").empty();
                    $("#div_Dtt").html("<h3 class='text-center'>Sin Resultados</h3>");
                    //Debug
                }
            });
        }
        function Fill_Dtt() {

            $("#div_Dtt").html("<h5 class='text-center'><i class='fa fa-list fa-fw'></i>Listado de Ingreso vs Costos</h5><h5 class='text-danger mt-3 ml-3' id='h_Total'></h5>");

            $("<table>", {
                "id": "DataTable",
                "class": "w-100 table table-hover table-striped table-iris",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#div_Dtt");
            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").text("#"),
                    $("<th>").text("Folio"),
                    $("<th>").text("Usuario"),
                    $("<th>").text("Fecha"),
                    $("<th>").text("Procedencia"),
                    $("<th>").text("Código"),
                    $("<th>").text("Examen"),
                    $("<th>", { "class": "text-right" }).text("Valor Sistema"),
                    $("<th>", { "class": "text-right" }).text("Valor Usuario"),
                    $("<th>", { "class": "text-right" }).text("Valor Copago"),
                    $("<th>", { "class": "text-right" }).text("Valor Pagado"),
                    $("<th>", { "class": "text-right" }).text("Costo")
                )
            );
            let i = 0;
            let tot_Previ = 0;
            let tot_Pagado = 0;
            let tot_Copago = 0;
            let tot_Costo = 0;
            Mx_Dtt.forEach(aah=> {
                $("<tr>", {
                    //"onclick": `Ajax_Redirect("` + i + `")`,
                    "class": "manito"
                }).attr("data-id", aah.ID_ATENCION).append(
                    $("<td>").text(i + 1),
                    $("<td>").text(aah.ATE_NUM),
                    $("<td>").text(aah.USU_NOMBRE+" "+aah.USU_APELLIDO),
                    $("<td>").text(moment(aah.ATE_FECHA).format("DD-MM-YYYY HH:mm:ss")),
                    $("<td>").text(aah.PROC_DESC),
                    $("<td>").text(aah.CF_COD),
                    $("<td>").text(aah.CF_DESC),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.ATE_DET_V_PREVI)),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.ATE_DET_V_PAGADO)),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.ATE_DET_V_COPAGO)),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.ATE_DET_V_PAGADO)),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.CONTROL_COSTO_PRECIO))

                ).appendTo("#DataTable tbody");

                tot_Previ += aah.ATE_DET_V_PREVI;
                tot_Pagado += aah.ATE_DET_V_PAGADO;
                tot_Copago += aah.ATE_DET_V_COPAGO;
                tot_Costo += aah.CONTROL_COSTO_PRECIO;
                i += 1;
            });

            $("#h_Total").text("Total Sistema: $" + addCommas(tot_Previ) + " | Total Usuario: $" + addCommas(tot_Pagado) + " | Total Copago: $" + addCommas(tot_Copago) + " | Total Pagado: $" + addCommas(tot_Pagado) + " | Total Costo: $" + addCommas(tot_Costo));

            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 50,
                "info": false,
                //"bPaginate": false,
                //"bFilter": false,
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
            Hide_Modal();
        }

        function Ajax_Excel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "ID_USUARIO": $("#Slt_Usu").val(),
                "USU_NOM": $("#Slt_Usu option:selected").text()
            });

            //$(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "InCo_Usu.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    $(".block_wait").fadeOut(500);

                    if (json_receiver != null) {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h5 class="m-1">Ingreso vs Costos por Usuario
            </h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha2">Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="Slt_Usu">Usuario:</label>
                    <select id="Slt_Usu" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <br />
                    <button type="button" class="btn btn-buscar btn-block mt-2" id="btn_Buscar"><i class="fa fa-search fa-fw"></i>Buscar</button>
                </div>
                <div class="col-lg">
                    <br />
                    <button type="button" class="btn btn-success btn-block mt-2" id="btn_Excel"><i class="fa fa-file-excel-o fa-fw"></i>Excel</button>
                </div>
            </div>
        </div>
    </div>

    <div id="div_Dtt" class="mt-3"></div>


</asp:Content>
