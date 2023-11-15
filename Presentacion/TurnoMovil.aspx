<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="TurnoMovil.aspx.vb" Inherits="Presentacion.VistaModulosMovil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <!-- Google Fonts-->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@500;800;900&display=swap" rel="stylesheet"/> 

    <!--#############################  -->
    
    <link rel="stylesheet" href="css/TestTurno.css" />
    <!--<script src="actualizarModulos.js"></script>-->

    <script src="TurnoMovil.js"></script>
    <!--<script src="turnoVisor.js"></script>-->
    <!--<script src="../mTurnoIngreso/turnoIngreso1.js"></script>-->
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
 
    <!--Div contenedor que tenga la clase row e id="div_Cartas"
        JQuery limpiar div_Cartas => $("#div_Cartas").empty();
        Buscar todos los módulos activos en la BD
        Por cada objeto en la lista que retorna la BD agregar <div> con clase col-lg con data-id="ID_MODULO_TURNO"
        $("<div>").attr({"class":"col-lg","data-id":"ID_MODULO_TURNO"}).appendTo($("#div_Cartas"));
          -->


    
    <div class="col">
        <img src="Imagenes/irislab_lateral.svg" width="300px" height:"3rem"/>
        
    </div>
   <div class="container row" id="Head_Cartas">
     
   </div>
   <div class="row" id="div_cartas" style="margin: auto"></div>
   
   <div class="row">
            <!--Reloj en el pie de la pagina -->
            <div class="col-md-4 date">
                <span id="S" class="weekDays"></span>, 
                <span id="D" class="day"></span>. 
                <span id="M" class="month"></span>
                <span id="A" class="year"></span>
            </div>
            <div class="col-md-4 clock">
                <div class="row">
                <div id="h" class="hours col card-header text-white "style="background:#006699"></div> <div id="j">:</div>
                <div id="m" class="minutes col card-header text-white"style="background:#006699"></div> <div id="j">:</div>
                <div id="s" class="seconds col card-header text-white"style="background:#006699"></div>
                </div>
            </div>

       <style>
           .container row{
               text-align:center;
           }
           .date{
               margin:0 auto;
               text-align:center;
           }

           .clock{
              text-align:center;
              margin: 10px;
           }
           #h,#m,#s{
               width:2rem;
               font-size:2.0rem;
               border-radius:5px;
               font-weight:700;
           }
           #S, #D, #M ,#A,#j{
               font-size:2.2rem;
               font-weight:600;
               color:#006699
           }
           .colorNoti{
            background-color:#3c6b7a;
            }
          
       </style>

   </div>

</asp:Content>

