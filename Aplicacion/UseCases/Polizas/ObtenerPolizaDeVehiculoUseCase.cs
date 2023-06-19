using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ObtenerPolizaDeVehiculoUseCase : UseCase<IRepositorioPoliza>
{
    public ObtenerPolizaDeVehiculoUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }

    public Poliza? Ejecutar(Vehiculo vehiculo)
    { 
        return Repositorio.ObtenerPolizaDeVehiculo(vehiculo);
    }
}