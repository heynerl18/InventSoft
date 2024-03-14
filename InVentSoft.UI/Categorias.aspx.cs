using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InVentSoft.DAL;
using InVentSoft.DAL.Dto;
using InVentSoft.BLL;
using System.Configuration;

namespace InVentSoft.UI
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            rpCategorias.DataSource = ObtenerCategorias();
            rpCategorias.DataBind();
        }

        private List<CategoriaDTO> ObtenerCategorias()
        {
            return BLL.CategoriaService.ObtenerCategorias();
        }

        protected void Crearbtn_Click(object sender, EventArgs e)
        {
            string script = "$('#formModal').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void Btnguadar_Click(object sender, EventArgs e)
        {
            List<string> errores = validarDatos(nombre.Text, iva.Text, grupoalimentos.SelectedItem.ToString());
            if(errores.Count > 0)
            {
                rpErrores.DataSource = errores;
                rpErrores.DataBind();
                pErrores.Visible = true;

                string script = "$('#formModal').modal('show')";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
                
            } else
            {
                pErrores.Visible = false;

                categoria nuevaCategoria = new categoria
                {
                    nombre = nombre.Text,
                    iva = Convert.ToDecimal(iva.Text),
                    grupoAlimentos = grupoalimentos.SelectedItem.ToString()
                };

                bool resultadoDeAgregado = BLL.CategoriaService.AgregarCategoria(nuevaCategoria);
                if (resultadoDeAgregado)
                {
                    pnlAlertaExitoso.Visible = true;
                    labelsuccess.Text = "Categoria agregado exitosamente!";
                    CargarCategorias();
                }
                else
                {
                    pnlAlertaExitoso.Visible = false;
                    panelAlertaError.Visible = true;
                    labelError.Text = "Error al registrar categoria";
                    CargarCategorias();
                }
            }
        }

        protected void Btneditar_Click(object sender, EventArgs e)
        {
            List<string> errores = validarDatos(txtnombre.Text, txtiva.Text, listgrupoalimentos.SelectedItem.ToString());
            if(errores.Count > 0)
            {
                rpErroresEdit.DataSource = errores;
                rpErroresEdit.DataBind();
                pErrorEdit.Visible = true;

                string script = "$('#editModal').modal('show')";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
            } else
            {
                pErrorEdit.Visible = false;

                categoria editCategoria = new categoria
                {
                    id = int.Parse(idcategoriaeditar.Value),
                    nombre = txtnombre.Text,
                    iva = Convert.ToDecimal(txtiva.Text),
                    grupoAlimentos = listgrupoalimentos.SelectedItem.ToString()
                };
                bool resultadoDeEditado = BLL.CategoriaService.ModificarCategoria(editCategoria);
                if (resultadoDeEditado)
                {
                    pnlAlertaExitoso.Visible = true;
                    labelsuccess.Text = "Categoria editado exitosamente!";
                    CargarCategorias();
                }
                else
                {
                    pnlAlertaExitoso.Visible = false;
                    panelAlertaError.Visible = true;
                    labelError.Text = "Error al editar categoria";
                }
            }
        }

        protected void Btneliminar_Click(object sender, EventArgs e)
        {
            string idCategoria = idcategoriaeliminar.Value;
            bool resultadoDeEliminado = BLL.CategoriaService.EliminarCategoria(int.Parse(idCategoria));
            if (resultadoDeEliminado)
            {
                pnlAlertaExitoso.Visible = true;
                labelsuccess.Text = "Categoria eliminado exitosamente!";
                CargarCategorias();
            }
            else
            {
                pnlAlertaExitoso.Visible = false;
                panelAlertaError.Visible = true;
                labelError.Text = "Error al eliminar categoria";
            }
        }

        protected List<string> validarDatos(string nombre, string iva, string grupoAlimentosItem)
        {

            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(nombre))
            {
                errores.Add("El nombre es requerido.");
            }

            if (string.IsNullOrEmpty(iva))
            {
                errores.Add("El iva es requerido.");
            }

            if (string.IsNullOrEmpty(grupoAlimentosItem) || grupoAlimentosItem == "Seleccione el grupo de alimento")
            {
                errores.Add("El grupo de alimento es requerido.");
            }
            return errores;
        }

    }
}