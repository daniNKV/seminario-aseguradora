  using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class EliminarTitularUseCase : UseCase<IRepositorioTitular>
{
    public EliminarTitularUseCase(IRepositorioTitular repositorio) : base(repositorio){
    }
    public void Ejecutar(int titularId)
    {
        try {
            Repositorio.Eliminar(titularId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}