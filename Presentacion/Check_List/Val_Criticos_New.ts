namespace VAL_CRITICOS_NEW {
    namespace MODAL {
        declare var modal_show: () => void
        declare var Hide_Modal: () => void

        export let show = () => {
            modal_show()
        }
        export let hide = () => {
            Hide_Modal()
        }
    }
    interface iHtmlSelect {
        text: string,
        value: number
    }
    interface iData {
        ID_ATENCION: number;
        ID_ATE_RES: number;
        ATE_NUM: string
        ATE_FECHA: Date;
        PAC_DCTO: string;
        PAC_NAME: string;
        SEXO_DESC: string;
        PAC_FNAC: Date;
        EDAD: string;
        PROC_DESC: string;
        PREVE_DESC: string;
        CODF_COD: string;
        CODF_DESC: string;
        PRU_DESC: string;
        EST_VALIDAC: string;
        FECHA_VALIDAC: Date;
        TIPO_RES: string;
        PRU_VALUE: number;
        ALARMA: string;
        ATE_RR_DESDE: number;
        ATE_R_DESDE: number;
        ATE_R_HASTA: number;
        ATE_RR_HASTA: number;
        FECHA_ENVIO: Date;
    }

    //Declaraciones Genéricas
    let fnError = (fail: any) => {
        MODAL.hide()
        $("#mdlError").modal("show")

        try {
            console.log(`[FAIL] - ERROR:`)
            console.log(`         Tipo: ${fail.responseJSON.ExceptionType}`)
            console.log(`         Tipo: ${fail.responseJSON.Message}`)
            console.log(`         Seguimiento: ${fail.responseJSON.StackTrace}\n\n`)
        } catch (err) {
            console.log(fail)
        }
    }
    let objLoad = (new class {
        private count: number

        constructor() {
            this.count = 0
        }

        public callback(): void {
            this.count += 1

            if (this.count > 2) {
                selProc.eventChange = () => {
                    ajaxPrev.requestNow({ ID_PROC: selProc.value })
                }

                MODAL.hide()
            }
        }
    })

    //Declaraciones WEBFORM
    let txtDate1 = new H.Ts_Textbox("txtDate1")
    let txtDate2 = new H.Ts_Textbox("txtDate2")
    let selProc = new H.Ts_Select("selProc")
    let selPrev = new H.Ts_Select("selPrev")
    let selCodF = new H.Ts_Select("selCodF")
    let selCrit = new H.Ts_Select("selEsta")
    let btnSearch = new H.Ts_Button("btnSearch")
    let btnExport = new H.Ts_Button("btnExport")
    let divTable = new H.Ts_Table("divTable")

    txtDate1.datePicker = true
    txtDate1.locked = true
    txtDate2.datePicker = true
    txtDate2.locked = true

    divTable.setDataTable(true, 50)
    divTable.isSelectable = true

    //Declaraciones AJAX
    let ajaxProc = new U.Ajax()
    ajaxProc.functName = "GET_Select_Proc"
    ajaxProc.error = fnError
    ajaxProc.success = (resp) => {
        let arr: Array<iHtmlSelect> = resp.d

        selProc.clean()
        arr.forEach(item => {
            selProc.addItem(item.text, item.value)
        })
        objLoad.callback()
    }

    let ajaxPrev = new U.Ajax()
    ajaxPrev.functName = "GET_Select_Prev"
    ajaxPrev.error = fnError
    ajaxPrev.success = (resp) => {
        let arr: Array<iHtmlSelect> = resp.d

        selPrev.clean()
        arr.forEach(item => {
            selPrev.addItem(item.text, item.value)
        })
        objLoad.callback()
    }

    let ajaxCodF = new U.Ajax()
    ajaxCodF.functName = "GET_Select_CodF"
    ajaxCodF.error = fnError
    ajaxCodF.success = (resp) => {
        let arr: Array<iHtmlSelect> = resp.d

        selCodF.clean()
        arr.forEach(item => {
            selCodF.addItem(item.text, item.value)
        })
        objLoad.callback()
    }

    let ajaxData = new U.Ajax()
    ajaxData.functName = "GET_Data"
    ajaxData.error = fnError
    ajaxData.success = (resp) => {
        let arr: Array<iData> = resp.d

        divTable.addHeader("N° Atención", H.cHTMLAlign.center)
        divTable.addHeader("Fecha Atenc", H.cHTMLAlign.center, 72)
        divTable.addHeader("RUT/DNI", H.cHTMLAlign.center)
        divTable.addHeader("Nombre Paciente", H.cHTMLAlign.center, 240)
        divTable.addHeader("Sexo", H.cHTMLAlign.center)
        divTable.addHeader("Fecha Nac", H.cHTMLAlign.center)
        divTable.addHeader("Edad", H.cHTMLAlign.center)
        divTable.addHeader("Procedencia", H.cHTMLAlign.center, 160)
        divTable.addHeader("Previsión", H.cHTMLAlign.center, 160)
        divTable.addHeader("Cod. Fonasa", H.cHTMLAlign.center, 72)
        divTable.addHeader("Descripción Cod. Fonasa", H.cHTMLAlign.center, 240)
        divTable.addHeader("Prueba", H.cHTMLAlign.center, 240)
        divTable.addHeader("Fecha Validac.", H.cHTMLAlign.center, 64)
        divTable.addHeader("Hora Validac.", H.cHTMLAlign.center, 64)
        divTable.addHeader("Resultado", H.cHTMLAlign.center)
        divTable.addHeader("Alarma", H.cHTMLAlign.center)
        divTable.addHeader("Muy Bajo", H.cHTMLAlign.center, 64)
        divTable.addHeader("Bajo", H.cHTMLAlign.center, 64)
        divTable.addHeader("Alto", H.cHTMLAlign.center, 64)
        divTable.addHeader("Muy Alto", H.cHTMLAlign.center, 64)

        arr.forEach(item => {
            divTable.addCellRow(item.ATE_NUM, H.cHTMLAlign.center)
            divTable.addCellRow(moment(item.ATE_FECHA).format("DD/MM/YYYY"), H.cHTMLAlign.center)
            divTable.addCellRow(item.PAC_DCTO, H.cHTMLAlign.center)
            divTable.addCellRow(item.PAC_NAME, H.cHTMLAlign.left)
            divTable.addCellRow(item.SEXO_DESC, H.cHTMLAlign.left)
            divTable.addCellRow(moment(item.PAC_FNAC).format("DD/MM/YYYY"), H.cHTMLAlign.center)
            divTable.addCellRow(item.EDAD, H.cHTMLAlign.center)
            divTable.addCellRow(item.PROC_DESC, H.cHTMLAlign.left)
            divTable.addCellRow(item.PREVE_DESC, H.cHTMLAlign.left)
            divTable.addCellRow(item.CODF_COD, H.cHTMLAlign.center)
            divTable.addCellRow(item.CODF_DESC, H.cHTMLAlign.left)
            divTable.addCellRow(item.PRU_DESC, H.cHTMLAlign.left)
            divTable.addCellRow(moment(item.FECHA_VALIDAC).format("DD/MM/YYYY"), H.cHTMLAlign.center)
            divTable.addCellRow(moment(item.FECHA_VALIDAC).format("hh:mm"), H.cHTMLAlign.center)
            divTable.addCellRow(U.CONV.formatNum(item.PRU_VALUE), H.cHTMLAlign.right)
            divTable.addCellRow(item.ALARMA, H.cHTMLAlign.center)
            divTable.addCellRow(U.CONV.formatNum(item.ATE_RR_DESDE), H.cHTMLAlign.right)
            divTable.addCellRow(U.CONV.formatNum(item.ATE_R_DESDE), H.cHTMLAlign.right)
            divTable.addCellRow(U.CONV.formatNum(item.ATE_R_HASTA), H.cHTMLAlign.right)
            divTable.addCellRow(U.CONV.formatNum(item.ATE_RR_HASTA), H.cHTMLAlign.right)

            divTable.makeRow()
        })

        divTable.makeTable()
        MODAL.hide()
    }

    let ajaxExcel = new U.Ajax()
    ajaxExcel.functName = "GET_Excel_Url"
    ajaxExcel.error = fnError
    ajaxExcel.success = (resp) => {
        let strURL = resp.d;
        let bolFound = false

        MODAL.hide()
        $(`#mdlExport .modal-body p`).hide()
        if (strURL != null) {
            bolFound = true

            if (strURL.match(/^https?:\/\//gi) == null) {
                strURL = `http://${strURL}`
            }

            $(`#mdlExport .modal-body p a`).attr("href", strURL)
            location.href = strURL
        }

        MODAL.hide()
        $(`#mdlExport .modal-body p[data-found=${bolFound}]`).show()
        $(`#mdlExport`).modal();

    };

    //Eventos
    btnSearch.eventClick = () => {
        MODAL.show()
        ajaxData.requestNow({
            DATE_01: txtDate1.value,
            DATE_02: txtDate2.value,
            ID_PROC: selProc.value,
            ID_PREV: selPrev.value,
            ID_CODF: selCodF.value,
            ID_CRIT: selCrit.value
        })
    }
    btnExport.eventClick = () => {
        MODAL.show()
        ajaxExcel.requestNow({
            DATE_01: txtDate1.value,
            DATE_02: txtDate2.value,
            ID_PROC: selProc.value,
            ID_PREV: selPrev.value,
            ID_CODF: selCodF.value,
            ID_CRIT: selCrit.value,
            ARR_STR: [
                selProc.text,
                selPrev.text,
                selCodF.text,
                selCrit.text
            ]
        })
    }

    H.form.load = () => {
        MODAL.show()
        ajaxProc.requestNow()
        ajaxPrev.requestNow({ ID_PROC: 0 })
        ajaxCodF.requestNow()

        selCrit.addItem("TODOS", 0)
        selCrit.addItem("BAJO", 1)
        selCrit.addItem("ALTO", 2)
    }
}