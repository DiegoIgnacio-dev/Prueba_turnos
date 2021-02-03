<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Det_Proc_Prev_Prog_Scr_3.aspx.vb" Inherits="Presentacion.Det_Proc_Prev_Prog_Scr_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../../../js/HighCharts.js"></script>
    <script src="../../../js/highcharts-more.js"></script>
    <script src="../../../js/HighC_Exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _desde, _hasta, _proc, _prev, _prog;
        $(document).ready(() => {
            _desde = getParameterByName("D");
            _hasta = getParameterByName("H");
            _proc = getParameterByName("P1");
            _prev = getParameterByName("P2");
            _prog = getParameterByName("P3");
            modal_show();
            Ajax_DataTable();

            //$("#_desde").text(_prog);
            $("#_hasta").text(_hasta);

            $("#btn_Excel").click(() => {
                Ajax_Excel();
            });
            $("#btn_Pdf").click(() => {
                Ajax_PDF();
            });
        });
        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function Ajax_ONCLICK_2(ID_USU, ID_ATE) {
            var loc = location.origin;
            window.open(loc + "/Scan_Docs/Ver_Orden.aspx?IDU=" + ID_USU + "&IDA=" + ID_ATE);
        }

        let Mx_Dtt = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TP_PAGO_DESC: "",
            ID_ATENCION: "",
            ID_USUARIO:""
        }];
        function Ajax_DataTable() {
            let Data_Par = JSON.stringify({
                "PROG": _prog
            });
            //console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Det_Proc_Prev_Prog_Scr_3.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#_desde").text(Mx_Dtt[0].ATE_NUM);
                        //$("#_proc").text(Mx_Dtt[0].PROC_DESC);
                        //$("#_prev").text(Mx_Dtt[0].PREVE_DESC);
                        //$("#_prog").text(Mx_Dtt[0].PROGRA_DESC);

                        Fill_DataTable();
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
        function Fill_DataTable() {
            $("#Div_Tabla").empty();

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Pago"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido" }).text("Total"),
                    $("<th>", { "class": "textoReducido" }, { "text-align": "right" }, { "align": "right" }).text("Documentos")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(() => {
                            return moment(Mx_Dtt[i].ATE_FECHA).format("DD-MM-YYYY HH:mm");
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TP_PAGO_DESC),
                        $("<td>", { "align": "right" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PREVI)),
                        $("<td>", { "align": "right" }, { "class": "textoReducido" }).text(function () {
                            $(this).append("<button type='button' class='btn btn-info btn-sm' onclick='Ajax_ONCLICK_2(" + Mx_Dtt[i].ID_USUARIO + "," + Mx_Dtt[i].ID_ATENCION + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver</button>");
                        })
                    )
                );
            }

            let at_tott = [];
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    at_tott.push(Mx_Dtt[i].ATE_NUM);
                }
                else {
                    let cnt_at = 0;
                    for (x = 0; x < at_tott.length; x++) {
                        if (at_tott[x] == Mx_Dtt[i].ATE_NUM) {
                            cnt_at = 1;
                        }
                    }
                    if (cnt_at == 0) {
                        at_tott.push(Mx_Dtt[i].ATE_NUM);
                    }
                }
            }
            $("#tot_at").text(at_tott.length);
            $("#tot_cf").text(Mx_Dtt.length);
            $("#DataTable").DataTable({
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
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
            $("#a-right").css("text-align", "right");

            do_Chart_2();
            do_Chart_1();
            Hide_Modal();
        }
        function do_Chart_2() {

            let Mx_Cant = [];
            let Mx_Series = [];

            for (i = 0; i < Mx_Dtt.length; i++) {
                if (Mx_Cant.length == 0) {
                    Mx_Cant.push({ CF_DESC: Mx_Dtt[i].CF_DESC, CANT: "" });
                } else {
                    let bool = 0;

                    Mx_Cant.forEach(aah=> {
                        if (aah.CF_DESC == Mx_Dtt[i].CF_DESC) {
                            bool = 1;
                        }
                    });

                    if (bool == 0) {
                        Mx_Cant.push({ CF_DESC: Mx_Dtt[i].CF_DESC, CANT: "" });
                    }
                }
            }

            for (y = 0; y < Mx_Cant.length; y++) {
                let cont = 0;
                Mx_Dtt.forEach(aah=> {
                    if (Mx_Cant[y].CF_DESC == aah.CF_DESC) {
                        cont += 1;
                    }
                });
                Mx_Cant[y].CANT = cont;
            }

            Mx_Series.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            for (x = 0; x < Mx_Cant.length; x++) {
                Mx_Series[0].data.push({
                    name: Mx_Cant[x].CF_DESC,
                    y: Mx_Cant[x].CANT
                });
            }

            //console.log(Mx_Series);

            Highcharts.chart('chrt_2', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '40%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Cantidad de Exámenes'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series
            });
        }
        function do_Chart_1() {

            let Mx_Tot = [];
            let Mx_Data = [];
            let Mx_Cate = [];
            let Cant_Tot = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                if (Mx_Tot.length == 0) {
                    Mx_Tot.push({ CF_DESC: Mx_Dtt[i].CF_DESC, CANT: "" });
                } else {
                    let bool = 0;

                    Mx_Tot.forEach(aah=> {
                        if (aah.CF_DESC == Mx_Dtt[i].CF_DESC) {
                            bool = 1;
                        }
                    });

                    if (bool == 0) {
                        Mx_Tot.push({ CF_DESC: Mx_Dtt[i].CF_DESC, CANT: "" });
                    }
                }
            }

            for (y = 0; y < Mx_Tot.length; y++) {
                let cont = 0;
                Mx_Dtt.forEach(aah=> {
                    if (Mx_Tot[y].CF_DESC == aah.CF_DESC) {
                        cont += parseInt(aah.ATE_DET_V_PREVI);
                    }
                });
                Mx_Tot[y].CANT = cont;
            }

            //console.log(Mx_Tot);

            Mx_Tot.forEach(aah=> {
                Mx_Data.push(aah.CANT);
                Mx_Cate.push(aah.CF_DESC);
            });

            Mx_Data.forEach(aah=> {
                Cant_Tot += aah;
            });

            Cant_Tot = addCommas(Cant_Tot);
            $("#val_total").text(Cant_Tot);
            Highcharts.setOptions({
                lang: {
                    thousandsSep: '.'
                }
            })

            Highcharts.chart('chrt_1', {
                chart: {
                    type: 'column',
                    height: '50%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Valorización de Exámenes',
                    margin: 50
                },
                subtitle: {
                    text: 'Total: $' + Cant_Tot,
                    style: {
                        color: '#ff0000',
                        fontWeight: 'bold'
                    }
                },
                xAxis: {
                    categories: Mx_Cate,
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Total (CLP)'
                    },
                    stackLabels: {
                        enabled: true,
                        format: '${total:,.0f}'
                    },
                    labels: {
                        format: "${value:,.0f}"
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr>' +
                        '<td style="padding:0"><b>${point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    series: {
                        colorByPoint: true,
                        dataLabels: {
                            enabled: true,
                            format: '${point.y:,.0f}',
                            rotation: -90,
                            y: -40,
                            color: "#666666",
                            crop: false
                        }
                    },
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    showInLegend: false,
                    name: '',
                    data: Mx_Data
                }]
            });
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

        function Ajax_Excel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "PROG": _prog
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Det_Proc_Prev_Prog_Scr_3.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Hide_Modal();
                        window.open(json_receiver, 'Download');
                    } else {
                        Hide_Modal();
                        console.log(response);
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    console.log(response);
                }
            });
        }

        var Mx_Dtt_PDF = [
{
    "urls": ""
}
        ];

        function Ajax_PDF() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": _desde,
                "HASTA": _hasta,
                "PROC": _proc,
                "PREV": _prev,
                "PROG": _prog,
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Det_Proc_Prev_Prog_Scr_3.aspx/PDFF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo PDF. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
    </script>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Detalle Folio: <span id="_desde"></span></h4>
        </div>
        <div class="card-body">
            <div class="row mb-2 pl-3 pr-3">
                <div class="col-lg">
                    <h4 class="text-danger">Valorización: $<span id="val_total"></span></h4>
                </div>
                <div class="col-lg">
                    <h4> Total de Exámenes: <span id="tot_cf"></span> </h4>
                </div>
    <%--            <div class="col-lg-1">
                    <button type="button" id="btn_Pdf" class="btn btn-warning btn-block btn-sm mt-0"><i class="fa fa-file-text-o fa-fw"></i>PDF</button>
                </div>--%>
                <div class="col-lg-1">
                    <button type="button" id="btn_Excel" class="btn btn-success btn-block btn-sm mt-0"><i class="fa fa-file-excel-o fa-fw"></i>Excel</button>
                </div>
            </div>
            <div id="Div_Tabla" style="max-height: 70vh; overflow: auto">
            </div>
        </div>
    </div>

    <div class="card border-bar mt-3">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Gráficos</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <div id="chrt_1"></div>
                </div>
            </div>
            <hr />
            <div class="row mt-3">
                <div class="col-lg">
                    <div id="chrt_2"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
