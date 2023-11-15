<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="actualizarModulosVista.aspx.vb" Inherits="Presentacion.visorModulosVista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <!-- Google Fonts-->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@500;800;900&display=swap" rel="stylesheet"/> 
    
    <link rel="stylesheet" href="../../../css/TestTurno.css" />
    <script src="VistaModulosActualizados_2.js"></script>

    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
   
    <div class="col">
        <img src="../../../Imagenes/irislab_lateral.svg" width="320px" height:"3rem"/>
    </div>

   <div class="row" id="Head_Cartas" style="margin-left:1rem">
     
   </div>
    <div class="row">
        <div class="col-2">
            <div id="cartaVista">
               
            </div>
        </div>
        <div class="col-10">
            <div class="row" id="div_cartas" style="margin:0 5rem; justify-content:flex-end;"></div>
        </div>
    </div>
   
   
   <div class="row">
            <div class="col"></div>
            <div class="col-md-3 date">
                <span id="S" class="weekDays"></span>, 
                <span id="D" class="day"></span>. 
                <span id="M" class="month"></span>
                <span id="A" class="year"></span>
            </div>
            <div class="row clock">
                <span id="h" class="hours col-md-3 text-white "style="background:#006699"></span> <span id="j">:</span>
                <span id="m" class="minutes col-md-3  text-white"style="background:#006699"></span> <span id="j">:</span>
                <span id="s" class="seconds col-md-3 text-white"style="background:#006699"></span>
            </div>

       <style>
           #h,#m,#s{
               width:5.8rem;
               font-size:2.5rem;
               border-radius:5px;
               font-weight:700;
               margin:0 auto;
           }
           #S, #D, #M ,#A,#j{
               
               margin:0 auto;
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
