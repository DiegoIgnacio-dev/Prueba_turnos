<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx.vb" Inherits="Presentacion.Resumen_Prev_Prog_Subp_Scr_3_Glob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../../../js/HighCharts.js"></script>
    <script src="../../../js/highcharts-more.js"></script>
    <script src="../../../js/modules/sunburst.js"></script>
    <script src="../../../js/HighC_Exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _cont_mod = 0;
        $(document).ready(() => {
            // modal_show();
            $("#div_tabla_graph").hide();
            $("#Div_Tabla_Tot").hide();
            let dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);
            $('#Txt_Date01, #Txt_Date02').datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd-mm-yyyy',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minDate: Date.now(),
                minView: 2
            });
            Ajax_LugarTM();
            Ajax_Preve();

            $("#Ddl_Preve").change(()=>{
                Ajax_Usu();
            });

            $("#btn_Buscar_by_Exam").click(() => {
                Ajax_DataTable_by_Exam();
            });

            $("#btn_Buscar").click(() => {
                Ajax_DataTable();
            });

            $("#btn_Excel").click(() => {
                Ajax_Excel();
            });

            $("#btn_Excel_by_Exam").click(() => {
                Ajax_Excel_by_Exam();
            });

            $("#btn_Excel_modal").click(() => {     //MODAL EXCEL
                $("#modal_Excel").modal();
            });

            $("#btn_Pdf_modal").click(() => {
                $("#modal_pdf").modal();
            });

            $("#btn_Pdf").click(() => {
                Ajax_PDF();
            });

            $("#btn_Pdf_by_exam").click(() => {
                Ajax_PDF_by_Exam();
        
            });
        });

        function c_modal() {
            if (_cont_mod == 3) {
                Hide_Modal();
            }
        }

        let Mx_Dtt_LugarTM = [{
            "ID_ESTADO": 0,
            "PROC_DESC": 0,
            "PROC_COD": 0,
            "ID_PROCEDENCIA": 0
        }];
        function Ajax_LugarTM() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_LugarTM = json_receiver;
                        Fill_Ddl_LugarTM();
                    } else {
                    
                    }
                },
                "error": function (response) {
                
                }
            });
        }
        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();



            var procee = Galletas.getGalleta("USU_ID_PROC");
            var ide_admin = Galletas.getGalleta("P_ADMIN");

            if (ide_admin == 1) {
                console.log("admin");
                Mx_Dtt_LugarTM.forEach(aaa => {
                            $("<option>",{"value": aaa.ID_PROCEDENCIA}).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                        });
            } else {
                Mx_Dtt_LugarTM.forEach(aaa => {

                    if (aaa.ID_PROCEDENCIA == 341 || aaa.ID_PROCEDENCIA == 368) {
                        $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }                 
                        });
            }

            //if (procee == 0) {

            //    Mx_Dtt_LugarTM.forEach(aaa => {
            //        $("<option>",
            //            {
            //                "value": aaa.ID_PROCEDENCIA
            //            }
            //        ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
            //    });
            //}
            //else {
            //    Mx_Dtt_LugarTM.forEach(aaa => {
            //        if (aaa.ID_PROCEDENCIA == procee) {
            //            $("<option>",
            //              {
            //                  "value": aaa.ID_PROCEDENCIA
            //              }
            //           ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
            //        }

            //    });
            //}

            _cont_mod += 1;
            c_modal();
        };

        let Mx_Dtt_Preve = [{
            "ID_ESTADO": 0,
            "PREVE_DESC": 0,
            "PREVE_COD": 0,
            "ID_PREVE": 0
        }];
        function Ajax_Preve() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Llenar_Ddl_Prevision",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Preve = json_receiver;
                        Fill_Ddl_Preve();
                    } else {
                 
                    }
                },
                "error": function (response) {
           
                }
            });
        }
        function Fill_Ddl_Preve() {
            $("#Ddl_Preve").empty();


            var preveee = Galletas.getGalleta("USU_PREV");

            if (preveee == 0) {

                Mx_Dtt_Preve.forEach(aaa => {
                    $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Preve");

                    $("<option>",
                        {
                            "value": aaa.ID_PREVE
                        }
                    ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
                });
            }
            else {
                Mx_Dtt_Preve.forEach(aaa => {
                    if (aaa.ID_PREVE == preveee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PREVE
                          }
                       ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
                    }

                });
            }

            _cont_mod += 1;
            c_modal();
            Ajax_Usu();
        };

        let Mx_Dtt_Usu = [{
            "ID_USUARIO": 0,
            "USU_NOMBRE": 0,
            "USU_APELLIDO": 0,
            "USU_NIC": 0
        }];



        function Ajax_Usu() {

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Call_User_Data",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Usu = json_receiver;
                        Fill_Ddl_Usu();
                    } else {
                      
                    }
                },
                "error": function (response) {
                 
                }
            });
        }

        let Mx_Dtt_Progra = [{
            "ID_ESTADO": 0,
            "PROGRA_DESC": 0,
            "PROGRA_COD": 0,
            "ID_PROGRA": 0
        }];
        function Ajax_Progra() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Llenar_Ddl_Programa",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Progra = json_receiver;
                        Fill_Ddl_Progra();
                    } else {
               
                    }
                },
                "error": function (response) {
                
                }
            });
        }
        function Fill_Ddl_Progra() {
            $("#Ddl_Progra").empty();

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Ddl_Progra");
            Mx_Dtt_Progra.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PROGRA
                    }
                ).text(aaa.PROGRA_DESC).appendTo("#Ddl_Progra");
            });
            _cont_mod += 1;
            c_modal();
        };

        function Fill_Ddl_Usu() {
            $("#Ddl_Usu").empty();
        
            var usuaidiiii = Galletas.getGalleta("ID_USER");

            Mx_Dtt_Usu.forEach(aaa => {
                if (usuaidiiii == aaa.ID_USUARIO) {
                    $("<option>",
                        {
                            "value": aaa.ID_USUARIO
                        }
                    ).text(aaa.USU_NIC + " " + aaa.USU_NOMBRE + " " + aaa.USU_APELLIDO).appendTo("#Ddl_Usu");
                }


            });
        };


        let Mx_Dtt = [{
            ID_ATENCION: "",
            ATE_NUM:"",
            ATE_FECHA:"",
            ATE_TOTAL:"",
            ATE_TOTAL_PREVI:"",
            ATE_TOTAL_COPA:"",
            ATE_V_SISTEMA:"",
            ATE_V_BENEF:"",
            ATE_V_CF:"",				//COPAGO
            ATE_V_CF_FP:"",			    //TP COPAGO
            ATE_V_CP:"",				//PARTICULAR
            ATE_V_CP_FP:"",			    //TP PARTICULAR
            ATE_V_BOLETA:"",
            ATE_V_PAGADO:"",
            ID_PROCEDENCIA:"", 
            PROC_DESC:"",
            ID_PREVE:"",   
            PREVE_DESC:"",
            ID_USUARIO:"",
            USU_NIC:"",
            USU_NOMBRE:"",
            USU_APELLIDO:"",
            ID_PACIENTE:"",
            PAC_NOMBRE:"",
            PAC_APELLIDO:"",
            ID_TP_PAGO_COPAGO_1:"",
            REL_MONTO_COPAGO_1:"",
            ID_TP_PAGO_COPAGO_2:"",
            REL_MONTO_COPAGO_2:"",
            ID_TP_PAGO_PARTICULAR:"",
            REL_MONTO_PARTICULAR:"",
            ID_TP_PAGO_PARTICULAR_2:"",
            REL_MONTO_PARTICULAR_2:"",
            ID_TP_COPAGO: "",
            ATE_V_BENEF:""
        }];
        function Ajax_DataTable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "ID_USER": $("#Ddl_Usu").val()
            });
            //console.log(Data_Par);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        //$("#graph").show();
                        $("#div_tabla_graph").show();

                        $("#Div_Tabla_Tot").show();
                    } else {
              
                        $("#Div_Tabla").empty();
                        $("#graph").hide();
                        $("#div_tabla_graph").hide();
                        $("#Div_Tabla_Tot").hide();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
               
                    $("#Div_Tabla").empty();
                    $("#graph").hide();
                    Hide_Modal();
                }
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        function Fill_DataTable() {
            $("#Div_Tabla").empty();

            //$("#Div_Tabla").html("<div class='row'><div class='col-lg'><h4 class='text-danger pl-3'>Valorización Total: $<span id='val_total'></span></h4></div><div class='col-lg'><h4>Atenciones: <span id='tot_at'></span> - Exámenes Validados: <span id='tot_cf'></span> </h4></div></div>");

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),              
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Paciente Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Total Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Total Sistema"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_TOTAL_COPA"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_SISTEMA"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_BENEF"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_CF"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_CF_FP"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_CP"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_CP_FP"),
                    $("<th>", { "class": "textoReducido" }).text("Num. Boleta"),
                    $("<th>", { "class": "textoReducido" }).text("ATE_V_PAGADO"),
                    $("<th>", { "class": "textoReducido" }).text("FP. Copago 1"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido " }).text("Total Copago 1"),
                    $("<th>", { "class": "textoReducido" }).text("FP. Copago 2"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido " }).text("Total Copago 2"),
                    $("<th>", { "class": "textoReducido" }).text("FP. Particular 1"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido " }).text("Total Particular 1"),
                    $("<th>", { "class": "textoReducido" }).text("FP. Particular 2"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido " }).text("Total Particular 2"),
                    $("<th>", { "class": "textoReducido" }).text("Descuentos"),
                    $("<th>", { "id": "a-right" }, { "class": "textoReducido " }).text("TOTAL"),
                    $("<th>", { "class": "textoReducido" }, { "align": "right" }, { "text-align": "right" }).text("Documentos")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)`,
                        //"ondblclick": `Ajax_ONCLICK_2("` + Mx_Dtt[i].ID_USUARIO + `","` + Mx_Dtt[i].ID_ATENCION + `",)`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt[i].ATE_FECHA).format("DD-MM-YYYY HH:mm")),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NIC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_TOTAL)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_TOTAL_PREVI)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_TOTAL_COPA)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_SISTEMA)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_BENEF)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_CF)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_CF_FP)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_CP)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_CP_FP)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_V_BOLETA),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_PAGADO)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].REL_MONTO_COPAGO_1 == "0") {
                                return "-";
                            } else {
                                if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 1) {
                                    return "Efectivo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 2) {
                                    return "Cheque";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 3) {
                                    return "Pendiente";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 4) {
                                    return "Bono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 5) {
                                    return "Bono Electronico";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 11) {
                                    return "Sin Costo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 18) {
                                    return "Abono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 19) {
                                    return "Convenio";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 20) {
                                    return "Transferencia";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_1 == 10) {
                                    return "Tarjeta";
                                }

                            }                          

                        }),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].REL_MONTO_COPAGO_1)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].REL_MONTO_COPAGO_2 == "0") {
                                return "-";
                            } else {
                                if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 1) {
                                    return "Efectivo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 2) {
                                    return "Cheque";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 3) {
                                    return "Pendiente";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 4) {
                                    return "Bono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 5) {
                                    return "Bono Electronico";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 11) {
                                    return "Sin Costo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 18) {
                                    return "Abono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 19) {
                                    return "Convenio";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 20) {
                                    return "Transferencia";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_COPAGO_2 == 10) {
                                    return "Tarjeta";
                                }
                            }                      

                        }),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" +  addCommas(Mx_Dtt[i].REL_MONTO_COPAGO_2)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].REL_MONTO_PARTICULAR == "0") {
                                return "";
                            }else{
                                if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 1) {
                                    return "Efectivo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 2) {
                                    return "Cheque";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 3) {
                                    return "Pendiente";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 4) {
                                    return "Bono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 5) {
                                    return "Bono Electronico";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 11) {
                                    return "Sin Costo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 18) {
                                    return "Abono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 19) {
                                    return "Convenio";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 20) {
                                    return "Transferencia";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR == 10) {
                                    return "Tarjeta";
                                }
                            }
                        }),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].REL_MONTO_PARTICULAR)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].REL_MONTO_PARTICULAR_2 == "0") {
                                return "";
                            } else {
                                if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 1) {
                                    return "Efectivo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 2) {
                                    return "Cheque";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 3) {
                                    return "Pendiente";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 4) {
                                    return "Bono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 5) {
                                    return "Bono Electronico";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 11) {
                                    return "Sin Costo";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 18) {
                                    return "Abono";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 19) {
                                    return "Convenio";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 20) {
                                    return "Transferencia";
                                } else if (Mx_Dtt[i].ID_TP_PAGO_PARTICULAR_2 == 10) {
                                    return "Tarjeta";
                                }
                            }
                        }),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].REL_MONTO_PARTICULAR_2)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_V_BENEF)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas((parseInt(Mx_Dtt[i].REL_MONTO_COPAGO_1) + parseInt(Mx_Dtt[i].REL_MONTO_COPAGO_2) + parseInt(Mx_Dtt[i].REL_MONTO_PARTICULAR) + parseInt(Mx_Dtt[i].REL_MONTO_PARTICULAR_2) + parseInt(Mx_Dtt[i].ATE_V_BENEF)))),
                        //$("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "right" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].TOT_VAL)),
                        $("<td>", { "align": "right" }, { "class": "textoReducido" }).text(function () {
                            $(this).append("<button type='button' class='btn btn-info btn-sm' onclick='Ajax_ONCLICK_2(" + Mx_Dtt[i].ID_USUARIO + "," + Mx_Dtt[i].ID_ATENCION + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver</button>");
                        })


                    )
                );
            }
            //$("#DataTable").DataTable({
            //    "bSort": false,
            //    "iDisplayLength": 100,
            //    "info": false,
            //    "bPaginate": false,
            //    //"bFilter": false,
            //    "language": {
            //        "lengthMenu": "Mostrar: _MENU_",
            //        "zeroRecords": "No hay coincidencias",
            //        "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            //        "infoEmpty": "No hay concidencias",
            //        "infoFiltered": "(Se busco en _MAX_ registros )",
            //        "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
            //        "paginate": {
            //            "previous": "Anterior",
            //            "next": "Siguiente"
            //        }
            //    }
            //});


            //$("#a-right").css("text-align", "right");
            let _v_total = 0;
            let t_att = 0;
            let t_exx = 0;
            Mx_Dtt.forEach(aah=> {
                _v_total += aah.TOT_VAL;
                t_att += aah.TOT_ATE;
                t_exx += aah.TOT_CF;
            });
            $("#val_total").text(addCommas(_v_total));
            $("#tot_at").text(t_att);
            $("#tot_cf").text(t_exx);
            

            let copaaaa = 0;
            let partiiii = 0;
            let desccc = 0;

            Mx_Dtt.forEach(aah=> {
                copaaaa += parseInt(aah.REL_MONTO_COPAGO_1) + parseInt(aah.REL_MONTO_COPAGO_2);
                partiiii += parseInt(aah.REL_MONTO_PARTICULAR) + parseInt(aah.REL_MONTO_PARTICULAR_2);
                desccc += parseInt(aah.ATE_V_BENEF);
            });

            Hide_Modal();


            $("#Div_Tabla_Tot").empty();

            //$("#Div_Tabla").html("<div class='row'><div class='col-lg'><h4 class='text-danger pl-3'>Valorización Total: $<span id='val_total'></span></h4></div><div class='col-lg'><h4>Atenciones: <span id='tot_at'></span> - Exámenes Validados: <span id='tot_cf'></span> </h4></div></div>");

            $("<table>", {
                "id": "DataTable_Tot",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Tot");

            $("#DataTable_Tot").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Tot").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Tot thead").attr("class", "cabzera");
            $("#DataTable_Tot thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Total Atenciones"),
                    $("<th>", { "align": "right" },{ "class": "textoReducido " }).text("Total Copago"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Particular"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Descuentos")
                )
            );

                $("#DataTable_Tot tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt.length),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(copaaaa)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(partiiii)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(desccc))
                    )
                );
            
            
            Hide_Modal();

            do_Chart_1();


        }



        function Ajax_ONCLICK(_PROG) {
            var loc = location.origin;
            window.open(loc + "/Gest_Financ/Estadisticas/Detalle/Det_Proc_Prev_Prog_Scr_2.aspx?&P3=" + _PROG);
        }

        function Ajax_ONCLICK_2(ID_USU, ID_ATE) {
            var loc = location.origin;
            window.open(loc + "/Scan_Docs/Ver_Orden.aspx?IDU=" + ID_USU + "&IDA=" + ID_ATE);
        }

        function do_Chart_1() {
   
            let Mx_Tot = [];
            let Mx_Data = [];
            let Mx_Cate = [];
            let Cant_Tot = 0;

            //for (i = 0; i < Mx_Dtt.length; i++) {
            //    if (Mx_Tot.length == 0) {
            //        Mx_Tot.push({ CF_DESC: Mx_Dtt[i].CF_DESC, CANT: "" });
            //    } else {
            //        let bool = 0;

            //        Mx_Tot.forEach(aah=> {
            //            if (aah.CF_DESC == Mx_Dtt[i].CF_DESC) {
            //                bool = 1;
            //            }
            //        });

            //        if (bool == 0) {
            //            Mx_Tot.push({ CF_DESC: Mx_Dtt[i].CF_DESC, CANT: "" });
            //        }
            //    }
            //}

            //for (y = 0; y < Mx_Tot.length; y++) {
            //    let cont = 0;
            //    Mx_Dtt.forEach(aah=> {
            //        if (Mx_Tot[y].CF_DESC == aah.CF_DESC) {
            //            cont += parseInt(aah.CF_PRECIO_AMB);
            //        }
            //    });
            //    Mx_Tot[y].CANT = cont;
            //}

            let tota_copa = 0;
            let tota_parti = 0;
            let dessssscccccc = 0;

            //Mx_Tot.forEach(aah=> {
            //    Mx_Data.push(aah.CANT);
            //    Mx_Cate.push(aah.CF_DESC);
            //});

            //console.log(Mx_Tot);

            //Mx_Tot.forEach(aah=> {
            //    Mx_Data.push(aah.CANT);
            //    Mx_Cate.push(aah.CF_DESC);
            //});

            Mx_Dtt.forEach(aah=> {
                tota_copa += parseInt(aah.REL_MONTO_COPAGO_1) + parseInt(aah.REL_MONTO_COPAGO_2);
                tota_parti += (parseInt(aah.REL_MONTO_PARTICULAR) + parseInt(aah.REL_MONTO_PARTICULAR_2));
                dessssscccccc += parseInt(aah.ATE_V_BENEF);
            });

            let BUUM = parseInt(tota_copa) + parseInt(tota_parti) + parseInt(dessssscccccc);
   

            //Cant_Tot = addCommas(Cant_Tot);
            //$("#val_total").text(Cant_Tot);
            Highcharts.setOptions({
                lang: {
                    thousandsSep: '.'
                }
            })

            Highcharts.chart('chrt_1', {
                chart: {
                    type: 'column',
                    height: '50%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Valorización de Exámenes Copago/Particular',
                    margin: 50
                },
                subtitle: {
                    text: 'Total:  $' + addCommas(BUUM)
                    ,
                    style: {
                        color: '#ff0000',
                        fontWeight: 'bold'
                    }
                },
                xAxis: {
                    categories: [
                    'Copago',
                    'Particular',
                    'Descuentos'
                    ],
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Total (CLP)'
                    },
                    stackLabels: {
                        enabled: true,
                        format: '${total:,.0f}'
                    },
                    labels: {
                        format: "${value:,.0f}"
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr>' +
                        '<td style="padding:0"><b>${point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    series: {
                        colorByPoint: true,
                        dataLabels: {
                            enabled: true,
                            format: '${point.y:,.0f}',
                            rotation: -90,
                            y: -40,
                            color: "#666666",
                            crop: false
                        }
                    },
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    showInLegend: false,
                    name: 'platita',
                    data: [tota_copa, tota_parti, dessssscccccc]
                }]
            });
            
        }

        function addCommas(nStr) {
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + '.' + '$2');
            }
            return x1 + x2;
        }

        function Ajax_Excel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": 0,//$("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val(),
                "ID_USER": $("#Ddl_Usu").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Hide_Modal();
                        window.open(json_receiver, 'Download');
                    } else {
                        Hide_Modal();
              
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                
                }
            });
        }

        function Ajax_Excel_by_Exam() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": 0,//$("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val(),
                "ID_USER": $("#Ddl_Usu").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/Gen_Excel_by_Exam",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Hide_Modal();
                        window.open(json_receiver, 'Download');
                    } else {
                        Hide_Modal();
                  
                    }
                },
                "error": function (response) {
                    Hide_Modal();
     
                }
            });
        }

        let Mx_Dtt_PDF_by_Exam = [{
            "urls": ""
        }];

        function Ajax_PDF_by_Exam() {
            modal_show();

            let Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": 0,//$("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val(),
                "ID_USER": $("#Ddl_Usu").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/PDFF_by_Exam",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo PDF. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        let Mx_Dtt_PDF = [{
            "urls": ""
        }];

        function Ajax_PDF() {
            modal_show();

            let Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": 0,//$("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "PROG": 0,//$("#Ddl_Progra").val(),
                "SUBP": 0,//$("#Ddl_Subp").val(),
                "ID_USER": $("#Ddl_Usu").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx/PDFF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo PDF. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
    </script>
    <style>
        .manito {
            cursor:pointer;
        }
    </style>

        <!-- Modal Excel -->
    <div id="modal_Excel" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Excel</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, qué formato desea exportar?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Excel_by_Exam" class="btn btn-success"><i class="fa fa-file-excel-o fa-fw"></i>Por Exámenes</button>
                    <button type="button" id="btn_Excel223232323" class="btn btn-success"><i class="fa fa-file-excel-o fa-fw"></i>Por Atenciones</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

            <!-- Modal PDF -->
    <div id="modal_pdf" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">PDF</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, qué formato desea exportar?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Pdf_by_exam" class="btn btn-warning"><i class="fa fa-file-text-o fa-fw"></i>Por Exámenes</button>
                    <button type="button" id="btn_Pdf7372873" class="btn btn-warning"><i class="fa fa-file-text-o fa-fw"></i>Por Atenciones</button>                
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <div class="card border-bar">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Secretaria Resumen Atenciones Global</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">
                    <label for="fecha2">Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg">    
                    <label>Procedencia</label>
                    <select id="Ddl_LugarTM" class="form-control form-control-sm">
                        <%--<option value="0">Todos</option>--%>
                    </select>
                </div>
                <div class="col-lg">
                    <label>Previsión</label>
                    <select id="Ddl_Preve" class="form-control form-control-sm">
                        <%--<option value="0">Todos</option>--%>
                    </select>
                </div>
                <div class="col-lg">
                    <label>Usuario</label>
                    <select id="Ddl_Usu" class="form-control form-control-sm">
                        <%--<option value="0">Todos</option>--%>
                    </select>
                </div>
                <div class="col-lg">
                    <br />
                </div>
<%--                <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Buscar_by_Exam" class="btn btn-buscar btn-block btn-sm"><i class="fa fa-search fa-fw"></i>Buscar por Examen</button>
                </div>--%>
                <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Buscar" class="btn btn-buscar btn-block btn-sm"><i class="fa fa-search fa-fw"></i>Buscar</button>
                </div>
                 <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Excel" class="btn btn-success btn-block btn-sm"><i class="fa fa-file-excel-o fa-fw"></i>Excel</button>
                </div>
                <div class="col-lg mb-1">
                     <br />
                    <button type="button" id="btn_Pdf" class="btn btn-warning btn-block btn-sm"><i class="fa fa-file-text-o fa-fw"></i>PDF</button>
                </div>
            </div>
        </div>
    </div>
    <div id="Div_Tabla" class="mt-3" style="overflow: auto">
    </div>
        <div id="Div_Tabla_Tot" class="mt-3" style="overflow: auto">
    </div>
        <div class="card border-bar mt-3" id="div_tabla_graph">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Gráficos</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <div id="chrt_1"></div>
                </div>
            </div>
            <hr />
        </div>
    </div>
<%--    <div id="graph" class="mt-3">
    </div>--%>
</asp:Content>
