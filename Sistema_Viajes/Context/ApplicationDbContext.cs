using Microsoft.EntityFrameworkCore;
using Sistema_Viajes.Models;

namespace Sistema_Viajes.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SucursalColaborador>()
                .HasKey(sucursalColaborador => new {sucursalColaborador.SucursalId, sucursalColaborador.ColaboradorId});

            modelBuilder.Entity<RegistroViajeColaborador>()
                .HasKey(registroViajeColaborador => new { registroViajeColaborador.ColaboradorId, registroViajeColaborador.ViajeId });

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set;}
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Transportista> Transportistas { get; set; }
        public DbSet<RegistroViaje> RegistroViajes { get; set; }
        public DbSet<SucursalColaborador> SucursalColaboradores { get; set; }
        public DbSet<RegistroViajeColaborador> RegistroViajeColaboradores { get; set; }
    }
}
