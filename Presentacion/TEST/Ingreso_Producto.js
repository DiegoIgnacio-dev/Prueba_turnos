$(document).ready(() => {
    $("#enviar").click(() => {
        fn_Insert_Producto();
    });
});
function fn_Insert_Producto() {

    var strParam = JSON.stringify({ //Stringificar parámetros
        "NOMBRE": $("#nombre_producto").val(), //String
        "DESCRIPCION": $("#descripcion_producto").val(), //String
        "PRECIO": $("#precio_producto").val() //Int
    });

    console.log(strParam);
    
    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "Ingreso_Producto.aspx/Crear_Producto", //Formulario y función del Back TE LLEVA A ingreso_producto

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