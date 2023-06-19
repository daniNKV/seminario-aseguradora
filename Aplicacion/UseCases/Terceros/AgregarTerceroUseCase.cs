using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Terceros;

public class AgregarTerceroUseCase : UseCase<IRepositorioTercero>
{
    public AgregarTerceroUseCase(IRepositorioTercero repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(Tercero tercero)
    {
        try {
            Repositorio.Agregar(tercero);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}