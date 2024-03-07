using InventSoft.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSoft.Negocio
{
    public class ProductoBL
    {
        private ProductoData productoData;

        public ProductoBL()
        {
            productoData = new ProductoData();
        }

        public List<producto> obtenerProductosConCategoria()
        {            
            return productoData.obtenerProductosConCategoria();
        }

        public List<producto> obtenerProductosPorCategorias(List<int> idsCategorias)
        {
            return productoData.obtenerProductosPorCategorias(idsCategorias);
        }

        public void InsertarProducto(producto nuevoProducto)
        {
            productoData.InsertarProducto(nuevoProducto);
        }

        public void ActualizarProducto(producto productoActualizado)
        {
            productoData.ActualizarProducto(productoActualizado);
        }

        public void EliminarProducto(int idProducto)
        {
            productoData.EliminarProducto(idProducto);
        }

        public List<producto> obtenerProductosConIva(decimal? porcentajeIva = null)
        {
            return productoData.obtenerProductosConIva(porcentajeIva);
        }

        public bool ReducirStock(List<ProductoVenta> productosVendidos)
        {
            return productoData.ReducirStock(productosVendidos);
        }

        public void GenerarReporteVenta(DateTime fechaHora, decimal subtotal, decimal ivaTotal, decimal totalPagado)
        {
            try
            {
                //Aqui se generaria el reporte con la libreria que segun corresponda
                Console.WriteLine($"Reporte de venta generado:\nFecha y hora: {fechaHora}\nSubtotal: {subtotal}\nIVA total: {ivaTotal}\nTotal pagado: {totalPagado}");
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre un error al generar el reporte
                Console.WriteLine("Error al generar el reporte de venta: " + ex.Message);
            }
        }

        /*
        public void GenerarReporteInventario(List<int> idsCategorias, decimal porcentajeIva)
        {
            try
            {
                // Obtener los productos según los filtros especificados
                var productosReporte = productoData.ObtenerProductosReporteInventario(idsCategorias, porcentajeIva);

                // Aquí podrías implementar la lógica para generar y mostrar el reporte
                Console.WriteLine("Reporte de Inventario:");

                /*Por ahora está asi pero aqui estaría la lógica de generar el reporte ya sea HMTL, PDF, etc
                foreach (var producto in productosReporte)
                {
                    Console.WriteLine($"Categoría: {producto.CategoriaNombre}, Grupo de alimentos: {producto.GrupoAlimentos}, Nombre: {producto.Nombre}, " +
                                      $"Cantidad en stock: {producto.Stock}, Unidad de venta: {producto.UnidadVenta}, Precio sin IVA: {producto.PrecioSinIva}, " +
                                      $"IVA del producto: {producto.Iva}");
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre un error al generar el reporte
                Console.WriteLine("Error al generar el reporte de inventario: " + ex.Message);
            }
        }*/
    }
}
