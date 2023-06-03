namespace Aplicacion.Interfaces;
using Entidades;

public interface IRepositorioAsegurable
{
    void AgregarAsegurable(Vehiculo asegurable);
    void EliminarAsegurable(int asegurableId);
    void ModificarAsegurable(Vehiculo asegurable);
    List<Vehiculo> ListarAsegurables();
}