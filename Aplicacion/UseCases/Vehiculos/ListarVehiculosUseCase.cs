using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Vehiculos;

public class ListarVehiculosUseCase : UseCase<IRepositorioVehiculo>
{
    public ListarVehiculosUseCase(IRepositorioVehiculo repositorio) : base(repositorio) {
    }
    public List<Vehiculo> Ejecutar()
    {
        return Repositorio.Listar();
    }
}