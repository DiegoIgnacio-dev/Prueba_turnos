<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Resumen_Prev_Prog_Subp_Scr.aspx.vb" Inherits="Presentacion.Resumen_Prev_Prog_Subp_Scr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../../../js/HighCharts.js"></script>
    <script src="../../../js/highcharts-more.js"></script>
    <script src="../../../js/modules/sunburst.js"></script>
    <script src="../../../js/HighC_Exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _cont_mod = 0;
        $(document).ready(() => {
            // modal_show();
            let dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);
            $('#Txt_Date01, #Txt_Date02').datetimepicker({
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
            });

            Ajax_LugarTM();
            Ajax_Preve();
            //Ajax_Progra();

            $("#Ddl_Preve").change(()=>{
                Ajax_Usu();
            });

            $("#btn_Buscar").click(() => {
                Ajax_DataTable();
            });
            $("#btn_Excel").click(() => {
                Ajax_Excel();
            });
            $("#btn_Pdf").click(() => {
                Ajax_PDF();
            });
        });

        function c_modal() {
            if (_cont_mod == 3) {
                Hide_Modal();
            }
        }

        let Mx_Dtt_LugarTM = [{
            "ID_ESTADO": 0,
            "PROC_DESC": 0,
            "PROC_COD": 0,
            "ID_PROCEDENCIA": 0
        }];
        function Ajax_LugarTM() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_LugarTM = json_receiver;
                        Fill_Ddl_LugarTM();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();



            var procee = Galletas.getGalleta("USU_ID_PROC");

            if (procee == 0) {
                //$("<option>",
                //{
                //    "value": "0"
                //}
                //).text("Todos").appendTo("#Ddl_LugarTM");
                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Dtt_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }

                });
            }

            //$("<option>",
            //{
            //    "value": "0"
            //}
            //).text("Todos").appendTo("#Ddl_LugarTM");
            //Mx_Dtt_LugarTM.forEach(aaa => {
            //    $("<option>",
            //        {
            //            "value": aaa.ID_PROCEDENCIA
            //        }
            //    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
            //});
            _cont_mod += 1;
            c_modal();
        };

        let Mx_Dtt_Preve = [{
            "ID_ESTADO": 0,
            "PREVE_DESC": 0,
            "PREVE_COD": 0,
            "ID_PREVE": 0
        }];
        function Ajax_Preve() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/Llenar_Ddl_Prevision",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Preve = json_receiver;
                        Fill_Ddl_Preve();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }
        function Fill_Ddl_Preve() {
            $("#Ddl_Preve").empty();


            var preveee = Galletas.getGalleta("USU_PREV");

            if (preveee == 0) {
                //$("<option>",
                //{
                //    "value": "0"
                //}
                //).text("Todos").appendTo("#Ddl_Preve");
                Mx_Dtt_Preve.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PREVE
                        }
                    ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
                });
            }
            else {
                Mx_Dtt_Preve.forEach(aaa => {
                    if (aaa.ID_PREVE == preveee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PREVE
                          }
                       ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
                    }

                });
            }

            //$("<option>",
            //{
            //    "value": "0"
            //}
            //).text("Todos").appendTo("#Ddl_Preve");
            //Mx_Dtt_Preve.forEach(aaa => {
            //    $("<option>",
            //        {
            //            "value": aaa.ID_PREVE
            //        }
            //    ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
            //});
            _cont_mod += 1;
            c_modal();
            Ajax_Usu();
        };

        let Mx_Dtt_Usu = [{
            "ID_USUARIO": 0,
            "USU_NOMBRE": 0,
            "USU_APELLIDO": 0,
            "USU_NIC": 0
        }];



        function Ajax_Usu() {

            let Data_Par = JSON.stringify({
                "ID_USER": $("#Ddl_Preve").val()//$("#fecha").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/Call_User_Data",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Usu = json_receiver;
                        Fill_Ddl_Usu();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }

        let Mx_Dtt_Progra = [{
            "ID_ESTADO": 0,
            "PROGRA_DESC": 0,
            "PROGRA_COD": 0,
            "ID_PROGRA": 0
        }];
        function Ajax_Progra() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/Llenar_Ddl_Programa",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Progra = json_receiver;
                        Fill_Ddl_Progra();
                    } else {
                        console.log(response);
                    }
                },
                "error": function (response) {
                    console.log(response);
                }
            });
        }
        function Fill_Ddl_Progra() {
            $("#Ddl_Progra").empty();

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Ddl_Progra");
            Mx_Dtt_Progra.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PROGRA
                    }
                ).text(aaa.PROGRA_DESC).appendTo("#Ddl_Progra");
            });
            _cont_mod += 1;
            c_modal();
        };

        function Fill_Ddl_Usu() {
            $("#Ddl_Usu").empty();

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Ddl_Usu");
            Mx_Dtt_Usu.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_USUARIO
                    }
                ).text(aaa.USU_NIC + " " + aaa.USU_NOMBRE + " " + aaa.USU_APELLIDO).appendTo("#Ddl_Usu");
            });
        };

        let Mx_Dtt = [{
            ID_PROCEDENCIA: "",
            PROC_DESC: "",
            ID_PREVE: "",
            PREVE_DESC: "",
            ID_PROGRA: "",
            PROGRA_DESC: "",
            TOT_ATE: "",
            TOT_CF: "",
            TOT_VAL: "",
            SUB_PROGRA_DESC: "",
            USU_NIC: "",
            ID_USUARIO:""
        }];
        function Ajax_DataTable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "PREV": $("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val(),
                "ID_USER": $("#Ddl_Usu").val()
            });
            //console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        Fill_DataTable();
                        $("#graph").show();
                    } else {
                        console.log(response);
                        $("#Div_Tabla").empty();
                        $("#graph").hide();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    $("#Div_Tabla").empty();
                    $("#graph").hide();
                    Hide_Modal();
                }
            });
        }
        function Fill_DataTable() {
            $("#Div_Tabla").empty();

            $("#Div_Tabla").html("<div class='row'><div class='col-lg'><h4 class='text-danger pl-3'>Valorización Total: $<span id='val_total'></span></h4></div><div class='col-lg'><h4>Atenciones: <span id='tot_at'></span> - Exámenes Validados: <span id='tot_cf'></span> </h4></div></div>");

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
                    $("<th>", { "class": "textoReducido" }).text("Procedencia"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    //$("<th>", { "class": "textoReducido" }).text("Programa"),
                    //$("<th>", { "class": "textoReducido" }).text("SubPrograma"),
                    $("<th>", { "class": "textoReducido" }).text("Total Atenciones"),
                    $("<th>", { "class": "textoReducido" }).text("Total Exámenes"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido " }).text("Total Valor")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_PROCEDENCIA + `","` + Mx_Dtt[i].ID_PREVE + `","` + Mx_Dtt[i].ID_USUARIO + `",)`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NIC),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROGRA_DESC),
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].SUB_PROGRA_DESC.toUpperCase()),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TOT_ATE),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TOT_CF),
                        $("<td>", { "align": "right" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].TOT_VAL))
                    )
                );
            }
            $("#DataTable").DataTable({
                "bSort": false,
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
            //do_chart();

            $("#a-right").css("text-align", "right");
            let _v_total = 0;
            let t_att = 0;
            let t_exx = 0;
            Mx_Dtt.forEach(aah=> {
                _v_total += aah.TOT_VAL;
                t_att += aah.TOT_ATE;
                t_exx += aah.TOT_CF;
            });
            $("#val_total").text(addCommas(_v_total));
            $("#tot_at").text(t_att);
            $("#tot_cf").text(t_exx);
            


            Hide_Modal();

        }

        function Ajax_ONCLICK(_PROC, _PREV, _PROG) {
            var loc = location.origin;
            window.open(loc + "/Gest_Financ/Estadisticas/Detalle/Det_Proc_Prev_Prog_Scr.aspx?D=" + $("#fecha").val() + "&H=" + $("#fecha2").val() + "&P1=" + _PROC + "&P2=" + _PREV + "&P3=" + _PROG);
        }

        function do_chart() {
            Mx_Orden = [];
            Mx_Orden2 = [];
            Mx_Orden3 = [];

            let last_proc = [];
            let cont_proc = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    cont_proc += 1;
                    last_proc.push(Mx_Dtt[i].PROC_DESC);
                    Mx_Orden.push({ PROC_DESC: Mx_Dtt[i].PROC_DESC, ID: "1." + cont_proc, ID_P: "0.0" });
                } else {
                    let _v = 0;
                    last_proc.forEach(aah=> {
                        if (aah == Mx_Dtt[i].PROC_DESC) {
                            _v = 1;
                        }
                    });
                    if (_v == 0) {
                        cont_proc += 1;
                        last_proc.push(Mx_Dtt[i].PROC_DESC);
                        Mx_Orden.push({ PROC_DESC: Mx_Dtt[i].PROC_DESC, ID: "1." + cont_proc, ID_P: "0.0" });
                    }
                }
            }

            //console.log(Mx_Orden);

            let last_prev = [];
            let cont_prev = 0;

            for (i = 0; i < Mx_Orden.length; i++) {
                for (x = 0; x < Mx_Dtt.length; x++) {
                    if (Mx_Orden[i].PROC_DESC == Mx_Dtt[x].PROC_DESC) {
                        if (cont_prev == 0) {
                            cont_prev += 1;
                            last_prev.push({ PROC_DESC: Mx_Orden[i].PROC_DESC, PREVE_DESC: Mx_Dtt[x].PREVE_DESC });
                            Mx_Orden2.push({ PROC_DESC: Mx_Dtt[x].PROC_DESC, PREVE_DESC: Mx_Dtt[x].PREVE_DESC, ID: "2." + cont_prev, ID_P: Mx_Orden[i].ID });
                        } else {
                            let _v = 0;
                            last_prev.forEach(aah=> {
                                if (aah.PROC_DESC == Mx_Dtt[x].PROC_DESC && aah.PREVE_DESC == Mx_Dtt[x].PREVE_DESC) {
                                    _v = 1;
                                }
                            });
                            if (_v == 0) {
                                cont_prev_proc = 1;
                                cont_prev += 1;
                                last_prev.push({ PROC_DESC: Mx_Orden[i].PROC_DESC, PREVE_DESC: Mx_Dtt[x].PREVE_DESC });
                                Mx_Orden2.push({ PROC_DESC: Mx_Dtt[x].PROC_DESC, PREVE_DESC: Mx_Dtt[x].PREVE_DESC, ID: "2." + cont_prev, ID_P: Mx_Orden[i].ID });
                            }
                        }
                    }
                }
            }

            //console.log(Mx_Orden2);

            let last_prog = [];
            let cont_prog = 0;

            for (i = 0; i < Mx_Orden2.length; i++) {
                for (x = 0; x < Mx_Dtt.length; x++) {
                    if (Mx_Orden2[i].PROC_DESC == Mx_Dtt[x].PROC_DESC && Mx_Orden2[i].PREVE_DESC == Mx_Dtt[x].PREVE_DESC) {
                        if (cont_prog == 0) {
                            cont_prog += 1;
                            last_prog.push({ PROC_DESC: Mx_Orden2[i].PROC_DESC, PREVE_DESC: Mx_Orden2[i].PREVE_DESC, PROGRA_DESC: Mx_Dtt[x].PROGRA_DESC });
                            Mx_Orden3.push({ PROC_DESC: Mx_Dtt[x].PROC_DESC, PREVE_DESC: Mx_Dtt[x].PREVE_DESC, PROGRA_DESC: Mx_Dtt[x].PROGRA_DESC, ID: "3." + cont_prog, ID_P: Mx_Orden2[i].ID, TOT_VAL: Mx_Dtt[x].TOT_VAL });
                        } else {
                            let _v = 0;
                            last_prog.forEach(aah=> {
                                if (aah.PROC_DESC == Mx_Dtt[x].PROC_DESC && aah.PREVE_DESC == Mx_Dtt[x].PREVE_DESC && aah.PROGRA_DESC == Mx_Dtt[x].PROGRA_DESC) {
                                    _v = 1;
                                }
                            });
                            if (_v == 0) {
                                cont_prog += 1;
                                last_prog.push({ PROC_DESC: Mx_Orden2[i].PROC_DESC, PREVE_DESC: Mx_Orden2[i].PREVE_DESC, PROGRA_DESC: Mx_Dtt[x].PROGRA_DESC });
                                Mx_Orden3.push({ PROC_DESC: Mx_Dtt[x].PROC_DESC, PREVE_DESC: Mx_Dtt[x].PREVE_DESC, PROGRA_DESC: Mx_Dtt[x].PROGRA_DESC, ID: "3." + cont_prog, ID_P: Mx_Orden2[i].ID, TOT_VAL: Mx_Dtt[x].TOT_VAL });
                            }
                        }
                    }
                }
            }

            //console.log(Mx_Orden3);
            let data = [];

            data.push({
                id: '0.0',
                parent: '',
                name: 'TOTAL'
            });

            Mx_Orden.forEach(aah=> {
                data.push({
                    id: aah.ID,
                    parent: aah.ID_P,
                    name: aah.PROC_DESC
                });
            });

            Mx_Orden2.forEach(aah=> {
                data.push({
                    id: aah.ID,
                    parent: aah.ID_P,
                    name: aah.PREVE_DESC
                });
            });

            Mx_Orden3.forEach(aah=> {
                data.push({
                    id: aah.ID,
                    parent: aah.ID_P,
                    name: aah.PROGRA_DESC.replace("<", "").replace(">", ""),
                    value: parseInt(aah.TOT_VAL)
                });
            });


            // Splice in transparent for the center circle
            Highcharts.getOptions().colors.splice(0, 0, 'transparent');

            Highcharts.setOptions({
                lang: {
                    thousandsSep: '.'
                }
            })

            Highcharts.chart('graph', {

                chart: {
                    height: '60%'
                },

                title: {
                    text: 'Valorización Procedencia-Previsión'
                },
                series: [{
                    type: "sunburst",
                    data: data,
                    allowDrillToNode: true,
                    cursor: 'pointer',
                    dataLabels: {
                        format: '{point.name}',
                        filter: {
                            property: 'innerArcLength',
                            operator: '>',
                            value: 16
                        }
                    },
                    levels: [{
                        level: 1,
                        levelIsConstant: false,
                        dataLabels: {
                            filter: {
                                property: 'outerArcLength',
                                operator: '>',
                                value: 64
                            },
                            crop: false
                        }
                    }, {
                        level: 2,
                        colorByPoint: true
                    },
                    {
                        level: 3,
                        colorVariation: {
                            key: 'brightness',
                            to: -0.5
                        }
                    }, {
                        level: 4,
                        colorVariation: {
                            key: 'brightness',
                            to: 0.5
                        }
                    }]

                }],
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr>' +
                        '<td style="padding:0"><b>${point.value:,.0f}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            crop: false
                        },
                        colors: ['#7cb5ec',
                            '#f15c80',
                            '#90ed7d',
                            '#f7a35c',
                            '#8085e9',
                            '#e4d354',
                            '#2b908f',
                            '#f45b5b',
                            '#91e8e1']
                    }
                },
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
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "PREV": $("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/Gen_Excel",
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
        let Mx_Dtt_PDF = [{
            "urls": ""
        }];

        function Ajax_PDF() {
            modal_show();

            let Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "PREV": $("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr.aspx/PDFF",
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
    <style>
        .manito {
            cursor:pointer;
        }
    </style>
    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Atenciones por Programa, previsión y procedencia</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha2">Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label>Procedencia</label>
                    <select id="Ddl_LugarTM" class="form-control form-control-sm"></select>
                </div>
                <div class="col-lg">
                    <label>Previsión</label>
                    <select id="Ddl_Preve" class="form-control form-control-sm"></select>
                </div>
                <div class="col-lg">
                    <label>Usuario</label>
                    <select id="Ddl_Usu" class="form-control form-control-sm">
                        <option value="0">Todos</option>
                    </select>
                </div>
<%--            <div class="col-lg">
                    <label>Programa</label>
                    <select id="Ddl_Progra" class="form-control form-control-sm"></select>
                </div>
                <div class="col-lg mb-2">
                    <label>Subprograma</label>
                    <select id="Ddl_Subp" class="form-control form-control-sm">
                        <option value="0">Todos</option>
                        <option value="1">Sin Subprograma</option>
                        
                    </select>
                </div>--%>
                <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Buscar" class="btn btn-buscar btn-block btn-sm"><i class="fa fa-search fa-fw"></i>Buscar</button>
                </div>
                 <div class="col-lg mb-1">
                     <br />
                            <button type="button" id="btn_Excel" class="btn btn-success btn-block btn-sm"><i class="fa fa-file-excel-o fa-fw"></i>Excel</button>
                        </div>
                <div class="col-lg">
<%--                    <div class="row">
                        <div class="col-lg">
                            <button type="button" id="btn_Pdf" class="btn btn-warning btn-block btn-sm mt-0"><i class="fa fa-file-text-o fa-fw"></i>PDF</button>
                        </div>
                    </div>--%>
         <%--           <div class="row mt-1 mb-2">
                        <div class="col-lg">
                            <button type="button" id="btn_Excel" class="btn btn-success btn-block btn-sm mt-0"><i class="fa fa-file-excel-o fa-fw"></i>Excel</button>
                        </div>
                    </div>--%>

                </div>
            </div>
        </div>
    </div>
    <div id="Div_Tabla" class="mt-3" style="overflow: auto">
    </div>
    <div id="graph" class="mt-3">
    </div>
</asp:Content>
