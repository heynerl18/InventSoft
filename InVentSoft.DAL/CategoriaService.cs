using InVentSoft.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVentSoft.DAL
{
    public class CategoriaService
    {
        public static List<CategoriaDTO> ObtenerCategorias()
        {
            List<CategoriaDTO> CategoriasDTOs = new List<CategoriaDTO>();

            List<categoria> categorias = new List<categoria>();

            using(inventEntities db = new inventEntities())
            {
                categorias = db.categoria.ToList();
                if (categorias != null)
                {
                    foreach(categoria cat in categorias)
                    {
                        CategoriasDTOs.Add(new CategoriaDTO(cat));
                    }
                }
            }

            return CategoriasDTOs;

        }

        public static categoria ConsultarCategoria(long id)
        {
            using (inventEntities db = new inventEntities())
            {
                return db.categoria.Find(id);
            }
        }

        public static bool AgregarCategoria(categoria cat)
        {
            bool resultado = false;
            try
            {
                using (inventEntities db = new inventEntities())
                {
                    db.categoria.Add(cat);
                    db.SaveChanges();
                    resultado = true;
                }
            }
            catch(Exception ex)
            {
                return resultado;
            }

            return resultado;
        }

        public static bool ModificarCategoria(categoria cat)
        {
            try
            {
                using (inventEntities db = new inventEntities())
                {
                    var existingCat = db.categoria.Find(cat.id);
                    if (existingCat != null)
                    {
                        db.Entry(existingCat).CurrentValues.SetValues(cat);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        // Registro de un posible error
                        System.Diagnostics.Debug.WriteLine("No se encontró la categoría con el ID proporcionado.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registro de excepción
                System.Diagnostics.Debug.WriteLine($"Error al modificar la categoría: {ex.Message}");
                return false;
            }
        }

        public static bool EliminarCategoria(long id)
        {
            bool resultado = false;
            try
            {
                using (inventEntities db = new inventEntities())
                {
                   categoria cat = db.categoria.Find(id) ;
                    if(cat!= null)
                    {
                        db.categoria.Remove(cat);
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
