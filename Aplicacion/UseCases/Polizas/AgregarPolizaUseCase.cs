using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class AgregarPolizaUseCase : UseCase<IRepositorioPoliza>
{
    public AgregarPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(Poliza poliza)
    {
        Repositorio.Agregar(poliza);
    }
}