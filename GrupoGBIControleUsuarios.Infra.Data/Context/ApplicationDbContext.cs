using GrupoGBIControleUsuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace GrupoGBIControleUsuarios.Infra.Data.Context;
public class ApplicationDbContext : DbContext 
{
    // Através do DBContext teremos uma sessão com o banco de dados
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    // Definição do mapeamento ORM
    public DbSet<Usuario> Usuarios { get; set; }
    

    // Configuração da Fluent-API
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Estamos sobrescrevendo o método.
        //Através de Reflection irá buscar quem implementa IEntityTypeConfiguration
        //Destaa forma não precisamos especificar aqui neste método cada uma das configurações, pois
        //ele irá identificar nos respectivos arquivos (classes de configuração de cada entidade do modelo).
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
