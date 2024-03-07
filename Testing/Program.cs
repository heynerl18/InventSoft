using InventSoft.Datos;
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
            using(inventEntities db = new inventEntities())
            {
                var productos = db.producto.ToList();

                foreach(var p in productos)
                {
                    Console.WriteLine(p.nombre);
                }
            }
            Console.ReadKey();
        }
    }
}
