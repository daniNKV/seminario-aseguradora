
namespace Aplicacion;

public class ModificarTitularUseCase
{
    private readonly IRepositorioTitular _repositorio;
    public ModificarTitularUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(int titularDni)
    {
        try {
            _repositorio.ModificarTitular(titularDni);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}