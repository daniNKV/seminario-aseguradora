using Aplicacion.Entidades;
using Aplicacion.Interfaces;

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
        throw new NotImplementedException();
    }
}