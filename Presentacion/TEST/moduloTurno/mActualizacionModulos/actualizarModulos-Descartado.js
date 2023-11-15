let Turno_Actual = [];

$(document).ready(() => { //Función al cargar documento.

    Ajax_Busca_Datos();
    $("#update").dblclick(() => {
        
    });

    fn_Actualizar_Visor();

    setInterval(updateTime, 1000);

    var a = Window.seleccionTurno;

    $("#Head_Cartas").empty();
    $("#div_cartas").empty();

    $("#Head_Cartas").attr({ "class": "text-left" })
    $("<h2>").text("Turnos de Atención").attr({
        "class": "text-center header-title"
    }).css({
        "text-align": "right",
        "font-size": "4.5rem",
        "color": "#006699"
    }).appendTo($("#Head_Cartas"));

});

function fn_Actualizar_Visor(){
    setInterval(Ajax_Busca_Datos, 8000)
    //cuando se ejecuta el Ajax  se visualizan las cartas pero entra en un bucle mientras no se actualice la pagina
}

let TURNO_DATA = [{    
    "MD_MODULO": "",//Letra del turno A
    "MD_MODULO_RECEP": "",//Numero del tuno
    "MD_TIPO_MODULO": "",//tipo de modulo, para generar la leyenda
    "ID_MODULO_TURNO": ""
}];

function Ajax_Busca_Datos() {    
    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "actualizarModulos.aspx/Busca_Modulos", //Formulario y función del Back End
        //"data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            TURNO_DATA = data.d;

            if (TURNO_DATA.length > 0) { //Si contiene datos

                //console.log(TURNO_DATA);
                Fn_Crear_Carta();
              
            } else { //Si no contiene datos
              console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });
}


