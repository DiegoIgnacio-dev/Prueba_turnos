﻿let arr_CAT = [];
let arr_MAX = [];
let arr_NOW = [];
let arr_MIN = [];
let labels = [];
let labels_TXT = [];
let labels_Plot = [];
let T_Examen;
let objGraph;
let v_CB, v_B, v_3, v_A, v_CA, r_Min, r_Max;
let c_R_Alto = 0, c_R_Bajo = 0, c_RR_Alto = 0, c_RR_Bajo = 0, v_R_Alto, v_R_Bajo, v_Prom = 0;
let int_refresh;
let INTERVAL;
let INTERVALCD;
let totalTiempo;
let push_CB = ""; push_B = ""; push_A = ""; push_CA = "";
let Prev_INT = "", Prev_MAQ = "", Prev_CAN = "", Prev_DESDE = "", Prev_HASTA = "";
let Cant_Divs = 0;
let ID_Row = 0;
let Prev_Row;
let Prev_ID_ROW;
let Mx_CF_PRU = [];
let Mx_Chk_Box = [];
$(document).ready(() => {

    $("#Btn_Interval").prop("disabled", true);
    $("#Btn_Reload").prop("disabled", true);

    $("#chk_Ref").prop('checked', true);
    $("#chk_Cri").prop('checked', true);

    $("#Btn_Reload").on("click", function () {
        console.log("CLICK RELOAD");
        if ($("#Txt_Interval").val() >= 5 && $("#Txt_Interval").val() <= 60) {
            console.log("15 - 60");
            int_refresh = $("#Txt_Interval").val() * 1000;
            if ($("#Btn_Interval").find("i").is(".fa-pause")) {
                console.log("RELOAD");
                Llenar_Data();

                clearInterval(INTERVAL);
                clearInterval(INTERVALCD);
                INTERVAL = setInterval(Llenar_Data, int_refresh);

                totalTiempo = $("#Txt_Interval").val();
                updateReloj();
            }
        }
    });

    $("#Btn_Interval").on("click", function () {
        if ($("#Txt_Interval").val() >= 5 && $("#Txt_Interval").val() <= 60) {
            //ajax bd
            int_refresh = $("#Txt_Interval").val() * 1000;
            $(this).toggleClass("btn-success btn-danger");
            $(this).find("i").toggleClass("fa-play fa-pause");
            if ($(this).find("i").is(".fa-pause")) {

                totalTiempo = $("#Txt_Interval").val();

                clearInterval(INTERVAL);

                INTERVAL = setInterval(Llenar_Data, int_refresh);
                updateReloj();
            } else {

                clearInterval(INTERVAL);
                clearInterval(INTERVALCD);
            }
        }
        else {

        }
    });


    $("#Txt_VC_BAJO").val("");
    $("#Txt_VC_ALTO").val("");
    $("#Txt_V_BAJO").val("");
    $("#Txt_V_ALTO").val("");

    var dateNow = moment().format("DD/MM/YYYY");
    //var dateNow = "30/07/2020";
    $("#Txt_Date01 input,#Txt_Date02 input").val(dateNow);

    $('#Txt_Date01, #Txt_Date02').datetimepicker(
        {
            debug: true,
            icons: {
                previous: 'fa fa-arrow-left',
                next: 'fa fa-arrow-right'
            },
            format: 'dd/mm/yyyy',
            language: 'es',
            weekStart: 1,
            autoclose: true,
            minDate: Date.now(),
            minView: 2
        }
    );

    Llenar_Ddl_Int();

    $("#slt_Int").change(() => {
        Llenar_Ddl_Maq();
    });

    $("#slt_Maq").change(() => {
        Llenar_Ddl_Det();
    });

    $("#slt_Det").change(() => {
        $("#Txt_VC_BAJO").val("");
        $("#Txt_V_BAJO").val("");
        $("#Txt_VC_ALTO").val("");
        $("#Txt_V_ALTO").val("");
        T_Examen = $("#slt_Det option:selected").text();
        Llenar_Data();
    });

    $("#fecha, #fecha2").change(() => {
        T_Examen = $("#slt_Det option:selected").text();
        Llenar_Data();
    });
    $("#txt_Agr").val("1");
    $("#txt_Agr").on('keypress', function (e) {
        if (e.which == 13) {
            console.log("Agrupar");
            if (arr_NOW.length > 0) {
                Agrupar();
            }
        }

    });

    $("#Txt_Interval").val(5);

    $("#chk_Ref").click(() => {
        if ($("#chk_Ref").is(':checked')) {
            $("#Txt_V_BAJO").attr("disabled", false);
            $("#Txt_V_ALTO").attr("disabled", false);
        } else {
            $("#Txt_V_BAJO").attr("disabled", true);
            $("#Txt_V_ALTO").attr("disabled", true);
        }
        if (arr_NOW.length > 0) {
            Agrupar();
        }
    });

    $("#chk_Cri").click(() => {
        if ($("#chk_Cri").is(':checked')) {
            $("#Txt_VC_BAJO").attr("disabled", false);
            $("#Txt_VC_ALTO").attr("disabled", false);
        } else {
            $("#Txt_VC_BAJO").attr("disabled", true);
            $("#Txt_VC_ALTO").attr("disabled", true);
        }
        if (arr_NOW.length > 0) {
            Agrupar();
        }
    });
});


function updateReloj() {
    document.getElementById('CuentaAtras').innerHTML = totalTiempo;

    if (totalTiempo == 0) {
        if (int_refresh >= 15 && int_refresh <= 60) {
            totalTiempo = int_refresh;
            updateReloj();
        }
        else {
            totalTiempo = int_refresh / 1000;
            updateReloj();
        }


    }
    else {
        /* Restamos un segundo al tiempo restante */
        totalTiempo -= 1;
        /* Ejecutamos nuevamente la función al pasar 1000 milisegundos (1 segundo) */
        INTERVALCD = setTimeout("updateReloj()", 1000);
    }


}

