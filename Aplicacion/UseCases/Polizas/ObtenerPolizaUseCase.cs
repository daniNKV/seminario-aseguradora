using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ObtenerPolizaUseCase : UseCase<IRepositorioPoliza>
{
    public ObtenerPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }
    public Poliza Ejecutar(int id)
    {
        return Repositorio.Obtener(id);
    }
}