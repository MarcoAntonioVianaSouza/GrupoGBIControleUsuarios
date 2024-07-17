using GrupoGBIControleUsuarios.Application.Interfaces;
using GrupoGBIControleUsuarios.Application.Mappings;
using GrupoGBIControleUsuarios.Application.Services;
using GrupoGBIControleUsuarios.Domain.Interfaces;
using GrupoGBIControleUsuarios.Infra.Data.Context;
using GrupoGBIControleUsuarios.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoGBIControleUsuarios.Infra.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        //Conexão SqlServer
        var server = configuration["DbServer"] ?? "localhost\\MSSQLSERVER2019";
        var port = configuration["DbPort"] ?? "1433"; // Padrão SQL SERVER
        var user = configuration["DbUser"] ?? "SA";
        var password = configuration["Password"] ?? "Dinamarca@2020";
        var database = configuration["Database"] ?? "GrupoGBIControleUsuarioProd";

        //var connectionString = $"Server={server}; Initial Catalog={database}; User ID={user}; Password={password}; Encrypt=False";
          var connectionString = $"Data Source={server}; Initial Catalog={database}; User ID={user}; Password={password};Encrypt=False";

        ////Para uso da conexão com SqlServer com Docker
         services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //// Descomentar se for utilizar Local (Sem Docker)
        //services.AddDbContext<ApplicationDbContext>(options =>
        // options.UseSqlServer(configuration.GetConnectionString("ControleUsuarioDB"
        //), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        
        return services;
    }
}
