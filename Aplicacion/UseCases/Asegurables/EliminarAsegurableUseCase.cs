using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class EliminarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;
    public EliminarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(int id)
    {
        try {
            _repositorio.EliminarAsegurable(id);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}