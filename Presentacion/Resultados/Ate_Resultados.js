/// <reference path="../js/webform.ts" />
/// <reference path="../scripts/typings/jquery/math.d.ts" />
/// <reference path="D:\Repos\IRIS_HOLANDA_MULTIPLE\iris_holanda_multiple\Presentacion\js/Galletas.js" />

var ATE_RES;
let ID_ATE;
(function (ATE_RES) {
    //---------------------------------------------------------------------------------------------
    //Declaración de Variables Internas------------------------------------------------------------
    let num_title_loop;
    let fn_title_loop = () => {
        let arr_dot = document.title.match(/\.+$/gi);
        if (arr_dot == null) {
            document.title = document.title.replace(/\.*$/i, ".");
        }
        else {
            if (arr_dot[0].length == 1) {
                document.title = document.title.replace(/\.*$/i, "..");
            }
            else if (arr_dot[0].length == 2) {
                document.title = document.title.replace(/\.*$/i, "...");
            }
            else {
                document.title = document.title.replace(/\.*$/i, "");
            }
        }
    };
    let strUrlQuery = (function () {
        //Comprobar URL
        let REE;
        let strURL = location.href.match(/([a-z]|[0-9]|-|_)\.aspx\?ID\=/gi);
        if (strURL == null) {
            //location.href = "/index.aspx"
            REE = null;
        }
        else {
            REE = location.href.match(/\?ID\=.+/gi)[0];
            REE = REE.replace(/\?(?=(ID\=.+))/gi, "");
        }
        return REE;
    }());
    let objWrite = {
        URL: null,
        Param: null,
    };
    //let fucusTimeout: number
    let keyEnter = false;
    let objData_Pac;
    let objData_HistGen;
    let objData_Dtt;
    let objData_Audit;
    let objData_ResCod;
    let objSel_Secc;
    let objSel_Exam;
    let objSel_IntExt;
    class class_Count_Load {
        constructor() {
            this.loaded = false;
            this.count = 0;
        }
        endLoad() {
            if (this.loaded == true) {
                return this.count;
            }
            else {
                this.count += 1;
            }
            //Eventos
            console.log(`Load Iterator Count => ${this.count}`);
            switch (this.count) {
                case 3:
                    console.log("Join 3");
                    if (Sel_Secc.getValue().value != null) {
                        this.ID_SECC_Now = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC;
                        this.ID_EXAM_Now = parseInt(`${Sel_Exam.getValue().value}`);
                        this.ID_INEX_Now = 0;
                    }
                    console.log("strUrlQuery: "+strUrlQuery);
                    if (strUrlQuery == null || strUrlQuery == "ID=Znpvy0y6YSQ=") {
                        console.log("Znpvy0y6YSQ=");
                        objAJAX_Sel_Prev.requestNow({
                            ID_PROC: Sel_Proc.getValue().value
                        }, () => {
                            fn_Charge_Exam();
                            objAJAX_Sel_Prog.requestNow({
                                ID_PREV: Sel_Prev.getValue().value
                            });
                        });
                        objAJAX_Sel_Secc.requestNow();
                        clearInterval(num_title_loop);
                        document.title = "Visor de Resultados";
                        Dtt_Exam.cleanTable("Por favor introduzca un Nro de Atención, en la casilla correspondiente, y presione Enter para Iniciar la búsqueda.");
                        Hide_Modal();
                        return;
                    }
                    console.log(">>> Req Pac Data");
                    objAJAX_Pac_Data.queryString = strUrlQuery;
                    objAJAX_Pac_Data.requestNow();
                    console.log(">>> Req Secc");
                    objAJAX_Sel_Secc.queryString = strUrlQuery;
                    objAJAX_Sel_Secc.requestNow();
                    console.log(">>> Req Gen Hist");
                    objAJAX_Pac_GenHist.queryString = strUrlQuery;
                    objAJAX_Pac_GenHist.requestNow();
                    break;
                case 5:
                    console.log("Join 5");
                    if (strUrlQuery == null) {
                        return;
                    }
                    Sel_Proc.setValue(objData_Pac.ID_PROCEDENCIA);
                    objAJAX_Sel_Prev.requestNow({
                        ID_PROC: objData_Pac.ID_PROCEDENCIA
                    }, () => {
                        fn_Charge_Exam();
                    });
                    break;
                case 6:
                    console.log("Join 6");
                    if (strUrlQuery == null) {
                        console.log("-->Se ha ingresado directamente al formulario...");
                        console.log("   Carga finalizada.-\n");
                        return;
                    }
                    Sel_Prev.setValue(objData_Pac.ID_PREVE);
                    objAJAX_Sel_Prog.requestNow({
                        ID_PREV: objData_Pac.ID_PREVE
                    });
                    break;
                case 7:
                    console.log("Join 7");
                    if (strUrlQuery == null) {
                        return;
                    }
                    //console.log("ID PROGGG "+objData_Pac.ID_PROGRA);
                    Sel_Prog.setValue(objData_Pac.ID_PROGRA);
                    //if (this.loaded == true) {
                    this.locateSecc();
                    //}
                    objAJAX_Fill_Table.queryString = strUrlQuery;
                    
                    objAJAX_Fill_Table.requestNow({
                        R_ID_SECC: (JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC),
                        R_ID_EXAM: parseInt(`${Sel_Exam.getValue().value}`),
                        R_ID_PAC: objData_Pac.ID_PACIENTE,
                        R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
                        R_SEXO: objData_Pac.SEXO_DESC,
                        R_DIA: objData_Pac.ATE_DIA,
                        R_MES: objData_Pac.ATE_MES,
                        R_AÑO: objData_Pac.ATE_AÑO
                    });
                    break;
                case 8:
                    console.log("Join 8");
                    if (strUrlQuery == null) {
                        return;
                    }
                    console.log("make table 1");
                    fn_Make_Table();
                    fn_Calc();
                    clearInterval(num_title_loop);
                    document.title = `Res ATE N°${objData_Pac.ATE_NUM}`;
                    Hide_Modal();
                    this.loaded = true;
                    this.count = 2;
            }
            return this.count;
        }
        locateSecc() {
            if (this.ID_SECC_Now == null) {
                return;
            }
            if (this.ID_EXAM_Now == null) {
                return;
            }
            //Asignar Sección
            let xValue = "";
            for (let i = 0; i < objSel_Secc.length; i++) {
                let ID_SECC_then = JSON.parse(decodeURI(atob(`${objSel_Secc[i].ID}`))).ID_SECC;
                if (ID_SECC_then == this.ID_SECC_Now) {
                    xValue = objSel_Secc[i].ID;
                    break;
                }
            }
            if (this.ID_EXAM_Now != 0) {
                Sel_Exam.setValue(this.ID_EXAM_Now);
            }
            if (xValue != "") {
                Sel_Secc.setValue(xValue);
            }
        }
    }
    //Declaración de Elem--------------------------------------------------------------------------
    let Txt_NumAte = new WEBFORM.class_Input("Txt_NumAte");
    //let Txt_DateAte = new WEBFORM.class_Input("Txt_DateAte");
    //let Txt_Nombre = new WEBFORM.class_Input("Txt_Nombre");
    //let Txt_Edad = new WEBFORM.class_Input("Txt_Edad");
    //let Txt_Sexo = new WEBFORM.class_Input("Txt_Sexo");
    //let Txt_FUR = new WEBFORM.class_Input("Txt_FUR");
    let Txt_ResCod_Det = new WEBFORM.class_Input("Txt_ResCod_Det");
    let Txt_ResCod_Out = new WEBFORM.class_Input("Txt_ResCod_Out");
    //let Txt_Sector = new WEBFORM.class_Input("Txt_Sector");
    //let Txt_Med = new WEBFORM.class_Input("Txt_Med");
    //let Txt_Hist = new WEBFORM.class_Input("Txt_Hist");
    //Txt_NumAte.numeric = {
    //    value: true,
    //    default: 1,
    //    min: 1,
    //    max: (10 ^ 8)
    //}
    //Txt_DateAte.setReadOnly(true);
    //Txt_Nombre.setReadOnly(true);
    //Txt_Edad.setReadOnly(true);
    //Txt_Sexo.setReadOnly(true);
    //Txt_FUR.setReadOnly(true);
    Txt_ResCod_Det.readOnly = true;
    //Txt_Sector.readOnly = true;
    //Txt_Med.readOnly = true;
    //Txt_Hist.readOnly = true;
    let Sel_Prev = new WEBFORM.class_Select("Sel_Prev");
    let Sel_Proc = new WEBFORM.class_Select("Sel_Proc");
    let Sel_Prog = new WEBFORM.class_Select("Sel_Prog");
    let Sel_Secc = new WEBFORM.class_Select("Sel_Secc");
    let Sel_Exam = new WEBFORM.class_Select("Sel_Exam");
    let Sel_IntExt = new WEBFORM.class_Select("Sel_IntExt");
    let Chk_Filther = new WEBFORM.class_Checkbox("Chk_Filther");
    let Btn_Audit = new WEBFORM.class_Button("Btn_Audit");
    let Btn_Validar = new WEBFORM.class_Button("Btn_Validar");
    let Btn_Desvalidar = new WEBFORM.class_Button("Btn_Desvalidar");
    let Btn_Print = new WEBFORM.class_Button("Btn_Print");
    let Btn_Graph = new WEBFORM.class_Button("Btn_Graph");
    let Btn_GraphAlt = new WEBFORM.class_Button("Btn_GraphAlt");
    let Btn_Hist = new WEBFORM.class_Button("Btn_Hist");
    let Btn_HistPruExit = new WEBFORM.class_Button("Btn_HistPruExit");
    let Btn_RC_Add = new WEBFORM.class_Button("Btn_RC_Add");
    let Btn_RC_New = new WEBFORM.class_Button("Btn_RC_New");
    let Btn_AteL = new WEBFORM.class_Button("Btn_AteL");
    let Btn_AteR = new WEBFORM.class_Button("Btn_AteR");
    let Mdl_Init_Load = new class_Count_Load();
    let Dtt_Exam = new WEBFORM.class_Table("Dtt_Exam", "Cargando...");
    let Dtt_Audit = new WEBFORM.class_Table("Dtt_Audit", "Cargando...");
    let fn_Make_Table = () => {

        $("#mdls").empty();

        Dtt_Exam.cleanTable();
        Dtt_Exam.addTHead("T", "center");
        Dtt_Exam.addTHead("E", "center");
        Dtt_Exam.addTHead("Examen", "left");
        Dtt_Exam.addTHead("Descripción", "left");
        Dtt_Exam.addTHead("Resultado", "left");
        Dtt_Exam.addTHead("Unidad", "left");
        Dtt_Exam.addTHead("", "left");
        Dtt_Exam.addTHead("Desde", "center");
        Dtt_Exam.addTHead("Hasta", "center");
        Dtt_Exam.addTHead("Result. Hist.", "left");
        Dtt_Exam.addTHead("T", "left");

        let Cont_Loop = 1;
        let Cont_Int = 2;
        let Curr_Exa = "";
        let Bg_Arr =[];

        let text_BG="";

       

        let _Z = 1050;
        //console.log(objData_Dtt);
        for (var i in objData_Dtt) {

            if(Curr_Exa == ""){
                Curr_Exa = objData_Dtt[i].Exam.ID_CF;
            }else if(Curr_Exa != objData_Dtt[i].Exam.ID_CF){
                Curr_Exa = objData_Dtt[i].Exam.ID_CF;

                if(Cont_Loop == 3){
                    Cont_Loop = 1;
                }else{
                    Cont_Loop += 1;
                }
            }
            if(Cont_Int == 1){
                Cont_Int = 2;
            }else{
                Cont_Int = 1;
            }

            if(Cont_Loop == 1){
                if(Cont_Int == 1){
                    text_BG="odd_C1";
                }else{
                    text_BG="even_C1";
                }
            }else if(Cont_Loop == 2){
                if(Cont_Int == 1){
                    text_BG="odd_C2";
                }else{
                    text_BG="even_C2";
                }
            }else{
                if(Cont_Int == 1){
                    text_BG="odd_C3";
                }else{
                    text_BG="even_C3";
                }
            }

            Bg_Arr=["bg-white","bg-white",text_BG,text_BG,text_BG,text_BG,text_BG,text_BG,text_BG,text_BG,text_BG];
            //Cont_Loop+=1;

            var index = i;
            let SeccInit = JSON.parse(decodeURI(atob(`${Sel_Secc.data[0].value}`)));
            let SeccNow = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`)));
            let xCF = parseInt(String(Sel_Exam.getValue().value));
            if ((SeccInit.ID_SECC != SeccNow.ID_SECC) || (xCF != 0)) {
                if (xCF == 0) {
                    var xFound = false;
                    SeccNow.ARR_ID.forEach((xElem) => {
                        if (objData_Dtt[i].Exam.ID_CF == xElem) {
                            xFound = true;
                        }
                    });
                    if (xFound == false) {
                        continue;
                    }
                }
                else {
                    if (objData_Dtt[i].Exam.ID_CF != xCF) {
                        continue;
                    }
                }
            }
            Dtt_Exam.addRow(index, [

                objData_Dtt[index].TT.DESC_TD,
                (function () {
                    if(objData_Dtt[index].EE.value == 11 && objData_Dtt[index].EE.estado == ""){
                        objData_Dtt[index].EE.estado = "T";
                    }
                    //console.log(objData_Dtt[index]);
                    //console.log(objData_Dtt[index].Exam.Descrp);
                    let strClass;
                    switch (objData_Dtt[index].EE.value) {
                        case 10:
                            strClass = "yellow";
                            break;
                        case 11:
                            strClass = "v_green";
                            break;
                        case 6:
                            strClass = "v_pink";
                            break;
                        case 14:
                            strClass = "v_blue";
                            break;
                        default:
                            strClass = "";
                            break;
                    }
                    return `<span class="EE ${strClass}">${objData_Dtt[index].EE.estado}</span>`;
                }()),
                objData_Dtt[index].Exam.Descrp,
                objData_Dtt[index].Desc,
                (function () {

                    let value = objData_Dtt[index].Res.value;
                    //if(!isNaN(value)){
                    //    value = parseFloat(value);
                    //}
                    
                    //value = value.toString;
                    //value = math.round(value);
                    let Stat_Valid = objData_Dtt[index].EE.value;
                    let stat = objData_Dtt[index].Stat;
                    let xParam;

                    if (objData_Dtt[index].Stat != null) {
                        stat = objData_Dtt[index].Stat.toLowerCase();
                    }
                    if (objData_Dtt[index].Desc.trim() == `EDAD`) {
                        value = objData_Pac.EDAD; //.match(/^[0-9]+(?=\saños)/gi)[0]
                        objData_Dtt[index].Res.value = value;
                    }
                    if ((TOOL.fn_IsNumeric(objData_Dtt[index].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[index].Res.a1) == true) &&
                        (stat != "n") && (value != null) && (value != "") && (TOOL.fn_IsNumeric(`${value}`.replace(/\,/gi, ".")) == true)) {

                        objData_Dtt[index].Res.a1 = math.round(parseFloat(objData_Dtt[index].Res.a1),objData_Dtt[index].Res.pruDecimal); 
                        objData_Dtt[index].Res.b1 = math.round(parseFloat(objData_Dtt[index].Res.b1),objData_Dtt[index].Res.pruDecimal); 

                        if ((objData_Dtt[index].Res.b1 > parseFloat(value.toString().replace(/,/gi, "."))) ||
                            (objData_Dtt[index].Res.a1 < parseFloat(value.toString().replace(/,/gi, ".")))) {
                            xParam += ` class="input_error"`;
                        }
                        else if ((TOOL.fn_IsNumeric(value.toString().replace(/,/gi, ".")) == false) &&
                            (objData_Dtt[index].TT.ID_TD != 1)) {
                            xParam += ` class="input_error"`;
                        }
                    }
                    if ((Stat_Valid == 6) || (Stat_Valid == 14) || (objData_Dtt[index].TT.ID_TD == 4)) {
                        xParam += ` readonly`;
                    }
                    if ((value == null || value == "") && objData_Dtt[index].Res.pruCero == true) {
                        value = 0;
                    }else if(value == null && objData_Dtt[index].Res.pruCero == false){
                        value="";
                    }
                    else {
                        if (TOOL.fn_IsNumeric(value) == true) {
                            value = TOOL.fn_cutDecimals(math.round(String(value).replace(/\,/gi, "."),objData_Dtt[index].Res.pruDecimal), objData_Dtt[index].Res.pruDecimal);
                        }
                        value = String(value).replace(/\./gi, ",");
                    }
                    xParam += ` rows="1"`;
                    if (objData_Dtt[index].TT.ID_TD == 4) {
                        xParam += ` data-calc="true"`;
                    }

                    //console.group();
                    //console.log(value);
                    //console.log(objData_Dtt[index].Res.a2);
                    //console.log(objData_Dtt[index].Res.b2);
                    //console.groupEnd();
                    //console.log("@@@@@@@@@@@@@@@@@@@@@ CARGAR MDLS @@@@@@@@@@@@@@@@@@@@@");
                    if(parseFloat(value) >=  parseFloat(objData_Dtt[index].Res.a2) && (objData_Dtt[index].Res.a2 != 0)){
                        //console.log("@@@@@@@@@@@@@@@@@@@@@ ALTO @@@@@@@@@@@@@@@@@@@@@");
                        let m_ID_RES = objData_Dtt[index].Res.ID_RES;
                        let m_Title="Valor Crítico Alto";
                        let m_Text="Estimado usuario, se detecto un valor crítico alto: <br> <b class='text-danger'>"+objData_Dtt[index].Desc+" : "+value+"</b>";
                        modal_Crit(m_ID_RES,m_Title,m_Text,_Z);
                        _Z -=1;

                    }else if(parseFloat(value) <=  parseFloat(objData_Dtt[index].Res.b2) && (objData_Dtt[index].Res.b2 != 0)){
                        //console.log("@@@@@@@@@@@@@@@@@@@@@ BAJO @@@@@@@@@@@@@@@@@@@@@");
                        let m_ID_RES = objData_Dtt[index].Res.ID_RES;
                        let m_Title="Valor Crítico Bajo";
                        let m_Text="Estimado usuario, se detecto un valor crítico bajo: <br> <b class='text-danger'>"+objData_Dtt[index].Desc+" : "+value+"</b>";
                        modal_Crit(m_ID_RES,m_Title,m_Text,_Z);
                        _Z -=1;
                    }

                    return `<input type="text" ${xParam} value="${value}" />`;
                }()),
                objData_Dtt[index].Unit,
                (function () {
                    let xVal = objData_Dtt[index].Stat;
                    if (xVal == null) {
                        xVal = "";
                    }
                    if ((xVal.toUpperCase() == "N") || (xVal.toUpperCase() == "")) {
                        return `<span class="td_stat">${xVal}</span>`;
                    }
                    else {
                        return `<span class="td_stat" style="color: #d30000;">${xVal}</span>`;
                    }
                }()),
                (function () {

                    //console.group("Rang Ref "+objData_Dtt[index].Desc);

                    let value;
                    if(objData_Dtt[index].EE.value == 6 || objData_Dtt[index].EE.value == 14){
                        //console.log("Res Validado");
                        value = objData_Dtt[index].Res.b1;
                    }else{
                        //console.log("Res No Validado");
                        value = objData_Dtt[index].Res.b1;
                        //console.log("BAJO: "+value);
                    }
                    
                    let dec = objData_Dtt[index].Res.pruDecimal;

                    if (value == null) {
                        //console.log("Val Null");
                        //console.groupEnd();
                        return ".";
                    }
                    else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                        value = String(TOOL.fn_cutDecimals(value, dec));
                        //console.log("Val Numeric");
                        //console.groupEnd();
                        return String(value).replace(/\./gi, ",");
                    }
                    else if((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)){
                        //console.log("Val Text");
                        //console.groupEnd();
                        return objData_Dtt[index].Res.rfT;
                    }
                    else {
                        //console.log("Val All");
                        //console.groupEnd();
                        return value;
                    }
                    
                }()),
                (function () {
                    let value;
                    if(objData_Dtt[index].EE.value == 6 || objData_Dtt[index].EE.value == 14){
                        value = objData_Dtt[index].Res.a1;
                    }else{
                        value = objData_Dtt[index].Res.a1;
                        //console.log("ALTO: "+value);
                    }
                    
                    let dec = objData_Dtt[index].Res.pruDecimal;

                    if (value == null) {
                        return ".";
                    }
                    else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                        value = String(TOOL.fn_cutDecimals(value, dec));
                        return String(value).replace(/\./gi, ",");
                    } else if((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)){
                        return ".";
                    }
                    else {
                        return value;
                    }
                }()),
                (function () {
                    if(objData_Dtt[i].ReHi != null && objData_Dtt[i].ReHi != ""){
                        return `<span class="sp-hist v_green">${objData_Dtt[i].ReHi}</span>`;
                    }else
                    {
                        return "";
                    }
                }()),
                objData_Dtt[i].cDia
            ],null,Bg_Arr);
            //console.log(objData_Dtt);
        }
        Btn_Graph.setActive(false);
        Btn_Audit.setActive(false);
        Dtt_Exam.isClickeable = true;
        //Dtt_Exam.isDataTable = true;
       
        Dtt_Exam.updateTable("No se han encontrado exámenes.", 100);


        //$("#Dtt_Exam input[type=text]").focus((Me) => {
        //    let strLenght = Me.currentTarget.value.length;
        //    //Me.currentTarget.selectionStart = strLenght;
        //    //Me.currentTarget.selectionEnd = strLenght;
        //    console.log("Focus");
        //    setTimeout(function(){ Me.currentTarget.selectionStart = Me.currentTarget.selectionEnd = strLenght; }, 0);
        //});
        

        $("#Dtt_Exam input[type=text]").focusin((Me) => {
            $("#Dtt_Exam tbody tr").removeClass("tr_selected");
            $(Me.currentTarget).parents("tr").addClass("tr_selected");
            //$(Me.currentTarget).select();

        });
        $("#Dtt_Exam input[type=text]").focusout((Me) => {
            if ($(Me.currentTarget).attr("readonly") == null) {
                //console.log("Beep!")
                fn_Write(Me)
                fn_Calc()
            }
            //clearTimeout(fucusTimeout)
            //console.log(`Pulsado Enter: ${keyEnter}`)
            //console.log(Me);
            if ($(Me.currentTarget).attr("readonly") == null) {
                if (keyEnter == false) {
                    let xItem = objData_Dtt[parseInt($(Me.currentTarget).parents("tr").attr("data-index"))];
                    let strOut;
                    if (xItem.Res.value == null && xItem.Res.pruCero == false) {
                        strOut = "";
                    }
                    else if(xItem.Res.value == null && xItem.Res.pruCero == true){
                        strOut = "" + TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
                    }
                    else {
                        if (TOOL.fn_IsNumeric(xItem.Res.value) == true) {
                            strOut = "" + TOOL.fn_cutDecimals(xItem.Res.value, xItem.Res.pruDecimal, false);
                        }
                        else {
                            strOut = `${xItem.Res.value}`;
                        }
                        strOut = `${strOut}`.replace(/\./gi, ",");
                    }
                    $(Me.currentTarget).val(strOut);
                }
            }

            keyEnter = false;
        });
        $("#Dtt_Exam input[type=text]").keypress((Me) => {
            //clearTimeout(fucusTimeout)
            if (Me.which == 13) {
                if ($(Me.currentTarget).attr("readonly") == null) {
                    fn_Write(Me);
                    fn_Calc();
                    keyEnter = true;
                    $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
                }
            }
        });

        $("#Dtt_Exam input[type=text]").keydown((Me) => {
            if(Me.which == 38) {
                //console.log("KEY PRESS: "+Me.which);
                $(Me.currentTarget).parents("tr").prev().find("input[type=text]").focus();
            }
            else if(Me.which == 40){
                //console.log("KEY PRESS: "+Me.which);
                $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
            }else{
                //console.log("KEY PRESS: "+Me.which);
            }
        });
        $("#Dtt_Exam tbody tr").dblclick((Me) => {
            let xi = parseInt($(Me.currentTarget).attr("data-index"));
            let xItem = objData_Dtt[xi];
            if ((xItem.EE.value == 6) || (xItem.EE.value == 14)) {
                return;
            }
            //Llenado de Datos para el Modal
            $("#mdlResCodificados h4").html(function () {
                let strOut;
                switch (xItem.TT.ID_TD) {
                    case 1:
                        strOut = "Alfanumérico";
                        break;
                    case 2:
                        strOut = "Numérico";
                        break;
                    default:
                        strOut = "Fórmula";
                        break;
                }
                //return `<small>Opciones para Tipo de Dato</small> ${strOut}`
                //return `Opciones para Tipo de Dato <small>${strOut}</small>`
                return `Opciones para Tipo de Dato ${strOut}`;
            }());
            $("#mdlResCodificados .mini-table").empty();
            $("#mdlResCodificados").modal();
            Txt_ResCod_Det.value = xItem.Desc;
            if (xItem.Res.value != null) {
                Txt_ResCod_Out.value = `${xItem.Res.value}`;
            }
            else {
                Txt_ResCod_Out.value = "";
            }
            objAJAX_Get_Res_Cod.requestNow({
                ID_PRUEBA: xItem.Exam.ID_EXA
            });
        });
        $("#Dtt_Exam table").DataTable({
            //"iDisplayLength": 10,
            "info": false,
            "bPaginate": false,
            "bFilter": false,
            "bSort": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay concidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay concidencias",
                "infoFiltered": "(Se busco en _MAX_ registros )",
                "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            }
        });
    };
    let fn_Write = (Me) => {
        //console.log(Me);
        let xValue = $(Me.currentTarget).val();
        //console.log("@@@@@ Val: "+xValue);
        let xIndex = parseInt(Dtt_Exam.tr_value);
        //console.log("@@@@@ Ind: "+xIndex);
        let xStat;
        let xParam;
        //Evaluar Valor
        xValue = String(xValue).trim();
        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
            xValue = parseFloat(xValue);
        }
        objData_Dtt[xIndex].Res.value = xValue;
        var objItem = objData_Dtt[xIndex].Res;
        xStat = (function () {
            if (objData_Dtt[xIndex].TT.ID_TD == 1) {
                if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                    (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                    ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                    if (objData_Dtt[xIndex].Res.b2 > xValue) {
                        return -2;
                    }
                    else if (objData_Dtt[xIndex].Res.a2 < xValue) {
                        return 2;
                    }
                    else if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                    if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return null;
                }
            }
            else if (objData_Dtt[xIndex].TT.ID_TD == 2) {
                if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                    (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                    ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                    if (objData_Dtt[xIndex].Res.b2 > xValue) {
                        return -2;
                    }
                    else if (objData_Dtt[xIndex].Res.a2 > xValue) {
                        return 2;
                    }
                    else if (objData_Dtt[xIndex].Res.b1 < xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                    if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return null;
                }
            }
            else if (objData_Dtt[xIndex].TT.ID_TD == 4) {
                //Fórmulaaaaaaaaaaaaaaaa
                return;
            }
        }());
        if (xStat == 9000) {
            objData_Dtt[xIndex].Stat = "";
        }
        else if (xStat < 0) {
            objData_Dtt[xIndex].Stat = "B";
        }
        else if (xStat > 0) {
            objData_Dtt[xIndex].Stat = "A";
        }
        else if (xStat == 0) {
            objData_Dtt[xIndex].Stat = "N";
        }
        else {
            objData_Dtt[xIndex].Stat = "";
        }
        //Validar ceros
        xValue = TOOL.fn_cutDecimals(String(xValue), objData_Dtt[xIndex].Res.pruDecimal, true).trim().replace(/\./gi, ",");
        if ((objData_Dtt[xIndex].Res.pruCero == false) &&
            (parseFloat(TOOL.fn_cutDecimals(parseFloat(`${xValue}`.replace(/,/gi, ".")), objData_Dtt[xIndex].Res.pruDecimal, true)) === 0)) {
            xValue = "";
            objData_Dtt[xIndex].Stat = "";
            $(Me.currentTarget).attr("class", "input_error");
        }
        else {
            if ((objData_Dtt[xIndex].Stat == "") && (xStat == null)) {
                $(Me.currentTarget).removeAttr("class");
            }
            else if (objData_Dtt[xIndex].Stat == "N") {
                $(Me.currentTarget).removeAttr("class");
            }
            else {
                $(Me.currentTarget).attr("class", "input_error");
            }
        }
        console.clear();

        //console.log(Me);

        console.log(`Val REF: [${objData_Dtt[xIndex].Res.PRU_COD}] -> ${objData_Dtt[xIndex].Desc}\nB2 = ${objData_Dtt[xIndex].Res.b2}\nB1 = ${objData_Dtt[xIndex].Res.b1}\nA1 = ${objData_Dtt[xIndex].Res.a1}\nA2 = ${objData_Dtt[xIndex].Res.a2}`);
        console.log(`Value = ${$(Me.currentTarget).val()}; ValueParsed = ${TOOL.fn_cutDecimals(xValue, objData_Dtt[xIndex].Res.pruDecimal, true)}; Stat = ${xStat}\nTipo Dato = ${objData_Dtt[xIndex].TT.ID_TD}\nDecimales = ${objData_Dtt[xIndex].Res.pruDecimal}\nAcepta Ceros = ${objData_Dtt[xIndex].Res.pruCero}\n\n`);
        $(Me.currentTarget).val(xValue);
        $(Me.currentTarget).parents("tr").find(".td_stat").text(objData_Dtt[xIndex].Stat);
        if ((objData_Dtt[xIndex].Stat.toLocaleUpperCase() != "N") && (objData_Dtt[xIndex].Stat.trim() != "")) {
            $(Me.currentTarget).parents("tr").find(".td_stat").css({
                color: "#d50000"
            });
        }
        else {
            $(Me.currentTarget).parents("tr").find(".td_stat").css({
                color: "#212529"
            });
        }
        if (objData_Dtt[xIndex].TT.ID_TD != 1) {
            objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue,
                EVAL: xValue
            };
        }
        else {
            objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue
            };
        }
        objAJAX_Write.URL = objWrite.URL;
        objAJAX_Write.requestNow(objWrite.Param);
    };

    let fn_Write_2 = (Me_Ind, Me_Val) => {

        let xValue = Me_Val;
        //console.log("@@@@@ Val: "+xValue);
        let xIndex = Me_Ind;
        //console.log("@@@@@ Ind: "+xIndex);
        let xStat;
        let xParam;
        //Evaluar Valor
        xValue = String(xValue).trim();
        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
            xValue = parseFloat(xValue);
        }
        objData_Dtt[xIndex].Res.value = xValue;
        var objItem = objData_Dtt[xIndex].Res;
        xStat = (function () {
            if (objData_Dtt[xIndex].TT.ID_TD == 1) {
                if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                    (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                    ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                    if (objData_Dtt[xIndex].Res.b2 > xValue) {
                        return -2;
                    }
                    else if (objData_Dtt[xIndex].Res.a2 < xValue) {
                        return 2;
                    }
                    else if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                    if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return null;
                }
            }
            else if (objData_Dtt[xIndex].TT.ID_TD == 2) {
                if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                    (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                    ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                    if (objData_Dtt[xIndex].Res.b2 > xValue) {
                        return -2;
                    }
                    else if (objData_Dtt[xIndex].Res.a2 > xValue) {
                        return 2;
                    }
                    else if (objData_Dtt[xIndex].Res.b1 < xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                    if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return null;
                }
            }
            else if (objData_Dtt[xIndex].TT.ID_TD == 4) {
                //Fórmulaaaaaaaaaaaaaaaa
                return;
            }
        }());
        if (xStat == 9000) {
            objData_Dtt[xIndex].Stat = "";
        }
        else if (xStat < 0) {
            objData_Dtt[xIndex].Stat = "B";
        }
        else if (xStat > 0) {
            objData_Dtt[xIndex].Stat = "A";
        }
        else if (xStat == 0) {
            objData_Dtt[xIndex].Stat = "N";
        }
        else {
            objData_Dtt[xIndex].Stat = "";
        }
        //Validar ceros
        xValue = TOOL.fn_cutDecimals(String(xValue), objData_Dtt[xIndex].Res.pruDecimal, true).trim().replace(/\./gi, ",");
        if ((objData_Dtt[xIndex].Res.pruCero == false) &&
            (parseFloat(TOOL.fn_cutDecimals(parseFloat(`${xValue}`.replace(/,/gi, ".")), objData_Dtt[xIndex].Res.pruDecimal, true)) === 0)) {
            xValue = "";
            objData_Dtt[xIndex].Stat = "";
            //$(Me.currentTarget).attr("class", "input_error");
        }
        else {
            if ((objData_Dtt[xIndex].Stat == "") && (xStat == null)) {
                //$(Me.currentTarget).removeAttr("class");
            }
            else if (objData_Dtt[xIndex].Stat == "N") {
                //$(Me.currentTarget).removeAttr("class");
            }
            else {
                //$(Me.currentTarget).attr("class", "input_error");
            }
        }
        console.clear();

        //console.log(Me);

        console.log(`Val REF: [${objData_Dtt[xIndex].Res.PRU_COD}] -> ${objData_Dtt[xIndex].Desc}\nB2 = ${objData_Dtt[xIndex].Res.b2}\nB1 = ${objData_Dtt[xIndex].Res.b1}\nA1 = ${objData_Dtt[xIndex].Res.a1}\nA2 = ${objData_Dtt[xIndex].Res.a2}`);
        //console.log(`Value = ${$(Me.currentTarget).val()}; ValueParsed = ${TOOL.fn_cutDecimals(xValue, objData_Dtt[xIndex].Res.pruDecimal, true)}; Stat = ${xStat}\nTipo Dato = ${objData_Dtt[xIndex].TT.ID_TD}\nDecimales = ${objData_Dtt[xIndex].Res.pruDecimal}\nAcepta Ceros = ${objData_Dtt[xIndex].Res.pruCero}\n\n`);
        //$(Me.currentTarget).val(xValue);
        //$(Me.currentTarget).parents("tr").find(".td_stat").text(objData_Dtt[xIndex].Stat);
        if ((objData_Dtt[xIndex].Stat.toLocaleUpperCase() != "N") && (objData_Dtt[xIndex].Stat.trim() != "")) {
            //$(Me.currentTarget).parents("tr").find(".td_stat").css({
            //    color: "#d50000"
            //});
        }
        else {
            //$(Me.currentTarget).parents("tr").find(".td_stat").css({
            //    color: "#212529"
            //});
        }
        if (objData_Dtt[xIndex].TT.ID_TD != 1) {
            objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue,
                EVAL: xValue
            };
        }
        else {
            objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue
            };
        }
        objAJAX_Write.URL = objWrite.URL;
        objAJAX_Write.requestNow(objWrite.Param);
    };


    let fn_Calc = () => {
        let fn_Proc = (xItem, miii) => {
            let calc = xItem.vector;
            
            let arrREE = [];
            let xInput="";
            if(calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi) != null){
                calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi).forEach((lol) => {
                    let _text = lol;
                    let _value = null;
                    objData_Dtt.forEach((kek, index) => {
                        if (_text == `[${kek.Res.PRU_COD}]`) {
                            _value = parseFloat(`${kek.Res.value}`.replace(/,/gi, "."));
                            
                            if((_value == "" || _value == null || isNaN(_value) == true) && kek.Res.pruCero == true){
                                console.log("If 1");
                                _value = parseFloat("0");
                                let reg = new RegExp(`\\[${kek.Res.PRU_COD}\\]`, `gi`);
                                calc = calc.replace(reg, `${_value}`);
                                calc = calc.replace(/,/gi, ".");
                            }
                            else if (TOOL.fn_IsNumeric(_value) == false && kek.Res.pruCero == false) {
                                _value = null;
                                console.log("If 2");
                            }
                            else {
                                let reg = new RegExp(`\\[${kek.Res.PRU_COD}\\]`, `gi`);
                                calc = calc.replace(reg, `${_value}`);
                                calc = calc.replace(/,/gi, ".");
                                console.log("If 3");
                            }
                            console.log(_value);
                            arrREE.push({
                                string: `${_text} -> ${kek.Exam.Descrp} - ${kek.Desc}`,
                                value: `${_value}`
                            });
                        }
                    });
                });
                console.log(`Fórmula Position ${miii}:`);
                console.log(`Fórmula RAW: ${xItem.vector}`);
                console.log(arrREE);
                xInput = $(`#Dtt_Exam table tbody tr[data-index="${miii}"] input`);
            }

            console.log(calc);
            if (calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi) == null) {

                let result = `${math.eval(calc)}`;
                //console.log("Result "+result);
                let res_raw = result;
                result = TOOL.fn_cutDecimals(math.round(result,objData_Dtt[miii].Res.pruDecimal), objData_Dtt[miii].Res.pruDecimal, true);
                result = `${result}`.replace(/\./gi, ",");
                //console.log(`Fórmula GET: ${calc}\n\nN° Decimales: ${objData_Dtt[miii].Res.pruDecimal}\nResultado RAW: ${res_raw}\nResultado Truncado: ${result}`);
                //console.log(`\n`);
                objData_Dtt[miii].Res.value = parseFloat(result.replace(/,/gi, "."));
                xInput.val(result);
                //Comparar con Rangos de Referencia
                if ((TOOL.fn_IsNumeric(objData_Dtt[miii].Res.b1) == true) || (TOOL.fn_IsNumeric(objData_Dtt[miii].Res.a1) == true)) {
                    if (objData_Dtt[miii].Res.b1 > objData_Dtt[miii].Res.value) {
                        xInput.parents("tr").find(".td_stat").text("B");
                        xInput.parents("tr").find(".td_stat").css({ "color": "rgb(213, 0, 0)" });
                        xInput.addClass("input_error");
                    }
                    else if (objData_Dtt[miii].Res.a1 < objData_Dtt[miii].Res.value) {
                        xInput.parents("tr").find(".td_stat").text("A");
                        xInput.parents("tr").find(".td_stat").css({ "color": "rgb(213, 0, 0)" });
                        xInput.addClass("input_error");
                    }
                    else {
                        xInput.parents("tr").find(".td_stat").text("N");
                        xInput.parents("tr").find(".td_stat").removeAttr("style");
                        xInput.removeClass("input_error");
                    }
                }
                objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
                objWrite.Param = {
                    ID_RES: objData_Dtt[miii].Res.ID_RES,
                    RES: result.replace(/\./gi, ","),
                    EVAL: result
                };
                objAJAX_Write.URL = objWrite.URL;
                objAJAX_Write.requestNow(objWrite.Param);
            }
            else {
                //console.log(`\n`);
                xInput.val("");
                objData_Dtt[miii].Res.value = null;
            }
        };
        objData_Dtt.forEach((item, main_index) => {
            if (item.TT.ID_TD == 4) {
                console.groupCollapsed(`Prueba a Calcular: ID: [${item.Res.ID_RES}]; ${item.Exam.Descrp} - ${item.Desc}`);
                fn_Proc(item.Res, main_index);
                console.groupEnd();
            }
        });
    };
    let fn_Activate_Validator = () => {
        //if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
        //    Btn_Validar.setActive(false);
        //    Btn_Desvalidar.setActive(false);
        //    Btn_Graph.setActive(false);
        //    return;
        //}
        //Btn_Validar.setActive(true);
        //Btn_Desvalidar.setActive(true);
    };

    function Check_Valida(Id_Ate,id_CF){
        let ret;
        var strParam = JSON.stringify({
            "ID_ATE": Id_Ate,
            "ID_CF": id_CF
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados.aspx/Check_Valida",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                //console.log(data.d);
                ret = data.d;
            },
            "async": false,
            "error": data => {
            }
        });
        return ret;
    }

    let fn_Validate = () => {
        modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        console.clear();
        console.log(`Exámenes por Validar:`);
        let v_Id_Cf = "";
        let v_Cons;
        for (var i = 0; i < xTR.length; i++) {

            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            
            // BUSCA SI ESTA VALIDADO

            if(v_Id_Cf  == ""){
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = Check_Valida(ID_ATE,v_Id_Cf);

                console.log("ID_CF "+v_Id_Cf+" v_Cons: "+v_Cons);
                
            }else if(v_Id_Cf != xItem.Exam.ID_CF){
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons =  Check_Valida(ID_ATE,v_Id_Cf);

                console.log("ID_CF "+v_Id_Cf+" v_Cons: "+v_Cons);
            }

            if(v_Id_Cf == xItem.Exam.ID_CF && v_Cons == 0){
                console.log("Se puede validar ["+xItem.Exam.Descrp+"] - "+xItem.Desc);
                //console.log(xItem);

                if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                    xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
                    console.log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> IF GUARDAR RESULTADO");
                    let Me_Val = xTR[xIndex].children[4].children[0].value;
                    let Me_Ind = xIndex
                    fn_Write_2(Me_Ind, Me_Val);
                }

                if ((xItem.EE.value != 6) && (xItem.EE.value != 14)) {
                    let bolHasValue = false;
                    if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                        bolHasValue = true;
                    }
                    console.groupCollapsed(`[${xItem.Exam.ID_CF}] => ${xItem.Exam.Descrp} - ${xItem.Desc}`);
                    console.log(`Obligatorio = ${xItem.Res.NEED_VALIDATE}\nTiene Valor = ${bolHasValue}\n`);
                    console.groupEnd();
                    if (bolHasValue == true) {
                        arrIndex_Success.push(xIndex);
                    }
                    else {
                        if (xItem.Res.NEED_VALIDATE == true) {
                            let fn_Add_CF_Error = () => {
                                arrErr.push({
                                    ID_CF: xItem.Exam.ID_CF,
                                    arrParam: [
                                        {
                                            ID_RES: xItem.Res.ID_RES,
                                            DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                        }
                                    ]
                                });
                            };
                            if (arrErr.length == 0) {
                                fn_Add_CF_Error();
                            }
                            else {
                                let Index_E = arrErr.DeepSearch("ID_CF", xItem.Exam.ID_CF);
                                if (Index_E == null) {
                                    fn_Add_CF_Error();
                                }
                                else {
                                    arrErr[Index_E].arrParam.push({
                                        ID_RES: xItem.Res.ID_RES,
                                        DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                    });
                                }
                            }
                        }
                    }
                }
            }else{
                console.log("No se puede validar ["+xItem.Exam.Descrp+"] - "+xItem.Desc);
            }

            
        }
        if (arrErr.length > 0) {
            console.error(`<<ERROR - VALIDACIÓN DENEGADA>>`);
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }
        let  Obj_Valid = [];
        for (var i of arrIndex_Success) {
            let fn_UltraSearch = () => {
                for (let riii of arrErr) {
                    if (riii.ID_CF == objData_Dtt[i].Exam.ID_CF) {
                        return true;
                    }
                }
                return false;
            };
            if (fn_UltraSearch() == false) {
                //objAJAX_Validate.requestNow({

                //});

                let Item_Valid;

                Item_Valid = {
                    ID_ATE_RES: objData_Dtt[i].Res.ID_RES,
                    DESDE: (function () {
                        let xVal = objData_Dtt[i].Res.b1;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                            if(objData_Dtt[i].Res.rfT != "" && objData_Dtt[i].Res.rfT != "NULL" && objData_Dtt[i].Res.rfT != null){
                                xVal = objData_Dtt[i].Res.rfT;
                            }
                        }
                        return xVal;
                    }()),
                    HASTA: (function () {
                        let xVal = objData_Dtt[i].Res.a1;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                            if(objData_Dtt[i].Res.rfT != "" && objData_Dtt[i].Res.rfT != "NULL" && objData_Dtt[i].Res.rfT != null){
                                xVal = ".";
                            }
                        }
                        return xVal;
                    }()),
                    AB: objData_Dtt[i].Stat,
                    MUY_DESDE: (function () {
                        let xVal = objData_Dtt[i].Res.b2;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                        }
                        return xVal;
                    }()),
                    MUY_HASTA: (function () {
                        let xVal = objData_Dtt[i].Res.a2;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                        }
                        return xVal;
                    }()),
                    MUY_AB: (function () {

                        // RR ALTOBAJO

                        let value = objData_Dtt[i].Res.value;
                        let output = 0;
                        let b2 = objData_Dtt[i].Res.b2;
                        let a2 = objData_Dtt[i].Res.a2;
                        if (TOOL.fn_IsNumeric(b2) == true) {
                            if (b2 > parseFloat(`${value}`) && ( objData_Dtt[i].Res.b2 != 0)) {
                                output = 1;
                            }
                        }
                        if (TOOL.fn_IsNumeric(a2) == true) {
                            if (a2 < parseFloat(`${value}`) && (objData_Dtt[i].Res.a2 != 0)) {
                                output = 2;
                            }
                        }
                        return output;
                    }()),
                    UNIDADES: objData_Dtt[i].Unit,
                    VALUE: objData_Dtt[i].Res.value
                };
                Obj_Valid.push(Item_Valid);
                objData_Dtt[i].EE.value = 6;
                objData_Dtt[i].EE.estado = "V";
                $(`tr[data-index=${i}] td`).eq(1).html(objData_Dtt[i].EE.estado);
            }
        }
        //console.log(Obj_Valid);
        objAJAX_Validate.requestNow({"Obj_Valid":Obj_Valid});
        console.log("make table 2");
        
    };
    let fn_Unvalidate = () => {

        modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        console.clear();
        console.log(`Exámenes por Desvalidar:`);
        for (var i = 0; i < xTR.length; i++) {
            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
            }

            if ((xItem.EE.value == 6) || (xItem.EE.value == 14)) {
                let bolHasValue = false;
                if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                    bolHasValue = true;
                }
                console.groupCollapsed(`[${xItem.Exam.ID_CF}] => ${xItem.Exam.Descrp} - ${xItem.Desc}`);
                console.log(`Obligatorio = ${xItem.Res.NEED_VALIDATE}\nTiene Valor = ${bolHasValue}\n`);
                console.groupEnd();
                if (bolHasValue == true) {
                    arrIndex_Success.push(xIndex);
                }
                else {
                    if (xItem.Res.NEED_VALIDATE == true) {
                        let fn_Add_CF_Error = () => {
                            arrErr.push({
                                ID_CF: xItem.Exam.ID_CF,
                                arrParam: [
                                    {
                                        ID_RES: xItem.Res.ID_RES,
                                        DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                    }
                                ]
                            });
                        };
                        if (arrErr.length == 0) {
                            fn_Add_CF_Error();
                        }
                        else {
                            let Index_E = arrErr.DeepSearch("ID_CF", xItem.Exam.ID_CF);
                            if (Index_E == null) {
                                fn_Add_CF_Error();
                            }
                            else {
                                arrErr[Index_E].arrParam.push({
                                    ID_RES: xItem.Res.ID_RES,
                                    DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                });
                            }
                        }
                    }
                }
            }
        }
        if (arrErr.length > 0) {
            console.error(`<<ERROR - DESVALIDACIÓN DENEGADA>>`);
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }

        let Obj_Unvalid = [];

        for (var i of arrIndex_Success) {

            let Item_Unvalid;

            let fn_UltraSearch = () => {
                for (let riii of arrErr) {
                    if (riii.ID_CF == objData_Dtt[i].Exam.ID_CF) {
                        return true;
                    }
                }
                return false;
            };
            if (fn_UltraSearch() == false) {
                
                Item_Unvalid = {ID_ATE_RES: objData_Dtt[i].Res.ID_RES,
                    VALUE: objData_Dtt[i].Res.value};

                objData_Dtt[i].EE.value = 7;
                objData_Dtt[i].EE.estado = "";
                $(`tr[data-index=${i}] td`).eq(1).html(objData_Dtt[i].EE.estado);
            }
            Obj_Unvalid.push(Item_Unvalid);
        }
        objAJAX_Unvalidate.requestNow({
            "Obj_Unvalid": Obj_Unvalid
        });

        console.log("make table 3");
        
    };
    //Declaración AJAX-----------------------------------------------------------------------------
    let objAJAX_Pac_Data = new TOOL.class_AJAX("Ate_Resultados.aspx/Page_Load", (resp) => {
        console.log("Start Load");
        objData_Pac = resp.d;

        
        //console.log("Datos Atención:")
        console.log(objData_Pac)
        //console.log("")
        //ID_ATE = `${objData_Pac.ID_ATENCION}`
        let r_FUR;

        if(objData_Pac.ATE_FUR != null && objData_Pac.ATE_FUR != ""){
            r_FUR = " | Fur: "+objData_Pac.ATE_FUR;
            console.log("FUR");
        }else{
            r_FUR = "";
            console.log("NO FUR");
        }

        Txt_NumAte.setValue(objData_Pac.ATE_NUM);
        //Txt_DateAte.setValue(moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY"));
        //$("#chk_Nombre label span").text(`${objData_Pac.PAC_NOMBRE} ${objData_Pac.PAC_APELLIDO}`);
        //Txt_Nombre.setValue(`${objData_Pac.PAC_RUT},  ${objData_Pac.EDAD},  ${objData_Pac.SEXO_DESC}${r_FUR}`);

        $("#title_Det_Ate").html("<i class='fa fa-user mr-2'></i> | "+objData_Pac.PAC_NOMBRE+" "+objData_Pac.PAC_APELLIDO+" | "+objData_Pac.PAC_RUT+" | F. Ate: "+moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY")+" | "+objData_Pac.EDAD+" | "+objData_Pac.SEXO_DESC+r_FUR);
        
        //let _ver_Sect;
        //if(objData_Pac.SECTOR_DESC != null && objData_Pac.SECTOR_DESC != ""){
        //    _ver_Sect = objData_Pac.SECTOR_DESC;
        //}
        //else{
        //    _ver_Sect = "SIN SECTOR";
        //}
        let v_Obs;

        v_Obs = objData_Pac.ATE_OBS_TM;

        if(v_Obs != "" && v_Obs != null){
            v_Obs = " | Obs: ";

        }else{
            v_Obs = "";
        }

        

        $("#title_Det_Ate_2").html("<i class='fa fa-edit mr-2'></i> | Sector: "+ objData_Pac.SECTOR_DESC.replace("<","").replace(">","")+" | Médico: "+objData_Pac.DOC_NOMBRE+" "+objData_Pac.DOC_APELLIDO+" | Orden: "+objData_Pac.ORD_DESC+ v_Obs);
        console.log("Sector: "+ objData_Pac.SECTOR_DESC+" | Médico: "+objData_Pac.DOC_NOMBRE+objData_Pac.DOC_APELLIDO);
        //Txt_Edad.setValue(objData_Pac.EDAD);
        //Txt_Sexo.setValue(objData_Pac.SEXO_COD);
        //Txt_FUR.setValue(objData_Pac.ATE_FUR);
        //Txt_Sector.value = objData_Pac.SECTOR_DESC;
        //Txt_Med.value = objData_Pac.DOC_NOMBRE+objData_Pac.DOC_APELLIDO;
        //Sel_IntExt.setValue(objData_Pac.ID_INTEXT);
        ID_ATE = objData_Pac.ID_ATENCION;
        //console.log(`Datos Paciente:`);
        //console.log(`   - ID_ATE  : ${objData_Pac.ID_ATENCION}`);
        //console.log(`   - NRO_ATE : ${objData_Pac.ATE_NUM}`);
        //console.log(`   - ID_PAC  : ${objData_Pac.ID_PACIENTE}`);
        //console.log(`   - Paciente: ${objData_Pac.PAC_NOMBRE} ${objData_Pac.PAC_APELLIDO}`);
        if (objData_Pac.CANT_HIST > 1) {
            Btn_Hist.setActive(true);
        }
        else {
            Btn_Hist.setActive(false);
        }

        console.log(">>> End Req Pac Data");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Pac_GenHist = new TOOL.class_AJAX("Ate_Resultados.aspx/Get_Hist_General_Info", (resp) => {
        objData_HistGen = resp.d;
        let _txt_Nom_His = "<i class='fa fa-user mr-2'></i>"+$("#title_Det_Ate").text() + " |  Ate: "+objData_HistGen.CANT_ATE+", Exa: "+objData_HistGen.CANT_EXA;
        //console.log(_txt_Nom_His);
        $("#title_Det_Ate").html(_txt_Nom_His);
        //Txt_Nombre.setValue(_txt_Nom_His);

        //Txt_Hist.value = `Ate: ${objData_HistGen.CANT_ATE}; Exa: ${objData_HistGen.CANT_EXA}`;
        console.log(">>> End Req Gen Hist");
        //Mdl_Init_Load.endLoad()
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Proc = new TOOL.class_AJAX("Ate_Resultados.aspx/Sel_Proc", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Proc.cleanAll();
        Sel_Proc.insertElem("<< Todos >>", 0);
        for (let i in xData) {
            Sel_Proc.insertElem(xData[i].DESC, xData[i].ID);
        }
        //objAJAX_Sel_Prev.requestNow({
        //    ID_PROC: parseInt(`${Sel_Proc.getValue().value}`)
        //})
        console.log("Sel Proc");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Prev = new TOOL.class_AJAX("Ate_Resultados.aspx/Sel_Prev", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Prev.cleanAll();
        Sel_Prev.insertElem("<< Todos >>", 0);
        let bolFound = false;
        for (let i in xData) {
            Sel_Prev.insertElem(xData[i].DESC, xData[i].ID);
        }
        //objAJAX_Sel_Prog.requestNow({
        //    ID_PREV: 0
        //})
        console.log("Sel Prev");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Prog = new TOOL.class_AJAX("Ate_Resultados.aspx/Sel_Prog", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Prog.cleanAll();
        Sel_Prog.insertElem("<< Todos >>", 0);
        for (let i in xData) {
            Sel_Prog.insertElem(xData[i].DESC, xData[i].ID);
        }
        console.log("Sel Prog");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Secc = new TOOL.class_AJAX("Ate_Resultados.aspx/Sel_Secc", (resp) => {
        let xData_In;
        objSel_Secc = [];
        Sel_Secc.cleanAll();
        xData_In = resp.d;
        xData_In.forEach((xItem, i) => {
            let strArray = encodeURI(JSON.stringify({
                ID_SECC: xItem.ID_SECC,
                ARR_ID: xItem.arrID
            }));
            objSel_Secc.push({
                ID: btoa(strArray),
                DESC: xItem.Descr
            });
        });
        for (let i = 0; i < objSel_Secc.length; ++i) {
            let sel_Item = {
                text: objSel_Secc[i].DESC,
                value: objSel_Secc[i].ID
            };
            Sel_Secc.data.push(sel_Item);
        }
        Sel_Secc.updateSelect();
        if (Mdl_Init_Load.loaded == false) {
            $(`#Sel_Secc`).off('eventChange');
            Sel_Secc.eventChange((Me) => {
                let strVal = `${Sel_Secc.getValue().value}`;
                let arrInt = [];
                try {
                    arrInt = JSON.parse(decodeURI(atob(strVal))).ARR_ID;
                }
                catch (err) {
                    objSel_Secc.forEach((xElem) => {
                        let item_array = JSON.parse(decodeURI(atob(`${xElem.ID}`))).ARR_ID;
                        item_array.forEach((xiii) => {
                            arrInt.push(xiii);
                        });
                    });
                }
                //console.log(`Array del elemento seleccionado:`)
                //console.log(arrInt)
                //console.log(`\n`)
                Sel_Exam.cleanAll();
                Sel_Exam.insertElem("<< Todos >>", 0);
                //console.group("Llenando Select de Exámenes")
                objSel_Exam.forEach((xElem, i) => {
                    let bolExist = false;
                    arrInt.forEach((xInt) => {
                        if (xInt == xElem.ID) {
                            bolExist = true;
                        }
                    });
                    if (bolExist) {
                        //console.log(`Este elemento existe:`)
                        //console.log(xElem)
                        let x_string = xElem.DESC;
                        let x_number = parseInt(`${xElem.ID}`);
                        Sel_Exam.insertElem(x_string, x_number);
                    }
                });
                console.groupEnd();
                console.log("make table 4 Sección");
                //fn_Make_Table();
            });
        }
        Sel_Secc.eventChange();
        console.log("Sel Secc");
        console.log(">>> End Sel Secc");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_Exam = new TOOL.class_AJAX("Ate_Resultados.aspx/Sel_Exam", (resp) => {
        objSel_Exam = resp.d;
        Sel_Exam.cleanAll();
        Sel_Exam.insertElem("<< Todos >>", 0);
        for (let i in objSel_Exam) {
            Sel_Exam.insertElem(objSel_Exam[i].DESC, objSel_Exam[i].ID);
        }
        if (Mdl_Init_Load.loaded == false) {
            Sel_Secc.eventChange();
        }
        console.log("Sel Exam");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Sel_IntExt = new TOOL.class_AJAX("Ate_Resultados.aspx/Sel_IntExt", (resp) => {
        objSel_IntExt = resp.d;
        //Sel_IntExt.cleanAll();
        //Sel_IntExt.insertElem("<< Todos >>", 0);
        //for (let i in objSel_IntExt) {
        //    Sel_IntExt.insertElem(objSel_IntExt[i].DESC, objSel_IntExt[i].ID);
        //}
        console.log("Sel IntExt");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Fill_Table = new TOOL.class_AJAX("Ate_Resultados.aspx/Json_DataTable", (resp) => {
        objData_Dtt = [];
        objData_Dtt = resp.d;
        //console.log(objData_Dtt);
        console.log("Json DTT");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Write = new TOOL.class_AJAX(objWrite.URL, (resp) => {
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Fill_Audit = new TOOL.class_AJAX("Ate_Resultados.aspx/Fill_Audit", (resp) => {
        objData_Audit = resp.d;
        Dtt_Audit.isClickeable = true;
        Dtt_Audit.isDataTable = false;
        Dtt_Audit.cleanTable();
        Dtt_Audit.addTHead("", "right");
        Dtt_Audit.addTHead("Forma", "left");
        Dtt_Audit.addTHead("Acción", "left");
        Dtt_Audit.addTHead("Fecha", "center");
        Dtt_Audit.addTHead("Hora", "center");
        Dtt_Audit.addTHead("Usuario", "center");
        objData_Audit.forEach((xItem, xIndex) => {
            Dtt_Audit.addRow(xIndex, [
                (function () {
                    let strOut = `${xIndex + 1}`;
                    while (strOut.length < `${objData_Audit.length}`.length) {
                        strOut = `0${strOut}`;
                    }
                    return strOut;
                }()),
                xItem.AUDI_FORMA,
                xItem.AUDI_ACCION,
                moment(xItem.AUDI_FECHA).format("DD/MM/YYYY"),
                moment(xItem.AUDI_FECHA).format("HH:mm"),
                xItem.USU_NIC
            ]);
        });
        Dtt_Audit.updateTable("No hay eventos asociados a la determinación seleccionada.");
        $("#mdlAudit").modal();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Validate = new TOOL.class_AJAX("Ate_Resultados.aspx/Set_Validate", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();
        $("#Sel_Exam").trigger("change");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Unvalidate = new TOOL.class_AJAX("Ate_Resultados.aspx/Set_Unvalidate", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();
        $("#Sel_Exam").trigger("change");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Get_Res_Cod = new TOOL.class_AJAX("Ate_Resultados.aspx/Get_Result_Cod", (resp) => {
        objData_ResCod = resp.d;
        let objTable = $("<table>", {
            class: "w-100 table-striped"
        });
        objTable.append($("<thead>").append($("<tr>").append($("<th>").text("Descripción"), $("<th>").text(""))), $("<tbody>"));
        objData_ResCod.forEach(xItem => {
            objTable.find("tbody").append($("<tr>").append($("<td>").text(xItem.RES_COD_DESC.replace(/\./gi, "")), $("<td>").append($("<button>", {
                type: "button",
                class: "btn btn-primary btn-sm"
            }).append($("<i>", {
                class: "fa fa-arrow-right",
                "aria-hidden": true
            })))));
        });
        $("#mdlResCodificados .mini-table").append(objTable);
        objTable.DataTable({
            //"iDisplayLength": 10,
            "info": false,
            "bPaginate": false,
            "bFilter": true,
            "bSort": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay concidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay concidencias",
                "infoFiltered": "(Se busco en _MAX_ registros )",
                "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            }
        });
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div:nth-child(2)").attr("class", "col-12");
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div:nth-child(1)").remove();
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div input").attr("placeholder");
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div").css({
            "display": "flex",
            "justify-content": "flex-start",
            "align-items": "flex-start",
            "padding-top": "1rem"
        });
        $("#mdlResCodificados .dataTables_wrapper table th").css({
            "display": "none"
        });
        //Evento Click
        $("#mdlResCodificados .mini-table button").click((Me) => {
            Me.stopImmediatePropagation();
            let strSelVal = $(Me.currentTarget).parents("tr").children("td:nth-child(1)").text();
            if (Txt_ResCod_Out.value == "") {
                //En caso de que el Txt de salida esté vacío...
                Txt_ResCod_Out.value = `${strSelVal}`;
            }
            else {
                //Buscar el ítem a ingresar en la cadena de destino
                let arrStr = Txt_ResCod_Out.value.replace(/\,\s+/gi, "☼").split("☼");
                arrStr.forEach((item, i) => {
                    if (item == strSelVal) {
                        arrStr.splice(i, 1); //Quitar elemento Repetido
                        return;
                    }
                });
                let strOut = "";
                arrStr.forEach((item, i) => {
                    if (i > 0) {
                        //Agregar "," solo cuando exista más un 1 elem en el arr
                        strOut = `${strOut}, `;
                    }
                    //Concatenar
                    strOut = `${strOut}${item}`;
                });
                //Enviar Cadena procesada al txt de Salida
                Txt_ResCod_Out.value = `${strOut}, ${strSelVal}`;
            }
            Txt_ResCod_Out.value = Txt_ResCod_Out.value.trim();
        });
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Get_Other_Ate = new TOOL.class_AJAX("Ate_Resultados.aspx/Change_Ate_L_or_R", (resp) => {
        console.log("Get Other Ate");
        console.log(resp);

        objAJAX_Get_ID_ATE.requestNow({
            NUM_ATE: resp.d
        });

        ////Comprobar QueryString
        //if ("Znpvy0y6YSQ=" == resp.d) {
        //    $(`#mdlLimit .modal-body > p`).hide();
        //    if (bolDir == false) {
        //        $(`#mdlLimit .modal-body > p[data-status=left]`).show();
        //    }
        //    else {
        //        $(`#mdlLimit .modal-body > p[data-status=right]`).show();
        //    }
        //    $(`#mdlLimit`).modal();


        //}
        //modal_show();
        //strUrlQuery = `ID=${resp.d}`;
        //let strURL = `Ate_Resultados.aspx?${strUrlQuery}`;
        //window.history.pushState({ path: strURL }, '', strURL);
        ////Limpiar datos
        //objData_Dtt = [];
        //Mdl_Init_Load.loaded = false;
        //console.log("Change L R");
        //Mdl_Init_Load.endLoad();
        //Btn_Audit.setActive(false);
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Get_ID_ATE = new TOOL.class_AJAX("Ate_Resultados.aspx/Get_ID_ATE_by_NUM_ATE", (resp) => {
     
        let response = resp.d;
        console.log(response);
        if (response == "0") {
            Hide_Modal();
            $(`#mdlLimit .modal-body > p`).hide();
            $(`#mdlLimit .modal-body > p[data-status=none]`).show();
            $(`#mdlLimit`).modal();

            //strUrlQuery = `ID=${resp.d}`;
            //let strURL = `Ate_Resultados.aspx?${strUrlQuery}`;
            //window.history.pushState({ path: strURL }, '', strURL);

            $("#title_Det_Ate").text("Sin Resultados");
            $("#title_Det_Ate_2").text("Sin Resultados");
            $("#Dtt_Exam table tbody").empty();

            $("#Btn_Hist").attr("disabled","disabled");
            $("#Btn_Print").attr("disabled","disabled");
            $("#Btn_Validar").attr("disabled","disabled");
            $("#Btn_Desvalidar").attr("disabled","disabled");

            $("#Sel_Secc").empty();
            $("#Sel_Secc").append($("<option>",{value:"JTdCJTIySURfU0VDQyUyMjowLCUyMkFSUl9JRCUyMjolNUI3NiwzMCU1RCU3RA==",text: "<< Todos >>"}));

            $("#Sel_Exam").empty();
            $("#Sel_Exam").append($("<option>",{value:0,text: "<< Todos >>"}));

            

            return;
        }
        $("#Btn_Hist").removeAttr("disabled");
        $("#Btn_Print").removeAttr("disabled");
        $("#Btn_Validar").removeAttr("disabled");
        $("#Btn_Desvalidar").removeAttr("disabled");
        modal_show();
        strUrlQuery = `ID=${resp.d}`;
        let strURL = `Ate_Resultados.aspx?${strUrlQuery}`;
        window.history.pushState({ path: strURL }, '', strURL);
        Mdl_Init_Load.count = 2;
        Mdl_Init_Load.loaded = false;
        console.log("ID ATE BY ATE NUM");
        Mdl_Init_Load.endLoad();
    }, (fail) => {

 
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Get_Hist_Graph = new TOOL.class_AJAX("Ate_Resultados.aspx/Draw_Graph_Hist", (resp) => {
        let str_examen;
        let str_parameter;
        if (xSelItem != null) {
            str_examen = xSelItem.Exam.Descrp;
            str_parameter = xSelItem.Desc;
        }
        else {
            str_examen = $(`#mdlHistExam table tbody tr.tr_selected td`).eq(1).text();
            str_parameter = $(`#mdlHistPruebas table tbody tr.tr_selected td`).eq(0).text();
        }
        let arr_Data = resp.d;
        $("#divGraph").empty();
        $("#divGraphData").empty();
        if (arr_Data.length == 0) {
            $("#divGraph").parent().find(".modal-header .modal-title").text(`Aviso`);
            $("#divGraph").append($("<p>", { class: "text-justify" }).html(`La determinación actualmente seleccionada no posee valores históricos graficables. Por favor seleccione otro parámetro para examinar.`));
            $("#divGraph").attr({ class: "col-12" });
            $("#divGraphData").attr({ class: "col-12" });
            $("#mdlGraph > div").removeClass("modal-lg");
            $("#mdlGraph > div").addClass("modal-md");
        }
        else {
            $("#mdlGraph > div").removeClass("modal-md");
            $("#mdlGraph > div").addClass("modal-lg");
            $("#divGraph").attr({ class: "col-12 col-md-8" });
            $("#divGraphData").attr({ class: "col-12 col-md-4" });
            $("#divGraph").parent().find(".modal-header .modal-title").text(`Historial de la Determinación`);
            let objTable = $("<table>", { class: "w-100 table-striped" });
            objTable.append($("<thead>").append($("<tr>").append($("<th>", { class: "text-center" }).text("Nro Atención"), $("<th>", { class: "text-center" }).text("Fecha"), $("<th>", { class: "text-center" }).text("Resultado"), $("<th>", { class: "text-center" }).text("E"))), $("<tbody>"));
            let arrEtiq = [];
            let arrRangoA = [];
            let arrValues = [];
            let arrRangoB = [];
            arr_Data.forEach((xItem, i) => {
                arrEtiq.push(moment(xItem.ATE_FECHA).format("DD/MM/YYYY"));
                arrRangoA.push(xItem.ATE_R_HASTA);
                arrValues.push(xItem.ATE_R_VALUE);
                arrRangoB.push(xItem.ATE_R_DESDE);
                objTable.children("tbody").append($("<tr>").append($("<td>", { class: "text-right" }).text(xItem.NN_ATE), $("<td>", { class: "text-center" }).text(moment(xItem.ATE_FECHA).format("DD/MM/YYYY")), $("<td>", { class: "text-right" }).text(`${xItem.ATE_R_VALUE}`.replace(/\./gi, ',')), $("<td>", { class: "text-center" }).text(function () {
                    switch (xItem.ATE_EST_VALIDA) {
                        case 6:
                            return "V";
                        case 14:
                            return "I";
                        case 16:
                            return "R";
                        default:
                            return "";
                    }
                }())));
            });
            Highcharts.chart("divGraph", {
                title: {
                    text: `Examen: ${str_examen}`
                },
                subtitle: {
                    text: `Determinación: ${str_parameter}`
                },
                xAxis: {
                    categories: arrEtiq
                },
                yAxis: {
                    title: {
                        text: `Valores de la Determinación.`
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: false
                    }
                },
                series: [
                    {
                        name: 'Rango Ref Desde',
                        data: arrRangoB
                    },
                    {
                        name: 'Valor',
                        data: arrValues
                    },
                    {
                        name: 'Rango Ref Hasta',
                        data: arrRangoA
                    }
                ]
            });
            objTable.appendTo("#divGraphData");
            let moreThan10 = false;
            if (arr_Data.length > 10) {
                moreThan10 = true;
            }
            let obj_dtt = objTable.DataTable({
                "iDisplayLength": 10,
                "info": moreThan10,
                "bPaginate": moreThan10,
                "bFilter": true,
                "bSort": true,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            $(`#divGraphData .dataTables_filter`).addClass("pull-right");
            $(`#divGraphData .dataTables_paginate`).addClass("pull-right");
            $(`#divGraphData .dataTables_filter`).parent().attr({ "class": "col-12" });
            //$(`#divGraphData .dataTables_length`).parent().attr({ "class": "col-3" })
            $(`#divGraphData table`).parent().addClass("table-responsive");
        }
        $("#mdlGraph").modal("show");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Get_Hist_Exam = new TOOL.class_AJAX("Ate_Resultados.aspx/Get_Table_Historico_Examenes", (resp) => {
        let arr_Data = resp.d;
        $(`#mdlHistExam .modal-body`).empty();
        $(`#mdlHistExam .modal-footer`).empty();
        if (arr_Data.length == 0) {
            $(`#mdlHistExam > div`).attr({ class: `modal-dialog modal-sm` });
            $(`#mdlHistExam .modal-body`).append($("<p>", { class: "text-justify" }).html(`El paciente actual no posee exámenes históricos registrados en el sistema.`));
        }
        else {
            $(`#mdlHistExam > div`).attr({ class: `modal-dialog modal-lg` });
            let _div1 = $("<div>", { class: "col-12" });
            let _div2 = $("<div>", { class: "col-12" });
            //Input con el nombre del paciente
            _div1.append($("<div>", {
                class: "form-group"
            }).append($("<label>").text("Nombre Paciente:"), $("<input>", {
                type: "text",
                class: "form-control",
                readonly: "readonly"
            }).val(`${objData_Pac.PAC_NOMBRE} ${objData_Pac.PAC_APELLIDO}`)));
            //Tabla con Datos
            let _table = $("<table>", { class: "w-100 table-striped" });
            _table.append($("<thead>").append($("<tr>").append($("<th>", { class: "text-center" }).text("Código"), $("<th>", { class: "text-center" }).text("Descripción"), $("<th>", { class: "text-center" }).text("Cantidad"), $("<th>", { class: "text-center" }).text("Ver"))));
            _table.append($("<tbody>"));
            //Agregar datos a la tabla
            arr_Data.forEach((xItem, i) => {
                let _tr = $("<tr>", { "data-value": xItem.ID_CODIGO_FONASA });
                _tr.append($("<td>", { class: "text-right" }).html(xItem.CF_COD));
                _tr.append($("<td>", { class: "text-left" }).html(xItem.CF_DESC));
                _tr.append($("<td>", { class: "text-right" }).html(`${xItem.EXA_COUNT}`));
                _tr.append($("<td>", { class: "text-center" }).html("<button type='button' class='btn btn-success btn-sm' name='btn_ver_hist'><i class='fa fa-search fa-fw'></i>Ver</button>"));
                _tr.appendTo(_table.find("tbody"));
            });
            //Evento Click
            _table.find("tbody").find("tr").click((Me) => {
                _table.find("tbody").find("tr").removeClass("tr_selected");
                $(Me.currentTarget).addClass("tr_selected");
            });
            //Evento Doble Click
            _table.find("tbody").find("tr").dblclick((Me) => {
                let numID_CF = parseInt($(Me.currentTarget).attr("data-value"));
                //Limpiar Modal de Pruebas
                let _div111 = $("#mdlHistPruebas .modal-body > .text-center");
                let _div222 = $("#mdlHistPruebas .modal-body > .text-left");
                _div111.show();
                _div222.hide();
                _div222.empty();
                _div222.append($("<input>", {
                    type: "text",
                    class: "form-control pb-2",
                    readonly: "readonly"
                }).val($(Me.currentTarget).find("td").eq(1).text()));
                $("#mdlHistExam").modal("hide");
                setTimeout(() => {
                    $("#mdlHistPruebas").modal();
                }, 500);
                objAJAX_Get_Hist_Pruebas.requestNow({
                    ID_ATE: objData_Pac.ID_ATENCION,
                    ID_CF: numID_CF
                });
            });
            //Meter todo en el Modal
            _table.appendTo(_div2);

            $(`#mdlHistExam .modal-body`).append($("<div>", { class: "row" }).append(_div1, _div2));

            $("button[name='btn_ver_hist']").click((Me)=>{
                //console.log($(Me.currentTarget));
                $(Me.currentTarget).parent().trigger("dblclick");
            });

            //Armar DataTable
            let moreThan10 = false;
            if (arr_Data.length > 10) {
                moreThan10 = true;
            }
            _table.DataTable({
                "iDisplayLength": 10,
                "info": moreThan10,
                "bPaginate": moreThan10,
                "bFilter": true,
                "bSort": true,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            $(`#mdlHistExam .dataTables_filter`).addClass("pull-right");
            $(`#mdlHistExam .dataTables_paginate`).addClass("pull-right");
            $(`#mdlHistExam .dataTables_filter`).parent().attr({ "class": "col-9" });
            $(`#mdlHistExam .dataTables_length`).parent().attr({ "class": "col-3" });
            $(`#mdlHistExam table`).parent().addClass("table-responsive");
        }
        let _btnExit = $(`<button>`, {
            type: `button`,
            class: `btn btn-primary`,
            "data-dismiss": "modal"
        });
        _btnExit.append($(`<i>`, { class: "fa fa-check" }));
        _btnExit.append($(`<span>`).text("Aceptar"));
        $(`#mdlHistExam .modal-footer`).append(_btnExit);
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    let objAJAX_Get_Hist_Pruebas = new TOOL.class_AJAX("Ate_Resultados.aspx/Get_Table_Historico_Pruebas_Por_Examen", (resp) => {
        let arr_Data = resp.d;
        let _div1 = $("#mdlHistPruebas .modal-body > .text-center");
        let _div2 = $("#mdlHistPruebas .modal-body > .text-left");
        //Tabla con Datos
        let _table = $("<table>", { class: "w-100 table-striped table-bordered" });
        let _headers = $("<tr>");
        _headers.append($("<th>", { class: "text-center" }).text("Determinación"));
        _table.append($("<thead>"), $("<tbody>"));
        //Llenar Tabla con Datos
        //Identificar Atenciones
        let arr_ID_ATE = [];
        arr_Data.forEach(xItem => {
            let bol_found = false;
            arr_ID_ATE.forEach(yItem => {
                if (xItem.ID_ATENCION == yItem.ID_ATE) {
                    bol_found = true;
                    return;
                }
            });
            if (bol_found == false) {
                //Agregar Atención
                arr_ID_ATE.push({
                    ID_ATE: xItem.ID_ATENCION,
                    VALUE: null
                });
                _headers.append($("<th>", { class: "text-center" }).html(`N° ${xItem.ATE_NUM}<br />${moment(xItem.ATE_FECHA).format("DD/MM/YYYY")}`));
            }
        });
        //Crear Filas
        let _row;
        for (var i in arr_Data) {
            let fn_new_row = () => {
                //Crear Nueva Fila
                arr_ID_ATE.forEach(item => {
                    item.VALUE = null;
                });
                _row = $("<tr>", {
                    "data-id_pru": arr_Data[i].ID_PRUEBA
                });
                _row.append($("<td>", { class: "text-left" }).text(arr_Data[i].PRU_DESC));
            };
            let fn_Add_Name = () => {
                //Agregar valores a la Fila
                if ((i != 0) || (i == arr_Data.length - 1)) {
                    if (i == arr_Data.length - 1) {
                        if (i == 0) {
                            fn_new_row();
                        }
                        fn_Add_Data();
                    }
                    arr_ID_ATE.forEach(item => {
                        if ((item.VALUE == null) || (item.VALUE == "")) {
                            item.VALUE = " - ";
                        }
                        _row.append($("<td>", {
                            class: (function () {
                                if (TOOL.fn_IsNumeric(item.VALUE.replace(/,/gi, ".")) == true) {
                                    return "text-right";
                                }
                                else if (item.VALUE == " - ") {
                                    return "text-center";
                                }
                                else {
                                    return "text-left";
                                }
                            }())
                        }).text(item.VALUE));
                    });
                    _table.find("tbody").append(_row);
                }
                fn_new_row();
            };
            let fn_Add_Data = () => {
                arr_ID_ATE.forEach(item => {
                    if (arr_Data[i].ID_ATENCION == item.ID_ATE) {
                        item.VALUE = arr_Data[i].ATE_RESULTADO;
                    }
                });
            };
            if (i == 0) {
                fn_Add_Name();
                fn_Add_Data();
            }
            else {
                if (arr_Data[i].ID_PRUEBA != arr_Data[i - 1].ID_PRUEBA) {
                    fn_Add_Name();
                    fn_Add_Data();
                }
                else if (i == arr_Data.length - 1) {
                    fn_Add_Name();
                }
                else {
                    fn_Add_Data();
                }
            }
        }
        //Evento Click
        _table.find("tbody tr").click((Me) => {
            _table.find("tbody tr").removeClass("tr_selected");
            $(Me.currentTarget).addClass("tr_selected");
            Btn_GraphAlt.setActive(true);
        });
        //Meter todo en la tabla
        _table.find("thead").append(_headers);
        _div2.append(_table);
        _div1.fadeOut(250, () => {
            _div2.fadeIn(250);
        });
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    });
    //---------------------------------------------------------------------------------------------
    //Eventos de Inputs----------------------------------------------------------------------------
    Txt_NumAte.evFocusOut((Me) => {
        if (strUrlQuery != null) {
            Txt_NumAte.value = `${objData_Pac.ATE_NUM}`;
        }
    });
    Txt_NumAte.evKeypress((Me) => {
        if (Me.which == 13) {
            document.title = `CARGANDO`;
            num_title_loop = setInterval(fn_title_loop, 250);
            objAJAX_Get_ID_ATE.requestNow({
                NUM_ATE: $(Me.currentTarget).val()
            });
        }
    });
    Txt_NumAte.evKeyup((Me) => {
        let strVal = $(Me.currentTarget).val();
        let arrNum = strVal.match(/[0-9]/gi);
        strVal = "";
        if (arrNum != null) {
            arrNum.forEach((xItem) => {
                if (strVal.length < 10) {
                    strVal = `${strVal}${xItem}`;
                }
            });
        }
        $(Me.currentTarget).val(strVal);
    });
    Sel_Proc.eventChange((Me) => {
        objAJAX_Sel_Prev.requestNow({
            ID_PROC: Sel_Proc.getValue().value
        });
    });
    Sel_Prev.eventChange((Me) => {
        objAJAX_Sel_Prog.requestNow({
            ID_PREV: Sel_Prev.getValue().value
        });
    });
    Sel_Secc.eventChange((Me) => {
        if (Mdl_Init_Load.loaded == true) {
            fn_Charge_Exam();
            Mdl_Init_Load.loaded = false;
            Mdl_Init_Load.count = 7;
            objData_Dtt = [];
            Dtt_Exam.cleanTable();
            modal_show();
            let ID_SECC_Now = Sel_Secc.getValue().value;
            let ID_EXAM_Now = parseInt(`${Sel_Exam.getValue().value}`);
            let ID_INEX_Now = 0;
            objAJAX_Fill_Table.queryString = strUrlQuery;
            objAJAX_Fill_Table.requestNow({
                R_ID_SECC: (JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC),
                R_ID_EXAM: parseInt(`${Sel_Exam.getValue().value}`),
                R_ID_PAC: objData_Pac.ID_PACIENTE,
                R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
                R_SEXO: objData_Pac.SEXO_DESC,
                R_DIA: objData_Pac.ATE_DIA,
                R_MES: objData_Pac.ATE_MES,
                R_AÑO: objData_Pac.ATE_AÑO
                
            }, () => {
                Sel_Secc.setValue(ID_SECC_Now);
                Sel_Exam.setValue(ID_EXAM_Now);
                fn_Activate_Validator();
                fn_Make_Table();
                fn_Calc();
                //Hide_Modal()
            });
        }
        else {
            fn_Activate_Validator();
        }
    });
    Sel_Exam.eventChange((Me) => {
        if (Mdl_Init_Load.loaded == true) {
            Mdl_Init_Load.loaded = false;
            Mdl_Init_Load.count = 7;
            objData_Dtt = [];
            Dtt_Exam.cleanTable();
            modal_show();
            let ID_SECC_Now = Sel_Secc.getValue().value;
            let ID_EXAM_Now = parseInt(`${Sel_Exam.getValue().value}`);
            let ID_INEX_Now = 0;
            objAJAX_Fill_Table.queryString = strUrlQuery;
            objAJAX_Fill_Table.requestNow({
                R_ID_SECC: (JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC),
                R_ID_EXAM: parseInt(`${Sel_Exam.getValue().value}`),
                R_ID_PAC: objData_Pac.ID_PACIENTE,
                R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
                R_SEXO: objData_Pac.SEXO_DESC,
                R_DIA: objData_Pac.ATE_DIA,
                R_MES: objData_Pac.ATE_MES,
                R_AÑO: objData_Pac.ATE_AÑO
            }, () => {
                Sel_Secc.setValue(ID_SECC_Now);
                Sel_Exam.setValue(ID_EXAM_Now);
                fn_Activate_Validator();
                console.log("make table 5 Examen");
                //fn_Make_Table();
                fn_Calc();
                //Hide_Modal()
            });
        }
        else {
            fn_Activate_Validator();
        }
    });
    Dtt_Exam.evclick_tr = (Me) => {
        $(Me.currentTarget).find("input").focus();
        Btn_Audit.setActive(true);
        Btn_Graph.setActive(true);
        let index = parseInt(`${Dtt_Exam.tr_value}`);
    };
    Btn_Validar.click((Me) => {
        if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
            $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder validar un examen, deberá seleccionar un Examen o Sección"));
            $(`#mdlAlert`).modal();
        }else{
            fn_Validate();
        }
    });
    Btn_Desvalidar.click((Me) => {
        if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
            $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder desvalidar un examen, deberá seleccionar un Examen o Sección"));
            $(`#mdlAlert`).modal();
        }else{
            fn_Unvalidate();
        }
    });
    Btn_Audit.click((Me) => {
        let objItem = objData_Dtt[parseInt($(`#Dtt_Exam tbody .tr_selected`).attr("data-index"))];
        let mdlTitle = $("#mdlAudit .modal-title");
        mdlTitle.text(`Auditoría ${objItem.Desc}`);
        objAJAX_Fill_Audit.requestNow({
            ID_RES: objItem.Res.ID_RES
        });
    });
    Btn_RC_New.click((Me) => {
        Txt_ResCod_Out.value = "";
    });
    Btn_Print.click((Me) => {
        let xUrl = "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=";
        xUrl = `${xUrl}${strUrlQuery.replace(/^ID=/gi, "")}`;
        window.open(xUrl, "_blank");
    });
    Btn_Graph.click((Me) => {
        let xIndex = parseInt(Dtt_Exam.tr_value);
        xSelItem = objData_Dtt[xIndex];
        console.log(`DATOS DEL RESULTADO:`);
        console.log(`   ID_ATEN = ${objData_Pac.ID_ATENCION}`);
        console.log(`   ATE_NUM = ${objData_Pac.ATE_NUM}`);
        console.log(`   ID_RESU = ${xSelItem.Res.ID_RES}\n\n`);
        bol_toHistCf = false;
        bol_toHistPru = false;
        objAJAX_Get_Hist_Graph.requestNow({
            ID_ATE: objData_Pac.ID_ATENCION,
            ID_PRU: xSelItem.Exam.ID_EXA,
            BL_ALL: false
        });
    });
    let bol_toHistCf = false;
    let bol_toHistPru = false;
    let xSelItem;
    Btn_GraphAlt.click((Me) => {
        let id_pru = parseInt($("#mdlHistPruebas table .tr_selected").attr("data-id_pru"));
        //$("#mdlHistPruebas").modal("hide");
        bol_toHistCf = false;
        bol_toHistPru = true;
        xSelItem = null;
        objData_Dtt.forEach((item, i) => {
            if (item.Exam.ID_EXA == id_pru) {
                xSelItem = item;
                return;
            }
        });
        
        objAJAX_Get_Hist_Graph.requestNow({
            ID_ATE: objData_Pac.ID_ATENCION,
            ID_PRU: id_pru,
            BL_ALL: true
        });
    });
    Btn_Hist.click((Me) => {
        objAJAX_Get_Hist_Exam.requestNow({
            ID_ATE: objData_Pac.ID_ATENCION
        }, () => {
            $("#mdlHistExam").modal();
        });
    });
    Btn_HistPruExit.click((Me) => {
        bol_toHistCf = true;
        bol_toHistPru = false;
    });
    let bolDir = false;
    let fn_Change_Ate = (bol_direction) => {

        console.log("BOOOOL "+bol_direction);

        console.log("Fn Change Ate");
        bolDir = bol_direction;
        return (Me) => {
            if (strUrlQuery == null) {
                console.log("-->No se ha seleccionado atención...");
                console.log("   Búsqueda Cancelada.-");
                Txt_NumAte.value = "";
                return;
            }
            document.title = `CARGANDO`;
            num_title_loop = setInterval(fn_title_loop, 250);
            let response = {
                ATE_NUM: parseInt($("#Txt_NumAte").val()),
                DIRECTION: bol_direction,
                ID_PROC: 0,
                ID_PREV: 0,
                ID_PROG: 0,
                ID_SECC: 0,
                ID_EXAM: 0,
                ID_SECT: 0,
                ID_PACI: 0
            };
            modal_show();

            console.log("IFs");

            if (Chk_Filther.getValues().indexOf(0) != -1) {
                response.ID_PROC = parseInt(`${Sel_Proc.getValue().value}`);
            }
            else {
                Sel_Proc.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(1) != -1) {
                response.ID_PREV = parseInt(`${Sel_Prev.getValue().value}`);
            }
            else {
                Sel_Prev.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(2) != -1) {
                response.ID_PROG = parseInt(`${Sel_Prog.getValue().value}`);
            }
            else {
                Sel_Prog.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(3) != -1) {
                let xItem = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`)));
                response.ID_SECC = parseInt(`${xItem.ID_SECC}`);
            }
            else {
                Sel_Secc.setValue(Sel_Secc.data[0].value);
            }
            if (Chk_Filther.getValues().indexOf(4) != -1) {
                response.ID_EXAM = parseInt(`${Sel_Exam.getValue().value}`);
            }
            else {
                Sel_Exam.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(5) != -1) {
                response.ID_SECT = 0;
            }
            else {
                Sel_IntExt.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(6) != -1) {
                response.ID_PACI = objData_Pac.ID_PACIENTE;
            }
            console.log("Req Other Ate");
            //console.group("checked");
            
            //console.log($("#objChk_Filther_0").prop("checked"));
            //console.log($("#objChk_Filther_1").prop("checked"));
            //console.log($("#objChk_Filther_2").prop("checked"));
            //console.log($("#objChk_Filther_3").prop("checked"));
            //console.log($("#objChk_Filther_4").prop("checked"));
            //console.log($("#objChk_Filther_5").prop("checked"));

            //console.groupEnd();
            let ate = parseInt($("#Txt_NumAte").val());
            if(response.DIRECTION == false){
                ate = ate - 1;
                $("#Txt_NumAte").val(ate);
            }else{
                ate = ate + 1;
                $("#Txt_NumAte").val(ate);
            }

            if($("#objChk_Filther_0").prop("checked") == false 
                && $("#objChk_Filther_1").prop("checked") == false 
                && $("#objChk_Filther_2").prop("checked") == false 
                && $("#objChk_Filther_3").prop("checked") == false 
                && $("#objChk_Filther_4").prop("checked") == false 
                && $("#objChk_Filther_5").prop("checked") == false){
                console.log("SUMA RESTA");
                

                console.log("Bool: "+response.DIRECTION);

                
                console.log(ate);
                objAJAX_Get_ID_ATE.requestNow({
                    NUM_ATE: ate
                });
            }else{
                objAJAX_Get_Other_Ate.requestNow(response);
            }
            
        };
    };
    Btn_AteL.click(fn_Change_Ate(false));
    Btn_AteR.click(fn_Change_Ate(true));
    //Evento de carga------------------------------------------------------------------------------
    window.addEventListener('popstate', () => {
        modal_show();
        let matched = location.href.match(/(ID.+)/gi);
        if (matched != null) {
            strUrlQuery = location.href.match(/(ID.+)/gi)[0];
        }
        else {
            strUrlQuery = null;
            clearInterval(num_title_loop);
            document.title = "Visor de Resultados";
            Dtt_Exam.cleanTable("Por favor introduzca un Nro de Atención, en la casilla correspondiente, y presione Enter para Iniciar la búsqueda.");
            console.clear();
            console.log("-->Se ha ingresado directamente al formulario...");
            console.log("   Carga finalizada.-\n");
            Hide_Modal();
            return;
        }
        document.title = `CARGANDO`;
        num_title_loop = setInterval(fn_title_loop, 250);
        Mdl_Init_Load.count = 2;
        Mdl_Init_Load.loaded = false;
        Mdl_Init_Load.endLoad();
    });
    $(document).ready(() => {
        let USU_PROF = Galletas.getGalleta("ID_PROF");

        if(USU_PROF == 1){
            $("#Btn_Validar").removeAttr("disabled");
            $("#Btn_Desvalidar").removeAttr("disabled");
        }else{
            $("#Btn_Validar").attr("disabled",true);
            $("#Btn_Desvalidar").attr("disabled",true);
        }
        //General
        modal_show();
        Btn_Audit.setActive(false);
        document.title = `CARGANDO`;
        num_title_loop = setInterval(fn_title_loop, 250);
        //Primera Carga
        objAJAX_Sel_Exam.requestNow();
        objAJAX_Sel_IntExt.requestNow();
        objAJAX_Sel_Proc.requestNow();
        //Modal Históricos
        $("#mdlHistPruebas").on("hidden.bs.modal", (e) => {
            if (bol_toHistCf == true) {
                Btn_GraphAlt.setActive(false);
                $("#mdlHistExam").modal("show");
            }
            if (bol_toHistPru == true) {
                //$("#mdlGraph").modal();
            }
        });
        //Modal Gráfico
        Btn_GraphAlt.setActive(false);
        $("#mdlGraph").on("hidden.bs.modal", (e) => {
            if (bol_toHistPru == true) {
                //$("#mdlHistPruebas").modal();
            }
        });
    });
    let fn_Charge_Exam = (option = 0) => {
        Sel_Exam.cleanAll();
        Sel_Exam.data = [];
        //Desarmar Array
        Sel_Exam.insertElem("<< Todos >>", 0);
        if (objSel_Secc != null) {
            objSel_Secc.forEach(ayyy => {
                let xItem = JSON.parse(decodeURI(atob(`${ayyy.ID}`)));
                if (xItem.ID_SECC != 0) {
                    objSel_Exam.forEach(lmao => {
                        xItem.ARR_ID.forEach(ID_CF => {
                            if (lmao.ID == ID_CF) {
                                Sel_Exam.insertElem(lmao.DESC, lmao.ID);
                            }
                        });
                    });
                }
            });
        }
        Sel_Exam.setValue(option);
    };
    //Comportamiento Botones Inferiores------------------------------------------------------------
    let fn_Redim_Bottom_Bar = () => {
        let x = window.innerWidth;
        let y = window.innerHeight;
        let bolClass = $("body").hasClass("sidenav-toggled");
        console.log(`Width: ${x}\nHeight: ${y}\nHasClass: ${bolClass}`);
        if (bolClass == true) {
            $(".float_buttons").addClass("float_buttons_toggled");
        }
        else {
            $(".float_buttons").removeClass("float_buttons_toggled");
        }
    };
    $(document).ready(() => {

        $("#Btn_P_Anti").click(()=>{
            $("#mdlPanel").modal("show");

            if(ID_ATE != ""){
                fn_Busca_Dtt_Cultivos();
            }

        });

        $("#btn_Agregar").click(()=>{
            fn_Agrega_Panel();
        });

        $("#btn_Quitar").click(()=>{
            fn_Quita_Panel();
        });

        $("#btn_Guardar_Panel").click(()=>{
            console.log("btn guarda panel");
            fn_Guarda_Panel();
        });

        fn_Redim_Bottom_Bar();
        $(window).resize(() => {
            fn_Redim_Bottom_Bar();
        });
        $("#sidenavToggler").click(() => {
            fn_Redim_Bottom_Bar();
        });
    });

    // BUSCA CULTIVOS

    let Mx_CF_Cult = [{
        "ID_CODIGO_FONASA": "",
        "CF_COD": "",
        "CF_DESC": "",
        "USU_NIC": "",
        "ID_DET_ATE": "",
        "ATE_DET_V_ID_ESTADO": "",
        "ATE_DET_V_FECHA": ""
    }];

    function fn_Busca_Dtt_Cultivos(){
        $("#table_Cultivos tbody").empty();
        $("#table_Cargado tbody").empty();
        $("#table_No_Cargado tbody").empty();
        $("#dat_Ate").empty();
        Mx_CF_Cult=[];
        modal_show();
        var strParam = JSON.stringify({
            "ID_ATE": ID_ATE
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados.aspx/Busca_Exa_Cultivo",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                console.log(data.d);
                Mx_CF_Cult = data.d;

                if(Mx_CF_Cult != null){
                    fn_Fill_Dtt_Cultivos();
                }

            },
            "error": data => {
                Hide_Modal();
            }
        });
        
    }

    function fn_Fill_Dtt_Cultivos(){
        
        $("#dat_Ate").html("<span class='w-100 text-center mb-3' style='color:#014b5d !important'><b>Folio: "+objData_Pac.ATE_NUM+" | "+objData_Pac.PAC_NOMBRE+" "+objData_Pac.PAC_APELLIDO+" | "+objData_Pac.PAC_RUT+" | F. Ate: "+moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY")+" | "+objData_Pac.EDAD+" | "+objData_Pac.SEXO_DESC+"</b></span>");
        console.log("FILL DTT CULTIVOS");
        let i=0;
        Mx_CF_Cult.forEach(aah =>{
            $("#table_Cultivos tbody").append(
             $("<tr>", { "class": "manito" ,"name":"p_Anti","data-index":i}).append(
              $("<td>").css("height","0").text(aah.CF_COD),
              $("<td>").css("height","0").text(aah.CF_DESC),
              $("<td>").css("height","0").text(moment(aah.ATE_DET_V_FECHA).format("DD-MM-YYYY HH:mm:ss")),
              $("<td>").css("height","0").text(aah.USU_NIC),
              $("<td>").css("height","0").html(()=>{
                  if (aah.ATE_DET_V_ID_ESTADO == 6 || aah.ATE_DET_V_ID_ESTADO == 14){
                      return "<input type='checkbox' checked/>";
                  }else{
                      return "<input type='checkbox'/>";
                  }
              }),
              $("<td>").css("height","0").html(()=>{
                  if (aah.ATE_DET_V_ID_ESTADO == 14){
                      return "<input type='checkbox' checked/>";
                  }else{
                      return "<input type='checkbox'/>";
                  }
              })
              )
           );
            i+=1;
        });

        $("tr[name='p_Anti']").click(e=>{
            let d_index = $(e.currentTarget).attr("data-index");
            fn_Busca_Dtt_No_Cargados(Mx_CF_Cult[d_index].ID_CODIGO_FONASA,ID_ATE);
            fn_Busca_Dtt_Cargados(Mx_CF_Cult[d_index].ID_CODIGO_FONASA,ID_ATE);
        });
        Hide_Modal();
    }

    // Busca Panel No Cargado

    let Mx_Ant_No_Cargado = [{
        "ID_CODIGO_FONASA": "",
        "CF_DESC": ""
    }];

    function fn_Busca_Dtt_No_Cargados(_ID_CF, _ID_ATE){
        $("#table_No_Cargado tbody").empty();
        Mx_Ant_No_Cargado = [];
        //modal_show();
        var strParam = JSON.stringify({
            "ID_CF": _ID_CF,
            "ID_ATE": _ID_ATE
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados.aspx/Busca_Exa_Ant_No_Cargado",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                console.log(data.d);
                Mx_Ant_No_Cargado = data.d;

                if(Mx_Ant_No_Cargado != null){
                    fn_Fill_Dtt_No_Cargados();
                }

            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }

    function fn_Fill_Dtt_No_Cargados(){
        console.log("FILL DTT NO CARGADOS");
        let i=0;
        Mx_Ant_No_Cargado.forEach(aah =>{
            $("#table_No_Cargado tbody").append(
             $("<tr>", { "class": "manito" ,"name":"p_No_C","data-index":i, "data-type":"No_Cargado"}).append(
              $("<td>").css("height","0").text(aah.CF_DESC),
              $("<td>").css("height","0").html(()=>{
                  return "<input type='checkbox' name='chk_No_Cargado'/>";
              })
             )
           );
            i+=1;
        });

        $("input[name='chk_No_Cargado']").click((e) =>{
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            console.log(index+" "+checked);
            if(checked == true){
                if(Mx_Check_NC.length > 0){
                    let cnt = 0;
                    Mx_Check_NC.forEach(aah =>{
                        if(aah == index){
                            cnt = 1;
                        }
                    });
                    if(cnt == 0){
                        Mx_Check_NC.push({"index":index,"type":type});  
                    }
                    console.log(Mx_Check_NC);
                }else{
                    Mx_Check_NC.push({"index":index,"type":type});
                    console.log(Mx_Check_NC);
                }
            }else{
                let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                Mx_Check_NC.splice(Mx_Index,1);
                console.log(Mx_Check_NC);
            }
        }).one();
    }

    // Busca Panel Cargado

    let Mx_Ant_Cargado = [{
        "ID_REL_CF_ANTIB": "",
        "ID_CODIGO_FONASA": "",
        "ID_ATENCION": "",
        "ID_DET_ATE": "",
        "ID_CF_ANTIBIOGRAMA": "",
        "CF_DESC": "",
        "CF_COD": "",
        "CF_DESC_CULT":"",
        "ATE_NUM":""
    }];

    function fn_Busca_Dtt_Cargados(_ID_CF, _ID_ATE){
        $("#table_Cargado tbody").empty();
        Mx_Ant_Cargado=[];
        //modal_show();
        var strParam = JSON.stringify({
            "ID_CF": _ID_CF,
            "ID_ATE": _ID_ATE
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados.aspx/Busca_Exa_Ant_Cargado",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                console.log(data.d);
                Mx_Ant_Cargado = data.d;

                if(Mx_Ant_Cargado != null){
                    fn_Fill_Dtt_Cargados();
                }

            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }

    function fn_Fill_Dtt_Cargados(){
        console.log("FILL DTT CARGADOS");
        let i=0;
        Mx_Ant_Cargado.forEach(aah =>{
            $("#table_Cargado tbody").append(
             $("<tr>", { "class": "manito" ,"name":"p_C","data-index":i, "data-type":"Cargado"}).append(
              $("<td>").css("height","0").text(aah.CF_DESC),
              $("<td>").css("height","0").html(()=>{
                  return "<input type='checkbox' name='chk_Cargado'/>";
              }),
              $("<td>").css("height","0").text(aah.CF_DESC_CULT),
              $("<td>").css("height","0").text(aah.ATE_NUM)
             )
           );
            i+=1;
        });

        $("input[name='chk_Cargado']").click((e) =>{
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            console.log(index+" "+checked);
            if(checked == true){
                if(Mx_Check_C.length > 0){
                    let cnt = 0;
                    Mx_Check_C.forEach(aah =>{
                        if(aah == index){
                            cnt = 1;
                        }
                    });
                    if(cnt == 0){
                        Mx_Check_C.push({"index":index,"type":type});  
                    }
                    console.log(Mx_Check_C);
                }else{
                    Mx_Check_C.push({"index":index,"type":type});
                    console.log(Mx_Check_C);
                }
            }else{
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index,1);
                console.log(Mx_Check_C);
            }
        }).one();
    }

    // Agregar Quitar Panel

    function fn_Agrega_Panel(){
        modal_show();
        Mx_Check_NC.forEach(aah=>{
            $("tr[name='p_No_C'][data-index='"+aah.index+"'][data-type='"+aah.type+"']").remove();

            $("#table_Cargado tbody").append(
             $("<tr>", { "class": "manito" ,"name":"p_C","data-index":aah.index,"data-type":aah.type}).append(
              $("<td>").css("height","0").text(()=>{
                  if(aah.type == "No_Cargado"){
                      return Mx_Ant_No_Cargado[aah.index].CF_DESC;
                  }else{
                      return Mx_Ant_Cargado[aah.index].CF_DESC;
                  }
                  
              }),
              $("<td>").css("height","0").html(()=>{
                  return "<input type='checkbox' name='chk_Cargado'/>";
              }),
              $("<td>").css("height","0").text(""),
              $("<td>").css("height","0").text("")
             )
           );


        });
        $("input[name='chk_Cargado']").unbind();
        $("input[name='chk_Cargado']").click((e) =>{
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            //console.log(index+" "+checked);
            if(checked == true){
                if(Mx_Check_C.length > 0){
                    let cnt = 0;
                    Mx_Check_C.forEach(aah =>{
                        if(aah == index){
                            cnt = 1;
                        }
                    });
                    if(cnt == 0){
                        Mx_Check_C.push({"index":index,"type":type});  
                    }
                    //console.log(Mx_Check_C);
                }else{
                    Mx_Check_C.push({"index":index,"type":type});
                    //console.log(Mx_Check_C);
                }
            }else{
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index,1);
                //console.log(Mx_Check_C);
            }
        }).one();

        Mx_Check_NC = [];
        Hide_Modal();
    }

    function fn_Quita_Panel(){
        modal_show();
        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");
        let _EST_VALIDA = Mx_CF_Cult[c_index].ATE_DET_V_ID_ESTADO;

        if(_EST_VALIDA != 6 && _EST_VALIDA != 14){
            Mx_Check_C.forEach(aah=>{
                $("tr[name='p_C'][data-index='"+aah.index+"'][data-type='"+aah.type+"']").remove();

                $("#table_No_Cargado tbody").append(
                 $("<tr>", { "class": "manito" ,"name":"p_No_C","data-index":aah.index,"data-type":aah.type}).append(
                  $("<td>").css("height","0").text(()=>{
                      if(aah.type == "No_Cargado"){
                          return Mx_Ant_No_Cargado[aah.index].CF_DESC;
                      }else{
                          return Mx_Ant_Cargado[aah.index].CF_DESC;
                      }
                  
                  }),
                  $("<td>").css("height","0").html(()=>{
                      return "<input type='checkbox' name='chk_No_Cargado'/>";
                  })
                 )
               );
            });
            $("input[name='chk_No_Cargado']").unbind();
            $("input[name='chk_No_Cargado']").click((e) =>{
                //e.stopImmediatePropagation();
                let index = $(e.currentTarget).parent().parent().attr("data-index");
                let checked = $(e.currentTarget).prop("checked");
                let type = $(e.currentTarget).parent().parent().attr("data-type");
                //console.log(index+" "+checked);
                if(checked == true){
                    if(Mx_Check_NC.length > 0){
                        let cnt = 0;
                        Mx_Check_NC.forEach(aah =>{
                            if(aah == index){
                                cnt = 1;
                            }
                        });
                        if(cnt == 0){
                            Mx_Check_NC.push({"index":index,"type":type});  
                        }
                        //console.log(Mx_Check_NC);
                    }else{
                        Mx_Check_NC.push({"index":index,"type":type});
                        //console.log(Mx_Check_NC);
                    }
                }else{
                    let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                    Mx_Check_NC.splice(Mx_Index,1);
                    //console.log(Mx_Check_NC);
                }
            }).one();

            Mx_Check_C = [];
            Hide_Modal();
        }else{
            console.log("CF VALIDADO O IMPRESO");
            Hide_Modal();
            $(`#mdlAlert .modal-header .modal-title`).text("Examen Validado o Impreso");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, No puede quitar paneles asociados a exámenes validados o impresos."));
            $(`#mdlAlert`).modal();
        }
    }

    // Guardar Panel

    function fn_Guarda_Panel(){

        console.clear();
        console.log("GUARDA PANEL");

        let NCar = [];
        let Car = [];
        let Mx_Guarda_Panel = [];

        Car = $("tr[name='p_C']");
        NCar = $("tr[name='p_No_C']");

        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");
        let ID_CF_CULT = Mx_CF_Cult[c_index].ID_CODIGO_FONASA;

        //console.log(Mx_Ant_Cargado);
        //console.log(Mx_Ant_No_Cargado);

        // Buscar data-type Cargado
        for(i = 0; i < Car.length; i++){
            let _type = Car[i].getAttribute("data-type");
            let _index = Car[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();

            if(_type == "No_Cargado"){
                //console.log(_index+" "+_type);
                Mx_Guarda_Panel.push({"ID_PANEL" : Mx_Ant_No_Cargado[_index].ID_CODIGO_FONASA, "ID_ATE" : ID_ATE, "ID_CF_CULT" : ID_CF_CULT, "ID_PREVE" : _prev, "TYPE" : "Crea"});
            }
        }

        // Buscar data-type No_Cargado
        for(i = 0; i < NCar.length; i++){
            let _type = NCar[i].getAttribute("data-type");
            let _index = NCar[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();


            if(_type == "Cargado"){
                //console.log(_index+" "+_type);
                Mx_Guarda_Panel.push({"ID_PANEL" : Mx_Ant_Cargado[_index].ID_CF_ANTIBIOGRAMA, "ID_ATE" : Mx_Ant_Cargado[_index].ID_ATENCION, "ID_CF_CULT" : ID_CF_CULT, "ID_PREVE" : _prev, "TYPE" : "Quita"});
            }
        }

        if(Mx_Guarda_Panel.length > 0){
            console.log(Mx_Guarda_Panel);
            modal_show();
            var strParam = JSON.stringify({
                "Mx_Panel": Mx_Guarda_Panel
            });
            $.ajax({
                "type": "POST",
                "url": "Ate_Resultados.aspx/Guarda_Panel_Cultivo",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(data.d);
                    $("tr[name='p_Anti'][class='manito active']").trigger("click");

                    objAJAX_Get_ID_ATE.requestNow({
                        NUM_ATE: $("#Txt_NumAte").val()
                    });

                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                }
            });
        
        }
    }


    function modal_Crit(ID_RES,TITLE,TEXT,Z){

        
        $("#mdls").append(
            $("<div>",{
                "id":"mdl"+ID_RES,
                "class":"modal fade",
                "data-backdrop":"static",
                "style":"z-index:"+Z+" !important"})
         );
                     
        $("<div>",{
            "class":"modal-dialog modal-md"}
        ).append(
             $("<div>",{
                 "id":"mdl_cont"+ID_RES,
                 "class":"modal-content border-danger"})
                 ).appendTo($("#mdl"+ID_RES));
    
        $("<div>",{
            "class":"modal-header bg-danger text-white text-center"}
            ).append(
                 $("<h4>",{
                     "id":"mdl_title"+ID_RES,
                     "class":"modal-title w-100"})
                     ).appendTo($("#mdl_cont"+ID_RES));

        $("<div>",{
            "id":"mdl_text"+ID_RES,
            "class":"modal-body pt-6 pb-6 text-left"}
                    ).appendTo($("#mdl_cont"+ID_RES));

        $("<div>",{
            "class":"modal-footer"}
            ).html("<button type='button' class='btn btn-primary' data-dismiss='modal'><i class='fa fa-check' aria-hidden='true'></i><span>Aceptar</span></button>").appendTo($("#mdl_cont"+ID_RES));


        $("#mdl_title"+ID_RES).text(TITLE);
        $("#mdl_text"+ID_RES).html(TEXT);
        Hide_Modal();

        $("#mdl"+ID_RES).modal({backdrop: false}).one();
      
        
        //$("#mdl"+ID_RES).modal({backdrop: false});
    }


    //Modal Resultados Codificados-----------------------------------------------------------------
    $(document).ready(() => {
        $(`#Btn_RC_Add`).click((Me) => {
            let xVal = Txt_ResCod_Out.value.replace(/\./gi, ",");
            $("#Dtt_Exam .tr_selected input[type=text]").val(xVal);
            let xEvent = $.Event("keypress");
            let objInput = document.querySelector("#Dtt_Exam .tr_selected input[type=text]");
            xEvent.currentTarget = objInput;
            xEvent.which = 13;
            xEvent.keyCode = 13;
            fn_Write(xEvent);
            fn_Calc();
            keyEnter = true;
            $(objInput).parents("tr").next().find("input[type=text]").focus();
        });
    });
})(ATE_RES || (ATE_RES = {}));
//# sourceMappingURL=Ate_Resultados.js.map
