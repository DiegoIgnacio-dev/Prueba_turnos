<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="revisionAtenciones.aspx.vb" Inherits="Presentacion.revisionAtenciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="revisionAtenciones.js"></script>
    <script src="HighCharts.js"></script>
    <script src="HighC_exporting.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        #card-header-main{
           background-color:#006699;
           color:white;
           font-size:1.8rem;
        }
        .card-count{
            background-color:#009ace;
            text-align:center;
            color:white;
        }
        #conteo{
            text-align:center;
            font-size:1.5rem;
            font-weight:700;
            color:#006699;
        }
        #hoy{
            text-align:center;
            font-size:1.5rem;
            font-weight:700;
            color:red;
        }
    </style>


    <div class="container">

        <div class="row">


            <!--Contruccion de la carta central-->
            <div class="col-12">

                <div class="card" style="max-width:250rem" >
                        <div class="card-header text-center mt-0 mb-4"id="card-header-main" >
                            Monitoreo de Atenciones
                        </div>
                    <div class="card-body">

                    

                    <div class="row">
                        <div class="col-2"></div>
                            <div class="col-lg-3">
                            <div class="input-group date" id="txt_Date01">
                                <input type="text"class="form-control" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="input-group date" id="txt_Date02">
                                <input type="text" class="form-control" readonly="true" placeholder="Hasta..." />
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" class="btn btn-primary" id="btn_Buscar">Buscar</button>
                        </div>
                        <div class="col-2"></div>
                    </div>

                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-4 mt-3">

                            <div class="card mt-5">
                                <div class="card-header card-count">
                                    Atenciones Totales:
                                </div>
                                <div class="card-body">
                                    <div id="conteo"></div>
                                </div>
                            </div>

                             <div class="card mt-5">
                                <div class="card-header card-count">
                                    Atenciones Actuales
                                </div>
                                <div class="card-body">
                                    <div id="hoy"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-8 col-md-8 col-sm-8">
                            <div id="Summary_Graph" style="margin-top:2rem"></div>
                        </div>
                    
                       </div>  
                    </div>
                </div><!--card-end-->
            </div>


            
        </div>


    </div>
</asp:Content>
