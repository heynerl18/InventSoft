using InVentSoft.DAL.Dto;
using System.Collections.Generic;

namespace InVentSoft.BLL
{
    public class ProductoService
    {
        public static List<ProductoDTO> ObtenerProductos()
        {
            List<ProductoDTO> productos = InVentSoft.DAL.ProductoService.ObtenerProductos();

            return productos;
        }
    }
}
