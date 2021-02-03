﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Atencion_Det.aspx.vb" Inherits="Presentacion.Atencion_Det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>


    <script>
        
          <!--FUNCION GET PARAMETRO URL-->     ssss
    var AJAX_Datos = 0;
    var AJAX_DTT = 0;
    var idAte = 0;
    var ateIDD = 0;

    window.onload = function () {
        if (Galletas.getGalleta("P_ADMIN") != 1) {
            $("#btnverresu").remove();
        }
    };

    $(document).ready(function () {
        modal_show();
        idAte = getParameterByName("ID_ATE");


        $(`#Btn_Res`).attr({
            href: `/Resultados/Ate_Resultados.aspx?ID=${idAte}`
        });


        Ajax_Llenar_Datos();
        Ajax_Llenar_Datatable();

    });
    </script>
    <!--FUNCIONES AJAX-->
    <script>
        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        //Declaacones JSON
        var Mx_Datos = [{
            "ID_ATENCION": "",
            "PAC_RUT": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "SEXO_DESC": "",
            "PAC_FNAC": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "PROC_DESC": "",
            "PREVE_DESC": "",
            "DOC_NOMBRE": "",
            "DOC_APELLIDO": "",
            "ENCRYPTED_ID": "",
            "DNI":""
        }];
        var Mx_DataTable = [{
            "CF_COD": "",
            "CF_DESC": "",
            "ATE_DET_V_FECHA": "",
            "TP_PAGO_DESC": "",
            "CF_DIAS": "",
            "ATE_DET_IMPRIME": "",
            "ATE_DET_V_ID_ESTADO": "",
            "ESTADO_WEB_DERIVADO": "",
            "ID_DET_ATE": "",
            "ID_PER": "",
            "USU_NIC":""
        }];


        function Ajax_Llenar_Datos() {
            //Debug



            //Parámetros
            var strParam = JSON.stringify({
                "ID_ATE": idAte
            });
            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Atencion_Det.aspx/Llenar_Datos",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug


                    if (data.d != null) {
                        Mx_Datos = JSON.parse(data.d);
                        ////console.log(Mx_Datos);
                        for (i = 0; i < Mx_Datos.length; ++i) {
                            var date_y = Mx_Datos[i].PAC_FNAC;
                            var date_x = Mx_Datos[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            date_y = String(date_y).replace("/Date(", "");
                            date_y = date_y.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            var Date_Change2 = new Date(parseInt(date_y));
                            Mx_Datos[i].ATE_FECHA = Date_Change;
                            Mx_Datos[i].PAC_FNAC = Date_Change2;
                        }
                        Fill_Data();


                    } else {
                        Hide_Modal();



                    }

                },
                "error": data => {
                    //Debug



                }
            });
        }
        function Ajax_Redirect() {

            //console.log(ateIDD);
            var loc = location.origin;
            window.open(loc + "/Print_Ate/VerExamenes.asp?id_cliente=" + ateIDD);
        }
        function Ajax_Redirect2() {


            var loc = location.origin;
            window.open(loc + "/Print_Ate/VerExamenesSolo.asp?id_cliente=" + ateIDD + "&ID_PERFIL_NUEVO=" + per);
        }

        function Ajax_Llenar_Datatable() {
            //Debug



            //Parámetros
            var strParam = JSON.stringify({
                "ID_ATE": idAte

            });
            AJAX_DTT = $.ajax({
                "type": "POST",
                "url": "Atencion_Det.aspx/Llenar_DataTable",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug


                    if (data.d != null) {
                        Mx_DataTable = JSON.parse(data.d);
                        ////console.log(Mx_DataTable);
                        for (i = 0; i < Mx_DataTable.length; ++i) {
                            var date_x = Mx_DataTable[i].ATE_DET_V_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_DataTable[i].ATE_DET_V_FECHA = Date_Change;

                        }
                        Fill_Dtt();

                    } else {
                        $("#btnprintall").remove();
                        $("#hrhide").remove();
                        $("#rowhide").remove();
                        //$("#btnverresu").remove();
                        Hide_Modal();
                    }
                },
                "error": data => {
                    Hide_Modal();
                    //Debug



                }
            });
        }
        function Ajax_Exa_Print(per) {
            console.log("ATE " + ateIDD + " PER: " + per);
            var loc = location.origin;
            window.open(loc + "/Print_Ate/VerExamenesSolo.asp?id_cliente=" + ateIDD + "&ID_PERFIL_NUEVO=" + per);

        }
        function Fill_Data() {

            ateIDD = Mx_Datos[0].ID_ATENCION;
            //console.log(ateIDD);
            var FNac = Mx_Datos[0].PAC_FNAC;
            var FIngr = Mx_Datos[0].ATE_FECHA;
            FNac = moment(FNac).format("DD-MM-YYYY");
            FIngr = moment(FIngr).format("DD-MM-YYYY HH:mm:SS");



            $("#Rut").text(function () {
                if (Mx_Datos[0].PAC_RUT == "") {
                    return Mx_Datos[0].DNI
                } else {
                    return Mx_Datos[0].PAC_RUT
                }
            });
            $("#Nombre").text(Mx_Datos[0].PAC_NOMBRE + " " + Mx_Datos[0].PAC_APELLIDO);
            $("#Sexo").text(Mx_Datos[0].SEXO_DESC);
            $("#FechaNac").text(FNac);
            $("#NumOrden").text(Mx_Datos[0].ATE_NUM);
            $("#FechaIng").text(FIngr);
            $("#LugarTM").text(Mx_Datos[0].PROC_DESC);
            $("#Prevision").text(Mx_Datos[0].PREVE_DESC);
            $("#ProfSol").text(Mx_Datos[0].DOC_NOMBRE + " " + Mx_Datos[0].DOC_APELLIDO);

        }
        function Fill_Dtt() {

            var tab = "";
            var id_det_ate = "";
            var inExa = 0;
            var inDer = 0;
            var inEsp = 0;
            var cont_no_esp = 0;
            Mx_DataTable.forEach(examen=> {


                if (examen.ATE_DET_V_ID_ESTADO == 6 || examen.ATE_DET_V_ID_ESTADO == 14) {
                    tab = "Exa";
                    inExa += 1;
                }
                else if (examen.ESTADO_WEB_DERIVADO != null && examen.ESTADO_WEB_DERIVADO != 0) {
                    tab = "Der";
                    inDer += 1;
                }
                else {
                    tab = "Esp";
                    inEsp += 1;
                }

                id_det_ate = examen.ID_DET_ATE;
                var date_ate_det = examen.ATE_DET_V_FECHA;
                date_ate_det = moment(date_ate_det).format("DD-MM-YYYY HH:mm:SS");
                var ffinal = date_ate_det;


                $("<tr>").append(
                    $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(function () {
                        if (tab == "Exa") { return inExa; }
                        else if (tab == "Der") { return inDer; }
                        else { return inEsp; }
                    }),
                    $("<td>").css("text-align", "center").text(examen.CF_COD),
                    $("<td>").text(examen.CF_DESC),
                    $("<td>").css("text-align", "center").text(ffinal),
                    $("<td>").css("text-align", "center").text(examen.USU_NIC),
                    $("<td>").css("text-align", "center").text(examen.TP_PAGO_DESC),
                    $("<td>").css("text-align", "center").text(examen.CF_DIAS),
                    $("<td>").css("text-align", "center").text(function () {
                        if (tab == "Esp") {
                            $(this).css("cssText", "background-color:#ffdaaa !important; color:inherit; cursor:pointer; text-align:center;").text("Espera");
                        }
                        else if (tab == "Der") {
                            $(this).css("cssText", "background-color:#a9d1fc !important; color:inherit;  text-align:center;").addClass("espera").text("Derivado");
                            cont_no_esp += 1;
                        }
                        else {
                            $(this).css("cssText", "background-color:#9bffb1 !important; color:inherit;  text-align:center;").addClass("espera").text("Realizado");
                            cont_no_esp += 1;
                        }
                    }),


                    $("<td>").css("text-align", "center").text(function () {
                        if (tab != "Esp") {
                            //$(this).css("cssText", "background-color:#28a745 !important; color:white; cursor:pointer; text-align:center;").text("Imprimir");
                            //$(this).attr({ "onclick": `Ajax_Exa_Print("` + id_det_ate + `")` });
                            $(this).append("<button type='button' class='btn btn-danger btn-sm' onclick='Ajax_Exa_Print(" + examen.ID_PER + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver PDF</button>");

                        }
                        else {
                            $(this).css("cssText", " color:inherit;  text-align:center;").addClass("espera").text("En Espera");
                        }
                    }),
                    $("<td>").css("text-align", "center").text(examen.ATE_DET_IMPRIME)

            ).appendTo("#DataTable tbody");
            });

            $("table").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                "bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });

            if (cont_no_esp == 0) {
                $("#btnprintall").remove();
            }
            Hide_Modal();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        
    </style>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="card border-bar">
                <div class="card-header bg-bar">
                    <h5>
                        <i class="fa fa-info"></i>
                        Detalles de Atenciones
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-1 text-center pt-3">
                            <i class="fa fa-user fa-5x" style="color: #00738e"></i>
                        </div>
                        <div class="col-lg">
                            <h5>Datos Paciente:</h5>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">RUT/DNI:</label>
                                <div class="col-9">
                                    <label id="Rut" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Nombre:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="Nombre" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Sexo:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="Sexo" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Fecha Nac:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="FechaNac" class="m-0"></label>
                                </div>
                            </div>

                        </div>
                        <div class="col-lg">
                            <h5>Datos Atención:</h5>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">N° de Orden:</label>
                                <div class="col-9">
                                    <label id="NumOrden" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Fecha Ingreso:</label>
                                <div class="col-9">
                                    <label id="FechaIng" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Lugar TM:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="LugarTM" class="m-0"></label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-3 col-form-label pt-0 pb-0 m-0">Previsión:</label>
                                <div class="col-9 text-uppercase">
                                    <label id="Prevision" class="m-0"></label>
                                </div>
                            </div>

                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg-6">
                            <h5>Profesional Solicitante:</h5>
                            <div class="text-left row">
                                <label class="col-sm-3 col-form-label">Nombre:</label>
                                <div class="col-sm-9">
                                    <label id="ProfSol"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr id="hrhide" />
                    <div class="row" id="rowhide">
                        <div class="col-lg-12" style="overflow: auto">
                            <h5>Lista de Exámenes</h5>

                            <table id="DataTable" cellspacing="0" class="table table-hover table-striped table-iris table-iris">
                                <thead>
                                    <tr>
                                        <th style="text-align: center">#</th>
                                        <th style="text-align: center">Código</th>
                                        <th>Descripción del Exámen</th>
                                        <th style="text-align: center">Fecha de Creación</th>
                                        <th style="text-align: center">Usuario</th>
                                        <th style="text-align: center">Forma de Pago</th>
                                        <th style="text-align: center">Días Hábiles de Proceso</th>
                                        <th style="text-align: center">Estado</th>
                                        <th style="text-align: center">PDF</th>
                                        <th style="text-align: center">N° Copias</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-8 col-lg-8"></div>
                        <div class="col-sm-12 col-md-4 col-lg-4" id="imptodos">
                            <button type="button" class="btn btn-print btn-block" id="btnprintall" onclick="Ajax_Redirect()"><i class="fa fa-fw fa-file-text mr-2"></i>Ver Todos los Exámenes</button>
                        </div>
                     <%--   <div class="col-sm-12 col-md-6 col-lg-4">
                            <button type="button" class="btn btn-primary btn-block" id="btnverresu" onclick="Ajax_Redirect2()"><i class="fa fa-fw fa-edit mr-2"></i>Ver/Editar  Resultados</button>
                        </div>--%>
                        <div class="md-6 col-lg-4">
                            <a id="Btn_Res" class="btn btn-primary btn-block" href="/Resultados/Ate_Resultados.aspx" runat="server">
                                <i class="fa fa-fw fa-edit mr-2"></i>
                                <span>Ver/Editar Resultados</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1"></div>

        </div>
    </div>
</asp:Content>
