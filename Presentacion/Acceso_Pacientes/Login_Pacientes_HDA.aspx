<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login_Pacientes_HDA.aspx.vb" Inherits="Presentacion.Login_Pacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <!-- El commit del diablo dejó la cagaa -->
    <link href="/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../css/Iris_Css.css" rel="stylesheet" />

    <script src="/vendor/jquery/jquery.js"></script>
    <script src="/vendor/popper/popper.js"></script>
    <script src="/vendor/bootstrap/js/bootstrap.js"></script>
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="/js/moment.js"></script>
    <script src="/js/moment_es.js"></script>
    <script src="/js/RUT.js"></script>
    <script src="Login_Pacientes_HDA.js"></script>

<style>
        @media screen and (min-width: 600px) {
            body {
                background: url(/Imagenes/IMAGEN_IRISHIS.jpg);
            }
        }
        .flex-box {
            display: flex;
            display: -webkit-flex;
            flex-flow: column nowrap;
            width: 100%;
            min-height: 100vh;
            justify-content: center;
            align-items: center;
        }

            .flex-box > div {
                min-width: 200px;
                width: 60%;
                max-width: 450px;
                box-shadow: 0 0 6px 6px rgba(0, 0, 0, 0.3);
            }

            .flex-box > img {
                display: block;
                min-width: 200px;
                width: 60%;
                max-width: 450px;
                height: auto;
            }

        /*.flex-box > .alert {
                display: flex;
                display: -webkit-flex;
                flex-flow: row nowrap;
                justify-content: space-around;
                align-items: center;
            }

                .flex-box > .alert > i {
                    width: 32px;
                    margin: 0px;
                    padding: 0px;
                }

                .flex-box > .alert > p {
                    width: calc(100% - 36px - 40px);
                    margin: 0px;
                    padding: 0px;
                    text-align: justify;
                }*/

        input[type=text] {
            color: #495057 !important;
            background: #ffffff !important;
        }

        /*@media (max-width: 575.98px) {
            .flex-box > .alert {
                flex-flow: column nowrap;
                padding: 10px;
            }

                .flex-box > .alert > i {
                    margin-bottom: 5px;
                }

                .flex-box > .alert > p {
                    width: calc(100% - 20px);
                    margin: 0px;
                    padding: 0px;
                    text-align: center;
                }
        }*/

        .centerx {
            display: flex;
            display: -webkit-flex;
            flex-flow: column nowrap;
            justify-content: center;
            align-items: center;
        }

        #message {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            z-index: 999999999;
        }

        .inner-message {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <%--    <img src="../Imagenes/peñalolen2-2.jpg" style="height:200px; width:auto;"/>--%>

    <%-- <img src="/Imagenes/00_logo_holanda_full.png" id="imgx2"/>--%>

    <div id="message">
        <div style="padding: 5px;">
            <%--<div class="alert alert-danger inner-message">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                test error message
            </div>--%>
            <div id="errRUT_1" class="alert alert-danger inner-message text-center" role="alert" style="display: none;">
                <strong><i class="fa fa-exclamation-circle fa-fw"></i>RUT que ha ingresado no corresponde a un formato válido.</strong>
            </div>
            <div id="errRUT_2" class="alert alert-danger inner-message text-center" role="alert" style="display: none;">
                <strong><i class="fa fa-exclamation-circle fa-fw"></i>El RUT no puede quedar vacío.</strong>
            </div>
            <div id="errFolio" class="alert alert-danger inner-message text-center" role="alert" style="display: none;">
                <strong><i class="fa fa-exclamation-circle fa-fw"></i>El Campo N° de Atención no puede quedar vacío.</strong>
            </div>
            <div id="errNotFound" class="alert alert-danger inner-message text-center" role="alert" style="display: none;">
                <strong><i class="fa fa-exclamation-circle fa-fw"></i>No se ha encontrado el Paciente o la Atención ingresada.</strong>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row mt-3">
            <div class="col-lg-12 text-center centerx">
                <img src="/Imagenes/00_logo_holanda_full.png" style="height: auto; width: 400px; background-color: white" />
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <div class="card cardcito border-bar">
                    <div class="card-header bg-bar p-2">
                        <h4 class="text-center m-0">ACCESO PACIENTES</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <label>RUT:</label>
                                    <input type="text" id="Txt_RUT" class="form-control form-control-sm" placeholder="12.345.678-9" tabindex="1" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <label>N° Atención:</label>
                                    <input type="text" id="Txt_AteNum" class="form-control form-control-sm" placeholder="123456789" tabindex="2" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <label>Fecha:</label>
                                    <div class="input-group date">
                                        <input type="text" id="Txt_Date" class="form-control form-control-sm" readonly tabindex="3" />
                                        <span class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group text-sm-left mb-0">
                                    <button type="button" id="Btn_Login" class="btn btn-block btn-info" tabindex="4">
                                        <i class="fa fa-sign-in"></i>
                                        <span>Ingresar</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>

        <div class="row">
            <div class="col-12 text-center">
                <img src="../Imagenes/IrisLab%20Logo%20LARGOa.png" style="max-height: 150px" class="img-fluid" alt="Responsive image" />
            </div>
        </div>
    </div>

</body>
</html>
