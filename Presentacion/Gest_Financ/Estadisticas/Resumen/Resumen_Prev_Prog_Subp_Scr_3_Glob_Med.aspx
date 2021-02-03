<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx.vb" Inherits="Presentacion.Resumen_Prev_Prog_Subp_Scr_3_Glob_Med" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../../../js/HighCharts.js"></script>
    <script src="../../../js/highcharts-more.js"></script>
    <script src="../../../js/modules/sunburst.js"></script>
    <script src="../../../js/HighC_Exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        let _cont_mod = 0;
        let search_mode = 69;

        let IIDD_AATTEE = 0;
        let AATTEE_NNUUMM = 0;
        let aaaaiiiiiddddiiiiooouuuu = 0;


        let aidi_ate_owo = 0;
        let ate_num_owo = 0;
        let aidi_usuario_owo = 0;

        $(document).ready(() => {

            //CARGAR Y TRANSFORMA IMAGEN EN BASE64


            $(function () {
                $("#file1").change(function () {
                    if (this.files && this.files[0]) {
                        var reader = new FileReader();
                        reader.onload = imageIsLoaded;
                        reader.readAsDataURL(this.files[0]);
                    }
                });
            });

            // modal_show();
            $("#div_tabla_graph").hide();
            $("#Div_Tabla_Tot").hide();
            let dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);
            $('#Txt_Date01, #Txt_Date02').datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd-mm-yyyy',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minDate: Date.now(),
                minView: 2
            });
            Ajax_LugarTM();
            //Call_AJAX_Ddl_By_Rel();
            Ajax_Preve();
            //Ajax_Usu();
            Ajax_DL_DOC();

            //AJAX GUARDAR EN EL MODAL MARCAR
            $("#btn_Marcar").click(function () {
                console.log("click!");
                selected = new Array();
                $("input:checkbox:checked").each(function () {
                    selected.push($(this).val());
                });
                if (selected == "") {
                    $("#mError_AAH h4").text("Sin Selección");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No hay selección.");
                    $("#mError_AAH").modal();
                } else {
                    Ajax_Update();
                }
            });



            //$("#btn_Marcar_Modal").click(function () {
            //    console.log("click!");
            //    selected = new Array();
            //    $("input:checkbox:checked").each(function () {
            //        selected.push($(this).val());
            //    });
            //    if (selected == "") {
            //        $("#mError_AAH h4").text("Sin Selección");
            //        $("#mError_AAH button").attr("class", "btn btn-danger");
            //        $("#mError_AAH p").text("No hay selección.");
            //        $("#mError_AAH").modal();
            //    } else {
            //        Ajax_Update();
            //    }
            //});

            $("#btn_PRUEBA_ORDER_MED").click(() => {
                PRUEBA_ORDER_MED();
            });

            $("#Ddl_Preve").change(()=>{
                Ajax_Usu();
            });

            $("#btn_Buscar").click(() => {
                search_mode = 1;
                Ajax_DataTable_Select();
            });

            $("#btn_Buscar_Folio").click(() => {

                if ($("#txt_Folio").val() == "") {
                
                } else {
                    search_mode = 0;
                    Ajax_DataTable_Folio();
                }           
            });

            $("#btn_Excel").click(() => {
                if (search_mode == 69) { }
                else {
                    Ajax_Excel();
                }
                
            });

            $("#btn_PDF").click(() => {
                if (search_mode == 69) {

                } else {
                    Ajax_PDF();
                }
                
            });

            $("#btn_Escanear_confirm").click(() => {
                Call_Scan();
            });

            $("#btn_Upload_confirm").click(() => {

                var img_comp = $('#ImgMed').attr('src');
                //console.log(img_comp);
                if (img_comp == "" || img_comp == undefined) {

                } else {
                    PRUEBA_ORDER_MED();
                }
            });
        });

        function Marcar_Modalssss() {
            console.log("click!");
            selected = new Array();
            $("input:checkbox:checked").each(function () {
                selected.push($(this).val());
            });
            if (selected == "") {
                $("#mError_AAH h4").text("Sin Selección");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("No hay selección.");
                $("#mError_AAH").modal();
                console.log("empty!");
            } else {
                console.log("go!");
                Ajax_Update();
            }

        };

        function imageIsLoaded(e) {
            $('#ImgMed').attr('src', e.target.result);
            $("#ImgMed").removeAttr("hidden");
        };

        //ENVIA LA IMAGEN AL BACK CON EL TIPO DE ARCHIVO

        function PRUEBA_ORDER_MED() {
            modal_show();
            var img = $('#ImgMed').attr('src');
            var validador = img.split(",")
            var count = 0;
            //console.log(validador)
            var tp_order = ""
            switch (validador[0]) {
                case "data:text/plain;base64":
                    console.log(validador[0])
                    tp_order = "txt"
                    img = validador[1]
                    count = 0
                    break

                case "data:image/png;base64":
                    tp_order = "png";
                    img = validador[1];
                    count = 1;
                    break

                case "data:application/pdf;base64":
                    tp_order = "pdf";
                    img = validador[1];
                    count = 0;
                    break
                case "data:image/jpeg;base64":
                    tp_order = "jpeg";
                    img = validador[1];
                    count = 1;
                    break
            };

            if (count == 0) {
                Hide_Modal();
                $("#modal_segurin_upload").modal("hide");
                $("#mError_AAH h4").text("Formato Incompatible");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Estimado Usuario, el formato del documento no es compatible.");
                $("#mError_AAH").modal();
            } else {
                var datos = JSON.stringify({
                    "DOMAIN_URL": location.origin,
                    "imgbase64": img,
                    "tp_order": tp_order,
                    "ID_ATENCION":aidi_ate_owo,
                    "ID_USUARIO":aidi_usuario_owo,
                    "ATE_NUM":ate_num_owo

                });

                //console.log(datos);


                $.ajax({
                    "type": "POST",
                    "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/prueba_order_med",
                    "contentType": "application/json;  charset=utf-8",
                    "data": datos,
                    "dataType": "json",
                    "success": function (response) {
                        var json = response.d;
                        $("#modal_segurin_upload").modal("hide");
                        $("#mError_AAH h4").text("Documento");
                        $("#mError_AAH button").attr("class", "btn btn-success");
                        $("#mError_AAH p").text("Estimado Usuario, el Documento se ha cargado satisfactoriamente");
                        $("#mError_AAH").modal();


                        //console.log("paso por el success");
                        Hide_Modal();

                    },
                    "error": function (response) {
                        //console.log("paso por el ERROR");
                        Hide_Modal();
                        console.log(response);
                        var str_Error = "Error interno del Servidor";
                        //cModal_Error("Error", str_Error);
                    }
                });

            }
        }

        function c_modal() {
            if (_cont_mod == 3) {
                Hide_Modal();
            }
        }

        function params_to_Call_scann(IIDD_AATTasdasdEE, AATTEE_NNUasdasdUMM) {

            IIDD_AATTEE = IIDD_AATTasdasdEE;
            AATTEE_NNUUMM = AATTEE_NNUasdasdUMM;

            aaaaiiiiiddddiiiiooouuuu = Galletas.getGalleta("ID_USER");
            if (aaaaiiiiiddddiiiiooouuuu == "") {
                aaaaiiiiiddddiiiiooouuuu = 0;
            }

            $("#modal_segurin").modal();
        }

        function params_to_Call_upload(ID_ATEOWO, ATE_NUMOWO) {
            $("#file1").val("");
            $("#ImgMed").removeAttr("src");
            $('#ImgMed').attr("hidden","hidden");

            aidi_ate_owo = ID_ATEOWO;
            ate_num_owo = ATE_NUMOWO;
            aidi_usuario_owo = Galletas.getGalleta("ID_USER");;


            $("#modal_segurin_upload").modal();
        };

        function Call_Scan() {

            $("#modal_segurin").modal("hide");

            Data_Par = JSON.stringify({
                "ID_USUARIO": aaaaiiiiiddddiiiiooouuuu,
                "ID_ATENCION": IIDD_AATTEE,
                "ATE_NUM": AATTEE_NNUUMM
            });
            $.ajax({
                "type": "POST",
                "url": "http://localhost:9990/SCAN/SCAN_ASOC",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "timeout": 50000,
                "success": data => {
                    //Debug
                    Llenar_IMG();
                    ARR_IMG = [];
                },
                "error": data => {
                    //Debug
                }
            });
        }

        let Mx_IMG = [{
            "ID_FOTO_ATE": "",
            "IMG": "",
            "USU_NIC": "",
            "FECHA_ASOC": "",
            "FOTO_ATE_PLATAFORMA": ""
        }];

        function Llenar_IMG() {

            $("#Grid_Img").empty();
            let Data_Par = JSON.stringify({
                "ID_ATENCION": AATTEE_NNUUMM//$("#txt_Folio").val()
            });
            //Debug
            AJAX_Ddl = $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Get_Img",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {

                    Mx_IMG = data.d;
                    IIDD_AATTEE = 0;
                   
                    
                    //Debug
                    if (Mx_IMG != null) {
                        Fill_IMG();
                    } else {
                        AATTEE_NNUUMM = 0;
                        //Debug
                        Hide_Modal();
                    }
                },
                "error": data => {
                    //Debug
                    AATTEE_NNUUMM = 0;
                    Hide_Modal();
                }
            });

        }

        let ARR_IMG = [];

        function Desasoc(ID_FOTO_ATE) {
            Data_Par = JSON.stringify({
                "ID_FOTO_ATE": ID_FOTO_ATE
            });
            //console.log(ARR_IMG);
            //console.log(Data_Par);
            AJAX_Grabar = $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Elimina_Asoc",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    //console.log("Si: " + data);
                    $("#Mdl_Image_Ate").modal("hide");
                    
                    $("#modal_Imagenes").modal("hide");
                    //$("#Mdl_Image_Ate_2").hide();
                    $("#Mdl_Image_Ate").hide();

                    if (search_mode == 0) {
                        Ajax_DataTable_Folio();
                    } else {
                        Ajax_DataTable_Select();
                    }
                    Ajax_DataTable_Select();

                    //Llenar_IMG();
                    //Llenar_IMG_Asoc();
                    ARR_IMG = [];
                },
                "error": data => {
                    console.log(data);
                    //Debug
                }
            });
        }

        function Fill_IMG_Fill(atetetete_nummmmmumumu) {
            AATTEE_NNUUMM = atetetete_nummmmmumumu;
            Llenar_IMG();
        };

        function Fill_IMG() {
            $("#modal_Imagenes .modal-footer").html("<button type='button' class='btn btn-danger' data-dismiss='modal'><i class='fa fa-fw fa-remove mr-2'></i>Cerrar</button>");
            Ajax_DataTable_Folio_Modal(AATTEE_NNUUMM);
            AATTEE_NNUUMM = 0;
            //$("#Grid_Img").empty();
            $("#Mdl_Image_Ate_2 img").attr("src", "");
            let count = 0;
            let count_div = 1;
            let D_Index = 0;
            let _D_Count = 1;
            $("#Grid_Img").append(
                $("<div id='div_Img_" + count_div + "' class='row mt-2 pl-4' style='max-width:calc(100% - 20px) !important'></div>")
                );
            Mx_IMG.forEach((imgx) => {
                if (imgx.IMG.length > 300) {
                    count += 1;
                    let _Plat;
                    if (imgx.FOTO_ATE_PLATAFORMA == 2) {
                        _Plat = "(PC)";
                    } else {
                        _Plat = "(APP)";

                    }
                    if (imgx.USU_NIC != null) {
                        Nombre_Doc = imgx.USU_NIC + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                    } else {
                        Nombre_Doc = "Web" + " " + _Plat + " </br> " + moment(imgx.FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss");
                        _D_Count += 1;
                    }
                    $("#div_Img_" + count_div).append(
                    ("<div class='col gallery-docs'><img src='data:image/jpeg;base64," + imgx.IMG + "' class='mt-2' style='max-height:200px; max-width:150px; cursor:pointer;' name='show_img' data-index='" + D_Index + "'/><div class='row'><div class='col-lg text-center' style='height:56px'><label>" + Nombre_Doc + "</label></div</div></div>")
                    );

                    if (count == 5) {
                        count = 0;
                        count_div += 1;
                        $("#Grid_Img").append(
                        $("<div id='div_Img_" + count_div + "' class='row pl-4' style='max-width:calc(100% - 20px) !important'></div>")
                        );
                    }
                }
                D_Index += 1;
                if (Mx_IMG.length == D_Index) {
                    let restt = 5 - count;
                    for (xx = 1; xx <= restt; xx++) {
                        $("#div_Img_" + count_div).append(
                             ("<div class='col-lg'></div>")
                            );
                    }
                }
            });
            $("img[name='show_img']").click(function () {
                let ii = $(this).attr("data-index");
                //Show_Image(ii)
                Show_Image_2(ii);
            });

            //$("img[name='show_img_2']").click(function () {
            //    let ii = $(this).attr("data-index");
            //    Show_Image(ii)
            //});

            //Hide_Modal();
            $("#modal_Imagenes").modal();
        }

        function Show_Image(i) {
            
            let img = parseInt(i) + 1;
            let Nombre_Doc_S;

            let _Plat;
            if (Mx_IMG[i].FOTO_ATE_PLATAFORMA == 2) {
                _Plat = "(PC)";
            } else {
                _Plat = "(APP)";
            }

            if (Mx_IMG[i].USU_NIC != null) {
                Nombre_Doc_S = Mx_IMG[i].USU_NIC + " - " + moment(Mx_IMG[i].FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss") + " " + _Plat;
            } else {
                Nombre_Doc_S = "Web - " + moment(Mx_IMG[i].FECHA_ASOC).format("DD/MM/YYYY HH:mm:ss") + " " + _Plat;
            }
            $("#mod_Name").text(Nombre_Doc_S);
            $("#Mdl_Image_Ate img").attr("src", "data:image/jpeg;base64," + Mx_IMG[i].IMG);
            $("#Mdl_Image_Ate .modal-footer").html("<button type='button' class='btn btn-warning' onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            $("#Mdl_Image_Ate").modal();
        }

        function Show_Image_2(i) {
            let img = parseInt(i);// + 1;
            let Nombre_Doc_S;
            //$("#mod_Name").text(Nombre_Doc_S);
            $("#Mdl_Image_Ate_2 img").attr("src", "data:image/jpeg;base64," + Mx_IMG[i].IMG );
            $("#Mdl_Image_Ate_2 img").attr("name", "show_img_2");
            $("#Mdl_Image_Ate_2 img").attr("data-index", img);
            
            $("#modal_Imagenes .modal-footer").html("<button type='button' id='btn_Marcar_Modal' class='btn btn-limpiar' onClick='Marcar_Modalssss();'><i class='fa fa-crosshairs fa-fw'></i>Marcar</button><button type='button' class='btn btn-warning' onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'><i class='fa fa-fw fa-remove mr-2'></i>Cerrar</button>");

                         
                    

            //$("#Mdl_Image_Ate_2 .modal-footer").html("<button type='button' class='btn btn-warning' onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            //$("#Mdl_Image_Ate_2 img").attr("onClick", "Show_Image(" + img + ");");                                    FUNCION DE IMAGEN GRANDE <-------------------------------
            //$("#Mdl_Image_Ate_2 img").css("cursor", "pointer");
            //$("#Mdl_Image_Ate_2 .modal-footer").html("<button type='button' class='btn btn-warning'>Desvincular</button><button type='button' class='btn btn-danger' data-dismiss='modal'>Cerrar</button>");
            // onClick='Desasoc(" + Mx_IMG[i].ID_FOTO_ATE + ");'
            //$("#Mdl_Image_Ate").modal();
        }


        let Mx_Dtt_LugarTM = [{
            "ID_ESTADO": 0,
            "PROC_DESC": 0,
            "PROC_COD": 0,
            "ID_PROCEDENCIA": 0
        }];
        function Ajax_LugarTM() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_Ddl_LugarTM",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_LugarTM = json_receiver;
                        Fill_Ddl_LugarTM();
                        //Call_AJAX_Ddl_By_Rel();
                    } else {
                    
                    }
                },
                "error": function (response) {
                
                }
            });
        }


        function Fill_Ddl_LugarTM() {
            $("#Ddl_LugarTM").empty();

            var procee = Galletas.getGalleta("USU_ID_PROC");
            var ide_admin = Galletas.getGalleta("P_ADMIN");

            if (ide_admin == 1 || procee == 0) {
                //console.log("admin");
                Mx_Dtt_LugarTM.forEach(aaa => {
                    $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                });
            } else {
                    Mx_Dtt_LugarTM.forEach(aaa => {
                        if (aaa.ID_PROCEDENCIA == procee) {
                            $("<option>", { "value": aaa.ID_PROCEDENCIA }).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
                        }
                    });
            }
                
            

            //var procee = Galletas.getGalleta("USU_ID_PROC");

            //if (procee == 0 || procee == "0") {

            //    Mx_Dtt_LugarTM.forEach(aaa => {
            //        $("<option>",
            //            {
            //                "value": aaa.ID_PROCEDENCIA
            //            }
            //        ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
            //    });
            //}
            //else {
            //    Mx_Dtt_LugarTM.forEach(aaa => {
            //        if (aaa.ID_PROCEDENCIA == procee) {
            //            $("<option>",
            //              {
            //                  "value": aaa.ID_PROCEDENCIA
            //              }
            //           ).text(aaa.PROC_DESC).appendTo("#Ddl_LugarTM");
            //        }

            //    });
            //}

            _cont_mod += 1;
            c_modal();
        };

        let Mx_Dtt_Preve = [{
            "ID_ESTADO": 0,
            "PREVE_DESC": 0,
            "PREVE_COD": 0,
            "ID_PREVE": 0
        }];
        function Ajax_Preve() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_Ddl_Prevision",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Preve = json_receiver;
                        Fill_Ddl_Preve();
                    } else {
                 
                    }
                },
                "error": function (response) {
           
                }
            });
        }
        function Fill_Ddl_Preve() {
            $("#Ddl_Preve").empty();

            var preveee = Galletas.getGalleta("USU_PREV");

            if (preveee == 0) {
                $("<option>",{"value": 0}).text("Todos").appendTo("#Ddl_Preve");
                Mx_Dtt_Preve.forEach(aaa => {
                    $("<option>",
                        {
                            "value": aaa.ID_PREVE
                        }
                    ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
                });
            }
            else {
                Mx_Dtt_Preve.forEach(aaa => {
                    if (aaa.ID_PREVE == preveee) {
                        $("<option>",
                          {
                              "value": aaa.ID_PREVE
                          }
                       ).text(aaa.PREVE_DESC).appendTo("#Ddl_Preve");
                    }

                });
            }

            _cont_mod += 1;
            c_modal();
            
        };

        var Mx_Ddl_Proc_By_rel = [
        {
            "ID_PROCEDENCIA": "",
            "PROC_COD": "",
            "PROC_DESC": "",
            "ID_ESTADO": ""
        }
        ];
        function Call_AJAX_Ddl_By_Rel() {



            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_REL_USU_PROC_TABLE",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Ddl_Proc_By_rel = JSON.parse(json_receiver);

                        //Fill_AJAX_Ddl();

                    } else {

                    }
                    Fill_Ddl_LugarTM();
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    alert("Error", str_Error);


                }
            });
        }

        var Mx_DL_DOC = [
{
    "ID_DOCTOR": 0,
    "DOC_NOMBRE": "asdf",
    "DOC_APELLIDO": "asdf",
    "ID_ESTADO": 0
}
        ];
        function Ajax_DL_DOC() {



            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_DL_DOC",
                //"data": '{}',
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_DL_DOC = json_receiver;
                        Fill_DL_DOC();

                    } else {



                    }
                },
                "error": function (response) {

                    var str_Error = "Error interno del Servidor";
                    cModal_Error("Error", str_Error);


                }
            });
        }

        function Fill_DL_DOC() {
            $("#Doctor").empty();

            $("<option>", {"value": 0}).text("Todos").appendTo("#Doctor");

            for (y = 0; y < Mx_DL_DOC.length; ++y) {
                $("<option>", {
                    "value": Mx_DL_DOC[y].ID_DOCTOR
                }).text(Mx_DL_DOC[y].DOC_NOMBRE + " " + Mx_DL_DOC[y].DOC_APELLIDO).appendTo("#Doctor");
            }
        }

        let Mx_Dtt_Usu = [{
            "ID_USUARIO": 0,
            "USU_NOMBRE": 0,
            "USU_APELLIDO": 0,
            "USU_NIC": 0
        }];



        function Ajax_Usu() {

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Call_User_Data",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Usu = json_receiver;
                        Fill_Ddl_Usu();
                    } else {
                      
                    }
                },
                "error": function (response) {
                 
                }
            });
        }

        let Mx_Dtt_Progra = [{
            "ID_ESTADO": 0,
            "PROGRA_DESC": 0,
            "PROGRA_COD": 0,
            "ID_PROGRA": 0
        }];
        function Ajax_Progra() {
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_Ddl_Programa",
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Progra = json_receiver;
                        Fill_Ddl_Progra();
                    } else {
               
                    }
                },
                "error": function (response) {
                
                }
            });
        }
        function Fill_Ddl_Progra() {
            $("#Ddl_Progra").empty();

            $("<option>",
            {
                "value": "0"
            }
            ).text("Todos").appendTo("#Ddl_Progra");
            Mx_Dtt_Progra.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_PROGRA
                    }
                ).text(aaa.PROGRA_DESC).appendTo("#Ddl_Progra");
            });
            _cont_mod += 1;
            c_modal();
        };

        function Fill_Ddl_Usu() {
            $("#Ddl_Usu").empty();

            $("<option>",{"value": 0}).text("Todos").appendTo("#Ddl_Usu");
            Mx_Dtt_Usu.forEach(aaa => {
                $("<option>",
                    {
                        "value": aaa.ID_USUARIO
                    }
                ).text(aaa.USU_NIC + " " + aaa.USU_NOMBRE + " " + aaa.USU_APELLIDO).appendTo("#Ddl_Usu");
            });
        };


        let Mx_Dtt = [{
            ATE_NUM:"", 
            ATE_FECHA:"", 
            ATE_DET_V_ID_ESTADO:"", 
            EST_DESCRIPCION:"", 
            CF_COD:"", 
            CF_DESC:"", 
            ID_CODIGO_FONASA:"", 
            ID_ATENCION:"", 
            PAC_NOMBRE:"", 
            PAC_APELLIDO:"", 
            PROC_DESC:"", 
            ID_PROCEDENCIA:"", 
            ATE_AÑO:"", 
            SEXO_DESC:"", 
            ID_PACIENTE:"", 
            ID_SEXO:"", 
            ID_ESTADO:"", 
            PAC_RUT:"", 
            PAC_FNAC:"", 
            ATE_DET_V_PREVI:"", 
            ATE_MES:"", 
            ATE_DIA:"", 
            TP_PAGO_DESC:"", 
            DOC_NOMBRE:"", 
            DOC_APELLIDO:"", 
            PROGRA_DESC:"", 
            ORD_DESC:"", 
            ATE_DET_V_PAGADO:"", 
            ATE_DET_V_COPAGO:"", 
            ID_USUARIO:"", 
            USUARIO_DET:"", 
            REVE_DESC:"", 
            USU_REV:"", 
            USU_CRE:"", 
            ATE_DET_RCAJA_ESTADO:"", 
            ATE_DET_RCAJA_FECHA:"", 
            ATE_DET_RCAJA_VALORD:"", 
            ATE_DET_RCAJA_VALORU:"", 
            ID_DET_ATE: "",
            ID_PREVE: "",
            ATE_DET_VALOR_BENEF: "",
            ATE_DET_VALOR_CS: "",
            DOCS_CANT:""
        }];
        function Ajax_DataTable_Folio() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": 0,//$("#Ddl_LugarTM").val(),
                "PREV": 0,//$("#Ddl_Preve").val(),
                "ID_USER": $("#Doctor").val(),
                "ATE_NUM": $("#txt_Folio").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_DataTable",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        //$("#graph").show();
                        $("#div_tabla_graph").show();

                        $("#Div_Tabla_Tot").show();
                    } else {
              
                        $("#Div_Tabla").empty();
                        $("#graph").hide();
                        $("#div_tabla_graph").hide();
                        $("#Div_Tabla_Tot").hide();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
               
                    $("#Div_Tabla").empty();
                    $("#graph").hide();
                    Hide_Modal();
                }
            });
        }

        let Mx_Dtt_Modal = [{
            ATE_NUM:"", 
            ATE_FECHA:"", 
            ATE_DET_V_ID_ESTADO:"", 
            EST_DESCRIPCION:"", 
            CF_COD:"", 
            CF_DESC:"", 
            ID_CODIGO_FONASA:"", 
            ID_ATENCION:"", 
            PAC_NOMBRE:"", 
            PAC_APELLIDO:"", 
            PROC_DESC:"", 
            ID_PROCEDENCIA:"", 
            ATE_AÑO:"", 
            SEXO_DESC:"", 
            ID_PACIENTE:"", 
            ID_SEXO:"", 
            ID_ESTADO:"", 
            PAC_RUT:"", 
            PAC_FNAC:"", 
            ATE_DET_V_PREVI:"", 
            ATE_MES:"", 
            ATE_DIA:"", 
            TP_PAGO_DESC:"", 
            DOC_NOMBRE:"", 
            DOC_APELLIDO:"", 
            PROGRA_DESC:"", 
            ORD_DESC:"", 
            ATE_DET_V_PAGADO:"", 
            ATE_DET_V_COPAGO:"", 
            ID_USUARIO:"", 
            USUARIO_DET:"", 
            REVE_DESC:"", 
            USU_REV:"", 
            USU_CRE:"", 
            ATE_DET_RCAJA_ESTADO:"", 
            ATE_DET_RCAJA_FECHA:"", 
            ATE_DET_RCAJA_VALORD:"", 
            ATE_DET_RCAJA_VALORU:"", 
            ID_DET_ATE: "",
            ID_PREVE: "",
            ATE_DET_VALOR_BENEF: "",
            ATE_DET_VALOR_CS: "",
            DOCS_CANT:""
        }];
        function Ajax_DataTable_Folio_Modal(atetetete_nummmmmumumuummumumu) {
            //console.log("enter function");
            modal_show();
            let Data_Par = JSON.stringify({
                "ATE_NUM": atetetete_nummmmmumumuummumumu
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_DataTable_Modal",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt_Modal = json_receiver;
                        $("#Div_Tabla_Modal").empty();
                        Hide_Modal();
                        $("#lbl_tiiiitle").text("Listado de Documentos " + " " + "N° Atención: " + Mx_Dtt_Modal[0].ATE_NUM + " - "  + "Pac. Nombre: " + Mx_Dtt_Modal[0].PAC_NOMBRE + " " + Mx_Dtt_Modal[0].PAC_APELLIDO);
                        //$("#lbl_pac_nom").text("N° Ate: " + Mx_Dtt_Modal[0].ATE_NUM);
                        //$("#lbl_ate_num").text("Pac. Nombre: " + Mx_Dtt_Modal[0].PAC_NOMBRE + " " + Mx_Dtt_Modal[0].PAC_APELLIDO);

                        Fill_DataTable_Modal();
                    } else {
              
                        $("#Div_Tabla_Modal").empty();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
               
                    Hide_Modal();
                }
            });
        }

        function Ajax_DataTable_Select() {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "TP_PAGO":0,
                "PREV": $("#Ddl_Preve").val(),
                "ID_USER": $("#Doctor").val(),
                "ID_ESTADO": $("#ddl_estado").val()
            });

            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Llenar_DataTable_Select",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Dtt = json_receiver;
                        $("#Div_Tabla").empty();
                        Fill_DataTable();
                        //$("#graph").show();
                        $("#div_tabla_graph").show();

                        $("#Div_Tabla_Tot").show();
                    } else {

                        $("#Div_Tabla").empty();
                        $("#graph").hide();
                        $("#div_tabla_graph").hide();
                        $("#Div_Tabla_Tot").hide();
                        Hide_Modal();
                    }
                },
                "error": function (response) {

                    $("#Div_Tabla").empty();
                    $("#graph").hide();
                    Hide_Modal();
                }
            });
        }

        function Ajax_Update() {
            let aaaaiiiiiddddiiii = Galletas.getGalleta("ID_USER");
            modal_show();
            let Data_Par = JSON.stringify({
                "MUESTRA": selected,
                "ID_USUARIO": aaaaiiiiiddddiiii
            });
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Ajax_Update",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        $("#modal_Imagenes").modal("hide");
                        if (search_mode == 0) {
                            Ajax_DataTable_Folio();
                        } else {
                            Ajax_DataTable_Select();
                        }
                        
                        Hide_Modal();
                    } else {
                        $("#modal_Imagenes").modal("hide");
                        $("#Div_Tabla").empty();
                        $("#graph").hide();
                        $("#div_tabla_graph").hide();
                        $("#Div_Tabla_Tot").hide();
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    $("#modal_Imagenes").modal("hide");
                    $("#Div_Tabla").empty();
                    $("#graph").hide();
                    Hide_Modal();
                }
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        function Fill_DataTable() {

            $("#Div_Tabla").empty();

            //$("#Div_Tabla").html("<div class='row'><div class='col-lg'><h4 class='text-danger pl-3'>Valorización Total: $<span id='val_total'></span></h4></div><div class='col-lg'><h4>Atenciones: <span id='tot_at'></span> - Exámenes Validados: <span id='tot_cf'></span> </h4></div></div>");

            $("<table>", {
                "id": "DataTable",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#DataTable").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable thead").attr("class", "cabzera");
            $("#DataTable thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),              
                    $("<th>", { "class": "textoReducido" }).text("N° Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha"),
                    $("<th>", { "class": "textoReducido" }).text("Paciente Nombre"),
                    $("<th>", { "class": "textoReducido" }).text("Procedencia"),
                    $("<th>", { "class": "textoReducido" }).text("Previsión"),
                    //$("<th>", { "class": "textoReducido" }).text("Usuario"),
                    $("<th>", { "class": "textoReducido" }).text("Exámenes"),
                    $("<th>", { "class": "textoReducido" }).text("Cod. Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("F. Pago"),
                    $("<th>", { "class": "textoReducido" }).text("Total Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Pagado"),
                    $("<th>", { "class": "textoReducido" }).text("Copago"),
                    $("<th>", { "class": "textoReducido" }).text("Particular"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Bonificación"),
                    $("<th>", { "class": "textoReducido" }).text("Seguro Complementario"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario Creación"),
                    $("<th>", { "class": "textoReducido" }).text("Médico"),
                    $("<th>", { "class": "textoReducido" }).text("Revisado"),
                    $("<th>", { "class": "textoReducido" }).text("Fecha Revisión"),
                    $("<th>", { "class": "textoReducido" }).text("Usuario Revisión"),
                    $("<th>", { "class": "textoReducido" }, { "text-align": "center" }).text("Órdenes"),
                    $("<th>", { "class": "textoReducido" }, { "text-align": "center" }).text("Cargar"),
                    $("<th>", { "class": "textoReducido" }, { "text-align": "right" }).text("Subir Doc."),
                    $("<th>", { "class": "textoReducido" }, { "text-align": "right" }).text("Ver Documentos")
                )
            );

            for (i = 0; i < Mx_Dtt.length; i++) {
                $("#DataTable tbody").append(
                    $("<tr>", {
                        //"onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)`,
                        //"ondblclick": `Ajax_ONCLICK_2("` + Mx_Dtt[i].ID_USUARIO + `","` + Mx_Dtt[i].ID_ATENCION + `",)`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].ATE_NUM),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(moment(Mx_Dtt[i].ATE_FECHA).format("DD-MM-YYYY HH:mm")),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PAC_NOMBRE + " " + Mx_Dtt[i].PAC_APELLIDO),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PROC_DESC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PREVE_DESC),
                        //$("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_NIC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_DESC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].CF_COD),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].TP_PAGO_DESC),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PREVI)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PAGADO)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_V_COPAGO)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].TP_PAGO_DESC == "Efectivo" || Mx_Dtt[i].TP_PAGO_DESC == "Particular" || Mx_Dtt[i].TP_PAGO_DESC == "Cheque" || Mx_Dtt[i].TP_PAGO_DESC == "Transferencia") {
                                return ("$" + addCommas(Mx_Dtt[i].ATE_DET_V_PAGADO));
                            } else {
                                return "$" + 0;
                            }
                        }),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_VALOR_BENEF)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt[i].ATE_DET_VALOR_CS)),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USUARIO_DET),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].DOC_NOMBRE + " " + Mx_Dtt[i].DOC_APELLIDO),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].USU_REV == "" || Mx_Dtt[i].USU_REV == null) {
                                $(this).html("<div class='checkbox checkbox-success pz'><input type='checkbox' value='" + Mx_Dtt[i].ID_DET_ATE + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                            } else {
                                $(this).html("<div class='checkbox checkbox-success pz'><input type='checkbox' checked='checked' disabled='disabled' value='" + 0 + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt[i].USU_REV == "" || Mx_Dtt[i].USU_REV == null) {
                                return "";
                            } else {
                                return moment(Mx_Dtt[i].ATE_DET_RCAJA_FECHA).format("DD-MM-YYYY HH:mm");
                            }
                        }),
                        $("<td>", { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }, { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].USU_REV),
                        $("<td>",{ "text-align": "center" }, { "onclick": `Ajax_ONCLICK("` + Mx_Dtt[i].ID_ATENCION + `",)` }).text(function () {
                            if (Mx_Dtt[i].DOCS_CANT == 0) {
                                return "-/-";
                            } else {
                                return Mx_Dtt[i].DOCS_CANT;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            $(this).append("<button type='button' class='btn btn-warning btn-sm' onclick='params_to_Call_scann(" + Mx_Dtt[i].ID_ATENCION + "," + Mx_Dtt[i].ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Escanear</button>");
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            $(this).append("<button type='button' class='btn btn-limpiar btn-sm' onclick='params_to_Call_upload(" + Mx_Dtt[i].ID_ATENCION + "," + Mx_Dtt[i].ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Subir Doc.</button>");
                        }),
                        $("<td>", { "align": "right" }, { "class": "textoReducido" }).text(function () {
                            //$(this).append("<button type='button' class='btn btn-info btn-sm' onclick='Ajax_ONCLICK_2(" + Mx_Dtt[i].ID_USUARIO + "," + Mx_Dtt[i].ID_ATENCION + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver</button>");
                            $(this).append("<button type='button' class='btn btn-info btn-sm' onclick='Fill_IMG_Fill(" + Mx_Dtt[i].ATE_NUM + ")'><i class='fa fa-fw fa-file-text mr-2'></i>Ver</button>");


                        })


                    )
                );
                
            }


            $("#DataTable").DataTable({
                "bSort": false,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay coincidencias",
                    "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });


            //$("#a-right").css("text-align", "right");
            let _v_total = 0;
            let t_att = 0;
            let t_exx = 0;
            Mx_Dtt.forEach(aah=> {
                _v_total += aah.TOT_VAL;
                t_att += aah.TOT_ATE;
                t_exx += aah.TOT_CF;
            });
            $("#val_total").text(addCommas(_v_total));
            $("#tot_at").text(t_att);
            $("#tot_cf").text(t_exx);
            

            let copaaaa = 0;
            let partiiii = 0;
            let desccc = 0;
            let toot_sistemmm = 0;
            let tooot_pagado = 0;
            let tooot_copa = 0;
            let toooot_benef = 0
            let toooot_SC = 0;
            let toootototot_particull = 0;

            Mx_Dtt.forEach(aah=> {

                copaaaa += 1 + parseInt(1);
                partiiii += parseInt(1) + parseInt(1);
                desccc += parseInt(1);
                toot_sistemmm += parseInt(aah.ATE_DET_V_PREVI)
                tooot_pagado += parseInt(aah.ATE_DET_V_PAGADO)
                tooot_copa += parseInt(aah.ATE_DET_V_COPAGO)        
                toooot_benef += parseInt(aah.ATE_DET_VALOR_BENEF)
                toooot_SC += parseInt(aah.ATE_DET_VALOR_CS)

                if (aah.TP_PAGO_DESC == "Efectivo" || aah.TP_PAGO_DESC == "Particular" || aah.TP_PAGO_DESC == "Cheque" || aah.TP_PAGO_DESC == "Transferencia") {
                    toootototot_particull += parseInt(aah.ATE_DET_V_PAGADO)
                }
            });

            Hide_Modal();


            $("#Div_Tabla_Tot").empty();

            //$("#Div_Tabla").html("<div class='row'><div class='col-lg'><h4 class='text-danger pl-3'>Valorización Total: $<span id='val_total'></span></h4></div><div class='col-lg'><h4>Atenciones: <span id='tot_at'></span> - Exámenes Validados: <span id='tot_cf'></span> </h4></div></div>");

            $("<table>", {
                "id": "DataTable_Tot",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Tot");

            $("#DataTable_Tot").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Tot").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Tot thead").attr("class", "cabzera");
            $("#DataTable_Tot thead").append(
                $("<tr>").append(
                    //$("<th>", { "class": "textoReducido" }).text("Total Atenciones"),
                    $("<th>", { "align": "right" },{ "class": "textoReducido " }).text("Total Exámenes"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Atención"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Pagado"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Copago"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Particular"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total Bonificación"),
                    $("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Total S. Complementario")
                    //$("<th>", { "align": "right" }, { "class": "textoReducido " }).text("Descuentos")
                )
            );

                $("#DataTable_Tot tbody").append(
                    $("<tr>").append(
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt.length),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt.length),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toot_sistemmm)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(tooot_pagado)),   
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(tooot_copa)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toootototot_particull)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toooot_benef)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(toooot_SC))
                        //$("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(desccc))
                    )
                );
            
            
            Hide_Modal();

            do_Chart_1();


        }


        // ------------------------------------- TABLA MODAL --------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------

        function Fill_DataTable_Modal() {

            $("#Div_Tabla_Modal").empty();

            //$("#Div_Tabla").html("<div class='row'><div class='col-lg'><h4 class='text-danger pl-3'>Valorización Total: $<span id='val_total'></span></h4></div><div class='col-lg'><h4>Atenciones: <span id='tot_at'></span> - Exámenes Validados: <span id='tot_cf'></span> </h4></div></div>");

            $("<table>", {
                "id": "DataTable_Modal",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Modal");

            $("#DataTable_Modal").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_Modal").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_Modal thead").attr("class", "cabzera");
            $("#DataTable_Modal thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Exámenes"),
                    $("<th>", { "class": "textoReducido" }).text("Cod. Fonasa"),
                    $("<th>", { "class": "textoReducido" }).text("F. Pago"),
                    $("<th>", { "class": "textoReducido" }).text("Total Atención"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Pagado"),
                    $("<th>", { "class": "textoReducido" }).text("Copago"),
                    $("<th>", { "class": "textoReducido" }).text("Particular"),
                    $("<th>", { "class": "textoReducido" }).text("Valor Bonificación"),
                    $("<th>", { "class": "textoReducido" }).text("Seguro Complementario"),
                    $("<th>", { "class": "textoReducido" }).text("Revisado")
                )
            );

            for (i = 0; i < Mx_Dtt_Modal.length; i++) {
                $("#DataTable_Modal tbody").append(
                    $("<tr>", {
                        "class": "manito"
                    }).append(
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modal[i].CF_DESC),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modal[i].CF_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_Modal[i].TP_PAGO_DESC),
                        $("<td>", { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modal[i].ATE_DET_V_PREVI)),
                        $("<td>", { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modal[i].ATE_DET_V_PAGADO)),
                        $("<td>", { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modal[i].ATE_DET_V_COPAGO)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt_Modal[i].TP_PAGO_DESC == "Efectivo" || Mx_Dtt_Modal[i].TP_PAGO_DESC == "Particular" || Mx_Dtt_Modal[i].TP_PAGO_DESC == "Cheque" || Mx_Dtt_Modal[i].TP_PAGO_DESC == "Transferencia") {
                                return ("$" + addCommas(Mx_Dtt_Modal[i].ATE_DET_V_PAGADO));
                            } else {
                                return "$" + 0;
                            }
                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modal[i].ATE_DET_VALOR_BENEF)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text("$" + addCommas(Mx_Dtt_Modal[i].ATE_DET_VALOR_CS)),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                            if (Mx_Dtt_Modal[i].USU_REV == "" || Mx_Dtt_Modal[i].USU_REV == null) {
                                $(this).html("<div class='checkbox checkbox-success pz'><input type='checkbox' value='" + Mx_Dtt_Modal[i].ID_DET_ATE + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                            } else {
                                $(this).html("<div class='checkbox checkbox-success pz'><input type='checkbox' checked='checked' disabled='disabled' value='" + 0 + "' class='manitos2' id='Hasdasd" + i + "'/><label class='manitos2' for='Hasdasd" + i + "'></label></div>")
                            }
                        })


                    )
                );

            }

        }
        // --------------------------------- FIN TABLA MODAL --------------------------------------------------



        function Ajax_ONCLICK(_PROG) {
            var loc = location.origin;
            window.open(loc + "/Gest_Financ/Estadisticas/Detalle/Det_Proc_Prev_Prog_Scr_2.aspx?&P3=" + _PROG);
        }

        function Ajax_ONCLICK_2(ID_USU, ID_ATE) {
            var loc = location.origin;
            window.open(loc + "/Scan_Docs/Ver_Orden.aspx?IDU=" + ID_USU + "&IDA=" + ID_ATE);
        }

        function do_Chart_1() {
   
            let Mx_Tot = [];
            let Mx_Data = [];
            let Mx_Cate = [];
            let Cant_Tot = 0;

            let tota_copa = 0;
            let tota_parti = 0;
            let dessssscccccc = 0;

            let tot_ssssiiiisttteeemmmaaa = 0;
            let tooot_pagadoooo = 0;
            let tooot_copaooo = 0;
            let tootototot_benef = 0;
            let tooottotot_SCCC = 0;
            let toooot_partiiii = 0;

            Mx_Dtt.forEach(aah=> {

                tot_ssssiiiisttteeemmmaaa += parseInt(aah.ATE_DET_V_PREVI)
                tooot_pagadoooo += parseInt(aah.ATE_DET_V_PAGADO)
                tooot_copaooo += parseInt(aah.ATE_DET_V_COPAGO)
                tootototot_benef += parseInt(aah.ATE_DET_VALOR_BENEF)
                tooottotot_SCCC += parseInt(aah.ATE_DET_VALOR_CS)

                if (aah.TP_PAGO_DESC == "Efectivo" || aah.TP_PAGO_DESC == "Particular" || aah.TP_PAGO_DESC == "Cheque" || aah.TP_PAGO_DESC == "Transferencia") {
                    toooot_partiiii += parseInt(aah.ATE_DET_V_PAGADO)
                }
            });

            let BUUM = parseInt(tot_ssssiiiisttteeemmmaaa)//parseInt(tota_copa) + parseInt(tota_parti) + parseInt(dessssscccccc);
   
            Highcharts.setOptions({
                lang: {
                    thousandsSep: '.'
                }
            })

            Highcharts.chart('chrt_1', {
                chart: {
                    type: 'column',
                    height: '50%'
                },
                credits: {
                    enabled: false
                },
                title: {
                    text: 'Valorización de Exámenes',
                    margin: 50
                },
                subtitle: {
                    text: 'Total Atención:  $' + addCommas(BUUM)
                    ,
                    style: {
                        color: '#ff0000',
                        fontWeight: 'bold'
                    }
                },
                xAxis: {
                    categories: [
                    'Total Atención',
                    'Total Pagado',
                    'Total Copago',
                    'Total Particular',
                    'Total Bonificación',
                    'Total S. Complementario'
                    ],
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Total (CLP)'
                    },
                    stackLabels: {
                        enabled: true,
                        format: '${total:,.0f}'
                    },
                    labels: {
                        format: "${value:,.0f}"
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr>' +
                        '<td style="padding:0"><b>${point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    series: {
                        colorByPoint: true,
                        dataLabels: {
                            enabled: true,
                            format: '${point.y:,.0f}',
                            rotation: -90,
                            y: -40,
                            color: "#666666",
                            crop: false
                        }
                    },
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    showInLegend: false,
                    name: 'platita',
                    data: [tot_ssssiiiisttteeemmmaaa, tooot_pagadoooo, tooot_copaooo, toooot_partiiii, tootototot_benef, tooottotot_SCCC]
                }]
            });
            
        }

        function addCommas(nStr) {
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + '.' + '$2');
            }
            return x1 + x2;
        }

        function Ajax_Excel() {
            modal_show();
            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "PREV": $("#Ddl_Preve").val(),
                "ID_USER": $("#Doctor").val(),
                "ATE_NUM": $("#txt_Folio").val(),
                "search_mode": search_mode,
                "TP_PAGO": 0,
                "ID_ESTADO": $("#ddl_estado").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {
                        Hide_Modal();
                        window.open(json_receiver, 'Download');
                    } else {
                        Hide_Modal();
              
                    }
                },
                "error": function (response) {
                    Hide_Modal();
                
                }
            });
        }

        let Mx_Dtt_PDF = [{
            "urls": ""
        }];

        function Ajax_PDF() {
            modal_show();

            let Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin,
                "DESDE": $("#fecha").val(),
                "HASTA": $("#fecha2").val(),
                "PROC": $("#Ddl_LugarTM").val(),
                "PREV": $("#Ddl_Preve").val(),
                "ID_USER": $("#Doctor").val(),
                "ATE_NUM": $("#txt_Folio").val(),
                "search_mode": search_mode,
                "TP_PAGO": 0,            
                "ID_ESTADO": $("#ddl_estado").val()
            });
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Resumen_Prev_Prog_Subp_Scr_3_Glob_Med.aspx/PDFF",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": (resp) => {
                    let xURL = "";
                    xURL = resp.d;

                    if (xURL != null) {
                        if (xURL.match(/^http(s?):\/\//gi) == null) {
                            xURL = "http://" + xURL;
                        }

                        var xMsg = `<p>Se ha generado correctamente el archivo PDF. `;
                        xMsg += `Si no se ha iniciado la descarga pulse <a href="${xURL}">aquí</a>.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);

                        window.open(xURL, "_blank");
                    } else {
                        var xMsg = `<p>No se ha generado ningún archivo debido a que la `;
                        xMsg += `búsqueda no retorna resultados.</p>`;
                        $("#mdlExcel .modal-body").html(xMsg);
                    }

                    $("#mdlExcel").modal();
                    Hide_Modal();
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);



                }
            });
        }
    </script>
    <style>
        .manito {
            cursor:pointer;
        }
        .negrito {
            font-weight:700;
            font-size:14px;
        }
    </style>

        <!-- Modal ERROR -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-reply mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>


            <!-- Modal PDF -->
    <div id="modal_pdf" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">PDF</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, qué formato desea exportar?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Pdf_by_exam" class="btn btn-warning"><i class="fa fa-file-text-o fa-fw"></i>Por Exámenes</button>
                    <button type="button" id="btn_Pdf7372873" class="btn btn-warning"><i class="fa fa-file-text-o fa-fw"></i>Por Atenciones</button>                
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>



    <!-- Modal Confirmacion escaneo -->
    <div id="modal_segurin" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Escanear Documento</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, desea escanear documento?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Escanear_confirm" class="btn btn-success"><i class="fa fa-upload fa-fw"></i>Escanear</button>             
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal Confirmacion escaneo -->
    <div id="modal_segurin_upload" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Subir Documento</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estimado Usuario, desea subir documento?</p>

                            <%--FRONT HTML--%>
        <div class="col-lg-6">
            <input type="file" name="file1" id="file1" class="inputfile"/>
            <label for="file1" class="btn btn-primary btn-lg" style="background-color: transparent; color: green; border: transparent;cursor:pointer">
                <i class="fa fa-paperclip fa-2x" aria-hidden="true"></i>
            </label>
            <%--<button type="button" id="btn_PRUEBA_ORDER_MED" class="btn btn-success btn-block btn-sm"><i class="fa fa-search-plus fa-fw"></i>Prueba Orden Médica</button>--%>
        </div>

        <div class="col-lg-12 text-center">
            <img src="#" id="ImgMed" style="max-width: 15%; border: 1px #009639 solid; padding: 1rem" hidden />
        </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Upload_confirm" class="btn btn-success"><i class="fa fa-upload fa-fw"></i>Subir</button>             
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Modal Galeria de Imagenes -->
    <div id="modal_Imagenes" class="modal fade" role="dialog" style="max-height:90vh; min-height:89vh">
        <div class="modal-dialog" style="max-width: 98vw; max-height:90vh; min-height:89vh">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="text-align:center;" id="lbl_tiiiitle">Listado de Documentos</h4>
                </div>
                <div class="modal-body">
                    <div class="col">
<%--                        <h5 id="lbl_pac_nom"></h5>
                        <br />
                        <h5 id="lbl_ate_num"></h5>--%>
                        <div class="row">
                            <div class="col-lg">
                                <div class="card border-bar mb-3">
                                    <div class="card-header text-center bg-bar">
                                        <h5 class="m-0"><i class="fa fa-picture-o fa-fw"></i> Galería</h5>
                                    </div>
                                    <div class="card-body p-0" style="background-color: #f5f5f5">
                                        <div id="Grid_Img" class="text-center" style="max-height: 500px; overflow: auto;"></div>
                                    </div>
                                </div>
                                <div id="Div_Tabla_Modal" style="overflow:auto;">

                                </div>
                            </div>
                            <div class="col-lg">
                                <div id="Mdl_Image_Ate_2" class="col-lg">
                                    <h3 class="modal-title w-100" id="mod_Name_2"></h3>
                                    <img src="" style="max-width: 50vw; max-height:90vh;" />
                            </div>
                            </div>                       
                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">       
                    <%--<button type="button" id="btn_Marcar_Modal" class="btn btn-limpiar"><i class="fa fa-crosshairs fa-fw"></i>Marcar</button>--%>    
                    <%--<button type='button' id="btn_desvincular_modal" class='btn btn-warning'>Desvincular</button>--%> 
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-fw fa-remove mr-2"></i>Cerrar</button>
                </div>
            </div>
        </div>
    </div>
        <%--MODAL IMAGEN EXPANDIDA--%>
        <div id="Mdl_Image_Ate" class="modal fade text-center p-0" role="dialog" style="z-index: 9999">
        <div  style="min-width: 55vw; height: 80vw; max-width: 99vw; margin-left:10px;">
            <!-- Modal content-->
            <div class="modal-content border-bar ">
                <div class="modal-header text-center bg-bar p-1">
                    <h3 class="modal-title w-100" id="mod_Name"></h3>
                </div>
                <div class="modal-body text-center">
                    <div class="row">
                        <div class="col-lg-6">
                        hola
                    </div>
                    <div class="col-lg-6">
                        <img src="" style="max-width: 30vw;" />
                    </div>
                    </div>
                    
                    
                </div>
                <div class="modal-footer">
                    
                </div>
            </div>
        </div>
    </div>








    <div class="card border-bar">
        <%----------------------------------------------------- CARGA DE IMAGEN --------------------------------------------------------%>




        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Revisión Bonos por Múltiple</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg-8">

                </div>
                <div class="col-lg-2">
                    <br />
                    <button type="button" id="btn_Excel" class="btn btn-success btn-block btn-sm"><i class="fa fa-search-plus fa-fw"></i>Excel</button>
                </div>
                <div class="col-lg-2">
                    <br />
                    <button type="button" id="btn_PDF" class="btn btn-warning btn-block btn-sm"><i class="fa fa-search-plus fa-fw"></i>PDF</button>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <label for="fecha">Desde:</label>
                    <div class='input-group date' id='Txt_Date01'>
                        <input type='text' id="fecha" class="form-control form-control-sm" readonly="true" placeholder="Desde..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-2">
                    <label for="fecha2">Hasta:</label>
                    <div class='input-group date' id='Txt_Date02'>
                        <input type='text' id="fecha2" class="form-control form-control-sm" readonly="true" placeholder="Hasta..." />
                        <span class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-lg-4">

                </div>
                <div class="col-lg-2">
                    <label>Folio</label>
                    <input type="text" id="txt_Folio" class="form-control form-control-sm"/>
                </div>
                <div class="col-lg-2">
                    <br />
                    <button type="button" id="btn_Buscar_Folio" class="btn btn-print btn-block btn-sm"><i class="fa fa-search-plus fa-fw"></i>Folio</button>
                </div>
            </div>
            <div class="row">
                <div class="col-lg">    
                    <label>Procedencia</label>
                    <select id="Ddl_LugarTM" class="form-control form-control-sm">
                        <%--<option value="0">Todos</option>--%>
                    </select>
                </div>
                <div class="col-lg">
                    <label>Previsión</label>
                    <select id="Ddl_Preve" class="form-control form-control-sm">
                        <%--<option value="0">Todos</option>--%>
                    </select>
                </div>
                <%--<div class="col-lg">
                    <label>Usuario</label>
                    <select id="Ddl_Usu" class="form-control form-control-sm">
                    </select>
                </div>--%>
                <div class="col-lg">
                    <label class="textoReducido">Doctor:</label>
                    <select id="Doctor" class="form-control form-control-sm">
                    </select>
                </div>
                <div class="col-lg">
                    <label class="textoReducido">Estado:</label>
                    <select id="ddl_estado" class="form-control form-control-sm">
                        <option value="0">Todos</option>
                        <option value="1">Revisado</option>
                        <option value="2">No Revisado</option>
                    </select>
                </div>
                <div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Buscar" class="btn btn-buscar btn-block btn-sm"><i class="fa fa-search fa-fw"></i>Buscar</button>
                </div>
                 <%--<div class="col-lg mb-1">
                    <br />
                    <button type="button" id="btn_Excel" class="btn btn-success btn-block btn-sm"><i class="fa fa-file-excel-o fa-fw"></i>Excel</button>
                </div>
                <div class="col-lg mb-1">
                     <br />
                    <button type="button" id="btn_Pdf" class="btn btn-warning btn-block btn-sm"><i class="fa fa-file-text-o fa-fw"></i>PDF</button>
                </div>--%>
                <div class="col-lg mb-1">
                     <br />
                    <button type="button" id="btn_Marcar" class="btn btn-limpiar btn-block btn-sm"><i class="fa fa-crosshairs fa-fw"></i>Marcar</button>
                </div>
            </div>
        </div>
    </div>

    <%--------------------------------------- DIV /2 PARA DOBLE DIV----------------------------------------%>

        <div id="Div_Tabla_Dual">
            <div class="row">
                <div id="Div_Tabla_2" class ="col-lg-6">

                </div>
                <div class="col-lg">

                </div>
            </div>
    </div>

    <%------------------------------------- FIN DIV /2 PARA DOBLE DIV -------------------------------------%>
    
    <div id="Div_Tabla" class="mt-3" style="overflow: auto">
<%--        <div class="card">
            <div class="list-group list-group-root well">
                <h5 class="m-0">
                    <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color: white !important">
                        <i class="fa fa-fw fa-chng fa-chevron-right"></i>****
                    </a></h5>
                <div class="collapse paddd minn0" id="item-1">
                    <span class="list-group-item">Procedencia<i class="fa fa-fw fa-minus"></i></span>
                </div>
            </div>
        </div>--%>
    </div>
        <div id="Div_Tabla_Tot" class="mt-3" style="overflow: auto">
    </div>
        <div class="card border-bar mt-3" id="div_tabla_graph">
        <div class="card-header bg-bar text-center">
            <h4 class="m-0">Gráficos</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-lg">
                    <div id="chrt_1"></div>
                </div>
            </div>
            <hr />
        </div>
    </div>
<%--    <div id="graph" class="mt-3">
    </div>--%>
</asp:Content>
