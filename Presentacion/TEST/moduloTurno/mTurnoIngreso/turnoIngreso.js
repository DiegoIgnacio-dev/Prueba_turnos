//VARIABLES GLOBALES
//Variables que pueden ser usadas en más de una funcion, es decir, en todo el formulario
//DOCUMENT READY

//Funcion para desabilitar opciones de modulo
$(document).ready(() => {

    $("input[name='chk_Mod_Ate']").click((e) => {
        let id = $(e.currentTarget).val();
        let check = $(e.currentTarget).prop("checked");
        let estado = 0;

        switch (check) {
            case true:
                estado = 1
                break;
            case false:
                estado = 3
                break;
        }

        if (estado != 0) {
            //Actualiza estado en BD
            //alert(id + " " + check + " " + estado);
        }
    });

    $("#updateCheck").click(() => {
        fn_Update_Check();
    });

    //Check desde la BD

    //SE GUARDA EL ESTADO DE LOS CHECKBOX DE FORMA LOCAL 
    checkbox1 = document.getElementById('inlineCheckbox1')
    checkbox1.checked = eval(window.localStorage.getItem(checkbox1.id))

    checkbox1.addEventListener('change', function () {
        window.localStorage.setItem(checkbox1.id, checkbox1.checked)
    })

    checkbox2 = document.getElementById('inlineCheckbox2')
    checkbox2.checked = eval(window.localStorage.getItem(checkbox2.id))

    checkbox2.addEventListener('change', function () {
        window.localStorage.setItem(checkbox2.id, checkbox2.checked)
    })

    checkbox3 = document.getElementById('inlineCheckbox3')
    checkbox3.checked = eval(window.localStorage.getItem(checkbox3.id))

    checkbox3.addEventListener('change', function () {
        window.localStorage.setItem(checkbox3.id, checkbox3.checked)
    })

    checkbox4 = document.getElementById('inlineCheckbox4')
    checkbox4.checked = eval(window.localStorage.getItem(checkbox4.id))

    checkbox4.addEventListener('change', function () {
        window.localStorage.setItem(checkbox4.id, checkbox4.checked)
    })

    checkbox5 = document.getElementById('inlineCheckbox5')
    checkbox5.checked = eval(window.localStorage.getItem(checkbox5.id))

    checkbox5.addEventListener('change', function () {
        window.localStorage.setItem(checkbox5.id, checkbox5.checked)
    })

    checkbox6 = document.getElementById('inlineCheckbox6')
    checkbox6.checked = eval(window.localStorage.getItem(checkbox6.id))

    checkbox6.addEventListener('change', function () {
        window.localStorage.setItem(checkbox6.id, checkbox6.checked)
    })


    //HERRAMIENTA PARA DESAHBILITAR MODULOS EN EL LADO DEL CLIENTE

    //A todos los checkbox ponerle nombre y hacer solo 1 consulta cuando se clickee alguno con nombre

    //MD_MODULO =A###############################
    var Update_Option = function () {
        if ($("#inlineCheckbox1").is(":checked")) {
            $("#OpA").prop('disabled', false);
        }
        else {
            $("#OpA").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox1").change(Update_Option);

    //MD_MODULO =B                   ################################
    var Update_Option = function () {
        if ($("#inlineCheckbox2").is(":checked")) {
            $("#OpB").prop('disabled', false);
        }
        else {
            $("#OpB").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox2").change(Update_Option);


    //MD_MODULO =C                  ################################
    var Update_Option = function () {
        if ($("#inlineCheckbox3").is(":checked")) {
            $("#OpC").prop('disabled', false);
        }
        else {
            $("#OpC").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox3").change(Update_Option);

    //MD_MODULO =D            #####################################

    var Update_Option = function () {
        if ($("#inlineCheckbox4").is(":checked")) {
            $("#OpD").prop('disabled', false);
        }
        else {
            $("#OpD").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox4").change(Update_Option);

    //MD_MODULO =E       ###################################

    var Update_Option = function () {
        if ($("#inlineCheckbox5").is(":checked")) {
            $("#OpE").prop('disabled', false);
        }
        else {
            $("#OpE").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox5").change(Update_Option);

    //MD_MODULO =F       ###################################

    var Update_Option = function () {
        if ($("#inlineCheckbox6").is(":checked")) {
            $("#OpF").prop('disabled', false);
        }
        else {
            $("#OpF").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox6").change(Update_Option);

    $("#update").click(() => { //Evento click para Botón Buscar

        //Call a funcíon Busca Datos

    });
    setInterval(Mostrar_Turno, 1000)

    $("#update").click(() => {
        fn__Update_Turno();
    });

    fn_reset();
    //boton para mostrar el panel de configuracion
    $("#config_btn").click(() => {
        MostrarConfig();
    });
    //boton qu oculta el panel de configuracion
    $("#config_btn").dblclick(() => {
        OcultarConfig();
    });
});

//FUNCIONES + VARIABLES


//Funcion para actualizar modulos ya creados 
function fn__Update_Turno() {

    var ID_TURNO
    switch ($("#moduloAtencion").val()) {
        case "A":
            ID_TURNO = 1
            break;

        case "B":
            ID_TURNO = 2
            break;

        case "C":
            ID_TURNO = 3
            break;

        case "D":
            ID_TURNO = 4
            break;

        case "E":
            ID_TURNO = 5
            break;

        case "F":
            ID_TURNO = 6
            break;

        default:
            ID_TURNO = null
    }
    var strParam = JSON.stringify({
        "ID_TURNO": ID_TURNO
    })

    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Turno", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            //console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            // console.log(data);
        }
    });
}
//funcion que envie la fecha actual a la base de datos para resetear el contador de los turnos 
function fn_reset() {
    var dateNow = moment().format("DD-MM-YYYY");
    //console.log(dateNow);
}

function fn_Update_Check() {

    var dateNow = moment().format("DD-MM-YYYY");
    var MD_FECHA = dateNow

    //Condicion A ############################################
    if ($("#inlineCheckbox1").is(":checked")) {
        var ID_MODULO_TURNO = 1;
        var ID_ESTADO = 1

    } else {
        var ID_MODULO_TURNO = 1;
        var ID_ESTADO = 2
    }

    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    console.log(strParam);

    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

    //Condicion 2###############################################
    if ($("#inlineCheckbox2").is(":checked")) {
        var ID_MODULO_TURNO = 2;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 2;
        var ID_ESTADO = 2
    }

    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    //console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            //console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

    //Condicion 3###############################################
    if ($("#inlineCheckbox3").is(":checked")) {
        var ID_MODULO_TURNO = 3;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 3;
        var ID_ESTADO = 2
    }




    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO,
    })

    console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            // console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });


    //Condicion 4###############################################

    if ($("#inlineCheckbox4").is(":checked")) {
        var ID_MODULO_TURNO = 4;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 4;
        var ID_ESTADO = 2
    }
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            //console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });


    //Condicion 5###############################################

    if ($("#inlineCheckbox5").is(":checked")) {
        var ID_MODULO_TURNO = 5;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 5;
        var ID_ESTADO = 2
    }
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            // console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

    //Condicion 6###############################################

    if ($("#inlineCheckbox6").is(":checked")) {
        var ID_MODULO_TURNO = 6;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 6;
        var ID_ESTADO = 2
    }
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    //console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

}

//ESTE SCRIPT SE ENCARGA DE VISUALIZAR EL TURNO INGRESADO EN LA VISTA DEL MODULO PARA PASAR AL SIGUIENTE TURNO

let modulo_Data = [{
    "MD_MODULO": "",
    "MD_MODULO_RECEP": "",
    "MD_TIPO_MODULO": ""
}];

function Mostrar_Turno() {

    switch ($("#moduloAtencion").val()) {
        case "A":
            var ID_TURNO = 1
            break;
        case "B":
            ID_TURNO = 2

            break;
        case "C":
            ID_TURNO = 3
            break;

        case "D":
            ID_TURNO = 4
            break;

        case "E":
            ID_TURNO = 5
            break;

        case "F":
            ID_TURNO = 6
            break;
        default:
            ID_TURNO = null
    }
    var strParam = JSON.stringify({
        "ID_TURNO": ID_TURNO
    });

    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Visor_Turno", //Formulario y función del Back End
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            modulo_Data = data.d;

            if (modulo_Data.length > 0) { //Si contiene datos

                // console.log( modulo_Data);

                //Fn_Crea_Tabla();
                CrearVista();


            } else { //Si no contiene datos
                console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });


}

function CrearVista() {

    $("#TurnoVista").empty();

    for (i = 0; i < modulo_Data.length; i++) {

        $("<div>").text("Turno Actual").css({
            "text-align": "center",
            "width": "7rem"
        }).attr({
            "id": "Carta" + i + "",
            "class": ""
        }).appendTo($("#TurnoVista"));

        $("#Carta" + i + "").append(
         $("<div>").css({

         }).attr({
             "id": "CardBodyMain" + i + "",
             "class": "row text-center mrgs mb-2"
         })//.appendTo($("#div_cartas"))
         );
        $("<div>").css({
            "width": "7rem",
            "height": "4.8rem",
            "background-color": "#006699"
        }).attr({
            "id": "CardBody" + i + "",
            "class": "card text-white mb-2"
        }).appendTo($("#CardBodyMain" + i + ""))
        $("#CardBody" + i + "").append(
        $("<div>").attr("class", "card-header"),
        $("<div>").css({
            "margin-top": "-25px",
            "text-align": "center",
            "font-size": "0.8rem"
        }).attr("class", "card-body")
         ).appendTo("#Carta" + i + "");

        //iteracion para que numeros menores de 10 se seteen con un = al principio
        if (modulo_Data[i].MD_MODULO_RECEP > 0 && modulo_Data[i].MD_MODULO_RECEP < 10) {
            modulo_Data[i].MD_MODULO_RECEP = "0" + modulo_Data[i].MD_MODULO_RECEP;
        }


        $("<h5>").css({ "margin": "0 auto", "font-size": "1rem", "height": "0.5rem", "text-align": "center", "font-weight": "600" }).text("" + modulo_Data[i].MD_MODULO + "" + modulo_Data[i].MD_MODULO_RECEP).attr({ "class": "card-title" + i + "" }).appendTo("#CardBody" + i + " .card-header");
        //$("<h2>").css({ "margin": "auto" }).text().attr("id", "MD_MODULO_RECEP").appendTo("#CardBody" + i + " .card-header");


        //SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
        if (Data_impresion[i].TR_TURNO_TIPO == 1) { Data_impresion[i].TR_TURNO_TIPO = "Atencion General"; }
        else if (Data_impresion[i].TR_TURNO_TIPO == 2) { Data_impresion[i].TR_TURNO_TIPO = "Atencion Empresa"; }
        else if (Data_impresion[i].TR_TURNO_TIPO == 3) { Data_impresion[i].TR_TURNO_TIPO = "Entrega de Examenes"; }
        else if (Data_impresion[i].TR_TURNO_TIPO == 4) { Data_impresion[i].TR_TURNO_TIPO = "Examen Pcr"; }

        $("<p>").css({ "margin": "0", "font-size": "0.9rem", "height": "0.5rem", "font-weight": "300" }).text(Data_impresion[i].TR_TURNO_TIPO).attr("id", "MD_TIPO_MODULO" + i + "").appendTo("#CardBody" + i + " .card-body");


    }
}

function MostrarConfig() {
    $("#config").css("display", "none");
    $("#config_btn").text("Cerrar Configuracion");
    if ($("#config").click) {
        $("#config").css("display", "block");
    }
}
function OcultarConfig() {
    $("#config").css("display", "none");
    $("#config_btn").text("Abrir Configuracion");
    if ($("#config").dblclick) {
        $("#config").css("display", "none");
    }
}
