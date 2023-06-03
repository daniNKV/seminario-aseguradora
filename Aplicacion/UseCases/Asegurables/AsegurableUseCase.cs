using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public abstract class AsegurableUseCase
{
    protected IRepositorioAsegurable Repositorio { get; private set; }

    protected AsegurableUseCase(IRepositorioAsegurable repositorio)
    {
        Repositorio = repositorio;
    }
}