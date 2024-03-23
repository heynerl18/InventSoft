<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="InVentSoft.UI.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center">Reportes</h2>
    <div class="panel panel-primary">
        <div class="panel-heading">Filtrado de reportes</div>
        <div class="panel-body">
            Reportes por categorías.
            <div class="row">
                <div class="col-sm-3">
                    <asp:ListBox ID="lbcategorias" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                </div>
                <div class="col-sm-9">
                    <asp:Button ID="reportecategoria" Text="Filtrar Reporte" CssClass="btn btn-success" runat="server" OnClick="reportecategoria_Click" />
                </div>
            </div>
            <hr style="border-color: #ccc; border-width: 1px; border-style: solid;" />
            Reportes por porcentajes de iva
            <div class="row">
                <div class="col-sm-3">
                    <asp:TextBox ID="txtreporteporcentajeiva" placeholder="Ingrese el porcentaje" Type="Number" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-9">
                    <asp:Button ID="BtnReportePorcentajaIva" Text="Filtrar por iva" CssClass="btn btn-success" runat="server" OnClick="BtnReportePorcentajaIva_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="panelTabla" runat="server" Visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">Resultados de reportes <span class="glyphicon glyphicon-ok-circle"></span></div>
            <div class="panel-body">
                <h2>Reportes de InVent Soft</h2>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr style=" background-color: #343a40;color: #fff;font-weight: bold;">
                            <th>Grupo Alimento</th>
                            <th>Categoría</th>
                            <th>Iva Categoría</th>
                            <th>Producto</th>
                            <th>Stock</th>
                            <th>Unidad Venta</th>
                            <th>Precio Sin Iva</th>
                            <th>Iva Producto</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpReportes" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <center><%# Eval("cat.grupoAlimentos") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("cat.nombre") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("cat.iva") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("nombre") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("stock") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("unidadVenta") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("precioSinIva") %></center>
                                    </td>
                                    <td>
                                        <center><%# Eval("Iva") %></center>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="panelAlertaError" CssClass="alert alert-danger" runat="server" Visible="false">
        <asp:Label ID="labelError" Text="" runat="server" />
        <button type="button" class="close" onclick="cerrarAlertaError()" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </asp:Panel>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.4.1, /css/bootstrap.min.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.4.1, /js/bootstrap.min.js"></script>

<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />

<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>

<script type="text/javascript">

    $(function () {
        $('#<%= lbcategorias.ClientID %>').multiselect({
            includeSelectAllOption: false,
            nonSelectedText: 'Seleccione categoría',
            buttonWidth: '100%',
            maxHeight: 200,
            dropRight: true,
        });
    });

    function cerrarAlertaError() {
        document.getElementById('<%= panelAlertaError.ClientID %>').style.display = 'none';
    }

</script>


</asp:Content>
