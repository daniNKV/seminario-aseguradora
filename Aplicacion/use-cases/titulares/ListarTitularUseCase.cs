
namespace Aplicacion;

public class ListarTitularUseCase
{
    private readonly IRepositorioTitular _repositorio;
    public ListarTitularUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar()
    {
        try {
            _repositorio.ListarTitulares();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}