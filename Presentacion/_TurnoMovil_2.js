﻿let Turno_Actual = [];//arreglo que almacenara la respuesta de mis cartas

let _ID_Turno = "", _Turno = "";

//PRIMER PARAMETRO DEBERA SER ASI PARA : ID_TURNO= 1 2 3 4 5,
//EL SEGUNDO DEBE SER ASI : A01 B01 C01 D01 E01 F01 SEGUN CORRESPONDA ,
//USAR MAYUSCULA Y EL 0 CORRESPONDIENTE EN NUMEROS DE UNA UNIDAD

$(document).ready(() => { //Función al cargar documento.
    _ID_Turno = getParameterByName("ID_TURNO");
    _Turno = getParameterByName("TURNO");

    Ajax_Busca_Datos();

    updateTime();

    //Intervalo de la funcion del reloj cada un segundo;
    setInterval(updateTime, 1000);
    setInterval(Ajax_Busca_Datos, 6000)

    //Metodo para limpiar la vista de las cartas
    $("#Head_Cartas").empty();
    $("#div_cartas").empty();


});

//Funcion para capturar el parametro get 
function getParameterByName(name) {    // Fuera del doc ready
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

//Funcion para el funcionamiento de  fecha + reloj
let updateTime = function () {
    //MESES
    var meses = [
        'Ene',
        'Feb',
        'Mar',
        'Abr',
        'May',
        'Jun',
        'Jul',
        'Agos',
        'Sept',
        'Oct',
        'Nov',
        'Dic'
    ]
    //DIAS
    var diasSem = [
        'Dom',
        'Lun',
        'Mar',
        'Miér',
        'Jue',
        'Vie',
        'Sab'

    ]

    var f = new Date();
    //document.write(diasSem[f.getDay()] + ", " + f.getDate() + " de " + meses[f.getMonth()] + " de " + f.getFullYear());

    document.getElementById('S').textContent = diasSem[f.getDay()];
    document.getElementById('D').textContent = f.getDate();
    document.getElementById('M').textContent = meses[f.getMonth()];
    document.getElementById('A').textContent = f.getFullYear();

    let currentDate = new Date(),
    hours = currentDate.getHours(),
    minutes = currentDate.getMinutes(),
    seconds = currentDate.getSeconds()
    document.getElementById('h').textContent = hours;

    if (minutes < 10) {
        minutes = "0" + minutes
    }

    if (seconds < 10) {
        seconds = "0" + seconds
    }

    document.getElementById('m').textContent = minutes;
    document.getElementById('s').textContent = seconds;
};

//Definicion de parametros a trabajar
let TURNO_DATA = [{
    "ID_MODULO_TURNO":"",
    "MD_MODULO": "",//Letra del turno A
    "MD_MODULO_RECEP": "",//Numero del tuno
    "MD_TIPO_MODULO": "",//tipo de modulo, para generar la leyenda
    "ID_ESTADO": ""
}];
//Funcion Ajax para el envio y recepcion de datos desde a BD
function Ajax_Busca_Datos() {

    let strParam = JSON.stringify({
        "ID_MODULO_TURNO": _ID_Turno
    });


    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "_TurnoMovil_2.aspx/Busca_Modulo_Movil", //Formulario y función del Back End
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            TURNO_DATA = data.d;

            if (TURNO_DATA.length > 0) { //Si contiene datos
                //console.log("json:" + strParam);
                //console.log(TURNO_DATA);
                Fn_Crear_Carta();

            } else { //Si no contiene datos
               // console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            //console.log(data);
        }
    });
}


//Funcion para la creacion del visor 

