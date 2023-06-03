using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Aplicacion.UseCases.Asegurables;
using Aplicacion.UseCases.Polizas;
using Aplicacion.UseCases.Titulares;

//Inyección de dependencias a casos de usos de Titular
IRepositorioTitular repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular);
ListarTitularesConSusAsegurablesUseCase listarTitularesYVehiculos = new ListarTitularesConSusAsegurablesUseCase(repoTitular);

//Inyección de dependencias a casos de usos de Poliza
IRepositorioPoliza repoPoliza = new RepositorioPolizaTXT();
AgregarPolizaUseCase agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
ListarPolizasUseCase listarPolizas = new ListarPolizasUseCase(repoPoliza);
ModificarPolizaUseCase modificarPoliza = new ModificarPolizaUseCase(repoPoliza);
EliminarPolizaUseCase eliminarPoliza = new EliminarPolizaUseCase(repoPoliza);

//Inyección de dependencias a casos de usos de Asegurables
IRepositorioAsegurable repoAsegurable = new RepositorioAsegurableTXT();
AgregarAsegurableUseCase agregarAsegurable = new AgregarAsegurableUseCase(repoAsegurable);
ListarAsegurableUseCase listarAsegurables = new ListarAsegurableUseCase(repoAsegurable);
ModificarAsegurableUseCase modificarAsegurable = new ModificarAsegurableUseCase(repoAsegurable) ;
EliminarAsegurableUseCase eliminarAsegurable = new EliminarAsegurableUseCase(repoAsegurable) ;


// DEMO TITULARES
Console.WriteLine("############################################");
Console.WriteLine("DEMO TITULARES");
Console.WriteLine("############################################");

// Instancia de Titular
Titular titular = new Titular(33123456, "García", "Juan")
{
    direccion = "13 nro. 546",
    telefono = "221-456456",
    email = "joseGarcia@gmail.com"
};
Console.WriteLine($"Id del titular recién instanciado: {titular.id}");

// Agregar titular al repositorio
PersistirTitular(titular);

// Comprobar ID correcta
Console.WriteLine($"Id del titular una vez persistido: {titular.id}");

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
modificarTitular.Ejecutar(titular);
ListarTitulares();

// Eliminación de un titular
Console.WriteLine();
Console.WriteLine("Eliminando al titular con id 1");
eliminarTitular.Ejecutar(1);
ListarTitulares();



for (int i = 0; i < 3; i++) {
    Console.WriteLine();
}

// DEMO POLIZAS
Console.WriteLine("################################################");
Console.WriteLine("DEMO POLIZAS");
Console.WriteLine("################################################");

// Instancia de Poliza
Poliza poliza = new Poliza("TodoRiesgo", 2000.0, new Vehiculo(), 2000.00, "22/05/2020");
Console.WriteLine($"Id de la poliza recién instanciada: {poliza.id}");

// Guardar instancia en repositorio
PersistirPoliza(poliza);
Console.WriteLine($"Id de la poliza una vez persistida: {poliza.id}");

// Agrega Polizas
PersistirPoliza(new Poliza("TodoRiesgo", new Vehiculo()));
PersistirPoliza(new Poliza("ResponsabilidadCivil", 4000.0, new Vehiculo(), 1000.00, "24/02/2021"));
PersistirPoliza(new Poliza("TodoRiesgo", 5000.0, new Vehiculo(), 2000.00, "22/01/2023"));

// //listamos las polizas utilizando un método local
ListarPolizas();

// Modificar una poliza existente
Console.WriteLine();
Console.WriteLine("Modificando el titular con ID 1");
poliza.tipoCobertura = "ResponsabilidadCivil";
poliza.franquicia = 50000.0;
poliza.valorAsegurado = 100000.0;

// Persistir la modificación
modificarPoliza.Ejecutar(poliza);

//Comprobar ejecución
ListarPolizas();

//Eliminando un titular
Console.WriteLine();
Console.WriteLine("Eliminando al titular con id 1");
eliminarPoliza.Ejecutar(1);
ListarPolizas();



for (int i = 0; i < 3; i++) {
    Console.WriteLine();
}

// DEMO VEHICULOS
Console.WriteLine("################################################");
Console.WriteLine("DEMO VEHICULOS");
Console.WriteLine("################################################");
// Instancia de vehiculo
Vehiculo vehiculo = new Vehiculo("ABC212", "Ford", "2013");
Console.WriteLine($"Id de la Vehiculo recién instanciada: {vehiculo.id}");

// Se agrega el vehiculo a repositorio utilizando un método local
PersistirVehiculo(vehiculo);

// El id que corresponde al vehiculo es establecido por el repositorio
Console.WriteLine($"Id de la Vehiculo una vez persistida: {vehiculo.id}");

// Se agregan unos Vehiculos más
PersistirVehiculo(new Vehiculo("ASK203", "Chevrolet", "1996"));
PersistirVehiculo(new Vehiculo("ABC212", "Ford", "2013"));
PersistirVehiculo(new Vehiculo());

ListarVehiculos();

//Modificar un Vehiculo existente
Console.WriteLine();
Console.WriteLine("Modificando el titular con ID 1");
vehiculo.marca = "Dodge";
vehiculo.dominio = "ZZZ999";
vehiculo.fabricacion = "1980";

modificarAsegurable.Ejecutar(vehiculo);
ListarVehiculos();

// Eliminando un vehiculo
Console.WriteLine();
Console.WriteLine("Eliminando al titular con id 1");
eliminarAsegurable.Ejecutar(1);
ListarVehiculos();



// Métodos Locales
void PersistirTitular(Titular t)
{
    try
    {
        agregarTitular.Ejecutar(t);
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

    List<Titular> lista = listarTitulares.Ejecutar();
    foreach (Titular t in lista)
    {
        Console.WriteLine(t);
    }
}

void PersistirVehiculo(Vehiculo v)
{
    try
    {
        agregarAsegurable.Ejecutar(v);
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
    List<Vehiculo> vehiculos = listarAsegurables.Ejecutar();
    foreach (Vehiculo v in vehiculos)
    {
        Console.WriteLine(v);
    }
}

void PersistirPoliza(Poliza p)
{
    try
    {
        agregarPoliza.Ejecutar(p);
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
    List<Poliza> lista = listarPolizas.Ejecutar();
    foreach (Poliza p in lista)
    {
        Console.WriteLine(p);
    }
}
