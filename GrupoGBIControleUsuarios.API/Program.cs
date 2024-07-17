using GrupoGBIControleUsuarios.Infra.IoC;
using GrupoGBIControleUsuarios.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastreuctureJWT(builder.Configuration);
//builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GrupoGBIControleUsuariosAPI",
        Version = "v1"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

//Configurando migração
DatabaseManagementService.MigrationInitialisation(app);

// Configure the HTTP request pipeline.
// Comentado apenas para aparecer no teste do Docker.
// Deverá ser comentado quando rodar em produção.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", 
            "GrupoGBIUsuarios.API V1");
    });
//}

app.UseHttpsRedirection();

app.UseStatusCodePages(); // Vai explicitar o erro que está sendo exibido.
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
