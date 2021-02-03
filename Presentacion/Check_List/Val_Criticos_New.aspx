<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Val_Criticos_New.aspx.vb" Inherits="Presentacion.Val_Criticos_New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true"%>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/vendor/datatables/dataTables.bootstrap4.js"></script>

    <link href="/css/WebForm2.css" rel="stylesheet" />
    <script src="/js/WebForm2.js"></script>
    <script src="Val_Criticos_New.js"></script>

    <style>
        @media (max-width: 575.98px) {
            .form-group br {
                display: none;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="m-2">
        <div class="card mb-2">
            <div class="card-header">
                <h5>Estadística de Valores Críticos</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-12 col-sm-6 col-md-2">
                        <div class="form-group">
                            <label for="txtDate1">Desde:</label>
                            <input type="text" id="txtDate1" class="form-control" />
                         </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-2">
                        <div class="form-group">
                            <label for="txtDate2">Hasta:</label>
                            <input type="text" id="txtDate2" class="form-control" />
                         </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-4">
                        <div class="form-group">
                            <label for="selProc">Procedencia:</label>
                            <select id="selProc" class="form-control"></select>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-4">
                        <div class="form-group">
                            <label for="selPrev">Previsión:</label>
                            <select id="selPrev" class="form-control"></select>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4">
                        <div class="form-group">
                            <label for="selCodF">Examen:</label>
                            <select id="selCodF" class="form-control"></select>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-4">
                        <div class="form-group">
                            <label for="selEsta">Estado:</label>
                            <select id="selEsta" class="form-control"></select>
                        </div>
                    </div>
                    <div class="col-12 col-sm-3 col-md-2">
                        <div class="form-group">
                            <br />
                            <button type="button" id="btnSearch" class="btn btn-block btn-primary">
                                <i class="fa fa-search"></i>
                                <span>Buscar</span>
                            </button>
                        </div>
                    </div>
                    <div class="col-12 col-sm-3 col-md-2">
                        <div class="form-group">
                            <br />
                            <button type="button" id="btnExport" class="btn btn-block btn-success">
                                <i class="fa fa-file-excel-o"></i>
                                <span>Excel</span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-header">
                <h5>Resultados</h5>
            </div>
            <div class="card-body" id="divTable">
                
            </div>
        </div>
    </div>

    <!-- Modales -->
    <div id="mdlExport" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Planilla Excel</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p data-found="true">El archivo solicitado se ha generado correctamente, si no se inicia automáticamente la descarga haga click en <a href="#">Este Enlace.</a></p>
                    <p data-found="false">La búsqueda solicitada no devuelve resultados, por lo cual el archivo no ha sido creado.</p>
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

    <div id="mdlError" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
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
