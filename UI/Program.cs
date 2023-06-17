
using Aplicacion.UseCases.Asegurables;
using Aplicacion.UseCases.Polizas;
using Aplicacion.UseCases.Titulares;
using Aplicacion.UseCases.Terceros;
using Aplicacion.UseCases.Siniestros;
using UI.Data;
using MudBlazor.Services;


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

// Asegurables
builder.Services.AddTransient<AgregarAsegurableUseCase>();
builder.Services.AddTransient<ListarAsegurableUseCase>();
builder.Services.AddTransient<EliminarAsegurableUseCase>();
builder.Services.AddTransient<ModificarAsegurableUseCase>();

// Titulares
builder.Services.AddTransient<AgregarAsegurableUseCase>();
builder.Services.AddTransient<ListarAsegurableUseCase>();
builder.Services.AddTransient<ListarTitularesConSusAsegurablesUseCase>();
builder.Services.AddTransient<EliminarAsegurableUseCase>();
builder.Services.AddTransient<ModificarAsegurableUseCase>();

// Siniestros
builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();

// Terceros
builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();


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
