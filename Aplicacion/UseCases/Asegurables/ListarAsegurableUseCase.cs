using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class ListarAsegurableUseCase : UseCase<IRepositorioAsegurable>
{
    public ListarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio) {
    }
    public List<Vehiculo> Ejecutar()
    {
        return Repositorio.Listar();
    }
}