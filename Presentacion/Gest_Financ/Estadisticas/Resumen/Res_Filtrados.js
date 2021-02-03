var RES_FILTRADOS;
(function (RES_FILTRADOS) {
    var MODAL;
    (function (MODAL) {
        MODAL.show = () => {
            modal_show();
        };
        MODAL.hide = () => {
            Hide_Modal();
        };
    })(MODAL = RES_FILTRADOS.MODAL || (RES_FILTRADOS.MODAL = {}));
    RES_FILTRADOS.root = `${location.origin}/Resultados/Ate_Result_lote.aspx`;
    //Objetos del Form
    let btn_search = new H3.Button("btn_search");
    let btn_export = new H3.Button("btn_export");
    let chk_todos = new H3.Checkbox("chk_todos");
    let txt_date1 = new H3.Textbox("txt_date1");
    let txt_date2 = new H3.Textbox("txt_date2");
    let txt_email = new H3.Textbox("txt_email");
    let sel_proc = new H3.Select("sel_proc");
    let sel_prev = new H3.Select("sel_prev");
    let sel_prog = new H3.Select("sel_prog");
    let sel_subp = new H3.Select("sel_subp");
    let tbl_data = new H3.Table("tbl_data");
    //AJAX
    let modal_load = (() => {
        return new class {
            constructor() {
                this.count = 1;
                this.maxim = 4;
                this.done = false;
                H3.form.eventLoad = () => {
                    MODAL.show();
                };
            }
            trigger() {
                if (this.count < this.maxim) {
                    this.count += 1;
                }
                else {
                    if (this.done == false) {
                        this.done = true;
                        MODAL.hide();
                    }
                }
            }
        }
        ;
    })();
    let ajax_error = (fail) => {
        MODAL.hide();
        $("#mdl_error").modal("show");
        try {
            console.log(`[FAIL] - ERROR:`);
            console.log(`         Tipo: ${fail.responseJSON.ExceptionType}`);
            console.log(`         Detalles: ${fail.responseJSON.Message}`);
            console.log(`         Seguimiento: ${fail.responseJSON.StackTrace}\n\n`);
        }
        catch (err) {
            console.log(fail);
        }
    };
    let ajax_proc = new U3.Ajax();
    ajax_proc.error = ajax_error;
    ajax_proc.functName = "GET_List_Proc";
    ajax_proc.success = (resp) => {
        let arr_data = resp.d;
        sel_proc.clean();
        sel_proc.additem("TODOS", 0);
        arr_data.forEach(elem => {
            sel_proc.additem(elem.text, elem.value);
        });
        modal_load.trigger();
    };
    let ajax_prev = new U3.Ajax();
    ajax_prev.error = ajax_error;
    ajax_prev.functName = "GET_List_Prev";
    ajax_prev.success = (resp) => {
        let arr_data = resp.d;
        sel_prev.clean();
        arr_data.forEach(elem => {
            sel_prev.additem(elem.text, elem.value);
        });
        modal_load.trigger();
    };
    let ajax_prog = new U3.Ajax();
    ajax_prog.error = ajax_error;
    ajax_prog.functName = "GET_List_Prog";
    ajax_prog.success = (resp) => {
        let arr_data = resp.d;
        sel_prog.clean();
        sel_prog.additem("TODOS", 0);
        arr_data.forEach(elem => {
            sel_prog.additem(elem.text, elem.value);
        });
        modal_load.trigger();
    };
    let ajax_subp = new U3.Ajax();
    ajax_subp.error = ajax_error;
    ajax_subp.functName = "GET_List_SubP";
    ajax_subp.success = (resp) => {
        let arr_data = resp.d;
        sel_subp.clean();
        sel_subp.additem("TODOS", 0);
        arr_data.forEach(elem => {
            sel_subp.additem(elem.text, elem.value);
        });
        modal_load.trigger();
    };
    let ajax_search = new U3.Ajax();
    ajax_search.error = ajax_error;
    ajax_search.functName = "Request_Data";
    ajax_search.success = (resp) => {
        let arr_data = resp.d;
        tbl_data.addHeader("", H3.cHTMLAlign.center);
        tbl_data.addHeader("N° Atención", H3.cHTMLAlign.center, 72);
        tbl_data.addHeader("Fecha", H3.cHTMLAlign.center, 72);
        tbl_data.addHeader("RUT", H3.cHTMLAlign.center, 96);
        tbl_data.addHeader("Nombre Paciente", H3.cHTMLAlign.center, 172);
        tbl_data.addHeader("Sexo", H3.cHTMLAlign.center, 72);
        tbl_data.addHeader("RUT Doctor", H3.cHTMLAlign.center, 96);
        tbl_data.addHeader("Nombre Doctor", H3.cHTMLAlign.center, 172);
        tbl_data.addHeader("Cod. Fonasa", H3.cHTMLAlign.center, 100);
        tbl_data.addHeader("Exámen", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("Determinación", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("Resultado", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("Unidad", H3.cHTMLAlign.center, 72);
        tbl_data.addHeader("Procedencia", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("Prevision", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("Programa", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("Subprograma", H3.cHTMLAlign.center, 156);
        tbl_data.addHeader("OC", H3.cHTMLAlign.center);
        let count = 0;
        arr_data.forEach((ate, i) => {
            ate.VALUES.forEach((res, j) => {
                count += 1;
                tbl_data.addCellRow(`${count}`, H3.cHTMLAlign.center);
                tbl_data.addCellRow(ate.ATE_NUM, H3.cHTMLAlign.center);
                tbl_data.addCellRow(moment(ate.ATE_FECHA).format("DD/MM/YYYY"), H3.cHTMLAlign.center);
                tbl_data.addCellRow(ate.PAC_RUT, H3.cHTMLAlign.center);
                tbl_data.addCellRow(`${ate.PAC_NOMBRE} ${ate.PAC_APELLIDO}`, H3.cHTMLAlign.left);
                tbl_data.addCellRow(ate.SEXO_DESC, H3.cHTMLAlign.center);
                tbl_data.addCellRow(ate.DOC_RUT, H3.cHTMLAlign.center);
                tbl_data.addCellRow(`${ate.DOC_NOMBRE} ${ate.DOC_APELLIDO}`, H3.cHTMLAlign.center);
                tbl_data.addCellRow(res.CF_COD, H3.cHTMLAlign.left);
                tbl_data.addCellRow(res.CF_DESC, H3.cHTMLAlign.left);
                tbl_data.addCellRow(res.PRU_DESC, H3.cHTMLAlign.left);
                tbl_data.addCellRow((() => {
                    switch (res.ID_TIPO_DATO) {
                        case 2:
                        case 4:
                            return res.ATE_RESULTADO_NUM.trim();
                            break;
                        default:
                            return res.ATE_RESULTADO.trim();
                            break;
                    }
                })(), //Resultado
                (() => {
                    let value;
                    switch (res.ID_TIPO_DATO) {
                        case 4:
                        case 2:
                            value = res.ATE_RESULTADO_NUM;
                            break;
                        default:
                            value = res.ATE_RESULTADO;
                            break;
                    }
                    if (U3.CONV.isNum(value.replace(/,/gi, ".")) == true) {
                        return H3.cHTMLAlign.right;
                    }
                    else {
                        return H3.cHTMLAlign.left;
                    }
                })() //Alineación
                );
                tbl_data.addCellRow(res.ATE_TXT_UNIDAD, H3.cHTMLAlign.left);
                tbl_data.addCellRow(ate.PROC_DESC, H3.cHTMLAlign.left);
                tbl_data.addCellRow(ate.PREVE_DESC, H3.cHTMLAlign.left);
                tbl_data.addCellRow(ate.PROGRA_DESC, H3.cHTMLAlign.left);
                tbl_data.addCellRow(ate.SUBP_DESC, H3.cHTMLAlign.left);
                tbl_data.addCellRow(ate.ATE_OMI, H3.cHTMLAlign.center);
                tbl_data.makeRow();
            });
        });
        tbl_data.makeTable();
        MODAL.hide();
    };
    let ajax_export = new U3.Ajax();
    ajax_export.error = ajax_error;
    ajax_export.functName = "Request_Excel";
    ajax_export.success = (resp) => {
        MODAL.hide();
        $("#mdl_sended .modal-body strong").text(txt_email.value);
        txt_email.value = "";
        $("#mdl_sended").modal();
    };
    //Configuración inicial
    txt_date1.datePicker = true;
    txt_date2.datePicker = true;
    txt_date1.locked = true;
    txt_date2.locked = true;
    chk_todos.checked = true;
    tbl_data.setDataTable(true);
    btn_export.locked = true;
    //Eventos
    chk_todos.eventChange = () => {
        if (chk_todos.checked == true) {
            chk_todos.text = "Todos los Result";
        }
        else {
            chk_todos.text = "Solo el 1er Result";
        }
    };
    btn_search.eventClick = () => {
        MODAL.show();
        ajax_search.requestNow({
            DATE_01: txt_date1.value,
            DATE_02: txt_date2.value,
            ID_PROC: sel_proc.value().value,
            ID_PREV: sel_prev.value().value,
            ID_PROG: sel_prog.value().value,
            ID_SUBP: sel_subp.value().value,
            ALL_EXA: chk_todos.checked,
            ARRTEXT: [
                sel_proc.value().text,
                sel_prev.value().text,
                sel_prog.value().text,
                sel_subp.value().text
            ]
        });
    };
    btn_export.eventClick = () => {
        MODAL.show();
        txt_email.value = txt_email.value.match(reg_email)[0];
        ajax_export.requestNow({
            DATE_01: txt_date1.value,
            DATE_02: txt_date2.value,
            ID_PROC: sel_proc.value().value,
            ID_PREV: sel_prev.value().value,
            ID_PROG: sel_prog.value().value,
            ID_SUBP: sel_subp.value().value,
            ALL_EXA: chk_todos.checked,
            EMAIL: txt_email.value,
            ARRTEXT: [
                sel_proc.value().text,
                sel_prev.value().text,
                sel_prog.value().text,
                sel_subp.value().text
            ]
        });
        add_email();
        btn_export.locked = true;
        $("#mdl_correo").modal("hide");
    };
    let reg_email = /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/i;
    let add_email = () => {
        let xVal = txt_email.value.trim();
        if (xVal.match(reg_email) != null) {
            function fn_guardar_Galleta() {
                dataList.append($("<option>", { value: xVal }));
                frag.push(xVal);
                frag = JSON.stringify(frag);
                frag = encodeURIComponent(frag);
                frag = btoa(frag);
                Galletas.setGalleta("email", frag, 60 * 60 * 24 * 365.6 * 5);
                frag = atob(frag);
                frag = decodeURIComponent(frag);
                frag = JSON.parse(frag);
            }
            if (frag.length == 0) {
                fn_guardar_Galleta();
            }
            else {
                let xFound = false;
                frag.forEach((xItem) => {
                    if (xItem == xVal) {
                        xFound = true;
                    }
                });
                if (xFound == false) {
                    fn_guardar_Galleta();
                }
            }
        }
    };
    txt_email.eventKeyUp = (me) => {
        if (me.which != 13) {
            if (txt_email.value.match(reg_email) == null) {
                btn_export.locked = true;
            }
            else {
                btn_export.locked = false;
            }
        }
        else {
            //Enviar correo
            btn_export.callEventClick();
        }
    };
    //Ejecutar los AJAX de inicio
    H3.form.eventLoad = () => {
        console.clear();
        ajax_proc.requestNow(null, () => {
            ajax_prev.requestNow({
                ID_PROC: 0
            }, () => {
                ajax_prog.requestNow({
                    ID_PREV: sel_prev.value().value
                }, () => {
                    ajax_subp.requestNow({
                        ID_PREV: sel_prev.value().value,
                        ID_PROG: sel_prog.value().value
                    }, () => {
                        txt_date1.callEventFocus();
                    });
                });
            });
        });
    };
    H3.form.eventLoad = () => {
        $("#mdl_correo").on("shown.bs.modal", () => {
            txt_email.callEventFocus();
            txt_email.callEventKeyUp();
        });
        $("#mdl_sended").on("shown.bs.modal", () => {
            $("#mdl_sended .modal-footer button").focus();
        });
        $("#mdl_sended").on("hidden.bs.modal", () => {
            txt_date1.callEventFocus();
        });
    };
    //Historial de correos
    let frag = Galletas.getGalleta("email");
    let dataList = $("<datalist>", { id: "email" });
    H3.form.eventLoad = () => {
        //Capturar galleta
        if (frag == null) {
            frag = [];
        }
        else {
            frag = atob(frag);
            frag = decodeURIComponent(frag);
            frag = JSON.parse(frag);
        }
        frag.forEach((xItem) => {
            dataList.append($("<option>", { value: xItem }));
        });
        $("body").append(dataList);
        $("#txt_email").attr("list", "email");
    };
})(RES_FILTRADOS || (RES_FILTRADOS = {}));
//# sourceMappingURL=Res_Filtrados.js.map