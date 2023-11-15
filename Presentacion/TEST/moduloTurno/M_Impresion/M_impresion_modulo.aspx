<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="M_impresion_modulo.aspx.vb" Inherits="Presentacion.M_impresion_modulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="M_Impresion_modulo_env.js"></script>
    <link rel="stylesheet" href="M_Impresio_Estilo.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div id="M_Impresion"></div>

    <%--<div class="card" style="width: 130px; border: none">
        <div class="card-body m-0 p-0">
            <div class="col-sm btn-Print-Div" style="background-image: url(img/GENERAL.svg)"></div>
        </div>
        <div class="card-footer text-center" style="border: none; background-color: transparent">
            <h5>Atención General</h5>
        </div>
    </div>--%>
<%--    <div class="card" style="width: 130px; border: none">
        <div class="card-body m-0 p-0" style="background-color: #006699; border-radius: 15px 15px 0px 0px;">
            <div class="col-sm btn-Print-Div-2" style="background-image: url(img/GENERAL.svg); padding: 0;"></div>
        </div>
    <div class="card-footer text-center" style="border: none; background-color: #006699; border-radius: 0px 0px 15px 15px; padding: 0.3rem; padding-top: 0;">
        <h5 style="color: white; font-weight: 700; margin: 0;">Atención General</h5>
    </div>
    </div>--%>
</asp:Content>
