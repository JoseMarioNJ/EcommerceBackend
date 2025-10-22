using Ecommerce.Api.Models;
using EcommerceBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Empresa> Empresas { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
    }
}