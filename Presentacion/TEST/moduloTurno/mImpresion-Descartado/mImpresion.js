$(document).ready(() => {
    
    //funcion que establece la primera vista como 1 en el turno A
    fn_primeraVista();
    
    setInterval(LimpiarCarta, 2000)
    //Crear_ticket();
    $("#btn-General").click(() => {
        countingClicks()
    });


    $("#btn-General").click(() => {
        Crear_ticket_General();
        fn_Imprimir();
    });

    //$("#btn-General").click(() => {Crear_ticket_General() });

    //$("#btn-Empresa").click(() => { fn_Imprimir(2); });
    //$("#btn-Examen").click(() => { fn_Imprimir(3); });
    //$("#btn-PCR").click(() => { fn_Imprimir(4); });
    //BTN GENERAL.CLICK EJECUTA CREAR TICKET

    $("#btn-General").click(() => {
        Crear_ticket_General();
    });
})


let turno_Impr_Data = [{
    "ID_TURNO_IMPR":"",
    "TR_TURNO_LET" : "",
    "TR_TURNO_NUM:": "",
    "TR_TURNO_TIPO": ""

}];

//funcion  para el envio de tipo de modulos
function fn_Imprimir(btn_tipo) {


    Data_Par = JSON.stringify([
       btn_tipo
    ]);
    console.log(btn_tipo)
    $.ajax({
        "type": "POST",
        "url": "http://localhost:9990/Turno_M/Imp_Turno_Manual",
        "data": Data_Par,
        "contentType": "application/json;  charset=utf-8",
        "crossDomain": "true",
        "dataType": "json",
        "timeout": 50000,
        "success": data => {
            console.log(Data_Par)
        },
        "error": data => {

        }
    });
}

//Primera vista encargada de setear elñ primer valor del valor del visor de tickets
function fn_primeraVista() {
    var ID_TURNO_IMPR = 1
    var StrParam = JSON.stringify({
        "ID_TURNO_IMPR": ID_TURNO_IMPR
    })

    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "mImpresion.aspx/M_Impresion", //Formulario y función del Back End
        "data": StrParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            turno_Impr_Data = data.d;

            if (turno_Impr_Data.length > 0) { //Si contiene datos
                //Crear_ticket();
                console.log(turno_Impr_Data);
                LimpiarCarta();
            } else { //Si no contiene datos
                console.log(data);

            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

}


//funcion contador para generar las 3 opciones de ingreso del primer boton de atencin general 
var count_click = 1;
function countingClicks() {
    count_click = ++count_click
    if (count_click > 3) {
        count_click = 1
    }

}

function Crear_ticket_General() {
    //CONTROL DE BOTON DE ATENCION GENERAL

        //Call a funcíon Busca Datos
        var TR_TURNO_LET
        console.log(count_click)
        if (count_click == 1) {
            TR_TURNO_LET ="A"
        } else if (count_click == 2) {
            TR_TURNO_LET ="B"
        } else if(count_click== 3) {
            TR_TURNO_LET = "C"
        }

        var ID_TURNO_IMPR = count_click;
        

        var StrParam = JSON.stringify({
            "ID_TURNO_IMPR": ID_TURNO_IMPR
            

        })
        console.log(StrParam);

        AJAX_Dtt = $.ajax({
            "type"       : "POST", //Método GET o POST
            "url"        : "mImpresion.aspx/M_Impresion", //Formulario y función del Back End
            "data"       : StrParam, //Parámetros a enviar
            "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
            "dataType"   : "json", //Tipo de dato "JSON"
            "success"    : data => { //Retorno estado Success (200)

                turno_Impr_Data = data.d;

                if (turno_Impr_Data.length > 0) { //Si contiene datos
                    
                    console.log(turno_Impr_Data);
                } else { //Si no contiene datos
                    console.log(data);

                }
            },
                "error": data => { // Retorno Error (500, 400, etc)
                    console.log(data);
            }
        });


    //CONTROL DE BOTON DE ATENCION A EMPRESAS
    $("#btn-Empresa").click(() => { //Evento click para Botón Buscar
        //Call a funcíon Busca Datos
        var ID_TURNO_IMPR = 4

        var StrParam = JSON.stringify({
            "ID_TURNO_IMPR":ID_TURNO_IMPR
        })
        console.log(StrParam);
    
    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url" : "mImpresion.aspx/M_Impresion", //Formulario y función del Back End
        "data": StrParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

        turno_Impr_Data = data.d;

        if (turno_Impr_Data.length > 0) { //Si contiene datos

            console.log(turno_Impr_Data)
        } else { //Si no contiene datos
            console.log(data);
        }
    },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

});

    //CONTROL DE BOTON DE ATENCION A EXAMEN
    $("#btn-Examen").click(() => { //Evento click para Botón Buscar
        //Call a funcíon Busca Datos
        var ID_TURNO_IMPR = 5

        var StrParam = JSON.stringify({
            "ID_TURNO_IMPR": ID_TURNO_IMPR
        })
        console.log(StrParam);

        AJAX_Dtt = $.ajax({
            "type": "POST", //Método GET o POST
            "url": "mImpresion.aspx/M_Impresion", //Formulario y función del Back End
            "data": StrParam, //Parámetros a enviar
            "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
            "dataType": "json", //Tipo de dato "JSON"
            "success": data => { //Retorno estado Success (200)

                turno_Impr_Data = data.d;

                if (turno_Impr_Data.length > 0) { //Si contiene datos

                    console.log(turno_Impr_Data)
                } else { //Si no contiene datos
                    console.log(data);
                }
            },
            "error": data => { // Retorno Error (500, 400, etc)
                console.log(data);
            }
        });
    });


    //CONTROL DE BOTON DE ATENCION A EXAMEN
    $("#btn-PCR").click(() => { //Evento click para Botón Buscar
        //Call a funcíon Busca Datos
        var ID_TURNO_IMPR = 6

        var StrParam = JSON.stringify({
            "ID_TURNO_IMPR": ID_TURNO_IMPR
        })
        console.log(StrParam);

        AJAX_Dtt = $.ajax({
            "type": "POST", //Método GET o POST
            "url": "mImpresion.aspx/M_Impresion", //Formulario y función del Back End
            "data": StrParam, //Parámetros a enviar
            "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
            "dataType": "json", //Tipo de dato "JSON"
            "success": data => { //Retorno estado Success (200)

                turno_Impr_Data = data.d;

                if (turno_Impr_Data.length > 0) { //Si contiene datos

                    console.log(turno_Impr_Data)
                } else { //Si no contiene datos
                    console.log(data);
                }
            },
            "error": data => { // Retorno Error (500, 400, etc)
                console.log(data);
            }
        });
    });


}



