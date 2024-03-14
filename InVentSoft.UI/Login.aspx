<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InVentSoft.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Login</title>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" 
    integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
<style>
    body{
        background: #ebedef;
    }
</style>
</head>
<body>
  <section class="vh-100 gradient-custom">
      <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-ligth text-dark" style="border-radius: 1rem;">
              <div class="card-body p-5 text-center">

                <div class="mb-md-5 mt-md-4 pb-5">

                  <h2 class="fw-bold mb-4 text-uppercase">Login</h2>
                  
                    <asp:Panel ID="pErrores" CssClass="alert alert-danger" runat="server" Visible="false">
                     <asp:Repeater ID="rpErrores" runat="server">
                        <ItemTemplate>
                           <li><%# Container.DataItem %></li>
                        </ItemTemplate>
                     </asp:Repeater>
                   </asp:Panel>

                   <asp:Panel ID="panelAlertaError" CssClass="alert alert-danger lert-dismissible fade show" role="alert" runat="server" Visible="false">
                      <asp:Label ID="labelError" Text="" runat="server" />
                      <button type="button" class="btn-close" data-bs-dismiss="alert" onclick="cerrarAlertaError()" aria-label="Close">
                      </button>
                  </asp:Panel>
                   <form id="loginform" runat="server">
                                            
                      <div class="mb-4">
                          <asp:TextBox ID="usuario" runat="server" CssClass="form-control form-control-lg" placeholder="Ingrese su usuario" />
                      </div>

                      <div class="mb-4">
                          <asp:TextBox runat="server" ID="contrasenia" Type="Password" CssClass="form-control form-control-lg" placeholder="Ingrese su contraseña" />
                      </div>
                       <asp:Button ID="BtnLogin" Text="Ingresar" CssClass="btn btn-outline-primary btn-lg px-5" runat="server" OnClick="BtnLogin_Click" />
                   </form>
                </div>
              </div>
            </div>
          </div>
        </div> 
      </div>
   </section>
<script type="text/javascript">
  function cerrarAlertaError() {
    document.getElementById('<%= panelAlertaError.ClientID %>').style.display = 'none';
  }
</script>
</body>
</html>
