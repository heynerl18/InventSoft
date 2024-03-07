using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSoft.Datos
{
    /*Este modelo servirá como Pivote para hacer la lógica de venta y asi mismo reducir el stock
     hacia la bd*/
    public class ProductoVenta
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Iva { get; set; }
    }


}
