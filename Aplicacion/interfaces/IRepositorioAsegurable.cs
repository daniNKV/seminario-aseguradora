namespace Aplicacion;

public interface IRepositorioAsegurable
{
    void AgregarAsegurable(IAsegurable asegurable);
    void EliminarAsegurable(int asegurableId);
    void ModificarAsegurable(int asegurableId);
    List<IAsegurable> ListarAsegurables();
}