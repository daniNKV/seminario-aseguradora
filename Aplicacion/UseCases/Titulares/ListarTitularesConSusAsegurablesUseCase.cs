using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ListarTitularesConSusAsegurablesUseCase : TitularUseCase
{
    public ListarTitularesConSusAsegurablesUseCase(IRepositorioTitular repositorio) : base(repositorio) 
    {
    }
    public List<Titular> Ejecutar()
    {
        return Repositorio.ListarTitulares();

    }
}