namespace Aplicacion;

public interface IRepositorioAsegurable: IRepositorio<IAsegurable>
{
    void AgregarAsegurable(IAsegurable asegurable);
    void EliminarAsegurable(int asegurableId);
    void ModificarAsegurable(IAsegurable asegurable);
    List<IAsegurable> ListarAsegurables();
}