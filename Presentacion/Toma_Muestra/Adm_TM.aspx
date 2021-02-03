<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Adm_TM.aspx.vb" Inherits="Presentacion.Adm_TM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script>
        //AJAAAAAAAAAAAAAAAAAAAAAAAAAAAAX
        //NO TOCAR NI MIRAR
        let Class_AJAX = function () {
            this.instance = null;
            this.url = "";
            this.success = () => { };
            this.error = (fail) => {
                Hide_Modal();
                $("#mdlError").modal("show");

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico");
                    $("#mdlTxt_Descr").text("Error en el Front End");
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
                    console.log(fail);
                }
            };
        };
        Class_AJAX.prototype.callback = function (data) {
            let objParam = {
                "type": "POST",
                "url": this.url,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": this.success,
                "error": this.error
            };

            if (data != null) {
                objParam["data"] = JSON.stringify(data);
            }

            this.instance = $.ajax(objParam);
        };
        //-------------------------------
        //AJAX INSTANCES-----------------
        let objAJAX_Print = new Class_AJAX();
        objAJAX_Print.success = (resp) => {
            console.log(resp);

            $(`#mdlPrint .modal-title`).html(resp.Status);
            $(`#mdlPrint .modal-body`).empty();
            if (resp.Code == 1000002) {
                $(`#mdlPrint .modal-body`).append(
                    $("<p>").html("Esta atención no posee exámenes pendientes.")
                );
            } else {
                $(`#mdlPrint .modal-body`).append(
                    $("<p>").html(resp.Message)
                );
            }

            $(`#mdlPrint`).modal();
        };
        //-------------------------------

        var XTIME = 1000;  //1 sec en milisec
        var SECS;
        var totalTiempo;
        var INTERVAL;
        var INTERVALCD;
        var id_ate;
        var n_ate;
        window.onload = function () {
            $("#txt_timer").val("15");
        };

        let AATTEE_NNUUMM = 0;
        $(document).ready(function () {
            $("#btn_pendiente").attr("disabled", "disabled");
            $("#btn_atendido").attr("disabled", "disabled");
            $("#btn_imprimir").attr("disabled", "disabled");

            $("#lbl_Act_Obs").val("");

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $("#Txt_Date02 input").val(dateNow);

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
            Llenar_Ddl_Estados();
            Llenar_Ddl_LugarTM();
            Ajax_DL_orden_ate();

            $("#btn_timer").on("click", function () {

                if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                    SECS = $("#txt_timer").val() * XTIME;
                    if ($("#btn_Play").find("i").is(".fa-pause")) {

                        FNAME();
                        clearInterval(INTERVAL);
                        clearInterval(INTERVALCD);
                        INTERVAL = setInterval(FNAME, SECS);

                        totalTiempo = $("#txt_timer").val();
                        updateReloj();
                    }
                }
            });

            $("#btn_Play").on("click", function () {
                if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                    //ajax bd
                    SECS = $("#txt_timer").val() * XTIME;
                    $(this).toggleClass("btn-success btn-danger");
                    $(this).find("i").toggleClass("fa-play fa-pause");
                    if ($(this).find("i").is(".fa-pause")) {

                        FNAME();
                        totalTiempo = $("#txt_timer").val();

                        clearInterval(INTERVAL);

                        INTERVAL = setInterval(FNAME, SECS);
                        updateReloj();
                    } else {

                        clearInterval(INTERVAL);
                        clearInterval(INTERVALCD);
                    }
                }
                else {

                }
            });
            $("#btn_Eti").click(() => {
                objAJAX_Print.url = "http://localhost:9990/Printer/Imp_Etiquetas";
                objAJAX_Print.callback([
                    id_ate
                ])
            });
            $("#btn_V_Ate").click(() => {
                objAJAX_Print.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
                objAJAX_Print.callback([
                    id_ate
                ])
            });
            $("#btn_TM").click(() => {
                objAJAX_Print.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
                objAJAX_Print.callback([
                    id_ate
                ])
            });



            ///////////////// pausa al clickear botones
            $("#btn_atendido").click(function () {
                Ajax_Update_Atendido();
                $("#span_est").text("ATENDIDO").css("color", "#28a745");
                $("#btn_atendido").attr("disabled", "disabled");
                $("#btn_pendiente").removeAttr("disabled");
            });
            $("#btn_pendiente").click(function () {
                Ajax_Update_Pendiente();
                $("#span_est").text("PENDIENTE").css("color", "#ffa837");
                $("#btn_pendiente").attr("disabled", "disabled");
                $("#btn_atendido").removeAttr("disabled");
            });
            $("#btn_imprimir").click(function () {
                $("#modal_print").modal();
            });


            $("#chk_Revisar").change(() => {
                let stat = $("#chk_Revisar").prop("checked");

                if (stat == true) {
                    $("#btn_imprimir").removeAttr("disabled");
                    $("#btn_pendiente").removeAttr("disabled");
                    $("#btn_atendido").removeAttr("disabled");
                } else {
                    $("#btn_imprimir").attr("disabled", "disabled");
                    $("#btn_pendiente").attr("disabled", "disabled");
                    $("#btn_atendido").attr("disabled", "disabled");
                }

            });
            $("#btn_BK").click(() => {
                window.open("http://bklab.cl/examenes3/", "_blank");
            });

            $("#btn_Act_Obs").click(() => {
                Act_Obs();
            });
        });

        function updateReloj() {
            document.getElementById('CuentaAtras').innerHTML = totalTiempo;

            if (totalTiempo == 0) {
                if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                    totalTiempo = $("#txt_timer").val();
                    updateReloj();
                }
                else {
                    totalTiempo = SECS / 1000;
                    updateReloj();
                }


            }
            else {
                /* Restamos un segundo al tiempo restante */
                totalTiempo -= 1;
                /* Ejecutamos nuevamente la función al pasar 1000 milisegundos (1 segundo) */
                INTERVALCD = setTimeout("updateReloj()", 1000);
            }
        }

        function FNAME() {
            Ajax_DataTable();

            if ($("#txt_timer").val() >= 15 && $("#txt_timer").val() <= 60) {
                SECS = $("#txt_timer").val() * XTIME;
            }
        }

        //Declaración de JSON
        var Mx_Ddl_LugarTM = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Ddl_Estados = [{
            "EST_DESCRIPCION": "",
            "EST_TM_ACTIVA": "",
            "ID_ESTADO": ""
        }];
        var Mx_DL_orden_ate = [{
            "ID_ORDEN": 0,
            "ORD_COD": "asdf",
            "ORD_DESC": "asdf",
            "ID_ESTADO": 0
        }];
        var Mx_Dtt = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "ATE_AÑO": "",
            "PROC_DESC": "",
            "ORD_DESC": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "PAC_FONO1": "",
            "PAC_MOVIL1": "",
            "SEXO_DESC": "",
            "ID_PACIENTE": "",
            "EST_DESCRIPCION": "",
            "ESPERA": "",
            "USU_NIC": "",
            "ATE_ID_ESTADO_TM": "",
            "DOCS_CANT": ""
        }];
        //AJAX DDL ESTADOS
        function Llenar_Ddl_Estados() {
            //Debug
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_Ddl_Estados",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_Estados = data.d;


                    Fill_Ddl_Estados();
                },
                "error": data => {
                    //Debug


                }
            });
        }
        //FILL DROPDOWNLIST ESTADO MANTENEDOR
        function Fill_Ddl_Estados() {
            Mx_Ddl_Estados.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_ESTADO
                    }
                ).text(aaa.EST_DESCRIPCION).appendTo("#Ddl_Estados");
            });
        }
        function Llenar_Ddl_LugarTM() {
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl_LugarTM = data.d;

                    Fill_Ddl_LugarTM();
                },
                "error": data => {
                    //Debug
                }
            });
        }

        function Fill_IMG_Fill(atetetete_nummmmmumumu) {
            AATTEE_NNUUMM = atetetete_nummmmmumumu;
            console.log("click!");
            Llenar_IMG();
            Llenar_Tabla_Muestra(AATTEE_NNUUMM);
        };

        $("img[name='show_img']").click(function () {
            let ii = $(this).attr("data-index");
            //Show_Image(ii)
            Show_Image_2(ii);
        });

        function Llenar_Tabla_Muestra(AN) {
            $("#table_Muestra tbody").empty();
            let Data_Par = JSON.stringify({
                "ATE_NUM": AN
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Get_Muestras",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {


                    data.d.forEach(aah=> {
                        $("<tr>").append(
                    $("<td>").text(aah.CF_COD),
                    $("<td>").text(aah.CF_DESC),
                    $("<td>").text(aah.MUESTRA)

                ).appendTo("#table_Muestra tbody");
                    });

                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                }
            });

        }


        function Show_Image_2(i) {
            let img = parseInt(i);// + 1;
            let Nombre_Doc_S;
            //$("#mod_Name").text(Nombre_Doc_S);
            $("#Mdl_Image_Ate_2 img").attr("src", "data:image/jpeg;base64," + Mx_IMG[i].IMG);
            $("#Mdl_Image_Ate_2 img").attr("name", "show_img_2");
            $("#Mdl_Image_Ate_2 img").attr("data-index", img);

            $("#modal_Imagenes .modal-footer").html("<button type='button' class='btn btn-danger' data-dismiss='modal'><i class='fa fa-fw fa-remove mr-2'></i>Cerrar</button>");




            //$("#Mdl_Image_Ate_2 .modal-footer").html("<button type='button' class='btn btn-warning' onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            //$("#Mdl_Image_Ate_2 img").attr("onClick", "Show_Image(" + img + ");");                                    FUNCION DE IMAGEN GRANDE <-------------------------------
            //$("#Mdl_Image_Ate_2 img").css("cursor", "pointer");
            //$("#Mdl_Image_Ate_2 .modal-footer").html("<button type='button' class='btn btn-warning'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            // onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'
            //$("#Mdl_Image_Ate").modal();
        }

        let Mx_IMG = [{
            "ID_FOTO_ATE": "",
            "IMG": "",
            "USU_NIC": "",
            "FECHA_ASOC": "",
            "FOTO_ATE_PLATAFORMA": ""
        }];

        function Llenar_IMG() {

            $("#Grid_Img").empty();
            let Data_Par = JSON.stringify({
                "ID_ATENCION": AATTEE_NNUUMM//$("#txt_Folio").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Get_Img",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {

                    Mx_IMG = data.d;
                    IIDD_AATTEE = 0;


                    //Debug
                    //if (Mx_IMG != null) {
                    Fill_IMG();
                    //}
                    //else {
                    //    AATTEE_NNUUMM = 0;
                    //Debug
                    //    Hide_Modal();
                    //}
                },
                "error": data => {
                    //Debug
                    AATTEE_NNUUMM = 0;
                    Hide_Modal();
                }
            });

        }

        let Mx_Dtt_Modal = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            ATE_DET_V_ID_ESTADO: "",
            EST_DESCRIPCION: "",
            CF_COD: "",
            CF_DESC: "",
            ID_CODIGO_FONASA: "",
            ID_ATENCION: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            ID_PROCEDENCIA: "",
            ATE_AÑO: "",
            SEXO_DESC: "",
            ID_PACIENTE: "",
            ID_SEXO: "",
            ID_ESTADO: "",
            PAC_RUT: "",
            PAC_FNAC: "",
            ATE_DET_V_PREVI: "",
            ATE_MES: "",
            ATE_DIA: "",
            TP_PAGO_DESC: "",
            DOC_NOMBRE: "",
            DOC_APELLIDO: "",
            PROGRA_DESC: "",
            ORD_DESC: "",
            ATE_DET_V_PAGADO: "",
            ATE_DET_V_COPAGO: "",
            ID_USUARIO: "",
            USUARIO_DET: "",
            REVE_DESC: "",
            USU_REV: "",
            USU_CRE: "",
            ATE_DET_RCAJA_ESTADO: "",
            ATE_DET_RCAJA_FECHA: "",
            ATE_DET_RCAJA_VALORD: "",
            ATE_DET_RCAJA_VALORU: "",
            ID_DET_ATE: "",
            ID_PREVE: "",
            ATE_DET_VALOR_BENEF: "",
            ATE_DET_VALOR_CS: "",
            DOCS_CANT: ""
        }];

        function Act_Obs() {
            //console.log("enter function");
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": $("#lblnate").text(),
                "OBS": $("#lbl_Act_Obs").val()
            });

            console.log(Data_Par);

            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Actualiza_Obs",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {

                    Hide_Modal();
                }
            });
        }

        function Ajax_DataTable_Folio_Modal(atetetete_nummmmmumumuummumumu) {
            //console.log("enter function");
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": atetetete_nummmmmumumuummumumu
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_DataTable_Modal",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Modal = json_receiver;
                        $("#Div_Tabla_Modal").empty();
                        Hide_Modal();
                        $("#lbl_tiiiitle").text("Listado de Documentos " + " " + "N° Atención: " + Mx_Dtt_Modal[0].ATE_NUM + " - " + "Pac. Nombre: " + Mx_Dtt_Modal[0].PAC_NOMBRE + " " + Mx_Dtt_Modal[0].PAC_APELLIDO);
                        //$("#lbl_pac_nom").text("N° Ate: " + Mx_Dtt_Modal[0].ATE_NUM);
                        //$("#lbl_ate_num").text("Pac. Nombre: " + Mx_Dtt_Modal[0].PAC_NOMBRE + " " + Mx_Dtt_Modal[0].PAC_APELLIDO);

                        Fill_DataTable_Modal();
                    } else {

                        $("#Div_Tabla_Modal").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {

                    Hide_Modal();
                }
            });
        }

        function Fill_IMG() {
            console.log("fill img");
            $("#modal_Imagenes .modal-footer").html("<button type='button' class='btn btn-danger' data-dismiss='modal'><i class='fa fa-fw fa-remove mr-2'></i>Cerrar</button>");
            Ajax_DataTable_Folio_Modal(AATTEE_NNUUMM);
            AATTEE_NNUUMM = 0;
            //$("#Grid_Img").empty();
            $("#Mdl_Image_Ate_2 img").attr("src", "");
            let count = 0;
            let count_div = 1;
            let D_Index = 0;
            let _D_Count = 1;
            $("#Grid_Img").append(
                $("<div id='div_Img_" + count_div + "' class='row mt-2 pl-4' style='max-width:calc(100% - 20px) !important'></div>")
                );

            if (Mx_IMG != null) {
                Mx_IMG.forEach((imgx) => {
                    if (imgx.IMG.length > 300) {
                        count += 1;
                        let _Plat;
                        if (imgx.FOTO_ATE_PLATAFORMA == 2) {
                            _Plat = "(PC)";
                        } else {
                            _Plat = "(APP)";

                        }
                        if (imgx.USU_NIC != null) {
                            Nombre_Doc = imgx.USU_NIC + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                        } else {
                            Nombre_Doc = "Web" + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                            _D_Count += 1;
                        }
                        $("#div_Img_" + count_div).append(
                        ("<div class='col gallery-docs'><img src='data:image/jpeg;base64," + imgx.IMG + "' class='mt-2' style='max-height:200px; max-width:150px; cursor:pointer;' name='show_img' data-index='" + D_Index + "'/><div class='row'><div class='col-lg text-center' style='height:56px'><label>" + Nombre_Doc + "</label></div</div></div>")
                        );

                        if (count == 5) {
                            count = 0;
                            count_div += 1;
                            $("#Grid_Img").append(
                            $("<div id='div_Img_" + count_div + "' class='row pl-4' style='max-width:calc(100% - 20px) !important'></div>")
                            );
                        }
                    }
                    D_Index += 1;
                    if (Mx_IMG.length == D_Index) {
                        let restt = 5 - count;
                        for (xx = 1; xx <= restt; xx++) {
                            $("#div_Img_" + count_div).append(
                                 ("<div class='col-lg'></div>")
                                );
                        }
                    }
                });
                $("img[name='show_img']").click(function () {
                    let ii = $(this).attr("data-index");
                    //Show_Image(ii)
                    Show_Image_2(ii);
                });
            }
            else {
                $("#Grid_Img").append(
                    $("<div class='mt-2 mb-2'>Atención sin documentos ingresados.</div>")
                    );
            }

            //$("img[name='show_img_2']").click(function () {
            //    let ii = $(this).attr("data-index");
            //    Show_Image(ii)
            //});

            //Hide_Modal();
            $("#modal_Imagenes").modal();
        }

        function Fill_Ddl_LugarTM() {
            var procee = Galletas.getGalleta("USU_ID_PROC");
            //var procee = 0;
            if (procee == 0) {
                $("<option>",
                {
                    "value": "0"
                }
                ).text("Todos").appendTo("#Ddl_LugarTM");
                Mx_Ddl_LugarTM.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            }
            else {
                Mx_Ddl_LugarTM.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }

                });
            }
        }
        function Ajax_DL_orden_ate() {
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_DL_ordenATE",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_orden_ate = json_receiver;
                        Fill_DL_orden_ate();
                    } else {
                    }
                },
                "error": function (response) {
                    var str_Error = "Error interno del Servidor";
                }
            });
        }
        function Fill_DL_orden_ate() {


            Mx_DL_orden_ate.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_ORDEN
                    }
                ).text(aaa.ORD_DESC).appendTo("#Ddl_Orden_Ate");
            });
        }

        function Ajax_DataTable() {

            var Data_Param = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "ID_ORD": $("#Ddl_Orden_Ate").val(),
                "ID_PROC": $("#Ddl_LugarTM").val(),
                "ID_ESTADO": $("#Ddl_Estados").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Llenar_DataTable",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#lblerror").text("");
                        Fill_Dtt();
                    } else {
                        $("#DataTable tbody").empty();
                        $("#lblerror").text("No se Encontraron Pacientes.").css("color", "red");
                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                }
            });
        }

        function Ajax_Update_Atendido() {

            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Estado_Atendido",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Ajax_DataTable();



                    } else {




                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";



                }
            });
        }
        function Ajax_Update_Pendiente() {

            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate
            });
            $.ajax({
                "type": "POST",
                "url": "Adm_TM.aspx/Update_Estado_Pendiente",
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Ajax_DataTable();



                    } else {




                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";



                }
            });
        }

        function Ajax_Print(urll) {
            console.log("ajax print");
            console.log("url: " + urll);
            console.log("ate: " + id_ate);
            var Data_Param = JSON.stringify({
                "ID_ATE": id_ate
            });
            $.ajax({
                "type": "POST",
                "url": urll,
                "data": Data_Param,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        console.log("SI");
                    } else {
                        console.log("NO");
                    }
                },
                "error": function (response) {
                    var str_Error = "Error interno del Servidor";
                    console.log(str_Error);

                }
            });
        }

        function Fill_Dtt() {

            $('#DataTable').dataTable().fnDestroy();
            $("#DataTable tbody").empty();
            var i = 0
            Mx_Dtt.forEach(aah => {
                var fecha = moment(aah.ATE_FECHA).format("DD-MM-YYYY hh:mm:ss");
                $("<tr>", {
                    "onclick": `Ajax_Redirect("` + i + `")`,
                    "class": "manito"
                }).attr("value", aah.ID_ATENCION).append(
                    $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(i + 1),
                    $("<td>").css("text-align", "center").text(aah.ATE_NUM),
                    $("<td>").text(aah.PAC_NOMBRE + " " + aah.PAC_APELLIDO),
                    $("<td>").text(aah.PROC_DESC),
                    $("<td>").css("text-align", "center").text(aah.ATE_AÑO + " Años"),
                    $("<td>").text(aah.ORD_DESC),
                    $("<td>").text(aah.USU_NIC),
                    $("<td>").css({
                        "text-align": "center",
                        "background": (function () {
                            var xTexto = aah.ESPERA

                            switch (xTexto.toUpperCase()) {
                                case "ESPERA":
                                    return "#ffdaaa";
                                case "PENDIENTE":
                                    return "#a9d1fc";
                                default:
                                    return "#9bffb1";
                            }
                        }())
                    }).text(aah.ESPERA),
                    $("<td>").css("text-align", "center").text(fecha),
                    $("<td>").css("text-align", "center").text(function () {
                        //if (aah.DOCS_CANT == 0) {
                        //$(this).append("<button type='button' disabled='disabled' class='btn btn-secondary btn-sm'><i class='fa fa-fw fa-file-text mr-2'></i>Ver Orden</button>");
                        //} else {
                        $(this).append("<button type='button' class='btn btn-limpiar btn-sm' onclick='Fill_IMG_Fill(" + aah.ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver Orden</button>");
                        //}
                    })

                ).appendTo("#DataTable tbody");
                i += 1;

            });
            $("#span_num_pac").text(Mx_Dtt.length);
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
            $("th").removeClass("sorting_asc");
        }
        function Ajax_Redirect(pos) {
            id_ate = Mx_Dtt[pos].ID_ATENCION;
            n_ate = Mx_Dtt[pos].ATE_NUM;

            $("#lblnate").text(Mx_Dtt[pos].ATE_NUM);
            $("#lblnom").text(Mx_Dtt[pos].PAC_NOMBRE + " " + Mx_Dtt[pos].PAC_APELLIDO);
            $("#lbledad").text(Mx_Dtt[pos].ATE_AÑO + " AÑOS");
            $("#lblsexo").text(Mx_Dtt[pos].SEXO_DESC.toUpperCase());
            $("#lblfono").text(Mx_Dtt[pos].PAC_FONO1);
            $("#lblcelu").text(Mx_Dtt[pos].PAC_MOVIL1);
            $("#lbl_Act_Obs").val(Mx_Dtt[pos].OBS);
            $("#span_est").text(Mx_Dtt[pos].ESPERA);
            if (Mx_Dtt[pos].ESPERA == "ESPERA") {
                $("#span_est").css("color", "#ffdaaa");
                $("#chk_Revisar").prop("checked", false);
                $("#btn_imprimir").attr("disabled", "disabled");
                $("#btn_pendiente").attr("disabled", "disabled");
                $("#btn_atendido").attr("disabled", "disabled");
                $("#chk_Revisar").removeAttr("disabled");
            }
            else if (Mx_Dtt[pos].ESPERA == "ATENDIDO") {
                $("#span_est").css("color", "#9bffb1");
                $("#btn_pendiente").removeAttr("disabled");
                $("#btn_atendido").attr("disabled", "disabled");
                $("#chk_Revisar").prop("checked", true);
                $("#btn_imprimir").removeAttr("disabled");
                $("#chk_Revisar").attr("disabled", "disabled");
            }
            else {
                $("#span_est").css("color", "#a9d1fc");
                $("#btn_atendido").removeAttr("disabled");
                $("#chk_Revisar").prop("checked", true);
                $("#btn_pendiente").attr("disabled", "disabled");
                $("#chk_Revisar").attr("disabled", "disabled");
            }


        }
        function AJAX_REQ() {
            var dataParam = [
              id_ate
            ];
            function AR_Success() {


                var str_Error = "La impresión se ha completado exitosamente."

                $("#mError_AAH h4").text("Impresión Correcta");
                $("#mError_AAH button").attr("class", "btn btn-success");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
            }
            function AR_Error() {


                var str_Error = "No se a detectado ninguna interface de impresión abierta. Abra IRISLAB_PRINT o " // o de lo contrario descargelo AQUI
                str_Error += "descargue la aplicación aquí <a href='" + window.origin + "/Iris_Print/Setup.exe'>DESCARGAR</a>";

                $("#mError_AAH h4").text("Error");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").html(str_Error);
                $("#mError_AAH").modal();
            }


            var AR_Eti = new Iris_Print(dataParam, AR_Success, AR_Error);
            AR_Eti.imp_Etiquetas();
        };
    </script>
    <style>
        #DataTable {
            border-collapse: collapse;
        }

        /*#DataTable thead {
                background-color: #46963f;
                color: white;
                height: 1.5rem;
            }

                #DataTable thead th {
                    padding: .75rem !important;
                }*/

        #lblnate, #lblnom, #lbledad, #lblsexo, #lblfono, #lblcelu {
            color: #015457;
        }

        #DataTable thead {
            background-color: #155fa0;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal_print" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Imprimir Documentos</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-4 text-center">
                            <button type="button" class="btn btn-print btn-block mt-2" id="btn_Eti">Imprimir Etiquetas</button>
                        </div>
                        <div class="col-lg-4 text-center">
                            <button type="button" class="btn btn-print btn-block mt-2" id="btn_V_Ate">Voucher Atención</button>
                        </div>
                        <div class="col-lg-4 text-center">
                            <button type="button" class="btn btn-print btn-block mt-2" id="btn_TM">Voucher Toma Muestra</button>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Galeria de Imagenes -->
    <div id="modal_Imagenes" class="modal fade" role="dialog" style="max-height: 90vh; min-height: 89vh">
        <div class="modal-dialog" style="max-width: 98vw; max-height: 90vh; min-height: 89vh">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="text-align: center;" id="lbl_tiiiitle">Listado de Documentos</h4>
                </div>
                <div class="modal-body">
                    <div>
                        <%--                        <h5 id="lbl_pac_nom"></h5>
                        <br />
                        <h5 id="lbl_ate_num"></h5>--%>
                        <div class="row">
                            <div class="col-lg">
                                <div class="card border-bar mb-3">
                                    <div class="card-header text-center bg-bar">
                                        <h5 class="m-0"><i class="fa fa-picture-o fa-fw"></i>Galería</h5>
                                    </div>
                                    <div class="card-body p-0" style="background-color: #f5f5f5">
                                        <div id="Grid_Img" class="text-center" style="max-height: 500px;"></div>
                                    </div>
                                </div>
                                <div id="Div_Tabla_Modal" style="overflow: auto;">
                                </div>
                            </div>
                            <div class="col-lg">
                                <div id="Mdl_Image_Ate_2" class="col-lg">
                                    <h3 class="modal-title w-100" id="mod_Name_2"></h3>
                                    <img src="" style="max-width: 50vw; max-height: 90vh;" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-lg-5">
                            <table class="w-100 table table-hover table-striped table-iris no-footer dataTable" cellspacing="0" id="table_Muestra">
                                <thead>
                                    <tr>
                                        <th>Código
                                        </th>
                                        <th>Examen
                                        </th>
                                        <th>Muestra
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-lg-12">
                            <label class="text-danger">
                                <input type="checkbox" id="chk_Revisar" />
                                Revisé los exámenes y muestras que se presentan en la órden o en la tabla. 
                            </label>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" id="btn_Marcar_Modal" class="btn btn-limpiar"><i class="fa fa-crosshairs fa-fw"></i>Marcar</button>--%>
                    <%--<button type='button' id="btn_desvincular_modal" class='btn btn-warning'>Desvincular</button>--%>
                    <button type="button" class="btn btn-danger" id="btn_cerrrrarrrrrrrr_modalll" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h3 style="text-align: center; padding: 5px;">Administración de Toma de Muestra</h3>
        </div>
        <div class="row" style="margin-top: 15px; margin-left: 0px !important; margin-right: 0px !important;">
            <div class="col-lg-10">
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
                        <label for="fecha">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_LugarTM">Lugar de TM</label>
                        <select id="Ddl_LugarTM" class="form-control">
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_Orden_Ate">Orden de Atención</label>
                        <select id="Ddl_Orden_Ate" class="form-control">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="Ddl_Estados">Estados</label>
                        <select id="Ddl_Estados" class="form-control">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-lg-2">
                        <button type="button" class="btn btn-info" id="btn_BK">Toma de Muestra BK</button>
                    </div>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">
                    <div class="col-lg">
                        <label for="txt_timer">Tiempo de Refresco:</label>
                        <div class="row">
                            <div class="col">
                                <input id="txt_timer" type="number" class="form-control" min="15" max="60" />
                            </div>
                            <div class="col text-center">
                                <h2 id="CuentaAtras">00</h2>
                            </div>
                        </div>

                        <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">
                            <div class="col">
                                <button type="button" id="btn_timer" class="btn btn-block btn-buscar">Actualizar</button>
                            </div>
                            <div class="col">
                                <button type="button" id="btn_Play" class="btn btn-block btn-success active"><i class="fa fa-w fa-play btnplay"></i></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h4 class="text-center">Datos del Paciente Seleccionado</h4>
        <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">

            <div class="col-lg">
                <label for="lblnate">N° Atención: <b><span id="lblnate"></span></b></label>

            </div>
            <div class="col-lg-4">
                <label for="lblnom">Nombre: <b><span id="lblnom"></span></b></label>

            </div>
            <div class="col-lg">
                <label for="lbledad">Edad: <b><span id="lbledad"></span></b></label>

            </div>
            <div class="col-lg">
                <label for="lblsexo">Sexo: <b><span id="lblsexo"></span></b></label>

            </div>
            <div class="col-lg">
                <label for="lblfono">Teléfono: <b><span id="lblfono"></span></b></label>

            </div>
            <div class="col-lg">
                <label for="lblcelu">Celular: <b><span id="lblcelu"></span></b></label>

            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                Observación Atención:
            </div>
            <div class="col-lg-5">
                <input type="text" class="form-control" id="lbl_Act_Obs" />
            </div>
            <div class="col-lg-3">
                <button type="button" class="btn btn-primary" id="btn_Act_Obs">Actualizar</button>
            </div>

        </div>
        <hr />
        <div class="row mb-3" style="overflow: auto; max-height: 50vh; margin-left: 0px !important; margin-right: 0px !important;">
            <div class="col-12">
                <h4 class="text-center">Listado de Pacientes</h4>
                <table id="DataTable" cellspacing="0" class="w-100 table table-hover table-striped table-iris">
                    <thead>
                        <tr>
                            <th class="text-center">#</th>
                            <th class="text-center">N° Atención</th>
                            <th>Nombre Paciente</th>
                            <th>Lugar de TM</th>
                            <th class="text-center">Edad</th>
                            <th>Orden</th>
                            <th>Usuario</th>
                            <th class="text-center">Estado</th>
                            <th class="text-center">Fecha</th>
                            <th class="text-center">Ver Orden</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-lg text-center mb-3">
                <h5 id="lblerror"></h5>
            </div>
        </div>
        <div class="row" style="margin-left: 0px !important; margin-right: 0px !important;">
            <div class="col-lg">
                <h5>N° de Pacientes: <b><span id="span_num_pac" style="color: red"></span></b></h5>
            </div>
            <div class="col-lg">
                <h5>Estado: <b><span id="span_est"></span></b></h5>
            </div>
            <div class="col-lg">
                <button type="button" id="btn_atendido" class="btn btn-success btn-block m-1"><i class="fa fa-fw fa-check"></i>Atendido</button>
            </div>
            <div class="col-lg">
                <button type="button" id="btn_pendiente" class="btn btn-pendiente btn-block m-1"><i class="fa fa-fw fa-clock-o"></i>Pendiente</button>
            </div>
            <div class="col-lg">
                <button type="button" id="btn_imprimir" class="btn btn-print btn-block m-1"><i class="fa fa-fw fa-print"></i>Imprimir</button>
            </div>
        </div>
    </div>

    <!-- Modales -->

    <div id="mdlPrint" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Impresión</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p>Impresión finalizada correctamente</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Aceptar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlError" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ERROR</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <div>
                        <strong>Tipo de Error: </strong>
                        <p id="mdlTxt_Type"></p>
                        <br />
                    </div>
                    <div>
                        <strong>Descripción: </strong>
                        <p id="mdlTxt_Descr"></p>
                        <br />
                    </div>
                    <div>
                        <strong>Pila de Seguimiento: </strong>
                        <code id="mdlTxt_StackT"></code>
                        <br />
                    </div>
                    <div>
                        <strong>Póngase en contacto con IrisLab para asistencia técnica.</strong>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Aceptar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
