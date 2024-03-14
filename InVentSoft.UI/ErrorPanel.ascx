<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorPanel.ascx.cs" Inherits="InVentSoft.UI.ErrorPanel" %>

<asp:Panel ID="pErrores" CssClass="alert alert-danger" runat="server" Visible="false">
    <asp:Repeater ID="rpErrores" runat="server">
    <ItemTemplate>
        <li><%# Container.DataItem %></li>
    </ItemTemplate>
    </asp:Repeater>
</asp:Panel>