using System;
using System.Collections.Generic;
using System.Linq;

namespace InventSoft.Datos
{
    public class ProductoData
    {
        public void InsertarProducto(producto nuevoProducto)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    context.producto.Add(nuevoProducto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el producto: " + ex.Message);
                throw; // Lanzar la excepción para que el controlador pueda manejarla
            }
        }

        public void ActualizarProducto(producto productoActualizado)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    var productoExistente = context.producto.Find(productoActualizado.id);
                    if (productoExistente != null)
                    {
                        context.Entry(productoExistente).CurrentValues.SetValues(productoActualizado);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Producto no encontrado para actualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el producto: " + ex.Message);
                throw; // Lanzar la excepción para que el controlador pueda manejarla
            }
        }

        public void EliminarProducto(int idProducto)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    var productoEliminar = context.producto.Find(idProducto);
                    if (productoEliminar != null)
                    {
                        context.producto.Remove(productoEliminar);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Producto no encontrado para eliminar.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto: " + ex.Message);
                throw; // Lanzar la excepción para que el controlador pueda manejarla
            }
        }

        public List<producto> obtenerProductosConCategoria()
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Consultar todos los productos con sus categorías relacionadas
                    return context.producto.Include("categoria").ToList();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí si ocurre un error al consultar los productos
                Console.WriteLine("Error al obtener los productos: " + ex.Message);
                return null; // Devolver null si ocurrió un error al consultar
            }
        }

        public List<producto> obtenerProductosPorCategorias(List<int> idsCategorias)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Consultar los productos que pertenecen a alguna de las categorías especificadas
                    return context.producto
                        .Where(p => idsCategorias.Contains(p.categoriaid ?? 0))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí si ocurre un error al consultar los productos
                Console.WriteLine("Error al obtener los productos: " + ex.Message);
                return null; // Devolver null si ocurrió un error al consultar
            }
        }

        public List<producto> obtenerProductosConIva(decimal? porcentajeIva = null)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Consultar los productos que tienen un valor de IVA especificado
                    var productosConIva = context.producto
                        .Where(p => p.Iva.HasValue && (!porcentajeIva.HasValue || p.Iva <= porcentajeIva))
                        .ToList();

                    // Consultar los productos que no tienen un valor de IVA especificado
                    // y obtener el IVA de la categoría asociada
                    var productosSinIva = context.producto
                        .Where(p => !p.Iva.HasValue)
                        .ToList()
                        .Select(p =>
                        {
                            p.Iva = context.categoria.FirstOrDefault(c => c.id == p.categoriaid)?.iva;
                            return p;
                        })
                        .Where(p => p.Iva.HasValue && (!porcentajeIva.HasValue || p.Iva <= porcentajeIva)) // Filtrar productos que obtuvieron un IVA válido de la categoría
                        .ToList();

                    // Combinar ambos conjuntos de productos
                    productosConIva.AddRange(productosSinIva);

                    return productosConIva;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los productos: " + ex.Message);
                return null; // Devolver null si ocurrió un error al consultar
            }
        }

        public categoria obtenerCategoriaPorId(int categoriaId)
        {
            using (inventEntities context = new inventEntities())
            {
                return context.categoria.FirstOrDefault(c => c.id == categoriaId);
            }
        }


        public bool ReducirStock(List<ProductoVenta> productosVendidos)
        {
            bool response = false;
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    foreach (var productoVenta in productosVendidos)
                    {
                        // Obtener el producto correspondiente desde la base de datos
                        var producto = context.producto.FirstOrDefault(p => p.id == productoVenta.ProductoId);

                        if (producto != null)
                        {
                            // Reducir el stock del producto
                            producto.stock -= productoVenta.Cantidad;
                        }
                    }

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                    response = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre un error al reducir el stock
                Console.WriteLine("Error al reducir el stock de los productos: " + ex.Message);
                return response;
            }

            return response;
        }

        public List<ProductoReporte> ObtenerProductosReporteInventario(List<int> idsCategorias, decimal porcentajeIva)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Consultar los productos según los filtros especificados
                    var productosReporte = (from p in context.producto
                                            join c in context.categoria on p.categoriaid equals c.id
                                            where idsCategorias.Contains(p.categoriaid ?? 0) &&
                                                  (c.iva <= porcentajeIva || p.Iva <= porcentajeIva || p.Iva == null)
                                            select new ProductoReporte
                                            {
                                                CategoriaNombre = c.nombre,
                                                GrupoAlimentos = c.grupoAlimentos,
                                                Nombre = p.nombre,
                                                Stock = (int)p.stock,
                                                UnidadVenta = p.unidadVenta,
                                                PrecioSinIva = (decimal)p.precioSinIva
                                                Iva = p.Iva ?? 0 // Si el IVA es nulo, asignar 0
                                            }).ToList();

                    return productosReporte;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre un error al obtener los productos para el reporte
                Console.WriteLine("Error al obtener los productos para el reporte de inventario: " + ex.Message);
                return null;
            }
        }
    }
}
}
