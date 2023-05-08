
namespace Aplicacion;

public class EliminarPolizaUseCase
{
    private readonly IRepositorioPoliza _repositorio;
    public EliminarPolizaUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(int polizaId)
    {
        try {
            _repositorio.EliminarPoliza(polizaId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}