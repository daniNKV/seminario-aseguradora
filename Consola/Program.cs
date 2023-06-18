using Microsoft.Extensions.DependencyInjection;
using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Aplicacion.UseCases.Polizas;
using Aplicacion.UseCases.Siniestros;
using Aplicacion.UseCases.Terceros;
using Aplicacion.UseCases.Titulares;
using Aplicacion.UseCases.Vehiculos;
using Repositorios.Txt;
using Repositorios.Database;


// Inyección de dependencias    
IServiceCollection services = new ServiceCollection();
services.AddTransient<AgregarPolizaUseCase>();
services.AddTransient<ListarPolizasUseCase>();
services.AddTransient<EliminarPolizaUseCase>();
services.AddTransient<ModificarPolizaUseCase>();
services.AddScoped<IRepositorioPoliza, RepositorioPolizaTxt>();

// Asegurables
services.AddTransient<AgregarVehiculoUseCase>();
services.AddTransient<ListarVehiculosUseCase>();
services.AddTransient<EliminarVehiculoUseCase>();
services.AddTransient<ModificarVehiculoUseCase>();
services.AddScoped<IRepositorioVehiculo, RepositorioVehiculoTxt>();

// Titulares
services.AddTransient<AgregarTitularUseCase>();
services.AddTransient<ListarTitularesUseCase>();
services.AddTransient<ListarTitularesConSusVehiculosUseCase>();
services.AddTransient<EliminarTitularUseCase>();
services.AddTransient<ModificarTitularUseCase>();
services.AddScoped<IRepositorioTitular, RepositorioTitularTxt>();

/*
// Siniestros
services.AddTransient<AgregarSiniestroUseCase>();
services.AddTransient<ListarSiniestrosUseCase>();
services.AddTransient<EliminarSiniestroUseCase>();
services.AddTransient<ModificarSiniestroUseCase>();
services.AddScoped<IRepositorioSiniestro, RepositorioSiniestroSqLite>();

// Terceros
services.AddTransient<AgregarTerceroUseCase>();
services.AddTransient<ListarTercerosUseCase>();
services.AddTransient<EliminarTerceroUseCase>();
services.AddTransient<ModificarTerceroUseCase>();
services.AddScoped<IRepositorioTercero, RepositorioTerceroTxt>();
*/

var proveedor = services.BuildServiceProvider();

var agregarTitular = proveedor.GetService<AgregarTitularUseCase>();
var listarTitulares = proveedor.GetService<ListarTitularesUseCase>();
var modificarTitular = proveedor.GetService<ModificarTitularUseCase>();
var eliminarTitular = proveedor.GetService<EliminarTitularUseCase>();
var listarTitularesYVehiculos = proveedor.GetService<ListarTitularesConSusVehiculosUseCase>();

//Inyección de dependencias a casos de usos de Poliza
var agregarPoliza = proveedor.GetService<AgregarPolizaUseCase>();
var listarPolizas = proveedor.GetService<ListarPolizasUseCase>();
var modificarPoliza = proveedor.GetService<ModificarPolizaUseCase>();
var eliminarPoliza = proveedor.GetService<EliminarPolizaUseCase>();

//Inyección de dependencias a casos de usos de Asegurables
var agregarAsegurable = proveedor.GetService<AgregarVehiculoUseCase>();
var listarVehiculoses = proveedor.GetService<ListarVehiculosUseCase>();
var modificarVehiculo = proveedor.GetService<ModificarVehiculoUseCase>();
var eliminarVehiculo = proveedor.GetService<EliminarVehiculoUseCase>();


// DEMO TITULARES
Console.WriteLine("############################################");
Console.WriteLine("DEMO TITULARES");
Console.WriteLine("############################################");

// Instancia de Titular
var titular = new Titular(33123456, "García", "Juan")
{
    Direccion = "13 nro. 546",
    Telefono = "221-456456",
    Email = "joseGarcia@gmail.com"
};
Console.WriteLine($"Id del titular recién instanciado: {titular.Id}");

// Agregar titular al repositorio
PersistirTitular(titular);

// Comprobar ID correcta
Console.WriteLine($"Id del titular una vez persistido: {titular.Id}");

// Agregar más titulares
PersistirTitular(new Titular(20654987, "Rodriguez", "Ana"));
PersistirTitular(new Titular(31456444, "Alconada", "Fermín"));
PersistirTitular(new Titular(12345654, "Perez", "Cecilia"));

// Listar los titulares utilizando un método local
ListarTitulares();

// No debe ser posible agregar un titular con igual DNI que uno existente
Console.WriteLine();
Console.WriteLine("Intentando agregar un titular con DNI 20654987");
titular = new Titular(20654987, "Alvarez", "Alvaro");
PersistirTitular(titular); //este titular no pudo persistirse

