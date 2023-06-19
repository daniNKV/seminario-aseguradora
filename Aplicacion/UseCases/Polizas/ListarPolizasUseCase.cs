using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ListarPolizasUseCase : UseCase<IRepositorioPoliza>
{
    public ListarPolizasUseCase(IRepositorioPoliza repositorio) : base(repositorio) {
    }
    public List<Poliza> Ejecutar()
    {
        return Repositorio.Listar();

    }
}