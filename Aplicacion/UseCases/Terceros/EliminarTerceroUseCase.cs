using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Terceros;

public class EliminarTerceroUseCase : UseCase<IRepositorioTercero>
{
    public EliminarTerceroUseCase(IRepositorioTercero repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(int terceroId)
    {
        try {
            Repositorio.Eliminar(terceroId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}