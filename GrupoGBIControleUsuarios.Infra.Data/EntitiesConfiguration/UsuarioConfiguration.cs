using GrupoGBIControleUsuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
