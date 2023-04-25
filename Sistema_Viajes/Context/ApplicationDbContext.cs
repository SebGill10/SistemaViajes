using Microsoft.EntityFrameworkCore;
using Sistema_Viajes.Models;

namespace Sistema_Viajes.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set;}
        public DbSet<Sucurrsal> Sucurrsales { get; set; }
        public DbSet<Transportista> Transportistas { get; set; }
    }
}
