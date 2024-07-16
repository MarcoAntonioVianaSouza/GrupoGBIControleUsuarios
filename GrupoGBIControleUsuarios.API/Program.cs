using GrupoGBIControleUsuarios.Infra.IoC;
using GrupoGBIControleUsuarios.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastreuctureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configurando migração
DatabaseManagementService.MigrationInitialisation(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages(); // Vai explicitar o erro que está sendo exibido.
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
