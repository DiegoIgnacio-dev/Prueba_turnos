<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ExamedInicio/masterPage.Master" CodeBehind="reservarHora_TM.aspx.vb" Inherits="ExamedInicio.reservarHora_TM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>


    <style>
        .loader {
            z-index: 1;
            width: 100%;
            height: 100%;
            position: fixed;
            background-color: #00000054;
            left: 0px;
            top: 0px;
            text-align: center;
            display: none;
        }

        .page-header {
            border-bottom: 1px solid #fff;
        }

        .bg-exa {
            background-color: white !important;
            border-bottom: 1px #009639 solid !important;
            color: #009639 !important;
            border-radius: unset;
        }

        .border-exa {
            border: 1px #009639 solid !important;
            border-radius: unset;
        }

        .pt-05 {
            padding-top: 0.5rem;
        }

        .color-exa {
            color: #009639 !important;
        }



        .inputfile {
            width: 0.1px;
            height: 0.1px;
            opacity: 0;
            overflow: hidden;
            position: absolute;
            z-index: -1;
        }



            .inputfile + label {
                cursor: pointer; /* "hand" cursor */
            }
    </style>

    <div class="container" style="margin-top: 10px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="progress progress-striped active">
                    <div class="progress-bar progress-bar-success" role="progressbar"
                        aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"
                        style="width: 25%">
                        <span class="sr-only">40% completado (éxito)</span>
                        <h5 class="pt-05">Paso 1: Busque Laboratorio</h5>
                    </div>
                    <div class="progress-bar progress-bar-info" role="progressbar"
                        aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"
                        style="width: 25%">
                        <span class="sr-only">40% completado (éxito)</span>
                        <h5 class="pt-05">Paso 2: Seleccione hora disponible</h5>
                    </div>
                    <div id="barra1" class="progress-bar progress-bar-warning" role="progressbar"
                        aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"
                        style="width: 0%">
                        <span class="sr-only">40% completado (éxito)</span>
                        <h5 class="pt-05">Paso 3: Solicite su hora</h5>
                    </div>
                </div>

                <div class="panel panel-default border-exa">
                    <div class="panel-heading bg-exa text-center" style="padding: 10px 20px;">
                        <h2><i class="fa fa-plus-square" style="color: #009639;"></i>Toma de Muestra Domiciliaria</h2>
                        <div class="pull-right">
                            <div class="btn-group">
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" style="padding: 0">
                        <div class="loader">
                            <img src="/ExamedInicio/ExamedMedico/img/loadingPDF_2.gif" style="margin-top: 20%;" />
                        </div>


                        <div class=" well" style="border: 1px solid #fff; -webkit-box-shadow: none;" id="datosConfimar" runat="server">


                            <%--MODAL DE INICIO DE SESSION--%>
                            <div class="modal fade" id="ModalSession" tabindex="-1" role="dialog" aria-labelledby="ModalSession" aria-hidden="true">
                                <div class="modal-dialog" style="z-index: 10000; width: 400px;">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <div class="login-panel panel panel-default" id="login">
                                                <div class="panel-heading">
                                                    <i class="fa fa-sign-in" style="color: #31708f"></i>Inicio de Sesion <strong>Paciente</strong>
                                                </div>
                                                <div class="panel-body" style="text-align: center" id="">
                                                    <span><i class="fa fa-user fa-5x" style="color: #31708f"></i></span>
                                                    <div class="col-lg-12">
                                                        <label for="chkRutlog" style="margin-right: 1rem;">
                                                            <input checked="checked" type="radio" id="chkLogRut" name="chkLogRut" />
                                                            Con Rut
                                                        </label>
                                                        <label class="chklog" style="margin-right: 1rem;">
                                                            <input type="radio" id="chkLogPasaport" name="chkLogRut" />
                                                            Con Pasaporte o Dni.
                                                        </label>
                                                    </div>
                                                    <input required="required" onblur="javascript:return Rut2(document.getElementById('RUT').value)" id="RUT" class="form-control rut" placeholder="Rut" />
                                                    <input required="required" id="txDni" class="form-control" style="display: none" placeholder="pasaporte / DNI" />
                                                    <br />
                                                    <input placeholder="Contraseña" id="txContraseña" class="form-control " type="password" />
                                                    <br />
                                                    <label id="text_pass" style="display: none">Usuario o Contraseña incorrecta</label>
                                                    <label class="btn btn-lg btn-primary btn-block" onclick="Login_agendamiento()">Iniciar Sesión </label>

                                                    <script>
                                                        $("input[name='chkLogRut']").click(function () {
                                                            if ($("#chkLogRut").is(":checked")) {
                                                                //con rut
                                                                $("#RUT").show(); // contenedor
                                                                $("#txDni").val("").hide(); //input

                                                            } else {
                                                                //sin  rut
                                                                $("#txDni").show(); // contenedor
                                                                $("#RUT").val("").hide(); //input
                                                            }
                                                        });
                                                    </script>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer" style="border-radius: 6px; padding: 8px 20px 8px; margin-top: 0px;">
                                            <small style="float: left; opacity: 1">Para mas información visita: <a runat="server" id="A1">www.examed.cl</a></small>
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>




                            <%--<label style="font-weight: 600">Nombre: </label>--%>
                            <div class="row">
                                <div class="col-md-5 text-center">
                                    <img style="width: 140px; height: auto;" src="" id="imgPerfil" runat="server" />
                                    <div style="text-align: center;">
                                        <span class="rating-avg-large" style="margin-top: 10px"><span class='p100'></span></span>
                                    </div>
                                    <h3>
                                        <label runat="server" id="lblNombre" class="color-exa"></label>
                                    </h3>
                                    <h5 style="color: rgb(0, 0, 0)">
                                        <label runat="server" id="lblEspe" class="color-exa"></label>
                                    </h5>
                                </div>
                                <div class="col-md-7 color-exa" style="font-size: 18px">
                                    <br />
                                    <h3>Fecha Agendamiento:
                                        <span runat="server" id="lblFecha" class="lblFecha" style="padding-bottom: 1.5rem; font-weight: 600"></span>
                                    </h3>
                                    <br />
                                    <%--<h4>Hora Agendamiento: 
                                        <span runat="server" id="lblHora" class="lblHora" style="padding-bottom: 1.5rem; font-weight: 600"></span>
                                        </h4>
                                        <br />--%>
                                    <h3>Laboratorio: 
                                        <span runat="server" id="lblCentroMedico" style="padding-bottom: 1.5rem; font-weight: 600"></span>
                                    </h3>
                                    <br />
                                    <h3>Dirección: 
                                        <span runat="server" id="lblDireccion" style="padding-bottom: 1.5rem; font-weight: 600"></span>
                                        <br />
                                        <a data-toggle="modal" data-target="#ModalUbicacion" onclick="CargarMaps()">Ver Mapa</a>
                                    </h3>
                                    <br />
                                    <h3>Precio: 
                                        <span runat="server" id="lblPrecio" style="margin-top: -5px; margin-bottom: -5px; font-weight: 600"></span>
                                    </h3>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6" id="det_user" style="display: none">

                                    <h3 class="page-header"><i class="fa fa-user"></i>Paciente
                                    </h3>
                                    <div class="panel panel-default">
                                        <div style="cursor: pointer; padding: 10px 10px" class="panel-heading collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false">

                                            <i class="fa fa-plus"></i>
                                            Ver Datos (<strong id="Nom_pac_session"></strong>)
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <!-- ----------------------------------------------------------------------------------------- -->
                                                    <div id="pac_ident">
                                                        <strong class="strong1">Rut:</strong>
                                                        <input type="text" class="form-control input-sm " id="pac_rut_u" />
                                                    </div>


                                                    <strong class="strong1">Nombres:</strong>
                                                    <input type="text" class="form-control input-sm " id="pac_nom_u" />
                                                    <strong class="strong1">Apellidos:</strong>
                                                    <input type="text" class="form-control input-sm " id="pac_ape_u" />

                                                    <strong class="strong1">Fecha de Nacimiento:</strong>
                                                    <input type="date" class="form-control input-sm " id="pac_fcnac_u" />
                                                </div>
                                                <div class="col-lg-6">

                                                    <strong class="strong1">Sexo:</strong>
                                                    <select class="form-control input-sm" id="cbSexo_u">
                                                        <option disabled="disabled">Seleccione una opción</option>
                                                        <option value="1">Masculino</option>
                                                        <option value="2">Femenino</option>
                                                    </select>
                                                    <strong class="strong1">Direccion:</strong>
                                                    <input type="text" class="form-control input-sm " id="pac_dir_u" />
                                                    <strong class="strong1">Telefono:</strong>
                                                    <input type="text" class="form-control input-sm " id="pac_tel_u" />
                                                    <strong class="strong1">Movil:</strong>
                                                    <input type="text" class="form-control input-sm " id="pac_movil_u" />
                                                    <strong class="strong1">Correo:</strong>
                                                    <input type="text" class="form-control input-sm " id="pac_email_u" />
                                                </div>
                                                <!-- ________________________________________________________________________________________________ -->
                                                <br />
                                                <label class="btn btn-primary" onclick="ActualizarDatos()">Actualizar Datos</label>
                                                <br />
                                                <div visible="false" style="margin-bottom: 0px" class="alert alert-success" id="divDatosActualizados" runat="server">
                                                    Los datos del paciente fueron <strong>actualizados.</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6 " style="padding: 2rem">
                                    <%--  <div class="col-lg-4">--%>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label for="chkYes">
                                                <input checked="checked" type="radio" id="chkYes" name="chkPassPort" />
                                                La reserva es para mí.
                                            </label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label for="chknBaby">
                                                <input type="radio" id="chkBaby" name="chkPassPort" />
                                                Recien Nacido.
                                            </label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label for="chkNo" class="ini_session">
                                                <input type="radio" id="chkNo" name="chkPassPort" />
                                                La reserva es para otra persona.
                                            </label>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="modal fade" id="ModalUbicacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                <div class="modal-dialog" style="z-index: 100000; width: 80%;">
                                    <div class="modal-content border-exa">
                                        <div class="modal-header bg-exa">
                                            <div class="row">
                                                <div class="col-lg-5">
                                                    <img src="/ExamedInicio/iconos/LOGO_EXAMED-01.png" style="text-align: center; width: 125px">
                                                </div>
                                                <div class="col-lg-7" style="margin-top: 2rem">
                                                    <h3 id="mdl_ubi" runat="server"></h3>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-body">
                                            <iframe id="Iframe2" width="100%" height="400" frameborder="0" style="border: 0" src="https://www.google.com/maps/embed/v1/place?q=Alameda%201660,%20Estación%20Central&amp;key=AIzaSyBY3rF1KM406RnMUqPgmAEpTp92kadPDi0" allowfullscreen=""></iframe>
                                        </div>
                                        <div class="modal-footer" style="border-radius: 6px; padding: 8px 20px 8px;">
                                            <button type="button" class="btn btn-primary cerrar" data-dismiss="modal">Cerrar</button>
                                            <%--  <button type="button" class="btn btn-primary">Save changes</button>--%>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>



                            <%--USUARIO  NO LOGEADO--%>
                            <div class="sin_user" style="display: none">
                                <div class="row pac_sin_session" style="border: 1px solid rgb(203, 209, 209); padding: 2rem; border-radius: 4px; margin-bottom: 1rem;">
                                    <div class="row" style="margin-bottom: 2rem">
                                        <div class="col-lg-5">
                                            <h3 style="color: rgb(0, 0, 0)">Datos Paciente</h3>
                                        </div>

                                        <div class="col-lg-3">
                                            <input required="required" onblur="javascript:return Rut(document.getElementById('ContentPlaceHolder1_textRut').value)" id="textRut" class="form-control Rut_ext" runat="server" placeholder="RUT" style="margin-top: 0" />
                                            <input id="pac_pasaporte" class="form-control pac_pasaporte" runat="server" placeholder="pasaporte" style="display: none" />

                                        </div>
                                        <div class="col-lg-4 text-center">
                                            <label for="chkRut" style="margin-right: 1rem;">
                                                <input checked="checked" type="radio" id="chkRut" name="chkRut" />
                                                Con Rut
                                            </label>
                                            <label class="chkextra" style="display: none; margin-right: 1rem;">
                                                <input type="radio" id="chkPasaporte" name="chkRut" />
                                                Con Pasaporte o Dni.
                                            </label>
                                            <label for="SinDin_rut" class="chkSinRutDni" style="margin-right: 1rem;">
                                                <input type="radio" id="chkSinDni" name="chkRut" />
                                                Sin Rut, Pasaporte o Dni.
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Nombre: *</strong>
                                        <input required="required" type="text" runat="server" placeholder="" id="pac_nomb" class="form-control pac_nomb" />
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Apellido: *</strong>
                                        <input required="required" type="text" placeholder="" id="pac_ape" class="form-control pac_ape" runat="server" />
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Fecha Nacimiento: *</strong>
                                        <input required="required" type="date" class="form-control nac_pac" id="nac_pac" runat="server" />
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Sexo *</strong>
                                        <select required="required" runat="server" id="Sexo_pac" class="form-control Sexo_pac">
                                            <option value="1" selected="selected">Masculino</option>
                                            <option value="2">Femenino</option>
                                        </select>
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Nacionalidad: *</strong>
                                        <select required="required" runat="server" id="nacionalidad_pac" class="form-control nacionalidad_pac">
                                            <option value="1" selected="selected">Chilena</option>
                                            <option value="2">Argentina</option>
                                            <option value="3">Colombiana</option>
                                        </select>
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Teléfono: *</strong>
                                        <%--    <input required="required" runat="server" class="form-control fono_pac" type="number" onkeydown="return jsDecimals(event)" id="Number1" />--%>
                                        <input required="required" runat="server" class="form-control fono_pac" type="number" id="fono_pac" onkeypress='return validaNumericos(event)' />
                                    </div>
                                    <div class="col-md-4">
                                        <strong>Email: *</strong>
                                        <input required="required" runat="server" class="form-control Email_pac" type="email" id="Email_pac" />
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Prevision: *</strong>
                                        <select required="required" runat="server" id="Select1" class="form-control previsiones_pac">
                                            <option value="1" selected="selected">Particular</option>
                                        </select>
                                    </div>
                                      <div class="col-md-4">
                                         <strong>Región:</strong>
                                        <select id="cbxRegion" class="form-control"></select>
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Comuna:</strong>
                                        <select id="cbxComuna" class="form-control"></select>
                                    </div>
                                     <div class="col-md-4">
                                        <strong>Direccion:</strong>
                                        <input id="direc_pac" required="required" type="text" class="form-control" placeholder="ej: Manuel Bulnes 667, Osorno"></input>
                                    </div>
                                    <div class="col-md-4">
                                        <strong>Motivos de la Consulta:</strong>
                                        <input type="text"  class="form-control" id="mot_pac_externo"></input>
                                    </div>
                                    <div class="col-lg-1 text-center" style="margin-top: 1rem; margin-bottom: 2rem">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <input type="file" name="file1" id="file1" class="inputfile"/>
                                                <label for="file1" class="btn btn-primary btn-lg" style="background-color: transparent; color: green; border: transparent;">
                                                    <i class="fa fa-paperclip fa-2x" aria-hidden="true"></i>
                                                     </label>
                                                <%--<label" class="btn btn-primary btn-lg" style="background-color: #1f4399;border:1px #1f4399 solid" onclick="PRUEBA_ORDER_MED()"> Prueba Orden Médica</label>--%>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-3 text-center ">
                                        <%-- <asp:Button formnovalidate="formnovalidate" Text="Solicitar hora" runat="server" ID="btn_sinRegistroExt" Style="margin-top: 10px; border-radius: 10px;" CssClass="btn btn-primary btn-lg" OnClick="btn_sinRegistroExt_Click" />--%>
                                        <button type="button" class="btn btn-primary form-control" onclick="GUARDA_PACIENTE_EXTERNO_SIN_SESSION()" style="margin-top: 3rem"><i class="fa fa-floppy-o" aria-hidden="true"></i> Solicitar Hora</button>
                                    </div>
                                    <div class="col-lg-12 text-center">
                                        <img src="#" id="ImgMed" style="max-width: 15%; border: 1px #009639 solid; padding: 1rem" hidden />
                                    </div>
                                </div>
                            </div>
                            <%--RECIEN NACIDO--%>
                            <div id="divBaby" class="row" style="display: none; border: 1px solid rgb(203, 209, 209); padding: 2rem; border-radius: 4px; margin-bottom: 1rem;">

                                <div class="row" style="margin-bottom: 2rem">
                                    <div class="col-lg-5">
                                        <h3>Datos Paciente</h3>
                                    </div>
                                    <div class="col-lg-3">
                                        <input placeholder="rut materno o paterno" onblur="javascript:return Rut3(document.getElementById('ContentPlaceHolder1_rut_padres').value)" runat="server" class="form-control rut_padres" type="text" id="rut_padres" style="display: none; margin-top: 0;" />
                                        <input placeholder="rut recien nacido" onblur="javascript:return Rut4(document.getElementById('ContentPlaceHolder1_rut_bebe').value)" runat="server" class="form-control rut_bebe" type="text" id="rut_bebe" style="margin-top: 0;" />

                                    </div>
                                    <div class="col-lg-4 text-center">
                                        <label for="" style="margin-right: 1rem;">
                                            <input checked="checked" type="radio" id="chkBebe" name="chkBaby" />
                                            Rut Recien Nacido *
                                        </label>
                                        <label for="" style="margin-right: 1rem;">
                                            <input type="radio" id="chkPadres" name="chkBaby" />
                                            Rut padres *
                                        </label>
                                    </div>
                                            </div>

                                <div class="col-md-3">
                                    <strong>Nombre Paciente: *</strong>
                                    <input required="required" runat="server" class="form-control nom_bb" type="text" id="nom_bb" />
                                </div>
                                <div class="col-md-3">

                                    <strong>Apellido Paciente: *</strong>
                                    <input required="required" runat="server" class="form-control ape_bb" type="text" id="ape_bb" />
                                </div>
                                <div class="col-md-2">
                                    <strong>Fecha de Nacimiento: *</strong>
                                    <input required="required" runat="server" class="form-control fc_nac_bb" type="date" id="fc_nac_bb" />
                                </div>
                                <div class="col-md-2">
                                    <strong>Sexo: *</strong>
                                    <select required="required" runat="server" id="sexo_bb" class="form-control sexo_bb">
                                        <option value="1" selected="selected">Masculino</option>
                                        <option value="2">Femenino</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <strong>Teléfono: *</strong>
                                    <input required="required" runat="server" class="form-control tel_bb" type="text" id="tel_bb" />
                                </div>
                                <div class="col-md-4">
                                    <strong>Email: *</strong>
                                    <input required="required" runat="server" class="form-control email_bb" type="email" id="email_bb" />
                                </div>
                                <div class="col-md-3">
                                    <strong>Previsión (Partena o Materna): *</strong>
                                    <select required="required" runat="server" id="Select2" class="form-control prevision_bb">
                                        <option value="1" selected="selected">PARTICULAR</option>
                                    </select>
                                </div>
                                <div class="col-md-3">
                                    <strong>Región:</strong>
                                    <select id="cbxRegion_bb" class="form-control"></select>
                                </div>
                                <div class="col-md-2">
                                    <strong>Comuna:</strong>
                                    <select id="cbxComuna_bb" class="form-control"></select>
                                </div>
                                <div class="col-md-4">
                                    <strong>Direccion:</strong>
                                    <input id="direc_pac_bb" required="required" type="text" class="form-control" placeholder="ej: Manuel Bulnes 667, Osorno"></input>
                                </div>
                                <div class="col-md-4">
                                    <strong>Motivos de la Toma de Muestra: *</strong>
                                    <input runat="server" class="form-control obs_bb" id="obs_bb"></input>
                                   
                                </div>
                                <div class="col-lg-1 text-center" style="margin-top: 1rem; margin-bottom: 2rem">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <input type="file" name="file2" id="file2" class="inputfile" />
                                            <label for="file2" class="btn btn-primary btn-lg" style="background-color: transparent; color: green; border: transparent;">
                                                <i class="fa fa-paperclip fa-2x" aria-hidden="true"></i>
                                            </label>
                                        </div>

                                    </div>
                                </div>
                               <div class="col-lg-3 text-center" style="margin-top: 2rem">
                                    <button type="button" class="btn btn-primary form-control" onclick="GRABAR_DATOS_PACIENTE_RECIEN_NACIDO()"><i class="fa fa-floppy-o" aria-hidden="true"></i> Solicitar Hora</button>
                               </div>
                                <div class="col-lg-12 text-center">
                                    <img src="#" id="ImgMed2" style="max-width: 15%; border: 1px #009639 solid; padding: 1rem" hidden />
                                </div>
                            </div>
                            <%--USUARIO  LOGEADO --%>
                            <div id="user_reg" style="display: none">
                                <%-- RESERVA PARA OTRO --%>
                                <div>
                                    <div id="divOtro" style="border: 1px solid rgb(203, 209, 209); padding: 2rem; border-radius: 4px; margin-bottom: 1rem; display: none;">
                                        <div class="row" style="margin-bottom: 2rem">
                                            <div class="col-lg-5">
                                                <h3>Datos Paciente</h3>
                                            </div>
                                            <div class="col-lg-3">
                                                <input required="required" runat="server" style="margin: 0" onblur="javascript:return Rut_Ext_ses(document.getElementById('ContentPlaceHolder1_Text2').value)" class="form-control txtRut_ses" type="text" id="Text2" placeholder="Rut Paciente" />

                                                <input required="required" runat="server" style="display: none; margin: 0" class="form-control txtPasaporte_ses" type="text" id="Text1" placeholder="Pasaporte o Dni" />

                                            </div>
                                            <div class="col-lg-4 text-center">
                                                <label for="chkRut" style="margin-right: 1rem;">
                                                    <input checked="checked" type="radio" id="chkRut_Ses" name="chkRut_Ses" />
                                                    Con Rut
                                                </label>
                                                <label class="chkextra_ext" style="display: none; margin-right: 1rem;">
                                                    <input type="radio" id="chkPasaporte_Ses" name="chkRut_Ses" />
                                                    Con Pasaporte o Dni.
                                                </label>
                                                <label for="SinDin_rut" class="chkSinRutDni" style="margin-right: 1rem;">
                                                    <input type="radio" id="chkSinDni_Ses" name="chkRut_Ses" />
                                                    Sin Rut, Pasaporte o Dni.
                                                </label>
                                            </div>
                                        </div>
                                        <%--<div>
                                            
                                        </div>
                                        <div class="col-md-6">
                                            </div>--%>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>Nombre Paciente: *</label>
                                                <input required="required" runat="server" class="form-control txNombre" type="text" id="txNombre" />
                                            </div>
                                            <div class="col-md-3">
                                                <label>Apellido Paciente: *</label>
                                                <input required="required" runat="server" class="form-control txApe" type="text" id="txApe" />
                                            </div>
                                            <div class="col-md-2">
                                                <label>Fecha de Nacimiento: *</label>
                                                <input required="required" runat="server" class="form-control txFecha" type="date" id="txFecha" />
                                            </div>
                                            <div class="col-md-2">
                                                <label>Sexo: *</label>
                                                <select required="required" runat="server" id="txSexo" class="form-control txSexo_ext">
                                                    <option value="1" selected="selected">Masculino</option>
                                                    <option value="2">Femenino</option>
                                                </select>
                                            </div>
                                            <div class="col-md-2">
                                                <label>Nacionalidad: *</label>
                                                <select required="required" runat="server" id="nacionalidad_ext" class="form-control nacionalidad_ext">
                                                    <option value="1" selected="selected">Chilena</option>
                                                    <option value="2">Argentina</option>
                                                    <option value="3">Brazil</option>
                                                    <option value="4">Uruguay</option>
                                                </select>
                                            </div>
                                            <div class="col-md-3">
                                                <label>Teléfono: *</label>
                                                <input required="required" runat="server" class="form-control txFono_ext" type="number" id="txFono_ext" onkeypress='return validaNumericos(event)' />
                                            </div>
                                            <div class="col-md-3">
                                                <label>Previsión: *</label>
                                                <select required="required" runat="server" id="Select3" class="form-control prevision_ext">
                                                    <option value="1" selected="selected">PARTICULAR</option>
                                                </select>
                                            </div>
                                            <div class="col-md-6">
                                                <label>Motivos de la Toma de Muestra: </label>
                                            <textarea runat="server" class="form-control txObs1" id="txObs1"></textarea>
                                            </div>
                                            
                                            <div class="col-md-12 text-center">
                                                <label class="btn-primary btn-lg" onclick="GUARDA_PACIENTE_EXTERNO_CON_SESSION()" style="margin-top: 2rem">Solicitar Hora</label>
                                            </div>
                                        </div>


                                        <%-- <asp:Button Text="Solicitar hora" runat="server" ID="btnReservaOTro" Style="margin-top: 10px; border-radius: 10px;" CssClass="btn btn-primary btn-lg" OnClick="btnReservaOTro_Click" />--%>
                                    </div>
                                </div>
                                <label style="display: none" id="lbl_ip_pac"></label>
                                <%-- RESERVA PARA MI --%>
                                <div class="ini_session">
                                    <div id="divYo" class="row">

                                        <div class="col-md-5">
                                            <label>Previsión: *</label>
                                            <select required="required" runat="server" id="Select4" class="form-control prevision_ses">
                                                <option value="1" selected="selected">PARTICULAR</option>
                                            </select>
                                            <br />
                                        </div>
                                        <div class="col-md-7">
                                            <label>Motivos de la Toma de Muestra</label>
                                            <textarea runat="server" placeholder="Ej: Examen solicitado para Telemedicina" class="form-control txObs_user" id="txObs" style="padding: 1rem;"></textarea>
                                        </div>
                                        <div class="col-lg-12 text-center">
                                            <label class=" btn-primary btn-lg" onclick="GUARDA_PACIENTE_CON_SESSION()" style="margin-top: 2rem">Solictar hora</label>
                                        </div>
                                        <%-- <asp:Button formnovalidate="formnovalidate" runat="server" ID="btnGrabar" Text="Solicitar Hora" Style="margin-top: 10px; border-radius: 10px;" class="btn btn-primary btn-lg" OnClick="btnGrabar_Click" />--%>
                                        <div id="ImageMapa">
                                            <%--<img src="#" runat="server" id="frGoogleMaps" width="600" height="300" style="border: 0" />--%>

                                            <%--<asp:Image ImageUrl="#" runat="server" ID="imgMapa" width="600" height="300"  />--%>
                                        </div>
                                        <%--<button class="btn btn-default"  id="btnSave">Prueba Imagen</button>--%>
                                        <br />
                                        <script>
                                            $(function () {
                                                //var body = $(iframe).contents().find('body');
                                                $("#btnSave").click(function () {
                                                    html2canvas($("#ImageMapa"), {
                                                        onrendered: function (canvas) {
                                                            theCanvas = canvas;
                                                            document.body.appendChild(canvas);
                                                            // Convert and download as image 
                                                            //Canvas2Image.saveAsPNG(canvas);
                                                            $("#img-out").append(canvas);
                                                            // Clean up 
                                                            //document.body.removeChild(canvas);
                                                        }
                                                    });
                                                    //Prueba Otra
                                                });
                                            });
                                        </script>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                </div> 

                <div id="ModSigHora" class="modal  " role="dialog">
                    <div class="modal-dialog " style="z-index: 4000;">
                        <!-- Modal content-->
                        <div class="modal-content " style="border-color: #ebccd1;">
                            <div class="modal-header bg-danger  ">
                                <button type="button" class="close" onclick="CANCELAR()" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title danger">Hora Agendada</h4>
                            </div>
                            <div class="modal-body">
                                <h5>Hora agendada</h5>
                                <br />
                                <div class="row">
                                    <div class="text-center" id="hora_sig">
                                    </div>
                                    <div class="text-center">
                                        <br />
                                        <h4>¿Desea Agendar la siguiente hora?</h4>
                                    </div>

                                </div>

                            </div>
                            <div class="modal-footer" style="padding: 0px 7px 8px;">
                                <label class="btn btn-success BtnConfir " id="btConfirmarHora" onclick="GUARDA_PACIENTE_EXTERNO_SIN_SESSION_SIG_HORA()">Confirmar</label>
                                <label type="button" class="btn btn-danger" data-dismiss="modal" onclick="CANCELAR()">Cancelar</label>
                            </div>
                        </div>
                    </div>
                </div>


                <div id="ModSinHora" class="modal  " role="dialog">
                    <div class="modal-dialog " style="z-index: 4000;">
                        <!-- Modal content-->
                        <div class="modal-content " style="border-color: #ebccd1;">
                            <div class="modal-header bg-danger  ">
                                <button type="button" class="close" onclick="CANCELAR()" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title danger">Hora Agendada</h4>
                            </div>
                            <div class="modal-body">
                                <h5>La hora Seleccionada ya fue agendada</h5>
                                <div class="text-center">
                                    <br />
                                    <h4 style="color: #a83a3a">Sin horas disponibles para el Día Seleccionado</h4>
                                </div>
                            </div>
                            <div class="modal-footer" style="padding: 0px 7px 8px;">
                                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="CANCELAR()">Volver a Agenda Medica</button>
                            </div>
                        </div>
                    </div>
                </div>


                <div id="RellCamp" class="modal " role="dialog">
                    <div class="modal-dialog ">
                        <!-- Modal content-->
                        <div class="modal-content " style="border-color: #ebccd1;">
                            <div class="modal-header bg-danger  ">
                                <button type="button" class="close" data-dismiss="modal" onclick="close()">&times;</button>
                                <h4 class="modal-title danger">Ups!</h4>
                            </div>
                            <div class="modal-body">
                                <div class="text-center">
                                    <br />
                                    <h4 style="color: #a83a3a">Rellene todos los campos</h4>
                                </div>
                            </div>
                            <div class="modal-footer" style="padding: 0px 7px 8px;">
                                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="cerrar()">Ok</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="CampAct" class="modal " role="dialog">
                    <div class="modal-dialog ">
                        <!-- Modal content-->
                        <div class="modal-content " style="border-color: #ebccd1;">
                            <div class="modal-header bg-success  ">
                                <button type="button" class="close" data-dismiss="modal" onclick="close()">&times;</button>
                                <h4 class="modal-title danger">¡Bien Hecho!</h4>
                            </div>
                            <div class="modal-body">
                                <div class="text-center">
                                    <br />
                                    <h4 style="color: #4e8025">Datos Actualizados correctamente</h4>
                                </div>
                            </div>
                            <div class="modal-footer" style="padding: 0px 7px 8px;">
                                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="cerrar()">Ok</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="CampActError" class="modal " role="dialog">
                    <div class="modal-dialog ">
                        <!-- Modal content-->
                        <div class="modal-content " style="border-color: #ebccd1;">
                            <div class="modal-header bg-success  ">
                                <button type="button" class="close" data-dismiss="modal" onclick="close()">&times;</button>
                                <h4 class="modal-title danger">¡UPS!</h4>
                            </div>
                            <div class="modal-body">
                                <div class="text-center">
                                    <br />
                                    <h4 style="color: #a83a3a">Error al actualizar los datos intente nuevamente</h4>
                                </div>
                            </div>
                            <div class="modal-footer" style="padding: 0px 7px 8px;">
                                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="cerrar()">Ok</button>
                            </div>
                        </div>
                    </div>
                </div>


                <asp:HiddenField runat="server" ID="COD_F" />

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

    <script src="js/reservarHora_TM.js"></script>

    <script>
        var bar = $('#barra1');
        $(function () {
            $(bar).each(function () {
                $(this).width('25%');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("input[name='chkPassPort']").click(function () {
                if ($("#chkNo").is(":checked")) {
                    $("#divOtro").show();
                    $("#divYo").hide();
                    $("#divBaby").hide();
                    $(".pac_sin_session").hide();
                } else {
                    if ($("#chkYes").is(":checked")) {
                        $("#divBaby").hide();
                        $("#divOtro").hide();
                        $("#divYo").show();
                        $(".pac_sin_session").show();
                    } else {
                        $("#divYo").hide();
                        $("#divOtro").hide();
                        $(".pac_sin_session").hide();
                        $("#divBaby").show();
                    }
                }
            });
            /******************************************************** CHECK BOX RUT usuario  sin registro*************************************************************/
            $("input[name='chkRut']").click(function () {
                if ($("#chkRut").is(":checked")) {
                    //con rut
                    $(".Rut_ext").show();
                    $(".pac_pasaporte").hide().val("");
                    $(".previsiones_pac").removeAttr("disabled", "disabled")

                } else {
                    //sin  rut
                    if ($("#chkSinDni").is(":checked")) {
                        $(".Rut_ext").hide().val("");
                        $(".pac_pasaporte").hide().val("");
                        $(".previsiones_pac").attr({ "selected": "selected" }).val("54")
                        $(".previsiones_pac").attr({ "disabled": "disabled" })
                    } else {
                        $(".Rut_ext").hide().val("");
                        $(".pac_pasaporte").show().val("");
                        $(".previsiones_pac").attr({ "selected": "selected", "disabled": "disabled" }).val("54")
                    }
                }
            });

            /******************************************************** CHECK BOX RUT usuario  con registro*************************************************************/
            $("input[name='chkRut_Ses']").click(function () {
                if ($("#chkRut_Ses").is(":checked")) {
                    //con rut
                    $(".txtRut_ses").show();
                    $(".txtPasaporte_ses").hide().val("");
                    $(".prevision_ext").removeAttr("disabled")


                } else {
                    //sin  rut
                    if ($("#chkSinDni_Ses").is(":checked")) {
                        $(".txtRut_ses").hide().val("");
                        $(".txtPasaporte_ses").hide().val("");

                        $(".prevision_ext").attr({ "selected": "selected" }).val("54")
                        $(".prevision_ext").attr({ "disabled": "disabled" })
                    } else {
                        $(".txtRut_ses").hide().val("");
                        $(".txtPasaporte_ses").show().val("");
                        $(".prevision_ext").attr({ "selected": "selected", "disabled": "disabled" }).val("54")
                    }
                }
            });

            /******************************************************** CHECK BOX RUT RECIEN NACIDO*************************************************************/

            $("input[name='chkBaby']").click(function () {
                if ($("#chkBebe").is(":checked")) {
                    //con rut bebe
                    $(".rut_bebe").show();
                    $(".rut_padres").hide().val("");
                } else {
                    //rut padres
                    $(".rut_padres").show();
                    $(".rut_bebe").hide().val("");

                }
            });

        });
    </script>

    <%--    RUT AGENDAMIENTO --%>
    <script type="text/javascript">

        function revisarDigito(dvr) {
            dv = dvr + ""
            if (dv != '0' && dv != '1' && dv != '2' && dv != '3' && dv != '4' && dv != '5' && dv != '6' && dv != '7' && dv != '8' && dv != '9' && dv != 'k' && dv != 'K') {
                alert("Debe ingresar un digito verificador valido");
                document.getElementById('ContentPlaceHolder1_textRut').value = '';
                document.getElementById('ContentPlaceHolder1_textRut').focus();
                document.getElementById('ContentPlaceHolder1_textRut').select();
                return false;
            }
            return true;
        }

        function revisarDigito2(crut) {
            largo = crut.length;
            if (largo < 2) {
                alert("Debe ingresar el rut completo")
                document.getElementById('ContentPlaceHolder1_textRut').value = '';
                document.getElementById('ContentPlaceHolder1_textRut').focus();
                document.getElementById('ContentPlaceHolder1_textRut').select();
                return false;
            }
            if (largo > 2)
                rut = crut.substring(0, largo - 1);
            else
                rut = crut.charAt(0);
            dv = crut.charAt(largo - 1);
            revisarDigito(dv);

            if (rut == null || dv == null)
                return 0

            var dvr = '0'
            suma = 0
            mul = 2

            for (i = rut.length - 1 ; i >= 0; i--) {
                suma = suma + rut.charAt(i) * mul
                if (mul == 7)
                    mul = 2
                else
                    mul++
            }
            res = suma % 11
            if (res == 1)
                dvr = 'k'
            else if (res == 0)
                dvr = '0'
            else {
                dvi = 11 - res
                dvr = dvi + ""
            }
            if (dvr != dv.toLowerCase()) {
                alert("EL rut es incorrecto")
                document.getElementById('ContentPlaceHolder1_textRut').value = '';
                document.getElementById('ContentPlaceHolder1_textRut').focus();
                document.getElementById('ContentPlaceHolder1_textRut').select();
                return false
            }


            return validardemascajas();
        }

        function Rut(texto) {
            if (texto != "") {
                var tmpstr = "";
                for (i = 0; i < texto.length ; i++)
                    if (texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-')
                        tmpstr = tmpstr + texto.charAt(i);
                texto = tmpstr;
                largo = texto.length;

                if (largo < 3) {
                    alert("Debe ingresar el rut completo")
                    //window.document.form1.TxtRut.text = "";
                    document.getElementById('ContentPlaceHolder1_textRut').value = '';
                    document.getElementById('ContentPlaceHolder1_textRut').focus();
                    document.getElementById('ContentPlaceHolder1_textRut').select();
                    return false;
                }

                for (i = 0; i < largo ; i++) {
                    if (texto.charAt(i) != "0" && texto.charAt(i) != "1" && texto.charAt(i) != "2" && texto.charAt(i) != "3" && texto.charAt(i) != "4" && texto.charAt(i) != "5" && texto.charAt(i) != "6" && texto.charAt(i) != "7" && texto.charAt(i) != "8" && texto.charAt(i) != "9" && texto.charAt(i) != "k" && texto.charAt(i) != "K") {
                        alert("El valor ingresado no corresponde a un R.U.T valido");
                        document.getElementById('ContentPlaceHolder1_textRut').value = '';
                        document.getElementById('ContentPlaceHolder1_textRut').focus();
                        document.getElementById('ContentPlaceHolder1_textRut').select();
                        return false;
                    }
                }

                var invertido = "";
                for (i = (largo - 1), j = 0; i >= 0; i--, j++)
                    invertido = invertido + texto.charAt(i);
                var dtexto = "";
                dtexto = dtexto + invertido.charAt(0);
                dtexto = dtexto + '-';
                cnt = 0;
            }
            for (i = 1, j = 2; i < largo; i++, j++) {
                //alert("i=[" + i + "] j=[" + j +"]" );		
                if (cnt == 3) {
                    dtexto = dtexto + '.';
                    j++;
                    dtexto = dtexto + invertido.charAt(i);
                    cnt = 1;
                }
                else {
                    dtexto = dtexto + invertido.charAt(i);
                    cnt++;
                }
            }


            invertido = "";
            for (i = (dtexto.length - 1), j = 0; i >= 0; i--, j++)
                invertido = invertido + dtexto.charAt(i);

            document.getElementById('ContentPlaceHolder1_textRut').value = invertido.toUpperCase()

            if (invertido == "11.111.111-1" || invertido == "99.999.999-9" || invertido == "22.222.222-2") {
                document.getElementById('ContentPlaceHolder1_textRut').value = ""

            }

            if (revisarDigito2(texto))
                return true;


            return false;
        }
        function validardemascajas() {
            return true;
        }


    </script>

    <%-- RUT INICIO SESSION--%>
    <script type="text/javascript">

        function revisarDigito1(dvr) {
            dv = dvr + ""
            if (dv != '0' && dv != '1' && dv != '2' && dv != '3' && dv != '4' && dv != '5' && dv != '6' && dv != '7' && dv != '8' && dv != '9' && dv != 'k' && dv != 'K') {
                alert("Debe ingresar un digito verificador valido");
                document.getElementById('RUT').value = '';
                document.getElementById('RUT').focus();
                document.getElementById('RUT').select();
                return false;
            }
            return true;
        }

        function revisarDigito3(crut) {
            largo = crut.length;
            if (largo < 2) {
                alert("Debe ingresar el rut completo")
                document.getElementById('RUT').value = '';
                document.getElementById('RUT').focus();
                document.getElementById('RUT').select();
                return false;
            }
            if (largo > 2)
                rut = crut.substring(0, largo - 1);
            else
                rut = crut.charAt(0);
            dv = crut.charAt(largo - 1);
            revisarDigito1(dv);

            if (rut == null || dv == null)
                return 0

            var dvr = '0'
            suma = 0
            mul = 2

            for (i = rut.length - 1 ; i >= 0; i--) {
                suma = suma + rut.charAt(i) * mul
                if (mul == 7)
                    mul = 2
                else
                    mul++
            }
            res = suma % 11
            if (res == 1)
                dvr = 'k'
            else if (res == 0)
                dvr = '0'
            else {
                dvi = 11 - res
                dvr = dvi + ""
            }
            if (dvr != dv.toLowerCase()) {
                alert("EL rut es incorrecto")
                document.getElementById('RUT').value = '';
                document.getElementById('RUT').focus();
                document.getElementById('RUT').select();
                return false
            }

            return validardemascajas2();
        }

        function Rut2(texto) {
            if (texto != "") {
                var tmpstr = "";
                for (i = 0; i < texto.length ; i++)
                    if (texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-')
                        tmpstr = tmpstr + texto.charAt(i);
                texto = tmpstr;
                largo = texto.length;

                if (largo < 3) {
                    alert("Debe ingresar el rut completo")
                    //window.document.form1.TxtRut.text = "";
                    document.getElementById('RUT').value = '';
                    document.getElementById('RUT').focus();
                    document.getElementById('RUT').select();
                    return false;
                }

                for (i = 0; i < largo ; i++) {
                    if (texto.charAt(i) != "0" && texto.charAt(i) != "1" && texto.charAt(i) != "2" && texto.charAt(i) != "3" && texto.charAt(i) != "4" && texto.charAt(i) != "5" && texto.charAt(i) != "6" && texto.charAt(i) != "7" && texto.charAt(i) != "8" && texto.charAt(i) != "9" && texto.charAt(i) != "k" && texto.charAt(i) != "K") {
                        alert("El valor ingresado no corresponde a un R.U.T valido");
                        document.getElementById('RUT').value = '';
                        document.getElementById('RUT').focus();
                        document.getElementById('RUT').select();
                        return false;
                    }
                }

                var invertido = "";
                for (i = (largo - 1), j = 0; i >= 0; i--, j++)
                    invertido = invertido + texto.charAt(i);
                var dtexto = "";
                dtexto = dtexto + invertido.charAt(0);
                dtexto = dtexto + '-';
                cnt = 0;
            }
            for (i = 1, j = 2; i < largo; i++, j++) {
                //alert("i=[" + i + "] j=[" + j +"]" );		
                if (cnt == 3) {
                    dtexto = dtexto + '.';
                    j++;
                    dtexto = dtexto + invertido.charAt(i);
                    cnt = 1;
                }
                else {
                    dtexto = dtexto + invertido.charAt(i);
                    cnt++;
                }
            }


            invertido = "";
            for (i = (dtexto.length - 1), j = 0; i >= 0; i--, j++)
                invertido = invertido + dtexto.charAt(i);

            document.getElementById('RUT').value = invertido.toUpperCase()

            if (invertido == "11.111.111-1" || invertido == "99.999.999-9" || invertido == "22.222.222-2") {
                document.getElementById('RUT').value = ""

            }

            if (revisarDigito3(texto))
                return true;


            return false;
        }
        function validardemascajas2() {
            return true;
        }


    </script>


    <%-- RUT BEBE--%>
    <script type="text/javascript">

        function revisarDigito2_bb(dvr) {
            dv = dvr + ""
            if (dv != '0' && dv != '1' && dv != '2' && dv != '3' && dv != '4' && dv != '5' && dv != '6' && dv != '7' && dv != '8' && dv != '9' && dv != 'k' && dv != 'K') {
                alert("Debe ingresar un digito verificador valido");
                document.getElementById('ContentPlaceHolder1_rut_bebe').value = '';
                document.getElementById('ContentPlaceHolder1_rut_bebe').focus();
                document.getElementById('ContentPlaceHolder1_rut_bebe').select();
                return false;
            }
            return true;
        }

        function revisarDigito4_bb(crut) {
            largo = crut.length;
            if (largo < 2) {
                alert("Debe ingresar el rut completo")
                document.getElementById('ContentPlaceHolder1_rut_bebe').value = '';
                document.getElementById('ContentPlaceHolder1_rut_bebe').focus();
                document.getElementById('ContentPlaceHolder1_rut_bebe').select();
                return false;
            }
            if (largo > 2)
                rut = crut.substring(0, largo - 1);
            else
                rut = crut.charAt(0);
            dv = crut.charAt(largo - 1);
            revisarDigito2_bb(dv);

            if (rut == null || dv == null)
                return 0

            var dvr = '0'
            suma = 0
            mul = 2

            for (i = rut.length - 1 ; i >= 0; i--) {
                suma = suma + rut.charAt(i) * mul
                if (mul == 7)
                    mul = 2
                else
                    mul++
            }
            res = suma % 11
            if (res == 1)
                dvr = 'k'
            else if (res == 0)
                dvr = '0'
            else {
                dvi = 11 - res
                dvr = dvi + ""
            }
            if (dvr != dv.toLowerCase()) {
                alert("EL rut es incorrecto")
                document.getElementById('ContentPlaceHolder1_rut_bebe').value = '';
                document.getElementById('ContentPlaceHolder1_rut_bebe').focus();
                document.getElementById('ContentPlaceHolder1_rut_bebe').select();
                return false
            }

            return validardemascajas3_bb();
        }

        function Rut4(texto) {
            if (texto != "") {
                var tmpstr = "";
                for (i = 0; i < texto.length ; i++)
                    if (texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-')
                        tmpstr = tmpstr + texto.charAt(i);
                texto = tmpstr;
                largo = texto.length;

                if (largo < 3) {
                    alert("Debe ingresar el rut completo")
                    //window.document.form1.TxtRut.text = "";
                    document.getElementById('ContentPlaceHolder1_rut_bebe').value = '';
                    document.getElementById('ContentPlaceHolder1_rut_bebe').focus();
                    document.getElementById('ContentPlaceHolder1_rut_bebe').select();
                    return false;
                }

                for (i = 0; i < largo ; i++) {
                    if (texto.charAt(i) != "0" && texto.charAt(i) != "1" && texto.charAt(i) != "2" && texto.charAt(i) != "3" && texto.charAt(i) != "4" && texto.charAt(i) != "5" && texto.charAt(i) != "6" && texto.charAt(i) != "7" && texto.charAt(i) != "8" && texto.charAt(i) != "9" && texto.charAt(i) != "k" && texto.charAt(i) != "K") {
                        alert("El valor ingresado no corresponde a un R.U.T valido");
                        document.getElementById('ContentPlaceHolder1_rut_bebe').value = "";
                        document.getElementById('ContentPlaceHolder1_rut_bebe').focus();
                        document.getElementById('ContentPlaceHolder1_rut_bebe').select();
                        return false;
                    }
                }

                var invertido = "";
                for (i = (largo - 1), j = 0; i >= 0; i--, j++)
                    invertido = invertido + texto.charAt(i);
                var dtexto = "";
                dtexto = dtexto + invertido.charAt(0);
                dtexto = dtexto + '-';
                cnt = 0;
            }
            for (i = 1, j = 2; i < largo; i++, j++) {
                //alert("i=[" + i + "] j=[" + j +"]" );		
                if (cnt == 3) {
                    dtexto = dtexto + '.';
                    j++;
                    dtexto = dtexto + invertido.charAt(i);
                    cnt = 1;
                }
                else {
                    dtexto = dtexto + invertido.charAt(i);
                    cnt++;
                }
            }


            invertido = "";
            for (i = (dtexto.length - 1), j = 0; i >= 0; i--, j++)
                invertido = invertido + dtexto.charAt(i);

            document.getElementById('ContentPlaceHolder1_rut_bebe').value = invertido.toUpperCase()

            if (invertido == "11.111.111-1" || invertido == "99.999.999-9" || invertido == "22.222.222-2") {
                document.getElementById('ContentPlaceHolder1_rut_bebe').value = ""

            }

            if (revisarDigito4_bb(texto))
                return true;


            return false;
        }
        function validardemascajas3_bb() {
            return true;
        }


    </script>

    <%-- RUT PADRES--%>
    <script type="text/javascript">

        function revisarDigito3_pad(dvr) {
            dv = dvr + ""
            if (dv != '0' && dv != '1' && dv != '2' && dv != '3' && dv != '4' && dv != '5' && dv != '6' && dv != '7' && dv != '8' && dv != '9' && dv != 'k' && dv != 'K') {
                alert("Debe ingresar un digito verificador valido");
                document.getElementById('ContentPlaceHolder1_rut_padres').value = '';
                document.getElementById('ContentPlaceHolder1_rut_padres').focus();
                document.getElementById('ContentPlaceHolder1_rut_padres').select();
                return false;
            }
            return true;
        }

        function revisarDigito5_pad(crut) {
            largo = crut.length;
            if (largo < 2) {
                alert("Debe ingresar el rut completo")
                document.getElementById('ContentPlaceHolder1_rut_padres').value = '';
                document.getElementById('ContentPlaceHolder1_rut_padres').focus();
                document.getElementById('ContentPlaceHolder1_rut_padres').select();
                return false;
            }
            if (largo > 2)
                rut = crut.substring(0, largo - 1);
            else
                rut = crut.charAt(0);
            dv = crut.charAt(largo - 1);
            revisarDigito3_pad(dv);

            if (rut == null || dv == null)
                return 0

            var dvr = '0'
            suma = 0
            mul = 2

            for (i = rut.length - 1 ; i >= 0; i--) {
                suma = suma + rut.charAt(i) * mul
                if (mul == 7)
                    mul = 2
                else
                    mul++
            }
            res = suma % 11
            if (res == 1)
                dvr = 'k'
            else if (res == 0)
                dvr = '0'
            else {
                dvi = 11 - res
                dvr = dvi + ""
            }
            if (dvr != dv.toLowerCase()) {
                alert("EL rut es incorrecto")
                document.getElementById('ContentPlaceHolder1_rut_padres').value = '';
                document.getElementById('ContentPlaceHolder1_rut_padres').focus();
                document.getElementById('ContentPlaceHolder1_rut_padres').select();
                return false
            }

            return validardemascajas4_pad();
        }

        function Rut3(texto) {
            if (texto != "") {
                var tmpstr = "";
                for (i = 0; i < texto.length ; i++)
                    if (texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-')
                        tmpstr = tmpstr + texto.charAt(i);
                texto = tmpstr;
                largo = texto.length;

                if (largo < 3) {
                    alert("Debe ingresar el rut completo")
                    //window.document.form1.TxtRut.text = "";
                    document.getElementById('ContentPlaceHolder1_rut_padres').value = '';
                    document.getElementById('ContentPlaceHolder1_rut_padres').focus();
                    document.getElementById('ContentPlaceHolder1_rut_padres').select();
                    return false;
                }

                for (i = 0; i < largo ; i++) {
                    if (texto.charAt(i) != "0" && texto.charAt(i) != "1" && texto.charAt(i) != "2" && texto.charAt(i) != "3" && texto.charAt(i) != "4" && texto.charAt(i) != "5" && texto.charAt(i) != "6" && texto.charAt(i) != "7" && texto.charAt(i) != "8" && texto.charAt(i) != "9" && texto.charAt(i) != "k" && texto.charAt(i) != "K") {
                        alert("El valor ingresado no corresponde a un R.U.T valido");
                        document.getElementById('ContentPlaceHolder1_rut_padres').value = '';
                        document.getElementById('ContentPlaceHolder1_rut_padres').focus();
                        document.getElementById('ContentPlaceHolder1_rut_padres').select();
                        return false;
                    }
                }

                var invertido = "";
                for (i = (largo - 1), j = 0; i >= 0; i--, j++)
                    invertido = invertido + texto.charAt(i);
                var dtexto = "";
                dtexto = dtexto + invertido.charAt(0);
                dtexto = dtexto + '-';
                cnt = 0;
            }
            for (i = 1, j = 2; i < largo; i++, j++) {
                //alert("i=[" + i + "] j=[" + j +"]" );		
                if (cnt == 3) {
                    dtexto = dtexto + '.';
                    j++;
                    dtexto = dtexto + invertido.charAt(i);
                    cnt = 1;
                }
                else {
                    dtexto = dtexto + invertido.charAt(i);
                    cnt++;
                }
            }


            invertido = "";
            for (i = (dtexto.length - 1), j = 0; i >= 0; i--, j++)
                invertido = invertido + dtexto.charAt(i);

            document.getElementById('ContentPlaceHolder1_rut_padres').value = invertido.toUpperCase()

            if (invertido == "11.111.111-1" || invertido == "99.999.999-9" || invertido == "22.222.222-2") {
                document.getElementById('ContentPlaceHolder1_rut_padres').value = ""

            }

            if (revisarDigito5_pad(texto))
                return true;


            return false;
        }
        function validardemascajas4_pad() {
            return true;
        }


    </script>



    <%-- RUT  EXTERNO PACIENTE CON SESSION --%>
    <script type="text/javascript">

        function revisarDigito_Ext_ses2(dvr) {
            dv = dvr + ""
            if (dv != '0' && dv != '1' && dv != '2' && dv != '3' && dv != '4' && dv != '5' && dv != '6' && dv != '7' && dv != '8' && dv != '9' && dv != 'k' && dv != 'K') {
                alert("Debe ingresar un digito verificador valido");
                document.getElementById('ContentPlaceHolder1_Text2').value = '';
                document.getElementById('ContentPlaceHolder1_Text2').focus();
                document.getElementById('ContentPlaceHolder1_Text2').select();
                return false;
            }
            return true;
        }

        function revisarDigito_Ext_ses(crut) {
            largo = crut.length;
            if (largo < 2) {
                alert("Debe ingresar el rut completo")
                document.getElementById('ContentPlaceHolder1_Text2').value = '';
                document.getElementById('ContentPlaceHolder1_Text2').focus();
                document.getElementById('ContentPlaceHolder1_Text2').select();
                return false;
            }
            if (largo > 2)
                rut = crut.substring(0, largo - 1);
            else
                rut = crut.charAt(0);
            dv = crut.charAt(largo - 1);
            revisarDigito_Ext_ses2(dv);

            if (rut == null || dv == null)
                return 0

            var dvr = '0'
            suma = 0
            mul = 2

            for (i = rut.length - 1 ; i >= 0; i--) {
                suma = suma + rut.charAt(i) * mul
                if (mul == 7)
                    mul = 2
                else
                    mul++
            }
            res = suma % 11
            if (res == 1)
                dvr = 'k'
            else if (res == 0)
                dvr = '0'
            else {
                dvi = 11 - res
                dvr = dvi + ""
            }
            if (dvr != dv.toLowerCase()) {
                alert("EL rut es incorrecto")
                document.getElementById('ContentPlaceHolder1_Text2').value = '';
                document.getElementById('ContentPlaceHolder1_Text2').focus();
                document.getElementById('ContentPlaceHolder1_Text2').select();
                return false
            }

            return validardemascajas_Ext_ses();
        }

        function Rut_Ext_ses(texto) {
            if (texto != "") {
                var tmpstr = "";
                for (i = 0; i < texto.length ; i++)
                    if (texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-')
                        tmpstr = tmpstr + texto.charAt(i);
                texto = tmpstr;
                largo = texto.length;

                if (largo < 3) {
                    alert("Debe ingresar el rut completo")
                    //window.document.form1.TxtRut.text = "";
                    document.getElementById('ContentPlaceHolder1_Text2').value = '';
                    document.getElementById('ContentPlaceHolder1_Text2').focus();
                    document.getElementById('ContentPlaceHolder1_Text2').select();
                    return false;
                }

                for (i = 0; i < largo ; i++) {
                    if (texto.charAt(i) != "0" && texto.charAt(i) != "1" && texto.charAt(i) != "2" && texto.charAt(i) != "3" && texto.charAt(i) != "4" && texto.charAt(i) != "5" && texto.charAt(i) != "6" && texto.charAt(i) != "7" && texto.charAt(i) != "8" && texto.charAt(i) != "9" && texto.charAt(i) != "k" && texto.charAt(i) != "K") {
                        alert("El valor ingresado no corresponde a un R.U.T valido");
                        document.getElementById('ContentPlaceHolder1_Text2').value = '';
                        document.getElementById('ContentPlaceHolder1_Text2').focus();
                        document.getElementById('ContentPlaceHolder1_Text2').select();
                        return false;
                    }
                }

                var invertido = "";
                for (i = (largo - 1), j = 0; i >= 0; i--, j++)
                    invertido = invertido + texto.charAt(i);
                var dtexto = "";
                dtexto = dtexto + invertido.charAt(0);
                dtexto = dtexto + '-';
                cnt = 0;
            }
            for (i = 1, j = 2; i < largo; i++, j++) {
                //alert("i=[" + i + "] j=[" + j +"]" );		
                if (cnt == 3) {
                    dtexto = dtexto + '.';
                    j++;
                    dtexto = dtexto + invertido.charAt(i);
                    cnt = 1;
                }
                else {
                    dtexto = dtexto + invertido.charAt(i);
                    cnt++;
                }
            }


            invertido = "";
            for (i = (dtexto.length - 1), j = 0; i >= 0; i--, j++)
                invertido = invertido + dtexto.charAt(i);

            document.getElementById('ContentPlaceHolder1_Text2').value = invertido.toUpperCase()


            if (invertido == "11.111.111-1" || invertido == "99.999.999-9" || invertido == "22.222.222-2") {
                document.getElementById('ContentPlaceHolder1_Text2').value = ""

            }

            if (revisarDigito_Ext_ses(texto))
                return true;


            return false;
        }
        function validardemascajas_Ext_ses() {
            return true;
        }


    </script>



</asp:Content>
