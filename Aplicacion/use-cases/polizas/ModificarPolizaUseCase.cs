
namespace Aplicacion;

public class ModificarPolizaUseCase
{
    private readonly IRepositorioPoliza _repositorio;
    public ModificarPolizaUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(int polizaId)
    {
        try {
            _repositorio.ModificarPoliza(polizaId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}