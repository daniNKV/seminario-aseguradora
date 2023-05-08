namespace Aplicacion;

public interface IRepositorioAsegurable: IRepositorio<IAsegurable>
{
    void AgregarAsegurable(IAsegurable asegurable);
    void EliminarAsegurable(int asegurableId);
    void ModificarAsegurable(int asegurableId);
    List<IAsegurable> ListarAsegurables();
}