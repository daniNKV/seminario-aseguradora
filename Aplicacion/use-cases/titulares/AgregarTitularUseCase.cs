
namespace Aplicacion;

public class AgregarTitularUseCase
{
    private readonly IRepositorioTitular _repositorio;

    public AgregarTitularUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }

    public void Ejecutar(Titular titular)
    {
        try {
            _repositorio.AgregarTitular(titular);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}