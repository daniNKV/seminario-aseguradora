using System.Diagnostics;
using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioPolizaSqLite : IRepositorioPoliza
{
    public Poliza? Obtener(int id)
    {
        using var context = new AseguradoraContexto();
        var poliza = context.Polizas
            .Include(p => p.VehiculoAsegurado)
            .FirstOrDefault(p => p.Id == id);
        return poliza;
    }

    public void Agregar(Poliza elemento)
    {
        using var context = new AseguradoraContexto();
        context.Polizas.Add(elemento);
        context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        using var context = new AseguradoraContexto();
        var polizaAEliminar = context.Polizas.FirstOrDefault(t => t.Id == id);
        if (polizaAEliminar != null)
        {
            context.Polizas.Remove(polizaAEliminar);
        } 
        context.SaveChanges();

    }    

    public void Modificar(Poliza elemento)
    {
        throw new NotImplementedException();
    }

    public List<Poliza> Listar()
    {
        using var context = new AseguradoraContexto();
        var polizas = context.Polizas.Include(p => p.VehiculoAsegurado).ToList();
        return polizas;
    }

    public Poliza? ObtenerPolizaDeVehiculo(Vehiculo vehiculo)
    {
        using var context = new AseguradoraContexto();
        var poliza = context.Polizas.Single(p => p.VehiculoAsegurado.Id == vehiculo.Id);
        return poliza;
    }

    public Poliza? ObtenerPolizaDeSiniestro(Siniestro siniestro)
    {
        using var context = new AseguradoraContexto();
        var poliza = context.Polizas.Single(p => p.Id == siniestro.PolizaId);
        return poliza;    
    }
}

