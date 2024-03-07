using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSoft.Datos
{
    public class CategoriaData
    {
        public bool guardarCategoria(categoria modelo)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    context.categoria.Add(modelo);
                    context.SaveChanges();
                    return true; // Devolver true si se guardó exitosamente
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al guardar la categoría: " + ex.Message);
                return false; // Devolver false si ocurrió un error al guardar
            }
        }

        public bool actualizarCategoria(categoria modelo)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Buscar la categoría existente en la base de datos
                    var categoriaExistente = context.categoria.Find(modelo.id);

                    if (categoriaExistente != null)
                    {
                        // Actualizar los datos de la categoría existente con los nuevos datos
                        context.Entry(categoriaExistente).CurrentValues.SetValues(modelo);
                        context.SaveChanges();
                        return true; // Devolver true si se actualizó exitosamente
                    }
                    else
                    {
                        Console.WriteLine("No se encontró la categoría para actualizar.");
                        return false; // Devolver false si no se encontró la categoría
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí si ocurre un error al actualizar
                Console.WriteLine("Error al actualizar la categoría: " + ex.Message);
                return false; // Devolver false si ocurrió un error al actualizar
            }
        }

        public bool eliminarCategoria(int id)
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Buscar la categoría a eliminar
                    var categoriaEliminar = context.categoria.Find(id);

                    if (categoriaEliminar != null)
                    {
                        // Eliminar la categoría de la base de datos
                        context.categoria.Remove(categoriaEliminar);
                        context.SaveChanges();
                        return true; // Devolver true si se eliminó exitosamente
                    }
                    else
                    {
                        Console.WriteLine("No se encontró la categoría para eliminar.");
                        return false; // Devolver false si no se encontró la categoría
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí si ocurre un error al eliminar
                Console.WriteLine("Error al eliminar la categoría: " + ex.Message);
                return false; // Devolver false si ocurrió un error al eliminar
            }
        }

        public List<categoria> consultarCategorias()
        {
            try
            {
                using (inventEntities context = new inventEntities())
                {
                    // Consultar todas las categorías en la base de datos
                    return context.categoria.ToList();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí si ocurre un error al consultar
                Console.WriteLine("Error al consultar las categorías: " + ex.Message);
                return null; // Devolver null si ocurrió un error al consultar
            }
        }
    }
}
