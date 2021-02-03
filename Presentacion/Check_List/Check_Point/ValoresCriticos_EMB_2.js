
$(document).ready(function () {
    Call_AJAX_Ddl();
    $("#divTable01").hide();
    Ajax_DL_programa();
    Ajax_Exam();
    //Ddl_REsultado();
    //Call_Data_Ddl_Stat();
    Fill_Ddl_Stat();
    Ajax_Ddl();
    fn_Req_Prev();
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

    //Registrar evento Click del Botón Buscar       
    $("#Btn_Search").click(function () {
        $("#Div_Tabla").empty();
        function restaFechas(f1, f2) {
            var aFecha1 = f1.split('-');
            var aFecha2 = f2.split('-');
            var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
            var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
            var dif = fFecha2 - fFecha1;
            var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
            return dias;
        }

        var Date_Diff = restaFechas(String($("#Txt_Date01 input").val()), String($("#Txt_Date02 input").val()));

        if (Date_Diff <= 31) {
            Call_Data_Table();

        } else {
            $("#mError_AAH h4").text("Rango de Fechas");
            $("#mError_AAH button").attr("class", "btn btn-danger");
            $("#mError_AAH p").text("Por favor, seleccione un rango de fechas menor a 30 días.");
            $("#mError_AAH").modal();
        }
    

    });

    $("#Btn_Gen").click(function () {

        Call_Export();

    });
    $("#Ddl_Examen").change(function () {
        pruebas_ddl();

    });

    $("#Prevision").change(function () {
        Call_AJAX_Ddl();
    });

});

var Mx_Ddl = [
    {
        "ID_PROCEDENCIA": "",
        "PROC_COD": "",
        "PROC_DESC": "",
        "ID_ESTADO": ""
    }
];
//AJAX DroDownList
function Call_AJAX_Ddl() {
    //Debug
    $("#Ddl_Proc").empty();
    var objParam = JSON.stringify({
        "ID_PREV": $("#Prevision").val(),
        "ID_USER": Galletas.getGalleta("ID_USER")
    });

    AJAX_Ddl = $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB_2.aspx/Llenar_Ddl_LugarTM",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            //Debug

            Mx_Ddl = JSON.parse(data.d);
            console.log(Mx_Ddl);
            Fill_Ddl_TM();
        },
        "error": data => {
            //Debug



        }
    });
}
function Fill_Ddl_TM() {
    
    if (Mx_Ddl != null) {

        $("<option>",
                      {
                          "value": 0
                      }
                   ).text("Todos").appendTo("#Ddl_Proc");

        var procee = Galletas.getGalleta("USU_ID_PROC");
        if (procee == 0) {
            Mx_Ddl.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PROCEDENCIA
                    }
                ).text(aaa.PROC_DESC).appendTo("#Ddl_Proc");
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
                   ).text(aaa.PROC_DESC).appendTo("#Ddl_Proc");
                }

            });
            //fn_Req_Prev();
        }
    }
    
   
}

var arrPrev = [{
    "ID_PREVE": 0,
    "PREVE_COD": "",
    "PREVE_DESC": "",
    "ID_ESTADO": 0
}];

function fn_Req_Prev() {
    var objParam = JSON.stringify({
        "ID_USER": Galletas.getGalleta("ID_USER")
    });
    console.log(objParam);
    objAJAX_Prev = $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB_2.aspx/Request_Prevision",
        "data": objParam,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": (resp) => {
            arrPrev = resp.d;
            console.log(arrPrev);
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

            Call_AJAX_Ddl();
        },
        "error": (fail) => {
        }
    });
};

//-------------------------------------------------- AJAX DDL PREVISIÓN ---------------------------------------------|
var Mx_Dtt_Prevision = [
{
    "ID_PREVE": 0,
    "PREVE_COD": 0,
    "PREVE_DESC": 0,
    "ID_ESTADO": 0
}
];

function Ajax_Prevision() {


    $.ajax({
        "type": "POST",
        "url": "Val_Criticos.aspx/Llenar_Ddl_Prevision",
        //"data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Dtt_Prevision = JSON.parse(json_receiver);
                Fill_Ddl_Prevision();

            } else {

                $("#mdlNotif h4").text("Sin resultados");
                $("#mdlNotif button").attr("class", "btn btn-danger");
                $("#mdlNotif p").text("No se han encontrado resultados para la búsqueda solicitada.");
                $("#mdlNotif").modal();
            }

        },
        "error": function (response) {
            var str_Error = response.responseJSON.ExceptionType + "\n \n";
            str_Error = response.responseJSON.Message;
            alert(str_Error);



        }
    });
}

