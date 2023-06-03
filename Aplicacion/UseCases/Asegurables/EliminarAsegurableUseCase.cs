using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class EliminarAsegurableUseCase : AsegurableUseCase
{
    public EliminarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio) {
    }
    public void Ejecutar(int id)
    {
        try {
            Repositorio.EliminarAsegurable(id);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}