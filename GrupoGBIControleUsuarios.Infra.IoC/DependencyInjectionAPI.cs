using GrupoGBIControleUsuarios.Application.Mappings;
using GrupoGBIControleUsuarios.Domain.Interfaces;
using GrupoGBIControleUsuarios.Infra.Data.Context;
using GrupoGBIControleUsuarios.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoGBIControleUsuarios.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
