/// <reference path="../scripts/typings/moment/numeral.d.ts" />
/// <reference path="../js/webform.ts" />
var CONVENIO;
(function (CONVENIO) {
    //--Declaraciones Objetos------------------------------------------------------------------------------------------
    let Txt_Date01 = new WEBFORM.class_Input("Txt_Date01");
    let Txt_Date02 = new WEBFORM.class_Input("Txt_Date02");
    let Sel_Prev = new WEBFORM.class_Select("Sel_Prev");
    let Btn_Search = new WEBFORM.class_Button("Btn_Search");
    let Btn_Export = new WEBFORM.class_Button("Btn_Export");
    let objTable_01 = new WEBFORM.class_Table("objTable_01", `Realice una búsqueda por rango de <strong>Fechas</strong> y <strong>Previsión.</strong>`);
    let objTable_02 = new WEBFORM.class_Table("objTable_02", "idle");
    //--Declaraciones AJAX---------------------------------------------------------------------------------------------
    let objAJAX_Sel_Prev = new TOOL.class_AJAX("Convenio.aspx/JSON_Prev_Call", (resp) => {
        let arrData = [];
        arrData = resp.d;
        Sel_Prev.cleanAll();
        Sel_Prev.insertElem("Todos", 0);
        arrData.forEach((xItem) => {
            Sel_Prev.insertElem(xItem.PREVE_DESC, xItem.ID_PREVE);
        });
        Hide_Modal();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Data = new TOOL.class_AJAX("Convenio.aspx/JSON_Data_Call", (resp) => {
        let arrData = [];
        arrData = resp.d;
        objTable_01.isClickeable = false;
        objTable_01.isDataTable = true;
        objTable_02.isClickeable = false;
        objTable_02.isDataTable = false;
        objTable_01.cleanTable();
        objTable_01.addTHead("", "right");
        objTable_01.addTHead("Cod. Fonasa", "left");
        objTable_01.addTHead("Decripción", "left");
        objTable_01.addTHead("Cantidad", "right");
        objTable_01.addTHead("Valor Unit.", "right");
        objTable_01.addTHead("Valor Pac.", "right");
        objTable_01.addTHead("Costo Deriv.", "right");
        objTable_01.addTHead("Total Costos", "right");
        objTable_01.addTHead("Diferencial", "right");
        objTable_01.addTHead("% Centro Méd.", "right");
        objTable_01.addTHead("% Laboratorio", "right");
        let arrTotal = [0, 0, 0, 0, 0, 0];
        arrData.forEach((xItem, xIndex) => {
            objTable_01.addRow(xIndex, [
                (function () {
                    let strNum = `${xIndex + 1}`;
                    let lnLast = `${arrData.length}`;
                    while (strNum.length < lnLast.length) {
                        strNum = `0${strNum}`;
                    }
                    return strNum;
                }()),
                xItem.CF_COD,
                xItem.CF_DESC,
                numeral(xItem.CANTIDAD).format(`0,0`).replace(/,/gi, "."),
                `$ ${numeral(xItem.CF_PRECIO_AMB).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(xItem.COSTO_AMB).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(xItem.COSTO_DERIV).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(xItem.COSTO_TOTAL).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(xItem.COSTO_AMB - xItem.COSTO_TOTAL).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(function () {
                    let numRes = xItem.COSTO_AMB - xItem.COSTO_TOTAL;
                    numRes *= xItem.PJE_CONV * 0.01;
                    return numRes;
                }()).format(`0,0`).replace(/,/gi, ".")} - ${xItem.PJE_CONV}%`,
                `$ ${numeral(function () {
                    let numRes = xItem.COSTO_AMB - xItem.COSTO_TOTAL;
                    numRes *= xItem.PJE_LAB * 0.01;
                    return numRes;
                }()).format(`0,0`).replace(/,/gi, ".")} - ${xItem.PJE_LAB}%`
            ]);
            //Totales
            arrTotal[0] += xItem.COSTO_AMB;
            arrTotal[1] += xItem.COSTO_DERIV;
            arrTotal[2] += xItem.COSTO_TOTAL;
            arrTotal[3] += xItem.COSTO_AMB - xItem.COSTO_TOTAL;
            arrTotal[4] += (xItem.COSTO_AMB - xItem.COSTO_TOTAL) * xItem.PJE_CONV * 0.01;
            arrTotal[5] += (xItem.COSTO_AMB - xItem.COSTO_TOTAL) * xItem.PJE_LAB * 0.01;
        });
        objTable_01.updateTable("No se han encontrado valores asociados a los parámetros de búsqueda indicados.");
        objTable_02.cleanTable();
        if (arrData.length > 1) {
            objTable_02.addTHead("Valor Pac.", "right");
            objTable_02.addTHead("Costo Deriv.", "right");
            objTable_02.addTHead("Total Costos", "right");
            objTable_02.addTHead("Diferencial", "right");
            objTable_02.addTHead("% Centro Méd.", "right");
            objTable_02.addTHead("% Laboratorio", "right");
            objTable_02.addRow(0, [
                `$ ${numeral(arrTotal[0]).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(arrTotal[1]).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(arrTotal[2]).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(arrTotal[3]).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(arrTotal[4]).format(`0,0`).replace(/,/gi, ".")}`,
                `$ ${numeral(arrTotal[5]).format(`0,0`).replace(/,/gi, ".")}`
            ]);
            objTable_02.updateTable("");
            $("#objTable_02").parent().fadeIn(250);
        }
        else {
            $("#objTable_02").parent().fadeOut(250);
        }
        Hide_Modal();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Excel = new TOOL.class_AJAX("Convenio.aspx/Gen_Xls", (resp) => {
        let xURL;
        xURL = resp.d;
        if (xURL != null) {
            if (xURL.match(/^http(s?):\/\//gi) == null) {
                xURL = "http://" + xURL;
            }
            var xMsg = `<p>Se ha generado correctamente el archivo excel. `;
            xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
            $("#mdlExcel .modal-body").html(xMsg);
            window.open(xURL, "_blank");
        }
        else {
            var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
            xMsg += `búsqueda no retorna resultados.</p>`;
            $("#mdlExcel .modal-body").html(xMsg);
        }
        $("#mdlExcel").modal();
        Hide_Modal();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    //-----------------------------------------------------------------------------------------------------------------
    //--Declaraciones de Eventos---------------------------------------------------------------------------------------
    Btn_Search.click((Me) => {
        modal_show();
        objAJAX_Sel_Data.requestNow({
            ID_PREV: Sel_Prev.getValue().value,
            DATE_str01: Txt_Date01.getValue(),
            DATE_str02: Txt_Date02.getValue()
        });
    });
    Btn_Export.click((Me) => {
        modal_show();
        objAJAX_Sel_Excel.requestNow({
            ID_PREV: Sel_Prev.getValue().value,
            DATE_str01: Txt_Date01.getValue(),
            DATE_str02: Txt_Date02.getValue()
        });
    });
    //-----------------------------------------------------------------------------------------------------------------
    //--Funciones de carga---------------------------------------------------------------------------------------------
    $(document).ready(() => {
        let arrTxt = [
            `Txt_Date01`,
            `Txt_Date02`
        ];
        arrTxt.forEach((xItem) => {
            $(`#${xItem}`).val(`${moment().format("DD/MM/YYYY")}`);
            $(`#${xItem}`).parent().datetimepicker({
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
            });
        });
        modal_show();
        $("#objTable_02").parent().hide();
        objAJAX_Sel_Prev.requestNow();
    });
})(CONVENIO || (CONVENIO = {}));
//# sourceMappingURL=Convenio.js.map