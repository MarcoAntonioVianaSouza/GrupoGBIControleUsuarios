using GrupoGBIControleUsuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GrupoGBIControleUsuarios.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.NomeDeUsuario).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.Sobrenome).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.Senha).HasMaxLength(255).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.Email).HasMaxLength(255).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.EAdministrador);
            builder.Property(p => p.DataHoraCriacao).HasColumnType("DateTime");

            builder.HasIndex(u => u.Nome).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
