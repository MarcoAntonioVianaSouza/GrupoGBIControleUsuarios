using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;


namespace GrupoGBIControleUsuarios.Infra.IoC;

public static class DependencyInjectionJWT
{
    public static IServiceCollection AddInfrastreuctureJWT(this IServiceCollection services,
        IConfiguration configuration)
    {
        //informar o tipo de autenticação JWT-Barear
        //definir o desafio de autenticação
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        //Habilita a autentação JWT usando o esquema e desafio definidos
        //validar o token
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["Jwt:Issuier"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });
        return services;
    }
}
