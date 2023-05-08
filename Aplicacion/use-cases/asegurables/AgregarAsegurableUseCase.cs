
namespace Aplicacion;

public class AgregarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;

    public AgregarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }

    public void Ejecutar(Vehiculo asegurable)
    {
        _repositorio.AgregarAsegurable(asegurable);
    }
}