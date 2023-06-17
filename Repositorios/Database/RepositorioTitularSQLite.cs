using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Repositorios.Database;

public class RepositorioTitularSqLite : IRepositorioTitular
{
    public void Agregar(Titular elemento)
    {
        throw new NotImplementedException();
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

    public List<IAsegurable> ListarItemsAsegurados(Titular titular)
    {
        throw new NotImplementedException();
    }
}