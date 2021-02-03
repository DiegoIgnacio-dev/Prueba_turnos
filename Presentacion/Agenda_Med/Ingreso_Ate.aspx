<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_Ate.aspx.vb" Inherits="Presentacion.Ingreso_Ate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../js/Deep-Copy.js"></script>
    <%--<script src="js/Deep-Copy.js"></script>--%>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

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
        //Class AJAX---------------------------------------------------------------------
        let Class_AJAX = function () {
            this.url = "";
            this.success = () => { };
            this.error = () => { };
        };
        Class_AJAX.prototype.callback = function (data) {
            $.ajax({
                "type": "POST",
                "url": this.url,
                "data": JSON.stringify(data),
                "contentType": "application/json;  charset=utf-8",
                "contentType": "text/plain;  charset=utf-8",
                "dataType": "json",
                //"timeout": 20000,
                "success": this.success,
                "error": this.error
            });
        };

        let timer = 5000;
        let objAJAX_Atenc = new Class_AJAX();
        objAJAX_Atenc.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
        objAJAX_Atenc.success = (resp) => {
            console.log(`[ OK ] Impresión Voucher Atención`);
            console.log(resp);
            console.log(``);

            //let str_Error = `La impresión de Comprobante de Atención se ha completado exitosamente, `;
            //str_Error += `iniciando Impresión de Etiquetas.`;
            //$("#title").text("Solicitud de Voucher");
            //$("#button_modal").attr("class", "btn btn-success");
            //$("#mError_AAH p").text(str_Error);
            //$("#mError_AAH").modal("show");
            
            //setTimeout(() => {
                $("#mError_AAH").modal(`hide`);

                objAJAX_Etiq.callback([
                    Mx_Dt023.ID_Atencion
                ]);
            //}, timer);

        };
        objAJAX_Atenc.error = (fail) => {
            console.log(`[ERROR] Impresión Voucher Atención`);
            console.log(fail);
            console.log(``);

            objAJAX_Etiq.callback([
                Mx_Dt023.ID_Atencion
            ]);
        };

        let objAJAX_Etiq = new Class_AJAX();
        objAJAX_Etiq.url = "http://localhost:9990/Printer/Imp_Etiquetas";
        objAJAX_Etiq.success = (resp) => {
            console.log(`[ OK ] Impresión Etiquetas`);
            console.log(resp);
            console.log(``);

            //let str_Error = `La impresión de Etiquetas se ha completado exitosamente, `;
            //str_Error += `iniciando Impresión de Etiquetas.`;
            //$("#title").text("Solicitud de Etiquetas");
            //$("#button_modal").attr("class", "btn btn-success");
            //$("#mError_AAH p").text(str_Error);
            //$("#mError_AAH").modal("show");
            
            //setTimeout(() => {
                $("#mError_AAH").modal(`hide`);

                objAJAX_Proc.callback([
                    Mx_Dt023.ID_Atencion
                ]);
            //}, timer);

        };
        objAJAX_Etiq.error = (fail) => {
            console.log(`[ERROR] Impresión Voucher Atención`);
            console.log(fail);
            console.log(``);

            objAJAX_Etiq.callback([
                Mx_Dt023.ID_Atencion
            ]);
        };

        let objAJAX_Proc = new Class_AJAX();
        objAJAX_Proc.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
        objAJAX_Proc.success = (resp) => {
            console.log(`[ OK ] Impresión Voucher LugarTM`);
            console.log(resp);
            console.log(``);

            let str_Error = `La impresión de Voucher y Etiquetas se ha completado exitosamente. `;
            str_Error += `Impresiones Finalizadas.`;
            $("#title").text("Impresiones Finalizadas");
            $("#button_modal").attr("class", "btn btn-success");
            $("#mError_AAH p").text(str_Error);

            $("#mError_AAH").modal("show");

            setTimeout(() => {
                $("#mError_AAH").modal(`hide`);
            }, timer);
        };
        objAJAX_Proc.error = (fail) => {
            console.log(`[ERROR] Impresión Voucher Atención`);
            console.log(fail);
            console.log(``);

            objAJAX_Etiq.callback([
                Mx_Dt023.ID_Atencion
            ]);
        };

        //-------------------------------------------------------------------------------

        let initializing = true;
        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
        var xId = 0;
        var selected = new Array();
        var verrut = 0;
        var ids = new Array();
        var hh = 0;
        var hh2 = 0;
        var hh3 = 0;
        var sifi = 0;
        var checked_rdn = 0;
        $(document).ready(function () {

            $("#btnInstructivos").click(() => {
                window.open("http://www.laboratorioaleman.cl/examenesprestaciones/examenes/indicaciones/", '_blank');
            });

            $("#dni").hide();
            $("#Naten").hide();
            if ($('#XXXXXXXX').length) {
                var scrollTrigger = 100, // px
                    backToTop = function () {
                        var scrollTop = $(window).scrollTop();
                        if (scrollTop > scrollTrigger && $("#Nom").val() != "") {

                            if ($("#checkBox999").is(':checked')) {
                                console.log("rut checked");
                                $("#xxx_xxx").text("Rut: " + $("#rut").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                            }
                            else if ($("#checkBox888").is(':checked')) {
                                console.log("dni checked");
                                $("#xxx_xxx").text("D.N.I: " + $("#dni").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                            }
                            else if ($("#checkBox8887").is(':checked')) {
                                console.log("nate checked");
                                $("#xxx_xxx").text("Folio: " + $("#Naten").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
                            } 

                            
                            $('#XXXXXXXX').addClass('show');
                        } else {
                            $('#XXXXXXXX').removeClass('show');
                        }
                    };
                backToTop();
                $(window).on('scroll', function () {
                    backToTop();
                });
            }

            $("#button_modal_pago").click(function () {


                if (Mx_Dt023.length != 0) {

                    objAJAX_Atenc.callback([
                         Mx_Dt023.ID_Atencion
                    ]);
                }
            });

            $(`#Procedencia`).change(() => {
                fn_Req_Prev();
            });

            $(`#Prevision`).change(() => {
                fn_Req_Prog();
            });

            $(`#Programa`).change(() => {
                fn_Req_SubP();
            });

            $("#Cuidad").change(() => {
                fn_Req_Comuna();
            });

            Ajax_DL_SEXO();
            Ajax_DL_NAC();
            //Ajax_Ciudad();
            Call_AJAX_Ddl();
            fn_Req_Ciud();
            Ajax_DL_sec();
            Ajax_DL_TP_ATE();
            Ajax_DL_orden_ate();
            Ajax_DL_DOC();
            Ajax_Diagnostico();
            $("#checkBox2").prop('checked', false);//solo los del objeto
            $("#checkBox999").prop('checked', true);
            $("#checkBox999").change(function () {
                if ($(this).is(':checked')) {
                    $("#checkBox888").prop('checked', false);
                    $("#checkBox8887").prop('checked', false);
                    $("#rut").show();
                    $("#dni").hide();
                    $("#Naten").hide();
                }
            });
            $("#checkBox888").change(function () {
                if ($(this).is(':checked')) {
                    $("#checkBox999").prop('checked', false);
                    $("#checkBox8887").prop('checked', false);
                    $("#rut").hide();
                    $("#dni").show();
                    $("#Naten").hide();
                }
            });
            $("#checkBox8887").change(function () {
                if ($(this).is(':checked')) {
                    $("#checkBox999").prop('checked', false);
                    $("#checkBox888").prop('checked', false);
                    $("#rut").hide();
                    $("#dni").hide();
                    $("#Naten").show();
                }
            });



            $('#FUR').attr("disabled", true);

            $('#checkBox2').attr("disabled", true);

            $("#fur").css("pointer-events", "none");
            var f = moment().format("YYYY-MM-DD");
            $("#fecha").val(f);
            $("#FUR").val(f);


            /////-*-*-*-*-*-*-*-*-*-*-*-*-*
            $("<table>", {
                "id": "DataTable_pac2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla3");

            $("#DataTable_pac2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pac2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_pac2 thead").attr("class", "cabzera");
            $("#DataTable_pac2 thead").append(
                $("<tr>").append(
                   $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
                   $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                   //$("<th>", { "class": "textoReducido text-center" }).text("Valor a Pagar"),
                   $("<th>", { "class": "textoReducido text-center" }).text("Dias Proceso"),
                   $("<th>", { "class": "textoReducido" }).text(""),
                   $("<th>", { "class": "textoReducido" }).text("Cambio de Estado")
                )
            );
            add_row();


            //-*-*-*-*-*-*-*-*-*-*-*-*-*
            $("#Btnnew").click(function () {
                Ajax_DL_SEXO();
                Ajax_DL_NAC();
                //Ajax_Ciudad();
                fn_Req_Ciud();
                $("#checkBox2").prop('checked', false);
                $('#FUR').attr("disabled", true);
                $('#checkBox2').attr("disabled", true);
                $("#fur").css("pointer-events", "none");
                var f = moment().format("DD-MM-YYYY");
                $("#fecha").val(f);
                $("#fecha2").val(f);
                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");
                $('#rut').val("");
                $('#dni').removeAttr("disabled");
                $('#dni').val("");
                $("#Nom").val("");
                $("#Interno").val("");
                $("#Ape").val("");
                $("#Edad").val("");
                $("#telfijo").val("");
                $("#Celular").val("");
                $("#Email").val("");
                $("#direccion").val("");
                Mx_Dtt_examcof.length = 0;
                $("#DataTable_pac2 tbody").empty();
                add_row();
                verrut = 0;
                Mx_Dtt2.length = 0;
                var str_Error = "Campos listo para el ingreso del nuevo paciente: "
                $("#title").text("Nuevo Paciente");
                $("#button_modal").attr("class", "btn btn-success");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                $('#XXXXXXXX').removeClass('show');

                //Actualizar Posición Ddl
                let xVal = 0;
                if ($("#chkMant_0").prop("checked") == false) {
                    xVal = $("#Procedencia option").eq(0).val();
                    $("#Procedencia").val(
                        parseInt(xVal)
                    );
                }

                setTimeout(() => {
                    if ($("#chkMant_3").prop("checked") == false) {
                        xVal = $("#Prevision option").eq(0).val();
                        $("#Prevision").val(
                            parseInt(xVal)
                        );
                    }

                    setTimeout(() => {
                        if ($("#chkMant_1").prop("checked") == false) {
                            fn_Req_Prog();
                            xVal = $("#Programa option").eq(0).val();
                            $("#Programa").val(
                                parseInt(xVal)
                            );
                        }

                        setTimeout(() => {
                            if ($("#chkMant_2").prop("checked") == false) {
                                fn_Req_SubP();
                                xVal = $("#Ddl_Prog02 option").eq(0).val();
                                $("#Ddl_Prog02").val(
                                    parseInt(xVal)
                                );
                            }
                        }, 1000);
                    }, 1000);
                }, 1000);
            });
            $("#fecha").change(function () {
                var asd = moment($("#fecha").val()).format("DD-MM-YYYY");



                var array = asd.split("-");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años " + meses + " meses " + dias + " dia");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años " + meses + " meses " + dias + " dia");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años " + meses + " meses " + dias + " dia");
                }
                $("#Edad").val(total);

            });
            $("#sex").change(function () {
                var sex = $("#sex option:selected").text();
                if (sex == "Femenino") {
                    $('#checkBox2').removeAttr("disabled");
                    var HXH = 0;
                    for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                        if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                            HXH = 1;
                        }
                    }
                    if (HXH == 1 && $("#sex").val() == 2 && sifi == 0) {
                        var str_Error = "Por favor Rellenar el campo F.U.R"
                        $("#title").text("Recordatorio");
                        $("#button_modal").attr("class", "btn btn-success");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        $('#XXXXXXXX').removeClass('show');
                        sifi = 1;
                    }
                } else {

                    $('#checkBox2').attr("disabled", true);
                    $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
                    $('#FUR').attr("disabled", true);
                    $("#fur").css("pointer-events", "none");
                    $("#FUR").val(f);
                }

                if (Mx_Dtt_exam02_respaldo.length > 0) {
                    if ($("#sex").val() == 2) {

                        var xxxer = false;
                        for (z = 0; z < Mx_Dtt_examcof.length; z++) {

                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1405) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }

                        }
                        if (xxxer == true) {
                            for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1406) {
                                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                }
                            }
                            fill_llenado_tabla()
                        }

                    }



                    if ($("#sex").val() == 1) {

                        var xxxer = false;
                        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                            //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1406) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }
                            //}
                        }
                        if (xxxer == true) {
                            for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                                if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1405) {
                                    Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02_respaldo[x]));
                                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                                }
                            }
                            fill_llenado_tabla()
                        }

                    }
                    if ($("#sex").val() == 0) {

                        var xxxer = false;
                        for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                            //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                            if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 690 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 691 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1405 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1406) {
                                Mx_Dtt_examcof.splice(z, 1);
                                xxxer = true;
                            }
                            fill_llenado_tabla();
                            //}
                        }
                    }
                }
            });
            $("#dni").focusout(function () {

                if ($("#dni").val() == "") {
                    var str_Error = "Ingrese un D.N.I Por favor.";
                    $("#mError_AAH h5").text("Error:");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                    $('#XXXXXXXX').removeClass('show');

                    $("#rut").val("");
                    $("#rut").css({
                        "border-color": "red"
                    });

                } else {
                    $("#dni").css({
                        "border-color": "green"
                    });
                    Ajax_busca_dni();
                }
            });

            $("#Naten").keydown(function EnterEvent(e) {
                if (e.keyCode == 13) {
                 
                    Ajax_modal_exa();
                }
            });
            $("#checkBox2").change(function () {
                if ($(this).is(':checked')) {
                    $("#FUR").removeAttr('disabled');
                    $("#fur").css("pointer-events", "auto");
                } else {
                    $('#FUR').attr("disabled", true);
                    $("#fur").css("pointer-events", "none");
                    $("#FUR").val(f);
                }
            });
            $("#rut").focusout(function () {
                if ($("#rut").val() != "") {
                    //Capturar Anáqlisis del RUT
                    var obj_RUT = Valid_RUT($("#rut").val());
                    if (obj_RUT.Valid == false) {
                        var str_Error = "El RUT ingresado no es Válido, ";
                        str_Error += "ingrese en el campo de texto un RUT válido.";

                        $("#mError_AAH h5").text("Error:");
                        $("#button_modal").attr("class", "btn btn-danger");
                        1
                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        $('#XXXXXXXX').removeClass('show');

                        $("#rut").val("");
                        $("#rut").css({
                            "border-color": "red"
                        });
                    } else {
                        $("#rut").css({
                            "border-color": "green"
                        });
                        $("#rut").val(obj_RUT.Format);
                        Ajax_busca_rut();
                    }
                }
            });

            $("#rut").keydown(function EnterEvent(e) {
                if (e.keyCode == 13) {

                    if ($("#rut").val() != "") {
                        //Capturar Anáqlisis del RUT
                        var obj_RUT = Valid_RUT($("#rut").val());
                        if (obj_RUT.Valid == false) {
                            var str_Error = "El RUT ingresado no es Válido, ";
                            str_Error += "ingrese en el campo de texto un RUT válido.";

                            $("#mError_AAH h5").text("Error:");
                            $("#button_modal").attr("class", "btn btn-danger");
                            1
                            $("#mError_AAH p").text(str_Error);
                            $("#mError_AAH").modal();
                            $('#XXXXXXXX').removeClass('show');

                            $("#rut").val("");
                            $("#rut").css({
                                "border-color": "red"
                            });
                        } else {
                            $("#rut").css({
                                "border-color": "green"
                            });
                            $("#rut").val(obj_RUT.Format);
                            Ajax_busca_rut();
                        }
                    }
                }
            });

            $("#Prevision").change(function () {
                Mx_Dtt_exam02.length = 0;
                Ajax_DataTable_examen02();
                $("#DataTable_pac2 tbody").empty();
                add_row();
            });



            $("#BtnSaveAll").click(function () {
                var sum = 0;

                if ($("#Nom").val() == "") {

                    $("#Nom").css({
                        "border-color": "red"
                    });
                    $("#Nom").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Nom").css({
                        "border-color": "#ccc"
                    });
                    $("#Nom").parent().css({
                        "color": "#212529"
                    });
                }

                //if ($("#Interno").val() == "") {

                //    $("#Interno").css({
                //        "border-color": "red"
                //    });
                //    $("#Interno").parent().css({
                //        "color": "red"
                //    });
                //} else {
                //    sum += 1;
                //    $("#Interno").css({
                //        "border-color": "#ccc"
                //    });
                //    $("#Interno").parent().css({
                //        "color": "#212529"
                //    });
                //}


                if ($("#Ape").val() == "") {

                    $("#Ape").css({
                        "border-color": "red"
                    });
                    $("#Ape").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Ape").css({
                        "border-color": "#ccc"
                    });
                    $("#Ape").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Edad").val() == "") {

                    $("#fecha").css({
                        "border-color": "red"
                    });
                    $("#fecha").parent().parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#fecha").css({
                        "border-color": "#ccc"
                    });
                    $("#fecha").parent().parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#sex").val() == 0) {

                    $("#sex").css({
                        "border-color": "red"
                    });
                    $("#sex").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#sex").css({
                        "border-color": "#ccc"
                    });
                    $("#sex").parent().css({
                        "color": "#212529"
                    });
                }

                if ($("#Nacio").val() == 0) {

                    $("#Nacio").css({
                        "border-color": "red"
                    });
                    $("#Nacio").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Nacio").css({
                        "border-color": "#ccc"
                    });
                    $("#Nacio").parent().css({
                        "color": "#212529"
                    });
                }
                if ($("#Cuidad").val() == 0) {

                    $("#Cuidad").css({
                        "border-color": "red"
                    });
                    $("#Cuidad").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Cuidad").css({
                        "border-color": "#ccc"
                    });
                    $("#Cuidad").parent().css({
                        "color": "#212529"
                    });
                }
                if ($("#Comuna").val() == 0) {

                    $("#Comuna").css({
                        "border-color": "red"
                    });
                    $("#Comuna").parent().css({
                        "color": "red"
                    });
                } else {
                    sum += 1;
                    $("#Comuna").css({
                        "border-color": "#ccc"
                    });
                    $("#Comuna").parent().css({
                        "color": "#212529"
                    });
                }

                //if ($("#sub_atencion").val() == 0) {

                //    $("#sub_atencion").css({
                //        "border-color": "red"
                //    });
                //    $("#sub_atencion").parent().css({
                //        "color": "red"
                //    });
                //} else {
                //    if ($("#sub_atencion").val() == 1) {
                //        if ($("#Total").val() == 0) {
                //            $("#sub_atencion").css({
                //                "border-color": "red"
                //            });
                //            $("#sub_atencion").parent().css({
                //                "color": "red"
                //            });
                //        } else {
                //            sum += 1;
                //            $("#sub_atencion").css({
                //                "border-color": "#ccc"
                //            });
                //            $("#sub_atencion").parent().css({
                //                "color": "#212529"
                //            });
                //        }
                //    }
                //    if ($("#sub_atencion").val() == 2) {
                //        if ($("#Actuales").val() == 0) {
                //            $("#sub_atencion").css({
                //                "border-color": "red"
                //            });
                //            $("#sub_atencion").parent().css({
                //                "color": "red"
                //            });
                //        } else {
                //            sum += 1;
                //            $("#sub_atencion").css({
                //                "border-color": "#ccc"
                //            });
                //            $("#sub_atencion").parent().css({
                //                "color": "#212529"
                //            });
                //        }



                //    }
                //    if ($("#sub_atencion").val() == 3) {

                //        if ($("#Disponibles").val() == 0) {
                //            $("#sub_atencion").css({
                //                "border-color": "red"
                //            });
                //            $("#sub_atencion").parent().css({
                //                "color": "red"
                //            });
                //        } else {
                //            sum += 1;
                //            $("#sub_atencion").css({
                //                "border-color": "#ccc"
                //            });
                //            $("#sub_atencion").parent().css({
                //                "color": "#212529"
                //            });
                //        }
                //    }
                //}
                if (sum == 7) {

                    if ($("#rut").val() == "") {
                        verrut = 2;
                    }
                    Ajax_guardar();
                } else {
                    $("#mError_AAH").modal('hide');
                    var str_Error = "Por favor llenar los campos marcados con color rojo";
                    $("#title").text("Faltan campos por llenar");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                    $('#XXXXXXXX').removeClass('show');

                    $('body, html').animate({
                        scrollTop: '0px'
                    }, 300);
                }
            });

            //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
            $("#Examen").click(function () {
                Fill_DataTable_exam02();
                $('#eModal2').modal('show');
                $('#XXXXXXXX').removeClass('show');
            });



            ///llenado tabla con modal  a  atabla principal
            $("#btnguardar").click(function () {
                selected = new Array();
                $(".pp input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    for (x = 0; x < selected.length; x++) {
                        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                            selected.splice(x, 1);
                        }
                    }
                }
                for (i = 0; i < selected.length; i++) {
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {




                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        }
                    }
                }

                fill_llenado_tabla();
                $('#eModal2').modal('hide');
            });


            $("#btnexarepetido").click(function () {
                selected = new Array();
                $(".sub_pp input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    for (x = 0; x < selected.length; x++) {
                        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == selected[x]) {
                            selected.splice(x, 1);
                        }
                    }
                }
                for (i = 0; i < selected.length; i++) {
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (selected[i] == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
                            Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                        }
                    }
                }
                if (xId != 0) {
                    for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                        if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == xId) {
                            Mx_Dtt_examcof.splice(z, 1);
                        }
                    }
                }
                fill_llenado_tabla();
                $('#eModal3').modal('hide');
            });

            $(document).on('click', '.borrar', function (event) {
                var rowstota = document.getElementById("DataTable_pac2").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();
                if (rowstota > 2) {
                    for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                        if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {
                            Mx_Dtt_examcof.splice(i, 1);
                        }
                        $(this).closest('tr').remove();
                        for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                            if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                                sifi = 1;
                            } else {
                                sifi = 0;
                            }
                        }
                    }
                } else {
                    var str_Error = "El campo no puede ser eliminado"
                    $("#title").text("Eliminar Examen");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                    $('#XXXXXXXX').removeClass('show');
                }
            });
            $(document).on('click', '.CEstado', function (event) {
                //var rowstota = document.getElementById("DataTable_pac2").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();

                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                        Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Espera"

                    }
                }

                fill_llenado_tabla();

            });
            $(document).on('click', '.Activado', function (event) {
                //var rowstota = document.getElementById("DataTable_pac2").rows.length;
                var ff = $(this).parent().parent().children().children('.td_input').attr('data-id');
                event.preventDefault();

                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == ff) {

                        Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN = "Activo"

                    }
                }

                fill_llenado_tabla();

            });
        });
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
    </script>
    <script>
        //--------------------------------------- JASON DIAGNOSTICO --------------------------------------------------------------------|
        var Mx_Diagnostico = [
                        {
                            "ID_DIAGNOSTICO": 0,
                            "DIA_COD": 0,
                            "DIA_DESC": 0,
                            "ID_ESTADO": 0
                        }
        ];

        function Ajax_Diagnostico() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Diagnostico = JSON.parse(json_receiver);
                        Fill_Ddl_diagnostico();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }


        var Mx_Detalle_ate = {
            "proparra1": [{
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "PREI_FECHA": 0,
                "PREI_FUR": 0,
                "PREI_OBS_FICHA": 0,
                "PREI_AÑO": 0,
                "PREI_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "SEXO_DESC": 0,
                "PAC_APELLIDO ": 0,
                "PAC_FNAC": 0,
                "PAC_DIR": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "PAC_OBS_PERMA": 0,
                "NAC_DESC": 0,
                "CIU_DESC": 0,
                "COM_DESC": 0,
                "ID_PACIENTE": 0,
                "PAC_RUT": 0,
                "DNI": 0,
                "id_Nacionalidad": 0

            }],
            "proparra2": [{
                "ID_PREINGRESO": 0,
                "ID_DET_PREI": 0,
                "ID_CODIGO_FONASA": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_ESTADO": 0,
                "PREI_DET_V_PREVI": 0,
                "PREI_DET_V_PAGADO": 0,
                "PREI_DET_V_COPAGO": 0,
                "PREI_DET_DOC": 0,
                "ID_TP_PAGO": 0,
                "TP_PAGO_DESC": 0,
                "CF_DIAS": 0,
                "ID_PER": 0,
                "ATE_NUM_AVIS": 0
            }],
            "proparra3": [{
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "TP_ATE_DESC": 0,
                "LOCAL_DESC": 0,
                "ORD_DESC": 0,
                "ID_ORDEN": 0,
                "ID_PROCEDENCIA": 0,
                "ID_DOCTOR": 0,
                "ID_PREVE": 0,
                "ID_LOCAL": 0,
                "PREI_CAMA": 0,
                "PREI_OBS_FICHA": 0,
                "PROC_DESC": 0,
                "PREVE_DESC": 0,
                "ATE_NUM_INTERNO": 0,
                "PREI_OBS_TM": "",
                "ID_ATENCION": 0,
                "VIH": "",
                "Sub_atencion": 0
            }]
        }
        function Ajax_modal_exa() {
            modal_show();
            var Data_Par_modal = JSON.stringify({
                "ID": $("#Naten").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/MODAL_PAC",
                "data": Data_Par_modal,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": Data_Par_modal_paciente => {
                    //Debug
                    //console.log(Data_Par_modal_paciente);
                    Mx_Detalle_ate = Data_Par_modal_paciente.d;
                    //ENVIAMOS ID_ATEMCION AL MODAL
                    //LLAMAMOS AL FILL MODAL
                    llenarmodal();

                    //// MOSTRAR EL MODAL
                    //$('#eModales33').modal('show');
                },
                "error": Data_Par_modal_paciente => {
                    Ajax_DL_SEXO();
                    Ajax_DL_NAC();
                    Ajax_Ciudad();
                    $("#checkBox2").prop('checked', false);
                    $('#FUR').attr("disabled", true);
                    $('#checkBox2').attr("disabled", true);
                    $("#fur").css("pointer-events", "none");
                    var f = moment().format("DD-MM-YYYY");
                    $("#fecha").val(f);
                    $("#fecha2").val(f);
                    $("#FUR").val(f);
                    $('#rut').removeAttr("disabled");
                    $('#rut').val("");
                    $('#dni').removeAttr("disabled");
                    $('#dni').val("");
                    $("#Nom").val("");
                    $("#Interno").val("");
                    $("#Ape").val("");
                    $("#Edad").val("");
                    $("#telfijo").val("");
                    $("#Celular").val("");
                    $("#Email").val("");
                    $("#direccion").val("");
                    Mx_Dtt_examcof.length = 0;
                    $("#DataTable_pac2 tbody").empty();
                    Hide_Modal();
                    console.log(Data_Par_modal_paciente);

                }
            });
        }
        var Mx_DL_Diag = [
{
    "ID_DIAGNOSTICO": 0,
    "DIA_COD": "asdf",
    "DIA_DESC": "asdf",
    "ID_ESTADO": 0,
    "DIA_HOST_AVIS": 0
}
        ];
        function Ajax_DLdiag(hosts) {
            Mx_DL_Diag.length = 0;


            var Data_Par = JSON.stringify({
                "HOST": hosts
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Diag = JSON.parse(json_receiver);
                        $("#Diag2").val(Mx_DL_Diag[0].DIA_DESC);
                        //$("#DdlDiagnostico").val(Mx_DL_Diag[0].ID_DIAGNOSTICO);
                    } else {
                        //$("#DdlDiagnostico").val(1);
                        $("#Diag2").val("");


                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    // cModal_Error("Error", str_Error);


                }
            });
        }

        var Mx_DL_Diag2 = [
            {
                "ID_DIAGNOSTICO": 0,
                "DIA_COD": "asdf",
                "DIA_DESC": "asdf",
                "ID_ESTADO": 0,
                "DIA_HOST_AVIS": 0
            }
        ];
        function Ajax_DLdiag2(hosts) {
            Mx_DL_Diag2.length = 0;


            var Data_Par = JSON.stringify({
                "HOST": hosts
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Diag2 = JSON.parse(json_receiver);
                        $("#Diag3").val(Mx_DL_Diag2[0].DIA_DESC);
                        //$("#DdlDiagnostico").val(Mx_DL_Diag[0].ID_DIAGNOSTICO);

                    } else {
                        //$("#DdlDiagnostico").val(1);
                        $("#Diag3").val("");


                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    // cModal_Error("Error", str_Error);


                }
            });
        }
        function llenarmodal() {

            if (Mx_Detalle_ate.proparra2.length > 0) {
                $("#Avis").val(Mx_Detalle_ate.proparra2[0].ATE_NUM_AVIS);
            }
            let FechaREE = moment(Mx_Detalle_ate.proparra1[0].PAC_FNAC).format("YYYY-MM-DD");
            $("#txtrut").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
            $("#dni").val(Mx_Detalle_ate.proparra1[0].DNI);
            $("#Nom").val(Mx_Detalle_ate.proparra1[0].PAC_NOMBRE);
            $("#Ape").val(Mx_Detalle_ate.proparra1[0].PAC_APELLIDO);
            $("#fecha").val(FechaREE);
            $("#Edad").val(`${Mx_Detalle_ate.proparra1[0].PREI_AÑO} años`);
            $("#telfijo").val(Mx_Detalle_ate.proparra1[0].PAC_FONO1);
            $("#Celular").val(Mx_Detalle_ate.proparra1[0].PAC_MOVIL1);
            Ajax_DataTable_examen02();
            $("#Programa").val(Mx_Detalle_ate.proparra3[0].ID_PROGRAMA);
            $("#Sector").val(Mx_Detalle_ate.proparra3[0].ID_SECTOR);
            $("#Prevision").val(Mx_Detalle_ate.proparra3[0].ID_PREVE);
            $("#Doctor").val(Mx_Detalle_ate.proparra3[0].ID_DOCTOR);
            Ajax_DLdiag(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO);
            Ajax_DLdiag2(Mx_Detalle_ate.proparra3[0].ID_DIAGNOSTICO2);
            $("#sub_atencion").val(Mx_Detalle_ate.proparra3[0].Sub_atencion);
            var obj_RUT2 = Valid_RUT($("#txtrut").val());
            $("#txtrut").val(obj_RUT2.Format);
            $("#Nacio").val(Mx_Detalle_ate.proparra1[0].id_Nacionalidad);
            if (Mx_Detalle_ate.proparra1[0].SEXO_DESC == 'Masculino') {
                $("#sex").val(1);
            } else {

                $("#sex").val(2);
            }
            var aaa = {};
            if (Mx_Detalle_ate.proparra2.length > 0) {
                Mx_Dtt_examcof.length = 0;
                for (p = 0; p < Mx_Detalle_ate.proparra2.length; p++) {
                    var objId = {
                        "ID_CODIGO_FONASA": Mx_Detalle_ate.proparra2[p].ID_CODIGO_FONASA,
                        "CF_COD": Mx_Detalle_ate.proparra2[p].CF_COD,
                        "CF_DESC": Mx_Detalle_ate.proparra2[p].CF_DESC,
                        "CF_DIAS": Mx_Detalle_ate.proparra2[p].CF_DIAS,
                        "ID_PER": Mx_Detalle_ate.proparra2[p].ID_PER,
                        "HO_CC": Mx_Detalle_ate.proparra2[p].ATE_NUM_AVIS
                    };
                    Mx_Dtt_examcof.push(fnClone(objId));
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                }

                for (l = 0; l < Mx_Dtt_examcof.length; l++) {
                    for (k = 0; k < Mx_Dtt_exam02.length; k++) {

                        if (Mx_Detalle_ate.proparra2[l].ID_CODIGO_FONASA == Mx_Dtt_exam02[k].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof[l]["CF_PRECIO_AMB"] = Mx_Dtt_exam02[k].CF_PRECIO_AMB
                        }
                    }


                }

     
                fill_llenado_tabla();
            } else {

                $("#DataTable_pac2 tbody").empty();
                add_row();

                var str_Error = "Estimado usuario el numero atención no contiene exámenes Pendientes"
                $("#title").text("Ingreso de Atención");
                $("#button_modal").attr("class", "btn btn-danger");
                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();
                $('#XXXXXXXX').removeClass('show');

            }

            Hide_Modal();
            //Ajax_Examens_avis();
        };
        //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
        function add_row() {
            var rowstota = document.getElementById("DataTable_pac2").rows.length;
            var xvalue = $("#DataTable_pac2 tr:last input").val();
            if (xvalue != "") {
                $("#DataTable_pac2 tbody").append(
                        $("<tr>", {
                            "class": "textoReducido manito",
                            "padding": "1px !important",
                        }).append(
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": 0,
                                    "data-cod": "",
                                    "class": "td_input negrita",
                                    "value": ""
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido td_val1 negrita"
                            }).text(""),
                        //$("<td>", {
                        //    "align": "center",
                        //    "class": "textoReducido td_val3"
                        //}).text(""),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido td_val2 negrita"
                           }).text(""),
                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")

                        )

                    )
                $(".td_input").keydown(function EnterEvent(e) {
                    if (e.keyCode == 13) {
                        xId = $(this).attr("data-id");
                        var xcod = $(this).attr("data-cod");
                        Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                    }
                });

                var HXH = 0;
                for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                    if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == 1054) {
                        HXH = 1;
                    }
                }
                if (HXH == 1 && $("#sex").val() == 2 && sifi == 0) {
                    var str_Error = "Por favor Rellenar el campo F.U.R"
                    $("#title").text("Recordatorio");
                    $("#button_modal").attr("class", "btn btn-success");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();
                    $('#XXXXXXXX').removeClass('show');
                    sifi = 1;
                }
            } else if ((rowstota == 1) || (rowstota == 2)) {
                $("#DataTable_pac2 tbody").append(
                        $("<tr>", {
                            "class": "textoReducido manito",
                            "padding": "1px !important",
                        }).append(
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": 0,
                                    "data-cod": "",
                                    "class": "td_input negrita",
                                    "value": ""
                                })
                            }())),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido td_val1 negrita"
                            }).text(""),
                            //$("<td>", {
                            //    "align": "center",
                            //    "class": "textoReducido td_val3"
                            //}).text(""),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido td_val2 negrita"
                           }).text(""),

                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'>Eliminar</i></button>"),
                        $("<td>", {
                            "align": "center"
                        }).html("<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Espera</button>")

                        )
                    )
                $(".td_input").focusout(function () {
                    xId = $(this).attr("data-id");
                    var xcod = $(this).attr("data-cod");
                    Ajax_DataTable_examen3($(this).val(), xId, xcod, $(this));
                });
            }
            var xLen = $(".td_input");
            $(".td_input").eq(xLen.length - 1).focus();
        }
        var Mx_Dtt_examcof = [
          {
              "AÑO_DESC": 0,
              "ID_PREVE": 0,
              "ID_CODIGO_FONASA": 0,
              "CF_PRECIO_AMB": 0,
              "CF_PRECIO_HOS": 0,
              "ID_ESTADO": 0,
              "CF_COD": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_CF_PRECIO": 0,
              "CF_DIAS": 0,
              "CF_ESTADO_EXA": 0
          }
        ];
        Mx_Dtt_examcof.length = 0;
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        var Mx_Dt023 = [
          {
              "Correlativo": 0,
              "ID_Atencion": 0
          }
        ];
        function Ajax_guardar() {
            modal_show();
            var fur = 0;
            var OB = "";
            var ID = 0;
            var ed = (function () {
                var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                var array = asd.split("-")
                var total = ""
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];

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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad);
                }
                return total;

            }());
            var me = (function () {
                var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                var array = asd.split("-")
                var total = ""
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];

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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(meses);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(meses);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(meses);
                }
                return total;

            }());
            var di = (function () {
                var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                var array = asd.split("-")
                var total = ""
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];

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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(dias);
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(dias);
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(dias);
                }
                return total;

            }());
            var TOTAL = 0;
            ids = new Array();
            var numeritocliniquito = 0;
            if ($("#NumeroClinico").val() == "") {
                numeritocliniquito = 0;
            } else {
                numeritocliniquito = $("#NumeroClinico").val();
            }
            for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                var xtotal = parseFloat(Mx_Dtt_examcof[x].CF_PRECIO_AMB);
                TOTAL += xtotal;

                var objId = {
                    "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
                    "id_PER": Mx_Dtt_examcof[x].ID_PER,
                    "Valor": Mx_Dtt_examcof[x].CF_PRECIO_AMB,
                    "Clinico": numeritocliniquito,
                    "CF_ESTADO_EXAMEN": Mx_Dtt_examcof[x].CF_ESTADO_EXAMEN
                };


                ids.push(objId);

            }
            gg = new Array();

            $("#checkBox2:checkbox:checked").each(function () {
                gg.push($(this).val());
            });
            if (gg.length == 1) {
                fur = $("#FUR").val();
            } else {
                fur = "";
            }
            if (verrut == 1) {
                var OB = Mx_Dtt2[0].ID_PACIENTE;
                var ID = Mx_Dtt2[0].PAC_OBS_PERMA;
            } else {
                var OB = "";
                var ID = 0;
            }

            var f = moment().format("DD-MM-YYYY");


  

           
            var Data_Par = JSON.stringify({
                //-*-*-*-*Datos Paciente-*-*-*-*-*-*
                "RUT_PAC": $('#txtrut').val(),
                "NOMBRE_PAC": $("#Nom").val(),
                "APE_PAC": $("#Ape").val(),
                "FNAC_PAC": moment($("#fecha").val()).format("DD-MM-YYYY"),
                "ID_SEXO": $("#sex").val(),
                "ID_NACIONALIDAD": $("#Nacio").val(),
                "FONO1": $("#telfijo").val(),
                "MOVIL1": $("#Celular").val(),
                "ID_CIU_COM": $("#Comuna").val(),
                "DIR_PAC": $("#direccion").val(),
                "EMAIL_PAC": $("#Email").val(),
                "FUR": fur,
                "Paridad": verrut,
                "ID_PAC": OB,
                "OB": $("#obdser").val(),
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                "Procedencia": $("#Procedencia").val(),
                "Programa": $("#Programa").val(),
                "Sector": $("#Sector").val(),
                "TipoAtencion": $("#TipoAtencion").val(),
                "PrioridadTM": $("#PrioridadTM").val(),
                "Doctor": $("#Doctor").val(),
                "Prevision": $("#Prevision").val(),
                //-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*
                "EDAD": ed,
                "MES": me,
                "DIA": di,
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                "TOTAL": TOTAL,
                "FECHA_PRE": f,
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-    
                "ids": ids,
                "ate_obs": $("#obs_ate").val(),
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                "Interno": 1,
                "id_Diag": $("#DdlDiagnostico").val(),
                "id_Diag2": $("#DdlDiagnostico2").val(),
                "sub_atencion": 1,
                "vih": $("#vih").val(),
                "dni": $("#dni").val(),
                "SUB_PROGRAMA": $("#Ddl_Prog02").val(),
                "S_Id_User": Galletas.getGalleta("ID_USER")

            });

            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Guardar_TodoByVal",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    //Comprobar Galletas
                    if ((json_receiver == null) || (json_receiver == "")) {
                        window.location = "/index.aspx";
                        return;
                    }

                    if (json_receiver != null) {

                        //ids.forEach(aaa => {
                        //if(aaa.id_CF == 496) {
                        //    // 496  Digoxina , Niveles Plasmáticos          |
                        //    // 597  Teofilina, Niveles Plasmáticos          |
                        //    // 709  Aminofilina, Niveles Plasmáticos        |       *** NIVELES PLASMÁTICOS ***
                        //    // 1005 Primidona, Niveles Plasmáticos BK       |
                        //    // 1013 Teofilina BK, Niveles Plasmáticos BK    |

                        //    // 31   Tiempo de Protrombina

                        //}else if (aaa.id_CF == 597) {

                        //}else if (aaa.id_CF == 709) {

                        //}else if (aaa.id_CF == 1005){

                        //}else if (aaa.id_CF == 1013){

                        //}else if (aaa.id_CF == 31)  {

                        //}

                        //});

                        //$("#modal_Datos_extras").modal("hide");
                        //$("#modal_Datos_extras").modal("show");

                        Mx_Dt023 = JSON.parse(json_receiver);
                        Hide_Modal();
                        Ajax_DL_SEXO();
                        Ajax_DL_NAC();
                        //Ajax_Ciudad();
                        $('#txtrut').val("");
                        //Ajax_DataTable();
                        $("#checkBox2").prop('checked', false);
                        $('#FUR').attr("disabled", true);
                        $('#checkBox2').attr("disabled", true);
                        $("#fur").css("pointer-events", "none");
                        var f = moment().format("DD-MM-YYYY");
                        $("#obs_ate").val("");
                        $("#NumeroClinico").val("");
                        $("#fecha").val(f);
                        $("#fecha2").val(f);
                        $("#FUR").val(f);
                        $('#rut').removeAttr("disabled");
                        $('#rut').val("");
                        $('#dni').removeAttr("disabled");
                        $('#dni').val("");
                        $("#Nom").val("");
                        $("#Ape").val("");
                        $("#Edad").val("");
                        $("#telfijo").val("");
                        $("#Celular").val("");
                        $("#Email").val("");
                        $("#direccion").val("");
                        $("#obdser").val("");
                        Mx_Dtt_examcof.length = 0;
                        $("#DataTable_pac2 tbody").empty();
                        $("#Interno").val("");
                        add_row();
                        verrut = 0;
                        Mx_Dtt2.length = 0;
                        $('#XXXXXXXX').removeClass('show');
                        $("#title2").text("Ingreso de Atención realizado");
                        $("#modalpccc").html("<p><strong>Nº de Folio:</strong> <strong style='font-size:20px;'>" + Mx_Dt023.Correlativo + "</strong>\n ¿Desea imprimir Etiquetas?</p>");
                        $("#MOdal_PAGO").modal();

                        let xVal = 0;
                        if ($("#chkMant_0").prop("checked") == false) {
                            xVal = $("#Procedencia option").eq(0).val();
                            $("#Procedencia").val(
                                parseInt(xVal)
                            );
                        }

                        setTimeout(() => {
                            if ($("#chkMant_3").prop("checked") == false) {
                                xVal = $("#Prevision option").eq(0).val();
                                $("#Prevision").val(
                                    parseInt(xVal)
                                );
                            }

                            setTimeout(() => {
                                if ($("#chkMant_1").prop("checked") == false) {
                                    fn_Req_Prog();
                                    xVal = $("#Programa option").eq(0).val();
                                    $("#Programa").val(
                                        parseInt(xVal)
                                    );
                                }

                                setTimeout(() => {
                                    if ($("#chkMant_2").prop("checked") == false) {
                                        fn_Req_SubP();
                                        xVal = $("#Ddl_Prog02 option").eq(0).val();
                                        $("#Ddl_Prog02").val(
                                            parseInt(xVal)
                                        );
                                    }
                                }, 1000);
                            }, 1000);
                        }, 1000);
                       
                    } else {
                        Hide_Modal();


                        var str_Error = "Estimano usuario Por favor ingresar exámenes"
                        $("#title").text("Ingreso de Atención");
                        $("#button_modal").attr("class", "btn btn-danger");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        $('#XXXXXXXX').removeClass('show');
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
        //-*-*-**-*-**--**--*-*-*-***-*****--**-*-*-*-*-*-*-*-*-*-*-*-*-*-
        var Mx_Dtt_exam02 = [
          {
              "AÑO_DESC": 0,
              "ID_PREVE": 0,
              "ID_CODIGO_FONASA": 0,
              "CF_PRECIO_AMB": 0,
              "CF_PRECIO_HOS": 0,
              "ID_ESTADO": 0,
              "CF_COD": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_CF_PRECIO": 0,
              "CF_DIAS": 0,
          }
        ];
        var Mx_Dtt_exam02_respaldo = [
  {
      "AÑO_DESC": 0,
      "ID_PREVE": 0,
      "ID_CODIGO_FONASA": 0,
      "CF_PRECIO_AMB": 0,
      "CF_PRECIO_HOS": 0,
      "ID_ESTADO": 0,
      "CF_COD": 0,
      "CF_DESC": 0,
      "ID_PER": 0,
      "ID_CF_PRECIO": 0,
      "CF_DIAS": 0,
  }
        ];
        function Ajax_DataTable_examen02() {
            var f = moment().format("DD-MM-YYYY");


            $("#Div_Tabla2").empty();
            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": f
            });

            $.ajax({
                "type": "POST",
                "url": "IN_PAC_AVIS.aspx/Llenar_tabla_exam2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_exam02 = JSON.parse(json_receiver);
                        Mx_Dtt_exam02_respaldo = JSON.parse(json_receiver);
                        //if ($("#sex").val() != 0) {
                        //    var posicion = 0;
                        //    if ($("#sex").val() == 1) {
                        //        for (x = 0; x < Mx_Dtt_exam02.length; x++) {                              //AQUI SE QUITA O AGREGAN CREATININAS
                        //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 691) {
                        //                posicion = x;
                        //            }
                        //        }
                        //        Mx_Dtt_exam02.splice(posicion, 1);
                        //    }
                        //    if ($("#sex").val() == 2) {
                        //        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        //            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 690) {
                        //                posicion = x;
                        //            }
                        //        }
                        //        Mx_Dtt_exam02.splice(posicion, 1);
                        //    }
                        //}
                        Fill_DataTable_exam02();

                    } else {


                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        var Mx_Dtt_exam03 = [
          {
              "AÑO_DESC": 0,
              "ID_PREVE": 0,
              "ID_CODIGO_FONASA": 0,
              "CF_PRECIO_AMB": 0,
              "CF_PRECIO_HOS": 0,
              "ID_ESTADO": 0,
              "CF_COD": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_CF_PRECIO": 0,
              "CF_DIAS": 0,
          }
        ];
     



        function Ajax_DataTable_examen3(cod_fonasa, id, cod, txis) {
            var f = moment().format("DD-MM-YYYY");


            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": f,
                "CF": cod_fonasa
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Saydex.aspx/Llenar_tabla_exam",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_exam03 = JSON.parse(json_receiver);
                        //if ($("#sex").val() != 0) {
                        //    var posicion = 0;
                        //    if ($("#sex").val() == 1) {
                        //        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                        //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                        //                posicion = x;
                        //            }
                        //        }
                        //        Mx_Dtt_exam03.splice(posicion, 1);
                        //    }
                        //    if ($("#sex").val() == 2) {
                        //        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                        //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                        //                posicion = x;
                        //            }
                        //        }
                        //        Mx_Dtt_exam03.splice(posicion, 1);
                        //    }
                        //}
                        success(id, cod, txis);


                    } else {


                        Mx_Dtt_exam03.length = 0;

                        Ajax_DataTable_examen3_PACK(cod_fonasa, id, cod, txis);
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }














        function Ajax_DataTable_examen3_PACK(cod_fonasa_2, id_2, cod_2, txis_2) {
            var f = moment().format("DD-MM-YYYY");


            var Data_Par = JSON.stringify({
                "ID_PREVE": $("#Prevision").val(),
                "Fecha": f,
                "CF": cod_fonasa_2
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Saydex.aspx/Llenar_tabla_exam_pack",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_exam03 = JSON.parse(json_receiver);
                        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                            if (Mx_Dtt_exam03[x]["CF_ESTADO_EXAMEN"] == undefined) {
                                Mx_Dtt_exam03[x]["CF_ESTADO_EXAMEN"] = "Activo";
                            }
                        }
                        //if ($("#sex").val() != 0) {
                        //    var posicion = 0;
                        //    if ($("#sex").val() == 1) {
                        //        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                        //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                        //                posicion = x;
                        //            }
                        //        }
                        //        Mx_Dtt_exam03.splice(posicion, 1);
                        //    }
                        //    if ($("#sex").val() == 2) {
                        //        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                        //            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                        //                posicion = x;
                        //            }
                        //        }
                        //        Mx_Dtt_exam03.splice(posicion, 1);
                        //    }
                        //}
                        success_2(id_2, cod_2, txis_2);


                    } else {


                        Mx_Dtt_exam03.length = 0;
                        success(id_2, cod_2, txis_2);
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }








        function success_2(xxid_2, xxcod_2, xtxis_2) {
            if (Mx_Dtt_exam03.length == 0) {
                $("input[data-id='" + xxid_2 + "']").val(xxcod_2);
            } else if (Mx_Dtt_exam03.length > 0) {


                var repetido = 0;

                if (Mx_Dtt_examcof.length > 0) {
                    for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                        for (c = 0; c < Mx_Dtt_examcof.length; c++) {
                            if (Mx_Dtt_examcof[c].ID_CODIGO_FONASA == Mx_Dtt_exam03[x].ID_CODIGO_FONASA) {
                                Mx_Dtt_examcof.splice(c, 1);
                                break;
                            }
                        }

                    }

                    for (z = 0; z < Mx_Dtt_exam03.length; z++) {
                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[z]));
                    }
                }
                else {
                    for (z = 0; z < Mx_Dtt_exam03.length; z++) {
                        Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam03[z]));
                    }
                }





                $("#DataTable_pac2 tbody").empty();
                for (i = 0; i < Mx_Dtt_examcof.length; i++) {

                    if (Mx_Dtt_examcof[i]["CF_TP_PAGO"] == undefined) {
                        Mx_Dtt_examcof[i]["CF_TP_PAGO"] = 18;
                    }
                    if (Mx_Dtt_examcof[i]["CF_TP_PROGRA"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PROGRA"] == 0) {
                        Mx_Dtt_examcof[i]["CF_TP_PROGRA"] = 1;
                    }
                    $("#DataTable_pac2 tbody").append(
                        $("<tr>", {
                            "class": "textoReducido manito",
                            "padding": "1px !important",
                            "data-index": i
                        }).append(
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido negrita"
                            }).html((function () {
                                //Retornar un campo input
                                return $("<input>", {
                                    "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                                    "data-cod": Mx_Dtt_examcof[i].CF_COD,
                                    "class": "td_input negrita",
                                    "value": Mx_Dtt_examcof[i].CF_COD
                                })
                            }())),

                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido td_val1 negrita"
                            }).text(Mx_Dtt_examcof[i].CF_DESC),
                                //$("<td>", {
                                //    "align": "center"
                                //}).append(
                                //$("<select>", {
                                //    class: "form-control textoReducido tp_programa",
                                //    "data-id_progama": Mx_Dtt_examcof[i].ID_CODIGO_FONASA

                                //}).append(function () {
                                //    let xxx = [];
                                //    for (x = 0; x < arrProg_2.length; x++) {
                                //        xxx.push($("<option>", {
                                //            value: arrProg_2[x].ID_PROGRA
                                //        }).text(arrProg_2[x].PROGRA_DESC));
                                //    }
                                //    console.log(xxx);
                                //    return xxx;
                                //}())),

                            //$("<td>", {

                            //    "align": "center"
                            //}).append(
                            //$("<select>", {
                            //    class: "form-control textoReducido tp_pago",
                            //    "id_pago": Mx_Dtt_examcof[i].ID_CODIGO_FONASA

                            //}).append(function () {
                            //    let xxx = [];
                            //    for (x = 0; x < Mx_Ddl_TP_PAGO.length; x++) {
                            //        xxx.push($("<option>", {
                            //            value: Mx_Ddl_TP_PAGO[x].ID_TP_PAGO
                            //        }).text(Mx_Ddl_TP_PAGO[x].TP_PAGO_DESC));
                            //    }
                            //    console.log(xxx);
                            //    return xxx;
                            //}())),
                            $("<td>", {
                                "align": "center",
                                "class": "textoReducido td_val2 negrita"
                            }).text(Mx_Dtt_examcof[i].CF_DIAS),
                            //$("<td>", {
                            //    "align": "center",
                            //    "class": "textoReducido td_val5"
                            //}).text(""),
                           //$("<td>", {
                           //    "align": "center"
                           //}).html(function () {
                           //    if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                           //        return "<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                           //    } else {
                           //        return "<button type='button' class='btn btn-success btn-xs Activado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                           //    }
                           //}()), 
                          //function () {
                          //    if ($("#TipoAtencion").val() == 1) {
                          //        return $("<td>", {
                          //            "align": "center",
                          //            "class": "textoReducido td_val3"
                          //        }).text("$ " + Mx_Dtt_examcof[i].CF_PRECIO_AMB)
                          //    } else {
                          //        return $("<td>", {
                          //            "align": "center",
                          //            "class": "textoReducido td_val3"
                          //        }).text("$ " + Mx_Dtt_examcof[i].CF_PRECIO_HOS)
                          //    }
                          //}(),
                           $("<td>", {
                               "align": "center"
                           }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'>X</button>"),
                                                       $("<td>", {
                                                           "align": "center"
                                                       }).html(function () {
                                                           if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                                                               return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                                                           } else {
                                                               return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                                                           }


                                                       }())
                            )


                    )
                    //precio = parseInt(precio) + parseInt(Mx_Dtt_examcof[i].CF_PRECIO_AMB);
                    //cantida_exa++;

                    //let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] select`).val(Mx_Dtt_examcof[i].CF_TP_PAGO)

                    //let xindex = $(`#DataTable_pac2 tbody tr[data-index =${i}] select`).val(Mx_Dtt_examcof[i].CF_TP_PROGRA)
                    //if (Mx_Dtt_examcof[i].CF_TP_PROGRA == 32) {
                    //    let xindex2 = $(`#DataTable_pac2 tbody tr[data-index =${i}] select`).attr('disabled', true)
                    //}

                    //console.log(xindex);
                }
                //console.log(cantida_exa)
                //$("#precio_").text("$" + precio);
                //$("#Cantida_").text(cantida_exa);
                add_row();
            } else {
                $("input[data-id='" + xxid + "']").val(xxcod);
            }
        }






        var Mx_Dtt = [
           {
               "ID_PROCEDENCIA": 0,
               "PROC_DESC": 0,
               "PROC_CANT_EXA": 0,
               "ID_ESTADO ": 0,
               "PRO_TIPO_I": 0,
               "TOTAL_ATE": 0,
               "PROC_CANT_EXA_BUSCA_DIAS": 0,
               "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
               "CONF_DIAS_EXA_BUSCA_DIAS": 0,
               "ID_ESTADO_BUSCA_DIAS ": 0,
               "ID_PROCEDENCIA_BUSCA_DIAS": 0,
               "ID_CONF_DIAS_BUSCA_DIAS": 0
           }
        ];
        var Mx_Ddl = [
    {
        "ID_PROCEDENCIA": "",
        "PROC_COD": "",
        "PROC_DESC": "",
        "ID_ESTADO": ""
    }
        ];
        function Call_AJAX_Ddl() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_Ddl_LugarTM",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_AJAX_Ddl();


                        fn_Req_Prev();


                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    alert("Error", str_Error);


                }
            });
        }
        var Mx_Dtt2 = [
           {
               "ID_PACIENTE": 0,
               "PAC_RUT": 0,
               "PAC_NOMBRE": 0,
               "PAC_APELLIDO ": 0,
               "ID_SEXO": 0,
               "TOTAL_ATE": 0,
               "PAC_FNAC": 0,
               "ID_NACIONALIDAD": 0,
               "ID_REL_CIU_COM": 0,
               "PAC_FONO1 ": 0,
               "PAC_FONO2": 0,
               "PAC_MOVIL1": 0,
               "PAC_MOVIL2": 0,
               "PAC_EMAIL": 0,
               "PAC_OBS_PER": 0,
               "PAC_DIR": 0,
               "ID_DIAGNOSTICO ": 0,
               "ID_ESTADO": 0,
               "ID_CIUDAD": 0,
               "PAC_OBS_PERMA": 0,
               "ID_COMUNA": 0
           }
        ];
        Mx_Dtt2.length = 0;
        function Ajax_busca_rut() {
            $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
            $('#FUR').attr("disabled", true);
            $('#checkBox2').attr("disabled", true);
            $("#fur").css("pointer-events", "none");


            modal_show();
            var Data_Par = JSON.stringify({
                "rut": $("#rut").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_rut",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2 = JSON.parse(json_receiver);



                        Ajax_modal_exa_RUT();



                        //Fill_DL_Rut();
                        //$('#txtrut').val($("#rut").val());
                        //Hide_Modal();
                        //verrut = 1;





                    } else {

                        $('#txtrut').val($("#rut").val());
                        Ajax_DL_SEXO();
                        Ajax_DL_NAC();
                        Ajax_Ciudad();
                        $("#checkBox2").prop('checked', false);
                        $('#FUR').attr("disabled", true);
                        $('#checkBox2').attr("disabled", true);
                        $("#fur").css("pointer-events", "none");
                        var f = moment().format("DD-MM-YYYY");
                        $("#fecha").val(f);
                        $("#fecha2").val(f);
                        $("#FUR").val(f);
                        $('#rut').removeAttr("disabled");

                        $('#dni').removeAttr("disabled");
                        $('#dni').val("");
                        $("#Nom").val("");
                        $("#Interno").val("");
                        $("#Ape").val("");
                        $("#Edad").val("");
                        $("#telfijo").val("");
                        $("#Celular").val("");
                        $("#Email").val("");
                        $("#direccion").val("");
                        Mx_Dtt_examcof.length = 0;
                        $("#DataTable_pac2 tbody").empty();
                        Hide_Modal();
                        verrut = 2;

                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        var Mx_Detalle_ate = {
            "proparra1": [{
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "PREI_FECHA": 0,
                "PREI_FUR": 0,
                "PREI_OBS_FICHA": 0,
                "PREI_AÑO": 0,
                "PREI_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "SEXO_DESC": 0,
                "PAC_APELLIDO ": 0,
                "PAC_FNAC": 0,
                "PAC_DIR": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "PAC_OBS_PERMA": 0,
                "NAC_DESC": 0,
                "CIU_DESC": 0,
                "COM_DESC": 0,
                "ID_PACIENTE": 0,
                "PAC_RUT": 0,
                "DNI": 0,
                "id_Nacionalidad": 0

            }],
            "proparra2": [{
                "ID_PREINGRESO": 0,
                "ID_DET_PREI": 0,
                "ID_CODIGO_FONASA": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_ESTADO": 0,
                "PREI_DET_V_PREVI": 0,
                "PREI_DET_V_PAGADO": 0,
                "PREI_DET_V_COPAGO": 0,
                "PREI_DET_DOC": 0,
                "ID_TP_PAGO": 0,
                "TP_PAGO_DESC": 0,
                "CF_DIAS": 0,
                "ID_PER": 0,
                "ATE_NUM_AVIS": 0
            }],
            "proparra3": [{
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "ID_PREINGRESO": 0,
                "PREI_NUM": 0,
                "TP_ATE_DESC": 0,
                "LOCAL_DESC": 0,
                "ORD_DESC": 0,
                "ID_ORDEN": 0,
                "ID_PROCEDENCIA": 0,
                "ID_DOCTOR": 0,
                "ID_PREVE": 0,
                "ID_LOCAL": 0,
                "PREI_CAMA": 0,
                "PREI_OBS_FICHA": 0,
                "PROC_DESC": 0,
                "PREVE_DESC": 0,
                "ATE_NUM_INTERNO": 0,
                "PREI_OBS_TM": "",
                "ID_ATENCION": 0,
                "VIH": "",
                "Sub_atencion": 0
            }]
        }
        function Ajax_modal_exa_RUT() {
            modal_show();
            Mx_Detalle_ate = 0;
            var Data_Par_modal = JSON.stringify({
                "ID": $("#rut").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Omi.aspx/MODAL_PAC_RUT",
                "data": Data_Par_modal,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": Data_Par_modal_paciente => {
                    //Debug
                    //console.log(Data_Par_modal_paciente);
                    Mx_Detalle_ate = Data_Par_modal_paciente.d;
                    //ENVIAMOS ID_ATEMCION AL MODAL
                    //LLAMAMOS AL FILL MODAL
                    //var obj_RUT2 = Valid_RUT(Mx_Dtt2[0].RUT_PACIENTE);
                    console.log("pok");
                    if (Mx_Detalle_ate.proparra1.length == 0) {
                        Fill_DL_Rut();
                        $('#txtrut').val($("#rut").val());
                        Hide_Modal();
                        verrut = 1;
                    } else {
                        //if (Mx_Detalle_ate.proparra1[0].PAC_RUT == Mx_Dtt2[0].PAC_RUT) {
                        //    console.log("la otra pagina 2");
                        //    var loc = location.origin;
                            //window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + Mx_Dtt2[0].PAC_RUT + "&Di=" + "NONE");
                        //} else {


                            Fill_DL_Rut();
                            $('#txtrut').val($("#rut").val());
                            Hide_Modal();
                            verrut = 1;
                        //}
                    }


                    //// MOSTRAR EL MODAL
                    //$('#eModales33').modal('show');
                },
                "error": Data_Par_modal_paciente => {
                    Hide_Modal();
                    console.log(Data_Par_modal_paciente);

                }
            });
        }

        //*--------------------------------------------------------------------------------------------------------------------------







        //*-----------------------------------------------------------------------------------------------------------------------------*
        var Mx_Dtt2_dni = [
   {
       "ID_PACIENTE": 0,
       "PAC_DNI": 0,
       "PAC_NOMBRE": 0,
       "PAC_APELLIDO ": 0,
       "ID_SEXO": 0,
       "TOTAL_ATE": 0,
       "PAC_FNAC": 0,
       "ID_NACIONALIDAD": 0,
       "ID_REL_CIU_COM": 0,
       "PAC_FONO1 ": 0,
       "PAC_FONO2": 0,
       "PAC_MOVIL1": 0,
       "PAC_MOVIL2": 0,
       "PAC_EMAIL": 0,
       "PAC_OBS_PER": 0,
       "PAC_DIR": 0,
       "ID_DIAGNOSTICO ": 0,
       "ID_ESTADO": 0,
       "ID_CIUDAD": 0,
       "PAC_OBS_PERMA": 0,
       "ID_COMUNA": 0
   }
        ];
        Mx_Dtt2_dni.length = 0;
        function Ajax_busca_dni() {
            $("#checkBox2").prop('checked', false);//solo los del objeto #diasHabilitados
            $('#FUR').attr("disabled", true);
            $('#checkBox2').attr("disabled", true);
            $("#fur").css("pointer-events", "none");


            modal_show();
            var Data_Par = JSON.stringify({
                "dni": $("#dni").val()
            });
            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN_2.aspx/Llenar_dni",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt2_dni = JSON.parse(json_receiver);
                        Ajax_modal_exa_DNI();
                       
                    } else {

                        Ajax_DL_SEXO();
                        Ajax_DL_NAC();
                        Ajax_Ciudad();
                        $("#checkBox2").prop('checked', false);
                        $('#FUR').attr("disabled", true);
                        $('#checkBox2').attr("disabled", true);
                        $("#fur").css("pointer-events", "none");
                        var f = moment().format("DD-MM-YYYY");
                        $("#fecha").val(f);
                        $("#fecha2").val(f);
                        $("#FUR").val(f);
                        $('#rut').removeAttr("disabled");
                        $('#txtrut').val("");
     
                        $("#Nom").val("");
                        $("#Interno").val("");
                        $("#Ape").val("");
                        $("#Edad").val("");
                        $("#telfijo").val("");
                        $("#Celular").val("");
                        $("#Email").val("");
                        $("#direccion").val("");
                        Mx_Dtt_examcof.length = 0;
                        $("#DataTable_pac2 tbody").empty();
                        Hide_Modal();
                        verrut = 2;

                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
        function Ajax_modal_exa_DNI() {
            modal_show();
            Mx_Detalle_ate = 0;
            console.log("DNI");
            var Data_Par_modal = JSON.stringify({
                "ID": $("#dni").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate_Omi.aspx/MODAL_PAC_DNI",
                "data": Data_Par_modal,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": Data_Par_modal_paciente => {
                    //Debug
                    //console.log(Data_Par_modal_paciente);
                    Mx_Detalle_ate = Data_Par_modal_paciente.d;


                    if (Mx_Detalle_ate.proparra1.length == 0) {
                        $('#dni').attr("disabled", true);
                        $("#Nom").val(Mx_Dtt2_dni[0].PAC_NOMBRE);
                        $("#Ape").val(Mx_Dtt2_dni[0].PAC_APELLIDO);
                        $("#fecha").val(moment(Mx_Dtt2_dni[0].PAC_FNAC).format("YYYY-MM-DD"));
                        console.log(Mx_Dtt2_dni[0].PAC_FNAC);
                        $("#Edad").val(function () {
                            var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                            var array = asd.split("-");
                            var total = "";
                            var dia = array[0];
                            var mes = array[1];
                            var ano = array[2];
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
                            if (ahora_mes > mes)
                                meses = ahora_mes - mes;
                            if (ahora_mes < mes)
                                meses = 12 - (mes - ahora_mes);
                            if (ahora_mes == mes && dia > ahora_dia)
                                meses = 11;
                            // calculamos los dias
                            var dias = 0;
                            total = String(edad + " Años");
                            if (ahora_dia > dia) {
                                dias = ahora_dia - dia;
                                total = String(edad + " Años");
                            }
                            if (ahora_dia < dia) {
                                ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                                dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                                total = String(edad + " Años");
                            }
                            return total
                        });
                        $("#sex").val(Mx_Dtt2_dni[0].ID_SEXO);//
                        if (Mx_Dtt2_dni[0].ID_SEXO == 2) {
                            $('#checkBox2').removeAttr("disabled");
                        }
                        $("#Nacio").val(Mx_Dtt2_dni[0].ID_NACIONALIDAD);


                        $("#telfijo").val(Mx_Dtt2_dni[0].PAC_FONO1);
                        $("#Celular").val(Mx_Dtt2_dni[0].PAC_MOVIL1);
                        Ajax_DataTable_examen02();
                        $("#direccion").val(Mx_Dtt2_dni[0].PAC_DIR);
                        $("#Email").val(Mx_Dtt2_dni[0].PAC_EMAIL);

                        Hide_Modal();
                        verrut = 1;
                    } else {
                        //if (Mx_Detalle_ate.proparra1[0].DNI == Mx_Dtt2_dni[0].DNI) {
                        //    console.log("la otra pagina 2");
                        //    var loc = location.origin;
                        //    window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + "NONE" + "&Di=" + Mx_AVIS[0].DNI);
                        //} else {
                            $('#dni').attr("disabled", true);
                            $("#Nom").val(Mx_Dtt2_dni[0].PAC_NOMBRE);
                            $("#Ape").val(Mx_Dtt2_dni[0].PAC_APELLIDO);
                            $("#fecha").val(moment(Mx_Dtt2_dni[0].PAC_FNAC).format("YYYY-MM-DD"));
                            console.log(Mx_Dtt2_dni[0].PAC_FNAC);
                            $("#Edad").val(function () {
                                var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                                var array = asd.split("-");
                                var total = "";
                                var dia = array[0];
                                var mes = array[1];
                                var ano = array[2];
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
                                if (ahora_mes > mes)
                                    meses = ahora_mes - mes;
                                if (ahora_mes < mes)
                                    meses = 12 - (mes - ahora_mes);
                                if (ahora_mes == mes && dia > ahora_dia)
                                    meses = 11;
                                // calculamos los dias
                                var dias = 0;
                                total = String(edad + " Años");
                                if (ahora_dia > dia) {
                                    dias = ahora_dia - dia;
                                    total = String(edad + " Años");
                                }
                                if (ahora_dia < dia) {
                                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                                    total = String(edad + " Años");
                                }
                                return total
                            });
                            $("#sex").val(Mx_Dtt2_dni[0].ID_SEXO);//
                            if (Mx_Dtt2_dni[0].ID_SEXO == 2) {
                                $('#checkBox2').removeAttr("disabled");
                            }
                            $("#Nacio").val(Mx_Dtt2_dni[0].ID_NACIONALIDAD);


                            $("#telfijo").val(Mx_Dtt2_dni[0].PAC_FONO1);
                            $("#Celular").val(Mx_Dtt2_dni[0].PAC_MOVIL1);
                            Ajax_DataTable_examen02();
                            $("#direccion").val(Mx_Dtt2_dni[0].PAC_DIR);
                            $("#Email").val(Mx_Dtt2_dni[0].PAC_EMAIL);

                            Hide_Modal();
                            verrut = 1;
                        //}
                    }


                    //// MOSTRAR EL MODAL
                    //$('#eModales33').modal('show');
                },
                "error": Data_Par_modal_paciente => {
                    Hide_Modal();
                    console.log(Data_Par_modal_paciente);

                }
            });
        }
        var Mx_DL_SEXO = [
        {
            "ID_SEXO": 0,
            "SEXO_COD": "asdf",
            "SEXO_DESC": "asdf",
            "ID_ESTADO": 0
        }
        ];
        function Ajax_DL_SEXO() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_SEXO",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_SEXO = JSON.parse(json_receiver);
                        Fill_DL_SEXO();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_NAC = [
        {
            "ID_NACIONALIDAD": 0,
            "NAC_COD": "asdf",
            "NAC_DESC": "asdf",
            "ID_ESTADO": 0
        }
        ];
        function Ajax_DL_NAC() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_NAC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_NAC = JSON.parse(json_receiver);
                        Fill_DL_NAC();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------- JASON CIUDAD --------------------------------------------------------------------------|
        var Mx_Ciudad = [
            {
                "ID_CIUDAD": 0,
                "CIU_COD": 0,
                "CIU_DESC": 0,
                "ID_ESTADO": 0
            }
        ];

        function Ajax_Ciudad() {


            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/IRIS_WEBF_BUSCA_CIUDAD",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ciudad = JSON.parse(json_receiver);
                        Fill_Ddl_Cuidad();
                        Ajax_Comuna();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }
        //--------------------------------------- JASON COMUNA --------------------------------------------------------------------------|
        var Mx_Comuna = [
            {
                "COM_DESC": 0,
                "ID_COMUNA": 0,
                "ID_ESTADO": 0,
                "ID_CIUDAD": 0,
                "ID_REL_CIU_COM": 0
            }
        ];
        function Ajax_Comuna() {



            var Data_Par = JSON.stringify({
                "ID_CIU": $("#Cuidad").val()
            });

            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Comuna = JSON.parse(json_receiver);
                        Fill_Ddl_Comuna();
                        $(".block_wait").hide();


                    } else {


                    }
                },
                "error": function (response) {


                }
            });
        }
        //--------------------------------------------------------------------------------------------
        var Mx_DL_prevision = [
      {
          "ID_COMUNA": 0,
          "COM_COD": "asdf",
          "COM_DESC": "asdf",
          "ID_ESTADO": 0
      }
        ];
        function Ajax_DL_prevision() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_prevision",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_prevision = JSON.parse(json_receiver);
                        Fill_DL_prevision();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_TP_ATE = [
     {
         "ID_TP_ATENCION": 0,
         "TP_ATE_COD": "asdf",
         "TP_ATE_DESC": "asdf",
         "ID_ESTADO": 0
     }
        ];
        function Ajax_DL_TP_ATE() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_aTENCIONES",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_TP_ATE = JSON.parse(json_receiver);
                        Fill_DL_TP_ATE();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_Sec = [
    {
        "ID_SECTOR": 0,
        "SECTOR_COD": "asdf",
        "SECTOR_DESC": "asdf",
        "ID_ESTADO": 0
    }
        ];
        function Ajax_DL_sec() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_Sectores",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Sec = JSON.parse(json_receiver);
                        Fill_DL_sec();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
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
                "url": "IN_PAC_MAN.aspx/Llenar_DL_Programa",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_Programa = JSON.parse(json_receiver);
                        Fill_DL_programa();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_DOC = [
  {
      "ID_DOCTOR": 0,
      "DOC_NOMBRE": "asdf",
      "DOC_APELLIDO": "asdf",
      "ID_ESTADO": 0
  }
        ];
        function Ajax_DL_DOC() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_DOC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_DOC = JSON.parse(json_receiver);
                        Fill_DL_DOC();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }
        var Mx_DL_orden_ate = [
 {
     "ID_ORDEN": 0,
     "ORD_COD": "asdf",
     "ORD_DESC": "asdf",
     "ID_ESTADO": 0
 }
        ];
        function Ajax_DL_orden_ate() {



            $.ajax({
                "type": "POST",
                "url": "IN_PAC_MAN.aspx/Llenar_DL_ordenATE",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_DL_orden_ate = JSON.parse(json_receiver);
                        Fill_DL_orden_ate();




                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }


        let objAJAX_Prev = 0;

        var arrPrev = [{
            "ID_PREVE": 0,
            "PREVE_COD": "",
            "PREVE_DESC": "",
            "ID_ESTADO": 0
        }];

        function fn_Req_Prev() {
            var objParam = JSON.stringify({
                "ID_PROC": $("#Procedencia").val()
            });

            objAJAX_Prev = $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Request_Prevision",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrPrev = resp.d;

                    //Llenar Ddl
                    $("#Prevision").empty();
                    //$("#Prevision").append(
                    //    $("<option>", {
                    //        "value": 0
                    //    }).text("<< TODOS >>")
                    //);
                    arrPrev.forEach((Item) => {
                        $("#Prevision").append(
                            $("<option>", {
                                "value": Item.ID_PREVE
                            }).text(Item.PREVE_DESC)
                        );
                    });

                    //Actualizar Exámenes
                    Mx_Dtt_exam02.length = 0;
                    Ajax_DataTable_examen02();
                    $("#DataTable_pac2 tbody").empty();
                    add_row();

                    fn_Req_Prog();
                },
                "error": (fail) => {
                    $("mdlError").modal();

                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                    $('#XXXXXXXX').removeClass('show');
                }
            });
        };

        let objAJAX_Prog = 0;

        var arrProg = [{
            "ID_PROGRA": 0,
            "ID_PREVE": 0,
            "PROGRA_DESC": "",
        }];

        function fn_Req_Prog() {
            var objParam = JSON.stringify({
                "ID_PREV": $("#Prevision").val()
            });

            objAJAX_Prog = $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Request_Programa",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrProg = resp.d;

                    //Llenar Ddl
                    $("#Programa").empty();
                    //$("#Programa").append(
                    //    $("<option>", {
                    //        "value": 0
                    //    }).text("<< TODOS >>")
                    //);
                    arrProg.forEach((Item) => {
                        $("#Programa").append(
                            $("<option>", {
                                "value": Item.ID_PROGRA
                            }).text(Item.PROGRA_DESC)
                        );
                    });

                    fn_Req_SubP();
                },
                "error": (fail) => {
                    $("mdlError").modal();

                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                }
            });
        };


        let objAJAX_SubP = 0;

        var arrSubP = [{
            "SubP_ID": 0,
            "SubP_Cod": "",
            "SubP_Desc": ""
        }];

        function fn_Req_SubP() {
            var objParam = JSON.stringify({
                "ID_PREV": $("#Prevision").val(),
                "ID_PROG": $("#Programa").val()
            });

            objAJAX_SubP = $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Request_SubPrograma",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrSubP = resp.d;

                    //Llenar Ddl
                    $("#Ddl_Prog02").empty();
                    if (arrSubP.length > 0) {
                        arrSubP.forEach((Item) => {
                            $("#Ddl_Prog02").append(
                                $("<option>", {
                                    "value": Item.SubP_ID
                                }).text(Item.SubP_Desc)
                            );
                        });
                    } else {
                        $("#Ddl_Prog02").append(
                            $("<option>", {
                                "value": 1
                            }).text("<Sin SubPrograma>")
                        );
                    }
                },
                "error": (fail) => {
                    $("mdlError").modal();

                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                }
            });
        };

        let objAJAX_Ciud = 0;
        var arrCiud = [{
            "text": "",
            "value": 0
        }];
        function fn_Req_Ciud() {
            objAJAX_Ciud = $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Data_Sel_Ciudad",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrCiud = resp.d;

                    //Llenar Ddl
                    $("#Cuidad").empty();
                    if (arrCiud.length > 0) {
                        arrCiud.forEach((Item) => {
                            $("#Cuidad").append(
                                $("<option>", {
                                    "value": Item.value
                                }).text(Item.text)
                            );
                        });
                    }

                    fn_Req_Comuna();
                },
                "error": (fail) => {
                    $("mdlError").modal();

                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                }
            });
        };

        let objAJAX_Comuna = 0;
        var arrComuna = [{
            "text": "",
            "value": 0
        }];
        function fn_Req_Comuna(ID_COM) {
            var objParam = JSON.stringify({
                "ID_CIUD": $("#Cuidad").val()
            });

            objAJAX_Comuna = $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Data_Sel_Comuna",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrComuna = resp.d;

                    //Llenar Ddl
                    $("#Comuna").empty();
                    if (arrComuna.length > 0) {
                        arrComuna.forEach((Item) => {
                            $("#Comuna").append(
                                $("<option>", {
                                    "value": Item.value
                                }).text(Item.text)
                            );
                        });

                        if (ID_COM != null) {
                            $("#Comuna").val(ID_COM);
                        }

                        //if (initializing == true) {
                        //    fn_Req_User_Location();
                        //    initializing = false;
                        //}
                    }
                },
                "error": (fail) => {
                    $("mdlError").modal();

                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                }
            });
        };

        let objAJAX_Location = 0;
        var objLocation = {
            "ID_CIUDAD": 0,
            "ID_COMUNA": 0
        };

        function fn_Req_User_Location() {
            var objParam = JSON.stringify({
                "ID_USER": Galletas.getGalleta("ID_USER")
            });

            $.ajax({
                "type": "POST",
                "url": "Ingreso_Ate.aspx/Get_Ciu_Com_User",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    objLocation = resp.d;
                    if ((objLocation.ID_CIUDAD != 0) && (objLocation.ID_COMUNA != 0)) {
                        $("#Cuidad").val(objLocation.ID_CIUDAD);
                        fn_Req_Comuna(objLocation.ID_COMUNA);
                    }
                },
                "error": (fail) => {
                    $("mdlError").modal();

                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
                }
            });
        };
    </script>
    <script>
        function Fill_DL_orden_ate() {
            $("#PrioridadTM").empty();
            for (y = 0; y < Mx_DL_orden_ate.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_orden_ate[y].ID_ORDEN
                }).text(Mx_DL_orden_ate[y].ORD_DESC).appendTo("#PrioridadTM");

            }
            $("#PrioridadTM").val(1);
        }
        function Fill_DL_DOC() {
            $("#Doctor").empty();
            for (y = 0; y < Mx_DL_DOC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_DOC[y].ID_DOCTOR
                }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
            }
        }
        function 


            Fill_DL_programa() {
            $("#Programa").empty();
            for (y = 0; y < Mx_DL_Programa.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_Programa[y].ID_PROGRA
                }).text(Mx_DL_Programa[y].PROGRA_DESC).appendTo("#Programa");
            }
        }
        function Fill_DL_sec() {
            $("#Sector").empty();
            for (y = 0; y < Mx_DL_Sec.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_Sec[y].ID_SECTOR
                }).text(Mx_DL_Sec[y].SECTOR_DESC).appendTo("#Sector");
            }
        }
        function Fill_DL_TP_ATE() {
            $("#TipoAtencion").empty();
            for (y = 0; y < Mx_DL_TP_ATE.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_TP_ATE[y].ID_TP_ATENCION
                }).text(Mx_DL_TP_ATE[y].TP_ATE_DESC).appendTo("#TipoAtencion");
            }
        }
        function Fill_DL_prevision() {
            $("#Prevision").empty();

            for (y = 0; y < Mx_DL_prevision.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_prevision[y].ID_PREVE
                }).text(Mx_DL_prevision[y].PREVE_DESC).appendTo("#Prevision");

            }
            Ajax_DataTable_examen02();

        }

        function Fill_DL_Rut() {
            let FechaREE = moment(Mx_Dtt2[0].PAC_FNAC).format("YYYY-MM-DD");


            $('#rut').attr("disabled", true);
            $("#Nom").val(Mx_Dtt2[0].PAC_NOMBRE);
            $("#Ape").val(Mx_Dtt2[0].PAC_APELLIDO);
            $("#fecha").val(FechaREE);
            $("#Edad").val(function () {
                var asd = moment($("#fecha").val()).format("DD-MM-YYYY");
                var array = asd.split("-");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
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
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                return total
            });
            $("#sex").val(Mx_Dtt2[0].ID_SEXO);//
            if (Mx_Dtt2[0].ID_SEXO == 2) {
                $('#checkBox2').removeAttr("disabled");
            }
            $("#Nacio").val(Mx_Dtt2[0].ID_NACIONALIDAD);
            $("#telfijo").val(Mx_Dtt2[0].PAC_FONO1);
            $("#Celular").val(Mx_Dtt2[0].PAC_MOVIL1);
            Ajax_DataTable_examen02();
            $("#direccion").val(Mx_Dtt2[0].PAC_DIR);
            $("#Email").val(Mx_Dtt2[0].PAC_EMAIL);

        };

        function Fill_AJAX_Ddl() {
            $("#Procedencia").empty();

            var procee = Galletas.getGalleta("USU_ID_PROC");
            if (procee == 0) {
                Mx_Ddl.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Procedencia");
                });
            }
            else {
                Mx_Ddl.forEach(aaa => {
                    if (aaa.ID_PROCEDENCIA == procee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PROCEDENCIA
                          }
                       ).text(aaa.PROC_DESC).appendTo("#Procedencia");
                    }

                });
            }
            //Ajax_DataTable();
        };

        //-----------------------------------------------------------------------------------------------------/
        //Llenar DropDownList Ciudad
        function Fill_Ddl_Cuidad() {
            $("#Cuidad").empty();
            for (y = 0; y < Mx_Ciudad.length; ++y) {
                $("<option>", {
                    "value": Mx_Ciudad[y].ID_CIUDAD
                }).text(Mx_Ciudad[y].CIU_DESC).appendTo("#Cuidad");
            }
        };
        //Llenar DropDownList Comuna
        function Fill_Ddl_Comuna() {
            $("#Comuna").empty();
            for (y = 0; y < Mx_Comuna.length; ++y) {
                $("<option>", {
                    "value": Mx_Comuna[y].ID_REL_CIU_COM
                }).text(Mx_Comuna[y].COM_DESC).appendTo("#Comuna");
            }
        };
        //-------------------------------------------------------------------------------------------------------/
        //var Mx_Dtt_4556 = [
        // {
        //     "ID_PROCEDENCIA": 0,
        //     "PROC_DESC": 0,
        //     "PROC_CANT_EXA": 0,
        //     "ID_ESTADO ": 0,
        //     "PRO_TIPO_I": 0,
        //     "TOTAL_ATE": 0,
        //     "PROC_CANT_EXA_BUSCA_DIAS": 0,
        //     "CONF_DIAS_FECHA_BUSCA_DIAS": 0,
        //     "CONF_DIAS_EXA_BUSCA_DIAS": 0,
        //     "ID_ESTADO_BUSCA_DIAS ": 0,
        //     "ID_PROCEDENCIA_BUSCA_DIAS": 0,
        //     "ID_CONF_DIAS_BUSCA_DIAS": 0,


        //     "AGEND_CUPO_NORMAL": 0,
        //     "AGEND_PRIORITARIO": 0,
        //     "AGEND_ESPONTANEO": 0,
        //     "TOTAL_AGEND_CUPO_NORMAL ": 0,
        //     "TOTAL_AGEND_PRIORITARIO": 0,
        //     "TOTAL_AGEND_ESPONTANEO": 0
        // }
        //];

        //function Ajax_DataTable() {




        //    var Data_Par = JSON.stringify({
        //        "fecha": "ssssss",
        //        "id": $("#Procedencia").val()
        //    });

        //    $.ajax({
        //        "type": "POST",
        //        "url": "Ingreso_Ate.aspx/Llenar_DataTable",
        //        "data": Data_Par,
        //        "contentType": "application/json;  charset=utf-8",
        //        "dataType": "json",
        //        "success": function (response) {
        //            var json_receiver = response.d;
        //            if (json_receiver != "null") {
        //                Mx_Dtt_4556 = JSON.parse(json_receiver);
        //                Fill_DataTable();




        //            } else {


        //                Hide_Modal();

        //                //$("#EM2 h5").text("Error:");
        //                //$("#button_modal").attr("class", "btn btn-danger");
        //                //$("#EM2 p").text("Sin resultados");
        //                //$("#EM2").modal();
        //            }
        //            //$("#Id_Conte").show();
        //            //$(".block_wait").fadeOut(500);
        //        },
        //        "error": function (response) {
        //            var str_Error = response.responseJSON.ExceptionType + "\n \n";
        //            str_Error = response.responseJSON.Message;
        //            alert(str_Error);



        //        }
        //    });
        //}

        function Fill_DL_SEXO() {
            $("#sex").empty();

            $("<option>", {
                "value": 0
            }).text("Seleccionar").appendTo("#sex");
            for (y = 0; y < Mx_DL_SEXO.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_SEXO[y].ID_SEXO
                }).text(Mx_DL_SEXO[y].SEXO_DESC).appendTo("#sex");
            }
        };
        function Fill_DL_NAC() {
            $("#Nacio").empty();

            $("<option>", {
                "value": 0
            }).text("Seleccionar").appendTo("#Nacio");
            for (y = 0; y < Mx_DL_NAC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_NAC[y].ID_NACIONALIDAD
                }).text(Mx_DL_NAC[y].NAC_DESC).appendTo("#Nacio");
            }
        };

        /// llenado examenes modal
        function Fill_DataTable_exam02() {
            $("#Div_Tabla2").empty();
            $("<table>", {
                "id": "DataTable_pac",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla2");

            $("#DataTable_pac").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_pac").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_pac thead").attr("class", "cabzera");
            $("#DataTable_pac thead").append(
                $("<tr>").append(

                    $("<th>", { "class": "textoReducido" }).text("Nº"),
                    $("<th>", { "class": "textoReducido" }).text("Codigo"),
                    $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                    //$("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                    $("<th>", { "class": "textoReducido" }).text("Carga")

                )
            );
            for (i = 0; i < Mx_Dtt_exam02.length; i++) {
                $("#DataTable_pac tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"

                        }).text(i + 1),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(Mx_Dtt_exam02[i].CF_COD),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido"
                        }).text(Mx_Dtt_exam02[i].CF_DESC),
                       //$("<td>", {
                       //    "align": "center",
                       //    "class": "textoReducido"
                       //}).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
                    $("<td>", {
                        "align": "center",
                        "class": "textoReducido"
                    }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
                    )
                )
            }
            $("#DataTable_pac").DataTable({
                "searching": true,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
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

        }
        ///llenar check  selecciondas
        function fill_llenado_tabla() {
            $("#DataTable_pac2 tbody").empty();
            for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                $("#DataTable_pac2 tbody").append(
                    $("<tr>", {
                        "class": "textoReducido manito",
                        "padding": "1px !important",
                    }).append(
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido negrita"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                                "data-cod": Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input negrita",
                                "value": Mx_Dtt_examcof[i].CF_COD
                            })
                        }())),
                        $("<td>", {
                            "align": "left",
                            "class": "textoReducido td_val1 negrita"
                        }).text(Mx_Dtt_examcof[i].CF_DESC),
                    //$("<td>", {
                    //    "align": "center",
                    //    "class": "textoReducido td_val3 negrita"
                    //}).text(Mx_Dtt_examcof[i].CF_PRECIO_AMB),
                       $("<td>", {
                           "align": "center",
                           "class": "textoReducido td_val2 negrita"
                       }).text(Mx_Dtt_examcof[i].CF_DIAS),
                       $("<td>", {
                           "align": "center"
                       }).html("<button type='button' class='btn btn-default btn-xs borrar negrita' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                        $("<td>", {
                            "align": "center"
                        }).html(function () {


                            if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                                return "<button type='button' class='btn btn-print btn-xs CEstado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                            } else {
                                return "<button type='button' class='btn btn-success btn-xs Activado negrita' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
                            }


                        }())
                    )
                )
            }
            add_row();
        }






        function success(xxid, xxcod, xtxis) {
            if (Mx_Dtt_exam03.length == 0) {
                $("input[data-id='" + xxid + "']").val(xxcod);
            } else if (Mx_Dtt_exam03.length == 1) {

                var repetido = 0;
                for (z = 0; z < Mx_Dtt_examcof.length; z++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == Mx_Dtt_exam03[0].ID_CODIGO_FONASA) {
                        repetido++
                    }
                }
                if (repetido == 0) {
                    if (xxid != 0) {
                        Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
                        for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == xxid) {
                                Mx_Dtt_examcof.splice(i, 1);
                            }
                        }

                    }

                    $("input[data-id='" + xxid + "']").val(Mx_Dtt_exam03[0].CF_COD);
                    $("input[data-id='" + xxid + "']").parent().parent().children(".td_val1").text(Mx_Dtt_exam03[0].CF_DESC);
                    $("input[data-id='" + xxid + "']").parent().parent().children(".td_val2").text(Mx_Dtt_exam03[0].CF_DIAS);
                    $("input[data-id='" + xxid + "']").parent().parent().children(".td_val3").text(Mx_Dtt_exam03[0].CF_PRECIO_AMB);
                    $("input[data-id='" + xxid + "']").attr("data-cod", Mx_Dtt_exam03[0].CF_COD);
                    $("input[data-cod='" + Mx_Dtt_exam03[0].CF_COD + "']").attr("data-id", Mx_Dtt_exam03[0].ID_CODIGO_FONASA);

                    Mx_Dtt_examcof.push(Mx_Dtt_exam03[0]);
                    Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"

                    add_row();
                } else {
                    $("input[data-id='" + xxid + "']").val(xxcod);
                }
            } else if (Mx_Dtt_exam03.length > 1) {

                $("#Div_Tabla4").empty();
                $("<table>", {
                    "id": "DataTable_pac3",
                    "class": "display",
                    "width": "100%",
                    "cellspacing": "0"
                }).appendTo("#Div_Tabla4");

                $("#DataTable_pac3").append(
                    $("<thead>"),
                    $("<tbody>")
                );
                $("#DataTable_pac3").attr("class", "table table-hover table-striped table-iris");
                $("#DataTable_pac3 thead").attr("class", "cabzera");
                $("#DataTable_pac3 thead").append(
                    $("<tr>").append(

                        $("<th>", { "class": "textoReducido" }).text("Nº"),
                        $("<th>", { "class": "textoReducido" }).text("Codigo"),
                        $("<th>", { "class": "textoReducido" }).text("Descripcion"),
                        $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
                        $("<th>", { "class": "textoReducido" }).text("Carga")

                    )
                );
                for (i = 0; i < Mx_Dtt_exam03.length; i++) {
                    $("#DataTable_pac3 tbody").append(
                        $("<tr>", {
                            "class": "textoReducido manito",
                            "padding": "1px !important",
                        }).append(
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"

                            }).text(i + 1),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).text(Mx_Dtt_exam03[i].CF_COD),
                            $("<td>", {
                                "align": "left",
                                "class": "textoReducido"
                            }).text(Mx_Dtt_exam03[i].CF_DESC),
                           $("<td>", {
                               "align": "center",
                               "class": "textoReducido"
                           }).text(Mx_Dtt_exam03[i].CF_PRECIO_AMB),
                        $("<td>", {
                            "align": "center",
                            "class": "textoReducido"
                        }).html("<div class='checkbox checkbox-success sub_pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='F" + i + "' value='" + Mx_Dtt_exam03[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='F" + i + "'></label></div>")
                        )
                    )

                }
                $("#eModal3").modal();

            }
        }
        //function Fill_DataTable() {

        //    for (i = 0; i < Mx_Dtt_4556.length; i++) {
        //        if ($("#Procedencia").val() == Mx_Dtt_4556[i].ID_PROCEDENCIA) {


        //            $("#Total").val(function () {
        //                var resu = 0;
        //                resu = Mx_Dtt_4556[i].AGEND_CUPO_NORMAL - Mx_Dtt_4556[i].TOTAL_AGEND_CUPO_NORMAL;
        //                if (resu < 0) {
        //                    resu = 0;
        //                }
        //                return resu;

        //            });
        //            $("#Actuales").val(function () {

        //                var resu = 0;
        //                resu = Mx_Dtt_4556[i].AGEND_PRIORITARIO - Mx_Dtt_4556[i].TOTAL_AGEND_PRIORITARIO;
        //                if (resu < 0) {
        //                    resu = 0;
        //                }
        //                return resu;
        //            });
        //            $("#Disponibles").val(function () {
        //                var resu = 0;
        //                resu = Mx_Dtt_4556[i].AGEND_ESPONTANEO - Mx_Dtt_4556[i].TOTAL_AGEND_ESPONTANEO;
        //                if (resu < 0) {
        //                    resu = 0;
        //                }
        //                return resu;
        //            });


        //            //var p1 = Mx_Dtt[i].AGEND_CUPO_NORMAL - Mx_Dtt[i].TOTAL_AGEND_CUPO_NORMAL;
        //            //var p2 = Mx_Dtt[i].AGEND_PRIORITARIO - Mx_Dtt[i].TOTAL_AGEND_PRIORITARIO;
        //            //var p3 = Mx_Dtt[i].AGEND_ESPONTANEO - Mx_Dtt[i].TOTAL_AGEND_ESPONTANEO;
        //            //var total = p1 + p2 + p3;
        //            //if (p1 == 0 && p2 == 0 && p3 == 0) {
        //            //    $('#BtnSaveAll').attr("disabled", false);
        //            //} else {
        //            //    uu = Mx_Dtt[i].CONF_DIAS_EXA_BUSCA_DIAS - total;
        //            //    if (uu <= 0) {
        //            //        $('#BtnSaveAll').attr("disabled", true);
        //            //    } else {
        //            //        $('#BtnSaveAll').attr("disabled", false);
        //            //    }
        //            //}
        //        }
        //    }
        //}
        function Fill_Ddl_diagnostico() {
            $("#DdlDiagnostico").empty();
            for (y = 0; y < Mx_Diagnostico.length; ++y) {
                $("<option>", {
                    "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
                }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico");
            }
            $("#DdlDiagnostico").val(1);


            $("#DdlDiagnostico2").empty();
            for (y = 0; y < Mx_Diagnostico.length; ++y) {
                $("<option>", {
                    "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
                }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico2");
            }
            $("#DdlDiagnostico2").val(1);
        };
    </script>
    <style>
        .negrita {
        font-weight:700;
        }


        .alertas {
            margin-top: 180px;
            text-align: center;
        }

        .manitos2 {
            cursor: pointer;
        }

        .textoReducido {
            font-size: 11px;
        }

        .ancho-columna {
            height: 10%;
            padding: -35px;
        }

        .highlights {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .topbuttom {
            display: block;
            height: 80px;
            width: 100%;
        }

        .topbuttom2 {
            display: block;
            height: 80px;
        }

        .textbot {
            display: block;
            height: 22px;
            width: 100%;
        }

        .textbotLeft {
            display: block;
            height: 28px;
            width: 100%;
        }

        .cabzera {
            background: #46963f;
            color: white;
        }

        .espera {
            background: #c7ff00;
        }

        .atendido {
            background: #1fc12c;
            color: white;
        }

        #XXXXXXXX {
            z-index: 9000;
            width: 100%;
            position: fixed;
            left: 0px;
            top: 0px;
            display: flex;
            display: -webkit-flex;
            flex-flow: row nowrap;
            justify-content: center;
            color: #444;
            border: 0;
            border-radius: 2px;
            text-decoration: none;
            transition: opacity 0.2s ease-out;
            opacity: 0;
            margin-top: 60px;
        }

            #XXXXXXXX div {
                font-size: 18px;
                border: none;
                outline: none;
                background-color: #014B5D;
                color: white;
                padding: 8px;
                border-radius: 4px;
                font-size: 15px;
            }



            #XXXXXXXX.show {
                opacity: 1;
            }

        #content {
            height: 2000px;
        }

        @media screen and (min-width: 558px) {
            .topbuttom2 {
                width: 100%;
            }
        }

        /*CHECKBOX DE FELIPE*/
        .div-chk-cont {
            display: flex;
            display: -webkit-flex;
            flex-flow: row wrap;

            justify-content: space-between;
            align-items: center;
        }

        .div-chk-cont > * {
            height: 12px;
            margin-bottom: 0.3rem;
        }

        input[type=checkbox] ~ .div-chk {
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;

            display: inline;
            min-height: 23.5px;
        }

        input[type=checkbox] ~ .div-chk i {
            font-size: 15px;
            color: #46963f;
        }
        input[type=checkbox] ~ .div-chk span {
            font-size: 10px;
        }
        
        input[type=checkbox] ~ .div-chk i:nth-child(1) {
            display: inline-block;
        }

        input[type=checkbox] ~ .div-chk i:nth-child(2) {
            display: none;
        }

        input[type=checkbox]:checked ~ .div-chk i:nth-child(1) {
            display: none;
        }

        input[type=checkbox]:checked ~ .div-chk i:nth-child(2) {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
<%--        <!-- modal Datos Extras -->
    <div id="modal_Datos_extras" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Datos Adicionales</h4>
                </div>
                <div class="modal-body">
                    <div id="rowDigoxina" class="row" style="padding-right: 5px; padding-left: 2px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Digoxina: </label>
                        </div>                   
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisDigoxina" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraDigoxina" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowTeofilina" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Teofilina: </label>
                        </div>  
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisTeofilina" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraTeofilina" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowAminofilina" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Aminofilina: </label>
                        </div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisAminofilina" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraAminofilina" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowPrimidona" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Primidona: </label>
                        </div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisPrimidona" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraPrimidona" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowTeofilinaBK" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Teofilina BK: </label>
                        </div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisTeofilinaBK" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraTeofilinaBK" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowTiempo_De_Protrombina" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Tiempo de Protrombina: </label>
                        </div>
                        <div class="col-md-4"></div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Paciente con Taco:</label>
                            <input type='text' id="txtDosisTiempo_De_Protrombina" class="form-control textoReducido"/>              
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="button_modal_Datos_extras" class="btn btn-success" data-dismiss="modal">Guardar</button>
                </div>
            </div>
        </div>
    </div>--%>

    <!-- Modal -->
    <div id="MOdal_PAGO" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title2" class="modal-title">Error</h4>
                </div>
                <div id="modalpccc" class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" id="b" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="button_modal_pago" class="btn btn-success" data-dismiss="modal">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
     <div id="XXXXXXXX" class="tobackinfo">
  <div id="xxx_xxx">
    
  </div>
  </div>

    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal" class="btn btn-danger" data-dismiss="modal">
                        <span>Aceptar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss5">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla4" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnexarepetido" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnguardar" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs -->
    <div class="card border-bar">
        <div class="card-header bg-bar p-2">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-sign-in"></i>
                Ingreso de Atención
            </h5>
        </div>
        <div class="card-body p-3">
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                        <div class="col-md checkbox checkbox-success">                    
                            <input id="checkBox999" value="rutee" type="checkbox"/> <label class="textoReducido" style="padding-left: 0px !important;" for="checkBox999">RUT</label><input id="checkBox888" value="DNI" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox888">DNI:</label><input id="checkBox8887" value="DNI" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox8887">N°Ate:</label>
                           
                            <input type='text' id="rut" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="12.345.789-0" />
                            <input type='text' id="dni" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="D.N.I" />
                            <input type='text' id="Naten" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="N° Atención" />
                                 
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">RUT:</label>
                                <input type='text' id="txtrut" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" disabled="disabled"/>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nombres:</label>
                                <input type='text' id="Nom" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Apellidos:</label>
                                <input type='text' id="Ape" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <%--     </div>
                        <div class="row">--%>
                            <div class="col-lg">
                                <label class="textoReducido">F.Nacimiento:</label>
                                <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                    <input type="date" min="0001-01-01" max="2018-12-01" id="fecha" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="Fecha"/>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                                <style>
                                    .glyphicon {
                                        display: inline-block;
                                        font-family: FontAwesome;
                                        font-style: normal;
                                        font-weight: normal;
                                        line-height: 1;
                                        -webkit-font-smoothing: antialiased;
                                        -moz-osx-font-smoothing: grayscale;
                                    }

                                    .glyphicon-arrow-left:before {
                                        content: "\f053";
                                    }

                                    .glyphicon-arrow-right:before {
                                        content: "\f054";
                                    }
                                </style>
                                <%--<script type="text/javascript">
                 
                                    $(function () {
                                        $('#datetimepicker1').datetimepicker(
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
                                                minView: 2,
                                                useCurrent: true

                                            })
                                    });
                                </script>--%>
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Edad:</label>
                                <input type='text' id="Edad" class="form-control textoReducido negrita" style="font-size:14px; text-align:center" readonly="true" placeholder="" disabled="disabled"/>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Sexo:</label>
                                <select id="sex" class="form-control textoReducido negrita" style="font-size:14px;">
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg checkbox checkbox-success">
                                <input id="checkBox2" type="checkbox" value="SoyFur" />
                                <label for="checkBox2" class="textoReducido">F.U.R:</label>
                                <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                    <input type='text' id="FUR" class="form-control textoReducido negrita" style="font-size:14px;"" readonly="true" placeholder="Fecha" />
                                    <span id="fur" class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                                <style>
                                    .glyphicon {
                                        display: inline-block;
                                        font-family: FontAwesome;
                                        font-style: normal;
                                        font-weight: normal;
                                        line-height: 1;
                                        -webkit-font-smoothing: antialiased;
                                        -moz-osx-font-smoothing: grayscale;
                                    }

                                    .glyphicon-arrow-left:before {
                                        content: "\f053";
                                    }

                                    .glyphicon-arrow-right:before {
                                        content: "\f054";
                                    }
                                </style>
                                <script type="text/javascript">
                                    ////////////////////////////////////
                                    ////////////////////////////////////
                                    $(function () {
                                        $('#datetimepicker3').datetimepicker(
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
                                                minView: 2,
                                                useCurrent: true

                                            })
                                    });
                                </script>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nacionalidad:</label>
                                <select id="Nacio" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tel. Fijo:</label>
                                <input type='text' id="telfijo" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Celular:</label>
                                <input type='text' id="Celular" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Dirección:</label>
                                <input type='text' id="direccion" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Ciudad:</label>
                                <select id="Cuidad" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Comuna:</label>
                                <select id="Comuna" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-lg">
                                    <label class="textoReducido">Email:</label>
                                    <input type='text' id="Email" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="Irislab@irislab.cl" />
                                </div>
