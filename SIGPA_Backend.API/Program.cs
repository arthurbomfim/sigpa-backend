using Microsoft.EntityFrameworkCore;
using SIGPA_Backend.Application.Interfaces;
using SIGPA_Backend.Application.UseCases.CriarUsuario;
using SIGPA_Backend.Infrastructure.Repositories;
using SIGPA_Backend.Infrastructure.Services;
using SIGPA_Backend.Domain.Interfaces;
using SIGPA_Backend.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});

// Registrar repositório e serviços da Infrastructure
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();

// Registrar UseCase da Application
builder.Services.AddScoped<ICriarUsuarioUseCase, CriarUsuarioUseCase>();

// Outras configurações da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Aqui: aplica automaticamente as migrations pendentes
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();