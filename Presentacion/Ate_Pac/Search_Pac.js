var SEARCH_PAC;
(function (SEARCH_PAC) {
    var MODAL;
    (function (MODAL) {
        MODAL.show = () => {
            modal_show();
        };
        MODAL.hide = () => {
            Hide_Modal();
        };
    })(MODAL || (MODAL = {}));
    //Declaraciones genéricas
    let fnError = (fail) => {
        MODAL.hide();
        $("#mdlError").modal("show");
        try {
            console.log(`[FAIL] - ERROR:`);
            console.log(`         Tipo: ${fail.responseJSON.ExceptionType}`);
            console.log(`         Detalle: ${fail.responseJSON.Message}`);
            console.log(`         Seguimiento: ${fail.responseJSON.StackTrace}\n\n`);
        }
        catch (err) {
            console.log(fail);
        }
    };
    let arrPac = [];
    let arrAte = [];
    //Declaraciones Webform
    let divTablePac = new H.Ts_Table("divTablePac");
    let divTableAte = new H.Ts_Table("divTableAte");
    let divTableDet = new H.Ts_Table("divTableDet");
    let btnSearch1 = new H.Ts_Button("btnSearch1");
    let btnSearch2 = new H.Ts_Button("btnSearch2");
    let btnClean = new H.Ts_Button("btnClean");
    let txtRUT = new H.Ts_Textbox("txtRUT");
    let txtDNI = new H.Ts_Textbox("txtDNI");
    let txtName = new H.Ts_Textbox("txtName");
    let txtlastN = new H.Ts_Textbox("txtlastN");
    let txtNAte = new H.Ts_Textbox("txtNAte");
    let txtDetNAte = new H.Ts_Textbox("txtDetNAte");
    let txtDetFecha = new H.Ts_Textbox("txtDetFecha");
    let txtDetProc = new H.Ts_Textbox("txtDetProc");
    let txtDetPrev = new H.Ts_Textbox("txtDetPrev");
    let txtDetPac = new H.Ts_Textbox("txtDetPac");
    let txtDetDoc = new H.Ts_Textbox("txtDetDoc");
    txtDetNAte.locked = true;
    txtDetFecha.locked = true;
    txtDetProc.locked = true;
    txtDetPrev.locked = true;
    txtDetPac.locked = true;
    txtDetDoc.locked = true;
    divTablePac.isSelectable = true;
    divTablePac.setDataTable(true, 10);
    divTablePac.msgInit = `Por favor realice una búsqueda.`;
    divTablePac.eventClick = () => {
        ajaxAte_ID_PAC.requestNow({
            ID_PAC: arrPac[divTablePac.value].ID_PAC
        });
    };
    divTableAte.isSelectable = true;
    divTableAte.setDataTable(true, 10);
    divTableAte.msgInit = `Por favor realice una búsqueda.`;
    divTableAte.eventClick = () => {
        txtDetNAte.value = arrAte[divTableAte.value].ATE_NUM;
        txtDetFecha.value = moment(arrAte[divTableAte.value]).format("DD/MM/YYYY");
        txtDetProc.value = arrAte[divTableAte.value].PROC_DESC;
        txtDetPrev.value = arrAte[divTableAte.value].PREV_DESC;
        txtDetPac.value = arrAte[divTableAte.value].PAC_NAME;
        txtDetDoc.value = arrAte[divTableAte.value].DOC_NAME;
        $("#lnkGoto").attr({ href: `/Buscar_Ate/Atencion_Det.aspx?ID_ATE=${arrAte[divTableAte.value].ID_ENCRYPT}` });
        $("#mdlDet").modal();
        ajaxDet.requestNow({
            ID_ATE: arrAte[divTableAte.value].ID_ATE
        });
    };
    //Declaraciones AJAX
    let ajaxPac = new U.Ajax();
    ajaxPac.functName = "GET_Pacientes";
    ajaxPac.error = fnError;
    ajaxPac.success = (resp) => {
        arrPac = resp.d;
        divTablePac.showLoading();
        divTablePac.addHeader("RUT", H.cHTMLAlign.center, 64);
        divTablePac.addHeader("DNI", H.cHTMLAlign.center);
        divTablePac.addHeader("Nombre", H.cHTMLAlign.center);
        arrPac.forEach((item, i) => {
            divTablePac.addCellRow(item.PAC_RUT, H.cHTMLAlign.center);
            divTablePac.addCellRow(item.PAC_DNI, H.cHTMLAlign.center);
            divTablePac.addCellRow(item.PAC_NAME, H.cHTMLAlign.left);
            divTablePac.makeRow();
        });
        MODAL.hide();
        divTablePac.makeTable(() => {
            H.form.scrollToID("divTablePac");
        });
    };
    let ajaxAte_ID_PAC = new U.Ajax();
    ajaxAte_ID_PAC.functName = "GET_Atenc_By_ID_PAC";
    ajaxAte_ID_PAC.error = fnError;
    ajaxAte_ID_PAC.success = (resp) => {
        arrAte = resp.d;
        divTableAte.showLoading();
        divTableAte.addHeader("N° Atención", H.cHTMLAlign.center, 64);
        divTableAte.addHeader("Fecha", H.cHTMLAlign.center);
        divTableAte.addHeader("Procedencia", H.cHTMLAlign.center);
        divTableAte.addHeader("Previsión", H.cHTMLAlign.center);
        arrAte.forEach((item, i) => {
            divTableAte.addCellRow(item.ATE_NUM, H.cHTMLAlign.center);
            divTableAte.addCellRow(moment(item.ATE_FECHA).format("DD/MM/YYYY"), H.cHTMLAlign.center);
            divTableAte.addCellRow(item.PROC_DESC, H.cHTMLAlign.left);
            divTableAte.addCellRow(item.PREV_DESC, H.cHTMLAlign.left);
            divTableAte.makeRow();
        });
        divTableAte.makeTable(() => {
            H.form.scrollToID("divTableAte");
        });
    };
    let ajaxAte_ATE_NUM = new U.Ajax();
    ajaxAte_ATE_NUM.functName = "GET_Atenc_By_ATE_NUM";
    ajaxAte_ATE_NUM.error = fnError;
    ajaxAte_ATE_NUM.success = (resp) => {
        arrAte = resp.d;
        divTableAte.showLoading();
        divTableAte.addHeader("N° Atención", H.cHTMLAlign.center, 64);
        divTableAte.addHeader("Fecha", H.cHTMLAlign.center);
        divTableAte.addHeader("Procedencia", H.cHTMLAlign.center);
        divTableAte.addHeader("Previsión", H.cHTMLAlign.center);
        arrAte.forEach((item, i) => {
            divTableAte.addCellRow(item.ATE_NUM, H.cHTMLAlign.center);
            divTableAte.addCellRow(moment(item.ATE_FECHA).format("DD/MM/YYYY"), H.cHTMLAlign.center);
            divTableAte.addCellRow(item.PROC_DESC, H.cHTMLAlign.left);
            divTableAte.addCellRow(item.PREV_DESC, H.cHTMLAlign.left);
            divTableAte.makeRow();
        });
        divTableAte.makeTable(() => {
            H.form.scrollToID("divTableAte");
        });
    };
    let ajaxDet = new U.Ajax();
    ajaxDet.functName = "GET_Ate_Det";
    ajaxDet.error = fnError;
    ajaxDet.success = (resp) => {
        let arrDet = resp.d;
        divTableDet.showLoading();
        divTableDet.addHeader("Cód. Fonasa", H.cHTMLAlign.center);
        divTableDet.addHeader("Descripción", H.cHTMLAlign.center);
        divTableDet.addHeader("Estado", H.cHTMLAlign.center);
        divTableDet.addHeader("Usuario validac.", H.cHTMLAlign.center);
        divTableDet.addHeader("Fecha validac.", H.cHTMLAlign.center);
        divTableDet.addHeader("Tipo Pago", H.cHTMLAlign.center);
        arrDet.forEach((item, i) => {
            divTableDet.addCellRow(item.CF_COD, H.cHTMLAlign.center);
            divTableDet.addCellRow(item.CF_DESC, H.cHTMLAlign.left);
            divTableDet.addCellRow(item.EST_COD, H.cHTMLAlign.center);
            divTableDet.addCellRow(item.USER_V, H.cHTMLAlign.left);
            divTableDet.addCellRow(moment(item.FECHA_V).format("DD/MM/YYYY hh:mm"), H.cHTMLAlign.center);
            divTableDet.addCellRow(item.TP_PAGO_DESC, H.cHTMLAlign.left);
            divTableDet.makeRow();
        });
        divTableDet.makeTable();
    };
    //Eventos
    btnSearch1.eventClick = () => {
        if ((txtRUT.value.length > 0) && (Valid_RUT(txtRUT.value).Valid == false)) {
            txtRUT.value = "";
        }
        if ((txtRUT.value == "") && (txtDNI.value == "") && (txtName.value == "") && (txtlastN.value == "")) {
            return;
        }
        MODAL.show();
        ajaxPac.requestNow({
            PAC_RUT: txtRUT.value,
            PAC_DNI: txtDNI.value,
            PAC_NAME: txtName.value,
            PAC_LASTN: txtlastN.value
        });
    };
    btnSearch2.eventClick = () => {
        ajaxAte_ATE_NUM.requestNow({
            ATE_NUM: txtNAte.value
        });
    };
    btnClean.eventClick = () => {
        txtRUT.value = "";
        txtDNI.value = "";
        txtName.value = "";
        txtlastN.value = "";
    };
    let eventKeyUp_01 = (me) => {
        if (me.which == 13) {
            let strVal = $(me.currentTarget).val();
            strVal = strVal.trim();
            $(me.currentTarget).val(strVal);
            btnSearch1.eventClick();
            return;
        }
    };
    let eventFocusOut = (me) => {
        let strVal = $(me.currentTarget).val();
        $(me.currentTarget).val(strVal.trim());
    };
    txtRUT.eventKeyUp = eventKeyUp_01;
    txtDNI.eventKeyUp = eventKeyUp_01;
    txtName.eventKeyUp = eventKeyUp_01;
    txtlastN.eventKeyUp = eventKeyUp_01;
    txtRUT.eventFocusOut = eventFocusOut;
    txtDNI.eventFocusOut = eventFocusOut;
    txtName.eventFocusOut = eventFocusOut;
    txtlastN.eventFocusOut = eventFocusOut;
    txtNAte.eventKeyUp = (me) => {
        let strOut = $(me.currentTarget).val();
        let arrM;
        arrM = strOut.match(/[0-9]/gi);
        if (arrM == null) {
            txtNAte.value = "";
        }
        else {
            strOut = "";
            arrM.forEach(item => {
                strOut = `${strOut}${item}`;
            });
            txtNAte.value = strOut;
        }
        //Búsqueda
        if (me.which == 13) {
            let strVal = $(me.currentTarget).val();
            strVal = strVal.trim();
            $(me.currentTarget).val(strVal);
            btnSearch2.eventClick();
            return;
        }
    };
    txtRUT.eventKeyUp = (me) => {
        let xValue = $(me.currentTarget).val();
        let xValAlt = "";
        let xOut = "";
        xValue = xValue.replace(/(\.|-)/gi, "");
        if (xValue.match(/^[0-9]*(k?)$/gi) == null) {
            $(me.currentTarget).val("");
            return;
        }
        else if (xValue.length > 9) {
            $(me.currentTarget).val("");
            return;
        }
        for (var i = xValue.length - 1; i >= 0; i--) {
            xValAlt = `${xValAlt}${xValue[i]}`;
        }
        xValAlt = xValAlt.split("");
        for (i = 0; i < xValAlt.length; i++) {
            xOut = `${xValAlt[i]}${xOut}`;
            if (i == 0) {
                xOut = `-${xOut}`;
            }
            else if (i == 3) {
                xOut = `.${xOut}`;
            }
            else if (i == 6) {
                xOut = `.${xOut}`;
            }
        }
        $(me.currentTarget).val(xOut);
        if (me.which == 13) {
            xValue = xOut;
            let objValid = Valid_RUT(xValue);
            if (xValue != "") {
                if (objValid.Valid == false) {
                    $(me.currentTarget).val("");
                }
                else {
                    btnSearch1.eventClick();
                }
            }
        }
    };
    txtRUT.eventFocusOut = () => {
        if ((txtRUT.value.length > 0) && (Valid_RUT(txtRUT.value).Valid == false)) {
            txtRUT.value = "";
            return;
        }
    };
})(SEARCH_PAC || (SEARCH_PAC = {}));
//# sourceMappingURL=Search_Pac.js.map