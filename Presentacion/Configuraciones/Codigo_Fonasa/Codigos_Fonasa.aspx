<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Codigos_Fonasa.aspx.vb" Inherits="Presentacion.Codigos_Fonasa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <%-- Colocar esto para forzar el evento load --%>
    <%@ OutputCache Location="None" NoStore="true" %>
    <script>
        $(document).ready(function () {

            //ON CLICK CLASS TOGGLE   
            $('table').on('click', 'tbody tr', function () {
                $("table tbody tr").removeClass("active");
                $(this).toggleClass("active");
            });
            $("#btn_guardar").attr("disabled", false);
            $("#btn_modificar").attr("disabled", true);
            $("#btn_eliminar").attr("disabled", true);
            Llenar_Ddl_Estado_Mant();
            Llenar_Ddl_Agrupacion_Mant();
            Llenar_Dtt();
            Llenar_Año();
            $("#btn_modificar").click(function () {
                Ajax_Update();
                Ajax_Update_PF();
            });
            $("#btn_eliminar").click(function () {
                Ajax_Delete();
                Ajax_Delete_PF();
                Ajax_Clear();
                $("#btn_modificar").attr("disabled", true);
                $("#btn_eliminar").attr("disabled", true);
            });
            $("#btn_nuevo").click(function () {
                Ajax_Clear();
                $("#btn_guardar").attr("disabled", false);
                $("#btn_modificar").attr("disabled", true);
                $("#btn_eliminar").attr("disabled", true);
            });
            $("#btn_guardar").click(function () {
                Ajax_Create();
                $("#btn_guardar").attr("disabled", true);
                $("#btn_modificar").attr("disabled", true);
                $("#btn_eliminar").attr("disabled", true);
            });
            $(document).on("change", "#div_chk input[type='checkbox']", function () {
                if ($(this).is(':checked')) {
                    $(this).val("1");
                } else {
                    $(this).val("0");
                }
            });
        });
        //VARIBLES
        var POSS = 0;
        var AÑOO = "";
        var ID_CFF = "";
        var Mx_Ddl_Estado_Mant = [{
            "ID_ESTADO": "",
            "EST_DESCRIPCION": "",
            "EST_MANTENEDOR": ""
        }];
        var Mx_Ddl_Agrupacion_Mant = [{
            "ID_AMUESTRA": "",
            "AMUE_COD": "",
            "AMUE_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Año = [{
            "ID_AÑO": "",
            "AÑO_COD": "",
            "AÑO_DESC": "",
            "ID_ESTADO": ""
        }];
        var Mx_Dtt = [{
            "ID_CODIGO_FONASA": "",
            "CF_COD": "",
            "CF_DESC": "",
            "CF_CORTO": "",
            "CF_IMP_SOLA": "",
            "CF_IMP_NOM_PER": "",
            "CF_SEL_PRUE": "",
            "CF_DIAS": "",
            "ID_ESTADO": "",
            "CF_IMP_NUEVO": "",
            "CF_IMP_PARCIAL": "",
            "CF_HOST": "",
            "ID_AMUESTRA": ""
        }];
    </script>
    <script>
        //AJAX DDL ESTADO MANTENEDOR
        function Llenar_Ddl_Estado_Mant() {
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Llenar_Ddl_Estado_Mant",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ddl_Estado_Mant = JSON.parse(data.d);

                    Fill_Ddl_Estado_Mantenedor();
                },
                "error": data => {
                    //Debug

                }
            });
        }
        //AJAX DDL AGRUPACION MANTENEDOR
        function Llenar_Ddl_Agrupacion_Mant() {
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Llenar_Ddl_Agrupacion_Mant",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Ddl_Agrupacion_Mant = JSON.parse(data.d);
                    Fill_Ddl_Agrupacion_Mantenedor();
                },
                "error": data => {
                    //Debug

                }
            });
        }
        //AJAX BUSCAR AÑO 
        function Llenar_Año() {
            var año = moment().format("YYYY");
            //Parámetros
            var strParam = JSON.stringify({
                "ANO": año
            });
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Llenar_Año",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Año = JSON.parse(data.d);
                    Mx_Año.forEach(aaññoo=> {
                        AÑOO = aaññoo.ID_AÑO;
                    });
                },
                "error": data => {
                    //Debug

                }
            });
        }
        //AJAX GUARDAR
        function Ajax_Create() {
            //Parámetros
            var strParam = JSON.stringify({
                "COD_CF": $("#txt_cod").val(),
                "DESC_CF": $("#txt_des").val(),
                "CORTO_CF": $("#txtdes_cor").val(),
                "DIAS_CF": $("#txt_ndias").val(),
                "ID_ESTADO": $("#ddl_est").val(),
                "SOLA_CF": $("#chk_imp_una_pag").val(),
                "IMP_NOM_CF": $("#chk_imp_nom_est").val(),
                "IMP_SEL_CF": $("#chk_imp_sel_prueba").val(),
                "IMP_PAR_CF": $("#chk_imp_parcial").val(),
                "HOST_CF": $("#txtcod_host").val(),
                "ID_MUESTRA": $("#ddl_agr").val(),
            });
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Create_CF",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    $("table").dataTable().fnDestroy();
                    Llenar_Dtt();
                    Ajax_Clear();
                    $("#EM2 h5").text("Código Fonasa Guardado");
                    $("#EM2 button").attr("class", "btn btn-success");
                    $("#EM2 p").text("Se realizaron los cambios con éxito");
                    $("#EM2").modal();

                },
                "error": data => {
                    //Debug

                    $("#EM2 h5").text("Error");
                    $("#EM2 button").attr("class", "btn btn-danger");
                    $("#EM2 p").text("Ocurrió un error durante el guardado del Código Fonasa");
                    $("#EM2").modal();
                }
            });


        }
        //AJAX MODIFICAR
        function Ajax_Update() {
            //Parámetros
            var strParam = JSON.stringify({
                "ID_CF": ID_CFF,
                "COD_CF": $("#txt_cod").val(),
                "DESC_CF": $("#txt_des").val(),
                "CORTO_CF": $("#txtdes_cor").val(),
                "DIAS_CF": $("#txt_ndias").val(),
                "ID_ESTADO": $("#ddl_est").val(),
                "SOLA_CF": $("#chk_imp_una_pag").val(),
                "IMP_NOM_CF": $("#chk_imp_nom_est").val(),
                "IMP_SEL_CF": $("#chk_imp_sel_prueba").val(),
                "IMP_PAR_CF": $("#chk_imp_parcial").val(),
                "HOST_CF": $("#txtcod_host").val(),
                "ID_MUESTRA": $("#ddl_agr").val()
            });
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Update_CF",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    $("#EM2 h5").text("Código Fonasa Modificado");
                    $("#EM2 button").attr("class", "btn btn-success");
                    $("#EM2 p").text("Se realizaron los cambios con éxito");
                    $("#EM2").modal();
                },
                "error": data => {
                    //Debug

                    $("#EM2 h5").text("Error");
                    $("#EM2 button").attr("class", "btn btn-danger");
                    $("#EM2 p").text("Ocurrió un error durante la modificación del Código Fonasa");
                    $("#EM2").modal();
                }
            });
            MX_UPD();
            Ajax_Clear();
        }
        function Ajax_Update_PF() {
            //Parámetros
            var strParam = JSON.stringify({
                "ID_ANO": AÑOO,
                "ID_USUARIO": "1",
                "ID_FONASA": ID_CFF,
                "ID_ESTADO": $("#ddl_est").val()
            });
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Update_PF",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                },
                "error": data => {
                    //Debug

                }
            });
        }
        //AJAX ELIMINAR
        function Ajax_Delete() {
            //Parámetros
            var strParam = JSON.stringify({
                "ID_CF": ID_CFF,
                "COD_CF": $("#txt_cod").val(),
                "DESC_CF": $("#txt_des").val(),
                "CORTO_CF": $("#txtdes_cor").val(),
                "DIAS_CF": $("#txt_ndias").val(),
                "ID_ESTADO": "2",
                "SOLA_CF": $("#chk_imp_una_pag").val(),
                "IMP_NOM_CF": $("#chk_imp_nom_est").val(),
                "IMP_SEL_CF": $("#chk_imp_sel_prueba").val(),
                "IMP_PAR_CF": $("#chk_imp_parcial").val(),
                "HOST_CF": $("#txtcod_host").val(),
                "ID_MUESTRA": $("#ddl_agr").val()
            });
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Update_CF",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    $("#EM2 h5").text("Código Fonasa Eliminado");
                    $("#EM2 button").attr("class", "btn btn-success");
                    $("#EM2 p").text("Se realizaron los cambios con éxito");
                    $("#EM2").modal();
                },
                "error": data => {
                    //Debug

                    $("#EM2 h5").text("Error");
                    $("#EM2 button").attr("class", "btn btn-danger");
                    $("#EM2 p").text("Ocurrió un error durante la Eliminación del Código Fonasa");
                    $("#EM2").modal();
                }
            });
            MX_DEL();
            Ajax_Clear();
        }
        function Ajax_Delete_PF() {
            //Parámetros
            var strParam = JSON.stringify({
                "ID_ANO": AÑOO,
                "ID_USUARIO": "1",
                "ID_FONASA": ID_CFF,
                "ID_ESTADO": "2"
            });
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Update_PF",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                },
                "error": data => {
                    //Debug

                }
            });
        }
        //AJAX DataTable
        function Llenar_Dtt() {
            modal_show();
            //Debug

            $.ajax({
                "type": "POST",
                "url": "Codigos_Fonasa.aspx/Llenar_Dtt",
                //"data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Dtt = JSON.parse(data.d);
                    Fill_Dtt();
                },
                "error": data => {
                    //Debug

                    Hide_Modal();
                }
            });
        }
        //MATRIZ DELETE
        function MX_DEL() {
            Mx_Dtt.splice(POSS, 1); //eliminar 
            $("table").dataTable().fnDestroy();
            Fill_Dtt();
        }
        //MATRIZ UPDATE
        function MX_UPD() {
            Mx_Dtt.splice(POSS, 1, {
                "CF_COD": $("#txt_cod").val(),
                "CF_CORTO": $("#txtdes_cor").val(),
                "CF_DESC": $("#txt_des").val(),
                "CF_DIAS": $("#txt_ndias").val(),
                "CF_IMP_SOLA": $("#chk_imp_una_pag").val(),
                "CF_IMP_NOM_PER": $("#chk_imp_nom_est").val(),
                "CF_IMP_NUEVO": "",
                "CF_IMP_PARCIAL": $("#chk_imp_parcial").val(),
                "CF_SEL_PRUE": $("#chk_imp_sel_prueba").val(),
                "ID_AMUESTRA": $("#ddl_agr").val(),
                "ID_CODIGO_FONASA": ID_CFF,
                "ID_ESTADO": $("#ddl_est").val()
            }); //actualizar
            $("table").dataTable().fnDestroy();
            Fill_Dtt();
        }
        //LIMPIAR CAMPOS
        function Ajax_Clear() {
            $("#txt_cod").val("");
            $("#txt_des").val("");
            $("#txtdes_cor").val("");
            $("#txt_ndias").val("");
            $("#chk_imp_una_pag").val("0");
            $("#chk_imp_una_pag").prop("checked", false);
            $("#chk_imp_nom_est").val("0");
            $("#chk_imp_nom_est").prop("checked", false);
            $("#chk_imp_sel_prueba").val("0");
            $("#chk_imp_sel_prueba").prop("checked", false);
            $("#chk_imp_parcial").val("0");
            $("#chk_imp_parcial").prop("checked", false);
            $("#txtcod_host").val("");
            $("table tbody tr").removeClass("active");
        }
        //LLENAR FORMULARIO 
        function Ajax_Llenar_Form(idd, i) {
            POSS = i - 1;
            $("#btn_guardar").attr("disabled", true);
            $("#btn_modificar").attr("disabled", false);
            $("#btn_eliminar").attr("disabled", false);
            Mx_Dtt.forEach(fona => {
                if (fona.ID_CODIGO_FONASA == idd) {
                    ID_CFF = fona.ID_CODIGO_FONASA;
                    $("#txt_cod").val(fona.CF_COD);
                    $("#txt_des").val(fona.CF_DESC);
                    $("#txtdes_cor").val(fona.CF_CORTO);
                    $("#txt_ndias").val(fona.CF_DIAS);
                    $("#ddl_est").val(fona.ID_ESTADO);
                    if (fona.CF_IMP_SOLA == 1) {
                        $("#chk_imp_una_pag").prop("checked", true);
                        $("#chk_imp_una_pag").val("1");
                    }
                    else {
                        $("#chk_imp_una_pag").prop("checked", false);
                        $("#chk_imp_una_pag").val("0");
                    }
                    if (fona.CF_IMP_NOM_PER == 1) {
                        $("#chk_imp_nom_est").prop("checked", true);
                        $("#chk_imp_nom_est").val("1");
                    }
                    else {
                        $("#chk_imp_nom_est").val("0");
                        $("#chk_imp_nom_est").prop("checked", false);
                    }
                    if (fona.CF_SEL_PRUE == 1) {
                        $("#chk_imp_sel_prueba").prop("checked", true);
                        $("#chk_imp_sel_prueba").val("1");
                    }
                    else {
                        $("#chk_imp_sel_prueba").prop("checked", false);
                        $("#chk_imp_sel_prueba").val("0");
                    }
                    if (fona.CF_IMP_PARCIAL == 1) {
                        $("#chk_imp_parcial").prop("checked", true);
                        $("#chk_imp_parcial").val("1");
                    }
                    else {
                        $("#chk_imp_parcial").prop("checked", false);
                        $("#chk_imp_parcial").val("0");
                    }
                    $("#txtcod_host").val(fona.CF_HOST);
                    $("#ddl_agr").val(fona.ID_AMUESTRA);
                }
                else {
                }
            });
        }
        //FILL DROPDOWNLIST ESTADO MANTENEDOR
        function Fill_Ddl_Estado_Mantenedor() {
            Mx_Ddl_Estado_Mant.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_ESTADO
                    }
                ).text(aaa.EST_DESCRIPCION).appendTo("#ddl_est");
            });
        }
        //FILL DROPDOWNLIST AGRUPACION MANTENEDOR
        function Fill_Ddl_Agrupacion_Mantenedor() {
            Mx_Ddl_Agrupacion_Mant.forEach(aax => {
                $("<option>", {
                    "value": aax.ID_AMUESTRA
                }
                ).text(aax.AMUE_DESC).appendTo("#ddl_agr");
            });
        }
        //FILL DATATABLE 
        function Fill_Dtt() {
            $("#DataTable_Fonasa tbody").empty();
            //Recorrer JSON
            //VAR i PARA ID DE CHK
            var i = 1
            Mx_Dtt.forEach(aah => {
                $("<tr>", {
                    "onclick": `Ajax_Llenar_Form("` + aah.ID_CODIGO_FONASA + `","` + i + `")`,
                    "class": "manito",
                    "id": aah.ID_CODIGO_FONASA
                }).append(
                     $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                     $("<td>").css("text-align", "left").text(aah.CF_COD),
                     $("<td>").css("text-align", "left").text(aah.CF_DESC),
                     //CREAR CHK CON ID
                     $("<td>").css("text-align", "center").html("<input type='checkbox' id='chk_Id_E" + i + "' value='" + aah.ID_ESTADO + "' />"),
                     $("<td>").css("text-align", "center").html("<input type='checkbox' id='chk_Id_S" + i + "' value='" + aah.CF_IMP_SOLA + "' />"),
                     $("<td>").css("text-align", "center").html("<input type='checkbox' id='chk_Id_N" + i + "' value='" + aah.CF_IMP_NOM_PER + "' />"),
                     $("<td>").css("text-align", "center").html("<input type='checkbox' id='chk_Id_P" + i + "' value='" + aah.CF_SEL_PRUE + "' />"),
                     $("<td>").css("text-align", "center").html("<input type='checkbox' id='chk_Id_I" + i + "' value='" + aah.CF_IMP_PARCIAL + "' />")
                ).appendTo("#DataTable_Fonasa tbody");
                //SI EL ESTADO DEL CHK ES 1.. CHECKEAR :B
                if (aah.ID_ESTADO == 1) {
                    $("#chk_Id_E" + i).prop("checked", true);
                }
                if (aah.CF_IMP_SOLA == 1) {
                    $("#chk_Id_S" + i).prop("checked", true);
                }
                if (aah.CF_IMP_NOM_PER == 1) {
                    $("#chk_Id_N" + i).prop("checked", true);
                }
                if (aah.CF_SEL_PRUE == 1) {
                    $("#chk_Id_P" + i).prop("checked", true);
                }
                if (aah.CF_IMP_PARCIAL == 1) {
                    $("#chk_Id_I" + i).prop("checked", true);
                }
                i += 1;
                Hide_Modal();
            });
            $("table").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        .manito {
            cursor: pointer;
        }
    </style>

    <div class="card-header bg-bar"><h5 class="text-center"><i class="fa fa-fw fa-info"></i>Información de Código Fonasa</h5></div>
        


        <div class="row mb-3">
            <div class="col-sm">
                <label for="txt_cod">Código</label>
                <input type="text" id="txt_cod" class="form-control" required />
            </div>
            <div class="col-sm">
                <label for="txt_des">Descripción</label>
                <input type="text" id="txt_des" class="form-control" required />
            </div>
            <div class="col-sm">
                <label for="txtdes_cor">Desc. Corta</label>
                <input type="text" id="txtdes_cor" class="form-control" required />
            </div>
            <div class="col-sm">
                <label for="txt_ndias">N° Días</label>
                <input type="number" id="txt_ndias" class="form-control" required />
            </div>
            <div class="col-sm">
                <label for="ddl_est">Estado</label>
                <select id="ddl_est" class="form-control"></select>
            </div>
        </div>
        <hr />
        <div class="row mb-3" id="div_chk">
            <div class="col-sm">
                <label for="chk_imp_una_pag">Imp. Una Página</label>
                <div class="form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" value="0" id="chk_imp_una_pag">
                        ACTIVO
                       
                    </label>
                </div>
            </div>
            <div class="col-sm">
                <label for="chk_imp_nom_est">Imp. Nom Estudio</label>
                <div class="form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" value="0" id="chk_imp_nom_est">
                        ACTIVO
                       
                    </label>
                </div>
            </div>
            <div class="col-sm">
                <label for="chk_imp_sel_prueba">Sel. Prueba</label>
                <div class="form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" value="0" id="chk_imp_sel_prueba">
                        ACTIVO
                       
                    </label>
                </div>
            </div>
            <div class="col-sm">
                <label for="chk_imp_parcial">Imp. Parcial</label>
                <div class="form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" value="0" id="chk_imp_parcial">
                        ACTIVO
                       
                    </label>
                </div>
            </div>
            <div class="col-sm">
                <label for="txtcod_host">Código HOST</label>
                <input type="text" id="txtcod_host" class="form-control" />
            </div>
            <div class="col-sm">
                <label for="ddl_agr">Agrupación</label>
                <select id="ddl_agr" class="form-control"></select>
            </div>
        </div>
        <hr />
        <div class="row mb-3" style="height: 41vh; overflow: auto;">
            <div class="col-sm-1"></div>
            <div class="col-sm-10">
                <table id="DataTable_Fonasa" cellspacing="0" class="table table-hover table-striped table-iris">
                    <thead>
                        <tr>
                            <th style="text-align: center">#</th>
                            <th style="text-align: center">Código</th>
                            <th style="width: 16vw;">Descripción</th>
                            <th class="text-center">Activo</th>
                            <th style="text-align: center">Imp. 1 Pag.</th>
                            <th style="text-align: center">Imp. Nom Est.</th>
                            <th style="text-align: center">Sel. Prueba</th>
                            <th style="text-align: center">Imp-Parcial.</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class="col-sm-1"></div>
        </div>
        <hr />
        <div class="row">
            <div class="col-sm">
                <button type="button" class="btn btn-print btn-block" style="padding:3px"><i class="fa fa-fw fa-file-text-o mr-2"></i>Indicaciones</button>
            </div>
            <div class="col-sm">
                <button type="button" class="btn btn-warning btn-block" style="padding:3px"><i class="fa fa-fw fa-link mr-2"></i>Asociar Estudio</button>
            </div>
            <div class="col-sm">
                <button type="button" class="btn btn-pendiente btn-block" style="padding:3px" id="btn_nuevo"><i class="fa fa-fw fa-plus mr-2"></i>Nuevo</button>
            </div>
            <div class="col-sm">
                <button type="button" class="btn btn-primary btn-block" style="padding:3px" id="btn_guardar"><i class="fa fa-fw fa-save mr-2"></i>Guardar</button>
            </div>
            <div class="col-sm">
                <button type="button" class="btn btn-info btn-block" style="padding:3px" id="btn_modificar"><i class="fa fa-fw fa-edit mr-2"></i>Modificar</button>
            </div>
            <div class="col-sm">
                <button type="button" class="btn btn-danger btn-block" style="padding:3px" id="btn_eliminar"><i class="fa fa-fw fa-remove mr-2"></i>Eliminar</button>
            </div>
            <div class="col-sm">
                <button type="button" class="btn btn-success btn-block" style="padding:3px"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
            </div>
        </div>


</asp:Content>
