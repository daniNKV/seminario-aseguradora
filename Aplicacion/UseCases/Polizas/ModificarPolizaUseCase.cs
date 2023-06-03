using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class ModificarPolizaUseCase : PolizaUseCase
{
    public ModificarPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio) {
    }
    public void Ejecutar(Poliza poliza)
    {
        try {
            Repositorio.ModificarPoliza(poliza);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}