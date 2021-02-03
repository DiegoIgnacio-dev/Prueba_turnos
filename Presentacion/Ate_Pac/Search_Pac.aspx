<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Search_Pac.aspx.vb" Inherits="Presentacion.Search_Pac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true"%>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/vendor/datatables/dataTables.bootstrap4.js"></script>

    <link href="/css/WebForm2.css" rel="stylesheet" />
    <script src="/js/WebForm2.js"></script>
    <script src="/js/RUT.js"></script>
    <script src="Search_Pac.js"></script>

    <style>
        .input-group-addon.dcto {
            width: 45px;
        }
        .input-group-addon.name {
            width: 68px;
        }

        *:not(.modal-footer) > .btn {
            margin: 0px!important;
            cursor: pointer;
        }

        .alert {
            margin-left: 1rem;
            margin-right: 1rem;
        }

        .separator {
            margin-bottom: 1rem;
        }
        
        .separator:after {
            position: absolute;
            content: "";
            bottom: 0;
            right: 1rem;
            height: 2px;
            width: calc(100% - 2rem);
            background: #d5d5d5;
        }

        .param {
            padding-bottom: 0.25rem!important;
        }

        table td {
            font-size: 0.7rem!important;
        }

        .redim .card-body {
            overflow: auto;
        }

        @media (min-width: 768px) {
            .separator {
                margin-bottom: inherit;
            }

            .separator:after {
                position: absolute;
                content: "";
                top: 0;
                right: 0;
                height: calc(100% - 15px);
                width: 2px;
                background: #d5d5d5;
            }

            .redim {
                margin-bottom: 0!important;
            }

            .redim .card-body {
                height: calc(100vh - 360px);
            }
        }

        @media (max-width: 575.98px) {
            .input-group-addon {
                width: 72px!important;
            }

            .form-group br {
                display: none;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="p-2">
        <div class="row">
            <div class="col-12">
                <div class="card mt-2 mb-2">
                    <div class="card-header">
                        <h5>Búsqueda de Pacientes</h5>
                    </div>
                    <div class="card-body param">
                        <div class="row">
                            <div class="col-12 col-sm-12 col-md-9 separator">
                                <div class="row">
                                    <div class="col-12 col-sm-6 col-md-4 col-lg-4">
                                        <div class="form-group input-group input-group-sm">
                                            <span class="input-group-addon dcto">RUT</span>
                                            <input type="text" id="txtRUT" class="form-control form-control-sm" />
                                        </div>
                                        <div class="form-group input-group input-group-sm">
                                            <span class="input-group-addon dcto">DNI</span>
                                            <input type="text" id="txtDNI" class="form-control form-control-sm" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-sm-6 col-md-5 col-lg-5">
                                        <div class="form-group input-group input-group-sm">
                                            <span class="input-group-addon name">Nombre</span>
                                            <input type="text" id="txtName" class="form-control form-control-sm" />
                                        </div>
                                        <div class="form-group input-group input-group-sm">
                                            <span class="input-group-addon name">Apellido</span>
                                            <input type="text" id="txtlastN" class="form-control form-control-sm" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-3 col-lg-3">
                                        <div class="row">
                                            <div class="col-6 col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <button type="button" id="btnSearch1" class="btn btn-sm btn-block btn-primary">
                                                        <i class="fa fa-search"></i>
                                                        <span>Buscar</span>
                                                    </button>
                                                </div>
                                            </div>
                                            <div class="col-6 col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <button type="button" id="btnClean" class="btn btn-sm btn-block btn-secondary">
                                                        <i class="fa fa-eraser"></i>
                                                        <span>Limpiar</span>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-12 col-sm-12 col-md-3">
                                <div class="row">
                                    <div class="col-12 col-sm-6 col-md-12 col-lg-12">
                                        <div class="form-group input-group input-group-sm">
                                            <span class="input-group-addon">N° Atenc</span>
                                            <input type="text" id="txtNAte" class="form-control form-control-sm" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-sm-6 col-md-12 col-lg-12">
                                        <div class="form-group">
                                            <button type="button" id="btnSearch2" class="btn btn-sm btn-block btn-primary">
                                                <i class="fa fa-search"></i>
                                                <span>Buscar</span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-6">
                <div class="card mt-2 mb-2 redim">
                    <div class="card-header">
                        <h5>Lista Pacientes</h5>
                    </div>
                    <div class="card-body pl-0 pr-0" id="divTablePac">

                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-6">
                <div class="card mt-2 mb-2 redim">
                    <div class="card-header">
                        <h5>Lista Atenciones</h5>
                    </div>
                    <div class="card-body pl-0 pr-0" id="divTableAte">

                    </div>
                </div>
            </div>
        </div>

        
    </div>

    <!-- Modales -->
    <div id="mdlDet" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Detalle Atención</h4>
                </div>
                <div class="modal-body text-left">
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-3">
                            <div class="form-group">
                                <label>N° Atención:</label>
                                <input type="text" id="txtDetNAte" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-6 col-sm-6 col-md-3">
                            <div class="form-group">
                                <label>Fecha:</label>
                                <input type="text" id="txtDetFecha" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-12 col-sm-6 col-md-3">
                            <div class="form-group">
                                <label>Procedencia:</label>
                                <input type="text" id="txtDetProc" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-12 col-sm-6 col-md-3">
                            <div class="form-group">
                                <label>Previsión:</label>
                                <input type="text" id="txtDetPrev" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-12 col-sm-6">
                            <div class="form-group">
                                <label>Nombre Paciente:</label>
                                <input type="text" id="txtDetPac" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-12 col-sm-6">
                            <div class="form-group">
                                <label>Nombre Doctor:</label>
                                <input type="text" id="txtDetDoc" class="form-control form-control-sm" />
                            </div>
                        </div>
                        <div class="col-12 pt-2" id="divTableDet">

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a href="#" target="_blank" id="lnkGoto" class="btn btn-success">
                        <i class="fa fa-eye" aria-hidden="true"></i>
                        <span>Ver Documentos</span>
                    </a>
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
