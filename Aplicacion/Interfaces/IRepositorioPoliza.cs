namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioPoliza : IRepositorio<Poliza>
{
    Poliza? ObtenerPolizaDeVehiculo(Vehiculo vehiculo);

    Poliza? ObtenerPolizaDeSiniestro(Siniestro siniestro);
}