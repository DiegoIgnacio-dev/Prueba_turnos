<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_PROVEE.Master" CodeBehind="REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx.vb" Inherits="Presentacion.REP_LAB_CANT_EXA_PROVEE_TOT_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true"%>
    
    <%-- Botones --%>
    <link href="../../../../Resourses/Style/Buttons.css" rel="stylesheet" />

        <%--Esto es para que funcione el gráfico--%>
    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script src="/js/Custom_modal.js"></script>
    <script src="/js/Custom_Objects.js"></script>

    <%-- Declaración de Eventos --%>
    <script>
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


            //Ajustes Visuales
            //$(".block_wait").css({ "display": "none" });
            $(".block_wait").hide();
            //$("#div_totales").empty().css({ "display": "none" });
            //$("#div_graficos").empty().css({ "display": "none" });
            $("#div_conte").hide();
            $("#div_totales").hide();
            $("#div_graficos").hide();
            Ajax_Exam();
            $("#Div_Tabla_Data").empty().css({ "background": "#ffffff" });
            //$("#Div_Tabla_Data").append(
            //    $("<div>").css({
            //        "width": "calc(100% - 60)",
            //        "text-align": "center",
            //        "padding": "30px",
            //        "font-size": "30px"
            //    }).text("Realice una Búsqueda.")

            //);

            //Llamar al llenado de los DropDownList
            //Ajax_Ddl();
            //Ajax_Ddl_Proce();
            //Registrar evento Click del Botón Buscar
            $("#Btn_Search").click(function () {
                
                    Ajax_DataTable();
                
               
            });

            $("#Btn_Export").click(function () {
                Ajax_Excel();
            });

            $("#Btn_PDF").click(() => {
                Ajax_PDF();
            });
        });
    </script>


    <%-- Peticiones AJAX --%>
    <script>
        //Json de llenado de DropDownList
        var Mx_Ddl = [
            {
                "ID_CODIGO_FONASA": 0,
                "CF_DESC": "asdf",
                "ID_ESTADO": 0
            }
        ];
        var Mx_Ddl_Proce = [
               {
                   "ID_PROCEDENCIA": "",
                   "PROC_COD": "",
                   "PROC_DESC": "",
                   "ID_ESTADO": ""
               }
        ];

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
                "url": "REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx/Llenar_Ddl_Exam",
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

        function Ajax_Ddl_Proce() {
            //Debug



            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl = JSON.parse(data.d);

                    Fill_Ddl_Proce();
                },
                "error": data => {
                    //Debug



                }
            });
        }
        function Fill_Ddl_Proce() {
            
            var procee = Galletas.getGalleta("USU_TM");

            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#DdlProce");
                Mx_Ddl.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#DdlProce");
                });
            }
            else {
                Mx_Ddl.forEach(aaa => {
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

        function Ajax_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_Ddl();
                        $(".block_wait").hide();



                    } else {
                      
                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Total").empty();
                        $("#Summary_Graph").empty();
                        $("#Div_dinero").empty();
                        $("#Div_Tabla_Data").append(
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
                   


                }
            });
        }
        //Json de llenado de DataTable
        var Mx_Dtt = [
            {
                "TOTAL_ATE": 0,
                "TOTAL_PREVE": 0,
                "TOT_FONASA": 0,
                "TOTA_SIS": 0,
                "TOTA_USU": 0,
                "TOTA_COPA": 0,
                "CF_DESC": "asdf",
                "ID_CODIGO_FONASA": 0,
                "ID_ESTADO": 0,
                "CF_COD": "asdf"

            }
        ];

        function Ajax_DataTable() {


            modal_show();
            var Data_Par = JSON.stringify({
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
                "ID_CF": $("#Ddl_Exam").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);

                        Fill_DataTable();
                        $("#div_conte").show();
                        $("#div_totales").show();
                        $("#div_graficos").show();
                        $(".block_wait").hide();


                    } else {
                        $("#div_conte").hide();
                        $("#div_totales").hide();
                        $("#div_graficos").hide();
                        $("#Div_Tabla_Data").empty();
                        $("#Div_Tabla_Data").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",

                                "color": "#000000"
                            }).text("Sin Resultados.")
                        );
                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    alert("Error en la Recepción de Datos");


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
                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
                "ID_CF": $("#Ddl_Exam").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx/PDFF",
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

        //Generar Excel
        function Ajax_Excel() {
            modal_show();


            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,

                "DATE_str01": String($("#TxtDate_01").val()),
                "DATE_str02": String($("#TxtDate_02").val()),
                "ID_CODIGO_FONASA": $("#Ddl_Exam").val()
            });

            $(".block_wait").fadeIn(500);

            $.ajax({
                "type": "POST",
                "url": "REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx/Gen_Excel",
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
                        var str_Error = "La petición de generación de planilla Excel no se ha realizado debido ";
                        str_Error += "a que los parámetros de búsqueda no arrojaron resultados."

                        $("#mdlNotif .modal-header h4").text("Error");
                        $("#mdlNotif .modal-body p").html(str_Error);
                        $("#mdlNotif").modal();
                        Hide_Modal();


                    }
                },
                "error": function (response) {
                    Hide_Modal();
                    $("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    $("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    $("#mdlNotif").modal();
                    Hide_Modal();


                }
            });
        }
    </script>

    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList
        function Fill_Ddl() {
            $("#DdlExamen").empty();

            $("<option>", {
                "value": 0
            }).text("Todos").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Ddl.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl[y].ID_CODIGO_FONASA
                }).text(Mx_Ddl[y].CF_DESC).appendTo("#DdlExamen");
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
                    $("<th>").text("Descripción de Prestación"),
                    $("<th>", { "class": "text-center" }).text("Cantidad Exámenes")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "left" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "center" }).text(addCommas(Mx_Dtt[i].TOTAL_ATE))
                    )
                );
            }

            $("#DataTable").DataTable({  "bSort": false,
                "iDisplayLength": 25,
                "language": {
                    "DisplayLength": 100,
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });

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

            var T_Ate = 0;
            var T_Exa = 0;

            for (i = 0; i < Mx_Dtt.length; i++) {

                //T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Dtt[i].TOTAL_ATE);
                T_Exa = parseFloat(T_Exa) + parseFloat(Mx_Dtt[i].TOT_FONASA);
            }


            $("#lbl_totales").text(addCommas(T_Exa));
            //$("#DataTableTotal").attr("class", "table table-hover table-striped table-iris");
            //$("#DataTableTotal thead").attr("class", "cabezera");
            //$("#DataTableTotal thead").append(
            //    $("<tr>").append(
            //        $("<th>").text("Cantidad Total de Exámenes: "),
            //        $("<th>").text(T_Exa)
            //    )
            //);


            //$("#DataTableTotal tbody").append(
            //        $("<tr>").append(
            //            //$("<td>", { "align": "left" }).text(T_Ate),
            //            $("<td>", { "align": "left" }).text(T_Exa)
            //        )
            //    );

            var arr = ["Array"];
            var arr1 = [0];
            var arr2 = [0];
            for (i = 0; i < Mx_Dtt.length; i++) {
                if (i == 0) {
                    arr.pop();
                    arr1.pop();
                    arr2.pop();
                }
                arr.push(Mx_Dtt[i].CF_DESC);
                arr1.push(parseFloat(Mx_Dtt[i].TOTAL_ATE));
                arr2.push(parseFloat(Mx_Dtt[i].TOT_FONASA));
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
                        text: 'Atenciones'
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
                    name: 'Cantidad Atenciones',
                    data: arr1
                }, {
                    name: 'Cantidad Exámenes',
                    data: arr2
                }]
            });

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
            <h5>Búsqueda por Cantidad de Exámenes Totales</h5>
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
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='fecha2'>
                        <input type='text' id="TxtDate_02" class="form-control" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-2">
                    <label for="Ddl_Exam">Exámenes:</label>
                    <select id="Ddl_Exam" class="form-control">
                        <option value="0">Seleccionar</option>
                    </select>
                </div>
      <%--          <div class="col-lg-4">
                </div>--%>
                <div class="col-lg-2">
                    <br />
                    <button id="Btn_Search" type="button" class="btn btn-block btn-buscar btn-sm"><i class="fa fa-fw fa-search mr-2"></i> Buscar</button>
                </div>
                <div class="col-lg-2">
                    <br />
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-search mr-2"></i> Excel</button>
                </div>
                <div class="col-lg-2">
                    <br />
                    <button id="Btn_PDF" type="button" class="btn btn-block btn-warning btn-sm"><i class="fa fa-fw fa-search mr-2"></i> PDF</button>
                </div>
