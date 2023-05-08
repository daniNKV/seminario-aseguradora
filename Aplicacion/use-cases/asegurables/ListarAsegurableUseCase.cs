
namespace Aplicacion;

public class ListarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;
    public ListarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar()
    {
        try {
            _repositorio.ListarAsegurables();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}