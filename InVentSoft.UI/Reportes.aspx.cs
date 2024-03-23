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
            panelAlertaError.Visible = false;
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

            List<int> CategoriasSeleccionados = new List<int>();

            foreach (ListItem item in lbcategorias.Items)
            {
                if (item.Selected)
                {
                    CategoriasSeleccionados.Add(int.Parse(item.Value));
                }
            }

            List<ProductoDTO> ResultadoFiltradoPorCategorias = ObtenerProductosCategorias(CategoriasSeleccionados);

            if(ResultadoFiltradoPorCategorias.Count > 0)
            {
                panelTabla.Visible = true;
                rpReportes.DataSource = ResultadoFiltradoPorCategorias;
                rpReportes.DataBind();
            }else
            {
                panelTabla.Visible = false;
                panelAlertaError.Visible = true;
                labelError.Text = "¡No se encontraron resultados!";
            }
        }

        protected void BtnReportePorcentajaIva_Click(object sender, EventArgs e)
        {
            decimal porcentajeIva = int.Parse(txtreporteporcentajeiva.Text);
            List<ProductoDTO> ResultadosProductosCategoriasPorIva = ObtenerProductosCategoriasPorIva(porcentajeIva);

            if(ResultadosProductosCategoriasPorIva.Count > 0)
            {
                panelTabla.Visible = true;
                rpReportes.DataSource = ResultadosProductosCategoriasPorIva;
                rpReportes.DataBind();
            }
            else
            {
                panelTabla.Visible = false;
                panelAlertaError.Visible = true;
                labelError.Text = "!No se encontraron resultados!";
            }
        }

        private List<ProductoDTO> ObtenerProductosCategorias(List<int> categoriasSeleccionados)
        {
            return BLL.ProductoService.ObtenerProductosPorCategorias(categoriasSeleccionados);
        }

        private List<ProductoDTO> ObtenerProductosCategoriasPorIva(decimal porcentajeIva)
        {
            return BLL.ProductoService.ObtenerProductosPorIva(porcentajeIva);
        }
    }

}