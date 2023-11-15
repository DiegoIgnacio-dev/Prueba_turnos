$(document).ready(() => {

    //Crear_Carta_Impr();
    fn_Busca_Tipo_Atencion_Impr();
    //funciones realacionadas a cada boton


    //$("#btn-Empresa").click(() => {
    //    fn_Log_Btn_Multi(5);

    //});
    //$("#btn-Examen").click(() => {
    //    fn_Log_Btn_Multi(3);

    //});
    //$("#btn-PCR").click(() => {
    //    fn_Log_Btn_Multi(4);

    //});

});

let Lst_TP_Impr = [];

function fn_Busca_Tipo_Atencion_Impr() {
    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "M_impresion_modulo.aspx/Busca_TP_Impr", //Formulario y función del Back End
        //"data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            Lst_TP_Impr = data.d;

            if (Lst_TP_Impr.length > 0) { //Si contiene datos

                //console.log( modulo_Data);

                //Fn_Crea_Tabla();
                Crear_Carta_Impr();


            } else { //Si no contiene datos
                console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });
}

function Crear_Carta_Impr() {

    $("#M_Impresion").empty();

    //Cuerpo del panel
    $("<div>").attr({
        "class": "card",
        "id": "PanelPrincipal"
    }).appendTo($("#M_Impresion"));

    //header del panel
    $("<div>").attr({
        "class": "card-header",
        "id": "Panel-header"
    }).text("BIENVENIDOS").css({
        "font-size": "1.6rem"
    }).appendTo
    ($("#PanelPrincipal"));
    //imagen IrisLab lateral

    $("<img>").attr({
        "class": "img-lateral",
        "src": "img/irislab_lateral.svg"
    }).appendTo($("#PanelPrincipal"));

    //Body del panel
    $("<div>").attr({
        "class": "card-body",
        "id": "body-panel"
    }).appendTo($("#PanelPrincipal"));

    //seccion de la carta
    $("<div>").attr({
        "id": "vistaTicket"
    }).appendTo($("#body-panel"));

    //Estructura del panel
    $("<div>").attr({
        "class": "row",
        "id": "panel"
    }).appendTo
    ($("#body-panel"));

    //descripcion de los botones
    $("<div>").text("Seleccione Su Atención").attr
        ("class", "col").css({
            "font-size":"1.6rem"
        }).appendTo($("#panel"));

    $("<div>").attr({
        "class": "container"
    }).appendTo($("#body-panel"))
    //seccion de botones
    $("<div>").attr({
        "class": "row",
        "id": "contenedor-btn"
    }).appendTo($(".container"));
    //Container del grupo de botones
    Lst_TP_Impr.forEach(item => {

        $("<div>").text("" + item.TP_ATE_MODULO_DESC + "").attr({
            "class": "card-body btn-Print-Div",
            "name": "btn-Print",
            "data-id": item.ID_ATE_TP_MODULO
        }).css({
            "background-image": "url('img/" + item.TP_ATE_IMG + ".svg')",
            "text-align": "center",
            "padding-top": "150px",
            "margin":"5px 5px",
            "color": "white",
            "font-weight": "600",
            "text-transform":"uppercase"
        }).appendTo($("#contenedor-btn"));

        //$("<div>").attr({
        //    "class": "card-footer",
        //}).text("" + item.TP_ATE_MODULO_DESC + "").css({
        //    "text-align":"center"
        //}).appendTo($(".btn-Print-Div"))
    });

    ////CLick
    $("div[name='btn-Print']").click((e) => {
        console.log("click");
        let _ID = $(e.currentTarget).attr("data-id");
        fn_Log_Btn_Multi(_ID);
    });
};


function fn_Log_Btn_Multi(btn_tipo) {




    Data_Par = JSON.stringify([
        parseInt(btn_tipo)
    ]);
    // console.log(StrParam);

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
            console.log(data);
        }
    });


}

