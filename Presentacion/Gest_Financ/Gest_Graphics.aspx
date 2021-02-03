<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Gest_Graphics.aspx.vb" Inherits="Presentacion.Gest_Graphics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%@ OutputCache Location="None" NoStore="true"%>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/vendor/datatables/dataTables.bootstrap4.js"></script>

    <script src="/js/HighCharts.js"></script>
    <script src="/js/HighC_Exporting.js"></script>

    <link href="/css/WebForm2.css" rel="stylesheet" />
    <script src="/js/WebForm2.js"></script>

    <link href="Gest_Graphics.css" rel="stylesheet" />
    <script src="Gest_Graphics.js"></script>

    <script>
        //Redimensionamiento de la barra de botones inferior
        let toggler = () => {
            let width = window.innerWidth;

            if (width <= 991.98) {
                width -= 83;
            } else {
                if ($(".sidenav-toggled").length == 0) {
                    width -= 336;
                } else {
                    width -= 136;
                }
            }


            $(".btn_float").width(width)
        };

        $(document).ready(() => {
            toggler();

            $("#sidenavToggler").click(toggler);
            $(window).resize(toggler);
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="row main">
        <div class="col-12 col-sm-12 col-md-12 col-lg-6 p-2">
            <div class="card">
                <div class="card-body" id="graphAteProcBar">

                </div>
            </div>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-6 p-2">
            <div class="card">
                <div class="card-body" id="graphAteProcPie">

                </div>
            </div>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-6 p-2">
            <div class="card">
                <div class="card-body" id="graphAtePrevBar">

                </div>
            </div>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-6 p-2">
            <div class="card">
                <div class="card-body" id="graphAtePrevPie">

                </div>
            </div>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-6 p-2">
            <div class="card">
                <div class="card-body" id="graphExaProcPrevBar">

                </div>
            </div>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-6 p-2">
            <div class="card">
                <div class="card-body" id="graphExaProcPrevPie">

                </div>
            </div>
        </div>
    </div>

    <div class="btn_float">
        <div class="row">
            <div class="col-6 col-sm-6 col-md-2">
                <div class="form-group">
                    <label>Desde:</label>
                    <input type="text" class="form-control" id="txtDate1" />
                </div>
            </div>
            <div class="col-6 col-sm-6 col-md-2">
                <div class="form-group">
                    <label>Hasta:</label>
                    <input type="text" class="form-control" id="txtDate2" />
                </div>
            </div>
            <div class="col-4 col-sm-4 col-md-3">
                <div class="form-group">
                    <label>Procedencia:</label>
                    <select class="form-control" id="selProc"></select>
                </div>
            </div>
            <div class="col-4 col-sm-4 col-md-3">
                <div class="form-group">
                    <label>Previsión:</label>
                    <select class="form-control" id="selPrev"></select>
                </div>
            </div>
            <div class="col-4 col-sm-4 col-md-2">
                <button class="btn btn-success btn-block" id="btnRefresh">
                    <i class="fa fa-refresh" aria-hidden="true"></i>
                    <span>Recargar</span>
                </button>
            </div>
        </div>
    </div>

    <div class="modal fade" id="mdlError" tabindex="-1" role="dialog" aria-labelledby="Error" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5>Error</h5>
          </div>
          <div class="modal-body">
              <p>Se ha producido un Error <strong>en la ejecución actual</strong>. Comuníquese con irisLAB para asistencia técnica.</p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
                <i class="fa fa-times"></i>
                <span>Cerrar</span>
            </button>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
