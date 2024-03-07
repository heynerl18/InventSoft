using InventSoft.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSoft.Negocio
{
    public class CategoriaBL
    {
        private CategoriaData categoriaData;

        public CategoriaBL()
        {
            categoriaData = new CategoriaData();
        }

        public bool guardarCategoria(categoria modelo)
        {         
            return categoriaData.guardarCategoria(modelo);
        }

        public bool actualizarCategoria(categoria modelo)
        {         
            return categoriaData.actualizarCategoria(modelo);
        }

        public bool eliminarCategoria(int id)
        {         
            return categoriaData.eliminarCategoria(id);
        }

        public List<categoria> consultarCategorias()
        {           
            return categoriaData.consultarCategorias();
        }
    }
}
