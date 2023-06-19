using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Siniestros;

public class ModificarSiniestroUseCase : UseCase<IRepositorioSiniestro>
{
    public ModificarSiniestroUseCase(IRepositorioSiniestro repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(Siniestro siniestro)
    {
        try {
            Repositorio.Modificar(siniestro);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}