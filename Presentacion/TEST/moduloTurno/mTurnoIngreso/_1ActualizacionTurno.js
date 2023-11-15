$(document).ready(() => {

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

function MostrarConfig() {
    $("#config").css("display", "none");
    $("#config_btn").text("Cerrar Configuracion");
        if($("#config").click){
            $("#config").css("display","block");
        } 
}
function OcultarConfig() {
    $("#config").css("display", "none");
    $("#config_btn").text("Abrir Configuracion");
    if ($("#config").dblclick) {
        $("#config").css("display", "none");
    }
}

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
            ID_TURNO =3
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
function fn_reset(){
    var dateNow = moment().format("DD-MM-YYYY");
    //console.log(dateNow);
}
