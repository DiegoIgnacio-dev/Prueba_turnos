<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Rev_Deter_Exa_EMB_Trans.aspx.vb" Inherits="Presentacion.Rev_Deter_Exa_EMB_Trans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script src="/js/IrisLabResourses.js"></script>
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        $(document).ready(function () {
            $("#Id_Conte").hide();
            //Ajax_previ();
            //Ajax_Exam();
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input").val(dateNow);
            $('#Txt_Date01').datetimepicker(
                {
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
                }
            );

            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date02 input").val(dateNow);
            $('#Txt_Date02').datetimepicker(
                {
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
                }
            );
            $(".block_wait").fadeOut(0);
            $("#Div_Tabla").empty();
            $("#Div_Tabla").show();
            $("#Id_Conte").hide();
            $("#Ddl_Exam").change(function () {
                if ($("#Ddl_Exam").val() != 0) {
                    Ajax_Det();
                } else {
                    //$("#mError_AAH h4").text("Seleccione");
                    //$("#mError_AAH button").attr("class", "btn btn-danger");
                    //$("#mError_AAH p").text("Por favor seleccione un examen.");
                    //$("#mError_AAH").modal();
                }
            });
            //Registrar evento Click del Botón Buscar       
            $("#Btn_Buscar").click(function () {

                //function restaFechas(f1, f2) {
                //    var aFecha1 = f1.split('-');
                //    var aFecha2 = f2.split('-');
                //    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
                //    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
                //    var dif = fFecha2 - fFecha1;
                //    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
                //    return dias;
                //}

                //var Date_Diff = restaFechas(String($("#Txt_Date01 input").val()), String($("#Txt_Date02 input").val()));

                //if (Date_Diff <= 1) {
                    Ajax_DataTable();
                //} else {

                //    $("#mError_AAH h4").text("Rango de Fechas");
                //    $("#mError_AAH button").attr("class", "btn btn-danger");
                //    $("#mError_AAH p").text("Por favor, seleccione un rango de fechas máximo de 2 días.");
                //    $("#mError_AAH").modal();
                //}

                


            });
            //Registrar evento Click del Botón Excel       
            $("#Btn_Excel").click(function () {
                Ajax_Excel();
            });

            Call_AJAX_Ddl();
            $(`#Procedencia`).change(() => {
                if ($("#Procedencia").val() == 0) {
                    $("#Ddl_previ").empty();
                    $("#Ddl_programa").empty();
                    $("#Ddl_subPrograma").empty();
                    $("<option>", { "value": 0 }).text("<Todos>").appendTo("#Ddl_previ");
                    $("#Ddl_programa").append($("<option>", { "value": 0 }).text("<Todos>"));
                    $("#Ddl_subPrograma").append($("<option>", { "value": 0 }).text("<Todos>"));
                    
                } else {
                    fn_Req_Prev();
                }
                
            });

            $(`#Ddl_previ`).change(() => {
                fn_Req_Prog();
            });

            $(`#Ddl_programa`).change(() => {
                fn_Req_SubP();
            });



            $(`#Ddl_subPrograma`).change(() => {
                if (arrSubP.length > 0) {
                    let tt = $(`#Ddl_subPrograma`).val();
                    if (tt == 2) {
                        //$("#Ddl_Exam").empty();
                        //$("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");

                        //for (y = 0; y < Mx_Exam.length; ++y) {
                        //    if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                        //        $("<option>", {
                        //            "value": Mx_Exam[y].ID_CODIGO_FONASA
                        //        }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                        //    }
                        //}

                    } else {
                        //$("#Ddl_Exam").empty();

                        //$("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");

                        //for (y = 0; y < Mx_Exam.length; ++y) {
                        //    if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                        //        $("<option>", {
                        //            "value": Mx_Exam[y].ID_CODIGO_FONASA
                        //        }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                        //    }
                        //}
                    }
                }
            });

        });
    </script>
    <script>
        var Mx_Ddl = [
{
    "ID_PROCEDENCIA": "",
    "PROC_COD": "",
    "PROC_DESC": "",
    "ID_ESTADO": ""
}
        ];
        function Call_AJAX_Ddl() {
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Llenar_Ddl_LugarTM",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl = JSON.parse(json_receiver);
                        Fill_AJAX_Ddl();
                        //fn_Req_Prev();

                    } else {



                    }
                },
                "error": function (response) {

                    //console.log(reponse);


                }
            });
        }
        function Fill_AJAX_Ddl() {
            $("#Procedencia").empty();
            $("<option>",{"value": 0}).text("<Todos>").appendTo("#Procedencia");
                Mx_Ddl.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PROCEDENCIA
                        }
                    ).text(aaa.PROC_DESC).appendTo("#Procedencia");
                });
            

            //Ajax_DataTable();
        };
        //------------------------------------------------ AJAX DDL previ -------------------------------------------|
        var Mx_Dtt_previ = [
    {
        "ID_ESTADO": 0,
        "PREVE_DESC": 0,
        "PREVE_COD": 0,
        "ID_PREVE": 0
    }
        ];
        function Ajax_previ() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Llenar_DdL_prevision",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_previ = JSON.parse(json_receiver);
                        Fill_Ddl_previ();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        let objAJAX_Prev = 0;

        var arrPrev = [{
            "ID_PREVE": 0,
            "PREVE_COD": "",
            "PREVE_DESC": "",
            "ID_ESTADO": 0
        }];

        function fn_Req_Prev() {
            var objParam = JSON.stringify({
                "ID_PROC": $("#Procedencia").val()
            });

            objAJAX_Prev = $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Request_Prevision",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrPrev = resp.d;

                    //Llenar Ddl
                    $("#Ddl_previ").empty();
                    //$("#Prevision").append(
                    //    $("<option>", {
                    //        "value": 0
                    //    }).text("<< TODOS >>")
                    //);
                    arrPrev.forEach((Item) => {
                        $("#Ddl_previ").append(
                            $("<option>", {
                                "value": Item.ID_PREVE
                            }).text(Item.PREVE_DESC)
                        );
                    });

                    ////Actualizar Exámenes
                    ////Mx_Dtt_exam02.length = 0;
                    //Ajax_DataTable_examen02();
                    //$("#DataTable_pac2 tbody").empty();
                    //add_row();

                    fn_Req_Prog();
                },
                "error": (fail) => {
                    console.log(fail);
                }
            });
        };

        let objAJAX_Prog = 0;

        var arrProg = [{
            "ID_PROGRA": 0,
            "ID_PREVE": 0,
            "PROGRA_DESC": "",
        }];

        function fn_Req_Prog() {
            var objParam = JSON.stringify({
                "ID_PREV": $("#Ddl_previ").val()
            });

            objAJAX_Prog = $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Request_Programa",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrProg = resp.d;

                    //Llenar Ddl
                    $("#Ddl_programa").empty();
                    //$("#Programa").append(
                    //    $("<option>", {
                    //        "value": 0
                    //    }).text("<< TODOS >>")
                    //);
                    arrProg.forEach((Item) => {
                        $("#Ddl_programa").append(
                            $("<option>", {
                                "value": Item.ID_PROGRA
                            }).text(Item.PROGRA_DESC)
                        );
                    });

                    fn_Req_SubP();
                },
                "error": (fail) => {
                    console.log(fail);
                }
            });
        };


        let objAJAX_SubP = 0;

        var arrSubP = [{
            "SubP_ID": 0,
            "SubP_Cod": "",
            "SubP_Desc": ""
        }];

        function fn_Req_SubP() {
            var objParam = JSON.stringify({
                "ID_PREV": $("#Ddl_previ").val(),
                "ID_PROG": $("#Ddl_programa").val()
            });

            objAJAX_SubP = $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Request_SubPrograma",
                "data": objParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    arrSubP = resp.d;
                    let gg = false;
                    //Llenar Ddl
                    $("#Ddl_subPrograma").empty();
                    if (arrSubP.length > 0) {
                        arrSubP.forEach((Item) => {
                            $("#Ddl_subPrograma").append(
                                $("<option>", {
                                    "value": Item.SubP_ID
                                }).text(Item.SubP_Desc)
                            );
                        });

                    } else {
                        $("#Ddl_subPrograma").append(
                            $("<option>", {
                                "value": 1
                            }).text("<Sin SubPrograma>")
                        );
                    }
                    if (arrSubP.length > 0) {
                        for (y = 0; y < arrSubP.length; ++y) {
                            if (arrSubP[y].SubP_ID == 2) {
                                gg = true;
                            }
                        }
                        if (gg == true) {
                            //$("#Ddl_Exam").empty();
                            //$("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");

                            //for (y = 0; y < Mx_Exam.length; ++y) {
                            //    if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                            //        $("<option>", {
                            //            "value": Mx_Exam[y].ID_CODIGO_FONASA
                            //        }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                            //    }
                            //}

                        } else {
                            //$("#Ddl_Exam").empty();

                            //$("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");

                            //for (y = 0; y < Mx_Exam.length; ++y) {
                            //    if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                            //        $("<option>", {
                            //            "value": Mx_Exam[y].ID_CODIGO_FONASA
                            //        }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                            //    }
                            //}
                        }
                    }

                },
                "error": (fail) => {
                    console.log(fail);
                }
            });
        };
        //------------------------------------------------ AJAX DDL EXAMEN -------------------------------------------|
        var Mx_Exam = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Exam() {
            modal_show();

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Llenar_Ddl_Exam",
                "data": JSON.stringify({
                    ID_PREV: $("#Ddl_previ").val()
                }),
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Exam = JSON.parse(json_receiver);
                        Fill_Ddl_Exam();

                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //------------------------------------------------ AJAX Ddl_Det -------------------------------------------|
        var Mx_Dtt_Det = [
    {
        "ID_CODIGO_FONASA": 0,
        "CF_COD": 0,
        "PRU_DESC": 0,
        "ID_PRUEBA": 0,
        "CF_DESC": 0,
        "ID_ESTADO": 0
    }
        ];
        function Ajax_Det() {

            var Data_Par = JSON.stringify({
                "ID_CF": $("#Ddl_Exam").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Llenar_Ddl_Det",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Det = JSON.parse(json_receiver);
                        Fill_Ddl_Det();
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }
        //-------------------------------------------------- AJAX TABLA MAIN ----------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "CF_DESC": 0,
                "CF_COD": 0,
                "ATE_AÑO": 0,
                "PRU_DESC": 0,
                "ATE_RESULTADO": 0,
                "ATE_RESULTADO_NUM": 0,
                "ID_CODIGO_FONASA": 0,
                "ID_PRUEBA": 0,
                "PAC_FNAC": 0,
                "ID_SEXO": 0,
                "UM_DESC": 0,
                "ID_TP_RESULTADO": 0,
                "TP_RESUL_DESC": 0,
                "TP_RESUL_COD": 0,
                "ID_U_MEDIDA": 0,
                "ATE_RR_DESDE": 0,
                "ATE_R_DESDE": 0,
                "ATE_R_HASTA": 0,
                "ATE_RR_HASTA": 0,
                "PRU_DECIMAL": 0,
                "PROC_DESC": 0,
                "ATE_NUM_INTERNO": 0,
                "ATE_DNI": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "id_proce": 0,
                "NAC_DESC": 0,
                "PROGRA_DESC": 0,
                "SECTOR_DESC": 0,
                "SUBP_DESC": 0,
                "AUDI_FORMA": 0,
                "ID_ATE_RES":0
            }
        ];
        function Ajax_DataTable() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_CF": $("#Ddl_Exam").val(),
                "ID_EST": 0,
                "Procedencia": $("#Procedencia").val(),
                "Ddl_previ": $("#Ddl_previ").val(),
                "Ddl_programa": $("#Ddl_programa").val(),
                "Ddl_subPrograma": $("#Ddl_subPrograma").val(),
                "TRANSMITIDO": $("#Ddl_Transmitido").val()
            });

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt = JSON.parse(json_receiver);
                        $("#Div_Tabla").empty();
                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].ATE_FECHA = Date_Change;
                        }

                        for (i = 0; i < Mx_Dtt.length; ++i) {
                            var date_x = Mx_Dtt[i].PAC_FNAC;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt[i].PAC_FNAC = Date_Change;
                        }
                        Fill_DataTable();
                        Hide_Modal();

                        $("#Id_Conte").show();
                    } else {

                        Hide_Modal();
                        $("#Id_Conte").hide();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //-----------------------------------------------DETALLE ATENCION---------------------------------------|
        var Mx_Dtt_Det_Ate = [
  {
      "ID_DET_ATE": 0,
      "CF_DESC": 0,
      "ID_CODIGO_FONASA": 0,
      "USU_NIC": 0,
      "ID_ATENCION": 0,
      "ID_ESTADO": 0,
      "CF_COD": 0,
      "ATE_FECHA": 0,
      "ATE_DET_V_ID_USU": 0,
      "ATE_DET_V_ID_ESTADO": 0,
      "ATE_DET_V_FECHA": 0,
      "ID_PER": 0,
      "ATE_DET_IMPRIME": 0,
      "ID_TP_PAGO": 0,
      "TP_PAGO_DESC": 0,
      "PAC_NOMBRE": 0,
      "PAC_APELLIDO": 0,
      "NUM_ATE": 0,
      "ENCRYPTED_ID": 0
  }
        ];
        function Ajax_DataTable_Det_Ate(ID_ATE) {

            var Data_Par = JSON.stringify({
                "ID_ATE": ID_ATE
            });
            //$(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Llenar_DataTable_Det_Ate",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Det_Ate = JSON.parse(json_receiver);
                        for (i = 0; i < Mx_Dtt_Det_Ate.length; ++i) {
                            var date_x = Mx_Dtt_Det_Ate[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Det_Ate[i].ATE_FECHA = Date_Change;
                        }
                        $("#Div_Tabla_Listado_Exa_Ate").empty();
                        Fill_DataTable_Listado_Exa_Ate();
                        $('#numerito').text("N° Atención: " + Mx_Dtt_Det_Ate[0].NUM_ATE);
                        $('#nombrecito').text("Nombre: " + Mx_Dtt_Det_Ate[0].PAC_NOMBRE + " " + Mx_Dtt_Det_Ate[0].PAC_APELLIDO).addClass("text-uppercase");
                        $('#eModal').modal('show');

                    } else {

                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    // $("#Id_Conte").show();
                    //$(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        var Mx_Dtt_Excel = [
    {
        "urls": ""
    }
        ];
        function Ajax_Excel() {
            modal_show();

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#Txt_Date01 input").val(),
                "HASTA": $("#Txt_Date02 input").val(),
                "ID_CF": $("#Ddl_Exam").val(),
                "ID_EST": 0,
                "Procedencia": $("#Procedencia").val(),
                "Ddl_previ": $("#Ddl_previ").val(),
                "Ddl_programa": $("#Ddl_programa").val(),
                "Ddl_subPrograma": $("#Ddl_subPrograma").val(),
                "TRANSMITIDO": $("#Ddl_Transmitido").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Rev_Deter_Exa_EMB_Trans.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        //Mx_Dtt_Excel = JSON.parse(json_receiver);
                        window.open(json_receiver, 'Download');
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#Id_Conte").hide();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- Funciones de Llenado de Elementos --%>
    <script>
        //Llenar DropDownList Determinacion
        function Fill_Ddl_Det() {
            $("#Ddl_Det").empty();
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Det");
            for (y = 0; y < Mx_Dtt_Det.length; ++y) {

                $("<option>", {
                    "value": Mx_Dtt_Det[y].ID_PRUEBA
                }).text(Mx_Dtt_Det[y].PRU_DESC).appendTo("#Ddl_Det");

            }


        };
        //Llenar DropDownList Preve
        function Fill_Ddl_previ() {
            $("#Ddl_previ").empty();
            //$("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_LugarTM");
            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_previ");
            for (y = 0; y < Mx_Dtt_previ.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_previ[y].ID_PREVE
                }).text(Mx_Dtt_previ[y].PREVE_DESC).appendTo("#Ddl_previ");
            }
        };

        //Llenar DropDownList Tipo de Examen
        function Fill_Ddl_Exam() {
            $("#Ddl_Exam").empty();

            $("<option>", { "value": 0 }).text("Todos").appendTo("#Ddl_Exam");

            for (y = 0; y < Mx_Exam.length; ++y) {
                if (Mx_Exam[y].ID_CODIGO_FONASA != 682) {
                    $("<option>", {
                        "value": Mx_Exam[y].ID_CODIGO_FONASA
                    }).text(Mx_Exam[y].CF_DESC).appendTo("#Ddl_Exam");
                }
            }
        };

    </script>
    <script>
        //---------------------------------------------------- TABLA  ------------------.........-----------------------------|
        function Fill_DataTable() {
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
            $("#DataTable thead").attr("class", "cabezera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Fecha Ingreso"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Lugar TM"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("Num Interno"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac"),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rut Paciente"),
                    $("<th>", { "class": "textoReducido text-center" }).text("DNI"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Programa"),
                    $("<th>", { "class": "textoReducido" }).text("SubPrograma"),
                    $("<th>", { "class": "textoReducido" }).text("Sector"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Determinación"),
                    $("<th>", { "class": "textoReducido text-center" }).text("T"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Resultado"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Unidad"),
                    $("<th>", { "class": "textoReducido" }).text("E"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rango Desde"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Rango Hasta"),
                    //$("<th>", { "class": "textoReducido text-center" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Transmitido")
                )
            );

            var admin = Galletas.getGalleta("P_ADMIN");

            for (i = 0; i < Mx_Dtt.length; i++) {

                $("#DataTable tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_DataTable_Det_Ate("` + Mx_Dtt[i].ID_ATENCION + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).css("cssText", "text-align:center;").text(function () {
                                        //Obtener valores
                                        var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                                        var dd = parseInt(obj_date.getDate());
                                        var mm = parseInt(obj_date.getMonth()) + 1;
                                        var yy = parseInt(obj_date.getFullYear());

                                        if (dd < 10) { dd = "0" + dd; }
                                        if (mm < 10) { mm = "0" + mm; }

                                        return String(dd + "/" + mm + "/" + yy);

                                    });
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(function () {
                                    //Obtener valores
                                    var obj_date = new Date(Mx_Dtt[i].ATE_FECHA);
                                    var dd = parseInt(obj_date.getDate());
                                    var mm = parseInt(obj_date.getMonth()) + 1;
                                    var yy = parseInt(obj_date.getFullYear());

                                    if (dd < 10) { dd = "0" + dd; }
                                    if (mm < 10) { mm = "0" + mm; }

                                    return String(dd + "/" + mm + "/" + yy);

                                });
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].PROC_DESC);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].PROC_DESC);
                            }
                        }),
                        //$("<td>").css("text-align", "center").text(function () {
                        //    if (i > 0) {
                        //        if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                        //            $(this).css("cssText", "text-align:center;").text("");
                        //        }
                        //        else {
                        //            $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM_INTERNO);
                        //        }
                        //    } else {
                        //        $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_NUM_INTERNO);
                        //    }
                        //}),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(function () {
                                        //Obtener valores
                                        var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                                        var dd = parseInt(obj_date.getDate());
                                        var mm = parseInt(obj_date.getMonth()) + 1;
                                        var yy = parseInt(obj_date.getFullYear());

                                        if (dd < 10) { dd = "0" + dd; }
                                        if (mm < 10) { mm = "0" + mm; }

                                        return String(dd + "/" + mm + "/" + yy);

                                    });
                                }
                            } else {
                                $(this).text(function () {
                                    //Obtener valores
                                    var obj_date = new Date(Mx_Dtt[i].PAC_FNAC);
                                    var dd = parseInt(obj_date.getDate());
                                    var mm = parseInt(obj_date.getMonth()) + 1;
                                    var yy = parseInt(obj_date.getFullYear());

                                    if (dd < 10) { dd = "0" + dd; }
                                    if (mm < 10) { mm = "0" + mm; }

                                    return String(dd + "/" + mm + "/" + yy);

                                });
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].ATE_AÑO + " Años");
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].ATE_AÑO + " Años");
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].PAC_RUT);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].PAC_RUT);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                }
                                else {
                                    $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_DNI);
                                }
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_DNI);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].NAC_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].NAC_DESC);
                            }
                        }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].PROGRA_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].PROGRA_DESC);
                            }
                        }),
                           $("<td>").text(function () {
                               if (i > 0) {
                                   if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                       $(this).css("cssText", "text-align:center;").text("");
                                   } else {
                                       $(this).text(Mx_Dtt[i].SUBP_DESC);
                                   }
                               } else {
                                   $(this).text(Mx_Dtt[i].SUBP_DESC);
                               }
                           }),
                        $("<td>").text(function () {
                            if (i > 0) {
                                if (Mx_Dtt[i - 1].ATE_NUM == Mx_Dtt[i].ATE_NUM) {
                                    $(this).css("cssText", "text-align:center;").text("");
                                } else {
                                    $(this).text(Mx_Dtt[i].SECTOR_DESC);
                                }
                            } else {
                                $(this).text(Mx_Dtt[i].SECTOR_DESC);
                            }
                        }),
                                                $("<td>").text(function () {
                                                    $(this).text(Mx_Dtt[i].CF_DESC);
                                                }),
                        $("<td>").text(function () {
                            $(this).text(Mx_Dtt[i].PRU_DESC);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TP_RESUL_COD),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_RESULTADO == "") {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_RESULTADO_NUM);
                            } else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt[i].ATE_RESULTADO);
                            }
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt[i].ATE_NUM == "") {
                                $(this).css("cssText", "text-align:left;").text("");
                            } else {
                                $(this).css("cssText", "text-align:left;").text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO);
                            }
                        }),

                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].UM_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(""),
                        $("<td>").css("text-align", "center").text((function () {
                            if (Mx_Dtt[i].ATE_R_DESDE != "") {
                                var dword = Mx_Dtt[i].ATE_R_DESDE;
                                if (dword != null) {
                                    dword = dword.replace(",", ".");
                                    var dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                    return dword;
                                } else {
                                    return " - ";
                                }
                            } else {
                                if (dword != null) {
                                    var dword = Mx_Dtt[i].ATE_RR_DESDE;
                                    dword = dword.replace(",", ".");
                                    dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                    return dword;
                                } else {
                                    return " - ";
                                }
                            }
                        })),
                        $("<td>").css("text-align", "center").text((function () {
                            if (Mx_Dtt[i].ATE_R_HASTA != "") {
                                var dword = Mx_Dtt[i].ATE_R_HASTA;
                                if (dword != null) {
                                    dword = dword.replace(",", ".");
                                    var dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                    return dword;
                                } else {
                                    return " - ";
                                }
                            } else {
                                if (dword != null) {
                                    var dword = Mx_Dtt[i].ATE_RR_HASTA;
                                    dword = dword.replace(",", ".");
                                    dword = $re.cutDecimals(dword, Mx_Dtt[i].PRU_DECIMAL);
                                    return dword;
                                } else {
                                    return " - ";
                                }
                            }
                        })),
                        //$("<td>").css("text-align", "center").text(function () {
                        //    if (Mx_Dtt[i].ATE_NUM == "") {
                        //        $(this).css("cssText", "text-align:left;").text("");
                        //    } else {
                        //        if (Mx_Dtt[i].ID_SEXO == 1) {
                        //            $(this).css("cssText", "text-align:left;").text("Masculino");
                        //        } else {
                        //            $(this).css("cssText", "text-align:left;").text("Femenino");
                        //        }

                        //    }
                        //}),
                        $("<td>").css("text-align", "center").text(Mx_Dtt[i].AUDI_FORMA)
                    )
                );

            }

        }
        //-----------------------------------------TABLA LISTADO DE EXAMENES de la ATENCIONES-------------------------------------------|
        function Fill_DataTable_Listado_Exa_Ate() {
            $("<table>", {
                "id": "DataTable_Lis_Exa_Ate",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Listado_Exa_Ate");
            $("#DataTable_Lis_Exa_Ate").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lis_Exa_Ate").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lis_Exa_Ate thead").attr("class", "cabezera");
            $("#DataTable_Lis_Exa_Ate thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción del Examen"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Forma de Pago")
                )
            );

            for (i = 0; i < Mx_Dtt_Det_Ate.length; i++) {
                $("#DataTable_Lis_Exa_Ate tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].CF_DESC),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Det_Ate[i].ATE_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }
                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Det_Ate[i].ATE_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());
                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }
                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Det_Ate[i].TP_PAGO_DESC)
                    )
                );
                $("<tr>").attr("id", i + 1);
            }
        }

    </script>
    <style>
        .progress-bar.animate {
            width: 100%;
        }

        #DataTable tbody td {
            text-transform: uppercase;
        }

        .mrgn {
            margin-left: 20px;
            margin-right: 20px;
        }

        #btnFichaAcceso {
            margin-bottom: 1vh;
        }

        #i {
            display: flex;
            flex-flow: row nowrap;
        }

        .manito {
            cursor: pointer;
        }

        .cabezera {
            background: #46963f;
            color: white;
        }

        .cabezera2 {
            background: #081f44;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .mayus {
            text-transform: uppercase;
        }

        .highlights {
            width: 90%;
            max-height: 60vh; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        @media screen and (max-width: 600px) {
            .flexon {
                display: flex;
                flex-flow: column;
                width: 90vw;
            }

            .flx {
                flex: 1;
                max-width: 100%;
            }

            .buttons {
                display: flex;
                flex-flow: column;
            }

            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <%--//---------------------------------------------- MODAL LISTADO DE EXÁMENES DE LA ATENCIÓN ------------------------------------%>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Listado Exámenes de la Atención</h4>
                </div>
                <div class="modal-header">
                    <div class="col">
                        <h6 class="modal-title" id="numerito">num ATEEE</h6>
                        <h6 class="modal-title" id="nombrecito">Nombreee</h6>
                    </div>
                </div>
                <div class="modal-body">
                    <form>
                        <div id="Div_Tabla_Listado_Exa_Ate" style="width: 100%;" class="table-responsive"></div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Salir</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES-----------------------------------------%>
    <div class="row">
        <div class="col-lg">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                    <h5 style="text-align: center; padding: 5px;">
                        <i class="fa fa-edit"></i>
                        Listado de Resultados por Determinaciones
                    </h5>
                </div>
                <div class="row mb-3" style="margin-left: 2px; margin-right: 2px;">
                    <div class="col-md">
                        <label for="fecha">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha" class="form-control textoReducido" style="height: 31.75px;" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar textoReducido"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md">
                        <label for="fecha">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control textoReducido" style="height: 31.75px;" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar textoReducido"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md">
                        <label for="Ddl_previ">Lugar TM.:</label>
                        <select id="Procedencia" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="0">Todos</option>
                        </select>
                    </div>



                    <div class="col-md">
                        <label for="Ddl_previ">Previsión:</label>
                        <select id="Ddl_previ" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <div class="col-md">
                        <label for="Ddl_programa">Programa:</label>
                        <select id="Ddl_programa" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <div class="col-md">
                        <label for="Ddl_subPrograma">Sub-Programa:</label>
                        <select id="Ddl_subPrograma" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <div class="col-md">
                        <label for="Ddl_Exam">Exámenes:</label>
                        <select id="Ddl_Exam" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="0">Todos</option>
                            <option value="745">Orina Completa-S</option>   
                            <option value="426">Orina Completa-C</option> 
                            <option value="669">Sedimento de Orina</option>
                            <option value="746">Sedimento orina (URO)</option>
                            <option value="823">Orina Completa (con URO) 2</option>
                            <option value="1054">Orina Completa (Quilpue)</option>
                            <option value="1103">Orina Completa 2 (Quilpue)</option>
                            <option value="1134">Orina Completa Peñalolen</option>
                        </select>
                    </div>
                    <div class="col-md">
                        <label for="Ddl_Transmitido">Transmitido:</label>
                        <select id="Ddl_Transmitido" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="1">Transmitido</option>
                            <option value="0">Todos</option>
                        </select>
                    </div>
                    <%--                    <div class="col-md">
                        <label for="Ddl_Det">Determinación:</label>
                        <select id="Ddl_Det" class="form-control textoReducido" style="height: 31.75px;">
                            <option value="0">Seleccionar</option>
                        </select>
                    </div>--%>
                </div>
                <div class="row" style="margin-left: 2px; margin-right: 2px;">
                    <div class="col-md">
                        <button id="Btn_Buscar" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                    </div>
                    <div class="col-md">
                        <button id="Btn_Excel" class="btn btn-success btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                    </div>
                </div>
                <%-------------------------------------------------------------TABLAS-------------------------------------------------------------%>
                <div class="row" id="Id_Conte">
                    <div class="col-md-12" id="Paciente">
                        <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-list"></i>Listado de Atenciones</h5>
                        <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
