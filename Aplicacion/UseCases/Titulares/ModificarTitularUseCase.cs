using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ModificarTitularUseCase : UseCase<IRepositorioTitular>
{
    public ModificarTitularUseCase(IRepositorioTitular repositorio) : base(repositorio) {
    }
    public void Ejecutar(Titular titular)
    {
        try {
            Repositorio.Modificar(titular);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}