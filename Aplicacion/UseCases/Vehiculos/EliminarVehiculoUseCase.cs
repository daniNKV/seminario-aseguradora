using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Vehiculos;

public class EliminarVehiculoUseCase: UseCase<IRepositorioVehiculo>
{
    public EliminarVehiculoUseCase(IRepositorioVehiculo repositorio) : base(repositorio) {
    }
    public void Ejecutar(int id)
    {
        try {
            Repositorio.Eliminar(id);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}