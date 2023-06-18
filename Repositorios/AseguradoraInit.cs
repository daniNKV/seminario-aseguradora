using Aplicacion.Entidades;
using Repositorios.Database;

namespace Repositorios;

public static class AseguradoraInit
{
    public static void Inicializar(AseguradoraContexto context)
    {
        InicializarTitulares(context);
    }
    private static void InicializarTitulares(AseguradoraContexto context)
    {
        if (context.Titulares.Any()) // ya fue inicializada
        {
            return;
        }
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
        context.SaveChanges();
    } 
}