<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ate_Resultados.aspx.vb" Inherits="Presentacion.Ate_Resultados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <script src="../js/HighCharts.js"></script>
    <script src="../js/HighC_Exporting.js"></script>

    <script src="/js/WebForm.js"></script>
    <script src="/js/math.js"></script>

    <script src="Ate_Resultados.js"></script>

    <script src="../js/Galletas.js"></script>

    <link href="Ate_Resultados.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        .v_pink {
            background-color: #fb91de !important;
        }

        .v_green {
            background-color: #c0ffc0 !important;
        }

        .v_blue {
            background-color: #0000ff !important;
        }
    </style>
    <div id="mdls"></div>
    <div class="card mb-2 border-bar">
        <div class="card-header bg-bar">
            <h4 class="m-0" id="title_Det_Ate">Detalle Atención</h4>
        </div>
        <div class="form-header card-body pl-2 pr-2 pt-1 pb-1">
            <div class="row pl-2 pr-2">
                <div class="col-lg">
                    <label>N° Ate:</label>
                    <div class="input-group mb-2">
                        <input type="text" id="Txt_NumAte" class="form-control form-control-sm" />
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-primary btn-sm" id="Btn_AteL">
                                <i class="fa fa-chevron-left" aria-hidden="true"></i>
                            </button>
                            <button type="button" class="btn btn-primary btn-sm" id="Btn_AteR">
                                <i class="fa fa-chevron-right" aria-hidden="true"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-lg-1">
                    <div class="form-group mb-2" id="chk_Nombre">
                        <input type="checkbox" name="Chk_Filther" data-text="Paciente:" data-value="6" />
                        <div class="form-group mb-2">
                            <div class="input-group-btn">
                                <button type="button" class="btn btn-primary btn-sm btn-block mt-0" id="Btn_Hist">
                                    <i class="fa fa-search" aria-hidden="true"></i>
                                    <span>Ver Hist.</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg">
                    <div class="form-group  mb-2">
                        <input type="checkbox" name="Chk_Filther" data-text="Procedencia:" data-value="0" />
                        <select id="Sel_Proc" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="form-group  mb-2">
                        <input type="checkbox" name="Chk_Filther" data-text="Previsión:" data-value="1" />
                        <select id="Sel_Prev" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>

                <div class="col-lg">
                    <div class="form-group mb-2">
                        <input type="checkbox" name="Chk_Filther" data-text="Programa:" data-value="2" />
                        <select id="Sel_Prog" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="form-group mb-2">
                        <input type="checkbox" name="Chk_Filther" data-text="Sección:" data-value="3" />
                        <select id="Sel_Secc" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
                <div class="col-lg">
                    <div class="form-group mb-2">
                        <input type="checkbox" name="Chk_Filther" data-text="Examen:" data-value="4" />
                        <select id="Sel_Exam" class="form-control form-control-sm">
                        </select>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card card-last border-bar">
        <div class="card-header bg-bar">
            <h5 class="m-0 text-left" id="title_Det_Ate_2">Resultados Atención</h5>
        </div>
        <div class="card-body pl-0 pr-0" id="Dtt_Exam">
        </div>
    </div>
    <div style="padding-top: 6rem"></div>
    <!-- Botones lado inferior -->
    <div class="float_buttons border-bar">
        <div class="row">
            <div class="col-12 col-sm-6 col-md-2">
                <button id="Btn_Audit" type="button" class="btn btn-block btn-primary">
                    <i class="fa fa-calendar"></i>
                    <span>Auditoría</span>
                </button>
            </div>
            <div class="col-12 col-sm-6 col-md-2">
                <button id="Btn_Graph" type="button" class="btn btn-block btn-warning">
                    <i class="fa fa-line-chart"></i>
                    <span>Graficar</span>
                </button>
            </div>
            <div class="col-12 col-sm-6 col-md-2">
                <button id="Btn_Validar" type="button" class="btn btn-block btn-success" disabled="disabled">
                    <i class="fa fa-check"></i>
                    <span>Validar</span>
                </button>
            </div>
            <div class="col-12 col-sm-6 col-md-2">
                <button id="Btn_Desvalidar" type="button" class="btn btn-block btn-danger" disabled="disabled">
                    <i class="fa fa-times"></i>
                    <span>Desvalidar</span>
                </button>
            </div>
            <div class="col-12 col-sm-6 col-md-2">
                <button id="Btn_Print" type="button" class="btn btn-block btn-success">
                    <i class="fa fa-print"></i>
                    <span>Imprimir</span>
                </button>
            </div>
            <div class="col-12 col-sm-6 col-md-2">
                <button id="Btn_P_Anti" type="button" class="btn btn-block btn-limpiar">
                    <i class="fa fa-flask"></i>
                    <span>Panel Antibiograma</span>
                </button>
            </div>
        </div>
    </div>

    <!-- Modales -->
    <div id="mdlLoading" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cargando</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-center">
                    <i class="fa fa-spinner fa-pulse fa-5x fa-fw"></i>
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
                        <strong>Contáctese con IrisLab para asistencia técnica.</strong>
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

    <div id="mdlLimit" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-sm">
            <div class="modal-content border-bar">
                <div class="modal-header text-center bg-bar">
                    <h4 class="modal-title w-100">Aviso</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <p data-status="none">El número de atención introducido no existe, por favor introduzca un número válido.</p>
                    <p data-status="left">No se han encontrado atenciones anteriores a la actualmente seleccionada, por favor introduzca un número existente.</p>
                    <p data-status="right">No se han encontrado atenciones anteriores a la actualmente seleccionada, por favor introduzca un número existente.</p>
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

    <div id="mdlAlert" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-md">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100"></h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
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

    <div id="mdlAudit" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Auditoría {name}</h4>
                </div>
                <div id="Dtt_Audit" class="modal-body pt-6 pb-6 text-left">
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

    <div id="mdlGraph" class="modal fade" data-backdrop="static" style="z-index:9999">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Historial de la Determinación</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-9" id="divGraph">
                        </div>
                        <div class="col-12 col-sm-12 col-md-3" id="divGraphData">
                        </div>
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

    <div id="mdlHistExam" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <div class="row w-100">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <h4 class="modal-title w-100">Valorización de Exámenes Paciente</h4>
                        </div>
                        <div class="col-1">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">
                                <i class="fa fa-times" aria-hidden="true" style="font-size: 20px"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                </div>
            </div>
        </div>
    </div>

    <div id="mdlHistPruebas" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <div class="row w-100">
                        <div class="col-2">
                            <button type="button" class="btn btn-warning" id="Btn_GraphAlt">
                                <i class="fa fa-line-chart"></i>
                                <span style="font-weight: 600">Graf</span>
                            </button>
                        </div>
                        <div class="col-8">
                            <h4 class="modal-title w-100">Valorización de Examen Paciente</h4>
                        </div>
                        <div class="col-2">
                            <button type="button" class="btn btn-danger" data-dismiss="modal" id="Btn_HistPruExit">
                                <i class="fa fa-chevron-left" aria-hidden="true" style="font-size: 20px"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="modal-body pt-6 pb-6">
                    <div class="text-center pt-5 pb-5">
                        <i class="fa fa-spinner fa-pulse fa-5x fa-fw"></i>
                        <h3 class="text-center mt-3">Cargando...</h3>
                    </div>
                    <div class="text-left" style="display: none; overflow: auto;">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlValidateError" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Aviso Validación</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <p>Se han encontrado parámetros obligatorios sin valor. Los siguientes Exámenes no pueden ser validados mientras tales parámetros no tengan valor asignado.</p>
                    <p>Los Parámetros obligatorios sin valor son los siguientes:</p>
                    <ul></ul>
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

    <div id="mdlResCodificados" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Opciones para tipo de Dato <small>Type of Data</small></h4>
                </div>
                <div class=" pt-6 pb-6 text-left">
                    <div class="modal-body row">
                        <div class="col-12">
                            <div class="form-group">
                                <label>Determinación:</label>
                                <input type="text" class="form-control" id="Txt_ResCod_Det" />
                            </div>
                        </div>
                        <div class="col-6">
                            <label>Descripción:</label>
                            <div class="mini-table">
                            </div>
                        </div>
                        <div class="col-6">
                            <label>Resultado:</label>
                            <textarea class="form-control" id="Txt_ResCod_Out"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_RC_New" class="btn">
                        <i class="fa fa-file-o" aria-hidden="true"></i>
                        <span>Nuevo</span>
                    </button>
                    <button type="button" id="Btn_RC_Add" class="btn btn-success" data-dismiss="modal">
                        <i class="fa fa-save" aria-hidden="true"></i>
                        <span>Guardar</span>
                    </button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlPanel" class="modal fade" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border-bar">
                <div class="modal-header bg-bar text-center">
                    <h4 class="modal-title w-100">Paneles de Antibiogramas</h4>
                </div>
                <div class="modal-body pt-6 pb-6 text-left">
                    <div class="row" id="dat_Ate">
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <table class="table table-hover table-striped table-iris" id="table_Cultivos">
                                <thead>
                                    <tr>
                                        <th>Código
                                        </th>
                                        <th>Descripción
                                        </th>
                                        <th>Fecha
                                        </th>
                                        <th>Usuario Validación
                                        </th>
                                        <th>Validado
                                        </th>
                                        <th>Impreso
                                        </th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <h4 class='w-100 text-center mb-3' style='color: #014b5d !important'>Panel Antibióticos</h4>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-5" style="height: 45vh; overflow: auto;">
                            <table class="table table-hover table-striped table-iris" id="table_No_Cargado">
                                <thead>
                                    <tr>
                                        <th>Panel Antibióticos
                                        </th>
                                        <th>Cargar
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-2">
                            <div class="row  text-center mb-3 mt-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar"><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white; min-width: 85.6px;" id="btn_Quitar"><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5" style="height: 45vh; overflow: auto;">
                            <table class="table table-hover table-striped table-iris" id="table_Cargado">
                                <thead>
                                    <tr>
                                        <th>Panel Antibióticos
                                        </th>
                                        <th>Quitar
                                        </th>
                                        <th>Folio
                                        </th>
                                        <th>Cultivo
                                        </th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btn_Guardar_Panel">
                        <i class="fa fa-save" aria-hidden="true"></i>
                        <span>Guardar</span>
                    </button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <i class="fa fa-check" aria-hidden="true"></i>
                        <span>Cerrar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
