/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/jQuery.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/bootstrap.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/datepicker/js/bootstrap-datepicker.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\vendor/datatables/jquery.dataTables.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\vendor/datatables/dataTables.bootstrap4.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/moment.js" />

let Class_AJAX = function () {
    this.instance = null;
    this.url = "";
    this.success = () => { };
    this.error = (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");

        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        } catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    };
};
Class_AJAX.prototype.callback = function (data) {
    let objParam = {
        "type": "POST",
        "url": this.url,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": this.success,
        "error": this.error
    };

    if (data != null) {
        objParam["data"] = JSON.stringify(data);
    }

    this.instance = $.ajax(objParam);
};

//Inicio--------------------------------------------
$(document).ready(() => {
    let arrStr = [
        "#Txt_Date01",
        "#Txt_Date02"
    ];

    arrStr.forEach((xItem) => {
        $(xItem).val(moment().format("DD/MM/YYYY"));

        $(xItem).parent().parent().datepicker({
            format: "dd/mm/yyyy",
            language: "es",
            autoclose: true
        });
    });

    $("#mdlSearch").modal({
        show: true,
        focus: true
    });
    $("#mdlSearch").on("show.bs.modal", () => {
        $("#Txt_Nate").val("");
    });
    $("#mdlSearch").on("shown.bs.modal", () => {
        $("#Txt_Nate").focus();
    });
});

//Eventos--------------------------------------------
$(document).ready(() => {
    $("#Btn_Search").click((Me) => {
        fn_Search();
    });
    $("#Txt_Nate").keydown((Me) => {
        let strData = $("#Txt_Nate").val();

        strData = strData.replace(/[^0-9]/gi, "");
        strData = strData.match(/[0-9]{1,10}/gi);

        if (strData != null) {
            strData = strData[0];
        }

        if (strData != null) {
            strData = strData.replace(/^0/gi, "");
        }
        $("#Txt_Nate").val(strData);
    });
    $("#Txt_Nate").keyup((Me) => {
        if (Me.which == 13) {
            fn_Search();
        } else {
            let strData = $("#Txt_Nate").val();

            strData = strData.replace(/[^0-9]/gi, "");
            strData = strData.match(/[0-9]{1,10}/gi);

            if (strData == null) {
                strData = "0";
            } else {
                strData = strData[0];
            }

            $("#Txt_Nate").val(strData);
        }
    });

    let fn_Search = () => {
        objAJAX_Info.callback({
            ATE_NUM: $("#Txt_Nate").val()
        });
        objAJAX_TableData.callback({
            ATE_NUM: $("#Txt_Nate").val()
        });
        $("#mdlSearch").modal("hide");
    };

    $("#Btn_Print").click(() => {
        let arrChk = $("input[name=chkPrint]:checked");
        let arrVal = [];

        for (i = 0; i < arrChk.length; i++) {
            arrVal.push(arrChk.eq(i).val());
        }

        console.log(arrVal);
        if (arrVal.length > 0) {
            objAJAX_Print.callback({
                ID_ATE: arrInfo.ID_ATENCION,
                ID_TMU: arrVal
            });
        }
    });
    $("#Btn_Export").click(() => {
        objAJAX_Export.callback({
            ATE_NUM: arrInfo.ATE_NUM,
            ID_T_MUE: []
        });
    });

    $("#Btn_ChkFull").click(() => {
        $("input[name=chkPrint]").prop("checked", true);
    });

    $("#Btn_ChkEmpty").click(() => {
        $("input[name=chkPrint]").prop("checked", false);
    });
});

//AJAX----------------------------------------------
let arrInfo = {
    ID_ATENCION: 0,
    ATE_NUM: "",
    ATE_FECHA: new Date,
    PROC_DESC: "",
    PREVE_DESC: "",
    PAC_RUT: "",
    PAC_NOMBRE: "",
    PAC_APELLIDO: "",
    SEXO_DESC: ""
};
let objAJAX_Info = new Class_AJAX();
objAJAX_Info.url = "Impr_Etiq.aspx/Get_Info";
objAJAX_Info.success = (resp) => {
    $("#divData").empty();

    arrInfo = resp.d;
    if (resp.length == 0) {
        return;
    }

    let letTable = $("<table>", {
        class: "w-100 table table-hover table-striped table-iris table-bordered"
    });
        
    letTable.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { align: "center" }).text("N° Atenc."),
                $("<th>", { align: "center" }).text("RUT"),
                $("<th>", { align: "center" }).text("Nombre Pac."),
                $("<th>", { align: "center" }).text("Procedencia"),
                $("<th>", { align: "center" }).text("Previsión")
            )
        )
    );

    let tbody = $("<tbody>");
    tbody.append(
        $("<tr>").append(
            $("<td>", { align: "center" }).html(arrInfo.ATE_NUM),
            $("<td>", { align: "center" }).html(arrInfo.PAC_RUT),
            $("<td>", { align: "left" }).html(`${arrInfo.PAC_NOMBRE} ${arrInfo.PAC_APELLIDO}`),
            $("<td>", { align: "left" }).html(arrInfo.PROC_DESC),
            $("<td>", { align: "left" }).html(arrInfo.PREVE_DESC)
        )
    );

    letTable.append(tbody);
    $("#divData").append(letTable);
};

