
namespace Aplicacion;

public class ListarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;
    public ListarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }
    public List<Vehiculo> Ejecutar()
    {
        return _repositorio.ListarAsegurables();
    }
}