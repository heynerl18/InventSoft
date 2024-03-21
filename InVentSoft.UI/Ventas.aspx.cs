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
            ddlproductos.DataSource = ObtenerProductos();
            ddlproductos.DataTextField = "nombre";
            ddlproductos.DataValueField = "id";
            ddlproductos.DataBind();
            ddlproductos.Items.Insert(0, new ListItem("Seleccione Producto", "0"));
        }

        private List<ProductoDTO> ObtenerProductos()
        {
            return BLL.ProductoService.ObtenerProductos();
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {


            panelReporte.Visible = true;

            fecha.InnerText = getFechaEmision();
            hora.InnerText = getHoraEmision();

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