<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Boleta_Electronica.aspx.vb" Inherits="Presentacion.Boleta_Electronica1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let ATE_NUM = "";

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

        $(document).ready(() => {



            Call_AJAX_Ddl();
            Ajax_Ddl_usuario();

            $("#txt_Folio").val("");
            let dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input, #Txt_Date03 input, #Txt_Date04 input, #Txt_Date08 input, #Txt_Date09 input").val(dateNow);

            $('#Txt_Date01, #Txt_Date02, #Txt_Date03, #Txt_Date04, #Txt_Date08, #Txt_Date09').datetimepicker({
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

            ATE_NUM = getParameterByName("AN");

            Llenar_DataTable_ATE();

            $("#Txt_Date01 input, #Txt_Date02 input").change(() => {
                Llenar_DataTable_ATE();
            });

            $("#txt_Folio").focus();
            $("#btn_Anula_Interno").attr("disabled", "disabled");
            $("#btn_Anula_Boleta").attr("disabled", "disabled");
            $("#btn_Ver_Boleta").attr("disabled", "disabled");
            $("#btn_Boleta").attr("disabled", "disabled");
            $("#btn_NC").attr("disabled", "disabled");

            if (ATE_NUM != "") {
                $("#txt_Folio").val(ATE_NUM);
                fn_Ver_Boleta();
                Llenar_DataTable();

            }

            $("#Btn_Buscar").click(() => {
                if ($("#txt_Folio").val() != "") {
                    ATE_NUM = $("#txt_Folio").val();
                    Llenar_DataTable();
                    fn_Ver_Boleta();
                }
            });

            $("#btn_Boleta").click(() => {

                //console.clear();

                console.log("Emite Boleta Electronica");
                if (ATE_NUM != "") {
                    fn_Boleta();
                }
            });


            $("#Btn_Rep").click(() => {

                $("#mdl_Reporte").modal("show");

            });

            $("#Btn_Rep_usuario").click(() => {

                $("#mdl_Reporte_usuario").modal("show");

            });

            $("#btn_Busca_Rep").click(() => {

                fn_Reporte();

            });

            $("#btn_Busca_Rep_usuario").click(() => {

                fn_Reporte_usuario();

            });

            
            $("#btn_Excel_Rep").click(() => {

                fn_Exportar();

            });
            
            $("#btn_Excel_Rep_usuario").click(() => {

                fn_Exportar_usuario();

            });

            $("#btn_Ver_Boleta").click(() => {

                console.clear();

                console.log("Ver Boleta Electronica");
                window.open(Mx_Bol.URL_BOLETA);

            });

            $("#btn_NC").click(() => {

                console.clear();

                console.log("Ver Nota Credito");
                window.open(Mx_Bol.URL_NC);

            });

            $("#btn_Refresh").click(() => {

                //console.clear();

                Llenar_DataTable_ATE();
            });

            $("#btn_Anular").click(() => {
                console.log("Anular Boleta Electronica");
                if (ATE_NUM != "") {
                    fn_Anula_Boleta();
                }
            });
            $("#btn_Anular_Interno").click(() => {
                console.log("Anular Boleta Interno");
                if (ATE_NUM != "") {
                    fn_Anula_Boleta_Interno();
                }
            });

            $("#btn_Anula_Boleta").click(() => {

                $("#mdl_Anular").modal("show");

            });

            $("#btn_Anula_Interno").click(() => {

                $("#mdl_Anular_Interno").modal("show");

            });

            $("#btn_Left").click(() => {
                if ($("#txt_Folio").val() != "") {
                    let v_txt_Ate = $("#txt_Folio").val();
                    if (v_txt_Ate != "" && $.isNumeric(v_txt_Ate) == true && v_txt_Ate > 1) {
                        v_txt_Ate = parseInt(v_txt_Ate) - 1;
                        $("#txt_Folio").val(v_txt_Ate);
                        ATE_NUM = v_txt_Ate;
                        Llenar_DataTable();
                        fn_Ver_Boleta();
                    }
                }
            });

            $("#btn_Right").click(() => {
                if ($("#txt_Folio").val() != "") {
                    let v_txt_Ate = $("#txt_Folio").val();
                    if (v_txt_Ate != "" && $.isNumeric(v_txt_Ate) == true) {
                        v_txt_Ate = parseInt(v_txt_Ate) + 1;
                        $("#txt_Folio").val(v_txt_Ate);
                        ATE_NUM = v_txt_Ate;
                        Llenar_DataTable();
                        fn_Ver_Boleta();
                    }
                }
            });

            $("#txt_Folio").on('keypress', (e) => {
                if (e.which == 13) {
                    if ($("#txt_Folio").val() != "") {
                        ATE_NUM = $("#txt_Folio").val();
                        Llenar_DataTable();
                        fn_Ver_Boleta();
                    }
                }
            });

            $("#Btn_Limpiar").click(() => {
                ATE_NUM = "";
                $("#Ate_Folio").text("");
                $("#Ate_Nombre").text("");
                $("#Ate_Fecha").text("");
                $("#Ate_Rut").text("");
                $("#Ate_Proce").text("");
                $("#Ate_Preve").text("");
                $("#txt_Folio").val("");
                $("#est_Boleta").html("");
                $("#btn_Ver_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Interno").attr("disabled", "disabled");
                $("#btn_NC").attr("disabled", "disabled");
                $("#btn_Boleta").attr("disabled", "disabled");
                $("#txt_Folio").focus();
            });

        });

        var Mx_Ddl = [{
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }];

        function Call_AJAX_Ddl() {
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "/Buscar_Ate/Buscar_Atencion.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    Mx_Ddl = data.d;
                    Fill_Ddl();
                },
                "error": data => {
                    console.log(data);
                }
            });
        }

        function Fill_Ddl_usu() {
            $("#DdlExamen").empty();

            //$("<option>", {
            //    "value": 0
            //}).text("Todos").appendTo("#DdlExamen");
            for (y = 0; y < Mx_Ddl_usu.length; ++y) {
                $("<option>", {
                    "value": Mx_Ddl_usu[y].ID_USUARIO}).text(Mx_Ddl_usu[y].USU_NIC).appendTo("#DdlExamen");
            }
        };

        function Fill_Ddl() {
            var procee = Galletas.getGalleta("USU_ID_PROC");

            $("#slt_Proc").empty();

            if (procee == 0) {
                $("#slt_Proc").append(
                    $("<option>", {
                        "value": "0"
                    }).text("TODOS")
                );
            }
            Mx_Ddl.forEach(aaa => {
                $("#slt_Proc").append(
                    $("<option>", {
                        "value": aaa.ID_PROCEDENCIA
                    }).text(aaa.PROC_DESC)
                );
            });
        }

        let Mx_Ate = [{
            "ATE_NUM": "",
            "FOLIO_CNE": "",
            "URL_BOLETA": "",
            "USUARIO":""
        }];

        function Llenar_DataTable_ATE() {

            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val()
            });
            //Debug
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Llenar_DataTable_ATE",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ate = data.d;
                    //console.log(Mx_Ate);
                    if (Mx_Ate != null) {
                        Fill_DataTable_ATE();
                    } else {
                        $("#DataTable tbody").empty();
                    }

                },
                "error": data => {
                    $("#DataTable tbody").empty();
                }
            });
        }

        function Fill_DataTable_ATE() {
            console.log("Fill DTT ATE");
            $("#DataTable tbody").empty();

            Mx_Ate.forEach(aah=> {
                //console.log(aah.ATE_NUM);

                $("<tr>", { "data-folio": aah.ATE_NUM, "name": "tr_Ate" }).append(
                    $("<td>", { "class": "text-right" }).text(aah.ATE_NUM),
                    $("<td>", { "class": "text-right" }).text(() => {
                        if (aah.FOLIO_CNE == "") { return ""; } else { return aah.FOLIO_CNE; }
                    }),
                    $("<td>", { "class": "text-center" }).html(() => {
                        if (aah.URL_BOLETA == "" && aah.FOLIO_CNE == "" && aah.FOLIO_CNE_NC == "") {
                            return "No emitida";
                        } else if (aah.FOLIO_CNE == "" && aah.FOLIO_CNE_NC != "") {
                            return "<span class='text-danger'>Anulada</span>";
                        } else {
                            return "<a class='btn btn-success btn-sm pt-0 pb-0' href='" + aah.URL_BOLETA + "' target='_blank'>Ver Boleta</a>";
                        }
                    }),
                    $("<td>", { "class": "text-right" }).text(() => {
                        if (aah.FOLIO_CNE_NC == "") { return ""; } else { return aah.FOLIO_CNE_NC; }
                    }),
                    $("<td>", { "class": "text-center" }).html(() => {
                        if (aah.URL_NC == "") {
                            return "";
                        } else {
                            return "<a class='btn btn-warning btn-sm pt-0 pb-0' href='" + aah.URL_NC + "' target='_blank'>Ver NC</a>";
                        }
                    }),
                             $("<td>", { "class": "text-right" }).text(() => {
                                 if (aah.FOLIO_CNE == "") { return ""; } else { return aah.USUARIO; }
                             })

                 ).appendTo("#DataTable tbody");

            });

            $("tr[name='tr_Ate']").click((e) => {
                let A_N = $(e.currentTarget).attr("data-folio");
                $("#txt_Folio").val(A_N);
                $("#Btn_Buscar").trigger("click");
            });
        }

        function modal_show() {
            $(".modalcarga").show();
            $(".container-fluid, .navbar").addClass("blur");


        };

        function Hide_Modal() {
            $(".container-fluid, .navbar").removeClass("blur");
            $(".modalcarga").fadeOut(250);
        }

        let Mx_DataTable = [{
            "ID_ATENCION": "",
            "ATE_NUM": "",
            "ATE_FECHA": "",
            "PAC_NOMBRE": "",
            "PAC_APELLIDO": "",
            "ID_PACIENTE": "",
            "PAC_RUT": "",
            "PREVE_DESC": "",
            "PROC_DESC": ""
        }];

        function Llenar_DataTable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": ATE_NUM
            });
            //Debug
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_DataTable = data.d;

                    if (Mx_DataTable != null) {
                        Fill_DataTable();
                    }

                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }

        function Fill_DataTable() {
            $("#Ate_Folio").text(Mx_DataTable.ATE_NUM);
            $("#Ate_Nombre").text(Mx_DataTable.PAC_NOMBRE + " " + Mx_DataTable.PAC_APELLIDO);
            $("#Ate_Fecha").text(moment(Mx_DataTable.ATE_FECHA).format("DD-MM-YYYY"));
            $("#Ate_Rut").text(Mx_DataTable.PAC_RUT);
            $("#Ate_Proce").text(Mx_DataTable.PROC_DESC);
            $("#Ate_Preve").text(Mx_DataTable.PREVE_DESC);
        }

        let Mx_Bol = {
            FOLIO_CNE: "",
            URL_BOLETA: "",
            FOLIO_CNE_NC: "",
            URL_NC: ""
        };

        function fn_Show_Btns(n) {

            if (n == 1) { //Sin NC con Boleta
                console.log("n1");
                $("#btn_Ver_Boleta").removeAttr("disabled");
                $("#btn_Anula_Boleta").removeAttr("disabled");
                $("#btn_Anula_Interno").removeAttr("disabled");
                $("#btn_NC").attr("disabled", "disabled");
                $("#btn_Boleta").attr("disabled", "disabled");
            } else if (n == 2) { //Con NC Con Boleta
                console.log("n2");
                $("#btn_Ver_Boleta").removeAttr("disabled");
                $("#btn_Anula_Boleta").removeAttr("disabled");
                $("#btn_Anula_Interno").removeAttr("disabled");
                $("#btn_NC").removeAttr("disabled");
                $("#btn_Boleta").attr("disabled", "disabled");
            } else if (n == 3) { //Con NC sin Boleta
                console.log("n3");
                $("#btn_Ver_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Interno").attr("disabled", "disabled");
                $("#btn_NC").removeAttr("disabled");
                $("#btn_Boleta").removeAttr("disabled");
            } else if (n == 4) { // Sin NC Sin Boleta
                console.log("n4");
                $("#btn_Ver_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Interno").attr("disabled", "disabled");
                $("#btn_Boleta").removeAttr("disabled");
                $("#btn_NC").attr("disabled", "disabled");
            } else {
                console.log("n5");
                $("#btn_Ver_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Boleta").attr("disabled", "disabled");
                $("#btn_Anula_Interno").attr("disabled", "disabled");
                $("#btn_Boleta").attr("disabled", "disabled");
                $("#btn_NC").attr("disabled", "disabled");
            }
        }

        function fn_Ver_Boleta() {
            modal_show();
            console.log("Busca Boleta");

            let Data_Par = JSON.stringify({
                Folio: ATE_NUM
            });

            Mx_Bol = [];

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Ver_Boleta_Electronica",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //console.log(data);
                    Mx_Bol = data.d;
                    if (data.d != null) {
                        if (data.d.URL_BOLETA != "" && data.d.URL_BOLETA != null) {


                            $("#est_Boleta").html("Boleta generada con Folio: <b class='text-danger'>" + Mx_Bol.FOLIO_CNE + "</b>");

                            if (data.d.URL_NC != "") {
                                fn_Show_Btns(2);
                            } else {
                                fn_Show_Btns(1);
                            }

                            //window.open(data.d.URL_BOLETA);
                        } else {
                            if (data.d.CONT == 0) {
                                $("#est_Boleta").html("<span class='text-danger'>Exámenes sin boleta electrónica afecta</span>");
                                fn_Show_Btns(5);
                            } else if (data.d.FOLIO_CNE == "" && data.d.FOLIO_CNE_NC != "") {
                                $("#est_Boleta").text("Boleta Anulada");
                                fn_Show_Btns(3);
                            } else {
                                $("#est_Boleta").text("Boleta no emitida");
                                fn_Show_Btns(4);
                            }

                        }
                    } else {
                        $("#est_Boleta").text("Boleta no emitida");
                        fn_Show_Btns(4);
                    }
                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }
        function fn_Anula_Boleta_Interno() {
            modal_show();
            let Data_Par = JSON.stringify({
                ATE_NUM: ATE_NUM,
                FOLIO_CNE: Mx_Bol.FOLIO_CNE,
                USUARIO: Galletas.getGalleta("NICKNAME")
            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Desvincular_BE",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    $("#mdl_Anular_Interno").modal("hide");
                    fn_Ver_Boleta();
                    Llenar_DataTable_ATE();

                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }
        function fn_Anula_Boleta() {
            modal_show();
            let Data_Par = JSON.stringify({
                Folio: ATE_NUM,
                URL_CNE: "http://movil.cnesoftware2.cl/wsdls/wsdlboletas/Wsboletas.php",
                USUARIO: Galletas.getGalleta("NICKNAME")
            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Anula_Boleta_Electronica",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    $("#mdl_Anular").modal("hide");
                    fn_Ver_Boleta();
                    Llenar_DataTable_ATE();
                    if (data.d != null && data.d.glosa == "Documento Generado Exitoso") {
                        window.open(data.d.rutadocumento);
                        fn_Ver_Boleta();
                        Llenar_DataTable_ATE();
                    } else {
                        //if (data.d.glosa = "Exámenes sin boleta electrónica afecta") {
                        $("#est_Boleta").html("<span class='text-danger'>No se pudo anular la Boleta Electrónica</span>");
                        //}
                    }
                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }

        var Mx_Ddl_usu = [
        {
            "ID_USUARIO": 0,
            "USU_NOMBRE": "asdf",
            "USU_APELLIDO": "asdf",
            "ID_ESTADO": 0,
            "USU_NIC": "asdf"
        }
            ];

        function Ajax_Ddl_usuario() {



            $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Llenar_Ddl",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Ddl_usu = json_receiver;
                        Fill_Ddl_usu();

                    } else {

                    }
                },
                "error": function (response) {
                    //cModal_Error("ERROR", "A ocurrido un error a nivel interno del lado del Server, disculpe las molestias.");


                }
            });
        }

        function fn_Boleta() {

            //let lst_Det = [
            //    {
            //        NmbItem: "TSH", // CF_DESC
            //        PrcItem: "1500", // PRECIO_PREVE
            //        IndExe: "0", // SI ES EXENTO O NO
            //        TieneIVA: "1" // SI EL VALOR VIENE CON VIA O NO
            //    }, {
            //        NmbItem: "Glicemia",
            //        PrcItem: "1000",
            //        IndExe: "0",
            //        TieneIVA: "1"
            //    }, {
            //        NmbItem: "Hemograma",
            //        PrcItem: "5000",
            //        IndExe: "0",
            //        TieneIVA: "0"
            //    }];
            //let _Params = {
            //    Folio: "24", // FOLIO ATENCION
            //    FormaEmision: "1", // 1 CONTADO, 2 CREDITO
            //    RUTReceptor: "18.490.960-K", // RUT PACIENTE
            //    RznSocRecep: "Carlos Velozo Weinberger", // NOMBRE PACIENTE
            //    DirRecep: "Le Mans 1550", //  DIRECCION PACIENTE
            //    CmnaRecep: "Osorno", // COMUNA PACIENTE
            //    CiudadRecep: "Osorno", // CIUDAD PACIENTE
            //    Lst_Detalle: lst_Det, // LISTA DE EXAMENES
            //    RazonRef: "Pago en Efectivo", // OBSERVACION DE PAGO
            //    CodVndor: "CVELOZO", // USUNIC
            //    CodCaja: "CAJA-CVELOZO" // CAJA-USUNIC
            //};
            modal_show();
            let Data_Par = JSON.stringify({
                Folio: ATE_NUM,
                URL_CNE: "http://movil.cnesoftware2.cl/wsdls/wsdlboletas/Wsboletas.php",
                USUARIO: Galletas.getGalleta("NICKNAME")
            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Boleta_Electronica",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    if (data.d != null && data.d.glosa == "Documento Generado Exitoso") {
                        window.open(data.d.rutadocumento);
                        fn_Ver_Boleta();
                        Llenar_DataTable_ATE();
                    } else {
                        console.log(data.d);
                        if (data.d.glosa = "Exámenes sin boleta electrónica afecta") {
                            $("#est_Boleta").html("<span class='text-danger'>Exámenes sin boleta electrónica afecta</span>");
                        }
                    }
                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data.d);
                }
            });

        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function fn_Reporte() {
            modal_show();
            let Data_Par = JSON.stringify({
                DESDE: $("#fecha3").val(),
                HASTA: $("#fecha4").val(),
                ID_PROCEDENCIA: $("#slt_Proc").val()
            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Reporte",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    let net = 0, iva = 0, tot=0;

                    data.d.forEach(aah=> {
                        $("<tr>").append(
                            $("<td>").text(aah.FOLIO),
                            $("<td>").text(moment(aah.FECHA).format("DD-MM-YYYY HH:mm:ss")),
                            $("<td>").text(aah.RUT),
                            $("<td>").text(aah.NOMBRE),
                            $("<td>").text(aah.COD),
                            $("<td>").text(aah.EXAMEN),
                            $("<td>").text(aah.PROCEDENCIA),
                            $("<td>").text(aah.TP_PAGO),
                            $("<td>").text(aah.BOLETA),
                            $("<td>", {"class":"text-right"}).text(aah.NETO),
                            $("<td>", { "class": "text-right" }).text(aah.IVA),
                            $("<td>", { "class": "text-right" }).text(aah.TOTAL)

                        ).appendTo("#Table_Reporte tbody");

                        net += aah.NETO;
                        iva += aah.IVA;
                        tot += aah.TOTAL;
                    });

                    $("#ttl_Neto").text(addCommas(net));
                    $("#ttl_IVA").text(addCommas(iva));
                    $("#ttl_Total").text(addCommas(tot));


                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }

        function fn_Reporte_usuario() {
            modal_show();
            let Data_Par = JSON.stringify({
                DESDE: $("#fecha3").val(),
                HASTA: $("#fecha4").val(),
                USU_NIC: $("#DdlExamen option:selected").text()
            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Reporte_usuario",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    let net2 = 0, iva2 = 0, tot2 = 0;

                   

                    $("#Table_Reporte_usuario tbody").empty();

                    data.d.forEach(aah=> {

                        

                        $("<tr>").append(
                            $("<td>").text(aah.ATE_NUM),
                            $("<td>").text(moment(aah.ATE_FECHA).format("DD-MM-YYYY HH:mm:ss")),
                            $("<td>").text(aah.PAC_RUT),
                            $("<td>").text(aah.PAC_NOMBRE + " " + aah.PAC_APELLIDO),
                            $("<td>").text(aah.FOLIO_CNE),
                            $("<td>").text("$" + addCommas(aah.TOTAL)),
                            $("<td>").text(aah.USUARIO)

                        ).appendTo("#Table_Reporte_usuario tbody");

                        net2 += aah.NETO;
                        iva2 += aah.IVA;
                        tot2 += aah.TOTAL;
                    });

                    $("#ttl_Neto2").text(addCommas(net2));
                    $("#ttl_IVA2").text(addCommas(iva2));
                    $("#ttl_Total2").text(addCommas(tot2));


                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }

        function fn_Exportar() {
            modal_show();
            let Data_Par = JSON.stringify({
                DOMAIN_URL: location.origin,
                DESDE: $("#fecha3").val(),
                HASTA: $("#fecha4").val(),
                ID_PROCEDENCIA: $("#slt_Proc").val()
                
            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Exportar",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    var json_receiver = data.d;
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();

                    }


                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }

        function fn_Exportar_usuario() {
            modal_show();
            let Data_Par = JSON.stringify({
                DOMAIN_URL: location.origin,
                DESDE: $("#fecha8").val(),
                HASTA: $("#fecha9").val(),
                USU_NIC: $("#DdlExamen option:selected").text()

            });

            AJAX_Datos = $.ajax({
                "type": "POST",
                "url": "Boleta_Electronica.aspx/Exportar_usuario",
                "data": Data_Par,
                "contentType": "application/json; charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data);

                    var json_receiver = data.d;
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();

                    }


                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                    console.log(data);
                }
            });
        }


    </script>
    <style>
        .f-h5 {
            font-size: 1.2rem;
        }
    </style>

    <div class="modal modalcarga">
        <div>
            <h2><b>Cargando...</b></h2>
            <div class="flex-content">
                <div class="box2">
                    <div style="display: inline-block">
                        <img class="imght" src="/Imagenes/ILWS.png" />
                    </div>
                </div>
                <div class="box1">
                    <img class="img360" src="/Imagenes/IRISSSS.png" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" role="dialog" id="mdl_Anular">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white text-center">
                    <h4 class="modal-title m-0">Anular Boleta</h4>
                </div>
                <div class="modal-body">
                    <p>¿Está seguro que desea anular la boleta electrónica?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btn_Anular">Anular</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" role="dialog" id="mdl_Reporte">
        <div class="modal-dialog modal-lg" role="document" style="width:80vw !important;max-width:80vw !important">
            <div class="modal-content">
                <div class="modal-header bg-bar text-white text-center">
                    <h4 class="modal-title m-0">Reporte Boleta</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <label class="m-0" for="fecha3">Desde:</label>
                            <div class='input-group date' id='Txt_Date03'>
                                <input type='text' id="fecha3" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label class="m-0" for="fecha4">Hasta:</label>
                            <div class='input-group date' id='Txt_Date04'>
                                <input type='text' id="fecha4" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <label class="m-0" for="slt_Proc">Procedencia:</label>
                            <select id="slt_Proc" class="form-control form-control-sm"></select>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="btn_Busca_Rep" class="btn btn-primary btn-block mt-3">Buscar</button>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="btn_Excel_Rep" class="btn btn-success btn-block mt-3">Exportar</button>
                        </div>
                    </div>
                     <div class="row mt-3">
                         <div class="col-lg-4 text-danger">
                             <h3>Neto: $<label id="ttl_Neto"></label></h3>
                         </div>
                         <div class="col-lg-4 text-danger">
                             <h3>IVA: $<label id="ttl_IVA"></label></h3>
                         </div>
                         <div class="col-lg-4 text-danger">
                             <h3>Total: $<label id="ttl_Total"></label></h3>
                         </div>
                        </div>
                    <div class="row mt-3">
                        <div class="col-12" style="overflow:auto">
                            <table id="Table_Reporte" cellspacing="0" class="table table-hover table-striped table-iris table-iris">
                                <thead>
                                    <tr>
                                        <th class="text-left">Folio
                                        </th>
                                        <th class="text-left">Fecha
                                        </th>
                                        <th class="text-left">RUT
                                        </th>
                                        <th class="text-left">Paciente
                                        </th>
                                        <th class="text-left">Código
                                        </th>
                                        <th class="text-left">Examen
                                        </th>
                                        <th class="text-left">Procedencia
                                        </th>
                                        <th class="text-left">Tipo Pago
                                        </th>
                                        <th class="text-left">N° Boleta
                                        </th>
                                        <th class="text-right">Neto
                                        </th>
                                        <th class="text-right">IVA
                                        </th>
                                        <th class="text-right">Total
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

        <div class="modal" tabindex="-1" role="dialog" id="mdl_Reporte_usuario">
        <div class="modal-dialog modal-lg" role="document" style="width:80vw !important;max-width:80vw !important">
            <div class="modal-content">
                <div class="modal-header bg-bar text-white text-center">
                    <h4 class="modal-title m-0">Reporte Boleta por Usuario</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <label class="m-0" for="fecha8">Desde:</label>
                            <div class='input-group date' id='Txt_Date08'>
                                <input type='text' id="fecha8" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg">
                            <label class="m-0" for="fecha9">Hasta:</label>
                            <div class='input-group date' id='Txt_Date09'>
                                <input type='text' id="fecha9" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <label class="m-0" for="DdlExamen">Usuario:</label>
                            <select id="DdlExamen" class="form-control form-control-sm"></select>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="btn_Busca_Rep_usuario" class="btn btn-primary btn-block mt-3">Buscar</button>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="btn_Excel_Rep_usuario" class="btn btn-success btn-block mt-3">Exportar</button>
                        </div>
                    </div>
                    <div class="row mt-3">
                         <div class="col-lg-4 text-danger">
                             <h3>Neto: $<label id="ttl_Neto2"></label></h3>
                         </div>
                         <div class="col-lg-4 text-danger">
                             <h3>IVA: $<label id="ttl_IVA2"></label></h3>
                         </div>
                         <div class="col-lg-4 text-danger">
                             <h3>Total: $<label id="ttl_Total2"></label></h3>
                         </div>
                        </div>
                    <div class="row mt-3">
                        <div class="col-12" style="overflow:auto">
                            <table id="Table_Reporte_usuario" cellspacing="0" class="table table-hover table-striped table-iris table-iris">
                                <thead>
                                    <tr>
                                        <th class="text-left">Folio
                                        </th>
                                        <th class="text-left">Fecha
                                        </th>
                                        <th class="text-left">RUT
                                        </th>
                                        <th class="text-left">Paciente
                                        </th>
                                        <th class="text-left">N° Boleta
                                        </th>
                                        <th class="text-left">Total
                                        </th>
                                         <th class="text-left">Usuario Emisor
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" role="dialog" id="mdl_Anular_Interno">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white text-center">
                    <h4 class="modal-title m-0">Desvincular Boleta</h4>
                </div>
                <div class="modal-body">
                    <p>¿Está seguro que desea desvincular la boleta electrónica?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btn_Anular_Interno">Desvincular</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="row mb-3 w-100">
        <div class="col-lg-12 text-center">
            <h1>Boleta Electrónica</h1>
        </div>
    </div>

    <div class="row m-0">
        <div class="col-lg-8">
            <div class="card border-bar mb-3 mt-3">
                <div class="card-header text-center bg-bar">
                    <h5 class="m-0"><i class="fa fa-user fa-fw"></i>Datos de Atención</h5>
                </div>
                <div class="card-body">
                    <div class="row mb-2">

                        <div class="col-lg-4 mb-2">
                            <div class="row">
                                <div class="col pr-0">
                                    Folio:
                                </div>
                                <i class="fa fa-arrow-left d-inline btn btn-sm btn-primary" id="btn_Left" style="border-radius: .2rem 0px 0px .2rem"></i>
                                <div class="col-6 p-0">
                                    <input type="text" id="txt_Folio" class="form-control form-control-sm text-danger font-weight-bold pt-0 pb-0" style="font-size: 1.2rem; border-radius: 0px;" />
                                </div>
                                <i class="fa fa-arrow-right d-inline btn btn-sm btn-primary" id="btn_Right" style="border-radius: 0px .2rem .2rem 0px"></i>
                            </div>
                        </div>
                        <div class="col-lg mb-2">
                            <button type="button" id="Btn_Buscar" class="btn btn-buscar btn-sm btn-block mt-0">Buscar</button>
                        </div>
                        <div class="col-lg mb-2">
                            <button type="button" id="Btn_Limpiar" class="btn btn-limpiar btn-sm btn-block mt-0">Limpiar</button>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="Btn_Rep" class="btn btn-success btn-sm btn-block mt-0">Reporte</button>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" id="Btn_Rep_usuario" class="btn btn-success btn-sm btn-block mt-0">Rep. Usuario</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2"></div>
                        <div class="col-lg f-h5">Folio: <span id="Ate_Folio" style="color: #014758 !important; font-weight: 600;"></span></div>
                        <div class="col-lg-4 f-h5">Fecha: <span id="Ate_Fecha" style="color: #014758 !important; font-weight: 600;"></span></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2"></div>
                        <div class="col-lg f-h5">Nombre: <span id="Ate_Nombre" style="color: #014758 !important; font-weight: 600;"></span></div>
                        <div class="col-lg-4 f-h5">RUT: <span id="Ate_Rut" style="color: #014758 !important; font-weight: 600;"></span></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2"></div>
                        <div class="col-lg f-h5">Procedencia: <span id="Ate_Proce" style="color: #014758 !important; font-weight: 600;"></span></div>
                        <div class="col-lg-4 f-h5">Previsión: <span id="Ate_Preve" style="color: #014758 !important; font-weight: 600;"></span></div>
                    </div>
                </div>
            </div>

            <div class="card border-bar">
                <div class="card-header bg-bar text-center">
                    <h5 class="m-0"><i class="fa fa-file-pdf-o fa-fw"></i>Boleta Electrónica</h5>
                </div>
                <div class="card-body">
                    <div class="row mt-3">
                        <div class="col-lg-12 text-center">
                            <h5 id="est_Boleta"></h5>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg text-center">
                            <button type="button" id="btn_Boleta" class="btn btn-primary m-3" disabled="disabled">Emitir Boleta</button>
                        </div>
                        <div class="col-lg text-center">
                            <button type="button" id="btn_Ver_Boleta" class="btn btn-success m-3" disabled="disabled">Ver Boleta</button>
                        </div>
                        <div class="col-lg text-center">
                            <button type="button" id="btn_Anula_Interno" class="btn btn-danger m-3" disabled="disabled">Desvincular Boleta</button>
                        </div>
                        <div class="col-lg text-center" hidden>
                            <button type="button" id="btn_Anula_Boleta" class="btn btn-danger m-3" disabled="disabled">Anular Boleta</button>
                        </div>
                        <div class="col-lg text-center" hidden>
                            <button type="button" id="btn_NC" class="btn btn-warning m-3" disabled="disabled">Ver Nota Crédito</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="card border-bar mb-3 mt-3">
                <div class="card-header text-center bg-bar">
                    <h5 class="m-0"><i class="fa fa-list fa-fw"></i>Atenciones</h5>
                </div>
                <div class="card-body p-1" style="max-height: 393px; overflow: auto;">
                    <div class="row m-0 pb-1">
                        <div class="col-lg-5">
                            <label class="m-0" for="fecha">Desde:</label>
                            <div class='input-group date' id='Txt_Date01'>
                                <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-5">
                            <label class="m-0" for="fecha2">Hasta:</label>
                            <div class='input-group date' id='Txt_Date02'>
                                <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <br />
                            <button type="button" class="btn btn-primary" id="btn_Refresh"><i class="fa fa-refresh"></i></button>
                        </div>
                    </div>
                    <table id="DataTable" cellspacing="0" class="table table-hover table-striped table-iris table-iris">
                        <thead>
                            <tr>
                                <th class="text-right">Folio
                                </th>
                                <th class="text-right">N° Boleta
                                </th>
                                <th class="text-center">Estado
                                </th>
                                <th class="text-right">N° NC
                                </th>
                                <th class="text-center">NC
                                </th>
                                <th class="text-center">Emisor
                                </th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
