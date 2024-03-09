using InVentSoft.DAL;
using InVentSoft.DAL.Dto;
using System.Collections.Generic;

namespace InVentSoft.BLL
{
    public class CategoriaService
    {
        public static List<CategoriaDTO> ObtenerCategorias()
        {
            List<InVentSoft.DAL.Dto.CategoriaDTO> Categorias = InVentSoft.DAL.CategoriaService.ObtenerCategorias();

            return Categorias;

        }

        public static bool AgregarCategoria(categoria cat)
        {
            return InVentSoft.DAL.CategoriaService.AgregarCategoria(cat);
        }

        public static bool ModificarCategoria(categoria cat)
        {
            return InVentSoft.DAL.CategoriaService.ModificarCategoria(cat);
        }

        public static bool EliminarCategoria(long id)
        {
            return InVentSoft.DAL.CategoriaService.EliminarCategoria(id);
        }
    }
}
