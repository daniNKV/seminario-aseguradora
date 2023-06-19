using System.Diagnostics;
using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioPolizaSqLite : IRepositorioPoliza
{
    public void Agregar(Poliza elemento)
    {
        using var context = new AseguradoraContexto();
        context.Polizas.Add(elemento);
        context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
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
}

