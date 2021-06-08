using FitnessStore.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessStore.API
{
    public class FitnessStoreDbContext : DbContext
    {
        public FitnessStoreDbContext(DbContextOptions<FitnessStoreDbContext> options) : base(options) 
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Refeicao> Refeicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Refeicoes)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.CodigoUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Refeicao>()
                .HasKey(r => r.CodigoRefeicao);

            base.OnModelCreating(modelBuilder);
        }
    }
}