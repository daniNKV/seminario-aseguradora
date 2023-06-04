using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class EliminarAsegurableUseCase: UseCase<IRepositorioAsegurable>
{
    public EliminarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio) {
    }
    public void Ejecutar(int id)
    {
        try {
            Repositorio.Eliminar(id);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}