let arrTableData = [
  {
      ID_ATENCION: 0,
      ATE_NUM: "",
      ATE_FECHA: new Date(),
      ID_PROCEDENCIA: 0,
      ID_PREVE: 0,
      ID_CODIGO_BARRA: 0,
      CB_COD: "",
      CB_DESC: "",
      ID_T_MUESTRA: 0,
      T_MUESTRA_COD: "",
      T_MUESTRA_DESC: "",
      ID_G_MUESTRA: 0,
      GMUE_COD: "",
      GMUE_DESC: ""
  }
];
let objAJAX_TableData = new Class_AJAX();
objAJAX_TableData.url = "Impr_Etiq.aspx/Get_Etiquetas";
objAJAX_TableData.success = (resp) => {
    $("#divTable").empty();

    arrTableData = resp.d;
    if (arrTableData.length == 0) {
        $("#divTable").append(
            $("<div>", {
                class: "alert alert-danger mb-0"
            }).text(`No se han encontrado etiquetas asociadas a ese Nro de Atención.`)
        );

        return;
    }

    let letTable = $("<table>", {
        class: "w-100 table table-hover table-striped table-iris"
    });

    letTable.append(
        $("<thead>").append(
            $("<tr>").append(
                $("<th>", { align: "center" }).text(""),
                $("<th>", { align: "center" }).text("Fecha"),
                $("<th>", { align: "center" }).text("N° Barra"),
                $("<th>", { align: "center" }).text("Tipo de Muestra"),
                $("<th>", { align: "center" }).text("Color Tubo"),
                $("<th>", { align: "center" }).text("Imprimir")
            )
        )
    );

    let tbody = $("<tbody>");
    arrTableData.forEach((xItem, xIndex) => {
        tbody.append(
            $("<tr>").append(
                $("<td>", { align: "right"  }).html(function () {
                    let reee = `${xIndex + 1}`;

                    while (reee.length < `${arrTableData.length}`.length) {
                        reee = `0${reee}`;
                    }

                    return reee;
                }()),
                $("<td>", { align: "center" }).html(moment(xItem.ATE_FECHA).format("DD/MM/YYYY - hh:mm")),
                $("<td>", { align: "center" }).html(xItem.CB_COD),
                $("<td>", { align: "left" }).html(xItem.T_MUESTRA_DESC),
                $("<td>", { align: "left" }).text(xItem.GMUE_DESC),
                $("<td>", { align: "center" }).append(
                    $("<input>", {
                        type: "checkbox",
                        name: "chkPrint",
                        class: "m-0",
                        id: `chk_${xIndex}`,
                        value: xItem.ID_T_MUESTRA,
                        checked: "checked",
                        style: "display: none;"
                    }),
                    $("<label>", {
                        class: "div-chk",
                        for: `chk_${xIndex}`
                    }).append(
                        `<i class="fa fa-square"></i>`,
                        `<i class="fa fa-check-square"></i>`)
                )
            )
        );
    });

    letTable.append(tbody);
    $("#divTable").append(letTable);
};

let objAJAX_Print = new Class_AJAX();
objAJAX_Print.url = "http://localhost:9990/Printer/Imp_Etiquetas_Cod_Barra";
objAJAX_Print.success = (resp) => {
    console.log(resp);

    $(`#mdlPrint .modal-header h5`).text(resp.Status);
    $(`#mdlPrint .modal-body`).empty();
    $(`#mdlPrint .modal-body`).append(
        $("<p>").html(resp.Message)
    );

    $(`#mdlPrint`).modal();
};

let objAJAX_Export = new Class_AJAX();
objAJAX_Export.url = "Impr_Etiq.aspx/Get_Excel";
objAJAX_Export.success = (resp) => {
    let strURL = resp.d;
    let bolFound = false;

    $(`#mdlExport .modal-body p`).hide();
    if (strURL != null) {
        bolFound = true;

        if (strURL.match(/^https?:\/\//gi) == null) {
            strURL = `http://${strURL}`;
        }

        $(`#mdlExport .modal-body p a`).attr("href", strURL);
    }

    $(`#mdlExport .modal-body p[data-found=${bolFound}]`).show();
    $(`#mdlExport`).modal();

    location.href = strURL;
};