using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

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