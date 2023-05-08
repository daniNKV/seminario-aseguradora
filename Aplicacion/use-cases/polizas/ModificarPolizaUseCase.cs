
namespace Aplicacion;

public class ModificarPolizaUseCase
{
    private readonly IRepositorioPoliza _repositorio;
    public ModificarPolizaUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(Poliza poliza)
    {
        try {
            _repositorio.ModificarPoliza(poliza);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}