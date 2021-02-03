/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\js/Galletas.js" />
/// <reference path="C:\Users\Administrador\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda Rebuild\Presentacion\js/RUT.js" />


function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
$.getScript("/js/moment.js");
var xId = 0;
var selected = new Array();
var verrut = 0;
var ids = new Array();
var sifi = 0;
var MX_HO_ExamenCodigo = new Array();
var Mx_HO_Examen_MULTIPLE_OMI = new Array();
var checked_rdn = 0;
var agregar_folio = 0;
var omi_save = 0;
var ff = 0;
//Class AJAX
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
        "timeout": 20000,
        "success": this.success,
        "error": this.error
    });
};

let timer = 5000;
let objAJAX_Voucher = new Class_AJAX();
objAJAX_Voucher.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";
objAJAX_Voucher.success = (resp) => {
    console.log(`[ OK ] Impresión Voucher Atención`);
    console.log(resp);
    console.log(``);

    setTimeout(() => {
        objAJAX_Etiq.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);

};
objAJAX_Voucher.error = (fail) => {
    console.log(`[ERROR] Impresión Voucher Atención`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        objAJAX_Etiq.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);
};

let objAJAX_Etiq = new Class_AJAX();
objAJAX_Etiq.url = "http://localhost:9990/Printer/Imp_Etiquetas";
objAJAX_Etiq.success = (resp) => {
    console.log(`[ OK ] Impresión Etiquetas`);
    console.log(resp);
    console.log(``);

    setTimeout(() => {
        objAJAX_LugarTM.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);

};
objAJAX_Etiq.error = (fail) => {
    console.log(`[ERROR] Impresión Etiquetas`);
    console.log(fail);
    console.log(``);

    setTimeout(() => {
        objAJAX_LugarTM.callback([
            Mx_Dt023.ID_Atencion
        ]);
    }, timer);
};

let objAJAX_LugarTM = new Class_AJAX();
objAJAX_LugarTM.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";
objAJAX_LugarTM.success = (resp) => {
    console.log(`[ OK ] Voucher LugarTM`);
    console.log(resp);
    console.log(``);

    var str_Error = "La impresión se ha completado exitosamente"
    $("#title").text("Solicitud de voucher");
    $("#button_modal").attr("class", "btn btn-success");
    $("#mError_AAH p").text(str_Error);
    $("#mError_AAH").modal();

    setTimeout(() => {
        $("#mError_AAH").modal("hide");
    });
};
objAJAX_LugarTM.error = (fail) => {
    console.log(`[ERROR] Impresión Etiquetas`);
    console.log(fail);
    console.log(``);

};


let initializing = true;
$(document).ready(function () {
    if ($('#XXXXXXXX').length) {
        var scrollTrigger = 100, // px
            backToTop = function () {
                var scrollTop = $(window).scrollTop();
                if (scrollTop > scrollTrigger && $("#Nom").val() != "") {

                    $("#xxx_xxx").text("Rut: " + $("#rut").val() + " Nombre: " + $("#Nom").val() + " " + $("#Ape").val() + " Edad: " + $("#Edad").val() + " Sexo: " + $("#sex option:selected").text())
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
            objAJAX_Voucher.callback([
                 Mx_Dt023.ID_Atencion
            ]);



        }
    });
    //$("#Div_Tabla").hide();


    $("#agregar_op").click(function () {

        if (Mx_Dtt_examcof.length == 0) {
            agregar_folio = 0;
        } else {
            buscar_omi_nuevo_folio();
            omi_save = $("#Avis").val();
            //$("#Avis").val("");
        }


    });

    Ajax_DL_SEXO();
    Ajax_DL_NAC();
    fn_Req_Ciud();
    //Ajax_Ciudad();
    Ajax_Diagnostico();
    Ajax_DataTable_examen0GObal();
    Ajax_DL_sec();
    Ajax_DL_TP_ATE();
    Ajax_DL_orden_ate();

    Ajax_DL_DOC();
    Call_AJAX_Ddl();
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

    $("#checkBox2").prop('checked', false);//solo los del objeto
    $('#FUR').attr("disabled", true);
    $('#checkBox2').attr("disabled", true);
    $('#TipoAtencion').attr("disabled", true);
    $("#fur").css("pointer-events", "none");
    var f = moment().format("DD-MM-YYYY");
    $("#fecha").val(f);

    //Ajax_DataTable();
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
    $("#DataTable_pac2").attr("class", "table table-striped table-hover table-iris");
    $("#DataTable_pac2 thead").attr("class", "cabzera");
    $("#DataTable_pac2 thead").append(
        $("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("Codigo Fonasa"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
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
        fn_Req_Ciud();
        //Ajax_Ciudad();
        $("#checkBox2").prop('checked', false);
        $('#FUR').attr("disabled", true);
        $('#checkBox2').attr("disabled", true);
        $("#fur").css("pointer-events", "none");
        var f = moment().format("DD-MM-YYYY");
        $("#fecha").val(f);
        $("#DNI").val("");
        $("#Avis").val("");
        $("#FUR").val(f);
        $('#rut').removeAttr("disabled");
        $('#rut').val("");
        $("#Nom").val("");
        $("#Ape").val("");
        $("#Edad").val("");
        $("#telfijo").val("");
        $("#Celular").val("");
        $("#Email").val("");
        $("#direccion").val("");
        $("#Diag2").val("");
        $("#Diag").val("");
        $("#PrioridadTM").val(1);
        Mx_Dtt_examcof.length = 0;
        Mx_examenes_avis.length = 0;
        $("#DataTable_pac2 tbody").empty();
        add_row();
        verrut = 0;
        Mx_Dtt2.length = 0;
        var str_Error = "Campos listo para el ingreso del nuevo paciente: ";
        $("#title").text("Nuevo Paciente");
        $("#button_modal").attr("class", "btn btn-success");
        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();
        $('#XXXXXXXX').removeClass('show');

        //Seleccionar Ddl
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
        var asd = $("#fecha").val();
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
                sifi = 1;

                $('#XXXXXXXX').removeClass('show');
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
                    //for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    //}
                }
                if (xxxer == true) {
                    for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 1026) {
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
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    //}
                }
                if (xxxer == true) {
                    for (x = 0; x < Mx_Dtt_exam02_respaldo.length; x++) {
                        if (Mx_Dtt_exam02_respaldo[x].ID_CODIGO_FONASA == 66) {
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
                    if (Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 1026 || Mx_Dtt_examcof[z].ID_CODIGO_FONASA == 66) {
                        Mx_Dtt_examcof.splice(z, 1);
                        xxxer = true;
                    }
                    fill_llenado_tabla();
                    //}
                }
            }
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
    $("#DNI").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {
            Ajax_busca_DNI();
        }
    });
    $("#Avis").keydown(function EnterEvent(e) {
        if (e.keyCode == 13) {

            if (Mx_Dtt_examcof.length == 0) {
                buscar_avis();
            } else {
                $("#mError_AAH2").modal('hide');
                var str_Error = "¿Estimado usurario desea borrar datos actuales y buscar datos nuevo con el N° OMI ingresado?";
                $("#title8").text("Borrar datos actuales");
                $("#mError_AAH2 p").text(str_Error);
                $("#mError_AAH2").modal();

            }

        }
    });

    //-*-*-*-*-*-*-*-*-* TABLA DINAMICA -*-*-*-*-*-*-*-*-*-*-*
    $("#button_modal2").click(function () {
        buscar_avis();
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

        //if ($("#interno").val() == "") {

        //    $("#interno").css({
        //        "border-color": "red"
        //    });
        //    $("#interno").parent().css({
        //        "color": "red"
        //    });
        //} else {
        //    sum += 1;
        //    $("#interno").css({
        //        "border-color": "#ccc"
        //    });
        //    $("#interno").parent().css({
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
                verrut = 1;
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
    });
    //$("#X_SIN_RUT").click(function () {
    //    AJAX_SIN_RUT();
    //    $('#eModal_Sinrut').modal('show');
    //});
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
});
var Mx_Dtt_4556 = [
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
    "ID_CONF_DIAS_BUSCA_DIAS": 0,
    "AGEND_CUPO_NORMAL": 0,
    "AGEND_PRIORITARIO": 0,
    "AGEND_ESPONTANEO": 0,
    "TOTAL_AGEND_CUPO_NORMAL ": 0,
    "TOTAL_AGEND_PRIORITARIO": 0,
    "TOTAL_AGEND_ESPONTANEO": 0
}
];

//function Ajax_DataTable() {
//    var Data_Par = JSON.stringify({
//        "fecha": "ssssss",
//        "id": $("#Procedencia").val()
//    });

//    $.ajax({
//        "type": "POST",
//        "url": "Ingreso_Ate_Omi.aspx/Llenar_DataTable",
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
//            }
//        },
//        "error": function (response) {
//            var str_Error = response.responseJSON.ExceptionType + "\n \n";
//            str_Error = response.responseJSON.Message;
//            alert(str_Error);



//        }
//    });
//}
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
                            "class": "td_input",
                            "value": ""
                        })
                    }())),
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido td_val1"
                    }).text(""),
                   $("<td>", {
                       "align": "center",
                       "class": "textoReducido td_val2"
                   }).text(""),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
                                        $("<td>", {
                                            "align": "center"
                                        }).html("<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")
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
            sifi = 1;

            $('#XXXXXXXX').removeClass('show');
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
                            "class": "td_input",
                            "value": ""
                        })
                    }())),
                    $("<td>", {
                        "align": "left",
                        "class": "textoReducido td_val1"
                    }).text(""),
                   $("<td>", {
                       "align": "center",
                       "class": "textoReducido td_val2"
                   }).text(""),
                $("<td>", {
                    "align": "center"
                }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'>Eliminar</i></button>"),
                                        $("<td>", {
                                            "align": "center"
                                        }).html("<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='0' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>")
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
  }
];
Mx_Dtt_examcof.length = 0;

