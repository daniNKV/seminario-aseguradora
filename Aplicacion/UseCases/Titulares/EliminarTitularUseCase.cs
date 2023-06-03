
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class EliminarTitularUseCase : TitularUseCase
{
    public EliminarTitularUseCase(IRepositorioTitular repositorio) : base(repositorio){
    }
    public void Ejecutar(int titularId)
    {
        try {
            Repositorio.EliminarTitular(titularId);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}