<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="InVentSoft.UI.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #preportefecha, #preportehora{
            font-family: Arial, sans-serif;
        }
    </style>

    <h2 class="text-center">Ventas</h2>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Ventas</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:Label Text="Productos" runat="server" />
                            <asp:DropDownList ID="ddlproductos" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <asp:Label Text="Cantidad" runat="server" />
                            <asp:TextBox ID="cantidadproductos" type="number" placeholder="Ingrese la cantidad" min="1" max="100" step="1" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" Style="margin-top: 10px;" />
                </div>
            </div>

        </div>
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Detalles</div>
                <div class="panel-body">

                    <div class="text-center">

                        <div class="form-group">
                            <label for="subtotal">Subtotal:</label>
                            <span id="subtotal">₡2000</span>
                        </div>

                        <div class="form-group">
                            <label for="iva">IVA:</label>
                            <span id="iva">₡3500</span>
                        </div>

                        <div class="form-group">
                            <label for="total">Total:</label>
                            <span id="total">₡5500</span>
                        </div>
                        <hr />
                        <asp:Button ID="BtnPagar" Text="Pagar" CssClass="btn btn-primary" runat="server" OnClick="BtnPagar_Click" />
                    </div>

                </div>
            </div>
        </div>
    </div>


    <asp:Panel ID="panelReporte" runat="server" Visible="false">
        <div class="panel panel-default">
            <div class="panel-heading">Factura</div>
            <div class="panel-body">

                <div class="form-group">
                    <label for="total" id="preportefecha">Fecha: </label>
                    <span id="fecha" runat="server"></span>
                </div>

                <div class="form-group">
                    <label for="hora" id="preportehora">Hora: </label>
                    <span id="hora" runat="server"></span>
                </div>

                <table class="table table-bordered table-hover">
                    <thead>
                        <tr style="background-color:#e5e7e9; color: #000; font-weight: bold;">
                            <th>Subtotal</th>
                            <th>Iva total</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>

                        <tr>
                            <td>
                                <center>₡2000</center>
                            </td>
                            <td>
                                <center>₡3500</center>
                            </td>
                            <td>
                                <center>₡5500</center>
                            </td>
                        </tr>

                    </tbody>
                </table>

            </div>
        </div>
    </asp:Panel>
</asp:Content>
