<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rel_Est_ExamSed.aspx.vb" Inherits="Presentacion.Rel_Est_ExamSed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(function () {
            $("#divTable01").hide();
            Ajax_Prevision();
            Ajax_LugarTM();
            Ajax_Preve();
  

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $('#Txt_Date01').datetimepicker(
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
            $("#Txt_Date02 input").val(dateNow);
            $('#Txt_Date02').datetimepicker(
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

            $("#Div_Tabla").empty();
            $("#Div_Tabla_Totales").empty();

            //Registrar evento Click del Botón Buscar       
            $("#Btn_Search").click(function () {
                $("#Div_Tabla").empty();
                $("#Div_Tabla_Totales").empty();
                Call_Data_Table();

            });

            $("#Btn_Gen").click(function () {

                Call_Export();

            });
            //$("#Ddl_Examen").change(function () {
            //    pruebas_ddl();

            //});
        });


        //-------------------------------------------------- AJAX DDL PREVISIÓN ---------------------------------------------|
        var Mx_Dtt_Prevision = [
        {
            "ID_EST": 0,
            "EST_EXA_COD": 0,
            "EST_EXA_DESC": 0,
            "ID_ESTADO": 0
        }
        ];

        function Ajax_Prevision() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Rel_Est_ExamSed.aspx/Llenar_Estadistica",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Prevision = JSON.parse(json_receiver);
                        Fill_Ddl_Prevision();
                        Hide_Modal();
                    } else {
                        console.log(response);
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    console.log(response)
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
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
                "url": "Rel_Est_ExamSed.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_LugarTM = json_receiver;
                        Fill_Ddl_LugarTM();
                    } else {

                    }
                },
                "error": function (response) {

                }
            });
        }


        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

            var procee = Galletas.getGalleta("USU_ID_PROC");
            var ide_admin = Galletas.getGalleta("P_ADMIN");

            if (ide_admin == 1) {
                $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_LugarTM");
                Mx_Dtt_LugarTM.forEach(aaa => {
                    
                    $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            } else {
                Mx_Dtt_LugarTM.forEach(aaa => {

                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }
                });
            }

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
                "url": "Rel_Est_ExamSed.aspx/Llenar_Ddl_Prevision",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Preve = json_receiver;
                        Fill_Ddl_Preve();
                    } else {

                    }
                },
                "error": function (response) {

                }
            });
        }
        function Fill_Ddl_Preve() {
            $("#Ddl_Preve").empty();

            var preveee = Galletas.getGalleta("USU_PREV");

            if (preveee == 0) {
                $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Preve");
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

            //_cont_mod += 1;
            //c_modal();

        };

        //----------    var Mx_Dtt_Prevision = [
        let arrData = [
          {
              ID_PRUEBA: 0,
              PRU_DESC: ""
          }
        ]

        function pruebas_ddl() {
            modal_show();

            var Data_Par = JSON.stringify({
                "id_cf": $("#Ddl_Examen").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Rel_Est_ExamSed.aspx/IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        arrData = JSON.parse(json_receiver);
                        Fill_Ddl_prueba();
                        Hide_Modal();
                    } else {
                        $("#Ddl_Prub").empty();

                        $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Prub");
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        var Mx_Exam = [
        {
            "ID_REL_PRU_EST": 0,
            "ID_EST": 0,
            "ID_PRUEBA": 0,
            "ID_ESTADO":0
        }
        ];

        function Ajax_Exam() {

            $.ajax({
                "type": "POST",
                "url": "Rel_Est_ExamSed.aspx/Llenar_Prueba",
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
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {

                }
            });
        }

        //-------------------------------------------------- AJAX ESTADO -------------------------------------------------------

        var JSON_Data_Table = [{
            "PAC_RUT": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "PAC_FNAC": "",
            "PRU_DESC": "",
            "CF_DESC": "",
            "ATE_AÑO": "",
            "ID_PACIENTE": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "ATE_RESULTADO": "",
            "ID_ATENCION": "",
            "ATE_RESULTADO_NUM": "",
            "ATE_RR_DESDE": "",
            "ATE_RR_HASTA": "",
            "ATE_RR_ALTOBAJO": "",
            "ATE_R_DESDE": "",
            "ATE_R_HASTA": "",
            "ATE_RESULTADO_ALT": "",
            "PROC_DESC": "",
            "ORD_DESC": "",
            "ATE_EST_VALIDA": "",
            "ID_CODIGO_FONASA": "",
            "ATE_DNI": "",
            "NAC_DESC": "",
            "PROGRA_DESC": "",
            "SECTOR_DESC": "",
            "ATE_NUM_INTERNO": "",
            "DOC_NOMBRE": "",
            "DOC_APELLIDO": "",
            "FONO": "",
            "numerico_es": ""
        }];

        function Call_Data_Table() {
            modal_show();
            console.log("into");
            var Data_Par = JSON.stringify({
                "DATE_str01": String($("#fecha2").val()),
                "DATE_str02": String($("#fecha3").val()),
                "ID_EST": $("#Programa").val(),
                "ID_PROC": $("#Ddl_LugarTM").val(),
                "ID_PREVE": $("#Ddl_Preve").val(),
                "ID_ESTADO": $("#Ddl_Estado").val()

            });

            $(".block_wait").fadeIn(500);
            AJAX_Data_Table = $.ajax({
                "type": "POST",
                "url": "Rel_Est_ExamSed.aspx/Call_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    if (response.d != "null") {
                        JSON_Data_Table = JSON.parse(response.d);
                        Hide_Modal();
                        $("#divTable01").show();

                        for (i = 0; i < JSON_Data_Table.length; ++i) {
                            let xVal = JSON_Data_Table[i].ATE_RESULTADO;
                            if (xVal.match(/^(\+|-)?[0-9]+((\.|,)[0-9]+)?$/gi) != null) {
                                var numerito = parseFloat(`${JSON_Data_Table[i].ATE_RESULTADO}`.replace(/,/g, "."));
                                JSON_Data_Table[i].ATE_RESULTADO = numerito;
                                JSON_Data_Table[i].numerico_es = 0;
                            }
                        }

                        Fill_DataTable();

                    } else {
                        Hide_Modal();
                        $("#divTable01").hide();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }


        function Call_Export() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DATE_str01": String($("#fecha2").val()),
                "DATE_str02": String($("#fecha3").val()),
                "ID_EST": $("#Programa").val(),
                "ID_PROC": $("#Ddl_LugarTM").val(),
                "ID_PREVE": $("#Ddl_Preve").val(),
                "ID_ESTADO": $("#Ddl_Estado").val()
            });

            AJAX_Data_Table = $.ajax({
                "type": "POST",
                "url": "Rel_Est_ExamSed.aspx/Call_Export",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    if (json_receiver != "null") {
                        Hide_Modal();
                        window.open(json_receiver, 'Download');

                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                }
            });
        }

        //Llenar DropDownList Examen
        //function Fill_Ddl_Exam() {
        //    $("#Ddl_Examen").empty();

        //    $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Examen");
        //    for (y = 0; y < Mx_Exam.length; ++y) {
        //        $("<option>", {
        //            "value": Mx_Exam[y].ID_REL_PRU_EST
        //        }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Examen");
        //    }
        //    pruebas_ddl();
        //};

        //Llenar DropDownList Prevision
        function Fill_Ddl_Prevision() {
            $("#Programa").empty();

            for (y = 0; y < Mx_Dtt_Prevision.length; ++y) {
                if (Mx_Dtt_Prevision[y].ID_EST == 6) {
                    $("<option>", {
                        "value": Mx_Dtt_Prevision[y].ID_EST
                    }).text(Mx_Dtt_Prevision[y].EST_EXA_DESC).appendTo("#Programa");
                }            
            }
        };
        function Fill_Ddl_prueba() {
            $("#Ddl_Prub").empty();


            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Prub");
            for (y = 0; y < arrData.length; ++y) {
                $("<option>", {
                    "value": arrData[y].ID_PRUEBA
                }).text(arrData[y].PRU_DESC).appendTo("#Ddl_Prub");
            }
        };

        //---------------------------------------------------- TABLA PACIENTE ------------------.........-----------------------------|
        function Fill_DataTable() {
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
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Folio"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Rut o DNI"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("DNI"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido  text-center" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Fono"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Programa"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sector"),
                    $("<th>", { "class": "textoReducido" }).text("Determinación"),
                    $("<th>", { "class": "textoReducido" }).text("Resultado"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Estado")
                    
                )
            );


            var nino = 0;
            var adulto = 0;

            var validado = 0;
            var en_spera = 0;

            var count = 0;
            for (i = 0; i < JSON_Data_Table.length; i++) {
                //if ((JSON_Data_Table[i].ID_CODIGO_FONASA == 459 && `${JSON_Data_Table[i].ATE_RESULTADO}`.replace(/,/g, ".") > 140) || (JSON_Data_Table[i].ID_CODIGO_FONASA == 103 && `${JSON_Data_Table[i].ATE_RESULTADO}`.replace(/,/g, ".") > 100) || (JSON_Data_Table[i].CF_DESC == "Perfil Bioquímico" && `${JSON_Data_Table[i].ATE_RESULTADO}`.replace(/,/g, ".") > 100) || (JSON_Data_Table[i].ID_CODIGO_FONASA == 676 && `${JSON_Data_Table[i].ATE_RESULTADO}`.replace(/,/g, ".") > 140)) {
                    var edades = 0;                                                                                             // && JSON_Data_Table[i].PROGRA_DESC == "EMBARAZADA"
                    count++;
                    $("#DataTable tbody").append(
                        $("<tr>").append(
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(count),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].ATE_NUM),
                            $("<td>").css("text-align", "center").text(function () {
                                if (JSON_Data_Table[i].PAC_RUT == "") {
                                    return JSON_Data_Table[i].ATE_DNI;
                                }
                                else {
                                    return JSON_Data_Table[i].PAC_RUT;
                                }
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].NAC_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PAC_NOMBRE + " " + JSON_Data_Table[i].PAC_APELLIDO),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                //Procesar datos de entrada
                                var date_xd = $.extend({}, JSON_Data_Table[i]).PAC_FNAC;
                                date_xd = String(date_xd).replace("/Date(", "");
                                date_xd = date_xd.replace(")/", "");

                                //Obtener valores
                                var obj_date = new Date(parseInt(date_xd));
                                var dd = parseInt(obj_date.getDate());
                                var MM = parseInt(obj_date.getMonth()) + 1;
                                var yy = parseInt(obj_date.getFullYear());

                                if (dd < 10) { dd = "0" + dd; }
                                if (MM < 10) { MM = "0" + MM; }

                                //var hh = parseInt(obj_date.getHours());
                                //var mm = parseInt(obj_date.getMinutes());

                                //if (hh < 10) { dd = "0" + dd; }
                                //if (mm < 10) { MM = "0" + MM; }

                                return String(dd + "/" + MM + "/" + yy);
                                //return String(dd + "/" + mm + "/" + yy + " " + hh + ":" + mm);
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                                var date_x = $.extend({}, JSON_Data_Table[i]).PAC_FNAC;
                                date_x = String(date_x).replace("/Date(", "");
                                date_x = date_x.replace(")/", "");

                                var total = ""
                                //Obtener valores
                                var obj_date = new Date(parseInt(date_x));
                                var dia = parseInt(obj_date.getDate());
                                var mes = parseInt(obj_date.getMonth()) + 1;
                                var ano = parseInt(obj_date.getFullYear());

                                if (dia < 10) { dia = "0" + dia; }
                                if (mes < 10) { mes = "0" + mes; }

                                // cogemos los valores actuales
                                var fecha_hoy = new Date();
                                var ahora_ano = fecha_hoy.getYear();
                                var ahora_mes = fecha_hoy.getMonth() + 1;
                                var ahora_dia = fecha_hoy.getDate();

                                // realizamos el calculo
                                var edad = (ahora_ano + 1900) - ano;
                                if (ahora_mes < mes) {
                                    edad--;
                                }
                                if ((mes == ahora_mes) && (ahora_dia < dia)) {
                                    edad--;
                                }
                                if (edad > 1900) {
                                    edad -= 1900;
                                }

                                // calculamos los meses
                                var meses = 0;
                                if (ahora_mes > mes) {
                                    meses = ahora_mes - mes;
                                }
                                if (ahora_mes < mes) {
                                    meses = 12 - (mes - ahora_mes);
                                }
                                if (ahora_mes == mes && dia > ahora_dia) {
                                    meses = 11;
                                }

                                // calculamos los dias
                                var dias = 0;
                                total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                if (ahora_dia > dia) {
                                    dias = ahora_dia - dia;
                                    total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                }
                                if (ahora_dia < dia) {
                                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                                    total = String(edad + " Años " + meses + " Meses " + dias + " Dias");
                                }
                                edades = edad;
                                return total;
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].FONO),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PROC_DESC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PROGRA_DESC),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].SECTOR_DESC),
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PRU_DESC),
                            $("<td>").css("text-align", "left").text(function () {
                                console.log("en la tabla");

                                if (JSON_Data_Table[i].numerico_es == 0) { //Declaraciones
                                    var Res_Num = JSON_Data_Table[i].ATE_RESULTADO_NUM;
                                    var Res_Str = JSON_Data_Table[i].ATE_RESULTADO;
                                    var Res_Alt = JSON_Data_Table[i].ATE_RESULTADO_ALT;

                                    //Evaluar
                                    if (Res_Num != null) {
                                        return Res_Num;
                                    } else if (Res_Str != null) {
                                        return Res_Str;
                                    } else {
                                        return Res_Alt;
                                    }
                                } else {
                                    return JSON_Data_Table[i].ATE_RESULTADO;
                                }


                                
                            }),
                            $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].DOC_NOMBRE + " " + JSON_Data_Table[i].DOC_APELLIDO),
                            $("<td>").css("text-align", "center").text(function () {
                                if (JSON_Data_Table[i].ATE_EST_VALIDA == 6 || JSON_Data_Table[i].ATE_EST_VALIDA == "6" || JSON_Data_Table[i].ATE_EST_VALIDA == 14 || JSON_Data_Table[i].ATE_EST_VALIDA == "14") {
                                    validado++;
                                    $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text("VALIDADO");
                                }
                                else  {
                                    en_spera++;
                                    $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text("EN ESPERA");
                                }
                            })
                           
                        )
                    );
                    if (edades <= 14) {
                        nino++;
                    } else {
                        adulto++;
                    }
                //}
                

            }
            //$("#nino").text(nino);
            //$("#adulto").text(adulto);
            $("#nino").text(en_spera);
            $("#adulto").text(validado);
            $(`#DataTable`).DataTable({
                "iDisplayLength": 25,
                "info": true,
                "bPaginate": true,
                "bFilter": true,
                "bSort": true,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se buscó en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            })

        }


        //Peticiones AJAX
        var Mx_DL_Programa = [
        {
            "ID_PROGRA": 0,
            "PROGRA_COD": "asdf",
            "PROGRA_DESC": "asdf",
            "ID_ESTADO": 0
        }
        ];
        function Ajax_DL_programa() {
            $.ajax({
                "type": "POST",
                "url": "ValoresCriticos_EMB.aspx/Llenar_DL_Programa",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Programa = JSON.parse(json_receiver);

                        $("#Programa").empty();
                        $("<option>", {
                            "value": 0
                        }).text("Todos").appendTo("#Programa");
                        for (y = 0; y < Mx_DL_Programa.length; ++y) {
                            $("<option>", {
                                "value": Mx_DL_Programa[y].ID_PROGRA
                            }).text(Mx_DL_Programa[y].PROGRA_DESC).appendTo("#Programa");
                        }
                    } else {
                    }
                },
                "error": function (response) {
                    var str_Error = "Error interno del Servidor";
                    console.log(response);
                }
            });
        }
    </script>
    <!--CSS del Form-->
    <style>
        #divToggle {
            width: 100%;
            height: 100%;
            display: flex;
            display: -webkit-flex;
            align-items: center;
            justify-content: flex-start;
            cursor: pointer;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -o-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

            #divToggle > i {
                padding-left: 15px;
                width: 72px;
                text-align: left;
            }
    </style>

    <style>
        /*Small devices (tablets, 768px and up)*/
        @media (min-width: 576px) {
            #divToggle {
                margin-top: 19px;
            }
        }

        @media (min-width: 768px) {
            #divToggle {
                margin-top: 0px;
            }
        }

        /*Medium devices (tablets, 768px and up)*/
        @media (min-width: 992px) {
            #Btn_Search, #Btn_Gen {
                margin-top: 19px;
            }

            #divToggle {
                margin-top: 16px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="p-2">
        <div class="card border-bar mb-3">
            <div class="card-header bg-bar">
                <h4 class="m-0">Búsqueda de Resultados - Orina Completa y Sedimento de Orina</h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <label for="Txt_Date01">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="Txt_Date02">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha3" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">    
                        <label>Procedencia</label>
                        <select id="Ddl_LugarTM" class="form-control form-control">
                            <%--<option value="0">Todos</option>--%>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label>Previsión</label>
                        <select id="Ddl_Preve" class="form-control form-control">
                            <%--<option value="0">Todos</option>--%>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Programa">Estadistica:</label>
                        <select id="Programa" class="form-control">
                            <option value="0">Seleccionar</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_Estado">Estado:</label>
                        <select id="Ddl_Estado" class="form-control">
                            <option value="0">Todos</option>
                            <option value="6">Validados</option>
                            <option value="1">En Espera</option>
                        </select>
                    </div>
                    
                    
                    <div class="col-lg">
                        <button type="button" id="Btn_Search" class="btn btn-block btn-buscar text-center">
                            <i class="fa fa-search" style="font-size: 1.5rem;"></i>
                            <span>Buscar</span>
                        </button>
                    </div>
                    <div class="col-lg">
                        <button type="button" id="Btn_Gen" class="btn btn-block btn-success text-center">
                            <i class="fa fa-file-excel-o" style="font-size: 1.5rem;"></i>
                            <span>Excel</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <div class="card mt-2 border-bar" id="divTable01">
            <div class="card-header bg-bar">
                <h4 class="m-0">Tabla de Resultados</h4>
            </div>
            <div class="card-body">
            <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">
                    
                        <div class="col-md-3 mb-1" style="margin-top:15px;">
                            <label>Cant. Exámenes en Espera:</label>
                        </div>
                        <div class="col-md-3 mb-1" style="margin-top:15px;">
                            <label id="nino"></label>
                        </div>
                        <div class="col-md-3 mb-1" style="margin-top:15px;">
                            <label>Cant. Exámenes Validados:</label>
                        </div>
                        <div class="col-md-3 mb-1" style="margin-top:15px;">
                            <label id="adulto"></label>
                        </div>
                    
                </div>
                <h5><i class="fa fa-fw fa-list"></i>Resultados de la Búsqueda</h5>
                <div class="row text-center" id="Paciente">
                    <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    <br />
                    <div id="Div_Tabla_Totales" style="width: 100%;" class="highlights"></div>
                </div>
            </div>
        </div>
    </div>

    <!--Modales-->
    <div id="mdlEmail" class="modal modal-sm">
        <div class="card">
            <div class="card-header text-center">
                <h2>Exportar</h2>
            </div>
            <div class="card-body pt-6 pb-6 text-left">
                <div class="form-group">
                    <label>Por favor introduzca su correo electrónico:</label>
                    <input type="text" id="Txt_Email" autocomplete="on" />
                </div>
            </div>
            <div class="card-footer text-right">
                <button type="button" id="Btn_Export" class="btn-success" disabled>
                    <i class="fa fa-check" aria-hidden="true"></i>
                    <span>Exportar</span>
                </button>
                <button type="button" class="btn-primary" data-dismiss="true">
                    <i class="fa fa-close" aria-hidden="true"></i>
                    <span>Cancelar</span>
                </button>
            </div>
        </div>
    </div>

    <div id="mdlEmail_2" class="modal modal-sm">
        <div class="card">
            <div class="card-header text-center">
                <h2>Exportar</h2>
            </div>
            <div class="card-body pt-6 pb-6 text-left">
                <p>El archivo Excel se está generando en 2do plano. Cuando el servidor termine de generar el archivo, éste será enviado al e-mail que indicó anteriormente.</p>
            </div>
            <div class="card-footer text-right">
                <button type="button" class="btn-primary" data-dismiss="true">
                    <i class="fa fa-check" aria-hidden="true"></i>
                    <span>Aceptar</span>
                </button>
            </div>
        </div>
    </div>
</asp:Content>
