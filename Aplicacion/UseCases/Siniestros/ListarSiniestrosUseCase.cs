using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Siniestros;

public class ListarSiniestrosUseCase : UseCase<IRepositorioSiniestro>
{
    public ListarSiniestrosUseCase(IRepositorioSiniestro repositorio) : base(repositorio)
    {
    }
    public List<Siniestro> Ejecutar()
    {
        return Repositorio.Listar();
    }
}