using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Contexto en memoria como Singleton para mantener el estado entre requests
builder.Services.AddSingleton<ApplicationDbContext>();

// Inyección de dependencias de Repositorios (Infrastructure -> Domain Interfaces)
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();

// Inyección de dependencias de Servicios (Application -> Application Interfaces)
builder.Services.AddScoped<ITurnoService, TurnoService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "API v1"
        );
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