// INTERFAZ

var Mx_Ddl_Int = [{
    "IRIS_LNK_I_ID": "",
    "IRIS_LNK_I_DESCRIPCION": ""
}];

function Llenar_Ddl_Int() {
    $.ajax({
        "type": "POST",
        "url": "Medias_Moviles.aspx/Llenar_Ddl_Int",
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": data => {
            Mx_Ddl_Int = data.d;
            Fill_Ddl_Int();
        },
        "error": data => {
        }
    });
}

function Fill_Ddl_Int() {
    Mx_Ddl_Int.forEach(aaa => {
        $("<option>",
            {
                "value": aaa.IRIS_LNK_I_ID
            }
        ).text(aaa.IRIS_LNK_I_DESCRIPCION).appendTo("#slt_Int");
    });
    $("#slt_Int").trigger('change');
}

// MAQUINA

var Mx_Ddl_Maq = [{
    "IRIS_LNK_MAQ_ID": "",
    "IRIS_LNK_MAQ_DESCRIPCION": ""
}];

function Llenar_Ddl_Maq() {

    let Data_Param = JSON.stringify({
        "IRIS_LNK_I_ID": $("#slt_Int").val()
    });

    $.ajax({
        "type": "POST",
        "url": "Medias_Moviles.aspx/Llenar_Ddl_Maq",
        "contentType": "application/json;  charset=utf-8",
        "data": Data_Param,
        "dataType": "json",
        "success": data => {
            Mx_Ddl_Maq = data.d;

            if (Mx_Ddl_Maq != null) {
                Fill_Ddl_Maq();
            } else {
                $("#slt_Maq").empty();
                $("#slt_Det").empty();
            }
            
        },
        "error": data => {
            $("#slt_Maq").empty();
            $("#slt_Det").empty();
        }
    });
}

function Fill_Ddl_Maq() {

    $("#slt_Maq").empty();

    Mx_Ddl_Maq.forEach(aaa => {
        $("<option>",
            {
                "value": aaa.IRIS_LNK_MAQ_ID
            }
        ).text(aaa.IRIS_LNK_MAQ_DESCRIPCION).appendTo("#slt_Maq");
    });
    $("#slt_Maq").trigger('change');
}

// DETERMINACION

var Mx_Ddl_Det = [{
    "REL_CM_CANAL_DESC": "",
    "REL_CM_DETER_DESC": ""
}];

function Llenar_Ddl_Det() {

    let Data_Param = JSON.stringify({
        "IRIS_LNK_MAQ_ID": $("#slt_Maq").val(),
        "IRIS_LNK_I_ID": $("#slt_Int").val()
    });

    $.ajax({
        "type": "POST",
        "url": "Medias_Moviles.aspx/Llenar_Ddl_Det",
        "contentType": "application/json;  charset=utf-8",
        "data": Data_Param,
        "dataType": "json",
        "success": data => {
            Mx_Ddl_Det = data.d;
            if (Mx_Ddl_Det != null) {
                Fill_Ddl_Det();
            } else {
                $("#slt_Det").empty();
            }
        },
        "error": data => {
            $("#slt_Det").empty();
        }
    });
}

function Fill_Ddl_Det() {
    //let det_Anterior = "";
    $("#slt_Det").empty();

    Mx_Ddl_Det.forEach(aaa => {

        //if (det_Anterior != aaa.IRIS_LNK_DET_DESCRIPCION) {
        $("<option>",
        {
            "value": aaa.REL_CM_CANAL_DESC
        }
    ).text(aaa.REL_CM_DETER_DESC).appendTo("#slt_Det");
        //det_Anterior = aaa.IRIS_LNK_DET_DESCRIPCION;
        //}
    });
    $("#slt_Det").trigger('change');
}

// DATA BUSQUEDA

var Mx_Data = [{
    "ATE_RESULTADO": "",
    "ATE_RESULTADO_NUM": "",
    "ATE_R_DESDE": "",
    "ATE_R_HASTA": "",
    "ATE_RR_DESDE": "",
    "ATE_RR_HASTA": "",
    "ATE_NUM": "",
    "ID_CODIGO_FONASA": "",
    "CF_DESC": "",
    "ID_PRUEBA": "",
    "PRU_DESC": ""
}];

function Llenar_Data() {
    console.log("llenar DTT");
    //let ID_PRUEBAS = [];

    //Mx_Ddl_Det.forEach(aah=> {

    //    if (aah.IRIS_LNK_DET_DESCRIPCION == $("#slt_Det option:selected").text()) {
    //        ID_PRUEBAS.push(aah.ID_PRUEBA);
    //    }
    //});

    if ($("#slt_Det").val() != "" && $("#slt_Det").val() != null) {
        let Data_Param = JSON.stringify({
            "DESDE": $("#fecha").val(),
            "HASTA": $("#fecha2").val(),
            "IRIS_LNK_I_ID": $("#slt_Int").val(),
            "IRIS_LNK_MAQ_ID": $("#slt_Maq").val(),
            "CANAL": $("#slt_Det").val()
        });

        $.ajax({
            "type": "POST",
            "url": "Medias_Moviles.aspx/Llenar_Data",
            "contentType": "application/json;  charset=utf-8",
            "data": Data_Param,
            "dataType": "json",
            "success": data => {
                Mx_Data = data.d;
                //console.log(Mx_Data);
                if (Mx_Data != null) {
                    Fill_Data();
                } else {
                    $("#divGraph").empty();
                    $("#divGraph").html("<div class='alert alert-info'>Esperando Resultados</div>");
                    $("#Txt_VC_BAJO").val("");
                    $("#Txt_VC_ALTO").val("");
                    $("#Txt_V_BAJO").val("");
                    $("#Txt_V_ALTO").val("");
                    $("#chk_CF_PRU").empty();
                    Prev_Row = 0;;
                    Prev_ID_ROW ="";
                    Mx_CF_PRU = [];
                    Mx_Chk_Box = [];
                }
            },
            "error": data => {
                $("#divGraph").empty();
                $("#divGraph").html("<div class='alert alert-info'>Esperando Resultados</div>");
                $("#Txt_VC_BAJO").val("");
                $("#Txt_VC_ALTO").val("");
                $("#Txt_V_BAJO").val("");
                $("#Txt_V_ALTO").val("");
                $("#chk_CF_PRU").empty();
            }
        });
    }
}