// Modificación de uno existente
Console.WriteLine();
Console.WriteLine("Modificando el titular con DNI 20654987");
modificarTitular?.Ejecutar(titular);
ListarTitulares();

// Eliminación de un titular
Console.WriteLine();
Console.WriteLine("Eliminando al titular con id 1");
eliminarTitular?.Ejecutar(1);
ListarTitulares();



for (var i = 0; i < 3; i++) {
    Console.WriteLine();
}

// DEMO POLIZAS
Console.WriteLine("################################################");
Console.WriteLine("DEMO POLIZAS");
Console.WriteLine("################################################");

// Instancia de Poliza
var poliza = new Poliza("TodoRiesgo", 2000.0, new Vehiculo(), 2000.00, "22/05/2020");
Console.WriteLine($"Id de la poliza recién instanciada: {poliza.Id}");

// Guardar instancia en repositorio
PersistirPoliza(poliza);
Console.WriteLine($"Id de la poliza una vez persistida: {poliza.Id}");

// Agrega Polizas
PersistirPoliza(new Poliza("TodoRiesgo", new Vehiculo()));
PersistirPoliza(new Poliza("ResponsabilidadCivil", 4000.0, new Vehiculo(), 1000.00, "24/02/2021"));
PersistirPoliza(new Poliza("TodoRiesgo", 5000.0, new Vehiculo(), 2000.00, "22/01/2023"));

// //listamos las polizas utilizando un método local
ListarPolizas();

// Modificar una poliza existente
Console.WriteLine();
Console.WriteLine("Modificando el titular con ID 1");
poliza.TipoCobertura = "ResponsabilidadCivil";
poliza.Franquicia = 50000.0;
poliza.ValorAsegurado = 100000.0;

// Persistir la modificación
modificarPoliza?.Ejecutar(poliza);

//Comprobar ejecución
ListarPolizas();

//Eliminando un titular
Console.WriteLine();
Console.WriteLine("Eliminando al titular con id 1");
eliminarPoliza?.Ejecutar(1);
ListarPolizas();



for (var i = 0; i < 3; i++) {
    Console.WriteLine();
}

// DEMO VEHICULOS
Console.WriteLine("################################################");
Console.WriteLine("DEMO VEHICULOS");
Console.WriteLine("################################################");
// Instancia de vehiculo
var vehiculo = new Vehiculo("ABC212", "Ford", "2013");
Console.WriteLine($"Id de la Vehiculo recién instanciada: {vehiculo.Id}");

// Se agrega el vehiculo a repositorio utilizando un método local
PersistirVehiculo(vehiculo);

// El id que corresponde al vehiculo es establecido por el repositorio
Console.WriteLine($"Id de la Vehiculo una vez persistida: {vehiculo.Id}");

// Se agregan unos Vehiculos más
PersistirVehiculo(new Vehiculo("ASK203", "Chevrolet", "1996"));
PersistirVehiculo(new Vehiculo("ABC212", "Ford", "2013"));
PersistirVehiculo(new Vehiculo());

ListarVehiculos();

//Modificar un Vehiculo existente
Console.WriteLine();
Console.WriteLine("Modificando el titular con ID 1");
vehiculo.Marca = "Dodge";
vehiculo.Dominio = "ZZZ999";
vehiculo.Fabricacion = "1980";

modificarVehiculo?.Ejecutar(vehiculo);
ListarVehiculos();

// Eliminando un vehiculo
Console.WriteLine();
Console.WriteLine("Eliminando al titular con id 1");
eliminarVehiculo?.Ejecutar(1);
ListarVehiculos();



// Métodos Locales
void PersistirTitular(Titular t)
{
    try
    {
        agregarTitular?.Ejecutar(t);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarTitulares()
{
    Console.WriteLine();
    Console.WriteLine("Listando todos los titulares de vehículos");

    var lista = listarTitulares?.Ejecutar();
    foreach (var t in lista ?? new List<Titular>())
    {
        Console.WriteLine(t);
    }
}

void PersistirVehiculo(Vehiculo v)
{
    try
    {
        agregarAsegurable?.Ejecutar(v);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ListarVehiculos()
{
    Console.WriteLine();
    Console.WriteLine("Listando todos las polizas de vehículos");
    var vehiculos = listarVehiculoses?.Ejecutar();
    foreach (var v in vehiculos ?? new List<Vehiculo>())
    {
        Console.WriteLine(v);
    }
}

void PersistirPoliza(Poliza p)
{
    try
    {
        agregarPoliza?.Ejecutar(p);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ListarPolizas()
{
    Console.WriteLine();
    Console.WriteLine("Listando todos las polizas de vehículos");
    var lista = listarPolizas?.Ejecutar();
    foreach (var p in lista ?? new List<Poliza>())
    {
        Console.WriteLine(p);
    }
}
