using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioTitularSqLite : IRepositorioTitular
{
    public Titular? Obtener(int id)
    {
        using var context = new AseguradoraContexto();
        var titular = context.Titulares
            .Include(s => s.ItemsAsegurados)
            .FirstOrDefault(s => s.Id == id);
        return titular;
    }

    public void Agregar(Titular elemento)
    {
        using var context = new AseguradoraContexto();
        context.Titulares.Add(elemento);
        context.SaveChanges();    
    }

    public void Eliminar(int id)
    {
        using var context = new AseguradoraContexto();
        
        var titularAEliminar = context.Titulares.Include(t => t.ItemsAsegurados).FirstOrDefault(t => t.Id == id);
        if (titularAEliminar != null)
        {
            context.Titulares.Remove(titularAEliminar);
            context.SaveChanges();
        }
    }

    public void Modificar(Titular elemento)
    {
        using var context = new AseguradoraContexto();
        var entidadExistente = context.Titulares.FirstOrDefault(e => e.Id == elemento.Id);
        if (entidadExistente == null) return;
        context.Entry(entidadExistente).State = EntityState.Modified;
        context.Entry(entidadExistente).CurrentValues.SetValues(elemento);
        context.SaveChanges();        
    }

    public List<Titular> Listar()
    {
        using var context = new AseguradoraContexto();
        var titulares = context.Titulares.ToList();
        return titulares;    
    }

    public List<Vehiculo> ListarItemsAsegurados(Titular titular)
    {
        throw new NotImplementedException();

    }
    public List<Titular> ListarTitularesConSusVehiculos()
    {
        using var context = new AseguradoraContexto();
        var titulares = context.Titulares.Include(t => t.ItemsAsegurados).ToList();
        return titulares;        
    }
}