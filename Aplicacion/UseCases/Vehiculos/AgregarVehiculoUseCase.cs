using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Vehiculos;

public class AgregarVehiculoUseCase : UseCase<IRepositorioVehiculo>
{
    public AgregarVehiculoUseCase(IRepositorioVehiculo repositorio) : base(repositorio){
    }

    public void Ejecutar(Vehiculo asegurable)
    { 
        Repositorio.Agregar(asegurable);
    }
}