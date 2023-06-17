using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Vehiculos;

public class ModificarVehiculosUseCase : UseCase<IRepositorioVehiculo>
{
    public ModificarVehiculosUseCase(IRepositorioVehiculo repositorio) : base(repositorio) {
    }
    public void Ejecutar(Vehiculo asegurable)
    {
        try {
            Repositorio.Modificar(asegurable);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}