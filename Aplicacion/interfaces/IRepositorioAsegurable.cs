namespace Aplicacion;

public interface IRepositorioAsegurable
{
    void AgregarAsegurable(Vehiculo asegurable);
    void EliminarAsegurable(int asegurableId);
    void ModificarAsegurable(Vehiculo asegurable);
    List<Vehiculo> ListarAsegurables();
}