using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Siniestros;

public class ListarSiniestrosUseCase : UseCase<IRepositorioSiniestro>
{
    public ListarSiniestrosUseCase(IRepositorioSiniestro repositorio) : base(repositorio)
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