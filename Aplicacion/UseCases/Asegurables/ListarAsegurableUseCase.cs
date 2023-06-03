using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class ListarAsegurableUseCase : AsegurableUseCase
{
    public ListarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio) {
    }
    public List<Vehiculo> Ejecutar()
    {
        return Repositorio.ListarAsegurables();
    }
}