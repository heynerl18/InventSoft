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
        public static List<ProductoDTO> ObtenerProductosConStock()
        {
            List<ProductoDTO> ProductoDTOs = new List<ProductoDTO>();

            using (inventEntities db = new inventEntities())
            {
                // Obtener los productos con stock mayor que cero
                List<producto> productos = db.producto.Include("categoria").Where(p => p.stock > 0).ToList();

                // Mapear los productos a objetos ProductoDTO
                foreach (producto p in productos)
                {
                    ProductoDTOs.Add(new ProductoDTO(p));
                }
            }

            return ProductoDTOs;
        }

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
            try
            {
                using (inventEntities db = new inventEntities())
                {
                    var existingProduct = db.producto.Find(producto.id);
                    if (existingProduct != null)
                    {
                        db.Entry(existingProduct).CurrentValues.SetValues(producto);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        // Registro de un posible error
                        System.Diagnostics.Debug.WriteLine("No se encontró el producto con el ID proporcionado.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registro de excepción
                System.Diagnostics.Debug.WriteLine($"Error al modificar el producto: {ex.Message}");
                return false;
            }
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

        public static List<ProductoDTO> ObtenerProductosPorCategorias(List<int> categoriasSeleccionadas)
        {
            List<ProductoDTO> ProductoDTOs = new List<ProductoDTO>();
            List<producto> productos = new List<producto>();

            using (inventEntities db = new inventEntities())
            {
                if (categoriasSeleccionadas != null && categoriasSeleccionadas.Any())
                {
                    productos = db.producto
                        .Include("categoria")
                        .Where(p => categoriasSeleccionadas.Contains((int)p.categoriaid))
                        .ToList();
                }
                else
                {
                    productos = db.producto.Include("categoria").ToList();
                }

                if (productos != null)
                {
                    foreach (producto p in productos)
                    {
                        ProductoDTOs.Add(new ProductoDTO(p));
                    }
                }
            }

            return ProductoDTOs;
        }

        public static List<ProductoDTO> ObtenerProductosPorIva(decimal? porcentajeIva = null)
        {
            List<ProductoDTO> ProductoDTOs = new List<ProductoDTO>();

            using (inventEntities db = new inventEntities())
            {
                IQueryable<producto> query = db.producto.Include("categoria");

                // Si se proporciona un porcentaje de IVA, filtrar por ese valor
                if (porcentajeIva.HasValue)
                {
                    query = query.Where(p => p.Iva <= porcentajeIva.Value);
                }
                else
                {
                    foreach (var producto in query)
                    {
                        // Si el producto no tiene un IVA asociado, verificar el porcentaje de IVA de la categoría
                        if (!producto.Iva.HasValue && producto.categoria != null && producto.categoria.iva.HasValue)
                        {
                            query = query.Where(p => p.categoria.iva <= producto.categoria.iva);
                        }
                    }
                }

                List<producto> productos = query.ToList();

                if (productos != null)
                {
                    foreach (producto p in productos)
                    {
                        ProductoDTOs.Add(new ProductoDTO(p));
                    }
                }
            }

            return ProductoDTOs;
        }
    }
}
