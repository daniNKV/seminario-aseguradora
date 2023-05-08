
namespace Aplicacion;

public class ListarPolizasUseCase
{
    private readonly IRepositorioPoliza _repositorio;
    public ListarPolizasUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar()
    {
        try {
            _repositorio.ListarPolizas();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}