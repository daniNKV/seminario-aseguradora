using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Terceros;

public class ListarTercerosUseCase : UseCase<IRepositorioTercero>
{
    public ListarTercerosUseCase(IRepositorioTercero repositorio) : base(repositorio)
    {
    }
    public void Ejecutar()
    {
        try {
            Repositorio.Listar();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}