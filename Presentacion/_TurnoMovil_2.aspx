<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="_TurnoMovil_2.aspx.vb" Inherits="Presentacion._TurnoMovil_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
      <!-- Google Fonts-->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@500;800;900&display=swap" rel="stylesheet"/>  
    <link rel="stylesheet" href="css/TestTurno.css" />
    <script src="_TurnoMovil_2.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server"> 
       
    <div class="col img-iris">
        <img src="Imagenes/irislab_lateral.svg" width="300px" height:"3rem"/>
    </div>

   <div class="container row" id="Head_Cartas"></div>

   <div class="col" id="div_cartas" style="margin:0 auto"></div>
   
   <div class="row">
            
            <div class="col-md-4 date">
                <span id="S" class="weekDays"></span><span class="j">,</span> 
                <span id="D" class="day"></span><span class="j">.</span> 
                <span id="M" class="month"></span>
                <span id="A" class="year"></span>
            </div>
            <div class="col-md-4 clock">
                <div class="row">
                <div id="h" class="hours col card-header text-white "style="background:#006699"></div> <div class="j">:</div>
                <div id="m" class="minutes col card-header text-white"style="background:#006699"></div> <div class="j">:</div>
                <div id="s" class="seconds col card-header text-white"style="background:#006699"></div>
                </div>
            </div>

       <!--Estilos del reloj del visor de turno movil-->
       <style>
           .img-iris{
               margin:10px auto;
           }

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
           #S, #D, #M ,#A,.j{
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
