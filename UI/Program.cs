
using Aplicacion.Interfaces;
using Aplicacion.UseCases.Polizas;
using Aplicacion.UseCases.Titulares;
using Aplicacion.UseCases.Terceros;
using Aplicacion.UseCases.Siniestros;
using Aplicacion.UseCases.Vehiculos;
using Microsoft.EntityFrameworkCore;
using UI.Data;
using MudBlazor.Services;
using Repositorios;
using Repositorios.Database;

using Repositorios.Txt;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add blazor components library
builder.Services.AddMudServices();

// Add use cases
// Polizas
builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();
builder.Services.AddTransient<ObtenerPolizaUseCase>();
builder.Services.AddTransient<ObtenerPolizaDeVehiculoUseCase>();
builder.Services.AddTransient<ObtenerPolizaDeSiniestroUseCase>();

builder.Services.AddScoped<IRepositorioPoliza, RepositorioPolizaSqLite>();

// Asegurables
builder.Services.AddTransient<AgregarVehiculoUseCase>();
builder.Services.AddTransient<ListarVehiculosUseCase>();
builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddTransient<ObtenerVehiculoUseCase>();

builder.Services.AddScoped<IRepositorioVehiculo, RepositorioVehiculoSqLite>();

// Titulares
builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<ListarTitularesConSusVehiculosUseCase>();
builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();
builder.Services.AddTransient<ObtenerTitularUseCase>();

builder.Services.AddScoped<IRepositorioTitular, RepositorioTitularSqLite>();

// Siniestros
builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();
builder.Services.AddTransient<ObtenerSiniestroUseCase>();

builder.Services.AddScoped<IRepositorioSiniestro, RepositorioSiniestroSqLite>();

// Terceros
builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();
builder.Services.AddTransient<ObtenerTerceroUseCase>();

builder.Services.AddScoped<IRepositorioTercero, RepositorioTerceroSqLite>();

using var context = new AseguradoraContexto();
context.Database.EnsureCreated();
var connection = context.Database.GetDbConnection();
connection.Open();
using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode=DELETE;";
    command.ExecuteNonQuery();
}
AseguradoraInit.Inicializar(context);
context.Dispose();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();