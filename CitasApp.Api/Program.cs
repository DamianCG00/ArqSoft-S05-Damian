using CitasApp.Aplication.Services;
using CitasApp.Interfaces;
using CitasApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Repositorios
builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();

// Servicios de aplicación
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// --- ENDPOINTS DE LA CALCULADORA PARA EL QUIZ ---
app.MapGet("/api/calculadora/sumar", (double a, double b) => new { operacion = "suma", a = a, b = b, resultado = a + b });
app.MapGet("/api/calculadora/restar", (double a, double b) => new { operacion = "resta", a = a, b = b, resultado = a - b });
app.MapGet("/api/calculadora/multiplicar", (double a, double b) => new { operacion = "multiplicacion", a = a, b = b, resultado = a * b });
app.MapGet("/api/calculadora/dividir", (double a, double b) => new { operacion = "division", a = a, b = b, resultado = a / b });

app.Run();