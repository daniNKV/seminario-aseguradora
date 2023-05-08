
namespace Aplicacion;

public class ModificarTitularUseCase
{
    private readonly IRepositorioTitular _repositorio;
    public ModificarTitularUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(Titular titular)
    {
        try {
            _repositorio.ModificarTitular(titular);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}