<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="InVentSoft.UI.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Productos</h2>
    <asp:Button ID="Crearbtn" CssClass="btn btn-success crear-btn" runat="server" Text="Crear Nuevo Producto" OnClick="Crearbtn_Click"/>
    <hr />
    <asp:Panel ID="pnlAlertaExitoso" CssClass="alert alert-success" runat="server" Visible="false">
      <asp:Label ID="labelsuccess" Text="" runat="server" />
      <button type="button" class="close" onclick="cerrarAlerta()" aria-label="Close">
        <span aria-hidden="true">&times;</span>
      </button>
    </asp:Panel>
    <asp:Panel ID="panelAlertaError" CssClass="alert alert-danger" runat="server" Visible="false">
      <asp:Label ID="labelError" Text="" runat="server" />
      <button type="button" class="close" onclick="cerrarAlertaError()" aria-label="Close">
        <span aria-hidden="true">&times;</span>
      </button>
    </asp:Panel>
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
                                <button type="button" class="btn btn-warning" id="editarbtn" onclick='abrirModalEditar(<%# Eval("id") %>, <%# Eval("cat.id") %>)'>Editar</button>
                                <button type="button" class="btn btn-danger" id="eliminarbtn" onclick='abrirModalEliminar(<%# Eval("id") %>)'>Eliminar</button>
                            </center>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <!-- Modal crear categorias -->
    <div id="formModal" class="modal fade" data-backdrop="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title">Crear Producto</h4>
                </div>
                <div class="modal-body">
                    
                    <asp:Panel ID="pErrores" CssClass="alert alert-danger" runat="server" Visible="false">
                      <asp:Repeater ID="rpErrores" runat="server">
                       <ItemTemplate>
                          <li><%# Container.DataItem %></li>
                       </ItemTemplate>
                      </asp:Repeater>
                    </asp:Panel>

                    <asp:Label Text="Nombre" runat="server"/>
                    <asp:TextBox ID="nombre" CssClass="form-control" placeholder="Ingrese nombre del producto" runat="server" />

                    <asp:Label Text="Categoría del producto" runat="server" />
                    <asp:DropDownList ID="ddlcategoria" CssClass="form-control" runat="server">
                    </asp:DropDownList>

                    <asp:Label Text="Precio Sin Iva" runat="server" />
                    <asp:TextBox ID="preciosiniva" Type="Number" CssClass="form-control" placeholder="Ingrese Precio Sin Iva" runat="server" />

                    <asp:Label Text="Iva" runat="server" />
                    <asp:TextBox ID="iva" Type="Number" CssClass="form-control" placeholder="Ingrese el iva" runat="server" />

                    <asp:Label Text="Unidad Venta" runat="server" />
                     <asp:DropDownList ID="unidadventa" CssClass="form-control" runat="server">
                        <asp:ListItem Text="">Seleccione la unidad de venta</asp:ListItem>
                        <asp:ListItem Text="Litros" />
                        <asp:ListItem Text="Unidades" />
                        <asp:ListItem Text="Kilos" />
                    </asp:DropDownList>

                    <asp:Label Text="Stock" runat="server" />
                    <asp:TextBox ID="stock" Type="Number" CssClass="form-control" placeholder="Ingrese el stock" runat="server" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Btnguadar" CssClass="btn btn-primary" Text="Guardar" runat="server" OnClick="Btnguadar_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal editar producto -->
    <div id="editModal" class="modal fade" data-backdrop="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title">Editar Producto</h4>
                </div>
                <div class="modal-body">
                    
                    <asp:Panel ID="pErroresEdit" CssClass="alert alert-danger" runat="server" Visible="false">
                        <asp:Repeater ID="rpErroresEdit" runat="server">
                            <ItemTemplate>
                                <li><%# Container.DataItem %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="txtnombre" CssClass="form-control" placeholder="Ingrese nombre del producto" runat="server" />

                    <asp:Label Text="Categoría del producto" runat="server" />
                    <asp:DropDownList ID="ddlistacategoria" CssClass="form-control" runat="server">
                    </asp:DropDownList>

                    <asp:Label Text="Precio Sin Iva" runat="server" />
                    <asp:TextBox ID="txtpreciosiniva" Type="Number" CssClass="form-control" placeholder="Ingrese Precio Sin Iva" runat="server" />

                    <asp:Label Text="Iva" runat="server" />
                    <asp:TextBox ID="txtiva" Type="Number" CssClass="form-control" placeholder="Ingrese el iva" runat="server" />

                    <asp:Label Text="Unidad Venta" runat="server" />
                    <asp:DropDownList ID="ddlistaunidadventa" CssClass="form-control" runat="server">
                        <asp:ListItem Text="">Seleccione la unidad de venta</asp:ListItem>
                        <asp:ListItem Text="Litros" />
                        <asp:ListItem Text="Unidades" />
                        <asp:ListItem Text="Kilos" />
                    </asp:DropDownList>

                    <asp:Label Text="Stock" runat="server" />
                    <asp:TextBox ID="txtstock" Type="Number" CssClass="form-control" placeholder="Ingrese el stock" runat="server" />

                    <asp:HiddenField ID="idproductoeditar" runat="server" />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Btneditar" CssClass="btn btn-primary" Text="Editar" runat="server" OnClick="Btneditar_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal eliminar producto -->
            <div id="deleteModal" class="modal fade" data-backdrop="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title">Eliminar Producto</h4>
                    <asp:Label ID="label1" Text="" runat="server" />
                </div>
                <div class="modal-body">
                    <p>¿Estás seguro de que quieres eliminar esta producto?</p>
                    <asp:HiddenField ID="idproductoeliminar" runat="server" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Btneliminar" CssClass="btn btn-primary" Text="Eliminar" runat="server" OnClick="Btneliminar_Click"/>
                </div>
            </div>
        </div>
    </div>


  <script type="text/javascript">

      function abrirModalEliminar(idProducto) {
          $('#<%= idproductoeliminar.ClientID %>').val(idProducto);
          $('#deleteModal').modal('show');
      }

      function abrirModalEditar(idProducto, idCategoria) {

          var elementoTr = document.getElementById('fila' + idProducto);
          elementosTd = elementoTr.getElementsByTagName('td');

          $('#<%= txtnombre.ClientID %>').val(elementosTd[1].textContent.trim());
          $('#<%= ddlistacategoria.ClientID %>').val(idCategoria);
          $('#<%= txtpreciosiniva.ClientID %>').val(elementosTd[3].textContent.trim());
          $('#<%= txtiva.ClientID %>').val(elementosTd[4].textContent.trim());
          $('#<%= ddlistaunidadventa.ClientID %>').val(elementosTd[5].textContent.trim());
          $('#<%= txtstock.ClientID %>').val(elementosTd[6].textContent.trim());

          $('#<%= idproductoeditar.ClientID %>').val(idProducto);

          $('#editModal').modal('show');
      }

      function cerrarAlerta() {
        document.getElementById('<%= pnlAlertaExitoso.ClientID %>').style.display = 'none';
      }

      function cerrarAlertaError() {
        document.getElementById('<%= panelAlertaError.ClientID %>').style.display = 'none';
      }
  </script>
</asp:Content>
