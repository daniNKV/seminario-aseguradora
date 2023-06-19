using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Vehiculos;

public class ObtenerVehiculoUseCase : UseCase<IRepositorioVehiculo>
{
    public ObtenerVehiculoUseCase(IRepositorioVehiculo repositorio) : base(repositorio)
    {
    }
    public Vehiculo? Ejecutar(int id)
    {
        return Repositorio.Obtener(id);
    }
}