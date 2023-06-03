using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class AgregarPolizaUseCase
{
    private readonly IRepositorioPoliza _repositorio;

    public AgregarPolizaUseCase(IRepositorioPoliza repositorio) {
        _repositorio = repositorio;
    }

    public void Ejecutar(Poliza poliza)
    {
        _repositorio.AgregarPoliza(poliza);
    }
}