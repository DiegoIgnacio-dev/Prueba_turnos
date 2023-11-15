$(document).ready(() => {


    $("#update").click(() => { //Evento click para Botón Buscar

        //Call a funcíon Busca Datos

    });
    setInterval(Mostrar_Turno, 1000)


});


//ESTE SCRIPT SE ENCARGA DE VISUALIZAR EL TURNO INGRESADO EN LA VISTA DEL MODULO PARA PASAR AL SIGUIENTE TURNO


//MD_MODULO
//MD_MODULO_RECEP
//MD_TIPO_MODULO

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