//-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/
var Mx_Dtt_exam02_respaldo_global = [
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
function Ajax_DataTable_examen0GObal() {

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_tabla_exam2_global",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam02_respaldo_global = JSON.parse(json_receiver);
            } else {


            }
        },
        "error": function (response) {
            console.log(response);



        }
    });
}
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
var Mx_Dt023 = [
  {
      "CORELATIVO": 0,
      "ID_PREINGRESO": 0
  }
];
function Ajax_guardar() {
    modal_show();
    var fur = 0;
    var OB = "";
    var ID = 0;
    var ed = (function () {
        var asd = $("#fecha").val();
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
        var asd = $("#fecha").val();
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
        var asd = $("#fecha").val();
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
    var HO_CC = 0;

    ids = new Array();
    for (x = 0; x < Mx_Dtt_examcof.length; x++) {

        for (z = 0; z < Mx_Dtt_exam02_respaldo_global.length; z++) {
            if (Mx_Dtt_examcof[x].ID_CODIGO_FONASA == Mx_Dtt_exam02_respaldo_global[z].ID_CODIGO_FONASA) {
                var xtotal = parseFloat(Mx_Dtt_exam02_respaldo_global[z].CF_PRECIO_AMB);
                TOTAL += xtotal;
                if (Mx_Dtt_examcof[x]["CF_MULTIPLICADOS"] == undefined) {
                    Mx_Dtt_examcof[x]["CF_MULTIPLICADOS"] = "";
                }
                var objId = {
                    "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
                    "id_PER": Mx_Dtt_exam02_respaldo_global[z].ID_PER,
                    "Valor": Mx_Dtt_exam02_respaldo_global[z].CF_PRECIO_AMB,
                    "HO_CC": Mx_Dtt_examcof[x].HO_CC,
                    "CF_ESTADO_EXAMEN": Mx_Dtt_examcof[x].CF_ESTADO_EXAMEN,
                    "CF_MULTIPLICADOS": Mx_Dtt_examcof[x].CF_MULTIPLICADOS,
                    "CODIGO_TEST": Mx_Dtt_examcof[x].CODIGO_TEST
                };
                ids.push(objId);
            }
        }
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
        var OB = "";
        ID = "0";
        //HO_CC = Mx_AVIS[0].N_OMI;
    } else {
        var OB = "";
        ID = "0";
        //HO_CC = Mx_Dtt2[0].N_OMI;
    }
    var diag = 0;
    var diag2 = 0;
    if ($("#Diag2").val() == "") {
        diag = 0;
    } else {
        diag = Mx_DL_Diag[0].ID_DIAGNOSTICO;
    }
    if ($("#Diag3").val() == "") {
        diag2 = 0;
    } else {
        diag2 = Mx_DL_Diag2[0].ID_DIAGNOSTICO;
    }
    var f = moment().format("DD-MM-YYYY");
    let hocc = "0";
    if ($("#Avis").val() == "") {

    } else {
        hocc = $("#Avis").val();
    }
    var Data_Par = {
        //-*-*-*-*Datos Paciente-*-*-*-*-*-*
        "RUT_PAC": $('#rut').val(),
        "HO_CC": hocc,
        "FUR": fur,
        "Paridad": verrut,
        "ID_PAC": ID,
        "OB": OB,
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        "Procedencia": $("#Procedencia").val(),
        "Programa": $("#Programa").val(),
        "Sector": $("#Sector").val(),
        "TipoAtencion": $("#TipoAtencion").val(),
        "PrioridadTM": $("#PrioridadTM").val(),
        "Doctor": $("#Doctor").val(),
        "Prevision": $("#Prevision").val(),
        //-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/-*/
        "EDAD": ed,
        "MES": me,
        "DIA": di,
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        "TOTAL": TOTAL,
        "FECHA_PRE": f,
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-    
        "ids": ids,
        "ATE_SAYDEX": "",
        "DIAG1": diag,
        "DIAG2": diag2,
        "interno": 1,
        "sub_atencion": 1,
        "vih": $("#vih").val(),
        "NOMBRE_PAC": $("#Nom").val(),
        "APE_PAC": $("#Ape").val(),
        "FNAC_PAC": $("#fecha").val(),
        "ID_SEXO": $("#sex").val(),
        "ID_NACIONALIDAD": $("#Nacio").val(),
        "FONO1": $("#telfijo").val(),
        "MOVIL1": $("#Celular").val(),
        "ID_CIU_COM": $("#Comuna").val(),
        "DIR_PAC": $("#direccion").val(),
        "EMAIL_PAC": $("#Email").val(),
        "ID_SUBP": $(`#Ddl_Prog02`).val(),
        "DNI": $("#DNI").val()
    };

    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Guardar_TodoByVal",
        "data": JSON.stringify(Data_Par),
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
                Mx_Dt023 = JSON.parse(json_receiver);
                Hide_Modal();
                Ajax_DL_SEXO();
                //Ajax_DataTable();
                Ajax_DL_NAC();
                //Ajax_Ciudad();
                fn_Req_Ciud();
                $("#checkBox2").prop('checked', false);
                $('#FUR').attr("disabled", true);
                $('#checkBox2').attr("disabled", true);
                $("#fur").css("pointer-events", "none");
                var f = moment().format("DD-MM-YYYY");
                $("#fecha").val(f);
                $("#Avis").val("");
                $("#FUR").val(f);
                $('#rut').removeAttr("disabled");
                $('#rut').val("");
                $('#DNI').val("");
                $("#Nom").val("");
                $("#Ape").val("");
                $("#Edad").val("");
                $("#telfijo").val("");
                $("#Celular").val("");
                $("#Email").val("");
                $("#PrioridadTM").val(1);
                $("#direccion").val("");
                Mx_Dtt_examcof.length = 0;
                $("#DataTable_pac2 tbody").empty();
                add_row();
                verrut = 0;
                Mx_Dtt2.length = 0;

                $("#title2").text("Ingreso de Atención realizado");
                $("#modalpccc").html("<p><strong>Nº Atención:</strong> <strong style='font-size:20px;'>" + Mx_Dt023.Correlativo + "</strong>\n ¿Desea imprimir Etiquetas?</p>");
                $("#MOdal_PAGO").modal();
                $('#XXXXXXXX').removeClass('show');

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
//--------------------------------------- JASON DIAGNOSTICO --------------------------------------------------------------------|
var Mx_Diagnostico = [
                {
                    "ID_DIAGNOSTICO": 0,
                    "DIA_COD": 0,
                    "DIA_DESC": 0,
                    "ID_ESTADO": 0
                }
];
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
function Ajax_Diagnostico() {



    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO",
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
var Mx_AVIS = [
      {
          "N_OMI": 0,
          "RUT_PACIENTE": 0,
          "NOMBRE_PACIENTE": 0,
          "APELLIDO_PACIENTE": 0,
          "SEXO_PACIENTE": 0,
          "FECHA_NAC_PACIENTE": "",
          "DIRECCION": 0,
          "COD_EXA_INTERNO": 0,
          "NOMBRE_EXAMEN": 0,
          "COD_EXA_HOMO": 0,
          "OBSERVACIONES": 0,
          "RUT_MEDICO ": 0,
          "NOMBRE": 0,
          "APELLIDO_MEDICO": 0,
          "EMP": 0,
          "DNI": 0
      }
];
function buscar_avis() {
    $('#rut').val("");
    $("#Nom").val("");
    $("#Ape").val("");

    $("#Edad").val("");
    $("#sex").val(0);//
    $("#DataTable_pac2 tbody").empty();
    //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
    $("#telfijo").val("");
    //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
    $("#Diag2").val("");
    $("#Diag").val("");
    //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
    $("#Email").val("");

    modal_show();
    var Data_Par = JSON.stringify({
        "AVIS": $("#Avis").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_AVIS",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_AVIS = JSON.parse(json_receiver);
                //if (Mx_AVIS[0].ID_PREVE != "") {
                // $("#Prevision").val(Mx_AVIS[0].ID_PREVE);
                //Ajax_DataTable_examen02();
                //}

                
                Ajax_modal_exa_RUT_2();



                //$("#DataTable_pac2 tbody").empty();
                //add_row();

                //Fill_DL_AVIS();

                //Hide_Modal();
                //verrut = 1;



            } else {


                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "El N° ingresado no pertenece a un paciente OMI";
                $("#title").text("N° OMI no encontrado :");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

var Mx_OMI = [
{
    "N_OMI": 0,
    "RUT_PACIENTE": 0,
    "NOMBRE_PACIENTE": 0,
    "APELLIDO_PACIENTE": 0,
    "SEXO_PACIENTE": 0,
    "FECHA_NAC_PACIENTE": 0,
    "DIRECCION": 0,
    "COD_EXA_INTERNO": 0,
    "NOMBRE_EXAMEN": 0,
    "COD_EXA_HOMO": 0,
    "OBSERVACIONES": 0,
    "RUT_MEDICO ": 0,
    "NOMBRE": 0,
    "APELLIDO_MEDICO": 0
}
];
function buscar_omi_nuevo_folio() {
    modal_show();
    var Data_Par = JSON.stringify({
        "AVIS": $("#Avis").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_AVIS",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_OMI = JSON.parse(json_receiver);


                if (Mx_OMI[0].RUT_PACIENTE != Mx_AVIS[0].RUT_PACIENTE) {
                    Hide_Modal();
                    $("#mError_AAH").modal('hide');
                    var str_Error = "El N° ingresado no pertenece al paciente OMI";
                    $("#title").text("N° OMI:");
                    $("#button_modal").attr("class", "btn btn-danger");

                    $("#mError_AAH p").text(str_Error);
                    $("#mError_AAH").modal();

                    $('#XXXXXXXX').removeClass('show');
                    $("#Avis").val("");
                    $("#Avis").val(omi_save);
                    agregar_folio = 0;
                } else {
                    agregar_folio = 0;
                    Fill_DL_OMI();
                }
                Hide_Modal();
                //verrut = 1;



            } else {


                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "El N° ingresado no pertenece a un paciente OMI";
                $("#title").text("N° OMI no encontrado :");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}
function buscar_avis23(dddd) {
    $('#rut').val("");
    $("#Nom").val("");
    $("#Ape").val("");

    $("#Edad").val("");
    $("#sex").val(0);//
    $("#DataTable_pac2 tbody").empty();
    //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
    $("#telfijo").val("");
    //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
    $("#Diag2").val("");
    $("#Diag").val("");
    //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
    $("#Email").val("");

    modal_show();
    var Data_Par = JSON.stringify({
        "AVIS": dddd
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_AVIS",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_AVIS = JSON.parse(json_receiver);
                //if (Mx_AVIS[0].ID_PREVE != "") {
                // $("#Prevision").val(Mx_AVIS[0].ID_PREVE);
                //Ajax_DataTable_examen02();
                //}


                $("#DataTable_pac2 tbody").empty();
                add_row();

                Fill_DL_AVIS();
                $('#eModal_Sinrut').modal('hide');
                Hide_Modal();
                verrut = 1;



            } else {


                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "El N° ingresado no pertenece a un paciente OMI";
                $("#title").text("N° OMI no encontrado :");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}
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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_tabla_exam2",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            console.log(`lol ${moment().format("DD/MM/YYYY")}`);
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam02 = JSON.parse(json_receiver);
                Mx_Dtt_exam02_respaldo = JSON.parse(json_receiver);
                if ($("#sex").val() != 0) {
                    var posicion = 0;
                    if ($("#sex").val() == 1) {
                        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1026) {
                                posicion = x;
                            }
                        }
                        Mx_Dtt_exam02.splice(posicion, 1);
                    }
                    if ($("#sex").val() == 2) {
                        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 66) {
                                posicion = x;
                            }
                        }
                        Mx_Dtt_exam02.splice(posicion, 1);
                    }
                }
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

var MX_DTT_SIN_RUT = [
    {
        "Id_integracion": 0,
        "Orden": 0,
        "Nombres": 0,
        "Apellidos": 0,
        "Rut": 0,
        "Estado": 0
    }
];
function AJAX_SIN_RUT() {
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/AJAX_SIN_RUT",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                MX_DTT_SIN_RUT = JSON.parse(json_receiver);

                FILL_SIN_RUT();

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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_tabla_exam",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_exam03 = JSON.parse(json_receiver);
                if ($("#sex").val() != 0) {
                    var posicion = 0;
                    if ($("#sex").val() == 1) {
                        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 1026) {
                                posicion = x;
                            }
                        }
                        Mx_Dtt_exam03.splice(posicion, 1);
                    }
                    if ($("#sex").val() == 2) {
                        for (x = 0; x < Mx_Dtt_exam03.length; x++) {
                            if (Mx_Dtt_exam03[x].ID_CODIGO_FONASA == 66) {
                                posicion = x;
                            }
                        }
                        Mx_Dtt_exam03.splice(posicion, 1);
                    }
                }
                success(id, cod, txis);


            } else {


                Mx_Dtt_exam03.length = 0;
                success(id, cod, txis);
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}


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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_Ddl_LugarTM",
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
       "Id_integracion": 0,
       "Orden": 0,
       "Nombres": 0,
       "Apellidos": 0,
       "Rut": 0,
       "Sexo": 0,
       "F_Nacimiento": 0,
       "Telefono": 0,
       "Mail": 0,
       "HO_Sexo": 0,
       "F_Atencion": 0,
       "Rut_medico ": 0,
       "Nombre_Medico ": 0,
       "Apellido_Medico ": 0,
       "Servicio_Codigo ": 0,
       "Cod_Procedencia": 0,
       "Examen_Codigo": 0,
       "Examen_Descripcion ": 0,
       "Fecha_Registro": 0,
       "Prevision ": 0,
       "Diagnostico ": 0,
       "Estado ": 0,
       "Proc_interfaz ": 0,
       "Fecha_D ": 0
   }
];

function Ajax_busca_rut() {

    $("#Nom").val("");
    $("#Ape").val("");

    $("#Edad").val("");
    $("#sex").val(0);//
    $("#DataTable_pac2 tbody").empty();
    //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
    $("#telfijo").val("");
    //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
    $("#Diag2").val("");
    $("#Diag").val("");
    //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
    $("#Email").val("");

    modal_show();
    var Data_Par = JSON.stringify({
        "AVIS": $("#rut").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_rut",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_AVIS.length = 0;
                Mx_AVIS = JSON.parse(json_receiver);
                //if (Mx_AVIS[0].ID_PREVE != "") {
                // $("#Prevision").val(Mx_AVIS[0].ID_PREVE);
                //Ajax_DataTable_examen02();
                //}
                Ajax_modal_exa_RUT();

                //$("#DataTable_pac2 tbody").empty();
                //add_row();

                //Fill_DL_AVIS();

                //Hide_Modal();
                //verrut = 2;



            } else {


                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "El N° ingresado no pertenece a un paciente OMI";
                $("#title").text("N° OMI no encontrado :");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;
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

    Mx_Detalle_ate = 0;
    var Data_Par_modal = JSON.stringify({
        "ID": $("#dni").val()
    });
    $.ajax({
        "type": "POST",
        "url": "AGRE_EXA_ATE_2.aspx/MODAL_PAC_DNI",
        "data": Data_Par_modal,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": Data_Par_modal_paciente => {
            //Debug
            //console.log(Data_Par_modal_paciente);
            Mx_Detalle_ate = Data_Par_modal_paciente.d;
            //ENVIAMOS ID_ATEMCION AL MODAL
            //LLAMAMOS AL FILL MODAL
            if (Mx_Detalle_ate[0].PAC_RUT == Mx_AVIS[0].RUT_PACIENTE) {
                console.log("la otra pagina");
            } else {


                $("#DataTable_pac2 tbody").empty();
                add_row();


                Fill_DL_AVIS();


                Hide_Modal();
                verrut = 2;
            }
        },
        "error": Data_Par_modal_paciente => {
            Hide_Modal();
            console.log(Data_Par_modal_paciente);

        }
    });
}
function Ajax_busca_DNI() {
    $("#Nom").val("");
    $("#Ape").val("");
    $("#Edad").val("");
    $("#sex").val(0);//
    $("#DataTable_pac2 tbody").empty();
    //$("#Nacio").val(Mx_AVIS[0].ID_NACIONALIDAD);
    $("#telfijo").val("");
    //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
    $("#Diag2").val("");
    $("#Diag").val("");
    //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
    $("#Email").val("");

    modal_show();
    var Data_Par = JSON.stringify({
        "AVIS": $("#DNI").val()
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DNI",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_AVIS.length = 0;
                Mx_AVIS = JSON.parse(json_receiver);
                //if (Mx_AVIS[0].ID_PREVE != "") {
                // $("#Prevision").val(Mx_AVIS[0].ID_PREVE);
                //Ajax_DataTable_examen02();
                //}
                Ajax_modal_exa_DNI();
   
            } else {


                Hide_Modal();
                $("#mError_AAH").modal('hide');
                var str_Error = "El N° ingresado no pertenece a un paciente OMI";
                $("#title").text("N° OMI no encontrado :");
                $("#button_modal").attr("class", "btn btn-danger");

                $("#mError_AAH p").text(str_Error);
                $("#mError_AAH").modal();

                $('#XXXXXXXX').removeClass('show');
                verrut = 0;
                MX_HO_ExamenCodigo.length = 0;
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DL_SEXO",
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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DL_NAC",
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
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_CIUDAD",
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
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA",
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
    var Data_Par = JSON.stringify({
        "id_lg_tm": $("#Procedencia").val()
    });


    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN_2.aspx/Llenar_DL_prevision",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_prevision = JSON.parse(json_receiver);
                Fill_DL_prevision();
                Ajax_DataTable_examen02();



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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DL_aTENCIONES",
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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DL_Sectores",
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

    var Data_Par = JSON.stringify({
        "ID_PREV": $("#Prevision").val()
    });

    $.ajax({
        "type": "POST",
        "url": "IN_PAC_MAN_2.aspx/Llenar_DL_Programa",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_Programa = JSON.parse(json_receiver);
                Fill_DL_programa();

                fn_Req_SubP();
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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DL_DOC",
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
        "url": "Ingreso_Ate_Omi.aspx/Llenar_DL_ordenATE",
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
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST",
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
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2",
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
var Mx_examenes_avis = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_COD": "asdf",
        "CF_DESC": "asdf",
        "ID_ESTADO": 0,
        "CF_AVIS": 0,
    }
];
function Ajax_Examens_avis() {
    Mx_Dtt_examcof.length = 0;


    var Data_Par = JSON.stringify({
        "examenes": MX_HO_ExamenCodigo
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_examcof = JSON.parse(json_receiver);
                //Fill_Mx_examenes_avis(); 
                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    Mx_Dtt_examcof[i]["CF_ESTADO_EXAMEN"] = "Activo"
                    for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                        if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                            Mx_Dtt_examcof[i].CF_DIAS = fnClone(Mx_Dtt_exam02[x].CF_DIAS);
                        }
                    }
                }

                fill_llenado_tabla();
                Hide_Modal();



            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            alert("Error", str_Error);


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
            var obj_RUT2 = Valid_RUT(Mx_AVIS[0].RUT_PACIENTE);
  
            if (Mx_Detalle_ate.proparra1.length == 0) {
                $("#DataTable_pac2 tbody").empty();
                add_row();

                Fill_DL_AVIS();

                Hide_Modal();
                verrut = 2;
            } else {
                if (Mx_Detalle_ate.proparra1[0].PAC_RUT == obj_RUT2.Format) {
                    console.log("la otra pagina 2");
                    var loc = location.origin;
                    window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + Mx_AVIS[0].RUT_PACIENTE + "&Di=" + "NONE");
                } else {


                    $("#DataTable_pac2 tbody").empty();
                    add_row();

                    Fill_DL_AVIS();

                    Hide_Modal();
                    verrut = 2;
                }
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

function Ajax_modal_exa_RUT_2() {
    modal_show();
    Mx_Detalle_ate = 0;
    let xID = "";

    if (Mx_AVIS[0].RUT_PACIENTE != null) {
        var obj_RUT3 = Valid_RUT(Mx_AVIS[0].RUT_PACIENTE);

        if (obj_RUT3.Valid == true) {
            xID = obj_RUT3.Format;
            execute_AJAX_RUT(xID);

        } else {
            xID = Mx_AVIS[0].DNI;
            execute_AJAX_DNI(xID);

        }
    } else if (Mx_AVIS[0].DNI != null) {
        xID = Mx_AVIS[0].DNI;
        execute_AJAX_DNI(xID);

    } else {
        Hide_Modal();
        $("#mError_AAH").modal('hide');
        var str_Error = "El N° ingresado no contiene Rut y DNI, lo cual no podra ser ingresado.";
        $("#title").text("N° OMI:");
        $("#button_modal").attr("class", "btn btn-danger");

        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();

        $('#XXXXXXXX').removeClass('show');
        verrut = 0;
        MX_HO_ExamenCodigo.length = 0;
    }

    function execute_AJAX_RUT(obj_RUT) {
        var Data_Par_modal = JSON.stringify({
            "ID": obj_RUT
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


                if (Mx_Detalle_ate.proparra1.length == 0) {
                    $("#DataTable_pac2 tbody").empty();
                    add_row();

                    Fill_DL_AVIS();

                    Hide_Modal();
                    verrut = 2;
                } else {
                    if (Mx_Detalle_ate.proparra1[0].PAC_RUT == obj_RUT3.Format) {
                        console.log("la otra pagina 2");
                        var loc = location.origin;
                        window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + Mx_AVIS[0].RUT_PACIENTE + "&Di=" + "NONE");
                    } else {



                        $("#DataTable_pac2 tbody").empty();
                        add_row();

                        Fill_DL_AVIS();

                        Hide_Modal();
                        verrut = 1;
                    }
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

    function execute_AJAX_DNI(obj_DNI) {
        var Data_Par_modal = JSON.stringify({
            "ID": obj_DNI
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
                    $("#DataTable_pac2 tbody").empty();
                    add_row();

                    Fill_DL_AVIS();

                    Hide_Modal();
                    verrut = 2;
                } else {
                    if (Mx_Detalle_ate.proparra1[0].DNI == Mx_AVIS[0].DNI) {
                        console.log("la otra pagina 2");
                        var loc = location.origin;
                        window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + "NONE" + "&Di=" + Mx_AVIS[0].DNI);
                    } else {


                        $("#DataTable_pac2 tbody").empty();
                        add_row();

                        Fill_DL_AVIS();

                        Hide_Modal();
                        verrut = 2;
                    }
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
}
function Ajax_modal_exa_DNI() {
    modal_show();
    Mx_Detalle_ate = 0;
    var Data_Par_modal = JSON.stringify({
        "ID": $("#DNI").val()
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
                $("#DataTable_pac2 tbody").empty();
                add_row();

                Fill_DL_AVIS();

                Hide_Modal();
                verrut = 2;
            } else {
                if (Mx_Detalle_ate.proparra1[0].DNI == Mx_AVIS[0].DNI) {
                    console.log("la otra pagina 2");
                    var loc = location.origin;
                    window.location.replace(loc + "/Agenda_Med/AGRE_EXA_ATE_2.aspx" + "?Rt" + "=" + "NONE" + "&Di=" + Mx_AVIS[0].DNI);
                } else {


                    $("#DataTable_pac2 tbody").empty();
                    add_row();

                    Fill_DL_AVIS();

                    Hide_Modal();
                    verrut = 2;
                }
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





var Mx_examenes_OMI_RESPALDO = [
{
    "ID_CODIGO_FONASA": 0,
    "CF_COD": "asdf",
    "CF_DESC": "asdf",
    "ID_ESTADO": 0,
    "CF_AVIS": 0,
}
];
function Ajax_Examens_OMI_RESLPADO() {


    var Data_Par = JSON.stringify({
        "examenes": Mx_HO_Examen_MULTIPLE_OMI
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_examenes_OMI_RESPALDO = JSON.parse(json_receiver);

                //let bFound = false;
                //let xi = 0;

                //for (let reee in Mx_examenes_OMI) {
                //    bFound = false;

                //    for (let ii in Mx_Dtt_examcof) {
                //        if (Mx_examenes_OMI[reee].ID_CODIGO_FONASA == Mx_Dtt_examcof[ii].ID_CODIGO_FONASA) {
                //            bFound = true;
                //            xi = ii;
                //            break;
                //        }
                //    }

                //    if (bFound == true) {
                //        let ID_SQL = parseInt(Mx_examenes_OMI[reee].HO_CC);
                //        let ID_TAB = parseInt(Mx_Dtt_examcof[xi].HO_CC);

                //        if (ID_SQL > ID_TAB) {
                //            Mx_Dtt_examcof[xi] = fnClone(Mx_examenes_OMI[reee]);
                //            Mx_Dtt_examcof[xi]["CF_ESTADO_EXAMEN"] = "Activo"
                //        }
                //    } else {
                //        Mx_Dtt_examcof.push(fnClone(Mx_examenes_OMI[reee]));

                //        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                //    }
                //}

                //fill_llenado_tabla();
                //Hide_Modal();



            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            alert("Error", str_Error);


        }
    });
}
var Mx_examenes_OMI = [
{
    "ID_CODIGO_FONASA": 0,
    "CF_COD": "asdf",
    "CF_DESC": "asdf",
    "ID_ESTADO": 0,
    "CF_AVIS": 0,
}
];

function Ajax_Examens_OMI() {


    var Data_Par = JSON.stringify({
        "examenes": MX_HO_ExamenCodigo
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/IRIS_WEBF_BUSCA_examenes_paciente",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_examenes_OMI = JSON.parse(json_receiver);

                let bFound = false;
                let xi = 0;

                for (let reee in Mx_examenes_OMI) {
                    bFound = false;

                    for (let ii in Mx_Dtt_examcof) {
                        if (Mx_examenes_OMI[reee].ID_CODIGO_FONASA == Mx_Dtt_examcof[ii].ID_CODIGO_FONASA) {
                            bFound = true;
                            xi = ii;
                            break;
                        }
                    }

                    if (bFound == true) {
                        let ID_SQL = parseInt(Mx_examenes_OMI[reee].HO_CC);
                        let ID_TAB = parseInt(Mx_Dtt_examcof[xi].HO_CC);

                        //if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == undefined) {
                        //    Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = "";
                        //}

                        if (ID_SQL > ID_TAB) {
                            Mx_Dtt_examcof[xi] = fnClone(Mx_examenes_OMI[reee]);
                            Mx_Dtt_examcof[xi]["CF_ESTADO_EXAMEN"] = "Activo"

                            //if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == "") {
                            //    Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = ID_SQL +"|"
                            //}
                            if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == undefined || Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == "") {
                                Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = ID_SQL + "|"
                            }
                            Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = `${Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"]}${ID_TAB}|`;


                        } else {
                            //if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == "") {
                            //    Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = ID_TAB + "|"
                            //}
                            if (Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == undefined || Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] == "") {
                                Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = ID_TAB + "|"
                            }
                            Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"] = `${Mx_Dtt_examcof[xi]["CF_MULTIPLICADOS"]}${ID_SQL}|`;
                        }
                    } else {
                        Mx_Dtt_examcof.push(fnClone(Mx_examenes_OMI[reee]));

                        Mx_Dtt_examcof[Mx_Dtt_examcof.length - 1]["CF_ESTADO_EXAMEN"] = "Activo"
                    }
                }

                fill_llenado_tabla();
                Hide_Modal();
                Ajax_Examens_OMI_RESLPADO();


            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            alert("Error", str_Error);


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

            //Refresh la lista esa de Exámenes
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
        "url": "Ingreso_Ate_Omi.aspx/Data_Sel_Ciudad",
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
        "url": "Ingreso_Ate_Omi.aspx/Data_Sel_Comuna",
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
        "url": "Ingreso_Ate_Omi.aspx/Get_Ciu_Com_User",
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


function Fill_Mx_examenes_avis() {


    for (i = 0; i < Mx_examenes_avis.length; i++) {
        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
            if (Mx_examenes_avis[i].ID_CODIGO_FONASA == Mx_Dtt_exam02[x].ID_CODIGO_FONASA) {
                Mx_Dtt_examcof.push(fnClone(Mx_Dtt_exam02[x]));
            }
        }
    }
    //fill_llenado_tabla();
}
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
    $("#Doctor").val(1);
}
function Fill_DL_programa() {
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
    Ajax_DL_programa();
}

function Fill_DL_Rut() {

    var fff = Mx_Dtt2[0].F_Nacimiento;
    var ffmm = moment(fff).format("DD-MM-YYYY");

    var sexo = 0;
    if (Mx_Dtt2[0].Sexo = 3) {
        sexo = 1;
    } else {
        sexo = 2;
    }
    $('#rut').val(Mx_Dtt2[0].Rut);
    var obj_RUT = Valid_RUT($("#rut").val());
    $("#rut").val(obj_RUT.Format);
    $("#Nom").val(Mx_Dtt2[0].Nombres);
    $("#Ape").val(Mx_Dtt2[0].Apellidos);
    $("#fecha").val(ffmm);
    $("#Edad").val(function () {
        var asd = ffmm;
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
    $("#sex").val(sexo);//

    if (sexo == 2) {
        $('#checkBox2').removeAttr("disabled");
    }
    //var asd = Mx_AVIS[0].HO_COD_DIAG;
    //var array = asd.split("|");
    //var COD = array[0];
    //var DIAG = array[2];
    //Ajax_DLdiag(array[1]);
    //Ajax_DLdiag2(array[0]);
    //Ajax_DataTable_examen02();
    //if (Mx_AVIS[0].ID_DIAGNOSTICO == null) {
    //    $("#DdlDiagnostico").val(1);
    //} else {
    //    $("#DdlDiagnostico").val(Mx_AVIS[0].ID_DIAGNOSTICO);
    //}
    $("#Nacio").val(1);
    $("#telfijo").val(Mx_Dtt2[0].Telefono);
    //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
    //$("#direccion").val(Mx_AVIS[0].PAC_DIR);
    $("#Email").val(Mx_Dtt2[0].Mail);

    //if (Mx_AVIS[0].ID_PROGRA != "") {
    //    $("#Programa").val(Mx_AVIS[0].ID_PROGRA);
    //}


    $("#Diag2").val(Mx_Dtt2[0].Diagnostico);
    ///preparar matrix de examenes
    MX_HO_ExamenCodigo.length = 0;




    for (x = 0; x < Mx_Dtt2.length; x++) {
        switch (x) {


            case 0:
                var objId = {
                    "Examen": Mx_Dtt2[x].Examen_Codigo,
                    "HO_CC": Mx_AVIS[x].N_OMI,
                    "CF_MULTIPLICADOS": ""
                };
                MX_HO_ExamenCodigo.push(fnClone(objId));
                break;
            default:
                if (Mx_Dtt2[x].Examen_Codigo != Mx_Dtt2[x - 1].Examen_Codigo) {
                    var objId = {
                        "Examen": Mx_Dtt2[x].Examen_Codigo,
                        "HO_CC": Mx_AVIS[x].N_OMI,
                        "CF_MULTIPLICADOS": ""
                    };
                    MX_HO_ExamenCodigo.push(fnClone(objId));
                }else{
                    MX_HO_ExamenCodigo[MX_HO_ExamenCodigo.length - 1].CF_MULTIPLICADOS = MX_HO_ExamenCodigo[MX_HO_ExamenCodigo.length - 1].HO_CC + "|" + Mx_AVIS[x].N_OMI;
                }
        }
    }
    console.log(JSON.stringify(MX_HO_ExamenCodigo));

    //var ftler = Array();
    //var hash = {};
    //MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
    //    var exists = !hash[current.Examen] || false;
    //    hash[current.Examen] = true;
    //    return exists;
    //});
    //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    for (y = 0; y < ftler.length; y++) {
    //        if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
    //            if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
    //                MX_HO_ExamenCodigo.splice(x, 1);
    //            }
    //        }
    //    }
    //}

    Ajax_Examens_avis();


};
function Fill_DL_OMI() {

    MX_HO_ExamenCodigo.length = 0;

    for (c = 0; c < Mx_OMI.length; c++) {
        var objId = {
            "Examen": Mx_OMI[c].COD_EXA_INTERNO,
            "HO_CC": Mx_OMI[c].N_OMI
        };
        Mx_HO_Examen_MULTIPLE_OMI.push(fnClone(objId));


    }

    for (x = 0; x < Mx_OMI.length; x++) {
        switch (x) {
            case 0:
                var objId = {
                    "Examen": Mx_OMI[x].COD_EXA_INTERNO,
                    "HO_CC": Mx_OMI[x].N_OMI
                };
                MX_HO_ExamenCodigo.push(fnClone(objId));
                break;
            default:
                if (Mx_OMI[x].COD_EXA_INTERNO != Mx_OMI[x - 1].COD_EXA_INTERNO) {
                    var objId = {
                        "Examen": Mx_OMI[x].COD_EXA_INTERNO,
                        "HO_CC": Mx_OMI[x].N_OMI
                    };
                    MX_HO_ExamenCodigo.push(fnClone(objId));
                }
        }
    }

    var ftler = Array();
    var hash = {};
    MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
        var exists = !hash[current.Examen] || false;
        hash[current.Examen] = true;
        return exists;
    });
    for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
        for (y = 0; y < ftler.length; y++) {
            if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
                if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
                    MX_HO_ExamenCodigo.splice(x, 1);
                }
            }
        }
    }
    Ajax_Examens_OMI();

}
function creardoctor(doc_nombre, apellido_doc, RUT_DOC) {

    var Data_Par = JSON.stringify({
        "nombre": doc_nombre,
        "Apellido": apellido_doc,
        "RUT": RUT_DOC
    });
    $.ajax({
        "type": "POST",
        "url": "Ingreso_Ate_Omi.aspx/crearDoc",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {

                Ajax_DL_DOC2();
                console.log("termine de actualizar");


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
function Fill_DL_AVIS() {
    var fff = Mx_AVIS[0].FECHA_NAC_PACIENTE;
    fff = fff.replace(/\//gi, "-")
    // var ffmm = moment(fff, "DD-MM-YYYY").toDate();

    var sexo = 0;
    if (Mx_AVIS[0].SEXO_PACIENTE == "M") {
        sexo = 1;
    } else {
        sexo = 2;
    }

    for (z = 0; z < Mx_AVIS.length; z++) {
        console.log(Mx_AVIS[z].DNI);
        if (Mx_AVIS[z].DNI != null) {

            $('#DNI').val(Mx_AVIS[z].DNI);

        }
    }
    if (Mx_AVIS[0].EMP == "SI") {
        $('#XXXXXXXX').removeClass('show');
        var str_Error = "Paciente con Embarazo"
        $("#title").text("Alerta");
        $("#button_modal").attr("class", "btn btn-success");
        $("#mError_AAH p").text(str_Error);
        $("#mError_AAH").modal();
        console.log("Mostrar modal ");
      
        //$("#PrioridadTM").val(2);
    }
    $('#rut').val(Mx_AVIS[0].RUT_PACIENTE);
    var obj_RUT = Valid_RUT($("#rut").val());
    $("#rut").val(obj_RUT.Format);
    $("#Nom").val(Mx_AVIS[0].NOMBRE_PACIENTE);
    $("#Ape").val(Mx_AVIS[0].APELLIDO_PACIENTE);
    $("#fecha").val(fff);
    $("#Edad").val(function () {
        var asd = fff;
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
    $("#sex").val(sexo);//

    if (sexo == 2) {
        $('#checkBox2').removeAttr("disabled");
    }
    //var asd = Mx_AVIS[0].HO_COD_DIAG;
    //var array = asd.split("|");
    //var COD = array[0];
    //var DIAG = array[2];
    //Ajax_DLdiag(array[1]);
    //Ajax_DLdiag2(array[0]);
    //Ajax_DataTable_examen02();
    //if (Mx_AVIS[0].ID_DIAGNOSTICO == null) {
    //    $("#DdlDiagnostico").val(1);
    //} else {
    //    $("#DdlDiagnostico").val(Mx_AVIS[0].ID_DIAGNOSTICO);
    //}
    $("#Nacio").val(1);
    $("#telfijo").val(Mx_AVIS[0].FONO);
    //$("#Celular").val(Mx_AVIS[0].PAC_MOVIL1);
    $("#direccion").val(Mx_AVIS[0].DIRECCION);
    //$("#Email").val(Mx_AVIS[0].Mail);

    //if (Mx_AVIS[0].ID_PROGRA != "") {
    //    $("#Programa").val(Mx_AVIS[0].ID_PROGRA);
    //}

    let drLng = $("#Doctor option").length;
    let strAVIS = Mx_AVIS[0].NOMBRE + " " + Mx_AVIS[0].APELLIDO_MEDICO;
    let DocStat = false;
    let regeX = new RegExp(`${strAVIS.replace(/\s+/g, "\\s+")}`, `gi`);
    for (i = 0; i < drLng; i++) {
        let Sel_Val = $("#Doctor option").eq(i).text();
        if (Sel_Val.match(regeX) != null) {
            $("#Doctor option").eq(i).prop('selected', true);
            DocStat = true;
            break;
        }
    }
    if (DocStat == false) {
        creardoctor(Mx_AVIS[0].NOMBRE, Mx_AVIS[0].APELLIDO_MEDICO, Mx_AVIS[0].RUT_MEDICO);
    }


    //$("#Diag2").val(Mx_AVIS[0].Diagnostico);
    ///preparar matrix de examenes
    MX_HO_ExamenCodigo.length = 0;

    for (x = 0; x < Mx_AVIS.length; x++) {
        switch (x) {
            case 0:
                var objId = {
                    "Examen": Mx_AVIS[x].COD_EXA_INTERNO,
                    "HO_CC": Mx_AVIS[x].N_OMI,
                    "CF_MULTIPLICADOS": ""
                };
                MX_HO_ExamenCodigo.push(fnClone(objId));
                break;
            default:
                if (Mx_AVIS[x].COD_EXA_INTERNO != Mx_AVIS[x - 1].COD_EXA_INTERNO) {
                    var objId = {
                        "Examen": Mx_AVIS[x].COD_EXA_INTERNO,
                        "HO_CC": Mx_AVIS[x].N_OMI,
                        "CF_MULTIPLICADOS": ""
                    };
                    MX_HO_ExamenCodigo.push(fnClone(objId));
                } 
        }
    }
    var ftler = Array();
    var hash = {};
    MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
        var exists = !hash[current.Examen] || false;
        hash[current.Examen] = true;
        return exists;
    });
    for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
        for (y = 0; y < ftler.length; y++) {
            if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
                if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
                    MX_HO_ExamenCodigo.splice(x, 1);
                }
            }
        }
    }
    console.log(JSON.stringify(MX_HO_ExamenCodigo));

    for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
        for (i = 0; i < Mx_AVIS.length; i++) {

            if (MX_HO_ExamenCodigo[x].HO_CC != Mx_AVIS[i].N_OMI && MX_HO_ExamenCodigo[x].Examen == Mx_AVIS[i].COD_EXA_INTERNO) {

                if (MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS == "") {
                    MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS = MX_HO_ExamenCodigo[x].HO_CC + "|" + Mx_AVIS[i].N_OMI + "|";
                } else {
                    MX_HO_ExamenCodigo[x].CF_MULTIPLICADOS = `${MX_HO_ExamenCodigo[x]["CF_MULTIPLICADOS"]}${Mx_AVIS[i].N_OMI}|`;
                }
            }

        }
    }

    console.log(JSON.stringify(MX_HO_ExamenCodigo));

    //var ftler = Array();
    //var hash = {};
    //MX_HO_ExamenCodigo = MX_HO_ExamenCodigo.filter(function (current) {
    //    var exists = !hash[current.Examen] || false;
    //    hash[current.Examen] = true;
    //    return exists;
    //});
    //for (x = 0; x < MX_HO_ExamenCodigo.length; x++) {
    //    for (y = 0; y < ftler.length; y++) {
    //        if (MX_HO_ExamenCodigo[x].Examen == ftler[y].Examen) {
    //            if (MX_HO_ExamenCodigo[x].HO_CC < ftler[y].HO_CC) {
    //                MX_HO_ExamenCodigo.splice(x, 1);
    //            }
    //        }
    //    }
    //}

    Ajax_Examens_avis();
}
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
        //fn_Req_Prev();
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


var Mx_DL_DOC = [
{
    "ID_DOCTOR": 0,
    "DOC_NOMBRE": "asdf",
    "DOC_APELLIDO": "asdf",
    "ID_ESTADO": 0
}
];
function Ajax_DL_DOC2() {



    $.ajax({
        "type": "POST",
        "url": "IN_PAC_AVIS.aspx/Llenar_DL_DOC",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_DL_DOC = JSON.parse(json_receiver);
                Fill_DL_DOC2();




            } else {



            }
        },
        "error": function (response) {

            var str_Error = "Error interno del Servidor";
            cModal_Error("Error", str_Error);


        }
    });
}

function Fill_DL_DOC2() {
    $("#Doctor").empty();
    for (y = 0; y < Mx_DL_DOC.length; ++y) {
        $("<option>", {
            "value": Mx_DL_DOC[y].ID_DOCTOR
        }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
    }

    let drLng = $("#Doctor option").length;
    let strAVIS2 = Mx_AVIS[0].NOMBRE + " " + Mx_AVIS[0].APELLIDO_MEDICO;

    let regeX = new RegExp(`${strAVIS2.replace(/\s+/g, "\\s+")}`, `gi`);
    for (i = 0; i < drLng; i++) {
        let Sel_Val = $("#Doctor option").eq(i).text();
        if (Sel_Val.match(regeX) != null) {
            $("#Doctor option").eq(i).prop('selected', true);

            break;
        }
    }
}
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
function Ajax_N_PACIENTE(orden) {
    $("#Avis").val(orden);

    buscar_avis23(orden);

}
function FILL_SIN_RUT() {
    $("#Div_Tabla45").empty();
    $("<table>", {
        "id": "DataTable_pac_256",
        "class": "display",
        "width": "100%",
        "cellspacing": "0"
    }).appendTo("#Div_Tabla45");

    $("#DataTable_pac_256").append(
        $("<thead>"),
        $("<tbody>")
    );
    $("#DataTable_pac_256").attr("class", "table table-striped table-hover table-iris");
    $("#DataTable_pac_256 thead").attr("class", "cabzera");
    $("#DataTable_pac_256 thead").append(
        $("<tr>").append(

            $("<th>", { "class": "textoReducido" }).text("Nº"),
            $("<th>", { "class": "textoReducido" }).text("Orden"),
            $("<th>", { "class": "textoReducido" }).text("Nombre"),
            $("<th>", { "class": "textoReducido" }).text("Apellido")

        )
    );

    for (i = 0; i < MX_DTT_SIN_RUT.length; i++) {
        $("#DataTable_pac_256 tbody").append(
            $("<tr>", {
                "class": "textoReducido manito",
                "padding": "1px !important",
                "onclick": `Ajax_N_PACIENTE("` + MX_DTT_SIN_RUT[i].Orden + `")`
            }).append(
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"

                }).text(i + 1),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(MX_DTT_SIN_RUT[i].Orden),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido"
                }).text(MX_DTT_SIN_RUT[i].Nombres),
               $("<td>", {
                   "align": "left",
                   "class": "textoReducido"
               }).text(MX_DTT_SIN_RUT[i].Apellidos)
            )
        )
    }
    //$('#DataTable_pac').DataTable({
    //    "iDisplayLength": false,
    //    "info": false,
    //    "bPaginate": false,
    //    "bFilter": true,
    //    "bSort": false,
    //    "language": {
    //        "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>"
    //    }
    //})
}
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
    $("#DataTable_pac").attr("class", "table table-striped table-hover table-iris");
    $("#DataTable_pac thead").attr("class", "cabzera");
    $("#DataTable_pac thead").append(
        $("<tr>").append(

            $("<th>", { "class": "textoReducido" }).text("Nº"),
            $("<th>", { "class": "textoReducido" }).text("Codigo"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            $("<th>", { "class": "textoReducido" }).text("Valor Ambulatorio"),
            $("<th>", { "class": "textoReducido" }).text("Carga")

        )
    );
    if ($("#sex").val() != 0) {
        var posicion = 0;
        if ($("#sex").val() == 1) {
            for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 1026) {
                    posicion = x;
                }
            }
            Mx_Dtt_exam02.splice(posicion, 1);
        } else {
            for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == 66) {
                    posicion = x;
                }
            }

            Mx_Dtt_exam02.splice(posicion, 1);
        }
    }
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
               $("<td>", {
                   "align": "center",
                   "class": "textoReducido"
               }).text(Mx_Dtt_exam02[i].CF_PRECIO_AMB),
            $("<td>", {
                "align": "center",
                "class": "textoReducido"
            }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
            )
        )
    }
    $('#DataTable_pac').DataTable({
        "iDisplayLength": false,
        "info": false,
        "bPaginate": false,
        "bFilter": true,
        "bSort": false,
        "language": {
            "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>"
        }
    })
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
                    "class": "textoReducido"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": Mx_Dtt_examcof[i].ID_CODIGO_FONASA,
                        "data-cod": Mx_Dtt_examcof[i].CF_COD,
                        "class": "td_input",
                        "value": Mx_Dtt_examcof[i].CF_COD
                    })
                }())),
                $("<td>", {
                    "align": "left",
                    "class": "textoReducido td_val1"
                }).text(Mx_Dtt_examcof[i].CF_DESC),
               $("<td>", {
                   "align": "center",
                   "class": "textoReducido td_val2"
               }).text(Mx_Dtt_examcof[i].CF_DIAS),
               $("<td>", {
                   "align": "center"
               }).html("<button type='button' class='btn btn-default btn-xs borrar' value='Eliminar' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'><i class='fa fa-trash-o' aria-hidden='true'></i> Eliminar</button>"),
               $("<td>", {
                   "align": "center"
               }).html(function () {
                   if (Mx_Dtt_examcof[i].CF_ESTADO_EXAMEN == "Activo") {
                       return "<button type='button' class='btn btn-print btn-xs CEstado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Pendiente</button>"
                   } else {
                       return "<button type='button' class='btn btn-success btn-xs Activado' value='Espera' data-id='" + Mx_Dtt_examcof[i].ID_CODIGO_FONASA + "' style='padding: .1rem .1rem;font-size: 14px;cursor: pointer;'> Cambiar a Activo</button>"
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
        $("#DataTable_pac3").attr("class", "table table-hover table-striped table-iris table-iris");
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
//Llenar DropDownList Diagnostico
function Fill_Ddl_diagnostico() {
    $("#DdlDiagnostico").empty();
    for (y = 0; y < Mx_Diagnostico.length; ++y) {
        $("<option>", {
            "value": Mx_Diagnostico[y].ID_DIAGNOSTICO
        }).text(Mx_Diagnostico[y].DIA_DESC).appendTo("#DdlDiagnostico");
    }
    //$("#DdlDiagnostico").val(1);
};