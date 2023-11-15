$(document).ready(() => { //Función al cargar documento.
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

    $("#btn_Buscar").click(() => { //Evento click para Botón Buscar
        Ajax_Busca_Datos(); //Call a funcíon Busca Datos
    });
});

let Mx_Data = [{

    "ID_PRODUCTO": "",
    "NOMBRE_PRODUCTO": "",
    "DESCRIPCION_PRODUCTO": "",
    "PRECIO_PRODUCTO": "",

}];

function Ajax_Busca_Datos() {

    var strParam = JSON.stringify({ //Stringificar parámetros
        "DESDE": $("#txt_Date01 input").val(),
        "HASTA": $("#txt_Date02 input").val()
    });

    console.log(strParam);

    AJAX_Dtt = $.ajax({
        "type": "POST", //Método GET o POST
        "url": "Test_DW.aspx/Busca_Datos", //Formulario y función del Back End
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)

            Mx_Data = data.d;

            if (Mx_Data.length > 0) { //Si contiene datos

                console.log(Mx_Data);

                Fn_Crea_Tabla();

            } else { //Si no contiene datos
                console.log(data);
            }
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });
}

function Fn_Crea_Tabla() {

    //Limpiamos el contenido del div "Div_Tabla"
    $("#Div_Tabla").empty();


    $("<h3>").text("Tabla Productos").attr("class", "text-center mt-3").appendTo($("#Div_Tabla"));

    //appendTo == Insertar dentro de otro elemento
    //append ==  Insertar dentro del mismo elemento

    //Creamos nuevo elemento <table>, le asignamos los atributos id, cellspacing y class, despues lo adjuntamos dentro del Div con id "Div_Tabla"
    $("<table>").attr({ "id": "DataTable", "cellspacing": "0", "class": "table table-hover table-striped table-iris table-iris" }).appendTo($("#Div_Tabla"));

    //A DataTable le adjuntamos un nuevo thead y tbody
    $("#DataTable").append(
        $("<thead>"),
        $("<tbody>")
    );
    //A thead le adjuntamos un nuevo tr
    $("#DataTable thead").append("<tr>");
    
    //A tr le adjuntamos los th, con el texto descriptivo de la columna
    $("#DataTable thead tr").append(
        $("<th>").text("NOMBRE PRODUCTO"),
        $("<th>").text("DESCRIPCION PRODUCTO"),
        $("<th>").attr("class", "text-right").text("PRECIO_PRODUCTO")
    );

    //Con un ciclo for, recorremos la matriz Mx_Data
    for (i = 0; i < Mx_Data.length; i++) {

        //Por cada indice en la matriz, creamos un tr nuevo y le asignamos al atributo id, el ID_PRODUCTO
        $("<tr>").attr("id", Mx_Data[i].ID_PRODUCTO).append(

            //Adjuntamos al tr, los td y sus respectivos textos 
            $("<td>").text(Mx_Data[i].NOMBRE_PRODUCTO),
            $("<td>").text(Mx_Data[i].DESCRIPCION_PRODUCTO),
            $("<td>").attr("class","text-right").text(Mx_Data[i].PRECIO_PRODUCTO)

            //Finalmente agregamos el tr junto a los td adjuntados, al body de la tabla
        ).appendTo("#DataTable tbody");

    }


    //Una vez creada la tabla, la podemos transformar utilizando la libreria DataTable
    $("#DataTable").DataTable({
        "bSort": false,
        "iDisplayLength": 100,
        "info": false,
        "bPaginate": false,
        "bFilter": true,
        "language": {
            "lengthMenu": "Mostrar: _MENU_",
            "zeroRecords": "No hay coincidencias",
            "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No hay concidencias",
            "infoFiltered": "(Se busco en _MAX_ registros )",
            "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente"
            }
        }
    });
}