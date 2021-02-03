namespace GEST_GRAPHICS {
    interface iSelect {
        text: string;
        value: number;
    }
    interface iData_Ate_Proc {
        CANT_ATE: number;
        PROC_DESC: string;
    }
    interface iData_Ate_Prev {
        CANT_ATE: number;
        PREV_DESC: string;
    }
    interface iData_Exam_Proc_Prev {
        CANT_EXAM: number;
        ID_ESTADO: number;
        EST_COD: string;
        EST_DESCRIPCION: string;
    }

    let fnError = (fail: any) => {
        $("#mdlError").modal()
        console.log(fail)
        console.log()
    }
    namespace ALERT {
        let build = (id: string, color: string, title: string, message: string, footer: string = null) => {
            let strBody: string

            if (footer != null) {
                strBody = `
                    <h4 class="alert-heading">${title}</h4>
                    <p>${message}</p>
                    <hr />
                    <p class="m-0">${footer}</p>
                `
            } else {
                strBody = `
                    <h4 class="alert-heading">${title}</h4>
                    <hr />
                    <p class="m-0">${message}</p>
                `
            }

            $(`#${id}`).empty()
            $(`#${id}`).append(
                $(`<div>`, {
                    class: `alert alert-${color} m-2`
                }).html(strBody)
            )
        }

        export let empty = (idElem: string, title: string) => {
            build(
                idElem,
                'secondary',
                title,
                `Actualmente no hay datos con la información solicitada para la fecha actual.`
            )
        }
    }
    namespace GRAPH {
        export interface iGraphData {
            text: string,
            value: number;
        }

        let build = (id: string, title: string, options: __Highcharts.Options) => {
            let base: JQuery = $(`#${id}`)

            //Armar Tarjeta
            base.empty()
            //base.append(
            //    $("<div>", { class: "card" }).append(
            //        $("<div>", {
            //            id: `HC_${id}`,
            //            class: "card-body"
            //        })
            //    )
            //)

            //Armar Gráfico
            Highcharts.chart(id, options)

            
        }

        export let graphBar = (options: {
            idElem: string;
            title: string;
            label_y: string;
            popover: string;
            data: Array<iGraphData>;
        }) => {
            let arrData: Array<Array<string|number>> = []

            //Armar Datos
            options.data.forEach((item, i) => {
                arrData.push([
                    item.text,
                    item.value
                ])
            })

            //Armar configuración
            let objHC: __Highcharts.Options = {
                credits: {
                    href: location.origin,
                    text: 'IrisLAB Web'
                },
                chart: {
                    type: 'column'
                },
                title: {
                    text: options.title
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    type: 'category',
                    labels: {
                        //rotation: -45,
                        style: {
                            fontSize: '10px',
                            fontFamily: 'Verdana, sans-serif',
                        }
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: options.label_y
                    }
                },
                legend: {
                    layout: 'horizontal',
                    enabled: false
                },
                tooltip: {
                    pointFormat: options.popover
                },
                plotOptions: {
                    series: {
                        color: (() => {
                            let rnd: number = Math.random()

                            if (rnd <= (1 / 3)) {
                                return "#e50000"
                            } else if ((rnd > (1 / 3)) && (rnd <= (2 / 3))) {
                                return "#e8890d"
                            } else {
                                return "#541d82"
                            }
                        })()
                    }
                },
                series: [{
                    name: 'Population',
                    data: arrData
                }]
            }

            //Armar gráfico
            build(options.idElem, options.title, objHC)
        }

        export let graphPie = (options: {
            idElem: string;
            title: string;
            label_y: string;
            popover: string;
            data: Array<iGraphData>;
        }) => {
            let arrData: Array<{
                name: string;
                y: number;
                sliced?: boolean;
                selected?: boolean;
            }> = []

            //Armar Datos
            options.data.forEach((item, i) => {
                arrData.push({
                    name: item.text,
                    y: item.value
                })
            })

            //Armar configuración
            let objHC: __Highcharts.Options = {
                credits: {
                    href: location.origin,
                    text: 'IrisLAB Web'
                },
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: options.title
                },
                tooltip: {
                    pointFormat: options.popover
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: options.label_y,
                    colorByPoint: true,
                    data: arrData
                }]
            }

            //Armar gráfico
            build(options.idElem, options.title, objHC)
        }
    }

    let btnRefresh = new H.Ts_Button("btnRefresh")
    let txtDate1 = new H.Ts_Textbox("txtDate1")
    let txtDate2 = new H.Ts_Textbox("txtDate2")
    let selProc = new H.Ts_Select("selProc")
    let selPrev = new H.Ts_Select("selPrev")

    txtDate1.datePicker = true
    txtDate2.datePicker = true
    txtDate1.locked = true
    txtDate2.locked = true

    let ajaxProc = new U.Ajax()
    ajaxProc.functName = "GET_Proc"
    ajaxProc.error = fnError
    ajaxProc.success = (resp) => {
        let arrData: Array<iSelect> = resp.d

        selProc.clean()
        arrData.forEach(item => {
            selProc.addItem(item.text, item.value)
        })
    }

    let ajaxPrev = new U.Ajax()
    ajaxPrev.functName = "GET_Prev"
    ajaxPrev.error = fnError
    ajaxPrev.success = (resp) => {
        let arrData: Array<iSelect> = resp.d

        selPrev.clean()
        arrData.forEach(item => {
            selPrev.addItem(item.text, item.value)
        })
    }

    let ajaxGraph_Ate_Proc = new U.Ajax()
    ajaxGraph_Ate_Proc.functName = "GET_Cant_Ate_byProc"
    ajaxGraph_Ate_Proc.error = fnError
    ajaxGraph_Ate_Proc.success = (resp) => {
        let arrData: Array<iData_Ate_Proc> = resp.d

        if (arrData.length == 0) {
            ALERT.empty('graphAteProcBar', 'Atenciones por Procedencia')
            ALERT.empty('graphAteProcPie', 'Atenciones por Procedencia')
            return
        }

        let arrValues: Array<GRAPH.iGraphData> = []
        arrData.forEach(item => {
            arrValues.push({
                text: item.PROC_DESC,
                value: item.CANT_ATE
            })
        })

        GRAPH.graphBar({
            idElem: 'graphAteProcBar',
            title: 'Atenciones Por Procedencia',
            label_y: 'Cantidad Atenc.',
            popover: 'Cant Ate: <b>{point.y:.0f}</b>',
            data: arrValues
        })

        GRAPH.graphPie({
            idElem: 'graphAteProcPie',
            title: 'Atenciones Por Procedencia',
            label_y: 'Cantidad Atenc.',
            popover: `{series.name}: <b>{point.percentage:.1f}%</b>`,
            data: arrValues
        })
    }

    let ajaxGraph_Ate_Prev = new U.Ajax()
    ajaxGraph_Ate_Prev.functName = "GET_Cant_Ate_byPrev"
    ajaxGraph_Ate_Prev.error = fnError
    ajaxGraph_Ate_Prev.success = (resp) => {
        let arrData: Array<iData_Ate_Prev> = resp.d

        if (arrData.length == 0) {
            ALERT.empty('graphAtePrevBar', 'Atenciones por Previsión')
            ALERT.empty('graphAtePrevPie', 'Atenciones por Previsión')
            return
        }

        let arrValues: Array<GRAPH.iGraphData> = []
        arrData.forEach(item => {
            arrValues.push({
                text: item.PREV_DESC,
                value: item.CANT_ATE
            })
        })

        GRAPH.graphBar({
            idElem: 'graphAtePrevBar',
            title: 'Atenciones Por Previsión',
            label_y: 'Cantidad Atenc.',
            popover: 'Cant Ate: <b>{point.y:.0f}</b>',
            data: arrValues
        })
        
        GRAPH.graphPie({
            idElem: 'graphAtePrevPie',
            title: 'Atenciones Por Previsión',
            label_y: 'Cantidad Atenc.',
            popover: `{series.name}: <b>{point.percentage:.1f}%</b>`,
            data: arrValues
        })
    }

    let ajaxGraph_Exam_Proc_Prev = new U.Ajax()
    ajaxGraph_Exam_Proc_Prev.functName = "GET_Cant_Exa_byProc_byPrev"
    ajaxGraph_Exam_Proc_Prev.error = fnError
    ajaxGraph_Exam_Proc_Prev.success = (resp) => {
        let arrData: Array<iData_Exam_Proc_Prev> = resp.d

        if (arrData.length == 0) {
            ALERT.empty('graphExaProcPrevBar', 'Exámenes por Estado de Validac.')
            ALERT.empty('graphExaProcPrevPie', 'Exámenes por Estado de Validac.')
            return
        }

        let arrValues: Array<GRAPH.iGraphData> = []
        arrData.forEach(item => {
            arrValues.push({
                text: item.EST_DESCRIPCION,
                value: item.CANT_EXAM
            })
        })

        GRAPH.graphBar({
            idElem: 'graphExaProcPrevBar',
            title: 'Exámenes Por Estado Validac.',
            label_y: 'Cant. de Exámenes',
            popover: 'Cant Exám: <b>{point.y:.0f}</b>',
            data: arrValues
        })

        GRAPH.graphPie({
            idElem: 'graphExaProcPrevPie',
            title: 'Exámenes Por Estado Validac.',
            label_y: 'Cant. de Exámenes',
            popover: `{series.name}: <b>{point.percentage:.1f}%</b>`,
            data: arrValues
        })
    }

    H.form.load = () => {
        ALERT.empty('graphAteProcBar', 'Atenciones por Procedencia')
        ALERT.empty('graphAteProcPie', 'Atenciones por Procedencia')
        ALERT.empty('graphAtePrevBar', 'Atenciones por Previsión')
        ALERT.empty('graphAtePrevPie', 'Atenciones por Previsión')
        ALERT.empty('graphExaProcPrevBar', 'Exámenes por Estado de Validac.')
        ALERT.empty('graphExaProcPrevPie', 'Exámenes por Estado de Validac.')

        ajaxProc.requestNow(null, () => {
            selProc.eventChange = (me) => {
                let value = selProc.value
                ajaxPrev.requestNow({ ID_PROC: value })
            }

            ajaxPrev.requestNow({ ID_PROC: 0 }, () => {
                //Llenar Gráficos
                ajaxGraph_Ate_Proc.requestNow({
                    DATE_01: txtDate1.value,
                    DATE_02: txtDate1.value,
                    ID_PROC: selProc.value,
                    ID_PREV: selPrev.value
                })
                ajaxGraph_Ate_Prev.requestNow({
                    DATE_01: txtDate1.value,
                    DATE_02: txtDate1.value,
                    ID_PROC: selProc.value,
                    ID_PREV: selPrev.value
                })
                ajaxGraph_Exam_Proc_Prev.requestNow({
                    DATE_01: txtDate1.value,
                    DATE_02: txtDate1.value,
                    ID_PROC: selProc.value,
                    ID_PREV: selPrev.value
                })
            })
        })
    }

    btnRefresh.eventClick = () => {
        ajaxGraph_Ate_Proc.requestNow({
            DATE_01: txtDate1.value,
            DATE_02: txtDate1.value,
            ID_PROC: selProc.value,
            ID_PREV: selPrev.value
        })
        ajaxGraph_Ate_Prev.requestNow({
            DATE_01: txtDate1.value,
            DATE_02: txtDate1.value,
            ID_PROC: selProc.value,
            ID_PREV: selPrev.value
        })
        ajaxGraph_Exam_Proc_Prev.requestNow({
            DATE_01: txtDate1.value,
            DATE_02: txtDate1.value,
            ID_PROC: selProc.value,
            ID_PREV: selPrev.value
        })
    }
}