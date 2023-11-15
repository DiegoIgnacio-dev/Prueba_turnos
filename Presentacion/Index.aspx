<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Index.aspx.vb" Inherits="Presentacion.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script>
        $(document).ready(function () {
            $("#con_wra").removeClass("py-3");


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
            //var Nom = Galletas.getGalleta("NAME");
            //var Ape = Galletas.getGalleta("SURNAME");
            //Nom = Nom.toUpperCase();
            //Ape = Ape.toUpperCase();
            $("#spn_Usr").text("Usuario Prueba");

            ////////////////////BTN PRUEBA
            ///// SPLIT CADENA NUMEROS POR

            var permiss = 1;

            //botones
            var btn_datas = {
                "datass":
                [
                //{
                //    "href": "TEST/Test_DW.aspx",
                //    "icon": "code",
                //    "textn1": "Lista",
                //    "textn2": "Producto"
                //},{
                //    "href": "TEST/Ingreso_Producto.aspx",
                //    "icon": "code",
                //    "textn1": "Ingreso",
                //    "textn2": "Producto"
                //},
                //{
                //    "href": "TEST/Ingreso_Ingredientes.aspx",
                //    "icon": "code",
                //    "textn1": "Ingreso",
                //    "textn2": "Ingredientes"
                //},
                 {
                     "href": "TEST/moduloTurno/Ingreso_Turnos/Ingreso_Turnos.aspx",
                     "icon": "code",
                     "textn1": "Ingreso",
                     "textn2": "Turnos"
                 }, {
                     "href": "TEST/moduloTurno/mActualizacionModulos/actualizarModulos.aspx",
                     "icon": "code",
                     "textn1": "Vista",
                     "textn2": "Modulos"
                 },
                 {
                     "href": "TEST/moduloTurno/mActualizacionModulos/actualizarModulosVista.aspx",
                    "icon": "code",
                   "textn1": "Vista",
                    "textn2": "Modulos 2"
                },
                 {
                     "href": "TEST/moduloTurno/M_Impresion/M_impresion_modulo.aspx",
                     "icon": "code",
                     "textn1": "Impresión",
                     "textn2": "Modulos"
                 }
                ]

            };


            switch (parseInt(permiss)) {
                case 0:
                    break;
                case 1:
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
                case 2:
                    var btnbool = [];
                    break;

                case 3:
                    var btnbool = [];
                    break;

                case 4:
                    var btnbool = [];
                    break;

                case 5:
                    var btnbool = [];
                    break;

                case 6:
                    var btnbool = [];
                    break;

                case 7:
                    var btnbool = [];
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

        });

        // Pruebas de botones 

        //Funciones Tomas validaciones con jquery

        $(document).ready(function () {

            $("#enviar").click(function () {

                var email = $("#email").val();
                var asunto = $("#asunto").val();
                var nombre = $("#nombre").val();

                if (email == "") {
                    $("#mensaje1").fadeIn();
                    return;
                } else {
                    $("#mensaje1").fadeOut();

                    if (asunto == "") {
                        $("#mensaje2").fadeIn();
                    } else {
                        $("#mensaje2").fadeOut();

                        if (nombre == "") {
                            $("#mensaje3").fadeIn();
                        }
                    }
                }
            })
        })


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

        .errores {
            display: none;
        }
    </style>


    <div class="row ml-3 mr-3 mb-3">
        <div class="col-lg" style="text-align: center">
            <img src="Imagenes/IrisLab%20Logo%20LARGOa.png" id="imgx" />
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
                            <button type="button" id="AVIS" class="btn btn-info btn-lg btn-block p-2">PACIENTE CAJA</button>
                        </div>
                        <%--<div class="col-6 " style="text-align: center;">
                            <a href="/Agenda_Med/Ingreso_Ate_Saydex.aspx" class="btn btn-danger btn-lg btn-block p-2">RAYEN</a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- PRUEBA FORMULARIO-->

    <!--INICIO FORMULARIO-->




    <!-- FIN  PRUEBA FORMULARIO-->


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
