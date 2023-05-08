
namespace Aplicacion;

public class EliminarTitularUseCase
{
    private readonly IRepositorioTitular _repositorio;
    public EliminarTitularUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(int titularId)
    {
        try {
            _repositorio.EliminarTitular(titularId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}