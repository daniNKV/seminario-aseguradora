using Aplicacion.Entidades;
using Repositorios.Database;

namespace Repositorios;

public static class AseguradoraInit
{
    public static void Inicializar(AseguradoraContexto context)
    {
        InicializarTitulares(context);
        context.SaveChanges();
        InicializarPolizas(context);
        context.SaveChanges();
        InicializarSiniestros(context);
        context.SaveChanges();
        
    }

    private static void InicializarPolizas(AseguradoraContexto context)
    {
        if (context.Polizas.Any())
        {
            return;
        }
        for (int i = 1; i < 20; i++)
        {
            context.Polizas.Add(CrearPoliza(i));
        }
    }

    private static void InicializarTitulares(AseguradoraContexto context)
    {
        if (context.Titulares.Any()) // ya fue inicializada
        {
            return;
        }
        var titulares = new List<Titular>();
        
        for (int i = 1; i < 11; i++)
        {
            titulares.Add( new Titular
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Dni = 12345678,
                Direccion = "Calle Falsa 123",
                Email = "juan@gmail.com",
                ItemsAsegurados = CrearListaVehiculos(2)
            });
        }
        foreach (var titular in titulares)
        {
            context.Titulares.Add(titular);
        }
    }

    
    private static void InicializarSiniestros(AseguradoraContexto context)
    {
        if (context.Siniestros.Any())
        {
            return;
        }
        var siniestros = new List<Siniestro>();
        
        for (int i = 1; i < 4; i++)
        {
            siniestros.Add(new Siniestro
            {
                PolizaId = i,
                FechaIngreso = default,
                FechaSuceso = default,
                Direccion = "null",
                Descripcion = "null",
                Terceros = CrearListaTerceros(2)
            });
        }
        foreach (var siniestro in siniestros)
        {
            context.Siniestros.Add(siniestro);
        }
    }
    

    private static List<Tercero> CrearListaTerceros(int cantidad)
    {
        var lista = new List<Tercero>();
        for (int i = 1; i < cantidad; i++)
        {
            lista.Add(new Tercero
            {
                Nombre = "null",
                Apellido = "null",
                Dni = 0,
                Telefono = "null",
                Aseguradora = "null",
            });
        }

        return lista;    
    }
    

    private static Poliza CrearPoliza(int i)
    {
        return new Poliza
        {
            TipoCobertura = "null",
            Franquicia = 0,
            VehiculoAseguradoId = i,
            ValorAsegurado = 0,

        };
    }
    
    private static List<Vehiculo> CrearListaVehiculos(int cantidad = 20)
    {
        var lista = new List<Vehiculo>();
        for (int i = 1; i < cantidad + 1; i++)
        {
            lista.Add(new Vehiculo
            {
                Marca = "Ford", 
                Dominio = "Fiesta", 
                Fabricacion  = "2010"
            });
        }

        return lista;
        
    }
}


/*context.Add(new Titular 
{ 
    Nombre = "Juan", 
    Apellido = "Pérez", 
    Dni = 12345678,
    Direccion = "Calle Falsa 123",
    Email="juan@gmail.com" 
});
context.Add(new Titular
{
    Nombre = "Ana",
    Apellido = "González",
    Dni = 12345678,
    Direccion = "Calle SiempreViva 123",    
    Email="AnaG@gmail.com"
});
context.Add(new Titular
{
    Nombre = "Laura",
    Apellido = "García",
    Dni = 12345678,
    Direccion = "Calle SiempreViva 123",
    Email="Laura@hotmail.com"
});
context.Add(new Vehiculo
{
    TitularId = 1, 
    Marca = "Ford", 
    Dominio = "Fiesta", 
    Fabricacion  = "2010"
});

context.Add(new Vehiculo
{
    TitularId = 2, 
    Marca = "Ford", 
    Dominio = "Fiesta", 
    Fabricacion  = "2010"
});
context.Add(new Vehiculo
{
    TitularId = 3, 
    Marca = "Ford", 
    Dominio = "Focus", 
    Fabricacion  = "2020"
});
        
context.Add(new Titular 
{ 
    Nombre = "Juan", 
    Apellido = "Pérez", 
    Dni = 12345678,
    Direccion = "Calle Falsa 123",
    Email="juan@gmail.com" 
});
context.Add(new Titular
{
    Nombre = "Ana",
    Apellido = "González",
    Dni = 12345678,
    Direccion = "Calle SiempreViva 123",    
    Email="AnaG@gmail.com"
});
context.Add(new Titular
{
    Nombre = "Laura",
    Apellido = "García",
    Dni = 12345678,
    Direccion = "Calle SiempreViva 123",
    Email="Laura@hotmail.com"
});*/