//----------    var Mx_Dtt_Prevision = [
let arrData = [
  {
      ID_PRUEBA: 0,
      PRU_DESC: ""
  }
]

function pruebas_ddl() {
 

    var Data_Par = JSON.stringify({
        "id_cf": $("#Ddl_Examen").val()

    });
    $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB.aspx/IRIS_WEBF_BUSCA_PRUEBA_POR_CODIGO_F",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                arrData = JSON.parse(json_receiver);
                Fill_Ddl_prueba();
           
            } else {
                $("#Ddl_Prub").empty();

                $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Prub");
        
                if ($("#Ddl_Examen").val() != 0)
                {
                    $("#mdlNotif h4").text("Sin resultados");
                    $("#mdlNotif button").attr("class", "btn btn-danger");
                    $("#mdlNotif p").text("No se han encontrado resultados para la búsqueda solicitada.");
                    $("#mdlNotif").modal();
                }
                
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
    "ID_CODIGO_FONASA": 0,
    "CF_DESC": 0,
    "ID_ESTADO": 0
}
];

function Ajax_Exam() {

    $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB.aspx/Llenar_Ddl_Exam",
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
                $("#mdlNotif h4").text("Sin resultados");
                $("#mdlNotif button").attr("class", "btn btn-danger");
                $("#mdlNotif p").text("No se han encontrado resultados para la búsqueda solicitada");
                $("#mdlNotif").modal();
            }
        },
        "error": function (response) {

        }
    });
}

//-------------------------------------------------- AJAX ESTADO -------------------------------------------------------
//var AJAX_Ddl_Stat = 0;
//function Call_Data_Ddl_Stat() {
//    modal_show();
//    AJAX_Ddl_Stat = $.ajax({
//        "type": "POST",
//        "url": "Val_Criticos.aspx/Call_Ddl_Stat",
//        //"data": '{}',
//        "contentType": "application/json;  charset=utf-8",
//        "dataType": "json",
//        "success": function (response) {
//            JSON_Ddl_Stat = JSON.parse(response.d);
//            Hide_Modal();
//            Fill_Ddl_Stat();
//        },
//        "error": function (response) {
//            Hide_Modal();
//        }
//    });
//}

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
    "SECC_DESC": "",
    "Encyp":""
}];


function Call_Data_Table() {
    modal_show();

    var Data_Par = JSON.stringify({
        "DATE_str01": String($("#fecha2").val()),
        "DATE_str02": String($("#fecha3").val()),
        "ID_EXAM": String($("#Ddl_Examen").val()),
        "ID_PROg": 0,
        "ID_PRUEB": String($("#Ddl_Prub").val()),
        "ID_RESUL": String($("#Ddl_resul").val()),
        "ID_STAT": $("#Ddl_Stat").val(),
        "ID_SECC": 0,
        "ID_PROCE": $("#Ddl_Proc").val(),
        "ID_PREVE": $("#Prevision").val()
    });
    console.log(Data_Par);
    $(".block_wait").fadeIn(500);
    AJAX_Data_Table = $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB_2.aspx/Call_DataTable",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            if (response.d != null) {
                JSON_Data_Table = JSON.parse(response.d);
                Hide_Modal();
                $("#divTable01").show();

                //for (i = 0; i < JSON_Data_Table.length; ++i) {
                //    var date_x = JSON_Data_Table[i].PAC_FNAC;
                //    date_x = String(date_x).replace("/Date(", "");
                //    date_x = date_x.replace(")/", "");
                //    var Date_Change = new Date(parseInt(date_x));
                //    JSON_Data_Table[i].PAC_FNAC = Date_Change;
                //}

                Fill_DataTable();

            } else {
                Hide_Modal();
                $("#divTable01").hide();
                $("#mdlNotif h4").text("Sin resultados");
                $("#mdlNotif button").attr("class", "btn btn-danger");
                $("#mdlNotif p").text("No se han encontrado resultados para la búsqueda solicitada.");
                $("#mdlNotif").modal();
            }

        },
        "error": function (response) {
           
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
        "ID_EXAM": String($("#Ddl_Examen").val()),
        "ID_PROg": 0,
        "ID_PRUEB": String($("#Ddl_Prub").val()),
        "ID_RESUL": String($("#Ddl_resul").val()),
        "id_est": $("#Ddl_Stat").val(),
        "ID_SECC": 0,
        "ID_PROCE": $("#Ddl_Proc").val(),
        "ID_PREVE": $("#Prevision").val()
    });
    console.log(Data_Par);
    AJAX_Data_Table = $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB_2.aspx/Call_Export",
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
                $("#mdlNotif h4").text("Sin resultados");
                $("#mdlNotif button").attr("class", "btn btn-danger");
                $("#mdlNotif p").text("No se han encontrado resultados para la búsqueda solicitada.");
                $("#mdlNotif").modal();
            }
        },
        "error": function (response) {
            console.log(response);
            Hide_Modal();
        }
    });
}
//var Mx_Dtt_resul = [
//           {
//               "ID_TP_RESULTADO": 0,
//               "TP_RESUL_COD": 0,
//               "TP_RESUL_DESC": 0,
//               "ID_ESTADO": 0
//           }
//];
//function Ddl_REsultado() {


