using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public abstract class TitularUseCase
{
    protected IRepositorioTitular Repositorio { get; private set; }

    protected TitularUseCase(IRepositorioTitular repositorio)
    {
        Repositorio = repositorio;
    }
}