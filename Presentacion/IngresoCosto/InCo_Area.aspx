<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="InCo_Area.aspx.vb" Inherits="Presentacion.InCo_Area" %>

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
            Llenar_Ddl_Area();

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

        var Mx_Ddl_Area = [{
            "ID_AREA": "",
            "AREA_COD": "",
            "AREA_DESC": "",
            "ID_ESTADO": ""
        }];
        function Llenar_Ddl_Area() {
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "InCo_Area.aspx/Llenar_Ddl_Area",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_Area = data.d;

                    Fill_Ddl_Area();
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Fill_Ddl_Area() {
            var procee = Galletas.getGalleta("USU_ID_PROC");
            //var procee = 0;

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Slt_Area");
            Mx_Ddl_Area.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_AREA
                    }
                ).text(aaa.AREA_DESC).appendTo("#Slt_Area");
            });
        }

        var Mx_Dtt = [{
            "TOT_FONASA": "",
            "TOT_SIS": "",
            "TOT_COPA": "",
            "CF_DESC": "",
            "RLS_LS_DESC": "",
            "AREA_DESC": "",
            "CF_COD": "",
            "CF_DESC": "",
            "CF_COD": "",
            "CONTROL_COSTO_PRECIO": ""
        }];
        function Ajax_Datatable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "ID_AREA": $("#Slt_Area").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "InCo_Area.aspx/IRIS_WEBF_BUSCA_LIS_ADM_AREA",
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
                    $("<th>").text("Código"),
                    $("<th>").text("Area"),
                    $("<th>").text("Examen"),
                    $("<th>", { "class": "text-right" }).text("Cantidad"),
                    $("<th>", { "class": "text-right" }).text("Costo Unit."),
                    $("<th>", { "class": "text-right" }).text("Total Costo")
                )
            );
            let i = 0;
            let tot_Cant = 0;
            let tot_Unit = 0;
            let tot_Costo = 0;
            Mx_Dtt.forEach(aah=> {
                $("<tr>", {
                    //"onclick": `Ajax_Redirect("` + i + `")`,
                    "class": "manito"
                }).attr("data-id", aah.ID_ATENCION).append(
                    $("<td>").text(i + 1),
                    $("<td>").text(aah.CF_COD),
                    $("<td>").text(aah.AREA_DESC),
                    $("<td>").text(aah.CF_DESC),
                    $("<td>", { "class": "text-right" }).text(addCommas(aah.TOT_FONASA)),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.CONTROL_COSTO_PRECIO)),
                    $("<td>", { "class": "text-right" }).text("$" + addCommas(aah.TOT_FONASA * aah.CONTROL_COSTO_PRECIO))

                ).appendTo("#DataTable tbody");

                tot_Cant += aah.TOT_FONASA;
                tot_Unit += aah.CONTROL_COSTO_PRECIO;
                tot_Costo += (aah.TOT_FONASA * aah.CONTROL_COSTO_PRECIO);
                i += 1;
            });

            $("#h_Total").text("Total Cantidad: " + addCommas(tot_Cant) + " | Total Unidad: $" + addCommas(tot_Unit) + " | Total Costo: $" + addCommas(tot_Costo));

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
                "ID_AREA": $("#Slt_Area").val(),
                "AREA_DESC": $("#Slt_Area option:selected").text()
            });

            //$(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "InCo_Area.aspx/Gen_Excel",
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
            <h5 class="m-1">Ingreso vs Costos por Area
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
                    <label for="Slt_Area">Area:</label>
                    <select id="Slt_Area" class="form-control"></select>
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
