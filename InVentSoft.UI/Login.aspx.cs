using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InVentSoft.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            const string USUARIO = "admin";
            const string PASSWORD = "admin";

            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(usuario.Text))
            {
                errores.Add("El usuario es requerido.");
            }

            if (string.IsNullOrEmpty(contrasenia.Text))
            {
                errores.Add("La contraseña es requerido.");
            }

            if(errores.Count > 0)
            {
                rpErrores.DataSource = errores;
                rpErrores.DataBind();
                panelAlertaError.Visible = false;
                pErrores.Visible = true;
            }else
            {
                pErrores.Visible = false;

                if (USUARIO == usuario.Text && PASSWORD == contrasenia.Text)
                {
                    Response.Redirect("/Ventas");
                }
                else
                {
                    panelAlertaError.Visible = true;
                    labelError.Text = "Usuario o Contraseña incorrectos.";
                }
            }
        }
    }
}