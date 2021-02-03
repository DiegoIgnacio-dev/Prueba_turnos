﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Env_Mues_Lab_PENDIENTES.aspx.vb" Inherits="Presentacion.Env_Mues_Lab_PENDIENTES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link href="../css/Custom_Modal.css" rel="stylesheet" />
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <script type="text/javascript">

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

        // Función para las teclas especiales
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, y Delete
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, y flechas
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest
            return false;
        }
    </script>

    <script>
        var CB_Pendiente = 0;
        var ATE_NUM_Pendiente = 0;
        var correxxx = 0;
        var ID_Ateee = 0;
        var ID_Pac = 0;
        var MULTIPLICADOSSSSS = "";
        var nombre_waaa = "";
        var NUM_OMI_PENDI = "";
        var ATE_CODI_TESTI = "";
        var ID_ATENCHION = 0;
        var ID_CEEFEICHON = 0;
        var CF_DESQUIIII = "";

        $(document).ready(function () {

            $("#txtNAte").focus();
            // AJAX AL CARGAR EL FORMULARIO
            Ajax_DataTable_Load();

            $("#xxx_xxx").click(function () {
                $('#XXXXXXXX').removeClass('show');
            });


            //Llenar FECHAS
            function FECHAS_INS() {
                var asd = Mx_Dtt[0].nac;

                asd = asd.replace(/-/g, "/");
                var array = asd.split("/");
                var total = "";
                var dia = array[0];
                var mes = array[1];
                var ano = array[2];
                //if (dia < 10) { dia = "0" + dia; }
                //if (mes < 10) { mes = "0" + mes; }
                // cogemos los valores actuales
                var fecha_hoy = new Date();
                var ahora_ano = fecha_hoy.getYear();
                var ahora_mes = fecha_hoy.getMonth() + 1;
                var ahora_dia = fecha_hoy.getDate();

                // realizamos el calculo
                var edad = (ahora_ano + 1900) - ano;
                if (ahora_mes < mes) {
                    edad--;
                }
                if ((mes == ahora_mes) && (ahora_dia < dia)) {
                    edad--;
                }
                if (edad > 1900) {
                    edad -= 1900;
                }
                // calculamos los meses
                var meses = 0;
                if (ahora_mes > mes)
                    meses = ahora_mes - mes;
                if (ahora_mes < mes)
                    meses = 12 - (mes - ahora_mes);
                if (ahora_mes == mes && dia > ahora_dia)
                    meses = 11;
                // calculamos los dias
                var dias = 0;
                total = String(edad + " Años");
                if (ahora_dia > dia) {
                    dias = ahora_dia - dia;
                    total = String(edad + " Años");
                }
                if (ahora_dia < dia) {
                    ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                    dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
                    total = String(edad + " Años");
                }
                //$("#txtEdad").val(total);
            }

            $("#Div_Tabla").empty();
            $("#Id_Conte").hide();

            $("#Btn_Buscar_x_ate").click(function () {

                if ($("#txtNAte").val() == "") {

                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, ingrese un número de folio");
                    $("#mError_AAH").modal();

                } else {
                    Ajax_DataTable();
                }
            });

            //AJAX GUARDAR EN EL MODAL MARCAR
            $("#Btn_Guardar").click(function () {
                selected = new Array();
                $("input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                if (selected == "") {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se ha seleccionado ninguna muestra.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Marcar_Guardar();
                }
            });

            //AJAX PENDIENTE EN EL MODAL MARCAR
            $("#Btn_Pendiente").click(function () {

                if (CB_Pendiente == 0 || ATE_NUM_Pendiente == 0) {
                    $("#mError_AAH h4").text("Seleccione una muestra");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, seleccione una muestra para marcar como pendiente.");
                    $("#mError_AAH").modal();
                } else {
                    $("#modal_pendientes h4").text("¿Marcar Pendiente?");
                    $("#modal_pendientes p").text("¿Está seguro que desea marcar como pendiente el examen? " + "[" + CB_Pendiente + "]" + " " + CF_DESQUIIII + ", Perteneciente al Folio: " + ATE_NUM_Pendiente);
                    $("#modal_pendientes").modal();
                }

            });

            //AJAX CONFIRMACION PENDIENTE EN EL MODAL MARCAR
            $("#Btn_Pendiente_Si").click(function () {
                $('#modal_pendientes').modal('hide');
                Ajax_Pendiente_Marcar();
            });

            $("#Btn_Anterior").click(function () {
                //Ajax_Pendiente_Marcar();
                var direccion = parseInt(Mx_Dtt_Marcar[0].ATE_NUM);
                direccion = direccion - 1;
                Ajax_DataTable_Marcar_Direccion(direccion);
            });

            $("#Btn_Siguiente").click(function () {
                //Ajax_Pendiente_Marcar();
                var direccion = parseInt(Mx_Dtt_Marcar[0].ATE_NUM);
                direccion = direccion + 1;
                Ajax_DataTable_Marcar_Direccion(direccion);
            });


            $('#txtNAte').change(function (event) {
                if ($("#txtNAte").val() != "")
                {
                    var hola = $('#txtNAte').val();

                    var keycode = event.which;
                    Ajax_DataTable();

                    var keycode = event.which;
                }
            });


            //CREAR LOTE
            $("#Btn_Crear_Lote").click(function () {
                if (Mx_Dtt_Load[0].ID_USUARIO == 0) {
                    $("#mError_AAH h4").text("Creación Fallida");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se puede crear un lote vacío.");
                    $("#mError_AAH").modal();
                } else {
                    Guardar_Lote();
                }

            });


            //CONFIRMAR LOTE
            $("#Btn_Confirmar_Lote").click(function () {
                Guardar_Lote_2(correxxx);
            });


            //MAS INFO PACIENTE
            $("#Btn_Info").click(function () {
                if (ID_Ateee == 0) {
                    $("#mError_AAH h4").text("Busque Folio");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Primero debe buscar un número de folio.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Info();
                }
            });

            // VER LOTES
            $("#Btn_Lote").click(function () {
                Ajax_Ver_Lotes_Anteriores();
            });

            $("#Btn_Anterior_Muestras_Lotes").click(function () {
                var direccion = parseInt(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);
                direccion = --direccion;
                Ajax_Muestras_Lotes_direccion_negativo(direccion);
            });

            $("#Btn_Siguiente_Muestras_Lotes").click(function () {
                var direccion = parseInt(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);
                direccion = ++direccion;
                Ajax_Muestras_Lotes_direccion_positivo(direccion);
            });

            $("#Btn_Grupos_Muestras_Lotes").click(function () {
                Ajax_Ver_Lotes_Anteriores();
            });

        });


    </script>


    <script>
                //-------------------------------------------------- TABLA LOAD ---------------------------------------------------------------|

        var Mx_Dtt_Load = [
    {
        "ID_USUARIO": 0,
        "ENVIO_ETI_NUM_ATE": 0,
        "ENVIO_ETI_CURVA": 0,
        "ENVIO_ETI_FECHA": 0,
        "CB_DESC": 0,
        "ATE_NUM": 0,
        "PAC_NOMBRE": 0,
        "PAC_APELLIDO": 0,
        "ID_ESTADO": 0,
        "EST_DESCRIPCION": 0,
        "T_MUESTRA_DESC": 0,
        "ID_ENVIO_ETI": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ENVIO_NUM": 0,
        "USU_NIC": 0,
        "ATE_NUM_OMI": 0,
        "ATE_CODIGO_TEST": 0,
        "ID_ATENCION": 0,
        "ID_CODIGO_FONASA": 0,
        "ATE_CF_MULTIPLICADOS": 0
    }
        ];




        function Ajax_DataTable_Load() {
            modal_show();


            //var Data_Par = JSON.stringify({
            //    "ID_USU": 1
            //});
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Form_Table",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Load = json_receiver;
                        Hide_Modal();
                        $("#Id_Conte").show();
                        $("#Div_Tabla_Load").empty();
                        $("#Div_Totales").empty();
                        $("#Div_Tabla").hide();
                        $("#Div_Tabla_Load").show();
                        $("#Div_Totales").show();

                        CB_Pendiente = 0;
                        ATE_NUM_Pendiente = 0;

                        for (i = 0; i < Mx_Dtt_Load.length; ++i) {
                            var date_x = Mx_Dtt_Load[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Load[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        $("#txtNAte").focus();
                        
                        Fill_DataTable_Load();


                    } else {

                        CB_Pendiente = 0;
                        ATE_NUM_Pendiente = 0;

                        $("#txtNAte").val("");
                        $("#txtNAte").focus();
                        Hide_Modal();
                        $("#Div_Tabla_Load").empty();
                        $("#Div_Totales").empty();
                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        $("#txtNAte").focus();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- DATOS PACIENTE Y LOTE O AGREGAR LA MUESTAR DEL LOTE ----------------------|
        var Mx_Dtt = [
            {
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0,
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ID_ENVIO": 0,
                "ID_USUARIO": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ID_ESTADO": 0,
                "Expr2": 0,
                "ID_PER": 0,
                "USU_NIC": 0,
                "ENVIO_ETI_FECHA": 0
            }
        ];

        let holaaaaaaaa = "";
        let chaoooooooo = "";

        function Ajax_DataTable() {
            modal_show();


            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNAte").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        if (json_receiver == "recepcionada") {
                            Ajax_DataTable_Load();
                        }
                        else if (json_receiver == "table") {
                            holaaaaaaaa = ($('#txtNAte').val().substring(0,2));
                            chaoooooooo = ($('#txtNAte').val().substring(2, 10));
                            $("#xxx_xxx").text("Último tubo cargado: " + "[" + holaaaaaaaa + "]," + " Perteneciente al folio N°: " + chaoooooooo + "  ✖");

                            $('#XXXXXXXX').addClass('show');

                            $('#txtNAte').val("");

                            Ajax_DataTable_Load();

                        } else if (json_receiver == "entregada") {
                            $('#XXXXXXXX').removeClass('show');
                            $("#mError_AAH").modal('hide');
                            $("#mError_AAH h4").text("Muestra Recepcionada");
                            $("#mError_AAH button").attr("class", "btn btn-danger");
                            $("#mError_AAH p").text("La muestra ya se encuentra recepcionada.");
                            $("#mError_AAH").modal();
                            $('#txtNAte').val("");

                            

                            setInterval(function () {
                                $("#mError_AAH").modal('hide');
                                $("#txtNAte").focus();
                            }, 1800)

                            $("#txtNAte").focus();
                            Ajax_DataTable_Load();
                        }

                        else {
                            Mx_Dtt = JSON.parse(json_receiver);
                            ID_Ateee = Mx_Dtt[0].ID_ATENCION;

                            //$("#txtNAte").val(Mx_Dtt[0].ATE_NUM);

                            $("#txtNum").val(Mx_Dtt[0].ATE_NUM);
                            $("#txtRut").val(Mx_Dtt[0].PAC_RUT);
                            $("#txtNom").val(Mx_Dtt[0].PAC_NOMBRE + " " + Mx_Dtt[0].PAC_APELLIDO);
                            $("#txtEdad").val(Mx_Dtt[0].ATE_AÑO);
                            $("#txtSexo").val(Mx_Dtt[0].SEXO_DESC);
                            $("#txtFono").val(Mx_Dtt[0].PAC_FONO1);
                            $("#txtCel").val(Mx_Dtt[0].PAC_MOVIL1);
                            $("#txtObsAte").val(Mx_Dtt[0].ATE_OBS_FICHA);
                            //$("#txtObsTm").val(Mx_Dtt[0].ATE_OBS_TM);

                            Ajax_Info_Asereje();
                            Ajax_DataTable_Marcar();



                        }
                    } else {


                        Hide_Modal();
                        $("#mError_AAH").modal('hide');
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                        $("#txtNAte").val("");
                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        var Mx_Dtt_Atencion_Asereje = [
{
    "ID_ATENCION": 0,
    "ATE_NUM": 0,
    "ATE_FECHA": 0,
    "ATE_FUR": 0,
    "ATE_OBS_FICHA": 0,
    "ATE_AÑO": 0,
    "ATE_OBS_TM": 0,
    "PAC_NOMBRE": 0,
    "SEXO_DESC": 0,
    "PAC_APELLIDO": 0,
    "PAC_FNAC": 0,
    "PAC_DIR": 0,
    "PAC_FONO1": 0,
    "PAC_MOVIL1": 0,
    "PAC_EMAIL": 0,
    "PAC_OBS_PERMA": 0,
    "NAC_DESC": 0,
    "COM_DESC": 0,
    "CIU_DESC": 0,
    "ID_PACIENTE": 0
}
        ];

        function Ajax_Info_Asereje() {

            //modal_show();


            var Data_Par = JSON.stringify({
                "ID_USU": ID_Ateee
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Atencion_Asereje = json_receiver;

                        ID_Pac = Mx_Dtt_Atencion_Asereje[0].ID_PACIENTE;
                        //$("#superNumAte").val(Mx_Dtt_Atencion_Asereje[0].ATE_NUM)
                        //$("#superNombre").val(Mx_Dtt_Atencion_Asereje[0].PAC_NOMBRE + " " + Mx_Dtt_Atencion_Asereje[0].PAC_APELLIDO);




                        Ajax_Info_Exa_Asereje();
                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    //Hide_Modal();


                }
            });
        }

        // -------------------------------------------- INFO DEL PACIENTE QUE VA EN EL MODAL Y LA WE@
        var Mx_Dtt_Datos_Actuales_Asereje = [
            {
                "ID_ATENCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0,
                "TP_ATE_DESC": 0,
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Info_Exa_Asereje() {

            var Data_Par = JSON.stringify({
                "ID_Pac": ID_Pac
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Exa_Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Datos_Actuales_Asereje = json_receiver;
                        //Hide_Modal();

                        //$("#Div_Tabla_Atencion").empty();
                        //$("#Div_Datos_Actuales").empty();

                        //$('#eModalInfo').modal('hide');
                        //$('#eModalInfo').modal('show');

                        //$("#numAtessss").text(Mx_Dtt_Datos_Actuales.length);
                        //Fill_DataTable_Atencion();
                        //Fill_DataTable_Datos_Actuales();



                        $("#superNumAte").text(Mx_Dtt_Datos_Actuales_Asereje[0].ATE_NUM);
                        $("#superNombre").text(Mx_Dtt_Datos_Actuales_Asereje[0].DOC_NOMBRE + " " + Mx_Dtt_Datos_Actuales_Asereje[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Datos_Actuales_Asereje[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Datos_Actuales_Asereje[0].PROC_DESC);
                        //nombre_waaa = $("#txtNom").val();
                        nombre_waaa = Mx_Dtt_Datos_Actuales_Asereje[0].PAC_NOMBRE + " " + Mx_Dtt_Datos_Actuales_Asereje[0].PAC_APELLIDO;
                        $("#superNomPaciente").text(nombre_waaa);


                        Hide_Modal();

                       
                    } else {
                        //$("#superNumAte").text("");
                        //$("#superNombre").text("");
                        //$("#superPrevision").text("");
                        //$("#superLugar").text("");
                        //$("#superNomPaciente").text("");

                        Hide_Modal();

                        //$("#mError_AAH h4").text("Sin Resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados.");
                        //$("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }












        //-------------------------------------------------- DATOS PACIENTE AL CAMBIAR DE MODAL ----------------------|
        var Mx_Dtt_Asereje = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_RUT": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0
            }
        ];

        function Ajax_DataTable_Asereje() {
            //modal_show();

            var Data_Par = JSON.stringify({
                "NUM_ATE": $("#txtNAte").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        if (json_receiver == "recepcionada") {
                            Ajax_DataTable_Load();
                        }
                        else if (json_receiver == "table") {
                            $('#txtNAte').val("");
                            Ajax_DataTable_Load();
                        } else if (json_receiver == "entregada") {
                            //$("#mError_AAH h4").text("Muestra Recepcionada");
                            //$("#mError_AAH button").attr("class", "btn btn-danger");
                            //$("#mError_AAH p").text("La muestra ya se encuentra recepcionada.");
                            //$("#mError_AAH").modal();
                            //$('#txtNAte').val("");
                            Ajax_DataTable_Load();
                        }

                        else {
                            Mx_Dtt_Asereje = JSON.parse(json_receiver);
                            ID_Ateee = Mx_Dtt_Asereje[0].ID_ATENCION;
                            $("#txtNum").val(Mx_Dtt_Asereje[0].ATE_NUM);
                            $("#txtRut").val(Mx_Dtt_Asereje[0].PAC_RUT);
                            $("#txtNom").val(Mx_Dtt_Asereje[0].PAC_NOMBRE + " " + Mx_Dtt_Asereje[0].PAC_APELLIDO);
                            $("#txtEdad").val(Mx_Dtt_Asereje[0].ATE_AÑO);
                            $("#txtSexo").val(Mx_Dtt_Asereje[0].SEXO_DESC);
                            $("#txtFono").val(Mx_Dtt_Asereje[0].PAC_FONO1);
                            $("#txtCel").val(Mx_Dtt_Asereje[0].PAC_MOVIL1);
                            $("#txtObsAte").val(Mx_Dtt_Asereje[0].ATE_OBS_FICHA);
                            //$("#txtObsTm").val(Mx_Dtt_Asereje[0].ATE_OBS_TM);

                            //Ajax_DataTable_Marcar();



                        }
                    } else {


                        //Hide_Modal();
                        //$("#mError_AAH h4").text("Sin resultados");
                        //$("#mError_AAH button").attr("class", "btn btn-danger");
                        //$("#mError_AAH p").text("No se han encontrado resultados");
                        //$("#mError_AAH").modal();

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }


        //-------------------------------------------------- GUARDAR TABLA MARCAR -----------------------------------------------------|
        var Mx_Dtt = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_RUT": 0,
                "PAC_EMAIL": 0,
                "ATE_AÑO": 0,
                "SEXO_DESC": 0
            }
        ];

        function Ajax_Marcar_Guardar() {
            modal_show();


            var Data_Par = JSON.stringify({
                "NUM_ATE": Mx_Dtt_Marcar[0].ATE_NUM,
                "MUESTRA": selected
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_DataTable_Marcar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        if (json_receiver == "recepcionada") {

                            Ajax_DataTable_Load();
                        }
                        else if (json_receiver == "table") {
                            //$("#mError_AAH h4").text("Muestra Recepcionada");
                            //$("#mError_AAH button").attr("class", "btn btn-success");
                            //$("#mError_AAH p").text("La muestra ha sido recepcionada satisfactoriamente.");
                            //$("#mError_AAH").modal();
                            //$('#eModal').modal('hide');

                            $("#txtNum").val("");
                            $("#txtRut").val("");
                            $("#txtNom").val("");
                            $("#txtEdad").val("");
                            $("#txtSexo").val("");
                            $("#txtFono").val("");
                            $("#txtCel").val("");
                            $("#txtObsAte").val("");
                            $("#txtObsTm").val("");
                            $('#eModal').modal('hide');
                            Ajax_DataTable_Load();
                        } else if (json_receiver == "tables") {
                            //$("#mError_AAH h4").text("Muestras Recepcionadas");
                            //$("#mError_AAH button").attr("class", "btn btn-success");
                            //$("#mError_AAH p").text("Las muestras han sido recepcionadas satisfactoriamente.");
                            //$("#mError_AAH").modal();
                            $("#txtNum").val("");
                            $("#txtNAte").val("");
                            $("#txtRut").val("");
                            $("#txtNom").val("");
                            $("#txtEdad").val("");
                            $("#txtSexo").val("");
                            $("#txtFono").val("");
                            $("#txtCel").val("");
                            $("#txtObsAte").val("");
                            $("#txtObsTm").val("");
                            $('#eModal').modal('hide');
                            Ajax_DataTable_Load();
                        }


                        else {
                            Mx_Dtt = JSON.parse(json_receiver);

                            $("#txtNum").val(Mx_Dtt[0].ATE_NUM);
                            $("#txtRut").val(Mx_Dtt[0].PAC_RUT);
                            $("#txtNom").val(Mx_Dtt[0].PAC_NOMBRE + " " + Mx_Dtt[0].PAC_APELLIDO);
                            FECHAS_INS();
                            $("#txtEdad").val(Mx_Dtt[0].ATE_AÑO);
                            $("#txtSexo").val(Mx_Dtt[0].SEXO_DESC);
                            $("#txtFono").val(Mx_Dtt[0].PAC_FONO1);
                            $("#txtCel").val(Mx_Dtt[0].PAC_MOVIL1);
                            $("#txtObsAte").val(Mx_Dtt[0].ATE_OBS_FICHA);
                            $("#txtObsTm").val(Mx_Dtt[0].ATE_OBS_TM);

                            Ajax_DataTable_Marcar();



                        }
                    } else {


                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                        $("#txtNum").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //--------------------------------------------- TABLE -------------------------------------------------------------------------|
        var Mx_Dtt_Table = [
          {
              "ID_USUARIO": 0,
              "RECEP_ETI_NUM_ATE": 0,
              "RECEP_ETI_CURVA": 0,
              "ENVIO_ETI_FECHA": 0,
              "CB_DESC": 0,
              "ATE_NUM": 0,
              "PAC_NOMBRE": 0,
              "PAC_APELLIDO": 0,
              "ID_ESTADO": 0,
              "EST_DESCRIPCION": 0,
              "T_MUESTRA_DESC": 0,
              "ID_RECEP_ETI": 0,
              "CF_DESC": 0,
              "ID_PER": 0,
              "ID_T_MUESTRA": 0,
              "ID_ATENCION": 0,
              "Expr1": 0,
              "ATE_EST_TM": 0,
              "USU_NIC": 0,
              "EST_DESCRIPCION": 0
          }
        ];

        function Ajax_DataTable_Ate_ONCLICK() {

            var Data_Par = JSON.stringify({
                "N_ATE": $("#txtNAte").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_DataTable2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Table = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Table.length; ++i) {
                            var date_x = Mx_Dtt_Table[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Table[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        $("#Id_Conte").show();
                        $("#Div_Tabla").empty();
                        Ajax_DataTable_Marcar();


                    } else {


                        $("#Div_Tabla").empty();
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados.");
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


        //-------------------------------------------------- TABLA MARCAR -------------------------------------------------------------|
        var Mx_Dtt_Marcar = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ID_ENVIO": 0,
                "ID_USUARIO": 0,
                "PAC_RUT": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ID_ESTADO": 0,
                "Expr2": 0,
                "ID_PER": 0,
                "USU_NIC": 0,
                "ENVIO_ETI_FECHA": 0,
                "EST_DESCRIPCION": 0

            }
        ];

        function Ajax_DataTable_Marcar() {

            var Data_Par = JSON.stringify({
                "N_ATE": $("#txtNAte").val()
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_DataTable3",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Marcar.length; ++i) {
                            var date_x = Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA = Date_Change;
                        }
                        $("#Div_Tabla_Antiguos").empty();
                        $("#sss").text("Detalle de Estado Folio N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        //$("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        //$("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        //$("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        //nombre_waaa = $("#txtNom").val();
                        nombre_waaa = Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO;
                        $("#superNomPaciente").text(nombre_waaa);


                        Fill_DataTable_Antiguos();
                        $('#eModal').modal('hide');
                        $('#eModal').modal('show');

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

        //-------------------------------------------------- BOTON GUARDAR TABLA MARCAR -----------------------------------------------|
        function Ajax_Pendiente_Marcar() {

            var Data_Par = JSON.stringify({
                "ATE_NUM": ATE_NUM_Pendiente,
                "CB": CB_Pendiente,
                "NUM_OMI": NUM_OMI_PENDI,
                "ATE_CODIGO_TEST": ATE_CODI_TESTI,
                "ID_ATE": ID_ATENCHION,
                "ID_CF": ID_CEEFEICHON,
                "MULTIPLICADOSSSSS": MULTIPLICADOSSSSS
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Ajax_Pendiente_Marcar",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {



                        $('#modal_pendientes').modal('hide');
                        //$("#mError_AAH h4").text("Muestra Eliminada");
                        //$("#mError_AAH button").attr("class", "btn btn-success");
                        //$("#mError_AAH p").text("La muestra ha sido eliminada satisfactoriamente.");
                        //$("#mError_AAH").modal();
                        $("#txtNum").val("");
                        $("#txtNAte").val("");
                        $("#txtRut").val("");
                        $("#txtNom").val("");
                        $("#txtEdad").val("");
                        $("#txtSexo").val("");
                        $("#txtFono").val("");
                        $("#txtCel").val("");
                        $("#txtObsAte").val("");
                        $("#txtObsTm").val("");
                        //$('#eModal').modal('hide');
                        Ajax_DataTable_Load();
                    } else {
                        $('#modal_pendientes').modal('hide');
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado muestras recepcionadas por el usuario.");
                        $("#mError_AAH").modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    $('#modal_pendientes').modal('hide');

                }
            });
        }

        //-------------------------------------------------- TABLA MARCAR -------------------------------------------------------------|
        var Mx_Dtt_Marcar = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "ID_PER": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ATE_EST_TM": 0,
                "EST_DESCRIPCION": 0,
                "ENVIO_ETI_FECHA": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "USU_NIC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0,
                "ID_PACIENTE": 0

            }
        ];

        function Llenar_Modal_Cargar_Doble_click(NUM_ATE) {
            $("#txtNAte").val(NUM_ATE);
            $("#txtNum").val(NUM_ATE);
            modal_show();

            var Data_Par = JSON.stringify({
                "NUM_ATE": NUM_ATE
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_Modal_Cargar_Doble_click",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        
                        Ajax_Info_Exa_Asereje();
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);
                        ID_Pac = Mx_Dtt_Marcar[0].ID_PACIENTE;
                        Ajax_Info_Exa_Asereje();
                            
                        for (i = 0; i < Mx_Dtt_Marcar.length; ++i) {
                            var date_x = Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        //$("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        //$("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        //$("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        //$("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        //nombre_waaa = $("#txtNom").val();
                        //$("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        $("#Div_Tabla_Antiguos").empty();
                        $("#sss").text("Detalle de Estado N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);
                        $('#eModal').modal('hide');
                        Fill_DataTable_Antiguos();

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        //$("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        nombre_waaa = $("#txtNom").val();
                        $("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        $('#eModal').modal('show');

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


        //-------------------------------------------------- TABLA MARCAR SEGUN DIRECCION ---------------------------------------------|
        var Mx_Dtt_Marcar = [
            {
                "ID_T_MUESTRA": 0,
                "ATE_NUM": 0,
                "ID_ATENCION": 0,
                "ID_PER": 0,
                "T_MUESTRA_DESC": 0,
                "CB_DESC": 0,
                "Expr1": 0,
                "CF_DESC": 0,
                "ATE_EST_TM": 0,
                "EST_DESCRIPCION": 0,
                "RECEP_ETI_FECHA": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "USU_NIC": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0

            }
        ];

        function Ajax_DataTable_Marcar_Direccion(direccion) {
            modal_show();

            var Data_Par = JSON.stringify({
                "N_ATE": direccion
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Llenar_DataTable3",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Marcar = JSON.parse(json_receiver);

                        for (i = 0; i < Mx_Dtt_Marcar.length; ++i) {
                            var date_x = Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA = Date_Change;
                        }
                        
                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        //$("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        nombre_waaa = $("#txtNom").val();
                        $("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        $("#Div_Tabla_Antiguos").empty();
                        $("#sss").text("Detalle de Estado Folio N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);
                        $('#txtNAte').val(Mx_Dtt_Marcar[0].ATE_NUM);
                        ID_Ateee = Mx_Dtt_Marcar[0].ID_ATENCION;
                        Ajax_DataTable_Asereje();
                        Ajax_Info_Asereje();
                        Fill_DataTable_Antiguos();

                        $("#superNumAte").text(Mx_Dtt_Marcar[0].ATE_NUM);
                        $("#superNombre").text(Mx_Dtt_Marcar[0].DOC_NOMBRE + " " + Mx_Dtt_Marcar[0].DOC_APELLIDO);
                        $("#superPrevision").text(Mx_Dtt_Marcar[0].PREVE_DESC);
                        $("#superLugar").text(Mx_Dtt_Marcar[0].PROC_DESC);
                        nombre_waaa = $("#txtNom").val();
                        $("#superNomPaciente").text(Mx_Dtt_Marcar[0].PAC_NOMBRE + " " + Mx_Dtt_Marcar[0].PAC_APELLIDO);

                        //Hide_Modal();


                    } else {


                        Hide_Modal();
                        Mx_Dtt_Marcar.length = 1;
                        $("#Div_Tabla_Antiguos").empty();
                        $("#DataTable_Antiguos").empty();
                        Mx_Dtt_Marcar[0].ATE_NUM = direccion;
                        $("#sss").text("Detalle de Estado Folio N°:" + " " + Mx_Dtt_Marcar[0].ATE_NUM);
                        Mx_Dtt_Marcar[0].ID_T_MUESTRA = "";
                        Mx_Dtt_Marcar[0].ID_ATENCION = "";
                        Mx_Dtt_Marcar[0].ID_PER = "";
                        Mx_Dtt_Marcar[0].T_MUESTRA_DESC = "";
                        Mx_Dtt_Marcar[0].CB_DESC = "";
                        Mx_Dtt_Marcar[0].Expr1 = "";
                        Mx_Dtt_Marcar[0].CF_DESC = "";
                        Mx_Dtt_Marcar[0].ATE_EST_TM = "";
                        Mx_Dtt_Marcar[0].EST_DESCRIPCION = "";
                        Mx_Dtt_Marcar[0].RECEP_ETI_FECHA = "";
                        Mx_Dtt_Marcar[0].PAC_NOMBRE = "";
                        Mx_Dtt_Marcar[0].PAC_APELLIDO = "";
                        Mx_Dtt_Marcar[0].USU_NIC = "";

                        $("#superNumAte").text("");
                        $("#superNombre").text("");
                        $("#superPrevision").text("");
                        $("#superLugar").text("");
                        $("#superNomPaciente").text("");

                        Fill_DataTable_Antiguos();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }

        //-------------------------------------------------- BOTON GUARDAR LOTE -------------------------------------------------------|
        var correlativin = 0;

        function Guardar_Lote() {

            //var Data_Par = JSON.stringify({
            //    "ATE_NUM": ATE_NUM_Pendiente,
            //    "CB": CB_Pendiente
            //});
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Guardar_Lote",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        correlativin = JSON.parse(json_receiver)


                        $("#Modal_Correlativo h4").text("Lote CREADO");
                        $("#Modal_Correlativo button").attr("class", "btn btn-success");
                        $("#Modal_Correlativo p").text("Lote Número: " + correlativin);
                        $("#Modal_Correlativo").modal();
                        Mx_Dtt_Load[0].ID_USUARIO = 0;
                        Ajax_Get_values_to_Lote(correlativin);
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

        //-------------------------------------------------- GUARDAR LOTE 2da PARTE ---------------------------------------------------|
        function Guardar_Lote_2(correlativin2) {


            var Data_Par = JSON.stringify({
                "correlativin": correlativin2,
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Guardar_Lote2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver == "null") {


                        $('#Modal_Correlativo').modal('hide');
                        $("#Modal_Correlativo").hide();
                        Ajax_DataTable_Load();
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

        //-------------------------------------------------- MAS INFO PACIENTE --------------------------------------------------------|
        var Mx_Dtt_Atencion = [
            {
                "ID_ATENCION": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "ATE_FUR": 0,
                "ATE_OBS_FICHA": 0,
                "ATE_AÑO": 0,
                "ATE_OBS_TM": 0,
                "PAC_NOMBRE": 0,
                "SEXO_DESC": 0,
                "PAC_APELLIDO": 0,
                "PAC_FNAC": 0,
                "PAC_DIR": 0,
                "PAC_FONO1": 0,
                "PAC_MOVIL1": 0,
                "PAC_EMAIL": 0,
                "PAC_OBS_PERMA": 0,
                "NAC_DESC": 0,
                "COM_DESC": 0,
                "CIU_DESC": 0,
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Info() {
            modal_show();

            var Data_Par = JSON.stringify({
                "ID_USU": ID_Ateee
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Atencion = json_receiver;

                        for (i = 0; i < Mx_Dtt_Atencion.length; ++i) {
                            var date_x = Mx_Dtt_Atencion[i].ATE_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Atencion[i].ATE_FECHA = Date_Change;
                        }

                        ID_Pac = Mx_Dtt_Atencion[0].ID_PACIENTE;
                        Ajax_Exa_Info();



                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- EXAMENES INFO PACIENTE ---------------------------------------------------|
        var Mx_Dtt_Datos_Actuales = [
            {
                "ID_ATENCION": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "ATE_NUM": 0,
                "ATE_FECHA": 0,
                "DOC_NOMBRE": 0,
                "DOC_APELLIDO": 0,
                "PREVE_DESC": 0,
                "PROC_DESC": 0,
                "TP_ATE_DESC": 0,
                "ID_PACIENTE": 0
            }
        ];

        function Ajax_Exa_Info() {

            var Data_Par = JSON.stringify({
                "ID_Pac": ID_Pac
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/Exa_Info",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Datos_Actuales = json_receiver;
                        Hide_Modal();

                        $("#Div_Tabla_Atencion").empty();
                        $("#Div_Datos_Actuales").empty();

                        $('#eModalInfo').modal('hide');
                        $('#eModalInfo').modal('show');

                        $("#numAtessss").text(Mx_Dtt_Datos_Actuales.length);
                        Fill_DataTable_Atencion();
                        Fill_DataTable_Datos_Actuales();


                    } else {

                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }


        //-------------------------------------------------- VER LOTES ANTERIORES ------------------------------------------------------|
        var Mx_Dtt_Lotes_Anteriores = [
            {
                "ENVIO_NUM": 0,
                "ID_USUARIO": 0,
                "ENVIO_FECHA": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Ver_Lotes_Anteriores() {

            //var Data_Par = JSON.stringify({
            //    "ID_Pac": ID_Pac
            //});
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Lotes_Anteriores = json_receiver;
                        Hide_Modal();

                        $('#eModal_Muestras_Por_Lotes').modal('hide');
                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModalLotesAnteriores').modal('show');
                        $("#Div_Tabla_Lotes_Anteriores").empty();

                        for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; ++i) {
                            var date_x = Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA = Date_Change;
                        }

                        Fill_DataTable_Lotes_Anteriores();


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
                    Hide_Modal();


                }
            });
        }

        //-------------------------------------------------- VER MUESTRAS POR LOTES ----------------------------------------------------|
        var Mx_Dtt_Muestras_Lotes = [
            {
                "ENVIO_NUM": 0,
                "ID_ATENCION": 0,
                "ENVIO_ETI_CURVA": 0,
                "ENVIO_ETI_NUM_ATE": 0,
                "ID_USUARIO": 0,
                "ENVIO_ETI_FECHA": 0,
                "ID_ENVIO": 0,
                "ID_ESTADO": 0,
                "CB_DESC": 0,
                "T_MUESTRA_DESC": 0,
                "CF_DESC": 0,
                "PAC_NOMBRE": 0,
                "PAC_APELLIDO": 0,
                "RLS_LS_DESC": 0,
                "ID_RLS_LS": 0,
                "EST_DESCRIPCION": 0,
                "ID_PER": 0,
                "PROC_DESC": 0,
                "ATE_AÑO": 0,
                "ATE_MES": 0,
                "ATE_DIA": 0,
                "SEXO_DESC": 0,
                "USU_NIC": 0
            }
        ];

        function Ajax_Muestras_Lotes(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        Hide_Modal();

                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();
                        $('#eModalLotesAnteriores').modal('hide');
                        $('#eModal_Muestras_Por_Lotes').modal('hide');
                        $('#eModal_Muestras_Por_Lotes').modal('show');


                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        $("#DataTable_Muestras_Por_Lotes").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }

        function Ajax_Muestras_Lotes_direccion_negativo(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });

            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        Hide_Modal();
                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM--;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);

                        Hide_Modal();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();


                }
            });
        }

        function Ajax_Muestras_Lotes_direccion_positivo(NUMLOTE) {
            modal_show();

            var Data_Par = JSON.stringify({
                "NUMLOTE": NUMLOTE
            });
            $.ajax({
                "type": "POST",
                "url": "Env_Mues_Lab_PENDIENTES.aspx/IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver.length > 0) {
                        Mx_Dtt_Muestras_Lotes = json_receiver;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);
                        $("#DataTable_Muestras_Por_Lotes").empty();

                        for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; ++i) {
                            var date_x = Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");

                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA = Date_Change;
                        }

                        Hide_Modal();
                        Fill_DataTable_Muestras_Por_Lotes();

                    } else {

                        Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM++;
                        $("#lote_nummmmm").text(Mx_Dtt_Muestras_Lotes[0].ENVIO_NUM);
                        Hide_Modal();
                        $("#DataTable_Muestras_Por_Lotes").empty();
                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                    Hide_Modal();

                }
            });
        }

        //--------------------------------------------------- CLICK EN TABLA ----------------------------------------------------------|
        function Ajax_Get_values_to_Pendiente(CBB, ATE_NUMM, NUM_OMII, ATE_COD_TEST, ID_ATEEEEEEECX, ID_CEEFEEE, PARA_CF_DESQQQ, MULTIPLICADOSSSSSTTTTTTTT) {

            CB_Pendiente = CBB;
            ATE_NUM_Pendiente = ATE_NUMM;
            NUM_OMI_PENDI = NUM_OMII;
            ATE_CODI_TESTI = ATE_COD_TEST;
            ID_ATENCHION = ID_ATEEEEEEECX;
            ID_CEEFEICHON = ID_CEEFEEE;
            CF_DESQUIIII = PARA_CF_DESQQQ;
            MULTIPLICADOSSSSS = MULTIPLICADOSSSSSTTTTTTTT;
        };

        function Ajax_Get_values_to_Lote(LOTE) {

            correxxx = LOTE;

        };

    </script>

    <script>
        //------------------------------------------------ TABLA Load -----------------------------------------------------------------|
        function Fill_DataTable_Load() {
            //let super_contador = 0;

            //$("<table>", {
            //    "id": "DataTable_Totales",
            //    "class": "display",
            //    "width": "100%",
            //    "cellspacing": "0"
            //}).appendTo("#Div_Totales");

            //$("#DataTable_Totales").append(
            //    $("<thead>"),
            //    $("<tbody>")
            //);
            //$("#DataTable_Totales").attr("class", "table table-hover table-striped table-iris");
            //$("#DataTable_Totales thead").attr("class", "cabezera");
            //$("#DataTable_Totales thead").append(
            //    $("<tr>").append(
            //        $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
            //        $("<th>", { "class": "textoReducido text-center" }).text("Total")

            //    )
            //);

            //for (var leKey in Mx_Dtt_Load.Dictionary) {
            //    $("#DataTable_Totales tbody").append(
            //        $("<tr>").append(
            //            $("<td>", { class: "textoReducido" }).text(leKey),
            //            $("<td>", { class: "textoReducido text-center" }).text(Mx_Dtt_Load.Dictionary[leKey])
            //        )
            //    );

            //    super_contador += Mx_Dtt_Load.Dictionary[leKey]

            //}
            //$("#DataTable_Totales tbody").append(
            //        $("<tr>").append(
            //            $("<td>", { class: "textoReducido negrin" }).text("TOTAL"),
            //            $("<td>", { class: "textoReducido text-center negrin" }).text(super_contador)
            //        )
            //    );



            $("<table>", {
                "id": "DataTable_Load",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Load");

            $("#DataTable_Load").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Load").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Load thead").attr("class", "cabzera");
            $("#DataTable_Load thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario")

                )
            );
            //let xi = 0;
            for (i = 0; i < Mx_Dtt_Load.length; i++) {
                //if (xi == 0) {
                    $("#DataTable_Load tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Get_values_to_Pendiente("` + Mx_Dtt_Load[i].CB_DESC + `","` + Mx_Dtt_Load[i].ATE_NUM + `","` + Mx_Dtt_Load[i].ATE_NUM_OMI + `","` + Mx_Dtt_Load[i].ATE_CODIGO_TEST + `","` + Mx_Dtt_Load[i].ID_ATENCION + `","` + Mx_Dtt_Load[i].ID_CODIGO_FONASA + `","` + Mx_Dtt_Load[i].CF_DESC + `","` + Mx_Dtt_Load[i].ATE_CF_MULTIPLICADOS + `")`,
                        "ondblclick": `Llenar_Modal_Cargar_Doble_click("` + Mx_Dtt_Load[i].ATE_NUM + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt_Load[i].CB_DESC + "]" + " " + Mx_Dtt_Load[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Load[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text("RECEP.");
                            }
                            else {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Load[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Load[i].ENVIO_ETI_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Load[i].ENVIO_ETI_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].PAC_NOMBRE + " " + Mx_Dtt_Load[i].PAC_APELLIDO),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_NIC)
                    )
                );
                //} else if (((xi > 0) && (Mx_Dtt_Load[xi].CB_DESC != Mx_Dtt_Load[xi - 1].CB_DESC))) {
                    //$("#DataTable_Load tbody").append(
                    //                    $("<tr>", {
                //                        "onclick": `Ajax_Get_values_to_Pendiente("` + Mx_Dtt_Load[i].CB_DESC + `","` + Mx_Dtt_Load[i].ATE_NUM + `")`,
                //                        "ondblclick": `Llenar_Modal_Cargar_Doble_click("` + Mx_Dtt_Load[i].ATE_NUM + `")`,
                    //                        "class": "manito"
                    //                    }).append(
                    //                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                //                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt_Load[i].CB_DESC + "]" + " " + Mx_Dtt_Load[i].T_MUESTRA_DESC),
                //                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].CF_DESC),
                    //                        $("<td>").css("text-align", "center").text(function () {
                //                            if (Mx_Dtt_Load[i].EST_DESCRIPCION == "RECEP.") {
                    //                                $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text("RECEP.");
                    //                            }
                    //                            else {
                //                                $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Load[i].EST_DESCRIPCION);
                    //                            }
                    //                        }),
                    //                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                    //                            //Obtener valores
                //                            var obj_date = new Date(Mx_Dtt_Load[i].ENVIO_ETI_FECHA);
                    //                            var dd = parseInt(obj_date.getDate());
                    //                            var mm = parseInt(obj_date.getMonth()) + 1;
                    //                            var yy = parseInt(obj_date.getFullYear());

                    //                            if (dd < 10) { dd = "0" + dd; }
                    //                            if (mm < 10) { mm = "0" + mm; }

                    //                            return String(dd + "/" + mm + "/" + yy);
                    //                        }),
                    //                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                    //                            //Obtener valores
                //                            var obj_date2 = new Date(Mx_Dtt_Load[i].ENVIO_ETI_FECHA);
                    //                            var hh = parseInt(obj_date2.getHours());
                    //                            var mm = parseInt(obj_date2.getMinutes());
                    //                            var ss = parseInt(obj_date2.getSeconds());

                    //                            if (hh < 10) { hh = "0" + hh; }
                    //                            if (mm < 10) { mm = "0" + mm; }
                    //                            if (ss < 10) { ss = "0" + ss; }

                    //                            return String(hh + ":" + mm + ":" + ss);
                    //                        }),
                //                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].PAC_NOMBRE + " " + Mx_Dtt_Load[i].PAC_APELLIDO),
                //                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].ATE_NUM),
                //                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Load[i].USU_NIC)
                    //                    )
                    //                );
                //}
                //xi++;
            }

            //Declarar evento
            $("#DataTable_Load tbody tr").click(function () {
                $("#DataTable_Load tbody tr").removeClass("active");
                $(this).addClass("active");
            });
        }
        //------------------------------------------------ TABLA LISTADO DE MUESTRAS --------------------------------------------------|
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
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text(""),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario")

                )
            );

            for (i = 0; i < Mx_Dtt_Table.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("[" + Mx_Dtt_Table[i].CB_DESC + "]" + " " + Mx_Dtt_Table[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Table[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color: #88d6e2 !important; color:white; cursor:pointer; text-align:center;").text("RECEP.");
                            }
                            else {
                                $(this).css("cssText", " color:inherit; background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Table[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Table[i].RECEP_ETI_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                            //Obtener valores
                            var obj_date2 = new Date(Mx_Dtt_Table[i].RECEP_ETI_FECHA);
                            var hh = parseInt(obj_date2.getHours());
                            var mm = parseInt(obj_date2.getMinutes());
                            var ss = parseInt(obj_date2.getSeconds());

                            if (hh < 10) { hh = "0" + hh; }
                            if (mm < 10) { mm = "0" + mm; }
                            if (ss < 10) { ss = "0" + ss; }

                            return String(hh + ":" + mm + ":" + ss);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].PAC_NOMBRE + " " + Mx_Dtt_Table[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Table[i].USU_NIC)
                    )
                );
            }
        }

        //------------------------------------------------ TABLA MARCAR  --------------------------------------------------------------|
        function Fill_DataTable_Antiguos() {
            $("<table>", {
                "id": "DataTable_Antiguos",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Antiguos");

            $("#DataTable_Antiguos").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Antiguos").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Antiguos thead").attr("class", "cabzera");

            $("#DataTable_Antiguos thead").append(
                $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Hora"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("Marcar"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario")

                )
            );

            let xi = 0;
            for (i = 0; i < Mx_Dtt_Marcar.length; i++) {
                //if (xi == 0) {
                    $("#DataTable_Antiguos tbody").append(
                    $("<tr>").append(
                    $("<td>").css("text-align", "center").text(function () {
                        if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                            $(this).css("cssText", "text-align:center;").text("");
                        }
                        else {
                            $(this).css("cssText", "text-align:center;").text(i + 1);
                        }
                    }),

                    $("<td>").css("text-align", "center").text(function () {
                        if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                            $(this).css("cssText", "text-align:center;").text("");
                        }
                        else {
                            $(this).css("cssText", "text-align:left;").text("[" + Mx_Dtt_Marcar[i].CB_DESC + "]" + " " + Mx_Dtt_Marcar[i].T_MUESTRA_DESC);
                        }
                    }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            let fecha = moment(Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY");
                            if (fecha == "01/01/0001") {
                                return "-/-";
                            }else{
                                return fecha;
                            }
                            
                        }),
                        //$("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                        //    //Obtener valores
                        //    var obj_date = new Date(Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA);
                        //    var dd = parseInt(obj_date.getDate());
                        //    var mm = parseInt(obj_date.getMonth()) + 1;
                        //    var yy = parseInt(obj_date.getFullYear());
                        //    var resultado = "";
                            
                        //    if (dd < 10) { dd = "0" + dd; }
                        //    if (mm < 10) { mm = "0" + mm; }

                        //    resultado = dd + "/" + mm + "/" + yy;

                        //    if (resultado == "01/01/1") {
                        //        return "";
                        //    } else {
                        //        return resultado;
                        //    }
                            $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                                let horita = moment(Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA).format("HH:mm:SS");
                                if(horita == "00:00:00"){
                                    return "-/-";
                                } else {
                                    return horita;
                                }
                            }),
                        //}),
                        //$("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                        //    //Obtener valores
                        //    var obj_date2 = new Date(Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA);
                        //    var hh = parseInt(obj_date2.getHours());
                        //    var mm = parseInt(obj_date2.getMinutes());
                        //    var ss = parseInt(obj_date2.getSeconds());
                        //    var resultado = "";

                        //    if (hh < 10) { hh = "0" + hh; }
                        //    if (mm < 10) { mm = "0" + mm; }
                        //    if (ss < 10) { ss = "0" + ss; }

                        //    resultado = hh + ":" + mm + ":" + ss;
                        //    if (resultado == "00:00:00") {
                        //        return "";
                        //    } else {
                        //        return resultado;
                        //    }


                        //}),
                        $("<td>").css("text-align", "center").text(function () {
                            $(this).css("cssText", "text-align:left;").text(Mx_Dtt_Marcar[i].PAC_NOMBRE + " " + Mx_Dtt_Marcar[i].PAC_APELLIDO);
                        }),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                                $(this).css("cssText", "text-align:center;").text("");
                            }
                            else {
                                $(this).css("cssText", "text-align:center;").text(Mx_Dtt_Marcar[i].ATE_NUM);
                            }
                        }),
                        //Mostrar Check Segun estado de recep 
                            $("<td>").css("text-align", "center").text(function () {
                                if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                                } else {
                                    if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "ENVIADO") {
                                        $(this).css("cssText", "text-align:center;background-color:#ffeafc;").text("");
                                    }
                                    else {
                                        $(this).html("<input type='checkbox' id='chekito" + i + "' value='" + Mx_Dtt_Marcar[i].CB_DESC + "'/>")
                                    }
                                }
                            }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].USU_NIC)
                    )
                );
                    
                //} else if (((xi > 0) && (Mx_Dtt_Marcar[xi].CB_DESC != Mx_Dtt_Marcar[xi - 1].CB_DESC))) {
                //    $("#DataTable_Antiguos tbody").append(
                //    $("<tr>").append(
                //    $("<td>").css("text-align", "center").text(function () {
                //        if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                //            $(this).css("cssText", "text-align:center;").text("");
                //        }
                //        else {
                //            $(this).css("cssText", "text-align:center;").text(i + 1);
                //        }
                //    }),

                //    $("<td>").css("text-align", "center").text(function () {
                //        if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                //            $(this).css("cssText", "text-align:center;").text("");
                //        }
                //        else {
                //            $(this).css("cssText", "text-align:left;").text("[" + Mx_Dtt_Marcar[i].CB_DESC + "]" + " " + Mx_Dtt_Marcar[i].T_MUESTRA_DESC);
                //        }
                //    }),
                //        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].CF_DESC),
                //        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                //            //Obtener valores
                //            var obj_date = new Date(Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA);
                //            var dd = parseInt(obj_date.getDate());
                //            var mm = parseInt(obj_date.getMonth()) + 1;
                //            var yy = parseInt(obj_date.getFullYear());

                //            if (dd < 10) { dd = "0" + dd; }
                //            if (mm < 10) { mm = "0" + mm; }

                //            return String(dd + "/" + mm + "/" + yy);
                //        }),
                //        $("<td>", { "align": "center" }, { "class": "textoReducido" }).text(function () {
                //            //Obtener valores
                //            var obj_date2 = new Date(Mx_Dtt_Marcar[i].ENVIO_ETI_FECHA);
                //            var hh = parseInt(obj_date2.getHours());
                //            var mm = parseInt(obj_date2.getMinutes());
                //            var ss = parseInt(obj_date2.getSeconds());

                //            if (hh < 10) { hh = "0" + hh; }
                //            if (mm < 10) { mm = "0" + mm; }
                //            if (ss < 10) { ss = "0" + ss; }

                //            return String(hh + ":" + mm + ":" + ss);


                //        }),
                //        $("<td>").css("text-align", "center").text(function () {
                //            $(this).css("cssText", "text-align:left;").text(Mx_Dtt_Marcar[i].PAC_NOMBRE + " " + Mx_Dtt_Marcar[i].PAC_APELLIDO);
                //        }),
                //        $("<td>").css("text-align", "center").text(function () {
                //            if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                //                $(this).css("cssText", "text-align:center;").text("");
                //            }
                //            else {
                //                $(this).css("cssText", "text-align:center;").text(Mx_Dtt_Marcar[i].ATE_NUM);
                //            }
                //        }),
                //        //Mostrar Check Segun estado de recep 
                //            $("<td>").css("text-align", "center").text(function () {
                //                if (Mx_Dtt_Marcar[i].CB_DESC == "") {
                //                } else {
                //                    if (Mx_Dtt_Marcar[i].EST_DESCRIPCION == "ENVIADO") {
                //                        $(this).css("cssText", "text-align:center;background-color:#ffeafc;").text("");
                //                    }
                //                    else {
                //                        $(this).html("<input type='checkbox' id='chekito" + i + "' value='" + Mx_Dtt_Marcar[i].CB_DESC + "'/>")
                //                    }
                //                }
                //            }),
                //        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Marcar[i].USU_NIC)
                //    )
                //);
                //}
                //xi++;
            }
        }

        //------------------------------------------------ ANTECEDENTES PACIENTE  ----------------------------------------------------|
        function Fill_DataTable_Atencion() {
            //     -------------------------------------------------  1   ---------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion thead").attr("class", "cabezera");

            $("#DataTable_Atencion thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Nac."),
                    $("<th>", { "class": "textoReducido" }).text("Edad"),
                    $("<th>", { "class": "textoReducido" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido" }).text("F.U.R")

                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                var sexo = "";
                if (Mx_Dtt_Atencion[i].SEXO_DESC == "Femenino") {

                } else {

                };
                $("#DataTable_Atencion tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_NOMBRE + " " + Mx_Dtt_Atencion[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_FNAC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_AÑO + " " + "Años"),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Atencion[i].SEXO_DESC == "Femenino") {
                                $(this).css("cssText", "background-color:#f5b0e5 !important;  cursor:pointer; text-align:center;").text("Femenino");
                            }
                            else {
                                $(this).css("cssText", " color:inherit; background-color:#88d6e2 !important; text-align:center;").text("Masculino");
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_FUR)
                    )
                );
            }
            //   ------------------------------------------------ 2 ---------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion2",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion2").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion2").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion2 thead").attr("class", "cabezera");

            $("#DataTable_Atencion2 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Nacionalidad"),
                    $("<th>", { "class": "textoReducido" }).text("Teléfono Fijo"),
                    $("<th>", { "class": "textoReducido" }).text("Celular"),
                    $("<th>", { "class": "textoReducido" }).text("Ciudad"),
                    $("<th>", { "class": "textoReducido" }).text("Comuna"),
                    $("<th>", { "class": "textoReducido" }).text("Dirección")
                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion2 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].NAC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_FONO1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_MOVIL1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].CIU_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].COM_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_DIR)
                    )
                );
            }

            //------------------------------------------------------- 3 --------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion3",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion3").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion3").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion3 thead").attr("class", "cabezera");

            $("#DataTable_Atencion3 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Email"),
                    $("<th>", { "class": "textoReducido" }).text("Observaciones PERMANENTES del Paciente")
                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion3 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_EMAIL),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].PAC_OBS_PERMA)
                    )
                );
            }
            //------------------------------------------------------- 4 ---------------------------------------------------------------|
            $("<table>", {
                "id": "DataTable_Atencion4",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Atencion");

            $("#DataTable_Atencion4").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion4").attr("class", "table table table-hover table-striped table-iris");
            $("#DataTable_Atencion4 thead").attr("class", "cabezera");

            $("#DataTable_Atencion4 thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("Observación de la Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Observación de Toma de Muestra")

                )
            );

            for (i = 0; i < Mx_Dtt_Atencion.length; i++) {
                $("#DataTable_Atencion4 tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_OBS_FICHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Atencion[i].ATE_OBS_TM)
                    )
                );
            }

        }

        //------------------------------------------------ TABLA ATENCIONES REGISTRADAS ANTECEDENTES PACIENTE --------------------------|
        function Fill_DataTable_Datos_Actuales() {
            $("<table>", {
                "id": "DataTable_Atencion_Datos_Actuales",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Datos_Actuales");

            $("#DataTable_Atencion_Datos_Actuales").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Atencion_Datos_Actuales").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Atencion_Datos_Actuales thead").attr("class", "cabezera2");

            $("#DataTable_Atencion_Datos_Actuales thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar de TM"),
                    $("<th>", { "class": "textoReducido" }).text("Tipo Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    $("<th>", { "class": "textoReducido" }).text("Médico")
                )
            );

            for (i = 0; i < Mx_Dtt_Datos_Actuales.length; i++) {
                $("#DataTable_Atencion_Datos_Actuales tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].ATE_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].PAC_NOMBRE + " " + Mx_Dtt_Datos_Actuales[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].ATE_FECHA),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].PROC_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].TP_ATE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].PREVE_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Datos_Actuales[i].DOC_NOMBRE + " " + Mx_Dtt_Datos_Actuales[i].DOC_APELLIDO)
                    )
                );
            }
        }

        //------------------------------------------------ TABLA LOTES ANTERIORES   -----------------------------------------------------|
        function Fill_DataTable_Lotes_Anteriores() {
            $("<table>", {
                "id": "DataTable_Lotes_Anteriores",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Lotes_Anteriores");

            $("#DataTable_Lotes_Anteriores").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Lotes_Anteriores").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Lotes_Anteriores thead").attr("class", "cabezera2");

            $("#DataTable_Lotes_Anteriores thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("fecha"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote")
                )
            );

            for (i = 0; i < Mx_Dtt_Lotes_Anteriores.length; i++) {
                $("#DataTable_Lotes_Anteriores tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Muestras_Lotes("` + Mx_Dtt_Lotes_Anteriores[i].ENVIO_NUM + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Lotes_Anteriores[i].ENVIO_FECHA);
                            var dd = parseInt(obj_date.getDate());
                            var mm = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());

                            if (dd < 10) { dd = "0" + dd; }
                            if (mm < 10) { mm = "0" + mm; }

                            return String(dd + "/" + mm + "/" + yy);
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Lotes_Anteriores[i].ENVIO_NUM)
                    )
                );
            }
        }

        //------------------------------------------------ TABLA MUESTRAS POR LOTES -----------------------------------------------------|
        function Fill_DataTable_Muestras_Por_Lotes() {
            $("<table>", {
                "id": "DataTable_Muestras_Por_Lotes",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Muestras_Lotes");

            $("#DataTable_Muestras_Por_Lotes").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Muestras_Por_Lotes").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Muestras_Por_Lotes thead").attr("class", "cabezera");

            $("#DataTable_Muestras_Por_Lotes thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Etiqueta"),
                    $("<th>", { "class": "textoReducido" }).text("Examen Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Nombre Paciente"),
                    $("<th>", { "class": "textoReducido" }).text("Folio"),
                    $("<th>", { "class": "textoReducido" }).text("N° Lote"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Desc. Sección"),
                    $("<th>", { "class": "textoReducido" }).text("Lugar")
                )
            );

            for (i = 0; i < Mx_Dtt_Muestras_Lotes.length; i++) {
                $("#DataTable_Muestras_Por_Lotes tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text("[" + Mx_Dtt_Muestras_Lotes[i].CB_DESC + "]" + " " + Mx_Dtt_Muestras_Lotes[i].T_MUESTRA_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].CF_DESC),
                        $("<td>").css("text-align", "center").text(function () {
                            if (Mx_Dtt_Muestras_Lotes[i].EST_DESCRIPCION == "RECEP.") {
                                $(this).css("cssText", "background-color: #88d6e2 !important; cursor:pointer; text-align:center;").text("RECEP.");
                            }
                            else {
                                $(this).css("cssText", "background-color:#f5b0e5 !important; text-align:center;").text(Mx_Dtt_Muestras_Lotes[i].EST_DESCRIPCION);
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(moment(Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_FECHA).format("DD/MM/YYYY")),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].PAC_NOMBRE + " " + Mx_Dtt_Muestras_Lotes[i].PAC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].ENVIO_ETI_NUM_ATE),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].ENVIO_NUM),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].USU_NIC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].RLS_LS_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido2" }).text(Mx_Dtt_Muestras_Lotes[i].PROC_DESC)
                    )
                );
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

        #DataTable_Ate tbody td {
            text-transform: uppercase;
        }

        #DataTable_Lis_Exa_Ate tbody td {
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

        .cabzera {
            background: #46963f;
            color: white;
        }

        .cabezera {
            background: #46963f;
            color: white;
        }
        .negrin{
            font-weight: 900;
        }
        .cabezera2 {
            background: #081f44;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .textoReducido2 {
            font-size: 10px;
        }

        .highlights {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 710px;
            height: 404px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
        }

        .checkbox-success input[type="checkbox"]:checked + label::before {
            background-color: #5cb85c;
            border-color: #5cb85c;
        }

        .checkbox-success input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-success {
            line-height: 13px;
            margin-bottom: 3px;
        }

            .checkbox-success input[type="checkbox"], label {
                cursor: pointer;
            }

        .checkbox label {
            width: 90%;
        }
            #XXXXXXXX {
            z-index:9000;
            width:100%;
            position:fixed;
            left: 0px;
            top:0px;
            display:flex;
            display:-webkit-flex;
            flex-flow:row nowrap;
            justify-content:center;      
            color: #01718c;
            border: 0;
            border-radius: 2px;
            text-decoration: none;
            transition: opacity 0.2s ease-out;
            opacity: 0;
            margin-top: 58px;
            cursor: pointer;
      
        }
        #XXXXXXXX div
        {
              font-size: 18px;
              border: none;
              outline: none;
              background-color: #009ec4;
              color: white;           
              padding: 5px;
              border-radius: 4px;
              font-size: 14px;
        }

     

            #XXXXXXXX.show {
                opacity: 1;
            }

        @media screen and (max-width: 600px) {
            #Paciente {
                margin-bottom: 1rem;
            }

            .flexon {
                display: flex;
                flex-flow: column;
                width: 90vw;
            }

            .flx {
                flex: 1;
                max-width: 100%;
            }

            .highlights {
                height: 100%;
            }

            .buttons {
                display: flex;
                flex-flow: column;
            }

        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
     <div id="XXXXXXXX" class="tobackinfo">
  <div id="xxx_xxx">
    
  </div>
  </div>

    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document" style="max-width:60vw">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss"></h4>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                <div class="col-md-7">
                    <div class="row">
                        <div class="col-md-2">
                            <label>Paciente: </label>
                        </div>
                        <div class="col-md-10">
                            <label id="superNomPaciente"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Médico: </label>
                        </div>
                        <div class="col-md-10">
                            <label id="superNombre"></label>
                        </div>
                    </div>
                </div>
                    <div class="col-md-4">
                    <div class="row">
                        <div class="col">
                            <label>N° Atención: </label>
                        </div>
                        <div class="col">
                            <label id="superNumAte"></label>
                        </div>
                    </div>
                        <div class="row">
                            <div class="col">
                                <label>Previsión: </label>
                            </div>
                            <div class="col">
                                <label id="superPrevision"></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Lugar de TM: </label>
                            </div>
                            <div class="col">
                                <label id="superLugar"></label>
                            </div>
                        </div>
                    </div>
            </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Antiguos" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Anterior" class="btn btn-dark fa fa-arrow-circle-o-left"></button>
                    <button type="button" id="Btn_Siguiente" class="btn btn-dark fa fa-arrow-circle-o-right"></button>
                    <button type="button" id="Btn_Guardar" class="btn btn-primary"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                </div>
                </div>
            </div>
        </div>
    <!-- Modal de confirmacion pendientes -->
    <div id="modal_pendientes" class="modal fade" role="dialog">
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
                    <button type="button" id="Btn_Pendiente_Si" class="btn btn-success"><i class="fa fa-fw fa-check mr-2"></i>Si</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>No</button>
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
    <!-- Modal Correlativo-->
    <div id="Modal_Correlativo" class="modal fade" role="dialog">
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
                    <button id="Btn_Confirmar_Lote" class="btn btn-danger" type="submit"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------------- MODAL DE INFO PACIENTE -------------------------------------------------------%>
    <div class="modal fade" id="eModalInfo" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Antecedentes del Paciente</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Atencion" style="width: 100%;" class="table-responsive"></div>
                    <h4>Listado de Atenciones Registradas</h4>
                    <div id="Div_Datos_Actuales" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <h5>N° de Atenciones: </h5>
                    <h5 id="numAtessss"></h5>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------------- MODAL LOTES ANTERIORES ---------------------------------------------------%>
    <div id="eModalLotesAnteriores" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Últimos Lotes</h4>
                </div>
                <div class="modal-body">
                    <div id="Div_Tabla_Lotes_Anteriores" style="width: 100%;" class="table-responsive"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%---------------------------------------------------- MODAL MUESTRAS DE LOTE --------------------------------------------------------%>
    <div class="modal fade" id="eModal_Muestras_Por_Lotes" tabindex="-1" role="dialog" aria-labelledby="eModalLabel">
        <div class="modal-dialog modal-lg" role="document" style="width: 80vw; max-width: 80vw;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Listar Lote de Trabajo</h4>
                </div>
                <div class="modal-header">
                    <h5>N° Lote: </h5>
                    <button type="button" id="Btn_Anterior_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-left"></button>
                    <h5 id="lote_nummmmm"></h5>
                    <button type="button" id="Btn_Siguiente_Muestras_Lotes" class="btn btn-success fa fa-arrow-circle-o-right"></button>
                    <button type="button" id="Btn_Grupos_Muestras_Lotes" class="btn btn-info"><i class="fa fa-fw fa-eye mr-2"></i>Ver Grupos Anteriores</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Salir</button>
                </div>
                <div class="modal-body" style="overflow: auto;">
                    <h5 class="modal-title" id="numerito">Listado de Muestra Recepcionada</h5>
                    <div id="Div_Muestras_Lotes" class="table-responsive" style="width: 100%; overflow: auto; max-height: 40vh;"></div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------------------------TÍTULO, TEXTBOX Y BOTONES----------------------------------------------%>
    <div>
        <div class="col-lg-1"></div>
    <div class="card-header bg-bar">
        <h5 style="text-align: center; padding: 5px;">
            <i class="fa fa-search"></i>
            Proceso EnvÍo de Muestras
        </h5>
    </div>
    <div class="row">
        <div class="col-lg-2">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtNAte">N° Etiqueta:</label>
                    <input id="txtNAte" maxlength="13" class="form-control textoReducido" type="text" placeholder="BUSCAR..." onkeydown="return jsDecimals(event);" />
                    <button id="Btn_Buscar_x_ate" class="btn btn-buscar btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtNum">N° Aten:</label>
                    <input id="txtNum" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtRut">Rut:</label>
                    <input id="txtRut" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtNom">Nombre:</label>
                    <input id="txtNom" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtEdad">Edad:</label>
                    <input id="txtEdad" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtSexo">Sexo:</label>
                    <input id="txtSexo" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtFono">Fono:</label>
                    <input id="txtFono" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtCel">Celular:</label>
                    <input id="txtCel" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtObsAte">Observaciones de la Atención:</label>
                    <input id="txtObsAte" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-12">
                    <label for="txtObsTm">Observaciones de Toma de Muestra:</label>
                    <input id="txtObsTm" class="form-control textoReducido" type="text" readonly="readonly" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <button id="Btn_Lote" class="btn btn-warning btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-eye mr-2"></i>Ver Lote</button>
        </div>
        <div class="col">
            <button id="Btn_Crear_Lote" class="btn btn-primary btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-save mr-2"></i>Crear Lote</button>
        </div>
        <div class="col">
            <button id="Btn_Pendiente" class="btn btn-danger btn-block" style="margin-bottom: 1vh; padding: 3px;" type="submit"><i class="fa fa-fw fa-clock-o mr-2"></i>Pendiente</button>
        </div>
        <div class="col">
            <button id="Btn_Info" class="btn btn-info btn-block" style="margin-bottom: 1vh; padding: 3px; border: 1px;" type="submit"><i class="fa fa-fw fa-eye mr-2"></i>Más Info</button>
        </div>
    </div>
    <div class="col-lg-1"></div>
    </div>

    <%-------------------------------------------------------------TABLAS-----------------------------------------------------------%>
    <div class="row" id="Id_Conte">
        <div class="col-lg-12" id="Paciente">
            <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-fw fa-list"></i>Listado de <b>MUESTRAS</b> Enviadas</h5>
            <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
            <div id="Div_Tabla_Load" style="width: 100%;" class="highlights"></div>
            <br />    
        <%--    <h5 style="text-align: center; padding: 5px; font-size: 15px;"><i class="fa fa-table"></i> Listado de <b>TUBOS</b> enviados</h5>
            <div id="Div_Totales" style="width: 100%; border-radius: 5px;" class="highlights"></div>--%>
        </div>
    </div>
</asp:Content>
