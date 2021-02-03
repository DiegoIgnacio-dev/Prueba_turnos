namespace MANT_PRECIOS_CONV {
    namespace II {
        export interface iYear {
            ID_AÑO: number;
            AÑO_COD: string;
            AÑO_DESC: string;
            ID_ESTADO: number;
        }

        export interface iPrev{
            ID_PREVE: number;
            PREVE_COD: string;
            PREVE_DESC: string;
            ID_ESTADO: number;
        }

        export interface iData {
            ID_CODIGO_FONASA: number;
            CF_COD: string;
            CF_DESC: string;
            CF_CONVENIO_OUT: boolean;
            ID_CF_PRECIO: number;
            CF_PRECIO_AMB: number;
            CF_PRECIO_COSTO_DERIV: number;
            CF_PRECIO_COSTO_T: number;
            CF_PRECIO_PJE_LAB: number;
            CF_PRECIO_PJE_CONV: number;
            ID_AÑO: number;
            AÑO_COD: string;
            AÑO_DESC: string;
            ID_PREVE: number;
            PREVE_COD: string;
            PREVE_DESC: string;
        }
    }
    
    //-----------------------------------------------------------------------------------------------------------------
    //--Declaraciones Funciones----------------------------------------------------------------------------------------
    declare var modal_show: () => void
    declare var Hide_Modal: () => void

    let fn_Init_Loading: any = {
        count: 0,
        max_count: 2,
        trigger: function () {
            this.count += 1

            if (this.count >= this.max_count) {
                this.count = 0
                Hide_Modal()
            }
        }
    }
    let fn_Make_Table = () => {
        objTable.isClickeable = false
        objTable.isDataTable = true
        objTable.cleanTable()

        objTable.addTHead("", "right")
        objTable.addTHead("Cod. Fonasa", "center")
        objTable.addTHead("Descripción", "left")
        objTable.addTHead("", "center")
        objTable.addTHead("Valor Unitario", "center")
        objTable.addTHead("Costo Derivado", "center")
        objTable.addTHead("Total Costos", "center")
        objTable.addTHead("Diferenc.", "center")
        objTable.addTHead("% Centro Med.", "center")
        objTable.addTHead("Monto Centro Med.", "center")
        objTable.addTHead("% Laborat.", "center")
        objTable.addTHead("Monto Laborat.", "center")

        arrData.forEach((xItem, xIndex) => {
            objTable.addRow(
                xIndex,
                [
                    (function (): string {
                        let strNow: string = `${xIndex + 1}`
                        let strLng: string = `${arrData.length}`

                        while (strNow.length < strLng.length) {
                            strNow = `0${strNow}`
                        }

                        return strNow
                    } ()),
                    xItem.CF_COD,
                    xItem.CF_DESC,
                    Chk_Enabled.toString(xIndex, null, (function (): boolean {
                        if (xItem.CF_CONVENIO_OUT == true) {
                            return true
                        } else {
                            return false
                        }
                    } ())),
                    `<input type="text" class="txt_table form-control" data-array="CF_PRECIO_AMB" data-dec="0,0" value="${function () {
                        let raw: number = xItem.CF_PRECIO_AMB
                        let strOut: string = numeral(raw).format("0,0")

                        strOut = strOut.replace(/,/g, ".")
                        return strOut
                    } ()}" />`,
                    `<input type="text" class="txt_table form-control" data-array="CF_PRECIO_COSTO_DERIV" data-dec="0,0" value="${function () {
                        let raw: number = xItem.CF_PRECIO_COSTO_DERIV
                        let strOut: string = numeral(raw).format("0,0")

                        strOut = strOut.replace(/,/g, ".")
                        return strOut
                    } ()}" />`,
                    `<input type="text" class="txt_table form-control" data-array="CF_PRECIO_COSTO_T" data-dec="0,0" value="${function () {
                        let raw: number = xItem.CF_PRECIO_COSTO_T
                        let strOut: string = numeral(raw).format("0,0")

                        strOut = strOut.replace(/,/g, ".")
                        return strOut
                    } ()}" />`,
                    `<input type="text" class="txt_table form-control" data-calc="dif" value="${function () {
                        let raw: number = xItem.CF_PRECIO_AMB - xItem.CF_PRECIO_COSTO_T
                        let strOut: string = numeral(raw).format("0,0")

                        strOut = strOut.replace(/,/g, ".")
                        return strOut
                    } ()}" readonly />`,
                    `<input type="text" class="txt_table form-control" data-array="CF_PRECIO_PJE_CONV" data-dec="0,0.00" value="${function () {
                        let raw: number = xItem.CF_PRECIO_PJE_CONV
                        let strOut: string = numeral(raw).format("0,0.00")

                        strOut = strOut.replace(/\./g, "d")
                        strOut = strOut.replace(/,/g, ".")
                        strOut = strOut.replace(/d/gi, ",")
                        return strOut
                    } ()}" />`,
                    `<input type="text" class="txt_table form-control" data-calc="pje1" value="${function () {
                        let raw: number = xItem.CF_PRECIO_AMB - xItem.CF_PRECIO_COSTO_T
                        let strOut: string = numeral(TOOL.fn_cutDecimals(raw * xItem.CF_PRECIO_PJE_CONV * 0.01, 0, true)).format("0,0")

                        strOut = strOut.replace(/\./g, "d")
                        strOut = strOut.replace(/,/g, ".")
                        strOut = strOut.replace(/d/gi, ",")
                        return strOut
                    } ()}" readonly/>`,
                    `<input type="text" class="txt_table form-control" data-array="CF_PRECIO_PJE_LAB" data-dec="0,0.00" value="${function () {
                        let raw: number = xItem.CF_PRECIO_PJE_LAB
                        let strOut: string = numeral(raw).format("0,0.00")

                        strOut = strOut.replace(/\./g, "d")
                        strOut = strOut.replace(/,/g, ".")
                        strOut = strOut.replace(/d/gi, ",")
                        return strOut
                    } ()}" />`,
                    `<input type="text" class="txt_table form-control" data-calc="pje2" value="${function () {
                        let raw: number = xItem.CF_PRECIO_AMB - xItem.CF_PRECIO_COSTO_T
                        let strOut: string = numeral(TOOL.fn_cutDecimals(raw * xItem.CF_PRECIO_PJE_LAB * 0.01, 0, true)).format("0,0")

                        strOut = strOut.replace(/\./g, "d")
                        strOut = strOut.replace(/,/g, ".")
                        strOut = strOut.replace(/d/gi, ",")
                        return strOut
                    } ()}" readonly/>`
                ]
            )
        })

        objTable.evReDraw = () => {
            fn_Chk_Click()
        }
        objTable.updateTable("No se han encontrado Resultados", 25)
        fn_Chk_Click()

        objTable.evReDraw = () => {
            $(".txt_table").off("focusout")
            $(".txt_table").off("focusin")
            $(".txt_table").off("keyup")

            $(".txt_table").keyup(fn_Txt_KeyUp)
            $(".txt_table").focusout(fn_Txt_FocusOut)
            $(".txt_table").focusin(fn_Txt_FocusIn)
            fn_Chk_Click()
        }

        objTable.updateTable("No se han encontrado Resultados", 25)
        $(".txt_table").off("focusout")
        $(".txt_table").off("focusin")
        $(".txt_table").off("keyup")

        $(".txt_table").keyup(fn_Txt_KeyUp)
        $(".txt_table").focusout(fn_Txt_FocusOut)
        $(".txt_table").focusin(fn_Txt_FocusIn)
        fn_Chk_Click()
    }
    let fn_Write_Data = (xIndex: number) => {
        let xItem = arrData[xIndex]
        
        objAJAX_Data_Rec.requestNow({
            ID_CODF: xItem.ID_CODIGO_FONASA,
            ID_PREC: xItem.ID_CF_PRECIO,
            BIT_CONV: xItem.CF_CONVENIO_OUT,
            LNG_PREC: xItem.CF_PRECIO_AMB,
            LNG_DERI: xItem.CF_PRECIO_COSTO_DERIV,
            LNG_CTOT: xItem.CF_PRECIO_COSTO_T,
            DBL_PJEC: xItem.CF_PRECIO_PJE_CONV,
            DBL_PJEL: xItem.CF_PRECIO_PJE_LAB
        })
    }
    let fn_Txt_FocusOut = (Me: JQueryEventObject) => {
        let arrField: string = $(Me.currentTarget).attr("data-array")
        let xVal: string = $(Me.currentTarget).val()
        let arrM: Array<string>
        
        if ($(Me.currentTarget).attr("readonly")) {
            return
        }

        arrM = xVal.match(/^[0-9]+(\.[0-9]+)?/gi)
        if (arrM != null) {
            xVal = arrM[0]
        } else {
            xVal = "0"
        }

        let floatVal: number = parseFloat(xVal)
        let strFormat: string = $(Me.currentTarget).attr("data-dec")
        let xRow: number = parseInt($(Me.currentTarget).parents("tr").attr("data-index"))

        switch ($(Me.currentTarget).attr("data-array")) { }

        if (strFormat.match(/\.0+$/g) == null) {
            arrData[xRow][arrField] = parseInt(`${floatVal}`)
        } else {
            arrData[xRow][arrField] = floatVal
        }
        
        window.clearInterval(countSave)
        fn_Auto_Calc(Me)
        fn_Write_Data(xRow)

        if (strFormat.match(/\.0+$/g) == null) {
            xVal = numeral(parseInt(`${arrData[xRow][arrField]}`)).format(strFormat)
        } else {
            xVal = numeral(arrData[xRow][arrField]).format(strFormat)
        }

        xVal = xVal.replace(/\./g, "d")
        xVal = xVal.replace(/,/g, ".")
        xVal = xVal.replace(/d/g, ",")

        $(Me.currentTarget).val(xVal)
    }
    let fn_Txt_FocusIn = (Me: JQueryEventObject) => {
        let xVal: string = $(Me.currentTarget).val()
        let arrM: Array<string>

        if ($(Me.currentTarget).attr("readonly")) {
            return
        }

        xVal = xVal.replace(/\./g, "")
        xVal = xVal.replace(/,/g, ".")

        arrM = xVal.match(/^[0-9]+(\.[0-9]+)?/gi)
        if (arrM != null) {
            xVal = arrM[0]
        } else {
            xVal = "0"
        }

        $(Me.currentTarget).val(xVal)
        $(Me.currentTarget).select()
    }
    let fn_Txt_KeyUp = (Me: JQueryEventObject) => {
        let arrField: string = $(Me.currentTarget).attr("data-array")
        let xVal: string = $(Me.currentTarget).val()
        let arrM: Array<string>
        
        if ($(Me.currentTarget).attr("readonly")) {
            return
        }
        
        xVal = xVal.replace(/,/gi, ".")
        arrM = xVal.match(/^[0-9]+(\.[0-9]*)?/gi)

        if (arrM != null) {
            xVal = arrM[0]
        } else {
            xVal = "0"
        }
        
        window.clearTimeout(countSave)
        if (Me.which == 13) {
            let objInput: JQuery

            if ($(Me.currentTarget).attr("data-array") == "CF_PRECIO_COSTO_T") {
                objInput = $(Me.currentTarget).parents("tr").find("input[data-array=CF_PRECIO_PJE_CONV]")
            } else if ($(Me.currentTarget).attr("data-array") == "CF_PRECIO_PJE_CONV") {
                objInput = $(Me.currentTarget).parents("tr").find("input[data-array=CF_PRECIO_PJE_LAB]")
            } else if ($(Me.currentTarget).attr("data-array") == "CF_PRECIO_PJE_LAB") {
                objInput = $(Me.currentTarget).parents("tr").next().find("input[data-array=CF_PRECIO_AMB]")
            } else {
                objInput = $(Me.currentTarget).parent().next().children("input")
            }

            objInput.focus()
            //objInput.select()
        } else {
            //let fn_Procesar_Valores = (writeDB: boolean = true) => {
            //    let xRow: number = parseInt($(Me.currentTarget).parents("tr").attr("data-index"))
            //    let floatVal: number = parseFloat(xVal)
            //    let strFormat: string = $(Me.currentTarget).attr("data-dec")

            //    if (strFormat.match(/\.0+$/g) == null) {
            //        arrData[xRow][arrField] = parseInt(`${floatVal}`)
            //    } else {
            //        arrData[xRow][arrField] = floatVal
            //    }

            //    $(Me.currentTarget).val(xVal)
            //    fn_Auto_Calc(Me)
            //    if (writeDB == true) {
            //        fn_Write_Data(xRow)
            //    }
            //}
            
            //fn_Procesar_Valores(false)
            //countSave = setTimeout(fn_Procesar_Valores(), 2000)
            $(Me.currentTarget).val(xVal.replace(/^0+(?=[1-9])/gi, ""))
        }
    }
    let fn_Auto_Calc = (Me: JQueryEventObject) => {
        let xIndex: number = parseInt($(Me.currentTarget).parents("tr").attr("data-index"))
        let txtDif: JQuery = $(Me.currentTarget).parents("tr").find("input[data-calc=dif]")
        let txtPje1: JQuery = $(Me.currentTarget).parents("tr").find("input[data-calc=pje1]")
        let txtPje2: JQuery = $(Me.currentTarget).parents("tr").find("input[data-calc=pje2]")

        let fn_To_String = (input: number | string, format: string): string => {
            let xOut: string = numeral(input).format(format)

            xOut = xOut.replace(/\./g, "d")
            xOut = xOut.replace(/,/g, ".")
            xOut = xOut.replace(/d/g, ",")

            return xOut
        }
        let xTR: JQuery = $(Me.currentTarget).parents("tr")
        switch ($(Me.currentTarget).attr("data-array")) {
            case "CF_PRECIO_AMB":
                if (arrData[xIndex].CF_PRECIO_AMB < arrData[xIndex].CF_PRECIO_COSTO_T) {
                    arrData[xIndex].CF_PRECIO_COSTO_T = arrData[xIndex].CF_PRECIO_AMB

                    xTR.find("input[data-array=CF_PRECIO_COSTO_T]").val(fn_To_String(arrData[xIndex].CF_PRECIO_COSTO_T, "0,0"))
                }
                break
            case "CF_PRECIO_COSTO_T":
                if (arrData[xIndex].CF_PRECIO_AMB < arrData[xIndex].CF_PRECIO_COSTO_T) {
                    arrData[xIndex].CF_PRECIO_COSTO_T = arrData[xIndex].CF_PRECIO_AMB
                }
                xTR.find("input[data-array=CF_PRECIO_COSTO_T]").val(fn_To_String(arrData[xIndex].CF_PRECIO_COSTO_T, "0,0"))
                break
            case "CF_PRECIO_PJE_CONV":
                if (arrData[xIndex].CF_PRECIO_PJE_CONV > 100) {
                    arrData[xIndex].CF_PRECIO_PJE_CONV = 100
                }
                if (100 != (arrData[xIndex].CF_PRECIO_PJE_CONV + arrData[xIndex].CF_PRECIO_PJE_LAB)) {
                    arrData[xIndex].CF_PRECIO_PJE_LAB = 100 - arrData[xIndex].CF_PRECIO_PJE_CONV
                    xTR.find("input[data-array=CF_PRECIO_PJE_CONV]").val(fn_To_String(arrData[xIndex].CF_PRECIO_PJE_CONV, "0,0.00"))
                    xTR.find("input[data-array=CF_PRECIO_PJE_LAB]").val(fn_To_String(arrData[xIndex].CF_PRECIO_PJE_LAB, "0,0.00"))
                }
                break
            case "CF_PRECIO_PJE_LAB":
                if (arrData[xIndex].CF_PRECIO_PJE_LAB > 100) {
                    arrData[xIndex].CF_PRECIO_PJE_LAB = 100
                }
                if (100 != (arrData[xIndex].CF_PRECIO_PJE_CONV + arrData[xIndex].CF_PRECIO_PJE_LAB)) {
                    arrData[xIndex].CF_PRECIO_PJE_CONV = 100 - arrData[xIndex].CF_PRECIO_PJE_LAB
                    xTR.find("input[data-array=CF_PRECIO_PJE_LAB]").val(fn_To_String(arrData[xIndex].CF_PRECIO_PJE_LAB, "0,0.00"))
                    xTR.find("input[data-array=CF_PRECIO_PJE_CONV]").val(fn_To_String(arrData[xIndex].CF_PRECIO_PJE_CONV, "0,0.00"))
                }
                break
        }

        let numDif: number = arrData[xIndex].CF_PRECIO_AMB - arrData[xIndex].CF_PRECIO_COSTO_T
        let arrVal: Array<string> = []
        arrVal.push(numeral(numDif).format("0,0"))
        arrVal.push(fn_To_String(TOOL.fn_cutDecimals(numDif * arrData[xIndex].CF_PRECIO_PJE_CONV * 0.01, 0, true), "0,0"))
        arrVal.push(fn_To_String(TOOL.fn_cutDecimals(numDif * arrData[xIndex].CF_PRECIO_PJE_LAB * 0.01, 0, true), "0,0"))

        arrVal.forEach(xItem => {
            xItem = xItem.replace(/\./g, "d")
            xItem = xItem.replace(/,/g, ".")
            xItem = xItem.replace(/d/g, ",")
        })

        txtDif.val(arrVal[0])
        txtPje1.val(arrVal[1])
        txtPje2.val(arrVal[2])
    }
    let fn_Chk_Click = () => {
        Chk_Enabled.evClick = (Me: JQueryEventObject) => {
            let xIndex: number = TOOL.fn_Base64().fromBase64($(Me.currentTarget).val())

            if (arrData[xIndex].CF_CONVENIO_OUT == false) {
                arrData[xIndex].CF_CONVENIO_OUT = true
            } else {
                arrData[xIndex].CF_CONVENIO_OUT = false
            }

            fn_Write_Data(xIndex)
        }
    }

    //--Declaraciones Objetos------------------------------------------------------------------------------------------
    let Chk_Filther = new WEBFORM.class_Checkbox("Chk_Filther")
    let Chk_Filther_2 = new WEBFORM.class_Checkbox("Chk_Filther_2")
    let Chk_Enabled = new WEBFORM.class_Chk_Static("Chk_Enabled")

    let Sel_Year = new WEBFORM.class_Select("Sel_Year")
    let Sel_Year_From = new WEBFORM.class_Select("Sel_Year_From")
    let Sel_Year_To = new WEBFORM.class_Select("Sel_Year_To")
    let Sel_Prev = new WEBFORM.class_Select("Sel_Prev")
    let Sel_Prev_From = new WEBFORM.class_Select("Sel_Prev_From")
    let Sel_Prev_To = new WEBFORM.class_Select("Sel_Prev_To")

    let Btn_Search = new WEBFORM.class_Button("Btn_Search")
    let Btn_Export = new WEBFORM.class_Button("Btn_Export")
    let Btn_Copy = new WEBFORM.class_Button("Btn_Copy")
    let Btn_Confirm_Copy = new WEBFORM.class_Button("Btn_Confirm_Copy")
    
    let objTable = new WEBFORM.class_Table("divTable", "Realice una búsqueda para editar los valores para alterar los datos.")
    let arrData: Array<II.iData> = []

    let countSave: number

    //--Declaraciones AJAX---------------------------------------------------------------------------------------------
    let objAJAX_Year = new TOOL.class_AJAX(
        "Mant_Precios_Conv.aspx/Select_Year",
        (resp: TOOL.int_ajax_success) => {
            let arrSel: Array<II.iYear> = resp.d

            Sel_Year.cleanAll()
            Sel_Year_From.cleanAll()
            Sel_Year_To.cleanAll()
            let valYear: number
            arrSel.forEach((xItem, xIndex) => {
                if (xItem.AÑO_DESC == moment().format("YYYY")) {
                    valYear = xIndex
                }
                Sel_Year.insertElem(xItem.AÑO_DESC, xItem.ID_AÑO)
                Sel_Year_From.insertElem(xItem.AÑO_DESC, xItem.ID_AÑO)
                Sel_Year_To.insertElem(xItem.AÑO_DESC, xItem.ID_AÑO)
            })

            Sel_Year.setValue(arrSel[valYear].ID_AÑO)
            Sel_Year_From.setValue(arrSel[valYear].ID_AÑO)
            Sel_Year_To.setValue(arrSel[valYear].ID_AÑO)
            fn_Init_Loading.trigger()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Prev = new TOOL.class_AJAX(
        "Mant_Precios_Conv.aspx/Select_Prev",
        (resp: TOOL.int_ajax_success) => {
            let arrSel: Array<II.iPrev> = resp.d

            Sel_Prev.cleanAll()
            Sel_Prev_From.cleanAll()
            Sel_Prev_To.cleanAll()
            arrSel.forEach((xItem) => {
                Sel_Prev.insertElem(xItem.PREVE_DESC, xItem.ID_PREVE)
                Sel_Prev_From.insertElem(xItem.PREVE_DESC, xItem.ID_PREVE)
                Sel_Prev_To.insertElem(xItem.PREVE_DESC, xItem.ID_PREVE)
            })

            fn_Init_Loading.trigger()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Data_View = new TOOL.class_AJAX(
        "Mant_Precios_Conv.aspx/Select_Data",
        (resp: TOOL.int_ajax_success) => {
            arrData = resp.d

            fn_Make_Table()
            Hide_Modal()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Data_Rec = new TOOL.class_AJAX(
        "Mant_Precios_Conv.aspx/Write_Data",
        (resp: TOOL.int_ajax_success) => {
            console.log("Guardado completado:")
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Export = new TOOL.class_AJAX(
        "Mant_Precios_Conv.aspx/Export",
        (resp: TOOL.int_ajax_success) => {
            let xURL: string
            xURL = resp.d

            if (xURL != null) {
                if (xURL.match(/^http(s?):\/\//gi) == null) {
                    xURL = "http://" + xURL
                }

                var xMsg = `<p>Se ha generado correctamente el archivo excel. `
                xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`
                $("#mdlExcel .modal-body").html(xMsg)

                window.open(xURL, "_blank")
            } else {
                var xMsg = `<p>No se ha generado ningún archivo debido a que la `
                xMsg += `búsqueda no retorna resultados.</p>`
                $("#mdlExcel .modal-body").html(xMsg)
            }
            
            $("#mdlExcel").modal()
            Hide_Modal()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Copy = new TOOL.class_AJAX(
        "Mant_Precios_Conv.aspx/Copy_Data",
        (resp: TOOL.int_ajax_success) => {
            Hide_Modal()
            $("#mdlCopySuccess").modal()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )
    
    //-----------------------------------------------------------------------------------------------------------------
    //--Declaraciones de Eventos---------------------------------------------------------------------------------------
    Btn_Search.click((Me: JQueryEventObject) => {
        let bolShowAll: boolean = false
        if (Chk_Filther.getValues().length > 0) {
            bolShowAll = Chk_Filther.getValues()[0]
        }

        modal_show()
        objAJAX_Data_View.requestNow({
            ID_PREV: Sel_Prev.getValue().value,
            ID_YEAR: Sel_Year.getValue().value,
            ALL_EXA: bolShowAll
        })
    })

    Btn_Export.click((Me: JQueryEventObject) => {
        let bolShowAll: boolean = false
        if (Chk_Filther.getValues().length > 0) {
            bolShowAll = Chk_Filther.getValues()[0]
        }

        modal_show()
        objAJAX_Export.requestNow({
            ID_PREV: Sel_Prev.getValue().value,
            ID_YEAR: Sel_Year.getValue().value,
            ALL_EXA: bolShowAll
        })
    })

    Btn_Confirm_Copy.click((Me: JQueryEventObject) => {
        let strText: string = `¿Desea copiar los valores desde <strong>${Sel_Prev_From.getValue().text}</strong>, año <strong>${Sel_Year_From.getValue().text}</strong> `
        strText += `hacia <strong>${Sel_Prev_To.getValue().text}</strong>, año <strong>${Sel_Year_To.getValue().text}</strong>?`

        $("#mdlConfirm .modal-body p").html(strText)
        $("#mdlConfirm").modal()
    })

    Btn_Copy.click((Me: JQueryEventObject) => {
        let bolTodos: boolean = false
        modal_show()

        console.log(Chk_Filther_2.getValues())
        if (Chk_Filther_2.getValues().length > 0) {
            bolTodos = true
        }

        objAJAX_Copy.requestNow({
            ID_PREV1: Sel_Prev_From.getValue().value,
            ID_YEAR1: Sel_Year_From.getValue().value,
            ID_PREV2: Sel_Prev_To.getValue().value,
            ID_YEAR2: Sel_Year_To.getValue().value,
            ALL: bolTodos
        })
    })

    $(document).ready(() => {
        modal_show()

        objAJAX_Year.requestNow()
        objAJAX_Prev.requestNow()

        $(window).resize(() => {
            let width: number = innerWidth

            if (width < 450) {
                $(`#mdlCopy .modal-body .view-2`).hide()
                $(`#mdlCopy .modal-body .view-3`).show()
                $(`#mdlCopy .modal-body .view-1`).removeClass("col-5")
                $(`#mdlCopy .modal-body .view-1`).addClass("col-12")
            } else {
                $(`#mdlCopy .modal-body .view-2`).show()
                $(`#mdlCopy .modal-body .view-3`).hide()
                $(`#mdlCopy .modal-body .view-1`).removeClass("col-12")
                $(`#mdlCopy .modal-body .view-1`).addClass("col-5")
            }
        })
        $(window).resize()
    })
}
