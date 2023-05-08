
namespace Aplicacion;

public class ModificarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;
    public ModificarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(IAsegurable asegurable)
    {
        try {
            _repositorio.ModificarAsegurable(asegurable);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}