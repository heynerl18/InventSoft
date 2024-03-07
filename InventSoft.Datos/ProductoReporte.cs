using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSoft.Datos
{
    /*Modelo de pivote para realizar los reportes de productos correspondientes*/
    public class ProductoReporte
    {
        public string CategoriaNombre { get; set; }
        public string GrupoAlimentos { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public string UnidadVenta { get; set; }
        public decimal PrecioSinIva { get; set; }
        public decimal Iva { get; set; }
    }
}
