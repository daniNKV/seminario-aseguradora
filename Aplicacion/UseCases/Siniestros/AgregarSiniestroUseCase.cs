using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Siniestros;

public class AgregarSiniestroUseCase : UseCase<IRepositorioSiniestro>
{
    public AgregarSiniestroUseCase(IRepositorioSiniestro repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(Siniestro siniestro)
    {
        try {
            Repositorio.Agregar(siniestro);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}