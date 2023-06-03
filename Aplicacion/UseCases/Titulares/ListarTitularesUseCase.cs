using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ListarTitularesUseCase : TitularUseCase
{
    private readonly IRepositorioTitular _repositorio;
    public ListarTitularesUseCase(IRepositorioTitular repositorio) : base(repositorio) {
    }
    public List<Titular> Ejecutar()
    {
        return Repositorio.ListarTitulares();

    }
}