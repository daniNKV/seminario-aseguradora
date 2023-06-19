using Aplicacion.Interfaces;

namespace Aplicacion.UseCases;

public abstract class UseCase<T>
{
    protected T Repositorio { get; private set; }

    protected UseCase(T repositorio)
    {
        Repositorio = repositorio;
    }
}