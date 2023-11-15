<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_Producto.aspx.vb" Inherits="Presentacion.Ingreso_Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="Ingreso_Producto.js"></script>

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
                                <label class="col-md-4 control-label" for="textinput">Producto:</label>
                                <input id="nombre_producto" name="textinput" type="text" placeholder="Ingrese el producto" class="form-control input-md" required=""/>
                            </div>

                            <div class="form-group">
                                <label class="col-md-4 control-label" for="textarea">Descripción</label>

                                <textarea class="form-control" id="descripcion_producto" name="textarea"></textarea>

                            </div>

                            <div class="form-group">

                                <label class="col-md-4 control-label" for="precio">Precio:</label>


                                <input id="precio_producto" name="precio" type="number" placeholder="Ingrese el monto." class="form-control input-md" required=""/>
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-primary" id="enviar">
                                    Enviar
                                </button>
                            </div>
                            <div id="exito" style="display: none">
                                <p>Sus datos han sido enviados correctamente.</p>
                            </div>
                            <div id="fracaso" style="display: none">
                                <p>Se ha producido un error.</p>
                            </div>
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
