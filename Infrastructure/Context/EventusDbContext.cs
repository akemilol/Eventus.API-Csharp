using Microsoft.EntityFrameworkCore;
using Eventus.API.Domain.Entities;


namespace Eventus.API.Infrastructure.Context

{
    public class EventusDbContext : DbContext
    {
        public EventusDbContext(DbContextOptions<EventusDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RelatoEvento> Relatos { get; set; }
        public DbSet<Abrigo> Abrigos { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<UsuarioAbrigo> UsuarioAbrigos { get; set; }
        public DbSet<UsuarioAlerta> UsuarioAlertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("USUARIOS")
                .HasMany(u => u.Relatos)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<RelatoEvento>()
                .ToTable("RELATOS");

            modelBuilder.Entity<Abrigo>()
                .ToTable("ABRIGO");

            modelBuilder.Entity<Alerta>()
                .ToTable("ALERTA");

            modelBuilder.Entity<UsuarioAbrigo>()
                .ToTable("USUARIO_ABRIGO");

            modelBuilder.Entity<UsuarioAlerta>()
                .ToTable("USUARIO_ALERTA");
        }
    }
}
