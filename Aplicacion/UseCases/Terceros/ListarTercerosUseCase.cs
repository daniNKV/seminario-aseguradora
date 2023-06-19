using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Terceros;

public class ListarTercerosUseCase : UseCase<IRepositorioTercero>
{
    public ListarTercerosUseCase(IRepositorioTercero repositorio) : base(repositorio)
    {
    }
    public List<Tercero> Ejecutar()
    {
        return Repositorio.Listar();

    }
}