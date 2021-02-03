<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Costos.aspx.vb" Inherits="Presentacion.Costos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
     <script>
        //$(function () {
        //    $('.list-group-item').on('click', function () {
        //        $('.fa-chng', this)
        //          .toggleClass('fa-chevron-right')
        //          .toggleClass('fa-chevron-down');
        //    });
        //});
    </script>
    <style>
        @media screen and (min-width:992px) {
            .xmb-3 {
                margin-bottom: 1rem !important;
            }
        }

        .fa-minus, .fa-chevron-right, .fa-chevron-down {
            margin-right: .25rem;
        }

        .card > .list-group:first-child .list-group-item:first-child {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }

        .ttl {
            background-color: #00738e !important;
            color: white;
            border-top-right-radius: .25rem !important;
            border-top-left-radius: .25rem !important;
        }

        .subb > a:hover {
            background-color: #11819b;
            color: white;
        }

        .minn > a:hover, .minn0 > a:hover {
            background-color: #d1edf0;
            color: black;
        }

        .fa-minus {
            font-size: 12px;
        }

        .fa-chng {
            font-size: 14px;
        }

        .ttl:hover {
            color: white;
        }

        .subb > a {
            padding-left: 2em;
            background-color: #1d96b2;
            color: white;
        }

        .minn0 > a {
            padding-left: 2em;
            color: #212529;
        }

        .minn > a {
            padding-left: 3.5em;
            color: #212529;
        }


        .list-group.list-group-root {
            padding: 0;
            overflow: hidden;
        }

            .list-group.list-group-root .list-group {
                margin-bottom: 0;
            }

            .list-group.list-group-root .list-group-item {
                border-radius: 0;
                border-width: 1px 0 0 0;
            }

            .list-group.list-group-root > .list-group-item:first-child {
                border-top-width: 0;
            }

            .list-group.list-group-root > .list-group > .list-group-item {
                padding-left: 30px;
            }

            .list-group.list-group-root > .list-group > .list-group > .list-group-item {
                padding-left: 45px;
            }

        .list-group-item .glyphicon {
            margin-right: 5px;
        }

        

       

        

        .list-group.list-group-root .list-group-item {
            border-width: 1px 1px 1px 1px;
            border-color: #00738e !important;
        }
        /*//////////////////*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
     <div class="card border-bar">
        <div class="card-header bg-bar">
            <h4 class="text-center m-0"><i class="fa fa-check-square-o fa-fw"></i>Costos</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-4 col-md-3">

                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-1" class="list-group-item ttl"  style="background-color:#cf3d4c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-down"></i>Costos
                                </a></h5>
                            <div class="collapse show paddd minn0" id="item-1">
                                <a href="/IngresoCosto/InCo_TM.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Lugar TM</a>
                                <a href="/IngresoCosto/InCo_Prev.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Previsión</a>
                                <a href="/IngresoCosto/InCo_Med.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Médico</a>
                                <a href="/IngresoCosto/InCo_Ord.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Orden Ate</a>
                                <a href="/IngresoCosto/InCo_Usu.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Usuario</a>
                                <a href="/IngresoCosto/InCo_TP.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Forma de Pago</a>
                                <a href="/IngresoCosto/InCo_Area.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Área</a>
                                <a href="/IngresoCosto/InCo_Sec.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Ingreso vs Costo por Sección</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-3">

                </div>
            </div>
        </div>
    </div>
</asp:Content>
