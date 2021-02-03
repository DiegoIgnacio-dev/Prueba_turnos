<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Resumen_Mod_TP_Pago.aspx.vb" Inherits="Presentacion.Resumen_Mod_TP_Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../../../js/Deep-Copy.js"></script>
    <script src="../../../js/HighCharts.js"></script>
    <script src="../../../js/highcharts-more.js"></script>
    <script src="../../../js/modules/sunburst.js"></script>
    <script src="../../../js/HighC_Exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _cont_mod = 0;
        let search_mode = 69;

        let IIDD_AATTEE = 0;
        let AATTEE_NNUUMM = 0;
        let aaaaiiiiiddddiiiiooouuuu = 0;


        let aidi_ate_owo = 0;
        let ate_num_owo = 0;
        let aidi_usuario_owo = 0;

        function format_toCLP(AAAAAA) {
            var num = AAAAAA;
            if (!isNaN(num)) {
                num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
                num = num.split('').reverse().join('').replace(/^[\.]/, '');
                return num;
                //input.value = num;
            }
        }

        var GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
        var GLOBAL_TOT_PREVISION = 0;
        var GLOBAL_TOT_FONASA = 0;
        var GLOBAL_TOT_COPA_PART = 0;
        var GLOBAL_TOT_PREVISION = 0;
        var GLOBAL_TOT_BENEFICIARIO = 0;
        var GLOBAL_TOT_A_PAGAR = 0;

        var PASS_SAVE = 1;

        function HOLAAAAAAAAAAA() {
            //console.log("entra en holaaaa");
            GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
            GLOBAL_TOT_PREVISION = 0;
            GLOBAL_TOT_FONASA = 0;
            GLOBAL_TOT_COPA_PART = 0;
            GLOBAL_TOT_PREVISION = 0;
            GLOBAL_TOT_BENEFICIARIO = 0;
            GLOBAL_TOT_A_PAGAR = 0;

            var asdasd = 0;
            asdasd.toLocaleString

            $(`.td_scomplementario`).each(function () {

                GLOBAL_TOT_SEGURO_COMPLEMENTARIO += parseInt(this.value);

                if (isNaN(GLOBAL_TOT_SEGURO_COMPLEMENTARIO)) {

                }

            });

            $(`.td_prevision`).each(function () {
                GLOBAL_TOT_PREVISION += parseInt(this.value);
            });

            $(`.td_valorapagar`).each(function () {
                let tipo = $(this).attr("data-tipo");


                if (tipo == 1 || tipo == "1" || tipo == 20 || tipo == "20") {
                    GLOBAL_TOT_COPA_PART += parseInt(this.value);
                } else {
                    GLOBAL_TOT_FONASA += parseInt(this.value);
                }

                GLOBAL_TOT_A_PAGAR += parseInt(this.value);
            });

            $(`.td_valorBeneficiario`).each(function () {
                GLOBAL_TOT_BENEFICIARIO += parseInt(this.value);
            });

            $("#Lbl_tot_a_pagar").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA)));
            $("#lbl_Tot_Pagar_Modal").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA)));  //MODAL

            $("#Lbl_tot_prevision").val(format_toCLP(GLOBAL_TOT_PREVISION));

            $("#Lbl_tot_beneficiario").val(format_toCLP(GLOBAL_TOT_SEGURO_COMPLEMENTARIO));

            $("#Lbl_tot_copa_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA));
            $("#lbl_Tot_Fonasa_Modal").val(format_toCLP(GLOBAL_TOT_FONASA));  //MODAL

            $("#lbl_tot_fonasa").val(format_toCLP(GLOBAL_TOT_PREVISION));
            $("#lbl_total_copago_fonasa").val(format_toCLP(GLOBAL_TOT_FONASA));                         //<------------------ NUEVO DE ESTE FORMULARIO ----------------------------
            $("#lbl_total_a_pagar").val(format_toCLP((GLOBAL_TOT_COPA_PART + GLOBAL_TOT_FONASA)));

            $("#Lbl_tot_copa_particular").val(format_toCLP(GLOBAL_TOT_COPA_PART));
            $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(format_toCLP(GLOBAL_TOT_COPA_PART));  //MODAL
        };

        var Mx_Dtt_Resp_valAmbulatorio = [{}];

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

        function jsDecimals(e) {
            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
                    if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }


        function ddl_Change_onTable(index, idcodfona, idtppago) {
            //console.log("enter function ddl_Change_onTable");
            let fuck2 = idtppago;
            if (Mx_Dtt_examcof.length == 0) {

            } else {
                for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    if (Mx_Dtt_examcof[i]["CF_TP_PAGO"] == undefined || Mx_Dtt_examcof[i]["CF_TP_PAGO"] == 0) {
                        Mx_Dtt_examcof[i]["CF_TP_PAGO"] = $("input[name=inlineMaterialRadiosExample]:checked").val();
                    } else {
                        Mx_Dtt_examcof[i].CF_TP_PAGO = $("input[name=inlineMaterialRadiosExample]:checked").val();
                    }
                }

                if (fuck2 == 3 || fuck2 == 11 || fuck2 == 4) {
                    for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                        for (x = 0; x < Mx_Dtt_exam02.length; x++) {
                            if (Mx_Dtt_exam02[x].ID_CODIGO_FONASA == Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                                //Mx_Dtt_examcof[i].CF_TP_PAGO = $("input[name=inlineMaterialRadiosExample]:checked").val();
                                Mx_Dtt_examcof[i].CF_TP_PAGO = fuck2
                                Mx_Dtt_examcof[i].CF_PRECIO_AMB = 0;
                                Mx_Dtt_examcof[i].CF_BONIFICACION = 0;
                                return 0;//Mx_Dtt_examcof[i].CF_PRECIO_AMB = 0;
                            }
                        }
                    }
                } else if (fuck2 == 1 || fuck2 == 20) {                                                             //CAMBIAMOS VALORES POR EFECTIVO O PARTICULAR
                    var findet = 0;
                    for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                        for (x = 0; x < Mx_Dtt_exam02_Particular.length; x++) {
                            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == idcodfona && Mx_Dtt_exam02_Particular[x].ID_CODIGO_FONASA == idcodfona) {
                                findet = 1;
                                //Mx_Dtt_examcof[i].CF_TP_PAGO = $("input[name=inlineMaterialRadiosExample]:checked").val();
                                Mx_Dtt_examcof[i].CF_TP_PAGO = fuck2;
                                Mx_Dtt_examcof[i].CF_BONIFICACION = 0;
                                Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                                return Mx_Dtt_exam02_Particular[x].CF_PRECIO_AMB;
                            }
                        }
                    }
                    for (x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                        if (Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {
                            //Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                            findet = 1;
                            return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                            //return Mx_Dtt_exam02[x].CF_PRECIO_AMB;
                        }
                    }
                }
                else if (fuck2 == 18 || fuck2 == 5 || fuck2 == 2 || fuck2 == 19 || fuck2 == 19) {
                    for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                        for (x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                            if (Mx_Dtt_examcof[i].ID_CODIGO_FONASA == idcodfona && Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {//== Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                                Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                                Mx_Dtt_examcof[i].CF_BONIFICACION = Mx_Dtt_Resp_valAmbulatorio[x].CF_BONIFICACION;
                                Mx_Dtt_examcof[i].CF_TP_PAGO = fuck2;
                                return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                            }
                        }
                    }
                }
                else {

                    //for (i = 0; i < Mx_Dtt_examcof.length; i++) {
                    for (x = 0; x < Mx_Dtt_Resp_valAmbulatorio.length; x++) {
                        if (Mx_Dtt_Resp_valAmbulatorio[x].ID_CODIGO_FONASA == idcodfona) {
                            //Mx_Dtt_examcof[i].ID_CODIGO_FONASA) {
                            findet = 1;
                            Mx_Dtt_examcof[i].CF_TP_PAGO = fuck2;
                            Mx_Dtt_examcof[i].CF_BONIFICACION = Mx_Dtt_Resp_valAmbulatorio[x].CF_BONIFICACION;
                            Mx_Dtt_examcof[i].CF_PRECIO_AMB = Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                            return Mx_Dtt_Resp_valAmbulatorio[x].CF_PRECIO_AMB;
                            //return Mx_Dtt_exam02[x].CF_PRECIO_AMB;
                        }
                    }
                    //}
                }

            }
            //fill_llenado_tabla();
        }


        $(document).ready(() => {

            // modal_show();
            $("#div_tabla_graph").hide();
            $("#Div_Tabla_Tot").hide();
            let dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input, #Txt_Date03 input").val(dateNow);
            $('#Txt_Date01, #Txt_Date02, #Txt_Date03 input').datetimepicker({
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
            //Ajax_Usu();})
            Ajax_DL_DOC();
            fn_Req_Pago();


            $("#Btn_Modificar_Final").click(() => {
                if (PASS_SAVE == 1) {
                    Ajax_guardar();
                } else {
                    $("#mError_AAH p").text("Debe revisar los valores ingresados");
                    $("#mError_AAH").modal();
                    $('#XXXXXXXX').removeClass('show');
                }
                
            });


            $("#Ddl_Preve").change(()=>{
                Ajax_Usu();
            });

            $("#btn_Buscar").click(() => {
                search_mode = 1;
                Ajax_DataTable_Select();
            });

            $("#btn_Buscar_Folio").click(() => {

                if ($("#txt_Folio").val() == "") {
                
                } else {
                    search_mode = 0;
                    Ajax_DataTable_Folio();
                }           
            });



        });

        function c_modal() {
            if (_cont_mod == 3) {
                Hide_Modal();
            }
        }


        function Fill_IMG_Fill(atetetete_nummmmmumumu) {
            AATTEE_NNUUMM = atetetete_nummmmmumumu;
            Llenar_IMG();
        };


        // -------------------------------------------- AJAX GUARDAR ------------------------------------------------------------------

        function Ajax_guardar() {
            modal_show();

            $("#txt_Folio").val(Mx_Dtt_examcof[0].ATE_NUM);

            var TOTAL = 0;
            ids = new Array();


            let SEGURRRR__COMPLEMNT_SOLO_PRIMERO = GLOBAL_TOT_SEGURO_COMPLEMENTARIO;
            for (x = 0; x < Mx_Dtt_examcof.length; x++) {
                var xtotal = parseFloat(Mx_Dtt_examcof[x].CF_PRECIO_AMB);
                TOTAL += xtotal;
                var objId = {
                    "id_CF": Mx_Dtt_examcof[x].ID_CODIGO_FONASA,
                    "Valor": Mx_Dtt_examcof[x].CF_PRECIO_AMB,
                    "CF_TP_PAGO": Mx_Dtt_examcof[x].ATE_DET_TP_1,
                    "ATE_DET_VALOR_BENEF": Mx_Dtt_examcof[x].ATE_DET_VALOR_BENEF,                           //1             DETALLE ATENCION CAJA
                    "ATE_DET_VALOR_CS": Mx_Dtt_examcof[x].ATE_DET_VALOR_CS,                                 //0, //SEGURRRR__COMPLEMNT_SOLO_PRIMERO,    //POR MIENTRAS  Mx_Dtt_examcof[x].ATE_DET_VALOR_CS,
                    "ATE_DET_TP_1": Mx_Dtt_examcof[x].ATE_DET_TP_1,                                         //3
                    "ATE_DET_TP_OBS": "",//$("#txt_nTarjeta_1_modal").val(),//Mx_Dtt_examcof[x].ATE_DET_TP_OBS,  //4
                    "ATE_DET_NUM_BOL": 0,                                                                   //5             LE PONEMOS 0  
                    "ATE_DET_NUM_BONO": Mx_Dtt_examcof[x].ATE_DET_NUM_BONO,                                 //6         

                };
                ids.push(objId);
                SEGURRRR__COMPLEMNT_SOLO_PRIMERO = 0;
            }

            gg = new Array();

            $("#checkBox2:checkbox:checked").each(function () {
                gg.push($(this).val());
            });

            var f = moment().format("DD-MM-YYYY");
            var Data_Par = JSON.stringify({               
                "ID_ATENCION": Mx_Dtt_examcof[0].ID_ATENCION,
                "TOTAL": TOTAL,
                "FECHA_PRE": f, 
                "ids": ids,
                "ATE_V_SISTEMA": GLOBAL_TOT_PREVISION,                                                                          //1     VALOR PREVISIION
                "ATE_V_BENEF": (GLOBAL_TOT_BENEFICIARIO + GLOBAL_TOT_SEGURO_COMPLEMENTARIO),                                    //2     VALOR BENEFICIARIO +  SEGURO COMPLEMENATRIO
                "ATE_V_CF": GLOBAL_TOT_FONASA,                                                                                  //3     TOTAL FONASA
                "ATE_V_CF_FP": 0,//$("#Ddl_Ttp_Modal").val(),                                                                       //4     TIPO DE PAGO FONASA
                "ATE_V_CP": 0,//$("#Lbl_tot_copa_particular").val(),                                                                //5     VALOR PARTICULAR
                "ATE_V_CP_FP": 0,//$("#Ddl_Ttp_Modal2").val(),                                                                      //6     TIPO DE PAGO PARTICULAR
                "ATE_V_BOLETA": 0,//$("#txt_nBoleta_2_modal").val(),                                                                //7     NUMERO DE BOLETA
                "ATE_V_PAGADO": 0,//$("#lbl_Tot_Pagar_Modal").val(),                                                                //8     TOTAL SUPREMO
                "ATE_V_SEG_COMP": GLOBAL_TOT_SEGURO_COMPLEMENTARIO,                                                             //9     SEGURO COMPLEMENTARIO
                // ---------------------------------------------------------- SE AGREGA SEGUNDO COPAGO -------------------------------------------------------
                "ATE_TP_COPAGO_1": 0,//$("#Ddl_Ttp_Modal").val(),                                                                   //10    TIPO COPAGO 1
                "ATE_VALOR_COPAGO_1": 0,//tp111,                                                                                    //11    VALOR COPAGO 1
                "ATE_TP_COPAGO_2": 0,//$("#Ddl_Ttp_Modal_2").val(),                                                              //12    TIPO COPAGO 2   
                "ATE_VALOR_COPAGO_2": 0,//tp222,                                                                                    //14    VALOR COPAGO 2
                //---------------------------------------------------------- SE AGREGA SEGUNDO PAGO PARTICULAR --------------------------------------------              
                "ATE_TP_PARTICULAR_1": 0,//$("#Ddl_Ttp_Modal2").val(),                                                              //15    TIPO PAGO PARTICULAR 1  
                "ATE_VALOR_PARTICULAR_1": 0,//$("#lbl_Tot_Pagar_Insumos_Particul_Modal").val(),                                     //16    VALOR PARTICULAR 1
                "ATE_TP_PARTICULAR_2": 0,//$("#Ddl_Ttp_Modal_2_Parti").val(),                                                       //17    TIPO PAGO PARTICULAR 2
                "ATE_VALOR_PARTICULAR_2": 0,//$("#lbl_Tot_Fonasa_Modal_2_Parti").val(),                                             //18    VALOR PARTICULAR 2
                //------------------------------------------  SE AGREGA SEGURO COMPLEMENTARIO PARA TABLA IRIS_ATENCION _________________________________________
                "ATE_V_SC": GLOBAL_TOT_SEGURO_COMPLEMENTARIO



                //GLOBAL_TOT_SEGURO_COMPLEMENTARIO
                //GLOBAL_TOT_PREVISION
                //GLOBAL_TOT_FONASA
                //GLOBAL_TOT_COPA_PART
                //GLOBAL_TOT_PREVISION
                //GLOBAL_TOT_BENEFICIARIO -------------
                //GLOBAL_TOT_A_PAGAR
                //---------------------------------------------------------------------                                 DESDE AQUI VAN LOS DATOS NUEVOS




            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Guardar_TodoByVal",
                //"url": "Ingreso_Ate_Caja4.aspx/TEST_GUARDAR",  
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    //Comprobar Galletas
                    if ((json_receiver == null) || (json_receiver == "")) {
                        //window.location = "/index.aspx";
                        //return;
                    }

                    if (json_receiver != null) {

                        Hide_Modal();
                                      
                        Mx_Dtt_examcof.length = 0;


                        GLOBAL_TOT_SEGURO_COMPLEMENTARIO = 0;
                        GLOBAL_TOT_PREVISION = 0;
                        GLOBAL_TOT_FONASA = 0;
                        GLOBAL_TOT_COPA_PART = 0;
                        GLOBAL_TOT_PREVISION = 0;
                        GLOBAL_TOT_BENEFICIARIO = 0;
                        GLOBAL_TOT_A_PAGAR = 0;

                        activador = 0;


                        activador_Parti = 0;

                        $("#materialInline1").prop('checked', true);

                        $("#Lbl_tot_a_pagar").val("");
                        $("#Lbl_tot_copa_fonasa").val("");
                        $("#Lbl_tot_copa_particular").val("");
                        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").val("");
                        $("#Lbl_tot_prevision").val("");
                        $("#Lbl_tot_beneficiario").val("");
                        $("#lbl_Tot_Pagar_Modal").val("");
                        $("#lbl_Tot_Fonasa_Modal").val("");
                        $("#txt_nTarjeta_1_modal").val("");
                        $("#txt_nTarjeta_2_modal").val("");
                        $("#txt_nBoleta_2_modal").val("");
                        $("#lbl_Tot_Fonasa_Modal_2").val("0");

                        $("#MOdal_NUEVO_SELECCION").modal("hide");

                        $("#divNewPaymen").hide();
                        $("#agregaMedioPago").show();
                        $("#spanAgregaMedioPago").show();
                        $("#lbl_Tot_Fonasa_Modal").attr("disabled", "disabled");

                        $("#divNewPaymen_Parti").hide();
                        $("#agregaMedioPago_Parti").show();
                        $("#spanAgregaMedioPago_Parti").show();
                        $("#lbl_Tot_Pagar_Insumos_Particul_Modal").attr("disabled", "disabled");

                        $("#modal_Modificar").modal("hide");

                       
                        Ajax_DataTable_Folio();
                        //Ajax_DataTable_Select();

                        $('#XXXXXXXX').removeClass('show');
                        $("#title2").text("Ingreso de Atención realizado");
                        $("#modalpccc").html("<p><strong>Nº de Folio:</strong> <strong style='font-size:20px;'>" + 00000000000 + "</strong>\n ¿Desea imprimir Etiquetas?</p>");
                        $("#MOdal_PAGO").modal();

                    } else {
                        Hide_Modal();


                        var str_Error = "Estimado Usuario"
                        $("#title").text("El cambio de Tipo de Pago se ha Realizado con Éxito");
                        $("#button_modal").attr("class", "btn btn-success");

                        $("#mError_AAH p").text(str_Error);
                        $("#mError_AAH").modal();
                        $('#XXXXXXXX').removeClass('show');
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
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
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_Ddl_LugarTM",
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

            if (ide_admin == 1 || procee == 0) {
                
                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            } else {
                Mx_Dtt_LugarTM.forEach(aaa => {
                    if (procee == aaa.ID_PROCEDENCIA) {
                        $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                    }
                        
                    
                });
            }

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
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_Ddl_Prevision",
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

        var arrPago = [{
            "ID_TP_PAGO": 0,
            "TP_PAGO_DESC": "",
            "TP_PAGO_ING": "",
            "ID_ESTADO": 0
        }];
        function fn_Req_Pago() {
            objAJAX_Prev = $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/tipo_pago",          //"2do PA, que excluye el Tp pago efecto, y mantiene "particular"
                //"data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrPago = resp.d;
                },
                "error": (fail) => {

                }
            });
        };

        function Fill_Ddl_Preve() {
            $("#Ddl_Preve").empty();
            $("#ddl_preve_modi").empty();

            Mx_Dtt_Preve.forEach(aaa => {
                $("<option>", { "value": aaa.ID_PREVE }).text(aaa.PREVE_DESC).appendTo("#ddl_preve_modi");
            });

            var preveee = Galletas.getGalleta("USU_PREV");

            if (preveee == 0) {
                $("<option>",{"value": 0}).text("Todos").appendTo("#Ddl_Preve");
                Mx_Dtt_Preve.forEach(aaa => {
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
            
        };

        var Mx_DL_DOC = [
{
    "ID_DOCTOR": 0,
    "DOC_NOMBRE": "asdf",
    "DOC_APELLIDO": "asdf",
    "ID_ESTADO": 0
}
        ];
        function Ajax_DL_DOC() {



            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_DL_DOC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_DL_DOC = json_receiver;
                        Fill_DL_DOC();

                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }

        function Fill_DL_DOC() {
            $("#Doctor").empty();

            $("<option>", {"value": 0}).text("Todos").appendTo("#Doctor");

            for (y = 0; y < Mx_DL_DOC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_DOC[y].ID_DOCTOR
                }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
            }
        }

        let Mx_Dtt_Usu = [{
            "ID_USUARIO": 0,
            "USU_NOMBRE": 0,
            "USU_APELLIDO": 0,
            "USU_NIC": 0
        }];



        function Ajax_Usu() {

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Call_User_Data",
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

        function Fill_Ddl_Usu() {
            $("#Ddl_Usu").empty();

            $("<option>",{"value": 0}).text("Todos").appendTo("#Ddl_Usu");
            Mx_Dtt_Usu.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_USUARIO
                    }
                ).text(aaa.USU_NIC + " " + aaa.USU_NOMBRE + " " + aaa.USU_APELLIDO).appendTo("#Ddl_Usu");
            });
        };

        //AJAX BUSCA PRECIOS PARTICULAR

        var Mx_Dtt_exam02_Particular = [
            {
                "AÑO_DESC": 0,
                "ID_PREVE": 0,
                "ID_CODIGO_FONASA": 0,
                "CF_PRECIO_AMB": 0,
                "CF_PRECIO_HOS": 0,
                "ID_ESTADO": 0,
                "CF_COD": 0,
                "CF_DESC": 0,
                "ID_PER": 0,
                "ID_CF_PRECIO": 0,
                "CF_DIAS": 0,
                "CF_PRECIO_PARTICULAR": 0,
                "CF_BONIFICACION": 0
            }
        ];
        function Ajax_DataTable_examen02_Particular() {
            var f = moment().format("DD-MM-YYYY");

            var Data_Par = JSON.stringify({
                "ID_PREVE": 185,//$("#Prevision").val(),
                "Fecha": f
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_tabla_exam2_particular",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {

                    var json_receiver = response.d;
                    if (json_receiver != null) {

                        Mx_Dtt_exam02_Particular = json_receiver;


                    } else {


                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        var Mx_Dtt_exam02 = [
  {
      "AÑO_DESC": 0,
      "ID_PREVE": 0,
      "ID_CODIGO_FONASA": 0,
      "CF_PRECIO_AMB": 0,
      "CF_PRECIO_HOS": 0,
      "ID_ESTADO": 0,
      "CF_COD": 0,
      "CF_DESC": 0,
      "ID_PER": 0,
      "ID_CF_PRECIO": 0,
      "CF_DIAS": 0,
  }
        ];
        var Mx_Dtt_exam02_respaldo = [
        {
            "AÑO_DESC": 0,
            "ID_PREVE": 0,
            "ID_CODIGO_FONASA": 0,
            "CF_PRECIO_AMB": 0,
            "CF_PRECIO_HOS": 0,
            "ID_ESTADO": 0,
            "CF_COD": 0,
            "CF_DESC": 0,
            "ID_PER": 0,
            "ID_CF_PRECIO": 0,
            "CF_DIAS": 0,
            "CF_PRECIO_PARTICULAR": 0,
            "CF_BONIFICACION": 0
        }
        ];
        function Ajax_DataTable_examen02(ID_PREVE) {
            var f = moment().format("DD-MM-YYYY");

            var Data_Par = JSON.stringify({
                "ID_PREVE": ID_PREVE,//$("#Prevision").val(),
                "Fecha": f
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_tabla_exam2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {

                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_exam02 = json_receiver;
                        Mx_Dtt_exam02_respaldo = json_receiver;
                        Mx_Dtt_Resp_valAmbulatorio = json_receiver;
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        let Mx_Dtt = [{
            ATE_NUM:"", 
            ATE_FECHA:"", 
            ATE_DET_V_ID_ESTADO:"", 
            EST_DESCRIPCION:"", 
            CF_COD:"", 
            CF_DESC:"", 
            ID_CODIGO_FONASA:"", 
            ID_ATENCION:"", 
            PAC_NOMBRE:"", 
            PAC_APELLIDO:"", 
            PROC_DESC:"", 
            ID_PROCEDENCIA:"", 
            ATE_AÑO:"", 
            SEXO_DESC:"", 
            ID_PACIENTE:"", 
            ID_SEXO:"", 
            ID_ESTADO:"", 
            PAC_RUT:"", 
            PAC_FNAC:"", 
            ATE_DET_V_PREVI:"", 
            ATE_MES:"", 
            ATE_DIA:"", 
            TP_PAGO_DESC:"", 
            DOC_NOMBRE:"", 
            DOC_APELLIDO:"", 
            PROGRA_DESC:"", 
            ORD_DESC:"", 
            ATE_DET_V_PAGADO:"", 
            ATE_DET_V_COPAGO:"", 
            ID_USUARIO:"", 
            USUARIO_DET:"", 
            REVE_DESC:"", 
            USU_REV:"", 
            USU_CRE:"", 
            ATE_DET_RCAJA_ESTADO:"", 
            ATE_DET_RCAJA_FECHA:"", 
            ATE_DET_RCAJA_VALORD:"", 
            ATE_DET_RCAJA_VALORU:"", 
            ID_DET_ATE: "",
            ID_PREVE: "",
            ATE_DET_VALOR_BENEF: "",
            ATE_DET_VALOR_CS: "",
            DOCS_CANT:""
        }];
        function Ajax_DataTable_Folio() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": 0,//$("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "ID_USER": $("#Doctor").val(),
                "ATE_NUM": $("#txt_Folio").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;


                        $("#Div_Tabla").empty();
                        Fill_DataTable();
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

        let Mx_Dtt_Modificar = [{
            ATE_NUM:"", 
            ATE_FECHA:"", 
            ATE_DET_V_ID_ESTADO:"", 
            EST_DESCRIPCION:"", 
            CF_COD:"", 
            CF_DESC:"", 
            ID_CODIGO_FONASA:"", 
            ID_ATENCION:"", 
            PAC_NOMBRE:"", 
            PAC_APELLIDO:"", 
            PROC_DESC:"", 
            ID_PROCEDENCIA:"", 
            ATE_AÑO:"", 
            SEXO_DESC:"", 
            ID_PACIENTE:"", 
            ID_SEXO:"", 
            ID_ESTADO:"", 
            PAC_RUT:"", 
            PAC_FNAC:"", 
            ATE_DET_V_PREVI:"", 
            ATE_MES:"", 
            ATE_DIA:"", 
            TP_PAGO_DESC:"", 
            DOC_NOMBRE:"", 
            DOC_APELLIDO:"", 
            PROGRA_DESC:"", 
            ORD_DESC:"", 
            ATE_DET_V_PAGADO:"", 
            ATE_DET_V_COPAGO:"", 
            ID_USUARIO:"", 
            USUARIO_DET:"", 
            REVE_DESC:"", 
            USU_REV:"", 
            USU_CRE:"", 
            ATE_DET_RCAJA_ESTADO:"", 
            ATE_DET_RCAJA_FECHA:"", 
            ATE_DET_RCAJA_VALORD:"", 
            ATE_DET_RCAJA_VALORU:"", 
            ID_DET_ATE: "",
            ID_PREVE: "",
            ATE_DET_VALOR_BENEF: "",
            ATE_DET_VALOR_CS: "",
            DOCS_CANT: "",
            ID_TP_PAGO:""
        }];

        let Mx_Dtt_examcof = [
        {
            ID_PREVE: "",
            ID_CODIGO_FONASA: "",
            ID_ESTADO: "",
            CF_COD: "",
            CF_DESC: "",
            ATE_DET_VALOR_BENEF: "",       //1
            ATE_DET_VALOR_CS: ""          //2
            //"ATE_DET_TP_1": 0,              //3
            //"ATE_DET_TP_OBS": 0,	        //4
            //"ATE_DET_NUM_BOL": 0,           //5
            //"ATE_DET_NUM_BONO": 0           //6
        }
        ];
        function Ajax_DataTable_Folio_Modificar(ID_ATE) {
            modal_show();
            let Data_Par = JSON.stringify({
                "ID_ATENCION": ID_ATE
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_DataTable_Modificar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Modificar = json_receiver;                        


                        Mx_Dtt_examcof.length = 0;
                        for (z = 0; z < Mx_Dtt_Modificar.length; z++) {
                            Mx_Dtt_examcof.push(fnClone(Mx_Dtt_Modificar[z]));
                        }
                        
                        $("#Div_Tabla_Modal").empty();
                        $("#Div_Tabla_Modal_Nuevos").empty();
                        Ajax_DataTable_examen02_Particular();
                        Ajax_DataTable_examen02(Mx_Dtt_Modificar[0].ID_PREVE);
                        Fill_DataTable_Modificar();
                        $("#modal_Modificar").modal("hide");
                        $("#modal_Modificar").modal();
                    } else {
                        $("#modal_Modificar").modal("hide");
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

        function Ajax_DataTable_Select() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "TP_PAGO":0,
                "PREV": $("#Ddl_Preve").val(),
                "ID_USER": $("#Doctor").val(),
                "ID_ESTADO": $("#ddl_estado").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Mod_TP_Pago.aspx/Llenar_DataTable_Select",
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
                    $("<th>", { "class": "textoReducido" }).text("Exámenes"),
                    $("<th>", { "class": "textoReducido" }).text("Cod. Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("F. Pago"),
                    $("<th>", { "class": "textoReducido" }).text("Total Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Pagado"),
                    $("<th>", { "class": "textoReducido" }).text("Copago"),
                    $("<th>", { "class": "textoReducido" }).text("Particular"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Bonificación"),
                    $("<th>", { "class": "textoReducido" }).text("Seguro Complementario"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario Creación"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Revisado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Revisión"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario Revisión"),
                    $("<th>", { "class": "textoReducido" }).text("Modificar")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt[i].ATE_FECHA).format("DD-MM-YYYY HH:mm")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TP_PAGO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PREVI)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PAGADO)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_COPAGO)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].TP_PAGO_DESC == "Efectivo" || Mx_Dtt[i].TP_PAGO_DESC == "Particular") {
                                return ("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PAGADO));
                            } else {
                                return "$" + 0;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_VALOR_BENEF)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_VALOR_CS)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USUARIO_DET),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),

                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].USU_REV == "" || Mx_Dtt[i].USU_REV == null) {
                                $(this).css("cssText", "background-color: #f5b0e5 !important; text-align:center;").text("NO");
                            }
                            else {
                                $(this).css("cssText", "background-color:#88d6e2 !important; text-align:center;").text("SI");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].USU_REV == "" || Mx_Dtt[i].USU_REV == null) {
                                return "";
                            } else {
                                return moment(Mx_Dtt[i].ATE_DET_RCAJA_FECHA).format("DD-MM-YYYY HH:mm");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_REV),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            $(this).append("<button type='button' class='btn btn-info btn-sm' onclick='Ajax_DataTable_Folio_Modificar(" + Mx_Dtt[i].ID_ATENCION + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Modificar</button>");
                        })


                    )
                );

            }


            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });


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
            let toot_sistemmm = 0;
            let tooot_pagado = 0;
            let tooot_copa = 0;
            let toooot_benef = 0
            let toooot_SC = 0;
            let toootototot_particull = 0;

            Mx_Dtt.forEach(aah=> {

                copaaaa += 1 + parseInt(1);
                partiiii += parseInt(1) + parseInt(1);
                desccc += parseInt(1);
                toot_sistemmm += parseInt(aah.ATE_DET_V_PREVI)
                tooot_pagado += parseInt(aah.ATE_DET_V_PAGADO)
                tooot_copa += parseInt(aah.ATE_DET_V_COPAGO)
                toooot_benef += parseInt(aah.ATE_DET_VALOR_BENEF)
                toooot_SC += parseInt(aah.ATE_DET_VALOR_CS)

                if (aah.TP_PAGO_DESC == "Efectivo" || aah.TP_PAGO_DESC == "Particular") {
                    toootototot_particull += parseInt(aah.ATE_DET_V_PAGADO)
                }
            });

            Hide_Modal();


            $("#Div_Tabla_Tot").empty();
    
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
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Exámenes"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Atención"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Pagado"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Copago"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Particular"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Bonificación"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total S. Complementario")
                )
            );

            $("#DataTable_Tot tbody").append(
                $("<tr>").append(
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt.length),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toot_sistemmm)),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(tooot_pagado)),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(tooot_copa)),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toootototot_particull)),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toooot_benef)),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toooot_SC))
                )
            );


            Hide_Modal();

            do_Chart_1();


        }




        function Fill_DataTable_Modificar() {
        
            $("<table>", {
                "id": "DataTable_Modificar",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Modal");

            $("#DataTable_Modificar").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Modificar").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Modificar thead").attr("class", "cabzera");
            $("#DataTable_Modificar thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),              
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Paciente Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Cod. Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Pago"),
                    $("<th>", { "class": "textoReducido" }).text("Total Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Pagado"),
                    $("<th>", { "class": "textoReducido" }).text("Copago"),
                    $("<th>", { "class": "textoReducido" }).text("Particular"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Bonificación"),
                    $("<th>", { "class": "textoReducido" }).text("Seguro Complementario")
                )
            );

            for (i = 0; i < Mx_Dtt_Modificar.length; i++) {
                $("#DataTable_Modificar tbody").append(
                    $("<tr>", {
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt_Modificar[i].ATE_FECHA).format("DD-MM-YYYY HH:mm")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].PAC_NOMBRE + " " + Mx_Dtt_Modificar[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].TP_PAGO_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modificar[i].ATE_DET_V_PREVI)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modificar[i].ATE_DET_V_PAGADO)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modificar[i].ATE_DET_V_COPAGO)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt_Modificar[i].TP_PAGO_DESC == "Efectivo" || Mx_Dtt_Modificar[i].TP_PAGO_DESC == "Particular") {
                                return ("$" + addCommas(Mx_Dtt_Modificar[i].ATE_DET_V_PAGADO));
                            } else {
                                return "$" + 0;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modificar[i].ATE_DET_VALOR_BENEF)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modificar[i].ATE_DET_VALOR_CS))


                    )
                );
                
            }

            Hide_Modal();
            Fill_DataTable_Modificar_Nuevos();

        }

        function Fill_DataTable_Modificar_Nuevos() {

            $("<table>", {
                "id": "DataTable_Modificar_Nuevos",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Modal_Nuevos");

            $("#DataTable_Modificar_Nuevos").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Modificar_Nuevos").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Modificar_Nuevos thead").attr("class", "cabzera");
            $("#DataTable_Modificar_Nuevos thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Cod. Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Pago"),
                    $("<th>", { "class": "textoReducido" }).text("Documento"),
                    $("<th>", { "class": "textoReducido" }).text("S. Complemenatrio"),
                    $("<th>", { "class": "textoReducido" }).text("Total Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Bonificación"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Copago")
                )
            );

            for (i = 0; i < Mx_Dtt_Modificar.length; i++) {
                $("#DataTable_Modificar_Nuevos tbody").append(
                    $("<tr>", {
                        "data-index": i
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].CF_DESC),    
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modificar[i].TP_PAGO_DESC),

                        $("<td>", { "align": "left" }).append($("<select>", {class: "form-control textoReducido tp_pago tp_pago2 negrita carlos_sama",

                            "data-id_pago": Mx_Dtt_Modificar[i].ID_CODIGO_FONASA,
                            "data-cod-exa": Mx_Dtt_Modificar[i].CF_COD,
                            "data-posicion": i,
                            "height": "calc(1.89rem + 6px)",
                            "font-size": "5px"

                        }).append(function () {                                             //TIPO DE PAGO
                            let xxx = [];

                            xxx.push($("<option>", { value: Mx_Dtt_Modificar[i].ID_TP_PAGO }).text(Mx_Dtt_Modificar[i].TP_PAGO_DESC));

                            for (x = 0; x < arrPago.length; x++) {
                                if (arrPago[x].ID_TP_PAGO == Mx_Dtt_Modificar[i].ID_TP_PAGO) {
                                    //console.log("TP igual: " + Mx_Dtt_Modificar[i].ID_TP_PAGO + " - " + Mx_Dtt_Modificar[i].TP_PAGO_DESC);
                                }else{
                                    xxx.push($("<option>", { value: arrPago[x].ID_TP_PAGO }).text(arrPago[x].TP_PAGO_DESC));
                                    xxx.push()
                            }
                                
                            }
                            
                            //console.log(xxx);
                            return xxx;
                            
                        }())
                    
                    ),

                    $("<td>", {                                                         //DOCUMENTO
                        "align": "left",
                        "class": "textoReducido negrita"
                    }).html((function () {
                        //Retornar un campo input
                        return $("<input>", {
                            "data-id": Mx_Dtt_Modificar[i].ID_CODIGO_FONASA,
                            "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                            "class": "td_input carlos_sama textDerecho borderRound td_documento negrita",
                            "onkeydown": "return jsDecimals(event)",
                            "value": ""
                        })
                    }())),
                        $("<td>", {                                                         //SEGURO COMPLEMENTARIO
                            "align": "left",
                            "class": "textoReducido"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_Modificar[i].ID_CODIGO_FONASA,
                                "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input  carlos_sama textDerecho borderRound td_scomplementario negrita",
                                "maxlength": "7",
                                "onkeydown": "return jsDecimals(event)",
                                //"disabled": "disabled",
                                "value": Mx_Dtt_Modificar[i].ATE_DET_VALOR_CS
                            })
                        }())),
                        $("<td>", {                                                         //VALOR PREVISION
                            "align": "left",
                            "class": "textoReducido negrita"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_Modificar[i].ID_CODIGO_FONASA,
                                "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input textoReducido carlos_sama textDerecho borderRound td_val3 dark_text td_prevision negrita",
                                "disabled": "disabled",
                                "maxlength": "7",
                                "onkeydown": "return jsDecimals(event)",
                                "value": Mx_Dtt_Modificar[i].ATE_DET_V_PREVI
                            })
                        }())),
                        $("<td>", {                                                         //VALOR BENEFICIARIO
                            "align": "left",
                            "class": "textoReducido negrita"
                        }).html((function () {
                            //Retornar un campo input
                            return $("<input>", {
                                "data-id": Mx_Dtt_Modificar[i].ID_CODIGO_FONASA,
                                "data-cod": "",//Mx_Dtt_examcof[i].CF_COD,
                                "class": "td_input textDerecho carlos_sama borderRound td_valorBeneficiario negrita",
                                "maxlength": "7",
                                "onkeydown": "return jsDecimals(event)",
                                "disabled": "disabled",
                                "value": Mx_Dtt_Modificar[i].ATE_DET_VALOR_BENEF
                            })
                        }())),
                $("<td>", {                                                                 //VALOR A PAGAR 
                    "align": "left",
                    "class": "textoReducido"
                }).html((function () {
                    //Retornar un campo input
                    return $("<input>", {
                        "data-id": Mx_Dtt_Modificar[i].ID_CODIGO_FONASA,
                        "data-cod": "",//,Mx_Dtt_examcof[i].CF_COD,
                        "class": "td_input textDerecho carlos_sama dark_text borderRound td_valorapagar negrita",
                        "maxlength": "7",
                        "onkeydown": "return jsDecimals(event)",
                        "disabled": "disabled",
                        "value": Mx_Dtt_Modificar[i].ATE_DET_V_PAGADO
                    })
                }()))


                    )
                );

                let xindex = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}] .tp_pago`).val(Mx_Dtt_examcof[i].CF_TP_PAGO);
                let xindex3 = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}] .tp_prevision`).val(Mx_Dtt_examcof[i].CF_TP_PREVE);

                Mx_Dtt_examcof[i].ATE_DET_VALOR_BENEF = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}] .td_valorBeneficiario`).val();                            //1
                Mx_Dtt_examcof[i].ATE_DET_VALOR_CS = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}] .td_scomplementario`).val();                                 //2
                Mx_Dtt_examcof[i].ATE_DET_TP_1 = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}] .tp_pago2`).val();                                               //3
                Mx_Dtt_examcof[i].ATE_DET_TP_OBS = "ate det tp obss";                                                                                           //4 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BOL = 0;                                                                                                          //5 
                Mx_Dtt_examcof[i].ATE_DET_NUM_BONO = "";                                                                                                        //6

                $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[i].ATE_DET_TP_1);

                //CAMBIO EN DROP TIPO DEPAGO
                $(`#DataTable_Modificar_Nuevos tbody tr .tp_pago2`).change(function EnterEvent(e) {                                                                         //CAMBIO EN DROP TIPO DE PAGO
                    //console.log("enter cambio de TP");
                    e.stopImmediatePropagation();
                    var x_id_pos_td = $(this).parents("tr").attr('data-index');
                    var x_id_codFonasa_td = $(this).attr('data-id_pago');
                    var x_id_tpago_td = $(this).val();


                    //var xId_index_td_val_documento = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();
                    var xId_index_td_val_prevision = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val();

                    //if (x_id_tpago_td == 1 || x_id_tpago_td == 20) {
                    //    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                                   //FUNCION CAMBIO VALOR        

                    //    $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //} else {
                    //    xId_index_td_val_prevision = Mx_Dtt_examcof[x_id_pos_td].CF_PRECIO_AMB;
                    //    $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_prevision`).text(xId_index_td_val_prevision);
                    //}

                    xId_index_td_val_prevision = ddl_Change_onTable(x_id_pos_td, x_id_codFonasa_td, x_id_tpago_td);                                         //FUNCION CAMBIO VALOR     
                    $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_prevision`).val(xId_index_td_val_prevision);

                    if (x_id_tpago_td == 1 || x_id_tpago_td == 3 || x_id_tpago_td == 11 || x_id_tpago_td == 20 || x_id_tpago_td == 4) {
                        xId_index_td_val_valorBeneficiario = 0;
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(0);
                    } else {
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val(Mx_Dtt_examcof[x_id_pos_td].CF_BONIFICACION);
                        xId_index_td_val_valorBeneficiario = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();
                    }

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_BENEF = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorBeneficiario`).val();                            //1
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_VALOR_CS = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1 = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                     //4 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BOL = 0;                                                                                                                    //5 
                    Mx_Dtt_examcof[x_id_pos_td].ATE_DET_NUM_BONO = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();                                       //6

                    $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).attr("data-tipo", Mx_Dtt_examcof[x_id_pos_td].ATE_DET_TP_1);          //SE MARCA ID TIPO PAGO PARA DIFERENCIAR DE FONASA O PARTICULAR

                    if (provisorio < 0) {
                        
                        $(this).parents("tr").attr('data-index');

                        PASS_SAVE = 0;

                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "border-color": "red" });
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "color": "red" });

                        $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                        $("#Lbl_tot_beneficiario").css({ "color": "red" });

                    } else {
                        
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_valorapagar`).val(parseInt(provisorio));

                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "border-color": "#ccc" });
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_scomplementario`).css({ "color": "#212529" });

                        $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                        $("#Lbl_tot_beneficiario").css({ "color": "#495057" });

                        PASS_SAVE = 1;
                        HOLAAAAAAAAAAA();
                    }

                    $("#Lbl_tot_beneficiario").trigger("keyup");
                });

                $(`#DataTable_Modificar_Nuevos tbody tr .td_scomplementario`).keyup(function EnterEvent(e) {                                                                    //POR FILA SEGURO COMPLEMENTARIO

                    
                    e.stopImmediatePropagation();
                    //var x_id_pos_td = $(this).parents("tr").attr('data-index');
                    //let x_id_pos_td_2 = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}]`).attr('data-index');

                    var x_id_pos_td_2 = $(this).parents("tr").attr('data-index');
                    
                    //let x_id_pos_td_2 = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${i}]`).attr('data-index');a

                    if ($(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val() == "") {
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val(0);
                    }

                    if ($(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val() == "") {
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val(0);
                    }

                    //var xId_index_td_val_documento = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td}] .td_documento`).val();
                    var xId_index_td_val_scomplementario = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();
                    
                    var xId_index_td_val_prevision = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_prevision`).val();
                    var xId_index_td_val_valorBeneficiario = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();
                    var xId_index_td_val_valorapagar = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val();

                    var SC_VB = parseInt(xId_index_td_val_scomplementario) + parseInt(xId_index_td_val_valorBeneficiario)

                    var provisorio = (parseInt(xId_index_td_val_prevision) - SC_VB);

                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_BENEF = 0;$(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_valorBeneficiario`).val();                          //1
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_VALOR_CS = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_scomplementario`).val();                                 //2
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_1 = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .tp_pago2`).val();                                               //3
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_TP_OBS = "ate det tp obss";                                                                                                                   //4 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BOL = 0;                                                                                                                                  //5 
                    Mx_Dtt_examcof[x_id_pos_td_2].ATE_DET_NUM_BONO = $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_documento`).val();                                       //6



                    if (provisorio < 0) {
                        $(this).parents("tr").attr('data-index');

                        PASS_SAVE = 0;
                        $(this).css({ "border-color": "red" });
                        $(this).css({ "color": "red" });

                        $("#Lbl_tot_beneficiario").css({ "border-color": "red" });
                        $("#Lbl_tot_beneficiario").css({ "color": "red" });


                    } else {
                        $(`#DataTable_Modificar_Nuevos tbody tr[data-index =${x_id_pos_td_2}] .td_valorapagar`).val(parseInt(provisorio));
                        PASS_SAVE = 1;
                        $(this).css({ "border-color": "#ccc" });
                        $(this).css({ "color": "#212529" });
                        $("#Lbl_tot_beneficiario").css({ "border-color": "#868e96" });
                        $("#Lbl_tot_beneficiario").css({ "color": "#495057" });
                        HOLAAAAAAAAAAA();
                    }


                    //$(".td_valorapagar").trigger("change")();

                    //$(".td_valorBeneficiario").trigger("change")();
                });


            }

            var stst_1 = 0;
            var stst_2 = 0;
            var stst_3 = 0;

            Mx_Dtt_Modificar.forEach(aah=> {
                stst_1 += aah.ATE_DET_V_PREVI;
                
                stst_2 += 0;
                stst_3 += 0;

            });

            $("#ddl_preve_modi").val(Mx_Dtt_Modificar[0].ID_PREVE);
            $("#lbl_tot_fonasa").val(format_toCLP(stst_1));
            $("#lbl_total_copago_fonasa").val();
            $("#lbl_total_a_pagar").val();
            Hide_Modal();

        }


        function do_Chart_1() {
   
            let Mx_Tot = [];
            let Mx_Data = [];
            let Mx_Cate = [];
            let Cant_Tot = 0;

            let tota_copa = 0;
            let tota_parti = 0;
            let dessssscccccc = 0;

            let tot_ssssiiiisttteeemmmaaa = 0;
            let tooot_pagadoooo = 0;
            let tooot_copaooo = 0;
            let tootototot_benef = 0;
            let tooottotot_SCCC = 0;
            let toooot_partiiii = 0;

            Mx_Dtt.forEach(aah=> {

                tot_ssssiiiisttteeemmmaaa += parseInt(aah.ATE_DET_V_PREVI)
                tooot_pagadoooo += parseInt(aah.ATE_DET_V_PAGADO)
                tooot_copaooo += parseInt(aah.ATE_DET_V_COPAGO)
                tootototot_benef += parseInt(aah.ATE_DET_VALOR_BENEF)
                tooottotot_SCCC += parseInt(aah.ATE_DET_VALOR_CS)

                if (aah.TP_PAGO_DESC == "Efectivo" || aah.TP_PAGO_DESC == "Particular") {
                    toooot_partiiii += parseInt(aah.ATE_DET_V_PAGADO)
                }
            });

            let BUUM = parseInt(tot_ssssiiiisttteeemmmaaa)//parseInt(tota_copa) + parseInt(tota_parti) + parseInt(dessssscccccc);
   
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
                    text: 'Valorización de Exámenes',
                    margin: 50
                },
                subtitle: {
                    text: 'Total Atención:  $' + addCommas(BUUM)
                    ,
                    style: {
                        color: '#ff0000',
                        fontWeight: 'bold'
                    }
                },
                xAxis: {
                    categories: [
                    'Total Atención',
                    'Total Pagado',
                    'Total Copago',
                    'Total Particular',
                    'Total Bonificación',
                    'Total S. Complementario'
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
                    data: [tot_ssssiiiisttteeemmmaaa, tooot_pagadoooo, tooot_copaooo, toooot_partiiii, tootototot_benef, tooottotot_SCCC]
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

    </script>
    <style>
        .manito {
            cursor:pointer;
        }
        .negrito {
            font-weight:700;
            font-size:14px;
        }
        .borderRound {
            border-radius:.25rem;
        }

        .carlos_sama {
            width: 7vw;
        }
                /*CHECKBOX DE FELIPE*/
        .div-chk-cont {
            display: flex;
            display: -webkit-flex;
            flex-flow: row wrap;
            justify-content: space-between;
            align-items: center;
        }

            .div-chk-cont > * {
                height: 12px;
                margin-bottom: 0.3rem;
            }

        input[type=checkbox] ~ .div-chk {
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            display: inline;
            min-height: 23.5px;
        }

            input[type=checkbox] ~ .div-chk i {
                font-size: 15px;
                color: #46963f;
            }

            input[type=checkbox] ~ .div-chk span {
                font-size: 10px;
            }

            input[type=checkbox] ~ .div-chk i:nth-child(1) {
                display: inline-block;
            }

            input[type=checkbox] ~ .div-chk i:nth-child(2) {
                display: none;
            }

        input[type=checkbox]:checked ~ .div-chk i:nth-child(1) {
            display: none;
        }

        input[type=checkbox]:checked ~ .div-chk i:nth-child(2) {
            display: inline-block;
        }
    </style>

        <!-- Modal ERROR -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
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



    <!-- Modal Confirmacion escaneo -->
    <div id="modal_segurin" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Escanear Documento</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, desea escanear documento?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Escanear_confirm" class="btn btn-success"><i class="fa fa-upload fa-fw"></i>Escanear</button>             
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal Confirmacion escaneo -->
    <div id="modal_segurin_upload" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Subir Documento</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, desea subir documento?</p>

                            <%--FRONT HTML--%>
        <div class="col-lg-6">
            <input type="file" name="file1" id="file1" class="inputfile"/>
            <label for="file1" class="btn btn-primary btn-lg" style="background-color: transparent; color: green; border: transparent;cursor:pointer">
                <i class="fa fa-paperclip fa-2x" aria-hidden="true"></i>
            </label>
        </div>

        <div class="col-lg-12 text-center">
            <img src="#" id="ImgMed" style="max-width: 15%; border: 1px #009639 solid; padding: 1rem" hidden />
        </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Upload_confirm" class="btn btn-success"><i class="fa fa-upload fa-fw"></i>Subir</button>             
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal Galeria de Imagenes -->
    <div id="modal_Modificar" class="modal fade" role="dialog" style="max-height:90vh; min-height:89vh">
        <div class="modal-dialog" style="max-width: 90vw; max-height:90vh; min-height:89vh">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <div class="col">
                        <div class="row">
                            <div class="col-lg">
                                <h4 class="modal-title" style="text-align:center;">Exámenes Actuales</h4>
                                <div id="Div_Tabla_Modal" style="overflow:auto;"></div>
                                <br />
                                <div class="row">
                                    <div class="col-lg">
                         <%--               <select id="ddl_preve_modi" class="form-control" style="max-width:9vw;">
                                            <option>Previsión</option>
                                        </select>--%>
                                    </div>
                                    <div class="col-lg">
                                        <h4 class="modal-title" style="text-align:center;">Exámenes Nuevos</h4>
                                    </div>
                                    <div class="col-lg">
                                        <div class="row">
                                            <div class="col-sm">
                                                <label style="cursor:pointer" for="chk_new_date"> Nueva F. Ingreso</label>
                                                <input type="checkbox" id="chk_new_date" style="cursor:pointer; border-radius:5px;"/>

                <%--if ($("#checkBox999").is(':checked')) {--%>
                                            </div>
                                            <div class="col-sm">
                                                <div class='input-group date' id='Txt_Date03'>
                                                    <input type='text' id="fecha3" class="form-control form-control-sm" readonly="true" placeholder="Fecha..." />
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="Div_Tabla_Modal_Nuevos" style="overflow:auto;"></div>
                            </div>                     
                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">
                    <br />
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-2"><label>Total Fonasa</label><input type="text" id="lbl_tot_fonasa" style="font-weight:700" class="form-control" disabled="disabled"/></div>
                        <div class="col-sm-2"><label>T. Copa Fonasa</label><input type="text" id="lbl_total_copago_fonasa" style="font-weight:700" class="form-control" disabled="disabled" value="0"/></div>
                        <div class="col-sm-2"><label>Total a Pagar</label><input type="text" id="lbl_total_a_pagar" style="font-weight:700" class="form-control" disabled="disabled" value="0"/></div>
                        <div class="col-sm-1"></div>
                        <div class="col-sm-2"><br /><button type="button" id="Btn_Modificar_Final" class="btn btn-success"><i class="fa fa-fw fa-save mr-2"></i>Modificar</button> </div>
                        <div class="col-sm-2"><br /><button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button></div>                  
                    </div>
                </div>
            </div>
        </div>
    </div>








    <div class="card border-bar">
        <%----------------------------------------------------- CARGA DE IMAGEN --------------------------------------------------------%>




        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Modificación Atención Caja</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-2">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-2">
                    <label for="fecha2">Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-4">

                </div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-2">
                    <label>Folio</label>
                    <input type="text" id="txt_Folio" class="form-control form-control-sm"/>
                </div>
            </div>
            <div class="row">
                <div class="col-lg">    
                    <label>Procedencia</label>
                    <select id="Ddl_LugarTM" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg">
                    <label>Previsión</label>
                    <select id="Ddl_Preve" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg">
                    <label class="textoReducido">Doctor:</label>
                    <select id="Doctor" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg">
                    <label class="textoReducido">Estado:</label>
                    <select id="ddl_estado" class="form-control form-control-sm">
                        <option value="0">Todos</option>
                        <option value="1">Revisado</option>
                        <option value="2">No Revisado</option>
                    </select>
                </div>
                <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Buscar" class="btn btn-buscar btn-block btn-sm"><i class="fa fa-search fa-fw"></i>Buscar</button>
                </div>
                <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Buscar_Folio" class="btn btn-print btn-block btn-sm"><i class="fa fa-search-plus fa-fw"></i>Folio</button>
                </div>
            </div>
        </div>
    </div>

    <%--------------------------------------- DIV /2 PARA DOBLE DIV----------------------------------------%>

        <div id="Div_Tabla_Dual">
            <div class="row">
                <div id="Div_Tabla_2" class ="col-lg-6">

                </div>
                <div class="col-lg">

                </div>
            </div>
    </div>

    <%------------------------------------- FIN DIV /2 PARA DOBLE DIV -------------------------------------%>
    
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
</asp:Content>
