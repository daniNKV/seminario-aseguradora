using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Siniestros;

public class ObtenerSiniestroUseCase : UseCase<IRepositorioSiniestro>
{
    public ObtenerSiniestroUseCase(IRepositorioSiniestro repositorio) : base(repositorio)
    {
    }
    public Siniestro Ejecutar(int id)
    {
        return Repositorio.Obtener(id);
    }
}