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

        public static ProductoDTO ConsultarProducto(int id)
        {
            
            using (inventEntities db = new inventEntities())
            {
                producto p = db.producto.Find(id);

                ProductoDTO pDto = new ProductoDTO(p);

                return pDto;
            }

           
        }

        public static bool AgregarProducto(producto producto)
        {
            bool resultado = false;
            try
            {
                using (inventEntities db = new inventEntities())
                {
                    db.producto.Add(producto);
                    db.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                return resultado;
            }

            return resultado;
        }

        public static bool ModificarProducto(producto producto)
        {
            bool resultado = false;

            try
            {
                using (inventEntities db = new inventEntities())
                {
                    db.Entry(producto).CurrentValues.SetValues(producto);
                    db.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                return resultado;
            }
            return resultado;
        }

        public static bool EliminarProducto(int id)
        {
            bool resultado = false;
            try
            {
                using (inventEntities db = new inventEntities())
                {
                    producto p = db.producto.Find(id);
                    if (p != null)
                    {
                        db.producto.Remove(p);
                        db.SaveChanges();
                        resultado = true;
                    }
                    db.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                return resultado;
            }

            return resultado;
        }
    }
}
