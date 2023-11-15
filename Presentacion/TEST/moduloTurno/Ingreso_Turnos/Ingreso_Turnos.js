
var Turno_Actual = [];
var objList = [];

$(document).ready(() => {
    fn_reset_turnos();

    fn_Cargar_Option();
    fn_Cargar_Option_Tp();

    //$("#moduloAtencion").change(function () {
    //    fn_Mostrar_Impr();
    //    fn_Mostrar_Turno();
    //})
    setInterval(fn_Mostrar_Turno, 2000);
    setInterval(fn_Mostrar_Impr, 2000);

    //setInterval($("#UltimaImpr").empty, 2000);
    $("#update").click(() => {
        //fn_Siguiente_Turno();
        fn_Turno_Menor();
    });

    $("#btn_config").click(() => {
        //fn_update_fecha();
        fn_Mostrar_Turno()();
    })

    $("#tipoAtencion").change(function () {
        $("#TurnoVista").empty();
        $("#UltimaImpr").empty();

        fn_Mostrar_Impr();
        
    });
    $("#moduloAtencion").change(function () {
        fn_Mostrar_Turno();
    });
});

//function fn_update_fecha() {
//    //let ID_MODULO_RECEP = modulo_Data[i].MD_MODULO;
//    let TIPO_ATENCION = ($('select[id=tipoAtencion]').val());//valor usando para definir el tipo ya sea 1 2 3 4

//    var parametros = JSON.stringify({
//        "ID_MODULO_RECEP":  modulo_Data[i].MD_MODULO,
//        "TIPO_ATENCION":TIPO_ATENCION
//    })

//    $.ajax({
//        "type": "POST", //Método GET o POST
//        "url": "Ingreso_Turnos.aspx/UPDATE_TIME", //Formulario y función del Back TE LLEVA A ingreso_producto
//        "data": parametros, //Parámetros a enviar
//        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
//        "dataType": "json", //Tipo de dato "JSON"
//        "success": data => { //Retorno estado Success (200)
//            console.log(data);
//        },
//        "error": data => { // Retorno Error (500, 400, etc)
//            // console.log(data);
//        }
//    });


//}


function fn_reset_turnos() {
    //capturar la fecha actual y comparar con la de los registros de mi base de datos para resetear
    let ONLY_DATE = moment().format("DD-MM-YYYY");//captura mi fecha

    //var strParam = JSON.stringify({
    //    "ONLY_DATE": ONLY_DATE//enviaremos la fecha para que por PA se hara un reset del contador
    //})
    //enviar fecha y consultar por cada registro 
    
    let Fecha_Data = [{
        "ID_MODULO_TURNO": "",
        "MD_FECHA": ""
    }];
    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "Ingreso_Turnos.aspx/RESET_FECHA", //Formulario y función del Back TE LLEVA A ingreso_producto
        //"data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            console.log(data);
            Fecha_Data = data;
        },
        "error": data => { // Retorno Error (500, 400, etc)
            // console.log(data);
        }
    });

}

//Variables para cargar las opciones
var OPTION_DATA_M = [{
    "ID_MODULO_RECEP": "",//id de la opcion
    "MODULO_RECEP_DESC": "",//descripcion
}];

//opcion del tipo de modulo
let OPTION_DATA_Tp = [{
    "ID_ATE_TP_MODULO": "",
    "TP_ATE_MODULO_DESC": ""
}]
//Funciones 

