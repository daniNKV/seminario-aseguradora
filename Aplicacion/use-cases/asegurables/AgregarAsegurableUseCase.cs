
namespace Aplicacion;

public class AgregarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;

    public AgregarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }

    public void Ejecutar(IAsegurable asegurable)
    {
        _repositorio.AgregarAsegurable(asegurable);
    }
}