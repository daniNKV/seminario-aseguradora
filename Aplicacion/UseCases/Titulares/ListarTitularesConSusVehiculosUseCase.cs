using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ListarTitularesConSusVehiculosUseCase : UseCase<IRepositorioTitular>
{
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repositorio) : base(repositorio) 
    {
    }
    public List<Titular> Ejecutar()
    {
        return Repositorio.ListarTitularesConSusVehiculos();

    }
}