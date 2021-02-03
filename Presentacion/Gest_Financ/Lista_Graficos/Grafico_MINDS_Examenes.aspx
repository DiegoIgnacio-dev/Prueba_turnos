﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_MINDS.Master" CodeBehind="Grafico_MINDS_Examenes.aspx.vb" Inherits="Presentacion.Grafico_MINDS_Examenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
    <%-- Highcharts --%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <%-- Custom Libraries --%>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>
    <%-- --------------------------------------------------------------- --%>
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
</script>   
    <script>
        //Devuelve una cadena con la Fecha de hoy del tipo "dd/MM/yyyy"
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
        //Devuelve un entero con la diferencia de días entre 2 fechas
        function restaFechas(f1, f2) {
            var aFecha1 = f1.split('/');
            var aFecha2 = f2.split('/');
            var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
            var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
            var dif = fFecha2 - fFecha1;
            var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
            return dias;
        }
    </script>
    <%-- Registro de Eventos --%>
    <script>


        var valor = 2;
        var valor_2 = 3;

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

        $(document).ready(function () {



            $("#div_hide").hide();
            $("#Chk_Bruto").prop("checked", true);
            //Establecer Datepickers
            /*$("#TxtDate_01").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_02").attr({
                "data-provide": "datepicker",
                "value": Date_Now
            });
            $("#TxtDate_01").datepicker({
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true,
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });
            $("#TxtDate_02").datepicker({
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true,
                format: "dd/mm/yyyy",
                disableTouchKeyboard: true,
                language: "es"
            });*/
            //Modificaciones Visuales del DOM
            $(".block_wait").hide();
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });
            $("#Div_Tabla").append(
                $("<div>").css({
                    "width": "calc(100% - 60)",
                    "text-align": "center",
                    "padding": "30px",
                    "font-size": "30px"
                }).text("Realice su Búsqueda.")
            );
            //Iniciar petición de datos requeridos en el inicio
            Ajax_Ddl();
            Ajax_Ddl_Mes();
            Ajax_Ddl_Grafico();
            Ajax_Exam();
            //Registrar Botón Buscar
            $("#Btn_Search").click(function () {

                if ($('#Chk_Pendientes').is(':checked')) {
                    valor = 1;
                } else if (($('#Chk_Todos').is(':checked'))) {
                    valor = 0;
                }

                if ($('#Chk_Pendientes_2').is(':checked')) {
                    valor_2 = 0;
                } else if (($('#Chk_Todos_2').is(':checked'))) {
                    valor_2 = 1;
                } else if (($('#Chk_Bruto').is(':checked'))) {
                    valor_2 = 2;
                }

                AJAX_DataTable();
            });
            //Registrar Botón Exportar
            $("#Btn_Export").click(function () {
                if ($('#Chk_Pendientes').is(':checked')) {
                    valor = 1;
                } else if (($('#Chk_Todos').is(':checked'))) {
                    valor = 0;
                }

                if ($('#Chk_Pendientes_2').is(':checked')) {
                    valor_2 = 0;
                } else if (($('#Chk_Todos_2').is(':checked'))) {
                    valor_2 = 1;
                } else if (($('#Chk_Bruto').is(':checked'))) {
                    valor_2 = 2;
                }

                Ajax_Excel();
            });

            $("#Btn_PDF").click(() => {
                if ($('#Chk_Pendientes').is(':checked')) {
                    valor = 1;
                } else if (($('#Chk_Todos').is(':checked'))) {
                    valor = 0;
                }

                if ($('#Chk_Pendientes_2').is(':checked')) {
                    valor_2 = 0;
                } else if (($('#Chk_Todos_2').is(':checked'))) {
                    valor_2 = 1;
                } else if (($('#Chk_Bruto').is(':checked'))) {
                    valor_2 = 2;
                }
                Ajax_PDF();
            });

            $("#E_DESDE").change(function () {
                var desde = $("#E_DESDE").val();
                if (desde == "") {
                    E_Desde = $("#E_DESDE").val(0);
                }
            });
            $("#Chk_Todos").prop("checked", true);
        });
    </script>
    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList

        //------------------------------------------------ AJAX DDL EXAMEN -------------------------------------------|
        var Mx_Exam = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];

        function Ajax_Exam() {
            modal_show();



            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Grafico_MINDS_Examenes.aspx/Llenar_Ddl_Exam",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Exam = JSON.parse(json_receiver);

                        Fill_Ddl_Exam();
                        Hide_Modal();


                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();

            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");
            for (y = 0; y < Mx_Exam.length; ++y) {
                $("<option>", {
                    "value": Mx_Exam[y].ID_CODIGO_FONASA
                }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
            }

        };

        var Mx_Ddl = [
            {
                "ID_AÑO": 0,
                "AÑO_COD": "asdf",
                "AÑO_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Ddl() {

            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Grafico_MINDS_Examenes.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_Ddl();

                    } else {

                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();

                }
            });
        }

        function Ajax_Ddl_Mes() {

            Fill_Ddl_Mes();
        }
        function Ajax_Ddl_Grafico() {

            Fill_Ddl_Grafico();
        }

        //JSON para el DataTable
        var Mx_Dtt = [
            {
                "E_Fecha": "",
                "E_Cantidad": "",
                "E_Dias": "",
                "CANT_EXA": "",
                "PREVI":"",
                "PAGADO":"",
                "COPAGO": "",
                "TOTA_SIS": ""
            }
        ];
        function AJAX_DataTable() {

            var Data_Par = JSON.stringify({
                "Mes": String($("#DllMes").val()),
                "Año": $("#DllAño option:selected").text(),
                "ID_CF": $("#Ddl_Exam").val(),
                "VALOR": valor,
                "VALOR_2": valor_2
            });
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Grafico_MINDS_Examenes.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].E_Fecha;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].E_Fecha = Date_Change;
                        }
                        Fill_DataTable();

                    } else {

                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );
                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();

                }
            });
        }
        //Generar Excel
        function Ajax_Excel() {


            var Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "Mes": String($("#DllMes").val()),
                "Año": $("#DllAño option:selected").text(),
                "ID_CF": $("#Ddl_Exam").val(),
                "CF_DESC": $("#Ddl_Exam option:selected").text(),
                "VALOR": valor,
                "VALOR_2": valor_2
            });
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Grafico_MINDS_Examenes.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        var str_Download = "La Planilla Excel se ha generado correctamente, puede descargarla haciendo click ";
                        str_Download += "<a href='" + json_receiver + "'>AQUÍ.</a>"
                        $("#mdlNotif .modal-header h4").text("Archivo Generado");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();

                    } else {
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."
                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Download);
                        $("#mdlNotif").modal();

                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();

                }
            });
        }

        //------------------------------------ PDF -----------------------------
        let Mx_Dtt_PDF = [{
            "urls": ""
        }];

        function Ajax_PDF() {
            modal_show();

            let Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DATE_str01": String($("#DllMes").val()),
                "DATE_str02": $("#DllAño option:selected").text(),
                "ID_CF": $("#Ddl_Exam").val(),
                "CF_DESC": $("#Ddl_Exam option:selected").text(),
                "VALOR": valor,
                "VALOR_2": valor_2
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Grafico_MINDS_Examenes.aspx/PDFF",
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
    <%-- Funciones de Llenado --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DllAño").empty();
            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#DllPreV");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_AÑO
                }).text(Mx_Ddl[y].AÑO_DESC).appendTo("#DllAño");
            }
        };
        function Fill_Ddl_Mes() {
            $("#DllMes").empty();
            $("<option>", {
                "value": 1
            }).text("Enero").appendTo("#DllMes");
            $("<option>", {
                "value": 2
            }).text("Febrero").appendTo("#DllMes");
            $("<option>", {
                "value": 3
            }).text("Marzo").appendTo("#DllMes");
            $("<option>", {
                "value": 4
            }).text("Abril").appendTo("#DllMes");
            $("<option>", {
                "value": 5
            }).text("Mayo").appendTo("#DllMes");
            $("<option>", {
                "value": 6
            }).text("Junio").appendTo("#DllMes");
            $("<option>", {
                "value": 7
            }).text("Julio").appendTo("#DllMes");
            $("<option>", {
                "value": 8
            }).text("Agosto").appendTo("#DllMes");
            $("<option>", {
                "value": 9
            }).text("Septiembre").appendTo("#DllMes");
            $("<option>", {
                "value": 10
            }).text("Octubre").appendTo("#DllMes");
            $("<option>", {
                "value": 11
            }).text("Noviembre").appendTo("#DllMes");
            $("<option>", {
                "value": 12
            }).text("Diciembre").appendTo("#DllMes");
        };
        function Fill_Ddl_Grafico() {
            $("#DllGrafico").empty();
            $("<option>", {
                "value": 0
            }).text("1-. Grafico lineal").appendTo("#DllGrafico");
        };
        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });
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
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").css("text-align", "center").text("#"),
                    $("<th>").css("text-align", "center").text("Fecha"),
                    $("<th>").css("text-align", "center").text("Día"),
                    $("<th>").css("text-align", "center").text("Cantidad Atenciones"),
                    $("<th>").css("text-align", "center").text("Cantidad Exámenes"),
                    $("<th>").css("text-align", "center").text("Venta")
                    
                )
            );
            for (i = 0; i < Mx_Dtt.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt[i].E_Fecha);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }

                            return String(dd + "/" + MM + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }).text(Mx_Dtt[i].E_Dias),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(Mx_Dtt[i].E_Cantidad, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(Mx_Dtt[i].CANT_EXA, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text("$ " + addCommas(Mx_Dtt[i].TOTA_SIS))
                        
                        )
                );
            }
            //LLENADO TABLA TOTALES
            $("#Div_Tabla_Total").empty().css({ "background": "#ffffff" });
            $("<table>", {
                "id": "DataTableTotal",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Total");
            $("#DataTableTotal").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTableTotal thead").append(
                $("<tr>").append(
                    $("<th>").css("text-align", "center").text("Cantidad Mensual Ate"),
                    $("<th>").css("text-align", "center").text("Promedio Diario Ate"),
                    $("<th>").css("text-align", "center").text("Ventas")
                )
            );
            var T_Ate = 0;
            var T_Exa = 0;
            var T_Sis = 0;
            var Total_Ventas = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {
                T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Dtt[i].E_Cantidad);
                T_Exa = parseFloat(T_Exa) + 1.
                Total_Ventas += parseFloat(Mx_Dtt[i].TOTA_SIS)
            }
            T_Sis = Math.round(T_Ate / T_Exa)
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Ate, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text(cFormat.numToString(T_Sis, 0, ".", ",")),
                        $("<td>", { "align": "center" }).text("$ " + addCommas(Total_Ventas))
                    )
                );
            grafico();
        };
        function grafico() {
            //var grafico = $("#DllGrafico").val();

            //if (grafico == 0) {
                var arr = ["Array"];
                var arr1 = [0];
                var fecha = ""
                var arr2 = [0];
                for (i = 0; i < Mx_Dtt.length; i++) {
                    if (i == 0) {
                        arr.pop();
                        arr1.pop();
                        arr2.pop();
                    }
                    fecha = (function () {
                        //Obtener valores
                        var obj_date = new Date(Mx_Dtt[i].E_Fecha);
                        var dd = parseInt(obj_date.getDate());
                        var MM = parseInt(obj_date.getMonth()) + 1;
                        var yy = parseInt(obj_date.getFullYear());
                        if (dd < 10) { dd = "0" + dd; }
                        if (MM < 10) { MM = "0" + MM; }

                        return String(dd + "/" + MM + "/" + yy);
                    })();
                    arr.push(fecha);
                    arr1.push(parseFloat(Mx_Dtt[i].E_Cantidad));
                    arr2.push(parseFloat(Mx_Dtt[i].CANT_EXA));
                }

                Highcharts.chart('Summary_Graph', {
                    chart: {
                        type: 'line'
                    },
                    title: {
                        text: ''
                    },
                    subtitle: {
                        text: ''
                    },
                    xAxis: {
                        categories: arr
                    },
                    yAxis: {
                        title: {
                            text: 'Atenciones/Exámenes'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: true
                        }
                    },
                    series: [{
                        name: 'Cantidad de Atenciones',
                        data: arr1
                    }, {
                        name: 'Cantidad de Exámenes',
                        data: arr2
                    }]
                });
            //};
            $("#div_hide").show();
        }
        function grafico_2() {
            //var grafico = $("#DllGrafico").val();

            //if (grafico == 0) {
            var arr = ["Array"];
            var arr1 = [0];
            var fecha = ""
            var arr2 = [0];
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    arr.pop();
                    arr1.pop();
                    arr2.pop();
                }
                fecha = (function () {
                    //Obtener valores
                    var obj_date = new Date(Mx_Dtt[i].E_Fecha);
                    var dd = parseInt(obj_date.getDate());
                    var MM = parseInt(obj_date.getMonth()) + 1;
                    var yy = parseInt(obj_date.getFullYear());
                    if (dd < 10) { dd = "0" + dd; }
                    if (MM < 10) { MM = "0" + MM; }

                    return String(dd + "/" + MM + "/" + yy);
                })();
                arr.push(fecha);
                arr1.push(parseFloat(Mx_Dtt[i].E_Cantidad));
                arr2.push(parseFloat(Mx_Dtt[i].CANT_EXA));
            }

            Highcharts.chart('Montos_Graph', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: arr
                },
                yAxis: {
                    title: {
                        text: 'Sistema/Pagado'
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: true
                    }
                },
                series: [{
                    name: 'Total Sistema',
                    data: arr1
                }, {
                    name: 'Total Pagado',
                    data: arr2
                }]
            });
            //};
            //$("#div_hide").show();
        }
    </script>

     <%-- Custom CSS --%>
    <style>
        table thead {
            background-color:#28a745;
            color:white;
        }

                .checkbox-success input[type="checkbox"]:checked + label::before {
            background-color: #5cb85c;
            border-color: #5cb85c;
        }

        .checkbox-success input[type="checkbox"]:checked + label::after {
            color: #fff;
        }




        .checkbox-success {
            line-height: 13px;
            margin-bottom: 3px;
        }

            .checkbox-success input[type="checkbox"], label {
                cursor: pointer;
            }

        .checkbox label {
            width: 90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-3 border-bar">
        <div class="card-header bg-bar">
            <h5>Cantidad de Atenciones Mensuales</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-1">
                    <label for="DllAño">Año:</label>
                    <select id="DllAño" class="form-control"></select>
                </div>
                <div class="col-lg-2">
                    <label for="DllMes">Mes:</label>
                    <select id="DllMes" class="form-control"></select>
                </div>
                <div class="col-lg-2">
                    <label for="Ddl_Exam">Exámenes:</label>
                    <select id="Ddl_Exam" class="form-control">
                        <option value="0">Seleccionar</option>
                    </select>
                </div>
<%--                <div class="col-lg-2">
                    <label for="Ddl_Monto">Montos:</label>
                    <select id="Ddl_Monto" class="form-control">
                        <option value="0">Todos</option>
                        <option value="1">$0</option>
                        <option value="2">$1 - $1.000</option>
                        <option value="3">$1.001 - $3.000</option>
                        <option value="4">$3.001 - $5.000</option>
                        <option value="5">$5.001 - $7.000</option>
                        <option value="6">$7.001 - $9.000</option>
                        <option value="7">$9.001 - $11.000</option>
                        <option value="8">$11.001 - $13.000</option>
                        <option value="9">$13.001 - $15.000</option>
                        <option value="10">$15.001 o más</option>
                    </select>
                </div>--%>
                <div class="col-lg-2">

                </div>
                <div class="col-lg-1">
                    <br />  
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
                </div>
                <div class="col-lg-1">
                    <br />
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
                </div>
                <div class="col-lg-1">
                    <br />
                    <button id="Btn_PDF" type="button" class="btn btn-block btn-warning btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i> PDF</button>
                </div>
            </div>

            <br />
            <div class="row">
                <form action="" class="row" style="margin-left:5px;">
                    <div class="col-lg-6">
                        <label for="Chk_Pendientes">CON Valor 0/domingos</label>
                        <input type="radio" name="gender" value="1" id="Chk_Pendientes"><br />
                    </div>
                    <div class="col-lg-6">
                        <label for="Chk_Todos">SIN Valor 0/domingos</label>
                        <input type="radio" name="gender" value="0" id="Chk_Todos">
                    </div>
                    <div class="col-lg-4">

                    </div>
                </form>
            </div>
            <div class="row">
                <form action="" class="row" style="margin-left:5px;">
                    <div class="col-lg">
                        <label for="Chk_Bruto">Todos</label>
                        <br />
                        <input type="radio" name="gender" value="2" id="Chk_Bruto"/>
                    </div>
                    <div class="col-lg">
                        <label for="Chk_Pendientes_2">Validados</label>
                        <input type="radio" name="gender" value="0" id="Chk_Pendientes_2"/>
                    </div>
                    <div class="col-lg">
                        <label for="Chk_Todos_2">Validados/Revisados</label>
                        <input type="radio" name="gender" value="1" id="Chk_Todos_2"/>
                    </div>
                </form>
            </div>



        </div>
    </div>
    <div class="card p-3 border-bar" id="div_hide">
        <div class="row">
            <div class="col-lg-3">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Detalle Mensual</h5>
                        <div id="Div_Tabla" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_Total" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9">
                <h5>Gráfico Atenciones</h5>
                <div id="Summary_Graph"></div>
            </div>
        </div>
<%--        <div class="row">
            <h5>Gráfico Montos</h5>
                <div id="Montos_Graph"></div>
        </div>--%>
    </div>
</asp:Content>
