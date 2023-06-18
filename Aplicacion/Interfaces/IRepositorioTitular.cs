namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioTitular : IRepositorio<Titular>
{
    List<Vehiculo> ListarItemsAsegurados(Titular titular);
    List<Titular> ListarTitularesConSusVehiculos();
}