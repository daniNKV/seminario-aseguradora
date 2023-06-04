
using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Polizas;

public class EliminarPolizaUseCase : UseCase<IRepositorioPoliza>
{
    public EliminarPolizaUseCase(IRepositorioPoliza repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(int polizaId)
    {
        try {
            Repositorio.Eliminar(polizaId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}