<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Anul_Bon.aspx.vb" Inherits="Presentacion.Anul_Bon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let ATE_NUM = "";
        $(document).ready(() => {
       
            //ATE_NUM = getParameterByName("AN");

            $("#txt_Folio").focus();

            $("#btn_Ver_Boleta").attr("disabled", "disabled");
            $("#btn_Boleta").attr("disabled", "disabled");

            if (ATE_NUM != "") {
                $("#txt_Folio").val(ATE_NUM);
                //fn_Ver_Boleta();
                Llenar_DataTable();

            }

            $("#Btn_Buscar").click(() => {
                if ($("#txt_Folio").val() != "") {
                    ATE_NUM = $("#txt_Folio").val();
                    Llenar_DataTable();
                    //fn_Ver_Boleta();
                }
            });

            $("#txt_Folio").on('keypress', (e) => {
                if (e.which == 13) {
                    if ($("#txt_Folio").val() != "") {
                        ATE_NUM = $("#txt_Folio").val();
                        Llenar_DataTable();
                        //fn_Ver_Boleta();
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
                $("#btn_Boleta").attr("disabled", "disabled");
                $("#txt_Folio").focus();
                $("#Div_Tabla_Det").empty();
            });

        });

        function Anul_Bon() {
            AnBonInt();
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
            "PROC_DESC": "",
            "ATE_BON_IMED": ""
        }];

        function Llenar_DataTable() {
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": ATE_NUM
            });
            //Debug
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Anul_Bon.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_DataTable = data.d;

                    if (Mx_DataTable != null && Mx_DataTable.ID_ATENCION != 0) {
                        console.log("exito");
                        Fill_DataTable();
                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin Resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado bonos asociados a folio.");
                        $("#mError_AAH").modal();
                    }
                    
                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }

        let Mx_DataTable_Det = [{
            "ID_ATENCION": "",
            "ID_CODIGO_FONASA": "",
            "ATE_DET_NUM_BONO": "",
            "CF_DESC": "",
            "USU_NIC":""
        }];

        function Llenar_DataTable_Det(_IDE_ATE) {
            modal_show();
            let Data_Par = JSON.stringify({
                "ID_ATENCION": _IDE_ATE
            });
            //Debug
            AJAX_Dtt = $.ajax({
                "type": "POST",
                "url": "Anul_Bon.aspx/Llenar_DataTable_det",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_DataTable_Det = data.d;

                    if (Mx_DataTable_Det != null) {
                        console.log("exito");
                        $("#Div_Tabla_Det").empty();
                        Fill_DataTable_Det();
                    }

                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }

        var Mx_Dtt_AnBonInt = [
          {
              CodError: "",
              GloEstado: ""
          }
        ];

        function AnBonInt() {
            Mx_Dtt_AnBonInt = [];
            var Data_Par = JSON.stringify({
                "CodUsuario": "0070614000-K",//"0017047947-5",
                "CodClave": "70614000-K",//"17047",
                "CodFinanciador": "71",
                "OrigenLlamado": "2",
                "RutConvenio": "0070614000-K",
                "RutBenef": "0008454365-9",
                "FolioBono": "745032440",
                "UrlRetorno": "www.google.cl",
                "S_Id_User": Galletas.getGalleta("ID_USER"),
            });
            $.ajax({
                "type": "POST",
                "url": "Anul_Bon.aspx/AnBonInt",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        ResAnBonInt = json_receiver;

                        if (Mx_Dtt_AnBonInt.CodError == 0) {
                            AnulBol();
                        } else {

                        }
                    } else {
                        aler("Error en proceso de anulación");
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        var Mx_Dtt_Log = [
          {
              CodError: "",
              GloEstado: ""
          }
        ];

        function AnulBol() {
            Mx_Dtt_AnBonInt = [];
            var Data_Par = JSON.stringify({
                "CodUsuario": "0070614000-K",//"0017047947-5",
                "CodClave": "70614000-K",//"17047",
                "CodFinanciador": "71",
                "OrigenLlamado": "2",
                "RutConvenio": "0070614000-K",
                "RutBenef": "0008454365-9",
                "FolioBono": "745032440",
                "UrlRetorno": "www.google.cl"
            });
            $.ajax({
                "type": "POST",
                "url": "Anul_Bon.aspx/AnulBol",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {


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

        function Fill_DataTable() {
            $("#Ate_Folio").text(Mx_DataTable.ATE_NUM);
            $("#Ate_Nombre").text(Mx_DataTable.PAC_NOMBRE + " " + Mx_DataTable.PAC_APELLIDO);
            $("#Ate_Fecha").text(moment(Mx_DataTable.ATE_FECHA).format("DD-MM-YYYY"));
            $("#Ate_Rut").text(Mx_DataTable.PAC_RUT);
            $("#Ate_Proce").text(Mx_DataTable.PROC_DESC);
            $("#Ate_Preve").text(Mx_DataTable.PREVE_DESC);
            $("#Ate_Bonos").text(Mx_DataTable.ATE_BON_IMED);
            Llenar_DataTable_Det(Mx_DataTable.ID_ATENCION)
            //Hide_Modal();
        }

        //------------------------------------------------ TABLA MARCAR  --------------------------------------------------------------|
        function Fill_DataTable_Det() {
            $("<table>", {
                "id": "DataTable_Det",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Det");

            $("#DataTable_Det").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Det").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Det thead").attr("class", "cabzera");

            $("#DataTable_Det thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Examen"),
                    $("<th>", { "class": "textoReducido" }).text("N° Bono"),
                    $("<th>", { "class": "textoReducido" }).text("Anular")

                )
            );

            for (i = 0; i < Mx_DataTable_Det.length; i++) {
                $("#DataTable_Det tbody").append(
                $("<tr>").append(
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DataTable_Det[i].USU_NIC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DataTable_Det[i].CF_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_DataTable_Det[i].ATE_DET_NUM_BONO),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                        //$(this).append("<button type='button' class='btn btn-info btn-sm' onclick='Fill_IMG_Fill(" + Mx_Dtt[i].ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver</button>");
                        $(this).append("<button type='button' class='btn btn-dark btn-sm' onclick='Anul_Bon(" + 1 + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Anular</button>");


                    })
                )
            );
            }
            Hide_Modal();
        }

    </script>
    <style>
        .f-h5 {
            font-size: 1.2rem;
        }
    </style>
    <div class="container">
        <div class="card border-bar mb-3 mt-3">
            <div class="card-header text-center bg-bar">
                <h5 class="m-0"><i class="fa fa-user fa-fw"></i>Datos de Atención</h5>
            </div>
            <div class="card-body">
                <div class="row mb-2">
                    <div class="col-lg-3 mb-2">
                        <div class="row">
                            <div class="col pr-0">
                                Folio:
                            </div>
                            <i class="fa fa-arrow-left d-inline btn btn-sm btn-primary" id="btn_Left"></i>
                            <div class="col-6 p-0">
                                <input type="text" id="txt_Folio" class="form-control form-control-sm text-danger font-weight-bold pt-0 pb-0" style="font-size: 1.2rem" />
                            </div>
                            <i class="fa fa-arrow-right d-inline btn btn-sm btn-primary" id="btn_Right"></i>
                        </div>
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Buscar" class="btn btn-buscar btn-sm btn-block mt-0">Buscar</button>
                    </div>
                    <div class="col-lg mb-4">
                    </div>
                    <div class="col-lg mb-2">
                        <button type="button" id="Btn_Limpiar" class="btn btn-limpiar btn-sm btn-block mt-0">Limpiar</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Folio: <span id="Ate_Folio"></span></div>
                    <div class="col-lg-4 f-h5">Fecha: <span id="Ate_Fecha"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Nombre: <span id="Ate_Nombre"></span></div>
                    <div class="col-lg-4 f-h5">RUT: <span id="Ate_Rut"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Procedencia: <span id="Ate_Proce"></span></div>
                    <div class="col-lg-4 f-h5">Previsión: <span id="Ate_Preve"></span></div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg f-h5">Bonos: <span id="Ate_Bonos"></span></div>
                </div>
            </div>
        </div>

        <div class="card border-bar">
            <div class="card-header bg-bar text-center">
                <h5 class="m-0"><i class="fa fa-file-pdf-o fa-fw"></i>Anulación Bono Imed</h5>
            </div>
            <div class="card-body">
                <div class="row mt-3">
                    <div class="col-lg-12 text-center">
                        <h5 id="est_Boleta"></h5>
                    </div>
                </div>
                <div class="row">
                    <div id="Div_Tabla_Det" style="width: 100%;" class="table-responsive"></div>
<%--                    <div class="col-lg-6 text-center">
                        <button type="button" id="btn_Boleta" class="btn btn-primary m-3" disabled="disabled">Emitir Boleta</button>
                    </div>
                    <div class="col-lg-6 text-center">
                        <button type="button" id="btn_Ver_Boleta" class="btn btn-success m-3" disabled="disabled">Ver Boleta</button>
                    </div>--%>
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

</asp:Content>
