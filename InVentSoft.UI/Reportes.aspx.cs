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
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            panelTabla.Visible = false;
        }

        private void CargarCategorias()
        {
            if (!IsPostBack)
            {
                lbcategorias.DataSource = ObtenerCategorias();
                lbcategorias.DataTextField = "nombre";
                lbcategorias.DataValueField = "id";
                lbcategorias.DataBind();
            }
        }

        private List<CategoriaDTO> ObtenerCategorias()
        {
            return BLL.CategoriaService.ObtenerCategorias();
        }

        protected void reportecategoria_Click(object sender, EventArgs e)
        {

            List<int> idscategoriasSeleccionados = new List<int>();

            foreach (ListItem item in lbcategorias.Items)
            {
                if (item.Selected)
                {
                    idscategoriasSeleccionados.Add(int.Parse(item.Value));
                }

            }

            /* Cargar reporte quemado */
            panelTabla.Visible = true;
            List<Dictionary<string, string>> elementos = ReportesQuemados();
            rpReportes.DataSource = elementos;
            rpReportes.DataBind();
        }

        protected void BtnReportePorcentajaIva_Click(object sender, EventArgs e)
        {
            panelTabla.Visible = true;
            /* Cargar reporte quemado */
            List<Dictionary<string, string>> elementos = ReportesQuemados();
            rpReportes.DataSource = elementos;
            rpReportes.DataBind();
        }

        protected List<Dictionary<string, string>> ReportesQuemados()
        {
            List<Dictionary<string, string>> elementos = new List<Dictionary<string, string>>();

            // Agregar elementos a la lista
            Dictionary<string, string> elemento1 = new Dictionary<string, string>();
            elemento1.Add("GrupoAlimento", "Verduras y Frutas");
            elemento1.Add("Categoría", "Frutas");
            elemento1.Add("IvaCategoría", "0.12");
            elemento1.Add("Producto", "Manzanas");
            elemento1.Add("Stock", "100");
            elemento1.Add("UnidadVenta", "Unidades");
            elemento1.Add("PrecioSinIva", "₡10");
            elemento1.Add("IvaProducto", "0.05");
            elementos.Add(elemento1);

            Dictionary<string, string> elemento2 = new Dictionary<string, string>();
            elemento2.Add("GrupoAlimento", "Verduras y Frutas");
            elemento2.Add("Categoría", "Verduras");
            elemento2.Add("IvaCategoría", "0.1");
            elemento2.Add("Producto", "Zanahorias");
            elemento2.Add("Stock", "50");
            elemento2.Add("UnidadVenta", "Unidades");
            elemento2.Add("PrecioSinIva", "₡5");
            elemento2.Add("IvaProducto", "0.02");
            elementos.Add(elemento2);

            return elementos;
        }
    }

}