function Fill_Data() {

    //console.log(Mx_Data);

    arr_NOW = [];
    c_R_Alto = 0; c_R_Bajo = 0; c_RR_Alto = 0; c_RR_Bajo = 0;
    let i = 1;
    v_CB = ""; v_B = ""; v_3 = ""; v_A = ""; v_CA = ""; r_Min = ""; r_Max = "";


    //  INICIO CHECKBOX CF PRU

    let sw_Actualiza_Chk; // SI ES LA MISMA BUSQUEDA O ES OTRA
    let cnt_CF_PRU = 0;

    if ((Prev_INT == "" && Prev_MAQ == "" && Prev_CAN == "" && Prev_DESDE == "" && Prev_HASTA == "") || (Prev_INT != $("#slt_Int").val() || Prev_MAQ != $("#slt_Maq").val() || Prev_CAN != $("#slt_Det").val() || Prev_DESDE != $("#fecha").val() || Prev_HASTA != $("#fecha2").val())) {

        Prev_INT = $("#slt_Int").val();
        Prev_MAQ = $("#slt_Maq").val();
        Prev_CAN = $("#slt_Det").val();
        Prev_DESDE = $("#fecha").val();
        Prev_HASTA = $("#fecha2").val();

        console.log("PD " + Prev_DESDE + " PH " + Prev_HASTA + " D " + $("#fecha").val() + " H " + $("#fecha2").val());

        console.log("SW 1");

        sw_Actualiza_Chk = 1;
    } else {
        console.log("PD " + Prev_DESDE + " PH " + Prev_HASTA + " D " + $("#fecha").val() + " H " + $("#fecha2").val());
        console.log("SW 0");

        sw_Actualiza_Chk = 0;
    }

    if (sw_Actualiza_Chk == 1) {
        Mx_CF_PRU = [];
        // AGREGA TODOS LOS CHECKS 
        $("#chk_CF_PRU").empty();
        console.log("EMPTY");
        Mx_Data.forEach(eeh=> {
            if (Mx_CF_PRU.length > 0) {

                Mx_CF_PRU.forEach(iih=> {
                    if (eeh.ID_CODIGO_FONASA == iih.ID_CODIGO_FONASA && eeh.ID_PRUEBA == iih.ID_PRUEBA) {
                        cnt_CF_PRU = 1
                    }
                });

                if (cnt_CF_PRU == 0) {
                    Mx_CF_PRU.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
                    //Mx_Chk_Box.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
                }

                cnt_CF_PRU = 0;
            } else {
                Mx_CF_PRU.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
                //Mx_Chk_Box.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
            }

        });

        console.log(Mx_CF_PRU);

        let CF_PRU_lenght = Mx_CF_PRU.length;

        let Cant_Rows = (CF_PRU_lenght / 3);

        console.log(CF_PRU_lenght);

        if (Cant_Rows < 1) {
            Cant_Rows = 1;
        } else if (Cant_Rows > 1 && Cant_Rows < 2) {
            Cant_Rows = 2;
        } else if (Cant_Rows > 2 && Cant_Rows < 3) {
            Cant_Rows = 3;
        } else if (Cant_Rows > 3 && Cant_Rows < 4) {
            Cant_Rows = 4;
        }

        console.log("CANT Rows: " + Cant_Rows);

        Prev_Row = Cant_Rows;

        Cant_Divs = 0;
        ID_Row = 0;

        for (i = 0; i < Cant_Rows; i++) {
            $("#chk_CF_PRU").append("<div class='row' id='row_" + i + "' class='mb-1'></div>");
            Prev_ID_ROW = i;
        }

        Mx_CF_PRU.forEach(aah=> {

            Cant_Divs += 1;

            if (Cant_Divs > 3) {
                ID_Row += 1;
                Cant_Divs = 1;
            }


            let chk_text = "";
            chk_text += "<div class='col-lg-4'><div class='form-check ml-1'>";
            chk_text += "<input type='checkbox' id='chk_CFPRU_" + aah.ID_CODIGO_FONASA + "_" + aah.ID_PRUEBA + "' checked='checked' class='mr-1' name='chk_clk_CFPRU'/>";
            chk_text += "<label class='form-check-label pl-0' for='chk_CFPRU_" + aah.ID_CODIGO_FONASA + "_" + aah.ID_PRUEBA + "'><span style='color:#d60096'>" + aah.CF_DESC + "</span> | <span style='color:#0079d6'>" + aah.PRU_DESC.substr(0, 20) + "</span></label>";
            chk_text += "</div></div>";

            //console.log(chk_text);
            $("#row_" + ID_Row).append(chk_text);
        });

    } else {
        // AGREGA SOLO LOS CHECKS NUEVOS
        let cnt_New = 0;
        Mx_Chk_Box = [];
        Mx_Data.forEach(eeh=> {
            if (Mx_Chk_Box.length > 0) {

                Mx_Chk_Box.forEach(iih=> {
                    if (eeh.ID_CODIGO_FONASA == iih.ID_CODIGO_FONASA && eeh.ID_PRUEBA == iih.ID_PRUEBA) {
                        cnt_New = 1
                    }
                });

                if (cnt_New == 0) {
                    Mx_Chk_Box.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
                }

                cnt_New = 0;
            } else {
                Mx_Chk_Box.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
            }

        });


        // INICIO QUITAR CHECKS QUE NO ESTÉN

        //console.log(Mx_Chk_Box);
        //console.log(Mx_CF_PRU);
        //let spl = [];
        //for (i = 0; i <= Mx_CF_PRU.length - 1; i++) {
        //    let cnt = 0;
        //    Mx_Chk_Box.forEach(xs=> {
        //        console.log(Mx_CF_PRU[i].ID_CODIGO_FONASA + " " + xs.ID_CODIGO_FONASA + " " + Mx_CF_PRU[i].ID_PRUEBA + " " + xs.ID_PRUEBA);
        //        if (Mx_CF_PRU[i].ID_CODIGO_FONASA == xs.ID_CODIGO_FONASA && Mx_CF_PRU[i].ID_PRUEBA == xs.ID_PRUEBA) {
        //            cnt = 1;
        //        }
        //    });
        //    console.group("DIVS");
        //    console.log(Mx_CF_PRU[i].CF_DESC);
        //    if (cnt == 0) {
        //        $("#chk_CFPRU_" + Mx_CF_PRU[i].ID_CODIGO_FONASA + "_" + Mx_CF_PRU[i].ID_PRUEBA).parent().parent().remove();
        //        console.log("Borrar: #chk_CFPRU_" + Mx_CF_PRU[i].ID_CODIGO_FONASA + "_" + Mx_CF_PRU[i].ID_PRUEBA);
        //        spl.push({ "ID_CODIGO_FONASA": Mx_CF_PRU[i].ID_CODIGO_FONASA, "ID_PRUEBA": Mx_CF_PRU[i].ID_PRUEBA });
        //        console.log("CANT DIVSSSSSS " + Cant_Divs);
        //        if (Cant_Divs <= 3 && Cant_Divs >= 1) {
        //            console.log("Cant_Divs Antes " + Cant_Divs);
        //            Cant_Divs -= 1;
        //            console.log("Cant_Divs Despues " + Cant_Divs);
        //        } else if (Cant_Divs == 0) {
        //            console.log("Cant_Divs Antes " + Cant_Divs);
        //            Cant_Divs = 2;
        //            console.log("Cant_Divs Despues " + Cant_Divs);
        //            Prev_ID_ROW -= 1;
        //            ID_Row -= 1;
        //        }
        //    }
        //    console.groupEnd();
        //    cnt = 0;
        //}
        //console.log(spl);
        //console.log("ROW ID: " + Prev_ID_ROW);
        //spl.forEach((x) => {
        //    index = Mx_CF_PRU.findIndex(a => a.ID_CODIGO_FONASA === x.ID_CODIGO_FONASA && a.ID_PRUEBA === x.ID_PRUEBA);
        //    console.log("INDEX " + Mx_CF_PRU[index].CF_DESC + " " + Mx_CF_PRU[index].PRU_DESC);
        //    Mx_CF_PRU.splice(index, 1);
        //});

        //console.group("MX_CF_PRU");
        //console.log("MX_CF_PRU LENGHT DESPUES DE BORRAR " + Mx_CF_PRU.length);
        //Mx_CF_PRU.forEach(XXX=> {
        //    console.log(XXX.CF_DESC+" "+XXX.PRU_DESC);
        //});
        //console.groupEnd();
        //FIN QUITAR CHECKS QUE NO ESTÉN

        console.log("Agregar Check Nuevos");
        //console.log(Mx_Data);
        Mx_Data.forEach(eeh=> {
            if (Mx_CF_PRU.length > 0) {
                Mx_CF_PRU.forEach(iih=> {
                    //console.log("EXISTNTES ID_CODIGO_FONASA " + iih.ID_CODIGO_FONASA + " CF_DESC " + iih.CF_DESC + " ID_PRUEBA " + iih.ID_PRUEBA + " PRU_DESC " + iih.PRU_DESC);
                    if (eeh.ID_CODIGO_FONASA == iih.ID_CODIGO_FONASA && eeh.ID_PRUEBA == iih.ID_PRUEBA) {
                        cnt_CF_PRU = 1;
                    }
                });
                if (cnt_CF_PRU == 0) {
                    Mx_CF_PRU.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "CF_DESC": eeh.CF_DESC, "ID_PRUEBA": eeh.ID_PRUEBA, "PRU_DESC": eeh.PRU_DESC });
                    //console.log("ID_CODIGO_FONASA " + eeh.ID_CODIGO_FONASA + " CF_DESC " + eeh.CF_DESC + " ID_PRUEBA " + eeh.ID_PRUEBA + " PRU_DESC " + eeh.PRU_DESC);
                    //console.log(Mx_CF_PRU);


                    let CF_PRU_lenght = Mx_CF_PRU.length;

                    //console.log("LENGHT: " + CF_PRU_lenght);

                    let Cant_Rows = (CF_PRU_lenght / 3);


                    if (Cant_Rows < 1) {
                        Cant_Rows = 1;
                    } else if (Cant_Rows > 1 && Cant_Rows < 2) {
                        Cant_Rows = 2;
                    } else if (Cant_Rows > 2 && Cant_Rows < 3) {
                        Cant_Rows = 3;
                    } else if (Cant_Rows > 3 && Cant_Rows < 4) {
                        Cant_Rows = 4;
                    }

                    console.log("DIF ROWS ANTES " + Cant_Rows + " - " + Prev_Row);
                    if (Cant_Rows > Prev_Row) {
                        Cant_Rows = Prev_Row + 1;
                    }

                    console.log("DIF ROWS " + Cant_Rows + " - " + Prev_Row);

                    let Dif_Row = Cant_Rows - Prev_Row;

                    //console.log("DIFERENCIA: " + Dif_Row);

                    if (Dif_Row > 0) {
                        for (i = 0; i < Dif_Row; i++) {

                            console.log("PREV PREV ROW: " + Prev_ID_ROW);

                            Prev_ID_ROW += 1;

                            console.log("POST PREV ROW: " + Prev_ID_ROW);
                            $("#chk_CF_PRU").append("<div class='row' id='row_" + Prev_ID_ROW + "' class='mb-1'></div>");
                        }
                    }

                    Prev_Row = Cant_Rows;

                    Cant_Divs += 1;

                    console.log("CANT DIVS " + Cant_Divs);

                    if (Cant_Divs > 3) {

                        console.log("PREV ROW: " + ID_Row);

                        ID_Row += 1;
                        Prev_ID_ROW += 1;

                        console.log("POST ROW: " + ID_Row);
                        Cant_Divs = 1;
                    }

                    let chk_text = "";
                    chk_text += "<div class='col-lg-4'><div class='form-check ml-1'>";
                    chk_text += "<input type='checkbox' id='chk_CFPRU_" + eeh.ID_CODIGO_FONASA + "_" + eeh.ID_PRUEBA + "' checked='checked' class='mr-1' name='chk_clk_CFPRU'/>";
                    chk_text += "<label class='form-check-label pl-0' for='chk_CFPRU_" + eeh.ID_CODIGO_FONASA + "_" + eeh.ID_PRUEBA + "'><span style='color:#d60096'>" + eeh.CF_DESC + "</span> | <span style='color:#0079d6'>" + eeh.PRU_DESC.substr(0, 20) + "</span></label>";
                    chk_text += "</div></div>";

                    //console.log(chk_text);
                    $("#row_" + ID_Row).append(chk_text);
                }
                cnt_CF_PRU = 0;
            }
        });
    }



    //  FIN CHECKBOX CF PRU

    let Mx_ID_CHK_ACTIVOS = [];

    Mx_CF_PRU.forEach(eeh=> {
        if ($("#chk_CFPRU_" + eeh.ID_CODIGO_FONASA + "_" + eeh.ID_PRUEBA).is(':checked') == true) {
            Mx_ID_CHK_ACTIVOS.push({ "ID_CODIGO_FONASA": eeh.ID_CODIGO_FONASA, "ID_PRUEBA": eeh.ID_PRUEBA });
        }
    });

    //console.group("CHK ACTIVOS")
    console.log(Mx_Data);
    console.log(Mx_ID_CHK_ACTIVOS);
    //console.groupEnd();

    Mx_Data.forEach(aah=> {
        // INICIO FILTRO POR CHECK

        Mx_ID_CHK_ACTIVOS.forEach(xxh=> {

            if (aah.ID_CODIGO_FONASA == xxh.ID_CODIGO_FONASA && aah.ID_PRUEBA == xxh.ID_PRUEBA) {

                // FIN FILTRO POR CHECK
                aah.ATE_RESULTADO = aah.ATE_RESULTADO.replace(",", ".");
                let x_Resultado = parseFloat(aah.ATE_RESULTADO);
                //NOW
                if (isNaN(x_Resultado) == false && x_Resultado != 0) {
                    v_Prom += x_Resultado;
                    arr_NOW.push(x_Resultado);
                    arr_CAT.push(i);
                    r_Min = arr_NOW[0].ATE_RESULTADO;
                    r_Max = arr_NOW[0].ATE_RESULTADO;
                    i++;
                } else if (isNaN(aah.ATE_RESULTADO_NUM) == false && aah.ATE_RESULTADO_NUM != 0) {
                    v_Prom += aah.ATE_RESULTADO_NUM;
                    arr_NOW.push(aah.ATE_RESULTADO_NUM);
                    arr_CAT.push(i);
                    i++;
                }
                //ALTO
                aah.ATE_R_HASTA = $.trim(aah.ATE_R_HASTA);
                if (c_R_Alto == 0 && aah.ATE_R_HASTA != null && $.trim(aah.ATE_R_HASTA) != "") {
                    v_A = parseFloat(aah.ATE_R_HASTA.replace(",", "."));
                    if (isNaN(v_A) == false) {
                        c_R_Alto = 1;
                    }
                }
                //BAJO
                aah.ATE_R_DESDE = $.trim(aah.ATE_R_DESDE);
                if (c_R_Bajo == 0 && aah.ATE_R_DESDE != null && $.trim(aah.ATE_R_DESDE) != "") {
                    v_B = parseFloat(aah.ATE_R_DESDE.replace(",", "."));
                    if (isNaN(v_B) == false) {
                        c_R_Bajo = 1;
                    }
                }
                //CRITICO ALTO
                aah.ATE_RR_HASTA = $.trim(aah.ATE_RR_HASTA);
                if (c_RR_Alto == 0 && aah.ATE_RR_HASTA != null && $.trim(aah.ATE_RR_HASTA) != "") {
                    v_CA = parseFloat(aah.ATE_RR_HASTA.replace(",", "."));
                    if (isNaN(v_CA) == false) {
                        c_RR_Alto = 1;
                    }
                }

                //CRITICO BAJO
                aah.ATE_RR_DESDE = $.trim(aah.ATE_RR_DESDE);
                if (c_RR_Bajo == 0 && aah.ATE_RR_DESDE != null && aah.ATE_RR_DESDE != "") {
                    v_CB = parseFloat(aah.ATE_RR_DESDE.replace(",", "."));
                    if (isNaN(v_CB) == false) {
                        c_RR_Bajo = 1;
                    }
                }
            }
        });
    });
    if ($("#Btn_Interval").find("i").is(".fa-play")) {
        $("#Btn_Interval").click();
    }
    $("input[name='chk_clk_CFPRU']").off("change");
    $("input[name='chk_clk_CFPRU']").change(() => {
        Fill_Data();
    });
    Agrupar();
}
function Agrupar() {
    labels = [];
    labels_TXT = [];
    labels_Plot = [];
    let agr_NOW = [];
    let agr_CAT = [];
    let v_agr_NOW = 0;
    let v_agr_CAT = 0;
    let ct_NOW = 0;
    let ct_CAT = 0;
    push_B = ""; push_A = "", push_CB = ""; push_CA = "";


    let v_txt_Agr = $("#txt_Agr").val();

    if (v_txt_Agr == "") {
        v_txt_Agr = 1;
        $("#txt_Agr").val("1");
    }

    if (v_txt_Agr >= 1 && v_txt_Agr != "") {

        for (i = 0; i < arr_NOW.length; i++) {

            ct_NOW += 1;

            if (i == arr_NOW.length - 1 && ct_NOW < v_txt_Agr) {
                v_agr_NOW += arr_NOW[i];
                console.log("ultimo: " + v_agr_NOW + " / " + ct_NOW);
                v_agr_NOW = v_agr_NOW / ct_NOW

                agr_NOW.push(parseFloat(v_agr_NOW.toFixed(2)));

                ct_CAT += 1;
                agr_CAT.push(ct_CAT);

                ct_NOW = 0;
                v_agr_NOW = 0;
            } else {
                if (ct_NOW == v_txt_Agr) {
                    v_agr_NOW += arr_NOW[i];

                    v_agr_NOW = v_agr_NOW / v_txt_Agr

                    agr_NOW.push(parseFloat(v_agr_NOW.toFixed(2)));

                    ct_CAT += 1;
                    agr_CAT.push(ct_CAT);

                    ct_NOW = 0;
                    v_agr_NOW = 0;
                } else {
                    v_agr_NOW += arr_NOW[i];
                }
            }
        }
    }


    /// MIN Y MAX
    r_Min = agr_NOW[0];
    r_Max = agr_NOW[0];
    agr_NOW.forEach(aah=> {
        if (r_Min > aah) {
            r_Min = aah;
        }
        if (r_Max < aah) {
            r_Max = aah;
        }
    });

    ///

    //console.log("Min: " + r_Min);
    //console.log("Max: " + r_Max);


    if (isNaN(v_3) == true) {
        v_3 = v_Prom;
    }

    let txt_crit_b = $("#Txt_VC_BAJO").val();
    txt_crit_b = parseFloat(txt_crit_b.replace(",", "."));
    //console.log(txt_crit_b);
    //console.log(c_RR_Bajo + " " + c_R_Bajo + " " + c_R_Alto + " " + c_RR_Alto);


    //TIENE VALOR CRITICO
    //if ($("#chk_Cri").is(':checked') == true) {
    //CRITICO BAJO
    if (c_RR_Bajo == 1 && $("#chk_Cri").is(':checked') == true) {
        //SI EL VALOR CRITICO ES DISTINTO AL TEXT Y ES UN NUMERO
        if (txt_crit_b != v_CB && isNaN(txt_crit_b) == false) {
            //if (r_Min < txt_crit_b) {
            labels_TXT.push("");
            labels_Plot.push(r_Min);
            //}
            push_CB = txt_crit_b;
            labels_Plot.push(txt_crit_b);
            //VALOR CRITICO X BD
        } else {
            //if (r_Min < v_CB) {
            labels_TXT.push("");
            labels_Plot.push(r_Min);
            //}
            labels_Plot.push(v_CB);
            $("#Txt_VC_BAJO").val(v_CB);
            push_CB = v_CB;
        }
        labels.push(v_CB);
        labels_TXT.push("(CB)");
        //SI NO TIENE VALOR CRITICO Y NO TIENE VALOR TEXTO
    } else if (c_RR_Bajo == 0 && isNaN(txt_crit_b) == true && $("#chk_Cri").is(':checked') == true) {

        labels_TXT.push("");
        labels.push(r_Min);
        push_CB = "";
        labels_Plot.push(r_Min);

        //SI NO TIENE VALOR CRITICO PERO TIENE VALOR TEXTO
    } else if ($("#chk_Cri").is(':checked') == true) {
        //if (r_Min < txt_crit_b) {
        labels_Plot.push(r_Min);
        labels_TXT.push("");
        //}
        labels_Plot.push(txt_crit_b);
        labels_TXT.push("(CB)");
        labels.push(r_Min);
        push_CB = txt_crit_b;
    }



    //}


    //BAJO
    let txt_b = $("#Txt_V_BAJO").val();
    txt_b = parseFloat(txt_b.replace(",", "."));
    if (c_R_Bajo == 1) {
        console.log("B1");
        if (txt_b != v_B && isNaN(txt_b) == false) {
            if (r_Min < txt_b && $("#chk_Cri").is(':checked') == false) {
                console.log("CHK 1");
                labels_TXT.push("");
                labels_Plot.push(r_Min);
            }
            push_B = txt_b;
            labels_Plot.push(txt_b);
            console.log("B1.1");
        }
        else {
            if ($("#chk_Cri").is(':checked') == false) {
                console.log("CHK 2");
                labels_TXT.push("");
                labels_Plot.push(r_Min);
            }
            console.log("B1.2");
            $("#Txt_V_BAJO").val(v_B);
            push_B = v_B;
            labels_Plot.push(v_B);
        }
        labels_TXT.push("(B)");
        labels.push(v_B);

    } else if (c_R_Bajo == 0 && isNaN(txt_b) == true && $("#chk_Cri").is(':checked') == false) {
        console.log("B2");
        console.log("Min Bajo");
        labels_TXT.push("");
        labels.push(r_Min);
        push_B = "";
        labels_Plot.push(r_Min);
    } else if (c_R_Bajo == 0 && isNaN(txt_b) == false) {
        console.log("B3");
        if (r_Min < txt_b && $("#chk_Cri").is(':checked') == false) {
            console.log("CHK 3");
            labels_TXT.push("");
            labels_Plot.push(r_Min);
        }

        labels_Plot.push(txt_b);
        labels_TXT.push("(B)");
        labels.push(r_Min);
        push_B = txt_b;
    }
    //ALTO
    let txt_a = $("#Txt_V_ALTO").val();
    txt_a = parseFloat(txt_a.replace(",", "."));
    if (c_R_Alto == 1) {
        if (txt_a != v_A && isNaN(txt_a) == false) {
            push_A = txt_a;
            labels_Plot.push(txt_a);
            labels_TXT.push("(A)");
            labels.push(v_A);

            if (r_Max > v_A && $("#chk_Cri").is(':checked') == false) {
                labels_TXT.push("");
                labels_Plot.push(r_Max);
            }
        } else {
            $("#Txt_V_ALTO").val(v_A);
            push_A = v_A;
            labels_Plot.push(v_A);
            labels_TXT.push("(A)");
            labels.push(v_A);

            if ($("#chk_Cri").is(':checked') == false) {
                labels_TXT.push("");
                labels_Plot.push(r_Max);
            }
        }
    } else if (c_R_Alto == 0 && isNaN(txt_a) == true && $("#chk_Cri").is(':checked') == false) {
        console.log("Max Alto");
        labels_TXT.push("");
        labels.push(r_Max);
        push_A = "";
        labels_Plot.push(r_Max);
    }
    else if (c_R_Alto == 0 && isNaN(txt_a) == false) {
        labels_Plot.push(txt_a);
        labels_TXT.push("(A)");
        labels.push(r_Max);
        push_A = txt_a;

        if (r_Max > txt_a && $("#chk_Cri").is(':checked') == false) {
            labels_TXT.push("");
            labels_Plot.push(r_Max);
        }
    }
    if ($("#chk_Cri").is(':checked') == true) {
        //CRITICO ALTO
        let txt_crit_a = $("#Txt_VC_ALTO").val();
        txt_crit_a = parseFloat(txt_crit_a.replace(",", "."));
        //TIENE VALOR CRITICO
        if (c_RR_Alto == 1) {
            //SI EL VALOR CRITICO ES DISTINTO AL TEXT Y ES UN NUMERO
            if (txt_crit_a != v_CA && isNaN(txt_crit_a) == false) {
                push_CA = txt_crit_a;
                labels_Plot.push(txt_crit_a);
                //VALOR CRITICO X BD
            } else {
                //if (r_Max > v_CA) {
                labels_TXT.push("");
                labels_Plot.push(r_Max);
                //}
                labels_Plot.push(v_CA);
                $("#Txt_VC_ALTO").val(v_CA);
                push_CA = v_CA;
                console.log(push_CA);
            }
            labels.push(v_CA);
            labels_TXT.push("(CA)");

            //if (r_Max > txt_crit_a) {
            labels_TXT.push("");
            labels_Plot.push(r_Max);
            //}

            //SI NO TIENE VALOR CRITICO Y NO TIENE VALOR TEXTO
        } else if (c_RR_Alto == 0 && isNaN(txt_crit_a) == true) {
            labels_TXT.push("");
            labels.push(r_Max);
            push_CA = "";
            labels_Plot.push(r_Max);
            //SI NO TIENE VALOR CRITICO PERO TIENE VALOR TEXTO
        } else if (c_RR_Alto == 0 && isNaN(txt_crit_a) == false) {
            labels_Plot.push(txt_crit_a);
            labels_TXT.push("(CA)");
            labels.push(r_Max);
            push_CA = txt_crit_a;

            //if (r_Max > txt_crit_a) {
            labels_Plot.push(r_Max);
            labels_TXT.push("");
            //}
        }
    }


    //if ($("#chk_Cri").is(':checked') == false) {
    //    console.log("splice");
    //    push_CA = "";
    //    push_CB = "";

    //    for (let ii = 0; ii < labels_TXT.length; ii++) {
    //        if (labels_TXT[ii] == "(CB)" || labels_TXT[ii] == "(CA)") {
    //            console.log("VAL CRIT " + labels_TXT[ii]);
    //            console.log(ii);
    //            labels_TXT.splice(ii, 1);
    //            labels_Plot.splice(ii, 1);
    //            //labels.splice(ii, 1);
    //        }
    //    }
    //}

    if ($("#chk_Cri").is(':checked') == false && $("#chk_Ref").is(':checked') == false) {
        push_CA = "";
        push_CB = "";
        push_A = "";
        push_B = "";
        labels_TXT = ["", ""];
        labels_Plot = [r_Min, r_Max];
    }

    //console.log(labels_Plot);

    //if ($("#chk_Ref").is(':checked') == true && (($("#chk_Cri").is(':checked') == true && $("#Txt_VC_BAJO").val() == "" && $("#Txt_VC_ALTO").val() == "") || ($("#chk_Cri").is(':checked') == false))) {
    //    console.log("Ordenar Solo Ref");
    //    let R_A, R_B, Dif;
    //    //Bajo;
    //    if ($("#Txt_V_BAJO").val() != "") {
    //        if (labels_Plot[0] <= labels_Plot[1]) {
    //            R_B = (labels_Plot[1] - labels_Plot[0]);
    //        } else {
    //            R_B = (labels_Plot[0] - labels_Plot[1]);
    //        }
    //    }
    //    //Alto
    //    if ($("#Txt_V_ALTO").val() != "") {
    //        if (labels_Plot[3] >= labels_Plot[2]) {
    //            R_A = (labels_Plot[3] - labels_Plot[2]);
    //        } else {
    //            R_A = (labels_Plot[2] - labels_Plot[3]);
    //        }
    //    }
    //    if (R_A >= R_B) {
    //        Dif = R_A - R_B;
    //    } else {
    //        Dif = R_B - R_A;
    //    }
    //    //Bajo;
    //    if ($("#Txt_V_BAJO").val() != "") {
    //        if (labels_Plot[0] <= labels_Plot[1]) {
    //            labels_Plot[0] = labels_Plot[0] - Dif;
    //        } else {
    //            labels_Plot[0] = labels_Plot[1] - Dif;
    //        }
    //    }
    //    //Alto
    //    if ($("#Txt_V_ALTO").val() != "") {
    //        if (labels_Plot[3] >= labels_Plot[2]) {
    //            labels_Plot[3] = labels_Plot[3] + Dif;
    //        } else {
    //            labels_Plot[3] = labels_Plot[2] + Dif;
    //        }
    //    }
    //}


    let R_A = "", R_B = "", Dif = "";

    if (labels_TXT[1] == "(CB)" || labels_TXT[1] == "(B)") {
        if (labels_Plot[0] <= labels_Plot[1]) {
            R_B = (labels_Plot[1] - labels_Plot[0]);
        } else {
            R_B = (labels_Plot[0] - labels_Plot[1]);
        }
    }
    if (labels_TXT[labels_TXT.length - 2] == "(CA)" || labels_TXT[labels_TXT.length - 2] == "(A)") {
        if (labels_Plot[labels_Plot.length - 2] <= labels_Plot[labels_Plot.length - 1]) {
            R_A = (labels_Plot[labels_Plot.length - 1] - labels_Plot[labels_Plot.length - 2]);
        } else {
            R_A = (labels_Plot[labels_Plot.length - 2] - labels_Plot[labels_Plot.length - 1]);
        }
    }

    if (R_A >= R_B) {
        Dif = R_A - R_B;
    } else {
        Dif = R_B - R_A;
    }

    console.log("DIF: " + Dif + " R_B: " + R_B + " R_A: " + R_A);

    if (Dif != "") {
        console.log("DIF Y R_B");
        if (labels_Plot[0] <= labels_Plot[1]) {
            labels_Plot[0] = (labels_Plot[0] - Dif);
        } else {
            labels_Plot[0] = (labels_Plot[1] - Dif);
        }
    }
    if (Dif != "") {
        console.log("DIF Y R_A");
        if (labels_Plot[labels_Plot.length - 2] <= labels_Plot[labels_Plot.length - 1]) {
            labels_Plot[labels_Plot.length - 1] = (labels_Plot[labels_Plot.length - 1] + Dif);
        } else {
            labels_Plot[labels_Plot.length - 1] = (labels_Plot[labels_Plot.length - 2] + Dif);
        }
    }


    //PLOT LINES

    let P_Lines = [];

    labels_TXT.forEach(txt => {

        if (txt == "(CB)" && $("#chk_Cri").is(':checked') == true) {
            P_Lines.push({
                color: '#FF0000',
                width: 3,
                value: push_CB
            });
        } else if (txt == "(B)" && $("#chk_Ref").is(':checked') == true) {
            P_Lines.push({
                color: '#ecf022',
                width: 2,
                value: push_B,
                dashStyle: "shortdash"
            });
        } else if (txt == "(A)" && $("#chk_Ref").is(':checked') == true) {
            P_Lines.push({
                color: '#ecf022',
                width: 2,
                value: push_A,
                dashStyle: "shortdash"
            });
        } else if (txt == "(CA)" && $("#chk_Cri").is(':checked') == true) {
            P_Lines.push({
                color: '#FF0000',
                width: 3,
                value: push_CA
            });
        }
    });

    //console.log(P_Lines);

    //console.group("Params");
    //console.log(labels_TXT);
    //console.log(labels);
    //console.log(labels_Plot);
    //console.log("CB: " + push_CB + " B: " + push_B + " A: " + push_A + " CA: " + push_CA);
    //console.log(agr_CAT);
    console.groupEnd();

    buildGraph();

    //let XX = 0;

    objGraph.update({
        chart: {
            animation: false
        },
        yAxis: {
            title: {
                text: ""
            },
            tickPositioner: function () {
                //console.log(labels_Plot);
                return labels_Plot;
            },
            labels: {
                formatter: function () {
                    //console.log(i);
                    if (this.isFirst) {
                        //console.log("IS FIRST");
                        i = -1;
                        //XX = 1;
                    }

                    i++;
                    //console.log(i);
                    //console.log(labels_TXT);
                    //console.log(labels_TXT[i] + " " + i);
                    if (labels_TXT[i] == "") {
                        //console.log("RET VACIO");
                        return "";
                    } else {
                        //console.log("RET " + this.value + " " + labels_TXT[i]);
                        return this.value + " " + labels_TXT[i];
                    }
                }
            }
            ,
            plotLines: P_Lines
        },
        xAxis: {
            categories: agr_CAT
        },
        series: [
            {
                name: "Resultado",
                data: agr_NOW,
                showInLegend: false,
                color: '#0587eb',
                marker: {
                    radius: 5
                }
            }
        ]
    });
    $("#Btn_Interval").removeAttr("disabled");
    $("#Btn_Reload").removeAttr("disabled");
}

// GRAFICO
function buildGraph() {
    $("#divGraph").empty();
    objGraph = Highcharts.chart("divGraph", {
        chart: {
            animation: false
        },
        plotOptions: {
            series: {
                line: {
                    dataLabels: {
                        enabled: true
                    }
                },
                enableMouseTracking: true,
                animation: false
            }
        },
        legend: {
            align: "right",
            verticalAlign: "middle",
            layout: "vertical"
        },
        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: "horizontal",
                        align: "center",
                        verticalAlign: "bottom"
                    }
                }
            }]
        },
        title: {
            text: T_Examen
        },
        series: [
            {
                name: "Resultado",
                data: []
            }
            //,{
            //    name: "Valor Alto",
            //    data: []
            //},
            //{
            //    name: "Valor Bajo",
            //    data: []
            //},
            //{
            //    name: "Valor Crítico Alto",
            //    data: []
            //},
            //{
            //    name: "Valor Crítico Bajo",
            //    data: []
            //}
        ]
    });
}