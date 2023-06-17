using System.Diagnostics;
using Aplicacion.Entidades;
using Aplicacion.Interfaces;

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
        Debug.Write("Listando polizas...");
        return context.Polizas.ToList();
    }
}