using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Repositorios.Database;

public class RepositorioAsegurableSqLite : IRepositorioAsegurable
{
    public void Agregar(Vehiculo elemento)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Vehiculo elemento)
    {
        throw new NotImplementedException();
    }

    public List<Vehiculo> Listar()
    {
        throw new NotImplementedException();
    }
}