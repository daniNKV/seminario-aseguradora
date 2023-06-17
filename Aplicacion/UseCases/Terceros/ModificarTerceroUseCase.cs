using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Terceros;

public class ModificarTerceroUseCase : UseCase<IRepositorioTercero>
{
    public ModificarTerceroUseCase(IRepositorioTercero repositorio) : base(repositorio)
    {
    }
    public void Ejecutar(Tercero tercero)
    {
        try {
            Repositorio.Modificar(tercero);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}