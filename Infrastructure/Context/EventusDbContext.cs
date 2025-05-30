using Microsoft.EntityFrameworkCore;
using Eventus.API.Domain.Entities;

namespace Eventus.API.Infrastructure.Context
{
    public class EventusDbContext : DbContext
    {
        public EventusDbContext(DbContextOptions<EventusDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RelatoEvento> Relatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("USUARIOS")
                .HasMany(u => u.Relatos)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<RelatoEvento>()
                .ToTable("RELATOS");
        }
    }
}
