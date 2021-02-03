<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_MINDS.Master" CodeBehind="Index_MINDS.aspx.vb" Inherits="Presentacion.Index_MINDS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>
    <script>

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

        $(document).ready(function () {

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

            $("#btn_TEEEEEEST").click(() => {
                AJAX_TEEEEEEEST();

            });

            $("div_hide").hide();
            $('#1').attr("onclick", '(window.location.href="/ate_pac/busca_paciente.aspx")');
            $('#2').attr("onclick", '(window.location.href="/agenda_med/in_pac_man.aspx")');

            $('#3').attr("onclick", '(window.location.href="/ate_pac/Imp_Ate_P.aspx")');
            $('#4').attr("onclick", '(window.location.href="/agenda_med/Imp_Ate_Directo.aspx")');

            AJAX_CANT();
            AJAX_EXA();
            AJAX_DataTable();

            $("#row_1").click(() => {
                row_1();
            });
            $("#row_2").click(() => {
                row_2();
            });
            $("#row_3").click(() => {
                row_3();
            });

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
            $("#spn_Usr").text(Nom + " " + Ape);

            ////////////////////BTN PRUEBA
            ///// SPLIT CADENA NUMEROS POR , 
            Call_AJAX_Ddl();
            var permiss = Galletas.getGalleta("P_ADMIN");
            switch (permiss) {
                case "0": //USU NORMAL
                    var btnbool;
                    if (Galletas.getGalleta("ID_USER") == 65) {     //MVASQUEZ
                        btnbool = [1, 2, 3, 4, 21, 5, 9, 12, 15, 16, 19, 17, 20, 23, 27,37, 35, 36, 38];
                    }else if (Galletas.getGalleta("ID_USER") == 160) {
                        btnbool = [1, 2, 3, 4, 21, 5, 9, 12, 15, 16, 19, 17, 20, 23, 27, 37, 35, 36];
                    }else if (Galletas.getGalleta("ID_USER") == 93) {
                        btnbool = [1, 2, 3, 4, 21, 5, 9, 12, 15, 16, 19, 17, 20, 23, 27, 37, 35, 36];
                    }
                    else {
                        btnbool = [1, 2, 3, 4, 21, 5, 9, 12, 15, 16, 19, 17, 20, 23, 35, 36];
                    }
                 
                    break;
                case "1": //ADMIN
                    btnbool = [1, 2, 3, 4, 5, 6, 7, 9, 12, 14, 18, 20, 23, 24, 26, 25, 27, 28, 31, 32, 33, 38, 39, 37, 40];
                    break;
                case "2": //CLINICO
                    var btnbool = [4, 5, 23];
                    break;
                case "3": //GESTION
                    var btnbool = [4, 5, 13, 23];
                    break;
                case "4": //AGENDA
                    if (Galletas.getGalleta("ID_USER") == 247) {                        //CLEON
                        var btnbool = [1, 2, 4, 21, 5, 12, 23, 27, 39, 38];
                    } else {
                        var btnbool = [1, 2, 4, 21, 5, 12, 23, 27];
                    }                   
                    break;
                case "5": //USU LAB WEB
                    var btnbool;
                    if (Galletas.getGalleta("ID_USER") == 57) {                         //MARAYA
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 39, 37, 38];
                    } else if (Galletas.getGalleta("ID_USER") == 135) {                 //KVEGA
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 39];
                    } else if (Galletas.getGalleta("ID_USER") == 58) {                  //MMELLA
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 39];
                    } else if (Galletas.getGalleta("ID_USER") == 49) {                  //CESCOBAR
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 38];
                    } else if (Galletas.getGalleta("ID_USER") == 51) {                  //TOYARZUN
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 38];
                    } else if (Galletas.getGalleta("ID_USER") == 145) {                 //DESCOBAR
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 38];
                    }
                    else if (Galletas.getGalleta("ID_USER") == 241) {                
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 38, 37];
                    }
                    else if (Galletas.getGalleta("ID_USER") == 242) {                 //PPIZARRO
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27, 38, 37];
                    }
                    else {
                        btnbool = [1, 2, 3, 4, 21, 5, 7, 9, 12, 17, 22, 23, 27];
                    }
                    break;
                case "6":                                                               //REAS
                    var btnbool;
                    btnbool = [32, 23];
                    break;
            //  CASE 7 SE ELIMINÓ
                case "8":                                                               //ESTAFETA
                    var btnbool;
                    btnbool = [38];
                    break;
                case "9":                                                               //MATRONA
                    var btnbool;
                    btnbool = [4, 5, 13, 23, 24, 38, 39];
                    break;
                case "10":                                                              //PROVEEDORES
                    btnbool = [41,42,43,45,46,47,48];
                    break;
                case "121":                                                              //MINDS
                    btnbool = [49, 50, 51, 52, 53, 54, 55, 56];
                    break;
            }



            //botones
            var btn_datas = {
                "datass":
                [{  //# 01
                    "href": "Agenda_Med/N_Ver_PROVEE_Disponibilidad_2.aspx",
                    "icon": "book",
                    "textn1": "Agenda",
                    "textn2": "Médica"
                },
                {   //# 02
                    "href": "Agenda_Med/Lis_Pac__PROVEE_TDM.aspx",
                    "icon": "list",
                    "textn1": "Listar",
                    "textn2": "Paciente"
                },
                {   //# 03
                    "href": "#",
                    "icon": "user",
                    "textn1": "Ingreso de",
                    "textn2": "Atención"
                },
                {   //# 04
                    "href": "Ate_Pac/Busca_PROVEE_Paciente.aspx",
                    "icon": "search",
                    "textn1": "Búsqueda de",
                    "textn2": "Pacientes"
                },
                {   //# 05
                    "href": "Buscar_Ate/Buscar_PROVEE_Atencion.aspx",
                    "icon": "search",
                    "textn1": "Búsqueda de",
                    "textn2": "Atenciones"
                },
                {   //# 06
                    "href": "Toma_Muestra/Adm_PROVE_TM.aspx",
                    "icon": "eyedropper",
                    "textn1": "Toma de",
                    "textn2": "Muestras"
                },
                {   //# 07
                    "href": "Recep_Mue/Recep_PROVEE_Mue.aspx",
                    "icon": "flask",
                    "textn1": "Recepción de",
                    "textn2": "Muestras"
                },
                {   //# 08
                    "href": "#",
                    "icon": "users",
                    "textn1": "Grupo de",
                    "textn2": "Trabajo"
                },
                {   //# 09
                    "href": "Imp_Etiquetas/Impr_PROVEE_Etiq.aspx",
                    "icon": "barcode",
                    "textn1": "Impresión de",
                    "textn2": "Etiquetas"
                },
                {   //# 10
                    "href": "#",
                    "icon": "area-chart",
                    "textn1": "Visor de",
                    "textn2": "Resultados"
                },
                {   //# 11
                    "href": "#",
                    "icon": "print",
                    "textn1": "Impresión de",
                    "textn2": "Resultados"
                },
                {   //# 12
                    "href": "/Imp_Etiquetas/Impr_PROVEE_Dcto.aspx",
                    "icon": "print",
                    "textn1": "Reimpresión",
                    "textn2": "Documentos"
                },
                {   //# 13
                    "href": "Repor_check.aspx",
                    "icon": "area-chart",
                    "textn1": "Reportes y",
                    "textn2": "Check List"
                },
                {   //# 14
                    "href": "Gest_Financ/Estadisticas/Resumen/Cupo_Tot_PROVEE_ate.aspx",
                    "icon": "area-chart",
                    "textn1": "Ver Cupos",
                    "textn2": "Agendados"
                },
                {   //# 15
                    "href": "Env_Mues_Lab/Env_Mues_PROVEE_Lab.aspx",
                    "icon": "random",
                    "textn1": "Envío de",
                    "textn2": "Muestras"
                },
                {   //# 16
                    "href": "Env_Mues_Lab/Lis_Env_Mues_PROVEE_Lab_2.aspx",
                    "icon": "flask",
                    "textn1": "Muestras Env.",
                    "textn2": "por Tubo"
                },
                {   //# 17
                    "href": "Reporte/Laboratorio/REP_LAB_PROVEE_EXA.aspx",
                    "icon": "table",
                    "textn1": "Buscar Ate.",
                    "textn2": "por Examen"
                },
                {   //# 18
                    "href": "Exa_Esp_PROVEE_V.aspx",
                    "icon": "edit",
                    "textn1": "Cambiar Estado",
                    "textn2": "Examen"
                },
                {   //# 19
                    "href": "Env_Mues_Lab/Lis_Env_Mues_PROVEE_Lab_3.aspx",
                    "icon": "flask",
                    "textn1": "Muestras Env.",
                    "textn2": "por Lote"
                },
                {   //# 20
                    "href": "Recha_Mues/Lis_Recha_PROVEE_Mues.aspx",
                    "icon": "flask",
                    "textn1": "Listado de",
                    "textn2": "Exa. Rechazados"
                },
                {   //# 21
                    "href": "Ate_Pac/Busca_Paciente_PROVEE_Agendado.aspx",
                    "icon": "search",
                    "textn1": "Bús Pac.",
                    "textn2": "Agendado"
                },
                {  //# 22
                    "href": "Ate_Pac/AVIS_C_PROVEE_D.aspx",
                    "icon": "book",
                    "textn1": "Número",
                    "textn2": "Avis"
                },
                {  //# 23
                    "href": "Configuraciones/Mantenedores/Documentos_PROVEE_Ver2.aspx",
                    "icon": "list",
                    "textn1": "Ver",
                    "textn2": "Documentos"
                },
                {  //# 24
                    "href": "Check_List/Rev_Deter_Exa__PROVEE_Scre_Sif.aspx",
                    "icon": "flask",
                    "textn1": "Resul. Deter",
                    "textn2": "Screening Sífilis"
                },
                {   //# 25
                    "href": "Recha_Mues/Lis_Recha_PROVEE_Mues_2.aspx",
                    "icon": "window-close",
                    "textn1": "Listado de",
                    "textn2": "Tubos Rechazados"
                },
                {   //# 26
                    "href": "Check_List/Check_Point/Chk_Tubo_PROVEE_Proce_2.aspx",
                    "icon": "flask",
                    "textn1": "Estados",
                    "textn2": "de Tubos"
                },
                {   //# 27
                    "href": "Gest_Financ/Estadisticas/Resumen/Cupo_Tot_PROVEE_ate_2.aspx",
                    "icon": "area-chart",
                    "textn1": "Ver Cupos",
                    "textn2": "Agendados"
                },
                {   //# 28
                    "href": "Agenda_Med/Lis_Pac_PROVEE_TDM_2.aspx",
                    "icon": "list",
                    "textn1": "Listar Paciente",
                    "textn2": "Iris PC"
                },
                {  //# 29
                    "href": "/Excel_TP_Real_PROVEE_ADM_2.aspx",
                    "icon": "list",
                    "textn1": "Trazabilidad PAP",
                    "textn2": "Administrador"
                },
                {  //# 30
                    "href": "/Excel_TP_PROVEE_Real_2.aspx",
                    "icon": "list",
                    "textn1": "Trazabilidad",
                    "textn2": "PAP"
                },
                {  //# 31
                    "href": "/Reg_Residuos_PROVEE_ADM.aspx",
                    "icon": "trash",
                    "textn1": "Registro",
                    "textn2": "REAS Admin"
                },
                {  //# 32
                    "href": "/Reg_PROVEE_Residuos.aspx",
                    "icon": "trash",
                    "textn1": "Registro",
                    "textn2": "REAS"
                },
                {  //# 33
                    "href": "/Lis_Env_PROVEE_Avis.aspx",
                    "icon": "list",
                    "textn1": "Listado",
                    "textn2": "Envíos Avis"
                },
                {  //# 34
                    "href": "/Lis_Tot_PROVEE_Exams.aspx",
                    "icon": "list",
                    "textn1": "Listado",
                    "textn2": "Exá./Resultados"
                },
                {  //# 35
                    "href": "Reporte/Hoja_de_trabajo/HT_PROVEE_Exa.aspx",
                    "icon": "list",
                    "textn1": "Hoja Trabajo",
                    "textn2": "Por Examen"
                },
                {  //# 36
                    "href": "Reporte/Hoja_de_trabajo/Ate_LTM_PROVEE_Detalle.aspx",
                    "icon": "list",
                    "textn1": "Hoja Trabajo",
                    "textn2": "Por Proce. Det"
                },
                {  //# 37
                    "href": "Reg_Pap/Excel_TP_Real_PROVEE_ADM_AVIS.aspx",
                    "icon": "list",
                    "textn1": "Detalle",
                    "textn2": "Muestras PAP"
                },
                {  //# 38
                    "href": "Reg_pap/Traza_PROVEE_Pap.aspx",
                    "icon": "list",
                    "textn1": "Traza",
                    "textn2": "Contenedor PAP"
                },
                {  //# 39
                    "href": "Reg_pap/Excel_TP_Real_ADM_PROVEE_AVIS_VER.aspx",
                    "icon": "list",
                    "textn1": "Listado",
                    "textn2": "Muestras PAP"
                },
                {  //# 40
                    "href": "Agenda_Med/AGRE_EXA_PROVEE_ATE.aspx",
                    "icon": "plus-square",
                    "textn1": "Agregar Exam.",
                    "textn2": "a Atención"
                },
                {   //# 41
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_EXA_PROVEE_TOT_2.aspx",
                    "icon": "table",
                    "textn1": "Cantidad",
                    "textn2": "de Exámenes"
                },
                {   //# 42
                    "href": "Gest_Financ/Lista_Graficos/Grafico_PROVEE_Examenes.aspx",
                    "icon": "table",
                    "textn1": "Cant. Mensual",
                    "textn2": "de Atenciones"
                },
                {   //# 43
                    "href": "Gest_Financ/Analisis_Atenciones/Ana_PROVEE_Prev.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exámenes",
                    "textn2": "Anual"
                },
                {   //# 44
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_EXA_CART_MEN.aspx",
                    "icon": "table",
                    "textn1": "Análisis",
                    "textn2": "Cart. Mensual"
                },
                {   //# 45
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_PROVEE_EXA_TOT.aspx",
                    "icon": "table",
                    "textn1": "Cantidad",
                    "textn2": "Exa. Totales"
                },
                {   //# 46
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_PROVEE_EXA_AREA.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exa.",
                    "textn2": "Area de Trabajo"
                },
                {   //# 47
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_PROVEE_EXA_SECC.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exa",
                    "textn2": "Por Sección"
                },
                {   //# 48
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_EXA_ARE_SECC.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exa",
                    "textn2": "Area y Secc."
                },
                {   //# 49                      -------------- //MINDS -----------------------------------------------------------
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_EXA_MINDS_TOT_2.aspx",
                    "icon": "table",
                    "textn1": "Cantidad",
                    "textn2": "de Exámenes"
                },
                {   //# 50
                    "href": "Gest_Financ/Lista_Graficos/Grafico_MINDS_Examenes.aspx",
                    "icon": "table",
                    "textn1": "Cant. Mensual",
                    "textn2": "de Atenciones"
                },
                {   //# 51
                    "href": "Gest_Financ/Analisis_Atenciones/Ana_MINDS_Prev.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exámenes",
                    "textn2": "Anual"
                },
                {   //# 52
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_MINDS_EXA_TOT.aspx",
                    "icon": "table",
                    "textn1": "Cantidad",
                    "textn2": "Exa. Totales"
                },
                {   //# 53
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_MINDS_EXA_AREA.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exa.",
                    "textn2": "Area de Trabajo"
                },
                {   //# 54
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_MINDS_EXA_SECC.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exa",
                    "textn2": "Por Sección"
                },
                {   //# 55
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_EXA_MINDS_ARE_SECC.aspx",
                    "icon": "table",
                    "textn1": "Cant. Exa",
                    "textn2": "Area y Secc."
                },
                {   //# 56
                    "href": "Gest_Financ/Lista_Graficos/Grafico_MINDS_Examenes_Monts.aspx",
                    "icon": "table",
                    "textn1": "Cant. Mensual",
                    "textn2": "Ate./Montos"
                }
                ]
            };

            var btn_count = btnbool.length;
            var max_cant = Math.round(btn_count / 2);
            var nrow1 = 1;
            var nrow2 = 1;
            var contador = 1;
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

            btnbool.forEach(function (aaa, xIndex) {

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
                else {
                    idxx = "";
                }
                if (btn_count > 6 && nrow1 <= max_cant) {
                    rows = "#amed";
                    nrow1 += 1;
                    contador++;
                    if (nrow1 == max_cant + 1) {
                        nrow1 += 1;
                        contador = 1;
                    }
                }
                else if (btn_count > 6 && nrow2 <= max_cant) {
                    rows = "#amed2";
                    nrow2 += 1;
                    contador++;
                }
                else {
                    rows = "#amed";
                    nrow1 += 1;
                    contador++;
                }
                $("<div>", { "class": "col-lg" }).append("<a href='" + hreff + "' " + idxx + " class='btn btn-sq btn-" + colors + " btnx'><i class='fa fa-" + icon + " fa-3x'></i><b><br />" + text1 + "<br>" + text2 + "</b></a>").appendTo(rows);

            });
            ////////////////////BTN PRUEBA
            $("#btnderivar").click(function () {



                $('#Manual').attr("onclick", "window.location.href='/Agenda_Med/Ingreso_PROVEE_Ate.aspx'");
                $('#AVIS').attr("onclick", "window.location.href='/Agenda_Med/Ingreso_Ate_PROVEE_Avis.aspx'");

                var admin2 = Galletas.getGalleta("P_ADMIN");
                if (admin2 == 1) {
                    $("#Manual").removeAttr('disabled');
                } else {

                    $('#Manual').attr("disabled", true);
                }


                $('#eModal').modal('show');
            });

            //$("#btnreimp").click(function () {
            //    $('#ATENCION').attr("onclick", "window.location.href='/agenda_med/Imp_Ate_P.aspx'");
            //    $('#ATENCION_DIREC').attr("onclick", "window.location.href='/agenda_med/Imp_Ate_Directo.aspx'");
            //    $('#eModal_321').modal('show');
            //});
        });

        //´buscar lista de procendecia maz agenda disponible
        Mx_Test = [{
            AYER: 0,
            AYER_SEMANA_PASADA: 0,
            MES_DIA:0,
            MES_DIA_PASADO: 0,
            MES_PASADO: 0,
            MES_ANTE_PASADO:0
        }];

        function AJAX_TEEEEEEEST() {
            //modal_show();
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Info_Extra",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Test = (data.d);

                    Hide_Modal();
                    if (Mx_Test != null) {

                        let por_1 = 0;
                        if (Mx_Test[0].AYER_SEMANA_PASADA != 0) {
                            por_1 = (((Mx_Test[0].AYER - Mx_Test[0].AYER_SEMANA_PASADA) / Mx_Test[0].AYER_SEMANA_PASADA) * 100);
                        } else {
                            por_1 = 100;
                        }
                        
                        let por_2 = 0;
                        
                        if (Mx_Test[0].MES_DIA_PASADO != 0) {
                            por_2 = (((Mx_Test[0].MES_DIA - Mx_Test[0].MES_DIA_PASADO) / Mx_Test[0].MES_DIA_PASADO) * 100);
                        } else {
                            por_2 = 100;
                        }

                        let por_3 = 0;

                        if(Mx_Test[0].MES_ANTE_PASADO != 0){
                            por_3 = (((Mx_Test[0].MES_PASADO - Mx_Test[0].MES_ANTE_PASADO) / Mx_Test[0].MES_ANTE_PASADO) * 100);
                        }else{
                            por_3 = 100;
                        }

                        $("#txt_Money_2_before").css({ "color": "#140054" });
                        $("#txt_Money_2_before").text("$" + addCommas(Mx_Test[0].AYER));

                        $("#txt_Money_3_before").css({ "color": "#140054" });
                        $("#txt_Money_3_before").text("$" + addCommas(Mx_Test[0].MES_DIA));

                        $("#txt_Money_4_before").css({ "color": "#140054" });
                        $("#txt_Money_4_before").text("$" + addCommas(Mx_Test[0].MES_PASADO));

                        

                        if (Mx_Test[0].AYER == Mx_Test[0].AYER_SEMANA_PASADA) {
                            $("#txt_Money_2").css({ "color": "#140054" });
                            $("#i_2").css({ "color": "#140054" });
                            $("#txt_Money_2").text("/$" + 0 + " (" + 0 + "%" + ")");
                        } else if (Mx_Test[0].AYER > Mx_Test[0].AYER_SEMANA_PASADA) {
                            $("#txt_Money_2").css({ "color": "#28a745" });
                            $("#i_2").addClass("fa fa-arrow-up");
                            $("#i_2").css({ "color": "#28a745" });
                            $("#txt_Money_2").text("/$" + addCommas(Mx_Test[0].AYER - Mx_Test[0].AYER_SEMANA_PASADA) + " (" + por_1.toFixed(2) + "%" + ")");
                        } else if (Mx_Test[0].AYER < Mx_Test[0].AYER_SEMANA_PASADA) {
                            $("#txt_Money_2").css({ "color": "#ff0000" });
                            $("#i_2").addClass("fa fa-arrow-down");
                            $("#i_2").css({ "color": "#ff0000" });
                            $("#txt_Money_2").text("/$" + addCommas(Mx_Test[0].AYER - Mx_Test[0].AYER_SEMANA_PASADA) + "  (" + por_1.toFixed(2) + "%" + ")");
                        }
                        

                        if (Mx_Test[0].MES_DIA == Mx_Test[0].MES_DIA_PASADO) {
                            $("#txt_Money_3").css({ "color": "#d2d900" });
                        } else if (Mx_Test[0].MES_DIA > Mx_Test[0].MES_DIA_PASADO) {
                            $("#txt_Money_3").css({ "color": "#28a745" });
                            $("#ii_3").addClass("fa fa-arrow-up");
                            $("#ii_3").css({ "color": "#28a745" });
                        } else if (Mx_Test[0].MES_DIA < Mx_Test[0].MES_DIA_PASADO){
                            $("#txt_Money_3").css({ "color": "#ff0000" });
                            $("#ii_3").addClass("fa fa-arrow-down");
                            $("#ii_3").css({ "color": "#ff0000" });
                        }
                        $("#txt_Money_3").text("/$" +  addCommas(Mx_Test[0].MES_DIA - Mx_Test[0].MES_DIA_PASADO) + "  (" + por_2.toFixed(2) + "%" + ")");

                        if (Mx_Test[0].MES_PASADO == Mx_Test[0].MES_ANTE_PASADO) {
                            $("#txt_Money_4").css({ "color": "#d2d900" });
                        } else if (Mx_Test[0].MES_PASADO > Mx_Test[0].MES_ANTE_PASADO) {
                            $("#txt_Money_4").css({ "color": "#28a745" });
                            $("#iii_4").addClass("fa fa-arrow-up");
                            $("#iii_4").css({ "color": "#28a745" });
                        } else if (Mx_Test[0].MES_PASADO < Mx_Test[0].MES_ANTE_PASADO) {
                            $("#txt_Money_4").css({ "color": "#ff0000" });
                            $("#iii_4").addClass("fa fa-arrow-down");
                            $("#iii_4").css({ "color": "#ff0000" });
                        }                    
                        $("#txt_Money_4").text("/$" + addCommas(Mx_Test[0].MES_PASADO - Mx_Test[0].MES_ANTE_PASADO) + "  (" + por_3.toFixed(2) + "%" + ")");


                        //$("#lbl_ayer").text(moment().add("days",-1).format("dddd, DD-MM-YYYY"));
                        //$("#lbl_antesayer").text(moment().add("days", -2).format("dddd, DD-MM-YYYY"));

                        $("#lbl_ayer").text("Ayer " + "(" + moment().add("days",-1).format("dddd") + ")" + " vs.  mismo día  de la semana pasada");
                        $("#lbl_antesayer").text("Este mes vs.  mismo día del mes pasado");
                        $("#lbl_mes_pasado").text("El mes pasado vs. mes anterior");
                    }

                },
                "error": data => {
                    //Debug



                }
            });
        }


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
            modal_show();
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Bus_Cant",
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
                "url": "Index_MINDS.aspx/Bus_Exa",
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
                "url": "Index_MINDS.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Ddl = JSON.parse(data.d);

                    var vv = Galletas.getGalleta("P_ADMIN");
                    var vv2 = Galletas.getGalleta("USU_ID_PROC");
                    if (vv == 1) {
                        $("#spn_tm").text("");

                    } else {

                        Mx_Ddl.forEach(aaa => {
                            if (aaa.ID_PROCEDENCIA == vv2) {
                                $("#spn_tm").text(aaa.PROC_DESC);
                                $("#spn_tm2").text(aaa.PROC_DESC);
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

        //JSON para el DataTable
        var Mx_Dtt_Table = [
            {
                "E_Fecha": "",
                "E_Cantidad": "",
                "E_Dias": "",
                "CANT_EXA": "",
                "TOTA_SIS":""
            }
        ];
        function AJAX_DataTable() {
           
            var Data_Par = JSON.stringify({
                "Mes": 4,       //String($("#DllMes").val()),
                "Año": "2020",  //$("#DllAño option:selected").text(),
                "ID_CF": 0     //$("#Ddl_Exam").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Table = JSON.parse(json_receiver);
                        for (i = 0; i < Mx_Dtt_Table.length; ++i) {
                            var date_x = Mx_Dtt_Table[i].E_Fecha;
                            date_x = String(date_x).replace("/Date(", "");
                            date_x = date_x.replace(")/", "");
                            var Date_Change = new Date(parseInt(date_x));
                            Mx_Dtt_Table[i].E_Fecha = Date_Change;
                        }
                        Mx_Dtt_Table.reverse();
                        Fill_DataTable();
                        Ajax_DataTable_Graph_2();
                        Ajax_DataTable_Graph_3();
                        Ajax_DataTable_Graph_4();
                        AJAX_JSON_Graph_5();
                        Ajax_DataTable_Graph_2_Money();
                        Ajax_DataTable_Graph_2_Money_Area();
                        Ajax_DataTable_Graph_2_Money_Doctor();
                        AJAX_TEEEEEEEST();

                    } else {

                        $("#Div_Tabla").empty().css({ "background": "#c30000" });
                        $("#Div_Tabla").append(
                            $("<div>").css({
                                "width": "calc(100% - 60)",
                                "text-align": "center",
                                "padding": "30px",
                                "font-size": "30px",
                                "font-weight": 900,
                                "color": "#ffffff"
                            }).text("Sin Resultados.")
                        );
                    }
                    Hide_Modal();
                },
                "error": function (response) {
                    Hide_Modal();
                    //$("#mdlNotif .modal-header h4").text(String(response.responseJSON.ExceptionType).trim());
                    //$("#mdlNotif .modal-body p").html(response.responseJSON.Message);
                    //$("#mdlNotif").modal();

                }
            });
        }

        let Mx_Dtt_Graph_2 = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TOTAL_EXA:""
        }];
        function Ajax_DataTable_Graph_2() {
            //let Data_Par = JSON.stringify({
            //    "DESDE": _desde,
            //    "HASTA": _hasta,
            //    "PROC": _proc,
            //    "PREV": _prev,
            //    "PROG": _prog,
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Graph_2",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Graph_2 = json_receiver;

                        grafico_2();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }
        let Mx_Dtt_Graph_Dinero_Preve = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TOTAL_EXA: "",
            TOTAL_ATE:""
        }];
        function Ajax_DataTable_Graph_2_Money() {
            //let Data_Par = JSON.stringify({
            //    "DESDE": _desde,
            //    "HASTA": _hasta,
            //    "PROC": _proc,
            //    "PREV": _prev,
            //    "PROG": _prog,
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Dinero",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Graph_Dinero_Preve = json_receiver;

                        grafico_Dinero_Preve();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

        let Mx_Dtt_Graph_Dinero_Preve_Area = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TOTAL_EXA: "",
            TOTAL_ATE: "",
            AREA_DESC:""
        }];
        function Ajax_DataTable_Graph_2_Money_Area() {
            //let Data_Par = JSON.stringify({
            //    "DESDE": _desde,
            //    "HASTA": _hasta,
            //    "PROC": _proc,
            //    "PREV": _prev,
            //    "PROG": _prog,
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Area_Dinero",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Graph_Dinero_Preve_Area = json_receiver;

                        grafico_Dinero_Preve_Area();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

        let Mx_Dtt_Graph_Dinero_Doctor = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TOTAL_EXA: "",
            TOTAL_ATE: "",
            AREA_DESC: "",
            DOC_NOMBRE: "",
            DOC_APELLIDO:""
        }];
        function Ajax_DataTable_Graph_2_Money_Doctor() {
            //let Data_Par = JSON.stringify({
            //    "DESDE": _desde,
            //    "HASTA": _hasta,
            //    "PROC": _proc,
            //    "PREV": _prev,
            //    "PROG": _prog,
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Medico",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Graph_Dinero_Doctor = json_receiver;

                        grafico_Dinero_Doctor();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

        let Mx_Dtt_Graph_3 = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TOTAL_EXA:"",
            USU_NIC:""
        }];
        function Ajax_DataTable_Graph_3() {
            //let Data_Par = JSON.stringify({
            //    "DESDE": _desde,
            //    "HASTA": _hasta,
            //    "PROC": _proc,
            //    "PREV": _prev,
            //    "PROG": _prog,
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Graph_3",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Graph_3 = json_receiver;

                        grafico_3();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }
        let Mx_Dtt_Graph_4 = [{
            ATE_NUM: "",
            ATE_FECHA: "",
            PAC_RUT: "",
            PAC_NOMBRE: "",
            PAC_APELLIDO: "",
            PROC_DESC: "",
            PREVE_DESC: "",
            PROGRA_DESC: "",
            CF_DESC: "",
            ATE_DET_V_PREVI: "",
            CF_COD: "",
            TOTAL_EXA:"",
            USU_NIC: "",
            SEXO_DESC: "",
            TOTAL_ATE:""
        }];
        function Ajax_DataTable_Graph_4() {
            //let Data_Par = JSON.stringify({
            //    "DESDE": _desde,
            //    "HASTA": _hasta,
            //    "PROC": _proc,
            //    "PREV": _prev,
            //    "PROG": _prog,
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Llenar_DataTable_Graph_4",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Graph_4 = json_receiver;

                        grafico_4();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

        var Mx_Data_Graph_5 = [{
            "FECHA": "",
            "NUMERO": ""
        }];
        function AJAX_JSON_Graph_5() {
            //modal_show();

            //var mom_fecha = moment().format("DD-MM-YYYY");
            //var Data_Par = JSON.stringify({
            //    "str_Date": mom_fecha
            //});
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Data_Graph_5",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Data_Graph_5 = json_receiver;

                        grafico_5();
                        Hide_Modal();


                    } else {

                        Hide_Modal();
                    }

                },
                "error": function (response) {
                    Hide_Modal();
                }
            });

        }
        var Mx_Dat_row_1 = [{
            "FECHA": "",
            "AYER": "",
            "AYER_SEMANA_PASADA":""
        }];
        function row_1() {
            //modal_show();

            //var mom_fecha = moment().format("DD-MM-YYYY");
            //var Data_Par = JSON.stringify({
            //    "str_Date": mom_fecha
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/row_1",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dat_row_1 = json_receiver;

                        grafico_row_1();
                        Hide_Modal();


                    } else {

                        Hide_Modal();
                    }

                },
                "error": function (response) {
                    Hide_Modal();
                }
            });

        }
        var Mx_Dat_row_2 = [{
            "E_Fecha": "",
            "ESTE_MES": "",
            "ESTE_DIA_MES_PASADO": ""
        }];
        function row_2() {
            //modal_show();

            //var mom_fecha = moment().format("DD-MM-YYYY");
            //var Data_Par = JSON.stringify({
            //    "str_Date": mom_fecha
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Row_2",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dat_row_2 = json_receiver;
                        Mx_Dat_row_2.reverse()
                        grafico_row_2();
                        Hide_Modal();


                    } else {

                        Hide_Modal();
                    }

                },
                "error": function (response) {
                    Hide_Modal();
                }
            });

        }

        var Mx_Dat_row_3 = [{
            "E_Fecha": "",
            "ESTE_MES": "",
            "ESTE_DIA_MES_PASADO": "",
            "Fecha_2": "",
            "Dias_2": ""
        }];
        function row_3() {
            //modal_show();

            //var mom_fecha = moment().format("DD-MM-YYYY");
            //var Data_Par = JSON.stringify({
            //    "str_Date": mom_fecha
            //});
            $.ajax({
                "type": "POST",
                "url": "Index_MINDS.aspx/Row_3",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dat_row_3 = json_receiver;
                        //Mx_Dat_row_3.reverse()
                        grafico_row_3();
                        Hide_Modal();


                    } else {

                        Hide_Modal();
                    }

                },
                "error": function (response) {
                    Hide_Modal();
                }
            });

        }


        //Llenar DataTable
        function Fill_DataTable() {
            $("#Div_Tabla").empty().css({ "background": "#ffffff" });
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
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>").css("text-align", "center").text("#"),
                    $("<th>").css("text-align", "center").text("Fecha"),
                    $("<th>").css("text-align", "center").text("Día"),
                    $("<th>").css("text-align", "center").text("Cantidad Atenciones"),
                    $("<th>").css("text-align", "center").text("Cantidad Exámenes"),
                    $("<th>").css("text-align", "center").text("Ventas")

                )
            );
            for (i = 0; i < Mx_Dtt_Table.length; ++i) {
                $("#DataTable tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(i + 1),
                        $("<td>", { "align": "center" }).text(function () {
                            //Obtener valores
                            var obj_date = new Date(Mx_Dtt_Table[i].E_Fecha);
                            var dd = parseInt(obj_date.getDate());
                            var MM = parseInt(obj_date.getMonth()) + 1;
                            var yy = parseInt(obj_date.getFullYear());
                            if (dd < 10) { dd = "0" + dd; }
                            if (MM < 10) { MM = "0" + MM; }

                            return String(dd + "/" + MM + "/" + yy);
                        }),
                        $("<td>", { "align": "center" }).text(Mx_Dtt_Table[i].E_Dias),
                        $("<td>", { "align": "center" }).text(addCommas(Mx_Dtt_Table[i].E_Cantidad)),
                        $("<td>", { "align": "center" }).text(addCommas(Mx_Dtt_Table[i].CANT_EXA)),
                        $("<td>", { "align": "center" }).text("$" + addCommas(Mx_Dtt_Table[i].TOTA_SIS))

                        )
                );
            }
            //LLENADO TABLA TOTALES
            $("#Div_Tabla_Total").empty().css({ "background": "#ffffff" });
            $("<table>", {
                "id": "DataTableTotal",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Total");
            $("#DataTableTotal").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTableTotal thead").append(
                $("<tr>").append(
                    $("<th>").css("text-align", "center").text("Cantidad Mensual Ate"),
                    $("<th>").css("text-align", "center").text("Promedio Diario Ate")
                )
            );
            var T_Ate = 0;
            var T_Exa = 0;
            var T_Sis = 0;

            for (i = 0; i < Mx_Dtt_Table.length; i++) {
                T_Ate = parseFloat(T_Ate) + parseFloat(Mx_Dtt_Table[i].E_Cantidad);
                T_Exa = parseFloat(T_Exa) + 1
            }
            T_Sis = Math.round(T_Ate / T_Exa)
            $("#DataTableTotal tbody").append(
                    $("<tr>").append(
                        $("<td>", { "align": "center" }).text(addCommas(T_Ate)),
                        $("<td>", { "align": "center" }).text(addCommas(T_Sis))
                    )
                );
            grafico();
        };

        function grafico() {
            //var grafico = $("#DllGrafico").val();

            //if (grafico == 0) {
            var arr = ["Array"];
            var arr1 = [0];
            var arr2 = [0];
            var fecha = ""
            for (i = 0; i < Mx_Dtt_Table.length; i++) {
                if (i == 0) {
                    arr.pop();
                    arr1.pop();
                    arr2.pop();
                }
                fecha = (function () {
                    //Obtener valores
                    var obj_date = new Date(Mx_Dtt_Table[i].E_Fecha);
                    var dd = parseInt(obj_date.getDate());
                    var MM = parseInt(obj_date.getMonth()) + 1;
                    var yy = parseInt(obj_date.getFullYear());
                    if (dd < 10) { dd = "0" + dd; }
                    if (MM < 10) { MM = "0" + MM; }

                    return String(dd + "/" + MM + "/" + yy);
                })();
                arr.push(fecha);
                arr1.push(parseFloat(Mx_Dtt_Table[i].E_Cantidad));
                arr2.push(parseFloat(Mx_Dtt_Table[i].CANT_EXA));
            }

            Highcharts.chart('Summary_Graph', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: arr
                },
                yAxis: {
                    title: {
                        text: 'Atenciones/Exámenes'
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: true
                    }
                },
                series: [{
                    name: 'Cantidad de Atenciones',
                    data: arr1
                }, {
                    name: 'Cantidad de Exámenes',
                    data: arr2
                }]
            });
            //};
            $("#div_hide").show();

        }

        function grafico_Dinero_Preve() {

            let Mx_Series = [];


            Mx_Series.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            let tot_money = 0;
            let tot_atem = 0;
            let tot_exam = 0;

            //for (x = 0; x < Mx_Dtt_Graph_Dinero_Preve.length; x++) {
                Mx_Series[0].data.push({
                    name: Mx_Dtt_Graph_Dinero_Preve[0].PREVE_DESC,
                    y: Mx_Dtt_Graph_Dinero_Preve[0].TOTA_SIS
                });

                //tot_money += Mx_Dtt_Graph_Dinero_Preve[x].TOTA_SIS;
                //tot_atem += Mx_Dtt_Graph_Dinero_Preve[x].TOTAL_ATE;
                //tot_exam += Mx_Dtt_Graph_Dinero_Preve[x].TOTAL_EXA;
            //}

            tot_money = Mx_Dtt_Graph_Dinero_Preve[0].TOTA_SIS;
            tot_atem = Mx_Dtt_Graph_Dinero_Preve[0].TOTAL_ATE;
            tot_exam = Mx_Dtt_Graph_Dinero_Preve[0].TOTAL_EXA;

            $("#txt_Money").text("$" + addCommas(tot_money));
            $("#txt_Atem").text(tot_atem);
            $("#txt_Exam").text(tot_exam);

            ////$("#lbl_ayer").text(moment().add("days",-1).format("dddd, DD-MM-YYYY"));
            ////$("#lbl_antesayer").text(moment().add("days", -2).format("dddd, DD-MM-YYYY"));

            //$("#lbl_ayer").text("Ayer vs.  mismo día  de la semana pasada");
            //$("#lbl_antesayer").text("Este mes vs.  mismo día delmes pasado");
            //$("#lbl_mes_pasado").text("El mes pasado vs. mes anterior");

            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt_Graph_Dinero_Preve.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].MES);
            //    arr1.push(parseFloat(Mx_Dtt_Graph_Dinero_Preve[i].PROC_DESC));
            //    arr2.push(parseFloat(Mx_Dtt_Graph_Dinero_Preve[i].CANT_EXA));
            //}

            Highcharts.chart('chrt_Dinero_Preve', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '45%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Totales por Previsión'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series
            });
        }

        function grafico_Dinero_Preve_Area() {

            let Mx_Series = [];


            Mx_Series.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            for (x = 0; x < Mx_Dtt_Graph_Dinero_Preve_Area.length; x++) {
                Mx_Series[0].data.push({
                    name: Mx_Dtt_Graph_Dinero_Preve_Area[x].AREA_DESC,
                    y: Mx_Dtt_Graph_Dinero_Preve_Area[x].TOTAL_ATE
                });

            }


            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt_Graph_Dinero_Preve_Area.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].MES);
            //    arr1.push(parseFloat(Mx_Dtt_Graph_Dinero_Preve_Area[i].PROC_DESC));
            //    arr2.push(parseFloat(Mx_Dtt_Graph_Dinero_Preve_Area[i].CANT_EXA));
            //}

            Highcharts.chart('chrt_6', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '45%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Cantidades de Exámenes por Area de Trabajo'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series
            });
        }

        function grafico_Dinero_Doctor() {

            let Mx_Series = [];


            Mx_Series.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            for (x = 0; x < Mx_Dtt_Graph_Dinero_Doctor.length; x++) {
                Mx_Series[0].data.push({
                    name: Mx_Dtt_Graph_Dinero_Doctor[x].DOC_NOMBRE + " " + Mx_Dtt_Graph_Dinero_Doctor[x].DOC_APELLIDO,
                    y: Mx_Dtt_Graph_Dinero_Doctor[x].TOTAL_ATE
                });

            }


            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt_Graph_Dinero_Doctor.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].MES);
            //    arr1.push(parseFloat(Mx_Dtt_Graph_Dinero_Doctor[i].PROC_DESC));
            //    arr2.push(parseFloat(Mx_Dtt_Graph_Dinero_Doctor[i].CANT_EXA));
            //}


            Highcharts.theme = {
                colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572',
                         '#FF9655', '#FFF263', '#6AF9C4'],
                chart: {},
            };
            // Apply the theme
            Highcharts.setOptions(Highcharts.theme);

            Highcharts.chart('chrt_7', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '45%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Cantidades de Exámenes por Médico'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series
            });
        }

        function grafico_2() {

            let Mx_Series = [];


            Mx_Series.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            for (x = 0; x < Mx_Dtt_Graph_2.length; x++) {
                Mx_Series[0].data.push({
                    name: Mx_Dtt_Graph_2[x].PROC_DESC,
                    y: Mx_Dtt_Graph_2[x].TOTAL_EXA
                });
            }



            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt_Graph_2.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].MES);
            //    arr1.push(parseFloat(Mx_Dtt_Graph_2[i].PROC_DESC));
            //    arr2.push(parseFloat(Mx_Dtt_Graph_2[i].CANT_EXA));
            //}

            Highcharts.chart('chrt_2', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '40%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Cantidad de Exámenes por Procedencia'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series
            });
        }
        function grafico_3() {

            let Mx_Series_3 = [];


            Mx_Series_3.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            for (x = 0; x < Mx_Dtt_Graph_3.length; x++) {
                Mx_Series_3[0].data.push({
                    name: Mx_Dtt_Graph_3[x].USU_NIC,
                    y: Mx_Dtt_Graph_3[x].TOTAL_EXA
                });
            }



            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt_Graph_2.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].MES);
            //    arr1.push(parseFloat(Mx_Dtt_Graph_2[i].PROC_DESC));
            //    arr2.push(parseFloat(Mx_Dtt_Graph_2[i].CANT_EXA));
            //}

            Highcharts.chart('chrt_3', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '40%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Cantidad de Exámenes por Usuario'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series_3
            });
        }
        function grafico_4() {

            let Mx_Series_4 = [];


            Mx_Series_4.push({
                name: 'Cantidad',
                colorByPoint: true,
                data: []
            });

            for (x = 0; x < Mx_Dtt_Graph_4.length; x++) {
                Mx_Series_4[0].data.push({
                    name: Mx_Dtt_Graph_4[x].SEXO_DESC,
                    y: Mx_Dtt_Graph_4[x].TOTAL_ATE
                });
            }



            //var arr = ["Array"];
            //var arr1 = [0];
            //var arr2 = [0];
            //for (i = 0; i < Mx_Dtt_Graph_2.length; i++) {
            //    if (i == 0) {
            //        arr.pop();
            //        arr1.pop();
            //        arr2.pop();
            //    }
            //    arr.push(Mx_Dtt[i].MES);
            //    arr1.push(parseFloat(Mx_Dtt_Graph_2[i].PROC_DESC));
            //    arr2.push(parseFloat(Mx_Dtt_Graph_2[i].CANT_EXA));
            //}

            Highcharts.chart('chrt_4', {


                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: '40%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Cantidad de Atenciones por Sexo'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}'
                        }
                    }
                },
                series: Mx_Series_4
            });
        }

        function grafico_5() {
            var grafico = 0;
            if (grafico == 0) {
                var arrPar = [];
                var arrVal = [];
                for (i = 0; i < Mx_Data_Graph_5.length; i++) {
                    arrVal.push(parseFloat(Mx_Data_Graph_5[i].NUMERO));
                    arrPar.push(function () {
                        //Obtener valores
                        var nDate = String(Mx_Data_Graph_5[i].FECHA);
                        nDate = nDate.toUpperCase().replace("/DATE(", "");
                        nDate = nDate.replace(")/", "");
                        var obj_date = new Date(parseInt(nDate));
                        var hh = parseInt(obj_date.getHours());
                        var mm = parseInt(obj_date.getMinutes());
                        if (hh < 10) { hh = "0" + hh; }
                        if (mm < 10) { mm = "0" + mm; }
                        return String(hh + ":" + mm);
                    }());
                }


                var fecha_now = moment().format("dddd, DD-MM-YYYY");

                Highcharts.chart('chrt_5', {
                    chart: {
                        type: 'line'
                    },
                    title: {
                        text: 'Atenciones Diarias por Hora'
                    },
                    subtitle: {
                        text: 'Datos del día ' + fecha_now
                    },
                    xAxis: {
                        categories: arrPar
                    },
                    yAxis: {
                        title: {
                            text: 'Atenciones'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: true
                        }
                    },
                    series: [{
                        name: 'Total Atenciones',
                        data: arrVal
                    }]
                });
            }
        }

        function grafico_row_1() {
            var grafico = 0;
            if (grafico == 0) {
                var arrPar = [];
                var arrVal = [];
                var arrVal_2 = [];
                for (i = 0; i < Mx_Dat_row_1.length; i++) {
                    arrVal.push(parseFloat(Mx_Dat_row_1[i].AYER));
                    arrVal_2.push(parseFloat(Mx_Dat_row_1[i].AYER_SEMANA_PASADA));
                    arrPar.push(function () {
                        //Obtener valores
                        var nDate = String(Mx_Dat_row_1[i].FECHA);
                        nDate = nDate.toUpperCase().replace("/DATE(", "");
                        nDate = nDate.replace(")/", "");
                        var obj_date = new Date(parseInt(nDate));
                        var hh = parseInt(obj_date.getHours());
                        var mm = parseInt(obj_date.getMinutes());
                        if (hh < 10) { hh = "0" + hh; }
                        if (mm < 10) { mm = "0" + mm; }
                        return String(hh + ":" + mm);
                    }());
                }


                var fecha_now = moment().format("dddd, DD-MM-YYYY");

                Highcharts.chart('div_row_1', {
                    chart: {
                        type: 'line'
                    },
                    title: {
                        text: 'Ventas Diarias por Hora'
                    },
                    subtitle: {
                        text: ''//'Datos del día ' + fecha_now
                    },
                    xAxis: {
                        categories: arrPar
                    },
                    yAxis: {
                        title: {
                            text: 'Ventas'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: true
                        }
                    },
                    series: [{
                        name: 'Total Ayer',
                        data: arrVal,
                    }, {
                        name: 'Total Ayer Semana Pasada',
                        data: arrVal_2,
                    }
                    ]
                });
            }
            $("#eModal_row_1").modal();
        }

        function grafico_row_2() {
            var grafico = 0;
            if (grafico == 0) {
                var arrPar = [];
                var arrVal = [];
                var arrVal_2 = [];
                var toti_este_messi = 0;
                var toti_mes_passadi = 0;

                for (i = 0; i < Mx_Dat_row_2.length; i++) {
                    arrVal.push(parseFloat(Mx_Dat_row_2[i].ESTE_MES));
                    arrVal_2.push(parseFloat(Mx_Dat_row_2[i].ESTE_DIA_MES_PASADO));
                    toti_este_messi += parseFloat(Mx_Dat_row_2[i].ESTE_MES);
                    toti_mes_passadi += parseFloat(Mx_Dat_row_2[i].ESTE_DIA_MES_PASADO);
                    arrPar.push(function () {
                        //Obtener valores
                        //var nDate = String(Mx_Dat_row_2[i].E_Fecha);
                        //nDate = nDate.toUpperCase().replace("/DATE(", "");
                        //nDate = nDate.replace(")/", "");
                        //var obj_date = new Date(parseInt(nDate));
                        //var hh = parseInt(obj_date.getHours());
                        //var mm = parseInt(obj_date.getMinutes());
                        //if (hh < 10) { hh = "0" + hh; }
                        //if (mm < 10) { mm = "0" + mm; }
                        //return String(hh + ":" + mm);
                        return moment(Mx_Dat_row_2[i].E_Fecha).format("DD-MM-YYYY");
                    }());
                }


                var fecha_now = moment().format("dddd, DD-MM-YYYY");

                Highcharts.chart('div_row_2', {
                    chart: {
                        type: 'line'
                    },
                    title: {
                        text: 'Ventas Diarias por Mes a la Fecha'
                    },
                    subtitle: {
                        text: ''//'Datos del día ' + fecha_now
                    },
                    xAxis: {
                        categories: arrPar
                    },
                    yAxis: {
                        title: {
                            text: 'Ventas'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: true
                        }
                    },
                    series: [{
                        name: 'Mes Actual',
                        data: arrVal,
                    }, {
                        name: 'Mes Pasado',
                        data: arrVal_2,
                    }
                    ]
                });
            }
            //$("#lbl_ayer").text("Ayer " + "(" + moment().add("days", -1).format("dddd") + ")" + " vs.  mismo día  de la semana pasada");
            $("#toti_este_messi").text("Total Mes Actual, desde 01 a " + moment().format("DD") + " de " + moment().format("MMMM") + ": " + "$" + addCommas(toti_este_messi));
            $("#toti_mes_passadi").text("Total Mes Pasado, desde 01 a " + moment().format("DD") + " de " + moment().add("month", -1).format("MMMM") + ": " + "$" + addCommas(toti_mes_passadi));
            $("#eModal_row_2").modal();
        }

        function grafico_row_3() {
            var grafico = 0;
            if (grafico == 0) {
                var arrPar = [];
                var arrVal = [];
                var arrVal_2 = [];
                var toti_este_messi_3 = 0;
                var toti_mes_passadi_3 = 0;
                for (i = 0; i < Mx_Dat_row_3.length; i++) {
                    arrVal.push(parseFloat(Mx_Dat_row_3[i].ESTE_MES));
                    arrVal_2.push(parseFloat(Mx_Dat_row_3[i].ESTE_DIA_MES_PASADO));
                    toti_este_messi_3 += parseFloat(Mx_Dat_row_3[i].ESTE_MES);
                    toti_mes_passadi_3 += parseFloat(Mx_Dat_row_3[i].ESTE_DIA_MES_PASADO);
                    arrPar.push(function () {
                        //Obtener valores
                        //var nDate = String(Mx_Dat_row_2[i].E_Fecha);
                        //nDate = nDate.toUpperCase().replace("/DATE(", "");
                        //nDate = nDate.replace(")/", "");
                        //var obj_date = new Date(parseInt(nDate));
                        //var hh = parseInt(obj_date.getHours());
                        //var mm = parseInt(obj_date.getMinutes());
                        //if (hh < 10) { hh = "0" + hh; }
                        //if (mm < 10) { mm = "0" + mm; }
                        //return String(hh + ":" + mm);
                        return moment(Mx_Dat_row_3[i].E_Fecha).format("DD-MMMM") + "/" + moment(Mx_Dat_row_3[i].Fecha_2).format("MMMM") + " - " + moment(Mx_Dat_row_3[i].E_Fecha).format("YYYY");
                    }());
                }

                var tot_mes = 0;

                var fecha_now = moment().format("dddd, DD-MM-YYYY");

                Highcharts.chart('div_row_3', {
                    chart: {
                        type: 'line'
                    },
                    title: {
                        text: 'Ventas Diarias por Mes Pasado - Mes Anterior'
                    },
                    subtitle: {
                        text: ''//'Datos del día ' + fecha_now
                    },
                    xAxis: {
                        categories: arrPar
                    },
                    yAxis: {
                        title: {
                            text: 'Ventas'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: true
                        }
                    },
                    series: [{
                        name: 'Mes Actual',
                        data: arrVal,
                    }, {
                        name: 'Mes Pasado',
                        data: arrVal_2,
                    }
                    ]
                });
            }
            $("#toti_este_messi_3").text("Total Mes Pasado, " + moment().add("month", -1).format("MMMM") + ": " + "$" + addCommas(toti_este_messi_3));
            $("#toti_mes_passadi_3").text("Total Mes Antepasado, " + moment().add("month", -2).format("MMMM") + ": " + "$" + addCommas(toti_mes_passadi_3));
            $("#eModal_row_3").modal();
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

        <div class="modal fade" id="eModal_row_1" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" style="text-align:center;">Ayer vs. Mismo Día de la Semana Pasada</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <div id="div_row_1"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="eModal_row_2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" style="text-align:center;">Este Mes vs. Mismo Día del Mes Pasado</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <div id="div_row_2"></div>
                        </div>
                    </div>
                    <div class="row">
                        <b><label id="toti_este_messi" style="text-align:left; color:#140054;"></label></b>
                        <b><label id="toti_mes_passadi" style="text-align:left; color:#140054;"></label></b>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="eModal_row_3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" style="text-align:center;">Mes Pasado vs. Mes Anterior</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <div id="div_row_3"></div>
                        </div>
                    </div>
                    <div class="row">
                        <b><label id="toti_este_messi_3" style="text-align:left; color:#140054;"></label></b>
                    </div>
                    <div class="row">
                        <b><label id="toti_mes_passadi_3" style="text-align:left; color:#140054;"></label></b>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="row ml-3 mr-3 mb-3">
        <div class="col-lg" style="text-align: center">
            <div class="card mt-lg-5 mb-3 p-3 border-info">
                <div class="row">
                    <div class="col-12 text-center">
                        <h5 style="color: #28a745"><b><span id="spn_tm2"></span></b></h5>
                    </div>
                    <div class="col-lg">
                        <div id="chrt_Dinero_Preve"></div>
                    </div>
                    <div class="col-lg">
                        <%--<h5>Estado de Exámenes</h5>--%>
                        <%--<h5 style="color: #28a745"><b>  <span id="spn_tm2"></span></b></h5>--%>
                        <div class="row">
                            <div class="col-7">
                                <%--<label for="txt_Money">Dinero:</label>--%>
                                <h1 style="color: #007e9e"><b>Venta Diaria:</b></h1>
                            </div>
                            <div class="col-5 text-danger">
                                <b>
                                    <%--<label id="txt_Money">0</label>--%></b>
                                <h1 id="txt_Money" style="color: #007e9e;font-weight:700;"></h1>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-8">
                                <h3 for="txt_Atem"><i class="fa fa-user"></i></h3>
                                <%--<label for="txt_Atem"><i class="fa fa-user"></i>:</label>--%>
                            </div>
                            <div class="col-4 text-primary">
                                <b>
                                    <label id="txt_Atem">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <h3><i class="fa fa-flask fa-1x"></i></h3>
                            </div>
                            <div class="col-4 text-success">
                                <b>
                                    <label id="txt_Exam">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <h3><b>%</b></h3>
                            </div>
                            <div class="col-4 text-success">
                                <b>
                                    <label id="">0%</label></b>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="background-color:#f0f0f0; border:solid; border-radius:5px; border-color:#cccccc;border-width:2px;">
                            <div class="row" style="cursor:pointer;" id="row_1">
                            <div class="col-7" style="text-align:right;">
                                <h4 id="lbl_ayer" style="cursor:pointer; color:#525151; font-size:15px;"><b></b></h4>
                            </div>
                            <div class="col-5" style="cursor:pointer;text-align:right;">
                             <b><label id="txt_Money_2_before" style="text-align:left !important;"></label></b><b><label id="txt_Money_2"></label></b><i id="i_2"></i>
                            </div>
                        </div>
                        <div class="row" style="cursor:pointer;" id="row_2">
                            <div class="col-7" style="text-align:right;">
                                <h4 id="lbl_antesayer" style="color:#525151; font-size:15px;"><b></b></h4>
                            </div>
                            <div class="col-5" style="text-align:right;">
                                <b><label id="txt_Money_3_before" style="text-align:left !important;"> </label></b><b><label id="txt_Money_3"></label></b><i id="ii_3"></i>
                            </div>
                        </div>
                        <div class="row" style="cursor:pointer;" id="row_3">
                            <div class="col-7" style="text-align:right;">
                                <h4 id="lbl_mes_pasado" style="color:#525151; font-size:15px;"><b></b></h4>
                            </div>
                            <div class="col-5" style="text-align:right;">
                               <b><label id="txt_Money_4_before"> </label></b><b><label id="txt_Money_4"></label></b><i id="iii_4"></i>
                            </div>
                        </div> 
                        </div>
                                
                    </div>
                </div>
            </div>
        </div>
<%--        <div class="col-lg">
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
        </div>--%>
    </div>
    <div class="card p-3 " id="div_hide" style="display:none"> <%--border-bar--%>
        <div class="row">
            <div class="col-lg-3">
                <div class="row mb-3">
                    <div class="col-lg">
                        <h5>Últimos 15 días</h5>
                        <div id="Div_Tabla" class="table table-hover table-striped table-iris"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9">
                <div id="Summary_Graph"></div>
            </div>
        </div>
        
    </div>
    <div class="card p-3 " id="asdad"> <%--border-bar--%>
        <div class="row">
            <div class="col-lg">
                <div id="chrt_4"></div>
            </div>
            <div class="col-lg">
                <%--<h5>Exámenes por Procedencia</h5>--%>
                <div id="chrt_2" class="table table-hover table-striped table-iris"></div>
            </div>
            <div class="col-lg">
                <div id="chrt_3"></div>
            </div>
        </div>
    </div>

        <div class="card p-3 " id="asdadasd"> <%--border-bar--%>
        <div class="row">
            <div class="col-lg">
                <%--<h5>Exámenes por Procedencia</h5>--%>
                <div id="chrt_6" class="table table-hover table-striped table-iris"></div>
            </div>
            <div class="col-lg">
                <div id="chrt_7"></div>
            </div>
          <%--  <div class="col-lg">
                <div id="chrt_4"></div>
            </div>--%>
        </div>
    </div>

        <div class="card p-3 " id="sdfdf"> <%--border-bar--%>
        <div class="row">
            <div class="col-lg">
                <%--<h5>Exámenes por Procedencia</h5>--%>
                <div id="chrt_5" class="table table-hover table-striped table-iris"></div>
            </div>
        </div>
    </div>

    <br />
    <div class="card p-3">
        <h3 style="color: #015368";> <b>Opciones</b></h3>
        <div class="row text-center mrgs mb-3" id="amed"></div>
        <div class="row text-center mrgs mb-3" id="amed2"></div>

    </div>
    

    <div class="mt-5 text-center" id="usr">
        <h3 style="color: #015368"> <b><span id="spn_Usr"></span> - BIENVENIDO(A) AL SITIO DE IRISLAB ANALYTICS </b></h3>
    </div>

    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="sss">OPCIONES DE INGRESO DE ATENCIÓN</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="Manual" class="btn btn-primary" style="height: 120px; width: 75%;" disabled="disabled"><b>PACIENTE MANUAL</b></button>
                        </div>
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="AVIS" class="btn btn-info" style="height: 120px; width: 75%;"><b>PACIENTE AVIS</b></button>
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
