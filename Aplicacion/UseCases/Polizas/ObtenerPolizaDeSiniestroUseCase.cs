using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ObtenerPolizaDeSiniestroUseCase : UseCase<IRepositorioPoliza>
{
    public ObtenerPolizaDeSiniestroUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }

    public Poliza? Ejecutar(Siniestro siniestro)
    { 
        return Repositorio.ObtenerPolizaDeSiniestro(siniestro);
    }
}