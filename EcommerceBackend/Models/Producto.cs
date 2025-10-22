namespace EcommerceBackend.Models
{
    public class Producto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }    // admin gestiona stock
        public Guid EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}