//funcion para la carga de datos de las opciones
function fn_Cargar_Option() {
    AJAX_Dtt = $.ajax({
        "type": "POST",
        "url": "Ingreso_Turnos.aspx/Carga_Option",
        "data": "{}",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {//Retorno estado Success (200)

            OPTION_DATA_M = data.d

            if (OPTION_DATA_M.length > 0) { //Si contiene datos
                console.log(" data del option" + [OPTION_DATA_M]);
                fn_Agregar_Opc();

            } else { //Si no contiene datos
                console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    })
}

//funcion que agregara mas opciones al elemento Select
function fn_Agregar_Opc() {
    for (i = 0; i < OPTION_DATA_M.length; i++) {
        $("<option>").text(OPTION_DATA_M[i].MODULO_RECEP_DESC).val(OPTION_DATA_M[i].ID_MODULO_RECEP).appendTo($("#moduloAtencion"));
    }

}

//funcion para la carga de datos de las opciones de tipo de atencion
function fn_Cargar_Option_Tp() {
    AJAX_Dtt = $.ajax({
        "type": "POST",
        "url": "Ingreso_Turnos.aspx/Carga_Option_Tp",
        "data": "{}",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {//Retorno estado Success (200)

            OPTION_DATA_Tp = data.d

            if (OPTION_DATA_Tp.length > 0) { //Si contiene datos
                console.log(OPTION_DATA_Tp);
                fn_Agregar_Opc_tipo();

            } else { //Si no contiene datos
                console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    })
}

function fn_Agregar_Opc_tipo() {
    for (i = 0; i < OPTION_DATA_Tp.length; i++) {
        $("<option>").text(OPTION_DATA_Tp[i].TP_ATE_MODULO_DESC).val(OPTION_DATA_Tp[i].ID_ATE_TP_MODULO).appendTo($("#tipoAtencion"));
    }

}

let modulo_Data = [{
    "MD_MODULO": "",
    "MD_MODULO_RECEP": "",
    "MD_TIPO_MODULO": "",
    "ID_MODULO_RECEP": ""
}];

//Funcion para mostrar el turno que se encuentra siendo atendido en el modulo
function fn_Mostrar_Turno() {
    
    let ID_MODULO_RECEP = $("#moduloAtencion").val();

    if (ID_MODULO_RECEP != 0) {
        var strParam = JSON.stringify({
            "ID_MODULO_RECEP": ID_MODULO_RECEP
        });

        AJAX_Dtt = $.ajax({
            "type": "POST", //Método GET o POST
            "url": "Ingreso_Turnos.aspx/Visor_Turno_Recep", //Formulario y función del Back End
            "data": strParam, //Parámetros a enviar
            "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
            "dataType": "json", //Tipo de dato "JSON"
            "success": data => { //Retorno estado Success (200)

                modulo_Data = data.d;

                if (modulo_Data.length > 0) { //Si contiene datos

                    console.log("atencion")
                    console.log( modulo_Data);
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
    function fn_update_fecha() {
        //let ID_MODULO_RECEP = modulo_Data[i].MD_MODULO;
        let TIPO_ATENCION = ($('select[id=tipoAtencion]').val());//valor usando para definir el tipo ya sea 1 2 3 4
        for (let i = 0; i < modulo_Data.length; i++) {
            var resep = modulo_Data[i].MD_MODULO

            var parametros = JSON.stringify({
                "LETRA_TURNO": resep,
                "TIPO_ATENCION": TIPO_ATENCION
            })

            $.ajax({
                "type": "POST", //Método GET o POST
                "url": "Ingreso_Turnos.aspx/UPDATE_TIME", //Formulario y función del Back TE LLEVA A ingreso_producto
                "data": parametros, //Parámetros a enviar
                "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
                "dataType": "json", //Tipo de dato "JSON"
                "success": data => { //Retorno estado Success (200)
                    console.log(data);
                },
                "error": data => { // Retorno Error (500, 400, etc)
                    // console.log(data);
                }
            });

        }

        //var parametros = JSON.stringify[{
        //    "LETRA_TURNO": resep,
        //    "TIPO_ATENCION": TIPO_ATENCION
        //}]

        //$.ajax({
        //    "type": "POST", //Método GET o POST
        //    "url": "Ingreso_Turnos.aspx/UPDATE_TIME", //Formulario y función del Back TE LLEVA A ingreso_producto
        //    "data": parametros, //Parámetros a enviar
        //    "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        //    "dataType": "json", //Tipo de dato "JSON"
        //    "success": data => { //Retorno estado Success (200)
        //        console.log(data);
        //    },
        //    "error": data => { // Retorno Error (500, 400, etc)
        //         console.log(data);
        //    }
        //});

    }
    return fn_update_fecha;

}



let Data_impresion = [{
    "LETRA_ATENCION": "",
    "TR_TURNO_NUM": "",
    "TR_ATENCION_TIPO": ""
}];

//Funcion que mostrara el ultimo turno impreso
function fn_Mostrar_Impr() {

    let ID_TIPO = $("#tipoAtencion").val();
    //console.log("fn_Mostrar_Impr");
    if (ID_TIPO != 0) {
        var strParam = JSON.stringify({
            "ID_TIPO": ID_TIPO
        });

        AJAX_Dtt1 = $.ajax({
            "type": "POST", //Método GET o POST
            "url": "Ingreso_Turnos.aspx/Visor_Ultima_Impresion_Tipo", //Formulario y función del Back End
            "data": strParam, //Parámetros a enviar
            "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
            "dataType": "json", //Tipo de dato "JSON"
            "success": data => { //Retorno estado Success (200)

                Data_impresion = data.d;
                //console.log(Data_impresion);
                if (Data_impresion.length > 0) { //Si contiene datos

                    // console.log(Data_impresion);

                    CrearUltImpr();



                } else { //Si no contiene datos
                    console.log(data);
                }
            },
            "error": data => { // Retorno Error (500, 400, etc)
                console.log(data);
            }
        });
    }

    


}


//Funcion para mostrar el turno actual en el modulo
function CrearVista() {

    $("#TurnoVista").empty();
    let ID_MODULO_RECEP_SLT = $("#moduloAtencion").val();

    for (let i = 0; i < modulo_Data.length; i++) {
        if (ID_MODULO_RECEP_SLT == modulo_Data[i].ID_MODULO_RECEP) {
            //div contenedor principal
            $("<div>").css({
                "text-align": "center",
                "width": "100%"
            }).attr({
                "id": "visorInfo" + i + "",
                "class": "visorInfo"
            }).appendTo($("#TurnoVista"));

            //cabezera del div principal
            $("<div>").text("Turno Actual").css({
                "display": "block"
            }).attr({
                "id": "visorInfoHead" + i + "",
                "class": "visorInfoHead"
            }).appendTo($("#visorInfo" + i));

            //Cuerpo del visor
            $("<div>").css({
                "display": "block",
                "text-align": "center"
            }).attr({
                "id": "visorBody" + i
            }).appendTo($("#visorInfo" + i))

            //contenedor visor de la letra y el numero
            $("<div>").attr({ "id": "visorLetNum" + i }).css({
                "display": "block",
                "text-align": "center"
            }).appendTo($("#visorBody" + i));

            //contenedor visor del tipo de atencion
            $("<div>").attr({ "id": "visorTipoMod" + i }).css({
                "display": "block",
                "text-align": "center"
            }).appendTo($("#visorBody" + i));

            //contenedor del visor modulo de recepcion
            $("<div>").attr({ "id": "visorModRec" + i }).css({
                "display": "block",
                "text-align": "center"
            }).appendTo($("#visorBody" + i));

            //vista de la letra y numero de recepcion
            $("<h5>").text("" + modulo_Data[i].MD_MODULO +
                           "" + modulo_Data[i].MD_MODULO_RECEP).
           css({
               "font-size": "1.2rem",
               "font-weight": "600",
               "text-align": "center"
           }).appendTo($("#visorLetNum" + i));

            //SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
            if (modulo_Data[i].MD_TIPO_MODULO == 1) { modulo_Data[i].MD_TIPO_MODULO = "Atención General"; }
            else if (modulo_Data[i].MD_TIPO_MODULO == 2) { modulo_Data[i].MD_TIPO_MODULO = "Atención Empresa"; }
            else if (modulo_Data[i].MD_TIPO_MODULO == 3) { modulo_Data[i].MD_TIPO_MODULO = "Atención de Examenes"; }
            else if (modulo_Data[i].MD_TIPO_MODULO == 4) { modulo_Data[i].MD_TIPO_MODULO = "Atención Pcr"; }

            $("<p>").css({
                "font-size": "1rem",
                "font-weight": "300"
            }).text(modulo_Data[i].MD_TIPO_MODULO).attr(
              "id", "MD_TIPO_MODULO" + i + "").appendTo("#visorTipoMod" + i);

            $("<p>").css({
                "font-size": "1rem",
                "font-weight": "300"
            }).text("Módulo" + " " + modulo_Data[i].ID_MODULO_RECEP).attr(
                "id", "ID_MODULO_RECEP" + i + "").appendTo("#visorModRec" + i);

        }
    }


    //for (i = 0; i < modulo_Data.length; i++) {

    //    $("<table>").css({
    //        "text-align": "center",
    //        "width": "100%"
    //    }).attr({
    //        "id": "tabla" + i + "",
    //        "class": "table"
    //    }).appendTo($("#TurnoVista"))

    //    $("<thead>").text("Turno Actual").css({
    //        "text-align": "center",
    //        "width": "5rem"
    //    }).attr({
    //        "id": "tablaHead" + i + ""
    //    }).appendTo($("#tabla" + i));

    //    $("<tbody>").css({
    //        "display": "block",
    //        "text-align": "center"
    //    }).attr({
    //        "id": "tablaBody" + i
    //    }).appendTo($("#tablaHead" + i))

    //    //iteracion para que numeros menores de 10 se seteen con un = al principio
    //    if (modulo_Data[i].MD_MODULO_RECEP > 0 && modulo_Data[i].MD_MODULO_RECEP < 10) {
    //        modulo_Data[i].MD_MODULO_RECEP = "0" + modulo_Data[i].MD_MODULO_RECEP;
    //    }

    //    $("<tr>").attr("id", "rowBody" + i).css({
    //        "display": "block",
    //        "text-align": "center"
    //    }).appendTo("#tablaBody" + i)

    //    $("<tr>").attr("id", "rowBody2" + i).css({
    //        "display": "block",
    //        "text-align": "center"
    //    }).appendTo("#tablaBody" + i)

    //    $("<tr>").attr("id", "rowBody3" + i).css({
    //        "display": "block",
    //        "text-align": "center"
    //    }).appendTo("#tablaBody" + i)

    //    $("<h5>").css({
    //        "font-size": "1.2rem",
    //        "font-weight": "600"
    //    }).text("" + modulo_Data[i].MD_MODULO + "" + modulo_Data[i].MD_MODULO_RECEP).attr({
    //        "id": "tablaContent" + i
    //    }).appendTo("#rowBody" + i);


    //    //SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
    //    if (modulo_Data[i].MD_TIPO_MODULO == 1) { modulo_Data[i].MD_TIPO_MODULO = "Atención General"; }
    //    else if (modulo_Data[i].MD_TIPO_MODULO == 2) { modulo_Data[i].MD_TIPO_MODULO = "Atención Empresa"; }
    //    else if (modulo_Data[i].MD_TIPO_MODULO == 3) { modulo_Data[i].MD_TIPO_MODULO = "Atención de Examenes"; }
    //    else if (modulo_Data[i].MD_TIPO_MODULO == 4) { modulo_Data[i].MD_TIPO_MODULO = "Atención Pcr"; }

    //    $("<p>").css({
    //        "font-size": "0.8rem",
    //        "font-weight": "300"
    //    }).text(modulo_Data[i].MD_TIPO_MODULO).attr(
    //    "id", "MD_TIPO_MODULO" + i + "").appendTo("#rowBody2" + i);


    //    $("<p>").css({
    //        "font-size": "0.8rem",
    //        "font-weight": "300"
    //    }).text("Módulo" + " " + modulo_Data[i].ID_MODULO_RECEP).attr(
    //    "id", "ID_MODULO_RECEP" + i + "").appendTo("#rowBody3" + i);




    //}
}

//funcion para mostrar la ultima impresion de ticket

function CrearUltImpr() {

    $("#UltimaImpr").empty();

    for (j = 0; j < Data_impresion.length; j++) {

        

        $("<table>").css({
            "text-align": "center",
            "width": "100%"
        }).attr({
            "id": "tabla_Impr" + j + "",
            "class": "table"
        }).appendTo($("#UltimaImpr"))

        $("<thead>").text("Ultima Impresión").css({
            "text-align": "center",
            "width": "5rem"
        }).attr({
            "id": "tablaHead_Impr" + j + ""
        }).appendTo($("#tabla_Impr" + j));

        $("<tbody>").css({
            "display": "block",
            "text-align": "center"
        }).attr({
            "id": "tablaBody_Impr" + j
        }).appendTo($("#tablaHead_Impr" + j))

        // iteracion para que numeros menores de 10 se seteen con un = al principio
        if (Data_impresion[j].TR_TURNO_NUM > 0 && Data_impresion[j].TR_TURNO_NUM < 10) {
            Data_impresion[j].TR_TURNO_NUM = "0" + Data_impresion[j].TR_TURNO_NUM;
        }

        $("<tr>").attr("id", "rowBody_Impr" + j).css({
            "display": "block",
            "text-align": "center"
        }).appendTo("#tablaBody_Impr" + j)

        $("<tr>").attr("id", "rowBody2_Impr" + j).css({
            "display": "block",
            "text-align": "center"
        }).appendTo("#tablaBody_Impr" + j)

        $("<tr>").attr("id", "rowBody3_Impr" + j).css({
            "display": "block",
            "text-align": "center",
            "min-height": "19.2px",
            "margin-bottom":"1rem"
        }).appendTo("#tablaBody_Impr" + j)

        //switch (Data_impresion[j].ID_MODULO_TURNO) {
        //    case 1:
        //        Data_impresion[j].ID_MODULO_TURNO = "A"
        //        break;
        //    case 2:
        //        Data_impresion[j].ID_MODULO_TURNO = "B"
        //        break;
        //    case 3:
        //        Data_impresion[j].ID_MODULO_TURNO = "C"
        //        break;
        //    case 4:
        //        Data_impresion[j].ID_MODULO_TURNO = "D"
        //        break;
        //    case 5:
        //        Data_impresion[j].ID_MODULO_TURNO = "E"
        //        break;
        //    case 6:
        //        Data_impresion[j].ID_MODULO_TURNO = "F"
        //        break;
        //}

        //console.log("" + Data_impresion[j].LETRA_ATENCION + "" + Data_impresion[j].TR_TURNO_NUM);

        $("<h5>").css({
            "font-size": "1.2rem",
            "font-weight": "600"
        }).text("" + Data_impresion[j].LETRA_ATENCION + "" + Data_impresion[j].TR_TURNO_NUM).attr({
            "id": "tablaContent_Impr" + j
        }).appendTo("#rowBody_Impr" + j);

        // SETEAR EL VALOR DE MD-TIPO MODULO PARA QUE MUESTRE EL MODULO AL CUAL CORRESPONDE
        if (Data_impresion[j].TR_ATENCION_TIPO == 1) { Data_impresion[j].TR_ATENCION_TIPO = "Atención General"; }
        else if (Data_impresion[j].TR_ATENCION_TIPO == 2) { Data_impresion[j].TR_ATENCION_TIPO = "Atención Empresa"; }
        else if (Data_impresion[j].TR_ATENCION_TIPO == 3) { Data_impresion[j].TR_ATENCION_TIPO = "Entrega de Examenes"; }
        else if (Data_impresion[j].TR_ATENCION_TIPO == 4) { Data_impresion[j].TR_ATENCION_TIPO = "Examen Pcr"; }



        $("<p>").css({
            "font-size": "0.8rem",
            "font-weight": "300"
        }).text(Data_impresion[j].TR_ATENCION_TIPO).attr(
        "id", "TR_TURNO_TIPO" + j + "").appendTo("#rowBody2_Impr" + j);


        $("<p>").css({
            "font-size": "0.8rem",
            "font-weight": "300"
        }).text("").appendTo("#rowBody3_Impr" + j);
    }

}

//Funcion para actualizar modulos ya creados 





function fn_Siguiente_Turno(Dato_ID, Dato_NUM) {


    let ONLY_DATE = moment().format("DD-MM-YYYY");//se usara para setear el turno despendiendoi de la fecha
    let ID_MODULO_RECEP = ($('select[id=moduloAtencion]').val());//se usara para ingresar el modulo en el cual se atendera el turno
    let TIPO_ATENCION = ($('select[id=tipoAtencion]').val());//valor usando para definir el tipo ya sea 1 2 3 4
    var LETRA_TURNO

    //definir ID_MODULO_TURNO y MD_MODULO_RECEP y LETRA
    switch (Dato_ID) {
        case 1:
             LETRA_TURNO = "A";
            break;
        case 2:
             LETRA_TURNO = "B";
            break;
        case 3:
             LETRA_TURNO = "C";
            break;
        case 4:
             LETRA_TURNO = "D";
            break;
        case 5:
             LETRA_TURNO = "E";
            break;
        case 6:
             LETRA_TURNO = "F";
            break;
    }


    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": Dato_ID,//Se usara para apuntar a que quiero ingresar los datos
        "ID_MODULO_RECEP": ID_MODULO_RECEP,
        "TIPO_ATENCION": TIPO_ATENCION,
        "ONLY_DATE": ONLY_DATE,//enviaremos la fecha para que por PA se hara un reset del contador
        "DATO_NUM": Dato_NUM,//numero de modulo de recepcion
        "LETRA_TURNO":LETRA_TURNO
    })
    console.log(strParam)
    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "Ingreso_Turnos.aspx/Siguiente_Turno", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            fn_Mostrar_Turno();
            console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            // console.log(data);
        }
    });
}

//MODIFICAR PA PARA QUE ME BUSQUE EL ID

let Data_Turno_Menor = [{
    "ID_MODULO_TURNO": "",
    "MD_MODULO_RECEP": ""
}];


function fn_Turno_Menor() {
    //Datos a enviar para la organizacion de mis datos

    let TIPO_MODULO = $("#tipoAtencion").val();

    if (TIPO_MODULO != 0) {
        var Parametro_Busqueda = JSON.stringify({
            "MD_TIPO_MODULO": TIPO_MODULO
        })

        console.log(Parametro_Busqueda);
        $.ajax({
            "type": "POST", //Método GET o POST
            "url": "Ingreso_Turnos.aspx/IRIS_WEBF_TURNO_MENOR", //Formulario y función del Back TE LLEVA A ingreso_producto
            "data": Parametro_Busqueda, //Parámetros a enviar
            "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
            "dataType": "json", //Tipo de dato "JSON"
            "success": data => { //Retorno estado Success (200)

                Data_Turno_Menor = data.d;
                obj_List = Data_Turno_Menor;
                console.log(obj_List);
                let index_Minimo_Turno;

                if (obj_List.length > 0) { //Si contiene datos

                    for (i = 0; i < obj_List.length; i++) {

                        //console.log(obj_List[i].MD_MODULO_RECEP);

                        if (i == 0) {
                            index_Minimo_Turno = i;
                        } else if (obj_List[i].MD_MODULO_RECEP < obj_List[index_Minimo_Turno].MD_MODULO_RECEP) {
                            console.log("Menor: " + i);
                            index_Minimo_Turno = i;
                        }
                    }

                    //if (obj_List[0].MD_MODULO_RECEP <= obj_List[1].MD_MODULO_RECEP && obj_List[0].MD_MODULO_RECEP <= obj_List[2].MD_MODULO_RECEP) {
                    //    console.log(obj_List[0].MD_MODULO);

                    //    Letra_Turno = obj_List[0].MD_MODULO;
                    //}
                    //else if (obj_List[1].MD_MODULO_RECEP <= obj_List[0].MD_MODULO_RECEP && obj_List[1].MD_MODULO_RECEP <= obj_List[2].MD_MODULO_RECEP) {
                    //    console.log(obj_List[1].MD_MODULO);
                    //    Letra_Turno = obj_List[1].MD_MODULO;
                    //}
                    //else if (obj_List[2].MD_MODULO_RECEP <= obj_List[0].MD_MODULO_RECEP && obj_List[2].MD_MODULO_RECEP <= obj_List[1].MD_MODULO_RECEP) {
                    //    console.log(obj_List[2].MD_MODULO);
                    //    Letra_Turno = obj_List[2].MD_MODULO;
                    //}

                    //Pasar ID_MODULO_TURNO
                    console.log(obj_List[index_Minimo_Turno].ID_MODULO_TURNO);
                    fn_Siguiente_Turno(obj_List[index_Minimo_Turno].ID_MODULO_TURNO, (obj_List[index_Minimo_Turno].MD_MODULO_RECEP + 1));

                    //parametro = Letra_Turno

                    //console.log(Data_Turno_Menor);
                    //console.log("letra menor turno " + Letra_Turno)
                    //fn_Siguiente_Turno(Letra_Turno);
                    fn_Mostrar_Turno();
                } else { //Si no contiene datos
                    //console.log(data);
                }

                //console.log(data);

            },
            "error": data => { // Retorno Error (500, 400, etc)
                console.log(data);
            }
        });
    }

   
}




