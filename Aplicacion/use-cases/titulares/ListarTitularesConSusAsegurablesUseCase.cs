namespace Aplicacion;

public class ListarTitularesConSusAsegurablesUseCase 
{
    private readonly IRepositorioTitular _repositorio;
    public ListarTitularesConSusAsegurablesUseCase(IRepositorioTitular repositorio) {
        _repositorio = repositorio;
    }
    public List<Titular> Ejecutar()
    {
        return _repositorio.ListarTitulares();

    }
}