//funcion que crea la carta(cambiar nombre)
function LimpiarCarta() {


    $("#vistaTicket").empty();

     for(i = 0; i < turno_Impr_Data.length; i++){
         $("#vistaTicket").attr({
             "class": "card"
         }).css({
             "border-radius":"10px",
             "background-color": "#006699",
             "color": "white",
             "text-align": "center"
         })
    //CABECERA DE LA CARTA
    $("<div>").attr({
        "class": "card-header" ,
        "id": "tr_Turno" + turno_Impr_Data[i].ID_TURNO_IMPR + ""
    }).text("TURNO").appendTo($("#vistaTicket"))

    //CUERPO DE LA CARTA
    $("<div>").attr({
        "class": "card-body" + turno_Impr_Data[i].ID_TURNO_IMPR + "",
        "id": "tr_Info" 
    }).appendTo($("#vistaTicket"))

    //INFORMACION TRAIDA DE LA BASE DE DATOS 
    //$("<h3>").attr({ "class": "TR_LET", "id": "tr_Let" + turno_Impr_Data[i].ID_TURNO_IMPR + "" }).text("" + turno_Impr_Data[i].TR_TURNO_LET + "").appendTo($("#tr_Info"))
    $("<h4>").attr({ "class": "TR_NUM", "id": "tr_Num" + turno_Impr_Data[i].ID_TURNO_IMPR + "" }).text(turno_Impr_Data[i].TR_TURNO_LET+" " + turno_Impr_Data[i].TR_TURNO_NUM).appendTo($("#tr_Info"))


         //pie de la carta donde informaremos el nombre del modulo

    if (turno_Impr_Data[i].TR_TURNO_TIPO == 1) {
        turno_Impr_Data[i].TR_TURNO_TIPO = "ATENCIÓN GENERAL"
    } else if (turno_Impr_Data[i].TR_TURNO_TIPO == 2) {
        turno_Impr_Data[i].TR_TURNO_TIPO = "ATENCIÓN EMPRESAS"
    } else if (turno_Impr_Data[i].TR_TURNO_TIPO == 3) {
        turno_Impr_Data[i].TR_TURNO_TIPO = "EXÁMENES"
    } else if (turno_Impr_Data[i].TR_TURNO_TIPO == 4) {
        turno_Impr_Data[i].TR_TURNO_TIPO = "PCR"
    }
    $("<div>").attr({
        "class": "card-footer",
        "id": "tr_Foot" + turno_Impr_Data[i].ID_TURNO_IMPR + ""
    }).text("" + turno_Impr_Data[i].TR_TURNO_TIPO + "").appendTo($("#vistaTicket"))

    }
}