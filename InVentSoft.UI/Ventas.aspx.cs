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
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();

            panelReporte.Visible = false;
        }

        private void CargarProductos()
        {
            if (!IsPostBack)
            {
                ddlproductos.DataSource = ObtenerProductos();
                ddlproductos.DataTextField = "nombre";
                ddlproductos.DataValueField = "id";
                ddlproductos.DataBind();
                ddlproductos.Items.Insert(0, new ListItem("Seleccione Producto", "0"));
            }
        }

        private List<ProductoDTO> ObtenerProductos()
        {
            return BLL.ProductoService.ObtenerProductosConStock();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(ddlproductos.SelectedValue);
            int cantidadProductos = int.Parse(cantidadproductos.Text);
            
            ProductoDTO aux = BLL.ProductoService.ConsultarProducto(idProducto);
            

            if (aux != null && cantidadProductos <= aux.Stock)
            {

                if(aux.Iva == null)
                {
                    aux.Iva = aux.cat.iva;
                }

                producto modificar = new producto
                {
                    id = aux.Id,
                    nombre = aux.Nombre,
                    categoriaid = aux.cat.id,
                    precioSinIva = aux.PrecioSinIva,
                    Iva = aux.Iva,
                    unidadVenta = aux.UnidadVenta,
                    stock = aux.Stock
                };
                modificar.stock -= cantidadProductos;
                DAL.ProductoService.ModificarProducto(modificar);
                modificar = null;
                calcularVentaProductos(idProducto, cantidadProductos);

            }
            else
            {
                Response.Write("<script>alert('La cantidad de productos a vender es mayor que el stock disponible.');</script>");
            }
        
            
            /* Limpiar campos */
            ddlproductos.SelectedIndex = 0;
            cantidadproductos.Text = "";
            aux = null;
           
        }

        private void calcularVentaProductos(int idProducto, int cantidadProductos)
        {
            decimal sumaSubTotal = 0;
            decimal sumaIva = 0;

            foreach(ProductoDTO producto in ObtenerProductos())
            {
                if(idProducto == producto.Id)
                {
                    sumaSubTotal += producto.PrecioSinIva.Value * cantidadProductos;
                    sumaIva += producto.Iva.Value * cantidadProductos;
                }
            }

            /* ---------------------------------------------------------------------------------------------- */

            subtotal.InnerText = sumaSubTotal.ToString("C", new System.Globalization.CultureInfo("es-CR"));
            iva.InnerText = sumaIva.ToString("C", new System.Globalization.CultureInfo("es-CR"));

            decimal sumaTotal = sumaSubTotal + sumaIva;
            total.InnerText = sumaTotal.ToString("C", new System.Globalization.CultureInfo("es-CR"));
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {
            panelReporte.Visible = true;

             //----------------
            // Tocar el stock
           // ---------------


            fecha.InnerText = getFechaEmision();
            hora.InnerText = getHoraEmision();

            reporteSubTotal.InnerText = subtotal.InnerText;
            reporteIva.InnerText = iva.InnerText;
            reporteTotal.InnerText = total.InnerText;
        }

        private string getFechaEmision()
        {
            DateTime fechaEmision = DateTime.Today;
            return fechaEmision.ToString("yyyy-MM-dd");
        }

        private string getHoraEmision()
        {
            DateTime horaEmision = DateTime.Now;
            return horaEmision.ToString("HH:mm:ss");
        }

    }
}