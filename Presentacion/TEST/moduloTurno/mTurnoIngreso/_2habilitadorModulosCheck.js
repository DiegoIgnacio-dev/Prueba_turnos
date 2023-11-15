
//Funcion para desabilitar opciones de modulo
$(document).ready(() => {

    $("#updateCheck").click(() => {
        fn_Update_Check();
    });

    //SE GUARDA EL ESTADO DE LOS CHECKBOX DE FORMA LOCAL 
    checkbox1 = document.getElementById('inlineCheckbox1')
    checkbox1.checked = eval(window.localStorage.getItem(checkbox1.id))

    checkbox1.addEventListener('change', function () {
        window.localStorage.setItem(checkbox1.id, checkbox1.checked)
    })

    checkbox2 = document.getElementById('inlineCheckbox2')
    checkbox2.checked = eval(window.localStorage.getItem(checkbox2.id))

    checkbox2.addEventListener('change', function () {
        window.localStorage.setItem(checkbox2.id, checkbox2.checked)
    })

    checkbox3 = document.getElementById('inlineCheckbox3')
    checkbox3.checked = eval(window.localStorage.getItem(checkbox3.id))

    checkbox3.addEventListener('change', function () {
        window.localStorage.setItem(checkbox3.id, checkbox3.checked)
    })

    checkbox4 = document.getElementById('inlineCheckbox4')
    checkbox4.checked = eval(window.localStorage.getItem(checkbox4.id))

    checkbox4.addEventListener('change', function () {
        window.localStorage.setItem(checkbox4.id, checkbox4.checked)
    })

    checkbox5 = document.getElementById('inlineCheckbox5')
    checkbox5.checked = eval(window.localStorage.getItem(checkbox5.id))

    checkbox5.addEventListener('change', function () {
        window.localStorage.setItem(checkbox5.id, checkbox5.checked)
    })

    checkbox6 = document.getElementById('inlineCheckbox6')
    checkbox6.checked = eval(window.localStorage.getItem(checkbox6.id))

    checkbox6.addEventListener('change', function () {
        window.localStorage.setItem(checkbox6.id, checkbox6.checked)
    })


    //HERRAMIENTA PARA DESAHBILITAR MODULOS EN EL LADO DEL CLIENTE

    //MD_MODULO =A###############################
    var Update_Option = function () {
        if ($("#inlineCheckbox1").is(":checked")) {
            $("#OpA").prop('disabled', false);
        }
        else {
            $("#OpA").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox1").change(Update_Option);

    //MD_MODULO =B                   ################################
    var Update_Option = function () {
        if ($("#inlineCheckbox2").is(":checked")) {
            $("#OpB").prop('disabled', false);
        }
        else {
            $("#OpB").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox2").change(Update_Option);


    //MD_MODULO =C                  ################################
    var Update_Option = function () {
        if ($("#inlineCheckbox3").is(":checked")) {
            $("#OpC").prop('disabled', false);
        }
        else {
            $("#OpC").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox3").change(Update_Option);

    //MD_MODULO =D            #####################################

    var Update_Option = function () {
        if ($("#inlineCheckbox4").is(":checked")) {
            $("#OpD").prop('disabled', false);
        }
        else {
            $("#OpD").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox4").change(Update_Option);

    //MD_MODULO =E       ###################################

    var Update_Option = function () {
        if ($("#inlineCheckbox5").is(":checked")) {
            $("#OpE").prop('disabled', false);
        }
        else {
            $("#OpE").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox5").change(Update_Option);

    //MD_MODULO =F       ###################################

    var Update_Option = function () {
        if ($("#inlineCheckbox6").is(":checked")) {
            $("#OpF").prop('disabled', false);
        }
        else {
            $("#OpF").prop('disabled', 'disabled');
        }
    };
    $(Update_Option);
    $("#inlineCheckbox6").change(Update_Option);



});

function fn_Update_Check() {

    var dateNow = moment().format("DD-MM-YYYY");
    var MD_FECHA = dateNow
    
    //Condicion A ############################################
    if ($("#inlineCheckbox1").is(":checked")) {
        var ID_MODULO_TURNO = 1;
        var ID_ESTADO = 1

    } else {
        var ID_MODULO_TURNO = 1;
        var ID_ESTADO = 2
    }

    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA":MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    console.log(strParam);

    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
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

    //Condicion 2###############################################
    if ($("#inlineCheckbox2").is(":checked")) {
        var ID_MODULO_TURNO = 2;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 2;
        var ID_ESTADO = 2
    }

    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA":MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    //console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            //console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

    //Condicion 3###############################################
    if ($("#inlineCheckbox3").is(":checked")) {
        var ID_MODULO_TURNO = 3;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 3;
        var ID_ESTADO = 2
    }

    

    
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA":MD_FECHA,
        "ID_ESTADO": ID_ESTADO,
    })

    console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
           // console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });


    //Condicion 4###############################################

    if ($("#inlineCheckbox4").is(":checked")) {
        var ID_MODULO_TURNO = 4;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 4;
        var ID_ESTADO = 2
    }
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA":MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
            //console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });


    //Condicion 5###############################################

    if ($("#inlineCheckbox5").is(":checked")) {
        var ID_MODULO_TURNO = 5;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 5;
        var ID_ESTADO = 2
    }
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
        "data": strParam, //Parámetros a enviar
        "contentType": "application/json;  charset=utf-8", //Tipo de Consulta y Codificación
        "dataType": "json", //Tipo de dato "JSON"
        "success": data => { //Retorno estado Success (200)
           // console.log(data);
        },
        "error": data => { // Retorno Error (500, 400, etc)
            console.log(data);
        }
    });

    //Condicion 6###############################################

    if ($("#inlineCheckbox6").is(":checked")) {
        var ID_MODULO_TURNO = 6;
        var ID_ESTADO = 1
    } else {
        var ID_MODULO_TURNO = 6;
        var ID_ESTADO = 2
    }
    var strParam = JSON.stringify({
        "ID_MODULO_TURNO": ID_MODULO_TURNO,
        "MD_FECHA": MD_FECHA,
        "ID_ESTADO": ID_ESTADO
    })

    //console.log(strParam);


    $.ajax({
        "type": "POST", //Método GET o POST
        "url": "turnoIngreso1.aspx/Update_Check", //Formulario y función del Back TE LLEVA A ingreso_producto
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




