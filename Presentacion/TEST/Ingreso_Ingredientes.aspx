<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_Ingredientes.aspx.vb" Inherits="Presentacion.Ingreso_Ingredientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="Ingreso_Ingredientes.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container-fluid">
  
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">

                            <div class="form-group">
                                <label class="col-md-4 control-label" for="textinput">Código: </label>
                                <input id="codigo_ingredientes" name="textinput" type="text" placeholder="Codigo del ingrediente" class="form-control input-md" required=""/>
                            </div>

                            <div class="form-group">
                                <label class="col-md-4 control-label" for="textarea">Descripción</label>
                                <textarea class="form-control" id="descripcion_ingredientes" name="textarea"></textarea>
                            </div>

                                <div class="form-group">
                                <label class="col-md-4 control-label" for="textinput">Unidad:</label>
                                <input id="unidad_medida_ingredientes" name="textinput" type="text" placeholder="Unidad de medida" class="form-control input-md" required=""/>
                                </div>

                                <div class="form-group">
                                <label class="col-md-4 control-label" for="textinput">Cantidad:</label>
                                <input id="cantidad_ingredientes" name="textinput" type="number" class="form-control input-md" required=""/>
                                </div>

                                <div class="form-group">
                                <label class="col-md-4 control-label" for="textinput">Fecha vence:</label>
                                <input id="fecha_vencimiento_ingredientes" name="textinput" type="date" class="form-control input-md" required=""/>
                                </div>

                            <div class="form-group">
                                <button type="button" class="btn btn-primary" id="enviar">
                                    Enviar
                                </button>
                            </div>
                          
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
