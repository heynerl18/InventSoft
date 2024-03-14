using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InVentSoft.BLL;
using InVentSoft.DAL.Dto;

namespace InVentSoft.UI
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            rpProductos.DataSource = ObtenerProductos();
            rpProductos.DataBind();
        }

        private List<ProductoDTO> ObtenerProductos()
        {
            return BLL.ProductoService.ObtenerProductos();
        }
    }
}