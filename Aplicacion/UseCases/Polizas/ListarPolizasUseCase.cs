using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ListarPolizasUseCase
{
    private readonly IRepositorioPoliza _repositorio;
    public ListarPolizasUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }
    public List<Poliza> Ejecutar()
    {
        return _repositorio.ListarPolizas();

    }
}