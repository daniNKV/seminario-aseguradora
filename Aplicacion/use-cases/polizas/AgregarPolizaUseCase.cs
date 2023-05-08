
namespace Aplicacion;

public class AgregarPolizaUseCase
{
    private readonly IRepositorioPoliza _repositorio;

    public AgregarPolizaUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }

    public void Ejecutar(Poliza poliza)
    {
        _repositorio.AgregarPoliza(poliza);
    }
}