//    $(".block_wait").fadeIn(500);
//    $.ajax({
//        "type": "POST",
//        "url": "ValoresCriticos_EMB.aspx/IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO",
//        //"data": Data_Par,
//        "contentType": "application/json;  charset=utf-8",
//        "dataType": "json",
//        "success": function (response) {
//            var json_receiver = response.d;
//            if (json_receiver != "null") {
//                Mx_Dtt_resul = JSON.parse(json_receiver);
//                $("#Ddl_resul").empty();

//                //$("<option>", { "value": 0 }).text("Seleccionar").appendTo("#DdlPrevision");
//                for (y = 0; y < Mx_Dtt_resul.length; ++y) {
//                    $("<option>", {
//                        "value": Mx_Dtt_resul[y].ID_TP_RESULTADO
//                    }).text(Mx_Dtt_resul[y].TP_RESUL_DESC).appendTo("#Ddl_resul");
//                }



//            } else {
//                $("#mdlNotif h4").text("Sin resultados");
//                $("#mdlNotif button").attr("class", "btn btn-danger");
//                $("#mdlNotif p").text("No se han encontrado resultados");
//                $("#mdlNotif").modal();
//            }
//            $(".block_wait").fadeOut(500);
//        },
//        "error": function (response) {
//            var str_Error = response.responseJSON.ExceptionType + "\n \n";
//            str_Error = response.responseJSON.Message;
//            alert(str_Error);

//        }
//    });
//}


//Llenar DropDownList Examen
function Fill_Ddl_Exam() {
    $("#Ddl_Examen").empty();

    $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Examen");
    for (y = 0; y < Mx_Exam.length; ++y) {
        $("<option>", {
            "value": Mx_Exam[y].ID_CODIGO_FONASA
        }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Examen");
    }
    pruebas_ddl();
};

//Llenar DropDownList Prevision
function Fill_Ddl_Prevision() {
    $("#DdlPrevision").empty();

    for (y = 0; y < Mx_Dtt_Prevision.length; ++y) {
        $("<option>", {
            "value": Mx_Dtt_Prevision[y].ID_PREVE
        }).text(Mx_Dtt_Prevision[y].PREVE_DESC).appendTo("#DdlPrevision");
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

//Llenar DropDownList Estado


function Fill_Ddl_Stat() {
    $("#Ddl_Stat").empty();

    $("<option>", {
        "value": 0
    }).text("Todos").appendTo("#Ddl_Stat");
    $("<option>", {
        "value": 2
    }).text("Alto").appendTo("#Ddl_Stat");
    $("<option>", {
        "value": 1
    }).text("Bajo").appendTo("#Ddl_Stat");
};
function Ajax_Redirect(id) {
    var loc = location.origin;
    window.open(loc + "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=" + id);
}
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
            $("<th>", { "class": "textoReducido text-center" }).text("Sección"),
            $("<th>", { "class": "textoReducido" }).text("Determinación"),
            $("<th>", { "class": "textoReducido" }).text("Resultado"),
            $("<th>", { "class": "textoReducido" }).text("Alarma"),
            $("<th>", { "class": "textoReducido" }).text("Médico")
        )
    );


    var nino = 0;
    var adulto = 0;


    var count = 0;
    for (i = 0; i < JSON_Data_Table.length; i++) {
        var edades = 0;
        count++;
        $("#DataTable tbody").append(
           $("<tr>", {
               "onclick": `Ajax_Redirect("` + JSON_Data_Table[i].Encyp + `")`,
               "class": "manito"
           }).attr("value", JSON_Data_Table[i].Encyp).append(
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
                $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].SECC_DESC),
                $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].PRU_DESC),
                $("<td>").css("text-align", "left").text(function () {
                    //Declaraciones
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
                }),
                $("<td>").css("text-align", "left").text(function () {
                     var Stat_t = JSON_Data_Table[i].ATE_RR_ALTOBAJO;

                     switch (Stat_t) {
                         case 1:
                             return "B";
                             break;
                         case 2:
                             return "A";
                             break;
                         default:
                             return "-";
                             break;
                     }
                 }),
                $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(JSON_Data_Table[i].DOC_NOMBRE + " " + JSON_Data_Table[i].DOC_APELLIDO)
                
            )
        );
        if (edades <= 14) {
            nino++;
        } else {
            adulto++;
        }

    }
    $("#nino").text(nino);
    $("#adulto").text(adulto);
    $(`#DataTable`).DataTable({
        "iDisplayLength": 100,
        "info": true,
        "bPaginate": true,
        "bFilter": true,
        "bSort": true,
        "language": {
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
           
        }
    });
}

