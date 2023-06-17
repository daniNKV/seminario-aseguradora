using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Repositorios.Database;

public class RepositorioSiniestroSqLite : IRepositorioSiniestro
{
    public void Agregar(Siniestro elemento)
    {
        using var context = new AseguradoraContexto();
        context.Siniestros.Add(elemento);
        context.SaveChanges();    
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Siniestro elemento)
    {
        throw new NotImplementedException();
    }

    public List<Siniestro> Listar()
    {
        throw new NotImplementedException();
    }

    public List<Tercero> ListarTerceros(Siniestro siniestro)
    {
        throw new NotImplementedException();
    }
}