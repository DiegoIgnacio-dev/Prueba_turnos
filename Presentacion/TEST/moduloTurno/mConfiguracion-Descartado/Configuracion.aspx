<%--<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Configuracion.aspx.vb" Inherits="Presentacion.Configuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

<script src="../mTurnoIngreso/turnoIngresoCheck.js"></script>
<script src="Configuracion.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">


     <div class="container-fluid card  text-light" id="formid" style="background-color:#006699; width:600px">
        <div class="card-header text-center">CONFIGURACIÓN DE MÓDULOS DE ATENCIÓN</div>
        <div class="card-body bg-light text-dark row row-cols-3">

            <!-- Vista de los 4 modulos a mostrar en pantalla-->

            <div class="card-header border-primary col-sm text-center">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox1"  value="1"/>
                    <label class="form-check-label" for="inlineCheckbox1">A  Atención General</label>
                </div>
            </div>

             <div class="card-header border-primary col-sm text-center">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox2"  value="1"/>
                    <label class="form-check-label" for="inlineCheckbox2">B  Atención Empresas</label>
                </div>
            </div>

             <div class="card-header border-primary col-sm text-center">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox3" value="1"/>
                    <label class="form-check-label" for="inlineCheckbox3">C Entrega de examenes</label>
                </div>
            </div>

             <div class="card-header border-primary col-sm text-center">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox4" value="1"/>
                    <label class="form-check-label" for="inlineCheckbox4">D Examen PCR</label>
                </div>
            </div>
          </div>
        <div class="card-footer bg-light text-dark row row-cols-3">
                      <button type="submit" class="btn btn-danger" id="updateCheck">
                                Activar/Desactivar
                      </button>
        </div>


    </div>
</asp:Content>--%>
