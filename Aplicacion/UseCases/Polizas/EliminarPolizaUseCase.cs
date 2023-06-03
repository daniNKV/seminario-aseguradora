
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class EliminarPolizaUseCase : PolizaUseCase
{
    public EliminarPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(int polizaId)
    {
        try {
            Repositorio.EliminarPoliza(polizaId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}