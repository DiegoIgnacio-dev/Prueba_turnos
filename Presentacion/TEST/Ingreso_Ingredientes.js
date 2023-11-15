$(document).ready(function () {
    $("#enviar").click(function () {
        fn_Ingreso_Ingredientes();
    })
})

function fn_Ingreso_Ingredientes() {

    var strParam = JSON.stringify({
        "CODIGO": $("#codigo_ingredientes").val(),
        "DESCRIPCION": $("#descripcion_ingredientes").val(),
        "UNIDAD": $("#unidad_medida_ingredientes").val(),
        "CANTIDAD": $("#cantidad_ingredientes").val(),
        "FECHAVENCE": $("#fecha_vencimiento_ingredientes").val()

    })
    //   console.log(strParam)

    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "Ingreso_Ingredientes.aspx/Crear_Ingredientes", //Formulario y función del Back TE LLEVA A ingreso_producto

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