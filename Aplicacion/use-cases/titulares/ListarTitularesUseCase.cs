
namespace Aplicacion;

public class ListarTitularesUseCase
{
    private readonly IRepositorioTitular _repositorio;
    public ListarTitularesUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }
    public List<Titular> Ejecutar()
    {
        return _repositorio.ListarTitulares();

    }
}