<%--                                <div class="col-lg">
                                    <label class="textoReducido">Nº Interno:</label>
                                    <input type='text' id="Interno" class="form-control textoReducido" placeholder="" />
                                </div>--%>
                                <div class="col-lg-5">
                                    <label class="textoReducido">observaciones permanentes del paciente:</label>
                                    <input type='text' id="obdser" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 1</label>
                                    <select id="DdlDiagnostico" class="form-control textoReducido negrita" style="font-size:14px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                               <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 2</label>
                                    <select id="DdlDiagnostico2" class="form-control textoReducido negrita" style="font-size:14px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Antecedentes de la Atención  </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg">
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Procedencia:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none;" id="chkMant_0" value="0" checked="checked" type="checkbox" />
                                    <label class="div-chk" for="chkMant_0">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Procedencia" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-sm">
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Previsión:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none" id="chkMant_3" value="3" checked="checked" type="checkbox" />
                                    <label class="div-chk" for="chkMant_3">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Prevision" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Doctor:</label>
                                <select id="Doctor" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tipo de Atención:</label>
                                <select id="TipoAtencion" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
<%--                     <div class="col-sm">
                            <label class="textoReducido">Cupo Normal:</label>
                            <input type='text' id="Total" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: yellow; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Prioritario:</label>
                            <input type='text' id="Actuales" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: #f4abe7; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Espontáneo:</label>
                            <input type='text' id="Disponibles" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: chartreuse; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Sub-Atención:</label>
                            <select id="sub_atencion" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="0">Seleccionar</option>
                                <option value="1">Agendado Cupo normal</option>
                                <option value="2">Agendado Prioritario</option>
                                <option value="3">Agendado Espontáneo</option>
                                
                            </select>
                        </div>--%>
                            <div class="col-lg">
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Programa:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none" id="chkMant_1" value="1" checked="checked" type="checkbox" />
                                    <label class="div-chk" for="chkMant_1">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Programa" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Sub Programa:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none;" id="chkMant_2" value="2" checked="checked" type="checkbox" />
                                    <label class="div-chk" for="chkMant_2">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Ddl_Prog02" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="1">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Sector:</label>
                                <select id="Sector" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-lg">
                                <label class="textoReducido">Localizacion:</label>
                                <select id="Localizacion" class="form-control textoReducido negrita" style="font-size:14px;"disabled="disabled">
                                    <option value="volvo">TOMA DE MUESTRA</option>
                                </select>
                            </div>
                            <div class="col-lg-1">
                                <label class="textoReducido">Cama:</label>
                                <input type='text' id="cama" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="0" disabled="disabled" value="0" />
                            </div>
                      <div class="col-sm">
                            <label class="textoReducido">V.I.H:</label>
                            <input type='text' id="vih" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" text-align: center;" />
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">Observacion de la Atencion:</label>
                                <input type='text' id="obs_ate" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Autorizo a Retirar:</label>
                                <input type='text' id="Autorizo_retirar" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Prioridad TM:</label>
                                <select id="PrioridadTM" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                          <div class="col-sm">
                                <label class="textoReducido">N° Orden Clínica</label>
                                     <input type='text' id="NumeroClinico" class="form-control textoReducido negrita" style="font-size:14px;text-align:center;" placeholder=""/>
                            </div>


                            <%--   </div>
                         <div class="row">--%>
                            
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Agregar Exámenes </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-sm">
                        <%--                    <div id="Div_Tabla" style="width: 100%;" class="highlights">                     
                         <table style="width:100%" class="table table-bordered">
                              <tr>
                                <th style="width: 20%;">Codigo Fonasa</th>
                                <th style="width: 100%;">Descripcion</th>
                                <th style="width: 50%;">Dias Proceso</th>
                              </tr>
                              <tr>
                                <td> <input type='text' id="Examen01" class="form-control textoReducido" placeholder=""/></td>
                                <td ><label id="desc1" style="margin-top:8px;"></label></td>
                                <td ><label id="dias1" style="margin-top:8px;"></label></td>
                              </tr>
                        </table> 
                    </div>--%>
                        <div id="Div_Tabla3" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>

            </div>
            <div class="container" style="max-width: 100%; border: 0px solid #fff;">
                <div class="row">
                    <div class="col-sm-3">
                        <button id="Examen" type="button" class="btn btn-danger btn-block">
                            <br />
                            <i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px;"></i>
                            <p style="margin-top: 2px;">Examen</p>
                        </button>
                    </div>
                    <div class="col-sm-1">
                        <button id="btnInstructivos" type="button" class="btn btn-limpiar btn-block">
                            <br />
                            <%--<i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px;"></i>--%>
                            <p style="margin-top: 2px; font-size:13px">Indicaciones</p>
                            <p style="margin-top: 0px; font-size:13px">Exámenes</p>
                        </button>
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-3" style="justify-content: flex-end;">
                        <button id="Btnnew" type="button" class="btn btn-info btn-block">
                            <br />
                            <i class="fa fa-plus-square" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Nuevo</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                        <button id="BtnSaveAll" type="button" class="btn btn-primary btn-block">
                            <br />
                            <i class="fa fa-fw fa-save" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Guardar</p>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
