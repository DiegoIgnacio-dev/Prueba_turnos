<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login_Pacientes_PLN.aspx.vb" Inherits="Presentacion.Login_Pacientes_PLN" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>

    <link href="/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <script src="/vendor/jquery/jquery.js"></script>
    <script src="/vendor/popper/popper.js"></script>
    <script src="/vendor/bootstrap/js/bootstrap.js"></script>
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="/js/moment.js"></script>
    <script src="/js/moment_es.js"></script>
    <script src="/js/RUT.js"></script>
    <script src="/Acceso_Pacientes/Login_Pacientes_PLN.js"></script>

    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="/css/Iris_Css.css" rel="stylesheet" />
    <style>
        @media screen and (min-width: 600px) {
            body {
                background: url(/Imagenes/IMAGEN_IRISHIS.jpg);
            }
        }

        input[type=text] {
            color: #495057 !important;
            background: #ffffff !important;
        }

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

    <div id="message">
        <div style="padding: 5px;">
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
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center">
                <img src="../Imagenes/logo_san_joaquin.png" style="max-height: 160px; width: auto; background-color: white;" class="img-fluid" alt="Responsive image" />
            </div>
            <div class="col-md-4 text-center centerx">
                <img src="../Imagenes/00_logo_holanda_full.png" style="height: auto; max-width: 270px; background-color: white" class="img-fluid" alt="Responsive image" />
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
                                        <i class="fa fa-sign-in fa-fw"></i>
                                        <span>Ingresar</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 text-center">
                <img src="../Imagenes/IrisLab%20Logo%20LARGOa.png" style="max-height: 150px" class="img-fluid" alt="Responsive image" />
            </div>
        </div>
    </div>

</body>
</html>
