<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Gerencia.aspx.vb" Inherits="Presentacion.Gerencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        
        $(function () {
            $('.list-group-item').on('click', function () {
                $('.fa-chng', this)
                  .toggleClass('fa-chevron-right')
                  .toggleClass('fa-chevron-down');
            });
        });
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
            <h4 class="text-center m-0"><i class="fa fa-check-square-o fa-fw"></i>Menú Gerencial</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color:#cf3d4c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Gerencia
                                </a></h5>
                            <div class="paddd minn0" id="item-1">
                                <a href="/Gest_Financ/Estadisticas/Detalle/LugarTM_Det.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Pacientes, Exámenes y precios por previsión y lugar de Tm</a>
                                <a href="/Gest_Financ/Administracion/List_Ate_Prev_and_Prog_Ag_M.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Atenciones por previsión</a>
                             <%--   <a href="/Gest_Financ/Administracion/List_Ate_Prev_and_Prog_Ag_M_Val.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Atenciones por Previsión y Programa VALIDADOS</a>    --%>       
                                <a href="/Gest_Financ/Estadisticas/Resumen/Resumen_Prev_Prog_Subp.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Atenciones por Programa, previsión y procedencia</a>     
                                 <a href="/Gest_Financ/Estadisticas/Resumen/Res_Filtrados.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Resultados (un parámetro)</a>      
                                 <a href="/Gest_Financ/Convenio.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Test Fuera Convenio</a>    
                                <a href="/Gest_Financ/Mant_Precios_Conv.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Mant. Precio Convenio</a>     
                                <a href="/Gest_Financ/Estadisticas/Multiple/Prev_TM_Exa_Mult_TCMD_New.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Resumen general de exámenes realizados</a>         
                                <a href="/Gest_Financ/Estadisticas/Resumen/Prevision_Sum_Ger.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Resumen Previsión-Procedencia</a>      
                                <a href="/Check_List/Check_point/Rel_Est_Exam.aspx" class="list-group-item">                 
                                    <i class="fa fa-fw fa-minus"></i>Check Estadísticas</a>
                                <a href="/Check_List/Rev_Deter_Exa_EMB_Trans.aspx" class="list-group-item">                 
                                    <i class="fa fa-fw fa-minus"></i>Resultados Transmitidos</a>
                                <a href="/Check_List/Rev_Deter_Exa_EMB_Trans_2.aspx" class="list-group-item">                 
                                    <i class="fa fa-fw fa-minus"></i>Resultados Transmitidos (Resumen)</a>
                            </div>
                        </div>
                    </div>
                </div>
<%--                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-2" class="list-group-item ttl" data-toggle="collapse" style="background-color:#923b6c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Cantidad Exámenes
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-2">
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_TOT.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes Totales</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_AREA.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes por Area de Trabajo</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_SECC.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes por Sección</a>
                                <a href="/Reporte/Laboratorio/REP_LAB_CANT_EXA_ARE_SECC.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Cantidad de Exámenes Area y Sección</a>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>



</asp:Content>
