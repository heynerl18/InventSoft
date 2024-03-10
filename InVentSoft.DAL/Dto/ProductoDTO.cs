namespace InVentSoft.DAL.Dto
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioSinIva { get; set; }
        public decimal? Iva { get; set; }
        public string UnidadVenta { get; set; }
        public int? Stock { get; set; }

        public categoria cat { get; set; }
        public ProductoDTO(producto producto)
        {
            this.Id = producto.id;
            this.Nombre = producto.nombre;            
            this.PrecioSinIva = producto.precioSinIva;
            this.Iva = producto.Iva;
            this.UnidadVenta = producto.unidadVenta;
            this.Stock = producto.stock;
            this.cat = producto.categoria;
        }
    }
}
