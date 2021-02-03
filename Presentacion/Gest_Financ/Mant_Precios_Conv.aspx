<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Mant_Precios_Conv.aspx.vb" Inherits="Presentacion.Mant_Precios_Conv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>

    <script src="/js/WebForm.js"></script>
    <script src="/js/math.js"></script>
    <script src="/js/numeral/numeral.min.js"></script>
    <script src="Mant_Precios_Conv.js"></script>

    <style>
        #divTable table thead {
            font-size: 0.75rem;
        }

        #divTable table tbody {
            font-size: 0.70rem;
        }

            #divTable table tbody tr {
                /*height: 35px;*/
            }

            #divTable table tbody input[type=text] {
                display: flex;
                display: -webkit-flex;
                width: calc(100% - 7px);
                max-width: 120px;
                /*height: 35px;*/
                padding: 3px;
                text-align: right;
                font-size: 0.75rem;
            }

        .checkbox {
            position: relative;
            top: -5px;
            left: -3px;
        }

            .checkbox label:before {
                margin-top: 0px;
                width: 15px;
                height: 15px;
            }

            .checkbox label:after {
                width: 5px;
                height: 5px;
            }


        #divTable tr > th:nth-child(2), #divTable tr > td:nth-child(2) {
            width: 80px !important;
        }

        #divTable tr > th:nth-last-child(-n+8), #divTable tr > td:nth-last-child(-n+8) {
            width: 80px !important;
        }

        #divTable tbody tr {
            height: 20px !important;
        }

        #divTable tr > td:nth-child(3) {
            white-space: pre;
        }

        #divTable tbody .tr_selected {
            color: #ffffff;
            background: #6e6cf0;
        }

        .webform_chk {
            font-size: 1rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card mb-2 border-bar">
        <div class="card-header bg-bar">
            <h5 class="mb-0">Mantenedor de Precios por Convenio</h5>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3">
                    <div class="form-group">
                        <label>Previsión:</label>
                        <select id="Sel_Prev" class="form-control"></select>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-3">
                    <div class="form-group">
                        <label>Año:</label>
                        <select id="Sel_Year" class="form-control"></select>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-2">
                    <div class="form-group">
                        <input type="checkbox" name="Chk_Filther" data-text="Todos" data-value="true" checked />
                        <button type="button" id="Btn_Search" class="btn btn-block btn-primary mt-0">
                            <i class="fa fa-search"></i>
                            <span>Buscar</span>
                        </button>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-2">
                    <div class="form-group">
                        <label></label>
                        <button type="button" id="Btn_Export" class="btn btn-block btn-success">
                            <i class="fa fa-file-excel-o"></i>
                            <span>Exportar</span>
                        </button>
                    </div>
                </div>
                <div class="col-12 col-sm-6 col-md-2">
                    <div class="form-group">
                        <label></label>
                        <button type="button" class="btn btn-block btn-danger" data-toggle="modal" data-target="#mdlCopy">
                            <i class="fa fa-clone"></i>
                            <span>Copiar</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card mb-2 border-bar">
        <div class="card-header bg-bar">
            <h5 class="mb-0">Resultados</h5>
        </div>
        <div id="divTable" class="card-body">

        </div>
    </div>

    <!-- MODALES -->
    <div id="mdlExcel" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Exportar</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
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

    <div id="mdlCopy" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Copiar Valores</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <div class="row">
                        <div class="col-5 view-1">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Desde:</label>
                                        <select id="Sel_Prev_From" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Año:</label>
                                        <select id="Sel_Year_From" class="form-control"></select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-2 view-2 text-center pt-5">
                            <i class="fa fa-arrow-right fa-2x" style="margin-top: 25px;"></i>
                        </div>
                        <div class="col-12 view-3 text-center">
                            <i class="fa fa-arrow-down fa-2x"></i>
                        </div>
                        <div class="col-5 view-1">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Hasta:</label>
                                        <select id="Sel_Prev_To" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Año:</label>
                                        <select id="Sel_Year_To" class="form-control"></select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-12">
                            <input type="checkbox" name="Chk_Filther_2" data-text="Todos los exámenes" data-value="true" checked />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Confirm_Copy" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-clone" aria-hidden="true"></i>
                        <span>Copiar</span>
                    </button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlConfirm" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Copiar Valores</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p>¿Está seguro que desea copiar los valores de {elem_1} a {elem_2}?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Copy" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Aceptar</span>
                    </button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlCopySuccess" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Copiar Valores</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <p>Copia efectuada Correctamente.</p>
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
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ERROR</h4>
                </div>
                <div class="modal-body pt-5 pb-5 text-left">
                    <div>
                        <strong>Tipo de Error: </strong>
                        <p id="mdlTxt_Type"></p>
                        <br />
                    </div>
                    <div>
                        <strong>Descripción: </strong>
                        <p id="mdlTxt_Descr"></p>
                        <br />
                    </div>
                    <div>
                        <strong>Pila de Seguimiento: </strong>
                        <code id="mdlTxt_StackT"></code>
                        <br />
                    </div>
                    <div>
                        <strong>Póngase en contacto con IrisLab para asistencia técnica.</strong>
                    </div>
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
