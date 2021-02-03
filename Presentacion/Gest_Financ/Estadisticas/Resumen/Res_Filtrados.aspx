<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Res_Filtrados.aspx.vb" Inherits="Presentacion.Res_Filtrados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <!-- General -->
    <%@ OutputCache Location="None" NoStore="true"%>
    <title>Resultados Filtrados</title>

    <!-- Datepicker -->
    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.min.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>

    <!-- Webform -->
    <link href="/js/webform3/webform3.css" rel="stylesheet" />
    <script src="/js/webform3/webform3.js"></script>
    <script src="Res_Filtrados.js"></script>

    <style>
        .datepicker {
            z-index: 50000;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="m2">
        <div class="card">
            <div class="card-header">
                <h5>Resultados (Un Parámetro)</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-sm-12 col-md-3">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <label for="txt_date1">Desde:</label>
                                    <input type="text" id="txt_date1" class="form-control" />
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <label for="txt_date2">Hasta:</label>
                                    <input type="text" id="txt_date2" class="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <label for="sel_proc">Procedencia:</label>
                                    <select id="sel_proc" class="form-control"></select>
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <label for="sel_prev">Previsión:</label>
                                    <select id="sel_prev" class="form-control"></select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <label for="sel_prog">Programa:</label>
                                    <select id="sel_prog" class="form-control"></select>
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <label for="sel_subp">SubPrograma:</label>
                                    <select id="sel_subp" class="form-control"></select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <input type="checkbox" id="chk_todos" data-text="Todos los Result" />
                                    <button type="button" id="btn_search" class="btn btn-block btn-primary">
                                        <i class="fa fa-search"></i>
                                        <span>Buscar</span>
                                    </button>
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-12">
                                <div class="form-group">
                                    <br />
                                    <button type="button" class="btn btn-block btn-success" data-toggle="modal" data-target="#mdl_correo">
                                        <i class="fa fa-table"></i>
                                        <span>Exportar</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card mt-3">
            <div class="card-header">
                <h5>Resultados</h5>
            </div>
            <div id="tbl_data" class="card-body">

            </div>
        </div>
    </div>

    <!-- Modales -->
    <div id="mdl_correo" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Enviar</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                   <p class="text-justify">Por favor ingrese un correo electrónico en la siguiente casilla para enviar. Cuando el correo sea válido se habilitará el botón enviar:</p>
                   <input type="text" id="txt_email" class="form-control" autocomplete="on" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" disabled="disabled" id="btn_export">
                        <i class="fa fa-send" aria-hidden="true"></i>
                        <span>Enviar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdl_sended" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Hecho</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p class="text-justify">Se ha iniciado una petición de datos, se enviará un correo a <strong></strong>. Recibirá un excel con los resultados que usted solicitó.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Aceptar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdl_error" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ERROR</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p>Se ha generado un error interno. Si el problema persiste contáctese con soporte de IrisLAB para asistencia técnica.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Aceptar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
