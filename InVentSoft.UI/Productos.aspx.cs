using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InVentSoft.BLL;
using InVentSoft.DAL;
using InVentSoft.DAL.Dto;

namespace InVentSoft.UI
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarCategorias();
        }

        private void CargarProductos()
        {
            rpProductos.DataSource = ObtenerProductos();
            rpProductos.DataBind();
        }

        private void CargarCategorias()
        {
            if (!IsPostBack)
            {
                cargarDropDownList();
            }
        }

        private void cargarDropDownList()
        {
            /* Agregar DropDownList */
            ddlcategoria.DataSource = ObtenerCategorias();
            ddlcategoria.DataTextField = "nombre";
            ddlcategoria.DataValueField = "id";
            ddlcategoria.DataBind();
            ddlcategoria.Items.Insert(0, new ListItem("Seleccione Categoría", "0"));

            /* Editar DropDownList */
            ddlistacategoria.DataSource = ObtenerCategorias();
            ddlistacategoria.DataTextField = "nombre";
            ddlistacategoria.DataValueField = "id";
            ddlistacategoria.DataBind();
            ddlistacategoria.Items.Insert(0, new ListItem("Seleccione Categoría", "0"));
        }

        private List<ProductoDTO> ObtenerProductos()
        {
            return BLL.ProductoService.ObtenerProductos();
        }

        private List<CategoriaDTO> ObtenerCategorias()
        {
            return BLL.CategoriaService.ObtenerCategorias();
        }

        protected void Btneliminar_Click(object sender, EventArgs e)
        {
            string idProducto = idproductoeliminar.Value;
            bool resultadoElimanado = BLL.ProductoService.EliminarProducto(int.Parse(idProducto));

            if (resultadoElimanado)
            {
                pnlAlertaExitoso.Visible = true;
                labelsuccess.Text = "Producto eliminado exitosamente!";
                CargarProductos();
            } else
            {
                pnlAlertaExitoso.Visible = false;
                panelAlertaError.Visible = true;
                labelError.Text = "Error al eliminar el producto!";
            }
        }

        protected void Crearbtn_Click(object sender, EventArgs e)
        {
            string script = "$('#formModal').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void Btnguadar_Click(object sender, EventArgs e)
        {
            List<string> errores = ValidarDatos(nombre.Text, ddlcategoria.SelectedValue, preciosiniva.Text, iva.Text, unidadventa.SelectedItem.ToString(), stock.Text);
            if(errores.Count > 0)
            {
                rpErrores.DataSource = errores;
                rpErrores.DataBind();
                pErrores.Visible = true;

                string script = "$('#formModal').modal('show')";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
            } else
            {
                producto producto = new producto
                {
                    nombre = nombre.Text,
                    categoriaid = int.Parse(ddlcategoria.SelectedValue),
                    precioSinIva = decimal.Parse(preciosiniva.Text),
                    Iva = decimal.Parse(iva.Text),
                    unidadVenta = unidadventa.SelectedItem.ToString(),
                    stock = int.Parse(stock.Text)
                };

                bool resultadoDeAgregado = BLL.ProductoService.AgregarProducto(producto);
                if (resultadoDeAgregado)
                {
                    pnlAlertaExitoso.Visible = true;
                    labelsuccess.Text = "Producto agregado exitosamente!";
                    CargarProductos();
                }
                else
                {
                    pnlAlertaExitoso.Visible = false;
                    panelAlertaError.Visible = true;
                    labelError.Text = "Error al registrar el producto!";
                }
            }
        }


        protected void Btneditar_Click(object sender, EventArgs e)
        {
            List<string> errores = ValidarDatos(txtnombre.Text,ddlistacategoria.SelectedValue, txtpreciosiniva.Text, txtiva.Text, ddlistaunidadventa.SelectedItem.ToString(), txtstock.Text);
            if(errores.Count > 0)
            {
                rpErroresEdit.DataSource = errores;
                rpErroresEdit.DataBind();
                pErroresEdit.Visible = true;

                string script = "$('#editModal').modal('show')";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
            } else
            {
                producto editproducto = new producto
                {
                    id = int.Parse(idproductoeditar.Value),
                    nombre = txtnombre.Text,
                    categoriaid = int.Parse(ddlistacategoria.SelectedValue),
                    precioSinIva = decimal.Parse(txtpreciosiniva.Text),
                    Iva = decimal.Parse(txtiva.Text),
                    unidadVenta = ddlistaunidadventa.SelectedItem.ToString(),
                    stock = int.Parse(txtstock.Text)
                };

                bool resultadoDeEditado = BLL.ProductoService.ModificarProducto(editproducto);

                if (resultadoDeEditado)
                {
                    pnlAlertaExitoso.Visible = true;
                    labelsuccess.Text = "Producto editado exitosamente!";
                    CargarProductos();
                } else
                {
                    pnlAlertaExitoso.Visible = false;
                    panelAlertaError.Visible = true;
                    labelError.Text = "Error al editar el producto!";
                }
            }
        }

        /* Validacion del form */
        protected List<string> ValidarDatos(string nombre, string idCategoria, string precioSinIva, string iva, string unidadVenta, string stock)
        {
            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(nombre))
            {
                errores.Add("El nombre es requerido.");
            }

            if (string.IsNullOrEmpty(idCategoria) || idCategoria == "0")
            {
                errores.Add("La categoría es requerido.");
            }

            if (string.IsNullOrEmpty(precioSinIva))
            {
                errores.Add("El precio sin iva es requerido.");
            }

            if (string.IsNullOrEmpty(iva))
            {
                errores.Add("El iva es requerido.");
            }

            if (string.IsNullOrEmpty(unidadVenta) || unidadVenta == "Seleccione la unidad de venta")
            {
                errores.Add("La unidad de venta es requerido.");
            }

            if (string.IsNullOrEmpty(stock))
            {
                errores.Add("El stock es requerido.");
            }
            return errores;
        }
    }
}