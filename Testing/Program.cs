using InventSoft.Datos;
using InventSoft.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductoBL productoBL = new ProductoBL();
            decimal porcentajeIva = 0.10m;
            var productosConIva = productoBL.obtenerProductosConIva(porcentajeIva);

            if (productosConIva != null)
            {
                Console.WriteLine($"Productos con un {porcentajeIva * 100}% de IVA:");
                foreach (var producto in productosConIva)
                {
                    Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, IVA: {producto.Iva * 100}%");
                }
            }
            else
            {
                Console.WriteLine("Error al consultar productos por IVA.");
            }

            Console.ReadKey();
            /*CategoriaBL categoriaBL = new CategoriaBL();
            // Consultar todas las categorías y mostrarlas en la consola
            var categorias = categoriaBL.consultarCategorias();

            if (categorias != null)
            {
                foreach (var c in categorias)
                {
                    Console.WriteLine(c.nombre);
                }
            }
            else
            {
                Console.WriteLine("Error al consultar las categorías.");
            }

            Console.ReadKey();

            // Crear una instancia de ProductoBL
            ProductoBL productoBL = new ProductoBL();

            // Obtener todos los productos con sus categorías y mostrarlos en la consola
            var productos = productoBL.obtenerProductosConCategoria();

            if (productos != null)
            {
                Console.WriteLine("\nProductos:");
                foreach (var p in productos)
                {
                    Console.WriteLine($"Nombre: {p.nombre}, Categoría: {(p.categoria != null ? p.categoria.nombre : "Sin categoría")}");
                }
            }
            else
            {
                Console.WriteLine("Error al obtener los productos.");
            }

            Console.ReadKey();*/
            /*
            using(inventEntities db = new inventEntities())
            {
                var productos = db.producto.ToList();

                foreach(var p in productos)
                {
                    Console.WriteLine(p.nombre);
                }
            }
            Console.ReadKey();*/

            // Definir una lista de IDs de categorías para filtrar productos
            /*List<int> idsCategorias = new List<int> { 1, 2, 3 }; // Ejemplo: IDs de categorías seleccionadas

            // Obtener los productos filtrados por las categorías especificadas
            var productosFiltrados = productoBL.obtenerProductosPorCategorias(idsCategorias);

            // Mostrar los productos filtrados en la consola
            if (productosFiltrados != null)
            {
                Console.WriteLine("Productos filtrados:");
                foreach (var producto in productosFiltrados)
                {
                    Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Categoría ID: {producto.categoriaid}");
                }
            }
            else
            {
                Console.WriteLine("Error al obtener los productos filtrados.");
            }

            Console.ReadKey();*/
        }
    }
}
