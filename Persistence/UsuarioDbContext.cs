using CadastroDePessoa.Entity;
using Microsoft.EntityFrameworkCore;

namespace CadastroDePessoa.Persistence
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>(entity =>
            {
                entity.HasKey(user => user.Id);

                entity.Property(user => user.Name).IsRequired().HasMaxLength(20).HasColumnType("varchar(33)");
                entity.Property(user => user.Email).IsRequired().HasMaxLength(33).HasColumnType("varchar(33)");
                entity.Property(user => user.CreatedAt).HasColumnName("Created_At");
                entity.Property(user => user.UpdatedAt).HasColumnName("Updated_At");
                entity.Property(user => user.Password).IsRequired();
            });
        }
    }
}
