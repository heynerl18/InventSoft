<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="InVentSoft.UI.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Productos</h2>
    <hr />
    <table class="table table-bordered table-hover">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Categoría</th>
                <th>Precio Sin Iva</th>
                <th>Iva</th>
                <th>Unidad Venta</th>
                <th>Stock</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpProductos" runat="server">
                <ItemTemplate>
                    <tr id='<%# "fila" + Eval("id") %>'>
                        <td class="id-categoria">
                            <center><%# Eval("id") %></center>
                        </td>
                        <td>
                            <center><%# Eval("nombre") %></center>
                        </td>
                        <td>
                            <center><%# Eval("cat.nombre") %></center>
                        </td>
                        <td>
                            <center><%# Eval("PrecioSinIva") %></center>
                        </td>
                        <td>
                            <center><%# Eval("Iva") %></center>
                        </td>
                        <td>
                            <center><%# Eval("UnidadVenta") %></center>
                        </td>
                        <td>
                            <center><%# Eval("Stock") %></center>
                        </td>

                        <td>
                            <center>
                                <button type="button" class="btn btn-warning" id="editarbtn" onclick='abrirModalEditar(<%# Eval("id") %>)'>Editar</button>
                                <button type="button" class="btn btn-danger" id="eliminarbtn" onclick='abrirModalEliminar(<%# Eval("id") %>)'>Eliminar</button>
                            </center>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
