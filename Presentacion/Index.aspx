<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Index.aspx.vb" Inherits="Presentacion.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%--<script>
        $(document).click(() => {
            checkGalletas();
        });

        $(document).keypress(() => {
            checkGalletas();
        });

        let checkGalletas = () => {
            Galletas.modTime("ASP.NET_SessionId", 30 * 60);
            Galletas.modTime("LOGGED", 30 * 60);
            Galletas.modTime("ID_USER", 30 * 60);
            Galletas.modTime("NICKNAME", 30 * 60);
            Galletas.modTime("NAME", 30 * 60);
            Galletas.modTime("SURNAME", 30 * 60);
            Galletas.modTime("P_ADMIN", 30 * 60);
            Galletas.modTime("USU_ID_PROC", 30 * 60);
            Galletas.modTime("USU_PREV", 30 * 60);

            if (Galletas.getGalleta("ID_USER") == null) {
                location.href = "/Index.aspx";
            }
        }

    </script>--%>
    <script>
        $(document).ready(function () {
            $("#con_wra").removeClass("py-3");
            $('#1').attr("onclick", '(window.location.href="/ate_pac/busca_paciente.aspx")');
            $('#2').attr("onclick", '(window.location.href="/agenda_med/in_pac_man.aspx")');

            $('#3').attr("onclick", '(window.location.href="/ate_pac/Imp_Ate_P.aspx")');
            $('#4').attr("onclick", '(window.location.href="/agenda_med/Imp_Ate_Directo.aspx")');

            AJAX_CANT();
            AJAX_EXA();

            if ($(window).width() < 975) {
                $(".btnx").removeClass("btn-sq");
                $(".btnx").addClass("btn-block");
            }

            $(window).on('resize', function () {
                if ($(window).width() < 975) {
                    $(".btnx").addClass("btn-block");
                    $(".btnx").removeClass("btn-sq");

                }
                else {
                    $(".btnx").addClass("btn-sq");
                    $(".btnx").removeClass("btn-block");

                }
            });
            var Nom = Galletas.getGalleta("NAME");
            var Ape = Galletas.getGalleta("SURNAME");
            Nom = Nom.toUpperCase();
            Ape = Ape.toUpperCase();
            $("#spn_Usr").text(Nom + " " + Ape);

            ////////////////////BTN PRUEBA
            ///// SPLIT CADENA NUMEROS POR , 
            Call_AJAX_Ddl();
            var permiss = Galletas.getGalleta("P_ADMIN");

            //botones
            var btn_datas = {
                "datass":
                [{      //01
                    "href": "Agenda_Med/N_Ver_Disponibilidad.aspx",
                    "icon": "book",
                    "textn1": "Agenda",
                    "textn2": "Médica"
                },
                {       //02
                    "href": "Agenda_Med/Lis_Pac_TDM.aspx",
                    "icon": "list",
                    "textn1": "Listar",
                    "textn2": "Paciente"
                },
                {       //03
                    "href": "#",
                    "icon": "user",
                    "textn1": "Ingreso de",
                    "textn2": "Atención"
                },
                {       //04
                    "href": "Ate_Pac/Search_Pac.aspx",
                    "icon": "search",
                    "textn1": "Búsqueda de",
                    "textn2": "Pacientes"
                },
                {       //05
                    "href": "Buscar_Ate/Buscar_Atencion.aspx",
                    "icon": "search",
                    "textn1": "Búsqueda de",
                    "textn2": "Atenciones"
                },
                {       //06
                    "href": "Toma_Muestra/Adm_TM.aspx",
                    "icon": "eyedropper",
                    "textn1": "Toma de",
                    "textn2": "Muestras"
                },
                {       //07
                    "href": "Recep_Mue/Recep_Mue_PENDIENTES_2.aspx",
                    "icon": "flask",
                    "textn1": "Recepción de",
                    "textn2": "Muestras"
                },
                {       //08
                    "href": "",
                    "icon": "users",
                    "textn1": "Grupo de",
                    "textn2": "Trabajo"
                },
                {       //09
                    "href": "Imp_Etiquetas/Impr_Etiq.aspx",
                    "icon": "barcode",
                    "textn1": "Impresión de",
                    "textn2": "Etiquetas"
                },
                {       //10
                    "href": "",
                    "icon": "area-chart",
                    "textn1": "Visor de",
                    "textn2": "Resultados"
                },
                {       //11
                    "href": "",
                    "icon": "print",
                    "textn1": "Impresión de",
                    "textn2": "Resultados"
                },
                {       //12
                    "href": "/Imp_Etiquetas/Impr_Dctos.aspx",
                    "icon": "print",
                    "textn1": "Reimpresión",
                    "textn2": "Documentos"
                },
                {       //13
                    "href": "Repor_check.aspx",
                    "icon": "area-chart",
                    "textn1": "Reportes y",
                    "textn2": "Check List"
                },
                {       //14
                    "href": "Gest_Financ/Estadisticas/Resumen/Cupo_Tot_ate.aspx",
                    "icon": "area-chart",
                    "textn1": "Ver Cupos",
                    "textn2": "Agendados"
                },
                {       //15
                    "href": "Env_Mues_Lab/Env_Mues_Lab_PENDIENTES_2.aspx",
                    "icon": "random",
                    "textn1": "Envío de",
                    "textn2": "Muestras"
                },
                {       //16
                    "href": "Env_Mues_Lab/Lis_Env_Mues_Lab_2.aspx",
                    "icon": "flask",
                    "textn1": "Lista Muest.",
                    "textn2": "Env. por Tubo"
                },
                {       //17
                    "href": "Reporte/Laboratorio/REP_LAB_EXA.aspx",
                    "icon": "table",
                    "textn1": "Buscar Ate.",
                    "textn2": "por Examen"
                },
                {       //18
                    "href": "Exa_Esp_V.aspx",
                    "icon": "edit",
                    "textn1": "Cambiar Estado",
                    "textn2": "Examen"
                },
                {       //19
                    "href": "Env_Mues_Lab/Lis_Env_Mues_Lab_3.aspx",
                    //"href": "#",
                    "icon": "flask",
                    "textn1": "Lista Muest.",
                    "textn2": "Env. por Lote"
                },
                {       //20
                    "href": "Agenda_Med/AGRE_EXA_ATE.aspx",
                    "icon": "plus-square",
                    "textn1": "Agregar Exam.",
                    "textn2": "a Atención"
                },
                {       //21
                    "href": "/Account/Conf_User.aspx",
                    "icon": "user",
                    "textn1": "Configuración",
                    "textn2": "de Usuarios"
                },
                 {       //22
                     "href": "/Check_List/Check_Point/ValoresCriticos_EMB_2.aspx",
                     "icon": "exclamation-triangle",
                     "textn1": "Valores",
                     "textn2": "Críticos"
                 },
                {       //23
                    "href": "/Check_List/Check_Point/Traza_Env_RecepLab2.aspx",
                    "icon": "exclamation-triangle",
                    "textn1": "Traza. Env/",
                    "textn2": "Rec/Rec.Lab"
                },
                {       //24
                    "href": "/Recha_Mues/Recha_Mues.aspx",
                    "icon": "window-close",
                    "textn1": "Rechazo",
                    "textn2": "de Muestras"
                },
                {       //25
                    "href": "/Recha_Mues/Lis_Recha_Mues.aspx",
                    "icon": "flask",
                    "textn1": "Lista",
                    "textn2": "Muestras Recha."
                },
                {       //26
                    "href": "/Check_List/Val_Criticos_New.aspx",
                    "icon": "exclamation-triangle",
                    "textn1": "Listado de",
                    "textn2": "Valores Críticos"
                },{     //27
                    "href": "/Fecha_Conf/Config_Ate_LM.aspx",
                    "icon": "edit",
                    "textn1": "Configuración",
                    "textn2": "Agendamiento."
                },
                {       //28
                    "href": "/Check_List/Rev_Deter_Exa_EMB.aspx",
                    "icon": "exclamation-triangle",
                    "textn1": "Resultados por",
                    "textn2": "Determinacion"
                },
                {       //29
                    "href": "/Gerencia.aspx",
                    "icon": "address-book-o",
                    "textn1": "Reportes",
                    "textn2": "Gerencia"
                },
                {       //30
                    "href": "/Resultados/Ate_Resultados.aspx",
                    "icon": "check",
                    "textn1": "Visor de",
                    "textn2": "Resultados"
                },
                {       //31
                    "href": "/Scan_Docs/Ver_Orden.aspx",
                    "icon": "file-text-o",
                    "textn1": "Ver",
                    "textn2": "Ordenes"
                },
                {       //32
                    "href": "/Gest_Financ/Estadisticas/Resumen/Resumen_Prev_Prog_Subp_Scr_2.aspx",
                    "icon": "file-text-o",
                    "textn1": "Secretaria",
                    "textn2": "Resu Atenciones"
                },
                {       //33
                "href": "/Gest_Financ/Lista_Graficos/GraficoTPUser.aspx",
                "icon": "file-text-o",
                "textn1": "Cant. Anuales",
                "textn2": "Por Usuario"
                },
                {       //34
                    "href": "/Reporte/Secretaria/DET_ATE_X_USU_TP.aspx",
                    "icon": "file-text-o",
                    "textn1": "Det. Ate",
                    "textn2": "Usu. y T. Pago"
                },
                {       //35
                    "href": "/Reporte/Secretaria/DET_ATE_X_PREV_TP.aspx",
                    "icon": "file-text-o",
                    "textn1": "Det. Ate",
                    "textn2": "Preve. - Usuario"
                },
                {       //36
                    "href": "/Gest_Financ/Estadisticas/Resumen/Resumen_Prev_Prog_Subp_Scr_3.aspx",
                    "icon": "file-text-o",
                    "textn1": "Secreataria",
                    "textn2": "Caja por Usuario"
                },
                {       //37
                    "href": "/Gest_Financ/Estadisticas/Resumen/Resumen_Prev_Prog_Subp_Scr_3_Glob.aspx",
                    "icon": "file-text-o",
                    "textn1": "Secreataria",
                    "textn2": "Caja Global"
                },
                {       //38
                    "href": "/Gest_Financ/Estadisticas/Resumen/Resumen_Prev_Prog_Subp_Scr_3_Glob_Rend.aspx",
                    "icon": "file-text-o",
                    "textn1": "",
                    "textn2": "Revisión"
                },
                {       //39
                    "href": "/Agenda_Med/Ingreso_Ate_Caja4.aspx",
                    "icon": "user",
                    "textn1": "Ingreso",
                    "textn2": "Caja"
                },
                {       //40
                    "href": "/Gest_Financ/Estadisticas/Resumen/Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx",
                    "icon": "file-text-o",
                    "textn1": "Revisión",
                    "textn2": "Múltiple"
                }
                ,
                {
                        //41
                    "href": "/Check_list/Check_Point/Rel_Est_Exam.aspx",
                    "icon": "file-text-o",
                    "textn1": "Check",
                    "textn2": "Estadísticas"
                }
                ,
                {
                        //42
                    "href": "/Gest_Financ/Estadisticas/Resumen/Resumen_Mod_TP_Pago.aspx",
                    "icon": "money",
                    "textn1": "Mod",
                    "textn2": "TP Pago"
                }
                ,
                {       //43
                    "href": "/Agenda_Med/Ingreso_Ate_Caja5.aspx",
                    "icon": "plane",
                    "textn1": "Caja",
                    "textn2": "Imed"
                },
                {       //44
                    "href": "/B_Elect/Boleta_Electronica.aspx",
                    "icon": "file-text-o",
                    "textn1": "Boleta",
                    "textn2": "Electrónica"
                },
                {       //45
                    "href": "Imed/Anul_Bon.aspx",
                    "icon": "file-text-o",
                    "textn1": "Anular",
                    "textn2": "Bono Imed"
                },
                {       //46
                    "href": "Configuraciones/Prevision/Asoc_Pre_Pre.aspx",
                    "icon": "money",
                    "textn1": "Asociar",
                    "textn2": "Precios"
                },
                {       //47
                    "href": "Configuraciones/Medicos/Crea_Edita_Med.aspx",
                    "icon": "medkit",
                    "textn1": "Crear",
                    "textn2": "Médico"
                }
                ,
                {       //48
                    "href": "QC/Menu_QC.aspx",
                    "icon": "area-chart",
                    "textn1": "Iris",
                    "textn2": "QC"
                }
                ]
                
            };

            switch (parseInt(permiss)) {
                case 0: //RECEPCION

                    let aaaiiiidiiii_uuuusuuuuu = Galletas.getGalleta("ID_USER");

                    if (aaaiiiidiiii_uuuusuuuuu == 8888888) {
                        var btnbool = [];
                    } else {
                        var btnbool = [3, 20, 31, 44, 12, 6, 4, 5, 46, 47];
                    }

                    
                    break;
                case 1: //ADMIN
                    var btnbool = (function () {
                        let arrNum = [];

                        for (i = 0; i < btn_datas.datass.length; i++) {
                            if (btn_datas.datass[i].href.trim() != "") {
                                arrNum.push(i + 1);
                            }
                        }

                        return arrNum;
                    }());
                    break;
                case 2: //TOMA DE MUESTRA
                    var btnbool = [3, 6, 4, 5, 9, 12, 15, 7, 24, 23];
                    break;

                case 3: //COBRANZA
                    var btnbool = [40, 42, 44, 9];
                    break;

                case 4: //TM Y RECEPCION
                    var btnbool = [3, 20, 31, 44, 12, 6, 4, 5, 23, 9, 15, 7, 24];
                    break;

                case 5: //RECEPCION LABORATORIO
                    var btnbool = [23];
                    break;

                case 6:   //TECNOLOGO MÉDICO
                    var btnbool = [23, 24, 22];
                    break;

                case 7:   //CONTADOR
                    var btnbool = [44];
                    break;

            }

            var btn_count = btnbool.length;


            var max_cant = 5;




            var nrow1 = 1;
            //function color
            function fn_color(xPos) {
                let numLng = btn_datas.datass.length;
                let numPos = xPos;

                while (numPos > 3) {
                    numPos -= 4;
                }

                switch (numPos) {
                    case 0:
                        return "success";
                        break;
                    case 1:
                        return "danger";
                        break;
                    case 2:
                        return "warning";
                        break;
                    case 3:
                        return "primary";
                        break;
                }
            }
            //var internas
            var colors = "";
            var rows = "";
            var icon = "";
            var text1 = "";
            var text2 = "";
            var hreff = "#";
            var idxx = "";

            let dv_Id = 1;
            let btn_cnt = 0;

            btnbool.forEach((aaa, xIndex) => {
                btn_cnt += 1;
                var y = aaa - 1;
                colors = fn_color(xIndex);
                hreff = btn_datas.datass[y].href;
                icon = btn_datas.datass[y].icon;
                text1 = btn_datas.datass[y].textn1;
                text2 = btn_datas.datass[y].textn2;

                if (y == 2) {
                    idxx = "id='btnderivar'";
                }
                else if (y == 11) {
                    idxx = "id='btnreimp'";
                }
                    //else if (text1 == "Lista Muest.") {
                    //    idxx = "id='btnlismueenv'";
                    //}
                else {
                    idxx = "";
                }


                if (dv_Id == 1 && nrow1 == 1) {

                    //console.log("== 1");

                    $("#div_btn_row").append("<div class='row text-center mrgs mb-3' id='amed" + dv_Id + "'></div>");

                    rows = "#amed" + dv_Id;
                    nrow1 += 1;
                }
                else if (nrow1 <= max_cant) {
                    //console.log("<= max cant");
                    rows = "#amed" + dv_Id;
                    nrow1 += 1;
                }
                else {
                    //console.log(">= max cant");
                    nrow1 = 1;
                    dv_Id += 1;
                    $("#div_btn_row").append("<div class='row text-center mrgs mb-3' id='amed" + dv_Id + "'></div>");

                    rows = "#amed" + dv_Id;
                    nrow1 += 1;
                }

                $("<div>", { "class": "col-lg" }).append("<a href='" + hreff + "' " + idxx + " class='btn btn-sq btn-" + colors + " btnx'><i class='fa fa-" + icon + " fa-3x'></i><b><br />" + text1 + "<br>" + text2 + "</b></a>").appendTo(rows);



                if (btn_cnt == btnbool.length) {
                    let diff_row = max_cant - nrow1;

                    for (var i = 0; i <= diff_row; i++) {
                        $("<div>", { "class": "col-lg" }).appendTo(rows);
                    }
                }
            });
            ////////////////////BTN PRUEBA
            $("#btnderivar").click(function () {

                //window.location.href="/Agenda_Med/Ingreso_Ate.aspx";
                $('#Manual').attr("onclick", "window.location.href='/Agenda_Med/Ingreso_Ate.aspx'");
                $('#AVIS').attr("onclick", "window.location.href='/Agenda_Med/Ingreso_Ate_Caja4_Bol_2.aspx'");
                $('#eModal').modal('show');
            });

            $("#btnins").click(function () {
                console.log("click!");
                window.location.href = "http://www.laboratorioaleman.cl/examenesprestaciones/examenes/indicaciones/";
            });
            //$("#btnlismueenv").click(function () {
            //    $('#xtubo').attr("onclick", "window.location.href='/Env_Mues_Lab/Lis_Env_Mues_Lab_2.aspx'");
            //    $('#xlote').attr("onclick", "window.location.href='/Env_Mues_Lab/Lis_Env_Mues_Lab_3.aspx'");
            //    $('#eModal2').modal('show');
            //});

            //$("#btnreimp").click(function () {
            //    $('#ATENCION').attr("onclick", "window.location.href='/agenda_med/Imp_Ate_P.aspx'");
            //    $('#ATENCION_DIREC').attr("onclick", "window.location.href='/agenda_med/Imp_Ate_Directo.aspx'");
            //    $('#eModal_321').modal('show');
            //});
        });

        //´buscar lista de procendecia maz agenda disponible
        Mx_Cant = [{
            "TOTAL_ATE": "",
            "TOT_FONASA": "",
            "ID_ESTADO": "",
            "Expr1": ""
        }];
        Mx_Exa = [{
            "TOTAL_PREVE": "",
            "EST_DESCRIPCION": "",
            "ID_ESTADO": "",
            "ATE_DET_V_ID_ESTADO": ""
        }];

        function AJAX_CANT() {
            $.ajax({
                "type": "POST",
                "url": "Index.aspx/Bus_Cant",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Cant = JSON.parse(data.d);

                    if (Mx_Cant != null) {
                        Fill_Cant();
                    }

                },
                "error": data => {
                    //Debug
                     


                }
            });
        }
        function AJAX_EXA() {
            $.ajax({
                "type": "POST",
                "url": "Index.aspx/Bus_Exa",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Exa = JSON.parse(data.d);

                    if (Mx_Exa != null) {
                        Fill_Exa();
                    }

                },
                "error": data => {
                    //Debug



                }
            });
        }

        //Declaración de JSON
        var Mx_Ddl22 = [
            {
                "ID_PROCEDENCIA": "",
                "PROC_COD": "",
                "PROC_DESC": "",
                "ID_ESTADO": ""
            }
        ];
        //AJAX DroDownList
        function Call_AJAX_Ddl() {
            //Debug


            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Index.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl = JSON.parse(data.d);

                    var vv = Galletas.getGalleta("P_ADMIN");
                    var vv2 = Galletas.getGalleta("USU_ID_PROC");
                    if ((vv == 1) || (vv == 100) || (vv == 101) || (vv == 102)) {
                        $("#spn_tm").text("GENERAL");

                    } else {

                        Mx_Ddl.forEach(aaa => {
                            if (aaa.ID_PROCEDENCIA == vv2) {
                                $("#spn_tm").text(aaa.PROC_DESC);
                            } else {
                                $("#spn_tm").text("General");
                            }
                        });
                    }
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Fill_Cant() {
            Mx_Cant.forEach(function (cant) {
                $("#txt_Ate").text(cant.TOTAL_ATE);
                $("#txt_Exa").text(cant.TOT_FONASA);
            });

        }
        function Fill_Exa() {
            Mx_Exa.forEach(function (Exam) {
                if (Exam.ATE_DET_V_ID_ESTADO == 7) {
                    $("#txt_Esp").text(Exam.TOTAL_PREVE);
                }
                if (Exam.ATE_DET_V_ID_ESTADO == 6) {
                    $("#txt_Val").text(Exam.TOTAL_PREVE);
                }
                if (Exam.ATE_DET_V_ID_ESTADO == 14) {
                    $("#txt_Imp").text(Exam.TOTAL_PREVE);
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        .btn-warning:hover {
            color: white;
        }

        .btnx {
            color: white !important;
            min-width: 131px !important;
        }

        .hd {
            display: none;
        }

        .fa-3x {
            margin-top: 7px;
        }

        .btn-warning {
            color: white;
            background: #ffa837;
        }

        .col-lg {
            margin-bottom: 1rem;
        }

        .btn-sq-lg {
            width: 150px !important;
            height: 150px !important;
        }

        .btn-sq {
            width: 112px !important;
            height: 112px !important;
            font-size: 15px;
        }

        .btn-sq-sm {
            width: 50px !important;
            height: 50px !important;
            font-size: 10px;
        }

        .btn-sq-xs {
            width: 25px !important;
            height: 25px !important;
            padding: 2px;
        }

        .mrgs {
            margin-left: 5rem;
            margin-right: 5rem;
        }

        @media screen and (max-width:320px) {
            .mrgs {
                margin-left: 3rem;
                margin-right: 3rem;
            }
        }

        #imgx {
            width: 55vw;
        }

        @media screen and (max-width:992px) {
            #imgx {
                width: 80vw;
            }

            #usr {
                display: none;
            }
        }
    </style>


    <div class="row ml-3 mr-3 mb-3">
        <div class="col-lg" style="text-align: center">
            <img src="Imagenes/IrisLab%20Logo%20LARGOa.png" id="imgx" />
        </div>
        <div class="col-lg">
            <div class="card mt-lg-5 mb-3 p-3 border-info">
                <div class="row">
                    <div class="col-12 text-center">
                        <h5 style="color: #007e9e"><b><span id="spn_tm"></span></b></h5>
                    </div>
                    <div class="col-lg mb-0">
                        <h5>N° de Atenciones</h5>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Ate">N° Atenciones:</label>
                            </div>
                            <div class="col-4 text-primary">
                                <b>
                                    <label id="txt_Ate">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Exa">N° Exámenes:</label>
                            </div>
                            <div class="col-4 text-success">
                                <b>
                                    <label id="txt_Exa">0</label></b>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg mb-0 ">
                        <h5>Estado de Exámenes</h5>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Esp">N° Espera:</label>
                            </div>
                            <div class="col-4 text-danger">
                                <b>
                                    <label id="txt_Esp">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Val">N° Validados:</label>
                            </div>
                            <div class="col-4 text-primary">
                                <b>
                                    <label id="txt_Val">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Imp">N° Impresos:</label>
                            </div>
                            <div class="col-4 text-success">
                                <b>
                                    <label id="txt_Imp">0</label></b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="div_btn_row">
    </div>

    <div class="text-center" id="usr">
        <h3 style="color: #015368"><b>BIENVENIDO(A)  <span id="spn_Usr"></span></b></h3>
    </div>
    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="sss">OPCIONES DE INGRESO DE ATENCIÓN</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-6 " style="text-align: center;">
                            <button type="button" id="Manual" class="btn btn-primary btn-lg btn-block p-2">PACIENTE MANUAL</button>
                        </div>
                        
                        <div class="col-6 " style="text-align: center;">
                            <button type="button" id="AVIS" class="btn btn-info btn-lg btn-block p-2" >PACIENTE CAJA</button>
                        </div>
                        <%--<div class="col-6 " style="text-align: center;">
                            <a href="/Agenda_Med/Ingreso_Ate_Saydex.aspx" class="btn btn-danger btn-lg btn-block p-2">RAYEN</a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="sss2">OPCIONES LISTA DE MUESTRAS ENVIADAS</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-6 " style="text-align: center;">
                            <button type="button" id="xtubo" class="btn btn-primary btn-lg btn-block p-2">POR TUBO</button>
                        </div>

                        <div class="col-6 " style="text-align: center;">
                            <button type="button" id="xlote" class="btn btn-info btn-lg btn-block p-2">POR LOTE</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal_321" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="55555">OPCIONES DE REIMPRESIÓN</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="ATENCION" class="btn btn-primary" style="height: 120px; width: 75%;"><b>PRE-INGRESO Y ATENCÍON</b></button>
                        </div>
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="ATENCION_DIREC" class="btn btn-info" style="height: 120px; width: 75%;"><b>ATENCIÓN DIRECTA</b></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
