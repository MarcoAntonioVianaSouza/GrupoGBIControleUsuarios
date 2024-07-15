using GrupoGBIControleUsuarios.Application.Mappings;
using GrupoGBIControleUsuarios.Domain.Interfaces;
using GrupoGBIControleUsuarios.Infra.Data.Context;
using GrupoGBIControleUsuarios.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoGBIControleUsuarios.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("ControleUsuarioDB"
        ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        //services.ConfigureApplicationCookie(options =>
        //         options.AccessDeniedPath = "/Account/Login");

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
