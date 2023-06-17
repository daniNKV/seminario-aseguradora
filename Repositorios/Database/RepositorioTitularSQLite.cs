using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Repositorios.Database;

public class RepositorioTitularSqLite : IRepositorioTitular
{
    public void Agregar(Titular elemento)
    {
        using var context = new AseguradoraContexto();
        context.Titulares.Add(elemento);
        context.SaveChanges();    
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Titular elemento)
    {
        throw new NotImplementedException();
    }

    public List<Titular> Listar()
    {
        throw new NotImplementedException();
    }

    public List<Asegurable> ListarItemsAsegurados(Titular titular)
    {
        throw new NotImplementedException();
    }
}