using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioVehiculoSqLite : IRepositorioVehiculo
{
    public Vehiculo? Obtener(int id)
    {
        using var context = new AseguradoraContexto();
        var vehiculo = context.Vehiculos
            .Include(v => v.Titular)
            .FirstOrDefault(s => s.Id == id);
        return vehiculo;
        
    }

    public void Agregar(Vehiculo elemento)
    {
        using var context = new AseguradoraContexto();
        context.Vehiculos.Add(elemento);
        context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        using var context = new AseguradoraContexto();
        
        var vehiculoAEliminar = context.Vehiculos.FirstOrDefault(t => t.Id == id);
        if (vehiculoAEliminar != null)
        {
            context.Vehiculos.Remove(vehiculoAEliminar);
            context.SaveChanges();
        }
    }

    public void Modificar(Vehiculo elemento)
    {
        using var context = new AseguradoraContexto();
        var entidadExistente = context.Vehiculos.FirstOrDefault(e => e.Id == elemento.Id);
        if (entidadExistente == null) return;
        context.Entry(entidadExistente).State = EntityState.Modified;
        context.Entry(entidadExistente).CurrentValues.SetValues(elemento);
        context.SaveChanges();
    }

    public List<Vehiculo> Listar()
    {
        using var context = new AseguradoraContexto();
        var vehiculos = context.Vehiculos.Include(x => x.Titular).ToList();
        return vehiculos;        
    }
}