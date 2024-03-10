using InVentSoft.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVentSoft.DAL
{
    public class ProductoService
    {
        public static List<ProductoDTO> ObtenerProductos()
        {
            List<ProductoDTO> ProductoDTOs = new List<ProductoDTO>();
            List<producto> productos = new List<producto>();

            using (inventEntities db = new inventEntities())
            {
                productos = db.producto.Include("categoria").ToList();
                if(productos != null)
                {
                    foreach(producto p in productos)
                    {
                        ProductoDTOs.Add(new ProductoDTO(p));
                    }
                }
            }

            return ProductoDTOs;
        }
    }
}
