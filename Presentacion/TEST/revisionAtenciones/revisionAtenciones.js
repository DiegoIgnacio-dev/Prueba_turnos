

$(document).ready(() => {

    var dateNow = moment().format("DD-MM-YYYY"); //Libreria Moment para fechas, capturar fecha actual del PC.
    $("#txt_Date01 input, #txt_Date02 input").val(dateNow); //Selector de elemento input para asignar valor.

    $("#txt_Date01, #txt_Date02").datetimepicker({ //Libreria DateTimePicker, para convertir elementos en calendario.
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
    });
    Fn_Buscar_Datos();
    //usamos el boton con id #btn_Buscar para ejecutar la funcion que me trera los datos desde el back 
    $("#btn_Buscar").click(() => {
        Fn_Buscar_Datos();
    });
})
//VARIABLES
let data_Turnos = [{
    "FECHA": "",
    "NUM_TUR": ""
}]
function Fn_Buscar_Datos() {
    let now = moment().format('DD/MM/YYYY');
    //console.log(now)

    let parametros = JSON.stringify({ //Stringificar parámetros
        "DESDE": $("#txt_Date01 input").val(), //parametros de fecha paradefinir un minimo y un maximo       
        "HASTA": $("#txt_Date02 input").val()
    });
    //console.log(parametros);

    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "revisionAtenciones.aspx/BUSCA_DATA_ATENCIONES", //Formulario y función del Back End
        "data": parametros, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            data_Turnos = data.d;

            if (data_Turnos.length > 0) { //Si contiene datos

                //console.log(data_Turnos);
                //logica para trabajar con las fechas
                //suma de fechas totales
                let dias = 0;
                let hoy = 0;
                for (let i = 0; i < data_Turnos.length; i++) {
                    // console.log(data_Turnos[i])
                     dias += data_Turnos[i].NUM_TUR
                     if (data_Turnos[i].FECHA == now) {
                         hoy += data_Turnos[i].NUM_TUR
                         //console.log("hoy:" + hoy);
                     }
                }


                grafico(data_Turnos)

                fn_agregar_datos(dias,hoy);
                //console.log(`Atenciones totales : ${dias}`);


               

            } else { //Si no contiene datos
                console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });



    
}

function fn_agregar_datos(conteo,hoy) {
    $("#conteo").empty();// limpiamos el elemento en el DOM
    $("#hoy").empty();// limpiamos el elemento en el DOM

    $("#conteo").append($("<p>").text(conteo))
    $("#hoy").append($("<p>").text(hoy))
}

function grafico(data_Turnos) {

    
    let arrDataLine=data_Turnos
    var grafico = 0;
    if (grafico == 0) {
        var arrPar = [];
        var arrVal = [];
        for (i = 0; i < arrDataLine.length; i++) {
            arrVal.push(arrDataLine[i].NUM_TUR);
            arrPar.push(arrDataLine[i].FECHA);
           
        }

        Highcharts.chart('Summary_Graph', {
            chart: {
                type: 'line'
            },
            title: {
                text: ''
            },
            subtitle: {
                text: ''
            },
            xAxis: {
                categories: arrPar
            },
            yAxis: {
                title: {
                    text: 'Atenciones'
                }
            },
            plotOptions: {
                line: {
                    dataLabels: {
                        enabled: true
                    },
                    enableMouseTracking: true
                }
            },
            series: [{
                name: 'Total Atenciones',
                data: arrVal
            }]
        });
    };
};


//LA ESTRUCTURA DE LA CONFIGURACION DEL GRAFICO ESTA EN LA DOCUMENTACION https://www.highcharts.com/docs/index
//TODO ES PARAMETRIZABLE USANDO BIEN LAS PROPIEDADES DEL OBJETO QUE SE DEFINE COMO "objHC"

//FUNCION CREA GRAFICO CON LIBRERIA HIGHCHARTS
function Build(id, title, options) {
    let base = $(`#${id}`);
    base.empty();
    Highcharts.chart(id, options);
}


