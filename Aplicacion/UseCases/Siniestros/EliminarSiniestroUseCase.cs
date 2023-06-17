using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Siniestros;

public class EliminarSiniestroUseCase : UseCase<IRepositorioSiniestro>
{
    public EliminarSiniestroUseCase(IRepositorioSiniestro repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(int siniestroId)
    {
        try {
            Repositorio.Eliminar(siniestroId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}