namespace EcommerceBackend.Models
{
public class Empresa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public ICollection<Producto>? Productos { get; set; }
}
}
