using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Vehiculos;

public class ModificarVehiculoUseCase : UseCase<IRepositorioVehiculo>
{
    public ModificarVehiculoUseCase(IRepositorioVehiculo repositorio) : base(repositorio) {
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