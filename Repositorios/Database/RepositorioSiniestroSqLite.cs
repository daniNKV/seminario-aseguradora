using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioSiniestroSqLite : IRepositorioSiniestro
{
    public Siniestro? Obtener(int id)
    {
        using var context = new AseguradoraContexto();
        var siniestro = context.Siniestros
            .Include(s => s.Poliza)
            .FirstOrDefault(s => s.Id == id);
        return siniestro;
        
    }

    public void Agregar(Siniestro elemento)
    {
        using var context = new AseguradoraContexto();
        context.Siniestros.Add(elemento);
        context.SaveChanges();    
    }

    public void Eliminar(int id)
    {
        using var context = new AseguradoraContexto();
        var siniestroAEliminar = context.Siniestros.FirstOrDefault(t => t.Id == id);
        if (siniestroAEliminar != null)
        {
            context.Siniestros.Remove(siniestroAEliminar);
            context.SaveChanges();
        }
    }

    public void Modificar(Siniestro elemento)
    {
        throw new NotImplementedException();
    }

    public List<Siniestro> Listar()
    {
        using var context = new AseguradoraContexto();
        var siniestros = context.Siniestros
            .Include(s => s.Poliza)
            .Include(s => s.Terceros)
            .ToList();
        return siniestros;        
    }

    public List<Tercero> ListarTerceros(Siniestro siniestro)
    {
        throw new NotImplementedException();
    }
}