function Fn_Crear_Carta() {

    //console.log("Crea Carta");
    let _Init = 0;

    //recorre el conjunto de datos TURNO_DATA y lo almacena en el arreglo de objetos Turno_actual

    if (Turno_Actual.length == 0) {
        TURNO_DATA.forEach(_t=> {
            Turno_Actual.push({ ID: _t.ID_MODULO_TURNO, TURNO: _t.MD_MODULO_RECEP, ESTADO: _t.ID_ESTADO });
            //console.log(Turno_Actual)
        });
        _Init = 1;
    } else {
        _Init = 0;
    }
    //console.log(Turno_Actual);
    //console.log("ID:" + _ID_Turno);
    //Fn_Crea_Individual(_ID_Turno, _Init)
    for (i = 0; i < Turno_Actual.length; i++) {
        Fn_Crea_Individual(i, _Init)
    }
}
//Funcion para Crear cada carta de forma individual
function Fn_Crea_Individual(i, _Init) {
    //iniacializar Variables
    let _Actualiza = 0;
    let _Existe = 0;
    let _Activo = 0;

    //Recorre y comprueba que exiten dichos parametros en el arreglo
    Turno_Actual.forEach(_t => {
        if (_t.ID == TURNO_DATA[i].ID_MODULO_TURNO) {
            _Existe = 1;

            if (_t.TURNO != TURNO_DATA[i].MD_MODULO_RECEP) {
                _Actualiza = 1;
            } else if (_t.ESTADO != TURNO_DATA[i].ID_ESTADO) {
                _Activo = 0

            }
        }
    });

    //Preguntar si lo que llego de la bd es igual a lo de la variable Turno Actual
    //, si no existe uno, se elimina por ID MODULO

    //INICIO construccion de las cartas 
    if (_Existe == 0 || _Init == 1) {
        //SI SE ENCUENTRAN PARAMETROS Y SI SU ESTADO ES ACTIVO QUE GENERE LOS MODULOS CORRESPONDIENTES
        if (_Activo == 0) {
            Turno_Actual.forEach(_t => {
                if (_t.ID == TURNO_DATA[i].ID_MODULO_TURNO) {
                    _t.ESTADO = TURNO_DATA[i].ID_ESTADO;
                    if (_t.ESTADO == 1) {
                        //console.log(_Existe + "existe actualiza " + _Init)
                        //console.log(_Existe + " Prueba " + _Init)
                        //CONTENEDOR DE LA CARTA PRINCIPAL
                        $("<div>").attr({
                            "id": "Carta" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                            "class": "col"
                        }).css({
                            "margin": "0 auto"

                        }).appendTo($("#div_cartas"));

                        //CUERPO PRINCIPAL DE LA CARTA
                        $("<div>").css({
                            "max-width": "14rem",
                            "border-radius": "10px",
                            "margin-top": "-24px",
                            "margin": "0 auto",
                            "border-color": "white"
                        }).attr({
                            "id": "CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                            "class": "card row text-center mrgs mb-4"
                        }).appendTo($("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO + ""));

                        //CABECERA DE LA CARTA
                        $("<div>").css({
                            "border-radius": "10px 10px 0 0",
                            "width": "14rem",
                            "background-color": "#006699"
                        }).attr({
                            "id": "CardHead" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                            "class": "card-header"
                        }).text("Turno").appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO))
                        //CUERPO DE LA CARTA

                        //iteracion para que numeros menores de 10 se seteen con un 0 al principio
                        if (TURNO_DATA[i].MD_MODULO_RECEP < 10) {
                            TURNO_DATA[i].MD_MODULO_RECEP = "0" + TURNO_DATA[i].MD_MODULO_RECEP;
                        }

                        $("<h2>").css({
                            "margin": "0",
                            "padding": "0",
                            "text-align": "center",
                            "font-weight": "600",
                            "font-size": "5rem",
                            "background-color": "#2589bd"
                        }).text(TURNO_DATA[i].MD_MODULO + TURNO_DATA[i].MD_MODULO_RECEP).attr({
                            "id": "card" + TURNO_DATA[i].ID_MODULO_TURNO,
                            "class": "card-body"
                        }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""))



                        //SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
                        if (TURNO_DATA[i].MD_TIPO_MODULO == 1) { TURNO_DATA[i].MD_TIPO_MODULO = "Atencion General"; }
                        else if (TURNO_DATA[i].MD_TIPO_MODULO == 2) { TURNO_DATA[i].MD_TIPO_MODULO = "Atencion Empresa"; }
                        else if (TURNO_DATA[i].MD_TIPO_MODULO == 3) { TURNO_DATA[i].MD_TIPO_MODULO = "Toma de Muestras"; }
                        else if (TURNO_DATA[i].MD_TIPO_MODULO == 4) { TURNO_DATA[i].MD_TIPO_MODULO = "Examen Pcr"; }

                        $("<div>").css({
                            "font-size": "1.2rem",
                            "font-weight": "700",
                            "background-color": "#2589bd",
                            "margin-bottom": "15px",
                            "border-radius": "0 0 10px 10px"
                        }).text("Atencion:").text(TURNO_DATA[i].MD_TIPO_MODULO).attr({
                            "id": "text-carta" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                            "class": "text_card"
                        }).appendTo
                        ($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO));


                        //PIE DE LA CARTA
                        $("<div>").text("Modulo" + " " + TURNO_DATA[i].MD_MODULO).css({
                            "border-radius": "10px 10px",
                            "width": "14rem",
                            "height": "4rem",
                            "margin": "auto",
                            "font-size": "1.8rem",
                            "font-weight": "700",
                            "text-transform": "uppercase",
                            "background-color": "#006699"
                        }).attr({
                            "id": "footer_Card",
                            "class": "card-footer text-center"
                        }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""));

                    }
                }
            });

            if (TURNO_DATA[i].MD_MODULO + TURNO_DATA[i].MD_MODULO_RECEP == _Turno) {
                //console.log("TURNO NOTIFICAR");
                Fn_Notificacion(TURNO_DATA[i].ID_MODULO_TURNO);
            }

        }
        //Si el turno Existe y es actualizado se ejecutara esta condicion 

    } else if (_Existe == 1 && _Actualiza == 1) {
        console.log(_Existe + " Existe y actualiza " + _Actualiza)
        //$("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO).empty();

        Turno_Actual.forEach(_t => {
            if (_t.ID == TURNO_DATA[i].ID_MODULO_TURNO) {
                _t.TURNO = TURNO_DATA[i].MD_MODULO_RECEP;
                //Al existir previamente borramos la carta y generamos la nueva en su lugar   

                $("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO).empty();

                //CONTENEDOR DE LA NUEVA CARTA PRINCIPAL 
                $("<div>").attr({
                    "id": "Carta" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                    "class": "col"
                }).css({
                    "margin": "0",
                    "border-radius": "10px"
                }).appendTo($("#div_cartas"));

                //CUERPO PRINCIPAL DE LA CARTA 
                $("<div>").css({
                    "max-width": "14rem",
                    "border-radius": "10px",
                    "margin-top": "-24px",
                    "margin": "0 auto",
                    "border-color": "white"
                }).attr({
                    "id": "CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                    "class": "card row text-center mrgs mb-4"
                }).appendTo($("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO + ""));
               
                //CABECERA DE LA CARTA
                $("<div>").css({
                    "border-radius": "10px 10px 0 0",
                    "width": "14rem",
                    "background-color": "#006699"
                }).attr({
                    "id": "CardHead" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                    "class": "card-header"
                }).text("Turno").appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""))

                //CUERPO DE LA CARTA
                //iteracion para que numeros menores de 10 se seteen con un 0 al principio
                if (TURNO_DATA[i].MD_MODULO_RECEP < 10) {
                    TURNO_DATA[i].MD_MODULO_RECEP = "0" + TURNO_DATA[i].MD_MODULO_RECEP;
                }

                //INFORMACION DEL TURNO ACTUALIZADO EJ: A01
                $("<h2>").css({
                    "margin": "0",
                    "padding": "0",
                    "text-align": "center",
                    "font-weight": "600",
                    "font-size": "5rem",
                    "background-color": "#2589bd"
                }).text("" + TURNO_DATA[i].MD_MODULO + "" + TURNO_DATA[i].MD_MODULO_RECEP).attr({
                    "id": "card" + TURNO_DATA[i].ID_MODULO_TURNO,
                    "class": "card-body"
                }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""))

                //SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
                if (TURNO_DATA[i].MD_TIPO_MODULO == 1) { TURNO_DATA[i].MD_TIPO_MODULO = "Atencion General"; }
                else if (TURNO_DATA[i].MD_TIPO_MODULO == 2) { TURNO_DATA[i].MD_TIPO_MODULO = "Atencion Empresa"; }
                else if (TURNO_DATA[i].MD_TIPO_MODULO == 3) { TURNO_DATA[i].MD_TIPO_MODULO = "Toma de Muestras"; }
                else if (TURNO_DATA[i].MD_TIPO_MODULO == 4) { TURNO_DATA[i].MD_TIPO_MODULO = "Examen Pcr"; }

                //DESCRIPCION DEL MODULO QUE CORRESPONDE A CADA CARTA 
                $("<div>").css({
                    "font-size": "1.2rem",
                    "font-weight": "700",
                    "background-color": "#2589bd",
                    "margin-bottom": "15px",
                    "border-radius": "0 0 10px 10px"
                }).text("Atencion:").text(TURNO_DATA[i].MD_TIPO_MODULO).attr({
                    "id": "text-carta" + TURNO_DATA[i].ID_MODULO_TURNO + "",
                    "class": "text_card"
                }).appendTo
                ($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO));

                //PIE DE LA CARTA
                $("<div>").text("Modulo" + " " + TURNO_DATA[i].MD_MODULO).css({
                    "border-radius": "10px 10px",
                    "width": "14rem",
                    "height": "4rem",
                    "margin": "0 auto",
                    "font-size": "1.8rem",
                    "font-weight": "700",
                    "text-transform": "uppercase",
                    "background-color": "#006699"
                }).attr({
                    "id": "footer_Card",
                    "class": "card-footer text-center"
                }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""));
            }
        });

        if (TURNO_DATA[i].MD_MODULO + TURNO_DATA[i].MD_MODULO_RECEP == _Turno) {
            Fn_Notificacion(TURNO_DATA[i].ID_MODULO_TURNO);
        }
    }
    else if (_Activo == 0) {
        //Funcion para limpiar las cartas con estado desactivado
        Turno_Actual.forEach(_t => {
            if (_t.ID == TURNO_DATA[i].ID_MODULO_TURNO) {
                _t.ESTADO = TURNO_DATA[i].ID_ESTADO;
                if (_t.ESTADO == 2) {
                    $("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO).empty();
                }
                //console.log(_t.ESTADO + "Desactivado?")
            }
        });
    }
}

function Fn_Notificacion(IDT) {
    //console.log("IDT " + IDT);
    //EFECTOS DE CAMBIO DE COLOR Y SONIDO PARA LA CARTA QUE ES ACTUALIZADA 
    $("#card" + IDT).toggleClass("CartaAnim");
    $("#CardHead" + IDT).toggleClass("CartaAnim");
    $("#text-carta" + IDT).toggleClass("CartaAnim");
    var sonido = new Audio();
    sonido.src = "Sound/turno-sound.wav"
    sonido.play();
}