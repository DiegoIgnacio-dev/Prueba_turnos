<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="mImpresion.aspx.vb" Inherits="Presentacion.mImpresion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <link rel="stylesheet" href="../../../css/TestTurno.css" />
    <script src="mImpresion.js"></script>
         <!-- Google Fonts-->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@500;800;900&display=swap" rel="stylesheet"/> 

    <!--#############################  -->
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card" id="PanelServicio">
        <!-- CABECERA DE LA PAGINA-->
        <div class="card-header text-center" id="title">BIENVENIDOS</div>

        <!--IMG LOGO IRIRSLAB-->

        <div class="row">
            <img src="../../../Imagenes/irislab_lateral.svg" id="img-logo"/>
        </div>
        <!--CONTENIDO DEL PANEL DE PRESENTACION-->
        <div class="card-body" id="cartaTicket">

            <!--SECCION DE VISUALIZACION DEL TURNO-->
            <div class="card" id="vistaTicket">

          </div>

            <div class="row">
                <h5 id="desc" style="">Seleccione La Atención Deseada</h5>
            </div>
            <div class="row" ><!-- dentro de un row se debe trabajar con col-->
                <!-- Generar los botones por jquery para asi poder generar los botons dependiendo del estado de cada modulo-->
                <div id="btn-group">
                    <div id="btn-General" class="btn"><img class="icon" src="../../../Imagenes/icon-test/ICON_Atención_FULL-02.svg"/></div>
                    <div id="btn-Empresa" class="btn"><img class="icon" src="../../../Imagenes/icon-test/ICON_Atención_FULL-03.svg"/></div>
                    <div id="btn-Examen" class="btn"><img class="icon" src="../../../Imagenes/icon-test/ICON_Atención_FULL-04.svg"/></div>
                    <div id="btn-PCR" class="btn"><img class="icon" src="../../../Imagenes/icon-test/ICON_Atención_FULL-05.svg" /></div>
               </div>
            </div>

        </div>
    </div>
    <!--Estilos Basicos del panel-->

</asp:Content>
