using InVentSoft.DAL;
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

        public static ProductoDTO ConsultarProducto(int id)
        {
            return InVentSoft.DAL.ProductoService.ConsultarProducto(id);
        }

        public static bool AgregarProducto(producto producto)
        {
            return InVentSoft.DAL.ProductoService.AgregarProducto(producto);
        }

        public static bool ModificarProducto(producto producto)
        {
            return InVentSoft.DAL.ProductoService.ModificarProducto(producto);
        }

        public static bool EliminarProducto(int id)
        {
            return InVentSoft.DAL.ProductoService.EliminarProducto(id);
        }
    }
}