//Funcion Reloj
var updateTime = function () {


    //Dias de la semana

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

function Fn_Crear_Carta() {
    console.log("Crea Carta");
    let _Init =0;
    if (Turno_Actual.length == 0) {
        TURNO_DATA.forEach(_t=> {
            Turno_Actual.push({ ID: _t.ID_MODULO_TURNO, TURNO: _t.MD_MODULO_RECEP });
            console.log(Turno_Actual)
        });
        _Init = 1;
    } else {
        _Init = 0;
    }
    //console.log(Turno_Actual);
    for (i = 0; i < TURNO_DATA.length; i++) {
        Fn_Crea_Individual(i, _Init);
    }
}
function Fn_Crea_Individual(i, _Init) {
    
    let _Actualiza = 0;
    let _Existe = 0;

    Turno_Actual.forEach(_t => {
        if (_t.ID == TURNO_DATA[i].ID_MODULO_TURNO) {
            _Existe = 1;
            
            if (_t.TURNO != TURNO_DATA[i].MD_MODULO_RECEP) {
                _Actualiza = 1;
            }
        } 
    });

    //Preguntar si lo que llego de la bd es igual a lo de la variable Turno Actual, si no existe uno, se elimina por ID MODULO
    //console.log(_Existe + " " + _Actualiza);
    if (_Existe == 0 || _Init == 1) {
        $("<div>").attr({ "id": "Carta" + TURNO_DATA[i].ID_MODULO_TURNO + "", "class": "col-auto" }).appendTo($("#div_cartas"));

        $("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO + "").css({
            "margin-top": "24px",
            "border-radius": "10px",
            "padding": "8px"
        }).append(

       //CardBodyMain
       $("<div>").css({
           "max-width": "14rem",
           "margin-top": "-24px"
       }).attr({
           "id": "CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + "",
           "class": "row text-center mrgs mb-4"
       })
    );
        $("<div>").css({
            "border-radius": "10px",
            "width": "15rem",
            "height": "13rem",
            "background-color": "#006699"
        }).attr({ "id": "CardBody" + TURNO_DATA[i].ID_MODULO_TURNO + "", "class": "card text-white mb-4" }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""))

        //Construccion de CardBody 

        //card header
        $("#CardHeader" + TURNO_DATA[i].ID_MODULO_TURNO + "").append(
        $("<div>").attr({ "class": "card-header", "id": "card" + TURNO_DATA[i].ID_MODULO_TURNO }),//.appendTo($("#CardBody" + i + ""))

        //card body
        $("<h2>").css({
            "border-radius": "0 0 10px 10px",
            "margin": "0",
            "padding": "0",
            "text-align": "center",
            "font-weight": "600",
            "font-size": "5rem",
            "background-color": "#2589bd"
        }).text("" + TURNO_DATA[i].MD_MODULO + "" + TURNO_DATA[i].MD_MODULO_RECEP).attr({ "id": "card" + TURNO_DATA[i].ID_MODULO_TURNO, "class": "card-body"})//.appendTo($("#CardBody" + i + ""))
        )
    } else if (_Existe == 1 && _Actualiza == 1) {
        Turno_Actual.forEach(_t => {
            if (_t.ID == TURNO_DATA[i].ID_MODULO_TURNO) {
                _t.TURNO = TURNO_DATA[i].MD_MODULO_RECEP;
            }
            
        });

    } else {
        //console.log("return");
        return false;
    }
    /// ORDERNAR DE ACÁ PARA ABAJO

    //iteracion para que numeros menores de 10 se seteen con un 0 al principio
    //if (TURNO_DATA[i].MD_MODULO_RECEP < 10) {
    //    TURNO_DATA[i].MD_MODULO_RECEP = "0" + TURNO_DATA[i].MD_MODULO_RECEP;
    //}
    //***********************************Cuerpo de la carta*****************************************************

    
    //$("#Carta" + TURNO_DATA[i].ID_MODULO_TURNO + "").css({
    //    "margin-top": "0rem",
    //    "border-radius": "10px",
    //    "padding":"8px"
    // }).append(

    //    //CardBodyMain
    //    $("<div>").css({
    //         "max-width": "15rem",
    //         "margin": "0.05rem"
    //     }).attr({
    //         "id": "CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + "",
    //         "class": "row text-center mrgs mb-4"
    //     })
    // );

    //CardBody
    //$("<div>").css({
    //    "border-radius": "10px",
    //    "width": "16rem",
    //    "height": "13rem",
    //    "background-color": "#006699"
    //}).attr({ "id": "CardBody" + TURNO_DATA[i].ID_MODULO_TURNO + "", "class": "card text-white mb-4" }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""))

    //Construccion de CardBody 

    //card header
    //$("#CardBody" + TURNO_DATA[i].ID_MODULO_TURNO + "").append(
    //$("<div>").attr({ "class": "card-header", "id": "card" + TURNO_DATA[i].ID_MODULO_TURNO }),

    //card body


    //$("<h2>").css({
    //    "border-radius": "0 0 10px 10px",
    //    "margin": "0",
    //    "padding": "0",
    //    "text-align": "center",
    //    "font-weight": "600",
    //    "font-size": "5.2rem",
    //    "background-color": "#2589bd"
    //}).text("" + TURNO_DATA[i].MD_MODULO + "" + TURNO_DATA[i].MD_MODULO_RECEP).attr({ "id": "cardB", "class": "card-body" + TURNO_DATA[i].ID_MODULO_TURNO + "" })
    // )//.appendTo($("#CardBody" + i + ""));

    //card footer
    $("<div>").text("Modulo" + " " + TURNO_DATA[i].MD_MODULO).css({
        "border-radius": "10px 10px",
        "width": "15rem",
        "height": "5rem",
        "margin": "auto",
        "font-size": "1.8rem",
        "font-weight": "700",
        "text-transform": "uppercase",
        "background-color": "#006699"
    }).attr({ "id": "footer_Card", "class": "card-footer  text-white text-center" }).appendTo($("#CardBodyMain" + TURNO_DATA[i].ID_MODULO_TURNO + ""));

    //Cntenido de Card-header
    $("<h3>").css({
        "margin": "0",
        "text-align": "center",
        "font-weight": "700"
    }).text("TURNO ").attr({ "class": "card-title", "id": "MD_MODULO" + TURNO_DATA[i].ID_MODULO_TURNO + "" }).appendTo($("#CardBody" + TURNO_DATA[i].ID_MODULO_TURNO + " .card-header"));

    //if (TURNO_DATA[i].MD_MODULO == "A") {
    //    TURNO_DATA[i].MD_MODULO = 1;
    //}
    //else if (TURNO_DATA[i].MD_MODULO == "B") {
    //    TURNO_DATA[i].MD_MODULO = 2;
    //} else if (TURNO_DATA[i].MD_MODULO == "C") {
    //    TURNO_DATA[i].MD_MODULO = 3;
    //} else if (TURNO_DATA[i].MD_MODULO == "D") {
    //    TURNO_DATA[i].MD_MODULO = 4;
    //} else if (TURNO_DATA[i].MD_MODULO == "E") {
    //    TURNO_DATA[i].MD_MODULO = 5;
    //} else if (TURNO_DATA[i].MD_MODULO == "F") {
    //    TURNO_DATA[i].MD_MODULO = 6;
    //}

    //Contenido de CardBody
    //SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
    if (TURNO_DATA[i].MD_TIPO_MODULO == 1) { TURNO_DATA[i].MD_TIPO_MODULO = "Atencion General"; }
    else if (TURNO_DATA[i].MD_TIPO_MODULO == 2) { TURNO_DATA[i].MD_TIPO_MODULO = "Atencion Empresa"; }
    else if (TURNO_DATA[i].MD_TIPO_MODULO == 3) { TURNO_DATA[i].MD_TIPO_MODULO = "Toma de Muestras"; }
    else if (TURNO_DATA[i].MD_TIPO_MODULO == 4) { TURNO_DATA[i].MD_TIPO_MODULO = "Examen Pcr"; }

    $("<p>").css({
        "font-size": "1.2rem",
        "font-weight": "700"
    }).text("Atencion:").text(TURNO_DATA[i].MD_TIPO_MODULO).attr("id", "MD_TIPO_MODULO" + TURNO_DATA[i].ID_MODULO_TURNO + "").appendTo($("#CardBody" + TURNO_DATA[i].ID_MODULO_TURNO + " #cardB"));

    if (_Actualiza == 1) {

       
        //$("#CardBodyMain" + i).toggleClass("Carta");
        $("#CardBody" + i).toggleClass("CartaAnim");
        $(".card-body" + i).toggleClass("CartaAnim");
        var sonido = new Audio();
        sonido.src = "Sound/turno-sound.wav"

        sonido.play();
    }
    

}
