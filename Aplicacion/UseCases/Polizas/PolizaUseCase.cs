using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public abstract class PolizaUseCase
{
    protected IRepositorioPoliza Repositorio { get; private set; }

    protected PolizaUseCase(IRepositorioPoliza repositorio)
    {
        Repositorio = repositorio;
    }
}