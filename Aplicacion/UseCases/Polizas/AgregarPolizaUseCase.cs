using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class AgregarPolizaUseCase : PolizaUseCase
{
    public AgregarPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(Poliza poliza)
    {
        Repositorio.AgregarPoliza(poliza);
    }
}