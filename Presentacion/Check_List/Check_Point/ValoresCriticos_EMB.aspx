<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="ValoresCriticos_EMB.aspx.vb" Inherits="Presentacion.ValoresCriticos_EMB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="ValoresCriticos_EMB.js"></script>
    <!--CSS del Form-->
    <style>
        #divToggle {
            width: 100%;
            height: 100%;
            display: flex;
            display: -webkit-flex;
            align-items: center;
            justify-content: flex-start;
            cursor: pointer;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -o-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

            #divToggle > i {
                padding-left: 15px;
                width: 72px;
                text-align: left;
            }

        .manito {
            cursor: pointer;
        }
    </style>

    <style>
        /*Small devices (tablets, 768px and up)*/
        @media (min-width: 576px) {
            #divToggle {
                margin-top: 19px;
            }
        }

        @media (min-width: 768px) {
            #divToggle {
                margin-top: 0px;
            }
        }

        /*Medium devices (tablets, 768px and up)*/
        @media (min-width: 992px) {
            #Btn_Search, #Btn_Gen {
                margin-top: 19px;
            }

            #divToggle {
                margin-top: 16px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="p-2">
        <div class="card border-bar mb-3">
            <div class="card-header bg-bar">
                <h4 class="m-0">Búsqueda de Resultados</h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-4 col-lg-2">
                                <label for="Txt_Date01">Desde:</label>
                                <div class='input-group date' id='Txt_Date01'>
                                    <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Desde..." />
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-4 col-lg-2">
                                <label for="Txt_Date02">Hasta:</label>
                                <div class='input-group date' id='Txt_Date02'>
                                    <input type='text' id="fecha3" class="form-control" readonly="true" placeholder="Hasta..." />
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <%--                            <div class="col-md mb-1">
                                <label for="Programa">Programa:</label>
                                <select id="Programa" class="form-control">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>--%>
                            <%--                            <div class="col-md mb-1">
                                <label for="Ddl_seccion">Sección:</label>
                                <select id="Ddl_seccion" class="form-control">
                                </select>
                            </div>--%>
                            <div class="col-md mb-4">
                                <label for="Ddl_Examen">Examen:</label>
                                <select id="Ddl_Examen" class="form-control">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-md mb-1">
                                <label for="Ddl_Prub">Prueba:</label>
                                <select id="Ddl_Prub" class="form-control">
                                    <option value="0">Seleccionar</option>
                                    <option value="0">Todos</option>
                                    <option value="1">Alto</option>
                                    <option value="2">Bajo</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md mb-1">
                                <label for="Ddl_Stat">Estado:</label>
                                <select id="Ddl_Stat" class="form-control">
                                </select>
                            </div>
                            <div class="col-md mb-1">
                                <label for="Ddl_resul">Resultados:</label>
                                <select id="Ddl_resul" class="form-control">
                                    <option value="1">Validados</option>
                                </select>
                            </div>

                            <div class="col-md mb-1">
                                <label for="Ddl_Proc">Procedencia:</label>
                                <select id="Ddl_Proc" class="form-control">
                                   
                                </select>
                            </div>

                            <div class="col-md mb-1">
                                <label for="Prevision">Prevision:</label>
                                <select id="Prevision" class="form-control">
                                   
                                </select>
                            </div>

                                                        <div class="col-12 col-sm-6 col-md-4 col-lg-2 p-1">
                                <button type="button" id="Btn_Search" class="btn btn-block btn-buscar text-center">
                                    <i class="fa fa-search" style="font-size: 1.5rem;"></i>
                                    <span>Buscar</span>
                                </button>
                            </div>
                            <div class="col-12 col-sm-6 col-md-4 col-lg-2 p-1">
                                <button type="button" id="Btn_Gen" class="btn btn-block btn-success text-center">
                                    <i class="fa fa-file-excel-o" style="font-size: 1.5rem;"></i>
                                    <span>Excel</span>
                                </button>
                            </div>
                        </div>
<%--                        <div class="row">

                        </div>--%>
                    </div>
                </div>
            </div>
        </div>

        <div class="card mt-2 border-bar" id="divTable01">
            <div class="card-header bg-bar">
                <h4 class="m-0">Tabla de Resultados</h4>
            </div>
            <div class="card-body">
                <div class="row" id="Id_Conte" style="margin-left: 1px; width: 100%;">

                    <div class="col-md-3 mb-1" style="margin-top: 15px;">
                        <label>Cant. Exámenes Niños:</label>
                    </div>
                    <div class="col-md-3 mb-1" style="margin-top: 15px;">
                        <label id="nino"></label>
                    </div>
                    <div class="col-md-3 mb-1" style="margin-top: 15px;">
                        <label>Cant. Exámenes Adultos:</label>
                    </div>
                    <div class="col-md-3 mb-1" style="margin-top: 15px;">
                        <label id="adulto"></label>
                    </div>

                </div>
                <h5><i class="fa fa-fw fa-list"></i>Resultados de la Búsqueda</h5>
                <div class="row text-center" id="Paciente">
                    <div id="Div_Tabla" style="width: 100%;" class="highlights"></div>
                </div>
            </div>
        </div>
    </div>

    <!--Modales-->
    <div id="mdlEmail" class="modal modal-sm">
        <div class="card">
            <div class="card-header text-center">
                <h4 class="m-0">Exportar</h4>
            </div>
            <div class="card-body pt-6 pb-6 text-left">
                <div class="form-group">
                    <label>Por favor introduzca su correo electrónico:</label>
                    <input type="text" id="Txt_Email" autocomplete="on" />
                </div>
            </div>
            <div class="card-footer text-right">
                <button type="button" id="Btn_Export" class="btn-success" disabled>
                    <i class="fa fa-check" aria-hidden="true"></i>
                    <span>Exportar</span>
                </button>
                <button type="button" class="btn-primary" data-dismiss="true">
                    <i class="fa fa-close" aria-hidden="true"></i>
                    <span>Cancelar</span>
                </button>
            </div>
        </div>
    </div>

    <div id="mdlEmail_2" class="modal modal-sm">
        <div class="card">
            <div class="card-header text-center">
                <h4 class="m-0">Exportar</h4>
            </div>
            <div class="card-body pt-6 pb-6 text-left">
                <p>El archivo Excel se está generando en 2do plano. Cuando el servidor termine de generar el archivo, éste será enviado al e-mail que indicó anteriormente.</p>
            </div>
            <div class="card-footer text-right">
                <button type="button" class="btn-primary" data-dismiss="true">
                    <i class="fa fa-check" aria-hidden="true"></i>
                    <span>Aceptar</span>
                </button>
            </div>
        </div>
    </div>
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%--  <div id="mdlError" class="modal">
        <div class="card">
            <div class="card-header text-center">
                <h2>ERROR</h2>
            </div>
            <div class="card-body pt-6 pb-6">
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
            <div class="card-footer text-right">
                <button type="button" class="btn-block btn-primary" data-dismiss="true">
                    <i class="fa fa-check" aria-hidden="true"></i>Aceptar
                </button>
            </div>
        </div>
    </div>--%>
</asp:Content>
