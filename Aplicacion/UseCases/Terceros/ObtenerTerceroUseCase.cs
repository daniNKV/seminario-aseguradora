using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Terceros;

public class ObtenerTerceroUseCase : UseCase<IRepositorioTercero>
{
    public ObtenerTerceroUseCase(IRepositorioTercero repositorio) : base(repositorio)
    {
    }
    public Tercero Ejecutar(int id)
    {
        return Repositorio.Obtener(id);
    }
}