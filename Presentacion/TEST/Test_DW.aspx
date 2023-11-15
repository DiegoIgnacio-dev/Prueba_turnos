<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Test_DW.aspx.vb" Inherits="Presentacion.Test_DW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="Test_DW.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <h3 class="text-center mb-3">Búsqueda de Productos</h3>
    <div class="row">
        <div class="col-lg-4">
            <div class="input-group date" id="txt_Date01">
                <input type="text"class="form-control" readonly="true" placeholder="Hasta..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="input-group date" id="txt_Date02">
                <input type="text" class="form-control" readonly="true" placeholder="Hasta..." />
                <span class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </span>
            </div>
        </div>
        <div class="col-lg-4">
            <button type="button" class="btn btn-primary" id="btn_Buscar">Buscar</button>
        </div>
    </div>

    <div class="row mt-3">
        <div class="col-lg-12" id="Div_Tabla">
        </div>
    </div>
</asp:Content>
