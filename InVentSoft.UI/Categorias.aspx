<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="InVentSoft.UI.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .crear-btn {
            margin-bottom: 2px;
        }
    </style>

    <h2 class="text-center">Categorías</h2>
    <asp:Button ID="Crearbtn" CssClass="btn btn-success crear-btn" Text="Crear Nueva Categoría" runat="server" OnClick="Crearbtn_Click" />

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
                <th>Iva</th>
                <th>GrupoAlimentos</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpCategorias" runat="server">
                <ItemTemplate>
                    <tr id='<%# "fila" + Eval("id") %>'>
                        <td class="id-categoria"><center><%# Eval("id") %></center></td>
                        <td><center><%# Eval("nombre") %></center></td>
                        <td><center><%# Eval("iva") %></center></td>
                        <td><center><%# Eval("grupoAlimentos") %></center></td>
                        <td>
                            <center>
                               <button type="button" class="btn btn-warning" id="editarbtn" onclick='abrirModalEditar(<%# Eval("id") %>)' >Editar</button>
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
                    <h4 class="modal-title">Crear Categoría</h4>
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
                    <asp:TextBox ID="nombre" CssClass="form-control" placeholder="Nombre de categoría" runat="server" />
                    <asp:Label Text="Iva" runat="server" />
                    <asp:TextBox ID="iva" CssClass="form-control" placeholder="Iva" runat="server" />
                    <asp:Label Text="Grupo Alimentos" runat="server" />
                    <asp:DropDownList ID="grupoalimentos" CssClass="form-control" runat="server">
                        <asp:ListItem Text="">Seleccione el grupo de alimento</asp:ListItem>
                        <asp:ListItem Text="Lácteos" />
                        <asp:ListItem Text="Hogar" />
                        <asp:ListItem Text="Carnes" />
                        <asp:ListItem Text="Frutas y Verduras" />
                        <asp:ListItem Text="Pastas" />
                        <asp:ListItem Text="Enlatados" />
                    </asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Btnguadar" CssClass="btn btn-primary" Text="Guardar" runat="server" OnClick="Btnguadar_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal editar categoria -->
        <div id="editModal" class="modal fade" data-backdrop="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title">Editar Categoría</h4>
                </div>
                <div class="modal-body">
                   <asp:Panel ID="pErrorEdit" CssClass="alert alert-danger" runat="server" Visible="false">
                      <asp:Repeater ID="rpErroresEdit" runat="server">
                       <ItemTemplate>
                          <li><%# Container.DataItem %></li>
                       </ItemTemplate>
                      </asp:Repeater>
                    </asp:Panel>
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="txtnombre" CssClass="form-control" placeholder="Nombre de categoría" runat="server" />
                    <asp:Label Text="Iva" runat="server" />
                    <asp:TextBox ID="txtiva" CssClass="form-control" placeholder="Iva" runat="server" />
                    <asp:Label Text="Grupo Alimentos" runat="server" />
                    <asp:DropDownList ID="listgrupoalimentos" CssClass="form-control" runat="server">
                        <asp:ListItem Text="">Seleccione el grupo de alimento</asp:ListItem>
                        <asp:ListItem Text="Lácteos" />
                        <asp:ListItem Text="Hogar" />
                        <asp:ListItem Text="Carnes" />
                        <asp:ListItem Text="Frutas y Verduras" />
                        <asp:ListItem Text="Pastas" />
                        <asp:ListItem Text="Enlatados" />
                    </asp:DropDownList>

                    <asp:HiddenField ID="idcategoriaeditar" runat="server" />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Btneditar" CssClass="btn btn-primary" Text="Editar" runat="server" OnClick="Btneditar_Click"/>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal eliminar categoria -->
        <div id="deleteModal" class="modal fade" data-backdrop="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title">Eliminar Categoría</h4>
                    <asp:Label ID="label1" Text="" runat="server" />
                </div>
                <div class="modal-body">
                    <p>¿Estás seguro de que quieres eliminar esta categoría?</p>
                    <asp:HiddenField ID="idcategoriaeliminar" runat="server" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Btneliminar" CssClass="btn btn-primary" Text="Eliminar" runat="server" OnClick="Btneliminar_Click"/>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function abrirModalEliminar(idCategoria) {
            $('#<%= idcategoriaeliminar.ClientID %>').val(idCategoria);
            $('#deleteModal').modal('show');
        }

        function abrirModalEditar(idCategoria) {

            var elementoTr = document.getElementById('fila' + idCategoria);
            var elementosTd = elementoTr.getElementsByTagName('td');

            $('#<%= txtnombre.ClientID %>').val(elementosTd[1].textContent);
            $('#<%= txtiva.ClientID %>').val(elementosTd[2].textContent);
            $('#<%= listgrupoalimentos.ClientID %>').val(elementosTd[3].textContent);

            $('#<%= idcategoriaeditar.ClientID %>').val(idCategoria);

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
