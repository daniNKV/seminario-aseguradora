using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ListarTitularesUseCase : UseCase<IRepositorioTitular>
{ 
    public ListarTitularesUseCase(IRepositorioTitular repositorio) : base(repositorio) {
    }
    public List<Titular> Ejecutar()
    {
        return Repositorio.Listar();
    }
}