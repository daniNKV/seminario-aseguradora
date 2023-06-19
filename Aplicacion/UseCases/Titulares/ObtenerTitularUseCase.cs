using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ObtenerTitularUseCase : UseCase<IRepositorioTitular>
{
    public ObtenerTitularUseCase(IRepositorioTitular repositorio) : base(repositorio)
    {
    }
    public Titular Ejecutar(int id)
    {
        return Repositorio.Obtener(id);
    }
}