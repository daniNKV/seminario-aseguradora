using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioVehiculoSqLite : IRepositorioVehiculo
{
    public void Agregar(Vehiculo elemento)
    {
        using var context = new AseguradoraContexto();
        context.Vehiculos.Add(elemento);
        context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Vehiculo elemento)
    {
        throw new NotImplementedException();
    }

    public List<Vehiculo> Listar()
    {
        using var context = new AseguradoraContexto();
        var vehiculos = context.Vehiculos.Include(x => x.Titular).ToList();
        return vehiculos;        
    }
}