<%--                <div class="col-lg">
                    <label for="DdlExamen">Tipo de Exámen:</label>
                    <select id="DdlExamen" class="form-control"></select>
                </div>
                <div class="col-lg">
                    <label for="DdlProce">Lugar de TM:</label>
                    <select id="DdlProce" class="form-control"></select>
                </div>--%>
                <%--  <div class="col-lg-1">
                   
                </div>
                <div class="col-lg-1">
                   
                </div>--%>
            </div>
<%--                <div class="col-lg">
                    <button id="Btn_Export" type="button" class="btn btn-block btn-success btn-sm"><i class="fa fa-fw fa-file-excel-o mr-2"></i> Excel</button>
                </div>--%>

        </div>
    </div>
    <div class="card mb-3 border-bar" id="div_conte">
        <div class="row">
            <div class="col-lg-12">
                <div class="card-header bg-bar p-2">
                    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de Exámenes</h5>
                </div>
                <br />
                <div id="Div_Tabla_Data" class="table table-hover table-striped table-iris"></div>

              <%--  <div class="row">
                    <div class="col-lg">
                        <h5>Totales</h5>
                        <div id="Div_Tabla_02" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>--%>
            </div>

        </div>
            <div class="card mb-3 border-bar" id="div_totales">
                <div class="card-header bg-bar p-2">
                    <h5>Totales de Exámenes: <span id="lbl_totales"></span></h5>
                </div>
                <div id="Div_Tabla_Total" class="card-body" style="overflow: auto">
                </div>
            </div>
            <div class="card mb-3 border-bar" id="div_graficos">
                <div class="card-header bg-bar p-2">
                    <h5>Gráfico de Totales</h5>
                </div>
                <div>
                    <div id="Summary_Graph" class="card-body" style="overflow: auto"></div>
                </div>
            </div>
    </div>
</asp:Content>




