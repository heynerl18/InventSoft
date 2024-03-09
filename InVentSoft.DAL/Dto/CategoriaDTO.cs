namespace InVentSoft.DAL.Dto
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Iva { get; set; }
        public string GrupoAlimentos { get; set; }
        //public ICollection<ProductoDTO> Producto { get; set; }

        public CategoriaDTO()
        {
            //this.Producto = new HashSet<ProductoDTO>();
        }

        public CategoriaDTO(categoria categoria)
        {
            this.Id = categoria.id;
            this.Nombre = categoria.nombre;
            this.Iva = categoria.iva;
            this.GrupoAlimentos = categoria.grupoAlimentos;
            //this.Producto = new HashSet<ProductoDTO>();
        }
    }
}
