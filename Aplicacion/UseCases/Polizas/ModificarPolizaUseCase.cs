using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ModificarPolizaUseCase : UseCase<IRepositorioPoliza>
{
    public ModificarPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio) {
    }
    public void Ejecutar(Poliza poliza)
    {
        try {
            Repositorio.Modificar(poliza);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}