using InVentSoft.DAL;
using InVentSoft.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVentSoft.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            categoria nuevaCategoria = new categoria
            {
                nombre = "Nueva Categoria",
                iva = 0.16m, // ejemplo de valor de IVA
                grupoAlimentos = "Grupo de Alimentos"
            };
            bool categoriaAgregada = InVentSoft.BLL.CategoriaService.AgregarCategoria(nuevaCategoria);
            Console.WriteLine("¿La categoría se agregó correctamente? " + categoriaAgregada);

            Console.ReadKey();*/
            List<CategoriaDTO> categorias = InVentSoft.BLL.CategoriaService.ObtenerCategorias();
           
            // Mostrar las categorías obtenidas
            Console.WriteLine("Categorías:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.Id}, Nombre: {categoria.Nombre}, IVA: {categoria.Iva}, Grupo de alimentos: {categoria.GrupoAlimentos}");
            }

            Console.ReadKey();

            producto nuevoProducto = new producto
            {
                nombre = "Nuevo Producto",
                categoriaid = 1, // ID de la categoría asociada
                precioSinIva = 10.5m,
                Iva = 0.16m,
                unidadVenta = "unidad",
                stock = 100
            };

            InVentSoft.BLL.ProductoService.AgregarProducto(nuevoProducto);

            ProductoDTO productoConsultado = InVentSoft.BLL.ProductoService.ConsultarProducto(8); // Obtener un producto existente para modificarlo
            producto productoModificar = new producto
            {
                nombre = productoConsultado.Nombre,
                categoriaid = productoConsultado.cat.id, // ID de la categoría asociada
                precioSinIva = productoConsultado.PrecioSinIva,
                Iva = productoConsultado.Iva,
                unidadVenta = productoConsultado.UnidadVenta,
                stock = productoConsultado.Stock
            };

            if (productoModificar != null)
            {
                productoModificar.nombre = "Producto Modificado";
                productoModificar.stock = 150;
                InVentSoft.BLL.ProductoService.ModificarProducto(productoModificar);
            }

            

            List<ProductoDTO> productos = InVentSoft.BLL.ProductoService.ObtenerProductos();
            // Mostrar los productos obtenidos
            Console.WriteLine("Productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Categoría: {producto.cat.nombre}, Precio sin IVA: {producto.PrecioSinIva}, IVA: {producto.Iva}, Unidad de venta: {producto.UnidadVenta}, Stock: {producto.Stock}");
            }

            Console.ReadKey();

            InVentSoft.BLL.ProductoService.EliminarProducto(8);

            List<ProductoDTO> productos2 = InVentSoft.BLL.ProductoService.ObtenerProductos();
            // Mostrar los productos obtenidos
            Console.WriteLine("Productos:");
            foreach (var producto in productos2)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Categoría: {producto.cat.nombre}, Precio sin IVA: {producto.PrecioSinIva}, IVA: {producto.Iva}, Unidad de venta: {producto.UnidadVenta}, Stock: {producto.Stock}");
            }

            Console.ReadKey();
            /*using(inventEntities db = new inventEntities() ){
                var categorias = db.categoria.ToList();

                foreach(var cat in categorias)
                {
                    Console.WriteLine(cat.nombre);
                }

                Console.ReadLine();
            }*/
        }
    }
}
