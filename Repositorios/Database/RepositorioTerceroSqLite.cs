using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioTerceroSqLite : IRepositorioTercero
{
    public void Agregar(Tercero elemento)
    {
        using var context = new AseguradoraContexto();
        context.Terceros.Add(elemento);
        context.SaveChanges();    
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Tercero elemento)
    {
        throw new NotImplementedException();
    }

    public List<Tercero> Listar()
    {
        using var context = new AseguradoraContexto();
        var terceros = context.Terceros.Include(t => t.Siniestro).ToList();
        return terceros;         }
}