var Mx_Ddl123 = [
           {
               "ID_RLS_LS": 0,
               "ID_LABO": 0,
               "ID_SECCION": 0,
               "RLS_LS_DESC": "dddd",
               "ID_ESTADO": 0
           }
];
function Ajax_Ddl() {

    $.ajax({
        "type": "POST",
        "url": "ValoresCriticos_EMB.aspx/Llenar_Ddl_22",
        //"data": '{}',
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": function (response) {
            var json_receiver = response.d;
            if (json_receiver != "null") {
                Mx_Ddl123 = JSON.parse(json_receiver);
                Fill_Ddl();
                $(".block_wait").hide();

            } else {

            }
        },
        "error": function (response) {


        }
    });
}





function Fill_Ddl() {
    $("#Ddl_seccion").empty();
    $("<option>", {
        "value": 0
    }).text("Todos").appendTo("#Ddl_seccion");
    for (y = 0; y < Mx_Ddl123.length; ++y) {
        $("<option>", {
            "value": Mx_Ddl123[y].ID_RLS_LS
        }).text(Mx_Ddl123[y].RLS_LS_DESC).appendTo("#Ddl_seccion");
    }
};
//var Mx_Exam = [
//{
//    "ID_CODIGO_FONASA": 0,
//    "CF_DESC": 0,
//    "ID_ESTADO": 0
//}
//];

//function Ajax_Exam() {
//    modal_show();
//    $(".block_wait").fadeIn(500);
//    $.ajax({
//        "type": "POST",
//        "url": "ValoresCriticos_EMB.aspx/Llenar_Ddl_Exam",
//        //"data": Data_Par,
//        "contentType": "application/json;  charset=utf-8",
//        "dataType": "json",
//        "success": function (response) {
//            var json_receiver = response.d;
//            if (json_receiver != "null") {
//                Mx_Exam = JSON.parse(json_receiver);
//                $("#Ddl_Examen").empty();
//                $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Examen");
//                for (y = 0; y < Mx_Exam.length; ++y) {
//                    $("<option>", {
//                        "value": Mx_Exam[y].ID_CODIGO_FONASA
//                    }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Examen");
//                }
//                Hide_Modal();
//            } else {
//                Hide_Modal();
//                $("#mdlNotif h4").text("Sin resultados");
//                $("#mdlNotif button").attr("class", "btn btn-danger");
//                $("#mdlNotif p").text("No se han encontrado resultados");
//                $("#mdlNotif").modal();
//            }
//            $(".block_wait").fadeOut(500);
//        },
//        "error": function (response) {
//            var str_Error = response.responseJSON.ExceptionType + "\n \n";
//            str_Error = response.responseJSON.Message;
//            alert(str_Error);
//        }
//    });
//}