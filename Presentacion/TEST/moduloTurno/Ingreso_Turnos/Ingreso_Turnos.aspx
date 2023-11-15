<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_Turnos.aspx.vb" Inherits="Presentacion.Ingreso_Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="Ingreso_Turnos.js"></script>
    <!--<script src="Ingreso_Turnos.js"></script>-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <style>
        #update{
        background-color: #006699;
        }
        #update:hover{
        background-color:#009ace;
        }

        #btn_config{
            background-color:#009ace
        }
        #btn_config:hover{
           background-color: #006699;
        }
    </style>
    <div class="row">
        <!-- Cada Modulo debera ser independiente de la letra que se este trabajando y seria determinado por 
        los usuarios (personal de atencion en el momento)-->
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="card" style="max-width: 250rem">
                <div class="card-header text-light text-center" style="background-color: #006699">
                    <h4 class="m-0">Módulo de Atención</h4>
                </div>
                <div class="card-body">
                    <div class="row mb-2">
                        <div class="col-sm">
                            <label for="exampleFormControlSelect1" style="font-weight: 200">Seleccione el Módulo</label>
                            <select class="form-control" id="moduloAtencion">
                                <option value="0">Seleccione El Módulo </option>
                            </select>
                        </div>
                        <div class="col-sm">
                            <label for="exampleFormControlSelect2" style="font-weight: 200">Seleccione el tipo de Atención</label>
                            <select class="form-control" id="tipoAtencion">
                                <option value="0">Seleccione uno... </option>
                            </select>
                        </div>
                    </div>
                    <div class="row mb-4">

                        <div class="col-sm">
                            <button type="button" class="btn btn-block text-light" id="update">
                                Actualizar Turno
                            </button>

                            <button type="button" class="btn btn-block text-light">
                                <a href="../../revisionAtenciones/revisionAtenciones.aspx">
                                    Mantenedor
                                </a>
                                
                            </button>
                        </div>

                        <div class="col-sm">
                             <button type="button" class="btn btn-block text-light" id="btn_config">
                                Repetir llamado
                            </button>
                        </div>
                        <div class="col-sm">
                            <div id="TurnoVista" class="col-sm" style="margin: 0 auto"></div>
                        </div>
                        <div class="col-sm">
                            <div id="UltimaImpr" class="col-sm" style="margin: 0 auto"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-2"></div>
        <div class="form" id="Box">
        </div>

        <br />
        <div id="config" style="display: none;">
            <div class="card card-header text-center text-light" style="background-color: #006699">CONFIGURACIÓN DE MÓDULOS DE ATENCIÓN</div>
            <div class="card-body text-dark row row-cols-3" id="check-group">

                <!-- Vista de los 4 modulos a mostrar en pantalla-->

                <div class="card-header text-secondary border-primary col-sm text-center">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox1" value="1" name="chk_Mod_Ate" />
                        <label class="form-check-label" for="inlineCheckbox1">A  Atención General</label>
                    </div>
                </div>

                <div class="card-header text-secondary border-primary col-sm text-center">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox2" value="2" name="chk_Mod_Ate" />
                        <label class="form-check-label" for="inlineCheckbox2">B  Atención General</label>
                    </div>
                </div>

                <div class="card-header text-secondary border-primary col-sm text-center">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox3" value="3" name="chk_Mod_Ate" />
                        <label class="form-check-label" for="inlineCheckbox3">C Atencion General</label>
                    </div>
                </div>

                <div class="card-header text-secondary border-primary col-sm text-center">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox4" value="4" name="chk_Mod_Ate" />
                        <label class="form-check-label" for="inlineCheckbox4">D Atencion A Empresas</label>
                    </div>
                </div>
                <div class="card-header text-secondary border-primary col-sm text-center">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox5" value="5" name="chk_Mod_Ate" />
                        <label class="form-check-label" for="inlineCheckbox5">E Entrega de Examenes</label>
                    </div>
                </div>
                <div class="card-header text-secondary border-primary col-sm text-center">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox6" value="6" name="chk_Mod_Ate" />
                        <label class="form-check-label" for="inlineCheckbox6">F  Examen PCR</label>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-light text-dark row row-cols-3">
                <button type="submit" class="btn btn-danger" id="updateCheck">
                    Activar/Desactivar
                </button>
            </div>
        </div>
    </div>
</asp:Content>
