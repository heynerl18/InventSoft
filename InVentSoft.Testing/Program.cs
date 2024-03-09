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

            categoria nuevaCategoria = new categoria
            {
                nombre = "Nueva Categoria",
                iva = 0.16m, // ejemplo de valor de IVA
                grupoAlimentos = "Grupo de Alimentos"
            };
            bool categoriaAgregada = InVentSoft.BLL.CategoriaService.AgregarCategoria(nuevaCategoria);
            Console.WriteLine("¿La categoría se agregó correctamente? " + categoriaAgregada);

            Console.ReadKey();
            List<CategoriaDTO> categorias = InVentSoft.BLL.CategoriaService.ObtenerCategorias();
           
            // Mostrar las categorías obtenidas
            Console.WriteLine("Categorías:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.Id}, Nombre: {categoria.Nombre}, IVA: {categoria.Iva}, Grupo de alimentos: {categoria.GrupoAlimentos}");
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
