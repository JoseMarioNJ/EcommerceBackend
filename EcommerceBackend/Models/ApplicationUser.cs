using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        // Si el usuario es una empresa, asociaciones
        public Guid? EmpresaId { get; set; }
    }
}